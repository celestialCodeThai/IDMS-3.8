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
using System.Text.RegularExpressions;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Rectangle = iTextSharp.text.Rectangle;
using Image = System.Drawing.Image;
using Font = iTextSharp.text.Font;
using System.Diagnostics;
using IDMS.Popup;
using System.Threading;

namespace IDMS.Page


{
    public partial class REPORT_2 : UserControl
    {
        IMAGE_REPORT_2 IMAGE_PAGE = new IMAGE_REPORT_2();
        REPORT_CONTROL2 R_PAGE = new REPORT_CONTROL2();
        bool imagepage = true;
        public REPORT_2(idmsPage mainPage)
        {

            InitializeComponent();

            //jhkhk
            imagePanel.Controls.Add(IMAGE_PAGE);

        }
       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (imagepage)
            {
                imagePanel.Controls.Add(R_PAGE);
                
                //pictureBox1.BackgroundImage = IDMS.Properties.Resources.tab_2;

                imagepage = false;
            }
            else
            {

                imagePanel.Controls.Add(IMAGE_PAGE);

                imagepage = true;
              //  pictureBox1.BackgroundImage = IDMS.Properties.Resources.tab_1;

            }
        }

        private void report_Click(object sender, EventArgs e)
        {
            imagePanel.Controls.Clear();
            imagePanel.Controls.Add(R_PAGE);
            report.ForeColor = Color.Black;
            img.ForeColor = Color.Gray;
        }

        private void img_Click(object sender, EventArgs e)
        {
            imagePanel.Controls.Clear();
            imagePanel.Controls.Add(IMAGE_PAGE);

            img.ForeColor = Color.Black;
            report.ForeColor = Color.Gray;
        }
    }
}
