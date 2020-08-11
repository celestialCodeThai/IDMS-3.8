using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using IDMS.DataManage;

namespace IDMS.Page
{
    public partial class statistics_UC : UserControl
    {
        DataAccess load = new DataAccess();

        DataTable doctorTable = new DataTable();
        DataTable doctorAssistantTable = new DataTable();
        DataTable scrubNurseTable = new DataTable();
        DataTable circulatingNurseTable = new DataTable();
        DataTable nurseAnesthetistTable = new DataTable();

        DataTable preDx1_Table = new DataTable();
        DataTable preDx2_Table = new DataTable();
        DataTable preDx3_Table = new DataTable();
        DataTable preDx4_Table = new DataTable();


        public statistics_UC()
        {
            InitializeComponent();



        }


        private void statistics_UC_Load(object sender, EventArgs e)
        {
            loadCountCase();
            loadPatient();

            addTableColumn();

            loadTable("Doctor");
            dataGridView1.DataSource = doctorTable;

            loadTable("Doctor 2");
            dataGridView4.DataSource = doctorAssistantTable;

            loadTable("Scrub Nurse");
            dataGridView3.DataSource = scrubNurseTable;

            loadTable("Circulating Nurse");
            dataGridView5.DataSource = circulatingNurseTable;

            loadTable("Anesthesist");
            dataGridView6.DataSource = nurseAnesthetistTable;

            loadPreDx1();
            //loadPreDx1("PreDX2");
            //loadPreDx1("PreDX3");
            //loadPreDx1("PreDX4");
            dataGridView7.DataSource = preDx1_Table;
            dataGridView7.Columns[0].Width = 500;



        }


        private void loadCountCase()
        {
            label2.Text = load.getCaseCount(true, "");
            label4.Text = load.getCaseCount(false, "EGD");
            label6.Text = load.getCaseCount(false, "Colono");
            label8.Text = load.getCaseCount(false, "ERCP");
            label10.Text = load.getCaseCount(false, "BRONCO");
            label12.Text = load.getCaseCount(false, "ENT");
        }


        private void loadPatient()
        {
            string male = load.getPatientCount("Male");
            string female = load.getPatientCount("Female");
            string total = load.getPatientCount("total");

            chart1.Titles.Add("Total Patients : " + total + "");
            chart1.Series["sPatient"].Points.AddXY("Male", male);
            chart1.Series["sPatient"].Points.AddXY("Female", female);

            string yrs_15 = load.getPatientAge("15");
            string yrs_30 = load.getPatientAge("30");
            string yrs_40 = load.getPatientAge("40");
            string yrs_50 = load.getPatientAge("50");
            string yrs_60 = load.getPatientAge("60");
            string yrs_70 = load.getPatientAge("70");

            chart2.Series["age"].Points.AddXY("15-29 yrs", yrs_15);
            chart2.Series["age"].Points.AddXY("30-39 yrs", yrs_30);
            chart2.Series["age"].Points.AddXY("40-49 yrs", yrs_40);
            chart2.Series["age"].Points.AddXY("50-59 yrs", yrs_50);
            chart2.Series["age"].Points.AddXY("60-69 yrs", yrs_60);
            chart2.Series["age"].Points.AddXY(">70 yrs", yrs_70);

        }


