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
        DataTable instrumentsTable = new DataTable();

        DataTable roomTable = new DataTable();
        DataTable financeTable = new DataTable();
        DataTable patientTypeAndFinanceTable = new DataTable();

        DataTable preDx1_Table = new DataTable();
        DataTable preDx2_Table = new DataTable();
        DataTable preDx3_Table = new DataTable();
        DataTable preDx4_Table = new DataTable();

        DataTable medicationTable = new DataTable();
        DataTable bronchoMedicationTable = new DataTable();
        DataTable entMedicationTable = new DataTable();

        public statistics_UC()
        {
            InitializeComponent();



        }


        private void statistics_UC_Load(object sender, EventArgs e)
        {
            loadCountCase();
            loadPatient();

            addTableColumn();

            loadProcedureTable("Doctor");
            dataGridView1.DataSource = doctorTable;

            loadProcedureTable("Doctor 2");
            dataGridView4.DataSource = doctorAssistantTable;

            loadProcedureTable("Scrub Nurse");
            dataGridView3.DataSource = scrubNurseTable;

            loadProcedureTable("Circulating Nurse");
            dataGridView5.DataSource = circulatingNurseTable;

            loadProcedureTable("Anesthesist");
            dataGridView6.DataSource = nurseAnesthetistTable;

            loadTable("Instruments");
            dataGridView2.DataSource = instrumentsTable;

            loadTable("Procedure Room");
            dataGridView8.DataSource = roomTable;

            loadTable("finance");
            dataGridView9.DataSource = financeTable;

            loadTable("patientType");
            dataGridView10.DataSource = patientTypeAndFinanceTable;

            loadMedication("Buscopan", "med1", "mg.");
            loadMedication("Diprivan", "med2", "mg.");
            loadMedication("Dormicum", "med3", "mg.");
            loadMedication("Pethidine", "med4", "mg.");
            loadMedication("Fentanyl", "med5", "mcg.");
            loadMedication("Propofol", "med7", "mg.");

            loadBronchoMedication("Midazolam", "med1", "mg.");
            loadBronchoMedication("Fentanyl", "med2", "mcg.");
            loadBronchoMedication("Lidocaine", "med3", "mL.");
            loadBronchoMedication("Atropine", "med4", "mg.");
            loadBronchoMedication("Pethidine", "med5", "mg.");

            loadEntMedication("Buscopan", "med1", "mg.");
            loadEntMedication("Xylocaine 10% Spray", "med2", "mg.");
            loadEntMedication("Dormicum", "med3", "mg.");
            loadEntMedication("Pethidine", "med4", "mg.");
            loadEntMedication("Fentanyl", "med5", "mcg.");
            loadEntMedication("Propofol", "med7", "mg.");

            mergeBronchoMedication();
            mergeEntMedication();
            dataGridView11.DataSource = medicationTable;

            loadPreDx1();
            loadPreDx2();
            loadPreDx3();
            loadPreDx4();
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

            instrumentsTable.Columns.Add("Name");
            instrumentsTable.Columns.Add("Case");
            instrumentsTable.PrimaryKey = new DataColumn[] { instrumentsTable.Columns["Name"] };

            roomTable.Columns.Add("Room");
            roomTable.Columns.Add("Case");
            roomTable.PrimaryKey = new DataColumn[] { roomTable.Columns["Room"] };

            financeTable.Columns.Add("Financial");
            financeTable.Columns.Add("Case");
            financeTable.PrimaryKey = new DataColumn[] { financeTable.Columns["Financial"] };

            patientTypeAndFinanceTable.Columns.Add("Type");
            patientTypeAndFinanceTable.Columns.Add("จ่ายเอง");
            patientTypeAndFinanceTable.Columns.Add("ต้นสังกัด");
            patientTypeAndFinanceTable.Columns.Add("ต่างด้าวขึ้นทะเบียน");
            patientTypeAndFinanceTable.Columns.Add("บัตรทอง");
            patientTypeAndFinanceTable.Columns.Add("ประกันสังคม");
            patientTypeAndFinanceTable.PrimaryKey = new DataColumn[] { patientTypeAndFinanceTable.Columns["Type"] };

            bronchoMedicationTable.Columns.Add("ตัวยาที่ใช้");
            bronchoMedicationTable.Columns.Add("ปริมาณ");
            bronchoMedicationTable.Columns.Add("หน่วย");
            bronchoMedicationTable.PrimaryKey = new DataColumn[] { bronchoMedicationTable.Columns["ตัวยาที่ใช้"] };

            medicationTable.Columns.Add("ตัวยาที่ใช้");
            medicationTable.Columns.Add("ปริมาณ");
            medicationTable.Columns.Add("หน่วย");
            medicationTable.PrimaryKey = new DataColumn[] { medicationTable.Columns["ตัวยาที่ใช้"] };

            entMedicationTable.Columns.Add("ตัวยาที่ใช้");
            entMedicationTable.Columns.Add("ปริมาณ");
            entMedicationTable.Columns.Add("หน่วย");
            entMedicationTable.PrimaryKey = new DataColumn[] { entMedicationTable.Columns["ตัวยาที่ใช้"] };
        }


        private void loadProcedureTable(string column)
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
                case "Instruments":
                    for (int i = 0; i < numberOfRecords; i++)
                    {
                        string name = rows[i][column].ToString();

                        if (!instrumentsTable.Rows.Contains(name) && name != "")
                        {

                            int totalCase = load.getCase(name, column);

                            DataRow row = instrumentsTable.NewRow();

                            row["Name"] = rows[i][column];
                            row["Case"] = totalCase;

                            instrumentsTable.Rows.Add(row);

                        }

                    }
                    break;


                case "Procedure Room":
                    for (int i = 0; i < numberOfRecords; i++)
                    {
                        string name = rows[i][column].ToString();

                        if (!roomTable.Rows.Contains(name) && name != "")
                        {

                            int totalCase = load.getCase(name, column);

                            DataRow row = roomTable.NewRow();

                            row["Room"] = rows[i][column];
                            row["Case"] = totalCase;

                            roomTable.Rows.Add(row);

                        }

                    }
                    break;

                case "finance":
                    for (int i = 0; i < numberOfRecords; i++)
                    {
                        string name = rows[i][column].ToString();

                        if (!financeTable.Rows.Contains(name) && name != "")
                        {

                            int totalCase = load.getCase(name, column);

                            DataRow row = financeTable.NewRow();

                            row["Financial"] = rows[i][column];
                            row["Case"] = totalCase;

                            financeTable.Rows.Add(row);

                        }

                    }
                    break;

                case "patientType":
                    for (int i = 0; i < numberOfRecords; i++)
                    {
                        string name = rows[i][column].ToString();

                        if (!patientTypeAndFinanceTable.Rows.Contains(name) && name != "")
                        {
                            int totalCase = load.getCase(name, column);
                            string type = rows[i][column].ToString();

                            DataRow row = patientTypeAndFinanceTable.NewRow();

                            row["Type"] = type;
                            row["จ่ายเอง"] = load.getCasePatientType(type, "จ่ายเอง");
                            row["ต้นสังกัด"] = load.getCasePatientType(type, "ต้นสังกัด");
                            row["ต่างด้าวขึ้นทะเบียน"] = load.getCasePatientType(type, "ต่างด้าวขึ้นทะเบียน");
                            row["บัตรทอง"] = load.getCasePatientType(type, "บัตรทอง");
                            row["ประกันสังคม"] = load.getCasePatientType(type, "ประกันสังคม");

                            patientTypeAndFinanceTable.Rows.Add(row);
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

            foreach (DataRow DX_ROW in preDx2_Table.Rows)
            {
                string DX2_KEY = DX_ROW["ICD10"].ToString();

                int DX2_EGD = Convert.ToInt32(DX_ROW["EGD"]);
                int DX2_Colono = Convert.ToInt32(DX_ROW["Colono"]);
                int DX2_ERCP = Convert.ToInt32(DX_ROW["ERCP"]);
                int DX2_Broncho = Convert.ToInt32(DX_ROW["Broncho"]);
                int DX2_ENT = Convert.ToInt32(DX_ROW["ENT"]);
                int DX2_Total = Convert.ToInt32(DX_ROW["Total"]);

                if (preDx1_Table.Rows.Contains(DX2_KEY))
                {
                    foreach (DataRow ORI_ROW in preDx1_Table.Rows)
                    {
                        string ORI_KEY = ORI_ROW["ICD10"].ToString();
                        if (ORI_KEY == DX2_KEY)
                        {
                            int UPDATE_EGD = Convert.ToInt32(ORI_ROW["EGD"]);
                            int UPDATE_Colono = Convert.ToInt32(ORI_ROW["Colono"]);
                            int UPDATE_ERCP = Convert.ToInt32(ORI_ROW["ERCP"]);
                            int UPDATE_Broncho = Convert.ToInt32(ORI_ROW["Broncho"]);
                            int UPDATE_ENT = Convert.ToInt32(ORI_ROW["ENT"]);
                            int UPDATE_Total = Convert.ToInt32(ORI_ROW["Total"]);

                            ORI_ROW["EGD"] = UPDATE_EGD + DX2_EGD;
                            ORI_ROW["Colono"] = UPDATE_Colono + DX2_Colono;
                            ORI_ROW["ERCP"] = UPDATE_ERCP + DX2_ERCP;
                            ORI_ROW["Broncho"] = UPDATE_Broncho + DX2_Broncho;
                            ORI_ROW["ENT"] = UPDATE_ENT + DX2_ENT;
                            ORI_ROW["Total"] = UPDATE_Total + DX2_Total;

                        }

                    }
                }
                else
                {
                    DataRow newRow = preDx1_Table.NewRow();
                    newRow["ICD10"] = DX2_KEY;
                    newRow["EGD"] = DX2_EGD;
                    newRow["Colono"] = DX2_Colono;
                    newRow["ERCP"] = DX2_ERCP;
                    newRow["Broncho"] = DX2_Broncho;
                    newRow["ENT"] = DX2_ENT;
                    newRow["Total"] = DX2_Total;
                    preDx1_Table.Rows.Add(newRow);
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

            foreach (DataRow DX_ROW in preDx3_Table.Rows)
            {
                string DX3_KEY = DX_ROW["ICD10"].ToString();

                int DX3_EGD = Convert.ToInt32(DX_ROW["EGD"]);
                int DX3_Colono = Convert.ToInt32(DX_ROW["Colono"]);
                int DX3_ERCP = Convert.ToInt32(DX_ROW["ERCP"]);
                int DX3_Broncho = Convert.ToInt32(DX_ROW["Broncho"]);
                int DX3_ENT = Convert.ToInt32(DX_ROW["ENT"]);
                int DX3_Total = Convert.ToInt32(DX_ROW["Total"]);

                if (preDx1_Table.Rows.Contains(DX3_KEY))
                {
                    foreach (DataRow ORI_ROW in preDx1_Table.Rows)
                    {
                        string ORI_KEY = ORI_ROW["ICD10"].ToString();
                        if (ORI_KEY == DX3_KEY)
                        {
                            int UPDATE_EGD = Convert.ToInt32(ORI_ROW["EGD"]);
                            int UPDATE_Colono = Convert.ToInt32(ORI_ROW["Colono"]);
                            int UPDATE_ERCP = Convert.ToInt32(ORI_ROW["ERCP"]);
                            int UPDATE_Broncho = Convert.ToInt32(ORI_ROW["Broncho"]);
                            int UPDATE_ENT = Convert.ToInt32(ORI_ROW["ENT"]);
                            int UPDATE_Total = Convert.ToInt32(ORI_ROW["Total"]);

                            ORI_ROW["EGD"] = UPDATE_EGD + DX3_EGD;
                            ORI_ROW["Colono"] = UPDATE_Colono + DX3_Colono;
                            ORI_ROW["ERCP"] = UPDATE_ERCP + DX3_ERCP;
                            ORI_ROW["Broncho"] = UPDATE_Broncho + DX3_Broncho;
                            ORI_ROW["ENT"] = UPDATE_ENT + DX3_ENT;
                            ORI_ROW["Total"] = UPDATE_Total + DX3_Total;

                        }

                    }
                }
                else
                {
                    DataRow newRow = preDx1_Table.NewRow();
                    newRow["ICD10"] = DX3_KEY;
                    newRow["EGD"] = DX3_EGD;
                    newRow["Colono"] = DX3_Colono;
                    newRow["ERCP"] = DX3_ERCP;
                    newRow["Broncho"] = DX3_Broncho;
                    newRow["ENT"] = DX3_ENT;
                    newRow["Total"] = DX3_Total;
                    preDx1_Table.Rows.Add(newRow);
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

            foreach (DataRow DX_ROW in preDx4_Table.Rows)
            {
                string DX4_KEY = DX_ROW["ICD10"].ToString();

                int DX4_EGD = Convert.ToInt32(DX_ROW["EGD"]);
                int DX4_Colono = Convert.ToInt32(DX_ROW["Colono"]);
                int DX4_ERCP = Convert.ToInt32(DX_ROW["ERCP"]);
                int DX4_Broncho = Convert.ToInt32(DX_ROW["Broncho"]);
                int DX4_ENT = Convert.ToInt32(DX_ROW["ENT"]);
                int DX4_Total = Convert.ToInt32(DX_ROW["Total"]);

                if (preDx1_Table.Rows.Contains(DX4_KEY))
                {
                    foreach (DataRow ORI_ROW in preDx1_Table.Rows)
                    {
                        string ORI_KEY = ORI_ROW["ICD10"].ToString();
                        if (ORI_KEY == DX4_KEY)
                        {
                            int UPDATE_EGD = Convert.ToInt32(ORI_ROW["EGD"]);
                            int UPDATE_Colono = Convert.ToInt32(ORI_ROW["Colono"]);
                            int UPDATE_ERCP = Convert.ToInt32(ORI_ROW["ERCP"]);
                            int UPDATE_Broncho = Convert.ToInt32(ORI_ROW["Broncho"]);
                            int UPDATE_ENT = Convert.ToInt32(ORI_ROW["ENT"]);
                            int UPDATE_Total = Convert.ToInt32(ORI_ROW["Total"]);

                            ORI_ROW["EGD"] = UPDATE_EGD + DX4_EGD;
                            ORI_ROW["Colono"] = UPDATE_Colono + DX4_Colono;
                            ORI_ROW["ERCP"] = UPDATE_ERCP + DX4_ERCP;
                            ORI_ROW["Broncho"] = UPDATE_Broncho + DX4_Broncho;
                            ORI_ROW["ENT"] = UPDATE_ENT + DX4_ENT;
                            ORI_ROW["Total"] = UPDATE_Total + DX4_Total;

                        }

                    }
                }
                else
                {
                    DataRow newRow = preDx1_Table.NewRow();
                    newRow["ICD10"] = DX4_KEY;
                    newRow["EGD"] = DX4_EGD;
                    newRow["Colono"] = DX4_Colono;
                    newRow["ERCP"] = DX4_ERCP;
                    newRow["Broncho"] = DX4_Broncho;
                    newRow["ENT"] = DX4_ENT;
                    newRow["Total"] = DX4_Total;
                    preDx1_Table.Rows.Add(newRow);
                }

            }

        }


        private void loadBronchoMedication(string name, string column, string unit)
        {
            DataRow newRow = bronchoMedicationTable.NewRow();

            newRow["ตัวยาที่ใช้"] = name;
            newRow["ปริมาณ"] = load.sumBronchoMedication(column);
            newRow["หน่วย"] = unit;
            bronchoMedicationTable.Rows.Add(newRow);

        }


        private void loadMedication(string name, string column, string unit)
        {
            DataRow newRow = medicationTable.NewRow();

            newRow["ตัวยาที่ใช้"] = name;
            newRow["ปริมาณ"] = load.sumMedication(column);
            newRow["หน่วย"] = unit;
            medicationTable.Rows.Add(newRow);

        }


        private void loadEntMedication(string name, string column, string unit)
        {
            DataRow newRow = entMedicationTable.NewRow();

            newRow["ตัวยาที่ใช้"] = name;
            newRow["ปริมาณ"] = load.sumEntMedication(column);
            newRow["หน่วย"] = unit;
            entMedicationTable.Rows.Add(newRow);

        }


        private void mergeBronchoMedication()
        {
            foreach (DataRow bronchoRow in bronchoMedicationTable.Rows)
            {
                string bronchoKey = bronchoRow["ตัวยาที่ใช้"].ToString();
                int bronchoValue = Convert.ToInt32(bronchoRow["ปริมาณ"]);

                if (medicationTable.Rows.Contains(bronchoKey))
                {
                    foreach (DataRow oriRow in medicationTable.Rows)
                    {
                        string key = oriRow["ตัวยาที่ใช้"].ToString();
                        if (key == bronchoKey)
                        {
                            int updateValue = Convert.ToInt32(oriRow["ปริมาณ"]);

                            oriRow["ปริมาณ"] = updateValue + bronchoValue;

                        }

                    }
                }

                else
                {
                    string unit = "";
                    switch (bronchoKey)
                    {
                        case "Fentanyl":
                            unit = "mcg.";
                            break;

                        case "Lidocaine":
                            unit = "mL.";
                            break;
                        default:
                            unit = "mg.";
                            break;
                    }

                    DataRow newRow = medicationTable.NewRow();
                    newRow["ตัวยาที่ใช้"] = bronchoKey;
                    newRow["ปริมาณ"] = bronchoValue;
                    newRow["หน่วย"] = unit;

                    medicationTable.Rows.Add(newRow);
                }

            }


        }

        private void mergeEntMedication()
        {
            foreach (DataRow entRow in entMedicationTable.Rows)
            {
                string entKey = entRow["ตัวยาที่ใช้"].ToString();
                int entValue = Convert.ToInt32(entRow["ปริมาณ"]);

                if (medicationTable.Rows.Contains(entKey))
                {
                    foreach (DataRow oriRow in medicationTable.Rows)
                    {
                        string key = oriRow["ตัวยาที่ใช้"].ToString();
                        if (key == entKey)
                        {
                            int updateValue = Convert.ToInt32(oriRow["ปริมาณ"]);

                            oriRow["ปริมาณ"] = updateValue + entValue;

                        }

                    }
                }

                else
                {
                    string unit = "";
                    switch (entKey)
                    {
                        case "Fentanyl":
                            unit = "mcg.";
                            break;

                        case "Lidocaine":
                            unit = "mL.";
                            break;
                        default:
                            unit = "mg.";
                            break;
                    }

                    DataRow newRow = medicationTable.NewRow();
                    newRow["ตัวยาที่ใช้"] = entKey;
                    newRow["ปริมาณ"] = entValue;
                    newRow["หน่วย"] = unit;

                    medicationTable.Rows.Add(newRow);
                }

            }


        }


    }

}
