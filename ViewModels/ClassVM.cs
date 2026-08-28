using Microsoft.Data.SqlClient;
using System.Data;
using GymTimeServer.Models;

namespace GymTimeServer.ViewModels
{
    public class ClassVM : DBconnect
    {
        private const string STATUS_CANCELLED = "בוטל";

        public ClassVM(IConfiguration config) : base(config) { }

        // תת-השאילתה סופרת כמה מקומות כבר נתפסו בכל שיעור
        public async Task<List<GymClass>> GetScheduleAsync(DateTime fromDate)
        {
            List<GymClass> list = new List<GymClass>();

            string query = @"SELECT c.ClassID, c.TypeID, c.TrainerName, c.ClassDate,
                                    c.StartTime, c.MaxParticipants, c.RoomName, c.IsCancelled,
                                    t.TypeName, t.DurationMinutes,
                                    (SELECT COUNT(*)
                                     FROM Bookings b
                                     WHERE b.ClassID = c.ClassID
                                       AND b.Status <> @Cancelled) AS TakenPlaces
                             FROM Classes c
                                  INNER JOIN ClassTypes t ON c.TypeID = t.TypeID
                             WHERE c.ClassDate >= @FromDate
                             ORDER BY c.ClassDate, c.StartTime";

            using (SqlConnection con = await OpenConnectionAsync())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = fromDate.Date;
                cmd.Parameters.Add("@Cancelled", SqlDbType.NVarChar, 10).Value = STATUS_CANCELLED;

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(ReadClass(reader));
                    }
                }
            }
            return list;
        }

        public async Task<GymClass?> GetByIdAsync(int classId)
        {
            string query = @"SELECT c.ClassID, c.TypeID, c.TrainerName, c.ClassDate,
                                    c.StartTime, c.MaxParticipants, c.RoomName, c.IsCancelled,
                                    t.TypeName, t.DurationMinutes,
                                    (SELECT COUNT(*)
                                     FROM Bookings b
                                     WHERE b.ClassID = c.ClassID
                                       AND b.Status <> @Cancelled) AS TakenPlaces
                             FROM Classes c
                                  INNER JOIN ClassTypes t ON c.TypeID = t.TypeID
                             WHERE c.ClassID = @ClassID";

            using (SqlConnection con = await OpenConnectionAsync())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = classId;
                cmd.Parameters.Add("@Cancelled", SqlDbType.NVarChar, 10).Value = STATUS_CANCELLED;

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return ReadClass(reader);
                    }
                }
            }
            return null;
        }

        // excludeClassId - כדי ששיעור בעריכה לא יתנגש עם עצמו
        public async Task<bool> IsRoomBusyAsync(DateTime date, TimeSpan time,
                                                string room, int excludeClassId)
        {
            string query = @"SELECT COUNT(*)
                             FROM Classes
                             WHERE ClassDate = @Date
                               AND StartTime = @Time
                               AND RoomName = @Room
                               AND ClassID <> @ExcludeID";

            using (SqlConnection con = await OpenConnectionAsync())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@Date", SqlDbType.Date).Value = date.Date;
                cmd.Parameters.Add("@Time", SqlDbType.Time).Value = time;
                cmd.Parameters.Add("@Room", SqlDbType.NVarChar, 30).Value = room;
                cmd.Parameters.Add("@ExcludeID", SqlDbType.Int).Value = excludeClassId;

                object? result = await cmd.ExecuteScalarAsync();
                return Convert.ToInt32(result) > 0;
            }
        }

        public async Task<int> AddAsync(GymClass gc)
        {
            string query = @"INSERT INTO Classes
                                (TypeID, TrainerName, ClassDate, StartTime,
                                 MaxParticipants, RoomName, IsCancelled)
                             VALUES
                                (@TypeID, @Trainer, @Date, @Time, @Max, @Room, 0);
                             SELECT SCOPE_IDENTITY();";

            using (SqlConnection con = await OpenConnectionAsync())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                AddClassParameters(cmd, gc);
                object? newId = await cmd.ExecuteScalarAsync();
                return Convert.ToInt32(newId);
            }
        }

        public async Task<bool> UpdateAsync(GymClass gc)
        {
            string query = @"UPDATE Classes
                             SET TypeID = @TypeID,
                                 TrainerName = @Trainer,
                                 ClassDate = @Date,
                                 StartTime = @Time,
                                 MaxParticipants = @Max,
                                 RoomName = @Room
                             WHERE ClassID = @ClassID";

            using (SqlConnection con = await OpenConnectionAsync())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                AddClassParameters(cmd, gc);
                cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = gc.ClassID;

                int rows = await cmd.ExecuteNonQueryAsync();
                return rows > 0;
            }
        }

        // לא מוחקים את השיעור, רק מסמנים ומבטלים את ההזמנות שלו
        public async Task<bool> CancelClassAsync(int classId)
        {
            string query = @"UPDATE Classes SET IsCancelled = 1 WHERE ClassID = @ClassID;
                             UPDATE Bookings SET Status = @Cancelled WHERE ClassID = @ClassID;";

            using (SqlConnection con = await OpenConnectionAsync())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = classId;
                cmd.Parameters.Add("@Cancelled", SqlDbType.NVarChar, 10).Value = STATUS_CANCELLED;

                int rows = await cmd.ExecuteNonQueryAsync();
                return rows > 0;
            }
        }

        private void AddClassParameters(SqlCommand cmd, GymClass gc)
        {
            cmd.Parameters.Add("@TypeID", SqlDbType.Int).Value = gc.TypeID;
            cmd.Parameters.Add("@Trainer", SqlDbType.NVarChar, 60).Value = gc.TrainerName;
            cmd.Parameters.Add("@Date", SqlDbType.Date).Value = gc.ClassDate.Date;
            cmd.Parameters.Add("@Time", SqlDbType.Time).Value = gc.StartTime;
            cmd.Parameters.Add("@Max", SqlDbType.Int).Value = gc.MaxParticipants;
            cmd.Parameters.Add("@Room", SqlDbType.NVarChar, 30).Value = gc.RoomName;
        }

        private GymClass ReadClass(SqlDataReader reader)
        {
            GymClass gc = new GymClass();
            gc.ClassID = Convert.ToInt32(reader["ClassID"]);
            gc.TypeID = Convert.ToInt32(reader["TypeID"]);
            gc.TrainerName = reader["TrainerName"].ToString() ?? "";
            gc.ClassDate = Convert.ToDateTime(reader["ClassDate"]);
            gc.StartTime = (TimeSpan)reader["StartTime"];
            gc.MaxParticipants = Convert.ToInt32(reader["MaxParticipants"]);
            gc.RoomName = reader["RoomName"].ToString() ?? "";
            gc.IsCancelled = Convert.ToBoolean(reader["IsCancelled"]);
            gc.TypeName = reader["TypeName"].ToString() ?? "";
            gc.DurationMinutes = Convert.ToInt32(reader["DurationMinutes"]);
            gc.TakenPlaces = Convert.ToInt32(reader["TakenPlaces"]);
            return gc;
        }
    }
}
