using IDMS.Page;
using IDMS.ReportContent;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDMS.DataManage
{
    class manageReportCOL
    {

        public void saveReportField(UserControl reportcon, string caseid, UserControl inforeport)
        {
            reportControlColono report = (reportControlColono)reportcon;
            Report info = (Report)inforeport;

            DataAccess save = new DataAccess();

            //top
            string reportType = save.getOption("option_value", "reportType");
            if (reportType == "2") { save.updatePatientCase(caseid, "Indication", report.commentText.Text); }

            string state1 = ""; string state2 = ""; string state3 = ""; string state4 = ""; string state5 = ""; string state6 = ""; string state7 = ""; string state8 = ""; string state9 = ""; string state10 = "";

            if (report.f1btn.BackColor == Color.Black) { state1 = "NA"; }
            else
            {
                if (report.f1btn2.BackColor == Color.Green) { state1 = "NORMAL"; }
                else
                {
                    if (report.f1btn3.BackColor == Color.Red) { state1 = "ABNORMAL"; }
                }
            }

            if (report.f2btn.BackColor == Color.Black) { state2 = "NA"; }
            else
            {
                if (report.f2btn2.BackColor == Color.Green) { state2 = "NORMAL"; }
                else
                {
                    if (report.f2btn3.BackColor == Color.Red) { state2 = "ABNORMAL"; }
                }
            }

            if (report.f3btn.BackColor == Color.Black) { state3 = "NA"; }
            else
            {
                if (report.f3btn2.BackColor == Color.Green) { state3 = "NORMAL"; }
                else
                {
                    if (report.f3btn3.BackColor == Color.Red) { state3 = "ABNORMAL"; }
                }
            }

            if (report.f4btn.BackColor == Color.Black) { state4 = "NA"; }
            else
            {
                if (report.f4btn2.BackColor == Color.Green) { state4 = "NORMAL"; }
                else
                {
                    if (report.f4btn3.BackColor == Color.Red) { state4 = "ABNORMAL"; }
                }
            }

            if (report.f5btn.BackColor == Color.Black) { state5 = "NA"; }
            else
            {
                if (report.f5btn2.BackColor == Color.Green) { state5 = "NORMAL"; }
                else
                {
                    if (report.f5btn3.BackColor == Color.Red) { state5 = "ABNORMAL"; }
                }
            }

            if (report.f6btn.BackColor == Color.Black) { state6 = "NA"; }
            else
            {
                if (report.f6btn2.BackColor == Color.Green) { state6 = "NORMAL"; }
                else
                {
                    if (report.f6btn3.BackColor == Color.Red) { state6 = "ABNORMAL"; }
                }
            }

            if (report.f7btn.BackColor == Color.Black) { state7 = "NA"; }
            else
            {
                if (report.f7btn2.BackColor == Color.Green) { state7 = "NORMAL"; }
                else
                {
                    if (report.f7btn3.BackColor == Color.Red) { state7 = "ABNORMAL"; }
                }
            }

            if (report.f8btn.BackColor == Color.Black) { state8 = "NA"; }
            else
            {
                if (report.f8btn2.BackColor == Color.Green) { state8 = "NORMAL"; }
                else
                {
                    if (report.f8btn3.BackColor == Color.Red) { state8 = "ABNORMAL"; }
                }
            }

            if (report.f9btn.BackColor == Color.Black) { state9 = "NA"; }
            else
            {
                if (report.f9btn2.BackColor == Color.Green) { state9 = "NORMAL"; }
                else
                {
                    if (report.f9btn3.BackColor == Color.Red) { state9 = "ABNORMAL"; }
                }
            }

            if (report.f10btn.BackColor == Color.Black) { state10 = "NA"; }
            else
            {
                if (report.f10btn2.BackColor == Color.Green) { state10 = "NORMAL"; }
                else
                {
                    if (report.f10btn3.BackColor == Color.Red) { state10 = "ABNORMAL"; }
                }
            }
            string[] field = { "a1", "a2", "a3", "a4", "a5",
                                "med1", "med2", "med3", "med4", "med5", "med6", "med7",
                                "history", "f1", "f2", "f3", "f4", "f5", "f6", "f7", "f8","f9","f10",
                                "pg1", "pg2", "pg3", "pg4", "pg5", "pg6", "pg7", "pg8", "pg9", "pg10",
                                "pg11", "pg12", "pg13", "pg14", "pg15", "pg16", "pg17", "pg18", "pg19", "pg20",
                                "pg21", "pg22", "pg23","pg24", "pg25", "pg26",
                                "cdx1", "cdx2", "cdx3", "cdx4",
                                "pdx1", "pdx2", "pdx3", "pdx4",
                                "bloodloss" , "c1", "c2", "c3", "c4",
                                "his1", "his2", "his3", "his4",
                                "rap1", "rap2", "r1", "r2", "r3", "r4",
                                "comment",
                                 "sf1", "sf2", "sf3", "sf4", "sf5", "sf6","sf7","sf8","sf9","sf10",
                                "bowelPreparationRegimen","bowelPreparationResult"
        };
            string[] data = {
                report.a1.Checked.ToString(),
                report.a2.Checked.ToString(),
                report.a3.Checked.ToString(),
                report.a4.Checked.ToString(),
                report.a5txt.Text,
                report.med1txt.Text,
                report.med2txt.Text,
                report.med3txt.Text,
                report.med4txt.Text,
                report.med5txt.Text,
                report.med6txt.Text,
                report.med7txt.Text,
                report.commentText.Text,
                report.f1txt.Text,
                report.f2txt.Text,
                report.f3txt.Text,
                report.f4txt.Text,
                report.f5txt.Text,
                report.f6txt.Text,
                report.f7txt.Text,
                report.f8txt.Text,
                report.f9txt.Text,
                report.f10txt.Text,
                report.pg1.Checked.ToString(),
                report.pg2.Checked.ToString(),
                report.pg3.Checked.ToString(),
                report.pg4.Checked.ToString(),
                report.pg5.Checked.ToString(),
                report.pg6.Checked.ToString(),
                report.pg7.Checked.ToString(),
                report.pg8.Checked.ToString(),
                report.pg9.Checked.ToString(),
                report.pg10.Checked.ToString(),
                report.pg11.Checked.ToString(),
                report.pg12.Checked.ToString(),
                report.pg13.Checked.ToString(),
                report.pg14.Checked.ToString(),
                report.pg15.Checked.ToString(),
                report.pg16.Checked.ToString(),
                report.pg17.Checked.ToString(),
                report.pg18.Checked.ToString(),
                report.pg19.Checked.ToString(),
                report.pg20.Checked.ToString(),
                report.pg21.Checked.ToString(),
                report.pg22.Checked.ToString(),
                report.pg23.Checked.ToString(),
                report.pg24.Checked.ToString(),
                report.pgtxtbox.Text,
                report.pgtxtbox2.Text,
                report.dx1.Text,
                report.dx2.Text,
                report.dx3.Text,
                report.dx4.Text,
                report.pdxtxt1.Text,
                report.pdxtxt2.Text,
                report.pdxtxt3.Text,
                report.pdxtxt4.Text,
                report.b1txt.Text,
                report.c1.Checked.ToString(),
                report.c2.Checked.ToString(),
                report.c3txt.Text,
                report.c4txt.Text,
                report.his1.Checked.ToString(),
                report.his2.Checked.ToString(),
                report.his3.Checked.ToString(),
                report.his4txt.Text,
                report.rap1.Checked.ToString(),
                report.rap2.Checked.ToString(),
                report.r1.Checked.ToString(),
                report.r2.Checked.ToString(),
                report.r3.Checked.ToString(),
                report.r42.Text + "/" + report.r43.Text,
                report.note.Text,
                state1,
                state2,
                state3,
                state4,
                state5,
                state6,
                state7,
                state8,
                state9,
                state10,
                report.bowelPreparationRegimenValue.Text,
                report.bowelPreparationResultValue.Text,
        };
            save.addReportFieldnew(caseid, data, field);
            /*
                        save.addReportField(caseid, report.a1.Checked.ToString(), "a1");
                        save.addReportField(caseid, report.a2.Checked.ToString(), "a2");
                        save.addReportField(caseid, report.a3.Checked.ToString(), "a3");
                        save.addReportField(caseid, report.a4.Checked.ToString(), "a4");
                        save.addReportField(caseid, report.a5txt.Text, "a5");

                        //
                        save.addReportField(caseid, report.med1txt.Text, "med1");
                        save.addReportField(caseid, report.med2txt.Text, "med2");
                        save.addReportField(caseid, report.med3txt.Text, "med3");
                        save.addReportField(caseid, report.med4txt.Text, "med4");
                        save.addReportField(caseid, report.med5txt.Text, "med5");
                        save.addReportField(caseid, report.med6txt.Text, "med6");
                        save.addReportField(caseid, report.med7txt.Text, "med7");

                        //
                        save.addReportField(caseid, report.commentText.Text, "history");
                        //finding
                        save.addReportField(caseid, report.f1txt.Text, "f1");
                        save.addReportField(caseid, report.f2txt.Text, "f2");
                        save.addReportField(caseid, report.f3txt.Text, "f3");
                        save.addReportField(caseid, report.f4txt.Text, "f4");
                        save.addReportField(caseid, report.f5txt.Text, "f5");
                        save.addReportField(caseid, report.f6txt.Text, "f6");
                        save.addReportField(caseid, report.f7txt.Text, "f7");
                        save.addReportField(caseid, report.f8txt.Text, "f8");
                        save.addReportField(caseid, report.f9txt.Text, "f9");
                        save.addReportField(caseid, report.f10txt.Text, "f10");

                        //pg1-25
                        save.addReportField(caseid, report.pg1.Checked.ToString(), "pg1");
                        save.addReportField(caseid, report.pg2.Checked.ToString(), "pg2");
                        save.addReportField(caseid, report.pg3.Checked.ToString(), "pg3");
                        save.addReportField(caseid, report.pg4.Checked.ToString(), "pg4");
                        save.addReportField(caseid, report.pg5.Checked.ToString(), "pg5");
                        save.addReportField(caseid, report.pg6.Checked.ToString(), "pg6");
                        save.addReportField(caseid, report.pg7.Checked.ToString(), "pg7");
                        save.addReportField(caseid, report.pg8.Checked.ToString(), "pg8");
                        save.addReportField(caseid, report.pg9.Checked.ToString(), "pg9");
                        save.addReportField(caseid, report.pg10.Checked.ToString(), "pg10");
                        save.addReportField(caseid, report.pg11.Checked.ToString(), "pg11");
                        save.addReportField(caseid, report.pg12.Checked.ToString(), "pg12");
                        save.addReportField(caseid, report.pg13.Checked.ToString(), "pg13");
                        save.addReportField(caseid, report.pg14.Checked.ToString(), "pg14");
                        save.addReportField(caseid, report.pg15.Checked.ToString(), "pg15");
                        save.addReportField(caseid, report.pg16.Checked.ToString(), "pg16");
                        save.addReportField(caseid, report.pg17.Checked.ToString(), "pg17");
                        save.addReportField(caseid, report.pg18.Checked.ToString(), "pg18");
                        save.addReportField(caseid, report.pg19.Checked.ToString(), "pg19");
                        save.addReportField(caseid, report.pg20.Checked.ToString(), "pg20");
                        save.addReportField(caseid, report.pg21.Checked.ToString(), "pg21");
                        save.addReportField(caseid, report.pg22.Checked.ToString(), "pg22");
                        save.addReportField(caseid, report.pg23.Checked.ToString(), "pg23");
                        save.addReportField(caseid, report.pg24.Checked.ToString(), "pg24");
                        save.addReportField(caseid, report.pgtxtbox.Text, "pg25");
                        save.addReportField(caseid, report.pgtxtbox2.Text, "pg26");

                        //
                        //cdx1-cdx4
                        save.addReportField(caseid, report.dx1.Text, "cdx1");
                        save.addReportField(caseid, report.dx2.Text, "cdx2");
                        save.addReportField(caseid, report.dx3.Text, "cdx3");
                        save.addReportField(caseid, report.dx4.Text, "cdx4");
                        //
                        save.addReportField(caseid, report.pdxtxt1.Text, "pdx1");
                        save.addReportField(caseid, report.pdxtxt2.Text, "pdx2");
                        save.addReportField(caseid, report.pdxtxt3.Text, "pdx3");
                        save.addReportField(caseid, report.pdxtxt4.Text, "pdx4");
                        //
                        save.addReportField(caseid, report.b1txt.Text, "bloodloss");
                        //
                        save.addReportField(caseid, report.c1.Checked.ToString(), "c1");
                        save.addReportField(caseid, report.c2.Checked.ToString(), "c2");
                        save.addReportField(caseid, report.c3txt.Text, "c3");
                        save.addReportField(caseid, report.c4txt.Text, "c4");
                        //
                        save.addReportField(caseid, report.his1.Checked.ToString(), "his1");
                        save.addReportField(caseid, report.his2.Checked.ToString(), "his2");
                        save.addReportField(caseid, report.his3.Checked.ToString(), "his3");
                        save.addReportField(caseid, report.his4txt.Text, "his4");
                        //rap
                        save.addReportField(caseid, report.rap1.Checked.ToString(), "rap1");
                        save.addReportField(caseid, report.rap2.Checked.ToString(), "rap2");
                        //
                        save.addReportField(caseid, report.r1.Checked.ToString(), "r1");
                        save.addReportField(caseid, report.r2.Checked.ToString(), "r2");
                        save.addReportField(caseid, report.r3.Checked.ToString(), "r3");
                        save.addReportField(caseid, report.r42.Text + "/" + report.r43.Text, "r4");
                        //
                        save.addReportField(caseid, report.note.Text, "comment");
                        //state
                        string state = "";
                        if (report.f1btn.BackColor == Color.Black) { state = "NA"; }
                        if (report.f1btn2.BackColor == Color.Green) { state = "NORMAL"; }
                        if (report.f1btn3.BackColor == Color.Red) { state = "ABNORMAL"; }
                        save.addReportField(caseid, state, "sf1");

                        if (report.f2btn.BackColor == Color.Black) { state = "NA"; }
                        if (report.f2btn2.BackColor == Color.Green) { state = "NORMAL"; }
                        if (report.f2btn3.BackColor == Color.Red) { state = "ABNORMAL"; }
                        save.addReportField(caseid, state, "sf2");

                        if (report.f3btn.BackColor == Color.Black) { state = "NA"; }
                        if (report.f3btn2.BackColor == Color.Green) { state = "NORMAL"; }
                        if (report.f3btn3.BackColor == Color.Red) { state = "ABNORMAL"; }
                        save.addReportField(caseid, state, "sf3");

                        if (report.f4btn.BackColor == Color.Black) { state = "NA"; }
                        if (report.f4btn2.BackColor == Color.Green) { state = "NORMAL"; }
                        if (report.f4btn3.BackColor == Color.Red) { state = "ABNORMAL"; }
                        save.addReportField(caseid, state, "sf4");

                        if (report.f5btn.BackColor == Color.Black) { state = "NA"; }
                        if (report.f5btn2.BackColor == Color.Green) { state = "NORMAL"; }
                        if (report.f5btn3.BackColor == Color.Red) { state = "ABNORMAL"; }
                        save.addReportField(caseid, state, "sf5");

                        if (report.f6btn.BackColor == Color.Black) { state = "NA"; }
                        if (report.f6btn2.BackColor == Color.Green) { state = "NORMAL"; }
                        if (report.f6btn3.BackColor == Color.Red) { state = "ABNORMAL"; }
                        save.addReportField(caseid, state, "sf6");

                        if (report.f7btn.BackColor == Color.Black) { state = "NA"; }
                        if (report.f7btn2.BackColor == Color.Green) { state = "NORMAL"; }
                        if (report.f7btn3.BackColor == Color.Red) { state = "ABNORMAL"; }
                        save.addReportField(caseid, state, "sf7");

                        if (report.f8btn.BackColor == Color.Black) { state = "NA"; }
                        if (report.f8btn2.BackColor == Color.Green) { state = "NORMAL"; }
                        if (report.f8btn3.BackColor == Color.Red) { state = "ABNORMAL"; }
                        save.addReportField(caseid, state, "sf8");

                        if (report.f9btn.BackColor == Color.Black) { state = "NA"; }
                        if (report.f9btn2.BackColor == Color.Green) { state = "NORMAL"; }
                        if (report.f9btn3.BackColor == Color.Red) { state = "ABNORMAL"; }
                        save.addReportField(caseid, state, "sf9");

                        if (report.f10btn.BackColor == Color.Black) { state = "NA"; }
                        if (report.f10btn2.BackColor == Color.Green) { state = "NORMAL"; }
                        if (report.f10btn3.BackColor == Color.Red) { state = "ABNORMAL"; }
                        save.addReportField(caseid, state, "sf10");

                        //
                        */

        }


        public void saveEditField(UserControl reportcon, string caseid, UserControl inforeport)
        {
            reportControlColono report = (reportControlColono)reportcon;
            Report info = (Report)inforeport;

            DataAccess save = new DataAccess();

            save.addReportField(caseid, info.infohn.Text, "hn");
            save.addReportField(caseid, info.infoname.Text, "name");
            save.updatePatientdata(caseid, "Patient Name", info.infoname.Text);
            save.updatePatientdata(caseid, "hn", info.infohn.Text);


        }


        private void setbuttonB(int a0, Button a1, Button a2, Button a3, TextBox b)
        {
            switch (a0)
            {
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

                    break;
                case 2:
                    a1.BackColor = Color.LightGray;
                    a2.BackColor = Color.Green;
                    a3.BackColor = Color.LightGray;

                    a1.ForeColor = Color.Black;
                    a2.ForeColor = Color.White;
                    a3.ForeColor = Color.Black;

                    a1.FlatAppearance.BorderColor = Color.Silver;
                    a2.FlatAppearance.BorderColor = Color.DarkGreen;
                    a3.FlatAppearance.BorderColor = Color.Silver;
                    b.Visible = true;

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


                    break;
            }
        }


        public void LoadReportField(UserControl reportcon, string caseid, UserControl inforeport)
        {
            reportControlColono report = (reportControlColono)reportcon;
            Report info = (Report)inforeport;

            DataAccess save = new DataAccess();

            string value = "";

            if (save.getValue(caseid, "a1") == "True")
            {
                report.a1.Checked = true;
            }
            if (save.getValue(caseid, "a2") == "True")
            {
                report.a2.Checked = true;
            }
            if (save.getValue(caseid, "a3") == "True")
            {
                report.a3.Checked = true;
            }
            if (save.getValue(caseid, "a4") == "True")
            {
                report.a4.Checked = true;
            }
            value = save.getValue(caseid, "a5");
            if (value != "")
            {
                report.a5txt.Text = value;
                report.a5.Checked = true;
            }

            //
            value = save.getValue(caseid, "med1");
            if (value != "")
            {
                report.med1txt.Text = value;
                report.med1.Checked = true;
            }
            value = save.getValue(caseid, "med1");
            if (value != "")
            {
                report.med1txt.Text = value;
                report.med1.Checked = true;
            }
            value = save.getValue(caseid, "med2");
            if (value != "")
            {
                report.med2txt.Text = value;
                report.med2.Checked = true;
            }
            value = save.getValue(caseid, "med3");
            if (value != "")
            {
                report.med3txt.Text = value;
                report.med3.Checked = true;
            }
            value = save.getValue(caseid, "med4");
            if (value != "")
            {
                report.med4txt.Text = value;
                report.med4.Checked = true;
            }
            value = save.getValue(caseid, "med5");
            if (value != "")
            {
                report.med5txt.Text = value;
                report.med5.Checked = true;
            }
            value = save.getValue(caseid, "med6");
            if (value != "")
            {
                report.med6txt.Text = value;
                report.med6.Checked = true;
            }
            value = save.getValue(caseid, "med7");
            if (value != "")
            {
                report.med7txt.Text = value;
                report.med7.Checked = true;
            }
            //
            value = save.getValue(caseid, "history");
            if (value != "")
            {
                //top
                string reportType = save.getOption("option_value", "reportType");
                if (reportType == "1")
                {
                    report.commentText.Text = value;
                }
            }
            //
            value = save.getValue(caseid, "f1");
            if (value != "")
            {
                setbuttonB(3, report.f1btn, report.f1btn2, report.f1btn3, report.f1txt);
                report.f1txt.Text = value;

            }
            value = save.getValue(caseid, "f2");
            if (value != "")
            {
                setbuttonB(3, report.f2btn, report.f2btn2, report.f2btn3, report.f2txt);
                report.f2txt.Text = value;
            }
            value = save.getValue(caseid, "f3");
            if (value != "")
            {
                setbuttonB(3, report.f3btn, report.f3btn2, report.f3btn3, report.f3txt);
                report.f3txt.Text = value;
            }
            value = save.getValue(caseid, "f4");
            if (value != "")
            {
                setbuttonB(3, report.f4btn, report.f4btn2, report.f4btn3, report.f4txt);
                report.f4txt.Text = value;
            }
            value = save.getValue(caseid, "f5");
            if (value != "")
            {
                setbuttonB(3, report.f5btn, report.f5btn2, report.f5btn3, report.f5txt);
                report.f5txt.Text = value;
            }
            value = save.getValue(caseid, "f6");
            if (value != "")
            {
                setbuttonB(3, report.f6btn, report.f6btn2, report.f6btn3, report.f6txt);
                report.f6txt.Text = value;
            }
            value = save.getValue(caseid, "f7");
            if (value != "")
            {
                setbuttonB(3, report.f7btn, report.f7btn2, report.f7btn3, report.f7txt);
                report.f7txt.Text = value;
            }
            value = save.getValue(caseid, "f8");
            if (value != "")
            {
                setbuttonB(3, report.f8btn, report.f8btn2, report.f8btn3, report.f8txt);
                report.f8txt.Text = value;
            }
            value = save.getValue(caseid, "f9");
            if (value != "")
            {
                setbuttonB(3, report.f9btn, report.f9btn2, report.f9btn3, report.f9txt);
                report.f9txt.Text = value;
            }
            value = save.getValue(caseid, "f10");
            if (value != "")
            {
                setbuttonB(3, report.f10btn, report.f10btn2, report.f10btn3, report.f10txt);
                report.f10txt.Text = value;

            }
            //
            if (save.getValue(caseid, "pg1") == "True")
            {
                report.pg1.Checked = true;
            }
            if (save.getValue(caseid, "pg2") == "True")
            {
                report.pg2.Checked = true;
            }
            if (save.getValue(caseid, "pg3") == "True")
            {
                report.pg3.Checked = true;
            }
            if (save.getValue(caseid, "pg4") == "True")
            {
                report.pg4.Checked = true;
            }
            if (save.getValue(caseid, "pg5") == "True")
            {
                report.pg5.Checked = true;
            }
            if (save.getValue(caseid, "pg6") == "True")
            {
                report.pg6.Checked = true;
            }
            if (save.getValue(caseid, "pg7") == "True")
            {
                report.pg7.Checked = true;
            }
            if (save.getValue(caseid, "pg8") == "True")
            {
                report.pg8.Checked = true;
            }
            if (save.getValue(caseid, "pg9") == "True")
            {
                report.pg9.Checked = true;
            }
            if (save.getValue(caseid, "pg10") == "True")
            {
                report.pg10.Checked = true;
            }
            if (save.getValue(caseid, "pg11") == "True")
            {
                report.pg11.Checked = true;
            }
            if (save.getValue(caseid, "pg12") == "True")
            {
                report.pg12.Checked = true;
            }
            if (save.getValue(caseid, "pg13") == "True")
            {
                report.pg13.Checked = true;
            }
            if (save.getValue(caseid, "pg14") == "True")
            {
                report.pg14.Checked = true;
            }
            if (save.getValue(caseid, "pg15") == "True")
            {
                report.pg15.Checked = true;
            }
            if (save.getValue(caseid, "pg16") == "True")
            {
                report.pg16.Checked = true;
            }
            if (save.getValue(caseid, "pg17") == "True")
            {
                report.pg17.Checked = true;
            }
            if (save.getValue(caseid, "pg18") == "True")
            {
                report.pg18.Checked = true;
            }
            if (save.getValue(caseid, "pg19") == "True")
            {
                report.pg19.Checked = true;
            }
            if (save.getValue(caseid, "pg20") == "True")
            {
                report.pg20.Checked = true;
            }
            if (save.getValue(caseid, "pg21") == "True")
            {
                report.pg21.Checked = true;
            }
            if (save.getValue(caseid, "pg22") == "True")
            {
                report.pg22.Checked = true;
            }
            if (save.getValue(caseid, "pg23") == "True")
            {
                report.pg23.Checked = true;
            }
            if (save.getValue(caseid, "pg24") == "True")
            {
                report.pg24.Checked = true;
            }
            value = save.getValue(caseid, "pg25");
            if (value != "")
            {
                report.pg25.Checked = true;
                report.pgtxtbox.Text = value;
            }
            value = save.getValue(caseid, "pg26");
            if (value != "")
            {
                report.pg26.Checked = true;
                report.pgtxtbox2.Text = value;
            }
            //cdx
            value = save.getValue(caseid, "cdx1");
            if (value != "")
            {
                report.dx1.Text = value;
            }
            value = save.getValue(caseid, "cdx2");
            if (value != "")
            {
                report.dx2.Text = value;
            }
            value = save.getValue(caseid, "cdx3");
            if (value != "")
            {
                report.dx3.Text = value;
            }
            value = save.getValue(caseid, "cdx4");
            if (value != "")
            {
                report.dx4.Text = value;
            }
            //pdxtxt1
            value = save.getValue(caseid, "pdx1");
            if (value != "")
            {
                report.pdxtxt1.Text = value;
            }
            value = save.getValue(caseid, "pdx2");
            if (value != "")
            {
                report.pdxtxt2.Text = value;
            }
            value = save.getValue(caseid, "pdx3");
            if (value != "")
            {
                report.pdxtxt3.Text = value;
            }
            value = save.getValue(caseid, "pdx4");
            if (value != "")
            {
                report.pdxtxt4.Text = value;
            }
            //bloodloss
            value = save.getValue(caseid, "bloodloss");
            if (value != "")
            {
                report.b1txt.Text = value;
            }
            //com
            if (save.getValue(caseid, "c1") == "True")
            {
                report.c1.Checked = true;
            }
            if (save.getValue(caseid, "c2") == "True")
            {
                report.c2.Checked = true;
            }
            value = save.getValue(caseid, "c3");
            if (value != "")
            {
                report.c3.Checked = true;
                report.c3txt.Text = value;
            }
            value = save.getValue(caseid, "c4");
            if (value != "")
            {
                report.c4.Checked = true;
                report.c4txt.Text = value;
            }
            //his
            if (save.getValue(caseid, "his1") == "True")
            {
                report.his1.Checked = true;
                report.hisradio2.Checked = true;

            }
            if (save.getValue(caseid, "his2") == "True")
            {
                report.his2.Checked = true;
                report.hisradio2.Checked = true;

            }
            if (save.getValue(caseid, "his3") == "True")
            {
                report.his3.Checked = true;
                report.hisradio2.Checked = true;

            }
            value = save.getValue(caseid, "his4");
            if (value != "")
            {
                report.his4.Checked = true;
                report.his4txt.Text = value;
                report.hisradio2.Checked = true;

            }
            //
            if (save.getValue(caseid, "rap1") == "True")
            {
                report.rapradio2.Checked = true;
                report.rap1.Checked = true;
            }
            if (save.getValue(caseid, "rap2") == "True")
            {
                report.rapradio2.Checked = true;
                report.rap2.Checked = true;
            }
            //
            if (save.getValue(caseid, "r1") == "True")
            {
                report.r1.Checked = true;
            }
            if (save.getValue(caseid, "r2") == "True")
            {
                report.r2.Checked = true;
            }
            if (save.getValue(caseid, "r3") == "True")
            {
                report.r3.Checked = true;
            }
            value = save.getValue(caseid, "r4");
            if (value != "" && value != "/")
            {
                string[] words = value.Split('/');
                report.r4.Checked = true;
                report.r42.Text = words[0];
                report.r43.Text = words[1];

            }
            //
            //comment
            value = save.getValue(caseid, "comment");
            if (value != "")
            {
                report.note.Text = value;
            }
            //statue
            value = save.getValue(caseid, "sf1");
            if (value != "ABNORMAL" && value != "")
            {
                if (value == "NA")
                {
                    setbuttonB(1, report.f1btn, report.f1btn2, report.f1btn3, report.f1txt);
                }
                else
                {
                    setbuttonB(2, report.f1btn, report.f1btn2, report.f1btn3, report.f1txt);
                }

            }
            value = save.getValue(caseid, "sf2");
            if (value != "ABNORMAL" && value != "")
            {
                if (value == "NA")
                {
                    setbuttonB(1, report.f2btn, report.f2btn2, report.f2btn3, report.f2txt);
                }
                else
                {
                    setbuttonB(2, report.f2btn, report.f2btn2, report.f2btn3, report.f2txt);
                }

            }
            value = save.getValue(caseid, "sf3");
            if (value != "ABNORMAL" && value != "")
            {
                if (value == "NA")
                {
                    setbuttonB(1, report.f3btn, report.f3btn2, report.f3btn3, report.f3txt);
                }
                else
                {
                    setbuttonB(2, report.f3btn, report.f3btn2, report.f3btn3, report.f3txt);
                }

            }
            value = save.getValue(caseid, "sf4");
            if (value != "ABNORMAL" && value != "")
            {
                if (value == "NA")
                {
                    setbuttonB(1, report.f4btn, report.f4btn2, report.f4btn3, report.f4txt);
                }
                else
                {
                    setbuttonB(2, report.f4btn, report.f4btn2, report.f4btn3, report.f4txt);
                }

            }
            value = save.getValue(caseid, "sf5");
            if (value != "ABNORMAL" && value != "")
            {
                if (value == "NA")
                {
                    setbuttonB(1, report.f5btn, report.f5btn2, report.f5btn3, report.f5txt);
                }
                else
                {
                    setbuttonB(2, report.f5btn, report.f5btn2, report.f5btn3, report.f5txt);
                }

            }
            value = save.getValue(caseid, "sf6");
            if (value != "ABNORMAL" && value != "")
            {
                if (value == "NA")
                {
                    setbuttonB(1, report.f6btn, report.f6btn2, report.f6btn3, report.f6txt);
                }
                else
                {
                    setbuttonB(2, report.f6btn, report.f6btn2, report.f6btn3, report.f6txt);
                }

            }
            value = save.getValue(caseid, "sf7");
            if (value != "ABNORMAL" && value != "")
            {
                if (value == "NA")
                {
                    setbuttonB(1, report.f7btn, report.f7btn2, report.f7btn3, report.f7txt);
                }
                else
                {
                    setbuttonB(2, report.f7btn, report.f7btn2, report.f7btn3, report.f7txt);
                }

            }
            value = save.getValue(caseid, "sf8");
            if (value != "ABNORMAL" && value != "")
            {
                if (value == "NA")
                {
                    setbuttonB(1, report.f8btn, report.f8btn2, report.f8btn3, report.f8txt);
                }
                else
                {
                    setbuttonB(2, report.f8btn, report.f8btn2, report.f8btn3, report.f8txt);
                }

            }
            value = save.getValue(caseid, "sf9");
            if (value != "ABNORMAL" && value != "")
            {
                if (value == "NA")
                {
                    setbuttonB(1, report.f9btn, report.f9btn2, report.f9btn3, report.f9txt);
                }
                else
                {
                    setbuttonB(2, report.f9btn, report.f9btn2, report.f9btn3, report.f9txt);
                }

            }
            value = save.getValue(caseid, "sf10");
            if (value != "ABNORMAL" && value != "")
            {
                if (value == "NA")
                {
                    setbuttonB(1, report.f10btn, report.f10btn2, report.f10btn3, report.f10txt);
                }
                else
                {
                    setbuttonB(2, report.f10btn, report.f10btn2, report.f10btn3, report.f10txt);
                }

            }

            //
            value = save.getValue(caseid, "hn");
            if (value != "")
            {
                info.infohn.Text = value;
            }
            value = save.getValue(caseid, "name");
            if (value != "")
            {
                info.infoname.Text = value;
            }

            //
            value = save.getValue(caseid, "bowelPreparationRegimen");
            if (value != null)
            {
                report.bowelPreparationRegimen.Text = value;
            }
            value = save.getValue(caseid, "bowelPreparationResult");
            if (value != null)
            {
                report.bowelPreparationResult.Text = value;
            }



        }

    }

}


