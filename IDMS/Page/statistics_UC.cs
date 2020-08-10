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

        DataTable icd10Table = new DataTable();
        DataTable tempTable = new DataTable();


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

            loadIcd10();
            dataGridView7.DataSource = icd10Table;
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

            icd10Table.Columns.Add("ICD10");
            icd10Table.Columns.Add("EGD");
            icd10Table.Columns.Add("Colono");
            icd10Table.Columns.Add("ERCP");
            icd10Table.Columns.Add("Broncho");
            icd10Table.Columns.Add("ENT");
            icd10Table.Columns.Add("Total");

            icd10Table.PrimaryKey = new DataColumn[] { icd10Table.Columns["ICD10"] };

            tempTable.Columns.Add("ICD10");
            tempTable.Columns.Add("EGD");
            tempTable.Columns.Add("Colono");
            tempTable.Columns.Add("ERCP");
            tempTable.Columns.Add("Broncho");
            tempTable.Columns.Add("ENT");
            tempTable.Columns.Add("Total");

            tempTable.PrimaryKey = new DataColumn[] { tempTable.Columns["ICD10"] };
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


        private void loadIcd10()
        {
            //ICD10_1
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

                if (!icd10Table.Rows.Contains(name) && name != "")
                {
                    int egd = load.getProcedureCase(name, "EGD", column);
                    int colono = load.getProcedureCase(name, "Col", column);
                    int ercp = load.getProcedureCase(name, "ERCP", column);
                    int broncho = load.getProcedureCase(name, "BRONCO", column);
                    int ent = load.getProcedureCase(name, "ENT", column);

                    int totalProcedure = egd + colono + ercp + broncho + ent;

                    DataRow row;
                    row = icd10Table.NewRow();

                    row["ICD10"] = rows[i][column];
                    row["EGD"] = egd;
                    row["Colono"] = colono;
                    row["ERCP"] = ercp;
                    row["Broncho"] = broncho;
                    row["ENT"] = ent;
                    row["Total"] = totalProcedure;

                    icd10Table.Rows.Add(row);

                }

            }


            //ICD10_2
            column = "PreDX2";
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

            numberOfRecords = dt.Rows.Count;
            rows = dt.Select();

            for (int i = 0; i < numberOfRecords; i++)
            {
                string name = rows[i][column].ToString();

                if (!tempTable.Rows.Contains(name) && name != "")
                {
                    int egd = load.getProcedureCase(name, "EGD", column);
                    int colono = load.getProcedureCase(name, "Col", column);
                    int ercp = load.getProcedureCase(name, "ERCP", column);
                    int broncho = load.getProcedureCase(name, "BRONCO", column);
                    int ent = load.getProcedureCase(name, "ENT", column);

                    int totalProcedure = egd + colono + ercp + broncho + ent;

                    DataRow row;
                    row = tempTable.NewRow();

                    row["ICD10"] = rows[i][column];
                    row["EGD"] = egd;
                    row["Colono"] = colono;
                    row["ERCP"] = ercp;
                    row["Broncho"] = broncho;
                    row["ENT"] = ent;
                    row["Total"] = totalProcedure;

                    tempTable.Rows.Add(row);

                }

                icd10Table.Merge(tempTable);

                try
                {
                    tempTable.Clear();
                }
                catch (DataException e)
                {
                    // Process exception and return.
                    Console.WriteLine("Exception of type {0} occurred.",
                        e.GetType());
                }

            }


            //ICD10_3
            column = "PreDX3";
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

            numberOfRecords = dt.Rows.Count;
            rows = dt.Select();

            for (int i = 0; i < numberOfRecords; i++)
            {
                string name = rows[i][column].ToString();

                if (!tempTable.Rows.Contains(name) && name != "")
                {
                    int egd = load.getProcedureCase(name, "EGD", column);
                    int colono = load.getProcedureCase(name, "Col", column);
                    int ercp = load.getProcedureCase(name, "ERCP", column);
                    int broncho = load.getProcedureCase(name, "BRONCO", column);
                    int ent = load.getProcedureCase(name, "ENT", column);

                    int totalProcedure = egd + colono + ercp + broncho + ent;

                    DataRow row;
                    row = tempTable.NewRow();

                    row["ICD10"] = rows[i][column];
                    row["EGD"] = egd;
                    row["Colono"] = colono;
                    row["ERCP"] = ercp;
                    row["Broncho"] = broncho;
                    row["ENT"] = ent;
                    row["Total"] = totalProcedure;

                    tempTable.Rows.Add(row);

                }

                icd10Table.Merge(tempTable);

                try
                {
                    tempTable.Clear();
                }
                catch (DataException e)
                {
                    // Process exception and return.
                    Console.WriteLine("Exception of type {0} occurred.",
                        e.GetType());
                }

            }

            
            //ICD10_4
            column = "PreDX4";
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

            numberOfRecords = dt.Rows.Count;
            rows = dt.Select();

            for (int i = 0; i < numberOfRecords; i++)
            {
                string name = rows[i][column].ToString();

                if (!tempTable.Rows.Contains(name) && name != "")
                {
                    int egd = load.getProcedureCase(name, "EGD", column);
                    int colono = load.getProcedureCase(name, "Col", column);
                    int ercp = load.getProcedureCase(name, "ERCP", column);
                    int broncho = load.getProcedureCase(name, "BRONCO", column);
                    int ent = load.getProcedureCase(name, "ENT", column);

                    int totalProcedure = egd + colono + ercp + broncho + ent;

                    DataRow row;
                    row = tempTable.NewRow();

                    row["ICD10"] = rows[i][column];
                    row["EGD"] = egd;
                    row["Colono"] = colono;
                    row["ERCP"] = ercp;
                    row["Broncho"] = broncho;
                    row["ENT"] = ent;
                    row["Total"] = totalProcedure;

                    tempTable.Rows.Add(row);

                }

                icd10Table.Merge(tempTable);

                try
                {
                    tempTable.Clear();
                }
                catch (DataException e)
                {
                    // Process exception and return.
                    Console.WriteLine("Exception of type {0} occurred.",
                        e.GetType());
                }

            }

            


        }




    }
}
