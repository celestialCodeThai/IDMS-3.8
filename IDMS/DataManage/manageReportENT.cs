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
    class manageReportENT
    {
        public void saveReportField(UserControl reportcon, string caseid, UserControl inforeport)
        {
            reportControlENT report = (reportControlENT)reportcon;
            Report info = (Report)inforeport;
            DataAccess save = new DataAccess();
            string[] field = { "a5",
                                "med1", "med2", "med3", "med4", "med5", "med6", "med7",
                                "history", "f8",

                                "cdx1", "cdx2", "cdx3", "cdx4",
                                "pdx1", "pdx2", "pdx3", "pdx4",
                                "c1", "c5",
                                "r1", "r2", "r3", "r4","r8",
                                "comment",
                                 "his1", "his2", "his3", "his4","r5",
                                 "pg1", "pg2", "pg3", "pg4", "pg5", "pg6", "pg7", "pg8", "pg9", "pg10",
                                "pg11", "pg12", "pg13", "pg14", "pg15", "pg16", "pg17", "pg18", "pg19", "pg20",
                                "pg21", "pg22", "pg23","pg24", "pg25", "pg26", "pg27", "pg28", "pg29", "pg30",
                                "pg31", "pg32", "pg33", "pg34","r6"

        };


            string[] data = {

            report.a5,

            report.med1txt.Text,
            report.med2txt.Text,
            report.med3txt.Text,
            report.med4txt.Text,
            report.med5txt.Text,
            report.med6txt.Text,
            report.med7txt.Text, 

            //
            report.commentText.Text,
            report.f8txt.Text, 


            //cdx1-cdx4
            report.dx1.Text,
            report.dx2.Text,
            report.dx3.Text,
            report.dx4.Text, 
            //
            report.pdxtxt1.Text,
            report.pdxtxt2.Text,
            report.pdxtxt3.Text,
            report.pdxtxt4.Text, 
            //


            //
            report.c1.Checked.ToString(),
            report.c5txt.Text, 

            //

            //
            report.r1.Checked.ToString(),
            report.r2.Checked.ToString(),
            report.r3.Checked.ToString(),
            report.r3.Checked.ToString(),
            report.r82.Text,

            report.note.Text,


            report.his1.Checked.ToString(),
            report.his2txt.Text,
            report.his3txt.Text,
            report.his4txt.Text,
            report.his5txt.Text, 
            //
            report.s0.Checked.ToString(),
            report.s1.Checked.ToString(),
            report.s2.Checked.ToString(),
            report.s3.Checked.ToString(),
            report.s4.Checked.ToString(),
            report.s5.Checked.ToString(),
            report.s6.Text,
            report.s7.Checked.ToString(),
            report.s8.Checked.ToString(),
            report.s9.Checked.ToString(),
            report.s10.Checked.ToString(),
            report.s11.Checked.ToString(),
            report.s12.Checked.ToString(),
            report.s13.Text,
            report.s14.Checked.ToString(),
            report.s15.Checked.ToString(),
            report.s16.Checked.ToString(),
            report.s17.Checked.ToString(),
            report.s18.Checked.ToString(),
            report.s19.Checked.ToString(),
            report.s20.Text,
            report.s21.Checked.ToString(),
            report.s22.Checked.ToString(),
            report.s23.Checked.ToString(),
            report.s24.Checked.ToString(),
            report.s25.Checked.ToString(),
            report.s26.Checked.ToString(),
            report.s27.Text,
            report.s28.Checked.ToString(),
            report.s29.Checked.ToString(),
            report.s30.Checked.ToString(),
            report.s31.Checked.ToString(),
            report.s32.Checked.ToString(),
            report.s33.Checked.ToString(),
            report.s34.Text





        };
            /*

            save.addReportField(caseid, report.a5, "a5");
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

            save.addReportField(caseid, report.f8txt.Text, "f8");


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


            //
            save.addReportField(caseid, report.c1.Checked.ToString(), "c1");
            save.addReportField(caseid, report.c5txt.Text, "c5");

            //

            //
            save.addReportField(caseid, report.r1.Checked.ToString(), "r1");
            save.addReportField(caseid, report.r2.Checked.ToString(), "r2");
            save.addReportField(caseid, report.r3.Checked.ToString(), "r3");
            save.addReportField(caseid, report.r3.Checked.ToString(), "r4");




            save.addReportField(caseid, report.r82.Text, "r8");
            //
            save.addReportField(caseid, report.note.Text, "comment");
            //state

            save.addReportField(caseid, report.his1.Checked.ToString(), "his1");
            save.addReportField(caseid, report.his2txt.Text, "his2");
            save.addReportField(caseid, report.his3txt.Text, "his3");
            save.addReportField(caseid, report.his4txt.Text, "his4");
            save.addReportField(caseid, report.his5txt.Text, "r5");
            //
            save.addReportField(caseid, report.s0.Checked.ToString(), "pg1");
            save.addReportField(caseid, report.s1.Checked.ToString(), "pg2");
            save.addReportField(caseid, report.s2.Checked.ToString(), "pg3");
            save.addReportField(caseid, report.s3.Checked.ToString(), "pg4");
            save.addReportField(caseid, report.s4.Checked.ToString(), "pg5");
            save.addReportField(caseid, report.s5.Checked.ToString(), "pg6");
            save.addReportField(caseid, report.s6.Text, "pg7");
            save.addReportField(caseid, report.s7.Checked.ToString(), "pg8");
            save.addReportField(caseid, report.s8.Checked.ToString(), "pg9");
            save.addReportField(caseid, report.s9.Checked.ToString(), "pg10");
            save.addReportField(caseid, report.s10.Checked.ToString(), "pg11");
            save.addReportField(caseid, report.s11.Checked.ToString(), "pg12");
            save.addReportField(caseid, report.s12.Checked.ToString(), "pg13");
            save.addReportField(caseid, report.s13.Text, "pg14");
            save.addReportField(caseid, report.s14.Checked.ToString(), "pg15");
            save.addReportField(caseid, report.s15.Checked.ToString(), "pg16");
            save.addReportField(caseid, report.s16.Checked.ToString(), "pg17");
            save.addReportField(caseid, report.s17.Checked.ToString(), "pg18");
            save.addReportField(caseid, report.s18.Checked.ToString(), "pg19");
            save.addReportField(caseid, report.s19.Checked.ToString(), "pg20");
            save.addReportField(caseid, report.s20.Text, "pg21");
            save.addReportField(caseid, report.s21.Checked.ToString(), "pg22");
            save.addReportField(caseid, report.s22.Checked.ToString(), "pg23");
            save.addReportField(caseid, report.s23.Checked.ToString(), "pg24");
            save.addReportField(caseid, report.s24.Checked.ToString(), "pg25");
            save.addReportField(caseid, report.s25.Checked.ToString(), "pg26");
            save.addReportField(caseid, report.s26.Checked.ToString(), "pg27");
            save.addReportField(caseid, report.s27.Text, "pg28");
            save.addReportField(caseid, report.s28.Checked.ToString(), "pg29");
            save.addReportField(caseid, report.s29.Checked.ToString(), "pg30");
            save.addReportField(caseid, report.s30.Checked.ToString(), "pg31");
            save.addReportField(caseid, report.s31.Checked.ToString(), "pg32");
            save.addReportField(caseid, report.s32.Checked.ToString(), "pg33");
            save.addReportField(caseid, report.s33.Checked.ToString(), "pg34");
            save.addReportField(caseid, report.s34.Text, "r6");
            //
            //save.addReportField(caseid, info.infohn.Text, "hn");
            //save.addReportField(caseid, info.infoname.Text, "name");
            //save.updatePatientdata(caseid, "Patient Name", info.infoname.Text);
            //save.updatePatientdata(caseid, "hn", info.infohn.Text);

    */
            save.addReportFieldnew(caseid, data, field);

        }
        public void saveEditField(UserControl reportcon, string caseid, UserControl inforeport)
        {
            reportControlERCP report = (reportControlERCP)reportcon;
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
            reportControlENT report = (reportControlENT)reportcon;
            Report info = (Report)inforeport;

            DataAccess save = new DataAccess();
            string value = "";


            value = save.getValue(caseid, "a5");
            if (value != "")
            {
                report.a5txt.Text = value;

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
                report.commentText.Text = value;
            }
            //


            value = save.getValue(caseid, "f8");
            if (value != "")
            {
                report.f8txt.Text = value;
            }



            //




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

            //com
            if (save.getValue(caseid, "c1") == "True")
            {
                report.c1.Checked = true;
            }

            value = save.getValue(caseid, "c5");
            if (value != "")
            {
                report.c5.Checked = true;
                report.c5txt.Text = value;
            }
            //his

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
            if (save.getValue(caseid, "r4") == "True")
            {
                report.r4.Checked = true;
            }

            value = save.getValue(caseid, "r8");
            if (value != "")
            {
                report.r8.Checked = true;
                report.r82.Text = value;

            }
            //
            //comment
            value = save.getValue(caseid, "comment");
            if (value != "")
            {
                report.note.Text = value;
            }
            //statue




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

            if (save.getValue(caseid, "his1") == "True")
            {
                report.his1.Checked = true;


                if (save.getValue(caseid, "pg1") == "True")
                {
                    report.s0.Checked = true;
                }
                if (save.getValue(caseid, "pg2") == "True")
                {
                    report.s1.Checked = true;
                }
                if (save.getValue(caseid, "pg3") == "True")
                {
                    report.s2.Checked = true;
                }
                if (save.getValue(caseid, "pg4") == "True")
                {
                    report.s3.Checked = true;
                }
                if (save.getValue(caseid, "pg5") == "True")
                {
                    report.s4.Checked = true;
                }
                if (save.getValue(caseid, "pg6") == "True")
                {
                    report.s5.Checked = true;
                    value = save.getValue(caseid, "pg7");
                    report.s6.Text = value;
                }


            }

            value = save.getValue(caseid, "his2");
            if (value != "")
            {
                report.his2.Checked = true;
                report.his2txt.Text = value;

                if (save.getValue(caseid, "pg8") == "True")
                {
                    report.s7.Checked = true;
                }
                if (save.getValue(caseid, "pg9") == "True")
                {
                    report.s8.Checked = true;
                }
                if (save.getValue(caseid, "pg10") == "True")
                {
                    report.s9.Checked = true;
                }
                if (save.getValue(caseid, "pg11") == "True")
                {
                    report.s10.Checked = true;
                }
                if (save.getValue(caseid, "pg12") == "True")
                {
                    report.s11.Checked = true;
                }
                if (save.getValue(caseid, "pg13") == "True")
                {
                    report.s12.Checked = true;
                    value = save.getValue(caseid, "pg14");
                    report.s13.Text = value;
                }
            }
            value = save.getValue(caseid, "his3");
            if (value != "")
            {
                report.his3.Checked = true;
                report.his3txt.Text = value;


                if (save.getValue(caseid, "pg15") == "True")
                {
                    report.s14.Checked = true;
                }
                if (save.getValue(caseid, "pg16") == "True")
                {
                    report.s15.Checked = true;
                }
                if (save.getValue(caseid, "pg17") == "True")
                {
                    report.s16.Checked = true;
                }
                if (save.getValue(caseid, "pg18") == "True")
                {
                    report.s17.Checked = true;
                }
                if (save.getValue(caseid, "pg19") == "True")
                {
                    report.s18.Checked = true;
                }
                if (save.getValue(caseid, "pg20") == "True")
                {
                    report.s19.Checked = true;
                    value = save.getValue(caseid, "pg21");
                    report.s20.Text = value;
                }
            }
            value = save.getValue(caseid, "his4");
            if (value != "")
            {
                report.his4.Checked = true;
                report.his4txt.Text = value;

                if (save.getValue(caseid, "pg22") == "True")
                {
                    report.s21.Checked = true;
                }
                if (save.getValue(caseid, "pg23") == "True")
                {
                    report.s22.Checked = true;
                }
                if (save.getValue(caseid, "pg24") == "True")
                {
                    report.s23.Checked = true;
                }
                if (save.getValue(caseid, "pg25") == "True")
                {
                    report.s24.Checked = true;
                }
                if (save.getValue(caseid, "pg26") == "True")
                {
                    report.s25.Checked = true;
                }
                if (save.getValue(caseid, "pg27") == "True")
                {
                    report.s26.Checked = true;
                    value = save.getValue(caseid, "pg28");
                    report.s27.Text = value;
                }
            }
            value = save.getValue(caseid, "r5");
            if (value != "")
            {
                report.his5.Checked = true;
                report.his5txt.Text = value;

                if (save.getValue(caseid, "pg29") == "True")
                {
                    report.s28.Checked = true;
                }
                if (save.getValue(caseid, "pg30") == "True")
                {
                    report.s29.Checked = true;
                }
                if (save.getValue(caseid, "pg31") == "True")
                {
                    report.s30.Checked = true;
                }
                if (save.getValue(caseid, "pg32") == "True")
                {
                    report.s31.Checked = true;
                }
                if (save.getValue(caseid, "pg33") == "True")
                {
                    report.s32.Checked = true;
                }
                if (save.getValue(caseid, "pg34") == "True")
                {
                    report.s33.Checked = true;
                    value = save.getValue(caseid, "r6");
                    report.s34.Text = value;
                }
            }


        }



        public void savepicture(UserControl reportcon, string caseid)
        {
            imageReport report = (imageReport)reportcon;
            DataAccess save = new DataAccess();
            int k;
            string[] field = new string[66];
            string[] cfield = new string[66];
            string[] data = new string[66];
            string[] cdata = new string[66];
            for (int i = 0; i < 66; i++)
            {
                k = i + 1;

                field[i] = "img" + k.ToString();
                data[i] = report.imgPath[i];
                cfield[i] = "cb" + k.ToString();
                cdata[i] = report.cBoxIndex[i].ToString();


            }

            save.addReportFieldnew(caseid, data, field);
            save.addReportFieldnew(caseid, cdata, cfield);

            //top ==============================================================================================================================================

            string[] imagesPointDatas = new string[66];
            string[] imagesPointField = new string[66];

            for (int i = 0; i < 66; i++)
            {
                imagesPointField[i] = "point_" + (i + 1) + "";
                imagesPointDatas[i] = report.recImage[i].ToString();
            }

            //System.Diagnostics.Debug.Write("recImage Value = " + report.recImage[0].ToString());

            save.imagePointInsertOrUpdate(caseid, imagesPointDatas, imagesPointField);

            // ================================================================================================================================================
        }

        public void Loadpicture(UserControl r, UserControl reportcon, string caseid)
        {
            imageReport report = (imageReport)reportcon;
            Report rep = (Report)r;

            DataAccess save = new DataAccess();
            string imageName = "";
            string Value = "";
            int k;
            for (int i = 0; i < 66; i++)
            {
                k = i + 1;

                if (save.getValue(caseid, "img" + k) != "")
                {
                    Value = save.getValue(caseid, "img" + k);
                    //report.setPicture(Value);

                    //top =====================================================================================================
                    int fieldNumber = i + 1;
                    string imagePoint = save.getValueWithTableName(caseid, "image_point", "point_" + fieldNumber + "");

                    if (imagePoint == null || imagePoint == "")
                    {
                        report.recImage[i] = new Rectangle(0, 0, 0, 0);
                    }
                    else
                    {
                        string[] imagePointDatas = imagePoint.Split('=');
                        string[] pointX = imagePointDatas[1].Split(',');
                        string[] pointY = imagePointDatas[2].Split(',');
                        string[] pointWidth = imagePointDatas[3].Split(',');
                        string[] pointHeight = imagePointDatas[4].Split('}');

                        int AXIS_X = Int32.Parse(pointX[0]);
                        int AXIS_Y = Int32.Parse(pointY[0]);
                        int CROP_WIDTH = Int32.Parse(pointWidth[0]);
                        int CROP_HEIGHT = Int32.Parse(pointHeight[0]);
                        report.recImage[i] = new Rectangle(AXIS_X, AXIS_Y, CROP_WIDTH, CROP_HEIGHT);
                    }

                    report.setPictureWithPoint(Value, report.recImage[i]);
                    //=========================================================================================================

                    //     report.cBoxIndex[i] = Convert.ToInt32(save.getValue(caseid, "cb" + k));
                    //    report.cBoxes[i].SelectedIndex = report.cBoxIndex[i];
                    imageName = Value.Replace(rep.imgFolder, null);
                    rep.selectImageTable.Rows.Add(imageName);

                    for (int v = 0; v < rep.imagelistTable.Rows.Count; v++)
                    {
                        if (string.Equals(rep.imagelistTable[0, v].Value as string, imageName))
                        {
                            rep.imagelistTable.Rows.RemoveAt(v);
                            v--;
                        }
                    }
                }
            }
        }




    }
}


