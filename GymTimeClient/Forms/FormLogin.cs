using GymTimeClient.Models;
using GymTimeClient.Service;

namespace GymTimeClient.Forms
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            if (txtUserName.Text.Trim() == "" || txtPassword.Text == "")
            {
                lblMessage.Text = "יש למלא שם משתמש וסיסמה";
                return;
            }

            // נועלים את הכפתור כדי שלא ילחצו כמה פעמים
            btnLogin.Enabled = false;
            btnLogin.Text = "מתחבר...";

            try
            {
                Client? user = await ApiService.LoginAsync(txtUserName.Text.Trim(),
                                                           txtPassword.Text);

                if (user == null)
                {
                    lblMessage.Text = "שם משתמש או סיסמה שגויים";
                    txtPassword.Text = "";
                    return;
                }

                ApiService.CurrentUser = user;
                this.Hide();

                Form mainForm;
                if (user.IsManager)
                {
                    mainForm = new FormManagerMain();
                }
                else
                {
                    mainForm = new FormClientMain();
                }

                mainForm.ShowDialog();

                // חוזרים לכאן כשסוגרים, מאפסים כדי שאפשר יהיה להתחבר עם משתמש אחר
                ApiService.CurrentUser = null;
                txtUserName.Text = "";
                txtPassword.Text = "";
                this.Show();
            }
            catch (HttpRequestException)
            {
                lblMessage.Text = "אין חיבור לשרת. יש לוודא שהשרת פועל";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "שגיאה: " + ex.Message;
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "התחברות";
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            FormRegister f = new FormRegister();
            f.ShowDialog();
        }
    }
}
