
namespace SalesProject.Forms
{
    partial class FrmCustomers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomers));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.txtPageNum = new System.Windows.Forms.TextBox();
            this.btnFirstPage = new System.Windows.Forms.Button();
            this.btnLastPage = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPagesCount = new System.Windows.Forms.Label();
            this.btnPreviousPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.pnlPagenation = new System.Windows.Forms.Panel();
            this.cmbCustomerName = new System.Windows.Forms.ComboBox();
            this.label38 = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.btnSaveCustomer = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnRefresh = new System.Windows.Forms.Button();
            this.grpCustomer = new System.Windows.Forms.GroupBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ت = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Del = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label33 = new System.Windows.Forms.Label();
            this.btnAccountStatement = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.pnlPagenation.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(7, 19);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.numericUpDown1.Size = new System.Drawing.Size(59, 29);
            this.numericUpDown1.TabIndex = 240;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // txtPageNum
            // 
            this.txtPageNum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPageNum.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.txtPageNum.Location = new System.Drawing.Point(282, 3);
            this.txtPageNum.Name = "txtPageNum";
            this.txtPageNum.Size = new System.Drawing.Size(64, 29);
            this.txtPageNum.TabIndex = 245;
            this.txtPageNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPageNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPageNum_KeyDown);
            this.txtPageNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPageNum_KeyPress);
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnFirstPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFirstPage.FlatAppearance.BorderSize = 0;
            this.btnFirstPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirstPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFirstPage.ForeColor = System.Drawing.Color.White;
            this.btnFirstPage.Location = new System.Drawing.Point(396, 2);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnFirstPage.Size = new System.Drawing.Size(54, 32);
            this.btnFirstPage.TabIndex = 244;
            this.btnFirstPage.Text = "<<";
            this.btnFirstPage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFirstPage.UseVisualStyleBackColor = false;
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
            // 
            // btnLastPage
            // 
            this.btnLastPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnLastPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLastPage.FlatAppearance.BorderSize = 0;
            this.btnLastPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLastPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLastPage.ForeColor = System.Drawing.Color.White;
            this.btnLastPage.Location = new System.Drawing.Point(179, 2);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnLastPage.Size = new System.Drawing.Size(54, 32);
            this.btnLastPage.TabIndex = 243;
            this.btnLastPage.Text = ">>";
            this.btnLastPage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLastPage.UseVisualStyleBackColor = false;
            this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(67, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 21);
            this.label2.TabIndex = 228;
            this.label2.Text = "عدد الصفحات";
            // 
            // lblPagesCount
            // 
            this.lblPagesCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblPagesCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPagesCount.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagesCount.Location = new System.Drawing.Point(2, 3);
            this.lblPagesCount.Name = "lblPagesCount";
            this.lblPagesCount.Size = new System.Drawing.Size(63, 30);
            this.lblPagesCount.TabIndex = 241;
            this.lblPagesCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnPreviousPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreviousPage.FlatAppearance.BorderSize = 0;
            this.btnPreviousPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreviousPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreviousPage.ForeColor = System.Drawing.Color.White;
            this.btnPreviousPage.Location = new System.Drawing.Point(356, 2);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPreviousPage.Size = new System.Drawing.Size(37, 32);
            this.btnPreviousPage.TabIndex = 239;
            this.btnPreviousPage.Text = "<";
            this.btnPreviousPage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreviousPage.UseVisualStyleBackColor = false;
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnNextPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextPage.FlatAppearance.BorderSize = 0;
            this.btnNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextPage.ForeColor = System.Drawing.Color.White;
            this.btnNextPage.Location = new System.Drawing.Point(236, 2);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnNextPage.Size = new System.Drawing.Size(37, 32);
            this.btnNextPage.TabIndex = 238;
            this.btnNextPage.Text = ">";
            this.btnNextPage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNextPage.UseVisualStyleBackColor = false;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // pnlPagenation
            // 
            this.pnlPagenation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pnlPagenation.Controls.Add(this.txtPageNum);
            this.pnlPagenation.Controls.Add(this.btnFirstPage);
            this.pnlPagenation.Controls.Add(this.btnLastPage);
            this.pnlPagenation.Controls.Add(this.label2);
            this.pnlPagenation.Controls.Add(this.lblPagesCount);
            this.pnlPagenation.Controls.Add(this.btnPreviousPage);
            this.pnlPagenation.Controls.Add(this.btnNextPage);
            this.pnlPagenation.Location = new System.Drawing.Point(111, 12);
            this.pnlPagenation.Name = "pnlPagenation";
            this.pnlPagenation.Size = new System.Drawing.Size(452, 36);
            this.pnlPagenation.TabIndex = 246;
            // 
            // cmbCustomerName
            // 
            this.cmbCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.cmbCustomerName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCustomerName.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cmbCustomerName.FormattingEnabled = true;
            this.cmbCustomerName.Location = new System.Drawing.Point(16, 69);
            this.cmbCustomerName.Name = "cmbCustomerName";
            this.cmbCustomerName.Size = new System.Drawing.Size(245, 27);
            this.cmbCustomerName.TabIndex = 0;
            this.cmbCustomerName.SelectionChangeCommitted += new System.EventHandler(this.cmbCustomerName_SelectionChangeCommitted);
            this.cmbCustomerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCustomerName_KeyDown);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9F);
            this.label38.Location = new System.Drawing.Point(306, 120);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(47, 19);
            this.label38.TabIndex = 224;
            this.label38.Text = "الشركة";
            // 
            // txtCompany
            // 
            this.txtCompany.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtCompany.Location = new System.Drawing.Point(16, 115);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCompany.Size = new System.Drawing.Size(244, 26);
            this.txtCompany.TabIndex = 1;
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtPhone.Location = new System.Drawing.Point(16, 157);
            this.txtPhone.MaxLength = 14;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPhone.Size = new System.Drawing.Size(244, 26);
            this.txtPhone.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtEmail.Location = new System.Drawing.Point(16, 201);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtEmail.Size = new System.Drawing.Size(244, 26);
            this.txtEmail.TabIndex = 3;
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtAddress.Location = new System.Drawing.Point(16, 244);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAddress.Size = new System.Drawing.Size(244, 68);
            this.txtAddress.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pnlPagenation);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Location = new System.Drawing.Point(15, 444);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(574, 56);
            this.groupBox2.TabIndex = 251;
            this.groupBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-3, -5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 21);
            this.label3.TabIndex = 242;
            this.label3.Text = "حجم الصفحة";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9F);
            this.label39.Location = new System.Drawing.Point(275, 247);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(78, 19);
            this.label39.TabIndex = 214;
            this.label39.Text = "العنـــــــــــوان";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9F);
            this.label41.Location = new System.Drawing.Point(312, 73);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(41, 19);
            this.label41.TabIndex = 206;
            this.label41.Text = "الاسم";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9F);
            this.label45.Location = new System.Drawing.Point(283, 160);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(70, 19);
            this.label45.TabIndex = 210;
            this.label45.Text = "رقم الهاتف";
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtId.Enabled = false;
            this.txtId.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtId.Location = new System.Drawing.Point(16, 26);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtId.Size = new System.Drawing.Size(244, 26);
            this.txtId.TabIndex = 39;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.Location = new System.Drawing.Point(277, 27);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(75, 19);
            this.label43.TabIndex = 40;
            this.label43.Text = "رقم التسجيل";
            // 
            // btnSaveCustomer
            // 
            this.btnSaveCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveCustomer.Font = new System.Drawing.Font("Hacen Saudi Arabia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveCustomer.ImageKey = "save_as.gif";
            this.btnSaveCustomer.ImageList = this.imageList2;
            this.btnSaveCustomer.Location = new System.Drawing.Point(799, 392);
            this.btnSaveCustomer.Name = "btnSaveCustomer";
            this.btnSaveCustomer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSaveCustomer.Size = new System.Drawing.Size(166, 38);
            this.btnSaveCustomer.TabIndex = 244;
            this.btnSaveCustomer.Text = "حفـــــظ";
            this.btnSaveCustomer.UseVisualStyleBackColor = true;
            this.btnSaveCustomer.Click += new System.EventHandler(this.btnSaveCustomer_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Printer.png");
            this.imageList2.Images.SetKeyName(1, "le-updates-icon.png");
            this.imageList2.Images.SetKeyName(2, "Refresh.ico");
            this.imageList2.Images.SetKeyName(3, "Print.ico");
            this.imageList2.Images.SetKeyName(4, "Search.ico");
            this.imageList2.Images.SetKeyName(5, "Save.ico");
            this.imageList2.Images.SetKeyName(6, "Del.ico");
            this.imageList2.Images.SetKeyName(7, "View Doc.ico");
            this.imageList2.Images.SetKeyName(8, "Add Card.ico");
            this.imageList2.Images.SetKeyName(9, "Add Folder.ico");
            this.imageList2.Images.SetKeyName(10, "Back 2.ico");
            this.imageList2.Images.SetKeyName(11, "Download.ico");
            this.imageList2.Images.SetKeyName(12, "Forward 2.ico");
            this.imageList2.Images.SetKeyName(13, "Properties.ico");
            this.imageList2.Images.SetKeyName(14, "Rename - Edit.ico");
            this.imageList2.Images.SetKeyName(15, "Spell.ico");
            this.imageList2.Images.SetKeyName(16, "6.jpg");
            this.imageList2.Images.SetKeyName(17, "7.jpg");
            this.imageList2.Images.SetKeyName(18, "12.jpg");
            this.imageList2.Images.SetKeyName(19, "13.jpg");
            this.imageList2.Images.SetKeyName(20, "14.jpg");
            this.imageList2.Images.SetKeyName(21, "19.jpg");
            this.imageList2.Images.SetKeyName(22, "1.jpg");
            this.imageList2.Images.SetKeyName(23, "9.jpg");
            this.imageList2.Images.SetKeyName(24, "Edit.ico");
            this.imageList2.Images.SetKeyName(25, "Delete.ico");
            this.imageList2.Images.SetKeyName(26, "Actions-trash-empty-icon.png");
            this.imageList2.Images.SetKeyName(27, "Actions-view-refresh-icon.png");
            this.imageList2.Images.SetKeyName(28, "recycle_bin_full3.png");
            this.imageList2.Images.SetKeyName(29, "trashcan_full.png");
            this.imageList2.Images.SetKeyName(30, "refresh-icon.png");
            this.imageList2.Images.SetKeyName(31, "save_as.gif");
            // 
            // btnRefresh
            // 
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Hacen Saudi Arabia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.ImageIndex = 30;
            this.btnRefresh.ImageList = this.imageList2;
            this.btnRefresh.Location = new System.Drawing.Point(799, 452);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnRefresh.Size = new System.Drawing.Size(166, 38);
            this.btnRefresh.TabIndex = 246;
            this.btnRefresh.Text = "تحديث";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grpCustomer
            // 
            this.grpCustomer.Controls.Add(this.cmbCustomerName);
            this.grpCustomer.Controls.Add(this.label38);
            this.grpCustomer.Controls.Add(this.txtCompany);
            this.grpCustomer.Controls.Add(this.txtPhone);
            this.grpCustomer.Controls.Add(this.txtEmail);
            this.grpCustomer.Controls.Add(this.txtAddress);
            this.grpCustomer.Controls.Add(this.label39);
            this.grpCustomer.Controls.Add(this.label40);
            this.grpCustomer.Controls.Add(this.label41);
            this.grpCustomer.Controls.Add(this.label45);
            this.grpCustomer.Controls.Add(this.txtId);
            this.grpCustomer.Controls.Add(this.label43);
            this.grpCustomer.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCustomer.Location = new System.Drawing.Point(606, 61);
            this.grpCustomer.Name = "grpCustomer";
            this.grpCustomer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grpCustomer.Size = new System.Drawing.Size(359, 328);
            this.grpCustomer.TabIndex = 247;
            this.grpCustomer.TabStop = false;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9F);
            this.label40.Location = new System.Drawing.Point(262, 204);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(91, 19);
            this.label40.TabIndex = 213;
            this.label40.Text = "البريد الإلكتروني";
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label17.Font = new System.Drawing.Font("Hacen Saudi Arabia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label17.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label17.ImageKey = "user (1).png";
            this.label17.ImageList = this.imageList3;
            this.label17.Location = new System.Drawing.Point(606, 17);
            this.label17.Name = "label17";
            this.label17.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label17.Size = new System.Drawing.Size(359, 40);
            this.label17.TabIndex = 249;
            this.label17.Text = "بيانات العميل";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dgvCustomers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCustomers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCustomers.ColumnHeadersHeight = 35;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.ت,
            this.CustomerName,
            this.Company,
            this.Phone,
            this.Email,
            this.Address,
            this.Id1,
            this.Del});
            this.dgvCustomers.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCustomers.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCustomers.EnableHeadersVisualStyles = false;
            this.dgvCustomers.Location = new System.Drawing.Point(15, 70);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvCustomers.RowHeadersVisible = false;
            this.dgvCustomers.RowHeadersWidth = 102;
            this.dgvCustomers.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCustomers.RowTemplate.DividerHeight = 2;
            this.dgvCustomers.RowTemplate.Height = 35;
            this.dgvCustomers.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(574, 368);
            this.dgvCustomers.TabIndex = 248;
            this.dgvCustomers.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCustomers_ColumnHeaderMouseClick);
            this.dgvCustomers.Click += new System.EventHandler(this.dgvCustomers_Click);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // ت
            // 
            this.ت.DataPropertyName = "ت";
            this.ت.HeaderText = "ت";
            this.ت.Name = "ت";
            this.ت.ReadOnly = true;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.HeaderText = "الاسم";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // Company
            // 
            this.Company.DataPropertyName = "Company";
            this.Company.HeaderText = "الشركة";
            this.Company.Name = "Company";
            this.Company.ReadOnly = true;
            // 
            // Phone
            // 
            this.Phone.DataPropertyName = "Phone";
            this.Phone.HeaderText = "رقم الهاتف";
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "العنوان";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            // 
            // Id1
            // 
            this.Id1.DataPropertyName = "Id1";
            this.Id1.HeaderText = "رقم التسجيل";
            this.Id1.Name = "Id1";
            this.Id1.ReadOnly = true;
            // 
            // Del
            // 
            this.Del.DataPropertyName = "Del";
            this.Del.HeaderText = "Del";
            this.Del.Name = "Del";
            this.Del.ReadOnly = true;
            this.Del.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Hacen Saudi Arabia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.ImageIndex = 29;
            this.btnDelete.ImageList = this.imageList2;
            this.btnDelete.Location = new System.Drawing.Point(606, 392);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDelete.Size = new System.Drawing.Size(166, 38);
            this.btnDelete.TabIndex = 245;
            this.btnDelete.Text = "حـــذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label33
            // 
            this.label33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label33.Font = new System.Drawing.Font("Hacen Saudi Arabia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label33.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label33.ImageKey = "participants.png";
            this.label33.ImageList = this.imageList3;
            this.label33.Location = new System.Drawing.Point(15, 29);
            this.label33.Name = "label33";
            this.label33.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label33.Size = new System.Drawing.Size(574, 40);
            this.label33.TabIndex = 250;
            this.label33.Text = "قائمة العملاء المسجلين";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAccountStatement
            // 
            this.btnAccountStatement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccountStatement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccountStatement.Font = new System.Drawing.Font("Hacen Saudi Arabia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccountStatement.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAccountStatement.ImageList = this.imageList2;
            this.btnAccountStatement.Location = new System.Drawing.Point(606, 452);
            this.btnAccountStatement.Name = "btnAccountStatement";
            this.btnAccountStatement.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAccountStatement.Size = new System.Drawing.Size(166, 38);
            this.btnAccountStatement.TabIndex = 252;
            this.btnAccountStatement.Text = "كشف الحساب الزبائن";
            this.btnAccountStatement.UseVisualStyleBackColor = true;
            this.btnAccountStatement.Click += new System.EventHandler(this.btnAccountStatement_Click);
            // 
            // FrmCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(981, 512);
            this.Controls.Add(this.btnAccountStatement);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSaveCustomer);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.grpCustomer);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.dgvCustomers);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label33);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "FrmCustomers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCustomers";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCustomers_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.FrmCustomers_VisibleChanged);
            this.HandleCreated += new System.EventHandler(this.FrmCustomers_HandleCreated);
            this.Resize += new System.EventHandler(this.FrmCustomers_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.pnlPagenation.ResumeLayout(false);
            this.pnlPagenation.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpCustomer.ResumeLayout(false);
            this.grpCustomer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.NumericUpDown numericUpDown1;
        internal System.Windows.Forms.TextBox txtPageNum;
        internal System.Windows.Forms.Button btnFirstPage;
        internal System.Windows.Forms.Button btnLastPage;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label lblPagesCount;
        internal System.Windows.Forms.Button btnPreviousPage;
        internal System.Windows.Forms.Button btnNextPage;
        internal System.Windows.Forms.Panel pnlPagenation;
        internal System.Windows.Forms.ComboBox cmbCustomerName;
        internal System.Windows.Forms.Label label38;
        internal System.Windows.Forms.TextBox txtCompany;
        internal System.Windows.Forms.TextBox txtPhone;
        internal System.Windows.Forms.TextBox txtEmail;
        internal System.Windows.Forms.TextBox txtAddress;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label39;
        internal System.Windows.Forms.Label label41;
        internal System.Windows.Forms.Label label45;
        internal System.Windows.Forms.TextBox txtId;
        internal System.Windows.Forms.Label label43;
        internal System.Windows.Forms.Button btnSaveCustomer;
        internal System.Windows.Forms.ImageList imageList2;
        internal System.Windows.Forms.Button btnRefresh;
        internal System.Windows.Forms.GroupBox grpCustomer;
        internal System.Windows.Forms.Label label40;
        internal System.Windows.Forms.Label label17;
        internal System.Windows.Forms.ImageList imageList3;
        internal System.Windows.Forms.DataGridView dgvCustomers;
        internal System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.Label label33;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ت;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Del;
        internal System.Windows.Forms.Button btnAccountStatement;
    }
}