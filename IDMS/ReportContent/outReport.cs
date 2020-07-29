using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emxx;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Runtime.InteropServices;
using IDMS.Page;
using IDMS.DataManage;
using MySql.Data.MySqlClient;

namespace IDMS.ReportContent
{

    public partial class outReport : Form
    {
        //  hdOutput zoutput;
        output zoutput;
        UserControl output2;
        UserControl output3;
        UserControl output4;
        UserControl output5;
        UserControl output6;
        int currentPage = 1;
        cOutput coutput;
        string filename;
        string cid;
        Report o1;
        string MODE;
        bool page2 = false;
        bool page3 = false;
        bool page4 = false;
        bool page5 = false;
        bool page6 = false;
        string infoname;
        string caseid;
        Report Multisave;
        public outReport(Report a, imageReport b, UserControl c)
        {
            InitializeComponent();

            Multisave = a;
            caseid = a.caseid;
            if (a.casepro == "")
            {
                MODE = a.infopro.Text;
            }
            else
            {
                MODE = a.casepro;
            }

            if (b.pic9.Enabled == true)
            {
                page2 = true;
            }
            if (b.pic21.Enabled == true)
            {
                page3 = true;
            }
            if (b.pic33.Enabled == true)
            {
                page4 = true;
            }
            if (b.pic45.Enabled == true)
            {
                page5 = true;
            }
            if (b.pic57.Enabled == true)
            {
                page6 = true;
            }
            if (MODE == "EGD")
            {
                reportControlEGD temp = (reportControlEGD)c;
                zoutput = new output();
                mainPanel.Controls.Add(zoutput);

                if (page2)
                {
                    output2 = new output2cs(a, b, temp, 2);
                }
                if (page3)
                {
                    output3 = new output2cs(a, b, temp, 3);
                }
                if (page4)
                {
                    output4 = new output2cs(a, b, temp, 4);
                }
                if (page5)
                {
                    output5 = new output2cs(a, b, temp, 5);
                }
                if (page6)
                {
                    output6 = new output2cs(a, b, temp, 6);
                }

            }
            else
            {
                if (MODE == "Colonoscopy")
                {
                    reportControlColono temp = (reportControlColono)c;
                    coutput = new cOutput(a, b, temp);
                    mainPanel.Controls.Add(coutput);
                    if (page2)
                    {
                        output2 = new output2cs(a, b, (UserControl)temp, 2);
                    }
                    if (page3)
                    {
                        output3 = new output2cs(a, b, (UserControl)temp, 3);
                    }
                    if (page4)
                    {
                        output4 = new output2cs(a, b, (UserControl)temp, 4);
                    }
                    if (page5)
                    {
                        output5 = new output2cs(a, b, (UserControl)temp, 5);
                    }
                    if (page6)
                    {
                        output6 = new output2cs(a, b, (UserControl)temp, 6);
                    }
                }





            }

            filename = a.patientHN.Text;
            cid = a.caseid;
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
                System.Drawing.Rectangle rct = DisplayRectangle;
                if (rct.Contains(e.Location))
                {
                    ReleaseCapture();
                    SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
        }







        private void Next_Click(object sender, EventArgs e)
        {
            changeToNextPage();

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                System.Drawing.Rectangle rct = DisplayRectangle;
                if (rct.Contains(e.Location))
                {
                    ReleaseCapture();
                    SendMessage(mainPanel.Parent.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
        }

        private void menuPanel_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                System.Drawing.Rectangle rct = DisplayRectangle;
                if (rct.Contains(e.Location))
                {
                    ReleaseCapture();
                    SendMessage(menuPanel.Parent.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            MessageBoxManager.OK = "Save";
            MessageBoxManager.Cancel = "Cancel";
            MessageBoxManager.Register();
            //   MessageBox.Show("This is a message...", "Test", MessageBoxButtons.OK);
            DialogResult dlgResult = MessageBox.Show("Note: this action can not be undone. this will convert the report to PDF which makes the report uneditable.", "Saving PDF", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dlgResult == DialogResult.OK)
            {
                MessageBoxManager.Unregister();







                mainPanel.AutoScrollPosition = new Point(0, 0);
                string outputFileName =  @IDMS.World.Settings.savePath +"/myimage1.bmp";
                string outputFileName2 = @IDMS.World.Settings.savePath +"/myimage2.bmp";
                string outputFileName3 = @IDMS.World.Settings.savePath +"/myimage3.bmp";
                string outputFileName4 = @IDMS.World.Settings.savePath +"/myimage4.bmp";
                string outputFileName5 = @IDMS.World.Settings.savePath +"/myimage5.bmp";
                string outputFileName6 = @IDMS.World.Settings.savePath +"/myimage6.bmp";
                /*
                                if (currentPage == 3)
                                {
                                    changeToPage1();

                                }
                                changeToPage1();
                */
                changetoFirstPage();



                mainPanel.AutoScrollPosition = new Point(0, 0);

                mainPanel.AutoSize = true;

                int width = mainPanel.Size.Width;
                int height = mainPanel.Size.Height;

                Bitmap bm = new Bitmap(width, height);
                mainPanel.DrawToBitmap(bm, new System.Drawing.Rectangle(0, 0, width, height));





                using (MemoryStream memory = new MemoryStream())
                {
                    using (FileStream fs = new FileStream(outputFileName, FileMode.Create, FileAccess.ReadWrite))
                    {
                        bm.Save(memory, ImageFormat.Bmp);
                        Clipboard.SetImage(bm);
                        byte[] bytes = memory.ToArray();
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }
                mainPanel.AutoSize = false;


                if (page2 == true)
                {
                    changeToNextPage();
                    mainPanel.AutoScrollPosition = new Point(0, 0);
                    mainPanel.AutoSize = true;
                    mainPanel.DrawToBitmap(bm, new System.Drawing.Rectangle(0, 0, width, height));




                    using (MemoryStream memory = new MemoryStream())
                    {
                        using (FileStream fs = new FileStream(outputFileName2, FileMode.Create, FileAccess.ReadWrite))
                        {
                            bm.Save(memory, ImageFormat.Bmp);
                            Clipboard.SetImage(bm);
                            byte[] bytes = memory.ToArray();
                            fs.Write(bytes, 0, bytes.Length);
                        }
                    }
                    mainPanel.AutoSize = false;
                }


                if (page3 == true)
                {
                    changeToNextPage();
                    mainPanel.AutoScrollPosition = new Point(0, 0);
                    mainPanel.AutoSize = true;
                    mainPanel.DrawToBitmap(bm, new System.Drawing.Rectangle(0, 0, width, height));




                    using (MemoryStream memory = new MemoryStream())
                    {
                        using (FileStream fs = new FileStream(outputFileName3, FileMode.Create, FileAccess.ReadWrite))
                        {
                            bm.Save(memory, ImageFormat.Bmp);
                            Clipboard.SetImage(bm);
                            byte[] bytes = memory.ToArray();
                            fs.Write(bytes, 0, bytes.Length);
                        }
                    }
                    mainPanel.AutoSize = false;
                }

                if (page4 == true)
                {
                    changeToNextPage();
                    mainPanel.AutoScrollPosition = new Point(0, 0);
                    mainPanel.AutoSize = true;
                    mainPanel.DrawToBitmap(bm, new System.Drawing.Rectangle(0, 0, width, height));




                    using (MemoryStream memory = new MemoryStream())
                    {
                        using (FileStream fs = new FileStream(outputFileName4, FileMode.Create, FileAccess.ReadWrite))
                        {
                            bm.Save(memory, ImageFormat.Bmp);
                            Clipboard.SetImage(bm);
                            byte[] bytes = memory.ToArray();
                            fs.Write(bytes, 0, bytes.Length);
                        }
                    }
                    mainPanel.AutoSize = false;
                }
                if (page5 == true)
                {
                    changeToNextPage();
                    mainPanel.AutoScrollPosition = new Point(0, 0);
                    mainPanel.AutoSize = true;
                    mainPanel.DrawToBitmap(bm, new System.Drawing.Rectangle(0, 0, width, height));




                    using (MemoryStream memory = new MemoryStream())
                    {
                        using (FileStream fs = new FileStream(outputFileName5, FileMode.Create, FileAccess.ReadWrite))
                        {
                            bm.Save(memory, ImageFormat.Bmp);
                            Clipboard.SetImage(bm);
                            byte[] bytes = memory.ToArray();
                            fs.Write(bytes, 0, bytes.Length);
                        }
                    }
                    mainPanel.AutoSize = false;
                }
                if (page6 == true)
                {
                    changeToNextPage();
                    mainPanel.AutoScrollPosition = new Point(0, 0);
                    mainPanel.AutoSize = true;
                    mainPanel.DrawToBitmap(bm, new System.Drawing.Rectangle(0, 0, width, height));




                    using (MemoryStream memory = new MemoryStream())
                    {
                        using (FileStream fs = new FileStream(outputFileName6, FileMode.Create, FileAccess.ReadWrite))
                        {
                            bm.Save(memory, ImageFormat.Bmp);
                            Clipboard.SetImage(bm);
                            byte[] bytes = memory.ToArray();
                            fs.Write(bytes, 0, bytes.Length);
                        }
                    }
                    mainPanel.AutoSize = false;
                }


                string filesave = "";
                Document doc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                if (Multisave.Multimode)
                {
                    filesave = IDMS.World.Settings.savePath + "/" + cid + "/" + filename + MODE + ".pdf";
                }
                else
                {
                    filesave = IDMS.World.Settings.savePath + "/" + cid + "/" + filename + ".pdf";

                }
                try
                {
                    PdfWriter.GetInstance(doc, new FileStream(filesave, FileMode.Create));
                }
                catch (IOException)
                {
                    foreach (Process clsProcess in Process.GetProcesses())
                    {
                        if (clsProcess.ProcessName.Contains(filesave))
                        {

                            clsProcess.Kill();

                        }
                    }

                }
                doc.Open();
                iTextSharp.text.Image pdfpage1 = iTextSharp.text.Image.GetInstance(outputFileName);
                pdfpage1.SetAbsolutePosition(0, 0);
                pdfpage1.ScaleAbsoluteHeight(doc.PageSize.Height);
                pdfpage1.ScaleAbsoluteWidth(doc.PageSize.Width);

                doc.Add(pdfpage1);
                if (page2)
                {
                    doc.NewPage();
                    iTextSharp.text.Image pdfpage2 = iTextSharp.text.Image.GetInstance(outputFileName2);
                    pdfpage2.SetAbsolutePosition(0, 0);
                    pdfpage2.ScaleAbsoluteHeight(doc.PageSize.Height);
                    pdfpage2.ScaleAbsoluteWidth(doc.PageSize.Width);


                    doc.Add(pdfpage2);
                }

                if (page3)
                {
                    doc.NewPage();
                    iTextSharp.text.Image pdfpage3 = iTextSharp.text.Image.GetInstance(outputFileName3);
                    pdfpage3.SetAbsolutePosition(0, 0);
                    pdfpage3.ScaleAbsoluteHeight(doc.PageSize.Height);
                    pdfpage3.ScaleAbsoluteWidth(doc.PageSize.Width);


                    doc.Add(pdfpage3);
                }
                if (page4)
                {
                    doc.NewPage();
                    iTextSharp.text.Image pdfpage4 = iTextSharp.text.Image.GetInstance(outputFileName4);
                    pdfpage4.SetAbsolutePosition(0, 0);
                    pdfpage4.ScaleAbsoluteHeight(doc.PageSize.Height);
                    pdfpage4.ScaleAbsoluteWidth(doc.PageSize.Width);


                    doc.Add(pdfpage4);
                }
                if (page5)
                {
                    doc.NewPage();
                    iTextSharp.text.Image pdfpage5 = iTextSharp.text.Image.GetInstance(outputFileName5);
                    pdfpage5.SetAbsolutePosition(0, 0);
                    pdfpage5.ScaleAbsoluteHeight(doc.PageSize.Height);
                    pdfpage5.ScaleAbsoluteWidth(doc.PageSize.Width);


                    doc.Add(pdfpage5);
                }
                if (page6)
                {
                    doc.NewPage();
                    iTextSharp.text.Image pdfpage6 = iTextSharp.text.Image.GetInstance(outputFileName6);
                    pdfpage6.SetAbsolutePosition(0, 0);
                    pdfpage6.ScaleAbsoluteHeight(doc.PageSize.Height);
                    pdfpage6.ScaleAbsoluteWidth(doc.PageSize.Width);


                    doc.Add(pdfpage6);
                }
                doc.Close();

                changetoFirstPage();

                if (Multisave.Multimode)
                {
                    saveMultiRecord(caseid);

                }
                else
                {
                    DataAccess cb = new DataAccess();
                    cb.updateDoneStatus(caseid);
                }
                System.Diagnostics.Process.Start(filesave);
                System.IO.DirectoryInfo di = new DirectoryInfo(IDMS.World.Settings.savePath + "/");

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
            }
            else if (dlgResult == DialogResult.Cancel)
            {

            }

        }
        public void saveMultiRecord(string caseid)
        {

            string newid = caseid + MODE;

            if (checkDBExist(newid))
            {
                // System.Windows.Forms.MessageBox.Show(checkDBExist(newid).ToString());

                DataAccess cbm = new DataAccess();

                cbm.AddNewCase(newid, Multisave.infoname.Text, Multisave.infohn.Text, MODE, Multisave.infoproroom.Text, Multisave.indication.Text
                        , Multisave.infoinstrument.Text, Multisave.pdx1.Text, Multisave.pdx2.Text, Multisave.pdx3.Text, Multisave.pdx4.Text, Multisave.date, Multisave.day, Multisave.infodoc.Text, Multisave.infoass.Text,
                          Multisave.infosnurse.Text, Multisave.infocnurse.Text, Multisave.anes.Text, "Done","Edit");




                cbm.DeleteRow(caseid);

            }

        }
        public bool checkDBExist(string thishn)
        {
            MySqlDataReader checkreader;

            MySqlConnection Checkcon = new MySqlConnection(dbhelper.CnnVal("db"));
            Checkcon.Open();
            MySqlCommand CheckCommand = new MySqlCommand("select * from patientcase where caseid='" + thishn + "'", Checkcon);
            bool a = true;

            checkreader = CheckCommand.ExecuteReader();

            while (checkreader.Read())
            {
                if (checkreader.HasRows == true)
                {

                    a = false;
                }

            }
            checkreader.Close();
            return a;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            changeToPage1();
        }
        private void changeToPage1()
        {
            /*
            if (page3)
            {
                setscroll();
                if (currentPage == 3)
                {
                    mainPanel.Controls.Clear();

                    mainPanel.Controls.Add(output2);


                    currentPage = 2;
                }
                else
                {
                    setscroll();

                    if (currentPage == 2)
                    {

                        mainPanel.Controls.Clear();
                        if (MODE == "EGD")
                        {
                            mainPanel.Controls.Add(zoutput);
                        }
                        else
                        {
                            if (MODE == "Colonoscopy")
                            {
                                mainPanel.Controls.Add(coutput);
                            }
                        }
                        currentPage = 1;
                    }
                }

            }
            else
            {
                if (page2)
                {
                    setscroll();
                    mainPanel.Controls.Clear();
                    if (MODE == "EGD")
                    {
                        mainPanel.Controls.Add(zoutput);
                    }
                    else
                    {
                        if (MODE == "Colonoscopy")
                        {
                            mainPanel.Controls.Add(coutput);
                        }
                    }

                }
            }
            */


            setscroll();
            if (currentPage == 2)
            {
                mainPanel.Controls.Clear();



                if (MODE == "EGD")
                {
                    mainPanel.Controls.Add(zoutput);
                }
                else
                {
                    if (MODE == "Colonoscopy")
                    {
                        mainPanel.Controls.Add(coutput);
                    }

                }

                    currentPage = 1;
            }
            if (currentPage == 3 && (page2))
            {
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(output2);
                currentPage = 2;
            }
            if (currentPage == 4 && (page3))
            {
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(output3);
                currentPage = 3;
            }
            if (currentPage == 5 && (page4))
            {
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(output4);
                currentPage = 4;
            }
            if (currentPage == 6 && (page5))
            {
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(output5);
                currentPage = 5;
            }

            pagetxt.Text = "Page " + currentPage;









        }
        private void changeToNextPage()
        {
            /*
            if (page3)
            {
                setscroll();
                if (currentPage == 1)
                {
                    mainPanel.Controls.Clear();
                    mainPanel.Controls.Add(output2);
                    currentPage = 2;
                }
                else
                {
                    if (currentPage == 2)
                    {
                        mainPanel.Controls.Clear();
                        mainPanel.Controls.Add(output3);
                        currentPage = 3;
                    }
                }
            }
            else
            {
                setscroll();
                if (page2)
                {
                    mainPanel.Controls.Clear();
                    mainPanel.Controls.Add(output2);

                }
            }
            */

            setscroll();
            if (currentPage == 5 && (page6))
            {
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(output6);
                currentPage = 6;
            }
            if (currentPage == 4 && (page5))
            {
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(output5);
                currentPage = 5;
            }
            if (currentPage == 3 && (page4))
            {
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(output4);
                currentPage = 4;
            }
            if (currentPage == 2 && (page3))
            {
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(output3);
                currentPage = 3;
            }
            if (currentPage == 1 && (page2))
            {
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(output2);
                currentPage = 2;
            }
            pagetxt.Text = "Page " + currentPage;

        }

        private void setscroll()
        {
            mainPanel.AutoScrollPosition = new Point(0, 0);
        }

        private void menuPanel_Paint(object sender, PaintEventArgs e)
        {

        }

       
        public void changetoFirstPage()
        {
            int j = currentPage;
            for (int i = 0; i < j; i++)
            {

                changeToPage1();
            }
        }
    }
}
