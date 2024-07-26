
// ***************************************************************************
// Professional Programmer Company , Tripoli-Libya (+218911409943)
// Data Access Layer - SqlConnection Class
// A class that contains the functions of connecting to SQL Server Database
//****************************************************************************
using SalesProject;
using SalesProject.Classes;
using SalesProject.Properties;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace SalesProject
{
    class SQLConClass
    {
        public static string sqlQuery;
        SqlConnection con;
        public SQLConClass()
        {
            con = new SqlConnection("Data Source=" + Settings.Default.Server + ";Initial Catalog=" + Settings.Default.Database + ";Integrated Security=False;User ID=" + Settings.Default.SQLLogin + ";Password=" + Settings.Default.SQLPassword + ";");
        }

        public DataSet selectData(string command, int type, SqlParameter[] parameters)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(command, con);
            if (!(parameters == null))
                cmd.Parameters.AddRange(parameters);
            if (type == 1)
                cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("فشل في الإتصال بقاعدة البيانات" + Environment.NewLine + ex.Message, "خطأ إتصال", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ds;
        }
        public int cmdExecute(string command, int type, SqlParameter[] parameters)
        {

            SqlCommand cmd = new SqlCommand(command, con);
            int saveState = -1;
            int rowsAffected = 0;

            if (!(parameters == null))
            {
                foreach (SqlParameter p in parameters)
                    if (p.Value == null) p.Value = DBNull.Value;

                cmd.Parameters.AddRange(parameters);
            }

            if (type == 1)
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@saveState", SqlDbType.Int).Direction = ParameterDirection.Output;
            }

            try
            {
                con.Open();
                rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (type == 1)
                {
                    saveState = Convert.ToInt32(cmd.Parameters["@saveState"].Value.ToString());
                    switch (saveState)
                    {
                        case 1:
                            {
                                FunctionsClass.msgTool("تم الحفظ بنجاح", 1);
                                break;
                            }
                        case 2:
                            {
                                FunctionsClass.msgTool("لم يتم الحفظ، تكرار في البيانات", 0);
                                break;
                            }
                        case 3:
                            {
                                FunctionsClass.msgTool("تم ارسال البيانات الى سلة المحذوفات ", 2);
                                break;
                            }
                        case 0:
                            {
                                FunctionsClass.msgTool("لم يتم الحفظ، خطأ في تنفيذ العملية", 0);
                                break;
                            }
                    }
                }

                else if (type == 0)
                {

                    saveState = rowsAffected;
                    switch (saveState)
                    {
                        case var @case when @case > 0:  // if
                            {
                                FunctionsClass.msgTool("تم الحفظ بنجاح", 1);
                                break;
                            }

                        default: // else
                            {
                                FunctionsClass.msgTool("لم يتم الحفظ، تكرار في البيانات  ", 0);
                                break;
                            }
                    }
                }
            }

            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("فشل في الإتصال بقاعدة البيانات" + Environment.NewLine + ex.Message, "خطأ إتصال", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return saveState;
        }
        public DataSet cmdExecuteData(string command, SqlParameter[] parameters)
        {
            SqlDataAdapter da;
            var ds = new DataSet();
            var cmd = new SqlCommand(command, con);
            VariablesClass.Save = -1;

            if (!(parameters == null))
            {
                foreach (SqlParameter p in parameters)
                    if (p.Value == null) p.Value = DBNull.Value;

                cmd.Parameters.AddRange(parameters);
            }

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@saveState", SqlDbType.Int).Direction = ParameterDirection.Output;

            try
            {
                con.Open();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);                  // int RowsCount  = da.Fill(ds);
                con.Close();

                VariablesClass.Save = Convert.ToInt32(cmd.Parameters["@saveState"].Value.ToString());
                switch (VariablesClass.Save)
                {
                    case 1:
                        {
                            FunctionsClass.msgTool("تم الحفظ بنجاح", 1);
                            break;
                        }
                    case 2:
                        {
                            FunctionsClass.msgTool("لم يتم الحفظ، تكرار في البيانات  ", 0);
                            break;
                        }
                    case 3:
                        {
                            FunctionsClass.msgTool("تم ارسال البيانات الى سلة المحذوفات ", 2);
                            break;
                        }
                    case 0:
                        {
                            FunctionsClass.msgTool("لم يتم الحفظ، خطأ في تنفيذ العملية", 0);
                            break;
                        }
                }
            }

            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("فشل في الإتصال بقاعدة البيانات" + Environment.NewLine + ex.Message, "خطأ إتصال", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return ds;

        }




    }
}