        private void addTableColumn()
        {
            doctorTable.Columns.Add("Name");
            doctorTable.Columns.Add("EGD");
            doctorTable.Columns.Add("Colono");
            doctorTable.Columns.Add("ERCP");
            doctorTable.Columns.Add("Broncho");
            doctorTable.Columns.Add("ENT");
            doctorTable.Columns.Add("Total");
            doctorTable.PrimaryKey = new DataColumn[] { doctorTable.Columns["Name"] };

            doctorAssistantTable.Columns.Add("Name");
            doctorAssistantTable.Columns.Add("EGD");
            doctorAssistantTable.Columns.Add("Colono");
            doctorAssistantTable.Columns.Add("ERCP");
            doctorAssistantTable.Columns.Add("Broncho");
            doctorAssistantTable.Columns.Add("ENT");
            doctorAssistantTable.Columns.Add("Total");
            doctorAssistantTable.PrimaryKey = new DataColumn[] { doctorAssistantTable.Columns["Name"] };

            scrubNurseTable.Columns.Add("Name");
            scrubNurseTable.Columns.Add("EGD");
            scrubNurseTable.Columns.Add("Colono");
            scrubNurseTable.Columns.Add("ERCP");
            scrubNurseTable.Columns.Add("Broncho");
            scrubNurseTable.Columns.Add("ENT");
            scrubNurseTable.Columns.Add("Total");
            scrubNurseTable.PrimaryKey = new DataColumn[] { scrubNurseTable.Columns["Name"] };

            circulatingNurseTable.Columns.Add("Name");
            circulatingNurseTable.Columns.Add("EGD");
            circulatingNurseTable.Columns.Add("Colono");
            circulatingNurseTable.Columns.Add("ERCP");
            circulatingNurseTable.Columns.Add("Broncho");
            circulatingNurseTable.Columns.Add("ENT");
            circulatingNurseTable.Columns.Add("Total");
            circulatingNurseTable.PrimaryKey = new DataColumn[] { circulatingNurseTable.Columns["Name"] };

            nurseAnesthetistTable.Columns.Add("Name");
            nurseAnesthetistTable.Columns.Add("EGD");
            nurseAnesthetistTable.Columns.Add("Colono");
            nurseAnesthetistTable.Columns.Add("ERCP");
            nurseAnesthetistTable.Columns.Add("Broncho");
            nurseAnesthetistTable.Columns.Add("ENT");
            nurseAnesthetistTable.Columns.Add("Total");
            nurseAnesthetistTable.PrimaryKey = new DataColumn[] { nurseAnesthetistTable.Columns["Name"] };

            preDx1_Table.Columns.Add("ICD10");
            preDx1_Table.Columns.Add("EGD");
            preDx1_Table.Columns.Add("Colono");
            preDx1_Table.Columns.Add("ERCP");
            preDx1_Table.Columns.Add("Broncho");
            preDx1_Table.Columns.Add("ENT");
            preDx1_Table.Columns.Add("Total");
            preDx1_Table.PrimaryKey = new DataColumn[] { preDx1_Table.Columns["ICD10"] };

            preDx2_Table.Columns.Add("ICD10");
            preDx2_Table.Columns.Add("EGD");
            preDx2_Table.Columns.Add("Colono");
            preDx2_Table.Columns.Add("ERCP");
            preDx2_Table.Columns.Add("Broncho");
            preDx2_Table.Columns.Add("ENT");
            preDx2_Table.Columns.Add("Total");
            preDx2_Table.PrimaryKey = new DataColumn[] { preDx2_Table.Columns["ICD10"] };

            preDx3_Table.Columns.Add("ICD10");
            preDx3_Table.Columns.Add("EGD");
            preDx3_Table.Columns.Add("Colono");
            preDx3_Table.Columns.Add("ERCP");
            preDx3_Table.Columns.Add("Broncho");
            preDx3_Table.Columns.Add("ENT");
            preDx3_Table.Columns.Add("Total");
            preDx3_Table.PrimaryKey = new DataColumn[] { preDx3_Table.Columns["ICD10"] };

            preDx4_Table.Columns.Add("ICD10");
            preDx4_Table.Columns.Add("EGD");
            preDx4_Table.Columns.Add("Colono");
            preDx4_Table.Columns.Add("ERCP");
            preDx4_Table.Columns.Add("Broncho");
            preDx4_Table.Columns.Add("ENT");
            preDx4_Table.Columns.Add("Total");
            preDx4_Table.PrimaryKey = new DataColumn[] { preDx4_Table.Columns["ICD10"] };

        }


