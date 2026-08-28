namespace GymTimeClient.Forms
{
    partial class FormClientMain
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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabSchedule = new System.Windows.Forms.TabPage();
            this.dgvSchedule = new System.Windows.Forms.DataGridView();
            this.colTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrainer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlaces = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBook = new System.Windows.Forms.Button();
            this.btnRefreshSchedule = new System.Windows.Forms.Button();
            this.tabMyBookings = new System.Windows.Forms.TabPage();
            this.dgvMyBookings = new System.Windows.Forms.DataGridView();
            this.colBkType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBkDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBkTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBkTrainer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBkStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancelBooking = new System.Windows.Forms.Button();
            this.btnRefreshBookings = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tabMain.SuspendLayout();
            this.tabSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            this.tabMyBookings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyBookings)).BeginInit();
            this.SuspendLayout();
            //
            // lblWelcome
            //
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(30, 90, 150);
            this.lblWelcome.Location = new System.Drawing.Point(180, 15);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(600, 30);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "שלום";
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
            this.tabMain.Controls.Add(this.tabSchedule);
            this.tabMain.Controls.Add(this.tabMyBookings);
            this.tabMain.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tabMain.Location = new System.Drawing.Point(25, 60);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(755, 460);
            this.tabMain.TabIndex = 2;
            //
            // tabSchedule
            //
            this.tabSchedule.BackColor = System.Drawing.Color.White;
            this.tabSchedule.Controls.Add(this.btnRefreshSchedule);
            this.tabSchedule.Controls.Add(this.btnBook);
            this.tabSchedule.Controls.Add(this.dgvSchedule);
            this.tabSchedule.Location = new System.Drawing.Point(4, 32);
            this.tabSchedule.Name = "tabSchedule";
            this.tabSchedule.Padding = new System.Windows.Forms.Padding(3);
            this.tabSchedule.Size = new System.Drawing.Size(747, 424);
            this.tabSchedule.TabIndex = 0;
            this.tabSchedule.Text = "לוח שיעורים";
            //
            // dgvSchedule
            //
            this.dgvSchedule.AllowUserToAddRows = false;
            this.dgvSchedule.AllowUserToDeleteRows = false;
            this.dgvSchedule.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSchedule.BackgroundColor = System.Drawing.Color.White;
            this.dgvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTypeName,
            this.colDate,
            this.colTime,
            this.colTrainer,
            this.colRoom,
            this.colDuration,
            this.colPlaces});
            this.dgvSchedule.Location = new System.Drawing.Point(15, 15);
            this.dgvSchedule.MultiSelect = false;
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.ReadOnly = true;
            this.dgvSchedule.RowHeadersVisible = false;
            this.dgvSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSchedule.Size = new System.Drawing.Size(715, 330);
            this.dgvSchedule.TabIndex = 0;
            //
            // colTypeName
            //
            this.colTypeName.DataPropertyName = "TypeName";
            this.colTypeName.HeaderText = "שיעור";
            this.colTypeName.Name = "colTypeName";
            this.colTypeName.ReadOnly = true;
            //
            // colDate
            //
            this.colDate.DataPropertyName = "DateText";
            this.colDate.HeaderText = "תאריך";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            //
            // colTime
            //
            this.colTime.DataPropertyName = "TimeText";
            this.colTime.HeaderText = "שעה";
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            //
            // colTrainer
            //
            this.colTrainer.DataPropertyName = "TrainerName";
            this.colTrainer.HeaderText = "מאמן";
            this.colTrainer.Name = "colTrainer";
            this.colTrainer.ReadOnly = true;
            //
            // colRoom
            //
            this.colRoom.DataPropertyName = "RoomName";
            this.colRoom.HeaderText = "אולם";
            this.colRoom.Name = "colRoom";
            this.colRoom.ReadOnly = true;
            //
            // colDuration
            //
            this.colDuration.DataPropertyName = "DurationMinutes";
            this.colDuration.HeaderText = "דקות";
            this.colDuration.Name = "colDuration";
            this.colDuration.ReadOnly = true;
            //
            // colPlaces
            //
            this.colPlaces.DataPropertyName = "PlacesText";
            this.colPlaces.HeaderText = "מקומות פנויים";
            this.colPlaces.Name = "colPlaces";
            this.colPlaces.ReadOnly = true;
            //
            // btnBook
            //
            this.btnBook.BackColor = System.Drawing.Color.FromArgb(30, 90, 150);
            this.btnBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBook.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBook.ForeColor = System.Drawing.Color.White;
            this.btnBook.Location = new System.Drawing.Point(540, 360);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(190, 42);
            this.btnBook.TabIndex = 1;
            this.btnBook.Text = "הזמנת מקום בשיעור";
            this.btnBook.UseVisualStyleBackColor = false;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            //
            // btnRefreshSchedule
            //
            this.btnRefreshSchedule.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRefreshSchedule.Location = new System.Drawing.Point(390, 360);
            this.btnRefreshSchedule.Name = "btnRefreshSchedule";
            this.btnRefreshSchedule.Size = new System.Drawing.Size(130, 42);
            this.btnRefreshSchedule.TabIndex = 2;
            this.btnRefreshSchedule.Text = "רענון";
            this.btnRefreshSchedule.UseVisualStyleBackColor = true;
            this.btnRefreshSchedule.Click += new System.EventHandler(this.btnRefreshSchedule_Click);
            //
            // tabMyBookings
            //
            this.tabMyBookings.BackColor = System.Drawing.Color.White;
            this.tabMyBookings.Controls.Add(this.btnRefreshBookings);
            this.tabMyBookings.Controls.Add(this.btnCancelBooking);
            this.tabMyBookings.Controls.Add(this.dgvMyBookings);
            this.tabMyBookings.Location = new System.Drawing.Point(4, 32);
            this.tabMyBookings.Name = "tabMyBookings";
            this.tabMyBookings.Padding = new System.Windows.Forms.Padding(3);
            this.tabMyBookings.Size = new System.Drawing.Size(747, 424);
            this.tabMyBookings.TabIndex = 1;
            this.tabMyBookings.Text = "ההזמנות שלי";
            //
            // dgvMyBookings
            //
            this.dgvMyBookings.AllowUserToAddRows = false;
            this.dgvMyBookings.AllowUserToDeleteRows = false;
            this.dgvMyBookings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMyBookings.BackgroundColor = System.Drawing.Color.White;
            this.dgvMyBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyBookings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBkType,
            this.colBkDate,
            this.colBkTime,
            this.colBkTrainer,
            this.colBkStatus});
            this.dgvMyBookings.Location = new System.Drawing.Point(15, 15);
            this.dgvMyBookings.MultiSelect = false;
            this.dgvMyBookings.Name = "dgvMyBookings";
            this.dgvMyBookings.ReadOnly = true;
            this.dgvMyBookings.RowHeadersVisible = false;
            this.dgvMyBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMyBookings.Size = new System.Drawing.Size(715, 330);
            this.dgvMyBookings.TabIndex = 0;
            //
            // colBkType
            //
            this.colBkType.DataPropertyName = "TypeName";
            this.colBkType.HeaderText = "שיעור";
            this.colBkType.Name = "colBkType";
            this.colBkType.ReadOnly = true;
            //
            // colBkDate
            //
            this.colBkDate.DataPropertyName = "DateText";
            this.colBkDate.HeaderText = "תאריך";
            this.colBkDate.Name = "colBkDate";
            this.colBkDate.ReadOnly = true;
            //
            // colBkTime
            //
            this.colBkTime.DataPropertyName = "TimeText";
            this.colBkTime.HeaderText = "שעה";
            this.colBkTime.Name = "colBkTime";
            this.colBkTime.ReadOnly = true;
            //
            // colBkTrainer
            //
            this.colBkTrainer.DataPropertyName = "TrainerName";
            this.colBkTrainer.HeaderText = "מאמן";
            this.colBkTrainer.Name = "colBkTrainer";
            this.colBkTrainer.ReadOnly = true;
            //
            // colBkStatus
            //
            this.colBkStatus.DataPropertyName = "Status";
            this.colBkStatus.HeaderText = "סטטוס";
            this.colBkStatus.Name = "colBkStatus";
            this.colBkStatus.ReadOnly = true;
            //
            // btnCancelBooking
            //
            this.btnCancelBooking.BackColor = System.Drawing.Color.Firebrick;
            this.btnCancelBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelBooking.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancelBooking.ForeColor = System.Drawing.Color.White;
            this.btnCancelBooking.Location = new System.Drawing.Point(540, 360);
            this.btnCancelBooking.Name = "btnCancelBooking";
            this.btnCancelBooking.Size = new System.Drawing.Size(190, 42);
            this.btnCancelBooking.TabIndex = 1;
            this.btnCancelBooking.Text = "ביטול הזמנה";
            this.btnCancelBooking.UseVisualStyleBackColor = false;
            this.btnCancelBooking.Click += new System.EventHandler(this.btnCancelBooking_Click);
            //
            // btnRefreshBookings
            //
            this.btnRefreshBookings.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRefreshBookings.Location = new System.Drawing.Point(390, 360);
            this.btnRefreshBookings.Name = "btnRefreshBookings";
            this.btnRefreshBookings.Size = new System.Drawing.Size(130, 42);
            this.btnRefreshBookings.TabIndex = 2;
            this.btnRefreshBookings.Text = "רענון";
            this.btnRefreshBookings.UseVisualStyleBackColor = true;
            this.btnRefreshBookings.Click += new System.EventHandler(this.btnRefreshBookings_Click);
            //
            // lblStatus
            //
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lblStatus.Location = new System.Drawing.Point(25, 528);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(755, 25);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // FormClientMain
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(805, 565);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblWelcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormClientMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GymTime - אזור אישי";
            this.Load += new System.EventHandler(this.FormClientMain_Load);
            this.tabMain.ResumeLayout(false);
            this.tabSchedule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
            this.tabMyBookings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyBookings)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabSchedule;
        private System.Windows.Forms.DataGridView dgvSchedule;
        private System.Windows.Forms.Button btnBook;
        private System.Windows.Forms.Button btnRefreshSchedule;
        private System.Windows.Forms.TabPage tabMyBookings;
        private System.Windows.Forms.DataGridView dgvMyBookings;
        private System.Windows.Forms.Button btnCancelBooking;
        private System.Windows.Forms.Button btnRefreshBookings;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrainer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlaces;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBkType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBkDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBkTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBkTrainer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBkStatus;
    }
}
