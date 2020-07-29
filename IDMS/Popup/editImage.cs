using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDMS.Popup
{
    public partial class editImage : Form
    {
        string outputFileName ;
        string outputFileName2;
        public editImage(string path)
        {
            InitializeComponent();

            outputFileName = path;
            outputFileName2 = IDMS.World.Settings.savePath + "/temp.jpg";

            pic.MouseClick += new MouseEventHandler(PicOneFaceUpA_MouseClick);
            pic.Image = Image.FromFile(outputFileName);
        }
        private int X;
        private int Y;
        void PicOneFaceUpA_MouseClick(object sender, MouseEventArgs e)
        {

            // MessageBox.Show(string.Format("X: {0} Y: {1}", X, Y));
/*

            Pen p = new Pen(Brushes.Red, 1.5f);



            p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

    */







            string draw = txt.Text;
            int h = txt.Text.Length + 100;
            int w = 25;
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;
            //  MessageBox.Show(coordinates.X.ToString()+" " + coordinates.Y.ToString());
            Bitmap myBitmap = new Bitmap(outputFileName);
            RectangleF rectf = new RectangleF(coordinates.X, coordinates.Y, h, w); //rectf for My Text
            using (Graphics g = Graphics.FromImage(myBitmap))
            {
                g.DrawRectangle(new Pen(Color.Red, 2), coordinates.X, coordinates.Y, h, w);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Near;
                sf.LineAlignment = StringAlignment.Near;
                g.DrawString(draw, new System.Drawing.Font("Tahoma", 16, FontStyle.Bold), Brushes.White, rectf, sf);
            //    g.DrawLine(p, coordinates.X, coordinates.Y, h, w);
            }




            pic.Image.Dispose();
            pic.Image = null;
            pic.InitialImage = null;
         //   System.IO.File.Delete(outputFileName2);


            myBitmap.Save(outputFileName2);

            pic.Image = Image.FromFile(outputFileName2);




        }
        public string GetMyResult()
        {
            return outputFileName2;
        }
        private void ok_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }
    }

}