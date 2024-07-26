
namespace SalesProject.Forms
{
    partial class FrmLogin
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbUserName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblTimerCount = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.picUser);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbUserName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(320, 231);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // picUser
            // 
            this.picUser.Location = new System.Drawing.Point(4, 9);
            this.picUser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(66, 55);
            this.picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUser.TabIndex = 76;
            this.picUser.TabStop = false;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtPassword.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(20, 157);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPassword.Size = new System.Drawing.Size(274, 29);
            this.txtPassword.TabIndex = 77;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Hacen Saudi Arabia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(205, 125);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(93, 24);
            this.label2.TabIndex = 74;
            this.label2.Text = "كلمة المرور:";
            // 
            // cmbUserName
            // 
            this.cmbUserName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbUserName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.cmbUserName.DisplayMember = "Id";
            this.cmbUserName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUserName.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUserName.FormattingEnabled = true;
            this.cmbUserName.IntegralHeight = false;
            this.cmbUserName.Location = new System.Drawing.Point(20, 74);
            this.cmbUserName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbUserName.Name = "cmbUserName";
            this.cmbUserName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbUserName.Size = new System.Drawing.Size(274, 30);
            this.cmbUserName.TabIndex = 75;
            this.cmbUserName.TabStop = false;
            this.cmbUserName.ValueMember = "Id";
            this.cmbUserName.SelectedIndexChanged += new System.EventHandler(this.cmbUserName_SelectedIndexChanged);
            this.cmbUserName.SelectionChangeCommitted += new System.EventHandler(this.cmbUserName_SelectionChangeCommitted);
            this.cmbUserName.TextChanged += new System.EventHandler(this.cmbUserName_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Hacen Saudi Arabia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(185, 39);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(114, 24);
            this.label5.TabIndex = 73;
            this.label5.Text = "اسم المستخدم:";
            // 
            // lblUser
            // 
            this.lblUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUser.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblUser.Location = new System.Drawing.Point(14, 349);
            this.lblUser.Name = "lblUser";
            this.lblUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUser.Size = new System.Drawing.Size(126, 23);
            this.lblUser.TabIndex = 92;
            this.lblUser.Text = "رقم التسجيل";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTimerCount
            // 
            this.lblTimerCount.Font = new System.Drawing.Font("Hacen Saudi Arabia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimerCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblTimerCount.Location = new System.Drawing.Point(281, 347);
            this.lblTimerCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimerCount.Name = "lblTimerCount";
            this.lblTimerCount.Size = new System.Drawing.Size(53, 25);
            this.lblTimerCount.TabIndex = 91;
            this.lblTimerCount.Text = "30";
            this.lblTimerCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTimerCount.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExit);
            this.groupBox2.Controls.Add(this.btnOK);
            this.groupBox2.Location = new System.Drawing.Point(14, 256);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(320, 90);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnExit.FlatAppearance.BorderSize = 3;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Navy;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.ImageKey = "Printer.png";
            this.btnExit.Location = new System.Drawing.Point(20, 26);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(118, 45);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.White;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnOK.FlatAppearance.BorderSize = 3;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.Navy;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.ImageKey = "Save.ico";
            this.btnOK.Location = new System.Drawing.Point(187, 25);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(119, 46);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "دخول";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 374);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTimerCount);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.MaximizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "منظومة إدارة فواتير المبيعات - تسجيل الدخول للمنظومة";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLogin_FormClosing);
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.PictureBox picUser;
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ComboBox cmbUserName;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Button btnExit;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.Label lblTimerCount;
        internal System.Windows.Forms.Timer timer2;
        internal System.Windows.Forms.Label lblUser;
    }
}