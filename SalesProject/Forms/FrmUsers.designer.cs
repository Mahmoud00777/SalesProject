
namespace SalesProject.Forms
{
    partial class FrmUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsers));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmsDeletePicture = new System.Windows.Forms.ToolStripMenuItem();
            this.txtUserJob = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnResetPass = new System.Windows.Forms.Button();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.chkShowDelUser = new System.Windows.Forms.CheckBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnLockedOut = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column6 = new System.Windows.Forms.DataGridViewImageColumn();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.grpUserInfo = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grpPermissions = new System.Windows.Forms.GroupBox();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.chkPrint = new System.Windows.Forms.CheckBox();
            this.chkInsert = new System.Windows.Forms.CheckBox();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.btnSavePermission = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkAdmin = new System.Windows.Forms.CheckBox();
            this.cmbOperation = new System.Windows.Forms.ComboBox();
            this.txtUserPhone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.grpUserInfo.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grpPermissions.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsDeletePicture
            // 
            this.cmsDeletePicture.Name = "cmsDeletePicture";
            this.cmsDeletePicture.Size = new System.Drawing.Size(137, 22);
            this.cmsDeletePicture.Text = "حذف الصورة";
            this.cmsDeletePicture.Click += new System.EventHandler(this.cmsDeletePicture_Click);
            // 
            // txtUserJob
            // 
            this.txtUserJob.BackColor = System.Drawing.Color.White;
            this.txtUserJob.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserJob.ForeColor = System.Drawing.Color.Black;
            this.txtUserJob.Location = new System.Drawing.Point(496, 99);
            this.txtUserJob.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUserJob.Name = "txtUserJob";
            this.txtUserJob.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUserJob.Size = new System.Drawing.Size(245, 25);
            this.txtUserJob.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(748, 106);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(103, 21);
            this.label7.TabIndex = 18;
            this.label7.Text = "الصفة/الوظيفة";
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.BackColor = System.Drawing.Color.White;
            this.txtUserPassword.Enabled = false;
            this.txtUserPassword.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserPassword.ForeColor = System.Drawing.Color.Black;
            this.txtUserPassword.Location = new System.Drawing.Point(599, 63);
            this.txtUserPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.PasswordChar = '*';
            this.txtUserPassword.ReadOnly = true;
            this.txtUserPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUserPassword.Size = new System.Drawing.Size(144, 25);
            this.txtUserPassword.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(772, 67);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 21);
            this.label8.TabIndex = 12;
            this.label8.Text = "كلمة المرور";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(752, 33);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 21);
            this.label9.TabIndex = 11;
            this.label9.Text = "اسم المستخدم";
            // 
            // ofd
            // 
            this.ofd.Filter = "Bakup files (*.Bak)|*.Bak";
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 10;
            this.toolTip1.AutoPopDelay = 2000;
            this.toolTip1.InitialDelay = 10;
            this.toolTip1.ReshowDelay = 2;
            // 
            // btnResetPass
            // 
            this.btnResetPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(89)))), ((int)(((byte)(251)))));
            this.btnResetPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetPass.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(89)))), ((int)(((byte)(251)))));
            this.btnResetPass.FlatAppearance.BorderSize = 4;
            this.btnResetPass.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(89)))), ((int)(((byte)(251)))));
            this.btnResetPass.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(89)))), ((int)(((byte)(251)))));
            this.btnResetPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetPass.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnResetPass.Location = new System.Drawing.Point(498, 62);
            this.btnResetPass.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnResetPass.Name = "btnResetPass";
            this.btnResetPass.Size = new System.Drawing.Size(98, 31);
            this.btnResetPass.TabIndex = 19;
            this.btnResetPass.Text = "ضبط كلمة المرور";
            this.toolTip1.SetToolTip(this.btnResetPass, "ضبط كلمة المرور الى = 0000");
            this.btnResetPass.UseVisualStyleBackColor = false;
            this.btnResetPass.Click += new System.EventHandler(this.btnResetPass_Click);
            // 
            // picUser
            // 
            this.picUser.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picUser.BackgroundImage")));
            this.picUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picUser.ContextMenuStrip = this.contextMenuStrip1;
            this.picUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picUser.Location = new System.Drawing.Point(344, 28);
            this.picUser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(144, 169);
            this.picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUser.TabIndex = 6;
            this.picUser.TabStop = false;
            this.toolTip1.SetToolTip(this.picUser, "أنقر لإضافة صورة للمستخدم");
            this.picUser.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picUser_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsDeletePicture});
            this.contextMenuStrip1.Name = "ContextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(138, 26);
            // 
            // timer1
            // 
            this.timer1.Tag = "0";
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Image files (*.jpg , *.png)|*.jpg;*.png";
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.White;
            this.txtUserName.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.ForeColor = System.Drawing.Color.Black;
            this.txtUserName.Location = new System.Drawing.Point(496, 28);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUserName.Size = new System.Drawing.Size(245, 25);
            this.txtUserName.TabIndex = 0;
            // 
            // chkShowDelUser
            // 
            this.chkShowDelUser.AutoSize = true;
            this.chkShowDelUser.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowDelUser.ForeColor = System.Drawing.Color.Maroon;
            this.chkShowDelUser.Location = new System.Drawing.Point(692, 535);
            this.chkShowDelUser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkShowDelUser.Name = "chkShowDelUser";
            this.chkShowDelUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkShowDelUser.Size = new System.Drawing.Size(185, 23);
            this.chkShowDelUser.TabIndex = 254;
            this.chkShowDelUser.Text = "عرض المستخدمين المحذوفين";
            this.chkShowDelUser.UseVisualStyleBackColor = true;
            this.chkShowDelUser.CheckedChanged += new System.EventHandler(this.chkShowDelUser_CheckedChanged);
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.SystemColors.Control;
            this.btnInsert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsert.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(89)))), ((int)(((byte)(251)))));
            this.btnInsert.FlatAppearance.BorderSize = 4;
            this.btnInsert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(89)))), ((int)(((byte)(251)))));
            this.btnInsert.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(89)))), ((int)(((byte)(251)))));
            this.btnInsert.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInsert.Font = new System.Drawing.Font("Hacen Saudi Arabia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.ForeColor = System.Drawing.Color.Black;
            this.btnInsert.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnInsert.ImageKey = "Save.png";
            this.btnInsert.ImageList = this.imageList1;
            this.btnInsert.Location = new System.Drawing.Point(695, 264);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(180, 41);
            this.btnInsert.TabIndex = 250;
            this.btnInsert.Text = "إضافــــــــــــــة";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Save.png");
            this.imageList1.Images.SetKeyName(1, "1471989464_list-remove.png");
            this.imageList1.Images.SetKeyName(2, "1479524557_check_book.png");
            this.imageList1.Images.SetKeyName(3, "le-updates-icon.png");
            this.imageList1.Images.SetKeyName(4, "1471482428_onebit_34.ico");
            this.imageList1.Images.SetKeyName(5, "1471482428_onebit_34.ico");
            this.imageList1.Images.SetKeyName(6, "1472054934_Down_Arrow_Direction_Download_Save_Open_Update.png");
            this.imageList1.Images.SetKeyName(7, "user (1).png");
            this.imageList1.Images.SetKeyName(8, "1472051461_user_warning.png");
            this.imageList1.Images.SetKeyName(9, "Action-delete-icon (1).png");
            this.imageList1.Images.SetKeyName(10, "Symbol-Delete.ico");
            this.imageList1.Images.SetKeyName(11, "1480391233_POWER - RESTART.png");
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.Control;
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(89)))), ((int)(((byte)(251)))));
            this.btnNew.FlatAppearance.BorderSize = 4;
            this.btnNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(89)))), ((int)(((byte)(251)))));
            this.btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(89)))), ((int)(((byte)(251)))));
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNew.Font = new System.Drawing.Font("Hacen Saudi Arabia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.Black;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.ImageKey = "le-updates-icon.png";
            this.btnNew.ImageList = this.imageList1;
            this.btnNew.Location = new System.Drawing.Point(695, 476);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(181, 41);
            this.btnNew.TabIndex = 251;
            this.btnNew.Text = "جــد يـــد";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(89)))), ((int)(((byte)(251)))));
            this.btnDelete.FlatAppearance.BorderSize = 4;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(89)))), ((int)(((byte)(251)))));
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(89)))), ((int)(((byte)(251)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Hacen Saudi Arabia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.ImageKey = "1471989464_list-remove.png";
            this.btnDelete.ImageList = this.imageList1;
            this.btnDelete.Location = new System.Drawing.Point(695, 370);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(181, 41);
            this.btnDelete.TabIndex = 252;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(89)))), ((int)(((byte)(251)))));
            this.btnUpdate.FlatAppearance.BorderSize = 4;
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(89)))), ((int)(((byte)(251)))));
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(89)))), ((int)(((byte)(251)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Font = new System.Drawing.Font("Hacen Saudi Arabia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.Black;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.ImageKey = "1479524557_check_book.png";
            this.btnUpdate.ImageList = this.imageList1;
            this.btnUpdate.Location = new System.Drawing.Point(695, 317);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(181, 41);
            this.btnUpdate.TabIndex = 253;
            this.btnUpdate.Text = "تعـــــــــــــديل";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnLockedOut
            // 
            this.btnLockedOut.BackColor = System.Drawing.SystemColors.Control;
            this.btnLockedOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLockedOut.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(89)))), ((int)(((byte)(251)))));
            this.btnLockedOut.FlatAppearance.BorderSize = 4;
            this.btnLockedOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(89)))), ((int)(((byte)(251)))));
            this.btnLockedOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(89)))), ((int)(((byte)(251)))));
            this.btnLockedOut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLockedOut.Font = new System.Drawing.Font("Hacen Saudi Arabia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLockedOut.ForeColor = System.Drawing.Color.Black;
            this.btnLockedOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLockedOut.ImageIndex = 10;
            this.btnLockedOut.ImageList = this.imageList1;
            this.btnLockedOut.Location = new System.Drawing.Point(695, 423);
            this.btnLockedOut.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLockedOut.Name = "btnLockedOut";
            this.btnLockedOut.Size = new System.Drawing.Size(181, 41);
            this.btnLockedOut.TabIndex = 256;
            this.btnLockedOut.Text = "إيقاف";
            this.btnLockedOut.UseVisualStyleBackColor = false;
            this.btnLockedOut.Click += new System.EventHandler(this.btnLockedOut_Click);
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToOrderColumns = true;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsers.ColumnHeadersHeight = 35;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.column1,
            this.column2,
            this.column4,
            this.column5,
            this.column3,
            this.column6});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(89)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsers.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUsers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvUsers.GridColor = System.Drawing.Color.Black;
            this.dgvUsers.Location = new System.Drawing.Point(14, 255);
            this.dgvUsers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsers.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.RowHeadersWidth = 50;
            this.dgvUsers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvUsers.RowTemplate.DividerHeight = 2;
            this.dgvUsers.RowTemplate.Height = 30;
            this.dgvUsers.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(664, 291);
            this.dgvUsers.TabIndex = 249;
            this.dgvUsers.Click += new System.EventHandler(this.dgvUser_Click);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // column1
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            this.column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.column1.DividerWidth = 2;
            this.column1.FillWeight = 30.45686F;
            this.column1.HeaderText = "ت";
            this.column1.MinimumWidth = 12;
            this.column1.Name = "column1";
            this.column1.ReadOnly = true;
            // 
            // column2
            // 
            this.column2.FillWeight = 187.5049F;
            this.column2.HeaderText = "اسم المستخدم";
            this.column2.MinimumWidth = 12;
            this.column2.Name = "column2";
            this.column2.ReadOnly = true;
            this.column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // column4
            // 
            this.column4.FillWeight = 101.9918F;
            this.column4.HeaderText = "الوظيفة";
            this.column4.MinimumWidth = 12;
            this.column4.Name = "column4";
            this.column4.ReadOnly = true;
            this.column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // column5
            // 
            this.column5.FillWeight = 89.70012F;
            this.column5.HeaderText = "رقم التسجيل";
            this.column5.MinimumWidth = 12;
            this.column5.Name = "column5";
            this.column5.ReadOnly = true;
            // 
            // column3
            // 
            this.column3.HeaderText = "الحالة";
            this.column3.MinimumWidth = 12;
            this.column3.Name = "column3";
            this.column3.ReadOnly = true;
            // 
            // column6
            // 
            this.column6.FillWeight = 88.35465F;
            this.column6.HeaderText = "الصورة";
            this.column6.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.column6.MinimumWidth = 12;
            this.column6.Name = "column6";
            this.column6.ReadOnly = true;
            this.column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // sfd
            // 
            this.sfd.Filter = "Bakup files (*.Bak)|*.Bak";
            // 
            // grpUserInfo
            // 
            this.grpUserInfo.BackColor = System.Drawing.SystemColors.Control;
            this.grpUserInfo.Controls.Add(this.groupBox3);
            this.grpUserInfo.Controls.Add(this.txtUserPhone);
            this.grpUserInfo.Controls.Add(this.label3);
            this.grpUserInfo.Controls.Add(this.txtUserEmail);
            this.grpUserInfo.Controls.Add(this.label2);
            this.grpUserInfo.Controls.Add(this.label1);
            this.grpUserInfo.Controls.Add(this.btnResetPass);
            this.grpUserInfo.Controls.Add(this.picUser);
            this.grpUserInfo.Controls.Add(this.txtUserName);
            this.grpUserInfo.Controls.Add(this.txtUserJob);
            this.grpUserInfo.Controls.Add(this.label7);
            this.grpUserInfo.Controls.Add(this.txtUserPassword);
            this.grpUserInfo.Controls.Add(this.label8);
            this.grpUserInfo.Controls.Add(this.label9);
            this.grpUserInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grpUserInfo.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpUserInfo.ForeColor = System.Drawing.Color.Black;
            this.grpUserInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grpUserInfo.Location = new System.Drawing.Point(14, 6);
            this.grpUserInfo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpUserInfo.Name = "grpUserInfo";
            this.grpUserInfo.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpUserInfo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grpUserInfo.Size = new System.Drawing.Size(862, 210);
            this.grpUserInfo.TabIndex = 248;
            this.grpUserInfo.TabStop = false;
            this.grpUserInfo.Text = "بيانات المستخدم";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grpPermissions);
            this.groupBox3.Controls.Add(this.btnSavePermission);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.chkAdmin);
            this.groupBox3.Controls.Add(this.cmbOperation);
            this.groupBox3.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(11, 15);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(316, 180);
            this.groupBox3.TabIndex = 231;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "صلاحيات المستخدم";
            // 
            // grpPermissions
            // 
            this.grpPermissions.Controls.Add(this.chkSelectAll);
            this.grpPermissions.Controls.Add(this.chkPrint);
            this.grpPermissions.Controls.Add(this.chkInsert);
            this.grpPermissions.Controls.Add(this.chkDelete);
            this.grpPermissions.Controls.Add(this.chkUpdate);
            this.grpPermissions.Location = new System.Drawing.Point(68, 70);
            this.grpPermissions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpPermissions.Name = "grpPermissions";
            this.grpPermissions.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpPermissions.Size = new System.Drawing.Size(244, 104);
            this.grpPermissions.TabIndex = 237;
            this.grpPermissions.TabStop = false;
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSelectAll.ForeColor = System.Drawing.Color.Black;
            this.chkSelectAll.Location = new System.Drawing.Point(136, 18);
            this.chkSelectAll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(86, 23);
            this.chkSelectAll.TabIndex = 235;
            this.chkSelectAll.Text = "تحديد الكل";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // chkPrint
            // 
            this.chkPrint.AutoSize = true;
            this.chkPrint.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrint.ForeColor = System.Drawing.Color.Black;
            this.chkPrint.Location = new System.Drawing.Point(20, 76);
            this.chkPrint.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkPrint.Name = "chkPrint";
            this.chkPrint.Size = new System.Drawing.Size(99, 23);
            this.chkPrint.TabIndex = 234;
            this.chkPrint.Text = "طباعة التقارير";
            this.chkPrint.UseVisualStyleBackColor = true;
            this.chkPrint.CheckedChanged += new System.EventHandler(this.chkInsert_CheckedChanged);
            // 
            // chkInsert
            // 
            this.chkInsert.AutoSize = true;
            this.chkInsert.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInsert.ForeColor = System.Drawing.Color.Black;
            this.chkInsert.Location = new System.Drawing.Point(128, 50);
            this.chkInsert.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkInsert.Name = "chkInsert";
            this.chkInsert.Size = new System.Drawing.Size(95, 23);
            this.chkInsert.TabIndex = 233;
            this.chkInsert.Text = "إضافة بيانات";
            this.chkInsert.UseVisualStyleBackColor = true;
            this.chkInsert.CheckedChanged += new System.EventHandler(this.chkInsert_CheckedChanged);
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDelete.ForeColor = System.Drawing.Color.Black;
            this.chkDelete.Location = new System.Drawing.Point(136, 78);
            this.chkDelete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(88, 23);
            this.chkDelete.TabIndex = 232;
            this.chkDelete.Text = "حذف بيانات";
            this.chkDelete.UseVisualStyleBackColor = true;
            this.chkDelete.CheckedChanged += new System.EventHandler(this.chkInsert_CheckedChanged);
            // 
            // chkUpdate
            // 
            this.chkUpdate.AutoSize = true;
            this.chkUpdate.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUpdate.ForeColor = System.Drawing.Color.Black;
            this.chkUpdate.Location = new System.Drawing.Point(24, 49);
            this.chkUpdate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(94, 23);
            this.chkUpdate.TabIndex = 231;
            this.chkUpdate.Text = "تعديل بيانات";
            this.chkUpdate.UseVisualStyleBackColor = true;
            this.chkUpdate.CheckedChanged += new System.EventHandler(this.chkInsert_CheckedChanged);
            // 
            // btnSavePermission
            // 
            this.btnSavePermission.BackColor = System.Drawing.SystemColors.Control;
            this.btnSavePermission.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSavePermission.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(89)))), ((int)(((byte)(251)))));
            this.btnSavePermission.FlatAppearance.BorderSize = 4;
            this.btnSavePermission.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(89)))), ((int)(((byte)(251)))));
            this.btnSavePermission.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(89)))), ((int)(((byte)(251)))));
            this.btnSavePermission.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSavePermission.Font = new System.Drawing.Font("Hacen Saudi Arabia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavePermission.ForeColor = System.Drawing.Color.Black;
            this.btnSavePermission.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnSavePermission.ImageKey = "Save.png";
            this.btnSavePermission.ImageList = this.imageList1;
            this.btnSavePermission.Location = new System.Drawing.Point(13, 132);
            this.btnSavePermission.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSavePermission.Name = "btnSavePermission";
            this.btnSavePermission.Size = new System.Drawing.Size(34, 34);
            this.btnSavePermission.TabIndex = 236;
            this.btnSavePermission.UseVisualStyleBackColor = false;
            this.btnSavePermission.Click += new System.EventHandler(this.btnSavePermission_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(10, 114);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 21);
            this.label5.TabIndex = 235;
            this.label5.Text = "حفظ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(250, 44);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 21);
            this.label4.TabIndex = 233;
            this.label4.Text = "العملية";
            // 
            // chkAdmin
            // 
            this.chkAdmin.AutoSize = true;
            this.chkAdmin.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAdmin.ForeColor = System.Drawing.Color.Maroon;
            this.chkAdmin.Location = new System.Drawing.Point(13, 16);
            this.chkAdmin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkAdmin.Name = "chkAdmin";
            this.chkAdmin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkAdmin.Size = new System.Drawing.Size(149, 21);
            this.chkAdmin.TabIndex = 232;
            this.chkAdmin.Text = "ADMINISTRATOR";
            this.chkAdmin.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.chkAdmin.UseVisualStyleBackColor = true;
            this.chkAdmin.CheckedChanged += new System.EventHandler(this.chkAdmin_CheckedChanged);
            // 
            // cmbOperation
            // 
            this.cmbOperation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbOperation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbOperation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.cmbOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbOperation.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cmbOperation.FormattingEnabled = true;
            this.cmbOperation.Location = new System.Drawing.Point(13, 41);
            this.cmbOperation.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbOperation.Name = "cmbOperation";
            this.cmbOperation.Size = new System.Drawing.Size(231, 27);
            this.cmbOperation.TabIndex = 231;
            this.cmbOperation.SelectedIndexChanged += new System.EventHandler(this.cmbOperation_SelectedIndexChanged);
            this.cmbOperation.SelectionChangeCommitted += new System.EventHandler(this.cmbOperation_SelectionChangeCommitted);
            // 
            // txtUserPhone
            // 
            this.txtUserPhone.BackColor = System.Drawing.Color.White;
            this.txtUserPhone.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserPhone.ForeColor = System.Drawing.Color.Black;
            this.txtUserPhone.Location = new System.Drawing.Point(496, 167);
            this.txtUserPhone.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUserPhone.MaxLength = 14;
            this.txtUserPhone.Name = "txtUserPhone";
            this.txtUserPhone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUserPhone.Size = new System.Drawing.Size(245, 25);
            this.txtUserPhone.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(774, 171);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(78, 21);
            this.label3.TabIndex = 24;
            this.label3.Text = "رقم الهاتف";
            // 
            // txtUserEmail
            // 
            this.txtUserEmail.BackColor = System.Drawing.Color.White;
            this.txtUserEmail.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserEmail.ForeColor = System.Drawing.Color.Black;
            this.txtUserEmail.Location = new System.Drawing.Point(496, 133);
            this.txtUserEmail.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUserEmail.Name = "txtUserEmail";
            this.txtUserEmail.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUserEmail.Size = new System.Drawing.Size(245, 25);
            this.txtUserEmail.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(748, 136);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(103, 21);
            this.label2.TabIndex = 22;
            this.label2.Text = "البريد الإلكتروني";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(374, 174);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 21);
            this.label1.TabIndex = 20;
            this.label1.Text = "تحميل صورة";
            this.label1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picUser_MouseUp);
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblMessage.Font = new System.Drawing.Font("Hacen Saudi Arabia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Black;
            this.lblMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMessage.ImageIndex = 7;
            this.lblMessage.ImageList = this.imageList1;
            this.lblMessage.Location = new System.Drawing.Point(1, 218);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(886, 34);
            this.lblMessage.TabIndex = 255;
            this.lblMessage.Text = "قائمة المستخدمين المسجلين في المنظومة";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 569);
            this.Controls.Add(this.chkShowDelUser);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnLockedOut);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.grpUserInfo);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FrmUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إدارة المستخدمين";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmUsers_FormClosing);
            this.Load += new System.EventHandler(this.FrmUsers_Load);
            this.HandleCreated += new System.EventHandler(this.FrmUsers_HandleCreated);
            this.Resize += new System.EventHandler(this.FrmUsers_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.grpUserInfo.ResumeLayout(false);
            this.grpUserInfo.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.grpPermissions.ResumeLayout(false);
            this.grpPermissions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolStripMenuItem cmsDeletePicture;
        internal System.Windows.Forms.TextBox txtUserJob;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txtUserPassword;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.OpenFileDialog ofd;
        internal System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.Button btnResetPass;
        internal System.Windows.Forms.PictureBox picUser;
        internal System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        internal System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.OpenFileDialog openFileDialog1;
        internal System.Windows.Forms.TextBox txtUserName;
        internal System.Windows.Forms.CheckBox chkShowDelUser;
        internal System.Windows.Forms.Button btnInsert;
        internal System.Windows.Forms.ImageList imageList1;
        internal System.Windows.Forms.Button btnNew;
        internal System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.Button btnUpdate;
        internal System.Windows.Forms.Button btnLockedOut;
        internal System.Windows.Forms.DataGridView dgvUsers;
        internal System.Windows.Forms.SaveFileDialog sfd;
        internal System.Windows.Forms.GroupBox grpUserInfo;
        internal System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.GroupBox grpPermissions;
        internal System.Windows.Forms.CheckBox chkSelectAll;
        internal System.Windows.Forms.CheckBox chkPrint;
        internal System.Windows.Forms.CheckBox chkInsert;
        internal System.Windows.Forms.CheckBox chkDelete;
        internal System.Windows.Forms.CheckBox chkUpdate;
        internal System.Windows.Forms.Button btnSavePermission;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.CheckBox chkAdmin;
        internal System.Windows.Forms.ComboBox cmbOperation;
        internal System.Windows.Forms.TextBox txtUserPhone;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtUserEmail;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn column3;
        private System.Windows.Forms.DataGridViewImageColumn column6;
    }
}