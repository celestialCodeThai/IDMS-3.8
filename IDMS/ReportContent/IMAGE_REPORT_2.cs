using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IDMS.Popup;

namespace IDMS.ReportContent
{
    public partial class IMAGE_REPORT_2 : UserControl
    {
        int IMG_X = 10, IMG_Y = 10;
        int IMG_GAP_X = 210;
        int IMG_SIZE = 200;
        int TICK_BTN_SIZE = 32;
        string PATH = "D:\\";
        public static int ROOT_IMAGE_COUNT = 0;
        public static int SELECT_IMAGE_COUNT = 0;
        List<PictureBox> LIST_ROOT_IMG = new List<PictureBox>();
        public static List<RoundBTN> LIST_TICK = new List<RoundBTN>();
        PictureBox[] ROOT_PIC;
        List<Image> UNEDIT_IMAGE = new List<Image>();
        public static List<ComboBox> LIST_COMBO_CHOICE = new List<ComboBox>();
        ComboBox[] COMBO_N;
        RoundBTN[] TICK_BTN;

        List<ComboBox> LIST_SELECTED_COMBO = new List<ComboBox>();
        List<String> SELECTED_COMBO = new List<String>();
        List<PictureBox> LIST_SELECTED_IMG = new List<PictureBox>();
        List<Image> SELECTED_IMG = new List<Image>();

        string VIEW_MODE = "NORMAL";
        int IMG_PER_ROW = 5;
        public IMAGE_REPORT_2()
        {
            InitializeComponent();
            SCAN_ROOT_FOLDER(PATH);
            Popup.MARK_EGD_2 MEGD = new Popup.MARK_EGD_2(this);
            MARK_PANEL.Controls.Add(MEGD);
            MARK_PANEL.AllowDrop = true;

        }
        public void SCAN_ROOT_FOLDER(string PATH)
        {

            string[] files = System.IO.Directory.GetFiles(PATH);
            for (int i = 0; i < files.Length; i++)
            {
                System.IO.FileInfo file = new System.IO.FileInfo(files[i]);

                var button = new RoundBTN
                {
                    Name = "tick" + ROOT_IMAGE_COUNT,

                    Size = new Size(TICK_BTN_SIZE, TICK_BTN_SIZE),
                    Location = new Point(IMG_X, IMG_Y),

                };
               
                button.Image = global::IDMS.Properties.Resources.number_select;
                //  button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                //button.BackColor = System.Drawing.Color.Transparent;
                button.ForeColor = Color.White;
                button.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
                var COMBO_BOX = new ComboBox
                {
                    Name = "c" + ROOT_IMAGE_COUNT,

                    Size = new Size(IMG_SIZE, IMG_SIZE),
                    Location = new Point(IMG_X, IMG_Y+ IMG_SIZE+2),

                };
                COMBO_BOX.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);

                COMBO_BOX.Items.Add("Esophagus");
                COMBO_BOX.Items.Add("EG junction");
                COMBO_BOX.Items.Add("Cardia");
                COMBO_BOX.Items.Add("Fundus");
                COMBO_BOX.Items.Add("Body");
                COMBO_BOX.Items.Add("Antrum");
                COMBO_BOX.Items.Add("Pylorus");
                COMBO_BOX.Items.Add("Bulb");
                COMBO_BOX.Items.Add("Second Portion");
                COMBO_BOX.TextChanged += new EventHandler(comboText);
                LIST_COMBO_CHOICE.Add(COMBO_BOX);
               
                IMAGE.Controls.Add(COMBO_BOX);
                COMBO_BOX.Visible = false;

                 button.Click += new EventHandler(button_Click);
                IMAGE.Controls.Add(button);
                LIST_TICK.Add(button);

                var picture = new PictureBox
                {
                    Name = "pic" + ROOT_IMAGE_COUNT,

                    Size = new Size(IMG_SIZE, IMG_SIZE),
                    Location = new Point(IMG_X, IMG_Y),

                    Image = Image.FromFile(PATH + file.Name),

                    SizeMode = PictureBoxSizeMode.StretchImage

                };
               
                picture.AllowDrop = true;
                picture.DragDrop += new DragEventHandler(PictureBox_DragDrop);
                picture.DragEnter += new DragEventHandler (PictureBox_DragEnter);
                picture.MouseMove += PictureBox_MouseMove;

                LIST_ROOT_IMG.Add(picture);
                IMAGE.Controls.Add(picture);
                //  picture.Controls.Add(button);
                IMG_X += IMG_GAP_X;
                ROOT_IMAGE_COUNT += 1;
                if ((ROOT_IMAGE_COUNT % IMG_PER_ROW) == 0)
                {
                    IMG_Y += IMG_GAP_X+30;
                    IMG_X = 10;
                }
                UNEDIT_IMAGE.Add(picture.Image);

               

            }


