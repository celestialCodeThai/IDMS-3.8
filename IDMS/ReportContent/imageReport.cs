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
using System.IO;
using IDMS.Popup;
using System.Diagnostics;
using gfoidl.Imaging;
using IDMS.DataManage;

namespace IDMS.ReportContent
{
    public partial class imageReport : UserControl
    {
        DataAccess load = new DataAccess();
        public int imgCount = 0;
        public static int maxImg = 66;
        public static int sizeImage = 500;
        public PictureBox[] boxes;
        public PictureBox[] INS;

        public ComboBox[] cBoxes;
        public Button[] markButton;
        public Button[] insButton;

        public Button[] textButton;
        public TextBox[] LtextMark;

        public int[] cBoxIndex;
        public string[] imgPath;

        string D;

        public Rectangle[] recImage;


        public imageReport(String P)
        {
            InitializeComponent();





            D = P;
            boxes = new PictureBox[] { pic1, pic2, pic3, pic4, pic5, pic6, pic7, pic8, pic9, pic10, picture11, pic12, pic13, pic14, pic15, pic16, pic17, pic18, pic19, pic20, pic21, pic22, pic23, pic24, pic25, pic26, pic27, pic28, pic29, pic30
                ,pic31,pic32,pic33,pic34,pic35,pic36,pic37,pic38,pic39,pic40,pic41,pic42,pic43,pic44,pic45,pic46,pic47,pic48,pic49,pic50,pic51,pic52,pic53,pic54,pic55,pic56,pic57,pic58,pic59,pic60,pic61,pic62,pic63,pic64,pic65,pic66
            };


            imgPath = new string[maxImg];


            cBoxes = new ComboBox[] { cb1, cb2, cb3, cb4, cb5, cb6, cb7, cb8, cb9, cb10, cb11, cb12, cb13, cb14, cb15, cb16, cb17, cb18, cb19, cb20, cb21, cb22, cb23, cb24, cb25, cb26, cb27, cb28, cb29, cb30
             ,cb31,cb32,cb33,cb34,cb35,cb36,cb37,cb38,cb39,cb40,cb41,cb42,cb43,cb44,cb45,cb46,cb47,cb48,cb49,cb50,cb51,cb52,cb53,cb54,cb55,cb56,cb57,cb58,cb59,cb60,cb61,cb62,cb63,cb64,cb65,cb66
            };


            markButton = new Button[] { m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16, m17, m18, m19, m20, m21, m22, m23, m24, m25, m26, m27, m28, m29, m30
            ,m31,m32,m33,m34,m35,m36,m37,m38,m39,m40,m41,m42,m43,m44,m45,m46,m47,m48,m49,m50,m51,m52,m53,m54,m55,m56,m57,m58,m59,m60,m61,m62,m63,m64,m65,m66
            };


            textButton = new Button[] { e1, e2, e3, e4, e5, e6, e7, e8, e9, e10, e11, e12, e13, e14, e15, e16, e17, e18, e19, e20, e21, e22, e23, e24, e25, e26, e27, e28, e29, e30
            ,e31,e32,e33,e34,e35,e36,e37,e38,e39,e40,e41,e42,e43,e44,e45,e46,e47,e48,e49,e50,e51,e52,e53,e54,e55,e56,e57,e58,e59,e60,e61,e62,e63,e64,e65,e66
            };


            LtextMark = new TextBox[] { mt1, mt2, mt3, mt4, mt5, mt6, mt7, mt8, mt9, mt10, mt11, mt12, mt13, mt14, mt15, mt16, mt17, mt18, mt19, mt20, mt21, mt22, mt23, mt24, mt25, mt26, mt27, mt28, mt29, mt30
            ,mt31,mt32,mt33,mt34,mt35,mt36,mt37,mt38,mt39,mt40,mt41,mt42,mt43,mt44,mt45,mt46,mt47,mt48,mt49,mt50,mt51,mt52,mt53,mt54,mt55,mt56,mt57,mt58,mt59,mt60,mt61,mt62,mt63,mt64,mt65,mt66
            };


            INS = new PictureBox[] { INS1,INS2,INS3,INS4,INS5,INS6,INS7,INS8,INS9,INS10,INS11,INS12,INS13,INS14,INS15,INS16,INS17,INS18,INS19,INS20,INS21,INS22,INS23,INS24,INS25,INS26,INS27,INS28,INS29,INS30,INS31,INS32,INS33,INS34
                ,INS35 ,INS36 ,INS37 ,INS38 ,INS39 ,INS40 ,INS41 ,INS42 ,INS43 ,INS44 ,INS45 ,INS46 ,INS47 ,INS48 ,INS49 ,INS50 ,INS51 ,INS52 ,INS53 ,INS54 ,INS55 ,INS56 ,INS57 ,INS58 ,INS59 ,INS60 ,INS61 ,INS62 ,INS63 ,INS64 ,INS65 ,INS66
            };


            cBoxIndex = new int[maxImg];


            recImage = new Rectangle[maxImg];


            imgCount = 0;

            setUnabledAll();


            foreach (var ins in INS)
            {
                ins.AllowDrop = true;
                ins.DragDrop += INS_DragDrop;
                ins.DragEnter += INS_DragEnter;
            }


            foreach (var box in boxes)
            {
                box.AllowDrop = true;
                box.DragDrop += PictureBox_DragDrop;
                box.DragEnter += PictureBox_DragEnter;

                box.MouseDoubleClick += PictureBox_MouseDoubleClick;
                box.MouseClick += PictureBox_MouseClick;
                box.MouseMove += PictureBox_MouseMove;
                box.Enabled = false;

            }


            foreach (var m in markButton)
            {

                m.Click += Mark_Click;

            }


            foreach (var t in textButton)
            {

                t.Click += Edit_Click;

            }


            if (P == "EGD")
            {
                foreach (var cBox in cBoxes)
                {

                    cBox.Items.Add(" ");
                    cBox.Items.Add("Oropharynx");
                    cBox.Items.Add("Esophagus");
                    cBox.Items.Add("EG Junction");
                    cBox.Items.Add("Cardia");
                    cBox.Items.Add("Fundus");
                    cBox.Items.Add("Body");
                    cBox.Items.Add("Incisura");
                    cBox.Items.Add("Antrum");
                    cBox.Items.Add("Pylorus");
                    cBox.Items.Add("Duodenum");
                    cBox.Items.Add("Bulb");
                    cBox.Items.Add("2nd Portion");

                    cBox.SelectedIndex = 0;
                    cBox.SelectionChangeCommitted += ComboBox_SelectionChangeCommitted;
                }
            }


            if (P == "Colonoscopy")
            {
                foreach (var cBox in cBoxes)
                {
                    cBox.Items.Add(" ");
                    cBox.Items.Add("Anal Canal");
                    cBox.Items.Add("Rectum");
                    cBox.Items.Add("SigmoidColon");
                    cBox.Items.Add("DescendingColon");
                    cBox.Items.Add("SplenicFlexure");
                    cBox.Items.Add("TransverseColon");
                    cBox.Items.Add("HepaticFlexure");
                    cBox.Items.Add("AscendingColon");
                    cBox.Items.Add("Cecum");
                    cBox.Items.Add("Terminalileum");

                    cBox.SelectedIndex = 0;
                    cBox.SelectionChangeCommitted += ComboBox_SelectionChangeCommitted;
                }
            }


            if (P == "ERCP")
            {
                foreach (var cBox in cBoxes)
                {
                    cBox.Items.Add(" ");
                    cBox.Items.Add("Duodenum");
                    cBox.Items.Add("Papilla major");
                    cBox.Items.Add("Papilla minor");
                    cBox.Items.Add("Pancreas");
                    cBox.Items.Add("Biliary system");



                    cBox.SelectedIndex = 0;
                    cBox.SelectionChangeCommitted += ComboBox_SelectionChangeCommitted;
                }
            }


            if (P == "BRONCO")
            {
                foreach (var cBox in cBoxes)
                {
                    cBox.Items.Add(" ");
                    cBox.Items.Add("Vocal cord");
                    cBox.Items.Add("Trachea");
                    cBox.Items.Add("Carina");
                    cBox.Items.Add("Right main");
                    cBox.Items.Add("Right intermediate");
                    cBox.Items.Add("RUL");
                    cBox.Items.Add("RML");
                    cBox.Items.Add("RLL");
                    cBox.Items.Add("Left main");
                    cBox.Items.Add("LUL");
                    cBox.Items.Add("Lingula");
                    cBox.Items.Add("LLL");


                    cBox.SelectedIndex = 0;
                    cBox.SelectionChangeCommitted += ComboBox_SelectionChangeCommitted;
                }
            }


            if (P == "ENT")
            {
                foreach (var cBox in cBoxes)
                {
                    cBox.Items.Add(" ");
                    cBox.SelectedIndex = 0;
                    cBox.SelectionChangeCommitted += ComboBox_SelectionChangeCommitted;
                }
            }


            string pictureMode = load.getOption("option_value", "pictureMode");
            bool squareMode = pictureMode == "1";

            if (!squareMode)
            {
                setWideMode();
            }

        }


