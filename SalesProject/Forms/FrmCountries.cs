using SalesProject.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SalesProject.Forms
{
    public partial class FrmCountries : Form
    {
        public FrmCountries()
        {
            InitializeComponent();
        }
        DataSet dsCountries = new DataSet();
        int countryId;
        int cr = -1;
        private void FrmCountries_Load(object sender, EventArgs e)
        {
            getFillData();
            setDgvHeader();
        }
        void getFillData()
        {
            SQLConClass.sqlQuery = "SELECT Id , ROW_NUMBER() OVER (ORDER BY (SELECT 1)) ت , Country  FROM TblCountries ORDER BY Country";
            SQLConClass sqlCon = new SQLConClass();
            dsCountries = sqlCon.selectData(SQLConClass.sqlQuery, 0, null);

            if (FunctionsClass.dsHasTables(dsCountries))
            {
                dgvCountries.DataSource = dsCountries.Tables[0];
                dgvCountries.ClearSelection();
            }
            else
                this.Close();
        }
        void setDgvHeader()
        {
            if (!FunctionsClass.dsHasTables(dsCountries))
                return;

            dgvCountries.Columns[0].Visible = false;
            dgvCountries.Columns[1].Width = 50;
            dgvCountries.Columns[2].HeaderText = "بلد الصنع";
        }
        private void dgvCountries_Click(object sender, EventArgs e)
        {
            if (FunctionsClass.checkDgvError((DataGridView)sender))
                return;
            cr = dgvCountries.CurrentRow.Index;
            displayData();
        }
        void displayData()
        {
            countryId = (int)dgvCountries.Rows[cr].Cells[0].Value;
            txtCountry.Text = dgvCountries.Rows[cr].Cells[2].Value.ToString();
            txtCountry.Focus();
        }
        private void txtCountry_TextChanged(object sender, EventArgs e)
        {
            if (countryId == 0)
            {
                dsCountries.Tables[0].DefaultView.RowFilter = "Country Like '%" + txtCountry.Text.Trim() + "%'";
                dgvCountries.ClearSelection();
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearData();
            getFillData();

        }
        void clearData()
        {
            cr = -1;
            countryId = 0;
            dgvCountries.ClearSelection();
            txtCountry.Clear();
            txtCountry.Focus();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (countryId != 0)
                btnRefresh.PerformClick();

            saveCountry();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (countryId == 0)
            {
                MessageBox.Show("الرجاء تحديد عنصر من القائمة", "تعديل بيانات", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            saveCountry();
        }
        void saveCountry()
        {
            if (txtCountry.Text.Trim() == "")
                return;

            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@Id", countryId),
                new SqlParameter("@Country", txtCountry.Text.Trim()) };

            SQLConClass sqlCon = new SQLConClass();

            sqlCon.cmdExecute("SaveCountry", 1, param);

            getFillData();
            SelectItem();

            //int[] array1 = new int[4];
            // array1[0] = 10;
            //array1[1] = 20;
            //array1[2] = 30;
            // array1[3] = 40;

            // int[] array2 = new int[] { 10, 20, 30, 40, 50, 60 };


        }
        void SelectItem()
        {
            DataRow[] itemRows = dsCountries.Tables[0].Select("Country='" + txtCountry.Text.Trim() + "'");
            if (itemRows.Length > 0)
            {
                cr = Convert.ToInt32(itemRows[0][1]) - 1;
                dgvCountries.Rows[cr].Selected = true;
                dgvCountries.FirstDisplayedScrollingRowIndex = cr;
                displayData();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (countryId == 0)
            {
                MessageBox.Show("الرجاء تحديد عنصر من القائمة", "حذف بيانات", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (MessageBox.Show("هل تريد حذف بلد الصنع" + Environment.NewLine + Environment.NewLine + txtCountry.Text.Trim(), "حذف بيانات", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {



                SQLConClass sqlCon = new SQLConClass();
                SqlParameter[] param = new SqlParameter[] { new SqlParameter("@Id", countryId) };

                VariablesClass.Save = sqlCon.cmdExecute("DeleteCountry", 1, param);

                if (VariablesClass.Save == 1)
                {
                    FunctionsClass.msgTool("تم الحذف بنجـــاح", 1);
                }
                else if (VariablesClass.Save == 2)
                {
                    FunctionsClass.msgTool("لم يتم الحذف، بلد الصنع مستخدم", 0);
                }


                switch (VariablesClass.Save)
                {
                    case 1: // if
                        {
                            FunctionsClass.msgTool("تم الحفظ بنجاح", 1);
                            break;
                        }
                    case 2:  // else if
                        {
                            FunctionsClass.msgTool("لم يتم الحفظ، تكرار في البيانات", 0);
                            break;
                        }
                }

                btnRefresh.PerformClick();
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
