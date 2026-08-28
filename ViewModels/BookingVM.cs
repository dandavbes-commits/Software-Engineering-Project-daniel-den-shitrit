using Microsoft.Data.SqlClient;
using System.Data;
using GymTimeServer.Models;

namespace GymTimeServer.ViewModels
{
    public class BookingVM : DBconnect
    {
        private const string STATUS_CANCELLED = "בוטל";

        public BookingVM(IConfiguration config) : base(config) { }

        public async Task<List<Booking>> GetByClientAsync(int clientId)
        {
            string query = @"SELECT b.BookingID, b.ClientID, b.ClassID, b.BookingDate, b.Status,
                                    t.TypeName, c.TrainerName, c.ClassDate, c.StartTime
                             FROM Bookings b
                                  INNER JOIN Classes c    ON b.ClassID = c.ClassID
                                  INNER JOIN ClassTypes t ON c.TypeID  = t.TypeID
                             WHERE b.ClientID = @ClientID
                             ORDER BY c.ClassDate DESC, c.StartTime DESC";

            using (SqlConnection con = await OpenConnectionAsync())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = clientId;
                return await ReadBookingsAsync(cmd);
            }
        }

        public async Task<List<Booking>> GetByClassAsync(int classId)
        {
            string query = @"SELECT b.BookingID, b.ClientID, b.ClassID, b.BookingDate, b.Status,
                                    cl.FullName AS ClientName, cl.Phone AS ClientPhone,
                                    t.TypeName, c.TrainerName, c.ClassDate, c.StartTime
                             FROM Bookings b
                                  INNER JOIN Clients cl   ON b.ClientID = cl.ClientID
                                  INNER JOIN Classes c    ON b.ClassID  = c.ClassID
                                  INNER JOIN ClassTypes t ON c.TypeID   = t.TypeID
                             WHERE b.ClassID = @ClassID
                             ORDER BY b.BookingDate";

            using (SqlConnection con = await OpenConnectionAsync())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = classId;
                return await ReadBookingsAsync(cmd);
            }
        }

        // הזמנה מבוטלת לא נחשבת, כדי שאפשר יהיה להירשם שוב
        public async Task<bool> HasActiveBookingAsync(int clientId, int classId)
        {
            string query = @"SELECT COUNT(*)
                             FROM Bookings
                             WHERE ClientID = @ClientID
                               AND ClassID = @ClassID
                               AND Status <> @Cancelled";

            using (SqlConnection con = await OpenConnectionAsync())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = clientId;
                cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = classId;
                cmd.Parameters.Add("@Cancelled", SqlDbType.NVarChar, 10).Value = STATUS_CANCELLED;

                object? result = await cmd.ExecuteScalarAsync();
                return Convert.ToInt32(result) > 0;
            }
        }

        // אם כבר יש שורה מבוטלת מעדכנים אותה, אחרת האילוץ UNIQUE נשבר
        public async Task<int> AddAsync(Booking b)
        {
            string query = @"IF EXISTS (SELECT 1 FROM Bookings
                                        WHERE ClientID = @ClientID AND ClassID = @ClassID)
                             BEGIN
                                 UPDATE Bookings
                                 SET Status = @Status, BookingDate = @BookingDate
                                 WHERE ClientID = @ClientID AND ClassID = @ClassID;

                                 SELECT BookingID FROM Bookings
                                 WHERE ClientID = @ClientID AND ClassID = @ClassID;
                             END
                             ELSE
                             BEGIN
                                 INSERT INTO Bookings (ClientID, ClassID, BookingDate, Status)
                                 VALUES (@ClientID, @ClassID, @BookingDate, @Status);

                                 SELECT SCOPE_IDENTITY();
                             END";

            using (SqlConnection con = await OpenConnectionAsync())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@ClientID", SqlDbType.Int).Value = b.ClientID;
                cmd.Parameters.Add("@ClassID", SqlDbType.Int).Value = b.ClassID;
                cmd.Parameters.Add("@BookingDate", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 10).Value = b.Status;

                object? newId = await cmd.ExecuteScalarAsync();
                return Convert.ToInt32(newId);
            }
        }

        public async Task<Booking?> GetByIdAsync(int bookingId)
        {
            string query = @"SELECT b.BookingID, b.ClientID, b.ClassID, b.BookingDate, b.Status,
                                    cl.FullName AS ClientName, cl.Phone AS ClientPhone,
                                    t.TypeName, c.TrainerName, c.ClassDate, c.StartTime
                             FROM Bookings b
                                  INNER JOIN Clients cl   ON b.ClientID = cl.ClientID
                                  INNER JOIN Classes c    ON b.ClassID  = c.ClassID
                                  INNER JOIN ClassTypes t ON c.TypeID   = t.TypeID
                             WHERE b.BookingID = @BookingID";

            using (SqlConnection con = await OpenConnectionAsync())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@BookingID", SqlDbType.Int).Value = bookingId;
                List<Booking> list = await ReadBookingsAsync(cmd);
                return list.Count > 0 ? list[0] : null;
            }
        }

        public async Task<bool> UpdateStatusAsync(int bookingId, string newStatus)
        {
            string query = "UPDATE Bookings SET Status = @Status WHERE BookingID = @BookingID";

            using (SqlConnection con = await OpenConnectionAsync())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 10).Value = newStatus;
                cmd.Parameters.Add("@BookingID", SqlDbType.Int).Value = bookingId;

                int rows = await cmd.ExecuteNonQueryAsync();
                return rows > 0;
            }
        }

        private async Task<List<Booking>> ReadBookingsAsync(SqlCommand cmd)
        {
            List<Booking> list = new List<Booking>();

            using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
            {
                // GetByClientAsync לא מחזירה את שם הלקוח
                bool hasClientName = HasColumn(reader, "ClientName");

                while (await reader.ReadAsync())
                {
                    Booking b = new Booking();
                    b.BookingID = Convert.ToInt32(reader["BookingID"]);
                    b.ClientID = Convert.ToInt32(reader["ClientID"]);
                    b.ClassID = Convert.ToInt32(reader["ClassID"]);
                    b.BookingDate = Convert.ToDateTime(reader["BookingDate"]);
                    b.Status = reader["Status"].ToString() ?? "";
                    b.TypeName = reader["TypeName"].ToString() ?? "";
                    b.TrainerName = reader["TrainerName"].ToString() ?? "";
                    b.ClassDate = Convert.ToDateTime(reader["ClassDate"]);
                    b.StartTime = (TimeSpan)reader["StartTime"];

                    if (hasClientName)
                    {
                        b.ClientName = reader["ClientName"].ToString() ?? "";
                        b.ClientPhone = reader["ClientPhone"].ToString() ?? "";
                    }
                    list.Add(b);
                }
            }
            return list;
        }

        private bool HasColumn(SqlDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i) == columnName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
