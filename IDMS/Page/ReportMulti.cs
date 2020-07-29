using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using IDMS.DataManage;
using IDMS.ReportContent;

namespace IDMS.Page


{
    public partial class ReportMulti : UserControl
    {
        public static Report reportA;
        public static Report reportB;
        public static Report reportC;
        
        public static string reportAid;
        public static string reportBid;
        public static string reportCid;
        public static string REALID;
        public static int tabcount;

        public ReportMulti(idmsPage mainPage, string hn, string cid,string pro)
        {
            InitializeComponent();
            tabcount = 0;
            string imgFolder;
            REALID = specialCharReplace(cid);
            if (pro.Contains("EGD"))
            {
                imgFolder = IDMS.World.Settings.savePath + "/images/" + cid + "/pictures/" + "EGD" + "/";
                if (!Directory.Exists(imgFolder))
                {
                   // MessageBox.Show(imgFolder + "\r\n has been deleted or no longer exist !");

                }
               // else
             //   {
                    Report egdControl = new Report(mainPage, hn, cid, "EGD");
                    TabPage egdTabPage = new TabPage("EGD");//Create new tabpage
                    egdTabPage.Controls.Add(egdControl);
                    tabControl.TabPages.Add(egdTabPage);
                    reportAid = cid + "EGD";
                    reportA = egdControl;
                    tabcount++;
               // }
            }
            if (pro.Contains("Colono"))
            { imgFolder = IDMS.World.Settings.savePath + "/images/" + cid + "/pictures/" + "COL" + "/";
                if (!Directory.Exists(imgFolder))
                {
                  //  MessageBox.Show(imgFolder + "\r\n has been deleted or no longer exist !");

                }
              //  else
               // {
                    Report ColonoControl = new Report(mainPage, hn, cid, "Colonoscopy");
                    TabPage ColonoTabPage = new TabPage("Colonoscopy");//Create new tabpage
                    ColonoTabPage.Controls.Add(ColonoControl);
                    tabControl.TabPages.Add(ColonoTabPage);
                    reportBid = cid + "COL";
                    reportB = ColonoControl;
                    tabcount++;
             //   }
            }
            if (pro.Contains("ERCP"))
            { imgFolder = IDMS.World.Settings.savePath + "/images/" + cid + "/pictures/" + "ERCP" + "/";
                if (!Directory.Exists(imgFolder))
                {
                  //  MessageBox.Show(imgFolder + "\r\n has been deleted or no longer exist !");

                }
              //  else
              //  {
                    Report ENTControl = new Report(mainPage, hn, cid, "ERCP");
                    TabPage ENTTabPage = new TabPage("ERCP");//Create new tabpage
                    ENTTabPage.Controls.Add(ENTControl);
                    tabControl.TabPages.Add(ENTTabPage);
                    reportCid = cid + "ERCP";
                    reportC = ENTControl;
                    tabcount++;
             //   }
            }
            if(tabcount == 0)
            {
                mainPage.ChangePageToCaseTC();
            }
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


    }
}
