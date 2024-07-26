
namespace SalesProject.Forms
{
    partial class FrmMessenger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMessenger));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtChat = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.picRefresh = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.picDelete = new System.Windows.Forms.PictureBox();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.picSetChat = new System.Windows.Forms.PictureBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.picSend = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.lbLTotalMsgCount = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.RichTextBox();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.picRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSetChat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(0, 477);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Size = new System.Drawing.Size(425, 8);
            this.groupBox3.TabIndex = 376;
            this.groupBox3.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 57);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(425, 8);
            this.groupBox1.TabIndex = 374;
            this.groupBox1.TabStop = false;
            // 
            // txtChat
            // 
            this.txtChat.BackColor = System.Drawing.Color.Ivory;
            this.txtChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChat.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChat.Location = new System.Drawing.Point(4, 59);
            this.txtChat.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtChat.Name = "txtChat";
            this.txtChat.ReadOnly = true;
            this.txtChat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtChat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtChat.Size = new System.Drawing.Size(418, 350);
            this.txtChat.TabIndex = 373;
            this.txtChat.Text = "";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(0, 402);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(425, 8);
            this.groupBox2.TabIndex = 375;
            this.groupBox2.TabStop = false;
            // 
            // picRefresh
            // 
            this.picRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picRefresh.Image = ((System.Drawing.Image)(resources.GetObject("picRefresh.Image")));
            this.picRefresh.Location = new System.Drawing.Point(48, 11);
            this.picRefresh.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.picRefresh.Name = "picRefresh";
            this.picRefresh.Size = new System.Drawing.Size(35, 35);
            this.picRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRefresh.TabIndex = 365;
            this.picRefresh.TabStop = false;
            this.toolTip1.SetToolTip(this.picRefresh, "تحديث");
            this.picRefresh.Click += new System.EventHandler(this.picRefresh_Click);
            this.picRefresh.MouseEnter += new System.EventHandler(this.picNew_MouseEnter);
            this.picRefresh.MouseLeave += new System.EventHandler(this.picNew_MouseLeave);
            // 
            // picDelete
            // 
            this.picDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDelete.Image = ((System.Drawing.Image)(resources.GetObject("picDelete.Image")));
            this.picDelete.Location = new System.Drawing.Point(6, 12);
            this.picDelete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.picDelete.Name = "picDelete";
            this.picDelete.Size = new System.Drawing.Size(35, 35);
            this.picDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDelete.TabIndex = 364;
            this.picDelete.TabStop = false;
            this.toolTip1.SetToolTip(this.picDelete, "مسح المحادثة بالكامل");
            this.picDelete.Click += new System.EventHandler(this.picDelete_Click);
            this.picDelete.MouseEnter += new System.EventHandler(this.picDelete_MouseEnter);
            this.picDelete.MouseLeave += new System.EventHandler(this.picDelete_MouseLeave);
            // 
            // picUser
            // 
            this.picUser.BackColor = System.Drawing.Color.Transparent;
            this.picUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picUser.Cursor = System.Windows.Forms.Cursors.Default;
            this.picUser.Location = new System.Drawing.Point(370, 3);
            this.picUser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(50, 52);
            this.picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUser.TabIndex = 363;
            this.picUser.TabStop = false;
            this.toolTip1.SetToolTip(this.picUser, "أقصى عدد للرسائل (1000) رسالة لكل محادثة ");
            // 
            // picSetChat
            // 
            this.picSetChat.BackColor = System.Drawing.SystemColors.Control;
            this.picSetChat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSetChat.Image = ((System.Drawing.Image)(resources.GetObject("picSetChat.Image")));
            this.picSetChat.Location = new System.Drawing.Point(88, 11);
            this.picSetChat.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.picSetChat.Name = "picSetChat";
            this.picSetChat.Size = new System.Drawing.Size(35, 35);
            this.picSetChat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSetChat.TabIndex = 366;
            this.picSetChat.TabStop = false;
            this.toolTip1.SetToolTip(this.picSetChat, "عرض المحادثة بالكامل");
            this.picSetChat.Click += new System.EventHandler(this.picSetChat_Click);
            this.picSetChat.MouseEnter += new System.EventHandler(this.picSetChat_MouseEnter);
            this.picSetChat.MouseLeave += new System.EventHandler(this.picSetChat_MouseLeave);
            // 
            // lblUserName
            // 
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.Font = new System.Drawing.Font("Hacen Saudi Arabia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.Green;
            this.lblUserName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUserName.ImageKey = "(none)";
            this.lblUserName.ImageList = this.imageList3;
            this.lblUserName.Location = new System.Drawing.Point(128, 11);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUserName.Size = new System.Drawing.Size(241, 36);
            this.lblUserName.TabIndex = 368;
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lblUserName, "أقصى عدد للرسائل (1000) رسالة لكل محادثة \r\nسيتم حذف الرسائل القديمة تلقائياً\r\n");
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "1472054491_button_30.png");
            this.imageList3.Images.SetKeyName(1, "7.jpg");
            this.imageList3.Images.SetKeyName(2, "Paste.ico");
            this.imageList3.Images.SetKeyName(3, "Contacts.ico");
            this.imageList3.Images.SetKeyName(4, "user (1).png");
            this.imageList3.Images.SetKeyName(5, "participants.png");
            // 
            // picSend
            // 
            this.picSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSend.Image = ((System.Drawing.Image)(resources.GetObject("picSend.Image")));
            this.picSend.Location = new System.Drawing.Point(5, 416);
            this.picSend.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.picSend.Name = "picSend";
            this.picSend.Size = new System.Drawing.Size(59, 58);
            this.picSend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSend.TabIndex = 367;
            this.picSend.TabStop = false;
            this.picSend.Tag = "";
            this.toolTip1.SetToolTip(this.picSend, "إرسال");
            this.picSend.Click += new System.EventHandler(this.picSend_Click);
            this.picSend.MouseEnter += new System.EventHandler(this.picSend_MouseEnter);
            this.picSend.MouseLeave += new System.EventHandler(this.picSend_MouseLeave);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.White;
            this.imageList1.Images.SetKeyName(0, "1.jpg");
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(310, 485);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBox1.Size = new System.Drawing.Size(108, 17);
            this.checkBox1.TabIndex = 369;
            this.checkBox1.Text = "( Enter )  للإرسال";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblMessage.Font = new System.Drawing.Font("Hacen Saudi Arabia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMessage.ImageIndex = 5;
            this.lblMessage.ImageList = this.imageList3;
            this.lblMessage.Location = new System.Drawing.Point(426, -1);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblMessage.Size = new System.Drawing.Size(460, 35);
            this.lblMessage.TabIndex = 362;
            this.lblMessage.Text = "المستخدمون";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.BackColor = System.Drawing.Color.Ivory;
            this.lblMsg.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblMsg.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.DarkGray;
            this.lblMsg.Location = new System.Drawing.Point(326, 412);
            this.lblMsg.Margin = new System.Windows.Forms.Padding(0);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblMsg.Size = new System.Drawing.Size(92, 21);
            this.lblMsg.TabIndex = 372;
            this.lblMsg.Text = "أكتب رسالة....";
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMsg.Click += new System.EventHandler(this.lblMsg_Click);
            // 
            // lbLTotalMsgCount
            // 
            this.lbLTotalMsgCount.AutoSize = true;
            this.lbLTotalMsgCount.BackColor = System.Drawing.Color.Red;
            this.lbLTotalMsgCount.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLTotalMsgCount.ForeColor = System.Drawing.Color.White;
            this.lbLTotalMsgCount.Location = new System.Drawing.Point(470, 6);
            this.lbLTotalMsgCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLTotalMsgCount.Name = "lbLTotalMsgCount";
            this.lbLTotalMsgCount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbLTotalMsgCount.Size = new System.Drawing.Size(25, 19);
            this.lbLTotalMsgCount.TabIndex = 371;
            this.lbLTotalMsgCount.Text = "13";
            this.lbLTotalMsgCount.TextChanged += new System.EventHandler(this.lbLTotalMsgCount_TextChanged);
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.Ivory;
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(68, 410);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtMessage.Multiline = false;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMessage.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(353, 71);
            this.txtMessage.TabIndex = 370;
            this.txtMessage.Text = "";
            this.txtMessage.WordWrap = false;
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AllowUserToResizeColumns = false;
            this.dgvUsers.AllowUserToResizeRows = false;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsers.ColumnHeadersHeight = 40;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column2,
            this.column7,
            this.column1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.column3});
            this.dgvUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsers.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvUsers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvUsers.EnableHeadersVisualStyles = false;
            this.dgvUsers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dgvUsers.Location = new System.Drawing.Point(426, 33);
            this.dgvUsers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.RowHeadersWidth = 102;
            this.dgvUsers.RowTemplate.DividerHeight = 2;
            this.dgvUsers.RowTemplate.Height = 30;
            this.dgvUsers.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(460, 471);
            this.dgvUsers.TabIndex = 361;
            this.dgvUsers.Click += new System.EventHandler(this.dgvUsers_Click);
            // 
            // column2
            // 
            this.column2.HeaderText = "Id";
            this.column2.MinimumWidth = 12;
            this.column2.Name = "column2";
            this.column2.Visible = false;
            // 
            // column7
            // 
            this.column7.FillWeight = 33.68455F;
            this.column7.HeaderText = "";
            this.column7.MinimumWidth = 12;
            this.column7.Name = "column7";
            this.column7.ReadOnly = true;
            // 
            // column1
            // 
            this.column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle2.NullValue")));
            this.column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.column1.FillWeight = 65.08857F;
            this.column1.HeaderText = "";
            this.column1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.column1.MinimumWidth = 12;
            this.column1.Name = "column1";
            this.column1.ReadOnly = true;
            this.column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.FillWeight = 104.5104F;
            this.dataGridViewTextBoxColumn3.HeaderText = "";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 12;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.FillWeight = 185.2501F;
            this.dataGridViewTextBoxColumn5.HeaderText = "دخول";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 12;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.FillWeight = 185.2501F;
            this.dataGridViewTextBoxColumn6.HeaderText = "مغادرة";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 12;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // column3
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Yellow;
            this.column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.column3.FillWeight = 64.83433F;
            this.column3.HeaderText = "رسائل";
            this.column3.MinimumWidth = 12;
            this.column3.Name = "column3";
            this.column3.ReadOnly = true;
            // 
            // FrmMessenger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(888, 506);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.picRefresh);
            this.Controls.Add(this.picDelete);
            this.Controls.Add(this.picUser);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.picSetChat);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.picSend);
            this.Controls.Add(this.lbLTotalMsgCount);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximizeBox = false;
            this.Name = "FrmMessenger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "المراسلات الداخلية";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMessenger_FormClosing);
            this.Load += new System.EventHandler(this.FrmMessenger_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSetChat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.RichTextBox txtChat;
        internal System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.PictureBox picRefresh;
        internal System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.PictureBox picDelete;
        internal System.Windows.Forms.PictureBox picUser;
        internal System.Windows.Forms.PictureBox picSetChat;
        internal System.Windows.Forms.Label lblUserName;
        internal System.Windows.Forms.ImageList imageList3;
        internal System.Windows.Forms.PictureBox picSend;
        internal System.Windows.Forms.ImageList imageList1;
        internal System.Windows.Forms.CheckBox checkBox1;
        internal System.Windows.Forms.Label lblMessage;
        internal System.Windows.Forms.Label lblMsg;
        internal System.Windows.Forms.Label lbLTotalMsgCount;
        internal System.Windows.Forms.RichTextBox txtMessage;
        internal System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn column7;
        private System.Windows.Forms.DataGridViewImageColumn column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn column3;
    }
}