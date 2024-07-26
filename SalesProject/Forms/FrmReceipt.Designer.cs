namespace SalesProject.Forms
{
    partial class FrmReceipt
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtReceipt = new System.Windows.Forms.TextBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.grbRecive = new System.Windows.Forms.GroupBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtNet = new System.Windows.Forms.TextBox();
            this.txtValueReceipt = new System.Windows.Forms.TextBox();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtReceipter = new System.Windows.Forms.TextBox();
            this.grbRecive.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(428, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "أسم العميل";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(160, 27);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(231, 26);
            this.cmbCustomer.TabIndex = 1;
            this.cmbCustomer.SelectionChangeCommitted += new System.EventHandler(this.cmbCustomer_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(391, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "إجمالي فواتير";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(253, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "القيمة المستلمة";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(115, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "القيمة المستحقة";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(371, 96);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(121, 24);
            this.txtTotal.TabIndex = 5;
            // 
            // txtReceipt
            // 
            this.txtReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceipt.Location = new System.Drawing.Point(244, 96);
            this.txtReceipt.Name = "txtReceipt";
            this.txtReceipt.Size = new System.Drawing.Size(121, 24);
            this.txtReceipt.TabIndex = 6;
            // 
            // txtValue
            // 
            this.txtValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue.Location = new System.Drawing.Point(109, 96);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(121, 24);
            this.txtValue.TabIndex = 7;
            // 
            // grbRecive
            // 
            this.grbRecive.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.grbRecive.Controls.Add(this.txtNote);
            this.grbRecive.Controls.Add(this.dtpTime);
            this.grbRecive.Controls.Add(this.dtpDate);
            this.grbRecive.Controls.Add(this.txtNet);
            this.grbRecive.Controls.Add(this.txtValueReceipt);
            this.grbRecive.Controls.Add(this.txtNum);
            this.grbRecive.Controls.Add(this.label9);
            this.grbRecive.Controls.Add(this.label8);
            this.grbRecive.Controls.Add(this.label7);
            this.grbRecive.Controls.Add(this.label6);
            this.grbRecive.Controls.Add(this.label5);
            this.grbRecive.Location = new System.Drawing.Point(43, 140);
            this.grbRecive.Name = "grbRecive";
            this.grbRecive.Size = new System.Drawing.Size(562, 195);
            this.grbRecive.TabIndex = 8;
            this.grbRecive.TabStop = false;
            this.grbRecive.Text = "بيانات إيصال المادي";
            // 
            // txtNote
            // 
            this.txtNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.Location = new System.Drawing.Point(39, 161);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(408, 24);
            this.txtNote.TabIndex = 13;
            // 
            // dtpTime
            // 
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTime.Location = new System.Drawing.Point(15, 52);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(139, 20);
            this.dtpTime.TabIndex = 12;
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(15, 26);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(139, 20);
            this.dtpDate.TabIndex = 11;
            // 
            // txtNet
            // 
            this.txtNet.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNet.Location = new System.Drawing.Point(39, 128);
            this.txtNet.Name = "txtNet";
            this.txtNet.Size = new System.Drawing.Size(406, 24);
            this.txtNet.TabIndex = 10;
            // 
            // txtValueReceipt
            // 
            this.txtValueReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValueReceipt.Location = new System.Drawing.Point(352, 77);
            this.txtValueReceipt.Name = "txtValueReceipt";
            this.txtValueReceipt.Size = new System.Drawing.Size(123, 24);
            this.txtValueReceipt.TabIndex = 9;
            this.txtValueReceipt.TextChanged += new System.EventHandler(this.txtValueReceipt_TextChanged);
            // 
            // txtNum
            // 
            this.txtNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNum.Location = new System.Drawing.Point(352, 26);
            this.txtNum.Name = "txtNum";
            this.txtNum.ReadOnly = true;
            this.txtNum.Size = new System.Drawing.Size(123, 24);
            this.txtNum.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(160, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 21);
            this.label9.TabIndex = 7;
            this.label9.Text = "تاريخ الايصال";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(498, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 21);
            this.label8.TabIndex = 6;
            this.label8.Text = "البيان";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(467, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 21);
            this.label7.TabIndex = 5;
            this.label7.Text = "إجمالي بالحروف";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(481, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 21);
            this.label6.TabIndex = 4;
            this.label6.Tag = "";
            this.label6.Text = "قيمة الايصال";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(489, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 21);
            this.label5.TabIndex = 3;
            this.label5.Text = "رقم الايصال";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(494, 355);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 43);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "حفظ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(384, 355);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(105, 43);
            this.btnNew.TabIndex = 10;
            this.btnNew.Text = "جديد";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(277, 355);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(105, 43);
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = "طباعة";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(177, 355);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 21);
            this.label10.TabIndex = 12;
            this.label10.Text = "المستلم";
            // 
            // txtReceipter
            // 
            this.txtReceipter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceipter.Location = new System.Drawing.Point(45, 351);
            this.txtReceipter.Name = "txtReceipter";
            this.txtReceipter.Size = new System.Drawing.Size(121, 24);
            this.txtReceipter.TabIndex = 13;
            // 
            // FrmReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 410);
            this.Controls.Add(this.txtReceipter);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grbRecive);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.txtReceipt);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.label1);
            this.Name = "FrmReceipt";
            this.Text = "إيصال إستلام المادي";
            this.Load += new System.EventHandler(this.FrmReceipt_Load);
            this.grbRecive.ResumeLayout(false);
            this.grbRecive.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtReceipt;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.GroupBox grbRecive;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox txtNet;
        private System.Windows.Forms.TextBox txtValueReceipt;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtReceipter;
        private System.Windows.Forms.TextBox txtNote;
    }
}