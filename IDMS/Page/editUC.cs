using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;
using IDMS.DataManage;
using IDMS.Popup;
using MySql.Data.MySqlClient;

namespace IDMS.Page
{
    public partial class editUC : UserControl
    {
        private idmsPage idms;

        public static bool camOpen = false;
        public static bool reportOpen = false;
        List<hnData> info = new List<hnData>();
        bool sex = true;
        bool Ptype = true;
        public editUC(idmsPage mainPage,string hn,string cid)
        {

            InitializeComponent();
            this.idms = mainPage;

            string path = Application.StartupPath;
            string sub = path.Replace("bin", "Jquery");
            sub = sub.Replace("Debug", "index.html");


            jqueryPanel.Url = new Uri(sub);

            defaultButton();
            loadcasedata(cid);


            

        }
        string caseid;
        public void loadcasedata(string cid)
        {

            MySqlDataReader readerPro;
            MySqlDataReader readerProhn;
            MySqlConnection connectionP = new MySqlConnection(dbhelper.CnnVal("db"));
            connectionP.Open();

            MySqlCommand myCommandPro = new MySqlCommand("select * from patientcase where caseid='" + cid + "'", connectionP);
            string patienthn = "";
            string patientpro = "";
            string Indi = "";
            string p1 = "";
            string p2 = "";
            string p3 = "";
            string p4 = "";
            caseid = cid;
            readerPro = myCommandPro.ExecuteReader();

            while (readerPro.Read())
            {
                patienthn = readerPro["hn"].ToString(); ;
                patientpro = readerPro["Procedure"].ToString();
                procedureRoom.Text = readerPro["Procedure Room"].ToString();
                Indi = readerPro["Indication"].ToString();
                instruments.Text = readerPro["Instruments"].ToString();
                p1 = readerPro["PreDX1"].ToString();
                p2 = readerPro["PreDX2"].ToString();
                p3 = readerPro["PreDX3"].ToString();
                p4 = readerPro["PreDX4"].ToString();
                regisDate.Text = readerPro["Date"].ToString();
               doc1.Text = readerPro["Doctor"].ToString();
                doc2.Text = readerPro["Doctor 2"].ToString();
                sn.Text = readerPro["Scrub Nurse"].ToString();
                cn.Text = readerPro["Circulating Nurse"].ToString();
                an.Text = readerPro["Anesthesist"].ToString();

            }
            readerPro.Close();
            if (patientpro.Contains("EGD"))
            { procedure1.Checked = true; }
            if (patientpro.Contains("Colono"))
            { procedure2.Checked = true; }
            if (patientpro.Contains("Enter"))
            { procedure3.Checked = true; }

            string[] temp;
            if (p1 != "")
            {
                temp = p1.Split('-');
                cd1.Text = temp[0];
                dx1.Text = temp[1];
            }
            if (p2 != "")
            {
                temp = p2.Split('-');
                cd2.Text = temp[0];
                dx2.Text = temp[1];
            }
            if (p3 != "")
            {
                temp = p3.Split('-');
                cd3.Text = temp[0];
                dx3.Text = temp[1];
            }
            if (p4 != "")
            {
                temp = p4.Split('-');
                cd4.Text = temp[0];
                dx4.Text = temp[1];
            }





            MySqlCommand myCommandPro2 = new MySqlCommand("select * from patientdata where hn='" + patienthn + "'", connectionP);
            readerProhn = myCommandPro2.ExecuteReader();
            string esex = "";
            string etype = "";
            while (readerProhn.Read())
            {
                hn.Text = readerProhn["hn"].ToString(); ;
                FirstName.Text = readerProhn["name"].ToString();
                LastName.Text = readerProhn["surname"].ToString();
                prefix.Text = readerProhn["prefix"].ToString();
                ageText.Text = readerProhn["age"].ToString();
                esex = readerProhn["sex"].ToString();
              //  dateBirth.Text = readerProhn["birthdate"].ToString();
                nationBox.Text = readerProhn["nationality"].ToString();
                etype = readerProhn["type"].ToString();
              



            }
            if (esex == "Male")
            {
                sexMalebutton.BackColor = Color.RoyalBlue;
                sexMalebutton.ForeColor = Color.White;

                sexFemalebutton.BackColor = Color.Lavender;
                sexFemalebutton.ForeColor = Color.RoyalBlue;
                sex = true;
            }
            else
            {

                sexFemalebutton.BackColor = Color.RoyalBlue;
                sexFemalebutton.ForeColor = Color.White;

                sexMalebutton.BackColor = Color.Lavender;
                sexMalebutton.ForeColor = Color.RoyalBlue;
                sex = false;
            }


            if (etype == "OPD")
            {
                opdButton.BackColor = Color.RoyalBlue;
                opdButton.ForeColor = Color.White;

                WardButton.BackColor = Color.Lavender;
                WardButton.ForeColor = Color.RoyalBlue;
                ward.Visible = false;
                ward.Text = "";
                Ptype = true;
            }
            else
            {
                WardButton.BackColor = Color.RoyalBlue;
                WardButton.ForeColor = Color.White;

                opdButton.BackColor = Color.Lavender;
                opdButton.ForeColor = Color.RoyalBlue;
                ward.Visible = true;
                Ptype = false;
                ward.Text = etype.Replace("WARD","");
            }
            connectionP.Close();

            setTime();
        }
        public void connectMySQL()
        {
            IDbConnection connection = new System.Data.SqlClient.SqlConnection(dbhelper.CnnVal("db"));



        }



