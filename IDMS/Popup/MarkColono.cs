using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDMS.Popup
{
    public partial class MarkColono : Form
    {
        string part;
        string mtext;
        public Label[] La;

        public MarkColono(string a, string t1, string t2, string t3, string t4, string t5, string t6, string t7, string t8, string t9, string b)
        {
            InitializeComponent();

            mtext = b;
            pic.Image = MakeSquareEndoWay(Image.FromFile(a), 500);
            pic.AllowDrop = true;
            pic.DragDrop += PictureBox_DragDrop;
            pic.DragEnter += PictureBox_DragEnter;
            pic.MouseMove += PictureBox_MouseMove;

            La = new Label[] { MarkText1, MarkText2, MarkText3, MarkText4, MarkText5, MarkText6, MarkText7, MarkText8, MarkText9 };


          //  pic.Image = Image.FromFile(a);

            //  for (int i = 0; i < 5; i++)

            // { label1.Text = t1[i]; }

            MarkText1.Text = t1;
            MarkText2.Text = t2;
            MarkText3.Text = t3;
            MarkText4.Text = t4;
            MarkText5.Text = t5;
            MarkText6.Text = t6;
            MarkText7.Text = t7;
            MarkText8.Text = t8;
            MarkText9.Text = t9;
          



        }
        private void PictureBox_DragDrop(object sender, DragEventArgs e)
        {


            var target = (PictureBox)sender;
            if (e.Data.GetDataPresent(typeof(PictureBox)))
            {
                var source = (PictureBox)e.Data.GetData(typeof(PictureBox));


            }

        }


        private void PictureBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }


        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var pb = (PictureBox)sender;
                if (pb.Image != null)
                {
                    pb.DoDragDrop(pb, DragDropEffects.Move);
                }
            }
        }

        string temp;

        public string GetMyResult()
        {
            return part;
        }
        public string GetMarkA()
        {
            return MarkText1.Text;
        }

        public string GetMarkB()
        {
            return MarkText2.Text;
        }
        public string GetMarkC()
        {
            return MarkText3.Text;
        }
        public string GetMarkD()
        {
            return MarkText4.Text;
        }
        public string GetMarkE()
        {
            return MarkText5.Text;
        }
        public string GetMarkF()
        {
            return MarkText6.Text;
        }
        public string GetMarkG()
        {
            return MarkText7.Text;
        }
        public string GetMarkH()
        {
            return MarkText8.Text;
        }
        public string GetMarkI()
        {
            return MarkText9.Text;
        }

        private void MarkText1_DragEnter(object sender, DragEventArgs e)
        {

            setDrag(MarkText1);


        }
        private void MarkText2_DragEnter(object sender, DragEventArgs e)
        {
            setDrag(MarkText2);

        }
        private void MarkText3_DragEnter(object sender, DragEventArgs e)
        {
            setDrag(MarkText3);


        }
        private void MarkText4_DragEnter(object sender, DragEventArgs e)
        {
            setDrag(MarkText4);

        }

        private void MarkText5_DragEnter(object sender, DragEventArgs e)
        {
            setDrag(MarkText5);
        }
        private void MarkText6_DragEnter(object sender, DragEventArgs e)
        {
            setDrag(MarkText6);


        }
        private void MarkText7_DragEnter(object sender, DragEventArgs e)
        {
            setDrag(MarkText7);


        }
        private void MarkText8_DragEnter(object sender, DragEventArgs e)
        {
            setDrag(MarkText8);


        }
        private void MarkText9_DragEnter(object sender, DragEventArgs e)
        {
            setDrag(MarkText9);


        }
       
        private void setDrag(Label A)
        {
            if (A.Text.Contains(mtext) == true)
            {
                return;
            }
            for (int i = 0; i < 9; i++)
            {
                if (La[i].Text.Contains(mtext) == true)
                {
                    La[i].Text = La[i].Text.Replace(mtext, null);
                }

            }
            if (A == La[0]) { part = "Rectum"; }
            if (A == La[1]) { part = "SigmoidColon"; }
            if (A == La[2]) { part = "DescendingColon"; }
            if (A == La[3]) { part = "SplenicFlexure"; }
            if (A == La[4]) { part = "TransverseColon"; }
            if (A == La[5]) { part = "HepaticFlexure"; }
            if (A == La[6]) { part = "AscendingColon"; }
            if (A == La[7]) { part = "Cecum"; }
            if (A == La[8]) { part = "Terminalileum"; }


            A.Text += mtext;
            this.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public Bitmap MakeSquareEndoWay(Image bmp, int size)
        {
            Bitmap s = (Bitmap)bmp;
            Bitmap res = new Bitmap(size, size);
            Graphics g = Graphics.FromImage(res);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, size, size);
            int t = 0, l = 0;
            if (s.Height > s.Width)
                t = (s.Height - s.Width) / 2;
            else
                l = (s.Width - s.Height) / 2;
            g.DrawImage(s, new Rectangle(0, 0, size, size), new Rectangle(l, t, s.Width - l * 2, s.Height - t * 2), GraphicsUnit.Pixel);
            return res;

        }
        private void HepaticFlexure_MouseEnter(object sender, EventArgs e)
        {
          
        }
    }
}
