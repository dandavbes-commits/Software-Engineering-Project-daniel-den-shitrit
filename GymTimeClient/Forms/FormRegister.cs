using GymTimeClient.Models;
using GymTimeClient.Service;

namespace GymTimeClient.Forms
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            // בדיקות מהירות כאן, השרת בודק הכל שוב
            if (txtFullName.Text.Trim() == "")
            {
                lblMessage.Text = "יש להזין שם מלא";
                txtFullName.Focus();
                return;
            }

            if (txtPassword.Text != txtConfirm.Text)
            {
                lblMessage.Text = "הסיסמאות אינן זהות";
                txtConfirm.Text = "";
                txtConfirm.Focus();
                return;
            }

            if (txtPassword.Text.Length < 6)
            {
                lblMessage.Text = "הסיסמה חייבת להיות באורך 6 תווים לפחות";
                txtPassword.Focus();
                return;
            }

            Client newClient = new Client();
            newClient.FullName = txtFullName.Text.Trim();
            newClient.Phone = txtPhone.Text.Trim();
            newClient.Email = txtEmail.Text.Trim();
            newClient.UserName = txtUserName.Text.Trim();
            newClient.UserPassword = txtPassword.Text;

            btnSave.Enabled = false;

            try
            {
                ActionResultMsg result = await ApiService.RegisterAsync(newClient);

                if (result.Success)
                {
                    MessageBox.Show(result.Message, "הרשמה הושלמה",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    lblMessage.Text = result.Message;
                }
            }
            catch (HttpRequestException)
            {
                lblMessage.Text = "אין חיבור לשרת";
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
