using Microsoft.Data.SqlClient;

namespace GymTimeServer.ViewModels
{
    // מחלקת בסיס לכל ה-ViewModel, שומרת את מחרוזת החיבור במקום אחד
    public class DBconnect
    {
        protected string connectionString;

        public DBconnect(IConfiguration config)
        {
            connectionString = config.GetConnectionString("GymTimeDB") ?? "";
        }

        protected async Task<SqlConnection> OpenConnectionAsync()
        {
            SqlConnection con = new SqlConnection(connectionString);
            await con.OpenAsync();
            return con;
        }
    }
}
