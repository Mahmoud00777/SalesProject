using SalesProject.Classes;
using SalesProject.Properties;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SalesProject
{
    public partial class FrmStore : Form
    {
        public FrmStore()
        {
            InitializeComponent();
        }

        bool selectAllText;
        string swText;
        DataSet dsStore = new DataSet();
        DataTable dtStore = new DataTable();
        int itemId, pageSize, pageNum = 1, pagesCount, rowsCount;

        private void FrmStore_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                numericUpDown1.Value = Settings.Default.PageSize;
                btnRefresh.PerformClick();
            }
            else
                dsStore.Clear();
        }

        ResizeControls r = new ResizeControls();

        private void FrmStore_Resize(object sender, EventArgs e)
        {
            r.ResizeControl();
        }
        private void radAll_CheckedChanged(object sender, EventArgs e)
        {
            radChecked((RadioButton)sender);
        }
        private void FrmStore_HandleCreated(object sender, EventArgs e)
        {
            r.Container = this;

        }
        private void FrmStore_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        void radChecked(RadioButton sender)
        {
            if (sender.Checked == true)
            {
                pageNum = 1;
                getFillData();
            }
        }
        void getFillData()
        {
            txtPageNum.Text = pageNum.ToString();
            pageSize = Settings.Default.PageSize;

            SQLConClass sqlCon = new SQLConClass();
            SQLConClass.sqlQuery = "Select Id, ROW_NUMBER() OVER (ORDER BY (SELECT 1)) AS N ,CONVERT(NVARCHAR,[Num],100) AS Num, [Name]+' - '+Describe AS Items,StoreQuantity,LowQuantity FROM TblItems  WHERE Del=0 ";
            if (radLow.Checked == true)
                SQLConClass.sqlQuery += " and StoreQuantity<=LowQuantity and StoreQuantity<>0";
            else if (radEmpty.Checked == true)
                SQLConClass.sqlQuery += " and StoreQuantity=0";

            SQLConClass.sqlQuery += " ORDER BY [Name] OFFSET " + pageSize * (pageNum - 1) + " ROWS FETCH NEXT " + pageSize + " ROWS ONLY";

            SQLConClass.sqlQuery += " SELECT COUNT(Id) FROM TblItems WHERE Del=0";
            if (radLow.Checked == true)
                SQLConClass.sqlQuery += " and StoreQuantity<=LowQuantity and StoreQuantity<>0";
            else if (radEmpty.Checked == true)
                SQLConClass.sqlQuery += " and StoreQuantity=0";

            dsStore = sqlCon.selectData(SQLConClass.sqlQuery, 0, default);
            if (FunctionsClass.dsHasTables(dsStore))
            {
                dtStore = dsStore.Tables[0].Copy();
                dsStore.Tables[0].Clear();
                dgvStore.DataSource = dtStore;
                rowsCount = (int)dsStore.Tables[1].Rows[0][0];
                clearData();
                getPagesCount();
            }
        }
        void clearData()
        {
            txtFilter.Text = "";
            txtFilter.Focus();
            dgvStore.ClearSelection();
            itemId = 0;
            FunctionsClass.clear(grpItems);

            focusedControl = null;
            selectAllText = false;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            pageNum = 1;
            getFillData();

            //RadioButton rad;
            //foreach (Control c in this.Controls)
            //{
            //    if (c is RadioButton)
            //    {
            //        rad = (RadioButton)c;
            //        if (rad.Checked == true)
            //            radChecked(rad);
            //    }
            //}
        }
        //********************************Pagenation*******************************
        void getPagesCount()
        {
            if (rowsCount % pageSize == 0 & rowsCount != 0)
                pagesCount = rowsCount / pageSize;
            else
                pagesCount = rowsCount / pageSize + 1;

            lblPagesCount.Text = pagesCount.ToString();
            txtPageNum.Text = pageNum.ToString();
        }
        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            checkPageSize();

            if (pageNum > 1)
                pageNum -= 1;

            getFillData();
        }
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            checkPageSize();

            if (pageNum < pagesCount)
                pageNum += 1;

            getFillData();
        }
        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            pageNum = 1;
            getFillData();
        }
        private void btnLastPage_Click(object sender, EventArgs e)
        {
            checkPageSize();

            pageNum = pagesCount;

            getFillData();
        }
        private void txtPageNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtPageNum.Text == string.Empty) return;

            if (e.KeyCode == Keys.Enter)
            {
                checkPageSize();

                if (Convert.ToInt32(txtPageNum.Text) > Convert.ToInt32(lblPagesCount.Text))
                    pageNum = Convert.ToInt32(lblPagesCount.Text);
                else if (Convert.ToInt32(txtPageNum.Text) <= 0)
                    pageNum = 1;
                else
                    pageNum = Convert.ToInt32(txtPageNum.Text);

                getFillData();
            }
        }
        void checkPageSize()
        {
            if (pageSize != Settings.Default.PageSize)
            {
                pageNum = 1;
                getFillData();
            }
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.PageSize = (int)numericUpDown1.Value;
            Settings.Default.Save();
        }
        private void txtPageNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !FunctionsClass.isPositiveIntNum(e);
        }
        //******************************TouchScreen****************************************************
        Control focusedControl;
        private void txtStoreQ_Enter(object sender, EventArgs e)
        {
            focusedControl = (Control)sender;
        }
        private void txtStoreQ_Click(object sender, EventArgs e)
        {
            selectAll((TextBox)sender);
        }
        void selectAll(TextBox sender)
        {
            sender.SelectAll();
            selectAllText = true;
        }
        private void touchScreenButton(string number)
        {
            if (focusedControl != null)
            {
                if (selectAllText == true)
                {
                    focusedControl.Text = number;
                    selectAllText = false;
                }
                else
                    focusedControl.Text += number;
            }
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            touchScreenButton(((Button)sender).Text);
        }
        private void btnC_Click(object sender, EventArgs e)
        {
            if (focusedControl != null)
                if (selectAllText == true)
                    focusedControl.Text = "";
                else if (focusedControl.Text.Length > 0)
                    focusedControl.Text = focusedControl.Text.Substring(0, focusedControl.Text.Length - 1);
        }
        private void bEnter_Click(object sender, EventArgs e)
        {
            if (focusedControl != null)
                if (focusedControl.Name == "txtPageNum")
                {
                    focusedControl.Focus();
                    SendKeys.Send("{ENTER}");   //SendKeys.Send("1");
                }
        }
        private void lblSearch_Click(object sender, EventArgs e)
        {
            txtFilter.Focus();
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (txtFilter.Text.Trim() == "")
                lblSearch.Visible = true;
            else
                lblSearch.Visible = false;

            dtStore.DefaultView.RowFilter = " Items Like '%" + txtFilter.Text.Trim() + "%' OR Num Like '%" + txtFilter.Text.Trim() + "%'";
            dgvStore.ClearSelection();
        }
        private void dgvStore_Click(object sender, EventArgs e)
        {
            if (FunctionsClass.checkDgvError(dgvStore) == true)
                return;

            itemId = (int)dgvStore.Rows[dgvStore.CurrentRow.Index].Cells[0].Value;
            txtItemName.Text = dgvStore.Rows[dgvStore.CurrentRow.Index].Cells[3].Value.ToString();
            txtStoreQ.Text = dgvStore.Rows[dgvStore.CurrentRow.Index].Cells[4].Value.ToString();
            txtLowQ.Text = dgvStore.Rows[dgvStore.CurrentRow.Index].Cells[5].Value.ToString();

            txtStoreQ.Focus();
            txtStoreQ.SelectAll();
            selectAllText = true;
        }
        private void dgvStore_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dtStore = FunctionsClass.columnHeaderMouseClick((DataGridView)sender, dtStore);
            clearData();
        }
        private void dgvStore_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (Convert.ToInt32(dgvStore.Rows[e.RowIndex].Cells[4].Value) == 0)
            {
                e.CellStyle.BackColor = Color.FromArgb(244, 61, 67);
                e.CellStyle.SelectionBackColor = Color.Red;
                e.CellStyle.SelectionForeColor = Color.Yellow;
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            }
            else if (Convert.ToInt32(dgvStore.Rows[e.RowIndex].Cells[4].Value) <= Convert.ToInt32(dgvStore.Rows[e.RowIndex].Cells[5].Value))
            {
                e.CellStyle.BackColor = Color.FromArgb(255, 255, 192);
                e.CellStyle.SelectionBackColor = Color.Yellow;
                e.CellStyle.SelectionForeColor = Color.Red;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (itemId == 0)
            {
                MessageBox.Show("الرجاء تحديد الصنف من القائمة", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (txtStoreQ.Text.Trim() == "" | txtLowQ.Text.Trim() == "")
            {
                MessageBox.Show("يرجى ادخال الكميات", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //if (Convert.ToInt32(txtStoreQ.Text) <= Convert.ToInt32(txtLowQ.Text))
            //{
            //    MessageBox.Show("يجب أن يكون الحد الأدنى أقل من الكمية في المخزن",  "خطأ إدخال",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            //    return;
            //}

            //if (Convert.ToInt32(txtStoreQ.Text) < 0 | Convert.ToInt32(txtLowQ.Text) < 0)
            //{
            //    MessageBox.Show("خطأ في ادخال الكميات", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            SQLConClass sqlCon = new SQLConClass();
            SQLConClass.sqlQuery = "UPDATE TblItems Set StoreQuantity=@StoreQuantity,LowQuantity=@LowQuantity WHERE Id=@itemId";
            SqlParameter[] param = new SqlParameter[] {
                           new SqlParameter("@itemId", itemId),
                           new SqlParameter("@StoreQuantity",Convert.ToInt32(txtStoreQ.Text)),
                           new SqlParameter("@LowQuantity",Convert.ToInt32(txtLowQ.Text)) };

            sqlCon.cmdExecute(SQLConClass.sqlQuery, 0, param);

            btnRefresh.PerformClick();
        }
        private void txtStoreQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !FunctionsClass.isPositiveIntNum(e);
        }
        private void txtLowQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !FunctionsClass.isPositiveIntNum(e);
        }

    }
}
