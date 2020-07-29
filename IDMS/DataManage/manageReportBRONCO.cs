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
    class manageReportBRONCO
    {
        public void saveReportField(UserControl reportcon, string caseid, UserControl inforeport)
        {
            reportControlBronco report = (reportControlBronco)reportcon;
            Report info = (Report)inforeport;
            DataAccess save = new DataAccess();

            //top
            string reportType = save.getOption("option_value", "reportType");
            if (reportType == "2") { save.updatePatientCase(caseid, "Indication", report.commentText.Text); }

            string state1 = ""; string state2 = ""; string state3 = ""; string state4 = ""; string state5 = ""; string state6 = ""; string state7 = ""; string state8 = ""; string state9 = ""; string state10 = ""; string state11 = ""; string state12 = "";

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

            if (report.f11btn.BackColor == Color.Black) { state11 = "NA"; }
            else
            {
                if (report.f11btn2.BackColor == Color.Green) { state11 = "NORMAL"; }
                else
                {
                    if (report.f11btn3.BackColor == Color.Red) { state11 = "ABNORMAL"; }
                }
            }
            if (report.f12btn.BackColor == Color.Black) { state12 = "NA"; }
            else
            {
                if (report.f12btn2.BackColor == Color.Green) { state12 = "NORMAL"; }
                else
                {
                    if (report.f12btn3.BackColor == Color.Red) { state12 = "ABNORMAL"; }
                }
            }
         


            string[] field = { "cxr1", "cxr2", "cxr3", "ct1", "ct2",
                                "med1", "med2", "med3", "med4", "med5", "med6",
                                "history", "f1", "f2", "f3", "f4", "f5", "f6", "f7", "f8","f9","f10","f11","f12",
                                "pg1", "pg2", "pg3", "pg4", "pg5", "pg6", "pg7", "pg8", "pg9", "pg10",
                                "pg11", "pg12", "pg13", "pg14", "pg15", "pg16", "pg17", "pg18", "pg19", "pg20",
                                "pg21", "pg22", "pg23","pg24", "pg25", "pg26", "pg27", "pg28", "pg29", "pg30",
                                "pg31", "pg32", "pg33", "pg34","pg35", "pg36", "pg37", "pg38", "pg39", "pg40",
                                "pg41", "pg42", "pg43", "pg44","pg45", "pg46", "pg47", "pg48", "pg49", "pg50",
                                "pg51", "pg52", "pg53", "pg54",
                                "pg1.1", "pg1.2", "pg1.3", "pg2.1", "pg2.2", "pg6.1", "pg7.1", "pg7.2","pg8.1", "pg9.1", "pg9.2","pg9.3","pg9.4","pg9.5",
                                "pg26.1", "pg27.1", "pg27.2", "pg33.1","pg33.2", "pg35.1", "pg43.1", "pg44.1", "pg45.1", "pg46.1",
                                "pg47.1", "pg48.1", "pg49.1", "pg50.1","pg51.1","pg52.1",

                                "cdx1", "cdx2",
                                "pdx1",
                                 "r1", "r2", "r3", "r4",

                                  
                                "bloodloss",
                              "c1", "c2", "c3", "c4","c5", "c6", "c7",
                                "comment",
                                 "sf1", "sf2", "sf3", "sf4", "sf5", "sf6","sf7","sf8","sf9","sf10","sf11","sf12"


        };
            string[] data = {
               


         

            report.cxr.Text,
            report.cxr2.Text,
            report.cxr3.Text,
            report.ct.Text, 
            report.ct2.Text, 
         
            report.med1txt.Text,
            report.med2txt.Text,
            report.med3txt.Text, 
            report.med4txt.Text, 
            report.med5txt.Text, 
            report.med6txt.Text, 

          
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
            report.f11txt.Text, 

            report.f12txt.Text, 


           
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
            report.pg25.Checked.ToString(),
            report.pg26.Checked.ToString(), 
            report.pg27.Checked.ToString(), 
            report.pg28.Checked.ToString(), 
            report.pg29.Checked.ToString(), 
            report.pg30.Checked.ToString(),
            report.pg31.Checked.ToString(), 
            report.pg32.Checked.ToString(), 
            report.pg33.Checked.ToString(), 
            report.pg34.Checked.ToString(), 
            report.pg35.Checked.ToString(), 
            report.pg36.Checked.ToString(), 
            report.pg37.Checked.ToString(), 
            report.pg38.Checked.ToString(), 
            report.pg39.Checked.ToString(), 
            report.pg40.Checked.ToString(), 
            report.pg41.Checked.ToString(), 
            report.pg42.Checked.ToString(), 
            report.pg43.Checked.ToString(), 
            report.pg44.Checked.ToString(), 
            report.pg45.Checked.ToString(), 
            report.pg46.Checked.ToString(), 
            report.pg47.Checked.ToString(), 
            report.pg48.Checked.ToString(), 
            report.pg49.Checked.ToString(), 
            report.pg50.Checked.ToString(), 
            report.pg51.Checked.ToString(), 
            report.pg52.Checked.ToString(), 
            report.pg53.Checked.ToString(), 
            report.pg54.Checked.ToString(), 
            //
            report.pg1_1.Text, 
            report.pg1_2.Text,
            report.pg1_3.Text, 
            report.pg2_1.Text, 
            report.pg2_2.Text, 
            report.pg6_1.Text, 
            report.pg7_1.Text, 
            report.pg7_2.Text, 
            report.pg8_1.Text, 
            report.pg9_1.Text, 
            report.pg9_2.Text, 
            report.pg9_3.Text, 
            report.pg9_4.Text, 
            report.pg9_5.Text, 
            report.pg26_1.Text, 
            report.pg27_1.Text, 
            report.pg27_2.Text, 
            report.pg33_1.Text, 
            report.pg33_2.Text,
            report.pg35_1.Text, 
            report.pg43_1.Text,
            report.pg44_1.Text, 
            report.pg45_1.Text, 
            report.pg46_1.Text, 
            report.pg47_1.Text, 
            report.pg48_1.Text, 
            report.pg49_1.Text, 
            report.pg50_1.Text, 
            report.pg51_1.Text, 
            report.pg52_1.Text,
            //cdx1-cdx4
            report.predx.Text, 
            report.indi.Text, 
            
            //
            report.pdx.Text, 

            //
            //
            report.ro1.Checked.ToString(),
            report.ro2.Checked.ToString(),
            report.ro3.Checked.ToString(), 
            report.ro4txt.Text, 

            //
            report.b1txt.Text, 
            //
           
            report.c1.Checked.ToString(),
            report.c5.Checked.ToString(), 
          
           
            report.c3.Checked.ToString(), 
            report.c6.Checked.ToString(), 
            report.c7.Checked.ToString(),
           report.c2txt.Text,
            report.c4txt.Text,

           
            //
           
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
                 state11,
                  state12
        };
            save.addReportFieldnewBRONCO(caseid, data, field);



            /*

            save.addbroncoReportField(caseid, report.cxr.Text, "cxr1");
            save.addbroncoReportField(caseid, report.cxr2.Text, "cxr2");
            save.addbroncoReportField(caseid, report.cxr3.Text, "cxr3");
            save.addbroncoReportField(caseid, report.ct.Text, "ct1");
            save.addbroncoReportField(caseid, report.ct2.Text, "ct2");
            //
            save.addbroncoReportField(caseid, report.med1txt.Text, "med1");
            save.addbroncoReportField(caseid, report.med2txt.Text, "med2");
            save.addbroncoReportField(caseid, report.med3txt.Text, "med3");
            save.addbroncoReportField(caseid, report.med4txt.Text, "med4");
            save.addbroncoReportField(caseid, report.med5txt.Text, "med5");
            save.addbroncoReportField(caseid, report.med6txt.Text, "med6");

            //
            save.addbroncoReportField(caseid, report.commentText.Text, "history");
            //finding
            save.addbroncoReportField(caseid, report.f1txt.Text, "f1");
            save.addbroncoReportField(caseid, report.f2txt.Text, "f2");
            save.addbroncoReportField(caseid, report.f3txt.Text, "f3");
            save.addbroncoReportField(caseid, report.f4txt.Text, "f4");
            save.addbroncoReportField(caseid, report.f5txt.Text, "f5");
            save.addbroncoReportField(caseid, report.f6txt.Text, "f6");
            save.addbroncoReportField(caseid, report.f7txt.Text, "f7");
            save.addbroncoReportField(caseid, report.f8txt.Text, "f8");
            save.addbroncoReportField(caseid, report.f9txt.Text, "f9");
            save.addbroncoReportField(caseid, report.f10txt.Text, "f10");
            save.addbroncoReportField(caseid, report.f11txt.Text, "f11");

            save.addbroncoReportField(caseid, report.f12txt.Text, "f12");


            //pg1-25
            save.addbroncoReportField(caseid, report.pg1.Checked.ToString(), "pg1");
            save.addbroncoReportField(caseid, report.pg2.Checked.ToString(), "pg2");
            save.addbroncoReportField(caseid, report.pg3.Checked.ToString(), "pg3");
            save.addbroncoReportField(caseid, report.pg4.Checked.ToString(), "pg4");
            save.addbroncoReportField(caseid, report.pg5.Checked.ToString(), "pg5");
            save.addbroncoReportField(caseid, report.pg6.Checked.ToString(), "pg6");
            save.addbroncoReportField(caseid, report.pg7.Checked.ToString(), "pg7");
            save.addbroncoReportField(caseid, report.pg8.Checked.ToString(), "pg8");
            save.addbroncoReportField(caseid, report.pg9.Checked.ToString(), "pg9");
            save.addbroncoReportField(caseid, report.pg10.Checked.ToString(), "pg10");
            save.addbroncoReportField(caseid, report.pg11.Checked.ToString(), "pg11");
            save.addbroncoReportField(caseid, report.pg12.Checked.ToString(), "pg12");
            save.addbroncoReportField(caseid, report.pg13.Checked.ToString(), "pg13");
            save.addbroncoReportField(caseid, report.pg14.Checked.ToString(), "pg14");
            save.addbroncoReportField(caseid, report.pg15.Checked.ToString(), "pg15");
            save.addbroncoReportField(caseid, report.pg16.Checked.ToString(), "pg16");
            save.addbroncoReportField(caseid, report.pg17.Checked.ToString(), "pg17");
            save.addbroncoReportField(caseid, report.pg18.Checked.ToString(), "pg18");
            save.addbroncoReportField(caseid, report.pg19.Checked.ToString(), "pg19");
            save.addbroncoReportField(caseid, report.pg20.Checked.ToString(), "pg20");
            save.addbroncoReportField(caseid, report.pg21.Checked.ToString(), "pg21");
            save.addbroncoReportField(caseid, report.pg22.Checked.ToString(), "pg22");
            save.addbroncoReportField(caseid, report.pg23.Checked.ToString(), "pg23");
            save.addbroncoReportField(caseid, report.pg24.Checked.ToString(), "pg24");
            save.addbroncoReportField(caseid, report.pg25.Checked.ToString(), "pg25");
            save.addbroncoReportField(caseid, report.pg26.Checked.ToString(), "pg26");
            save.addbroncoReportField(caseid, report.pg27.Checked.ToString(), "pg27");
            save.addbroncoReportField(caseid, report.pg28.Checked.ToString(), "pg28");
            save.addbroncoReportField(caseid, report.pg29.Checked.ToString(), "pg29");
            save.addbroncoReportField(caseid, report.pg30.Checked.ToString(), "pg30");
            save.addbroncoReportField(caseid, report.pg31.Checked.ToString(), "pg31");
            save.addbroncoReportField(caseid, report.pg32.Checked.ToString(), "pg32");
            save.addbroncoReportField(caseid, report.pg33.Checked.ToString(), "pg33");
            save.addbroncoReportField(caseid, report.pg34.Checked.ToString(), "pg34");
            save.addbroncoReportField(caseid, report.pg35.Checked.ToString(), "pg35");
            save.addbroncoReportField(caseid, report.pg36.Checked.ToString(), "pg36");
            save.addbroncoReportField(caseid, report.pg37.Checked.ToString(), "pg37");
            save.addbroncoReportField(caseid, report.pg38.Checked.ToString(), "pg38");
            save.addbroncoReportField(caseid, report.pg39.Checked.ToString(), "pg39");
            save.addbroncoReportField(caseid, report.pg40.Checked.ToString(), "pg40");
            save.addbroncoReportField(caseid, report.pg41.Checked.ToString(), "pg41");
            save.addbroncoReportField(caseid, report.pg42.Checked.ToString(), "pg42");
            save.addbroncoReportField(caseid, report.pg43.Checked.ToString(), "pg43");
            save.addbroncoReportField(caseid, report.pg44.Checked.ToString(), "pg44");
            save.addbroncoReportField(caseid, report.pg45.Checked.ToString(), "pg45");
            save.addbroncoReportField(caseid, report.pg46.Checked.ToString(), "pg46");
            save.addbroncoReportField(caseid, report.pg47.Checked.ToString(), "pg47");
            save.addbroncoReportField(caseid, report.pg48.Checked.ToString(), "pg48");
            save.addbroncoReportField(caseid, report.pg49.Checked.ToString(), "pg49");
            save.addbroncoReportField(caseid, report.pg50.Checked.ToString(), "pg50");
            save.addbroncoReportField(caseid, report.pg51.Checked.ToString(), "pg51");
            save.addbroncoReportField(caseid, report.pg52.Checked.ToString(), "pg52");
            save.addbroncoReportField(caseid, report.pg53.Checked.ToString(), "pg53");
            save.addbroncoReportField(caseid, report.pg54.Checked.ToString(), "pg54");
            //
            save.addbroncoReportField(caseid, report.pg1_1.Text, "pg1.1");
            save.addbroncoReportField(caseid, report.pg1_2.Text, "pg1.2");
            save.addbroncoReportField(caseid, report.pg1_3.Text, "pg1.3");
            save.addbroncoReportField(caseid, report.pg2_1.Text, "pg2.1");
            save.addbroncoReportField(caseid, report.pg2_2.Text, "pg2.2");
            save.addbroncoReportField(caseid, report.pg6_1.Text, "pg6.1");
            save.addbroncoReportField(caseid, report.pg7_1.Text, "pg7.1");
            save.addbroncoReportField(caseid, report.pg7_2.Text, "pg7.2");
            save.addbroncoReportField(caseid, report.pg8_1.Text, "pg8.1");
            save.addbroncoReportField(caseid, report.pg9_1.Text, "pg9.1");
            save.addbroncoReportField(caseid, report.pg9_2.Text, "pg9.2");
            save.addbroncoReportField(caseid, report.pg9_3.Text, "pg9.3");
            save.addbroncoReportField(caseid, report.pg9_4.Text, "pg9.4");
            save.addbroncoReportField(caseid, report.pg9_5.Text, "pg9.5");
            save.addbroncoReportField(caseid, report.pg26_1.Text, "pg26.1");
            save.addbroncoReportField(caseid, report.pg27_1.Text, "pg27.1");
            save.addbroncoReportField(caseid, report.pg27_2.Text, "pg27.2");
            save.addbroncoReportField(caseid, report.pg33_1.Text, "pg33.1");
            save.addbroncoReportField(caseid, report.pg33_2.Text, "pg33.2");
            save.addbroncoReportField(caseid, report.pg35_1.Text, "pg35.1");
            save.addbroncoReportField(caseid, report.pg43_1.Text, "pg43.1");
            save.addbroncoReportField(caseid, report.pg44_1.Text, "pg44.1");
            save.addbroncoReportField(caseid, report.pg45_1.Text, "pg45.1");
            save.addbroncoReportField(caseid, report.pg46_1.Text, "pg46.1");
            save.addbroncoReportField(caseid, report.pg47_1.Text, "pg47.1");
            save.addbroncoReportField(caseid, report.pg48_1.Text, "pg48.1");
            save.addbroncoReportField(caseid, report.pg49_1.Text, "pg49.1");
            save.addbroncoReportField(caseid, report.pg50_1.Text, "pg50.1");
            save.addbroncoReportField(caseid, report.pg51_1.Text, "pg51.1");
            save.addbroncoReportField(caseid, report.pg52_1.Text, "pg52.1");
            //cdx1-cdx4
            save.addbroncoReportField(caseid, report.predx.Text, "cdx1");
            save.addbroncoReportField(caseid, report.indi.Text, "cdx2");
            
            //
            save.addbroncoReportField(caseid, report.pdx.Text, "pdx1");

            //
            //
            save.addbroncoReportField(caseid, report.ro1.Checked.ToString(), "r1");
            save.addbroncoReportField(caseid, report.ro2.Checked.ToString(), "r2");
            save.addbroncoReportField(caseid, report.ro3.Checked.ToString(), "r3");
            save.addbroncoReportField(caseid, report.ro4txt.Text, "r4");

            //
            save.addbroncoReportField(caseid, report.b1txt.Text, "bloodloss");
            //
            save.addbroncoReportField(caseid, report.c1.Checked.ToString(), "c1");
              save.addbroncoReportField(caseid, report.c2txt.Text, "c2");
            save.addbroncoReportField(caseid, report.c3.Checked.ToString(), "c3");
          
            save.addbroncoReportField(caseid, report.c4txt.Text, "c4");
            save.addbroncoReportField(caseid, report.c5.Checked.ToString(), "c5");
            save.addbroncoReportField(caseid, report.c6.Checked.ToString(), "c6");
            save.addbroncoReportField(caseid, report.c7.Checked.ToString(), "c7");
            //
           
            save.addbroncoReportField(caseid, report.note.Text, "comment");
            //state
            string state = "";
            if (report.f1btn.BackColor == Color.Black) { state = "NA"; }
            if (report.f1btn2.BackColor == Color.Green) { state = "NORMAL"; }
            if (report.f1btn3.BackColor == Color.Red) { state = "ABNORMAL"; }
            save.addbroncoReportField(caseid, state, "sf1");

            if (report.f2btn.BackColor == Color.Black) { state = "NA"; }
            if (report.f2btn2.BackColor == Color.Green) { state = "NORMAL"; }
            if (report.f2btn3.BackColor == Color.Red) { state = "ABNORMAL"; }
            save.addbroncoReportField(caseid, state, "sf2");

            if (report.f3btn.BackColor == Color.Black) { state = "NA"; }
            if (report.f3btn2.BackColor == Color.Green) { state = "NORMAL"; }
            if (report.f3btn3.BackColor == Color.Red) { state = "ABNORMAL"; }
            save.addbroncoReportField(caseid, state, "sf3");

            if (report.f4btn.BackColor == Color.Black) { state = "NA"; }
            if (report.f4btn2.BackColor == Color.Green) { state = "NORMAL"; }
            if (report.f4btn3.BackColor == Color.Red) { state = "ABNORMAL"; }
            save.addbroncoReportField(caseid, state, "sf4");

            if (report.f5btn.BackColor == Color.Black) { state = "NA"; }
            if (report.f5btn2.BackColor == Color.Green) { state = "NORMAL"; }
            if (report.f5btn3.BackColor == Color.Red) { state = "ABNORMAL"; }
            save.addbroncoReportField(caseid, state, "sf5");

            if (report.f6btn.BackColor == Color.Black) { state = "NA"; }
            if (report.f6btn2.BackColor == Color.Green) { state = "NORMAL"; }
            if (report.f6btn3.BackColor == Color.Red) { state = "ABNORMAL"; }
            save.addbroncoReportField(caseid, state, "sf6");

            if (report.f7btn.BackColor == Color.Black) { state = "NA"; }
            if (report.f7btn2.BackColor == Color.Green) { state = "NORMAL"; }
            if (report.f7btn3.BackColor == Color.Red) { state = "ABNORMAL"; }
            save.addbroncoReportField(caseid, state, "sf7");

            if (report.f8btn.BackColor == Color.Black) { state = "NA"; }
            if (report.f8btn2.BackColor == Color.Green) { state = "NORMAL"; }
            if (report.f8btn3.BackColor == Color.Red) { state = "ABNORMAL"; }
            save.addbroncoReportField(caseid, state, "sf8");

            if (report.f9btn.BackColor == Color.Black) { state = "NA"; }
            if (report.f9btn2.BackColor == Color.Green) { state = "NORMAL"; }
            if (report.f9btn3.BackColor == Color.Red) { state = "ABNORMAL"; }
            save.addbroncoReportField(caseid, state, "sf9");

            if (report.f10btn.BackColor == Color.Black) { state = "NA"; }
            if (report.f10btn2.BackColor == Color.Green) { state = "NORMAL"; }
            if (report.f10btn3.BackColor == Color.Red) { state = "ABNORMAL"; }
            save.addbroncoReportField(caseid, state, "sf10");

            if (report.f11btn.BackColor == Color.Black) { state = "NA"; }
            if (report.f11btn2.BackColor == Color.Green) { state = "NORMAL"; }
            if (report.f11btn3.BackColor == Color.Red) { state = "ABNORMAL"; }
            save.addbroncoReportField(caseid, state, "sf11");

            if (report.f12btn.BackColor == Color.Black) { state = "NA"; }
            if (report.f12btn2.BackColor == Color.Green) { state = "NORMAL"; }
            if (report.f12btn3.BackColor == Color.Red) { state = "ABNORMAL"; }
            save.addbroncoReportField(caseid, state, "sf12");
            //
            //save.addbroncoReportField(caseid, info.infohn.Text, "hn");
            //save.addbroncoReportField(caseid, info.infoname.Text, "name");
            //save.updatePatientdata(caseid, "Patient Name", info.infoname.Text);
            //save.updatePatientdata(caseid, "hn", info.infohn.Text);
            */
        }
        public void saveEditField(UserControl reportcon, string caseid, UserControl inforeport)
        {
            reportControlEGD report = (reportControlEGD)reportcon;
            Report info = (Report)inforeport;
            DataAccess save = new DataAccess();

            save.addbroncoReportField(caseid, info.infohn.Text, "hn");
            save.addbroncoReportField(caseid, info.infoname.Text, "name");
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
            reportControlBronco report = (reportControlBronco)reportcon;
            Report info = (Report)inforeport;

            DataAccess save = new DataAccess();
            string value = "";

          
            value = save.getValueBRONCO(caseid, "cxr1");
            if (value != "")
            {
                report.cxr.Text = value;
                
            }
            value = save.getValueBRONCO(caseid, "cxr2");
            if (value != "")
            {
                report.cxr2.Text = value;

            }
            value = save.getValueBRONCO(caseid, "cxr3");
            if (value != "")
            {
                report.cxr3.Text = value;

            }
            value = save.getValueBRONCO(caseid, "ct1");
            if (value != "")
            {
                report.ct.Text = value;

            }
            value = save.getValueBRONCO(caseid, "ct2");
            if (value != "")
            {
                report.ct2.Text = value;

            }
            value = save.getValueBRONCO(caseid, "ct3");
            if (value != "")
            {
                report.ct3.Text = value;

            }
            //
            value = save.getValueBRONCO(caseid, "med1");
            if (value != "")
            {
                report.med1txt.Text = value;
                report.med1.Checked = true;
            }
            value = save.getValueBRONCO(caseid, "med1");
            if (value != "")
            {
                report.med1txt.Text = value;
                report.med1.Checked = true;
            }
            value = save.getValueBRONCO(caseid, "med2");
            if (value != "")
            {
                report.med2txt.Text = value;
                report.med2.Checked = true;
            }
            value = save.getValueBRONCO(caseid, "med3");
            if (value != "")
            {
                report.med3txt.Text = value;
                report.med3.Checked = true;
            }
            value = save.getValueBRONCO(caseid, "med4");
            if (value != "")
            {
                report.med4txt.Text = value;
                report.med4.Checked = true;
            }
            value = save.getValueBRONCO(caseid, "med5");
            if (value != "")
            {
                report.med5txt.Text = value;
                report.med5.Checked = true;
            }
            value = save.getValueBRONCO(caseid, "med6");
            if (value != "")
            {
                report.med6txt.Text = value;
                report.med6.Checked = true;
            }
           
            //
            value = save.getValueBRONCO(caseid, "history");
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
            value = save.getValueBRONCO(caseid, "f1");
            if (value != "")
            {
                setbuttonB(3, report.f1btn, report.f1btn2, report.f1btn3, report.f1txt);
                report.f1txt.Text = value;

            }
            value = save.getValueBRONCO(caseid, "f2");
            if (value != "")
            {
                setbuttonB(3, report.f2btn, report.f2btn2, report.f2btn3, report.f2txt);
                report.f2txt.Text = value;
            }
            value = save.getValueBRONCO(caseid, "f3");
            if (value != "")
            {
                setbuttonB(3, report.f3btn, report.f3btn2, report.f3btn3, report.f3txt);
                report.f3txt.Text = value;
            }
            value = save.getValueBRONCO(caseid, "f4");
            if (value != "")
            {
                setbuttonB(3, report.f4btn, report.f4btn2, report.f4btn3, report.f4txt);
                report.f4txt.Text = value;
            }
            value = save.getValueBRONCO(caseid, "f5");
            if (value != "")
            {
                setbuttonB(3, report.f5btn, report.f5btn2, report.f5btn3, report.f5txt);
                report.f5txt.Text = value;
            }
            value = save.getValueBRONCO(caseid, "f6");
            if (value != "")
            {
                setbuttonB(3, report.f6btn, report.f6btn2, report.f6btn3, report.f6txt);
                report.f6txt.Text = value;
            }
            value = save.getValueBRONCO(caseid, "f7");
            if (value != "")
            {
                setbuttonB(3, report.f7btn, report.f7btn2, report.f7btn3, report.f7txt);
                report.f7txt.Text = value;
            }
            value = save.getValueBRONCO(caseid, "f8");
            if (value != "")
            {
                setbuttonB(3, report.f8btn, report.f8btn2, report.f8btn3, report.f8txt);
                report.f8txt.Text = value;
            }
            value = save.getValueBRONCO(caseid, "f9");
            if (value != "")
            {
                setbuttonB(3, report.f9btn, report.f9btn2, report.f9btn3, report.f9txt);
                report.f9txt.Text = value;
            }
            value = save.getValueBRONCO(caseid, "f10");
            if (value != "")
            {
                setbuttonB(3, report.f10btn, report.f10btn2, report.f10btn3, report.f10txt);
                report.f10txt.Text = value;

            }
            value = save.getValueBRONCO(caseid, "f11");
            if (value != "")
            {
                setbuttonB(3, report.f11btn, report.f11btn2, report.f11btn3, report.f11txt);
                report.f11txt.Text = value;

            }
            value = save.getValueBRONCO(caseid, "f12");
            if (value != "")
            {
                setbuttonB(3, report.f12btn, report.f12btn2, report.f12btn3, report.f12txt);
                report.f12txt.Text = value;

            }
            //
            if (save.getValueBRONCO(caseid, "pg1") == "True")
            {
                report.pg1.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg2") == "True")
            {
                report.pg2.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg3") == "True")
            {
                report.pg3.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg4") == "True")
            {
                report.pg4.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg5") == "True")
            {
                report.pg5.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg6") == "True")
            {
                report.pg6.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg7") == "True")
            {
                report.pg7.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg8") == "True")
            {
                report.pg8.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg9") == "True")
            {
                report.pg9.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg10") == "True")
            {
                report.pg10.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg11") == "True")
            {
                report.pg11.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg12") == "True")
            {
                report.pg12.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg13") == "True")
            {
                report.pg13.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg14") == "True")
            {
                report.pg14.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg15") == "True")
            {
                report.pg15.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg16") == "True")
            {
                report.pg16.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg17") == "True")
            {
                report.pg17.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg18") == "True")
            {
                report.pg18.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg19") == "True")
            {
                report.pg19.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg20") == "True")
            {
                report.pg20.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg21") == "True")
            {
                report.pg21.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg22") == "True")
            {
                report.pg22.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg23") == "True")
            {
                report.pg23.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg24") == "True")
            {
                report.pg24.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg25") == "True")
            {
                report.pg25.Checked = true;
            }

            if (save.getValueBRONCO(caseid, "pg26") == "True")
            {
                report.pg26.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg27") == "True")
            {
                report.pg27.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg28") == "True")
            {
                report.pg28.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg29") == "True")
            {
                report.pg29.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg30") == "True")
            {
                report.pg30.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg31") == "True")
            {
                report.pg31.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg32") == "True")
            {
                report.pg32.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg33") == "True")
            {
                report.pg33.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg34") == "True")
            {
                report.pg34.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg35") == "True")
            {
                report.pg35.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg36") == "True")
            {
                report.pg36.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg37") == "True")
            {
                report.pg37.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg38") == "True")
            {
                report.pg38.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg39") == "True")
            {
                report.pg39.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg40") == "True")
            {
                report.pg40.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg41") == "True")
            {
                report.pg41.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg42") == "True")
            {
                report.pg42.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg43") == "True")
            {
                report.pg43.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg44") == "True")
            {
                report.pg44.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg45") == "True")
            {
                report.pg45.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg46") == "True")
            {
                report.pg46.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg47") == "True")
            {
                report.pg47.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg48") == "True")
            {
                report.pg48.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg49") == "True")
            {
                report.pg49.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg50") == "True")
            {
                report.pg50.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg51") == "True")
            {
                report.pg51.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg52") == "True")
            {
                report.pg52.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg53") == "True")
            {
                report.pg53.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "pg54") == "True")
            {
                report.pg54.Checked = true;
            }
            //
            value = save.getValueBRONCO(caseid, "pg1.1");
            if (value != "")
            {
                report.pg1_1.Text = value;
            }
            value = save.getValueBRONCO(caseid, "pg1.2");
            if (value != "")
            {
                report.pg1_2.Text = value;
            }
          
            value = save.getValueBRONCO(caseid, "pg1.3");
            if (value != "")
            {
                report.pg1_3.Text = value;
            }
            value = save.getValueBRONCO(caseid, "pg2.1");
            if (value != "")
            {
                report.pg2_1.Text = value;
            }
            value = save.getValueBRONCO(caseid, "pg2.2");
            if (value != "")
            {
                report.pg2_2.Text = value;
            }
            value = save.getValueBRONCO(caseid, "pg6.1");
            if (value != "")
            {
                report.pg6_1.Text = value;
            }
            value = save.getValueBRONCO(caseid, "pg7.1");
            if (value != "")
            {
                report.pg7_1.Text = value;
            }
            value = save.getValueBRONCO(caseid, "pg7.2");
            if (value != "")
            {
                report.pg7_2.Text = value;
            }

            value = save.getValueBRONCO(caseid, "pg8.1");
            if (value != "")
            {
                report.pg8_1.Text = value;
            }
            value = save.getValueBRONCO(caseid, "pg9.1");
            if (value != "")
            {
                report.pg9_1.Text = value;
            }
            value = save.getValueBRONCO(caseid, "pg9.2");
            if (value != "")
            {
                report.pg9_2.Text = value;
            }
            value = save.getValueBRONCO(caseid, "pg9.3");
            if (value != "")
            {
                report.pg9_3.Text = value;
            }
            value = save.getValueBRONCO(caseid, "pg9.4");
            if (value != "")
            {
                report.pg9_4.Text = value;
            }
            value = save.getValueBRONCO(caseid, "pg9.5");
            if (value != "")
            {
                report.pg9_5.Text = value;
            }
            value = save.getValueBRONCO(caseid, "pg26.1");
            if (value != "")
            {
                report.pg26_1.Text = value;
            }
            value = save.getValueBRONCO(caseid, "pg27.1");
            if (value != "")
            {
                report.pg27_1.Text = value;
            }
            value = save.getValueBRONCO(caseid, "pg27.2");
            if (value != "")
            {
                report.pg27_2.Text = value;
            }
            value = save.getValueBRONCO(caseid, "pg33.1");
            if (value != "")
            {
                report.pg33_1.Text = value;
            }
            value = save.getValueBRONCO(caseid, "pg33.2");
            if (value != "")
            {
                report.pg33_2.Text = value;
            }
            value = save.getValueBRONCO(caseid, "pg35.1");
            if (value != "")
            {
                report.pg35_1.Text = value;
            }
            value = save.getValueBRONCO(caseid, "pg43.1");
            if (value != "")
            {
                report.pg43_1.Text = value;
            }
            value = save.getValueBRONCO(caseid, "pg44.1");
            if (value != "")
            {
                report.pg44_1.Text = value;
            }
            value = save.getValueBRONCO(caseid, "pg45.1");
            if (value != "")
            {
                report.pg45_1.Text = value;
            }
            value = save.getValueBRONCO(caseid, "pg46.1");
            if (value != "")
            {
                report.pg46_1.Text = value;
            }
            value = save.getValueBRONCO(caseid, "pg47.1");
            if (value != "")
            {
                report.pg47_1.Text = value;
            }
            value = save.getValueBRONCO(caseid, "pg48.1");
            if (value != "")
            {
                report.pg48_1.Text = value;
            }
            value = save.getValueBRONCO(caseid, "pg49.1");
            if (value != "")
            {
                report.pg49_1.Text = value;
            }
            value = save.getValueBRONCO(caseid, "pg50.1");
            if (value != "")
            {
                report.pg50_1.Text = value;
            }
            value = save.getValueBRONCO(caseid, "pg51.1");
            if (value != "")
            {
                report.pg51_1.Text = value;
            }
            value = save.getValueBRONCO(caseid, "pg52.1");
            if (value != "")
            {
                report.pg52_1.Text = value;
            }
            //
            //cdx
            value = save.getValueBRONCO(caseid, "cdx1");
            if (value != "")
            {
                report.predx.Text = value;
            }
           
            value = save.getValueBRONCO(caseid, "cdx2");
            if (value != "")
            {
                report.indi.Text = value;
            }
            //pdxtxt1
            value = save.getValueBRONCO(caseid, "pdx1");
            if (value != "")
            {
                report.pdx.Text = value;
            }
            
            //bloodloss
            value = save.getValueBRONCO(caseid, "bloodloss");
            if (value != "")
            {
                report.b1txt.Text = value;
            }
            //com










            if (save.getValueBRONCO(caseid, "c1") == "True")
            {
                report.c1.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "c2") == "True")
            {
                report.c5.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "c3") == "True")
            {
                report.c3.Checked = true;
            }

            if (save.getValueBRONCO(caseid, "c4") == "True")
            {
                report.c6.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "c5") == "True")
            {
                report.c7.Checked = true;
            }

            value = save.getValueBRONCO(caseid, "c6");
            if (value != "")
            {
                report.c2.Checked = true;
                report.c2txt.Text = value;
            }
            value = save.getValueBRONCO(caseid, "c7");
            if (value != "")
            {
                report.c4.Checked = true;
                report.c4txt.Text = value;
            }
         
        
            //his
          
            if (save.getValueBRONCO(caseid, "r1") == "True")
            {
                report.ro1.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "r2") == "True")
            {
                report.ro2.Checked = true;
            }
            if (save.getValueBRONCO(caseid, "r3") == "True")
            {
                report.ro3.Checked = true;
            }
            value = save.getValueBRONCO(caseid, "r4");
            if (value != "")
            {
             
                report.ro4.Checked = true;
                report.ro4txt.Text = value;
             

            }
            //
            //comment
            value = save.getValueBRONCO(caseid, "comment");
            if (value != "")
            {
                report.note.Text = value;
            }
            //statue
            value = save.getValueBRONCO(caseid, "sf1");
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
            value = save.getValueBRONCO(caseid, "sf2");
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
            value = save.getValueBRONCO(caseid, "sf3");
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
            value = save.getValueBRONCO(caseid, "sf4");
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
            value = save.getValueBRONCO(caseid, "sf5");
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
            value = save.getValueBRONCO(caseid, "sf6");
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
            value = save.getValueBRONCO(caseid, "sf7");
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
            value = save.getValueBRONCO(caseid, "sf8");
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
            value = save.getValueBRONCO(caseid, "sf9");
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
            value = save.getValueBRONCO(caseid, "sf10");
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
            value = save.getValueBRONCO(caseid, "sf11");
            if (value != "ABNORMAL" && value != "")
            {
                if (value == "NA")
                {
                    setbuttonB(1, report.f11btn, report.f11btn2, report.f11btn3, report.f11txt);
                }
                else
                {
                    setbuttonB(2, report.f11btn, report.f11btn2, report.f11btn3, report.f11txt);
                }

            }
            value = save.getValueBRONCO(caseid, "sf12");
            if (value != "ABNORMAL" && value != "")
            {
                if (value == "NA")
                {
                    setbuttonB(1, report.f12btn, report.f12btn2, report.f12btn3, report.f12txt);
                }
                else
                {
                    setbuttonB(2, report.f12btn, report.f12btn2, report.f12btn3, report.f12txt);
                }

            }
            //
            value = save.getValueBRONCO(caseid, "hn");
            if (value != "")
            {
                info.infohn.Text = value;
            }
            value = save.getValueBRONCO(caseid, "name");
            if (value != "")
            {
                info.infoname.Text = value;
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

            save.addReportFieldnewBRONCO(caseid, data, field);
            save.addReportFieldnewBRONCO(caseid, cdata, cfield);

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

            DataAccess load = new DataAccess();
            string imageName = "";
            string Value = "";
            int k;
            for (int i = 0; i < 66; i++)
            {
                k = i + 1;

                if (load.getValueBRONCO(caseid, "img" + k) != "")
                {
                    Value = load.getValueBRONCO(caseid, "img" + k);
                    //report.setPicture(Value);

                    //top =====================================================================================================
                    int fieldNumber = i + 1;
                    string imagePoint = load.getValueWithTableName(caseid, "image_point", "point_" + fieldNumber + "");

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

                    report.cBoxIndex[i] = Convert.ToInt32(load.getValueBRONCO(caseid, "cb" + k));
                    report.cBoxes[i].SelectedIndex = report.cBoxIndex[i];
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