        private System.Delegate _delPageMethod;
        public Delegate CallingPageMethod
        {
            set { _delPageMethod = value; }
        }


        private void ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var a = (((ComboBox)sender).TabIndex) - 31;
            cBoxIndex[a] = cBoxes[a].SelectedIndex;


        }


        public void setPicture(string a)
        {
            try
            {
                if (imgCount < maxImg)
                {
                    boxes[imgCount].Image = MakeSquareEndoWay(Image.FromFile(a), sizeImage);
                    imgPath[imgCount] = a;

                    setEnabled(imgCount);

                    boxes[imgCount].Enabled = true;

                    imgCount++;

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(a + " is missing");
            }
        }


        public void setPictureWithPoint(string a, Rectangle point)
        {
            try
            {
                if (imgCount < maxImg)
                {
                    boxes[imgCount].Image = MakeSquareEndoWayPoint(Image.FromFile(a), sizeImage, point);
                    imgPath[imgCount] = a;

                    setEnabled(imgCount);

                    boxes[imgCount].Enabled = true;

                    imgCount++;

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(a + " is missing");
            }
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


        public Bitmap MakeSquareEndoWayPoint(Image bmp, int size, Rectangle point)
        {
            Image newIMG = (Image)(new Bitmap(bmp, new Size(((bmp.Width * 3) / 4), ((bmp.Height * 3) / 4))));

            bmp = newIMG;

            if (point.Width == 0)
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

            if (point.X + point.Width > bmp.Width)
            {
                point.Width = bmp.Width - point.X;
            }

            if (point.Y + point.Height > bmp.Height)
            {
                point.Height = bmp.Height - point.Y;
            }

            if (point.X < 0)
            {
                int g = point.X + point.Width;
                point.Width = g;
                point.X = 0;
            }

            if (point.Y < 0)
            {
                int g = point.Y + point.Height;
                point.Height = g;
                point.Y = 0;
            }

            Image img = bmp.Crop(point);
            Bitmap x = (Bitmap)img;

            return x;


        }


        public void changePicture(int b, string a, string imgname, string oldimg, Rectangle point, bool isEdit)
        {

            if (isEdit)
            {
                Report parent = this.Parent.Parent as Report;
                if (parent != null)
                {
                    //parent.selectImageTable.Rows.Add(imgname);

                    // parent.imagelistTable.Rows.Add(parent.selectImageTable[0, b].Value);
                    string imageName = oldimg.Replace(parent.imgFolder, null);

                    parent.table.Rows.Add(imageName);

                    parent.selectImageTable[0, b].Value = imgname;
                    parent.imagelistTable.Sort(parent.imagelistTable.Columns[0], ListSortDirection.Ascending);



                }
            }
            //  MakeSquareEndoWayP(boxes[b], Image.FromFile(a), sizeImage, point);
            boxes[b].Image = MakeSquareEndoWayPoint(Image.FromFile(a), sizeImage, point);
            imgPath[b] = a;
            boxes[b].Refresh();

        }


        public void clearPicture()
        {
            for (int i = 0; i < imgCount; i++)
            {
                boxes[i].Image = null;
                boxes[i].Enabled = false;
                imgPath[i] = null;

                cBoxes[i].SelectedIndex = 0;
                cBoxIndex[i] = 0;
                recImage[maxImg - 1] = new Rectangle(new Point(0, 0), new Size(0, 0)); ;

            }
            setUnabledAll();
            imgCount = 0;
        }


        public void removePicture(string Folder, string Name)
        {
            string a = Folder + Name;
            int index = 0;
            for (int i = 0; i < imgCount; i++)
            {
                if (imgPath[i] == a)
                {
                    index = i;
                }
            }

            for (int i = index; i < maxImg - 1; i++)
            {
                imgPath[i] = imgPath[i + 1];
                cBoxIndex[i] = cBoxIndex[i + 1];
                recImage[i] = recImage[i + 1];

            }
            recImage[maxImg - 1] = new Rectangle(new Point(0, 0), new Size(0, 0)); ;
            cBoxIndex[maxImg - 1] = 0;
            imgPath[maxImg - 1] = null;
            boxes[imgCount - 1].Enabled = false;
            setUnabled(imgCount - 1);

            updateSelectedImage(Name);

            imgCount--;







            reloadImage();



        }


        private void updateSelectedSwap(string tname, string sname)
        {
            if (imgCount > 0)
            {

                int tRow = 0;
                int sRow = 0;
                Report parent = this.Parent.Parent as Report;
                if (parent != null)
                {
                    // parent.selectImageTable.Rows.Clear();
                    // parent.selectImageTable.Rows.RemoveAt(v);

                    tname = tname.Replace(parent.imgFolder, null);
                    sname = sname.Replace(parent.imgFolder, null);
                    string t = "", s = "";
                    for (int i = 0; i < parent.selectImageTable.Rows.Count - 1; i++)
                    {
                        //  System.Windows.Forms.MessageBox.Show(parent.selectImageTable.Rows[i].Cells[0].Value.ToString());

                        // your index is in i
                        if (tname == parent.selectImageTable.Rows[i].Cells[0].Value.ToString())
                        {
                            tRow = i;
                            t = parent.selectImageTable.Rows[i].Cells[0].Value.ToString();
                        }
                        if (sname == parent.selectImageTable.Rows[i].Cells[0].Value.ToString())
                        {
                            sRow = i;
                            s = parent.selectImageTable.Rows[i].Cells[0].Value.ToString();
                        }
                    }

                    parent.selectImageTable.Rows[tRow].Cells[0].Value = s;
                    parent.selectImageTable.Rows[sRow].Cells[0].Value = t;

                    // System.Windows.Forms.MessageBox.Show("trow is "+tRow.ToString()+" srow is"+ sRow.ToString());

                }

            }

        }


        private void updateSelectedImage(string imgname)
        {



            if (imgCount > 0)
            {


                Report parent = this.Parent.Parent as Report;
                if (parent != null)
                {
                    // parent.selectImageTable.Rows.Clear();







                    for (int v = 0; v < parent.selectImageTable.Rows.Count; v++)
                    {
                        if (string.Equals(parent.selectImageTable[0, v].Value as string, imgname))
                        {
                            parent.selectImageTable.Rows.RemoveAt(v);
                            v--;
                        }
                    }

                    //  parent.imagelistTable.Rows.Add(imgname);


                }
            }
        }


        private void PictureBox_DragDrop(object sender, DragEventArgs e)
        {


            var target = (PictureBox)sender;
            if (e.Data.GetDataPresent(typeof(PictureBox)))
            {
                var source = (PictureBox)e.Data.GetData(typeof(PictureBox));

                if (source != target)
                {
                    Console.WriteLine("Do DragDrop from " + source.Name + " to " + target.Name);

                    SwapImages(source, target);


                }
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


        private void PictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var a = (((PictureBox)sender).TabIndex) - 1;


            string Name = imgPath[a];




            if (a < imgCount)
            {
                for (int i = a; i < maxImg - 1; i++)
                {
                    imgPath[i] = imgPath[i + 1];
                    cBoxIndex[i] = cBoxIndex[i + 1];
                    recImage[i] = recImage[i + 1];

                }
                cBoxIndex[maxImg - 1] = 0;
                recImage[maxImg - 1] = new Rectangle(new Point(0, 0), new Size(0, 0)); ;
                imgPath[maxImg - 1] = null;
                boxes[imgCount - 1].Enabled = false;
                setUnabled(imgCount - 1);
                imgCount--;
            }

            reloadImage();


            // string Name = imgPath[a]; 
            object[] obj = new object[1];
            obj[0] = Name as object;
            _delPageMethod.DynamicInvoke(obj);



            if (imgCount > 0)
            {


                Report parent = this.Parent.Parent as Report;
                if (parent != null)
                {
                    parent.picPreview.Image = null;
                    // string a = imgPath[targetPath];

                    //  string fileName = Path.GetFileNameWithoutExtension(a);

                    parent.picnamePreview.Text = null;

                }
                parent.imagelistTable.Sort(parent.imagelistTable.Columns[0], ListSortDirection.Ascending);

            }




        }


        private void SwapImages(PictureBox source, PictureBox target)
        {
            if (source.Image == null || target.Image == null)
            {
                return;
            }

            var temp = target.Image;
            target.Image = source.Image;
            source.Image = temp;


            var a = (((PictureBox)source).TabIndex) - 1;
            var b = (((PictureBox)target).TabIndex) - 1;

            var tempPath = imgPath[a];
            imgPath[a] = imgPath[b];
            imgPath[b] = tempPath;

            var tempTab = cBoxes[a].SelectedIndex;
            cBoxes[a].SelectedIndex = cBoxes[b].SelectedIndex;
            cBoxIndex[a] = cBoxes[a].SelectedIndex;

            cBoxes[b].SelectedIndex = tempTab;
            cBoxIndex[b] = tempTab;

            var tempRec = recImage[a];
            recImage[a] = recImage[b];
            recImage[b] = tempRec;




            updateSelectedSwap(imgPath[a], imgPath[b]);


        }


        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {



            if (imgCount > 0)
            {
                var target = (PictureBox)sender;
                var targetPath = (((PictureBox)sender).TabIndex) - 1;

                Report parent = this.Parent.Parent as Report;
                if (parent != null)
                {
                    parent.picPreview.Image = target.Image;
                    string a = imgPath[targetPath];

                    string fileName = Path.GetFileNameWithoutExtension(a);

                    parent.picnamePreview.Text = fileName;

                }
            }


        }


        private void reloadImage()
        {
            var y = 0;
            foreach (var box in boxes)
            {
                box.Image = null;
                cBoxes[y].SelectedIndex = 0;
                y++;
            }

            for (int i = 0; i < imgCount; i++)
            {
                //    System.Windows.Forms.MessageBox.Show(imgPath[i]);
                boxes[i].Image = MakeSquareEndoWayPoint(Image.FromFile(imgPath[i]), sizeImage, recImage[i]);
                // boxes[i].Image.Tag = selectImageTable[indexX, i].Value.ToString();
                cBoxes[i].SelectedIndex = cBoxIndex[i];


            }
        }


        public string[] mark1 = new String[20];
        string[] mark2 = new String[20];
        string[] mark3 = new String[20];
        string[] mark4 = new String[20];


        private void editImg(int i)
        {
            i = i - 1;
            if (boxes[i].Image == null) { return; }
            boxes[i].Image = MakeSquareEndoWay(Image.FromFile(imgPath[i]), sizeImage);
            // boxes[i].Image = null;
            using (ImageEditor formOptions = new ImageEditor(imgPath[i], recImage[i]))
            {
                formOptions.ShowDialog();

                string result = formOptions.GetMyResult();
                string imgname = formOptions.GetFilename();
                Rectangle point = formOptions.GetSquare();
                bool isEdit = formOptions.GetIsEdit();
                if (imgname != null)
                {
                    recImage[i] = point;
                    changePicture(i, result, imgname, imgPath[i], point, isEdit);
                }

            }
        }


        private void marking(int i2, string a, string b, string c, string d, string e, string f, string g, string h, string i, string j, string k)
        {
            i2 = i2 - 1;
            if (imgPath[i2] == null) { return; }
            if (D == "EGD")
            {
                using (Mark formOptions = new Mark(imgPath[i2], a, b, c, d, e, f, g, h, i, LtextMark[i2].Text))
                {
                    formOptions.ShowDialog();

                    string result = formOptions.GetMyResult();
                    // System.Windows.Forms.MessageBox.Show(result);
                    mark1[0] = formOptions.GetMarkA();
                    mark1[1] = formOptions.GetMarkB();

                    mark1[2] = formOptions.GetMarkC();

                    mark1[3] = formOptions.GetMarkD();
                    mark1[4] = formOptions.GetMarkE();
                    mark1[5] = formOptions.GetMarkF();
                    mark1[6] = formOptions.GetMarkG();
                    mark1[7] = formOptions.GetMarkH();
                    mark1[8] = formOptions.GetMarkI();
                    cBoxes[i2].Text = result;


                }
            }
            else
            {
                if (D == "Colonoscopy")
                {
                    using (MarkColono formOptions = new MarkColono(imgPath[i2], a, b, c, d, e, f, g, h, i, LtextMark[i2].Text))
                    {
                        formOptions.ShowDialog();

                        string result = formOptions.GetMyResult();
                        // System.Windows.Forms.MessageBox.Show(result);
                        mark1[0] = formOptions.GetMarkA();
                        mark1[1] = formOptions.GetMarkB();

                        mark1[2] = formOptions.GetMarkC();

                        mark1[3] = formOptions.GetMarkD();
                        mark1[4] = formOptions.GetMarkE();
                        mark1[5] = formOptions.GetMarkF();
                        mark1[6] = formOptions.GetMarkG();
                        mark1[7] = formOptions.GetMarkH();
                        mark1[8] = formOptions.GetMarkI();
                        cBoxes[i2].Text = result;


                    }


                }
                if (D == "BRONCO")
                {
                    using (MarkBronco formOptions = new MarkBronco(imgPath[i2], a, b, c, d, e, f, g, h, i, j, k, LtextMark[i2].Text))
                    {
                        formOptions.ShowDialog();

                        string result = formOptions.GetMyResult();
                        // System.Windows.Forms.MessageBox.Show(result);
                        mark1[0] = formOptions.GetMarkA();
                        mark1[1] = formOptions.GetMarkB();

                        mark1[2] = formOptions.GetMarkC();

                        mark1[3] = formOptions.GetMarkD();
                        mark1[4] = formOptions.GetMarkE();
                        mark1[5] = formOptions.GetMarkF();
                        mark1[6] = formOptions.GetMarkG();
                        mark1[7] = formOptions.GetMarkH();
                        mark1[8] = formOptions.GetMarkI();
                        mark1[9] = formOptions.GetMarkJ();
                        mark1[10] = formOptions.GetMarkK();
                        cBoxes[i2].Text = result;


                    }
                }

            }
        }


        private void Mark_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            string buttonIndex = button.Name.Replace("m", null);
            // System.Windows.Forms.MessageBox.Show(buttonIndex);
            int x = Int32.Parse(buttonIndex);

            marking(x, mark1[0], mark1[1], mark1[2], mark1[3], mark1[4], mark1[5], mark1[6], mark1[7], mark1[8], mark1[9], mark1[10]);

        }


        private void Edit_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            string buttonIndex = button.Name.Replace("e", null);
            // System.Windows.Forms.MessageBox.Show(buttonIndex);
            int x = Int32.Parse(buttonIndex);

            editImg(x);
        }


        public void setEnabled(int i)
        {
            boxes[i].Visible = true;
            cBoxes[i].Visible = true;
            markButton[i].Visible = true;
            textButton[i].Visible = true;
            LtextMark[i].Visible = true;


        }


        public void setUnabled(int i)
        {


            boxes[i].Visible = false;
            cBoxes[i].Visible = false;
            markButton[i].Visible = false;
            textButton[i].Visible = false;
            LtextMark[i].Visible = false;


        }


        public void setUnabledAll()
        {

            for (int i = 0; i < maxImg; i++)
            {
                boxes[i].Visible = false;
                cBoxes[i].Visible = false;
                markButton[i].Visible = false;
                textButton[i].Visible = false;
                LtextMark[i].Visible = false;
            }

        }


        private void INS_DragDrop(object sender, DragEventArgs e)
        {



            var target = (PictureBox)sender;


            var INS_INDEX = (int.Parse(target.Name.Replace("INS", ""))) - 1;

            //   MessageBox.Show("INS Index is " + INS_INDEX.ToString());

            if (e.Data.GetDataPresent(typeof(PictureBox)))
            {
                var source = (PictureBox)e.Data.GetData(typeof(PictureBox));

                if (source != target)
                {
                    // Console.WriteLine("Do DragDrop from " + source.Name + " to " + target.Name);

                    // SwapImages(source, target);

                    var PIC_INDEX = (int.Parse(source.Name.Replace("pic", ""))) - 1;
                    //   MessageBox.Show("pictureArrayIndex is " + PIC_INDEX.ToString());

                    //boxes[INS_INDEX] = boxes[PIC_INDEX];
                    insertImages(INS_INDEX, PIC_INDEX);
                }
            }


        }


        private void insertImages(int lower, int higher)
        {


            string Lower = imgPath[lower];
            string Higher = imgPath[higher];

            ////

            Report parent = this.Parent.Parent as Report;
            string tname = Lower.Replace(parent.imgFolder, null);
            string sname = Higher.Replace(parent.imgFolder, null);

            ////

            int cBoxHigher = cBoxIndex[higher];
            Rectangle recImageHigher = recImage[higher];
            Rectangle recImageLower = recImage[lower];

            string table = parent.selectImageTable.Rows[higher].Cells[0].Value.ToString();
            if (higher > lower)
            {
                for (int i = higher; i > lower; i--)
                {
                    if (i - 1 >= 0)
                    {
                        imgPath[i] = imgPath[i - 1];
                        cBoxIndex[i] = cBoxIndex[i - 1];
                        recImage[i] = recImage[i - 1];
                        parent.selectImageTable.Rows[i].Cells[0].Value = parent.selectImageTable.Rows[i - 1].Cells[0].Value;
                    }
                }

                imgPath[lower] = Higher;
                cBoxIndex[lower] = cBoxHigher;
                recImage[lower] = recImageHigher;

                parent.selectImageTable.Rows[lower].Cells[0].Value = table;
            }
            else
            {

                if (higher < lower)
                {

                    for (int i = higher; i < lower - 1; i++)
                    {
                        string path = imgPath[i + 1];
                        int cpathIndex = cBoxIndex[i + 1];
                        Rectangle recImageIndex = recImage[i + 1];
                        string tableValue = parent.selectImageTable.Rows[i + 1].Cells[0].Value.ToString();
                        if (i + 1 <= imgCount)
                        {


                            imgPath[i] = path;
                            cBoxIndex[i] = cpathIndex;
                            recImage[i] = recImageIndex;

                            parent.selectImageTable.Rows[i].Cells[0].Value = tableValue;

                        }
                    }

                    imgPath[lower - 1] = Higher;
                    cBoxIndex[lower - 1] = cBoxHigher;
                    recImage[lower - 1] = recImageHigher;
                    parent.selectImageTable.Rows[lower - 1].Cells[0].Value = table;

                }


            }
            reloadImage();


        }


        private void INS_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }


        public void setDefaultRectangle()
        {
            for (int i = 0; i < 66; i++)
            {
                recImage[i] = new Rectangle(0, 0, 0, 0);
            }
        }


        private void setWideMode()
        {
            Size insSize = new Size(40, 110);
            Size picSize = new Size(195, 110);
            Size comboBoxSize = new Size(150, 24);

            int insAxisX = -15;
            int insAxisY = 40;

            int picAxisX = 25;
            int picAxisY = 40;

            int comboBoxAxisX = 55;
            int comboBoxAxisY = 155;

            int textMarkAxisX = 25;
            int textMarkAxisY = 155;

            int markButtonAxisX = 220;
            int markButtonAxisY = 85;

            int textButtonAxisX = 220;
            int textButtonAxisY = 120;

            int nextPosition = 240;


            foreach (PictureBox ins in INS)
            {
                ins.Size = insSize;
            }


            foreach (PictureBox picture in boxes)
            {
                picture.Size = picSize;
            }


            foreach (ComboBox comboBox in cBoxes)
            {
                comboBox.Size = comboBoxSize;
            }

            for (int i = 0; i < 3; i++)
            {
                INS[i].Location = new Point(insAxisX, insAxisY);
                insAxisX += nextPosition;

                boxes[i].Location = new Point(picAxisX, picAxisY);
                picAxisX += nextPosition;

                cBoxes[i].Location = new Point(comboBoxAxisX, comboBoxAxisY);
                comboBoxAxisX += nextPosition;

                LtextMark[i].Location = new Point(textMarkAxisX, textMarkAxisY);
                textMarkAxisX += nextPosition;

                markButton[i].Location = new Point(markButtonAxisX, markButtonAxisY);
                markButtonAxisX += nextPosition;

                textButton[i].Location = new Point(textButtonAxisX, textButtonAxisY);
                textButtonAxisX += nextPosition;
            }


        }


    }
}
