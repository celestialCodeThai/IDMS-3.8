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
using gfoidl.Imaging;
using IDMS.DataManage;

namespace IDMS.Popup
{
    public partial class ImageEditor : Form
    {
        string outputFileName;
        string outputFileName2;
        string imgname;
        private bool isMoving = false;
        private Point mouseDownPosition = Point.Empty;
        private Point mouseDownPosition2 = Point.Empty;

        private Point mouseMovePosition = Point.Empty;
        private Point mouseMoveCrop = Point.Empty;

        private List<Tuple<Point, Point>> lines = new List<Tuple<Point, Point>>();

        DataAccess load = new DataAccess();

        string editMode = "";
        int defaultH;
        int defaultW;
        static int i = 0;
        //new data
        private Image _originalImage;
        private bool _selecting;
        private Rectangle _selection;
        private Rectangle _selectionDefault;
        bool isEdit = false;

        public ImageEditor(string path, Rectangle defaultPoint)
        {

            InitializeComponent();
            this.pic.MouseWheel += OnMouseWheel;

            outputFileName = path;
            pic.Image = MakeSquareEndoWay(Image.FromFile(outputFileName), 500);

            outputFileName2 = outputFileName;


            string pictureMode = load.getOption("option_value", "pictureMode");
            bool squareMode = pictureMode == "1";



            if (squareMode)
            {
                if (defaultPoint.Width != 0)
                {
                    _selectionDefault = defaultPoint;
                }
                else
                {
                    int t = 0, l = 0;
                    int newW = (pic.Image.Width * 3) / 4;
                    int newH = (pic.Image.Height * 3) / 4;

                    if (newH > newW)
                    {
                        t = (newH - newW) / 2;
                    }
                    else
                    {
                        l = (newW - newH) / 2;
                    }

                    _selectionDefault = new Rectangle(l, t, newW - l * 2, newH - t * 2);
                }
            }
            else
            {
                if (defaultPoint.Width != 0)
                {
                    _selectionDefault = defaultPoint;
                }
                else
                {
                    int newW = (pic.Image.Width * 3) / 4;
                    int newH = (pic.Image.Height * 3) / 4;

                    _selectionDefault = new Rectangle(0, 0, newW, newH);

                }


            }


            drawSquare();

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
            if (editMode == "CROP_2")
            {
                if (e.Button == MouseButtons.Left)
                {
                    // mouseMoveCrop = e.Location;
                    isMoving = true;

                }

            }

            if (editMode == "CROP")
            {
                if (e.Button == MouseButtons.Left)
                {
                    _selecting = true;
                    _selection = new Rectangle(new Point(e.X, e.Y), new Size());
                }

            }

            else
            {

                if ((LineisClick) || (addtextisClick))
                {
                    isMoving = true;
                    mouseDownPosition = e.Location;
                    mouseMovePosition = e.Location;

                    FirstClick = true;
                }
            }
        }
        bool FirstClick = true;

