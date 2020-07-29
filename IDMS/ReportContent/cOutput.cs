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
    public partial class cOutput : UserControl
    {
        public PictureBox[] boxes;
        public Label[] cBoxes;
        public TextBox[] mtb;

        public Label[] text;


        public cOutput(Report a, imageReport b, reportControlColono c)
        {
            InitializeComponent();
            boxes = new PictureBox[] { pic1, pic2, pic3, pic4, pic5, pic6, pic7, pic8 };
            cBoxes = new Label[] { c1, c2, c3, c4, c5, c6, c7, c8 };
            mtb = new TextBox[] { mt1, mt2, mt3, mt4, mt5, mt6, mt7, mt8 };
            text = new Label[] { name, edotxt, snursetxt, cnursetxt, anttxt, bh, note };




            l1.Text = b.mark1[0];
            l2.Text = b.mark1[1];
            l3.Text = b.mark1[2];
            l4.Text = b.mark1[3];
            l5.Text = b.mark1[4];
            l6.Text = b.mark1[5];
            l7.Text = b.mark1[6];
            l8.Text = b.mark1[7];
            l9.Text = b.mark1[8];
            this.hn.Text = "";
            this.hn.Text = a.infohn.Text;
            this.name.Text = "";
            this.name.Text = a.infoname.Text;

            this.sex.Text = a.infosex.Text;
            this.age.Text = a.infoage.Text;
            this.regis.Text = a.inforegis.Text;
            this.duration.Text = a.Duration.Text;

            this.edotxt.Text = "";
            this.edotxt.Text = a.infodoc.Text;
            this.snursetxt.Text = "";
            this.snursetxt.Text = a.infosnurse.Text;
            this.proroom.Text = "";
            this.proroom.Text = a.infoproroom.Text;
            this.anttxt.Text = "";
            this.anttxt.Text = a.anes.Text;
            this.anestxt.Text = "";
            this.anestxt.Text = a.anes.Text;
            this.predx1txt.Text = "";
            int predxCount = 0;
            if (a.pdx1.Text != "") { predxCount = 1; }
            if (a.pdx2.Text != "") { predxCount = 2; }
            if (a.pdx3.Text != "") { predxCount = 3; }
            if (a.pdx4.Text != "") { predxCount = 4; }

            if (predxCount == 1)
            {
                this.predx1txt.Text = a.pdx1.Text;

            }
            if (predxCount == 2)
            {
                this.predx1txt.Text = a.pdx1.Text + ", " + a.pdx2.Text;

            }
            if (predxCount == 3)
            {
                this.predx1txt.Text = a.pdx1.Text + ", " + a.pdx2.Text + ", " + a.pdx3.Text;
                predx1txt.Font = new Font("Roboto", 8f, FontStyle.Regular);
                predx1txt.Location = new Point(predx1txt.Location.X, predx1txt.Location.Y);

            }
            if (predxCount == 4)
            {
                this.predx1txt.Text = a.pdx1.Text + ", " + a.pdx2.Text + ", " + a.pdx3.Text + ", " + a.pdx4.Text;
                predx1txt.Font = new Font("Roboto", 8f, FontStyle.Regular);
                predx1txt.Location = new Point(predx1txt.Location.X, predx1txt.Location.Y);
            }

            this.cnursetxt.Text = "";

            this.cnursetxt.Text = a.infocnurse.Text;
            int check = 0;
            this.inttxt.Text = "";
            this.inttxt.Text = a.infoinstrument.Text;
            if (this.inttxt.Text != "") { check++; }
            if (a.in2.Text != "")
            {
                if (check > 0) { inttxt.Text += ", "; }
                inttxt.Text += a.in2.Text;
            }
            this.Inditxt.Text = "";
            this.Inditxt.Text = a.indication.Text;
            this.medtxt.Text = "";

            if (c.f1btn.BackColor == Color.Black)
            {

                this.f1.Text = "N/A";
                this.f1.ForeColor = Color.Black;
            }
            else
            {
                if (c.f1btn2.BackColor == Color.Green)
                {
                    this.f1.Text = "Normal";
                    this.f1.ForeColor = Color.Green;
                }
                else
                {
                    this.f1.Text = c.f1txt.Text;
                    this.f1.ForeColor = Color.DarkRed;
                }
            }


            if (c.f2btn.BackColor == Color.Black)
            {

                this.f2.Text = "N/A";
                this.f2.ForeColor = Color.Black;
            }
            else
            {
                if (c.f2btn2.BackColor == Color.Green)
                {
                    this.f2.Text = "Normal";
                    this.f2.ForeColor = Color.Green;
                }
                else
                {
                    this.f2.Text = c.f2txt.Text;
                    this.f2.ForeColor = Color.DarkRed;
                }
            }


            if (c.f3btn.BackColor == Color.Black)
            {

                this.f3.Text = "N/A";
                this.f3.ForeColor = Color.Black;
            }
            else
            {
                if (c.f3btn2.BackColor == Color.Green)
                {
                    this.f3.Text = "Normal";
                    this.f3.ForeColor = Color.Green;
                }
                else
                {
                    this.f3.Text = c.f3txt.Text;
                    this.f3.ForeColor = Color.DarkRed;
                }
            }

            if (c.f4btn.BackColor == Color.Black)
            {

                this.f4.Text = "N/A";
                this.f4.ForeColor = Color.Black;
            }
            else
            {
                if (c.f4btn2.BackColor == Color.Green)
                {
                    this.f4.Text = "Normal";
                    this.f4.ForeColor = Color.Green;
                }
                else
                {
                    this.f4.Text = c.f4txt.Text;
                    this.f4.ForeColor = Color.DarkRed;
                }
            }


            if (c.f5btn.BackColor == Color.Black)
            {

                this.f5.Text = "N/A";
                this.f5.ForeColor = Color.Black;
            }
            else
            {
                if (c.f5btn2.BackColor == Color.Green)
                {
                    this.f5.Text = "Normal";
                    this.f5.ForeColor = Color.Green;
                }
                else
                {
                    this.f5.Text = c.f5txt.Text;
                    this.f5.ForeColor = Color.DarkRed;
                }
            }

            if (c.f6btn.BackColor == Color.Black)
            {

                this.f6.Text = "N/A";
                this.f6.ForeColor = Color.Black;
            }
            else
            {
                if (c.f6btn2.BackColor == Color.Green)
                {
                    this.f6.Text = "Normal";
                    this.f6.ForeColor = Color.Green;
                }
                else
                {
                    this.f6.Text = c.f6txt.Text;
                    this.f6.ForeColor = Color.DarkRed;
                }
            }


            if (c.f7btn.BackColor == Color.Black)
            {

                this.f7.Text = "N/A";
                this.f7.ForeColor = Color.Black;
            }
            else
            {
                if (c.f7btn2.BackColor == Color.Green)
                {
                    this.f7.Text = "Normal";
                    this.f7.ForeColor = Color.Green;
                }
                else
                {
                    this.f7.Text = c.f7txt.Text;
                    this.f7.ForeColor = Color.DarkRed;
                }
            }

            if (c.f8btn.BackColor == Color.Black)
            {

                this.f8.Text = "N/A";
                this.f8.ForeColor = Color.Black;
            }
            else
            {
                if (c.f8btn2.BackColor == Color.Green)
                {
                    this.f8.Text = "Normal";
                    this.f8.ForeColor = Color.Green;
                }
                else
                {
                    this.f8.Text = c.f8txt.Text;
                    this.f8.ForeColor = Color.DarkRed;
                }
            }

            if (c.f9btn.BackColor == Color.Black)
            {

                this.f9.Text = "N/A";
                this.f9.ForeColor = Color.Black;
            }
            else
            {
                if (c.f9btn2.BackColor == Color.Green)
                {
                    this.f9.Text = "Normal";
                    this.f9.ForeColor = Color.Green;
                }
                else
                {
                    this.f9.Text = c.f9txt.Text;
                    this.f9.ForeColor = Color.DarkRed;
                }
            }

            if (c.f10btn.BackColor == Color.Black)
            {

                this.f10.Text = "N/A";
                this.f10.ForeColor = Color.Black;
            }
            else
            {
                if (c.f10btn2.BackColor == Color.Green)
                {
                    this.f10.Text = "Normal";
                    this.f10.ForeColor = Color.Green;
                }
                else
                {
                    this.f10.Text = c.f10txt.Text;
                    this.f10.ForeColor = Color.DarkRed;
                }
            }




            int PostDxCount = 0;

            string spdxtxt = "";
            if (c.dx1.Text != "" || c.pdxtxt1.Text != "") { PostDxCount++; }
            if (c.dx2.Text != "" || c.pdxtxt2.Text != "") { PostDxCount++; }
            if (c.dx3.Text != "" || c.pdxtxt3.Text != "") { PostDxCount++; }
            if (c.dx4.Text != "" || c.pdxtxt4.Text != "") { PostDxCount++; }
            if (PostDxCount > 2)
            {
                postdx1.Font = new Font("Roboto", 10f, FontStyle.Regular);
                postdx1.Location = new Point(postdx1.Location.X, postdx1.Location.Y + 5);

                //3
                if (c.dx1.Text != "") { spdxtxt += c.dx1.Text + "-"; }
                spdxtxt += c.pdxtxt1.Text;
                spdxtxt += ", ";
                if (c.dx2.Text != "") { spdxtxt += c.dx2.Text + "-"; }
                spdxtxt += c.pdxtxt2.Text;
                spdxtxt += ", ";
                if (c.dx3.Text != "") { spdxtxt += c.dx3.Text + "-"; }
                spdxtxt += c.pdxtxt3.Text;



                if (PostDxCount > 3)
                {
                    spdxtxt += ", ";
                    if (c.dx4.Text != "") { spdxtxt += c.dx4.Text + "-"; }
                    spdxtxt += c.pdxtxt4.Text;


                }
            }
            else
            {
                if (PostDxCount > 0)
                {
                    //1

                    if (c.dx1.Text != "") { spdxtxt += c.dx1.Text + "-"; }
                    spdxtxt += c.pdxtxt1.Text;
                    if (PostDxCount > 1)
                    {
                        //2
                        spdxtxt += ", ";
                        if (c.dx2.Text != "") { spdxtxt += c.dx2.Text + "-"; }
                        spdxtxt += c.pdxtxt2.Text;
                    }
                }

            }
            PostDxCount = 0;
            this.postdx1.Text = spdxtxt;

            string histxt = "";
            if (c.his1.Checked == true) { if (histxt != "") { histxt += ", "; } histxt += c.his1.Text; }
            if (c.his2.Checked == true) { if (histxt != "") { histxt += ", "; } histxt += c.his2.Text; }
            if (c.his3.Checked == true) { if (histxt != "") { histxt += ", "; } histxt += c.his3.Text; }
            if (c.his4.Checked == true) { if (histxt != "") { histxt += ", "; } histxt += c.his4.Text + " " + c.his4txt.Text; }
            this.his.Text = histxt;

            if (c.rap1.Checked == true) { rap1.Checked = true; }
            if (c.rap2.Checked == true) { rap2.Checked = true; }

            note.Text = c.note.Text;


            string comtxt = "";
            if (c.c1.Checked == true) { if (comtxt != "") { comtxt += ", "; } comtxt += c.c1.Text; }
            if (c.c2.Checked == true) { if (comtxt != "") { comtxt += ", "; } comtxt += c.c2.Text; }
            if (c.c3.Checked == true) { if (comtxt != "") { comtxt += ", "; } comtxt += c.c3.Text + " " + c.c3txtl.Text + " " + c.c3txt.Text; }
            if (c.c4.Checked == true) { if (comtxt != "") { comtxt += ", "; } comtxt += c.c4txt.Text; }

            com.Text = comtxt;

            string atxt = "";
            if (c.a1.Checked == true) { if (atxt != "") { atxt += ", "; } atxt += c.a1.Text; }
            if (c.a2.Checked == true) { if (atxt != "") { atxt += ", "; } atxt += c.a2.Text; }
            if (c.a3.Checked == true) { if (atxt != "") { atxt += ", "; } atxt += c.a3.Text; }
            if (c.a4.Checked == true) { if (atxt != "") { atxt += ", "; } atxt += c.a4.Text; }
            if (c.a5.Checked == true) { if (atxt != "") { atxt += ", "; } atxt += c.a5txt.Text; }
            anestxt.Text = atxt;


            string mtxt = "";
            if (c.med1.Checked == true) { if (mtxt != "") { mtxt += ", "; } mtxt += c.med1.Text + " " + c.med1txt.Text + " mg"; }
            if (c.med2.Checked == true) { if (mtxt != "") { mtxt += ", "; } mtxt += c.med2.Text + " " + c.med2txt.Text + " mg"; }
            if (c.med3.Checked == true) { if (mtxt != "") { mtxt += ", "; } mtxt += c.med3.Text + " " + c.med3txt.Text + " mg"; }
            if (c.med4.Checked == true) { if (mtxt != "") { mtxt += ", "; } mtxt += c.med4.Text + " " + c.med4txt.Text + " mg"; }
            if (c.med5.Checked == true) { if (mtxt != "") { mtxt += ", "; } mtxt += c.med5.Text + " " + c.med5txt.Text + " mcg"; }
            if (c.med6.Checked == true) { if (mtxt != "") { mtxt += ", "; } mtxt += c.med6txt.Text + " mg"; }
            medtxt.Text = mtxt;



            string ptxt = "";
            if (c.pg1.Checked == true) { if (ptxt != "") { ptxt += ", "; } ptxt += c.pg1.Text; }
            if (c.pg2.Checked == true) { if (ptxt != "") { ptxt += ", "; } ptxt += c.pg2.Text; }
            if (c.pg3.Checked == true) { if (ptxt != "") { ptxt += ", "; } ptxt += c.pg3.Text; }
            if (c.pg4.Checked == true) { if (ptxt != "") { ptxt += ", "; } ptxt += c.pg4.Text; }
            if (c.pg5.Checked == true) { if (ptxt != "") { ptxt += ", "; } ptxt += c.pg5.Text; }
            if (c.pg6.Checked == true) { if (ptxt != "") { ptxt += ", "; } ptxt += c.pg6.Text; }
            if (c.pg7.Checked == true) { if (ptxt != "") { ptxt += ", "; } ptxt += c.pg7.Text; }
            if (c.pg8.Checked == true) { if (ptxt != "") { ptxt += ", "; } ptxt += c.pg8.Text; }
            if (c.pg9.Checked == true) { if (ptxt != "") { ptxt += ", "; } ptxt += c.pg9.Text; }
            if (c.pg10.Checked == true) { if (ptxt != "") { ptxt += ", "; } ptxt += c.pg10.Text; }
            if (c.pg11.Checked == true) { if (ptxt != "") { ptxt += ", "; } ptxt += c.pg11.Text; }
            if (c.pg12.Checked == true) { if (ptxt != "") { ptxt += ", "; } ptxt += c.pg12.Text; }
            if (c.pg13.Checked == true) { if (ptxt != "") { ptxt += ", "; } ptxt += c.pg13.Text; }
            if (c.pg14.Checked == true) { if (ptxt != "") { ptxt += ", "; } ptxt += c.pg14.Text; }
            if (c.pg15.Checked == true) { if (ptxt != "") { ptxt += ", "; } ptxt += c.pg15.Text; }
            if (c.pg16.Checked == true) { if (ptxt != "") { ptxt += ", "; } ptxt += c.pg16.Text; }
            if (c.pg17.Checked == true) { if (ptxt != "") { ptxt += ", "; } ptxt += c.pg17.Text; }
            if (c.pg18.Checked == true) { if (ptxt != "") { ptxt += ", "; } ptxt += c.pg18.Text; }
            if (c.pg19.Checked == true) { if (ptxt != "") { ptxt += ", "; } ptxt += c.pg19.Text; }
            if (c.pg20.Checked == true) { if (ptxt != "") { ptxt += ", "; } ptxt += c.pg20.Text; }
            if (c.pg21.Checked == true) { if (ptxt != "") { ptxt += ", "; } ptxt += c.pg21.Text; }
            if (c.pg22.Checked == true) { if (ptxt != "") { ptxt += ", "; } ptxt += c.pg22.Text; }
            if (c.pg23.Checked == true) { if (ptxt != "") { ptxt += ", "; } ptxt += c.pg23.Text; }
            if (c.pg24.Checked == true) { if (ptxt != "") { ptxt += ", "; } ptxt += c.pg24.Text; }
            if (c.pg25.Checked == true) { if (ptxt != "") { ptxt += ", "; } ptxt += c.pgtxtbox.Text; }
            prolabel.Text = ptxt;

            int i = 0;
            //  int c = b.imgCount;



            for (int e = 0; e < b.imgCount; e++)
            {
                if (b.imgPath[i] != null)
                {
                    if (b.imgPath[i].Contains("COL") == true)
                    {
                        i++;
                    }
                }

            }
            for (int z = 0; z < 8; z++)
            {
                boxes[z].Visible = false;
                cBoxes[z].Visible = false;
            }
            int imgperpage;

            if (i < 8) { imgperpage = i; } else { imgperpage = 8; }
            for (int z = 0; z < imgperpage; z++)
            {
                boxes[z].Visible = true;
                boxes[z].Image = b.boxes[z].Image;
                cBoxes[z].Text = b.cBoxes[z].Text;
                cBoxes[z].Visible = true;
                mtb[z].Visible = true;

            }



            bh.Text = c.commentText.Text;
            recom.Text = "";
            blood.Text = "";
            if (c.b1txt.Text != "")
            {
                blood.Text = c.b1txt.Text + " mg";
            }

            string retxt = "";
            if (c.r1.Checked == true) { if (retxt != "") { retxt += ", "; } retxt += c.r1.Text; }
            if (c.r2.Checked == true) { if (retxt != "") { retxt += ", "; } retxt += c.r2.Text; }
            if (c.r3.Checked == true) { if (retxt != "") { retxt += ", "; } retxt += c.r3.Text; }
            if (c.r4.Checked == true) { if (retxt != "") { retxt += ", "; } retxt += c.r4.Text + " " + c.r42.Text + " within " + c.r43.Text; }
            recom.Text = retxt;








            foreach (var txt in text)
            {
                changeFont(txt);
            }
        }



        public System.Drawing.Font formFont;
        public float fontSize = (float)8.25;
        public int iWidth = 300;
        public int iHeight = 300;

        public void zoom()
        {
            SizeF a = new SizeF(1.5f, 1.5f);
            this.Scale(a);

            formFont = new Font("Microsoft Sans Serif", 22);
            edo.Font = formFont;


        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void output_Load(object sender, EventArgs e)
        {

        }

        private void pro_Click(object sender, EventArgs e)
        {

        }

        private void l1_Click(object sender, EventArgs e)
        {

        }
        public string getpdxcode(string a)
        {
            int index = a.IndexOf("-");
            if (index > 0)
                a = a.Substring(0, index);
            return a;
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