        string pro = "";
        bool checkfield()
        {
            bool checker = true;
            if (hn.Text == "")
            {
              //  checkhn.Visible = true;
                checker = false;
            }
            if (prefix.Text == "")
            {
               // checkprefix.Visible = true;
                checker = false;
            }
            if (FirstName.Text == "")
            {
              //  checkname.Visible = true;
                checker = false;
            }
            if (LastName.Text == "")
            {
               // checklastname.Visible = true;
                checker = false;
            }
            if (procedure1.Checked == false && procedure2.Checked == false && procedure3.Checked == false)
            {

              //  checkpro.Visible = true;
                checker = false;
            }
            if (doc1.Text == null)
            {
               // checkdoc.Visible = true;
                checker = false;
            }
            if (nationBox.Text == "")
            {
              //  checknation.Visible = true;
                checker = false;
            }
            if (ageText.Text == "")
            {
               // checkage.Visible = true;
                checker = false;
            }

            return checker;
        }
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (checkfield() == false) { return; }

            DialogResult dialogResult = MessageBox.Show("Sure", "register data ?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {




                if (procedure1.Checked == true)
                {
                    pro += "EGD";
                }
                if (procedure2.Checked == true)
                {
                    if (procedure1.Checked == true) { pro += "/Colono"; }
                    else { pro += "Colonoscopy"; }
                }
                if (procedure3.Checked == true)
                {
                    if (procedure1.Checked == true || procedure2.Checked == true) { pro += "/Enter"; }
                    else { pro += "Enterscopy"; }
                }












                string a = hn.Text + "-" + tempdate + "-" + temptime;
                string b = regisDate.Text + "-" + regisTime.Text;
                string c = regisDate.Text;
                string pRoom = procedureRoom.Text;
                string inst = instruments.Text;
                string d1 = doc1.Text;
                string d2 = "";
                if (doc2.SelectedItem != null) { d2 = doc2.SelectedItem.ToString(); }
                string sc = "";
                if (sn.SelectedItem != null)
                {
                    sc = sn.SelectedItem.ToString();
                }



                string ac = "";
                if (an.SelectedItem != null)
                {
                    ac = sn.SelectedItem.ToString();
                }


                string cc = "";
                if (cn.SelectedItem != null)
                {
                    cc = sn.SelectedItem.ToString();
                }





                string indi = getindication();

                string birth = "";
                string pf;
                if (prefix.Text == "")
                {
                    pf = prefix.SelectedItem.ToString();
                }
                else
                {
                    pf = prefix.Text;
                }
                string nt = nationBox.SelectedItem.ToString();
                string w;
                string gender;
                if (Ptype == true)
                {
                    w = "OPD";
                }
                else
                {
                    w = "WARD" + ward.Text;
                }

                if (sex == true)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                DataAccess db = new DataAccess();
                string cname = pf+" " + FirstName.Text + " " + LastName.Text;
                db.DeleteRow(caseid);
                db.AddNewCase(a, cname, hn.Text, pro, pRoom, indi, inst, cd1.Text + "-" + dx1.Text, cd2.Text + "-" + dx2.Text, cd3.Text + "-" + dx3.Text, cd4.Text + "-" + dx4.Text, b, c, d1, d2, sc, cc, ac, "Prepare","editFinance","editType");








                System.Windows.Forms.MessageBox.Show("register complete");



                idms.ChangePageToCase();



            }
            else if (dialogResult == DialogResult.No)
            {

            }


        }

