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
namespace IDMS.ReportContent
{
    public partial class coutput2cs : UserControl
    {

        public PictureBox[] boxes;
        public Label[] cBoxes;


        public coutput2cs(Report a, imageReport b, reportControlColono c)
        {
            InitializeComponent();
            boxes = new PictureBox[] { pic1, pic2, pic3, pic4, pic5, pic6, pic7, pic8, pic9, pic10, pic11, pic12, pic13, pic14, pic15, pic16 };
            cBoxes = new Label[] { c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16 };



            this.hn.Text = "";
            this.hn.Text = a.patientHN.Text;
            this.name.Text = "";
            this.name.Text = a.infoname.Text;

            this.sex.Text = a.infosex.Text;
            this.age.Text = a.infoage.Text;
            this.regis.Text = a.inforegis.Text;
            this.duration.Text = a.Duration.Text;



            for (int z = 0; z < 16; z++)
            {
                boxes[z].Visible = false;
                cBoxes[z].Visible = false;
            }
            int i = b.imgCount;

            int x = 8;

            for (int z = 0; z < i - 8; z++)
            {
                boxes[z].Visible = true;
                boxes[z].Image = b.boxes[x].Image;
                cBoxes[z].Text = b.cBoxes[x].Text;
                cBoxes[z].Visible = true;
                x++;
            }

        }


    }
}
