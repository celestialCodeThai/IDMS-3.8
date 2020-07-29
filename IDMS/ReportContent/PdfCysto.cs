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
    class PdfCysto
    {
        bool page2, page3, page4, page5, page6;
        const int BODY_X = 65;
        const int SMALL_GAP = 2;
        const int IMG_SIZE = 130;

        public PdfCysto(imageReport output)
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
        public void GEN_PdfEGD(String PRO, imageReport output, Report report, reportControlCysto Cysto, string ORIGINAL_ID, bool Multimode)
        {
            string filename = specialCharReplace(report.infohn.Text);
            string Filesave = "";
            Document doc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            Filesave = IDMS.World.Settings.savePath + "/images/" + specialCharReplace(ORIGINAL_ID) + "/" + PRO + "-HN " + filename + "-TIME " + DateTime.Now.ToString("HH") + "." + DateTime.Now.ToString("mm") + "." + DateTime.Now.ToString("ss") + ".pdf";

            if (!Directory.Exists(IDMS.World.Settings.savePath + "/images/" + specialCharReplace(ORIGINAL_ID))) { return; }
            Document pdfDoc = new Document(PageSize.A4, 0, 0, 0, 0);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(Filesave, FileMode.Create));


            pdfDoc.Open();
            pdfDoc.Add(GetHeader(pdfDoc, writer, PRO, report));
            pdfDoc.Add(GetBodyERCP(pdfDoc, writer, report, Cysto, output));
            pdfDoc.Add(GetImg(pdfDoc, writer, output));

            if (page2)
            {
                pdfDoc.NewPage();
                pdfDoc.Add(GetHeader(pdfDoc, writer, PRO, report));
                pdfDoc.Add(GetImg2(pdfDoc, writer, 2, output));
            }
            if (page3)
            {
                pdfDoc.NewPage();
                pdfDoc.Add(GetHeader(pdfDoc, writer, PRO, report));
                pdfDoc.Add(GetImg2(pdfDoc, writer, 3, output));
            }
            if (page4)
            {
                pdfDoc.NewPage();
                pdfDoc.Add(GetHeader(pdfDoc, writer, PRO, report));
                pdfDoc.Add(GetImg2(pdfDoc, writer, 4, output));
            }
            if (page5)
            {
                pdfDoc.NewPage();
                pdfDoc.Add(GetHeader(pdfDoc, writer, PRO, report));
                pdfDoc.Add(GetImg2(pdfDoc, writer, 5, output));
            }
            if (page6)
            {
                pdfDoc.NewPage();
                pdfDoc.Add(GetHeader(pdfDoc, writer, PRO, report));
                pdfDoc.Add(GetImg2(pdfDoc, writer, 6, output));
            }
            pdfDoc.Close();

            DataManage.DataAccess Load = new DataManage.DataAccess();
            if (Load.getusbtext("1", "IS_USE") == "1")
            {
                string sourceFile = Filesave;
                string Filesave2;
                string PATH = Load.getusbtext("1", "USB_PATH");

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
            png.SetAbsolutePosition(150, 150);
            PlaceChunckHead(writer, "Cystoscopy Report", 110, 820);
            PlaceChunckHeadMini(writer, "ห้องส่องกล้องโรงพยาบาลเจ้าพระยา", 110, 800);
            PlaceChunckHeadMini2(writer, "113/44 Borommaratchachonnani Rd, Khwaeng Arun Amarin,Khet Bangkok Noi,Bangkok 10700", 0, 780);
            PlaceChunckHeadMini2(writer, "Phone: 02-431-1111", 0, 770);

            PdfPCell headerTableCell_0 = new PdfPCell(png);
            headerTableCell_0.HorizontalAlignment = Element.ALIGN_LEFT;
            headerTableCell_0.Border = Rectangle.NO_BORDER;
            headerTable.AddCell(headerTableCell_0);



            PdfPCell headerTableCell_1 = new PdfPCell();


            headerTableCell_1.HorizontalAlignment = Element.ALIGN_LEFT;
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
        private PdfPTable GetBodyERCP(Document pdfDoc, PdfWriter writer, Report report, reportControlCysto reportControl, imageReport output)
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
            Phrase DocBody = new Phrase("Surgeon:", f2);
            Phrase NurseBody = new Phrase("Surgical nurse:", f2);
            Phrase AntBody = new Phrase("Anesthetist:", f2);
            Phrase AnesBody = new Phrase("Anesthesia:", f2);
            Phrase OpBody = new Phrase("Operation:", f2);
            Phrase InstBody = new Phrase("Instrument:", f2);
            Phrase InciBody = new Phrase("Incision:", f2);
            Phrase CliDxBody = new Phrase("Clinical-Diagnosis:", f2);
            Phrase HistorytBody = new Phrase("Patient history:", f2);
            Phrase AssBody = new Phrase("Assistant:", f2);
            Phrase ProRoomBody = new Phrase("Position:", f2);
            Phrase FindingBody = new Phrase("Findings:", f2);

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
            string snursename = report.infosnurse.Text; Phrase getNursename = new Phrase(snursename, Thai);
            string antname = ""; string anesname = report.anes.Text;


            if (reportControl.a1.Checked == true) { if (antname != "") { antname += ", "; } antname += reportControl.a1.Text; }
            if (reportControl.a2.Checked == true) { if (antname != "") { antname += ", "; } antname += reportControl.a2.Text; }
           
            if (reportControl.a5.Checked == true) { if (antname != "") { antname += ", "; } antname += reportControl.a5txt.Text; }



            Phrase getAnesname = new Phrase(anesname, Thai);

            Phrase getAntname = new Phrase(antname, Thai);

            string op = "";

            if (reportControl.OP_1.Checked == true) { if (op != "") { op += ", "; } op += reportControl.OP_1.Text; }
            if (reportControl.OP_2.Checked == true) { if (op != "") { op += ", "; } op += reportControl.OP_2.Text; }
            if (reportControl.OP_3.Checked == true) { if (op != "") { op += ", "; } op += reportControl.OP_3.Text ; }
            if (reportControl.OP_4.Checked == true) { if (op != "") { op += ", "; } op += reportControl.OP_4.Text + " " + reportControl.OP_4txt.Text; }
            if (reportControl.OP_5.Checked == true) { if (op != "") { op += ", "; } op += reportControl.OP_5.Text + " " + reportControl.OP_5txt.Text ; }
            if (reportControl.OP_6.Checked == true) { if (op != "") { op += ", "; } op += reportControl.OP_6txt.Text; }


            Phrase getOp = new Phrase(op, Thai);

            string instname = report.infoinstrument.Text;
            if (report.in2.Text != "" && instname != "")
            {
                instname += ", ";
                instname += report.in2.Text;
            }

            Phrase getInstname = new Phrase(instname, Thai);

            string indiname = "";

            if (reportControl.INCI_1.Checked == true) { if (indiname != "") { indiname += ", "; } indiname += reportControl.INCI_1.Text; }
            if (reportControl.INCI_2.Checked == true) { if (indiname != "") { indiname += ", "; } indiname += reportControl.INCI_2.Text; }
            if (reportControl.INCI_3.Checked == true) { if (indiname != "") { indiname += ", "; } indiname += reportControl.INCI_3.Text; }

            Phrase getIndiname = new Phrase(indiname, Thai);



            string pdxname = ""; 
            if (reportControl.pdx1.Checked == true) { if (pdxname != "") { pdxname += ", "; } pdxname += reportControl.pdx1.Text; }
            if (reportControl.pdx2.Checked == true) { if (pdxname != "") { pdxname += ", "; } pdxname += reportControl.pdx2.Text; }
            if (reportControl.pdx3.Checked == true) { if (pdxname != "") { pdxname += ", "; } pdxname += reportControl.pdx3.Text; }
            if (reportControl.pdx4.Checked == true) { if (pdxname != "") { pdxname += ", "; } pdxname += reportControl.pdx4.Text; }
            if (reportControl.pdx5.Checked == true) { if (pdxname != "") { pdxname += ", "; } pdxname += reportControl.pdx5txt.Text; }





            Phrase getPdx = new Phrase(pdxname, Thai);
            string hisname = "";
            hisname = reportControl.commentText.Text;



            Phrase getHisname = new Phrase(hisname, Thai);
            string cnursename = report.infocnurse.Text; Phrase getCnursename = new Phrase(cnursename, Thai);
            string proroomname = reportControl.POS.Text; Phrase getproroomname = new Phrase(proroomname, Thai);
            //

            int BodyX = 70; int BodyY = 745; int BodySpace = 13;
            int BodyX2 = 230;
            ct.SetSimpleColumn(headerBody, BodyX - 5, BodyY + 15, 580, 317, 15, Element.ALIGN_LEFT);
            ct1.SetSimpleColumn(DocBody, BodyX, BodyY, 580, 317, 15, Element.ALIGN_LEFT);
            ct2.SetSimpleColumn(NurseBody, BodyX, BodyY - BodySpace, 580, 317, 15, Element.ALIGN_LEFT);
            ct4.SetSimpleColumn(AnesBody, BodyX, BodyY - (BodySpace * 2), 580, 317, 15, Element.ALIGN_LEFT);
            ct5.SetSimpleColumn(OpBody, BodyX, BodyY - (BodySpace * 3), 580, 317, 15, Element.ALIGN_LEFT);
            ct6.SetSimpleColumn(InstBody, BodyX, BodyY - (BodySpace * 4), 580, 317, 15, Element.ALIGN_LEFT);
            ct7.SetSimpleColumn(InciBody, BodyX, BodyY - (BodySpace * 5), 580, 317, 15, Element.ALIGN_LEFT);

            ct8.SetSimpleColumn(CliDxBody, BodyX, BodyY - (BodySpace * 6), 580, 317, 15, Element.ALIGN_LEFT);
            //
            //
            ct3.SetSimpleColumn(AntBody, BodyX + BodyX2, BodyY, 580, 317, 15, Element.ALIGN_LEFT);
            ct10.SetSimpleColumn(AssBody, BodyX + BodyX2, BodyY - BodySpace, 580, 317, 15, Element.ALIGN_LEFT);
            ct11.SetSimpleColumn(ProRoomBody, BodyX + BodyX2, BodyY - (BodySpace * 2), 580, 317, 15, Element.ALIGN_LEFT);

            int infoX = BodyX + 75; int infoX2 = 235;

            d1.SetSimpleColumn(getDocname, infoX, BodyY, 580, 317, 15, Element.ALIGN_LEFT); d1.Go();
            d2.SetSimpleColumn(getNursename, infoX, BodyY - BodySpace, 580, 317, 15, Element.ALIGN_LEFT); d2.Go();
            d4.SetSimpleColumn(getAnesname, infoX + infoX2, BodyY, 580, 317, 15, Element.ALIGN_LEFT); d4.Go();
            d5.SetSimpleColumn(getOp, infoX, BodyY - (BodySpace * 3), 580, 317, 15, Element.ALIGN_LEFT); d5.Go();
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


            d3.SetSimpleColumn(getAntname, infoX, BodyY - (BodySpace * 2), 580, 317, 15, Element.ALIGN_LEFT); d3.Go();
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
            iTextSharp.text.Image png = null;

            png = iTextSharp.text.Image.GetInstance(IDMS.Properties.Resources.egd, System.Drawing.Imaging.ImageFormat.Png);
            png.SetAbsolutePosition(BodyX + BodyX2 + 155, 610);

            png.ScaleAbsolute(145, 150);
            pdfDoc.Add(png);
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

            //LastBodyPart
            ColumnText lb0 = new ColumnText(cb);

            ColumnText lb1 = new ColumnText(cb);
            ColumnText lb2 = new ColumnText(cb);
            ColumnText lb3 = new ColumnText(cb);
            ColumnText lb4 = new ColumnText(cb);
            ColumnText lb5 = new ColumnText(cb);
            ColumnText lb6 = new ColumnText(cb);
            ColumnText lb7 = new ColumnText(cb);
            ColumnText lb8 = new ColumnText(cb);

            ColumnText l0 = new ColumnText(cb);

            ColumnText l1 = new ColumnText(cb);
            ColumnText l2 = new ColumnText(cb);
            ColumnText l3 = new ColumnText(cb);
            ColumnText l4 = new ColumnText(cb);
            ColumnText l5 = new ColumnText(cb);
            ColumnText l6 = new ColumnText(cb);
            ColumnText l7 = new ColumnText(cb);
            ColumnText l8 = new ColumnText(cb);
            iTextSharp.text.Font f3 = FontFactory.GetFont("Roboto", 14, iTextSharp.text.Font.BOLD, BaseColor.RED);

            Phrase LB0 = new Phrase("Findings:", f2);

            Phrase LB1 = new Phrase("Procedures:", f2);
            Phrase LB2 = new Phrase("Post-opt.Diagnosis:", f2);
            Phrase LB3 = new Phrase("Estimate blood loss:", f2);
            Phrase LB5 = new Phrase("Comment:", f2);


            Phrase LB7 = new Phrase("Complication:", f2);

            //info
            string L0;
            string ftxt = "";
            if (reportControl.F_1.Checked == true) { if (ftxt != "") { ftxt += ", "; } ftxt += reportControl.F_1.Text; }
            if (reportControl.F_1txt.Text != "") { ftxt += reportControl.F_1txt.Text + " cm."; }


            if (reportControl.F_2.Checked == true) { if (ftxt != "") { ftxt += ", "; } ftxt += reportControl.F_2.Text; }
            if (reportControl.F_3.Checked == true) { if (ftxt != "") { ftxt += ", "; } ftxt += reportControl.F_3.Text; }
            if (reportControl.F_4.Checked == true) { if (ftxt != "") { ftxt += ", "; } ftxt += reportControl.F_4.Text; }
            if (reportControl.F_5.Checked == true) { if (ftxt != "") { ftxt += ", "; } ftxt += reportControl.F_5.Text; }
            if (reportControl.F_6.Checked == true) { if (ftxt != "") { ftxt += ", "; } ftxt += reportControl.F_6.Text; }
            if (reportControl.F_7.Checked == true) { if (ftxt != "") { ftxt += ", "; } ftxt += reportControl.F_7.Text; }
            if (reportControl.F_8.Checked == true) { if (ftxt != "") { ftxt += ", "; } ftxt += reportControl.F_8.Text; }
            if (reportControl.F_9.Checked == true) { if (ftxt != "") { ftxt += ", "; } ftxt += reportControl.F_9.Text; }

            if (reportControl.F_10.Checked == true) { if (ftxt != "") { ftxt += ", "; } ftxt += reportControl.F_10.Text; }
            if (reportControl.F_10txt.Text != "") { ftxt += reportControl.F_10txt.Text +" cm"; }
            if (reportControl.F_10txt2.Text != "") { ftxt += "x " +reportControl.F_10txt2.Text ; }


            if (reportControl.F_11.Checked == true) { if (ftxt != "") { ftxt += ", "; } ftxt += reportControl.F_11.Text; }
            if (reportControl.F_11.Text != ""){  ftxt += reportControl.F_11txt.Text+ " cm.H20"; }


            if (reportControl.F_12.Checked == true) { if (ftxt != "") { ftxt += ", "; } ftxt += reportControl.F_12.Text; }
            if (reportControl.F_13.Checked == true) { if (ftxt != "") { ftxt += ", "; } ftxt += reportControl.F_13.Text; }
            if (reportControl.F_14.Checked == true) { if (ftxt != "") { ftxt += ", "; } ftxt += reportControl.F_14.Text; }
            if (reportControl.F_15.Checked == true) { if (ftxt != "") { ftxt += ", "; } ftxt += reportControl.F_15.Text; }
            if (reportControl.F_16.Checked == true) { if (ftxt != "") { ftxt += ", "; } ftxt += reportControl.F_16.Text; }
            if (reportControl.F_17.Checked == true) { if (ftxt != "") { ftxt += ", "; } ftxt += reportControl.F_17.Text; }
            if (reportControl.F_18.Checked == true) { if (ftxt != "") { ftxt += ", "; } ftxt += reportControl.F_18.Text; }
            if (reportControl.F_19.Checked == true) { if (ftxt != "") { ftxt += ", "; } ftxt += reportControl.F_19.Text; }
            if (reportControl.F_20.Checked == true) { if (ftxt != "") { ftxt += ", "; } ftxt += reportControl.F_20.Text; }


            if (reportControl.F_21.Text != "") { if (ftxt != "") { ftxt += ", "; } ftxt += "size "+reportControl.F_21.Text+" cm"; }
            if (reportControl.F_22.Text != "") { if (ftxt != "") { ftxt += ", "; } ftxt += "x "+reportControl.F_22.Text; }
            if (reportControl.F_23.Text != "") { if (ftxt != "") { ftxt += ", "; } ftxt += "At"+reportControl.F_23.Text; }
            if (reportControl.F_24.Text != "") { if (ftxt != "") { ftxt += ", "; } ftxt += "Stricture urethra at" + reportControl.F_24.Text; }
            if (reportControl.F_25.Text != "") { if (ftxt != "") { ftxt += ", "; } ftxt += "length"+ reportControl.F_25.Text+ " cm"; }

            L0 = ftxt;
            Phrase getL0 = new Phrase(L0, Thai);

            //
            string L1;

            string ptxt = "";

            if (reportControl.pg1.Checked == true) { if (ptxt != "") { ptxt += ", "; } ptxt += reportControl.pg1.Text; }
            if (reportControl.pg1txt.Text != "") { ftxt += reportControl.pg1txt.Text + " length"; }
            if (reportControl.pg2txt.Text != "") { ftxt += reportControl.pg2txt.Text + " finding as above"; }


            if (reportControl.pg2.Checked == true) { if (ptxt != "") { ptxt += ", "; } ptxt += reportControl.pg2.Text; }
            if (reportControl.pg3.Checked == true) { if (ptxt != "") { ptxt += ", "; } ptxt += reportControl.pg3.Text; }

            if (reportControl.pg4.Checked == true) { if (ptxt != "") { ptxt += ", "; } ptxt += reportControl.pg4.Text; }
            if (reportControl.pg4txt.Text != "") { ftxt += reportControl.pg4txt.Text + " length"; }
            if (reportControl.pg4txt2.Text != "") { ftxt += reportControl.pg4txt2.Text + " finding as above"; }

            if (reportControl.pg5.Checked == true) { if (ptxt != "") { ptxt += ", "; } ptxt += reportControl.pg5.Text; }
            if (reportControl.pg5txt.Text != "") { ftxt += reportControl.pg5txt.Text ; }



            if (reportControl.pg6.Checked == true) { if (ptxt != "") { ptxt += ", "; } ptxt += reportControl.pg6.Text; }
            if (reportControl.pg6txt.Text != "") { ftxt += reportControl.pg6txt.Text; }


            if (reportControl.pg7.Checked == true) { if (ptxt != "") { ptxt += "-"; } ptxt += reportControl.pg7.Text; }


            if (reportControl.pg8.Checked == true) { if (ptxt != "") { ptxt += "-"; } ptxt += reportControl.pg8.Text; }
            if (reportControl.pg8txt.Text != "") { ftxt += reportControl.pg8txt.Text+ " was replaced"; }


            if (reportControl.pg9.Checked == true) { if (ptxt != "") { ptxt += ", "; } ptxt += reportControl.pg9.Text; }


            if (reportControl.pg10.Checked == true) { if (ptxt != "") { ptxt += "-"; } ptxt += reportControl.pg10.Text; }
            if (reportControl.pg11.Checked == true) { if (ptxt != "") { ptxt += "-"; } ptxt += reportControl.pg11.Text; }
            if (reportControl.pg11txt.Text != "") { ftxt += reportControl.pg11txt.Text+ " was replaced"; }







            L1 = ptxt;

            Phrase getL1 = new Phrase(L1, Thai);
            string L2 = "2";


            string spdxtxt = "";
            if (reportControl.POST_DX1.Checked == true) { if (spdxtxt != "") { spdxtxt += ", "; } spdxtxt += reportControl.POST_DX1.Text; }
            if (reportControl.POST_DX2.Checked == true) { if (spdxtxt != "") { spdxtxt += ", "; } spdxtxt += reportControl.POST_DX2.Text; }
            if (reportControl.POST_DX3.Checked == true) { if (spdxtxt != "") { spdxtxt += ", "; } spdxtxt += reportControl.POST_DX3.Text; }
            if (reportControl.POST_DX4.Checked == true) { if (spdxtxt != "") { spdxtxt += ", "; } spdxtxt += reportControl.POST_DX4.Text; }
            if (reportControl.POST_DX5.Checked == true) { if (spdxtxt != "") { spdxtxt += ", "; } spdxtxt += reportControl.POST_DX5txt.Text; }

            L2 = spdxtxt;


            string L3 = ""; string L4 = ""; string L5 = "";


            if (reportControl.b1txt.Text != "")
            {
                L3 = reportControl.b1txt.Text + " mL";
            }
            string comtxt = ""; string L7 = "";
            if (reportControl.c1.Text != "") { if (comtxt != "") { comtxt += ", "; } comtxt += reportControl.c1.Text; }
           

            L7 = comtxt;




            string retxt = "";
            if (reportControl.r1.Text != "") { if (retxt != "") { retxt += ", "; } retxt += reportControl.r1.Text; }
           

            L5 = retxt;
            if ((retxt != "") && (reportControl.note.Text != "")) { L5 += "/"; }
            L5 += reportControl.note.Text;


            Phrase getL2 = new Phrase(L2, ThaiRed);
            Phrase getL3 = new Phrase(L3, Thai);
          //  Phrase getL4 = new Phrase(L4, Thai);
            Phrase getL5 = new Phrase(L5, Thai);


            int FX = BodyX + 65; int extraline; int gap = 15; int j;

           

            Phrase getL7 = new Phrase(L7, Thai);
            int LowerY = HIS_BODY; int LowerSpace = 250;
            //
            lb0.SetSimpleColumn(LB0, BodyX, LowerY, 580, 317, 15, Element.ALIGN_LEFT); lb0.Go();
            l0.SetSimpleColumn(getL0, BodyX + 65, LowerY, 580, 317, 15, Element.ALIGN_LEFT); l0.Go();

            int lb1y = LowerY - BodySpace;
            extraline = calculatePDFWidth(L0, 80);
            if (extraline > 0)
            {
                j = gap * extraline;
                lb1y -= j;

            }

            //
            lb1.SetSimpleColumn(LB1, BodyX, lb1y, 580, 317, 15, Element.ALIGN_LEFT); lb1.Go();
            l1.SetSimpleColumn(getL1, BodyX + 65, lb1y, 580, 317, 15, Element.ALIGN_LEFT); l1.Go();
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
            lb3.SetSimpleColumn(LB3, BodyX, lb3y, 580, 317, 15, Element.ALIGN_LEFT); lb3.Go();
            l3.SetSimpleColumn(getL3, BodyX + 100, lb3y, 580, 317, 15, Element.ALIGN_LEFT); l3.Go();


            int lb5y = lb3y - BodySpace;


          
            lb5.SetSimpleColumn(LB5, BodyX, lb5y, 580, 317, 15, Element.ALIGN_LEFT); lb5.Go();
            l5.SetSimpleColumn(getL5, BodyX + 50, lb5y, 580, 317, 15, Element.ALIGN_LEFT); l5.Go();

            lb7.SetSimpleColumn(LB7, BodyX + LowerSpace, lb3y, 580, 317, 15, Element.ALIGN_LEFT); lb7.Go();
            l7.SetSimpleColumn(getL7, BodyX + LowerSpace + 70, lb3y, 580, 317, 15, Element.ALIGN_LEFT); l7.Go();

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
                    if (output.imgPath[i].Contains("EGD") == true)
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
            if (i >= X1) { j = X2; }
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
