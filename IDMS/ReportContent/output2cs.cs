using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IDMS.Page;
using System.Text.RegularExpressions;

namespace IDMS.ReportContent
{
    public partial class output2cs : UserControl
    {

        public PictureBox[] boxes;
        public Label[] cBoxes;
        public TextBox[] mtb;
        public string[] P3,P4,P5,P6;
        string pcase;
        public output2cs(Report a, imageReport b, UserControl c, int page)
        {
            InitializeComponent();
            boxes = new PictureBox[] { pic1, pic2, pic3, pic4, pic5, pic6, pic7, pic8, pic9, pic10, pic11, pic12 };
            cBoxes = new Label[] { c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12 };
            mtb = new TextBox[] { mt1, mt2, mt3, mt4, mt5, mt6, mt7, mt8, mt9, mt10, mt11, mt12 };
            P3 = new string[] { "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD" ,"AE","AF"};
            P4 = new string[] { "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR" };

            P5 = new string[] { "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD" };

            P6 = new string[] { "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN" };



            this.hn.Text = "";
            this.hn.Text = a.patientHN.Text;
            this.name.Text = "";
            this.name.Text = a.infoname.Text;

            this.sex.Text = a.infosex.Text;
            this.age.Text = a.infoage.Text;
            this.regis.Text = a.inforegis.Text;
            this.duration.Text = a.Duration.Text;
            this.pro.Text = a.infopro.Text;

            changeFont(name);
            for (int z = 0; z < 12; z++)
            {
                boxes[z].Visible = false;
                cBoxes[z].Visible = false;
            }
            //  int i = imageReport.imgCount;


            if (pro.Text == "EGD")
            {
                pcase = "EGD";
                //headertxt.Text = "EsophagoGastroDuodenosopy Report";
                header.BackgroundImage = Properties.Resources.EGD_header;
               

            }
            if (pro.Text == "Colonoscopy")
            {
                pcase = "COL"; 
                //headertxt.Text = "Colonoscopy Report"; 
            }
            if (pro.Text == "Enterscopy") { pcase = "ENT"; }
            int i = 0;
            //  int c = b.imgCount;



            for (int e = 0; e < b.imgCount; e++)
            {
                if (b.imgPath[i] != null)
                {
                    if (b.imgPath[i].Contains(pcase) == true)
                    {
                        i++;
                    }
                }

            }

            int j = i;








            if (page == 2)
            {
                if (i >= 21) { j = 20; }
                int x = 8;
                for (int z = 0; z < j - 8; z++)
                {
                    boxes[z].Visible = true;
                    boxes[z].Image = b.boxes[x].Image;
                    cBoxes[z].Text = b.cBoxes[x].Text;
                    cBoxes[z].Visible = true;
                    mtb[z].Visible = true;

                    x++;
                }

            }

            if (page == 3)
            {
                if (i > 31) { j = 32; }
                int x = 20;
                    for (int z = 0; z < j - 20; z++)
                    {
                        boxes[z].Visible = true;
                        boxes[z].Image = b.boxes[x].Image;
                        cBoxes[z].Text = b.cBoxes[x].Text;
                        cBoxes[z].Visible = true;
                        mtb[z].Visible = true;
                        mtb[z].Text = P3[z];

                        x++;
                    }
                


            }
            if (page == 4)
            {
                if (i > 43){ j = 44; }
                int x = 32;
                    for (int z = 0; z < j - 32; z++)
                    {
                        boxes[z].Visible = true;
                        boxes[z].Image = b.boxes[x].Image;
                        cBoxes[z].Text = b.cBoxes[x].Text;
                        cBoxes[z].Visible = true;
                        mtb[z].Visible = true;
                        mtb[z].Text = P4[z];

                        x++;
                    
                }


            }
            if (page == 5)
            {
                if (i > 55) { j = 56; }
               
                    int x = 44;
                    for (int z = 0; z < j - 44; z++)
                    {
                        boxes[z].Visible = true;
                        boxes[z].Image = b.boxes[x].Image;
                        cBoxes[z].Text = b.cBoxes[x].Text;
                        cBoxes[z].Visible = true;
                        mtb[z].Visible = true;
                        mtb[z].Text = P5[z];

                        x++;
                    }
                


            }
            if (page == 6)
            {
                if (i > 56)
                {
                    int x = 56;
                    for (int z = 0; z < i - 56; z++)
                    {
                        boxes[z].Visible = true;
                        boxes[z].Image = b.boxes[x].Image;
                        cBoxes[z].Text = b.cBoxes[x].Text;
                        cBoxes[z].Visible = true;
                        mtb[z].Visible = true;
                        mtb[z].Text = P6[z];

                        x++;
                    }
                }


            }

        }







        private void changeFont(Label text)
        {
            string temp = text.Text.Replace(" ", null);
            temp = temp.Replace(".", null);
            if (Regex.IsMatch(temp, "^[a-zA-Z0-9]*$"))
            {
                text.Font = new Font("Roboto", 11.25f, FontStyle.Regular);
                text.Location = new Point(text.Location.X, text.Location.Y + 2);
            }
            else
            {
                text.Font = new Font("Roboto", 14f, FontStyle.Regular);
            }

        }



















    }
}








               






            
