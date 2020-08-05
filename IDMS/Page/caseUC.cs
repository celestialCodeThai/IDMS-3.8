using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using IDMS.DataManage;
using System.Data.SqlClient;
using IDMS.Popup;
using System.Data.SQLite;

namespace IDMS.Page
{
    public partial class caseUC : UserControl
    {
        private idmsPage idms;

        AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
        AutoCompleteStringCollection collectionDate = new AutoCompleteStringCollection();
        AutoCompleteStringCollection collectionDoctor = new AutoCompleteStringCollection();
        MySqlConnection conn = new MySqlConnection(dbhelper.CnnVal("db"));
        MySqlDataReader reader;
        string st;
        string sday;
        DataGridViewButtonColumn btnc = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btnc2 = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btnc3 = new DataGridViewButtonColumn();

        public caseUC(idmsPage mainPage)
        {
            InitializeComponent();
            this.idms = mainPage;
            DateTime today = DateTime.Today;

            sday = today.ToString("dd/MM/yyyy");
            //   help.Text = "Please Enter hn or name";
            dts.CellClick += dts_CellClick;

            btnc.Name = " ";
            btnc.Text = "";
            btnc.UseColumnTextForButtonValue = true;
            btnc.Visible = true;

            btnc.FlatStyle = FlatStyle.Popup;

            btnc2.Name = " ";
            btnc2.Text = "";
            btnc2.UseColumnTextForButtonValue = true;
            btnc2.Visible = true;

            btnc2.FlatStyle = FlatStyle.Popup;

            btnc3.Name = " ";
            btnc3.Text = "";
            btnc3.UseColumnTextForButtonValue = true;
            btnc3.Visible = true;

            btnc3.FlatStyle = FlatStyle.Popup;

            dts.Columns.Add(btnc);
            dts.Columns.Add(btnc2);
            dts.Columns.Add(btnc3);

            searchBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            searchBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            t3txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            t3txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            stall.Checked = true;
            t2.Checked = true;

            searchTime();
            conn.Open();

            reloadCollection();

            loadTotalCase();
        }

        public void reloadCollection()
        {
            string querySelect = "SELECT `hn`, `name`, `surname` FROM patientdata";
            MySql.Data.MySqlClient.MySqlCommand commandSelect = new MySql.Data.MySqlClient.MySqlCommand(querySelect, conn);
            reader = commandSelect.ExecuteReader();
            while (reader.Read())
            {
                string type1 = reader[0].ToString();
                string type2 = reader[1].ToString() + " " + reader[2].ToString();
                // patientH.Items.Add(type); //data inserted in combobox list (dropdownstyle in c# dropdown) so that I can still type
                collection.Add(type1); //data inserted in collection so that it will be autocomplete when you type keywords
                collection.Add(type2);
            }
            reader.Close();

            string querySelect2 = "SELECT `Day` FROM patientcase";

            MySql.Data.MySqlClient.MySqlCommand commandSelect2 = new MySql.Data.MySqlClient.MySqlCommand(querySelect2, conn);
            reader = commandSelect2.ExecuteReader();
            while (reader.Read())
            {
                string type1 = reader[0].ToString();


                collectionDate.Add(type1);

            }
            reader.Close();

            searchBox.AutoCompleteCustomSource = collection;
            t3txt.AutoCompleteCustomSource = collectionDate;

        }

