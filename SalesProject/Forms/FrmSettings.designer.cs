
namespace SalesProject.Forms
{
    partial class FrmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSettings));
            this.cmbDateFormat = new System.Windows.Forms.ComboBox();
            this.txtAdminName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAdminPass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSQLUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSQLPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtBackupDays = new System.Windows.Forms.TextBox();
            this.txtBackupFiles = new System.Windows.Forms.TextBox();
            this.chkDays = new System.Windows.Forms.CheckBox();
            this.chkFiles = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.radNo = new System.Windows.Forms.RadioButton();
            this.btnAutoBackupPath = new System.Windows.Forms.Button();
            this.radYes = new System.Windows.Forms.RadioButton();
            this.txtAutoBackupPath = new System.Windows.Forms.TextBox();
            this.cmbDrives = new System.Windows.Forms.ComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ckbStartupSystem = new System.Windows.Forms.CheckBox();
            this.bntCancel = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblWait = new System.Windows.Forms.Label();
            this.btnAsyncBackup = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btnBackupPath = new System.Windows.Forms.Button();
            this.btnRestoeDatabase = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtBackupName = new System.Windows.Forms.TextBox();
            this.txtBackupPath = new System.Windows.Forms.TextBox();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbDateFormat
            // 
            this.cmbDateFormat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.cmbDateFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDateFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDateFormat.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDateFormat.FormattingEnabled = true;
            this.cmbDateFormat.Location = new System.Drawing.Point(156, 49);
            this.cmbDateFormat.Name = "cmbDateFormat";
            this.cmbDateFormat.Size = new System.Drawing.Size(214, 29);
            this.cmbDateFormat.TabIndex = 310;
            // 
            // txtAdminName
            // 
            this.txtAdminName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.txtAdminName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdminName.ForeColor = System.Drawing.Color.Black;
            this.txtAdminName.Location = new System.Drawing.Point(155, 22);
            this.txtAdminName.Name = "txtAdminName";
            this.txtAdminName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAdminName.Size = new System.Drawing.Size(215, 29);
            this.txtAdminName.TabIndex = 48;
            this.txtAdminName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(21, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 19);
            this.label3.TabIndex = 51;
            this.label3.Text = "Admin Password";
            // 
            // txtAdminPass
            // 
            this.txtAdminPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.txtAdminPass.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdminPass.Location = new System.Drawing.Point(156, 58);
            this.txtAdminPass.Name = "txtAdminPass";
            this.txtAdminPass.PasswordChar = '*';
            this.txtAdminPass.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAdminPass.Size = new System.Drawing.Size(214, 29);
            this.txtAdminPass.TabIndex = 49;
            this.txtAdminPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAdminPass.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label6.Location = new System.Drawing.Point(23, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 19);
            this.label6.TabIndex = 50;
            this.label6.Text = "Admin Name";
            // 
            // txtSQLUser
            // 
            this.txtSQLUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.txtSQLUser.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSQLUser.ForeColor = System.Drawing.Color.Black;
            this.txtSQLUser.Location = new System.Drawing.Point(154, 119);
            this.txtSQLUser.Name = "txtSQLUser";
            this.txtSQLUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSQLUser.Size = new System.Drawing.Size(214, 29);
            this.txtSQLUser.TabIndex = 44;
            this.txtSQLUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(19, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 19);
            this.label1.TabIndex = 47;
            this.label1.Text = "SQLPassword";
            // 
            // txtSQLPassword
            // 
            this.txtSQLPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.txtSQLPassword.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSQLPassword.Location = new System.Drawing.Point(154, 160);
            this.txtSQLPassword.Name = "txtSQLPassword";
            this.txtSQLPassword.PasswordChar = '*';
            this.txtSQLPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSQLPassword.Size = new System.Drawing.Size(214, 29);
            this.txtSQLPassword.TabIndex = 45;
            this.txtSQLPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(21, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 19);
            this.label2.TabIndex = 46;
            this.label2.Text = "SQLUserName";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(19, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 19);
            this.label4.TabIndex = 37;
            this.label4.Text = "Database Name";
            // 
            // txtDatabase
            // 
            this.txtDatabase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.txtDatabase.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatabase.Location = new System.Drawing.Point(154, 74);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDatabase.Size = new System.Drawing.Size(214, 29);
            this.txtDatabase.TabIndex = 35;
            this.txtDatabase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(21, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 19);
            this.label5.TabIndex = 36;
            this.label5.Text = "Server Name";
            // 
            // sfd
            // 
            this.sfd.Filter = "Bakup files (*.Bak)|*.Bak";
            // 
            // ofd
            // 
            this.ofd.Filter = "Bakup files (*.Bak)|*.Bak";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtBackupDays);
            this.groupBox3.Controls.Add(this.txtBackupFiles);
            this.groupBox3.Controls.Add(this.chkDays);
            this.groupBox3.Controls.Add(this.chkFiles);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox3.Location = new System.Drawing.Point(15, 289);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox3.Size = new System.Drawing.Size(407, 285);
            this.groupBox3.TabIndex = 305;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Automatic Backup Database";
            // 
            // txtBackupDays
            // 
            this.txtBackupDays.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.txtBackupDays.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBackupDays.Location = new System.Drawing.Point(228, 241);
            this.txtBackupDays.Name = "txtBackupDays";
            this.txtBackupDays.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBackupDays.Size = new System.Drawing.Size(74, 29);
            this.txtBackupDays.TabIndex = 291;
            this.txtBackupDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBackupFiles
            // 
            this.txtBackupFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.txtBackupFiles.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBackupFiles.Location = new System.Drawing.Point(228, 204);
            this.txtBackupFiles.Name = "txtBackupFiles";
            this.txtBackupFiles.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBackupFiles.Size = new System.Drawing.Size(74, 29);
            this.txtBackupFiles.TabIndex = 290;
            this.txtBackupFiles.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkDays
            // 
            this.chkDays.AutoSize = true;
            this.chkDays.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDays.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.chkDays.Location = new System.Drawing.Point(315, 244);
            this.chkDays.Name = "chkDays";
            this.chkDays.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkDays.Size = new System.Drawing.Size(85, 23);
            this.chkDays.TabIndex = 311;
            this.chkDays.Text = "Unlimited";
            this.chkDays.UseVisualStyleBackColor = true;
            // 
            // chkFiles
            // 
            this.chkFiles.AutoSize = true;
            this.chkFiles.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFiles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.chkFiles.Location = new System.Drawing.Point(315, 208);
            this.chkFiles.Name = "chkFiles";
            this.chkFiles.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkFiles.Size = new System.Drawing.Size(85, 23);
            this.chkFiles.TabIndex = 310;
            this.chkFiles.Text = "Unlimited";
            this.chkFiles.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label9.Location = new System.Drawing.Point(12, 244);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(213, 19);
            this.label9.TabIndex = 293;
            this.label9.Text = "Maximum (Days) of Backup Files";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label8.Location = new System.Drawing.Point(11, 209);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(213, 19);
            this.label8.TabIndex = 292;
            this.label8.Text = "Maximum Count Of Backup Files";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.radNo);
            this.groupBox4.Controls.Add(this.btnAutoBackupPath);
            this.groupBox4.Controls.Add(this.radYes);
            this.groupBox4.Controls.Add(this.txtAutoBackupPath);
            this.groupBox4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(7, 27);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox4.Size = new System.Drawing.Size(384, 159);
            this.groupBox4.TabIndex = 283;
            this.groupBox4.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label14.Location = new System.Drawing.Point(6, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(368, 19);
            this.label14.TabIndex = 283;
            this.label14.Text = "Backup Database automatically when you close The system";
            // 
            // radNo
            // 
            this.radNo.AutoSize = true;
            this.radNo.Checked = true;
            this.radNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.radNo.Location = new System.Drawing.Point(262, 54);
            this.radNo.Name = "radNo";
            this.radNo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radNo.Size = new System.Drawing.Size(51, 23);
            this.radNo.TabIndex = 1;
            this.radNo.TabStop = true;
            this.radNo.Text = "NO";
            this.radNo.UseVisualStyleBackColor = true;
            // 
            // btnAutoBackupPath
            // 
            this.btnAutoBackupPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(89)))), ((int)(((byte)(251)))));
            this.btnAutoBackupPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAutoBackupPath.FlatAppearance.BorderSize = 0;
            this.btnAutoBackupPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoBackupPath.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoBackupPath.ForeColor = System.Drawing.Color.White;
            this.btnAutoBackupPath.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAutoBackupPath.Location = new System.Drawing.Point(4, 103);
            this.btnAutoBackupPath.Name = "btnAutoBackupPath";
            this.btnAutoBackupPath.Size = new System.Drawing.Size(131, 30);
            this.btnAutoBackupPath.TabIndex = 280;
            this.btnAutoBackupPath.Text = "Auto Backup Path";
            this.btnAutoBackupPath.UseVisualStyleBackColor = false;
            // 
            // radYes
            // 
            this.radYes.AutoSize = true;
            this.radYes.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radYes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.radYes.Location = new System.Drawing.Point(68, 54);
            this.radYes.Name = "radYes";
            this.radYes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radYes.Size = new System.Drawing.Size(56, 23);
            this.radYes.TabIndex = 0;
            this.radYes.Text = "YES";
            this.radYes.UseVisualStyleBackColor = true;
            // 
            // txtAutoBackupPath
            // 
            this.txtAutoBackupPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.txtAutoBackupPath.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAutoBackupPath.Location = new System.Drawing.Point(139, 101);
            this.txtAutoBackupPath.Name = "txtAutoBackupPath";
            this.txtAutoBackupPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAutoBackupPath.Size = new System.Drawing.Size(238, 29);
            this.txtAutoBackupPath.TabIndex = 276;
            this.txtAutoBackupPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbDrives
            // 
            this.cmbDrives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDrives.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDrives.FormattingEnabled = true;
            this.cmbDrives.Location = new System.Drawing.Point(15, 594);
            this.cmbDrives.Name = "cmbDrives";
            this.cmbDrives.Size = new System.Drawing.Size(76, 31);
            this.cmbDrives.TabIndex = 302;
            this.cmbDrives.Visible = false;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // txtServer
            // 
            this.txtServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.txtServer.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServer.ForeColor = System.Drawing.Color.Black;
            this.txtServer.Location = new System.Drawing.Point(154, 36);
            this.txtServer.Name = "txtServer";
            this.txtServer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtServer.Size = new System.Drawing.Size(214, 29);
            this.txtServer.TabIndex = 34;
            this.txtServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label11.Location = new System.Drawing.Point(11, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 19);
            this.label11.TabIndex = 311;
            this.label11.Text = "Date Format";
            // 
            // ckbStartupSystem
            // 
            this.ckbStartupSystem.AutoSize = true;
            this.ckbStartupSystem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbStartupSystem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ckbStartupSystem.Location = new System.Drawing.Point(15, 88);
            this.ckbStartupSystem.Name = "ckbStartupSystem";
            this.ckbStartupSystem.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ckbStartupSystem.Size = new System.Drawing.Size(253, 23);
            this.ckbStartupSystem.TabIndex = 309;
            this.ckbStartupSystem.Text = "Strat Application at Startup Windows";
            this.ckbStartupSystem.UseVisualStyleBackColor = true;
            // 
            // bntCancel
            // 
            this.bntCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(89)))), ((int)(((byte)(251)))));
            this.bntCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bntCancel.FlatAppearance.BorderSize = 0;
            this.bntCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntCancel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntCancel.ForeColor = System.Drawing.Color.White;
            this.bntCancel.Image = ((System.Drawing.Image)(resources.GetObject("bntCancel.Image")));
            this.bntCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bntCancel.Location = new System.Drawing.Point(459, 534);
            this.bntCancel.Name = "bntCancel";
            this.bntCancel.Size = new System.Drawing.Size(172, 40);
            this.bntCancel.TabIndex = 308;
            this.bntCancel.Text = "Cancel";
            this.bntCancel.UseVisualStyleBackColor = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnTestConnection);
            this.groupBox5.Controls.Add(this.txtSQLUser);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.txtSQLPassword);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.txtServer);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.txtDatabase);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox5.Location = new System.Drawing.Point(459, 18);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox5.Size = new System.Drawing.Size(392, 265);
            this.groupBox5.TabIndex = 304;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Settings Of System Connection";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(89)))), ((int)(((byte)(251)))));
            this.btnTestConnection.FlatAppearance.BorderSize = 0;
            this.btnTestConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestConnection.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestConnection.ForeColor = System.Drawing.Color.White;
            this.btnTestConnection.Image = ((System.Drawing.Image)(resources.GetObject("btnTestConnection.Image")));
            this.btnTestConnection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTestConnection.Location = new System.Drawing.Point(25, 206);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(343, 40);
            this.btnTestConnection.TabIndex = 282;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(655, 534);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(172, 40);
            this.btnSave.TabIndex = 307;
            this.btnSave.Text = "Save Settings";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label7.Location = new System.Drawing.Point(5, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 19);
            this.label7.TabIndex = 302;
            this.label7.Text = "Title Company Name";
            // 
            // txtCompany
            // 
            this.txtCompany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.txtCompany.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompany.Location = new System.Drawing.Point(156, 13);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCompany.Size = new System.Drawing.Size(214, 29);
            this.txtCompany.TabIndex = 303;
            this.txtCompany.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblWait);
            this.groupBox1.Controls.Add(this.btnAsyncBackup);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.btnBackupPath);
            this.groupBox1.Controls.Add(this.btnRestoeDatabase);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.txtBackupName);
            this.groupBox1.Controls.Add(this.txtBackupPath);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox1.Location = new System.Drawing.Point(15, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(407, 265);
            this.groupBox1.TabIndex = 306;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manual Backup";
            // 
            // lblWait
            // 
            this.lblWait.AutoSize = true;
            this.lblWait.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWait.ForeColor = System.Drawing.Color.Green;
            this.lblWait.Location = new System.Drawing.Point(105, 231);
            this.lblWait.Name = "lblWait";
            this.lblWait.Size = new System.Drawing.Size(220, 22);
            this.lblWait.TabIndex = 281;
            this.lblWait.Text = "Processing. please wait....";
            this.lblWait.Visible = false;
            // 
            // btnAsyncBackup
            // 
            this.btnAsyncBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(89)))), ((int)(((byte)(251)))));
            this.btnAsyncBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAsyncBackup.FlatAppearance.BorderSize = 0;
            this.btnAsyncBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsyncBackup.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsyncBackup.ForeColor = System.Drawing.Color.White;
            this.btnAsyncBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsyncBackup.Location = new System.Drawing.Point(146, 125);
            this.btnAsyncBackup.Name = "btnAsyncBackup";
            this.btnAsyncBackup.Size = new System.Drawing.Size(236, 40);
            this.btnAsyncBackup.TabIndex = 280;
            this.btnAsyncBackup.Text = "Async Backup";
            this.btnAsyncBackup.UseVisualStyleBackColor = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label10.Location = new System.Drawing.Point(29, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 19);
            this.label10.TabIndex = 279;
            this.label10.Text = "Backup Name";
            // 
            // btnBackupPath
            // 
            this.btnBackupPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(89)))), ((int)(((byte)(251)))));
            this.btnBackupPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackupPath.FlatAppearance.BorderSize = 0;
            this.btnBackupPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackupPath.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackupPath.ForeColor = System.Drawing.Color.White;
            this.btnBackupPath.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBackupPath.Location = new System.Drawing.Point(11, 43);
            this.btnBackupPath.Name = "btnBackupPath";
            this.btnBackupPath.Size = new System.Drawing.Size(131, 30);
            this.btnBackupPath.TabIndex = 278;
            this.btnBackupPath.Text = "Backup Path";
            this.btnBackupPath.UseVisualStyleBackColor = false;
            // 
            // btnRestoeDatabase
            // 
            this.btnRestoeDatabase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(89)))), ((int)(((byte)(251)))));
            this.btnRestoeDatabase.FlatAppearance.BorderSize = 0;
            this.btnRestoeDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestoeDatabase.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestoeDatabase.ForeColor = System.Drawing.Color.White;
            this.btnRestoeDatabase.Image = ((System.Drawing.Image)(resources.GetObject("btnRestoeDatabase.Image")));
            this.btnRestoeDatabase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRestoeDatabase.Location = new System.Drawing.Point(148, 175);
            this.btnRestoeDatabase.Name = "btnRestoeDatabase";
            this.btnRestoeDatabase.Size = new System.Drawing.Size(234, 40);
            this.btnRestoeDatabase.TabIndex = 263;
            this.btnRestoeDatabase.Text = "Restore";
            this.btnRestoeDatabase.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(11, 125);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(131, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 55;
            this.pictureBox1.TabStop = false;
            // 
            // txtBackupName
            // 
            this.txtBackupName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.txtBackupName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBackupName.Location = new System.Drawing.Point(146, 84);
            this.txtBackupName.MaxLength = 50;
            this.txtBackupName.Name = "txtBackupName";
            this.txtBackupName.Size = new System.Drawing.Size(238, 29);
            this.txtBackupName.TabIndex = 52;
            this.txtBackupName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(255)))));
            this.txtBackupPath.Enabled = false;
            this.txtBackupPath.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBackupPath.Location = new System.Drawing.Point(146, 42);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.Size = new System.Drawing.Size(238, 29);
            this.txtBackupPath.TabIndex = 50;
            this.txtBackupPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtAdminName);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.txtAdminPass);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Location = new System.Drawing.Point(457, 289);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(394, 96);
            this.groupBox6.TabIndex = 285;
            this.groupBox6.TabStop = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.cmbDateFormat);
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.Controls.Add(this.ckbStartupSystem);
            this.groupBox7.Controls.Add(this.txtCompany);
            this.groupBox7.Location = new System.Drawing.Point(457, 395);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(393, 121);
            this.groupBox7.TabIndex = 312;
            this.groupBox7.TabStop = false;
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 581);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.cmbDrives);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.bntCancel);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "FrmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الضبط";
            this.Load += new System.EventHandler(this.FrmSettings_Load);
            this.HandleCreated += new System.EventHandler(this.FrmSettings_HandleCreated);
            this.Resize += new System.EventHandler(this.FrmSettings_Resize);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ComboBox cmbDateFormat;
        internal System.Windows.Forms.TextBox txtAdminName;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtAdminPass;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox txtSQLUser;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtSQLPassword;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtDatabase;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.SaveFileDialog sfd;
        internal System.Windows.Forms.OpenFileDialog ofd;
        internal System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txtBackupDays;
        internal System.Windows.Forms.TextBox txtBackupFiles;
        internal System.Windows.Forms.GroupBox groupBox4;
        internal System.Windows.Forms.ComboBox cmbDrives;
        internal System.Windows.Forms.Label label14;
        internal System.Windows.Forms.RadioButton radNo;
        internal System.Windows.Forms.Button btnAutoBackupPath;
        internal System.Windows.Forms.RadioButton radYes;
        internal System.Windows.Forms.TextBox txtAutoBackupPath;
        internal System.Windows.Forms.ImageList imageList1;
        internal System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        internal System.Windows.Forms.TextBox txtServer;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.CheckBox ckbStartupSystem;
        internal System.Windows.Forms.Button bntCancel;
        internal System.Windows.Forms.GroupBox groupBox5;
        internal System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txtCompany;
        internal System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Button btnBackupPath;
        internal System.Windows.Forms.Button btnRestoeDatabase;
        internal System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.TextBox txtBackupName;
        internal System.Windows.Forms.TextBox txtBackupPath;
        internal System.Windows.Forms.Button btnAsyncBackup;
        internal System.Windows.Forms.Label lblWait;
        internal System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        internal System.Windows.Forms.CheckBox chkDays;
        internal System.Windows.Forms.CheckBox chkFiles;
    }
}