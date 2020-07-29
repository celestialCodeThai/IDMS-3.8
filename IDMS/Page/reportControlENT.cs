using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IDMS.Popup;
namespace IDMS.Page
{
    public partial class reportControlENT : UserControl
    {
        public reportControlENT()
        {
            InitializeComponent();

            loadDataList("doctor");
            PP.Text = "ENT";

            this.f8list.MouseUp += new System.Windows.Forms.MouseEventHandler(this.List_RightClick);

            //    this.hislist.MouseUp += new System.Windows.Forms.MouseEventHandler(this.List_RightClick);
            defaultButton();
        }












        private void c4_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void c5_CheckedChanged(object sender, EventArgs e)
        {
            if (c5.Checked)
            {
                c5txt.Visible = true;

            }
            else
            {
                c5txt.Visible = false;
                c5txt.Clear();

            }
        }




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
        string medid;

        private void pdx1btn_Click(object sender, EventArgs e)
        {
            pdxtxt1.Text = getmedData();
            dx1.Text = medid;
        }

        private void pdx2btn_Click(object sender, EventArgs e)
        {
            pdxtxt2.Text = getmedData();
            dx2.Text = medid;
        }

        private void pdx3btn_Click(object sender, EventArgs e)
        {
            pdxtxt3.Text = getmedData();
            dx3.Text = medid;

        }

        private void pdx4btn_Click(object sender, EventArgs e)
        {
            pdxtxt4.Text = getmedData();
            dx4.Text = medid;

        }




        private void f8txt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            multilist(f8txt, f8list);

        }



        private void multilist(TextBox a, ListBox b)
        {
            if (b.Visible == false)
            {
                b.Visible = true;
            }
            else
            {

                a.Text = "";
                int i = 0;
                foreach (int list in b.SelectedIndices)
                {

                    if (i > 0)
                    {
                        a.Text += ", ";
                    }
                    a.Text += b.Items[list].ToString();

                    i++;
                }
                //  b.Visible = false;
                a.SelectionStart = a.Text.Length;


            }

        }





