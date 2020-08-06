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

        public statistics_UC()
        {
            InitializeComponent();


            loadCountCase();
            loadPatient();
            loadDoctorTable();

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
        /*
        private void loadDoctorTable()
        {
            for(int i =1;i<21;i++)
            {
                string index = i.ToString();
                dataGridView1.Rows.Add("Surachai "+ index, "20", "25", "45", "56", "77", "999");
                dataGridView1.Columns[0].Visible = false;
            }
            
        }
        */

        private void loadDoctorTable()
        {
            string query = "SELECT * FROM `patientdata`";

            try
            {
                MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db"));
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);

                connection.Open();

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            dataGridView1.Columns[2].Visible = false; 

        }

    }
}
