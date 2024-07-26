namespace SalesProject.Forms
{
    partial class FrmAccountStatement
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvAccount = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ت = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoteFor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USERNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbCustomers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAccount
            // 
            this.dgvAccount.AllowUserToAddRows = false;
            this.dgvAccount.AllowUserToDeleteRows = false;
            this.dgvAccount.AllowUserToResizeColumns = false;
            this.dgvAccount.AllowUserToResizeRows = false;
            this.dgvAccount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAccount.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccount.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.ت,
            this.Num,
            this.Date,
            this.Value,
            this.NoteFor,
            this.USERNAME});
            this.dgvAccount.Location = new System.Drawing.Point(2, 131);
            this.dgvAccount.Name = "dgvAccount";
            this.dgvAccount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvAccount.RowHeadersVisible = false;
            this.dgvAccount.Size = new System.Drawing.Size(680, 325);
            this.dgvAccount.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // ت
            // 
            this.ت.DataPropertyName = "ت";
            this.ت.HeaderText = "ت";
            this.ت.Name = "ت";
            // 
            // Num
            // 
            this.Num.DataPropertyName = "Num";
            this.Num.HeaderText = "رقم الايصال";
            this.Num.Name = "Num";
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "تاريخ الايصال";
            this.Date.Name = "Date";
            // 
            // Value
            // 
            this.Value.DataPropertyName = "Value";
            this.Value.HeaderText = "القيمة";
            this.Value.Name = "Value";
            // 
            // NoteFor
            // 
            this.NoteFor.DataPropertyName = "NoteFor";
            this.NoteFor.HeaderText = "ملاحظة";
            this.NoteFor.Name = "NoteFor";
            // 
            // USERNAME
            // 
            this.USERNAME.DataPropertyName = "USERNAME";
            this.USERNAME.HeaderText = "مستلم";
            this.USERNAME.Name = "USERNAME";
            // 
            // cmbCustomers
            // 
            this.cmbCustomers.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCustomers.FormattingEnabled = true;
            this.cmbCustomers.Location = new System.Drawing.Point(250, 24);
            this.cmbCustomers.Name = "cmbCustomers";
            this.cmbCustomers.Size = new System.Drawing.Size(205, 27);
            this.cmbCustomers.TabIndex = 1;
            this.cmbCustomers.SelectionChangeCommitted += new System.EventHandler(this.cmbCustomers_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Hacen Saudi Arabia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(477, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "أسم الزبون";
            // 
            // FrmAccountStatement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 459);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCustomers);
            this.Controls.Add(this.dgvAccount);
            this.Name = "FrmAccountStatement";
            this.Text = "FrmAccountStatement";
            this.Load += new System.EventHandler(this.FrmAccountStatement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ت;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoteFor;
        private System.Windows.Forms.DataGridViewTextBoxColumn USERNAME;
        private System.Windows.Forms.ComboBox cmbCustomers;
        private System.Windows.Forms.Label label1;
    }
}