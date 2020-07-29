

using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Microsoft.VisualBasic;
using System.Drawing.Imaging;
using System.Threading;
using System.IO;
using System.Timers;
using System.IO.Ports;
using System.Media;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using IDMS.DataManage;
using IDMS.Popup;
using IDMS.World;
using Tulpep.NotificationWindow;
using Accord.Video.FFMPEG;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media.Imaging;
using gfoidl.Imaging;

namespace IDMS.Page
{
    public partial class examUC : UserControl
    {
        //old videoPanel = 720; 576 ;

        private static int normalPanelW = 720;
        private static int normalPanelH = 576;
        private static int hdPanelW = 760;
        private static int hdPanelH = 460;
        private static int hdPanelMenu = 240;
        private static int cutRightMenu = 540;
        private static int MarginError = 120;

        private idmsPage idms;
        public static examUC Current;
        public static int vdoindex = 0;
        public static SerialPort comport = new SerialPort();
        public static int vdoCount;
        string proname = "";
        public static int fileCount;
        public static string data_cache;

        AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
        MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db"));
        MySqlDataReader reader;

        string hn;
        string caseid;

        private FilterInfoCollection VideoCaptureDevices;
        private VideoCaptureDevice FinalVideo = null;
        private Bitmap video;
        private VideoFileWriter FileWriter = new VideoFileWriter();
        private SaveFileDialog saveAvi;

        private static bool needSnapshot = false;
        private static bool external = false;
        private static string USB_PATH = "";
        string starttime;

        public examUC(idmsPage mainPage, string hn2, string cid)
        {
            InitializeComponent();
            this.idms = mainPage;
            this.hn = hn2;
            this.caseid = cid;
            starttime = DateTime.Now.ToString("HH:mm");

            comport.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            //**
            btnOpenPort_Click();
            startSendData();

            DataAccess Load = new DataAccess();
            string useCamera = Load.getOption("option_value", "useCamera");
            CheckMode(useCamera);
        }

        public static System.Windows.Forms.Timer aTimer = new System.Windows.Forms.Timer();

        private void triggerShot()
        {
            needSnapshot = true;
        }

        EventHandler eventSwitch;

        public void OnTimedEvent(object source, EventArgs e)
        {
            SendData();
            if (World.Current.Fire)
            {
                triggerShot();
                World.Current.Fire = false;
            }
        }

        public void startSendData()
        {
            aTimer = new System.Windows.Forms.Timer();
            eventSwitch = new EventHandler(OnTimedEvent);
            // aTimer.Tick += new EventHandler(OnTimedEvent);
            aTimer.Tick += eventSwitch;
            // Set the Interval to 5 seconds.
            DataManage.DataAccess Load = new DataManage.DataAccess();
            string data = Load.getusbtext("3", "USB_PATH");
            int x = Int32.Parse(data);
            aTimer.Interval = x;
            aTimer.Enabled = true;
        }

