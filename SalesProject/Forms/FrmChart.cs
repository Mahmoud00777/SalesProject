using SalesProject;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace SalesProject.Forms
{
    public partial class FrmChart : Form
    {
        private DataTable DTItem = new DataTable(), DTChart = new DataTable();

        private ResizeControls R = new ResizeControls();
        public FrmChart()
        {
            InitializeComponent();
        }
        private void FrmChart_Resize(object sender, EventArgs e)
        {
            R.ResizeControl();

        }
        private void FrmChart_HandleCreated(object sender, EventArgs e)
        {
            R.Container = this;

        }
        private void FrmChart_Load(object sender, EventArgs e)
        {
            //tabControl1.SelectTab(5);
            cmbYear.Items.Clear();
            for (int Y = 2011, loopTo = DateTime.Now.Year; Y <= loopTo; Y++)
            {
                CmbYearSelectItemChart.Items.Add(Y);
                cmbYear.Items.Add(Y);
            }

            cmbMonth.Items.Clear();
            for (int M = 1; M <= 12; M++)
                cmbMonth.Items.Add(M);

            cmbMonth.SelectedIndex = DateTime.Now.Month - 1;

            CmbYearSelectItemChart.SelectedIndex = CmbYearSelectItemChart.Items.Count - 1;
            cmbYear.SelectedIndex = cmbYear.Items.Count - 1;


            chrtSelectItemSalesQuantity.Series.Clear();
            GetItem();
        }


        private void GetItem()
        {
            try
            {
                DTItem.Clear();
                ConClass.sqlQuery = "SELECT *  FROM TblItems WHERE DEL='FALSE'";
                // ConClass.sqlQuery = "SELECT top 5 id,Name,SalePrice,StoreQuantity  FROM TblItems WHERE DEL='FALSE'"
                ConClass.da = new SqlDataAdapter(ConClass.sqlQuery, ConClass.con);
                ConClass.da.Fill(DTItem);
            }

            catch (Exception ex)
            {
                MessageBox.Show("خطأ في جلب البيانات" + ex.Message, "خطأ إتصال بقواعد البيانات", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cmbItemChart.DataSource = DTItem;
            cmbItemChart.DisplayMember = "Name";
            cmbItemChart.ValueMember = "ID";
            cmbItemChart.SelectedIndex = -1;

            Chart();

        }

        private void Chart()
        {

            //var DTDistinctChart = DTItem.DefaultView.ToTable(true, "Name"); // جلب الاسماء بدون تكرار

            var DTChart = new DataTable();
            DTChart = DTItem.Copy();

            chart1.Series["Series1"].XValueMember = DTChart.Columns["Name"].ToString();
            chart1.Series["Series1"].YValueMembers = DTChart.Columns["StoreQuantity"].ToString();
            chart1.DataSource = DTChart;

            // التاب الأولى

            DTChart.DefaultView.Sort = "SalePrice DESC";
            DTChart = DTChart.DefaultView.ToTable();

            chrtItemPrice.Series["Series1"].XValueMember = DTChart.Columns["Name"].ToString();
            chrtItemPrice.Series["Series1"].YValueMembers = DTChart.Columns["SalePrice"].ToString();
            chrtItemPrice.DataSource = DTChart;


            // التاب الثانية ثلاثية الأبعاد 
            DTChart.DefaultView.Sort = "StoreQuantity DESC";
            DTChart = DTChart.DefaultView.ToTable();

            chrt3DItemQuantity.Series["Series1"].XValueMember = DTChart.Columns["Name"].ToString();
            chrt3DItemQuantity.Series["Series1"].YValueMembers = DTChart.Columns["StoreQuantity"].ToString();
            chrt3DItemQuantity.DataSource = DTChart;


            // --نفس الطريقة السابقة ولكن بدون استعمال DataSource
            // -- تماما مثل DataGridView نستخدمها بطريقتين
            // -- مع تحيات عبد الوهاب التركي وشركاءه واخوانه وجيرانه وولاد شارعه
            chrt3DItemQuantity.Series["Series1"].Points.Clear();
            foreach (DataRow itm in DTChart.Rows)
                chrt3DItemQuantity.Series["Series1"].Points.AddXY(itm["Name"], itm["StoreQuantity"]);


            // **********************---أعلى 5 أصناف مبيعاً**********************----------
            try
            {
                DTChart = new DataTable();
                ConClass.sqlQuery = @"SELECT TOP 5 TblItems.Name, SUM(TblInvoContents.ItemQuantity) AS TOTAL 
        FROM TblItems,TblInvoContents where TblItems.ID=TblInvoContents.ItemID 
        GROUP BY Name ORDER BY TOTAL DESC";
                ConClass.da = new SqlDataAdapter(ConClass.sqlQuery, ConClass.con);
                ConClass.da.Fill(DTChart);
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ في جلب البيانات" + ex.Message, "خطأ إتصال بقواعد البيانات", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            if (DTChart.Rows.Count == 0)
            {
                return;
            }


            chrtTopFiveItem.Series["Item"].XValueMember = DTChart.Columns["Name"].ToString();
            chrtTopFiveItem.Series["Item"].YValueMembers = DTChart.Columns["TOTAL"].ToString();
            chrtTopFiveItem.DataSource = DTChart;

            // نفس الطريقة السابقة
            chrtTopFiveItem.Series["Item"].Points.Clear();  // تم تسمية Seies1 باسم Item من الخصائص
            for (int i = 0, loopTo = DTChart.Rows.Count - 1; i <= loopTo; i++)
                chrtTopFiveItem.Series["Item"].Points.AddXY(DTChart.Rows[i][0], DTChart.Rows[i][1].ToString());


            // **********************---أدنى 5 أصناف مبيعاً**********************----------
            DTChart = new DataTable();
            ConClass.sqlQuery = @"SELECT TOP 5 TblItems.Name, SUM(TblInvoContents.ItemQuantity) AS TOTAL 
        FROM TblItems,TblInvoContents where TblItems.ID=TblInvoContents.ItemID 
        GROUP BY  Name ORDER BY TOTAL ASC";
            ConClass.da = new SqlDataAdapter(ConClass.sqlQuery, ConClass.con);
            ConClass.da.Fill(DTChart);


            chrtlowestFiveItem.Series["Item"].Points.Clear();
            for (int i = 0, loopTo1 = DTChart.Rows.Count - 1; i <= loopTo1; i++)
                chrtlowestFiveItem.Series["Item"].Points.AddXY(DTChart.Rows[i][0], DTChart.Rows[i][1]);


            // **********************--- مبيعات الأصناف خلال الأشهر**********************---------
            DTChart = new DataTable();
            ConClass.sqlQuery = @"SELECT TblItems.Name, SUM(TblInvoContents.ItemQuantity) AS TOTAL ,MONTH(TblInvoices.InvoDate) AS M
         FROM TblItems,TblInvoContents,TblInvoices 
         where TblItems.ID=TblInvoContents.ItemID And TblItems.DEL='FALSE' " + " And TblInvoices.ID=TblInvoContents.InvoID " + " And YEAR(InvoDate) =" + cmbYear.Text + " And MONTH(InvoDate) =" + cmbMonth.Text + " GROUP BY  Name,MONTH(InvoDate), YEAR(InvoDate) ORDER BY TOTAL DESC";

            ConClass.da = new SqlDataAdapter(ConClass.sqlQuery, ConClass.con);
            ConClass.da.Fill(DTChart);

            chrtItemSalesQuantity.Series.Clear();

            if (DTChart.Rows.Count == 0)
            {
                MessageBox.Show("لم يتم بيع أي أصناف في هذا الشهر ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int Month = Convert.ToInt32(cmbMonth.Text);
            chrtItemSalesQuantity.ChartAreas[0].AxisX.CustomLabels.Clear();
            chrtItemSalesQuantity.ChartAreas[0].AxisX.CustomLabels.Add(Month - 1, Month + 1, Month.ToString() + "/" + cmbYear.Text);
            chrtItemSalesQuantity.ChartAreas[0].RecalculateAxesScale();

            // -------------------طريقة اخرى---------------------
            //chrtItemSalesQuantity.ChartAreas[0].AxisX.Interval = 1;
            //chrtItemSalesQuantity.ChartAreas[0].AxisX.Maximum = Month + 1;
            //chrtItemSalesQuantity.ChartAreas[0].RecalculateAxesScale();
            // ----------------------------------------------------

            foreach (DataRow Row in DTChart.Rows)
            {
                string SeriesName = Row["Name"].ToString();
                chrtItemSalesQuantity.Series.Add(SeriesName);
                //chrtItemSalesQuantity.Series[SeriesName].ChartType = SeriesChartType.Line; // Default=Column حتى ان كانت الخصائص لاين
                chrtItemSalesQuantity.Series[SeriesName].IsValueShownAsLabel = true;

                chrtItemSalesQuantity.Series[SeriesName].Points.AddXY(Month, Row["Total"]);
            }

        }
        private void CmbYearSelectItemChart_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnClearChart_Click(sender, e);
        }
        private void btnClearChart_Click(object sender, EventArgs e)
        {
            chrtSelectItemSalesQuantity.Series.Clear();
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
            DTChart = new DataTable();
            ConClass.sqlQuery = "SELECT  TblItems.Name, SUM(TblInvoContents.ItemQuantity) AS TOTAL ,MONTH(InvoDate) AS M" + " FROM TblItems,TblInvoContents,TblInvoices " + "where TblItems.ID=TblInvoContents.ItemID and TblItems.DEL='FALSE' " + "And TblInvoices.ID=TblInvoContents.InvoID " + " And TblItems.ID=" + cmbItemChart.SelectedValue + " And YEAR(InvoDate) =" + CmbYearSelectItemChart.Text + " GROUP BY  Name,MONTH(InvoDate) ORDER BY M ASC";

            ConClass.da = new SqlDataAdapter(ConClass.sqlQuery, ConClass.con);
            ConClass.da.Fill(DTChart);

            if (DTChart.Rows.Count == 0)
            {
                MessageBox.Show("هذا الصنف لم يتم بيع أي كميه منه في هذه السنة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string seriesName = cmbItemChart.Text.Trim();

            foreach (var SName in chrtSelectItemSalesQuantity.Series)
            {
                if (SName.Name == seriesName.ToString())
                {
                    MessageBox.Show("هذا الصنف تم إضافته مسبقاً", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            {
                var withBlock = chrtSelectItemSalesQuantity;
                withBlock.Series.Add(seriesName);
                withBlock.Series[seriesName].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                withBlock.Series[seriesName].BorderWidth = 3;
                withBlock.Series[seriesName].MarkerStyle = MarkerStyle.Square;
                withBlock.Series[seriesName].MarkerSize = 6;
                withBlock.Series[seriesName].MarkerColor = Color.Red;
                withBlock.Series[seriesName].IsValueShownAsLabel = true;
                withBlock.ChartAreas[0].AxisX.CustomLabels.Clear();
                for (int i = 0; i <= DTChart.Rows.Count - 1; i++)
                {
                    for (int j = 0; j <= 12; j++)
                    {
                        withBlock.ChartAreas[0].AxisX.CustomLabels.Add(j + 0, j + 2, j + 1.ToString() + "/" + CmbYearSelectItemChart.Text);
                        withBlock.ChartAreas[0].RecalculateAxesScale();
                        if (Convert.ToInt32(DTChart.Rows[i]["M"]) == j)
                        {
                            withBlock.Series[seriesName].Points.AddXY(j, DTChart.Rows[i]["Total"]);
                        }

                    }
                }
            }
        }

        private void btnRefrech1_Click(object sender, EventArgs e)
        {
            FrmChart_Load(sender, e);

        }
    }
}