        private void loadTable(string column)
        {
            string query = "SELECT * FROM `patientcase`";
            DataTable dt = new DataTable();

            try
            {
                MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db"));
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);

                connection.Open();

                adapter.Fill(dt);

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            int numberOfRecords = dt.Rows.Count;

            DataRow[] rows = dt.Select();

            switch (column)
            {
                case "Doctor":
                    for (int i = 0; i < numberOfRecords; i++)
                    {
                        string name = rows[i][column].ToString();

                        if (!doctorTable.Rows.Contains(name) && name != "")
                        {
                            int egd = load.getProcedureCase(name, "EGD", column);
                            int colono = load.getProcedureCase(name, "Col", column);
                            int ercp = load.getProcedureCase(name, "ERCP", column);
                            int broncho = load.getProcedureCase(name, "BRONCO", column);
                            int ent = load.getProcedureCase(name, "ENT", column);

                            int totalProcedure = egd + colono + ercp + broncho + ent;

                            DataRow row;
                            row = doctorTable.NewRow();

                            row["Name"] = rows[i]["Doctor"];
                            row["EGD"] = egd;
                            row["Colono"] = colono;
                            row["ERCP"] = ercp;
                            row["Broncho"] = broncho;
                            row["ENT"] = ent;
                            row["Total"] = totalProcedure;

                            doctorTable.Rows.Add(row);

                        }

                    }
                    break;


                case "Doctor 2":
                    for (int i = 0; i < numberOfRecords; i++)
                    {
                        string name = rows[i][column].ToString();

                        if (!doctorAssistantTable.Rows.Contains(name) && name != "")
                        {
                            int egd = load.getProcedureCase(name, "EGD", column);
                            int colono = load.getProcedureCase(name, "Col", column);
                            int ercp = load.getProcedureCase(name, "ERCP", column);
                            int broncho = load.getProcedureCase(name, "BRONCO", column);
                            int ent = load.getProcedureCase(name, "ENT", column);

                            int totalProcedure = egd + colono + ercp + broncho + ent;

                            DataRow row;
                            row = doctorAssistantTable.NewRow();

                            row["Name"] = rows[i]["Doctor 2"];
                            row["EGD"] = egd;
                            row["Colono"] = colono;
                            row["ERCP"] = ercp;
                            row["Broncho"] = broncho;
                            row["ENT"] = ent;
                            row["Total"] = totalProcedure;

                            doctorAssistantTable.Rows.Add(row);

                        }

                    }
                    break;


                case "Scrub Nurse":
                    for (int i = 0; i < numberOfRecords; i++)
                    {
                        string name = rows[i][column].ToString();

                        if (!scrubNurseTable.Rows.Contains(name) && name != "")
                        {
                            int egd = load.getProcedureCase(name, "EGD", column);
                            int colono = load.getProcedureCase(name, "Col", column);
                            int ercp = load.getProcedureCase(name, "ERCP", column);
                            int broncho = load.getProcedureCase(name, "BRONCO", column);
                            int ent = load.getProcedureCase(name, "ENT", column);

                            int totalProcedure = egd + colono + ercp + broncho + ent;

                            DataRow row;
                            row = scrubNurseTable.NewRow();

                            row["Name"] = rows[i]["Scrub Nurse"];
                            row["EGD"] = egd;
                            row["Colono"] = colono;
                            row["ERCP"] = ercp;
                            row["Broncho"] = broncho;
                            row["ENT"] = ent;
                            row["Total"] = totalProcedure;

                            scrubNurseTable.Rows.Add(row);

                        }

                    }
                    break;


                case "Circulating Nurse":
                    for (int i = 0; i < numberOfRecords; i++)
                    {
                        string name = rows[i][column].ToString();

                        if (!circulatingNurseTable.Rows.Contains(name) && name != "")
                        {
                            int egd = load.getProcedureCase(name, "EGD", column);
                            int colono = load.getProcedureCase(name, "Col", column);
                            int ercp = load.getProcedureCase(name, "ERCP", column);
                            int broncho = load.getProcedureCase(name, "BRONCO", column);
                            int ent = load.getProcedureCase(name, "ENT", column);

                            int totalProcedure = egd + colono + ercp + broncho + ent;

                            DataRow row;
                            row = circulatingNurseTable.NewRow();

                            row["Name"] = rows[i]["Circulating Nurse"];
                            row["EGD"] = egd;
                            row["Colono"] = colono;
                            row["ERCP"] = ercp;
                            row["Broncho"] = broncho;
                            row["ENT"] = ent;
                            row["Total"] = totalProcedure;

                            circulatingNurseTable.Rows.Add(row);

                        }

                    }
                    break;


                case "Anesthesist":
                    for (int i = 0; i < numberOfRecords; i++)
                    {
                        string name = rows[i][column].ToString();

                        if (!nurseAnesthetistTable.Rows.Contains(name) && name != "")
                        {
                            int egd = load.getProcedureCase(name, "EGD", column);
                            int colono = load.getProcedureCase(name, "Col", column);
                            int ercp = load.getProcedureCase(name, "ERCP", column);
                            int broncho = load.getProcedureCase(name, "BRONCO", column);
                            int ent = load.getProcedureCase(name, "ENT", column);

                            int totalProcedure = egd + colono + ercp + broncho + ent;

                            DataRow row;
                            row = nurseAnesthetistTable.NewRow();

                            row["Name"] = rows[i]["Anesthesist"];
                            row["EGD"] = egd;
                            row["Colono"] = colono;
                            row["ERCP"] = ercp;
                            row["Broncho"] = broncho;
                            row["ENT"] = ent;
                            row["Total"] = totalProcedure;

                            nurseAnesthetistTable.Rows.Add(row);

                        }

                    }
                    break;


            }



        }


        private void loadPreDx1()
        {
            string column = "PreDX1";
            string query = "SELECT * FROM `patientcase`";
            DataTable dt = new DataTable();

            try
            {
                MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db"));
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);

                connection.Open();

                adapter.Fill(dt);

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            int numberOfRecords = dt.Rows.Count;

            DataRow[] rows = dt.Select();

            for (int i = 0; i < numberOfRecords; i++)
            {
                string name = rows[i][column].ToString();

                if (!preDx1_Table.Rows.Contains(name) && name != "")
                {
                    int egd = load.getProcedureCase(name, "EGD", column);
                    int colono = load.getProcedureCase(name, "Col", column);
                    int ercp = load.getProcedureCase(name, "ERCP", column);
                    int broncho = load.getProcedureCase(name, "BRONCO", column);
                    int ent = load.getProcedureCase(name, "ENT", column);

                    int totalProcedure = egd + colono + ercp + broncho + ent;

                    DataRow row;
                    row = preDx1_Table.NewRow();

                    row["ICD10"] = rows[i][column];
                    row["EGD"] = egd;
                    row["Colono"] = colono;
                    row["ERCP"] = ercp;
                    row["Broncho"] = broncho;
                    row["ENT"] = ent;
                    row["Total"] = totalProcedure;

                    preDx1_Table.Rows.Add(row);

                }

            }

        }