        public void RemoveText(object sender, EventArgs e)
        {
            searchBox.Text = "";
            searchBox.ForeColor = Color.Black;
        }

        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchBox.Text))
                searchBox.Text = "Search case...";
            if (searchBox.Text == "Search case...")
            {
                searchBox.ForeColor = Color.Gray;
            }
            else
            {
                searchBox.ForeColor = Color.Black;
            }
        }

        private System.Data.SQLite.SQLiteConnection sql_con;
        private System.Data.SQLite.SQLiteCommand sql_cmd;
        private System.Data.SQLite.SQLiteDataAdapter DB;
        private System.Data.SQLite.SQLiteDataReader readerOption;

        string caseid;
        string casestatus;
        string casehn;
        string pro;
        private void dts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 0)
            {

                DataGridViewRow row = this.dts.Rows[e.RowIndex];
                caseid = row.Cells["caseid"].Value.ToString();
                casestatus = row.Cells["Status"].Value.ToString();
                casehn = row.Cells["HN#"].Value.ToString();
                if (casestatus == "Done")
                {

                    System.Windows.Forms.MessageBox.Show("This Case is Already Done");
                    return;

                }
                if (casestatus == "Prepare")
                {
                    //   idms.ChangePageToEdit(caseid, casehn);
                    DataAccess DELETE = new DataAccess();
                    DELETE.DeleteRow(caseid);
                    searchTime();
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Can't Remove Case Data After Examination");
                }
            }

            if (e.ColumnIndex == 1)
            {

                DataGridViewRow row = this.dts.Rows[e.RowIndex];
                caseid = row.Cells["caseid"].Value.ToString();
                casestatus = row.Cells["Status"].Value.ToString();
                casehn = row.Cells["HN#"].Value.ToString();
                if (casestatus == "Done")
                {

                    System.Windows.Forms.MessageBox.Show("This Case is Already Done");
                    return;

                }
                if (CheckFreeSpace())
                {
                    //Start top preview popup

                    DataManage.DataAccess Load = new DataManage.DataAccess();
                    string usePreviewPopup = Load.getOption("option_value", "previewPopup");

                    //System.Diagnostics.Debug.WriteLine("usePreviewPopup is " + usePreviewPopup);


                    if (usePreviewPopup == "1")
                    {
                        string buttonValue = getEditPopup(caseid);

                        System.Diagnostics.Debug.WriteLine("buttonValue is " + buttonValue);

                        if (buttonValue == "cancel")
                        {
                            return;
                        }
                    }

                    idms.ChangePageToExam(caseid, casehn);

                    //End top
                }
            }

            if (e.ColumnIndex == 2)
            {

                DataGridViewRow row = this.dts.Rows[e.RowIndex];
                caseid = row.Cells["caseid"].Value.ToString();
                casestatus = row.Cells["Status"].Value.ToString();
                casehn = row.Cells["HN#"].Value.ToString();
                pro = row.Cells["Procedure"].Value.ToString();

                string imgFolder = IDMS.World.Settings.savePath + "/images/" + specialCharReplace(caseid);

                String PROCEDURE = pro;
                if (pro.Contains("Colonoscopy")) { PROCEDURE = "COL"; }
                string imgFolder_oldversion = IDMS.World.Settings.savePath + "/" + specialCharReplace(caseid) + "/pictures/" + PROCEDURE;
                imgFolder_oldversion = imgFolder_oldversion.Replace("idmsCASE", "idmsData");

                //หลังบรรทัดนี้  imgFolder_oldversion  = IDMS.World.Settings.savePath \ specialCharReplace(caseid)           \ pro \pictures\
                //หลังบรรทัดนี้  imgFolder_oldversion  = C:\idmsData                   \HN y2000-DATE 21.07.63-TIME 09.52.01  \EGD  \pictures\

           // C:\idmsData\262003824 - 030863 - 082817\pictures\COL

                if (pro.Contains("/"))
                {
                    imgFolder_oldversion = imgFolder_oldversion.Replace(pro + "/pictures/", "");
                }
                if ((!System.IO.Directory.Exists(imgFolder))&& (System.IO.Directory.Exists(imgFolder_oldversion)))
                {
                    imgFolder = imgFolder_oldversion;
                  
                }
               



                 //   MessageBox.Show(imgFolder_oldversion);
              



                if (casestatus == "Pending")
                {
                    if (!System.IO.Directory.Exists(imgFolder))
                    {
                        string txt = imgFolder + "\r\n can not find ! ";
                        string txt2 = "remove this case?";

                        DialogResult dialogResult = MessageBox.Show(txt, txt2, MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            DataAccess DELETE = new DataAccess();
                            DELETE.DeleteRow(caseid);
                            searchTime();
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            //do something else
                        }

                    }
                    else
                    {

                        if (pro.Contains("/"))
                        {
                            idms.ChangePageToMReport(casehn, caseid, pro);
                        }
                        else
                        {
                            idms.ChangePageToReport(casehn, caseid);
                        }
                    }
                }
                else
                {

                    string name = casehn;
                    if (casestatus == "Done" || casestatus == "Prepare")
                    {
                        if (!System.IO.Directory.Exists(imgFolder))
                        {
                            string txt = imgFolder + "\r\n can not find ! ";
                            string txt2 = "remove this case?";

                            DialogResult dialogResult = MessageBox.Show(txt, txt2, MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                DataAccess DELETE = new DataAccess();
                                DELETE.DeleteRow(caseid);
                                searchTime();
                            }
                            else if (dialogResult == DialogResult.No)
                            {
                                //do something else
                            }

                        }
                        else
                        {
                            if (pro.Contains("/"))
                            {
                                idms.ChangePageToMReport(casehn, caseid, pro);
                            }
                            else
                            {
                                idms.ChangePageToReport(casehn, caseid);
                            }

                        }
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Please Examination First..");
                    }
                }

            }

        }



        string status;
        Image btnimage = (System.Drawing.Bitmap)Properties.Resources.exam_edit1;
        private void dts_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // if (searchtype == true)
            //  {
            if (e.RowIndex < 0)
                return;

            //I supposed your button column is at index 0
            if (e.ColumnIndex == 0)
            {


                DataGridViewRow row = this.dts.Rows[e.RowIndex];

                btnimage = (System.Drawing.Bitmap)Properties.Resources.case_delete;

                e.CellStyle.BackColor = Color.White;
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = btnimage.Width;
                var h = btnimage.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(btnimage, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
            if (e.ColumnIndex == 1)
            {


                DataGridViewRow row = this.dts.Rows[e.RowIndex];


                btnimage = (System.Drawing.Bitmap)Properties.Resources.exam_edit1;

                e.CellStyle.BackColor = Color.White;
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                if (row.Cells["Status"].Value.ToString() == "Prepare")
                {
                    e.CellStyle.BackColor = ColorTranslator.FromHtml("#FFD800");
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                }

                var w = btnimage.Width;
                var h = btnimage.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(btnimage, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
            if (e.ColumnIndex == 2)
            {


                DataGridViewRow row = this.dts.Rows[e.RowIndex];


                btnimage = (System.Drawing.Bitmap)Properties.Resources.report_edit1;

                e.CellStyle.BackColor = Color.White;
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                if (row.Cells["Status"].Value.ToString() == "Pending")
                {
                    e.CellStyle.BackColor = ColorTranslator.FromHtml("#007FFF");
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                }

                if (row.Cells["Status"].Value.ToString() == "Done")
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                }

                var w = btnimage.Width;
                var h = btnimage.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(btnimage, new Rectangle(x, y, w, h));
                e.Handled = true;
            }


            if (e.ColumnIndex == 8)
            {


                DataGridViewRow row = this.dts.Rows[e.RowIndex];

                if (row.Cells["Status"].Value.ToString() == "Prepare")
                {
                    btnimage = (System.Drawing.Bitmap)Properties.Resources.preparebox1;
                }
                if (row.Cells["Status"].Value.ToString() == "Pending")
                {
                    btnimage = (System.Drawing.Bitmap)Properties.Resources.writingbox;
                }
                if (row.Cells["Status"].Value.ToString() == "Done")
                {
                    btnimage = (System.Drawing.Bitmap)Properties.Resources.donebox1;
                }
                e.CellStyle.BackColor = Color.White;
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = btnimage.Width;
                var h = btnimage.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(btnimage, new Rectangle(x, y, w, h));
                e.Handled = true;
            }

        }

        string newstr = "holder";
        string a1;
        string b1;
        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            //  if (searchtype == true)
            //   {
            //  dts.Columns.Remove(btnc);
            // dts.DataSource = null;
            // dts.Rows.Clear();
            if (searchBox.Text.Contains("'"))
            {
                return;

            }
            if (searchBox.Text.Contains('\\'))
            {
                return;

            }
            if (searchBox.Text == "" || searchBox.Text == "Search case...")
            {
                searchTime();
            }
            else
            {

                dts.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
                dts.EnableHeadersVisualStyles = false;
                dts.AllowUserToAddRows = false;

                dts.Columns[0].Width = dts.Width / 20;

                dts.Columns[1].Width = dts.Width / 20;
                dts.Columns[2].Width = dts.Width / 20;
                dts.Columns[3].Width = (dts.Width - dts.Columns[0].Width) / 10;
                dts.Columns[4].Width = (dts.Width - dts.Columns[0].Width) / 5;
                dts.Columns[5].Width = (dts.Width - dts.Columns[0].Width) / 10;
                dts.Columns[6].Width = (dts.Width - dts.Columns[0].Width) / 6;
                dts.Columns[7].Width = (dts.Width - dts.Columns[0].Width) / 6;
                dts.Columns[8].Width = (dts.Width - dts.Columns[0].Width) / 6;
                dts.Columns["caseid"].Visible = false;
                dts.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dts.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (searchBox.Text.Contains(" "))
                {
                    string str = searchBox.Text;
                    newstr = str.Substring(0, str.IndexOf(' '));
                }


                MySqlCommand myCommand = new MySqlCommand("select * from patientdata where hn='" + searchBox.Text + "'OR name='" + newstr + "'", conn);
                // 




                try
                {
                    reader = myCommand.ExecuteReader();
                }
                catch (SqlException)
                {

                }
                while (reader.Read())
                {
                    name.Text = (reader["name"].ToString() + " " + reader["surname"].ToString());
                    b1 = reader["hn"].ToString();
                }
                reader.Close();



                if (stdone.Checked == true)
                {
                    st = " = 'Done";
                }
                else
                {
                    if (stnew.Checked == true)
                    {
                        st = "!= 'Done";


                    }
                }





                string query = "";
                if (stall.Checked == true)
                {

                    //query = "select `hn` as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where hn='" + b1 + "'";
                    query = "select `hn` as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where hn='" + b1 + "'OR Doctor='" + newstr + "'";

                    if (t1.Checked == true)
                    {
                        //query = "select `hn` as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where hn='" + b1 + "'";
                        query = "select `hn` as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where hn='" + b1 + "'OR Doctor='" + newstr + "'";
                    }

                    if (t2.Checked == true)
                    {
                        //query = "select `hn` as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where hn='" + b1 + "' AND Day ='" + sday + "'";
                        query = "select `hn` as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where hn='" + b1 + "' AND Day ='" + sday + "'OR Doctor='" + newstr + "' AND Day ='" + sday + "'";
                    }

                    if (t3.Checked == true)
                    {
                        if (searchBox.Text == "Search case...")
                        {
                            query = "select `hn` as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where Day ='" + t3txt.Text + "'";
                        }
                        else
                        {
                            //query = "select `hn` as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where hn='" + b1 + "' AND Day ='" + t3txt.Text + "'";
                            query = "select `hn` as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where hn='" + b1 + "' AND Day ='" + t3txt.Text + "'OR Doctor='" + newstr + "' AND Day ='" + t3txt.Text + "'";
                        }
                    }
                }

                else
                {
                    if (t1.Checked == true)
                    {
                        query = "select `hn` as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where hn='" + b1 + "' AND status " + st + "'" + "'OR Doctor='" + newstr + "' AND status " + st + "'";

                    }
                    if (t2.Checked == true)
                    {
                        query = "select `hn`as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where hn='" + b1 + "' AND Day ='" + sday + "' AND status " + st + "'OR Doctor='" + newstr + "' AND Day ='" + sday + "' AND status " + st + "'";

                    }
                    if (t3.Checked == true)
                    {
                        if (searchBox.Text == "Search case...")
                        {
                            query = "select `hn` as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where Day ='" + t3txt.Text + "' AND status " + st + "'";

                        }
                        else
                        {
                            query = "select `hn` as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where hn='" + b1 + "' AND Day ='" + t3txt.Text + "' AND status " + st + "'OR Doctor='" + newstr + "' AND Day ='" + t3txt.Text + "' AND status " + st + "'";
                        }
                    }
                }

                query = "select `hn` as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where hn='" + b1 + "'OR Doctor='" + searchBox.Text + "'";
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dts.DataSource = ds.Tables[0];

                }


                reader.Close();


                dts.Sort(dts.Columns["Date"], ListSortDirection.Descending);




                /*
                               int columnIndex = 6;
                                if (dts.Columns[" "] == null)
                                {
                                   dts.Columns.Insert(columnIndex, btnc);

                                }
                */
                //   }



            }




        }

        private void st1_CheckedChanged(object sender, EventArgs e)
        {
            dts.DataSource = null;
            dts.Rows.Clear();
            if (searchBox.Text == "" || searchBox.Text == "Search case...")
            {
                searchTime();
            }
            else

            {


                if (stdone.Checked == true)
                {
                    st = " = 'Done";
                }
                else
                {
                    if (stnew.Checked == true)
                    {
                        st = " = 'Prepare' OR status ='Pending";


                    }
                }




                string query = "select `hn`as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where hn='" + b1 + "' AND status " + st + "'";

                if (t1.Checked == true)
                {
                    query = "select `hn`as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where hn='" + b1 + "' AND status " + st + "'";

                }
                else
                if (t2.Checked == true)
                {
                    query = "select `hn`as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where hn='" + b1 + "' AND Day ='" + sday + "' AND status " + st + "'";


                }
                else
                if (t3.Checked == true)
                {
                    if (searchBox.Text == "Search case...")
                    {
                        query = "select `hn` as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where Day ='" + t3txt.Text + "' AND status " + st + "'";

                    }
                    else
                    {
                        query = "select `hn` as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where hn='" + b1 + "' AND Day ='" + t3txt.Text + "' AND status " + st + "'";
                    }
                }



                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dts.DataSource = ds.Tables[0];

                }

                dts.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
                dts.EnableHeadersVisualStyles = false;
                dts.AllowUserToAddRows = false;

                dts.Columns[0].Width = dts.Width / 20;

                dts.Columns[1].Width = dts.Width / 20;
                dts.Columns[2].Width = dts.Width / 20;
                dts.Columns[3].Width = (dts.Width - dts.Columns[0].Width) / 10;
                dts.Columns[4].Width = (dts.Width - dts.Columns[0].Width) / 5;
                dts.Columns[5].Width = (dts.Width - dts.Columns[0].Width) / 10;
                dts.Columns[6].Width = (dts.Width - dts.Columns[0].Width) / 6;
                dts.Columns[7].Width = (dts.Width - dts.Columns[0].Width) / 6;
                dts.Columns[8].Width = (dts.Width - dts.Columns[0].Width) / 6;
                dts.Columns["caseid"].Visible = false;
                dts.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dts.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dts.Sort(dts.Columns["Date"], ListSortDirection.Descending);

            }










        }










        public void searchTime()
        {


            name.Text = "";

            if (stdone.Checked == true)
            {
                st = " = 'Done";
            }
            else
            {
                if (stnew.Checked == true)
                {
                    st = "!= 'Done";


                }
            }

            string query = "";
            if (stall.Checked == true)
            {
                query = "select `hn` as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase";
                if (t1.Checked == true)
                {
                    query = "select `hn` as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase";
                }
                if (t2.Checked == true)
                {
                    query = "select `hn` as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where Day ='" + sday + "'";

                }
                if (t3.Checked == true)
                {
                    if (searchBox.Text == "Search case...")
                    {
                        query = "select `hn` as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where Day ='" + t3txt.Text + "'";

                    }
                    else
                    {
                        query = "select `hn` as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where hn='" + b1 + "' AND Day ='" + t3txt.Text + "'";
                    }

                }

            }
            else
            {
                if (t1.Checked == true)
                {
                    query = "select `hn` as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where status " + st + "'";
                }

                if (t2.Checked == true)
                {
                    query = "select `hn` as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where status " + st + "' AND Day ='" + sday + "'";
                }

                if (t3.Checked == true)
                {
                    if (searchBox.Text == "Search case...")
                    {
                        query = "select `hn` as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where status " + st + "' AND Day ='" + t3txt.Text + "'";

                    }
                    else
                    {
                        query = "select `hn` as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where hn='" + b1 + "' AND Day ='" + t3txt.Text + "' AND status " + st + "'";
                    }
                }

            }
            try
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dts.DataSource = ds.Tables[0];

                }
            }
            catch
            {
                MessageBox.Show("can not connect database");

                foreach (var process in System.Diagnostics.Process.GetProcessesByName("IDMS"))
                {

                    process.Kill();
                }


            }


            dts.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dts.EnableHeadersVisualStyles = false;
            dts.AllowUserToAddRows = false;

            dts.Columns[0].Width = dts.Width / 20;

            dts.Columns[1].Width = dts.Width / 20;
            dts.Columns[2].Width = dts.Width / 20;
            dts.Columns[3].Width = (dts.Width - dts.Columns[0].Width) / 10;
            dts.Columns[4].Width = (dts.Width - dts.Columns[0].Width) / 5;
            dts.Columns[5].Width = (dts.Width - dts.Columns[0].Width) / 10;
            dts.Columns[6].Width = (dts.Width - dts.Columns[0].Width) / 6;
            dts.Columns[7].Width = (dts.Width - dts.Columns[0].Width) / 6;
            dts.Columns[8].Width = (dts.Width - dts.Columns[0].Width) / 6;
            dts.Columns["caseid"].Visible = false;
            dts.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dts.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            int columnIndex = 8;
            if (dts.Columns[" "] == null)
            {
                dts.Columns.Insert(columnIndex, btnc);

                // dts.Columns.Add(btnc);

            }
            if (dts.Columns[" "] == null)
            {
                dts.Columns.Insert(columnIndex, btnc2);

                // dts.Columns.Add(btnc);

            }
            if (dts.Columns[" "] == null)
            {
                dts.Columns.Insert(columnIndex, btnc3);

                // dts.Columns.Add(btnc);

            }

            dts.Sort(dts.Columns["Date"], ListSortDirection.Descending);

            //dts.Rows.RemoveAt(0);
            //  dts.Rows.RemoveAt(2);


        }

        private void t2_CheckedChanged(object sender, EventArgs e)
        {
            searchBox.Text = "Search case...";


            if (searchBox.Text == "" || searchBox.Text == "Search case...")
            {

                searchTime();
            }
            else
            {








                if (stdone.Checked == true)
                {
                    st = " = 'Done";
                }
                else
                {
                    if (stnew.Checked == true)
                    {
                        st = " = 'Prepare' OR status ='Pending";


                    }
                }

                string query = "select `hn`as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where hn='" + b1 + "' AND status " + st + "'";

                if (t1.Checked == true)
                {
                    query = "select `hn`as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where hn='" + b1 + "' AND status " + st + "'";

                }
                else
                if (t2.Checked == true)
                {
                    query = "select `hn`as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where hn='" + b1 + "' AND Day ='" + sday + "' AND status " + st + "'";


                }
                else
                if (t3.Checked == true)
                {
                    if (searchBox.Text == "Search case...")
                    {
                        query = "select `hn` as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where Day ='" + t3txt.Text + "' AND status " + st + "'";

                    }
                    else
                    {
                        query = "select `hn` as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where hn='" + b1 + "' AND Day ='" + t3txt.Text + "' AND status " + st + "'";
                    }
                }



                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dts.DataSource = ds.Tables[0];


                }

                reader.Close();


                dts.Sort(dts.Columns["Date"], ListSortDirection.Descending);

            }

        }
        public idmsPage MyParent { get; set; }

        private void regisbtn_Click(object sender, EventArgs e)
        {
            idms.ChangePage();
        }

        private void st0_CheckedChanged(object sender, EventArgs e)
        {
            dts.DataSource = null;
            dts.Rows.Clear();
            if (searchBox.Text == "" || searchBox.Text == "Search case...")
            {
                searchTime();
            }
            else
            {
                string query = "select `hn`as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where hn='" + b1 + "'";

                if (t1.Checked == true)
                {
                    query = "select `hn`as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where hn='" + b1 + "'";

                }
                else
                if (t2.Checked == true)
                {
                    query = "select `hn` as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where hn='" + b1 + "' AND Day ='" + sday + "'";

                }
                else
                if (t3.Checked == true)
                {
                    if (searchBox.Text == "Search case...")
                    {
                        query = "select `hn` as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where Day ='" + t3txt.Text + "'";

                    }
                    else
                    {
                        query = "select `hn` as 'HN#',`Patient Name`,`Procedure`,`Date`,`Doctor`,`status` as 'Status',`caseid` from patientcase where hn='" + b1 + "' AND Day ='" + t3txt.Text + "'";
                    }

                }

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dts.DataSource = ds.Tables[0];

                }

                dts.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
                dts.EnableHeadersVisualStyles = false;
                dts.AllowUserToAddRows = false;

                dts.Columns[0].Width = dts.Width / 20;

                dts.Columns[1].Width = dts.Width / 20;
                dts.Columns[2].Width = dts.Width / 20;
                dts.Columns[3].Width = (dts.Width - dts.Columns[0].Width) / 10;
                dts.Columns[4].Width = (dts.Width - dts.Columns[0].Width) / 5;
                dts.Columns[5].Width = (dts.Width - dts.Columns[0].Width) / 10;
                dts.Columns[6].Width = (dts.Width - dts.Columns[0].Width) / 6;
                dts.Columns[7].Width = (dts.Width - dts.Columns[0].Width) / 6;
                dts.Columns[8].Width = (dts.Width - dts.Columns[0].Width) / 6;
                dts.Columns["caseid"].Visible = false;
                dts.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dts.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dts.Sort(dts.Columns["Date"], ListSortDirection.Descending);


            }




        }

        private void t3txt_TextChanged(object sender, EventArgs e)
        {
            searchTime();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Permanent Delete All Data ?", "Delete All Data", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DialogResult dialogResult2 = MessageBox.Show("Are you sure ?", "Delete All Data", MessageBoxButtons.YesNo);

                if (dialogResult2 == DialogResult.Yes)
                {
                    DataAccess data = new DataAccess();
                    data.DeleteAll();
                    //   data.DeleteReportAll();
                    searchTime();
                    MessageBox.Show("Delete Succeeded");
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }

        }

        private void caseUC_Load(object sender, EventArgs e)
        {

        }
        public bool CheckFreeSpace()
        {
            var drives = System.IO.DriveInfo.GetDrives();
            string SPACE = "";
            double freeSpace = -1;
            double formatDivideBy = 1;
            foreach (System.IO.DriveInfo info in drives)
            {
                string str = IDMS.World.Settings.savePath.Substring(0, 2) + "\\";
                if (info.Name == str)
                {
                    // SPACE = (info.TotalFreeSpace/ 1024.0).ToString();
                    long freeSpaceNative = info.AvailableFreeSpace;
                    formatDivideBy = Math.Pow(1024, (int)3);

                    freeSpace = freeSpaceNative / formatDivideBy;
                    freeSpace = Math.Round(freeSpace, 2, MidpointRounding.ToEven);

                }
            }
            if (freeSpace < 1.00)
            {
                MessageBox.Show("Low Memory Please Clear Space Before Proceeding");

                return false;
            }
            return true;
        }
        public String specialCharReplace(String hn)
        {
            String hid = hn;

            string[] regEx = { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "+", "=", "|", "\\", "[", "]", "{", "}", "/", "'" };

            for (int i = 0; i < regEx.Length; i++)
            {
                if (hid.Contains(regEx[i])) { hid = hid.Replace(regEx[i], "_"); }
            }

            //if (hid.Contains("'")) { hid = hid.Replace("'", "_"); }
            //if (hid.Contains('\\')) { hid = hid.Replace('\\', '_'); }
            //if (hid.Contains('/')) { hid = hid.Replace('/', '_'); }

            return hid;
        }

        private string getEditPopup(string caseid)
        {
            string actionButtonValue;
            using (previewPopup formOptions = new previewPopup(caseid))
            {
                formOptions.ShowDialog();
                actionButtonValue = formOptions.GetMyResult();
            }
            return actionButtonValue;
        }

        private void loadTotalCase()
        {
            string query = "SELECT COUNT(caseid) FROM `patientcase`";

            MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db"));

            connection.Open();
            MySqlCommand sql_cmd = new MySqlCommand(query, connection);

            int count = Convert.ToInt32(sql_cmd.ExecuteScalar());

            label9.Text = "เคสทั้งหมด " + count.ToString();
         
            connection.Close();
            connection.Dispose();

        }

    }
}







