using GymTimeClient.Models;
using GymTimeClient.Service;

namespace GymTimeClient.Forms
{
    public partial class FormClientMain : Form
    {
        // שומרים את הרשימות גם כאן כדי לקחת את ה-ID של השורה שנבחרה
        private List<GymClass> schedule = new List<GymClass>();
        private List<Booking> myBookings = new List<Booking>();

        public FormClientMain()
        {
            InitializeComponent();
        }

        private async void FormClientMain_Load(object sender, EventArgs e)
        {
            if (ApiService.CurrentUser != null)
            {
                lblWelcome.Text = "שלום " + ApiService.CurrentUser.FullName;
            }

            await LoadScheduleAsync();
            await LoadMyBookingsAsync();
        }

        private async Task LoadScheduleAsync()
        {
            try
            {
                lblStatus.Text = "טוען לוח שיעורים...";

                schedule = await ApiService.GetScheduleAsync();

                // בלי ה-null הטבלה לא מתרעננת
                dgvSchedule.DataSource = null;
                dgvSchedule.AutoGenerateColumns = false;
                dgvSchedule.DataSource = schedule;

                lblStatus.Text = "נמצאו " + schedule.Count + " שיעורים";
            }
            catch (HttpRequestException)
            {
                lblStatus.Text = "אין חיבור לשרת";
            }
        }

        private async Task LoadMyBookingsAsync()
        {
            if (ApiService.CurrentUser == null)
            {
                return;
            }

            try
            {
                myBookings = await ApiService.GetMyBookingsAsync(ApiService.CurrentUser.ClientID);

                dgvMyBookings.DataSource = null;
                dgvMyBookings.AutoGenerateColumns = false;
                dgvMyBookings.DataSource = myBookings;

                ColorBookingRows();
            }
            catch (HttpRequestException)
            {
                lblStatus.Text = "אין חיבור לשרת";
            }
        }

        private void ColorBookingRows()
        {
            for (int i = 0; i < dgvMyBookings.Rows.Count; i++)
            {
                string status = myBookings[i].Status;

                if (status == "אושר")
                {
                    dgvMyBookings.Rows[i].DefaultCellStyle.BackColor =
                        System.Drawing.Color.FromArgb(225, 245, 225);
                }
                else if (status == "בוטל")
                {
                    dgvMyBookings.Rows[i].DefaultCellStyle.BackColor =
                        System.Drawing.Color.FromArgb(250, 225, 225);
                }
                else
                {
                    dgvMyBookings.Rows[i].DefaultCellStyle.BackColor =
                        System.Drawing.Color.FromArgb(255, 248, 220);
                }
            }
        }

        private async void btnBook_Click(object sender, EventArgs e)
        {
            if (dgvSchedule.CurrentRow == null || dgvSchedule.CurrentRow.Index < 0)
            {
                MessageBox.Show("יש לבחור שיעור מהרשימה", "שימו לב",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GymClass selected = schedule[dgvSchedule.CurrentRow.Index];

            if (selected.FreePlaces <= 0)
            {
                MessageBox.Show("השיעור מלא", "אין מקום",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult answer = MessageBox.Show(
                "להזמין מקום בשיעור " + selected.TypeName +
                " בתאריך " + selected.DateText + " בשעה " + selected.TimeText + "?",
                "אישור הזמנה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
            {
                return;
            }

            btnBook.Enabled = false;

            try
            {
                ActionResultMsg result = await ApiService.BookClassAsync(
                    ApiService.CurrentUser!.ClientID, selected.ClassID);

                MessageBox.Show(result.Message,
                                result.Success ? "הזמנה בוצעה" : "ההזמנה נכשלה",
                                MessageBoxButtons.OK,
                                result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                if (result.Success)
                {
                    // גם מספר המקומות הפנויים השתנה
                    await LoadScheduleAsync();
                    await LoadMyBookingsAsync();
                }
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("אין חיבור לשרת", "שגיאה",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnBook.Enabled = true;
            }
        }

        private async void btnCancelBooking_Click(object sender, EventArgs e)
        {
            if (dgvMyBookings.CurrentRow == null || dgvMyBookings.CurrentRow.Index < 0)
            {
                MessageBox.Show("יש לבחור הזמנה מהרשימה", "שימו לב",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Booking selected = myBookings[dgvMyBookings.CurrentRow.Index];

            if (selected.Status == "בוטל")
            {
                MessageBox.Show("ההזמנה כבר מבוטלת", "שימו לב",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult answer = MessageBox.Show(
                "לבטל את ההזמנה לשיעור " + selected.TypeName + "?",
                "אישור ביטול", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
            {
                return;
            }

            btnCancelBooking.Enabled = false;

            try
            {
                ActionResultMsg result = await ApiService.CancelMyBookingAsync(
                    selected.BookingID, ApiService.CurrentUser!.ClientID);

                MessageBox.Show(result.Message,
                                result.Success ? "בוטל" : "הביטול נכשל",
                                MessageBoxButtons.OK,
                                result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                if (result.Success)
                {
                    await LoadMyBookingsAsync();
                    await LoadScheduleAsync();
                }
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("אין חיבור לשרת", "שגיאה",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnCancelBooking.Enabled = true;
            }
        }

        private async void btnRefreshSchedule_Click(object sender, EventArgs e)
        {
            await LoadScheduleAsync();
        }

        private async void btnRefreshBookings_Click(object sender, EventArgs e)
        {
            await LoadMyBookingsAsync();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
