using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IDMS.ReportContent;

namespace IDMS.Popup
{
    public partial class MARK_EGD_2 : UserControl
    {
        string mtext;
        public static Label[] La;
        string part;
        IMAGE_REPORT_2 imgReport;
        public MARK_EGD_2(IMAGE_REPORT_2 imgReport)
        {
            InitializeComponent();
            this.imgReport = imgReport;
            La = new Label[] { label1 , label2 , label3 , label4 , label5 , label6 , label7,label8, label9
    };
            

            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
        }

        private void button3_DragEnter(object sender, DragEventArgs e)
        {
            //PictureBox pic = sender as PictureBox;

            setDrag(label3, IMAGE_REPORT_2.MARKtext);

        }
        private void button4_DragEnter(object sender, DragEventArgs e)
        {
            //PictureBox pic = sender as PictureBox;

            setDrag(label4, IMAGE_REPORT_2.MARKtext);

        }
        public void setDrag(Label A, string a)
        {
            mtext = a;
            //if (A.Text.Contains(mtext) == true)
            //{
            //    return;
            //}
            //for (int i = 0; i < 9; i++)
            //{
            // if (La[i].Text.Contains(mtext) == true)
            //   {
            //        La[i].Text = La[i].Text.Replace(mtext, null);
            //    }

            //}
            if (A == La[0]) { part = "Esophagus"; }
            if (A == La[1]) { part = "EG junction"; }
            if (A == La[2]) { part = "Cardia"; }
            if (A == La[3]) { part = "Fundus"; }
            if (A == La[4]) { part = "Body"; }
            if (A == La[5]) { part = "Antrum"; }
            if (A == La[6]) { part = "Pylorus"; }
            if (A == La[7]) { part = "Bulb"; }
            if (A == La[8]) { part = "Second Portion"; }


            A.Text += mtext;
         
            IMAGE_REPORT_2.MARKtext = "";

            for (int i= 0; i <= IMAGE_REPORT_2.SELECT_IMAGE_COUNT; i++)
            {
                string T = "[" + (i+1) + "]";
                if (A.Text.Contains(T))
                {
                    for (int y = 0; y < IMAGE_REPORT_2.ROOT_IMAGE_COUNT; y++)
                    {
                        Console.WriteLine(IMAGE_REPORT_2.LIST_TICK[y].Text);
                        if (IMAGE_REPORT_2.LIST_TICK[y].Text == (i + 1).ToString())
                        {
                            IMAGE_REPORT_2.LIST_COMBO_CHOICE[y].Text = part;
                        }
                    }
                }

            }
           // IMAGE_REPORT_2.COMBO_CHOICE[0].Text = part;
        }



        public static void CAL_MARKTEXT(string i, int j)
        {
            int number = Int32.Parse(i);

            foreach (Label a in La)
            {
                string T = "[" + i + "]";
                if (a.Text.Contains(T))
                {
                    a.Text = a.Text.Replace(T, "");
                }

            }
            for (int h = number; h <=j; h++)
            {
                foreach (Label a in La)
                {
                    string T2 = "[" + h + "]";
                    if (a.Text.Contains(T2))
                    {
                        string T3 = "[" + (h - 1) + "]";
                        a.Text = a.Text.Replace(T2, T3);
                    }
                }

            }


        }
        public static void Clear_LABEL()
        {
            foreach (Label a in La)
            {
                a.Text = "";

            }
            IMAGE_REPORT_2.MARKtext = "";

        }

    }
}
