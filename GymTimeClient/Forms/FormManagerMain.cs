using GymTimeClient.Models;
using GymTimeClient.Service;

namespace GymTimeClient.Forms
{
    public partial class FormManagerMain : Form
    {
        private List<ClassType> types = new List<ClassType>();
        private List<GymClass> classes = new List<GymClass>();
        private List<Booking> participants = new List<Booking>();

        // חוסם את האירועים של הטבלאות בזמן שממלאים אותן,
        // אחרת מקבלים שגיאת אינדקס מחוץ לתחום
        private bool isLoading = false;

        public FormManagerMain()
        {
            InitializeComponent();
        }

        private async void FormManagerMain_Load(object sender, EventArgs e)
        {
            if (ApiService.CurrentUser != null)
            {
                lblWelcome.Text = "אזור ניהול - " + ApiService.CurrentUser.FullName;
            }

            dtpClassDate.MinDate = DateTime.Today;
            dtpClassDate.Value = DateTime.Today;
            dtpClassTime.Value = DateTime.Today.AddHours(18);

            await LoadTypesAsync();
            await LoadClassesAsync();
        }

        // ==================== סוגי שיעורים ====================

        private async Task LoadTypesAsync()
        {
            try
            {
                isLoading = true;

                types = await ApiService.GetTypesAsync();

                dgvTypes.DataSource = null;
                dgvTypes.AutoGenerateColumns = false;
                dgvTypes.DataSource = types;

                cmbClassType.DataSource = null;
                cmbClassType.DataSource = types;

                lblStatus.Text = "קיימים " + types.Count + " סוגי שיעורים";
            }
            catch (HttpRequestException)
            {
                lblStatus.Text = "אין חיבור לשרת";
            }
            finally
            {
                isLoading = false;
            }
        }

        private void dgvTypes_SelectionChanged(object sender, EventArgs e)
        {
            if (isLoading || dgvTypes.CurrentRow == null)
            {
                return;
            }

            int index = dgvTypes.CurrentRow.Index;
            if (index < 0 || index >= types.Count)
            {
                return;
            }

            ClassType t = types[index];
            txtTypeName.Text = t.TypeName;
            txtTypeDesc.Text = t.TypeDescription;
            numTypeDuration.Value = t.DurationMinutes;
        }

