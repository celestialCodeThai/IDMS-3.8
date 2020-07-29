using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDMS.Popup
{
    public partial class ImageEditor_2 : Form
    {
        string outputFileName;
        string outputFileName2;
        string imgname;
        private bool isMoving = false;
        private Point mouseDownPosition = Point.Empty;
        private Point mouseDownPosition2 = Point.Empty;

        private Point mouseMovePosition = Point.Empty;
        private List<Tuple<Point, Point>> lines = new List<Tuple<Point, Point>>();

        public ImageEditor_2(string path)
        {
            InitializeComponent();
            outputFileName = path;
            pic.Image = MakeSquareEndoWay(Image.FromFile(outputFileName), 500);

            outputFileName2 = outputFileName;

        }
        Point textLocation = new Point(-123, -321);
        Point newLocation = new Point(0, 10);
        Point ARROW = Point.Empty;
        readonly Point Invalid = new Point(-123, -321);

        private void cb_ApplyText_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(pic.Image);

            if (LineisClick)
            {

                // Graphics g = Graphics.FromImage(pic.Image);
                Pen p = new Pen(Color.SpringGreen, 10);
                p.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                g.DrawLine(p, mouseDownPosition, mouseMovePosition);
                p.Dispose();
            }
            else
            {
                // Graphics g = Graphics.FromImage(pic.Image);
                g.DrawString(txt.Text,
                    new Font("Tahoma", Convert.ToInt32(25)),
                    new SolidBrush(Color.SpringGreen), textLocation);
                textLocation = Invalid;
            }
            pic.Refresh();
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if ((LineisClick) || (addtextisClick))
            {
                isMoving = true;
                mouseDownPosition = e.Location;
                mouseMovePosition = e.Location;

                FirstClick = true;

                //while (e.Button == MouseButtons.Left) { FirstClick = true; }


            }
        }
        bool FirstClick = true;
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (LineisClick)
            {







                if (isMoving)
                {
                    mouseMovePosition = e.Location;
                    pic.Invalidate();
                }
                else
                {
                    ApplyChange();
                }
            }
            else
            {
                if (!e.Button.HasFlag(MouseButtons.Left)) { return; }
                textLocation = e.Location;
                pic.Invalidate();
            }
        }


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // textLocation.Y = textLocation.Y -40;
            // textLocation.X = textLocation.X - 40;
            if (LineisClick)
            {

                var g = e.Graphics;
                /*
                if (FirstClick)
                {
                    ARROW = new Point(mouseDownPosition.X + 100, mouseDownPosition.Y + 100);
                    Pen p = new Pen(Color.SpringGreen, 10);
                    p.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                    g.DrawLine(p, mouseDownPosition, ARROW);
                    p.Dispose();
                    FirstClick = false;

                }
                */
                if (isMoving)
                {
                    Pen p = new Pen(Color.SpringGreen, 10);
                    p.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                    g.DrawLine(p, mouseDownPosition, mouseMovePosition);
                    p.Dispose();

                }



            }
            else
            {
                if (textLocation != Invalid)
                    e.Graphics.DrawString(txt.Text,
                        new Font("Tahoma", Convert.ToInt32(25)),

                        new SolidBrush(Color.SpringGreen), textLocation);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string procedurename = "";
            if (outputFileName.Contains("EGD")) { procedurename = "EGD"; }
            if (outputFileName.Contains("COL")) { procedurename = "COL"; }
            if (outputFileName.Contains("ENT")) { procedurename = "ENT"; }
            if (outputFileName.Contains("BRONCO")) { procedurename = "BRONCO"; }
            if (outputFileName.Contains("ERCP")) { procedurename = "ERCP"; }

            string savepath = outputFileName.Replace(".jpg", null);
            int count = 1;

            string input = savepath;
            int index = input.IndexOf(procedurename);
            if (index > 0)
                input = input.Substring(0, index);
            input = input + procedurename;
            string[] fileArray = Directory.GetFiles(input, "*.jpg");


            string fileName = savepath.Replace(input, null);
            fileName = fileName.Replace("/", null);


            string path = input + "/";
            index = fileName.IndexOf("MARK");
            if (index > 0)
                fileName = fileName.Substring(0, index);

            foreach (string file in fileArray)
            {
                if (file.Contains(fileName + "MARK") == true)
                {
                    count++;


                }
            }


            outputFileName2 = path + fileName + "MARK" + count.ToString() + ".jpg";
            imgname = fileName + "MARK" + count.ToString() + ".jpg";
            pic.Image.Save(outputFileName2);
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
        public string GetMyResult()
        {
            return outputFileName2;
        }
        public string GetFilename()
        {
            return imgname;
        }
        bool LineisClick = false;
        private void Line_Click(object sender, EventArgs e)
        {
            if (!LineisClick)
            {

                if (addtextisClick)
                {
                    txtP.Visible = false;
                    addtextisClick = false;
                    isMoving = false;
                    txt.Text = "";
                    addtxt.BackColor = Color.MidnightBlue;

                }



                mouseDownPosition = Point.Empty;
                mouseDownPosition2 = Point.Empty;
                mouseMovePosition = Point.Empty;

                LineisClick = true;
                Line.BackColor = Color.SpringGreen;
                //  mouseDownPosition = Point.Empty;
            }
            else
            {
                mouseDownPosition = Point.Empty;
                mouseDownPosition2 = Point.Empty;
                mouseMovePosition = Point.Empty;
                LineisClick = false;
                FirstClick = false;
                Line.BackColor = Color.MidnightBlue;
            }
        }

        private void pic_MouseUp(object sender, MouseEventArgs e)
        {
            if (LineisClick)
            {
                if (isMoving)
                {
                    lines.Add(Tuple.Create(mouseDownPosition, mouseMovePosition));
                }
                isMoving = false;
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            LineisClick = false;
            Line.BackColor = Color.MidnightBlue;
            txtP.Visible = false;
            addtextisClick = false;
            isMoving = false;
            txt.Text = "";
            addtxt.BackColor = Color.MidnightBlue;
            pic.Image = MakeSquareEndoWay(Image.FromFile(outputFileName), 500);

        }

        private void txt_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void txt_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void txtP_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {

                mouseDownPosition2 = e.Location;
            }
        }

        private void txtP_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                txtP.Left = e.X + txtP.Left;
                txtP.Top = e.Y + txtP.Top;
            }

        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            textLocation = mouseDownPosition;

            pic.Invalidate();
        }

        private void pic_Click(object sender, EventArgs e)
        {
            if (addtextisClick)
            {
                txtP.Visible = true;
                txt.Focus();
            }

        }
        bool addtextisClick = false;
        private void addtxt_Click(object sender, EventArgs e)
        {

            if (!addtextisClick)
            {

                addtextisClick = true;
                addtxt.BackColor = Color.SpringGreen;


                if (LineisClick)
                {
                    LineisClick = false;
                    Line.BackColor = Color.MidnightBlue;
                }

            }
            else
            {




                txtP.Visible = false;
                addtextisClick = false;
                isMoving = false;
                txt.Text = "";
                addtxt.BackColor = Color.MidnightBlue;

            }
        }


        private void ApplyChange()
        {
            Graphics g = Graphics.FromImage(pic.Image);

            if (LineisClick)
            {

                // Graphics g = Graphics.FromImage(pic.Image);
                Pen p = new Pen(Color.SpringGreen, 10);
                p.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                g.DrawLine(p, mouseDownPosition, mouseMovePosition);
                p.Dispose();
            }
            else
            {
                // Graphics g = Graphics.FromImage(pic.Image);
                g.DrawString(txt.Text,
                    new Font("Tahoma", Convert.ToInt32(25)),
                    new SolidBrush(Color.SpringGreen), textLocation);
                textLocation = Invalid;
            }
            pic.Refresh();
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //enter key is down

                ApplyChange();
                /*
                txtP.Visible = false;
                addtextisClick = false;
                isMoving = false;
                txt.Text = "";
                addtxt.BackColor = Color.MidnightBlue;
                */


                LineisClick = false;
                Line.BackColor = Color.MidnightBlue;
                txtP.Visible = false;
                addtextisClick = false;
                isMoving = false;
                txt.Text = "";
                addtxt.BackColor = Color.MidnightBlue;





                e.Handled = true;
                e.SuppressKeyPress = true;


                string procedurename = "";
                if (outputFileName.Contains("EGD")) { procedurename = "EGD"; }
                if (outputFileName.Contains("COL")) { procedurename = "COL"; }
                if (outputFileName.Contains("ENT")) { procedurename = "ENT"; }
                string savepath = outputFileName.Replace(".jpg", null);
                int count = 1;

                string input = savepath;
                int index = input.IndexOf(procedurename);
                if (index > 0)
                    input = input.Substring(0, index);
                input = input + procedurename;
                string[] fileArray = Directory.GetFiles(input, "*.jpg");


                string fileName = savepath.Replace(input, null);
                fileName = fileName.Replace("/", null);


                string path = input + "/";
                index = fileName.IndexOf("MARK");
                if (index > 0)
                    fileName = fileName.Substring(0, index);

                foreach (string file in fileArray)
                {
                    if (file.Contains(fileName + "MARK") == true)
                    {
                        count++;


                    }
                }


                outputFileName2 = path + fileName + "MARK" + count.ToString() + ".jpg";
                imgname = fileName + "MARK" + count.ToString() + ".jpg";
                pic.Image.Save(outputFileName2);
                this.Close();

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}