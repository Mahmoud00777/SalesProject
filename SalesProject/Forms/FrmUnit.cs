using SalesProject.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesProject.Forms
{
    public partial class FrmUnit : Form
    {
        private DataSet dsUnit = new DataSet();
        private int unitID;
        private int cr = -1;
        public FrmUnit()
        {
            InitializeComponent();
        }

        private void FrmUnit_Load(object sender, EventArgs e)
        {
            getFillData();
            setDgvHeader();
        }
        private void getFillData()
        {
            ConClass.sqlQuery = "SELECT Id , ROW_NUMBER() OVER (ORDER BY (SELECT 1)) ت , Unit FROM TblUnits ORDER BY Unit";
            var sqlCon = new SQLConClass();
            dsUnit = sqlCon.SelectData(ConClass.sqlQuery, 0, default);
            if (FunctionsClass.dsHasTables(dsUnit))
            {
                dgvUnit.DataSource = dsUnit.Tables[0];
                dgvUnit.ClearSelection();
            }
            else
            {
                Dispose();
            }
        }
        private void setDgvHeader()
        {
            if (!FunctionsClass.dsHasTables(dsUnit))
                return;
            dgvUnit.Columns[0].Visible = false;
            dgvUnit.Columns[1].Width = 50;
            dgvUnit.Columns[2].HeaderText = "الوحدة";
        }
        private void dgvUnit_Click(object sender, EventArgs e)
        {
            if (FunctionsClass.checkDGVError(dgvUnit) == true)
                return;

            cr = dgvUnit.CurrentRow.Index;
            displayData();
        }
        private void displayData()
        {
            unitID = Convert.ToInt32(dgvUnit.Rows[cr].Cells[0].Value);
            txtUnit.Text = dgvUnit.Rows[cr].Cells[2].Value.ToString();
            txtUnit.Focus();
        }
        private void txtUnit_TextChanged(object sender, EventArgs e)
        {
            if (unitID == 0)
            {
                dsUnit.Tables[0].DefaultView.RowFilter = " Unit Like '%" + txtUnit.Text.Trim() + "%'";
                dgvUnit.ClearSelection();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (unitID != 0)
                btnRefresh.PerformClick();
            SaveUnit();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (unitID == 0)
            {
                MessageBox.Show("الرجاء تحديد عنصر من القائمة", "تعديل بيانات", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SaveUnit();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cr = -1;
            unitID = 0;
            dgvUnit.ClearSelection();
            txtUnit.Clear();
            txtUnit.Focus();
            getFillData();
        }
        private void SaveUnit()
        {
            if (txtUnit.Text.Trim() == "")
                return;
            var sqlCon = new SQLConClass();
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@Id", unitID), new SqlParameter("@Unit", txtUnit.Text.Trim()) };
            sqlCon.CMDExecute("SaveUnit", 1, param);
            getFillData();
            selectItem();
        }
        private void selectItem()
        {
            DataRow[] itemRows = dsUnit.Tables[0].Select("Unit='" + txtUnit.Text.Trim() + "'");
            if (itemRows.Length > 0)
            {
                cr = Convert.ToInt32(itemRows[0][1]) - 1;
                dgvUnit.Rows[cr].Selected = true;
                dgvUnit.FirstDisplayedScrollingRowIndex = cr;
                displayData();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (unitID == 0)
            {
                MessageBox.Show("الرجاء تحديد عنصر من القائمة", "حذف بيانات", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (MessageBox.Show("هل تريد حذف الوحدة" + Environment.NewLine + Environment.NewLine + txtUnit.Text.Trim(), "تأكيد حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var sqlCon = new SQLConClass();
                SqlParameter[] param = new SqlParameter[] { new SqlParameter("@Id", unitID) };
                sqlCon.CMDExecute("DeleteUnit", 1, param);
                btnRefresh.PerformClick();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void par_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                VariablesClass.sw = true;
                VariablesClass.pos = e.Location;
            }
        }

        private void par_MouseMove(object sender, MouseEventArgs e)
        {
            if (VariablesClass.sw == true)
            {
                this.Location = new Point(this.Location.X + (e.X - VariablesClass.pos.X), this.Location.Y + (e.Y - VariablesClass.pos.Y));
            }
        }

        private void par_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                VariablesClass.sw = false;
            }
        }
    }
}
