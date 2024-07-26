using SalesProject.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SalesProject.Forms
{
    public partial class FrmCharts : Form
    {
        public FrmCharts()
        {
            InitializeComponent();
        }

        DataTable dTItem = new DataTable(), dTChart = new DataTable();

        ResizeControls r = new ResizeControls();

        private void FrmCharts_Resize(object sender, EventArgs e)
        {
            r.ResizeControl();

        }
        private void FrmCharts_HandleCreated(object sender, EventArgs e)
        {
            r.Container = this;

        }
        private void FrmCharts_Load(object sender, EventArgs e)
        {
            //tabControl1.SelectTab(5);
            cmbYear.Items.Clear();
            cmbYear1.Items.Clear();
            for (int year = DateTime.Now.Year - 10; year <= DateTime.Now.Year; year++)
            {
                cmbYear.Items.Add(year);
                cmbYear1.Items.Add(year);
            }

            cmbMonth.Items.Clear();
            for (int month = 1; month <= 12; month++)
                cmbMonth.Items.Add(month);

            cmbMonth.SelectedIndex = DateTime.Now.Month - 1;


            cmbYear.SelectedIndex = cmbYear.Items.Count - 1;
            cmbYear1.SelectedIndex = cmbYear1.Items.Count - 1;


            GetItem();
        }
        private void GetItem()
        {
            try
            {
                dTItem.Clear();
                SQLConClass.sqlQuery = "SELECT *  FROM TblItems WHERE DEL='FALSE' ORDER BY Name ASC";
                ConClass.da = new SqlDataAdapter(SQLConClass.sqlQuery, ConClass.con);
                ConClass.da.Fill(dTItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في جلب البيانات" + ex.Message, "خطأ إتصال بقواعد البيانات", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cmbItemChart.DataSource = dTItem;
            cmbItemChart.DisplayMember = "Name";
            cmbItemChart.ValueMember = "ID";
            cmbItemChart.SelectedIndex = -1;

            Chart();
        }
        private void Chart()
        {

            //var dTDistinctChart = dTItem.DefaultView.ToTable(true, "Name"); // جلب الاسماء بدون تكرار

            dTChart.Clear();
            dTChart = dTItem.Copy();


            // التاب الأولى

            dTChart.DefaultView.Sort = "SalePrice DESC";
            dTChart = dTChart.DefaultView.ToTable();

            chrtItemPrice.Series["Series1"].XValueMember = dTChart.Columns["Name"].ToString();
            chrtItemPrice.Series["Series1"].YValueMembers = dTChart.Columns["SalePrice"].ToString();
            chrtItemPrice.DataSource = dTChart;


            // التاب الثانية ثلاثية الأبعاد 
            dTChart.DefaultView.Sort = "StoreQuantity DESC";
            dTChart = dTChart.DefaultView.ToTable();

            chrt3DItemQuantity.Series["Series1"].XValueMember = dTChart.Columns["Name"].ToString();
            chrt3DItemQuantity.Series["Series1"].YValueMembers = dTChart.Columns["StoreQuantity"].ToString();
            chrt3DItemQuantity.DataSource = dTChart;


            // --نفس الطريقة السابقة ولكن بدون استعمال DataSource
            // -- DataGridView  نستخدمها بطريقتين تماما مثل

            chrt3DItemQuantity.Series["Series1"].Points.Clear();
            foreach (DataRow itm in dTChart.Rows)
                chrt3DItemQuantity.Series["Series1"].Points.AddXY(itm["Name"], itm["StoreQuantity"]);


            // **********************---أعلى 5 أصناف مبيعاً**********************----------
            try
            {
                dTChart = new DataTable();
                SQLConClass.sqlQuery = "SELECT top 5 [Name], SUM(ItemQuantity) AS TOTAL FROM TblItems,TblInvoContents where TblItems.ID=TblInvoContents.ItemID GROUP BY [Name] ORDER BY TOTAL DESC";
                ConClass.da = new SqlDataAdapter(SQLConClass.sqlQuery, ConClass.con);
                ConClass.da.Fill(dTChart);
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في جلب البيانات" + ex.Message, "خطأ إتصال بقواعد البيانات", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            if (dTChart.Rows.Count == 0)
            {
                return;
            }

            chart1.Series["Series1"].XValueMember = dTChart.Columns["Name"].ToString();
            chart1.Series["Series1"].YValueMembers = dTChart.Columns["TOTAL"].ToString();
            chart1.DataSource = dTChart;


            chrtTopFive.Series["Item"].XValueMember = dTChart.Columns["Name"].ToString();
            chrtTopFive.Series["Item"].YValueMembers = dTChart.Columns["TOTAL"].ToString();
            chrtTopFive.DataSource = dTChart;





            // نفس الطريقة السابقة
            chrtTopFive.Series["Item"].Points.Clear();// من الخصائص Item تم تسمية Seies1 
            for (int i = 0; i <= dTChart.Rows.Count - 1; i++)
                chrtTopFive.Series["Item"].Points.AddXY(dTChart.Rows[i][0], dTChart.Rows[i][1].ToString());


            // **********************---أدنى 5 أصناف مبيعاً**********************----------
            dTChart.Clear();
            SQLConClass.sqlQuery = "SELECT top 5 [Name], SUM(ItemQuantity) AS TOTAL FROM TblItems,TblInvoContents where TblItems.ID=TblInvoContents.ItemID GROUP BY [Name] ORDER BY TOTAL ASC";
            ConClass.da = new SqlDataAdapter(SQLConClass.sqlQuery, ConClass.con);
            ConClass.da.Fill(dTChart);


            chrtlowestFive.Series["Item"].Points.Clear();
            foreach (DataRow itm in dTChart.Rows)
                chrtlowestFive.Series["Item"].Points.AddXY(itm["Name"], itm["Total"]);


            // **********************--- مبيعات الأصناف خلال شهر معين**********************---------
            dTChart = new DataTable();
            SQLConClass.sqlQuery = "SELECT [Name],SUM(ItemQuantity)AS TOTAL FROM TblItems,TblInvoContents,TblInvoices where TblItems.ID=TblInvoContents.ItemID And TblInvoices.ID=TblInvoContents.InvoID And TblItems.DEL='FALSE' And YEAR(InvoDate) =" + cmbYear.Text + " And MONTH(InvoDate) =" + cmbMonth.Text + " GROUP BY  [Name]ORDER BY TOTAL DESC";

            ConClass.da = new SqlDataAdapter(SQLConClass.sqlQuery, ConClass.con);
            ConClass.da.Fill(dTChart);

            chrtSalesQuantity.Series.Clear();

            if (dTChart.Rows.Count == 0)
            {
                FunctionsClass.msgTool("لم يتم بيع أي أصناف في هذا الشهر", 2);
                return;
            }

            //---------------------------------------------------
            int Month = Convert.ToInt32(cmbMonth.Text);
            chrtSalesQuantity.ChartAreas[0].AxisX.CustomLabels.Clear();
            chrtSalesQuantity.ChartAreas[0].AxisX.CustomLabels.Add(Month - 1, Month + 1, Month.ToString() + "/" + cmbYear.Text);
            chrtSalesQuantity.ChartAreas[0].RecalculateAxesScale();
            // -------------------طريقة اخرى---------------------
            //chrtSalesQuantity.ChartAreas[0].AxisX.Interval = 1;
            //chrtSalesQuantity.ChartAreas[0].AxisX.Maximum = Month + 1;
            //chrtSalesQuantity.ChartAreas[0].RecalculateAxesScale();
            // ---------------------------------------------------

            foreach (DataRow Row in dTChart.Rows)
            {
                string SeriesName = Row["Name"].ToString();
                chrtSalesQuantity.Series.Add(SeriesName);
                //chrtSalesQuantity.Series[SeriesName].ChartType = SeriesChartType.Line; // Default=Column حتى ان كانت الخصائص لاين
                chrtSalesQuantity.Series[SeriesName].IsValueShownAsLabel = true;
                chrtSalesQuantity.Series[SeriesName].Points.AddXY(Month, Row["Total"]);
            }

        }
        private void cmbYear1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnClearChart_Click(sender, e); // عند تغيير السنة يقوم بمسح البيانات المعروضة
        }
        private void btnClearChart_Click(object sender, EventArgs e)
        {
            chrtSelectItem.Series.Clear();
            cmbItemChart.SelectedIndex = -1;
        }
        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbYear.Text == "" | cmbMonth.Text == "")
            {
                return;
            }
            GetItem();
        }
        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbYear.Text == "" | cmbMonth.Text == "")
            {
                return;
            }
            GetItem();
        }
        private void btnAddToChart_Click(object sender, EventArgs e)
        {
            if (cmbItemChart.Text.Trim() == "")
            {
                MessageBox.Show("الرجاء إختيار صنف من القائمة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbItemChart.Focus();
                return;
            }
            dTChart = new DataTable();
            SQLConClass.sqlQuery = "SELECT TblItems.[Name],SUM(ItemQuantity)AS TOTAL,MONTH(InvoDate) AS [month] FROM TblItems,TblInvoContents,TblInvoices where TblItems.ID=TblInvoContents.ItemID And TblInvoices.ID=TblInvoContents.InvoID And TblItems.ID=" + cmbItemChart.SelectedValue + " And YEAR(InvoDate) ="+ cmbYear1.Text +" GROUP BY  [Name],MONTH(InvoDate) ORDER BY [month] ASC";

            ConClass.da = new SqlDataAdapter(SQLConClass.sqlQuery, ConClass.con);
            ConClass.da.Fill(dTChart);

            if (dTChart.Rows.Count == 0)
            {
                MessageBox.Show("هذا الصنف لم يتم بيع أي كميه منه في هذه السنة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string seriesName = cmbItemChart.Text.Trim();

            foreach (var SName in chrtSelectItem.Series)
            {
                if (SName.Name == seriesName.ToString())
                {
                    MessageBox.Show("هذا الصنف تم إضافته مسبقاً", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }


            chrtSelectItem.Series.Add(seriesName);
            chrtSelectItem.Series[seriesName].ChartType = SeriesChartType.Line;
            chrtSelectItem.Series[seriesName].BorderWidth = 3;
            chrtSelectItem.Series[seriesName].MarkerStyle = MarkerStyle.Square;
            chrtSelectItem.Series[seriesName].MarkerSize = 6;
            chrtSelectItem.Series[seriesName].MarkerColor = Color.Red;
            chrtSelectItem.Series[seriesName].IsValueShownAsLabel = true;
            chrtSelectItem.ChartAreas[0].AxisX.CustomLabels.Clear();
            for (int i = 0; i <= dTChart.Rows.Count - 1; i++)
            {
                for (int j = 0; j <= 12; j++)
                {
                    chrtSelectItem.ChartAreas[0].AxisX.CustomLabels.Add(j + 0, j + 2, (j + 1).ToString() + "/" + cmbYear1.Text);
                    chrtSelectItem.ChartAreas[0].RecalculateAxesScale();
                    if (Convert.ToInt32(dTChart.Rows[i]["month"]) == j)
                    {
                        chrtSelectItem.Series[seriesName].Points.AddXY(j, dTChart.Rows[i]["Total"]);
                    }
                }
            }
        }
        private void btnRefrech1_Click(object sender, EventArgs e)
        {
            FrmCharts_Load(sender, e);

        }
    }
}
