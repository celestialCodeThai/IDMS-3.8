using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Drawing;

using Rectangle = iTextSharp.text.Rectangle;
using Image = System.Drawing.Image;
using Font = iTextSharp.text.Font;
using System.Diagnostics;
using IDMS.Page;

namespace IDMS.ReportContent
{
    class PdfENT
    {
        bool page2, page3, page4, page5, page6;
        const int BODY_X = 65;
        const int SMALL_GAP = 2;
        const int IMG_SIZE = 130;

        public PdfENT(imageReport output)
        {
            if (output.pic9.Enabled == true)
            {
                page2 = true;
            }
            if (output.pic21.Enabled == true)
            {
                page3 = true;
            }
            if (output.pic33.Enabled == true)
            {
                page4 = true;
            }
            if (output.pic45.Enabled == true)
            {
                page5 = true;
            }
            if (output.pic57.Enabled == true)
            {
                page6 = true;
            }

        }
        public String specialCharReplace(String hn)
        {
            String hid = hn;

            string[] regEx = { "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "+", "=", "|", "\\", "[", "]", "{", "}", "/", "'" };

            for (int i = 0; i < regEx.Length; i++)
            {
                if (hid.Contains(regEx[i])) { hid = hid.Replace(regEx[i], "_"); }
            }

            //if (hid.Contains("'")) { hid = hid.Replace("'", "_"); }
            //if (hid.Contains('\\')) { hid = hid.Replace('\\', '_'); }
            //if (hid.Contains('/')) { hid = hid.Replace('/', '_'); }


            return hid;
        }

        public void GEN_PdfEGD(String PRO, imageReport output, Report report, reportControlENT ERCP, string ORIGINAL_ID, bool Multimode)
        {
            string filename = specialCharReplace(report.infohn.Text);
            string Filesave = "";
            Document doc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            Filesave = IDMS.World.Settings.savePath + "/images/" + specialCharReplace(ORIGINAL_ID) + "/" + PRO + "-HN " + filename + "-TIME " + DateTime.Now.ToString("HH") + "." + DateTime.Now.ToString("mm") + "." + DateTime.Now.ToString("ss") + ".pdf";

            string imgFolder = IDMS.World.Settings.savePath + "/images/" + specialCharReplace(ORIGINAL_ID) + "/" + PRO + "/";
            string imgFolder_oldversion = IDMS.World.Settings.savePath + "/" + specialCharReplace(ORIGINAL_ID) + "/" + PRO + "/";

            imgFolder_oldversion = imgFolder_oldversion.Replace("idmsCASE", "idmsData");

            if ((!System.IO.Directory.Exists(imgFolder)) && (!System.IO.Directory.Exists(imgFolder_oldversion)))
            {
                return;
            }

            if ((!System.IO.Directory.Exists(imgFolder)) && (System.IO.Directory.Exists(imgFolder_oldversion)))
            {
                imgFolder = imgFolder_oldversion;
                Filesave = imgFolder + PRO + "-HN " + filename + "-TIME " + DateTime.Now.ToString("HH") + "." + DateTime.Now.ToString("mm") + "." + DateTime.Now.ToString("ss") + ".pdf";
            }

            Document pdfDoc = new Document(PageSize.A4, 0, 0, 0, 0);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(Filesave, FileMode.Create));

            DataManage.DataAccess load = new DataManage.DataAccess();

            string pictureMode = load.getOption("option_value", "pictureMode");
            bool squareMode = pictureMode == "1";

            pdfDoc.Open();
            pdfDoc.Add(GetHeader(pdfDoc, writer, PRO, report));
            pdfDoc.Add(GetBodyERCP(pdfDoc, writer, report, ERCP, output));

            if (squareMode) { pdfDoc.Add(GetImg(pdfDoc, writer, output)); }
            else { pdfDoc.Add(GetImg_Wide(pdfDoc, writer, output)); }

            if (page2)
            {
                pdfDoc.NewPage();
                pdfDoc.Add(GetHeader(pdfDoc, writer, PRO, report));
                pdfDoc.Add(GetImg2(pdfDoc, writer, 2, output));
                if (squareMode) { pdfDoc.Add(GetImg2(pdfDoc, writer, 2, output)); }
                else { pdfDoc.Add(GetImg2_Wide(pdfDoc, writer, 2, output)); }
            }
            if (page3)
            {
                pdfDoc.NewPage();
                pdfDoc.Add(GetHeader(pdfDoc, writer, PRO, report));
                if (squareMode) { pdfDoc.Add(GetImg2(pdfDoc, writer, 3, output)); }
                else { pdfDoc.Add(GetImg2_Wide(pdfDoc, writer, 3, output)); }
            }
            if (page4)
            {
                pdfDoc.NewPage();
                pdfDoc.Add(GetHeader(pdfDoc, writer, PRO, report));
                if (squareMode) { pdfDoc.Add(GetImg2(pdfDoc, writer, 4, output)); }
                else { pdfDoc.Add(GetImg2_Wide(pdfDoc, writer, 4, output)); }
            }
            if (page5)
            {
                pdfDoc.NewPage();
                pdfDoc.Add(GetHeader(pdfDoc, writer, PRO, report));
                if (squareMode) { pdfDoc.Add(GetImg2(pdfDoc, writer, 5, output)); }
                else { pdfDoc.Add(GetImg2_Wide(pdfDoc, writer, 5, output)); }
            }
            if (page6)
            {
                pdfDoc.NewPage();
                pdfDoc.Add(GetHeader(pdfDoc, writer, PRO, report));
                if (squareMode) { pdfDoc.Add(GetImg2(pdfDoc, writer, 6, output)); }
                else { pdfDoc.Add(GetImg2_Wide(pdfDoc, writer, 6, output)); }
            }
            pdfDoc.Close();

            if (load.getusbtext("1", "IS_USE") == "1")
            {
                string sourceFile = Filesave;
                string Filesave2;
                string PATH = load.getusbtext("1", "USB_PATH");

                if (Directory.Exists(PATH))
                {
                    if (!Directory.Exists(PATH + "\\images"))
                        Directory.CreateDirectory(PATH + "\\images\\");

                    string current_fullpath_local = String.Format("{0}\\{1}", PATH, "\\images");
                    if (!Directory.Exists(current_fullpath_local))
                        Directory.CreateDirectory(current_fullpath_local);

                    string current_fullpath_img_local = String.Format("{0}\\" + ORIGINAL_ID + "\\" + PRO + "\\", current_fullpath_local);
                    if (!Directory.Exists(current_fullpath_local + "\\" + ORIGINAL_ID + "\\" + PRO + "\\"))
                        Directory.CreateDirectory(current_fullpath_local + "\\" + ORIGINAL_ID + "\\" + PRO + "\\");

                    Filesave2 = PATH + "/images/" + ORIGINAL_ID + "/" + PRO + "-HN " + filename + "-TIME " + DateTime.Now.ToString("HH") + "." + DateTime.Now.ToString("mm") + "." + DateTime.Now.ToString("ss") + ".pdf";
                    string destinationFile = Filesave2;
                    System.IO.File.Copy(sourceFile, destinationFile);
                    System.Diagnostics.Process.Start(destinationFile);
                }
                else
                {
                    System.Diagnostics.Process.Start(Filesave);
                }
            }
            else
            {
                System.Diagnostics.Process.Start(Filesave);
            }

        }

        public iTextSharp.text.Image getHeadImg(String PRO)
        {
            string projectDirectory;
            projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;

            DataManage.DataAccess Load = new DataManage.DataAccess();
            projectDirectory += "\\Resources\\" + Load.getsettingValue("1", "Logo");
            iTextSharp.text.Image PNG = null;

            PNG = iTextSharp.text.Image.GetInstance(Image.FromFile(projectDirectory), System.Drawing.Imaging.ImageFormat.Png);

            return PNG;
        }

