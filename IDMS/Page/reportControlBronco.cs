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
using IDMS.DataManage;

namespace IDMS.Page
{
    public partial class reportControlBronco : UserControl
    {
        string cid;
        public reportControlBronco(string caseid)
        {
            InitializeComponent();

            //top
            DataAccess Load = new DataAccess();
            string reportType = Load.getOption("option_value", "reportType");
            string indicationValue = Load.getValueWithTableName(caseid, "patientcase", "Indication");
            if (reportType == "2")
            {
                label22.Text = "Indication";
                commentText.Text = indicationValue;
            }
            //

            this.f1list.MouseUp += new System.Windows.Forms.MouseEventHandler(this.List_RightClick);
            this.f2list.MouseUp += new System.Windows.Forms.MouseEventHandler(this.List_RightClick);
            this.f3list.MouseUp += new System.Windows.Forms.MouseEventHandler(this.List_RightClick);
            this.f4list.MouseUp += new System.Windows.Forms.MouseEventHandler(this.List_RightClick);
            this.f5list.MouseUp += new System.Windows.Forms.MouseEventHandler(this.List_RightClick);
            this.f6list.MouseUp += new System.Windows.Forms.MouseEventHandler(this.List_RightClick);
            this.f7list.MouseUp += new System.Windows.Forms.MouseEventHandler(this.List_RightClick);
            this.f8list.MouseUp += new System.Windows.Forms.MouseEventHandler(this.List_RightClick);
            this.f9list.MouseUp += new System.Windows.Forms.MouseEventHandler(this.List_RightClick);
            this.f10list.MouseUp += new System.Windows.Forms.MouseEventHandler(this.List_RightClick);
            this.f11list.MouseUp += new System.Windows.Forms.MouseEventHandler(this.List_RightClick);
            this.f12list.MouseUp += new System.Windows.Forms.MouseEventHandler(this.List_RightClick);
        }







        private void f1btn_Click(object sender, EventArgs e)
        {
            setbuttonB(1, f1btn, f1btn2, f1btn3, f1txt, f1list);

        }



        private void med1_CheckedChanged(object sender, EventArgs e)
        {
            if (med1.Checked)
            {
                med1txt.Visible = true;
                med1l.Visible = true;
            }
            else
            {
                med1txt.Visible = false;
                med1l.Visible = false;
                med1txt.Clear();
            }
        }

        private void med2_CheckedChanged(object sender, EventArgs e)
        {
            if (med2.Checked)
            {
                med2txt.Visible = true;
                med2l.Visible = true;
            }
            else
            {
                med2txt.Visible = false;
                med2l.Visible = false;
                med2txt.Clear();

            }
        }

        private void med3_CheckedChanged(object sender, EventArgs e)
        {
            if (med3.Checked)
            {
                med3txt.Visible = true;
                med3l.Visible = true;
            }
            else
            {
                med3txt.Visible = false;
                med3l.Visible = false;
                med3txt.Clear();
            }
        }

        private void med4_CheckedChanged(object sender, EventArgs e)
        {
            if (med4.Checked)
            {
                med4txt.Visible = true;
                med4l.Visible = true;
            }
            else
            {
                med4txt.Visible = false;
                med4l.Visible = false;
                med4txt.Clear();
            }
        }

        private void med5_CheckedChanged(object sender, EventArgs e)
        {
            if (med5.Checked)
            {
                med5txt.Visible = true;
                med5l.Visible = true;
            }
            else
            {
                med5txt.Visible = false;
                med5l.Visible = false;
                med5txt.Clear();
            }
        }

        private void med6_CheckedChanged(object sender, EventArgs e)
        {
            if (med6.Checked)
            {
                med6txt.Visible = true;

            }
            else
            {
                med6txt.Visible = false;

                med6txt.Clear();

            }
        }

        private void anes5_CheckedChanged(object sender, EventArgs e)
        {
            if (ro4.Checked)
            {
                ro4txt.Visible = true;

            }
            else
            {
                ro4txt.Visible = false;
                ro4txt.Clear();

            }
        }

       

        private void c4_CheckedChanged(object sender, EventArgs e)
        {
            if (c4.Checked)
            {
                b1txt.Visible = true;
            }
            else
            {
                b1txt.Visible = false;
                b1txt.Clear();

            }
        }

