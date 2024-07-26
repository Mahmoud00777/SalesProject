
namespace SalesProject.Forms
{
    partial class FrmDelElements
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDelElements));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radCategory = new System.Windows.Forms.RadioButton();
            this.radCustomer = new System.Windows.Forms.RadioButton();
            this.radItem = new System.Windows.Forms.RadioButton();
            this.radInvoice = new System.Windows.Forms.RadioButton();
            this.lblFind = new System.Windows.Forms.Label();
            this.dgvDelElements = new System.Windows.Forms.DataGridView();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDelElements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnRefresh.FlatAppearance.BorderSize = 3;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Hacen Saudi Arabia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.Navy;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.ImageKey = "refresh-icon.png";
            this.btnRefresh.ImageList = this.imageList2;
            this.btnRefresh.Location = new System.Drawing.Point(584, 329);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnRefresh.Size = new System.Drawing.Size(242, 46);
            this.btnRefresh.TabIndex = 242;
            this.btnRefresh.Text = "تحديث";
            this.btnRefresh.UseVisualStyleBackColor = false;
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
            this.imageList2.Images.SetKeyName(16, "Delete.ico");
            this.imageList2.Images.SetKeyName(17, "refresh-icon.png");
            // 
            // btnRestore
            // 
            this.btnRestore.BackColor = System.Drawing.Color.White;
            this.btnRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestore.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnRestore.FlatAppearance.BorderSize = 3;
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.Font = new System.Drawing.Font("Hacen Saudi Arabia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestore.ForeColor = System.Drawing.Color.Navy;
            this.btnRestore.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRestore.ImageKey = "Forward 2.ico";
            this.btnRestore.ImageList = this.imageList2;
            this.btnRestore.Location = new System.Drawing.Point(584, 269);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnRestore.Size = new System.Drawing.Size(242, 46);
            this.btnRestore.TabIndex = 241;
            this.btnRestore.Text = "اسـتـعـــــــــادة";
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClose.FlatAppearance.BorderSize = 3;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Hacen Saudi Arabia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Navy;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.ImageKey = "Del.ico";
            this.btnClose.ImageList = this.imageList2;
            this.btnClose.Location = new System.Drawing.Point(584, 391);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClose.Size = new System.Drawing.Size(242, 46);
            this.btnClose.TabIndex = 240;
            this.btnClose.Text = "اغــلاق";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Hacen Saudi Arabia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.ImageKey = "4n9tt.png";
            this.label1.Location = new System.Drawing.Point(567, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 35);
            this.label1.TabIndex = 239;
            this.label1.Text = "نوع العناصر المحذوفة";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.radCategory);
            this.groupBox2.Controls.Add(this.radCustomer);
            this.groupBox2.Controls.Add(this.radItem);
            this.groupBox2.Controls.Add(this.radInvoice);
            this.groupBox2.Location = new System.Drawing.Point(568, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(270, 195);
            this.groupBox2.TabIndex = 238;
            this.groupBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(179, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(88, 183);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // radCategory
            // 
            this.radCategory.AutoSize = true;
            this.radCategory.Font = new System.Drawing.Font("Hacen Saudi Arabia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radCategory.Location = new System.Drawing.Point(65, 147);
            this.radCategory.Name = "radCategory";
            this.radCategory.Size = new System.Drawing.Size(102, 28);
            this.radCategory.TabIndex = 3;
            this.radCategory.TabStop = true;
            this.radCategory.Tag = "المجموعة";
            this.radCategory.Text = "المجموعات";
            this.radCategory.UseVisualStyleBackColor = true;
            this.radCategory.CheckedChanged += new System.EventHandler(this.radCategory_CheckedChanged);
            // 
            // radCustomer
            // 
            this.radCustomer.AutoSize = true;
            this.radCustomer.Font = new System.Drawing.Font("Hacen Saudi Arabia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radCustomer.Location = new System.Drawing.Point(100, 63);
            this.radCustomer.Name = "radCustomer";
            this.radCustomer.Size = new System.Drawing.Size(67, 28);
            this.radCustomer.TabIndex = 2;
            this.radCustomer.TabStop = true;
            this.radCustomer.Tag = "الزبون";
            this.radCustomer.Text = "الزبائن";
            this.radCustomer.UseVisualStyleBackColor = true;
            this.radCustomer.CheckedChanged += new System.EventHandler(this.radCustomer_CheckedChanged);
            // 
            // radItem
            // 
            this.radItem.AutoSize = true;
            this.radItem.Font = new System.Drawing.Font("Hacen Saudi Arabia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radItem.Location = new System.Drawing.Point(90, 105);
            this.radItem.Name = "radItem";
            this.radItem.Size = new System.Drawing.Size(77, 28);
            this.radItem.TabIndex = 1;
            this.radItem.TabStop = true;
            this.radItem.Tag = "الصنف";
            this.radItem.Text = "الأصناف";
            this.radItem.UseVisualStyleBackColor = true;
            this.radItem.CheckedChanged += new System.EventHandler(this.radItem_CheckedChanged);
            // 
            // radInvoice
            // 
            this.radInvoice.AutoSize = true;
            this.radInvoice.Font = new System.Drawing.Font("Hacen Saudi Arabia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radInvoice.Location = new System.Drawing.Point(91, 21);
            this.radInvoice.Name = "radInvoice";
            this.radInvoice.Size = new System.Drawing.Size(76, 28);
            this.radInvoice.TabIndex = 0;
            this.radInvoice.TabStop = true;
            this.radInvoice.Tag = "الفاتورة";
            this.radInvoice.Text = "الفواتير";
            this.radInvoice.UseVisualStyleBackColor = true;
            this.radInvoice.CheckedChanged += new System.EventHandler(this.radInvoice_CheckedChanged);
            // 
            // lblFind
            // 
            this.lblFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblFind.Font = new System.Drawing.Font("Hacen Saudi Arabia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFind.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblFind.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblFind.ImageIndex = 16;
            this.lblFind.Location = new System.Drawing.Point(0, 9);
            this.lblFind.Name = "lblFind";
            this.lblFind.Size = new System.Drawing.Size(551, 35);
            this.lblFind.TabIndex = 237;
            this.lblFind.Text = "بيانات العناصر المحذوفة";
            this.lblFind.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvDelElements
            // 
            this.dgvDelElements.AllowUserToAddRows = false;
            this.dgvDelElements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDelElements.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dgvDelElements.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Hacen Saudi Arabia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDelElements.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDelElements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDelElements.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDelElements.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvDelElements.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDelElements.Location = new System.Drawing.Point(11, 87);
            this.dgvDelElements.Name = "dgvDelElements";
            this.dgvDelElements.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvDelElements.RowHeadersVisible = false;
            this.dgvDelElements.RowHeadersWidth = 102;
            this.dgvDelElements.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDelElements.RowTemplate.DividerHeight = 2;
            this.dgvDelElements.RowTemplate.Height = 35;
            this.dgvDelElements.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDelElements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDelElements.Size = new System.Drawing.Size(529, 324);
            this.dgvDelElements.TabIndex = 229;
            this.dgvDelElements.Tag = "0";
            this.dgvDelElements.Click += new System.EventHandler(this.dgvDelElements_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(495, 47);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(51, 37);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 239;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(46, 34);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 238;
            this.pictureBox2.TabStop = false;
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilter.Location = new System.Drawing.Point(11, 53);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(478, 28);
            this.txtFilter.TabIndex = 212;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.lblFind);
            this.groupBox1.Controls.Add(this.dgvDelElements);
            this.groupBox1.Controls.Add(this.txtFilter);
            this.groupBox1.Location = new System.Drawing.Point(9, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(551, 425);
            this.groupBox1.TabIndex = 237;
            this.groupBox1.TabStop = false;
            // 
            // FrmDelElements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 455);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximizeBox = false;
            this.Name = "FrmDelElements";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إدارة بيانات العناصر المحذوفة";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDelElements_FormClosing);
            this.Load += new System.EventHandler(this.FrmDelElements_Load);
            this.HandleCreated += new System.EventHandler(this.FrmDelElements_HandleCreated);
            this.Resize += new System.EventHandler(this.FrmDelElements_Resize);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDelElements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnRefresh;
        internal System.Windows.Forms.ImageList imageList2;
        internal System.Windows.Forms.Button btnRestore;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.RadioButton radCategory;
        internal System.Windows.Forms.RadioButton radCustomer;
        internal System.Windows.Forms.RadioButton radItem;
        internal System.Windows.Forms.RadioButton radInvoice;
        internal System.Windows.Forms.Label lblFind;
        internal System.Windows.Forms.DataGridView dgvDelElements;
        internal System.Windows.Forms.PictureBox pictureBox3;
        internal System.Windows.Forms.PictureBox pictureBox2;
        internal System.Windows.Forms.TextBox txtFilter;
        internal System.Windows.Forms.GroupBox groupBox1;
    }
}