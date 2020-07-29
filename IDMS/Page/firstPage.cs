using IDMS.DataManage;
using System;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace IDMS.Page
{
    public partial class firstPage : Form
    {
        //gook
        public firstPage()
        {
            InitializeComponent();
            this.Opacity = 0;
            DataAccess Load = new DataAccess();
            string data = Load.getusbtext("0", "USB_PATH");
            data = Decode(data);
            MAC.Text = data;

            //top
            string mysqlVersion = Load.getOption("option_value", "mysqlVersion");
            string sqliteVersion = Load.getOption("option_value", "sqliteVersion");
            db.Text = "DB "+mysqlVersion;
            dbl.Text = "DBL "+sqliteVersion;
        }

        private void button1_Click(object sender, EventArgs e)
        {


           
            if (LICENSE_VERIFY())
            {
                Form IDMSpage = new idmsPage();
                IDMSpage.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please Contact SEI to Buy License For IDMS");
                Application.Exit();

            }
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
            FadeIn(this, 5);

        }

        public bool LICENSE_VERIFY()
        {
            DataAccess Load = new DataAccess();
            string data = Load.getusbtext("0", "USB_PATH");
            if (data != null && data != "")
            {
                System.Net.NetworkInformation.NetworkInterface[] nics = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();
                String sMacAddress = string.Empty;
                foreach (System.Net.NetworkInformation.NetworkInterface adapter in nics)
                {
                    if (adapter.GetPhysicalAddress().ToString() == MAC.Text) { return true; }
                }
            }
                return false;
            
        }

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
          
        }

        private void admin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
              if(admin.Text == "sei") { admin.BackColor = Color.Navy; admin.Text = ""; admin.ForeColor = Color.White; }



                if ((admin.Text == "idms-active")&&(admin.BackColor == Color.Navy))
                {
                    admin.Visible = false;
                    admin.BackColor = Color.White;
                    admin.ForeColor = Color.Black;
                    admin.Text = "";
                 //   MessageBox.Show("default ip is "+IDMS.World.Settings.mac);



                    string PCID = Encode(GetMACAddress2());
                    DataAccess Save = new DataAccess();
                    Save.AddMac(PCID);

                }
                if ((admin.Text == "idms-drive") && (admin.BackColor == Color.Navy))
                {
                  
                    admin.BackColor = Color.Black;                  
                    admin.Text = "";
                  

                }
                if ((admin.Text == "idms-switch") && (admin.BackColor == Color.Navy))
                {

                    admin.BackColor = Color.Gray;
                    admin.Text = "";


                }
                if ((admin.BackColor == Color.Black)&& (admin.Text != "")&& admin.Text.All(Char.IsLetter))
                {
                    if (admin.Text.Length == 1)
                    {
                        DataAccess Save = new DataAccess();
                        Save.AddDrive(admin.Text.ToUpper() + ":/");
                        admin.Visible = false;
                        admin.BackColor = Color.White;
                        admin.ForeColor = Color.Black;
                        admin.Text = "";
                    }
                    else
                    {
                        if (admin.Text == "current")
                        {
                            DataAccess Load = new DataAccess();
                            string data = Load.getusbtext("2", "USB_PATH");
                            string a = data.Replace(":/", "");
                            admin.Text = a;
                            admin.SelectionStart = admin.Text.Length;

                        }
                       
                    }

                }


                if ((admin.BackColor == Color.Gray) && (admin.Text != ""))
                {
                    if (admin.Text.All(Char.IsDigit))
                    {
                        DataAccess Save = new DataAccess();
                        Save.AddSwitch(admin.Text);
                        admin.Visible = false;
                        admin.BackColor = Color.White;
                        admin.ForeColor = Color.Black;
                        admin.Text = "";
                    }
                    else
                    {
                        if (admin.Text == "speed")
                        {
                            DataAccess Load = new DataAccess();
                            string data = Load.getusbtext("3", "USB_PATH");
                            admin.Text = data;
                            admin.SelectionStart = admin.Text.Length;

                        }

                    }

                }


            }
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string Reverse(string text)
        {
            char[] cArray = text.ToCharArray();
            string reverse = String.Empty;
            for (int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }
            return reverse;
        }
        public string Encode(string text)
        {
           string Encode ;

            Encode = RandomString(2) + Reverse(text) + RandomString(2);
            return Encode;
        }
        public string Decode(string text)
        {
            string Decode;
            string sub = text.Substring(2, text.Length - 2);

            Decode = sub.Substring(0, sub.Length - 2);

            Decode = Reverse(Decode);
            return Decode;
        }
        public static string GetMACAddress2()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    //IPInterfaceProperties properties = adapter.GetIPProperties(); Line is not required
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }

        private void AdminPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (admin.Visible == true)
            {
                admin.Visible = false;
                admin.BackColor = Color.White;
                admin.ForeColor = Color.Black;
                admin.Text = "";
            }
            else
            {
                admin.Visible = true;
            }
        }
    }
}
