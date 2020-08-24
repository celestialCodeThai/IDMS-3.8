using Dapper;
using IDMS.DataManage;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDMS.Popup
{
    public partial class previewPopup : Form
    {
        DataAccess db = new DataAccess();
        string caseId;
        string hnId;
        string prefix;
        string clickValue;
        public previewPopup(string caseid)
        {
            InitializeComponent();

            MySqlDataReader readerPro;
            MySqlConnection connectionP = new MySqlConnection(dbhelper.CnnVal("db"));


            connectionP.Open();
            MySqlCommand myCommandPro = new MySqlCommand("select * from patientcase where caseid='" + caseid + "'", connectionP);
            readerPro = myCommandPro.ExecuteReader();


            caseId = caseid;


            while (readerPro.Read())
            {
                hnId = readerPro["hn"].ToString();

                string date = readerPro["Date"].ToString();
                string day = readerPro["Day"].ToString();
                string[] splitRegisDate = date.Split('-');
                regisDate.Text = splitRegisDate[0];
                regisTime.Text = splitRegisDate[1];

                string indication = readerPro["Indication"].ToString();
                indicationValue.Text = indication;

                string preDx1 = readerPro["PreDX1"].ToString();
                string preDx2 = readerPro["PreDX2"].ToString();
                string preDx3 = readerPro["PreDX3"].ToString();
                string preDx4 = readerPro["PreDX4"].ToString();
                preDiagnosisValue.Text = preDx1 + preDx2 + preDx3 + preDx4;

                string hn = readerPro["hn"].ToString();
                hnValue.Text = hn;

                string camera = readerPro["Instruments"].ToString();
                string[] getAllCamera = camera.Split('$');
                instrumentsValue_1.Text = getAllCamera[0];

                if (getAllCamera.Length == 2) { instrumentsValue_2.Text = getAllCamera[1]; }

                string procedure = readerPro["Procedure"].ToString();
                procedureValue.Text = procedure;

                string procedureRoom = readerPro["Procedure Room"].ToString();
                roomValue.Text = procedureRoom;

                string doctor = readerPro["Doctor"].ToString();
                string doctor2 = readerPro["Doctor 2"].ToString();
                string scrubNurse = readerPro["Scrub Nurse"].ToString();
                string circulatingNurse = readerPro["Circulating Nurse"].ToString();
                string anesthesist = readerPro["Anesthesist"].ToString();
                doctorValue.Text = doctor;
                doctor2Value.Text = doctor2;
                scrubNurseValue.Text = scrubNurse;
                circulatingNurseValue.Text = circulatingNurse;
                anesthesistValue.Text = anesthesist;

                if (instrumentsValue_2.Text.Length > 0)
                {
                    removeButton.Visible = true;
                }

            }
            connectionP.Close();

            MySqlDataReader readerPatienData;
            MySqlConnection getPatienData = new MySqlConnection(dbhelper.CnnVal("db"));
            getPatienData.Open();

            MySqlCommand patienDatas = new MySqlCommand("select * from patientdata where hn='" + hnValue.Text + "'", getPatienData);
            readerPatienData = patienDatas.ExecuteReader();

            while (readerPatienData.Read())
            {
                prefix = readerPatienData["prefix"].ToString();

                string type = readerPatienData["type"].ToString();
                typeValue.Text = type;

                string firstName = readerPatienData["name"].ToString();
                firstNameValue.Text = firstName;

                string lastName = readerPatienData["surname"].ToString();
                lastNameValue.Text = lastName;

                string age = readerPatienData["age"].ToString();
                ageValue.Text = age;

                string nationality = readerPatienData["nationality"].ToString();
                nationalityValue.Text = nationality;
            }
            getPatienData.Close();
        }


        string cameraid;


        private string getcameraData()
        {
            using (Instrument formOptions = new Instrument())
            {
                formOptions.ShowDialog();

                string result = formOptions.GetMyResult();
                cameraid = formOptions.GetMyResultID();
                return result;

            }

        }


        private void instrumentsClick(object sender, EventArgs e)
        {
            string camera = getcameraData();
            if (camera != null)
            {
                instrumentsValue_1.Text = cameraid + "-" + camera;
            }
        }


        private void submitValue_Click(object sender, EventArgs e)
        {
            string updateFullName = "`Patient Name`";
            string updateCamera = "`Instruments`";
            string updateProcedureRoom = "`Procedure Room`";
            string updateDoctor = "`Doctor`";
            string updateDoctor2 = "`Doctor 2`";
            string updateScrubNurse = "`Scrub Nurse`";
            string updateCirculatingNurse = "`Circulating Nurse`";
            string updateAnesthesist = "`Anesthesist`";
            string updateCameraA = "`cameraA`";
            string updateCameraB = "`cameraB`";

            string name = firstNameValue.Text;
            string lastName = lastNameValue.Text;
            string fullName = prefix + " " + name + " " + lastName;
            string procedureRoom = roomValue.Text;
            string camera = instrumentsValue_1.Text + "$" + instrumentsValue_2.Text;
            string doctor = doctorValue.Text;
            string doctor2 = doctor2Value.Text;
            string scrubNurse = scrubNurseValue.Text;
            string circulatingNurse = circulatingNurseValue.Text;
            string anesthesist = anesthesistValue.Text;
            string cameraA = instrumentsValue_1.Text;
            string cameraB = instrumentsValue_2.Text;

            string patientcaseUpdateQuery = "UPDATE patientcase SET " +
                    updateFullName + " = '" + fullName + "'," +
                    updateProcedureRoom + " = '" + procedureRoom + "'," +
                    updateDoctor + " = '" + doctor + "'," +
                    updateDoctor2 + " = '" + doctor2 + "'," +
                    updateScrubNurse + " = '" + scrubNurse + "'," +
                    updateCirculatingNurse + " = '" + circulatingNurse + "'," +
                    updateAnesthesist + " = '" + anesthesist + "'," +
                    updateCameraA + " = '" + cameraA + "'," +
                    updateCameraB + " = '" + cameraB + "'," +
                    updateCamera + " = '" + camera +
                    "' WHERE `patientcase`.`caseid` = '" + caseId + "'";

            using (MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db")))
            {
                connection.Execute(patientcaseUpdateQuery);
            }

            string type = typeValue.Text;
            string age = ageValue.Text;
            string nationality = nationalityValue.Text;


            string updateName = "`name` = '" + name + "'";
            string updateSurname = "`surname` = '" + lastName + "'";

            string updateType = "`type` = '" + type + "'";
            string updateAge = "`age` = '" + age + "'";
            string updateNationality = "`nationality` = '" + nationality + "'";



            using (MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db")))
            {
                connection.Execute("UPDATE patientdata SET " + updateType + "," + updateName + "," + updateSurname + "," + updateAge + "," + updateNationality + " WHERE `patientdata`.`hn` = '" + hnId + "'");
            }

            clickValue = "submit";

            Close();
        }


        public string GetMyResult()
        {
            return clickValue;
        }


        private void cancel_Click(object sender, EventArgs e)
        {
            clickValue = "cancel";
            Close();
        }


        private void selectButton_2_Click(object sender, EventArgs e)
        {
            string camera = getcameraData();
            if (camera != null)
            {
                instrumentsValue_2.Text = cameraid + "-" + camera;
                removeButton.Visible = true;
            }
        }


        private void removeButton_Click(object sender, EventArgs e)
        {
            instrumentsValue_2.Text = "";
            removeButton.Visible = false;
        }


    }
}