        private void drawSquare()
        {
            modeSwitch("start");
            int t = 0, l = 0;
            if (pic.Height > pic.Width)
            {
                t = (pic.Height - pic.Width) / 2;
            }
            else
            { l = (pic.Width - pic.Height) / 2; }

            if (_selectionDefault.Width == 0)
            {
                _selectionDefault = new Rectangle(new Point(l, t), new Size(pic.Height, pic.Height));
            }
            pic.Refresh();
        }
        Rectangle ImageArea(PictureBox pbox)
        {

            Size si = _selectionDefault.Size;
            Size sp = pbox.Size;
            float ri = 1f * si.Width / si.Height;
            float rp = 1f * sp.Width / sp.Height;
            if (rp > ri)
            {
                int width = si.Width * sp.Height / si.Height;
                int left = (sp.Width - width) / 2;
                return new Rectangle(left, 0, width, sp.Height);
            }
            else
            {
                int height = si.Height * sp.Width / si.Width;
                int top = (sp.Height - height) / 2;
                return new Rectangle(0, top, sp.Width, height);
            }

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (editMode == "CROP_2")
            {


                pic.Cursor = ImageArea(pic).Contains(e.Location) ?
                                                Cursors.Hand : Cursors.Default;

                if (isMoving)
                {/*
                    String directionX = "NON";
                    String directionY = "NON";
                    int range = 4;
                    if (e.X > oldX) { Console.WriteLine("Right"); directionX = "RIGHT"; }
                   else { Console.WriteLine("LEFT"); directionX = "LEFT"; }

                   if (e.Y > oldY) { Console.WriteLine("DOWN"); directionY = "DOWN"; }
                    else { Console.WriteLine("UP"); directionY = "UP"; }

                 

                    if(directionX == "RIGHT") { _selectionDefault.X= _selectionDefault.X+ range; }
                    if (directionX == "LEFT") { _selectionDefault.X= _selectionDefault.X- range; }

                    if (directionY == "DOWN") { _selectionDefault.Y = _selectionDefault.Y + range; }
                    if (directionY == "UP") { _selectionDefault.Y = _selectionDefault.Y - range; }

                */
                    int margin = 0;
                    int xRightBound = pic.Width;
                    int xLeftBound = 0;


                    if (((e.X - (_selectionDefault.Width / 2)) + _selectionDefault.Width <= pic.Width + margin) && (e.X - (_selectionDefault.Width / 2) >= -margin))
                    {

                        _selectionDefault.X = e.X - (_selectionDefault.Width / 2);
                    }
                    else if ((e.X - (_selectionDefault.Width / 2)) + _selectionDefault.Width > pic.Width + margin)
                    {
                        _selectionDefault.X = xRightBound - _selectionDefault.Width;

                    }
                    else if (e.X - (_selectionDefault.Width / 2) < -margin)
                    {
                        _selectionDefault.X = xLeftBound;

                    }


                    if (((e.Y - (_selectionDefault.Height / 2)) + _selectionDefault.Height <= pic.Height + margin) && (e.Y - (_selectionDefault.Height / 2) >= -margin))
                    {
                        _selectionDefault.Y = e.Y - (_selectionDefault.Height / 2);

                    }
                    else if ((e.Y - (_selectionDefault.Height / 2)) + _selectionDefault.Height > pic.Height + margin)
                    {
                        _selectionDefault.Y = pic.Height - _selectionDefault.Height;
                    }
                    else if (e.Y - (_selectionDefault.Height / 2) < -margin)
                    {
                        _selectionDefault.Y = 0;
                    }




                    //oldX = e.X;
                    //oldY = e.Y;
                    //  isMoving = false;
                }
                pic.Cursor = ImageArea(pic).Contains(e.Location) ?
                                            Cursors.Hand : Cursors.Default;
            }
            if (editMode == "CROP")
            {
                if (_selecting)
                {
                    _selection.Width = e.X - _selection.X;
                    _selection.Height = e.Y - _selection.Y;
                    pic.Refresh();
                }
            }
            else
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


        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {


            Pen pCrop = new Pen(Color.SpringGreen, 3);
            e.Graphics.DrawRectangle(pCrop, _selectionDefault);
            if (editMode == "CROP")
            {


                if (_selecting)
                {
                    // Draw a rectangle displaying the current selection
                    Pen pen = Pens.GreenYellow;
                    e.Graphics.DrawRectangle(pen, _selection);
                }
            }
            else
            {
                if (LineisClick)
                {

                    var g = e.Graphics;

                    if (isMoving)
                    {
                        Pen p = new Pen(Color.SpringGreen, 5);
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

            if (isEdit)
            {
                outputFileName2 = path + fileName + "MARK" + count.ToString() + ".jpg";
                imgname = fileName + "MARK" + count.ToString() + ".jpg";
                pic.Image.Save(outputFileName2);
            }
            else
            {
                imgname = fileName + ".jpg";

            }
            this.Close();

        }
        public Bitmap MakeSquareEndoWay(Image bmp, int size)
        {
            Bitmap s = (Bitmap)bmp;
            /*
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
            */
            return s;

        }
        public string GetMyResult()
        {
            return outputFileName2;
        }
        public string GetFilename()
        {
            return imgname;
        }
        public Rectangle GetSquare()
        {
            return _selectionDefault;
        }
        public bool GetIsEdit()
        {
            return isEdit;
        }
        bool LineisClick = false;
        private void Line_Click(object sender, EventArgs e)
        {


            if (!LineisClick)
            {
                modeSwitch("LINE");
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
                modeSwitch("NONE");
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
            if (editMode == "CROP_2")
            {
                if (isMoving)
                {


                }
                isMoving = false;
            }

            if (editMode == "CROP")
            {
                if (e.Button == MouseButtons.Left && _selecting && _selection.Width >= 0 && _selection.Height >= 0)
                {
                    // Create cropped image:


                    // MessageBox.Show(Math.Abs(_selection.Width).ToString());

                    Image img = pic.Image.Crop(_selection);

                    // Fit image to the picturebox:
                    pic.Width = img.Width;
                    pic.Height = img.Height;
                    pic.Image = img.Fit2PictureBox(pic);






                    _selecting = false;
                    modeSwitch("NONE");



                }
            }
            else
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

            if (editMode == "NONE" || (editMode == "start"))
            {





                modeSwitch("CROP_2");
            }

            if (addtextisClick)
            {
                txtP.Visible = true;
                txt.Focus();
            }

        }
        bool addtextisClick = false;
        private void addtxt_Click(object sender, EventArgs e)
        {
            modeSwitch("TEXT");
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

            Point a1 = Point.Empty;
            Point a2 = Point.Empty;
            Point a3 = Point.Empty;

            if (LineisClick)
            {
                a1.X = (mouseDownPosition.X * 4) / 3;
                a1.Y = (mouseDownPosition.Y * 4) / 3;

                a2.X = (mouseMovePosition.X * 4) / 3;
                a2.Y = (mouseMovePosition.Y * 4) / 3;


                Pen p = new Pen(Color.SpringGreen, 5);
                p.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                g.DrawLine(p, a1, a2);
                p.Dispose();
            }
            else
            {
                a3.X = (textLocation.X * 4) / 3;
                a3.Y = (textLocation.Y * 4) / 3;

                g.DrawString(txt.Text,
                    new Font("Tahoma", Convert.ToInt32(30)),
                    new SolidBrush(Color.SpringGreen), a3);
                textLocation = Invalid;
            }
            isEdit = true;
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
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ImageEditor_Load(object sender, EventArgs e)
        {
            Mode.Text = "";
            _originalImage = pic.Image.Clone() as Image;
            //  pic.Width = _originalImage.Width;
            // pic.Height = _originalImage.Height;

            pic.Width = (_originalImage.Width * 3) / 4;
            pic.Height = (_originalImage.Height * 3) / 4;






            //   panel1.Width = _originalImage.Width;
            //  this.Height = panel1.Height + pic.Height+40;
            //   this.Width = _originalImage.Width;
            defaultW = (_originalImage.Width * 3) / 4;
            defaultH = (_originalImage.Height * 3) / 4;
            //   drawSquare();

        }

        private void Original_Click(object sender, EventArgs e)
        {
            pic.Image = _originalImage.Clone() as Image;

        }



        private void Clear_Click(object sender, EventArgs e)
        {
            modeSwitch("NONE");

            LineisClick = false;
            Line.BackColor = Color.MidnightBlue;
            txtP.Visible = false;
            addtextisClick = false;
            isMoving = false;
            txt.Text = "";
            addtxt.BackColor = Color.MidnightBlue;

            //   Image Oldimage = _originalImage.Clone() as Image;

            defaultImage();
            //  Oldimage.Dispose();
        }
        private void defaultImage()
        {
            pic.Image = _originalImage.Clone() as Image;
            pic.Width = defaultW;
            pic.Height = defaultH;


        }
        private void Crop_Click(object sender, EventArgs e)
        {
            /*
            defaultImage();
            modeSwitch("CROP");
            */
            modeSwitch("CROP_2");
        }

        private void dropShadow(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            Color[] shadow = new Color[3];
            shadow[0] = Color.FromArgb(181, 181, 181);
            shadow[1] = Color.FromArgb(195, 195, 195);
            shadow[2] = Color.FromArgb(211, 211, 211);
            Pen pen = new Pen(shadow[0]);
            using (pen)
            {
                foreach (Panel p in panel.Controls.OfType<Panel>())
                {
                    Point pt = p.Location;
                    pt.Y += p.Height;
                    for (var sp = 0; sp < 3; sp++)
                    {
                        pen.Color = shadow[sp];
                        e.Graphics.DrawLine(pen, pt.X, pt.Y, pt.X + p.Width - 1, pt.Y);
                        pt.Y++;
                    }
                }
            }
        }

        public void modeSwitch(String MODE)
        {
            editMode = MODE;
            crop_button1.Visible = false;
            crop_button2.Visible = false;
            crop_label.Visible = false;
            defaultCropButton.Visible = false;
            switch (MODE)
            {
                case "CROP":
                    Mode.Text = "Crop Image ใช้เมาส์ลากสี่เหลี่ยมบนรูปเพื่อโฟกัส";
                    break;
                case "CROP_2":
                    Mode.Text = "ใช้เมาส์เพื่อเลือกบริเวณที่ต้องการแสดงใน report";
                    crop_button1.Visible = true;
                    crop_button2.Visible = true;
                    crop_label.Visible = true;
                    defaultCropButton.Visible = true;
                    break;
                case "LINE":
                    Mode.Text = "ลากเส้น ใช้เมาส์ลากเส้นบนรูป";
                    break;
                case "TEXT":
                    Mode.Text = "เพิ่มข้อความ ใช้เมาส์วางตำแหน่ง";
                    break;
                case "NONE":
                    Mode.Text = "";
                    break;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            modeSwitch("CROP_2");
        }


        int[] sizeZoom = { 1, 2, 3, 4 };

        private void OnMouseWheel(object sender, MouseEventArgs e)
        {
            /*
                        if (editMode == "CROP_2")

                        {
                            int newValueX = _selectionDefault.Width - Convert.ToInt32(_selectionDefault.Width * e.Delta / 1000);
                            int newValueY = _selectionDefault.Height - Convert.ToInt32(_selectionDefault.Height * e.Delta / 1000);

                            if ((_selectionDefault.X + newValueX <= pic.Width) && (_selectionDefault.Y + newValueY <= pic.Height) && (newValueX > (pic.Height / 10)))
                            {
                                _selectionDefault.Width = newValueX;
                                _selectionDefault.Height = newValueY;
                                pic.Refresh();
                            }
                        }
                        */
        }

        private void CropImage(Rectangle data)
        {

            Image img = pic.Image.Crop(data);

            // Fit image to the picturebox:
            pic.Width = img.Width;
            pic.Height = img.Height;
            pic.Image = img.Fit2PictureBox(pic);

            //  _selecting = false;
            modeSwitch("NONE");



        }

        private void button3_Click(object sender, EventArgs e)
        {
            CropImage(_selectionDefault);
        }

        private void crop_button1_Click(object sender, EventArgs e)
        {
            {
                int newValueX = _selectionDefault.Width - Convert.ToInt32(_selectionDefault.Width * -120 / 1000);
                int newValueY = _selectionDefault.Height - Convert.ToInt32(_selectionDefault.Height * -120 / 1000);

                if ((_selectionDefault.X + newValueX <= pic.Width) && (_selectionDefault.Y + newValueY <= pic.Height) && (newValueX > (pic.Height / 10)))
                {
                    _selectionDefault.Width = newValueX;
                    _selectionDefault.Height = newValueY;
                    pic.Refresh();
                }
            }


        }

        private void crop_button2_Click(object sender, EventArgs e)
        {
            {
                int newValueX = _selectionDefault.Width - Convert.ToInt32(_selectionDefault.Width * 120 / 1000);
                int newValueY = _selectionDefault.Height - Convert.ToInt32(_selectionDefault.Height * 120 / 1000);

                if ((_selectionDefault.X + newValueX <= pic.Width) && (_selectionDefault.Y + newValueY <= pic.Height) && (newValueX > (pic.Height / 10)))
                {
                    _selectionDefault.Width = newValueX;
                    _selectionDefault.Height = newValueY;
                    pic.Refresh();
                }
            }

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
     
            Mode.Text = "";
            _originalImage = pic.Image.Clone() as Image;
            pic.Width = (_originalImage.Width * 3) / 4;
            pic.Height = (_originalImage.Height * 3) / 4;

            defaultW = _originalImage.Width;
            defaultH = _originalImage.Height;

            Bitmap res = new Bitmap(500, 500);
            int t = 0, l = 0;
            if (pic.Image.Height > pic.Image.Width)
                t = (pic.Image.Height - pic.Image.Width) / 2;
            else
                l = (pic.Image.Width - pic.Image.Height) / 2;


            _selectionDefault = new Rectangle(l, t, pic.Image.Width - l * 2, pic.Image.Height - t * 2);


            drawSquare();
        }
    }
}