        private void sexFemalebutton_Click(object sender, EventArgs e)
        {
            sexFemalebutton.BackColor = Color.RoyalBlue;
            sexFemalebutton.ForeColor = Color.White;

            sexMalebutton.BackColor = Color.Lavender;
            sexMalebutton.ForeColor = Color.RoyalBlue;
            sex = false;
        }

        private void sexMalebutton_Click(object sender, EventArgs e)
        {

            sexMalebutton.BackColor = Color.RoyalBlue;
            sexMalebutton.ForeColor = Color.White;

            sexFemalebutton.BackColor = Color.Lavender;
            sexFemalebutton.ForeColor = Color.RoyalBlue;
            sex = true;
        }

        private void opdButton_Click(object sender, EventArgs e)
        {
            opdButton.BackColor = Color.RoyalBlue;
            opdButton.ForeColor = Color.White;

            WardButton.BackColor = Color.Lavender;
            WardButton.ForeColor = Color.RoyalBlue;
            ward.Visible = false;
            ward.Text = "";
            Ptype = true;
        }

        private void WardButton_Click(object sender, EventArgs e)
        {
            WardButton.BackColor = Color.RoyalBlue;
            WardButton.ForeColor = Color.White;

            opdButton.BackColor = Color.Lavender;
            opdButton.ForeColor = Color.RoyalBlue;
            ward.Visible = true;
            Ptype = false;
        }








        //For 24 H format

        DateTime today = DateTime.Today;

        DateTime tempDB;
        string tempdate;
        string temptime;

        public void setTime()
        {
            tempDB = today;
            regisDate.Text = today.ToString("dd/MM/yyyy");
            tempdate = today.ToString("ddMMyy");
            regisTime.Text = DateTime.Now.ToString("HH:mm A.M./P.M.");
            temptime = DateTime.Now.ToString("HHmmss");
        }
        private void datenowbtn_Click(object sender, EventArgs e)
        {
            setTime();
        }

        private void birthDate_TextChanged(object sender, EventArgs e)
        {
            //TimeSpan ts = DateTime.Now - Convert.ToDateTime(birthDate.Text);
            // int age = Convert.ToInt32(ts.Days) / 365;
            // ageText.Text = age.ToString();
        }

       



        private string getindication()
        {









            string b = "";
            var element = jqueryPanel.Document.GetElementById("jq");
            dynamic dom = element.DomElement;
            /*
                        int index = (int)dom.selectedIndex(); 
                          if (index != -1)
                          {
                             b = element.Children[index].InnerText;
                            System.Windows.Forms.MessageBox.Show(b);
                          }
                   */


            for (int i = 0; i < 7; i++)
            {
                if (dom.Children[i].selected == true)
                {

                    b += dom.Children[i].InnerText + ",";

                    //  System.Windows.Forms.MessageBox.Show(b);
                }
            }
            if (b.Length > 0)
            {
                b = b.Remove(b.Length - 1);
            }

            return b;





        }