        private void List_RightClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {

                if (sender == f8list)
                {
                    multilist(f8txt, f8list);
                }



            }

        }





        private void setbuttonB(int a0, Button a1, Button a2, Button a3, TextBox b, ListBox c)
        {
            b.Text = "";
            c.ClearSelected();
            switch (a0)
            {
                case 1:
                    a1.BackColor = Color.Black;
                    a2.BackColor = Color.LightGray;
                    a3.BackColor = Color.LightGray;

                    a1.ForeColor = Color.White;
                    a2.ForeColor = Color.Black;
                    a3.ForeColor = Color.Black;

                    a1.FlatAppearance.BorderColor = Color.DimGray;
                    a2.FlatAppearance.BorderColor = Color.Silver;
                    a3.FlatAppearance.BorderColor = Color.Silver;
                    b.Visible = false;
                    //   b.Enabled = false;
                    //  b.Visible = true;
                    c.Visible = false;

                    break;
                case 2:
                    a1.BackColor = Color.LightGray;
                    a2.BackColor = Color.Green;
                    a3.BackColor = Color.LightGray;

                    a1.ForeColor = Color.Black;
                    a2.ForeColor = Color.White;
                    a3.ForeColor = Color.Black;

                    a1.FlatAppearance.BorderColor = Color.Silver;
                    a2.FlatAppearance.BorderColor = Color.DarkGreen;
                    a3.FlatAppearance.BorderColor = Color.Silver;
                    // b.Visible = false;
                    //  b.Enabled = false;
                    b.Visible = true;
                    c.Visible = false;

                    break;
                case 3:
                    a1.BackColor = Color.LightGray;
                    a2.BackColor = Color.LightGray;
                    a3.BackColor = Color.Red;


                    a1.ForeColor = Color.Black;
                    a2.ForeColor = Color.Black;
                    a3.ForeColor = Color.White;

                    a1.FlatAppearance.BorderColor = Color.Silver;
                    a2.FlatAppearance.BorderColor = Color.Silver;
                    a3.FlatAppearance.BorderColor = Color.DarkRed;
                    b.Visible = true;
                    // b.Enabled = true;
                    c.Visible = false;


                    break;
            }

        }



        private void a5txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void pdxtxt1_TextChanged(object sender, EventArgs e)
        {

            if (pdxtxt1.Text != "")
            {
                pdx2btn.BackColor = Color.CornflowerBlue;
                pdx2btn.Enabled = true;
                dx2.Enabled = true;
                pdxtxt2.Enabled = true;
            }
            else
            {


                pdx2btn.Enabled = false;
                pdx2btn.BackColor = Color.Gainsboro;

                dx2.Enabled = false;
                pdxtxt2.Text = "";
                dx2.Text = "";
                pdxtxt2.Enabled = false;
            }

        }
        private void pdxtxt2_TextChanged(object sender, EventArgs e)
        {

            if (pdxtxt2.Text != "")
            {
                pdx3btn.BackColor = Color.CornflowerBlue;

                pdx3btn.Enabled = true;
                dx3.Enabled = true;
                pdxtxt3.Enabled = true;
            }
            else
            {
                pdx3btn.Enabled = false;
                pdx3btn.BackColor = Color.Gainsboro;

                dx3.Enabled = false;
                pdxtxt3.Text = "";
                dx3.Text = "";
                pdxtxt3.Enabled = false;
            }

        }
        private void pdxtxt3_TextChanged(object sender, EventArgs e)
        {

            if (pdxtxt3.Text != "")
            {
                pdx4btn.BackColor = Color.CornflowerBlue;

                pdx4btn.Enabled = true;
                dx4.Enabled = true;
                pdxtxt4.Enabled = true;
            }
            else
            {
                pdx4btn.Enabled = false;
                pdx4btn.BackColor = Color.Gainsboro;

                dx4.Enabled = false;
                pdxtxt4.Text = "";
                dx4.Text = "";
                pdxtxt4.Enabled = false;
            }

        }
        private void defaultButton()
        {
            pdx2btn.BackColor = Color.Gainsboro;
            pdx3btn.BackColor = Color.Gainsboro;
            pdx4btn.BackColor = Color.Gainsboro;


        }








        private void r8_CheckedChanged(object sender, EventArgs e)
        {

            if (r8.Checked)
            {
                r82.Visible = true;

            }
            else
            {
                r82.Visible = false;
                r82.Clear();

            }
        }





        private System.Data.SQLite.SQLiteConnection sql_con;
        private System.Data.SQLite.SQLiteCommand sql_cmd;
        private System.Data.SQLite.SQLiteDataAdapter DB;
        private System.Data.SQLite.SQLiteDataReader reader;
        private void loadDataList(string table)
        {
            string query = "select * from " + table;
            sql_con = new System.Data.SQLite.SQLiteConnection(DataManage.dbhelper.CnnVal("setting"));
            sql_con.Open();
            sql_cmd = new System.Data.SQLite.SQLiteCommand(query, sql_con);
            reader = sql_cmd.ExecuteReader();

            DB = new System.Data.SQLite.SQLiteDataAdapter(query, sql_con);
            DataSet ds = new DataSet();
            DB.Fill(ds);
            DataSet ds2 = new DataSet();
            DB.Fill(ds2);
            reader.Close();
            sql_con.Close();
            sql_con.Dispose();


            if (table == "doctor")
            {
                a5txt.DataSource = ds.Tables[0];
                a5txt.DisplayMember = "docname";
                a5txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                a5txt.AutoCompleteCustomSource = GetAutoSourceCollectionFromTable(ds.Tables[0]);
                a5txt.SelectedIndex = -1;
                a5txt.DataSource = ds2.Tables[0];
                a5txt.DisplayMember = "docname";
                a5txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                a5txt.AutoCompleteCustomSource = GetAutoSourceCollectionFromTable(ds2.Tables[0]);
                a5txt.SelectedIndex = -1;
            }



        }
        private AutoCompleteStringCollection GetAutoSourceCollectionFromTable(DataTable table)
        {
            AutoCompleteStringCollection autoSourceCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in table.Rows)
            {
                autoSourceCollection.Add(row[1].ToString()); //assuming required data is in first column
            }

            return autoSourceCollection;
        }
        public string a5;
        private void a5txt_SelectedIndexChanged(object sender, EventArgs e)
        {
            a5 = a5txt.Text;
        }
        private void med1_CheckedChanged(object sender, EventArgs e)
        {
            if (med1.Checked)
            {
                med1txt.Visible = true;
                med1l.Visible = true;
            }
            else
            {
                med1txt.Visible = false;
                med1l.Visible = false;
                med1txt.Clear();
            }
        }

        private void med2_CheckedChanged(object sender, EventArgs e)
        {
            if (med2.Checked)
            {
                med2txt.Visible = true;
                med2l.Visible = true;
            }
            else
            {
                med2txt.Visible = false;
                med2l.Visible = false;
                med2txt.Clear();

            }
        }

        private void med3_CheckedChanged(object sender, EventArgs e)
        {
            if (med3.Checked)
            {
                med3txt.Visible = true;
                med3l.Visible = true;
            }
            else
            {
                med3txt.Visible = false;
                med3l.Visible = false;
                med3txt.Clear();
            }
        }

        private void med4_CheckedChanged(object sender, EventArgs e)
        {
            if (med4.Checked)
            {
                med4txt.Visible = true;
                med4l.Visible = true;
            }
            else
            {
                med4txt.Visible = false;
                med4l.Visible = false;
                med4txt.Clear();
            }
        }

        private void med5_CheckedChanged(object sender, EventArgs e)
        {
            if (med5.Checked)
            {
                med5txt.Visible = true;
                med5l.Visible = true;
            }
            else
            {
                med5txt.Visible = false;
                med5l.Visible = false;
                med5txt.Clear();
            }
        }

        private void med6_CheckedChanged(object sender, EventArgs e)
        {
            if (med6.Checked)
            {
                med6txt.Visible = true;

            }
            else
            {
                med6txt.Visible = false;

                med6txt.Clear();

            }
        }
        private void med7_CheckedChanged(object sender, EventArgs e)
        {
            if (med7.Checked)
            {
                med7txt.Visible = true;
                med7l.Visible = true;
            }
            else
            {
                med7txt.Visible = false;
                med7l.Visible = false;
                med7txt.Clear();
            }
        }
    }
}
