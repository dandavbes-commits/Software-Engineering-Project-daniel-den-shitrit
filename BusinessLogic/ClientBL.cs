using GymTimeServer.Models;
using GymTimeServer.ViewModels;

namespace GymTimeServer.BusinessLogic
{
    public class ClientBL
    {
        private ClientVM clientVM;

        public ClientBL(IConfiguration config)
        {
            clientVM = new ClientVM(config);
        }

        public async Task<Client?> LoginAsync(LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.UserName) ||
                string.IsNullOrWhiteSpace(request.Password))
            {
                return null;
            }

            string hash = PasswordHelper.Hash(request.Password);
            return await clientVM.LoginAsync(request.UserName.Trim(), hash);
        }

        public async Task<ActionResultMsg> RegisterAsync(Client c)
        {
            if (string.IsNullOrWhiteSpace(c.FullName) || c.FullName.Trim().Length < 2)
            {
                return new ActionResultMsg(false, "יש להזין שם מלא");
            }

            if (!IsValidPhone(c.Phone))
            {
                return new ActionResultMsg(false, "מספר טלפון לא תקין");
            }

            if (string.IsNullOrWhiteSpace(c.UserName) || c.UserName.Trim().Length < 3)
            {
                return new ActionResultMsg(false, "שם המשתמש חייב להיות באורך 3 תווים לפחות");
            }

            if (c.UserPassword.Length < 6)
            {
                return new ActionResultMsg(false, "הסיסמה חייבת להיות באורך 6 תווים לפחות");
            }

            if (await clientVM.IsUserNameTakenAsync(c.UserName.Trim()))
            {
                return new ActionResultMsg(false, "שם המשתמש כבר תפוס, יש לבחור שם אחר");
            }

            // מנהל אפשר להוסיף רק ישירות במסד
            c.IsManager = false;
            c.FullName = c.FullName.Trim();
            c.UserName = c.UserName.Trim();
            c.UserPassword = PasswordHelper.Hash(c.UserPassword);

            int newId = await clientVM.AddClientAsync(c);

            if (newId > 0)
            {
                return new ActionResultMsg(true, "ההרשמה הושלמה, אפשר להתחבר");
            }
            return new ActionResultMsg(false, "ההרשמה נכשלה, יש לנסות שוב");
        }

        public async Task<List<Client>> GetAllClientsAsync()
        {
            return await clientVM.GetAllClientsAsync();
        }

        // 9 או 10 ספרות, מתעלם ממקפים ורווחים
        private bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                return false;
            }

            string digitsOnly = "";
            foreach (char ch in phone)
            {
                if (char.IsDigit(ch))
                {
                    digitsOnly += ch;
                }
                else if (ch != '-' && ch != ' ')
                {
                    return false;
                }
            }
            return digitsOnly.Length == 9 || digitsOnly.Length == 10;
        }
    }
}
