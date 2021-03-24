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
using Tulpep.NotificationWindow;
using MySql.Data.MySqlClient;

namespace IDMS.Page
{
    public partial class regisUC : UserControl
    {
        public static regisUC Current;
        private idmsPage idms;

        public static bool camOpen = false;
        public static bool reportOpen = false;
        List<hnData> info = new List<hnData>();
        bool sex = true;
        bool Ptype = false;
        string indi;
        string birth;
        string pro;
        string nt;
        string path;
        string sub;


        public regisUC(idmsPage mainPage)
        {
            Current = this;

            InitializeComponent();

            this.idms = mainPage;
            ClearData();
            path = Application.StartupPath;
            sub = path.Replace("bin", "Jquery");
            sub = sub.Replace("Debug", "index.html");


            jqueryPanel.Url = new Uri(sub);

            setTime();
            adddroplist();
            autoComplete();
            defaultButton();
            loadDataList("doctor");
            loadDataList("nurse");
            loadDataList("anesthesist");
            loadProcedureRoom();
            ClearData();
            loadTemplate();
        }


        public void loadTemplate()
        {
            DataAccess load = new DataAccess();
            string reportTemplate = load.getOption("option_value", "reportType");

            if (reportTemplate == "1")
            {
                groupBox7.Visible = false;
            }
            else
            {
                groupBox7.Visible = true;
            }
        }


        public void lockEdit(bool existHn)
        {
            FirstName.ReadOnly = existHn;
            LastName.ReadOnly = existHn;
        }


        public void ClearData()
        {
            financeValue.Text = "";

            sexMalebutton.BackColor = Color.CornflowerBlue;
            sexMalebutton.ForeColor = Color.White;
            sexFemalebutton.BackColor = Color.Lavender;
            sexFemalebutton.ForeColor = Color.CornflowerBlue;
            sex = true;

            WardButton.BackColor = Color.CornflowerBlue;
            WardButton.ForeColor = Color.White;
            opdButton.BackColor = Color.Lavender;
            opdButton.ForeColor = Color.CornflowerBlue;
            Ptype = false;
            //

            in2.Text = "";
            indi = "";
            birth = "";
            pro = "";
            FirstName.Text = "";
            LastName.Text = "";
            dateBirth.Text = "";
            yearBirth.Text = "";
            monthBirth.Text = "";
            ageText.Text = "";
            procedureRoom.Text = "";
            instruments.Text = "";
            doc1.Text = "";
            doc2.Text = "";
            an.Text = "";
            sn.Text = "";
            nt = "";
            prefix.Text = "";
            hn.Text = "";
            procedure1.Checked = false;
            procedure2.Checked = false;
            pro5.Checked = false;
            pro4.Checked = false;
            bon1.Visible = false;
            bon2.Visible = false;
            bon3.Visible = false;
            procedure3.Checked = false;
            procedure1.Enabled = true;
            procedure2.Enabled = true;
            procedure3.Enabled = true;
            dx1.Text = "";
            dx2.Text = "";
            dx3.Text = "";
            dx4.Text = "";
            cd1.Text = "";
            cd2.Text = "";
            cd3.Text = "";
            cd4.Text = "";
            nationBox.Text = "";
            cn.Text = "";

            path = Application.StartupPath;
            sub = path.Replace("bin", "Jquery");


            sub = sub.Replace("Debug", "index.html");


            jqueryPanel.Url = new Uri(sub);
        }


        string autoFillName;
        string autoFillSName;
        string autoFillsex;
        string autoFillprefix;
        string autoFillAge;
        string autoFillBirth;
        string autoFillNation;
        string autoType;


        public void autoComplete()
        {
            AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();
            hn.AutoCompleteCustomSource = acsc;
            hn.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            hn.AutoCompleteSource = AutoCompleteSource.CustomSource;
            MySqlDataReader Completereader;

            MySqlConnection Completecon = new MySqlConnection(dbhelper.CnnVal("db"));
            Completecon.Open();
            MySqlCommand CompleteCommand = new MySqlCommand("select * from patientdata", Completecon);


            Completereader = CompleteCommand.ExecuteReader();
            if (Completereader.HasRows == true)
            {
                while (Completereader.Read())
                {

                    acsc.Add(Completereader["hn"].ToString());

                }
            }
            Completereader.Close();
            Completecon.Close();
        }


