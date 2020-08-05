using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using IDMS.DataManage;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace IDMS.Page
{
    public partial class statUC : UserControl
    {
       
       

        public statUC()
        {
            InitializeComponent();
          //  MessageBox.Show(PullData().ToString());
            // DataAccess db = new DataAccess();
            //  db.AddNewCase(a, cname, hn.Text, pro, pRoom, indi, inst, predx1, predx2, predx3, predx4, b, regisday, d1, d2, sc, cc, ac, "Prepare");


        }



        static int PullData(string data)
        {
      
            string query = "SELECT COUNT(*) FROM patientcase WHERE `Procedure` = '" + data + "'";


            using (var conn = new MySqlConnection(dbhelper.CnnVal("db")))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    conn.Close();
                    return count;
                }
            }
        }
        static int PullDataCamera(string data)
        {

            string query = "SELECT COUNT(*) FROM patientcase WHERE `Instruments` LIKE '%" + data + "%'";


            using (var conn = new MySqlConnection(dbhelper.CnnVal("db")))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    conn.Close();
                    return count;
                }
            }
        }
        static int PullDataEGD(string data, int data2)
        {
            string data3 = "EGD";
            //  string query = "SELECT COUNT(*) FROM report LEFT JOIN patientcase ON report.caseid = patientcase.caseid WHERE `report.sf" + data2.ToString() + "` = '" + data + "'";

            string query = "SELECT COUNT(*) FROM report JOIN patientcase ON report.caseid = patientcase.caseid WHERE report.sf" + data2.ToString() + " = '" + data + "' and patientcase.Procedure = '" + data3 + "'";

            using (var conn = new MySqlConnection(dbhelper.CnnVal("db")))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    conn.Close();
                    return count;
                }
            }
        }
        static int PullDataCOL(string data, int data2)
        {
            string data3 = "Colonoscopy";
            //  string query = "SELECT COUNT(*) FROM report LEFT JOIN patientcase ON report.caseid = patientcase.caseid WHERE `report.sf" + data2.ToString() + "` = '" + data + "'";

            string query = "SELECT COUNT(*) FROM report JOIN patientcase ON report.caseid = patientcase.caseid WHERE report.sf" + data2.ToString() + " = '" + data + "' and patientcase.Procedure = '" + data3 + "'";

            using (var conn = new MySqlConnection(dbhelper.CnnVal("db")))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    conn.Close();
                    return count;
                }
            }
        }
        static int PullDataERCP(string data, int data2)
        {
            string data3 = "ERCP";
            //  string query = "SELECT COUNT(*) FROM report LEFT JOIN patientcase ON report.caseid = patientcase.caseid WHERE `report.sf" + data2.ToString() + "` = '" + data + "'";

            string query = "SELECT COUNT(*) FROM report JOIN patientcase ON report.caseid = patientcase.caseid WHERE report.sf" + data2.ToString() + " = '" + data + "' and patientcase.Procedure = '" + data3 + "'";

            using (var conn = new MySqlConnection(dbhelper.CnnVal("db")))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    conn.Close();
                    return count;
                }
            }
        }
        static int PullDataBronco(string data, int data2)
        {
            string data3 = "BRONCO";
            //  string query = "SELECT COUNT(*) FROM report LEFT JOIN patientcase ON report.caseid = patientcase.caseid WHERE `report.sf" + data2.ToString() + "` = '" + data + "'";

            string query = "SELECT COUNT(*) FROM broncoreport JOIN patientcase ON broncoreport.caseid = patientcase.caseid WHERE broncoreport.sf" + data2.ToString() + " = '" + data + "' and patientcase.Procedure = '" + data3 + "'";

            using (var conn = new MySqlConnection(dbhelper.CnnVal("db")))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    conn.Close();
                    return count;
                }
            }
        }
        static int PullDataDoc(string DOCTOR ,string PROCEDURE)
        {

            string query = "SELECT COUNT(*) FROM patientcase WHERE `Doctor` = '" + DOCTOR + "' AND `Procedure` = '" + PROCEDURE + "'";


            using (var conn = new MySqlConnection(dbhelper.CnnVal("db")))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    conn.Close();
                    return count;
                }
            }
        }
        static int PullDataPatient(string data)
        {


            string query = "SELECT COUNT(*) FROM patientdata WHERE `sex` = '" + data + "'";

            using (var conn = new MySqlConnection(dbhelper.CnnVal("db")))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    conn.Close();
                    return count;
                }
            }
        }
       

     
        
        static DataTable GetProTable()
        {


            DataTable table = new DataTable();
            table.Columns.Add("Procedure", typeof(string));
            table.Columns.Add("count", typeof(int));
          
            table.Rows.Add("EGD", PullData("EGD"));
            table.Rows.Add("COL", PullData("Colonoscopy"));
            table.Rows.Add("ERCP", PullData("ERCP"));
            table.Rows.Add("BRONCO", PullData("BRONCO"));


            return table;
        }

        static DataTable GetCameraTable()
        {
         SQLiteConnection sql_con;         
         SQLiteCommand sql_cmd;
         SQLiteDataAdapter DB;
         SQLiteDataReader reader;
        string query = "select * from " + "camera";
            sql_con = new SQLiteConnection(dbhelper.CnnVal("setting"));
            sql_con.Open();
            sql_cmd = new SQLiteCommand(query, sql_con);
            reader = sql_cmd.ExecuteReader();
           
            DB = new SQLiteDataAdapter(query, sql_con);
            DataSet ds = new DataSet();
            DB.Fill(ds);
         
            reader.Close();
            sql_con.Close();
            sql_con.Dispose();

            int rows = ds.Tables[0].Rows.Count;
            string[] Camera = new string[rows];
            for (int i = 0; i < rows; i++)
            {
                Camera[i] = ds.Tables[0].Rows[i]["brand"].ToString() + " " + ds.Tables[0].Rows[i]["model"].ToString();

                
            }
          
            DataTable table = new DataTable();
            table.Columns.Add("Camera", typeof(string));
            table.Columns.Add("count", typeof(int));

         
            for (int i = 0; i < rows; i++)
            {
                table.Rows.Add(Camera[i], PullDataCamera(ds.Tables[0].Rows[i]["model"].ToString()));
            }


            return table;
        }

        static DataTable GetPatientTable()
        {

            int m = PullDataPatient("Male");
            int f = PullDataPatient("Female");
            DataTable table = new DataTable();
            table.Columns.Add("Gender", typeof(string));
            table.Columns.Add("Count", typeof(int));


            table.Rows.Add("Male", m);
            table.Rows.Add("Female", f);
            table.Rows.Add("All", m+f);


            return table;
        }


        static DataTable GetDoctorTable()
        {
            SQLiteConnection sql_con;
            SQLiteCommand sql_cmd;
            SQLiteDataAdapter DB;
            SQLiteDataReader reader;
            string query = "select * from " + "doctor";
            sql_con = new SQLiteConnection(dbhelper.CnnVal("setting"));
            sql_con.Open();
            sql_cmd = new SQLiteCommand(query, sql_con);
            reader = sql_cmd.ExecuteReader();

            DB = new SQLiteDataAdapter(query, sql_con);
            DataSet ds = new DataSet();
            DB.Fill(ds);




            reader.Close();
            sql_con.Close();
            sql_con.Dispose();
            int rows = ds.Tables[0].Rows.Count;
            string[] Doc = new string[rows];
            for (int i = 0; i < rows; i++)
            {
                Doc[i] = ds.Tables[0].Rows[i]["docname"].ToString() ;
            }


            DataTable table = new DataTable();
            table.Columns.Add("Doctor", typeof(string));
            table.Columns.Add("EGD", typeof(int));
            table.Columns.Add("COL", typeof(int));
            table.Columns.Add("ERCP", typeof(int));
            table.Columns.Add("BRONCO", typeof(int));


            for (int i = 0; i < rows; i++)
            {
                table.Rows.Add(Doc[i], PullDataDoc(Doc[i], "EGD"), PullDataDoc(Doc[i], "Colonoscopy"), PullDataDoc(Doc[i], "ERCP"), PullDataDoc(Doc[i], "BRONCO"));
            }



            return table;
        }

        static DataTable GetAnesTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Anesthasia", typeof(string));
            table.Columns.Add("count", typeof(int));
           





            table.Rows.Add("Topical", 0);
            table.Rows.Add("IV sedation", 0);
            table.Rows.Add("General with ET tube", 0);
            table.Rows.Add("Epidural block", 0);
            table.Rows.Add("Other", 0);






            return table;
        }

        static DataTable GetEGDTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Organ", typeof(string));
            table.Columns.Add("Normal", typeof(int));
            table.Columns.Add("Abnormal", typeof(int));

            table.Rows.Add("Oropharnyx", PullDataEGD("NORMAL",1), PullDataEGD("ABNORMAL", 1));
            table.Rows.Add("Esophagus", PullDataEGD("NORMAL", 2), PullDataEGD("ABNORMAL", 2));
            table.Rows.Add("EG junction", PullDataEGD("NORMAL", 3), PullDataEGD("ABNORMAL", 3));
            table.Rows.Add("Stomach-Cardia", PullDataEGD("NORMAL", 4), PullDataEGD("ABNORMAL", 4));
            table.Rows.Add("Stomach-Fundus", PullDataEGD("NORMAL", 5), PullDataEGD("ABNORMAL", 5));
            table.Rows.Add("Stomach-Body", PullDataEGD("NORMAL", 6), PullDataEGD("ABNORMAL", 6));
            table.Rows.Add("Stomach-Antrum", PullDataEGD("NORMAL", 7), PullDataEGD("ABNORMAL", 7));
            table.Rows.Add("Stomach-Pylorus", PullDataEGD("NORMAL", 8), PullDataEGD("ABNORMAL", 8));
            table.Rows.Add("Duodenum-Blub", PullDataEGD("NORMAL", 9), PullDataEGD("ABNORMAL", 9));
            table.Rows.Add("Duodenum-2nd Portion", PullDataEGD("NORMAL", 10), PullDataEGD("ABNORMAL", 10));

            return table;
        }
        static DataTable GetCOLTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Organ", typeof(string));
            table.Columns.Add("Normal", typeof(int));
            table.Columns.Add("Abnormal", typeof(int));

            table.Rows.Add("Anal canal", PullDataCOL("NORMAL", 1), PullDataCOL("ABNORMAL", 1));
            table.Rows.Add("Rectum", PullDataCOL("NORMAL", 2), PullDataCOL("ABNORMAL", 2));
            table.Rows.Add("Sigmoid colon", PullDataCOL("NORMAL",3), PullDataCOL("ABNORMAL", 3));
            table.Rows.Add("Descending colon", PullDataCOL("NORMAL", 4), PullDataCOL("ABNORMAL", 4));
            table.Rows.Add("Splenic flexure", PullDataCOL("NORMAL", 5), PullDataCOL("ABNORMAL", 5));
            table.Rows.Add("Transverse colon", PullDataCOL("NORMAL", 6), PullDataCOL("ABNORMAL", 6));
            table.Rows.Add("Hepatic flexure", PullDataCOL("NORMAL", 7), PullDataCOL("ABNORMAL", 7));
            table.Rows.Add("Ascending colon", PullDataCOL("NORMAL", 8), PullDataCOL("ABNORMAL", 8));
            table.Rows.Add("Cecum", PullDataCOL("NORMAL", 9), PullDataCOL("ABNORMAL", 9));
            table.Rows.Add("Terminal plenum", PullDataCOL("NORMAL", 10), PullDataCOL("ABNORMAL", 10));



            return table;
        }
        static DataTable GetERCPTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Organ", typeof(string));
            table.Columns.Add("Normal", typeof(int));
            table.Columns.Add("Abnormal", typeof(int));

            table.Rows.Add("Duodenum", PullDataERCP("NORMAL", 1), PullDataERCP("ABNORMAL", 1));
            table.Rows.Add("Papilla major", PullDataERCP("NORMAL", 2), PullDataERCP("ABNORMAL", 2));
            table.Rows.Add("Papilla minor", PullDataERCP("NORMAL", 3), PullDataERCP("ABNORMAL", 3));
            table.Rows.Add("Pancreas", PullDataERCP("NORMAL", 4), PullDataERCP("ABNORMAL", 4));
            table.Rows.Add("Biliary system", PullDataERCP("NORMAL", 5), PullDataERCP("ABNORMAL", 5));
           



            return table;
        }

        static DataTable GetBRONCOTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Organ", typeof(string));
            table.Columns.Add("Normal", typeof(int));
            table.Columns.Add("Abnormal", typeof(int));

            table.Rows.Add("Vocal cord", PullDataBronco("NORMAL", 1), PullDataBronco("ABNORMAL", 1));
            table.Rows.Add("Tranchea", PullDataBronco("NORMAL", 2), PullDataBronco("ABNORMAL", 2));
            table.Rows.Add("Carina", PullDataBronco("NORMAL", 3), PullDataBronco("ABNORMAL", 3));
            table.Rows.Add("Right main", PullDataBronco("NORMAL", 4), PullDataBronco("ABNORMAL", 4));
            table.Rows.Add("Right intermediate", PullDataBronco("NORMAL", 5), PullDataBronco("ABNORMAL", 5));
            table.Rows.Add("RUL", PullDataBronco("NORMAL", 6), PullDataBronco("ABNORMAL", 6));
            table.Rows.Add("RML", PullDataBronco("NORMAL", 7), PullDataBronco("ABNORMAL", 7));
            table.Rows.Add("RLL", PullDataBronco("NORMAL", 8), PullDataBronco("ABNORMAL", 8));
            table.Rows.Add("Left main", PullDataBronco("NORMAL", 9), PullDataBronco("ABNORMAL", 9));
            table.Rows.Add("LUL", PullDataBronco("NORMAL", 10), PullDataBronco("ABNORMAL", 10));
            table.Rows.Add("Lingular", PullDataBronco("NORMAL", 11), PullDataBronco("ABNORMAL", 11));
            table.Rows.Add("LLL", PullDataBronco("NORMAL", 12), PullDataBronco("ABNORMAL", 12));




            return table;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = "STAT";
                savefile.Filter = "Excel Files|*.csv;";


               

             
                    if (savefile.ShowDialog() == DialogResult.OK)
                    {
                  



                    DataTable TABLE = GetProTable();


                    WriteDataTableToExcel(TABLE, "Statistic", savefile.FileName, "Details");

                




                    MessageBox.Show(this, "Data saved in Excel format at location " + savefile.FileName, "Successfully Saved", MessageBoxButtons.OK, MessageBoxIcon.Question);










                }


            }
            catch (Exception ex)
            {
              
            }
            finally
            {

            }

        }
        public bool WriteDataTableToExcel(System.Data.DataTable dataTable, string worksheetName, string saveAsLocation, string ReporType)
        {
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook excelworkBook;
            Microsoft.Office.Interop.Excel.Worksheet excelSheet;
            Microsoft.Office.Interop.Excel.Range excelCellrange;

            try
            {
                // Start Excel and get Application object.
                excel = new Microsoft.Office.Interop.Excel.Application();

                // for making Excel visible
                excel.Visible = false;
                excel.DisplayAlerts = false;

                // Creation a new Workbook
                excelworkBook = excel.Workbooks.Add(Type.Missing);

                // Workk sheet
                excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelworkBook.ActiveSheet;
                excelSheet.Name = worksheetName;

                //Add Report Stat here
                List<int> countList = new List<int>();
                List<int> ColumnsList = new List<int>();

                DataTable dataTable_1 = GetProTable();
                int count_1 =  AddtableExcel(0, excelSheet, dataTable_1, "Procedure Done");
                countList.Add(0);
                ColumnsList.Add(dataTable_1.Columns.Count);


                DataTable dataTable_2 = GetCameraTable();
                int count_2   =  AddtableExcel(count_1, excelSheet, dataTable_2, "Camera Used");
                countList.Add(count_1);
                ColumnsList.Add(dataTable_2.Columns.Count);


                DataTable dataTable_3 = GetPatientTable();
                int count_3 = AddtableExcel(count_2, excelSheet, dataTable_3, "Patient");
                countList.Add(count_2);
                ColumnsList.Add(dataTable_3.Columns.Count);


                DataTable dataTable_4 = GetDoctorTable();
                int count_4 = AddtableExcel(count_3, excelSheet, dataTable_4, "Doctor");
                countList.Add(count_3);
                ColumnsList.Add(dataTable_4.Columns.Count);


                DataTable dataTable_5 = GetEGDTable();
                int count_5 = AddtableExcel(count_4, excelSheet, dataTable_5, "EGD Report");
                countList.Add(count_4);
                ColumnsList.Add(dataTable_5.Columns.Count);


                DataTable dataTable_6 = GetCOLTable();
                int count_6 = AddtableExcel(count_5, excelSheet, dataTable_6, "COL Report");
                countList.Add(count_5);
                ColumnsList.Add(dataTable_6.Columns.Count);


                DataTable dataTable_7 = GetERCPTable();
                int count_7 = AddtableExcel(count_6, excelSheet, dataTable_7, "ERCP Report");
                countList.Add(count_6);
                ColumnsList.Add(dataTable_7.Columns.Count);

                DataTable dataTable_8 = GetBRONCOTable();
                int count_8 = AddtableExcel(count_7, excelSheet, dataTable_8, "BRONCO Report");
                countList.Add(count_7);
                ColumnsList.Add(dataTable_8.Columns.Count);


                int[] Count = countList.ToArray();
                int[] Columns = ColumnsList.ToArray();

                for (int i = 0; i < Count.Length; i++)
                {
                    excelCellrange = excelSheet.Range[excelSheet.Cells[Count[i]+1, 1], excelSheet.Cells[Count[i] + 2, Columns[i]]];
                    FormattingExcelCells(excelCellrange, "#000099", System.Drawing.Color.White, true);
                }

                
                excelworkBook.SaveAs(saveAsLocation); ;
                excelworkBook.Close();
                excel.Quit();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                excelSheet = null;
                excelCellrange = null;
                excelworkBook = null;
            }

        }

        /// <summary>
        /// FUNCTION FOR FORMATTING EXCEL CELLS
        /// </summary>
        /// <param name="range"></param>
        /// <param name="HTMLcolorCode"></param>
        /// <param name="fontColor"></param>
        /// <param name="IsFontbool"></param>
        /// 
        public int AddtableExcel(int rowcount, Microsoft.Office.Interop.Excel.Worksheet excelSheet, DataTable dataTable, string ReporType)
        {
            Microsoft.Office.Interop.Excel.Range excelCellrange;

            int table2 = rowcount + 1;

            rowcount += 2;
            int counter = rowcount + 1;
            excelSheet.Cells[rowcount - 1, 1] = ReporType;
         //   excelSheet.Cells[rowcount - 1, 2] = "Date : " + DateTime.Now.ToShortDateString();


            foreach (DataRow datarow in dataTable.Rows)
            {
                rowcount += 1;
                for (int i = 1; i <= dataTable.Columns.Count; i++)
                {
                    if (rowcount == counter)
                    {
                        excelSheet.Cells[counter - 1, i] = dataTable.Columns[i - 1].ColumnName;
                        excelSheet.Cells.Font.Color = System.Drawing.Color.Black;

                    }

                    excelSheet.Cells[rowcount, i] = datarow[i - 1].ToString();
                    /*
                    if (rowcount > counter)
                    {
                        if (i == dataTable.Columns.Count)
                        {
                            if (rowcount % 2 == 0)
                            {
                                excelCellrange = excelSheet.Range[excelSheet.Cells[rowcount, 1], excelSheet.Cells[rowcount, dataTable.Columns.Count]];
                                FormattingExcelCells(excelCellrange, "#CCCCFF", System.Drawing.Color.Black, false);
                            }

                        }
                    }
                    */

                }

            }
            excelCellrange = excelSheet.Range[excelSheet.Cells[table2, 1], excelSheet.Cells[rowcount, dataTable.Columns.Count]];
            excelCellrange.EntireColumn.AutoFit();
            Microsoft.Office.Interop.Excel.Borders border = excelCellrange.Borders;
            border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            border.Weight = 2d;


           

          

            return rowcount+1;

        }

        public void FormattingExcelCells(Microsoft.Office.Interop.Excel.Range range, string HTMLcolorCode, System.Drawing.Color fontColor, bool IsFontbool)
        {
            range.Interior.Color = System.Drawing.ColorTranslator.FromHtml(HTMLcolorCode);
            range.Font.Color = System.Drawing.ColorTranslator.ToOle(fontColor);
            if (IsFontbool == true)
            {
                range.Font.Bold = IsFontbool;
            }
        }

    }
}
