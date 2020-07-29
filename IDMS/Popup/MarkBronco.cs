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
    public partial class MarkBronco : Form
    {
        string part;
        string mtext;
        public Label[] La;

        public MarkBronco(string a, string t1, string t2, string t3, string t4, string t5, string t6, string t7, string t8, string t9, string t10, string t11, string b)
        {
            InitializeComponent();

            mtext = b;
            pic.Image = MakeSquareEndoWay(Image.FromFile(a), 500);
            pic.AllowDrop = true;
            pic.DragDrop += PictureBox_DragDrop;
            pic.DragEnter += PictureBox_DragEnter;
            pic.MouseMove += PictureBox_MouseMove;

            La = new Label[] { label1, label2, label3, label4, label5, label6, label7, label8, label9, label10, label11 };


            //  pic.Image = Image.FromFile(a);

            //  for (int i = 0; i < 5; i++)

            // { label1.Text = t1[i]; }

            label1.Text = t1;
            label2.Text = t2;
            label3.Text = t3;
            label4.Text = t4;
            label5.Text = t5;
            label6.Text = t6;
            label7.Text = t7;
            label8.Text = t8;
            label9.Text = t9;
            label10.Text = t10;
            label11.Text = t11;
          
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
        public string GetMyResult()
        {
            return part;
        }
        public string GetMarkA()
        {
            return label1.Text;
        }

        public string GetMarkB()
        {
            return label2.Text;
        }
        public string GetMarkC()
        {
            return label3.Text;
        }
        public string GetMarkD()
        {
            return label4.Text;
        }
        public string GetMarkE()
        {
            return label5.Text;
        }
        public string GetMarkF()
        {
            return label6.Text;
        }
        public string GetMarkG()
        {
            return label7.Text;
        }
        public string GetMarkH()
        {
            return label8.Text;
        }
        public string GetMarkI()
        {
            return label9.Text;
        }
        public string GetMarkJ()
        {
            return label10.Text;
        }
        public string GetMarkK()
        {
            return label11.Text;
        }
        
        private void setDrag(Label A)
        {
            if (A.Text.Contains(mtext) == true)
            {
                return;
            }
            for (int i = 0; i < 11; i++)
            {
                if (La[i].Text.Contains(mtext) == true)
                {
                    La[i].Text = La[i].Text.Replace(mtext, null);
                }

            }
            if (A == La[0]) { part = "Vocal cord"; }
            if (A == La[1]) { part = "Trachea"; }
            if (A == La[2]) { part = "Carina"; }
            if (A == La[3]) { part = "RUL"; }
            if (A == La[4]) { part = "LUL"; }
            if (A == La[5]) { part = "Right main"; }
            if (A == La[6]) { part = "Left main"; }
            if (A == La[7]) { part = "RML"; }
            if (A == La[8]) { part = "RLL"; }
            if (A == La[9]) { part = "Lingular"; }
            if (A == La[10]) { part = "LLL"; }

            
            A.Text += mtext;
            this.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void Fundus_Click(object sender, EventArgs e)
        {

        }

        private void Vocal_Cord_DragEnter(object sender, DragEventArgs e)
        {
            setDrag(label1);

        }

        private void Trachea_DragEnter(object sender, DragEventArgs e)
        {
            setDrag(label2);
        }

        private void Carina_DragEnter(object sender, DragEventArgs e)
        {
            setDrag(label3);

        }

        private void RUL_DragEnter(object sender, DragEventArgs e)
        {
            setDrag(label4);

        }

        private void LUL_DragEnter(object sender, DragEventArgs e)
        {
            setDrag(label5);

        }

        private void Right_main_DragEnter(object sender, DragEventArgs e)
        {
            setDrag(label6);

        }

        private void Left_Main_DragEnter(object sender, DragEventArgs e)
        {
            setDrag(label7);

        }

        private void RML_DragEnter(object sender, DragEventArgs e)
        {
            setDrag(label8);

        }

        private void RLL_DragEnter(object sender, DragEventArgs e)
        {
            setDrag(label9);

        }

        private void Lingular_DragEnter(object sender, DragEventArgs e)
        {
            setDrag(label10);

        }

        private void LLL_DragEnter(object sender, DragEventArgs e)
        {
            setDrag(label11);

        }
    }
}