        private PdfPTable GetHeader2(Document pdfDoc, PdfWriter writer, String PRO, Page.Report report)
        {
            iTextSharp.text.Font fntTableFontHdr = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            PdfPTable headerTable = new PdfPTable(2);
            headerTable.TotalWidth = 530f;
            headerTable.HorizontalAlignment = 0;
            headerTable.SpacingAfter = 20;

            float[] headerTableColWidth = new float[2];
            headerTableColWidth[0] = 375f;
            headerTableColWidth[1] = 155f;

            headerTable.SetWidths(headerTableColWidth);
            headerTable.LockedWidth = true;

            iTextSharp.text.Image png = null;
            png = getHeadImg(PRO);

            png.ScaleAbsolute(50, 50);
            png.SetAbsolutePosition(150, 150);

            PdfPCell headerTableCell_0 = new PdfPCell(png);
            headerTableCell_0.HorizontalAlignment = Element.ALIGN_LEFT;
            headerTableCell_0.Border = Rectangle.NO_BORDER;
            headerTable.AddCell(headerTableCell_0);



            PdfPCell headerTableCell_1 = new PdfPCell();
            //   headerTable.AddCell(new Paragraph("Hello World!"));


            headerTableCell_1.HorizontalAlignment = Element.ALIGN_LEFT;
            // headerTableCell_1.VerticalAlignment = Element.ALIGN_BOTTOM;
            headerTableCell_1.Border = Rectangle.NO_BORDER;
            headerTable.AddCell(headerTableCell_1);


            PdfContentByte cb = writer.DirectContent;
            cb.MoveTo(375f, pdfDoc.PageSize.Height - 75f);
            cb.LineTo(375f, pdfDoc.PageSize.Height - 5);
            cb.Stroke();

            cb.MoveTo(375f, pdfDoc.PageSize.Height - 5);
            cb.LineTo(pdfDoc.PageSize.Width - 5, pdfDoc.PageSize.Height - 5);
            cb.Stroke();

            cb.MoveTo(pdfDoc.PageSize.Width - 5, pdfDoc.PageSize.Height - 5);
            cb.LineTo(pdfDoc.PageSize.Width - 5, pdfDoc.PageSize.Height - 75f);
            cb.Stroke();

            cb.MoveTo(375f, pdfDoc.PageSize.Height - 75f);
            cb.LineTo(pdfDoc.PageSize.Width - 5, pdfDoc.PageSize.Height - 75f);
            cb.Stroke();

            cb.MoveTo(0f, pdfDoc.PageSize.Height - 80f);
            cb.LineTo(875f, pdfDoc.PageSize.Height - 80f);
            cb.Stroke();

            iTextSharp.text.Font f1 = FontFactory.GetFont("ANGSA", 11, iTextSharp.text.Font.NORMAL, new BaseColor(54, 103, 255));
            //BaseFont bf = BaseFont.CreateFont("c:/windows/Fonts/ANGSA_0.TTF"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            //thai Font
            BaseFont bf = BaseFont.CreateFont("c:/windows/fonts/micross.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            iTextSharp.text.Font Thai = new Font(bf, 10);

            //
            ColumnText ct = new ColumnText(cb);
            ColumnText ct1 = new ColumnText(cb);

            ColumnText ct2 = new ColumnText(cb);

            ColumnText ct3 = new ColumnText(cb);

            ColumnText ct4 = new ColumnText(cb);

            ColumnText ct5 = new ColumnText(cb);
            ColumnText ct6 = new ColumnText(cb);

            ColumnText h1 = new ColumnText(cb);
            ColumnText h2 = new ColumnText(cb);
            ColumnText h3 = new ColumnText(cb);
            ColumnText h4 = new ColumnText(cb);
            ColumnText h5 = new ColumnText(cb);
            ColumnText h6 = new ColumnText(cb);
            ColumnText h7 = new ColumnText(cb);
            ColumnText h8 = new ColumnText(cb);

            Phrase headerHN = new Phrase("HN#:", f1);
            Phrase headerNAME = new Phrase("Name:", f1);
            Phrase headerPRO = new Phrase("Procedure:", f1);
            Phrase headerREGIS = new Phrase("Register Date:", f1);
            Phrase headerDuration = new Phrase("Duration:", f1);
            Phrase headerSEX = new Phrase("Sex:", f1);
            Phrase headerAGE = new Phrase("Age:", f1);

            string H1 = report.infohn.Text; Phrase getHN = new Phrase(H1, Thai);
            string H2 = report.infoname.Text; Phrase getNAME = new Phrase(H2, Thai);
            string H3 = report.infopro.Text; Phrase getPRO = new Phrase(H3, Thai);
            string H4 = report.inforegis.Text; Phrase getREGIS = new Phrase(H4, Thai);
            string H5 = report.Duration.Text; ; Phrase getDUR = new Phrase(H5, Thai);
            string H6 = report.infosex.Text; Phrase getSEX = new Phrase(H6, Thai);
            string H7 = report.infoage.Text; Phrase getAGE = new Phrase(H7, Thai);

            ct.SetSimpleColumn(headerHN, 379, 840, 580, 317, 15, Element.ALIGN_LEFT);
            ct1.SetSimpleColumn(headerNAME, 379, 827, 580, 317, 15, Element.ALIGN_LEFT);
            ct2.SetSimpleColumn(headerPRO, 379, 814, 580, 317, 15, Element.ALIGN_LEFT);
            ct3.SetSimpleColumn(headerREGIS, 379, 801, 580, 317, 15, Element.ALIGN_LEFT);
            ct4.SetSimpleColumn(headerDuration, 379, 788, 580, 317, 15, Element.ALIGN_LEFT);
            ct5.SetSimpleColumn(headerSEX, 475, 840, 580, 317, 15, Element.ALIGN_LEFT);
            ct6.SetSimpleColumn(headerAGE, 540, 840, 580, 317, 15, Element.ALIGN_LEFT);
            ct.Go();
            ct1.Go();
            ct2.Go();
            ct3.Go();
            ct4.Go();
            ct5.Go();
            ct6.Go();

            h1.SetSimpleColumn(getHN, 379 + 27, 840, 580, 317, 15, Element.ALIGN_LEFT); h1.Go();
            h2.SetSimpleColumn(getNAME, 379 + 35, 827, 580, 317, 15, Element.ALIGN_LEFT); h2.Go();
            h3.SetSimpleColumn(getPRO, 379 + 60, 814, 580, 317, 15, Element.ALIGN_LEFT); h3.Go();
            h4.SetSimpleColumn(getREGIS, 379 + 75, 801, 580, 317, 15, Element.ALIGN_LEFT); h4.Go();
            h5.SetSimpleColumn(getDUR, 379 + 50, 788, 580, 317, 15, Element.ALIGN_LEFT); h5.Go();
            h6.SetSimpleColumn(getSEX, 475 + 25, 840, 580, 317, 15, Element.ALIGN_LEFT); h6.Go();
            h7.SetSimpleColumn(getAGE, 540 + 25, 840, 580, 317, 15, Element.ALIGN_LEFT); h7.Go();



            return headerTable;
        }
        public static int BodyEnd;
        //reportBody
        private PdfPTable GetBodyERCP(Document pdfDoc, PdfWriter writer, Report report, reportControlENT reportControl, imageReport output)
        {
            PdfPTable BodyTable = new PdfPTable(2);
            PdfContentByte cb = writer.DirectContent;

            iTextSharp.text.Font f1 = FontFactory.GetFont("Roboto", 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font f2 = FontFactory.GetFont("Roboto", 10, iTextSharp.text.Font.NORMAL, new BaseColor(54, 103, 255));
            BaseFont bf = BaseFont.CreateFont("c:/windows/fonts/micross.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            Font Thai = new Font(bf, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            Font ThaiGreen = new Font(bf, 10, iTextSharp.text.Font.NORMAL, BaseColor.GREEN);

            Font ThaiRed = new Font(bf, 10, iTextSharp.text.Font.NORMAL, BaseColor.RED);

            ColumnText ct = new ColumnText(cb);
            ColumnText ct1 = new ColumnText(cb);
            ColumnText ct2 = new ColumnText(cb);
            ColumnText ct3 = new ColumnText(cb);
            ColumnText ct4 = new ColumnText(cb);
            ColumnText ct5 = new ColumnText(cb);
            ColumnText ct6 = new ColumnText(cb);
            ColumnText ct7 = new ColumnText(cb);
            ColumnText ct8 = new ColumnText(cb);
            ColumnText ct9 = new ColumnText(cb);
            ColumnText ct10 = new ColumnText(cb);
            ColumnText ct11 = new ColumnText(cb);

            ColumnText finding = new ColumnText(cb);
            ColumnText finding3b = new ColumnText(cb);
            ColumnText finding8b = new ColumnText(cb);

            ColumnText finding1 = new ColumnText(cb);
            ColumnText finding2 = new ColumnText(cb);
            ColumnText finding3 = new ColumnText(cb);
            ColumnText finding4 = new ColumnText(cb);
            ColumnText finding5 = new ColumnText(cb);
            ColumnText finding6 = new ColumnText(cb);
            ColumnText finding7 = new ColumnText(cb);
            ColumnText finding8 = new ColumnText(cb);
            ColumnText finding9 = new ColumnText(cb);
            ColumnText finding10 = new ColumnText(cb);




            Phrase headerBody = new Phrase("Case's information", f1);
            Phrase DocBody = new Phrase("Endoscopist:", f2);
            Phrase NurseBody = new Phrase("Referring Physician:", f2);
            Phrase AnesBody = new Phrase("Procedure Performed:", f2);
            Phrase MedBody = new Phrase("Medication:", f2);
            Phrase InstBody = new Phrase("Instrument:", f2);
            Phrase IndiBody = new Phrase("Indication:", f2);
            Phrase PreDxBody = new Phrase("Pre-diagnosis:", f2);
            Phrase HistorytBody = new Phrase("Patient history:", f2);

            Phrase AntBody = new Phrase("Scrub nurse:", f2);

            Phrase CNurseBody = new Phrase("Circulation nurse:", f2);
            Phrase ProRoomBody = new Phrase("Procedure room:", f2);

            ColumnText d1 = new ColumnText(cb);
            ColumnText d2 = new ColumnText(cb);
            ColumnText d3 = new ColumnText(cb);
            ColumnText d4 = new ColumnText(cb);
            ColumnText d5 = new ColumnText(cb);
            ColumnText d6 = new ColumnText(cb);
            ColumnText d7 = new ColumnText(cb);
            ColumnText d8 = new ColumnText(cb);
            ColumnText d9 = new ColumnText(cb);
            ColumnText d10 = new ColumnText(cb);
            ColumnText d11 = new ColumnText(cb);

            ColumnText df1 = new ColumnText(cb);
            ColumnText df2 = new ColumnText(cb);
            ColumnText df3 = new ColumnText(cb);
            ColumnText df4 = new ColumnText(cb);
            ColumnText df5 = new ColumnText(cb);
            ColumnText df6 = new ColumnText(cb);
            ColumnText df7 = new ColumnText(cb);
            ColumnText df8 = new ColumnText(cb);
            ColumnText df9 = new ColumnText(cb);
            ColumnText df10 = new ColumnText(cb);
            ColumnText df11 = new ColumnText(cb);

            //get datainfo
            string docname = report.infodoc.Text; Phrase getDocname = new Phrase(docname, Thai);
            string snursename = reportControl.a5txt.Text; Phrase getNursename = new Phrase(snursename, Thai);
            string antname = reportControl.PP.Text;




            string anesname = report.infosnurse.Text;
            Phrase getAnesname = new Phrase(anesname, Thai);

            Phrase getAntname = new Phrase(antname, Thai);

            string medname = "";

            if (reportControl.med1.Checked == true) { if (medname != "") { medname += ", "; } medname += reportControl.med1.Text + " " + reportControl.med1txt.Text + " mg"; }
            if (reportControl.med2.Checked == true) { if (medname != "") { medname += ", "; } medname += reportControl.med2.Text + " " + reportControl.med2txt.Text + " mg"; }
            if (reportControl.med3.Checked == true) { if (medname != "") { medname += ", "; } medname += reportControl.med3.Text + " " + reportControl.med3txt.Text + " mg"; }
            if (reportControl.med4.Checked == true) { if (medname != "") { medname += ", "; } medname += reportControl.med4.Text + " " + reportControl.med4txt.Text + " mg"; }
            if (reportControl.med5.Checked == true) { if (medname != "") { medname += ", "; } medname += reportControl.med5.Text + " " + reportControl.med5txt.Text + " mcg"; }
            if (reportControl.med6.Checked == true) { if (medname != "") { medname += ", "; } medname += reportControl.med6txt.Text + " mg"; }
            if (reportControl.med7.Checked == true) { if (medname != "") { medname += ", "; } medname += reportControl.med7.Text + " " + reportControl.med7txt.Text + " mg"; }


            Phrase getMedname = new Phrase(medname, Thai);

            string instname = report.infoinstrument.Text;
            if (report.in2.Text != "" && instname != "")
            {
                instname += ", ";
                instname += report.in2.Text;
            }

            Phrase getInstname = new Phrase(instname, Thai);
            string indiname = "";

            if (reportControl.r1.Checked == true) { if (indiname != "") { indiname += ", "; } indiname += reportControl.r1.Text; }
            if (reportControl.r2.Checked == true) { if (indiname != "") { indiname += ", "; } indiname += reportControl.r2.Text; }
            if (reportControl.r3.Checked == true) { if (indiname != "") { indiname += ", "; } indiname += reportControl.r3.Text; }
            if (reportControl.r4.Checked == true) { if (indiname != "") { indiname += ", "; } indiname += reportControl.r4.Text; }

            if (reportControl.r8.Checked == true) { if (indiname != "") { indiname += ", "; } indiname += reportControl.r82.Text; }

            Phrase getIndiname = new Phrase(indiname, Thai);



            string pdxname = ""; int predxCount = 0;
            if (report.pdx1.Text != "") { predxCount = 1; }
            if (report.pdx2.Text != "") { predxCount = 2; }
            if (report.pdx3.Text != "") { predxCount = 3; }
            if (report.pdx4.Text != "") { predxCount = 4; }

            if (predxCount == 1)
            {
                pdxname = report.pdx1.Text;

            }
            if (predxCount == 2)
            {
                pdxname = report.pdx1.Text + ", " + report.pdx2.Text;

            }
            if (predxCount == 3)
            {
                pdxname = report.pdx1.Text + ", " + report.pdx2.Text + ", " + report.pdx3.Text;


            }
            if (predxCount == 4)
            {
                pdxname = report.pdx1.Text + ", " + report.pdx2.Text + ", " + report.pdx3.Text + ", " + report.pdx4.Text;

            }




            Phrase getPdx = new Phrase(pdxname, Thai);
            string hisname = "";
            hisname = reportControl.commentText.Text;




            Phrase getHisname = new Phrase(hisname, Thai);
            string cnursename = report.infocnurse.Text; Phrase getCnursename = new Phrase(cnursename, Thai);
            string proroomname = report.infoproroom.Text; Phrase getproroomname = new Phrase(proroomname, Thai);
            //

            int BodyX = 70; int BodyY = 745; int BodySpace = 13;
            int BodyX2 = 230;
            ct.SetSimpleColumn(headerBody, BodyX - 5, BodyY + 15, 580, 317, 15, Element.ALIGN_LEFT);
            ct1.SetSimpleColumn(DocBody, BodyX, BodyY, 580, 317, 15, Element.ALIGN_LEFT);
            ct2.SetSimpleColumn(NurseBody, BodyX, BodyY - BodySpace, 580, 317, 15, Element.ALIGN_LEFT);
            ct4.SetSimpleColumn(AnesBody, BodyX, BodyY - (BodySpace * 2), 580, 317, 15, Element.ALIGN_LEFT);
            ct5.SetSimpleColumn(MedBody, BodyX, BodyY - (BodySpace * 3), 580, 317, 15, Element.ALIGN_LEFT);
            ct6.SetSimpleColumn(InstBody, BodyX, BodyY - (BodySpace * 4), 580, 317, 15, Element.ALIGN_LEFT);
            ct7.SetSimpleColumn(IndiBody, BodyX, BodyY - (BodySpace * 5), 580, 317, 15, Element.ALIGN_LEFT);

            ct8.SetSimpleColumn(PreDxBody, BodyX, BodyY - (BodySpace * 6), 580, 317, 15, Element.ALIGN_LEFT);
            //
            //
            ct3.SetSimpleColumn(AntBody, BodyX + BodyX2, BodyY, 580, 317, 15, Element.ALIGN_LEFT);
            ct10.SetSimpleColumn(CNurseBody, BodyX + BodyX2, BodyY - BodySpace, 580, 317, 15, Element.ALIGN_LEFT);
            ct11.SetSimpleColumn(ProRoomBody, BodyX + BodyX2, BodyY - (BodySpace * 2), 580, 317, 15, Element.ALIGN_LEFT);




            int infoX = BodyX + 75; int infoX2 = 235;

            d1.SetSimpleColumn(getDocname, infoX, BodyY, 580, 317, 15, Element.ALIGN_LEFT); d1.Go();
            d2.SetSimpleColumn(getNursename, infoX + 30, BodyY - BodySpace, 580, 317, 15, Element.ALIGN_LEFT); d2.Go();
            d4.SetSimpleColumn(getAntname, infoX + 30, BodyY - (BodySpace * 2), 580, 317, 15, Element.ALIGN_LEFT); d4.Go();
            d5.SetSimpleColumn(getMedname, infoX, BodyY - (BodySpace * 3), 580, 317, 15, Element.ALIGN_LEFT); d5.Go();
            d6.SetSimpleColumn(getInstname, infoX, BodyY - (BodySpace * 4), 580, 317, 15, Element.ALIGN_LEFT); d6.Go();
            d7.SetSimpleColumn(getIndiname, infoX, BodyY - (BodySpace * 5), 580, 317, 15, Element.ALIGN_LEFT); d7.Go();
            d8.SetSimpleColumn(getPdx, infoX, BodyY - (BodySpace * 6), 580, 317, 15, Element.ALIGN_LEFT); d8.Go();




            ct9.SetSimpleColumn(HistorytBody, BodyX, BodyY - (BodySpace * 7), 580, 317, 15, Element.ALIGN_LEFT);

            d9.SetSimpleColumn(getHisname, infoX, BodyY - (BodySpace * 7), 580, 317, 15, Element.ALIGN_LEFT); d9.Go();


            int HIS_BODY = BodyY - (BodySpace * 9);
            int newline = calculatePDFWidth(hisname, 83);
            if (newline > 0)
            {

                HIS_BODY -= (15 * newline);

            }


            d3.SetSimpleColumn(getAnesname, infoX + infoX2, BodyY, 580, 317, 15, Element.ALIGN_LEFT); d3.Go();
            d10.SetSimpleColumn(getCnursename, infoX + infoX2, BodyY - BodySpace, 580, 317, 15, Element.ALIGN_LEFT); d10.Go();
            d11.SetSimpleColumn(getproroomname, infoX + infoX2, BodyY - (BodySpace * 2), 580, 317, 15, Element.ALIGN_LEFT); d11.Go();


            ct.Go();
            ct1.Go();
            ct2.Go();
            ct3.Go();
            ct4.Go();
            ct5.Go();
            ct6.Go();
            ct7.Go();
            ct8.Go();
            ct9.Go();
            ct10.Go();
            ct11.Go();

            //Right picture
            //    resources.GetObject("panel5.BackgroundImage")
            /*
            iTextSharp.text.Image png = null;

            png = iTextSharp.text.Image.GetInstance(IDMS.Properties.Resources.ercp, System.Drawing.Imaging.ImageFormat.Png);
            png.SetAbsolutePosition(BodyX + BodyX2 + 155, 610);

            png.ScaleAbsolute(145, 150);
            pdfDoc.Add(png);
            */
            //text
            string lp1 = "", lp2 = "", lp3 = "", lp4 = "", lp5 = "", lp6 = "", lp7 = "", lp8 = "", lp9 = "";


            lp1 += output.mark1[0];
            lp2 += output.mark1[1];
            lp3 += output.mark1[2];
            lp4 += output.mark1[3];
            lp5 += output.mark1[4];
            lp6 += output.mark1[5];
            lp7 += output.mark1[6];
            lp8 += output.mark1[7];
            lp9 += output.mark1[8];

            PlaceChunckIMG(writer, lp9, BodyX + BodyX2 + 160, 630);
            PlaceChunckIMG(writer, lp8, BodyX + BodyX2 + 165, 670);
            PlaceChunckIMG(writer, lp7, BodyX + BodyX2 + 200, 670);
            PlaceChunckIMG(writer, lp6, BodyX + BodyX2 + 230, 650);
            PlaceChunckIMG(writer, lp5, BodyX + BodyX2 + 250, 670);
            PlaceChunckIMG(writer, lp4, BodyX + BodyX2 + 270, 720);
            PlaceChunckIMG(writer, lp3, BodyX + BodyX2 + 240, 705);
            PlaceChunckIMG(writer, lp2, BodyX + BodyX2 + 230, 730);

            //
            int BGAP = 5;
            cb.MoveTo(BodyX - 10, HIS_BODY + BGAP);
            cb.LineTo(BodyX + 30, HIS_BODY + BGAP);
            cb.Stroke();

            //  BaseFont.getWidthPoint("test", 11f);
            int FindingY = HIS_BODY + BGAP;
            Phrase F00 = null, F01 = null, F02 = null, F03 = null, F04 = null, F05 = null, F06 = null, F07 = null, F08 = null, F09 = null, F10 = null, F03b = null, F08b = null;

            F00 = new Phrase("Finding", f1);




            //get datafindinginfo
            string fd1 = ""; Phrase getFD1 = null;
            fd1 = reportControl.f8txt.Text;
            fd1 = cutEnter(fd1);
            getFD1 = new Phrase(fd1, Thai);







            int FX = BodyX + 65; int extraline; int gap = 15; int j;

            //

            finding.SetSimpleColumn(F00, BodyX - 5, FindingY, 580, 317, 15, Element.ALIGN_LEFT);
            //f1
            int f1y = FindingY - BodySpace;
            finding1.SetSimpleColumn(F01, BodyX, f1y, 580, 317, 15, Element.ALIGN_LEFT);
            df1.SetSimpleColumn(getFD1, FX, f1y, 580, 317, 15, Element.ALIGN_LEFT); df1.Go();


            //f2
            int f2y = FindingY - (BodySpace * 2);
            extraline = calculatePDFWidth(fd1, 80);
            if (extraline > 0)
            {
                j = gap * extraline;
                f2y -= j;

            }



            finding.Go();
            finding1.Go(); finding2.Go(); finding3.Go(); finding4.Go(); finding5.Go(); finding6.Go(); finding7.Go(); finding8.Go();
            //Lin            int Fline = f6y - BodySpace;


            cb.MoveTo(BodyX - 10, f2y - 10);
            cb.LineTo(BodyX + 30, f2y - 10);
            cb.Stroke();
            //LastBodyPart
            ColumnText lb1 = new ColumnText(cb);
            ColumnText lb2 = new ColumnText(cb);
            ColumnText lb3 = new ColumnText(cb);
            ColumnText lb4 = new ColumnText(cb);
            ColumnText lb5 = new ColumnText(cb);
            ColumnText lb6 = new ColumnText(cb);
            ColumnText lb7 = new ColumnText(cb);
            ColumnText lb8 = new ColumnText(cb);

            ColumnText l1 = new ColumnText(cb);
            ColumnText l2 = new ColumnText(cb);
            ColumnText l3 = new ColumnText(cb);
            ColumnText l4 = new ColumnText(cb);
            ColumnText l5 = new ColumnText(cb);
            ColumnText l6 = new ColumnText(cb);
            ColumnText l7 = new ColumnText(cb);
            ColumnText l8 = new ColumnText(cb);
            iTextSharp.text.Font f3 = FontFactory.GetFont("Roboto", 14, iTextSharp.text.Font.BOLD, BaseColor.RED);

            Phrase LB1 = new Phrase("Speciments:", f2);
            Phrase LB2 = new Phrase("Post-diagnosis:", f3);
            Phrase LB4 = new Phrase("Complication:", f2);
            Phrase LB5 = new Phrase("Comment:", f2);




            //info
            string L1;

            string ptxt = "";


            if (reportControl.his1.Checked == true)
            {
                { if (ptxt != "") { ptxt += ", "; } ptxt += reportControl.his1.Text + " "; }
                if (reportControl.s0.Checked == true) ptxt += reportControl.s0.Text + " ";
                if (reportControl.s1.Checked == true) ptxt += reportControl.s1.Text + " ";
                if (reportControl.s2.Checked == true) ptxt += reportControl.s2.Text + " ";
                if (reportControl.s3.Checked == true) ptxt += reportControl.s3.Text + " ";
                if (reportControl.s4.Checked == true) ptxt += reportControl.s4.Text + " ";
                if (reportControl.s5.Checked == true) ptxt += reportControl.s5.Text + " " + reportControl.s6.Text;

            }

            if (reportControl.his2.Checked == true)
            {
                { if (ptxt != "") { ptxt += ", "; } ptxt += reportControl.his2txt.Text; }
                if (reportControl.s7.Checked == true) ptxt += reportControl.s7.Text + " ";
                if (reportControl.s8.Checked == true) ptxt += reportControl.s8.Text + " ";
                if (reportControl.s9.Checked == true) ptxt += reportControl.s9.Text + " ";
                if (reportControl.s10.Checked == true) ptxt += reportControl.s10.Text + " ";
                if (reportControl.s11.Checked == true) ptxt += reportControl.s11.Text + " ";
                if (reportControl.s12.Checked == true) ptxt += reportControl.s12.Text + " " + reportControl.s13.Text;
            }
            if (reportControl.his3.Checked == true)
            {
                { if (ptxt != "") { ptxt += ", "; } ptxt += reportControl.his3txt.Text; }
                if (reportControl.s14.Checked == true) ptxt += reportControl.s14.Text + " ";
                if (reportControl.s15.Checked == true) ptxt += reportControl.s15.Text + " ";
                if (reportControl.s16.Checked == true) ptxt += reportControl.s16.Text + " ";
                if (reportControl.s17.Checked == true) ptxt += reportControl.s17.Text + " ";
                if (reportControl.s18.Checked == true) ptxt += reportControl.s18.Text + " ";
                if (reportControl.s19.Checked == true) ptxt += reportControl.s19.Text + " " + reportControl.s20.Text;
            }
            if (reportControl.his4.Checked == true)
            {
                { if (ptxt != "") { ptxt += ", "; } ptxt += reportControl.his4txt.Text; }
                if (reportControl.s21.Checked == true) ptxt += reportControl.s21.Text + " ";
                if (reportControl.s22.Checked == true) ptxt += reportControl.s22.Text + " ";
                if (reportControl.s23.Checked == true) ptxt += reportControl.s23.Text + " ";
                if (reportControl.s24.Checked == true) ptxt += reportControl.s24.Text + " ";
                if (reportControl.s25.Checked == true) ptxt += reportControl.s25.Text + " ";
                if (reportControl.s26.Checked == true) ptxt += reportControl.s26.Text + " " + reportControl.s27.Text;
            }

            if (reportControl.his5.Checked == true)
            {
                { if (ptxt != "") { ptxt += ", "; } ptxt += reportControl.his5txt.Text; }
                if (reportControl.s28.Checked == true) ptxt += reportControl.s28.Text + " ";
                if (reportControl.s29.Checked == true) ptxt += reportControl.s29.Text + " ";
                if (reportControl.s30.Checked == true) ptxt += reportControl.s30.Text + " ";
                if (reportControl.s31.Checked == true) ptxt += reportControl.s31.Text + " ";
                if (reportControl.s32.Checked == true) ptxt += reportControl.s32.Text + " ";
                if (reportControl.s33.Checked == true) ptxt += reportControl.s33.Text + " " + reportControl.s34.Text;

            }


            L1 = ptxt;

            Phrase getL1 = new Phrase(L1, Thai);
            string L2 = "2";

            int PostDxCount = 0;

            string spdxtxt = "";

            if (reportControl.dx1.Text != "" || reportControl.pdxtxt1.Text != "") { PostDxCount++; }
            if (reportControl.dx2.Text != "" || reportControl.pdxtxt2.Text != "") { PostDxCount++; }
            if (reportControl.dx3.Text != "" || reportControl.pdxtxt3.Text != "") { PostDxCount++; }
            if (reportControl.dx4.Text != "" || reportControl.pdxtxt4.Text != "") { PostDxCount++; }
            if (PostDxCount > 2)
            {

                //3
                if (reportControl.dx1.Text != "") { spdxtxt += reportControl.dx1.Text + "-"; }
                spdxtxt += reportControl.pdxtxt1.Text;
                spdxtxt += ", ";
                if (reportControl.dx2.Text != "") { spdxtxt += reportControl.dx2.Text + "-"; }
                spdxtxt += reportControl.pdxtxt2.Text;
                spdxtxt += ", ";
                if (reportControl.dx3.Text != "") { spdxtxt += reportControl.dx3.Text + "-"; }
                spdxtxt += reportControl.pdxtxt3.Text;



                if (PostDxCount > 3)
                {
                    spdxtxt += ", ";
                    if (reportControl.dx4.Text != "") { spdxtxt += reportControl.dx4.Text + "-"; }
                    spdxtxt += reportControl.pdxtxt4.Text;


                }
            }
            else
            {
                if (PostDxCount > 0)
                {
                    //1

                    if (reportControl.dx1.Text != "") { spdxtxt += reportControl.dx1.Text + "-"; }
                    spdxtxt += reportControl.pdxtxt1.Text;
                    if (PostDxCount > 1)
                    {
                        //2
                        spdxtxt += ", ";
                        if (reportControl.dx2.Text != "") { spdxtxt += reportControl.dx2.Text + "-"; }
                        spdxtxt += reportControl.pdxtxt2.Text;
                    }
                }

            }

            PostDxCount = 0;
            L2 = spdxtxt;


            string L3 = ""; string L4 = ""; string L5 = "";



            string comtxt = ""; string L7 = "";
            if (reportControl.c1.Checked == true) { if (comtxt != "") { comtxt += ", "; } comtxt += reportControl.c1.Text; }
            if (reportControl.c5.Checked == true) { if (comtxt != "") { comtxt += ", "; } comtxt += reportControl.c5txt.Text; }

            L4 = comtxt;




            string retxt = "";
            if (reportControl.r1.Checked == true) { if (retxt != "") { retxt += ", "; } retxt += reportControl.r1.Text; }
            if (reportControl.r2.Checked == true) { if (retxt != "") { retxt += ", "; } retxt += reportControl.r2.Text; }
            if (reportControl.r3.Checked == true) { if (retxt != "") { retxt += ", "; } retxt += reportControl.r3.Text; }




            L5 = retxt;
            if ((retxt != "") && (reportControl.note.Text != "")) { L5 += "/"; }
            L5 += reportControl.note.Text;


            Phrase getL2 = new Phrase(L2, ThaiRed);
            Phrase getL3 = new Phrase(L3, Thai);
            Phrase getL4 = new Phrase(L4, Thai);
            Phrase getL5 = new Phrase(L5, Thai);



            string histxt = "";

            L4 = histxt;

            Phrase getL7 = new Phrase(L7, Thai);
            int LowerY = f2y - BodySpace; int LowerSpace = 250;
            //
            lb1.SetSimpleColumn(LB1, BodyX, LowerY, 580, 317, 15, Element.ALIGN_LEFT); lb1.Go();
            l1.SetSimpleColumn(getL1, BodyX + 65, LowerY, 580, 317, 15, Element.ALIGN_LEFT); l1.Go();
            //
            int lb2y = LowerY - BodySpace;
            extraline = calculatePDFWidth(L1, 80);
            if (extraline > 0)
            {
                j = gap * extraline;
                lb2y -= j;

            }
            lb2.SetSimpleColumn(LB2, BodyX, lb2y, 580, 317, 15, Element.ALIGN_LEFT); lb2.Go();
            l2.SetSimpleColumn(getL2, BodyX + 110, lb2y, 580, 317, 15, Element.ALIGN_LEFT); l2.Go();
            //
            int lb3y = lb2y - BodySpace;
            extraline = calculatePDFWidth(L2, 71);
            if (extraline > 0)
            {
                j = gap * extraline;
                lb3y -= j;

            }



            int lb4y = lb3y;

            lb4.SetSimpleColumn(LB4, BodyX, lb4y, 580, 317, 15, Element.ALIGN_LEFT); lb4.Go();
            l4.SetSimpleColumn(getL4, BodyX + 70, lb4y, 580, 317, 15, Element.ALIGN_LEFT); l4.Go();

            int lb5y = lb4y - BodySpace;
            lb5.SetSimpleColumn(LB5, BodyX, lb5y, 580, 317, 15, Element.ALIGN_LEFT); lb5.Go();
            l5.SetSimpleColumn(getL5, BodyX + 50, lb5y, 580, 317, 15, Element.ALIGN_LEFT); l5.Go();



            //


            extraline = calculatePDFWidth(L5, 80);
            if (extraline > 0)
            {
                j = gap * extraline;
                lb5y -= j;

            }
            BodyEnd = lb5y - BodySpace;


            return BodyTable;


        }

        private PdfPTable GetImg(Document pdfDoc, PdfWriter writer, imageReport output)
        {
            string[] P1 = new string[] { "A", "B", "C", "D", "E", "F", "G", "H" };
            iTextSharp.text.Image picPdf1 = null, picPdf2 = null, picPdf3 = null, picPdf4 = null, picPdf5 = null, picPdf6 = null, picPdf7 = null, picPdf8 = null;
            iTextSharp.text.Image[] picPDF;
            picPDF = new iTextSharp.text.Image[] { picPdf1, picPdf2, picPdf3, picPdf4, picPdf5, picPdf6, picPdf7, picPdf8 };


            PdfPTable imgTable = new PdfPTable(2);
            PdfContentByte cb = writer.DirectContent;


            iTextSharp.text.Font f1 = FontFactory.GetFont("Roboto", 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font f2 = FontFactory.GetFont("Roboto", 30, iTextSharp.text.Font.BOLD, new BaseColor(54, 103, 255));
            BaseFont bf = BaseFont.CreateFont("c:/windows/fonts/micross.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            Font thai = new Font(bf, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            Font thaiGreen = new Font(bf, 10, iTextSharp.text.Font.NORMAL, BaseColor.GREEN);

            Font thaiRed = new Font(bf, 10, iTextSharp.text.Font.NORMAL, BaseColor.RED);



            int BodyY = BodyEnd - IMG_SIZE - 5;
            int LoopX = BODY_X;
            int LoopY = 200;

            int i = 0;
            for (int e = 0; e < output.imgCount; e++)
            {
                if (output.imgPath[i] != null)
                {
                    if (output.imgPath[i].Contains("ENT") == true)
                    {
                        i++;
                    }
                }

            }
            int imgperpage;
            if (i < 8) { imgperpage = i; } else { imgperpage = 8; }
            for (int z = 0; z < imgperpage; z++)
            {

                Image img = Image.FromFile(output.imgPath[z]);
                iTextSharp.text.Image v = iTextSharp.text.Image.GetInstance(output.MakeSquareEndoWay(img, 500), System.Drawing.Imaging.ImageFormat.Jpeg);
                picPDF[z] = v;
                picPDF[z].ScaleAbsolute(IMG_SIZE, IMG_SIZE);
                picPDF[z].SetAbsolutePosition(LoopX, LoopY);
                pdfDoc.Add(picPDF[z]);
                PlaceChunckB(writer, P1[z], LoopX, LoopY - 15);
                PlaceChunck(writer, output.cBoxes[z].Text, LoopX + 15, LoopY - 15);
                if (z == 3)
                {
                    LoopX = BODY_X; LoopY = LoopY - IMG_SIZE - 20;
                }
                else
                { LoopX += IMG_SIZE + SMALL_GAP; }
            }

            cb.MoveTo(BODY_X + IMG_SIZE * 2 + 50, 15);
            cb.LineTo(BODY_X + IMG_SIZE * 3 + SMALL_GAP * 3 + 125, 15);
            cb.Stroke();
            PlaceChunck(writer, "Signature", BODY_X + IMG_SIZE * 2 + 50, 20);
            return imgTable;

        }

        private PdfPTable GetImg_Wide(Document pdfDoc, PdfWriter writer, imageReport output)
        {
            string[] P1 = new string[] { "A", "B", "C", "D", "E", "F", "G", "H" };
            iTextSharp.text.Image picPdf1 = null, picPdf2 = null, picPdf3 = null, picPdf4 = null, picPdf5 = null, picPdf6 = null, picPdf7 = null, picPdf8 = null;
            iTextSharp.text.Image[] picPDF;
            picPDF = new iTextSharp.text.Image[] { picPdf1, picPdf2, picPdf3, picPdf4, picPdf5, picPdf6, picPdf7, picPdf8 };


            PdfPTable imgTable = new PdfPTable(2);
            PdfContentByte cb = writer.DirectContent;


            iTextSharp.text.Font f1 = FontFactory.GetFont("Roboto", 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            iTextSharp.text.Font f2 = FontFactory.GetFont("Roboto", 30, iTextSharp.text.Font.BOLD, new BaseColor(54, 103, 255));
            BaseFont bf = BaseFont.CreateFont("c:/windows/fonts/micross.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            Font thai = new Font(bf, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            Font thaiGreen = new Font(bf, 10, iTextSharp.text.Font.NORMAL, BaseColor.GREEN);

            Font thaiRed = new Font(bf, 10, iTextSharp.text.Font.NORMAL, BaseColor.RED);



            int BodyY = BodyEnd - IMG_SIZE - 5;
            int LoopX = BODY_X;
            int LoopY = 200;

            int i = 0;
            for (int e = 0; e < output.imgCount; e++)
            {
                if (output.imgPath[i] != null)
                {
                    if (output.imgPath[i].Contains("ENT") == true)
                    {
                        i++;
                    }
                }

            }
            int imgperpage;
            if (i < 8) { imgperpage = i; } else { imgperpage = 8; }
            for (int z = 0; z < imgperpage; z++)
            {

                Image img = Image.FromFile(output.imgPath[z]);
                iTextSharp.text.Image v = iTextSharp.text.Image.GetInstance(output.MakeSquareEndoWay(img, 500), System.Drawing.Imaging.ImageFormat.Jpeg);
                picPDF[z] = v;
                picPDF[z].ScaleAbsolute(IMG_SIZE, IMG_SIZE);
                picPDF[z].SetAbsolutePosition(LoopX, LoopY);
                pdfDoc.Add(picPDF[z]);
                PlaceChunckB(writer, P1[z], LoopX, LoopY - 15);
                PlaceChunck(writer, output.cBoxes[z].Text, LoopX + 15, LoopY - 15);
                if (z == 3)
                {
                    LoopX = BODY_X; LoopY = LoopY - IMG_SIZE - 20;
                }
                else
                { LoopX += IMG_SIZE + SMALL_GAP; }
            }

            cb.MoveTo(BODY_X + IMG_SIZE * 2 + 50, 15);
            cb.LineTo(BODY_X + IMG_SIZE * 3 + SMALL_GAP * 3 + 125, 15);
            cb.Stroke();
            PlaceChunck(writer, "Signature", BODY_X + IMG_SIZE * 2 + 50, 20);
            return imgTable;

        }

        private PdfPTable GetImg2(Document pdfDoc, PdfWriter writer, int page, imageReport output)
        {
            string[] P2, P3, P4, P5, P6, PX = null;
            P2 = new string[] { "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T" };
            P3 = new string[] { "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF" };
            P4 = new string[] { "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR" };

            P5 = new string[] { "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD" };

            P6 = new string[] { "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN" };

            iTextSharp.text.Image picPdf1 = null, picPdf2 = null, picPdf3 = null, picPdf4 = null, picPdf5 = null, picPdf6 = null, picPdf7 = null, picPdf8 = null, picPdf9 = null, picPdf10 = null, picPdf11 = null, picPdf12 = null;
            iTextSharp.text.Image[] picPDF;
            picPDF = new iTextSharp.text.Image[] { picPdf1, picPdf2, picPdf3, picPdf4, picPdf5, picPdf6, picPdf7, picPdf8, picPdf9, picPdf10, picPdf11, picPdf12 };

            int BodyX = 65; int smallgap = 12;

            PdfPTable imgTable = new PdfPTable(2);
            PdfContentByte cb = writer.DirectContent;
            cb.MoveTo(65 + 130 * 2 + 50, 5);
            cb.LineTo(65 + 130 * 3 + smallgap * 3 + 125, 5);
            cb.Stroke();
            PlaceChunck(writer, "Signature", 65 + 130 * 2 + 50, 10);



            int i = 0;
            for (int e = 0; e < output.imgCount; e++)
            {
                if (output.imgPath[i] != null)
                {
                    if (output.imgPath[i].Contains("EGD") == true)
                    {
                        i++;
                    }
                }

            }
            int j = i;


            int size = 165; int BodyY = 595;

            int LoopX = BodyX; int LoopY = BodyY;
            ///
            int X1 = 0, X2 = 0, X3 = 0;
            if (page == 2) { PX = P2; X1 = 21; X2 = 20; X3 = 8; }
            if (page == 3) { PX = P3; X1 = 31; X2 = 32; X3 = 20; }

            if (page == 4) { PX = P4; X1 = 43; X2 = 44; X3 = 32; }

            if (page == 5) { PX = P5; X1 = 55; X2 = 56; X3 = 44; }
            if (page == 6) { PX = P6; X1 = 56; X2 = i; X3 = 56; }
            if (i > X1) { j = X2; }
            ///
            int x = X3;

            for (int z = 0; z < j - X3; z++)
            {
                Image a = Image.FromFile(output.imgPath[x]);
                iTextSharp.text.Image v = iTextSharp.text.Image.GetInstance(output.MakeSquareEndoWay(a, 500), System.Drawing.Imaging.ImageFormat.Jpeg);
                picPDF[z] = v;
                picPDF[z].ScaleAbsolute(size, size);
                picPDF[z].SetAbsolutePosition(LoopX, LoopY);
                pdfDoc.Add(picPDF[z]);
                PlaceChunckB(writer, PX[z], LoopX, LoopY - 15);
                PlaceChunck(writer, output.cBoxes[x].Text, LoopX + 15, LoopY - 15);
                if (z == 2 || z == 5 || z == 8)
                {
                    LoopX = BodyX; LoopY = LoopY - size - 20;
                }
                else
                { LoopX += size + smallgap; }
                x++;
            }

            return imgTable;

        }

        private PdfPTable GetImg2_Wide(Document pdfDoc, PdfWriter writer, int page, imageReport output)
        {
            string[] P2, P3, P4, P5, P6, PX = null;
            P2 = new string[] { "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T" };
            P3 = new string[] { "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF" };
            P4 = new string[] { "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR" };

            P5 = new string[] { "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD" };

            P6 = new string[] { "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN" };

            iTextSharp.text.Image picPdf1 = null, picPdf2 = null, picPdf3 = null, picPdf4 = null, picPdf5 = null, picPdf6 = null, picPdf7 = null, picPdf8 = null, picPdf9 = null, picPdf10 = null, picPdf11 = null, picPdf12 = null;
            iTextSharp.text.Image[] picPDF;
            picPDF = new iTextSharp.text.Image[] { picPdf1, picPdf2, picPdf3, picPdf4, picPdf5, picPdf6, picPdf7, picPdf8, picPdf9, picPdf10, picPdf11, picPdf12 };

            int BodyX = 65; int smallgap = 12;

            PdfPTable imgTable = new PdfPTable(2);
            PdfContentByte cb = writer.DirectContent;
            cb.MoveTo(65 + 130 * 2 + 50, 5);
            cb.LineTo(65 + 130 * 3 + smallgap * 3 + 125, 5);
            cb.Stroke();
            PlaceChunck(writer, "Signature", 65 + 130 * 2 + 50, 10);



            int i = 0;
            for (int e = 0; e < output.imgCount; e++)
            {
                if (output.imgPath[i] != null)
                {
                    if (output.imgPath[i].Contains("EGD") == true)
                    {
                        i++;
                    }
                }

            }
            int j = i;


            int size = 165; int BodyY = 595;

            int LoopX = BodyX; int LoopY = BodyY;
            ///
            int X1 = 0, X2 = 0, X3 = 0;
            if (page == 2) { PX = P2; X1 = 21; X2 = 20; X3 = 8; }
            if (page == 3) { PX = P3; X1 = 31; X2 = 32; X3 = 20; }

            if (page == 4) { PX = P4; X1 = 43; X2 = 44; X3 = 32; }

            if (page == 5) { PX = P5; X1 = 55; X2 = 56; X3 = 44; }
            if (page == 6) { PX = P6; X1 = 56; X2 = i; X3 = 56; }
            if (i > X1) { j = X2; }
            ///
            int x = X3;

            for (int z = 0; z < j - X3; z++)
            {
                Image a = Image.FromFile(output.imgPath[x]);
                iTextSharp.text.Image v = iTextSharp.text.Image.GetInstance(output.MakeSquareEndoWay(a, 500), System.Drawing.Imaging.ImageFormat.Jpeg);
                picPDF[z] = v;
                picPDF[z].ScaleAbsolute(size, size);
                picPDF[z].SetAbsolutePosition(LoopX, LoopY);
                pdfDoc.Add(picPDF[z]);
                PlaceChunckB(writer, PX[z], LoopX, LoopY - 15);
                PlaceChunck(writer, output.cBoxes[x].Text, LoopX + 15, LoopY - 15);
                if (z == 2 || z == 5 || z == 8)
                {
                    LoopX = BodyX; LoopY = LoopY - size - 20;
                }
                else
                { LoopX += size + smallgap; }
                x++;
            }

            return imgTable;

        }

        public float calculatePDFStringWidth(string a)
        {
            var chunk = new Chunk(a);

            float WidthWithCharSpacing = chunk.GetWidthPoint() + chunk.GetCharacterSpacing() * (chunk.Content.Length - 1);
            // System.Windows.Forms.MessageBox.Show(WidthWithCharSpacing.ToString());
            return WidthWithCharSpacing;
        }
        public int calculatePDFWidth(string a, int b)
        {
            var chunk = new Chunk(a);
            int line = 0;
            int s = a.Length;
            //  System.Windows.Forms.MessageBox.Show(s.ToString());

            for (int i = 1; i <= 5; i++)
            {
                if (s > b * i)
                {
                    line += 1;
                }
            }
            // System.Windows.Forms.MessageBox.Show(line.ToString());

            return line;
        }
        private void PlaceChunck(PdfWriter writer, String text, int x, int y)
        {
            PdfContentByte cb = writer.DirectContent;
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SaveState();
            cb.BeginText();
            cb.MoveText(x, y);
            cb.SetFontAndSize(bf, 14);
            cb.ShowText(text);
            cb.EndText();
            cb.RestoreState();
        }




        private void PlaceChunckB(PdfWriter writer, String text, int x, int y)
        {
            PdfContentByte cb = writer.DirectContent;
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SaveState();
            cb.SetColorFill(new BaseColor(54, 103, 255));
            cb.Fill();

            cb.BeginText();
            cb.MoveText(x, y);
            cb.SetFontAndSize(bf, 15);
            cb.ShowText(text);
            cb.EndText();
            cb.RestoreState();
        }
        private void PlaceChunckIMG(PdfWriter writer, String text, int x, int y)
        {
            PdfContentByte cb = writer.DirectContent;
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SaveState();
            // cb.SetColorFill(new BaseColor(54, 103, 255));
            cb.Fill();

            cb.BeginText();
            cb.MoveText(x, y);
            cb.SetFontAndSize(bf, 8);
            cb.ShowText(text);
            cb.EndText();
            cb.RestoreState();
        }

        public string cutEnter(string b)
        {

            if (b.Contains("\r\n"))
            {
                b = b.Replace("\r\n", " ");

            }
            return b;
        }

        private PdfPTable GetHeader(Document pdfDoc, PdfWriter writer, String PRO, Page.Report report)
        {
            iTextSharp.text.Font fntTableFontHdr = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            PdfPTable headerTable = new PdfPTable(2);
            headerTable.TotalWidth = 530f;
            headerTable.HorizontalAlignment = 0;
            headerTable.SpacingAfter = 20;

            float[] headerTableColWidth = new float[2];
            headerTableColWidth[0] = 375f;
            headerTableColWidth[1] = 155f;

            headerTable.SetWidths(headerTableColWidth);
            headerTable.LockedWidth = true;

            iTextSharp.text.Image png = null;
            png = getHeadImg(PRO);
            png.ScaleAbsolute(100, 50);

            png.ScaleAbsolute(100, 50);
            //png.ScaleAbsolute(50, 50);
            png.SetAbsolutePosition(150, 150);

            PlaceChunckHead(writer, "ENT Report", 110, 820);
            DataManage.DataAccess Load = new DataManage.DataAccess();
            PlaceChunckHeadMini(writer, Load.getsettingtext("1", "name"), 110, 800);
            PlaceChunckHeadMini2(writer, Load.getsettingtext("1", "line1"), 0, 780);
            PlaceChunckHeadMini2(writer, Load.getsettingtext("1", "line2"), 0, 770);

          

            PdfPCell headerTableCell_0 = new PdfPCell(png);
            headerTableCell_0.HorizontalAlignment = Element.ALIGN_LEFT;
            headerTableCell_0.Border = Rectangle.NO_BORDER;
            headerTable.AddCell(headerTableCell_0);



            PdfPCell headerTableCell_1 = new PdfPCell();
            //   headerTable.AddCell(new Paragraph("Hello World!"));


            headerTableCell_1.HorizontalAlignment = Element.ALIGN_LEFT;
            // headerTableCell_1.VerticalAlignment = Element.ALIGN_BOTTOM;
            headerTableCell_1.Border = Rectangle.NO_BORDER;
            headerTable.AddCell(headerTableCell_1);


            PdfContentByte cb = writer.DirectContent;
            cb.MoveTo(375f, pdfDoc.PageSize.Height - 75f);
            cb.LineTo(375f, pdfDoc.PageSize.Height - 5);
            cb.Stroke();

            cb.MoveTo(375f, pdfDoc.PageSize.Height - 5);
            cb.LineTo(pdfDoc.PageSize.Width - 5, pdfDoc.PageSize.Height - 5);
            cb.Stroke();

            cb.MoveTo(pdfDoc.PageSize.Width - 5, pdfDoc.PageSize.Height - 5);
            cb.LineTo(pdfDoc.PageSize.Width - 5, pdfDoc.PageSize.Height - 75f);
            cb.Stroke();

            cb.MoveTo(375f, pdfDoc.PageSize.Height - 75f);
            cb.LineTo(pdfDoc.PageSize.Width - 5, pdfDoc.PageSize.Height - 75f);
            cb.Stroke();

            cb.MoveTo(0f, pdfDoc.PageSize.Height - 80f);
            cb.LineTo(875f, pdfDoc.PageSize.Height - 80f);
            cb.Stroke();

            iTextSharp.text.Font f1 = FontFactory.GetFont("ANGSA", 11, iTextSharp.text.Font.NORMAL, new BaseColor(54, 103, 255));
            //BaseFont bf = BaseFont.CreateFont("c:/windows/Fonts/ANGSA_0.TTF"), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            //thai Font
            BaseFont bf = BaseFont.CreateFont("c:/windows/fonts/micross.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            iTextSharp.text.Font Thai = new Font(bf, 10);

            //
            ColumnText ct = new ColumnText(cb);
            ColumnText ct1 = new ColumnText(cb);

            ColumnText ct2 = new ColumnText(cb);

            ColumnText ct3 = new ColumnText(cb);

            ColumnText ct4 = new ColumnText(cb);

            ColumnText ct5 = new ColumnText(cb);
            ColumnText ct6 = new ColumnText(cb);

            ColumnText h1 = new ColumnText(cb);
            ColumnText h2 = new ColumnText(cb);
            ColumnText h3 = new ColumnText(cb);
            ColumnText h4 = new ColumnText(cb);
            ColumnText h5 = new ColumnText(cb);
            ColumnText h6 = new ColumnText(cb);
            ColumnText h7 = new ColumnText(cb);
            ColumnText h8 = new ColumnText(cb);

            Phrase headerHN = new Phrase("HN#:", f1);
            Phrase headerNAME = new Phrase("Name:", f1);
            Phrase headerPRO = new Phrase("Procedure:", f1);
            Phrase headerREGIS = new Phrase("Register Date:", f1);
            Phrase headerDuration = new Phrase("Duration:", f1);
            Phrase headerSEX = new Phrase("Sex:", f1);
            Phrase headerAGE = new Phrase("Age:", f1);

            string H1 = report.infohn.Text; Phrase getHN = new Phrase(H1, Thai);
            string H2 = report.infoname.Text; Phrase getNAME = new Phrase(H2, Thai);
            string H3 = report.infopro.Text; Phrase getPRO = new Phrase(H3, Thai);
            string H4 = report.inforegis.Text; Phrase getREGIS = new Phrase(H4, Thai);
            string H5 = report.Duration.Text; ; Phrase getDUR = new Phrase(H5, Thai);
            string H6 = report.infosex.Text; Phrase getSEX = new Phrase(H6, Thai);
            string H7 = report.infoage.Text; Phrase getAGE = new Phrase(H7, Thai);

            ct.SetSimpleColumn(headerHN, 379, 840, 580, 317, 15, Element.ALIGN_LEFT);
            ct1.SetSimpleColumn(headerNAME, 379, 827, 580, 317, 15, Element.ALIGN_LEFT);
            ct2.SetSimpleColumn(headerPRO, 379, 814, 580, 317, 15, Element.ALIGN_LEFT);
            ct3.SetSimpleColumn(headerREGIS, 379, 801, 580, 317, 15, Element.ALIGN_LEFT);
            ct4.SetSimpleColumn(headerDuration, 379, 788, 580, 317, 15, Element.ALIGN_LEFT);
            ct5.SetSimpleColumn(headerSEX, 475, 840, 580, 317, 15, Element.ALIGN_LEFT);
            ct6.SetSimpleColumn(headerAGE, 540, 840, 580, 317, 15, Element.ALIGN_LEFT);
            ct.Go();
            ct1.Go();
            ct2.Go();
            ct3.Go();
            ct4.Go();
            ct5.Go();
            ct6.Go();

            h1.SetSimpleColumn(getHN, 379 + 27, 840, 580, 317, 15, Element.ALIGN_LEFT); h1.Go();
            h2.SetSimpleColumn(getNAME, 379 + 35, 827, 580, 317, 15, Element.ALIGN_LEFT); h2.Go();
            h3.SetSimpleColumn(getPRO, 379 + 60, 814, 580, 317, 15, Element.ALIGN_LEFT); h3.Go();
            h4.SetSimpleColumn(getREGIS, 379 + 75, 801, 580, 317, 15, Element.ALIGN_LEFT); h4.Go();
            h5.SetSimpleColumn(getDUR, 379 + 50, 788, 580, 317, 15, Element.ALIGN_LEFT); h5.Go();
            h6.SetSimpleColumn(getSEX, 475 + 25, 840, 580, 317, 15, Element.ALIGN_LEFT); h6.Go();
            h7.SetSimpleColumn(getAGE, 540 + 25, 840, 580, 317, 15, Element.ALIGN_LEFT); h7.Go();



            return headerTable;
        }
        private void PlaceChunckHead(PdfWriter writer, String text, int x, int y)
        {
            string projectDirectory;
            projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            projectDirectory += "\\Resources\\Fonts\\Roboto-Black.TTF";

            PdfContentByte cb = writer.DirectContent;
            // BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, BaseFont.EMBEDDED);

            BaseFont bf = BaseFont.CreateFont(projectDirectory, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            cb.SaveState();
            //  cb.SetColorFill(new BaseColor(54, 103, 255));
            cb.Fill();

            cb.BeginText();
            cb.MoveText(x, y);
            cb.SetFontAndSize(bf, 15);
            cb.ShowText(text);
            cb.EndText();
            cb.RestoreState();
        }

        private void PlaceChunckHeadMini(PdfWriter writer, String text, int x, int y)
        {
            string projectDirectory;
            projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            projectDirectory += "\\Resources\\Fonts\\LeelawUI.TTF";

            PdfContentByte cb = writer.DirectContent;
            // BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, BaseFont.EMBEDDED);

            BaseFont bf = BaseFont.CreateFont(projectDirectory, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            cb.SaveState();
            //  cb.SetColorFill(new BaseColor(54, 103, 255));
            cb.Fill();

            cb.BeginText();
            cb.MoveText(x, y);
            cb.SetFontAndSize(bf, 15);
            cb.ShowText(text);
            cb.EndText();
            cb.RestoreState();
        }
        private void PlaceChunckHeadMini2(PdfWriter writer, String text, int x, int y)
        {
            string projectDirectory;
            projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            projectDirectory += "\\Resources\\Fonts\\LeelawUI.TTF";

            PdfContentByte cb = writer.DirectContent;
            // BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, BaseFont.EMBEDDED);

            BaseFont bf = BaseFont.CreateFont(projectDirectory, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            cb.SaveState();
            //  cb.SetColorFill(new BaseColor(54, 103, 255));
            cb.Fill();

            cb.BeginText();
            cb.MoveText(x, y);
            cb.SetFontAndSize(bf, 7.5f);
            cb.ShowText(text);
            cb.EndText();
            cb.RestoreState();
        }
    }
}