        public void autoFill(string thishn)
        {

            MySqlDataReader Fillreader;

            MySqlConnection Fillcon = new MySqlConnection(dbhelper.CnnVal("db"));
            Fillcon.Open();
            MySqlCommand FillCommand = new MySqlCommand("select * from patientdata where hn='" + thishn + "'", Fillcon);

            Fillreader = FillCommand.ExecuteReader();
            String fullbirthDate = "";
            while (Fillreader.Read())
            {
                if (Fillreader.HasRows == true)
                {
                    FirstName.Text = (Fillreader["name"].ToString());
                    LastName.Text = (Fillreader["surname"].ToString());
                    prefix.Text = (Fillreader["prefix"].ToString());
                    ageText.Text = (Fillreader["age"].ToString());
                    // autoFillsex = (checkreader["sex"].ToString());
                    //autoFillBirth = (checkreader["birthdate"].ToString());
                    fullbirthDate = (Fillreader["birthdate"].ToString());
                    autoType = (Fillreader["type"].ToString());
                    nationBox.Text = (Fillreader["nationality"].ToString());
                }




                //   28 / 8 / 2558
                if (fullbirthDate != "" && fullbirthDate != null)
                {
                    string[] str = fullbirthDate.Split('/');

                    dateBirth.Text = str[0];
                    monthBirth.SelectedIndex = Convert.ToInt32(str[1]);
                    yearBirth.Text = str[2];


                }

                //top
                FirstName.ReadOnly = true;
                LastName.ReadOnly = true;
                prefix.Enabled = false;
                sexMalebutton.Enabled = false;
                sexFemalebutton.Enabled = false;

                FirstName.BackColor = Color.WhiteSmoke;
                LastName.BackColor = Color.WhiteSmoke;
            }

            Fillreader.Close();



        }


        public string existName = "";


        public bool checkDBExist(string thishn)
        {
            MySqlDataReader checkreader;

            MySqlConnection Checkcon = new MySqlConnection(dbhelper.CnnVal("db"));
            Checkcon.Open();
            MySqlCommand CheckCommand = new MySqlCommand("select * from patientdata where hn='" + thishn + "'", Checkcon);
            bool a = true;

            checkreader = CheckCommand.ExecuteReader();

            while (checkreader.Read())
            {
                if (checkreader.HasRows == true)
                {
                    a = false;
                    existName = checkreader["prefix"].ToString() + " " + checkreader["name"].ToString() + " " + checkreader["surname"].ToString();
                }

            }
            checkreader.Close();
            return a;

        }


        public void connectMySQL()
        {
            IDbConnection connection = new System.Data.SqlClient.SqlConnection(dbhelper.CnnVal("db"));



        }


        private bool Drag;
        private int MouseX;
        private int MouseY;


        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;