        public void SendData()
        {
            try
            {
                comport.Write("7");
                data_cache = "7";
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void CheckMode(String modeEXAM)
        {
            switch (modeEXAM)
            {
                case "NORMAL":
                    MODE.Text = "Normal MODE";
                    videoPanel.Width = normalPanelW;
                    videoPanel.Height = normalPanelH;
                    hideRightBar.Visible = false;
                    flowLayoutPanel1.Location = new Point(9, 654);
                    panel1.Height = 760;
                    groupBox1.Height = 740;
                    groupBox4.Height = 740;
                    break;
                case "HD":

                    MODE.Text = "Sxga MODE";
                    /*
                    videoPanel.Width = hdPanelW;
                    videoPanel.Height = hdPanelH;
                    hideRightBar.Visible = false;
                    */

                    videoPanel.Width = normalPanelW;
                    videoPanel.Height = normalPanelH;
                    hideRightBar.Visible = false;
                    flowLayoutPanel1.Location = new Point(9, 654);
                    panel1.Height = 760;
                    groupBox1.Height = 740;
                    groupBox4.Height = 740;

                    break;
                case "HD+PREVIEW":
                    MODE.Text = "HD MODE";
                    videoPanel.Width = hdPanelW;
                    //  groupBox1.Width = (hdPanelW - hdPanelMenu)+40;
                    // panel1.Width = (hdPanelW - hdPanelMenu) + 40;
                    //  hideRightBar.Width = 24;
                    videoPanel.Height = hdPanelH;
                    hideRightBar.Visible = true;

                    break;
                default:
                    break;
            }
        }

        private void btnOpenPort_Click()
        {
            getComport();
            bool error = false;
            // Set the port's settings
            comport.BaudRate = 300;
            comport.DataBits = 8;
            comport.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
            comport.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
            //  comport.PortName = "COM3";
            comport.PortName = World.Settings.selectedComPort;
            comport.DtrEnable = true;
            comport.RtsEnable = true;
            try
            {
                // Open the port
                comport.Open();
            }
            catch (UnauthorizedAccessException) { error = true; }
            catch (IOException) { error = true; }
            catch (ArgumentException) { error = true; }

            if (error) MessageBox.Show("Could not open the COM port.  Most likely it is already in use, has been removed, or is unavailable.", "COM Port Unavalible", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!comport.IsOpen) return;
            string data = comport.ReadExisting();

            if (data == data_cache)
            {
                World.Current.Fire = true;
                data_cache = null;

            }
        }

        private void getComport()
        {
            //System.Windows.Forms.MessageBox.Show("test");

            World.Settings.availableComPorts.AddRange(World.Settings.OrderedPortNames());
            if (World.Settings.availableComPorts.Count == 1) { World.Settings.selectedComPort = World.Settings.availableComPorts[0]; }
        }

        private void ExaminationPage_Load(object sender, EventArgs e)
        {

            try
            {
                DataManage.DataAccess Load = new DataManage.DataAccess();

                USB_PATH = Load.getusbtext("1", "USB_PATH");
                if (Load.getusbtext("1", "IS_USE") == "1")
                {

                    if (!Directory.Exists(USB_PATH))
                    { external = false; MessageBox.Show("external storage can't Find ,Data will save only in this computer "); }
                    else
                    { external = true; }

                }
            }
            catch
            {

                MessageBox.Show("external storage can't Find ,Data will save only in this computer ");
            }
            VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            try
            {
                FinalVideo = new VideoCaptureDevice(VideoCaptureDevices[0].MonikerString);




                for (int i = 0; i < FinalVideo.VideoCapabilities.Length; i++)
                {
                    string resolution_size = FinalVideo.VideoCapabilities[i].FrameSize.ToString();
                    //    MessageBox.Show(resolution_size);
                    if ((FinalVideo.VideoCapabilities[i].FrameSize.Width.ToString() == "640") && (FinalVideo.VideoCapabilities[i].FrameSize.Width.ToString() == "480"))
                    {

                        vdoindex = i;

                    }

                }





                FinalVideo.VideoResolution = FinalVideo.VideoCapabilities[vdoindex]; ;





                FinalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
                FinalVideo.Start();



            }
            catch
            {
                MessageBox.Show("camera not found");
                comport.Close();
                //Disconnect();
                idms.ChangePageToCaseTC();
            }






            MySqlConnection conn = new MySqlConnection(dbhelper.CnnVal("db"));
            conn.Open();
            MySqlCommand myCommand = new MySqlCommand("select * from patientdata where hn='" + hn + "'", conn);


            reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                patientHN.Text = (reader["hn"].ToString());
                patientFirstName.Text = (reader["name"].ToString());
                patientLastName.Text = (reader["surname"].ToString());
                patientAge.Text = (reader["age"].ToString());
                sex.Text = (reader["sex"].ToString());

            }
            reader.Close();
            MySqlCommand newCommand = new MySqlCommand("select * from patientcase where caseid='" + caseid + "'", conn);


            reader = newCommand.ExecuteReader();
            while (reader.Read())
            {
                pro.Text = (reader["Procedure"].ToString());

            }

            if (pro.Text.Contains("ERCP") == true)
            {
                ERCP.Checked = true;

                ERCP.Enabled = true;
                //    autoDirectoryImage();

            }

            if (pro.Text.Contains("Colono") == true)
            {
                colono.Checked = true;

                colono.Enabled = true;
                //   autoDirectoryImage();

            }


            if (pro.Text.Contains("EGD") == true)
            {
                egd.Checked = true;
                egd.Enabled = true;
                //  autoDirectoryImage();

            }
            if (pro.Text.Contains("BRONCO") == true)
            {
                BRONCO.Checked = true;
                BRONCO.Enabled = true;
                //    autoDirectoryImage();

            }
            if (pro.Text.Contains("ENT") == true)
            {
                ENT.Checked = true;
                ENT.Enabled = true;
                //    autoDirectoryImage();

            }
        }


        public delegate void CaptureSnapshotManifast(Bitmap image);
        public void UpdateCaptureSnapshotManifast(Bitmap image)
        {
            try
            {
                needSnapshot = false;


                if (MODE.Text == "HD MODE")
                { pictureBox1.Image = noMenuImage(image); }
                else
                {


                    pictureBox1.Image = image;

                }
                pictureBox1.Update();













                string hnID = caseid;
                hnID = specialCharReplace(hnID);
                proname = getProcedureName();
                // if (imgPath.Length <= 0)
                // {
                if (IDMS.World.Settings.savePath == String.Empty)
                {
                    IDMS.World.Settings.savePath = System.IO.Directory.GetCurrentDirectory();
                }
                if (!Directory.Exists(IDMS.World.Settings.savePath + "\\images"))
                    Directory.CreateDirectory(IDMS.World.Settings.savePath + "\\images\\");

                string current_fullpath = String.Format("{0}\\{1}", IDMS.World.Settings.savePath, "\\images");
                if (!Directory.Exists(current_fullpath))
                    Directory.CreateDirectory(current_fullpath);

                string current_fullpath_img = String.Format("{0}\\" + hnID + "\\" + proname + "\\", current_fullpath);
                if (!Directory.Exists(current_fullpath + "\\" + hnID + "\\" + proname + "\\"))
                    Directory.CreateDirectory(current_fullpath + "\\" + hnID + "\\" + proname + "\\");

                fileCount = Directory.GetFiles(current_fullpath_img).Length;
                fileCount += 1;

                string nameCapture = getProcedureName() + fileCount.ToString("D2") + ".jpg";



                if (Directory.Exists(current_fullpath_img))
                {
                    pictureBox1.Image.Save(current_fullpath_img + nameCapture);
                }
                else
                {
                    Directory.CreateDirectory(current_fullpath_img);
                    pictureBox1.Image.Save(current_fullpath_img + nameCapture);

                }



                if (external)

                {
                    if (USB_PATH == String.Empty)
                    {
                        USB_PATH = System.IO.Directory.GetCurrentDirectory();
                    }
                    if (!Directory.Exists(USB_PATH + "\\images"))
                        Directory.CreateDirectory(USB_PATH + "\\images\\");

                    string current_fullpath_local = String.Format("{0}\\{1}", USB_PATH, "\\images");
                    if (!Directory.Exists(current_fullpath_local))
                        Directory.CreateDirectory(current_fullpath_local);

                    string current_fullpath_img_local = String.Format("{0}\\" + hnID + "\\" + proname + "\\", current_fullpath_local);
                    if (!Directory.Exists(current_fullpath_local + "\\" + hnID + "\\" + proname + "\\"))
                        Directory.CreateDirectory(current_fullpath_local + "\\" + hnID + "\\" + proname + "\\");

                    if (Directory.Exists(current_fullpath_img_local))
                    {
                        pictureBox1.Image.Save(current_fullpath_img_local + nameCapture);
                    }
                    else
                    {
                        Directory.CreateDirectory(current_fullpath_img_local);
                        pictureBox1.Image.Save(current_fullpath_img_local + nameCapture);

                    }


                }

                string fn = current_fullpath_img + nameCapture;

                PictureBox pp = new PictureBox();
                pp.Image = Image.FromFile(fn);
                pp.Size = new Size(160, 106);
                pp.SizeMode = PictureBoxSizeMode.StretchImage;
                Label ll = new Label();
                ll.Font = new Font("Arial", 12, FontStyle.Bold);
                ll.Text = getProcedureName() + fileCount.ToString("D2") + ".jpg";
                screenCaptureList.Controls.Add(ll);
                screenCaptureList.Controls.Add(pp);
                screenCaptureList.Controls.SetChildIndex(pp, 0);
                screenCaptureList.Controls.SetChildIndex(ll, 1);






                string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
                string FileName = string.Format("{0}Resources\\001.wav", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));


                // System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"D:\001.wav");
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@FileName);
                player.Play();

                PopupNotifier popup = new PopupNotifier();
                popup.TitleText = "";
                popup.ContentText = ll.Text + " " + "has been capture !";
                popup.Popup();




            }
            catch { }
        }


