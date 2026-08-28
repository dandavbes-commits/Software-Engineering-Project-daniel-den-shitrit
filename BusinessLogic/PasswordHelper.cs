using System.Security.Cryptography;
using System.Text;

namespace GymTimeServer.BusinessLogic
{
    // הסיסמה עצמה לא נשמרת במסד, רק ה-Hash שלה
    public static class PasswordHelper
    {
        public static string Hash(string password)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = SHA256.HashData(bytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
