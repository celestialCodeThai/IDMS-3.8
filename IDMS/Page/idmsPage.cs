using IDMS.Page;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDMS
{
    public partial class idmsPage : Form
    {

        caseUC caseuc;
        regisUC regisuc;
        examUC examuc;

        public static string currentPage = "case";


        public idmsPage()
        {
            InitializeComponent();
            this.Opacity = 0;

            caseuc = new caseUC(this);
            regisuc = new regisUC(this);
            usercontrolPanel.Controls.Add(caseuc);




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






        private void CloseBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit IDMS?",
                               "IDMS",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information) == DialogResult.Yes)
            {


                if (idmsPage.currentPage == "report")
                {

                    Report.savedataExit();
                }
                //Application.Exit();
                foreach (var process in System.Diagnostics.Process.GetProcessesByName("IDMS"))
                {
                    // MessageBox.Show(process.ToString());

                    process.Kill();
                }
            }
        }
        private void IDMS_FormClosing(object sender, FormClosingEventArgs e)
        {/*
            if (MessageBox.Show("Exit IDMS?",
                               "IDMS",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Information) == DialogResult.No)
            {
                e.Cancel = true;
            }
            */
        }

        public void ChangePage()
        {
            if (regisuc != null) { usercontrolPanel.Controls.Remove(regisuc); }
            usercontrolPanel.Controls.Clear();
            regisuc.setTime();
            regisuc.loadTemplate();

            usercontrolPanel.Controls.Add(regisuc);
        }
        public void ChangePageToExam(string caseid, string hn)
        {
            if (examuc != null) { usercontrolPanel.Controls.Remove(examuc); }

            usercontrolPanel.Controls.Clear();
            examuc = new examUC(this, hn, caseid);



            usercontrolPanel.Controls.Add(examuc);


        }
        public void ChangePageToEdit(string caseid, string hn)
        {
            usercontrolPanel.Controls.Clear();
            UserControl edituc = new editUC(this, hn, caseid);

            usercontrolPanel.Controls.Add(edituc);


        }
        public void ChangePageToCaseTC()
        {
            usercontrolPanel.Controls.Clear();
            if (examuc != null)
            {
                examuc.Disconnect();
            }
            usercontrolPanel.Controls.Add(caseuc);

            //  caseuc.searchTime();
            // caseuc.reloadCollection();
        }
        public void ChangePageToCase()
        {

            usercontrolPanel.Controls.Clear();

            if (examuc != null)
            {
                examuc.Disconnect();
            }
            caseuc.searchTime();
            //reloadCollection add new data to regis this make programe slow
            // caseuc.reloadCollection();
            usercontrolPanel.Controls.Add(caseuc);





        }

        public void ChangePageToReport(string hn, string caseid)
        {
            usercontrolPanel.Controls.Clear();
            UserControl report = new Report(this, hn, caseid, "");
            // UserControl report = new ReportMulti(this, hn, caseid);
            usercontrolPanel.Controls.Add(report);
        }
        public void ChangePageToMReport(string hn, string caseid, string pro)
        {
            usercontrolPanel.Controls.Clear();
            UserControl report = new ReportMulti(this, hn, caseid, pro);
            usercontrolPanel.Controls.Add(report);
        }

        private void Logo_Click(object sender, EventArgs e)
        {
            if (idmsPage.currentPage == "report")
            {
                // Report.QuickSave();

                Report.savedata();
                idmsPage.currentPage = "case";

            }
            ChangePageToCase();
        }



        private static async void FadeIn(Form o, int interval = 80)
        {
            //Object is not fully invisible. Fade it in
            while (o.Opacity < 1.0)
            {
                await Task.Delay(interval);
                o.Opacity += 0.05;
            }
            o.Opacity = 1; //make fully visible       
        }
        private void firstPage_Shown(object sender, EventArgs e)
        {
            FadeIn(this, 1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            usercontrolPanel.Controls.Clear();
            UserControl setting = new settingUC();
            //UserControl setting = new settingUC_Tab2();

            usercontrolPanel.Controls.Add(setting);
        }

        private void statmenu_Click(object sender, EventArgs e)
        {
            usercontrolPanel.Controls.Clear();
            UserControl stat = new statUC();
            usercontrolPanel.Controls.Add(stat);
        }

        private void Statistic_Click(object sender, EventArgs e)
        {
            usercontrolPanel.Controls.Clear();
            UserControl stat = new statUC();
            usercontrolPanel.Controls.Add(stat);
        }
    }
}