        private void c5_CheckedChanged(object sender, EventArgs e)
        {
            if (c4.Checked)
            {
                c4txt.Visible = true;

            }
            else
            {
                c4txt.Visible = false;
                c4txt.Clear();

            }
        }



        private string getmedData()
        {
            using (medTable_Template2 formOptions = new medTable_Template2())
            {
                formOptions.ShowDialog();

                string result = formOptions.GetMyResult();
                medid = formOptions.GetMyResultID();
                return result;

            }
        }
        string medid;

        private void f12txt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            multilist(f12txt, f12list);
        }
        private void f11txt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            multilist(f11txt, f11list);
        }
        private void f10txt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            multilist(f10txt, f10list);
        }

        private void f9txt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            multilist(f9txt, f9list);
        }

        private void f8txt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            multilist(f8txt, f8list);

        }

        private void f7txt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            multilist(f7txt, f7list);

        }

        private void f6txt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            multilist(f6txt, f6list);

        }

        private void f5txt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            multilist(f5txt, f5list);

        }

        private void f4txt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            multilist(f4txt, f4list);

        }

        private void f3txt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            multilist(f3txt, f3list);

        }

        private void f2txt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            multilist(f2txt, f2list);

        }

        private void f1txt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            multilist(f1txt, f1list);

        }

        private void multilist(TextBox a, ListBox b)
        {
            if (b.Visible == false)
            {
                b.Visible = true;
            }
            else
            {

                a.Text = "";
                int i = 0;
                foreach (int list in b.SelectedIndices)
                {

                    if (i > 0)
                    {
                        a.Text += ", ";
                    }
                    a.Text += b.Items[list].ToString();

                    i++;
                }
                b.Visible = false;
                a.SelectionStart = a.Text.Length;


            }

        }





        private void List_RightClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                if (sender == f1list)
                {
                    multilist(f1txt, f1list);


                }

                if (sender == f2list)
                {
                    multilist(f2txt, f2list);
                }
                if (sender == f3list)
                {
                    multilist(f3txt, f3list);
                }
                if (sender == f4list)
                {
                    multilist(f4txt, f4list);
                }
                if (sender == f5list)
                {
                    multilist(f5txt, f5list);
                }
                if (sender == f6list)
                {
                    multilist(f6txt, f6list);
                }
                if (sender == f7list)
                {
                    multilist(f7txt, f7list);
                }
                if (sender == f8list)
                {
                    multilist(f8txt, f8list);
                }
                if (sender == f9list)
                {
                    multilist(f9txt, f9list);
                }
                if (sender == f10list)
                {
                    multilist(f10txt, f10list);
                }
                if (sender == f11list)
                {
                    multilist(f11txt, f11list);
                }
                if (sender == f12list)
                {
                    multilist(f12txt, f12list);
                }
            }

        }

      

        private void f1btn2_Click(object sender, EventArgs e)
        {
            setbuttonB(2, f1btn, f1btn2, f1btn3, f1txt, f1list);
        }

        private void f1btn3_Click(object sender, EventArgs e)
        {
            setbuttonB(3, f1btn, f1btn2, f1btn3, f1txt, f1list);

        }


        private void setbuttonB(int a0, Button a1, Button a2, Button a3, TextBox b, ListBox c)
        {
            //b.Text = "";
            c.ClearSelected();
            switch (a0)
            {//NA
                case 1:
                    a1.BackColor = Color.Black;
                    a2.BackColor = Color.LightGray;
                    a3.BackColor = Color.LightGray;

                    a1.ForeColor = Color.White;
                    a2.ForeColor = Color.Black;
                    a3.ForeColor = Color.Black;

                    a1.FlatAppearance.BorderColor = Color.DimGray;
                    a2.FlatAppearance.BorderColor = Color.Silver;
                    a3.FlatAppearance.BorderColor = Color.Silver;
                    b.Visible = false;
                    c.Visible = false;
                    //   b.Enabled = false;
                    //  b.Visible = true;
                    break;
                case 2:
                    //NORMAL
                    a1.BackColor = Color.LightGray;
                    a2.BackColor = Color.Green;
                    a3.BackColor = Color.LightGray;

                    a1.ForeColor = Color.Black;
                    a2.ForeColor = Color.White;
                    a3.ForeColor = Color.Black;

                    a1.FlatAppearance.BorderColor = Color.Silver;
                    a2.FlatAppearance.BorderColor = Color.DarkGreen;
                    a3.FlatAppearance.BorderColor = Color.Silver;
                    //  b.Visible = false;
                    //  b.Enabled = false;
                    b.Visible = true;
                    c.Visible = false;

                    break;
                case 3:
                    a1.BackColor = Color.LightGray;
                    a2.BackColor = Color.LightGray;
                    a3.BackColor = Color.Red;


                    a1.ForeColor = Color.Black;
                    a2.ForeColor = Color.Black;
                    a3.ForeColor = Color.White;

                    a1.FlatAppearance.BorderColor = Color.Silver;
                    a2.FlatAppearance.BorderColor = Color.Silver;
                    a3.FlatAppearance.BorderColor = Color.DarkRed;
                    b.Visible = true;
                    // b.Enabled = true;
                    c.Visible = false;


                    break;
            }

        }

        private void f2btn_Click_1(object sender, EventArgs e)
        {
            setbuttonB(1, f2btn, f2btn2, f2btn3, f2txt, f2list);
        }

        private void f2btn2_Click(object sender, EventArgs e)
        {
            setbuttonB(2, f2btn, f2btn2, f2btn3, f2txt, f2list);
        }

        private void f2btn3_Click(object sender, EventArgs e)
        {
            setbuttonB(3, f2btn, f2btn2, f2btn3, f2txt, f2list);
        }

        private void f3btn_Click_1(object sender, EventArgs e)
        {
            setbuttonB(1, f3btn, f3btn2, f3btn3, f3txt, f3list);
        }

        private void f3btn2_Click(object sender, EventArgs e)
        {
            setbuttonB(2, f3btn, f3btn2, f3btn3, f3txt, f3list);
        }

        private void f3btn3_Click(object sender, EventArgs e)
        {
            setbuttonB(3, f3btn, f3btn2, f3btn3, f3txt, f3list);
        }

        private void f4btn_Click_1(object sender, EventArgs e)
        {
            setbuttonB(1, f4btn, f4btn2, f4btn3, f4txt, f4list);
        }

        private void f4btn2_Click(object sender, EventArgs e)
        {
            setbuttonB(2, f4btn, f4btn2, f4btn3, f4txt, f4list);
        }

        private void f4btn3_Click(object sender, EventArgs e)
        {
            setbuttonB(3, f4btn, f4btn2, f4btn3, f4txt, f4list);
        }

        private void f5btn_Click_1(object sender, EventArgs e)
        {
            setbuttonB(1, f5btn, f5btn2, f5btn3, f5txt, f5list);
        }

        private void f5btn2_Click(object sender, EventArgs e)
        {
            setbuttonB(2, f5btn, f5btn2, f5btn3, f5txt, f5list);

        }

        private void f5btn3_Click(object sender, EventArgs e)
        {
            setbuttonB(3, f5btn, f5btn2, f5btn3, f5txt, f5list);

        }

        private void f6btn_Click_1(object sender, EventArgs e)
        {
            setbuttonB(1, f6btn, f6btn2, f6btn3, f6txt, f6list);

        }

        private void f6btn2_Click(object sender, EventArgs e)
        {
            setbuttonB(2, f6btn, f6btn2, f6btn3, f6txt, f6list);

        }

        private void f6btn3_Click(object sender, EventArgs e)
        {
            setbuttonB(3, f6btn, f6btn2, f6btn3, f6txt, f6list);

        }

        private void f7btn_Click_1(object sender, EventArgs e)
        {
            setbuttonB(1, f7btn, f7btn2, f7btn3, f7txt, f7list);
        }

        private void f7btn2_Click(object sender, EventArgs e)
        {
            setbuttonB(2, f7btn, f7btn2, f7btn3, f7txt, f7list);

        }

        private void f7btn3_Click(object sender, EventArgs e)
        {
            setbuttonB(3, f7btn, f7btn2, f7btn3, f7txt, f7list);

        }

        private void f8btn_Click_1(object sender, EventArgs e)
        {
            setbuttonB(1, f8btn, f8btn2, f8btn3, f8txt, f8list);

        }

        private void f8btn2_Click(object sender, EventArgs e)
        {
            setbuttonB(2, f8btn, f8btn2, f8btn3, f8txt, f8list);

        }

        private void f8btn3_Click(object sender, EventArgs e)
        {
            setbuttonB(3, f8btn, f8btn2, f8btn3, f8txt, f8list);

        }

        private void f9btn_Click_1(object sender, EventArgs e)
        {
            setbuttonB(1, f9btn, f9btn2, f9btn3, f9txt, f9list);

        }

        private void f9btn2_Click(object sender, EventArgs e)
        {
            setbuttonB(2, f9btn, f9btn2, f9btn3, f9txt, f9list);

        }

        private void f9btn3_Click(object sender, EventArgs e)
        {
            setbuttonB(3, f9btn, f9btn2, f9btn3, f9txt, f9list);

        }

        private void f10btn_Click_1(object sender, EventArgs e)
        {
            setbuttonB(1, f10btn, f10btn2, f10btn3, f10txt, f10list);

        }

        private void f10btn2_Click(object sender, EventArgs e)
        {
            setbuttonB(2, f10btn, f10btn2, f10btn3, f10txt, f10list);

        }

        private void f10btn3_Click(object sender, EventArgs e)
        {
            setbuttonB(3, f10btn, f10btn2, f10btn3, f10txt, f10list);

        }

        private void f11btn_Click(object sender, EventArgs e)
        {
            setbuttonB(1, f11btn, f11btn2, f11btn3, f11txt, f11list);
        }

        private void f11btn2_Click(object sender, EventArgs e)
        {
            setbuttonB(2, f11btn, f11btn2, f11btn3, f11txt, f11list);
        }

        private void f11btn3_Click(object sender, EventArgs e)
        {
            setbuttonB(3, f11btn, f11btn2, f11btn3, f11txt, f11list);
        }
        private void f12btn_Click(object sender, EventArgs e)
        {
            setbuttonB(1, f12btn, f12btn2, f12btn3, f12txt, f12list);
        }

        private void f12btn2_Click(object sender, EventArgs e)
        {
            setbuttonB(2, f12btn, f12btn2, f12btn3, f12txt, f12list);
        }

        private void f12btn3_Click(object sender, EventArgs e)
        {
            setbuttonB(3, f12btn, f12btn2, f12btn3, f12txt, f12list);
        }
        private void a5txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

       

        DataAccess save = new DataAccess();

        private void save_CheckedChanged(object sender, EventArgs e)
        {
            /*
            CheckBox checkbox = (CheckBox)sender;
            if (checkbox.Checked == true)
            {
              save.addReportField(cid, "T", checkbox.Name);
            }
            else
            {
                save.addReportField(cid, "F", checkbox.Name);
            }
            */
        }




        private void savetext_CheckedChanged(object sender, EventArgs e)
        {
            /*
            TextBox txtbox = (TextBox)sender;
            CheckBox a = new CheckBox();
            string txtname = "";
            if(txtbox.Name == "pgtxtbox") { a = pg25; }
            if (txtbox.Name == "c3txt") { a = c3; } 
            if (txtbox.Name == "c4txt") { a = c4; }
            if (txtbox.Name == "his4txt") { a = his4; }
             if (txtbox.Name == "r43") { a = r4; txtname = r42.Text + "/" + r43.Text; }
            txtname = txtbox.Text;
            if (a.Checked == true)
            {
                save.addReportField(cid, txtname, a.Name);
            }
            else
            {
                save.addReportField(cid, "", a.Name);
            }
            */
        }

       

        private void savetext_txtChanged(object sender, EventArgs e)
        {
            /*
            TextBox txtbox = (TextBox)sender;
            string controlName = "";
            string txtname = txtbox.Text;
            

            if (txtbox.Name == "note") { controlName = "comment"; }
            if (txtbox.Name == "b1txt") { controlName = "bloodloss"; }
            save.addReportField(cid, txtname, controlName);
           */
        }

        private void ReportControl_Load(object sender, EventArgs e)
        {

        }

        private void his4btn_Click(object sender, EventArgs e)
        {

        }

       

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox38_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}



