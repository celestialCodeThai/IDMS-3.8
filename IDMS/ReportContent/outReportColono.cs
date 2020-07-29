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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Runtime.InteropServices;
using IDMS.Page;
namespace IDMS.ReportContent
{

    public partial class outReportColono : Form
    {
        //  hdOutput zoutput;
        output zoutput;
        output2cs output2;
        cOutput coutput;
        string filename;
        string cid;
        Report o1;
        imageReport o2;
        public outReportColono(Report a, imageReport b, reportControlColono c)
        {
            InitializeComponent();

              
                    coutput = new cOutput(a, b, c);
                    mainPanel.Controls.Add(coutput);
                
               



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
            changeToPage2();

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
            mainPanel.AutoScrollPosition = new Point(0, 0);

            string outputFileName = @"D:/myimage1.bmp";
            string outputFileName2 = @"D:/myimage2.bmp";
            //zoutput.zoom();
            changeToPage1();




            mainPanel.AutoScrollPosition = new Point(0, 0);
            // wait(10000); //wait one second

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

            //  Clipboard.SetImage(bm);
            if (o2.pic9.Enabled == true)
            {
                changeToPage2();
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


            //   mainPanel.AutoSize = false;
            /*
            PdfDocument doc = new PdfDocument();
              doc.Pages.Add(new PdfPage());
              XGraphics xgr = XGraphics.FromPdfPage(doc.Pages[0]);


            XImage img = Image.FromFile(@"D:/01.png");


            xgr.DrawImage(img, 0, 0);



            */
            //  imgFolder = Demo2._0.World.Settings.savePath + "/" + caseid + "/pictures/";


            Document doc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            string filesave = IDMS.World.Settings.savePath + "/" + cid + "/" + filename + ".pdf";
            PdfWriter.GetInstance(doc, new FileStream(filesave, FileMode.Create));
            doc.Open();
            iTextSharp.text.Image img2 = iTextSharp.text.Image.GetInstance(outputFileName);
            img2.SetAbsolutePosition(0, 0);
            img2.ScaleAbsoluteHeight(doc.PageSize.Height);
            img2.ScaleAbsoluteWidth(doc.PageSize.Width);
            //  img2.ScaleToFit(width, height);
            doc.Add(img2);
            if (o2.pic9.Enabled == true)
            {
                doc.NewPage();
                iTextSharp.text.Image img3 = iTextSharp.text.Image.GetInstance(outputFileName2);
                img3.SetAbsolutePosition(0, 0);
                img3.ScaleAbsoluteHeight(doc.PageSize.Height);
                img3.ScaleAbsoluteWidth(doc.PageSize.Width);


                doc.Add(img3);
            }
            doc.Close();

            /* -----
             doc.Pages.Add();

             mainPanel.AutoScrollPosition = new Point(0, 1500);
             mainPanel.AutoSize = true;
             mainPanel.DrawToBitmap(bm, new Rectangle(0, 0, width, height));
             XGraphics xgr2 = XGraphics.FromPdfPage(doc.Pages[1]);
             XImage img2 = bm;
              xgr2.DrawImage(img2, 0, 0);
            */

            //    string filesave = "D:/myimage.pdf";

            //    doc.Save(filesave);
            changeToPage1();

            System.Diagnostics.Process.Start(filesave);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            changeToPage1();
        }
        private void changeToPage1()
        {
            if (o2.pic9.Enabled == true)
            {
                mainPanel.Controls.Clear();
                //  zoutput = new output(o1, o2, o3);

                mainPanel.Controls.Add(zoutput);

            }
        }
        private void changeToPage2()
        {
            if (o2.pic9.Enabled == true)
            {
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(output2);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainPanel.AutoScrollPosition = new Point(0, 0);
        }
        public void wait(int min)
        {
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            if (min == 0 || min < 0) return;
            //Console.WriteLine("start wait timer");
            timer1.Interval = min;
            timer1.Enabled = true;
            timer1.Start();
            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                //Console.WriteLine("stop wait timer");
            };
            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }
    }
}