        private async void btnAddType_Click(object sender, EventArgs e)
        {
            if (txtTypeName.Text.Trim() == "")
            {
                MessageBox.Show("יש להזין שם לסוג השיעור", "שימו לב",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ClassType t = new ClassType();
            t.TypeName = txtTypeName.Text.Trim();
            t.TypeDescription = txtTypeDesc.Text.Trim();
            t.DurationMinutes = (int)numTypeDuration.Value;

            ActionResultMsg result = await ApiService.AddTypeAsync(t);
            ShowResult(result);

            if (result.Success)
            {
                ClearTypeFields();
                await LoadTypesAsync();
            }
        }

        private async void btnUpdateType_Click(object sender, EventArgs e)
        {
            ClassType? selected = GetSelectedType();
            if (selected == null)
            {
                return;
            }

            selected.TypeName = txtTypeName.Text.Trim();
            selected.TypeDescription = txtTypeDesc.Text.Trim();
            selected.DurationMinutes = (int)numTypeDuration.Value;

            ActionResultMsg result = await ApiService.UpdateTypeAsync(selected);
            ShowResult(result);

            if (result.Success)
            {
                await LoadTypesAsync();
            }
        }

        private async void btnDeleteType_Click(object sender, EventArgs e)
        {
            ClassType? selected = GetSelectedType();
            if (selected == null)
            {
                return;
            }

            DialogResult answer = MessageBox.Show(
                "למחוק את סוג השיעור " + selected.TypeName + "?",
                "אישור מחיקה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
            {
                return;
            }

            ActionResultMsg result = await ApiService.DeleteTypeAsync(selected.TypeID);
            ShowResult(result);

            if (result.Success)
            {
                ClearTypeFields();
                await LoadTypesAsync();
            }
        }

        private ClassType? GetSelectedType()
        {
            if (dgvTypes.CurrentRow == null || dgvTypes.CurrentRow.Index < 0)
            {
                MessageBox.Show("יש לבחור סוג שיעור מהטבלה", "שימו לב",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            return types[dgvTypes.CurrentRow.Index];
        }

        private void ClearTypeFields()
        {
            txtTypeName.Text = "";
            txtTypeDesc.Text = "";
            numTypeDuration.Value = 45;
        }

        // ==================== לוח שיעורים ====================

        private async Task LoadClassesAsync()
        {
            try
            {
                isLoading = true;

                classes = await ApiService.GetManagerScheduleAsync(DateTime.Today);

                dgvClasses.DataSource = null;
                dgvClasses.AutoGenerateColumns = false;
                dgvClasses.DataSource = classes;

                FillClassPicker();

                lblStatus.Text = "בלוח יש " + classes.Count + " שיעורים";
            }
            catch (HttpRequestException)
            {
                lblStatus.Text = "אין חיבור לשרת";
            }
            finally
            {
                isLoading = false;
            }

            // חייב להיות אחרי ש-isLoading חזר ל-false,
            // אחרת האירועים חסומים והמסכים נשארים ריקים
            await LoadParticipantsAsync();
            ShowSelectedClassInFields();
        }

        private void FillClassPicker()
        {
            cmbClassPicker.Items.Clear();

            foreach (GymClass gc in classes)
            {
                string text = gc.TypeName + " | " + gc.DateText + " | " + gc.TimeText +
                              " | " + gc.TrainerName;
                cmbClassPicker.Items.Add(text);
            }

            if (cmbClassPicker.Items.Count > 0)
            {
                cmbClassPicker.SelectedIndex = 0;
            }
        }

        private void dgvClasses_SelectionChanged(object sender, EventArgs e)
        {
            if (isLoading)
            {
                return;
            }
            ShowSelectedClassInFields();
        }

        private void ShowSelectedClassInFields()
        {
            if (dgvClasses.CurrentRow == null)
            {
                return;
            }

            int index = dgvClasses.CurrentRow.Index;
            if (index < 0 || index >= classes.Count)
            {
                return;
            }

            GymClass gc = classes[index];
            txtTrainer.Text = gc.TrainerName;
            txtRoom.Text = gc.RoomName;
            numMaxParticipants.Value = gc.MaxParticipants;

            // תאריך שעבר לא יכול להיכנס ל-DateTimePicker בגלל MinDate
            if (gc.ClassDate.Date >= dtpClassDate.MinDate.Date)
            {
                dtpClassDate.Value = gc.ClassDate.Date;
            }
            dtpClassTime.Value = DateTime.Today.Add(gc.StartTime);

            for (int i = 0; i < types.Count; i++)
            {
                if (types[i].TypeID == gc.TypeID)
                {
                    cmbClassType.SelectedIndex = i;
                    break;
                }
            }
        }

        private async void btnAddClass_Click(object sender, EventArgs e)
        {
            GymClass? gc = BuildClassFromFields();
            if (gc == null)
            {
                return;
            }

            ActionResultMsg result = await ApiService.AddClassAsync(gc);
            ShowResult(result);

            if (result.Success)
            {
                await LoadClassesAsync();
            }
        }

        private async void btnUpdateClass_Click(object sender, EventArgs e)
        {
            if (dgvClasses.CurrentRow == null || dgvClasses.CurrentRow.Index < 0)
            {
                MessageBox.Show("יש לבחור שיעור מהטבלה", "שימו לב",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GymClass? gc = BuildClassFromFields();
            if (gc == null)
            {
                return;
            }

            gc.ClassID = classes[dgvClasses.CurrentRow.Index].ClassID;

            ActionResultMsg result = await ApiService.UpdateClassAsync(gc);
            ShowResult(result);

            if (result.Success)
            {
                await LoadClassesAsync();
            }
        }

        private async void btnCancelClass_Click(object sender, EventArgs e)
        {
            if (dgvClasses.CurrentRow == null || dgvClasses.CurrentRow.Index < 0)
            {
                MessageBox.Show("יש לבחור שיעור מהטבלה", "שימו לב",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GymClass selected = classes[dgvClasses.CurrentRow.Index];

            DialogResult answer = MessageBox.Show(
                "לבטל את השיעור? כל ההזמנות אליו יבוטלו גם הן",
                "אישור ביטול", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (answer != DialogResult.Yes)
            {
                return;
            }

            ActionResultMsg result = await ApiService.CancelClassAsync(selected.ClassID);
            ShowResult(result);

            if (result.Success)
            {
                await LoadClassesAsync();
            }
        }

        private GymClass? BuildClassFromFields()
        {
            if (cmbClassType.SelectedItem == null)
            {
                MessageBox.Show("יש לבחור סוג שיעור", "שימו לב",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            if (txtTrainer.Text.Trim() == "" || txtRoom.Text.Trim() == "")
            {
                MessageBox.Show("יש להזין שם מאמן ושם אולם", "שימו לב",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            ClassType selectedType = (ClassType)cmbClassType.SelectedItem;

            GymClass gc = new GymClass();
            gc.TypeID = selectedType.TypeID;
            gc.TrainerName = txtTrainer.Text.Trim();
            gc.RoomName = txtRoom.Text.Trim();
            gc.ClassDate = dtpClassDate.Value.Date;
            gc.StartTime = new TimeSpan(dtpClassTime.Value.Hour, dtpClassTime.Value.Minute, 0);
            gc.MaxParticipants = (int)numMaxParticipants.Value;

            return gc;
        }

        // ==================== נרשמים ====================

        private async void cmbClassPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading)
            {
                return;
            }
            await LoadParticipantsAsync();
        }

        private async Task LoadParticipantsAsync()
        {
            int index = cmbClassPicker.SelectedIndex;
            if (index < 0 || index >= classes.Count)
            {
                return;
            }

            GymClass gc = classes[index];

            try
            {
                participants = await ApiService.GetClassParticipantsAsync(gc.ClassID);

                dgvParticipants.DataSource = null;
                dgvParticipants.AutoGenerateColumns = false;
                dgvParticipants.DataSource = participants;

                int active = 0;
                foreach (Booking b in participants)
                {
                    if (b.Status != "בוטל")
                    {
                        active++;
                    }
                }

                lblCount.Text = "רשומים " + active + " מתוך " + gc.MaxParticipants + " מקומות";
            }
            catch (HttpRequestException)
            {
                lblStatus.Text = "אין חיבור לשרת";
            }
        }

        private async void btnApprove_Click(object sender, EventArgs e)
        {
            await ChangeSelectedStatusAsync("אושר");
        }

        private async void btnReject_Click(object sender, EventArgs e)
        {
            await ChangeSelectedStatusAsync("בוטל");
        }

        private async Task ChangeSelectedStatusAsync(string newStatus)
        {
            if (dgvParticipants.CurrentRow == null || dgvParticipants.CurrentRow.Index < 0)
            {
                MessageBox.Show("יש לבחור נרשם מהטבלה", "שימו לב",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Booking selected = participants[dgvParticipants.CurrentRow.Index];

            ActionResultMsg result = await ApiService.ChangeStatusAsync(
                selected.BookingID, newStatus);

            ShowResult(result);

            if (result.Success)
            {
                await LoadParticipantsAsync();
                await LoadClassesAsync();
            }
        }

        private void ShowResult(ActionResultMsg result)
        {
            MessageBox.Show(result.Message,
                            result.Success ? "בוצע" : "לא בוצע",
                            MessageBoxButtons.OK,
                            result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
