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
    public partial class FrmAccountStatement : Form
    {
        public FrmAccountStatement()
        {
            InitializeComponent();
        }
        DataSet dsCustomer = new DataSet(); DataSet ds = new DataSet();

        private void cmbCustomers_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbCustomers.SelectedValue == null)
            {
                return;
            }

            SQLConClass sQL = new SQLConClass();
            SQLConClass.sqlQuery = "SELECT TblReceipts.Id,ROW_NUMBER() OVER (ORDER BY (SELECT 1)) ت ,Num,[Date],[Value],NoteFor,USERNAME FROM TblReceipts,TblCustomers,TblUsers WHERE TblCustomers.Id=TblReceipts.CustomerId AND TblUsers.Id=TblReceipts.UserId AND TblCustomers.Id=@Id AND TblReceipts.Del=0 ";
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@Id", cmbCustomers.SelectedValue) };
            dsCustomer = sQL.selectData(SQLConClass.sqlQuery, 0, param);
            if (FunctionsClass.dsHasTables(dsCustomer))
            {
                dgvAccount.DataSource = dsCustomer.Tables[0];
                dgvAccount.ClearSelection();
            }
        }
        public void getFillData()
        {
            SQLConClass sql = new SQLConClass();
            SQLConClass.sqlQuery = "SELECT * FROM TblCustomers WHERE Del=0";
            ds = sql.selectData(SQLConClass.sqlQuery, 0, null);
            if (FunctionsClass.dsHasTables(ds))
            {
                cmbCustomers.DataSource = ds.Tables[0];
                cmbCustomers.DisplayMember = "Name";
                cmbCustomers.ValueMember = "Id";
                cmbCustomers.SelectedValue = -1;
            }
        }

        private void FrmAccountStatement_Load(object sender, EventArgs e)
        {
            getFillData();
        }
    }
}
