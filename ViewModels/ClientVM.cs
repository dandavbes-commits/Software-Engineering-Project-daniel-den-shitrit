using Microsoft.Data.SqlClient;
using System.Data;
using GymTimeServer.Models;

namespace GymTimeServer.ViewModels
{
    public class ClientVM : DBconnect
    {
        public ClientVM(IConfiguration config) : base(config) { }

        // מחזיר null אם השם או הסיסמה לא נכונים
        public async Task<Client?> LoginAsync(string userName, string passwordHash)
        {
            string query = @"SELECT ClientID, FullName, Phone, Email, UserName,
                                    IsManager, JoinDate
                             FROM Clients
                             WHERE UserName = @UserName AND UserPassword = @Password";

            using (SqlConnection con = await OpenConnectionAsync())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 30).Value = userName;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 64).Value = passwordHash;

                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return ReadClient(reader);
                    }
                }
            }
            return null;
        }

        public async Task<bool> IsUserNameTakenAsync(string userName)
        {
            string query = "SELECT COUNT(*) FROM Clients WHERE UserName = @UserName";

            using (SqlConnection con = await OpenConnectionAsync())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 30).Value = userName;
                object? result = await cmd.ExecuteScalarAsync();
                return Convert.ToInt32(result) > 0;
            }
        }

        public async Task<int> AddClientAsync(Client c)
        {
            string query = @"INSERT INTO Clients
                                (FullName, Phone, Email, UserName, UserPassword, IsManager, JoinDate)
                             VALUES
                                (@FullName, @Phone, @Email, @UserName, @Password, @IsManager, @JoinDate);
                             SELECT SCOPE_IDENTITY();";

            using (SqlConnection con = await OpenConnectionAsync())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@FullName", SqlDbType.NVarChar, 60).Value = c.FullName;
                cmd.Parameters.Add("@Phone", SqlDbType.NVarChar, 15).Value = c.Phone;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 80).Value = c.Email;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 30).Value = c.UserName;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 64).Value = c.UserPassword;
                cmd.Parameters.Add("@IsManager", SqlDbType.Bit).Value = c.IsManager;
                cmd.Parameters.Add("@JoinDate", SqlDbType.Date).Value = DateTime.Today;

                object? newId = await cmd.ExecuteScalarAsync();
                return Convert.ToInt32(newId);
            }
        }

        public async Task<List<Client>> GetAllClientsAsync()
        {
            List<Client> list = new List<Client>();

            string query = @"SELECT ClientID, FullName, Phone, Email, UserName,
                                    IsManager, JoinDate
                             FROM Clients
                             ORDER BY FullName";

            using (SqlConnection con = await OpenConnectionAsync())
            using (SqlCommand cmd = new SqlCommand(query, con))
            using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    list.Add(ReadClient(reader));
                }
            }
            return list;
        }

        private Client ReadClient(SqlDataReader reader)
        {
            Client c = new Client();
            c.ClientID = Convert.ToInt32(reader["ClientID"]);
            c.FullName = reader["FullName"].ToString() ?? "";
            c.Phone = reader["Phone"].ToString() ?? "";
            c.Email = reader["Email"] == DBNull.Value ? "" : reader["Email"].ToString()!;
            c.UserName = reader["UserName"].ToString() ?? "";
            c.IsManager = Convert.ToBoolean(reader["IsManager"]);
            c.JoinDate = Convert.ToDateTime(reader["JoinDate"]);
            return c;   // בלי הסיסמה
        }
    }
}
