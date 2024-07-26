
namespace SalesProject.Forms
{
    partial class FrmItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmItem));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnUnit = new System.Windows.Forms.Button();
            this.btnCountry = new System.Windows.Forms.Button();
            this.btnDelCategory = new System.Windows.Forms.Button();
            this.btnUpdateCategory = new System.Windows.Forms.Button();
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.btnFindItemNum = new System.Windows.Forms.Button();
            this.picItem = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsDeletePicture = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsDelCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.lstCategory = new System.Windows.Forms.ListBox();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtLowQuantity = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.txtUpdateCategory = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.grpItem = new System.Windows.Forms.GroupBox();
            this.txtDescribe = new System.Windows.Forms.TextBox();
            this.cmbName = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtStoreQuantity = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSalePrice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtPurchasePrice = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtAddCategory = new System.Windows.Forms.TextBox();
            this.lstItem = new System.Windows.Forms.ListBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picItem)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.grpItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUnit
            // 
            this.btnUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUnit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUnit.FlatAppearance.BorderSize = 0;
            this.btnUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnit.ForeColor = System.Drawing.Color.White;
            this.btnUnit.Image = ((System.Drawing.Image)(resources.GetObject("btnUnit.Image")));
            this.btnUnit.Location = new System.Drawing.Point(191, 320);
            this.btnUnit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnUnit.Name = "btnUnit";
            this.btnUnit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnUnit.Size = new System.Drawing.Size(37, 28);
            this.btnUnit.TabIndex = 672;
            this.btnUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnUnit, "اضافة وحدة");
            this.btnUnit.UseVisualStyleBackColor = false;
            this.btnUnit.Click += new System.EventHandler(this.btnUnit_Click);
            // 
            // btnCountry
            // 
            this.btnCountry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnCountry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCountry.FlatAppearance.BorderSize = 0;
            this.btnCountry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCountry.ForeColor = System.Drawing.Color.White;
            this.btnCountry.Image = ((System.Drawing.Image)(resources.GetObject("btnCountry.Image")));
            this.btnCountry.Location = new System.Drawing.Point(16, 216);
            this.btnCountry.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCountry.Name = "btnCountry";
            this.btnCountry.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnCountry.Size = new System.Drawing.Size(37, 28);
            this.btnCountry.TabIndex = 228;
            this.btnCountry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnCountry, "اضافة بلد الصنع");
            this.btnCountry.UseVisualStyleBackColor = false;
            this.btnCountry.Click += new System.EventHandler(this.btnCountry_Click);
            // 
            // btnDelCategory
            // 
            this.btnDelCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnDelCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelCategory.FlatAppearance.BorderSize = 0;
            this.btnDelCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelCategory.ForeColor = System.Drawing.Color.White;
            this.btnDelCategory.Image = ((System.Drawing.Image)(resources.GetObject("btnDelCategory.Image")));
            this.btnDelCategory.Location = new System.Drawing.Point(472, 478);
            this.btnDelCategory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDelCategory.Name = "btnDelCategory";
            this.btnDelCategory.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDelCategory.Size = new System.Drawing.Size(37, 29);
            this.btnDelCategory.TabIndex = 240;
            this.toolTip1.SetToolTip(this.btnDelCategory, "حذف المجموعة");
            this.btnDelCategory.UseVisualStyleBackColor = false;
            this.btnDelCategory.Click += new System.EventHandler(this.btnDelCategory_Click);
            // 
            // btnUpdateCategory
            // 
            this.btnUpdateCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnUpdateCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateCategory.FlatAppearance.BorderSize = 0;
            this.btnUpdateCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateCategory.ForeColor = System.Drawing.Color.White;
            this.btnUpdateCategory.ImageKey = "111.png";
            this.btnUpdateCategory.ImageList = this.imageList3;
            this.btnUpdateCategory.Location = new System.Drawing.Point(276, 478);
            this.btnUpdateCategory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnUpdateCategory.Name = "btnUpdateCategory";
            this.btnUpdateCategory.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnUpdateCategory.Size = new System.Drawing.Size(37, 29);
            this.btnUpdateCategory.TabIndex = 239;
            this.toolTip1.SetToolTip(this.btnUpdateCategory, "تعديل اسم المجموعة");
            this.btnUpdateCategory.UseVisualStyleBackColor = false;
            this.btnUpdateCategory.Click += new System.EventHandler(this.btnUpdateCategory_Click);
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Black;
            this.imageList3.Images.SetKeyName(0, "111.png");
            // 
            // btnFindItemNum
            // 
            this.btnFindItemNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnFindItemNum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFindItemNum.FlatAppearance.BorderSize = 0;
            this.btnFindItemNum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFindItemNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindItemNum.ForeColor = System.Drawing.Color.White;
            this.btnFindItemNum.Image = ((System.Drawing.Image)(resources.GetObject("btnFindItemNum.Image")));
            this.btnFindItemNum.Location = new System.Drawing.Point(18, 31);
            this.btnFindItemNum.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFindItemNum.Name = "btnFindItemNum";
            this.btnFindItemNum.Size = new System.Drawing.Size(35, 26);
            this.btnFindItemNum.TabIndex = 205;
            this.btnFindItemNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.btnFindItemNum, "بحث");
            this.btnFindItemNum.UseVisualStyleBackColor = false;
            this.btnFindItemNum.Click += new System.EventHandler(this.btnFindItemNum_Click);
            // 
            // picItem
            // 
            this.picItem.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.picItem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picItem.BackgroundImage")));
            this.picItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picItem.ContextMenuStrip = this.contextMenuStrip2;
            this.picItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picItem.Location = new System.Drawing.Point(18, 262);
            this.picItem.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.picItem.Name = "picItem";
            this.picItem.Size = new System.Drawing.Size(157, 155);
            this.picItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picItem.TabIndex = 37;
            this.picItem.TabStop = false;
            this.toolTip1.SetToolTip(this.picItem, "أنقر لإضافة صورة للمستخدم والزر الأيمن للحذف");
            this.picItem.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picItem_MouseUp);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsDeletePicture});
            this.contextMenuStrip2.Name = "ContextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(138, 26);
            // 
            // cmsDeletePicture
            // 
            this.cmsDeletePicture.Name = "cmsDeletePicture";
            this.cmsDeletePicture.Size = new System.Drawing.Size(137, 22);
            this.cmsDeletePicture.Text = "حذف الصورة";
            this.cmsDeletePicture.Click += new System.EventHandler(this.cmsDeletePicture_Click);
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnAddCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddCategory.FlatAppearance.BorderSize = 0;
            this.btnAddCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCategory.ForeColor = System.Drawing.Color.White;
            this.btnAddCategory.Image = ((System.Drawing.Image)(resources.GetObject("btnAddCategory.Image")));
            this.btnAddCategory.Location = new System.Drawing.Point(276, 64);
            this.btnAddCategory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnAddCategory.Size = new System.Drawing.Size(37, 29);
            this.btnAddCategory.TabIndex = 235;
            this.toolTip1.SetToolTip(this.btnAddCategory, "اضافة مجموعة");
            this.btnAddCategory.UseVisualStyleBackColor = false;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsDelCategory});
            this.contextMenuStrip1.Name = "CmsCategory";
            this.contextMenuStrip1.Size = new System.Drawing.Size(100, 26);
            // 
            // cmsDelCategory
            // 
            this.cmsDelCategory.Name = "cmsDelCategory";
            this.cmsDelCategory.Size = new System.Drawing.Size(99, 22);
            this.cmsDelCategory.Text = "حذف";
            this.cmsDelCategory.Click += new System.EventHandler(this.cmsDelCategory_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Hacen Saudi Arabia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.ImageKey = "refresh-icon.png";
            this.btnRefresh.ImageList = this.imageList2;
            this.btnRefresh.Location = new System.Drawing.Point(518, 464);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnRefresh.Size = new System.Drawing.Size(140, 43);
            this.btnRefresh.TabIndex = 230;
            this.btnRefresh.Text = "تحديث";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
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
            this.imageList2.Images.SetKeyName(32, "Save.png");
            this.imageList2.Images.SetKeyName(33, "3.png");
            // 
            // lstCategory
            // 
            this.lstCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lstCategory.ContextMenuStrip = this.contextMenuStrip1;
            this.lstCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstCategory.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lstCategory.FormattingEnabled = true;
            this.lstCategory.ItemHeight = 19;
            this.lstCategory.Location = new System.Drawing.Point(276, 93);
            this.lstCategory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lstCategory.Name = "lstCategory";
            this.lstCategory.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lstCategory.Size = new System.Drawing.Size(234, 346);
            this.lstCategory.TabIndex = 231;
            this.lstCategory.Click += new System.EventHandler(this.lstCategory_Click);
            // 
            // cmbUnit
            // 
            this.cmbUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(226, 320);
            this.cmbUnit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(126, 29);
            this.cmbUnit.TabIndex = 671;
            // 
            // cmbCountry
            // 
            this.cmbCountry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.cmbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Location = new System.Drawing.Point(52, 215);
            this.cmbCountry.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(300, 29);
            this.cmbCountry.TabIndex = 669;
            // 
            // lblBarcode
            // 
            this.lblBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblBarcode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBarcode.Font = new System.Drawing.Font("CarolinaBar-B39-2.5-22x158x720", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarcode.Location = new System.Drawing.Point(18, 59);
            this.lblBarcode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(332, 36);
            this.lblBarcode.TabIndex = 220;
            this.lblBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNum
            // 
            this.txtNum.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNum.Location = new System.Drawing.Point(52, 31);
            this.txtNum.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNum.Name = "txtNum";
            this.txtNum.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNum.Size = new System.Drawing.Size(299, 26);
            this.txtNum.TabIndex = 0;
            this.txtNum.Click += new System.EventHandler(this.txtNum_Click);
            this.txtNum.TextChanged += new System.EventHandler(this.txtNum_TextChanged);
            this.txtNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNum_KeyDown);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(378, 36);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(66, 19);
            this.label21.TabIndex = 218;
            this.label21.Text = "رقم الصنف";
            // 
            // txtLowQuantity
            // 
            this.txtLowQuantity.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLowQuantity.Location = new System.Drawing.Point(191, 286);
            this.txtLowQuantity.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtLowQuantity.Name = "txtLowQuantity";
            this.txtLowQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLowQuantity.Size = new System.Drawing.Size(160, 26);
            this.txtLowQuantity.TabIndex = 6;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(379, 291);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(63, 19);
            this.label31.TabIndex = 216;
            this.label31.Text = "الحد الأدنى";
            // 
            // txtUpdateCategory
            // 
            this.txtUpdateCategory.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUpdateCategory.Location = new System.Drawing.Point(314, 478);
            this.txtUpdateCategory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUpdateCategory.Name = "txtUpdateCategory";
            this.txtUpdateCategory.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUpdateCategory.Size = new System.Drawing.Size(159, 29);
            this.txtUpdateCategory.TabIndex = 238;
            this.txtUpdateCategory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label16.Font = new System.Drawing.Font("Hacen Saudi Arabia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label16.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label16.ImageKey = "2.png";
            this.label16.ImageList = this.imageList1;
            this.label16.Location = new System.Drawing.Point(10, 28);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label16.Size = new System.Drawing.Size(260, 35);
            this.label16.TabIndex = 237;
            this.label16.Text = "الاصناف";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.White;
            this.imageList1.Images.SetKeyName(0, "1479606346_config-users.png");
            this.imageList1.Images.SetKeyName(1, "3d bar chart.bmp");
            this.imageList1.Images.SetKeyName(2, "13.png");
            this.imageList1.Images.SetKeyName(3, "198-512.png");
            this.imageList1.Images.SetKeyName(4, "checklist-icon-277x300.png");
            this.imageList1.Images.SetKeyName(5, "solution.png");
            this.imageList1.Images.SetKeyName(6, "6.jpg");
            this.imageList1.Images.SetKeyName(7, "9.jpg");
            this.imageList1.Images.SetKeyName(8, "27.jpg");
            this.imageList1.Images.SetKeyName(9, "32.jpg");
            this.imageList1.Images.SetKeyName(10, "33.jpg");
            this.imageList1.Images.SetKeyName(11, "35.jpg");
            this.imageList1.Images.SetKeyName(12, "images.jpg");
            this.imageList1.Images.SetKeyName(13, "images.png");
            this.imageList1.Images.SetKeyName(14, "5.jpg");
            this.imageList1.Images.SetKeyName(15, "5.png");
            this.imageList1.Images.SetKeyName(16, "8.jpg");
            this.imageList1.Images.SetKeyName(17, "18.jpg");
            this.imageList1.Images.SetKeyName(18, "19.jpg");
            this.imageList1.Images.SetKeyName(19, "22.png");
            this.imageList1.Images.SetKeyName(20, "3.png");
            this.imageList1.Images.SetKeyName(21, "6.png");
            this.imageList1.Images.SetKeyName(22, "7.jpg");
            this.imageList1.Images.SetKeyName(23, "2.png");
            // 
            // grpItem
            // 
            this.grpItem.Controls.Add(this.txtDescribe);
            this.grpItem.Controls.Add(this.btnUnit);
            this.grpItem.Controls.Add(this.btnCountry);
            this.grpItem.Controls.Add(this.cmbUnit);
            this.grpItem.Controls.Add(this.cmbCountry);
            this.grpItem.Controls.Add(this.lblBarcode);
            this.grpItem.Controls.Add(this.txtNum);
            this.grpItem.Controls.Add(this.label21);
            this.grpItem.Controls.Add(this.txtLowQuantity);
            this.grpItem.Controls.Add(this.label31);
            this.grpItem.Controls.Add(this.cmbName);
            this.grpItem.Controls.Add(this.label24);
            this.grpItem.Controls.Add(this.txtStoreQuantity);
            this.grpItem.Controls.Add(this.label12);
            this.grpItem.Controls.Add(this.txtSalePrice);
            this.grpItem.Controls.Add(this.label8);
            this.grpItem.Controls.Add(this.btnFindItemNum);
            this.grpItem.Controls.Add(this.label27);
            this.grpItem.Controls.Add(this.picItem);
            this.grpItem.Controls.Add(this.label18);
            this.grpItem.Controls.Add(this.cmbCategory);
            this.grpItem.Controls.Add(this.label22);
            this.grpItem.Controls.Add(this.txtPurchasePrice);
            this.grpItem.Controls.Add(this.label19);
            this.grpItem.Controls.Add(this.label20);
            this.grpItem.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9.75F);
            this.grpItem.Location = new System.Drawing.Point(518, 23);
            this.grpItem.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpItem.Name = "grpItem";
            this.grpItem.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grpItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grpItem.Size = new System.Drawing.Size(452, 428);
            this.grpItem.TabIndex = 232;
            this.grpItem.TabStop = false;
            this.grpItem.Text = "بيانات الصنف";
            // 
            // txtDescribe
            // 
            this.txtDescribe.Location = new System.Drawing.Point(16, 145);
            this.txtDescribe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDescribe.Name = "txtDescribe";
            this.txtDescribe.Size = new System.Drawing.Size(335, 28);
            this.txtDescribe.TabIndex = 673;
            // 
            // cmbName
            // 
            this.cmbName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.cmbName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbName.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.cmbName.FormattingEnabled = true;
            this.cmbName.Location = new System.Drawing.Point(16, 112);
            this.cmbName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbName.Name = "cmbName";
            this.cmbName.Size = new System.Drawing.Size(335, 27);
            this.cmbName.TabIndex = 1;
            this.cmbName.Tag = "1";
            this.cmbName.SelectionChangeCommitted += new System.EventHandler(this.cmbName_SelectionChangeCommitted);
            this.cmbName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbName_KeyDown);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(396, 325);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(46, 19);
            this.label24.TabIndex = 211;
            this.label24.Text = "الوحدة";
            // 
            // txtStoreQuantity
            // 
            this.txtStoreQuantity.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStoreQuantity.Location = new System.Drawing.Point(191, 252);
            this.txtStoreQuantity.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtStoreQuantity.Name = "txtStoreQuantity";
            this.txtStoreQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtStoreQuantity.Size = new System.Drawing.Size(160, 26);
            this.txtStoreQuantity.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Hacen Saudi Arabia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(352, 257);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 18);
            this.label12.TabIndex = 209;
            this.label12.Text = "الكمية في المخزن";
            // 
            // txtSalePrice
            // 
            this.txtSalePrice.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalePrice.Location = new System.Drawing.Point(191, 388);
            this.txtSalePrice.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSalePrice.Name = "txtSalePrice";
            this.txtSalePrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSalePrice.Size = new System.Drawing.Size(160, 26);
            this.txtSalePrice.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(384, 393);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 19);
            this.label8.TabIndex = 207;
            this.label8.Text = "سعر البيع";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(372, 154);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(73, 19);
            this.label27.TabIndex = 44;
            this.label27.Text = "وصف الصنف";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(388, 221);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(57, 19);
            this.label18.TabIndex = 33;
            this.label18.Text = "بلد الصنع";
            // 
            // cmbCategory
            // 
            this.cmbCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(16, 181);
            this.cmbCategory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(335, 29);
            this.cmbCategory.TabIndex = 3;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(382, 185);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(62, 19);
            this.label22.TabIndex = 28;
            this.label22.Text = "المجموعة";
            // 
            // txtPurchasePrice
            // 
            this.txtPurchasePrice.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPurchasePrice.Location = new System.Drawing.Point(191, 354);
            this.txtPurchasePrice.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPurchasePrice.Name = "txtPurchasePrice";
            this.txtPurchasePrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPurchasePrice.Size = new System.Drawing.Size(161, 26);
            this.txtPurchasePrice.TabIndex = 8;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(380, 359);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 19);
            this.label19.TabIndex = 6;
            this.label19.Text = "سعر الشراء";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(373, 117);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(69, 19);
            this.label20.TabIndex = 25;
            this.label20.Text = "اسم الصنف";
            // 
            // txtAddCategory
            // 
            this.txtAddCategory.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddCategory.Location = new System.Drawing.Point(314, 64);
            this.txtAddCategory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtAddCategory.Name = "txtAddCategory";
            this.txtAddCategory.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAddCategory.Size = new System.Drawing.Size(196, 29);
            this.txtAddCategory.TabIndex = 234;
            this.txtAddCategory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAddCategory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddCategory_KeyDown);
            // 
            // lstItem
            // 
            this.lstItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lstItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstItem.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lstItem.FormattingEnabled = true;
            this.lstItem.ItemHeight = 19;
            this.lstItem.Location = new System.Drawing.Point(10, 62);
            this.lstItem.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lstItem.Name = "lstItem";
            this.lstItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lstItem.Size = new System.Drawing.Size(260, 422);
            this.lstItem.TabIndex = 233;
            this.lstItem.Click += new System.EventHandler(this.lstItem_Click);
            this.lstItem.DoubleClick += new System.EventHandler(this.lstItem_DoubleClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Hacen Saudi Arabia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.ImageIndex = 29;
            this.btnDelete.ImageList = this.imageList2;
            this.btnDelete.Location = new System.Drawing.Point(674, 464);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDelete.Size = new System.Drawing.Size(140, 43);
            this.btnDelete.TabIndex = 229;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label32.Font = new System.Drawing.Font("Hacen Saudi Arabia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label32.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label32.ImageKey = "7.jpg";
            this.label32.ImageList = this.imageList1;
            this.label32.Location = new System.Drawing.Point(276, 28);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label32.Size = new System.Drawing.Size(234, 35);
            this.label32.TabIndex = 236;
            this.label32.Text = "المجموعات";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Hacen Saudi Arabia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.ImageKey = "save_as.gif";
            this.btnSave.ImageList = this.imageList2;
            this.btnSave.Location = new System.Drawing.Point(830, 464);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSave.Size = new System.Drawing.Size(140, 43);
            this.btnSave.TabIndex = 228;
            this.btnSave.Text = "حفـــــظ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(977, 518);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lstCategory);
            this.Controls.Add(this.btnDelCategory);
            this.Controls.Add(this.btnUpdateCategory);
            this.Controls.Add(this.txtUpdateCategory);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.grpItem);
            this.Controls.Add(this.btnAddCategory);
            this.Controls.Add(this.txtAddCategory);
            this.Controls.Add(this.lstItem);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "FrmItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmItem";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmItem_FormClosing);
            this.Load += new System.EventHandler(this.FrmItem_Load);
            this.HandleCreated += new System.EventHandler(this.FrmItem_HandleCreated);
            this.Resize += new System.EventHandler(this.FrmItem_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picItem)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.grpItem.ResumeLayout(false);
            this.grpItem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.Button btnUnit;
        internal System.Windows.Forms.Button btnCountry;
        internal System.Windows.Forms.Button btnDelCategory;
        internal System.Windows.Forms.Button btnUpdateCategory;
        internal System.Windows.Forms.ImageList imageList3;
        internal System.Windows.Forms.Button btnFindItemNum;
        internal System.Windows.Forms.PictureBox picItem;
        internal System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        internal System.Windows.Forms.ToolStripMenuItem cmsDeletePicture;
        internal System.Windows.Forms.Button btnAddCategory;
        internal System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem cmsDelCategory;
        internal System.Windows.Forms.Button btnRefresh;
        internal System.Windows.Forms.ImageList imageList2;
        internal System.Windows.Forms.ListBox lstCategory;
        internal System.Windows.Forms.ComboBox cmbUnit;
        internal System.Windows.Forms.ComboBox cmbCountry;
        internal System.Windows.Forms.Label lblBarcode;
        internal System.Windows.Forms.TextBox txtNum;
        internal System.Windows.Forms.Label label21;
        internal System.Windows.Forms.TextBox txtLowQuantity;
        internal System.Windows.Forms.Label label31;
        internal System.Windows.Forms.TextBox txtUpdateCategory;
        internal System.Windows.Forms.Label label16;
        internal System.Windows.Forms.ImageList imageList1;
        internal System.Windows.Forms.GroupBox grpItem;
        internal System.Windows.Forms.ComboBox cmbName;
        internal System.Windows.Forms.Label label24;
        internal System.Windows.Forms.TextBox txtStoreQuantity;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.TextBox txtSalePrice;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label27;
        internal System.Windows.Forms.Label label18;
        internal System.Windows.Forms.ComboBox cmbCategory;
        internal System.Windows.Forms.Label label22;
        internal System.Windows.Forms.TextBox txtPurchasePrice;
        internal System.Windows.Forms.Label label19;
        internal System.Windows.Forms.Label label20;
        internal System.Windows.Forms.TextBox txtAddCategory;
        internal System.Windows.Forms.ListBox lstItem;
        internal System.Windows.Forms.Button btnDelete;
        internal System.Windows.Forms.Label label32;
        internal System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDescribe;
    }
}