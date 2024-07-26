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
    public partial class FrmCountry : Form
    {
        private DataSet dsCountry = new DataSet();
        private int countryId;
        private int cr = -1;

        public FrmCountry()
        {
            InitializeComponent();
        }

        private void FrmCountry_Load(object sender, EventArgs e)
        {
            getFillData();
            setDGVHeader();
        }
        private void getFillData()
        {
            ConClass.sqlQuery = "SELECT Id , ROW_NUMBER() OVER (ORDER BY (SELECT 1)) ت , Country  FROM TblCountries ORDER BY Country";
            var sqlCon = new SQLConClass();
            dsCountry = sqlCon.SelectData(ConClass.sqlQuery,0, default);
            if (FunctionsClass.dsHasTables(dsCountry) == true)
            {
                dgvCountry.DataSource = dsCountry.Tables[0];
                dgvCountry.ClearSelection();
            }
            else
            {
                Dispose();
            }
        }
        private void setDGVHeader()
        {
            if (!FunctionsClass.dsHasTables(dsCountry))
                return;
            dgvCountry.Columns[0].Visible = false;
            dgvCountry.Columns[1].Width = 50;
            dgvCountry.Columns[2].HeaderText = "بلد الصنع";
        }

        private void dgvCountry_Click(object sender, EventArgs e)
        {
            if (FunctionsClass.checkDGVError(dgvCountry) == true)
                return;

            cr = dgvCountry.CurrentRow.Index;
            DisplayData();
        }
        private void DisplayData()
        {
            countryId = (int)dgvCountry.Rows[cr].Cells[0].Value;
            txtCountry.Text = dgvCountry.Rows[cr].Cells[2].Value.ToString();
            txtCountry.Focus();
        }

        private void txtCountry_TextChanged(object sender, EventArgs e)
        {
            if (countryId == 0)
            {
                dsCountry.Tables[0].DefaultView.RowFilter = " Country Like '%" + txtCountry.Text.Trim() + "%'";
                dgvCountry.ClearSelection();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearData();
            getFillData();
        }
        private void clearData()
        {
            cr = -1;
            countryId = 0;
            dgvCountry.ClearSelection();
            txtCountry.Clear();
            txtCountry.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (countryId != 0)
                btnRefresh.PerformClick();

            SaveCountry();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (countryId == 0)
            {
                MessageBox.Show("الرجاء تحديد عنصر من القائمة", "تعديل بيانات", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            SaveCountry();
        }
        private void SaveCountry()
        {
            if (txtCountry.Text.Trim() == "")
                return;

            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@Id", countryId), new SqlParameter("@Country", txtCountry.Text.Trim()) };
            var sqlCon = new SQLConClass();
            sqlCon.CMDExecute("SaveCountry", 1, param);

            getFillData();
            SelectItem();
        }
        private void SelectItem()
        {
            DataRow[] itemRows = dsCountry.Tables[0].Select("Country='" + txtCountry.Text.Trim() + "'");
            if (itemRows.Length > 0)
            {
                cr = Convert.ToInt32(itemRows[0][1]) - 1;
                dgvCountry.Rows[cr].Selected = true;
                dgvCountry.FirstDisplayedScrollingRowIndex = cr;
                DisplayData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (countryId == 0)
            {
                MessageBox.Show("الرجاء تحديد عنصر من القائمة", "حذف بيانات", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (MessageBox.Show("هل تريد حذف بلد الصنع" + Environment.NewLine + Environment.NewLine + txtCountry.Text.Trim(), "تأكيد حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                SqlParameter[] param = new SqlParameter[] { new SqlParameter("@Id", countryId) };

                var sqlCon = new SQLConClass();
                VariablesClass.Save = sqlCon.CMDExecute("DeleteCountry", 1, param);
                if (VariablesClass.Save == 2)
                {
                    FunctionsClass.msgTool("لم يتم الحذف، بلد الصنع مستخدم", 0);
                }

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