        private void loadPreDx2()
        {
            string column = "PreDX2";
            string query = "SELECT * FROM `patientcase`";
            DataTable dt = new DataTable();

            try
            {
                MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db"));
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);

                connection.Open();

                adapter.Fill(dt);

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            int numberOfRecords = dt.Rows.Count;

            DataRow[] rows = dt.Select();

            for (int i = 0; i < numberOfRecords; i++)
            {
                string name = rows[i][column].ToString();

                if (!preDx2_Table.Rows.Contains(name) && name != "")
                {
                    int egd = load.getProcedureCase(name, "EGD", column);
                    int colono = load.getProcedureCase(name, "Col", column);
                    int ercp = load.getProcedureCase(name, "ERCP", column);
                    int broncho = load.getProcedureCase(name, "BRONCO", column);
                    int ent = load.getProcedureCase(name, "ENT", column);

                    int totalProcedure = egd + colono + ercp + broncho + ent;

                    DataRow row;
                    row = preDx2_Table.NewRow();

                    row["ICD10"] = rows[i][column];
                    row["EGD"] = egd;
                    row["Colono"] = colono;
                    row["ERCP"] = ercp;
                    row["Broncho"] = broncho;
                    row["ENT"] = ent;
                    row["Total"] = totalProcedure;

                    preDx2_Table.Rows.Add(row);

                }

            }

        }


        private void loadPreDx3()
        {
            string column = "PreDX3";
            string query = "SELECT * FROM `patientcase`";
            DataTable dt = new DataTable();

            try
            {
                MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db"));
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);

                connection.Open();

                adapter.Fill(dt);

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            int numberOfRecords = dt.Rows.Count;

            DataRow[] rows = dt.Select();

            for (int i = 0; i < numberOfRecords; i++)
            {
                string name = rows[i][column].ToString();

                if (!preDx3_Table.Rows.Contains(name) && name != "")
                {
                    int egd = load.getProcedureCase(name, "EGD", column);
                    int colono = load.getProcedureCase(name, "Col", column);
                    int ercp = load.getProcedureCase(name, "ERCP", column);
                    int broncho = load.getProcedureCase(name, "BRONCO", column);
                    int ent = load.getProcedureCase(name, "ENT", column);

                    int totalProcedure = egd + colono + ercp + broncho + ent;

                    DataRow row;
                    row = preDx3_Table.NewRow();

                    row["ICD10"] = rows[i][column];
                    row["EGD"] = egd;
                    row["Colono"] = colono;
                    row["ERCP"] = ercp;
                    row["Broncho"] = broncho;
                    row["ENT"] = ent;
                    row["Total"] = totalProcedure;

                    preDx3_Table.Rows.Add(row);

                }

            }

        }


        private void loadPreDx4()
        {
            string column = "PreDX4";
            string query = "SELECT * FROM `patientcase`";
            DataTable dt = new DataTable();

            try
            {
                MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db"));
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);

                connection.Open();

                adapter.Fill(dt);

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            int numberOfRecords = dt.Rows.Count;

            DataRow[] rows = dt.Select();

            for (int i = 0; i < numberOfRecords; i++)
            {
                string name = rows[i][column].ToString();

                if (!preDx4_Table.Rows.Contains(name) && name != "")
                {
                    int egd = load.getProcedureCase(name, "EGD", column);
                    int colono = load.getProcedureCase(name, "Col", column);
                    int ercp = load.getProcedureCase(name, "ERCP", column);
                    int broncho = load.getProcedureCase(name, "BRONCO", column);
                    int ent = load.getProcedureCase(name, "ENT", column);

                    int totalProcedure = egd + colono + ercp + broncho + ent;

                    DataRow row;
                    row = preDx4_Table.NewRow();

                    row["ICD10"] = rows[i][column];
                    row["EGD"] = egd;
                    row["Colono"] = colono;
                    row["ERCP"] = ercp;
                    row["Broncho"] = broncho;
                    row["ENT"] = ent;
                    row["Total"] = totalProcedure;

                    preDx4_Table.Rows.Add(row);

                }

            }

        }


    }

}
