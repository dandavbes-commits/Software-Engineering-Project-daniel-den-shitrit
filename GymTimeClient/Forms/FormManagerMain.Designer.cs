namespace GymTimeClient.Forms
{
    partial class FormManagerMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tabMain = new System.Windows.Forms.TabControl();
            // --- לשונית סוגי שיעורים ---
            this.tabTypes = new System.Windows.Forms.TabPage();
            this.dgvTypes = new System.Windows.Forms.DataGridView();
            this.colTpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTpDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTpDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTypeName = new System.Windows.Forms.Label();
            this.txtTypeName = new System.Windows.Forms.TextBox();
            this.lblTypeDuration = new System.Windows.Forms.Label();
            this.numTypeDuration = new System.Windows.Forms.NumericUpDown();
            this.lblTypeDesc = new System.Windows.Forms.Label();
            this.txtTypeDesc = new System.Windows.Forms.TextBox();
            this.btnAddType = new System.Windows.Forms.Button();
            this.btnUpdateType = new System.Windows.Forms.Button();
            this.btnDeleteType = new System.Windows.Forms.Button();
            // --- לשונית לוח שיעורים ---
            this.tabClasses = new System.Windows.Forms.TabPage();
            this.dgvClasses = new System.Windows.Forms.DataGridView();
            this.colClType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClTrainer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClPlaces = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblClType = new System.Windows.Forms.Label();
            this.cmbClassType = new System.Windows.Forms.ComboBox();
            this.lblClTrainer = new System.Windows.Forms.Label();
            this.txtTrainer = new System.Windows.Forms.TextBox();
            this.lblClRoom = new System.Windows.Forms.Label();
            this.txtRoom = new System.Windows.Forms.TextBox();
            this.lblClDate = new System.Windows.Forms.Label();
            this.dtpClassDate = new System.Windows.Forms.DateTimePicker();
            this.lblClTime = new System.Windows.Forms.Label();
            this.dtpClassTime = new System.Windows.Forms.DateTimePicker();
            this.lblClMax = new System.Windows.Forms.Label();
            this.numMaxParticipants = new System.Windows.Forms.NumericUpDown();
            this.btnAddClass = new System.Windows.Forms.Button();
            this.btnUpdateClass = new System.Windows.Forms.Button();
            this.btnCancelClass = new System.Windows.Forms.Button();
            // --- לשונית נרשמים ---
            this.tabParticipants = new System.Windows.Forms.TabPage();
            this.lblSelectClass = new System.Windows.Forms.Label();
            this.cmbClassPicker = new System.Windows.Forms.ComboBox();
            this.dgvParticipants = new System.Windows.Forms.DataGridView();
            this.colPrName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();

            this.tabMain.SuspendLayout();
            this.tabTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTypeDuration)).BeginInit();
            this.tabClasses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxParticipants)).BeginInit();
            this.tabParticipants.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParticipants)).BeginInit();
            this.SuspendLayout();
            //
            // lblWelcome
            //
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(30, 90, 150);
            this.lblWelcome.Location = new System.Drawing.Point(200, 15);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(670, 30);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "אזור ניהול";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // btnLogout
            //
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLogout.Location = new System.Drawing.Point(25, 15);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(120, 32);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "יציאה";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            //
            // tabMain
            //
            this.tabMain.Controls.Add(this.tabClasses);
            this.tabMain.Controls.Add(this.tabParticipants);
            this.tabMain.Controls.Add(this.tabTypes);
            this.tabMain.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tabMain.Location = new System.Drawing.Point(25, 60);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(845, 490);
            this.tabMain.TabIndex = 2;
            //
            // ================= לשונית לוח שיעורים =================
            //
            this.tabClasses.BackColor = System.Drawing.Color.White;
            this.tabClasses.Controls.Add(this.btnCancelClass);
            this.tabClasses.Controls.Add(this.btnUpdateClass);
            this.tabClasses.Controls.Add(this.btnAddClass);
            this.tabClasses.Controls.Add(this.numMaxParticipants);
            this.tabClasses.Controls.Add(this.lblClMax);
            this.tabClasses.Controls.Add(this.dtpClassTime);
            this.tabClasses.Controls.Add(this.lblClTime);
            this.tabClasses.Controls.Add(this.dtpClassDate);
            this.tabClasses.Controls.Add(this.lblClDate);
            this.tabClasses.Controls.Add(this.txtRoom);
            this.tabClasses.Controls.Add(this.lblClRoom);
            this.tabClasses.Controls.Add(this.txtTrainer);
            this.tabClasses.Controls.Add(this.lblClTrainer);
            this.tabClasses.Controls.Add(this.cmbClassType);
            this.tabClasses.Controls.Add(this.lblClType);
            this.tabClasses.Controls.Add(this.dgvClasses);
            this.tabClasses.Location = new System.Drawing.Point(4, 32);
            this.tabClasses.Name = "tabClasses";
            this.tabClasses.Size = new System.Drawing.Size(837, 454);
            this.tabClasses.TabIndex = 0;
            this.tabClasses.Text = "לוח שיעורים";
            //
            // dgvClasses
            //
            this.dgvClasses.AllowUserToAddRows = false;
            this.dgvClasses.AllowUserToDeleteRows = false;
            this.dgvClasses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClasses.BackgroundColor = System.Drawing.Color.White;
            this.dgvClasses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClasses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colClType,
            this.colClDate,
            this.colClTime,
            this.colClTrainer,
            this.colClRoom,
            this.colClPlaces,
            this.colClStatus});
            this.dgvClasses.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvClasses.Location = new System.Drawing.Point(12, 12);
            this.dgvClasses.MultiSelect = false;
            this.dgvClasses.Name = "dgvClasses";
            this.dgvClasses.ReadOnly = true;
            this.dgvClasses.RowHeadersVisible = false;
            this.dgvClasses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClasses.Size = new System.Drawing.Size(813, 215);
            this.dgvClasses.TabIndex = 0;
            this.dgvClasses.SelectionChanged += new System.EventHandler(this.dgvClasses_SelectionChanged);
            //
            this.colClType.DataPropertyName = "TypeName";
            this.colClType.HeaderText = "שיעור";
            this.colClType.Name = "colClType";
            this.colClType.ReadOnly = true;
            //
            this.colClDate.DataPropertyName = "DateText";
            this.colClDate.HeaderText = "תאריך";
            this.colClDate.Name = "colClDate";
            this.colClDate.ReadOnly = true;
            //
            this.colClTime.DataPropertyName = "TimeText";
            this.colClTime.HeaderText = "שעה";
            this.colClTime.Name = "colClTime";
            this.colClTime.ReadOnly = true;
            //
            this.colClTrainer.DataPropertyName = "TrainerName";
            this.colClTrainer.HeaderText = "מאמן";
            this.colClTrainer.Name = "colClTrainer";
            this.colClTrainer.ReadOnly = true;
            //
            this.colClRoom.DataPropertyName = "RoomName";
            this.colClRoom.HeaderText = "אולם";
            this.colClRoom.Name = "colClRoom";
            this.colClRoom.ReadOnly = true;
            //
            this.colClPlaces.DataPropertyName = "PlacesText";
            this.colClPlaces.HeaderText = "פנויים";
            this.colClPlaces.Name = "colClPlaces";
            this.colClPlaces.ReadOnly = true;
            //
            this.colClStatus.DataPropertyName = "StatusText";
            this.colClStatus.HeaderText = "מצב";
            this.colClStatus.Name = "colClStatus";
            this.colClStatus.ReadOnly = true;
            //
            // שורת קלט ראשונה: סוג, מאמן, אולם
            //
            this.lblClType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblClType.Location = new System.Drawing.Point(745, 245);
            this.lblClType.Name = "lblClType";
            this.lblClType.Size = new System.Drawing.Size(80, 25);
            this.lblClType.TabIndex = 1;
            this.lblClType.Text = "סוג שיעור:";
            this.lblClType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            this.cmbClassType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClassType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbClassType.Location = new System.Drawing.Point(590, 245);
            this.cmbClassType.Name = "cmbClassType";
            this.cmbClassType.Size = new System.Drawing.Size(150, 25);
            this.cmbClassType.TabIndex = 2;
            //
            this.lblClTrainer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblClTrainer.Location = new System.Drawing.Point(510, 245);
            this.lblClTrainer.Name = "lblClTrainer";
            this.lblClTrainer.Size = new System.Drawing.Size(70, 25);
            this.lblClTrainer.TabIndex = 3;
            this.lblClTrainer.Text = "מאמן:";
            this.lblClTrainer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            this.txtTrainer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTrainer.Location = new System.Drawing.Point(340, 245);
            this.txtTrainer.Name = "txtTrainer";
            this.txtTrainer.Size = new System.Drawing.Size(165, 25);
            this.txtTrainer.TabIndex = 4;
            //
            this.lblClRoom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblClRoom.Location = new System.Drawing.Point(270, 245);
            this.lblClRoom.Name = "lblClRoom";
            this.lblClRoom.Size = new System.Drawing.Size(60, 25);
            this.lblClRoom.TabIndex = 5;
            this.lblClRoom.Text = "אולם:";
            this.lblClRoom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            this.txtRoom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRoom.Location = new System.Drawing.Point(105, 245);
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.Size = new System.Drawing.Size(160, 25);
            this.txtRoom.TabIndex = 6;
            //
            // שורת קלט שנייה: תאריך, שעה, מקסימום משתתפים
            //
            this.lblClDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblClDate.Location = new System.Drawing.Point(745, 285);
            this.lblClDate.Name = "lblClDate";
            this.lblClDate.Size = new System.Drawing.Size(80, 25);
            this.lblClDate.TabIndex = 7;
            this.lblClDate.Text = "תאריך:";
            this.lblClDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            this.dtpClassDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpClassDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpClassDate.Location = new System.Drawing.Point(590, 285);
            this.dtpClassDate.Name = "dtpClassDate";
            this.dtpClassDate.Size = new System.Drawing.Size(150, 25);
            this.dtpClassDate.TabIndex = 8;
            //
            this.lblClTime.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblClTime.Location = new System.Drawing.Point(510, 285);
            this.lblClTime.Name = "lblClTime";
            this.lblClTime.Size = new System.Drawing.Size(70, 25);
            this.lblClTime.TabIndex = 9;
            this.lblClTime.Text = "שעה:";
            this.lblClTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            this.dtpClassTime.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpClassTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpClassTime.Location = new System.Drawing.Point(390, 285);
            this.dtpClassTime.Name = "dtpClassTime";
            this.dtpClassTime.ShowUpDown = true;
            this.dtpClassTime.Size = new System.Drawing.Size(115, 25);
            this.dtpClassTime.TabIndex = 10;
            //
            this.lblClMax.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblClMax.Location = new System.Drawing.Point(280, 285);
            this.lblClMax.Name = "lblClMax";
            this.lblClMax.Size = new System.Drawing.Size(105, 25);
            this.lblClMax.TabIndex = 11;
            this.lblClMax.Text = "מקומות:";
            this.lblClMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            this.numMaxParticipants.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numMaxParticipants.Location = new System.Drawing.Point(200, 285);
            this.numMaxParticipants.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            this.numMaxParticipants.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numMaxParticipants.Name = "numMaxParticipants";
            this.numMaxParticipants.Size = new System.Drawing.Size(70, 25);
            this.numMaxParticipants.TabIndex = 12;
            this.numMaxParticipants.Value = new decimal(new int[] { 12, 0, 0, 0 });
            //
            // כפתורי לוח השיעורים
            //
            this.btnAddClass.BackColor = System.Drawing.Color.FromArgb(30, 90, 150);
            this.btnAddClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddClass.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddClass.ForeColor = System.Drawing.Color.White;
            this.btnAddClass.Location = new System.Drawing.Point(665, 340);
            this.btnAddClass.Name = "btnAddClass";
            this.btnAddClass.Size = new System.Drawing.Size(160, 42);
            this.btnAddClass.TabIndex = 13;
            this.btnAddClass.Text = "פתיחת שיעור חדש";
            this.btnAddClass.UseVisualStyleBackColor = false;
            this.btnAddClass.Click += new System.EventHandler(this.btnAddClass_Click);
            //
            this.btnUpdateClass.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnUpdateClass.Location = new System.Drawing.Point(495, 340);
            this.btnUpdateClass.Name = "btnUpdateClass";
            this.btnUpdateClass.Size = new System.Drawing.Size(160, 42);
            this.btnUpdateClass.TabIndex = 14;
            this.btnUpdateClass.Text = "עדכון השיעור הנבחר";
            this.btnUpdateClass.UseVisualStyleBackColor = true;
            this.btnUpdateClass.Click += new System.EventHandler(this.btnUpdateClass_Click);
            //
            this.btnCancelClass.BackColor = System.Drawing.Color.Firebrick;
            this.btnCancelClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelClass.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelClass.ForeColor = System.Drawing.Color.White;
            this.btnCancelClass.Location = new System.Drawing.Point(325, 340);
            this.btnCancelClass.Name = "btnCancelClass";
            this.btnCancelClass.Size = new System.Drawing.Size(160, 42);
            this.btnCancelClass.TabIndex = 15;
            this.btnCancelClass.Text = "ביטול השיעור";
            this.btnCancelClass.UseVisualStyleBackColor = false;
            this.btnCancelClass.Click += new System.EventHandler(this.btnCancelClass_Click);
            //
            // ================= לשונית נרשמים =================
            //
            this.tabParticipants.BackColor = System.Drawing.Color.White;
            this.tabParticipants.Controls.Add(this.lblCount);
            this.tabParticipants.Controls.Add(this.btnReject);
            this.tabParticipants.Controls.Add(this.btnApprove);
            this.tabParticipants.Controls.Add(this.dgvParticipants);
            this.tabParticipants.Controls.Add(this.cmbClassPicker);
            this.tabParticipants.Controls.Add(this.lblSelectClass);
            this.tabParticipants.Location = new System.Drawing.Point(4, 32);
            this.tabParticipants.Name = "tabParticipants";
            this.tabParticipants.Size = new System.Drawing.Size(837, 454);
            this.tabParticipants.TabIndex = 1;
            this.tabParticipants.Text = "נרשמים לשיעור";
            //
            this.lblSelectClass.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSelectClass.Location = new System.Drawing.Point(715, 18);
            this.lblSelectClass.Name = "lblSelectClass";
            this.lblSelectClass.Size = new System.Drawing.Size(110, 28);
            this.lblSelectClass.TabIndex = 0;
            this.lblSelectClass.Text = "בחירת שיעור:";
            this.lblSelectClass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            this.cmbClassPicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClassPicker.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbClassPicker.Location = new System.Drawing.Point(225, 18);
            this.cmbClassPicker.Name = "cmbClassPicker";
            this.cmbClassPicker.Size = new System.Drawing.Size(485, 25);
            this.cmbClassPicker.TabIndex = 1;
            this.cmbClassPicker.SelectedIndexChanged += new System.EventHandler(this.cmbClassPicker_SelectedIndexChanged);
            //
            this.dgvParticipants.AllowUserToAddRows = false;
            this.dgvParticipants.AllowUserToDeleteRows = false;
            this.dgvParticipants.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvParticipants.BackgroundColor = System.Drawing.Color.White;
            this.dgvParticipants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParticipants.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPrName,
            this.colPrPhone,
            this.colPrStatus});
            this.dgvParticipants.Location = new System.Drawing.Point(12, 60);
            this.dgvParticipants.MultiSelect = false;
            this.dgvParticipants.Name = "dgvParticipants";
            this.dgvParticipants.ReadOnly = true;
            this.dgvParticipants.RowHeadersVisible = false;
            this.dgvParticipants.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParticipants.Size = new System.Drawing.Size(813, 265);
            this.dgvParticipants.TabIndex = 2;
            //
            this.colPrName.DataPropertyName = "ClientName";
            this.colPrName.HeaderText = "שם המתאמן";
            this.colPrName.Name = "colPrName";
            this.colPrName.ReadOnly = true;
            //
            this.colPrPhone.DataPropertyName = "ClientPhone";
            this.colPrPhone.HeaderText = "טלפון";
            this.colPrPhone.Name = "colPrPhone";
            this.colPrPhone.ReadOnly = true;
            //
            this.colPrStatus.DataPropertyName = "Status";
            this.colPrStatus.HeaderText = "סטטוס";
            this.colPrStatus.Name = "colPrStatus";
            this.colPrStatus.ReadOnly = true;
            //
            this.btnApprove.BackColor = System.Drawing.Color.SeaGreen;
            this.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApprove.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Location = new System.Drawing.Point(665, 340);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(160, 42);
            this.btnApprove.TabIndex = 3;
            this.btnApprove.Text = "אישור ההזמנה";
            this.btnApprove.UseVisualStyleBackColor = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            //
            this.btnReject.BackColor = System.Drawing.Color.Firebrick;
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReject.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReject.ForeColor = System.Drawing.Color.White;
            this.btnReject.Location = new System.Drawing.Point(495, 340);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(160, 42);
            this.btnReject.TabIndex = 4;
            this.btnReject.Text = "דחיית ההזמנה";
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            //
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(30, 90, 150);
            this.lblCount.Location = new System.Drawing.Point(12, 340);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(470, 42);
            this.lblCount.TabIndex = 5;
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // ================= לשונית סוגי שיעורים =================
            //
            this.tabTypes.BackColor = System.Drawing.Color.White;
            this.tabTypes.Controls.Add(this.btnDeleteType);
            this.tabTypes.Controls.Add(this.btnUpdateType);
            this.tabTypes.Controls.Add(this.btnAddType);
            this.tabTypes.Controls.Add(this.txtTypeDesc);
            this.tabTypes.Controls.Add(this.lblTypeDesc);
            this.tabTypes.Controls.Add(this.numTypeDuration);
            this.tabTypes.Controls.Add(this.lblTypeDuration);
            this.tabTypes.Controls.Add(this.txtTypeName);
            this.tabTypes.Controls.Add(this.lblTypeName);
            this.tabTypes.Controls.Add(this.dgvTypes);
            this.tabTypes.Location = new System.Drawing.Point(4, 32);
            this.tabTypes.Name = "tabTypes";
            this.tabTypes.Size = new System.Drawing.Size(837, 454);
            this.tabTypes.TabIndex = 2;
            this.tabTypes.Text = "סוגי שיעורים";
            //
            this.dgvTypes.AllowUserToAddRows = false;
            this.dgvTypes.AllowUserToDeleteRows = false;
            this.dgvTypes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTypes.BackgroundColor = System.Drawing.Color.White;
            this.dgvTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTpName,
            this.colTpDesc,
            this.colTpDuration});
            this.dgvTypes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvTypes.Location = new System.Drawing.Point(12, 12);
            this.dgvTypes.MultiSelect = false;
            this.dgvTypes.Name = "dgvTypes";
            this.dgvTypes.ReadOnly = true;
            this.dgvTypes.RowHeadersVisible = false;
            this.dgvTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTypes.Size = new System.Drawing.Size(813, 230);
            this.dgvTypes.TabIndex = 0;
            this.dgvTypes.SelectionChanged += new System.EventHandler(this.dgvTypes_SelectionChanged);
            //
            this.colTpName.DataPropertyName = "TypeName";
            this.colTpName.HeaderText = "שם השיעור";
            this.colTpName.Name = "colTpName";
            this.colTpName.ReadOnly = true;
            //
            this.colTpDesc.DataPropertyName = "TypeDescription";
            this.colTpDesc.HeaderText = "תיאור";
            this.colTpDesc.Name = "colTpDesc";
            this.colTpDesc.ReadOnly = true;
            //
            this.colTpDuration.DataPropertyName = "DurationMinutes";
            this.colTpDuration.HeaderText = "משך בדקות";
            this.colTpDuration.Name = "colTpDuration";
            this.colTpDuration.ReadOnly = true;
            //
            this.lblTypeName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTypeName.Location = new System.Drawing.Point(715, 260);
            this.lblTypeName.Name = "lblTypeName";
            this.lblTypeName.Size = new System.Drawing.Size(110, 25);
            this.lblTypeName.TabIndex = 1;
            this.lblTypeName.Text = "שם השיעור:";
            this.lblTypeName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            this.txtTypeName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTypeName.Location = new System.Drawing.Point(505, 260);
            this.txtTypeName.Name = "txtTypeName";
            this.txtTypeName.Size = new System.Drawing.Size(205, 25);
            this.txtTypeName.TabIndex = 2;
            //
            this.lblTypeDuration.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTypeDuration.Location = new System.Drawing.Point(375, 260);
            this.lblTypeDuration.Name = "lblTypeDuration";
            this.lblTypeDuration.Size = new System.Drawing.Size(125, 25);
            this.lblTypeDuration.TabIndex = 3;
            this.lblTypeDuration.Text = "משך בדקות:";
            this.lblTypeDuration.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            this.numTypeDuration.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numTypeDuration.Location = new System.Drawing.Point(290, 260);
            this.numTypeDuration.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            this.numTypeDuration.Minimum = new decimal(new int[] { 15, 0, 0, 0 });
            this.numTypeDuration.Name = "numTypeDuration";
            this.numTypeDuration.Size = new System.Drawing.Size(75, 25);
            this.numTypeDuration.TabIndex = 4;
            this.numTypeDuration.Value = new decimal(new int[] { 45, 0, 0, 0 });
            //
            this.lblTypeDesc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTypeDesc.Location = new System.Drawing.Point(715, 300);
            this.lblTypeDesc.Name = "lblTypeDesc";
            this.lblTypeDesc.Size = new System.Drawing.Size(110, 25);
            this.lblTypeDesc.TabIndex = 5;
            this.lblTypeDesc.Text = "תיאור:";
            this.lblTypeDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            this.txtTypeDesc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTypeDesc.Location = new System.Drawing.Point(290, 300);
            this.txtTypeDesc.Name = "txtTypeDesc";
            this.txtTypeDesc.Size = new System.Drawing.Size(420, 25);
            this.txtTypeDesc.TabIndex = 6;
            //
            this.btnAddType.BackColor = System.Drawing.Color.FromArgb(30, 90, 150);
            this.btnAddType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddType.ForeColor = System.Drawing.Color.White;
            this.btnAddType.Location = new System.Drawing.Point(665, 350);
            this.btnAddType.Name = "btnAddType";
            this.btnAddType.Size = new System.Drawing.Size(160, 42);
            this.btnAddType.TabIndex = 7;
            this.btnAddType.Text = "הוספה";
            this.btnAddType.UseVisualStyleBackColor = false;
            this.btnAddType.Click += new System.EventHandler(this.btnAddType_Click);
            //
            this.btnUpdateType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnUpdateType.Location = new System.Drawing.Point(495, 350);
            this.btnUpdateType.Name = "btnUpdateType";
            this.btnUpdateType.Size = new System.Drawing.Size(160, 42);
            this.btnUpdateType.TabIndex = 8;
            this.btnUpdateType.Text = "עדכון הנבחר";
            this.btnUpdateType.UseVisualStyleBackColor = true;
            this.btnUpdateType.Click += new System.EventHandler(this.btnUpdateType_Click);
            //
            this.btnDeleteType.BackColor = System.Drawing.Color.Firebrick;
            this.btnDeleteType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeleteType.ForeColor = System.Drawing.Color.White;
            this.btnDeleteType.Location = new System.Drawing.Point(325, 350);
            this.btnDeleteType.Name = "btnDeleteType";
            this.btnDeleteType.Size = new System.Drawing.Size(160, 42);
            this.btnDeleteType.TabIndex = 9;
            this.btnDeleteType.Text = "מחיקת הנבחר";
            this.btnDeleteType.UseVisualStyleBackColor = false;
            this.btnDeleteType.Click += new System.EventHandler(this.btnDeleteType_Click);
            //
            // lblStatus
            //
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lblStatus.Location = new System.Drawing.Point(25, 558);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(845, 25);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // FormManagerMain
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(895, 595);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblWelcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormManagerMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GymTime - ניהול המכון";
            this.Load += new System.EventHandler(this.FormManagerMain_Load);

            this.tabMain.ResumeLayout(false);
            this.tabTypes.ResumeLayout(false);
            this.tabTypes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTypeDuration)).EndInit();
            this.tabClasses.ResumeLayout(false);
            this.tabClasses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxParticipants)).EndInit();
            this.tabParticipants.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParticipants)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TabControl tabMain;

        private System.Windows.Forms.TabPage tabTypes;
        private System.Windows.Forms.DataGridView dgvTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTpName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTpDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTpDuration;
        private System.Windows.Forms.Label lblTypeName;
        private System.Windows.Forms.TextBox txtTypeName;
        private System.Windows.Forms.Label lblTypeDuration;
        private System.Windows.Forms.NumericUpDown numTypeDuration;
        private System.Windows.Forms.Label lblTypeDesc;
        private System.Windows.Forms.TextBox txtTypeDesc;
        private System.Windows.Forms.Button btnAddType;
        private System.Windows.Forms.Button btnUpdateType;
        private System.Windows.Forms.Button btnDeleteType;

        private System.Windows.Forms.TabPage tabClasses;
        private System.Windows.Forms.DataGridView dgvClasses;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClTrainer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClPlaces;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClStatus;
        private System.Windows.Forms.Label lblClType;
        private System.Windows.Forms.ComboBox cmbClassType;
        private System.Windows.Forms.Label lblClTrainer;
        private System.Windows.Forms.TextBox txtTrainer;
        private System.Windows.Forms.Label lblClRoom;
        private System.Windows.Forms.TextBox txtRoom;
        private System.Windows.Forms.Label lblClDate;
        private System.Windows.Forms.DateTimePicker dtpClassDate;
        private System.Windows.Forms.Label lblClTime;
        private System.Windows.Forms.DateTimePicker dtpClassTime;
        private System.Windows.Forms.Label lblClMax;
        private System.Windows.Forms.NumericUpDown numMaxParticipants;
        private System.Windows.Forms.Button btnAddClass;
        private System.Windows.Forms.Button btnUpdateClass;
        private System.Windows.Forms.Button btnCancelClass;

        private System.Windows.Forms.TabPage tabParticipants;
        private System.Windows.Forms.Label lblSelectClass;
        private System.Windows.Forms.ComboBox cmbClassPicker;
        private System.Windows.Forms.DataGridView dgvParticipants;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrStatus;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Label lblCount;
    }
}
