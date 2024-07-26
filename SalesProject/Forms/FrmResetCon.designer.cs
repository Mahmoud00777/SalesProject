
namespace SalesProject.Forms
{
    partial class FrmResetCon
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSQLUser = new System.Windows.Forms.TextBox();
            this.lable111 = new System.Windows.Forms.Label();
            this.txtSQLPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.OFD = new System.Windows.Forms.OpenFileDialog();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.txtSQLUser);
            this.groupBox5.Controls.Add(this.lable111);
            this.groupBox5.Controls.Add(this.txtSQLPassword);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.txtServer);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.txtDatabase);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.Black;
            this.groupBox5.Location = new System.Drawing.Point(11, 11);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox5.Size = new System.Drawing.Size(324, 291);
            this.groupBox5.TabIndex = 58;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Settings Of System Connection";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(12, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(291, 46);
            this.button1.TabIndex = 59;
            this.button1.Text = "Applay Settings";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnApplay_Click);
            // 
            // txtSQLUser
            // 
            this.txtSQLUser.BackColor = System.Drawing.Color.White;
            this.txtSQLUser.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSQLUser.ForeColor = System.Drawing.Color.Black;
            this.txtSQLUser.Location = new System.Drawing.Point(115, 125);
            this.txtSQLUser.Name = "txtSQLUser";
            this.txtSQLUser.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSQLUser.Size = new System.Drawing.Size(188, 26);
            this.txtSQLUser.TabIndex = 39;
            this.txtSQLUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lable111
            // 
            this.lable111.AutoSize = true;
            this.lable111.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable111.ForeColor = System.Drawing.Color.Black;
            this.lable111.Location = new System.Drawing.Point(6, 166);
            this.lable111.Name = "lable111";
            this.lable111.Size = new System.Drawing.Size(99, 19);
            this.lable111.TabIndex = 42;
            this.lable111.Text = "SQLPassword";
            // 
            // txtSQLPassword
            // 
            this.txtSQLPassword.BackColor = System.Drawing.Color.White;
            this.txtSQLPassword.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSQLPassword.Location = new System.Drawing.Point(115, 166);
            this.txtSQLPassword.Name = "txtSQLPassword";
            this.txtSQLPassword.PasswordChar = '*';
            this.txtSQLPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSQLPassword.Size = new System.Drawing.Size(188, 26);
            this.txtSQLPassword.TabIndex = 40;
            this.txtSQLPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 19);
            this.label2.TabIndex = 41;
            this.label2.Text = "SQLUserName";
            // 
            // txtServer
            // 
            this.txtServer.BackColor = System.Drawing.Color.White;
            this.txtServer.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServer.ForeColor = System.Drawing.Color.Black;
            this.txtServer.Location = new System.Drawing.Point(115, 45);
            this.txtServer.Name = "txtServer";
            this.txtServer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtServer.Size = new System.Drawing.Size(188, 26);
            this.txtServer.TabIndex = 34;
            this.txtServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(6, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 19);
            this.label4.TabIndex = 37;
            this.label4.Text = "Database Name";
            // 
            // txtDatabase
            // 
            this.txtDatabase.BackColor = System.Drawing.Color.White;
            this.txtDatabase.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatabase.Location = new System.Drawing.Point(115, 84);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDatabase.Size = new System.Drawing.Size(188, 26);
            this.txtDatabase.TabIndex = 35;
            this.txtDatabase.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(8, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 19);
            this.label5.TabIndex = 36;
            this.label5.Text = "Server Name";
            // 
            // OFD
            // 
            this.OFD.Filter = "Bakup files (*.Bak)|*.Bak";
            this.OFD.Title = "استرجاع قاعدة البيانات";
            // 
            // FrmResetCon
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 315);
            this.Controls.Add(this.groupBox5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "FrmResetCon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ضبط الإتصال بالسيرفر وقواعد البيانات";
            this.Load += new System.EventHandler(this.FrmResetCon_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.GroupBox groupBox5;
        internal System.Windows.Forms.Button button1;
        internal System.Windows.Forms.TextBox txtSQLUser;
        internal System.Windows.Forms.Label lable111;
        internal System.Windows.Forms.TextBox txtSQLPassword;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtServer;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtDatabase;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.OpenFileDialog OFD;
    }
}