        string medid;
        private string getmedData()
        {
            using (medTable_Template2 formOptions = new medTable_Template2())
            {
                formOptions.ShowDialog();

                string result = formOptions.GetMyResult();
                medid = formOptions.GetMyResultID();
                return result;

            }
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

        private void predx1btn_Click(object sender, EventArgs e)
        {

            dx1.Text = getmedData();
            cd1.Text = medid;
        }

        private void predx2btn_Click(object sender, EventArgs e)
        {
            dx2.Text = getmedData();
            cd2.Text = medid;
        }

        private void predx3btn_Click(object sender, EventArgs e)
        {
            dx3.Text = getmedData();
            cd3.Text = medid;
        }

        private void predx4_Click(object sender, EventArgs e)
        {
            dx4.Text = getmedData();
            cd4.Text = medid;
        }

        private void instu_Click(object sender, EventArgs e)
        {

        }










        private void button2_Click(object sender, EventArgs e)
        {
            idms.ChangePageToCase();

        }
        public void RemoveText(object sender, EventArgs e)
        {
            RemoveText(hn);
        }

        public void AddText(object sender, EventArgs e)
        {
            AddText(hn, "Enter Hn Number");
        }

        public void RemoveText(TextBox a)
        {
            a.Text = "";
            a.ForeColor = Color.Black;
        }

        public void AddText(TextBox a, String b)
        {

            if (string.IsNullOrWhiteSpace(a.Text))
                a.Text = b;
            if (a.Text == b)
            {
                a.ForeColor = Color.Gray;
            }
            else
            {

                a.ForeColor = Color.Black;


            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private void dx1_TextChanged(object sender, EventArgs e)
        {

            if (dx1.Text != "")
            {
                predx2btn.Enabled = true;
                predx2btn.BackColor = Color.CornflowerBlue;
                dx2.Enabled = true;
                cd2.Enabled = true;
            }
            else
            {
                predx2btn.BackColor = Color.Gainsboro;

                predx2btn.Enabled = false;
                dx2.Enabled = false;
                cd2.Enabled = false;
                cd2.Text = "";
                dx2.Text = "";


            }

        }
        private void dx2_TextChanged(object sender, EventArgs e)
        {


            if (dx2.Text != "")
            {
                predx3btn.Enabled = true;
                predx3btn.BackColor = Color.CornflowerBlue;

                dx3.Enabled = true;
                cd3.Enabled = true;
            }
            else
            {
                predx3btn.BackColor = Color.Gainsboro;

                predx3btn.Enabled = false;
                dx3.Enabled = false;
                cd3.Enabled = false;
                cd3.Text = "";
                dx3.Text = "";
            }

        }
        private void dx3_TextChanged(object sender, EventArgs e)
        {


            if (dx3.Text != "")
            {
                predx4btn.Enabled = true;
                predx4btn.BackColor = Color.CornflowerBlue;

                dx4.Enabled = true;
                cd4.Enabled = true;
            }
            else
            {
                predx4btn.BackColor = Color.Gainsboro;

                predx4btn.Enabled = false;
                dx4.Enabled = false;
                cd4.Enabled = false;
                cd4.Text = "";
                dx4.Text = "";
            }

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        private void defaultButton()
        {
            predx2btn.BackColor = Color.Gainsboro;
            predx3btn.BackColor = Color.Gainsboro;
            predx4btn.BackColor = Color.Gainsboro;


        }
        private void in2btn_Click(object sender, EventArgs e)
        {

            string camera = getcameraData();
            in2.Text = cameraid + "-" + camera;
        }
    }
}