        private bool m_aeroEnabled;


        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;


        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);
        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]

        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );

        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }


        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();
                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW; return cp;
            }
        }


        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0; DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }


        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 0,
                            rightWidth = 0,
                            topHeight = 0
                        }; DwmExtendFrameIntoClientArea(this.Handle, ref margins);
                    }
                    break;
                default: break;
            }
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT) m.Result = (IntPtr)HTCAPTION;
        }


        private void PanelMove_MouseDown(object sender, MouseEventArgs e)
        {
            Drag = true;
            MouseX = Cursor.Position.X - this.Left;
            MouseY = Cursor.Position.Y - this.Top;
        }


        private void PanelMove_MouseMove(object sender, MouseEventArgs e)
        {
            if (Drag)
            {
                this.Top = Cursor.Position.Y - MouseY;
                this.Left = Cursor.Position.X - MouseX;
            }
        }


        private void PanelMove_MouseUp(object sender, MouseEventArgs e) { Drag = false; }


        private const int HT_CAPTION = 0x2;
        private const int WM_NCLBUTTONDOWN = 0x00A1;
        [DllImport("user32", CharSet = CharSet.Auto)]
        private static extern bool ReleaseCapture();
        [DllImport("user32", CharSet = CharSet.Auto)]
        private static extern int SendMessage(
            IntPtr hwnd,
            int wMsg,
            int wParam,
            int lParam);


        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                Rectangle rct = DisplayRectangle;
                if (rct.Contains(e.Location))
                {
                    ReleaseCapture();
                    SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
        }



        bool checkfield()
        {
            bool checker = true;

            checkhn.Visible = false;
            checkprefix.Visible = false;
            checklastname.Visible = false;
            checkpro.Visible = false;
            checkdoc.Visible = false;
            checknation.Visible = false;
            checkage.Visible = false;


            if (hn.Text == "")
            {
                checkhn.Visible = true;
                checker = false;
            }
            if (prefix.Text == "")
            {
                checkprefix.Visible = true;
                checker = false;
            }
            if (FirstName.Text == "")
            {
                checker = false;
            }
            if (LastName.Text == "")
            {
                checklastname.Visible = true;
                checker = false;
            }
            if (procedure1.Checked == false && procedure2.Checked == false && procedure3.Checked == false && pro4.Checked == false && pro5.Checked == false)
            {

                checkpro.Visible = true;
                checker = false;
            }
            if (doc1.Text == null)
            {
                checkdoc.Visible = true;
                checker = false;
            }
            /*
            if (nationBox.Text == "")
            {
                checknation.Visible = true;
                checker = false;
            }
            */
            if (ageText.Text == "")
            {
                checkage.Visible = true;
                checker = false;
            }

            return checker;
        }


        private void RegisterButton_Click(object sender, EventArgs e)
        {
            pro = "";
            if (checkfield() == false) { return; }

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to add this case?", "Add case", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                if (pro4.Checked == true)
                {
                    pro += "BRONCO";
                }
                else
                {
                    if (procedure1.Checked == true)
                    {
                        pro += "EGD";
                    }
                    if (procedure2.Checked == true)
                    {
                        if (procedure1.Checked == true) { pro += "/"; }
                        if (procedure1.Checked == true || procedure3.Checked == true) { pro += "Colono"; }
                        if (procedure1.Checked == false && procedure3.Checked == false) { pro += "Colonoscopy"; }

                    }
                    if (procedure3.Checked == true)
                    {
                        if (procedure1.Checked == true || procedure2.Checked == true) { pro += "/ERCP"; }
                        else { pro += "ERCP"; }
                    }
                    if (pro5.Checked == true)
                    {
                        pro += "ENT";
                    }

                }

                string dateformat = DateTime.Now.ToString("dd") + "." + DateTime.Now.ToString("MM") + "." + DateTime.Now.ToString("yy");
                string timeformat = DateTime.Now.ToString("HH") + "." + DateTime.Now.ToString("mm") + "." + DateTime.Now.ToString("ss");

                string caseId = "HN " + hn.Text + "-DATE " + dateformat + "-TIME " + timeformat;
                string b = regisDate.Text + "-" + regisTime.Text;
                string regisday = regisDate.Text;
                string pRoom = "";

                pRoom = procedureRoom.Text;
                string inst = instruments.Text;

                if (in2.Text != "")
                {
                    if (inst != "") { inst += "$"; }
                    inst += in2.Text;
                }

                string d1 = doc1.Text;
                string d2 = "";
                d2 = doc2.Text;
                string sc = "";
                sc = sn.Text;
                string ac = "";

                ac = an.Text;

                string cc = "";

                cc = cn.Text;

                indi = getindication();

                if (dateBirth.SelectedItem == null || monthBirth.SelectedItem == null || monthBirth.SelectedItem == null) { birth = ""; }
                else
                {
                    try
                    {
                        int i = monthBirth.SelectedIndex;
                        birth = dateBirth.SelectedItem.ToString() + "/" + i.ToString() + "/" + yearBirth.SelectedItem.ToString();
                    }
                    catch { }
                }

                string pf;

                if (prefix.Text == "")
                {
                    pf = prefix.SelectedItem.ToString();
                }
                else
                {
                    pf = prefix.Text;
                }
                if (nationBox.SelectedItem != null)
                {
                    nt = nationBox.SelectedItem.ToString();
                }

                string w;
                string gender;
                if (Ptype == true)
                {
                    w = "OPD";
                }
                else
                {
                    w = "WARD";
                }

                if (sex == true)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                string predx1 = "";
                if (dx1.Text != "")
                {
                    if (cd1.Text != "")
                    { predx1 += cd1.Text + "-"; }
                    predx1 += dx1.Text;
                }
                string predx2 = "";
                if (dx2.Text != "")
                {
                    if (cd2.Text != "")
                    { predx2 += cd2.Text + "-"; }
                    predx2 += dx2.Text;
                }
                string predx3 = "";
                if (dx3.Text != "")
                {
                    if (cd3.Text != "")
                    { predx3 += cd3.Text + "-"; }
                    predx3 += dx3.Text;

                }
                string predx4 = "";
                if (dx4.Text != "")
                {
                    if (cd4.Text != "")
                    { predx4 += cd4.Text + "-"; }
                    predx4 += dx4.Text;

                }

                DataAccess db = new DataAccess();
                string cname = pf + " " + FirstName.Text + " " + LastName.Text;
                if (checkDBExist(hn.Text))
                {
                    db.InsertData(hn.Text, FirstName.Text, LastName.Text, gender, pf, ageText.Text, birth, nt, w);
                }
                else
                {
                    cname = existName;
                }

                string finance = financeValue.Text;
                string cameraA = instruments.Text;
                string cameraB = in2.Text;



                db.AddNewCase(caseId, cname, hn.Text, pro, pRoom, indi, inst, predx1, predx2, predx3, predx4, b, regisday, d1, d2, sc, cc, ac, "Prepare", finance, w, cameraA, cameraB);



                PopupNotifier popup = new PopupNotifier();
                popup.TitleText = "Successfully registered";
                popup.ContentText = "New case has been added";

                popup.Popup();

                autoComplete();
                idms.ChangePageToCase();
            }
            else if (dialogResult == DialogResult.No)
            {

            }


        }


        private void sexFemalebutton_Click(object sender, EventArgs e)
        {
            sexFemalebutton.BackColor = Color.CornflowerBlue;
            sexFemalebutton.ForeColor = Color.White;

            sexMalebutton.BackColor = Color.Lavender;
            sexMalebutton.ForeColor = Color.CornflowerBlue;
            sex = false;
        }


        private void sexMalebutton_Click(object sender, EventArgs e)
        {
            sexMalebutton.BackColor = Color.CornflowerBlue;
            sexMalebutton.ForeColor = Color.White;
            sexFemalebutton.BackColor = Color.Lavender;
            sexFemalebutton.ForeColor = Color.CornflowerBlue;
            sex = true;
        }


        private void opdButton_Click(object sender, EventArgs e)
        {
            opdButton.BackColor = Color.CornflowerBlue;
            opdButton.ForeColor = Color.White;

            WardButton.BackColor = Color.Lavender;
            WardButton.ForeColor = Color.CornflowerBlue;
            Ptype = true;
        }


        private void WardButton_Click(object sender, EventArgs e)
        {
            WardButton.BackColor = Color.CornflowerBlue;
            WardButton.ForeColor = Color.White;
            opdButton.BackColor = Color.Lavender;
            opdButton.ForeColor = Color.CornflowerBlue;
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


        private void button1_Click_1(object sender, EventArgs e)
        {
            string a = hn.Text + "-" + tempdate + "-" + temptime;

        }


        private string getindication()
        {
            string b = "";
            var element = jqueryPanel.Document.GetElementById("jq");
            dynamic dom = element.DomElement;


            int check = 0;
            for (int i = 0; i < 28; i++)
            {
                if (dom.Children[i].selected == true)
                {
                    if (check > 0) { b += ", "; }

                    b += dom.Children[i].InnerText;
                    check++;
                }
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

            string camera = getcameraData();
            if (camera != null)
            {
                instruments.Text = cameraid + "-" + camera;
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            idms.ChangePageToCase();

        }



        private void adddroplist()
        {
            for (int i = 0; i < 100; i++)
            {

                yearBirth.Items.Add((2461 + i).ToString());
            }

        }


        private void yearBirth_SelectedIndexChanged(object sender, EventArgs e)
        {
            string currentyear;
            string currentday;
            int a;
            currentyear = today.ToString("yyyy");
            currentday = yearBirth.SelectedItem.ToString();
            a = Int32.Parse(currentyear) - Int32.Parse(currentday);
            if (a >= 0)
            {
                ageText.Text = a.ToString();
            }


        }


        private void button1_Click_3(object sender, EventArgs e)
        {
            string superdate;
            if (dateBirth.SelectedItem == null || monthBirth.SelectedItem == null || monthBirth.SelectedItem == null) { return; }
            superdate = dateBirth.SelectedItem.ToString() + "/" + monthBirth.SelectedIndex.ToString() + "/" + yearBirth.SelectedItem.ToString();
            MessageBox.Show(superdate);
        }


        private void regisUC_Leave(object sender, EventArgs e)
        {
            ClearData();
            setTime();
        }


        public String specialCharReplace(String hn)
        {
            String hid = hn;

            string[] regEx = { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "+", "=", "|", "\\", "[", "]", "{", "}", "/", "'" };

            for (int i = 0; i < regEx.Length; i++)
            {
                if (hid.Contains(regEx[i])) { hid = hid.Replace(regEx[i], "_"); }
            }
            return hid;
        }


        private void hn_TextChanged(object sender, EventArgs e)
        {
            FirstName.ReadOnly = false;
            LastName.ReadOnly = false;
            prefix.Enabled = true;
            sexMalebutton.Enabled = true;
            sexFemalebutton.Enabled = true;

            FirstName.BackColor = Color.White;
            LastName.BackColor = Color.White;

            if (hn.Text.Contains("'") || hn.Text.Contains('\\') || hn.Text.Contains('/'))
            {
                // hn.Text = hn.Text.Replace("'","");
                // hn.Text = hn.Text.Replace("\\", "");
                //  hn.Text = hn.Text.Replace("/", "");

                //   checkhn.Text = "Can't have \\ , / in hn";
                // checkhn.Visible = true;

            }
            else
            {
                checkhn.Text = "*Please Fill Data";
                checkhn.Visible = false;
            }
        }


        private void hn_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {


                if (hn.Text.Contains("'") || hn.Text.Contains('\\'))
                {
                    return;

                }
                else
                {
                    autoFill(hn.Text);

                }
            }

        }


        private void FirstName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
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

        private void button4_Click(object sender, EventArgs e)
        {
            string a = getindication();
            MessageBox.Show(a);
        }

        private void checknation_Click(object sender, EventArgs e)
        {

        }

        private System.Data.SQLite.SQLiteConnection sql_con;
        private System.Data.SQLite.SQLiteCommand sql_cmd;
        private System.Data.SQLite.SQLiteDataAdapter DB;
        private System.Data.SQLite.SQLiteDataReader reader;


        private void loadProcedureRoom()
        {
            string query = "select * from procedure_room";
            sql_con = new System.Data.SQLite.SQLiteConnection(dbhelper.CnnVal("setting"));
            sql_con.Open();

            DB = new System.Data.SQLite.SQLiteDataAdapter(query, sql_con);
            DataSet ds = new DataSet();
            DB.Fill(ds);

            sql_con.Close();
            sql_con.Dispose();

            procedureRoom.DataSource = ds.Tables[0];
            procedureRoom.DisplayMember = "name";
            procedureRoom.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            procedureRoom.AutoCompleteCustomSource = GetAutoSourceCollectionFromTable(ds.Tables[0]);
            procedureRoom.SelectedIndex = -1;

        }


        private void loadDataList(string table)
        {
            string query = "select * from " + table;
            sql_con = new System.Data.SQLite.SQLiteConnection(dbhelper.CnnVal("setting"));
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
                doc1.DataSource = ds.Tables[0];
                doc1.DisplayMember = "docname";
                doc1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                doc1.AutoCompleteCustomSource = GetAutoSourceCollectionFromTable(ds.Tables[0]);
                doc1.SelectedIndex = -1;

                doc2.DataSource = ds2.Tables[0];
                doc2.DisplayMember = "docname";
                doc2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                doc2.AutoCompleteCustomSource = GetAutoSourceCollectionFromTable(ds2.Tables[0]);
                doc2.SelectedIndex = -1;
            }
            if (table == "nurse")
            {
                sn.DataSource = ds.Tables[0];
                sn.DisplayMember = "nursename";
                sn.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                sn.AutoCompleteCustomSource = GetAutoSourceCollectionFromTable(ds.Tables[0]);
                sn.SelectedIndex = -1;
                cn.DataSource = ds2.Tables[0];
                cn.DisplayMember = "nursename";
                cn.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cn.AutoCompleteCustomSource = GetAutoSourceCollectionFromTable(ds2.Tables[0]);
                cn.SelectedIndex = -1;
            }
            if (table == "anesthesist")
            {
                an.DataSource = ds.Tables[0];
                an.DisplayMember = "anesname";
                an.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                an.AutoCompleteCustomSource = GetAutoSourceCollectionFromTable(ds.Tables[0]);
                an.SelectedIndex = -1;
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



        private void pro4_CheckedChanged(object sender, EventArgs e)
        {
            if (pro4.Checked == true)
            {
                procedure1.Checked = false;
                procedure2.Checked = false;
                procedure3.Checked = false;
                pro5.Checked = false;
                procedure1.Enabled = false;
                procedure2.Enabled = false;
                procedure3.Enabled = false;
                pro5.Enabled = false;
                bon1.Visible = true;
                bon2.Visible = true;
                bon3.Visible = true;

            }
            else
            {
                bon1.Visible = false;
                bon2.Visible = false;
                bon3.Visible = false;
                procedure1.Enabled = true;
                procedure2.Enabled = true;
                procedure3.Enabled = true;
                pro5.Enabled = true;
            }
        }


        private void pro5_CheckedChanged(object sender, EventArgs e)
        {
            if (pro5.Checked == true)
            {
                procedure1.Checked = false;
                procedure2.Checked = false;
                procedure3.Checked = false;
                pro4.Checked = false;
                procedure1.Enabled = false;
                procedure2.Enabled = false;
                procedure3.Enabled = false;
                pro4.Enabled = false;
            }
            else
            {
                procedure1.Enabled = true;
                procedure2.Enabled = true;
                procedure3.Enabled = true;
                pro4.Enabled = true;
            }
        }

        private void st4_Click(object sender, EventArgs e)
        {

        }
    }
}