        void FinalVideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            if (btnStart.Text == "Stop Record")
            {
                video = (Bitmap)eventArgs.Frame.Clone();
                videoPanel.Image = (Bitmap)eventArgs.Frame.Clone();
                //AVIwriter.Quality = 0;
                FileWriter.WriteVideoFrame(video);
                //AVIwriter.AddFrame(video);
                //btnStart.Text = "Record";
            }
            else
            {
                video = (Bitmap)eventArgs.Frame.Clone();
                videoPanel.Image = (Bitmap)eventArgs.Frame.Clone();
            }
            if (needSnapshot)
            {
                this.Invoke(new CaptureSnapshotManifast(UpdateCaptureSnapshotManifast), videoPanel.Image);
            }

        }










        public string getProcedureName()
        {
            string proname = "";
            if (egd.Checked == true) { proname = "EGD"; }
            if (colono.Checked == true) { proname = "COL"; }
            if (ERCP.Checked == true) { proname = "ERCP"; }
            if (BRONCO.Checked == true) { proname = "BRONCO"; }
            if (ENT.Checked == true) { proname = "ENT"; }

            return proname;
        }





        string finishtime;

        private void button1_Click(object sender, EventArgs e)
        {
            idms.ChangePageToCase();
        }
        bool i = true;
        private void pause_Click(object sender, EventArgs e)
        {

        }






        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {

                if (btnStart.Text == "Record")
                {


                    vdoCount += 1;
                    string hnID = caseid;


                    hnID = specialCharReplace(hnID);






                    if (IDMS.World.Settings.savePath == String.Empty) { IDMS.World.Settings.savePath = System.IO.Directory.GetCurrentDirectory(); }



                    if (!Directory.Exists(IDMS.World.Settings.savePath + "\\vdo")) Directory.CreateDirectory(IDMS.World.Settings.savePath + "\\vdo\\");
                    string current_fullpath = String.Format("{0}\\{1}", IDMS.World.Settings.savePath, "vdo");
                    string current_fullpathLocal = String.Format("{0}\\{1}", USB_PATH, "vdo");


                    if (!Directory.Exists(current_fullpath)) Directory.CreateDirectory(current_fullpath);

                    string current_fullpath_video;
                    string current_path_video;
                    if (external)
                    {


                        current_fullpath_video = String.Format("{0}" + "\\" + "{1}" + "\\" + proname + "\\{1}(" + vdoCount.ToString() + ").mp4", current_fullpathLocal, hnID);
                        current_path_video = String.Format("{0}" + "\\" + hnID + "\\" + proname + "\\", current_fullpathLocal);
                        if (!Directory.Exists(current_fullpathLocal + "\\" + hnID + "\\" + proname + "\\")) Directory.CreateDirectory(current_fullpathLocal + "\\" + hnID + "\\" + proname + "\\");




                    }
                    else
                    {

                        current_fullpath_video = String.Format("{0}" + "\\" + "{1}" + "\\" + proname + "\\{1}(" + vdoCount.ToString() + ").mp4", current_fullpath, hnID);
                        current_path_video = String.Format("{0}" + "\\" + hnID + "\\" + proname + "\\", current_fullpath);
                        if (!Directory.Exists(current_fullpath + "\\" + hnID + "\\" + proname + "\\")) Directory.CreateDirectory(current_fullpath + "\\" + hnID + "\\" + proname + "\\");


                    }



                    videoCaptureList.Items.Insert(0, hnID + "(" + vdoCount.ToString() + ")" + ".mp4");


                    int h = FinalVideo.VideoCapabilities[vdoindex].FrameSize.Height;
                    int w = FinalVideo.VideoCapabilities[vdoindex].FrameSize.Width;
                    //  int h = captureDevice.VideoDevice.VideoResolution.FrameSize.Height;
                    //    int w = captureDevice.VideoDevice.VideoResolution.FrameSize.Width;


                    //  int h = 480;
                    //  int w = 640;

                    if (MODE.Text == "HD MODE")
                    {


                        w = FinalVideo.VideoCapabilities[vdoindex].FrameSize.Width - cutRightMenu;


                    };
                    string text = current_fullpath_video;
                    FileWriter.Open(text, w, h, 25, VideoCodec.Default, 5000000);
                    FileWriter.WriteVideoFrame(video);


                    btnStart.Text = "Stop Record";
                    rec.Visible = true;


                }
                else
                {


                    if (btnStart.Text == "Stop Record")
                    {
                        btnStart.Text = "Record";
                        rec.Visible = false;
                        if (FinalVideo == null)
                        { return; }
                        if (FinalVideo.IsRunning)
                        {

                            FileWriter.Close();

                            pictureBox1.Image = null;
                        }
                    }
                    else
                    {
                        this.FinalVideo.Stop();
                        FileWriter.Close();

                        pictureBox1.Image = null;
                    }

                }
            }
            catch
            {



            }
        }

        private void screenShotBtn_Click(object sender, EventArgs e)
        {
            needSnapshot = true;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {


            if (btnStart.Text == "Stop Record")
            {
                btnStart.Text = "Record";
                if (FinalVideo == null)
                { return; }
                if (FinalVideo.IsRunning)
                {

                    FileWriter.Close();

                    pictureBox1.Image = null;
                }
            }
            else
            {
                this.FinalVideo.Stop();
                FileWriter.Close();

                pictureBox1.Image = null;
            }







        }

        public void wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            // Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                // Console.WriteLine("stop wait timer");
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }


        public Bitmap noMenuImage(Image bmp)
        {

            wait(1000);
            //    int cropX = bmp.Width-cutRightMenu+MarginError;
            int cropX = bmp.Width - cutRightMenu;

            Rectangle point = new Rectangle(new Point(0, 0), new Size(cropX, bmp.Height));

            Image img = bmp.Crop(point);
            Bitmap x = (Bitmap)img;

            return x;


        }

        public void Disconnect()
        {
            try
            {



                if (FinalVideo == null)
                { return; }
                if (FinalVideo.IsRunning)
                {
                    this.FinalVideo.Stop();
                    FileWriter.Close();
                }





                IDMS.World.Current.sCount = 0;
                screenShotBtn.Enabled = true;
                btnStart.Enabled = true;

                aTimer.Enabled = false;


                screenShotBtn.Enabled = false;
                comport.Close();


            }
            catch { }
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

        private void btnStop_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you finish the procedure?", "End Procedure", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                try
                {

                    IDMS.World.Current.Rec = false;

                    screenShotBtn.Enabled = true;
                    btnStart.Enabled = true;
                    //  btnStop.Enabled = false;


                    aTimer.Enabled = false;

                    screenShotBtn.Enabled = false;
                    comport.Close();



                    finishtime = DateTime.Now.ToString("HH:mm");

                    string duration = starttime + "-" + finishtime;


                    DataAccess cb = new DataAccess();
                    cb.updatePendingStatus(caseid, duration);



                    aTimer.Tick -= eventSwitch;
                    idms.ChangePageToCase();




                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.ToString());
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



    }
}