            ROOT_PIC = LIST_ROOT_IMG.ToArray();
            TICK_BTN = LIST_TICK.ToArray();
            COMBO_N = LIST_COMBO_CHOICE.ToArray();
        }
        protected void comboText(object sender, EventArgs e)
        {

            ComboBox combobox = sender as ComboBox;
            
          
            bool EXIST = true;
            for (int i = 0; i < SELECTED_COMBO.Count; i++)
            {
                if (SELECTED_COMBO[i].Contains(combobox.Name))
                {
                    SELECTED_COMBO[i] = combobox.Name + "/" + combobox.Text;
                    EXIST = false;
                }
            }
            if (EXIST) { SELECTED_COMBO.Add(combobox.Name + "/" + combobox.Text); }
            



        }
        protected void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int i = Int32.Parse(button.Name.Replace("tick", ""));
          //  MessageBox.Show(i.ToString());
            if (button.Text == "")
            {
                SELECT_IMAGE_COUNT += 1;
               
                LIST_SELECTED_IMG.Add(LIST_ROOT_IMG[i]);
                SELECTED_IMG.Add(LIST_ROOT_IMG[i].Image);
               
                button.Text = (LIST_SELECTED_IMG.IndexOf(LIST_ROOT_IMG[i]) + 1).ToString();
                LIST_ROOT_IMG[i].Image = AdjustBrightness(LIST_ROOT_IMG[i].Image, -100);
                MARKtext +="["+ button.Text+"]";
              
                LIST_COMBO_CHOICE[i].Visible = true;
            }
            else
            {
                MARK_EGD_2.CAL_MARKTEXT(button.Text, SELECT_IMAGE_COUNT);
                SELECT_IMAGE_COUNT -= 1;
            
                button.Text = "";
                LIST_ROOT_IMG[i].Image = UNEDIT_IMAGE[i];
              
                LIST_SELECTED_IMG.Remove(LIST_ROOT_IMG[i]);
                SELECTED_IMG.Remove(LIST_ROOT_IMG[i].Image);
                LIST_COMBO_CHOICE[i].Visible = false;
                LIST_COMBO_CHOICE[i].Text = "";
             //   LIST_COMBO_CHOICE.Remove(LIST_COMBO_CHOICE[i]);
                CAL_NUMBERLIST();



                SELECTED_COMBO.Remove("c" + i.ToString() + "/"+"");
            }
        }
        public static Image AdjustBrightness(Image Image, int Value)
        {

            Bitmap TempBitmap = (Bitmap)Image;

            Bitmap NewBitmap = new Bitmap(TempBitmap.Width, TempBitmap.Height);

            Graphics NewGraphics = Graphics.FromImage(NewBitmap);

            float FinalValue = (float)Value / 255.0f;

            float[][] FloatColorMatrix ={

                    new float[] {1, 0, 0, 0, 0},

                    new float[] {0, 1, 0, 0, 0},

                    new float[] {0, 0, 1, 0, 0},

                    new float[] {0, 0, 0, 1, 0},

                    new float[] {FinalValue, FinalValue, FinalValue, 1, 1}
                };

            System.Drawing.Imaging.ColorMatrix NewColorMatrix = new System.Drawing.Imaging.ColorMatrix(FloatColorMatrix);

            System.Drawing.Imaging.ImageAttributes Attributes = new System.Drawing.Imaging.ImageAttributes();

            Attributes.SetColorMatrix(NewColorMatrix);

            NewGraphics.DrawImage(TempBitmap, new Rectangle(0, 0, TempBitmap.Width, TempBitmap.Height), 0, 0, TempBitmap.Width, TempBitmap.Height, GraphicsUnit.Pixel, Attributes);

            Attributes.Dispose();

            NewGraphics.Dispose();

            return (Image)NewBitmap;
        }

        public void CAL_NUMBERLIST()
        {
            // (LIST_SELECTED_IMG.IndexOf(LIST_ROOT_IMG[i]) + 1).ToString();
            for (var i = 0; i < ROOT_IMAGE_COUNT; i++)
            {
                if (LIST_SELECTED_IMG.Contains(LIST_ROOT_IMG[i]))
                {
                    // MessageBox.Show(LIST_ROOT_IMG[i].Name);
                    LIST_TICK[i].Text = (LIST_SELECTED_IMG.IndexOf(LIST_ROOT_IMG[i]) + 1).ToString();
                }
            }

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

        private void button3_DragEnter(object sender, DragEventArgs e)
        {
            Button button = sender as Button;
            button.Text = "KUY";
            // MessageBox.Show("test");
            e.Effect = DragDropEffects.Move;
            


        }
        public static string MARKtext;
       

        private void VIEWSELECT_BTN_Click(object sender, EventArgs e)
        {
            LOAD_SELECT_PICTURE();
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
        public void CLEAR_LIST()
        {
            
            LIST_TICK.Clear();
            LIST_SELECTED_IMG.Clear();
            SELECTED_IMG.Clear();
            SELECT_IMAGE_COUNT = 0;
            LIST_ROOT_IMG.Clear();
            LIST_COMBO_CHOICE.Clear();
        }
        public void CLEAR_ALL_IMG()
        {
            for (int i = 0; i < ROOT_IMAGE_COUNT; i++) // 0 - 2
            {
                LIST_ROOT_IMG.Remove(ROOT_PIC[i]);
                TICK_BTN[i].Click -= new EventHandler(button_Click);

                UNEDIT_IMAGE.Clear();
                LIST_TICK.Remove(TICK_BTN[i]);
                LIST_COMBO_CHOICE.Remove(COMBO_N[i]);
                this.Controls.Remove(ROOT_PIC[i]);
                this.Controls.Remove(TICK_BTN[i]);
                this.Controls.Remove(COMBO_N[i]);
                ROOT_PIC[i].Dispose();
                TICK_BTN[i].Dispose();
                LIST_TICK.Clear();
                COMBO_N[i].Dispose();
            }
           
            ROOT_IMAGE_COUNT = 0; IMG_X = 10; IMG_Y = 10;


            
        }
        public void CLEAR_SELECT_IMG()
        {


         

            for (int i = 0; i < SELECT_IMAGE_COUNT; i++) // 0 - 2
            {
                UNEDIT_IMAGE.Clear();

                LIST_ROOT_IMG.Remove(LIST_SELECTED_IMG[i]);
                LIST_COMBO_CHOICE.Remove(COMBO_N[i]);
                TICK_BTN[i].Click -= new EventHandler(button_Click);
                this.Controls.Remove(LIST_ROOT_IMG[i]);
                this.Controls.Remove(LIST_COMBO_CHOICE[i]);
                LIST_ROOT_IMG[i].Dispose();
                
                LIST_COMBO_CHOICE[i].Dispose();


            }
            LIST_SELECTED_IMG.Clear();
            LIST_SELECTED_COMBO.Clear();
            SELECTED_COMBO.Clear();
            LIST_SELECTED_IMG.Clear();
            SELECTED_IMG.Clear();
            SELECT_IMAGE_COUNT = 0; ROOT_IMAGE_COUNT = 0; IMG_X = 10; IMG_Y = 10;
        }
        private void button2_Click(object sender, EventArgs e)
        {
          
            if (VIEW_MODE == "SELECT")
            {
                MARK_EGD_2.Clear_LABEL();
                CLEAR_SELECT_IMG();
               
                CLEAR_LIST();
            }
            else
            {
                MARK_EGD_2.Clear_LABEL();
                CLEAR_LIST();
                CLEAR_ALL_IMG();
                VIEW_MODE = "NORMAL";
            }

            SCAN_ROOT_FOLDER(PATH);
        }

        private void VIEWALL_BTN_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < SELECT_IMAGE_COUNT; i++)
            {
                MessageBox.Show(SELECTED_COMBO[i]);
            }
        }
        private void LOAD_SELECT_PICTURE()
        {
         CLEAR_ALL_IMG();
            VIEW_MODE = "SELECT";
            for (int i = 0; i < SELECT_IMAGE_COUNT; i++)
            {
              
                var COMBO_BOX = new ComboBox
                {
                    Name = "c" + ROOT_IMAGE_COUNT,

                    Size = new Size(IMG_SIZE, IMG_SIZE),
                    Location = new Point(IMG_X, IMG_Y + IMG_SIZE + 2),

                };
                COMBO_BOX.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);

                COMBO_BOX.Items.Add("Esophagus");
                COMBO_BOX.Items.Add("EG junction");
                COMBO_BOX.Items.Add("Cardia");
                COMBO_BOX.Items.Add("Fundus");
                COMBO_BOX.Items.Add("Body");
                COMBO_BOX.Items.Add("Antrum");
                COMBO_BOX.Items.Add("Pylorus");
                COMBO_BOX.Items.Add("Bulb");
                COMBO_BOX.Items.Add("Second Portion");
                try
                {
                    string output = SELECTED_COMBO[i].Substring(SELECTED_COMBO[i].IndexOf('/') + 1);
                    COMBO_BOX.Text = output;
                }
                catch { }
              
                LIST_COMBO_CHOICE.Add(COMBO_BOX);

                IMAGE.Controls.Add(COMBO_BOX);






                var picture = new PictureBox
                {
                    Name = LIST_SELECTED_IMG[i].Name,

                    Size = new Size(IMG_SIZE, IMG_SIZE),
                    Location = new Point(IMG_X, IMG_Y),

                    Image = SELECTED_IMG[i],

                    SizeMode = PictureBoxSizeMode.StretchImage

                };
                //picture.AllowDrop = true;
                //picture.DragDrop += new DragEventHandler(PictureBox_DragDrop);
                //picture.DragEnter += new DragEventHandler(PictureBox_DragEnter);
                //picture.MouseMove += PictureBox_MouseMove;

                LIST_ROOT_IMG.Add(picture);
                IMAGE.Controls.Add(picture);
               
                IMG_X += IMG_GAP_X;
                ROOT_IMAGE_COUNT += 1;
                if ((ROOT_IMAGE_COUNT % IMG_PER_ROW) == 0)
                {
                    IMG_Y += IMG_GAP_X + 30;
                    IMG_X = 10;
                }
               




            }

        }
    }
}
