using Microsoft.Data.SqlClient;
using System.Data;
using GymTimeServer.Models;

namespace GymTimeServer.ViewModels
{
    public class ClassTypeVM : DBconnect
    {
        public ClassTypeVM(IConfiguration config) : base(config) { }

        public async Task<List<ClassType>> GetAllAsync()
        {
            List<ClassType> list = new List<ClassType>();

            string query = @"SELECT TypeID, TypeName, TypeDescription, DurationMinutes
                             FROM ClassTypes
                             ORDER BY TypeName";

            using (SqlConnection con = await OpenConnectionAsync())
            using (SqlCommand cmd = new SqlCommand(query, con))
            using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    ClassType t = new ClassType();
                    t.TypeID = Convert.ToInt32(reader["TypeID"]);
                    t.TypeName = reader["TypeName"].ToString() ?? "";
                    t.TypeDescription = reader["TypeDescription"] == DBNull.Value
                                        ? "" : reader["TypeDescription"].ToString()!;
                    t.DurationMinutes = Convert.ToInt32(reader["DurationMinutes"]);
                    list.Add(t);
                }
            }
            return list;
        }

        public async Task<int> AddAsync(ClassType t)
        {
            string query = @"INSERT INTO ClassTypes (TypeName, TypeDescription, DurationMinutes)
                             VALUES (@Name, @Description, @Duration);
                             SELECT SCOPE_IDENTITY();";

            using (SqlConnection con = await OpenConnectionAsync())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = t.TypeName;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 200).Value = t.TypeDescription;
                cmd.Parameters.Add("@Duration", SqlDbType.Int).Value = t.DurationMinutes;

                object? newId = await cmd.ExecuteScalarAsync();
                return Convert.ToInt32(newId);
            }
        }

        public async Task<bool> UpdateAsync(ClassType t)
        {
            string query = @"UPDATE ClassTypes
                             SET TypeName = @Name,
                                 TypeDescription = @Description,
                                 DurationMinutes = @Duration
                             WHERE TypeID = @TypeID";

            using (SqlConnection con = await OpenConnectionAsync())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = t.TypeName;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 200).Value = t.TypeDescription;
                cmd.Parameters.Add("@Duration", SqlDbType.Int).Value = t.DurationMinutes;
                cmd.Parameters.Add("@TypeID", SqlDbType.Int).Value = t.TypeID;

                int rows = await cmd.ExecuteNonQueryAsync();
                return rows > 0;
            }
        }

        // כמה שיעורים משתמשים בסוג הזה - בודקים לפני מחיקה
        public async Task<int> CountClassesOfTypeAsync(int typeId)
        {
            string query = "SELECT COUNT(*) FROM Classes WHERE TypeID = @TypeID";

            using (SqlConnection con = await OpenConnectionAsync())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@TypeID", SqlDbType.Int).Value = typeId;
                object? result = await cmd.ExecuteScalarAsync();
                return Convert.ToInt32(result);
            }
        }

        public async Task<bool> DeleteAsync(int typeId)
        {
            string query = "DELETE FROM ClassTypes WHERE TypeID = @TypeID";

            using (SqlConnection con = await OpenConnectionAsync())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@TypeID", SqlDbType.Int).Value = typeId;
                int rows = await cmd.ExecuteNonQueryAsync();
                return rows > 0;
            }
        }
    }
}
