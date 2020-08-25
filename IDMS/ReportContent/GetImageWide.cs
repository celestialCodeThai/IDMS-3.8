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
using System.Windows.Forms;
using IDMS.DataManage;
using IDMS.ReportContent;


namespace IDMS.ReportContent
{
    class GetImageWide
    {

        DataAccess load = new DataAccess();

        BaseColor Black = BaseColor.BLACK;
        BaseColor DimGray = new BaseColor(105, 105, 105);
        BaseColor Gray = BaseColor.GRAY;
        BaseColor LightSkyBlue = new BaseColor(135, 206, 250);
        BaseColor DarkGreen = new BaseColor(0, 100, 0);


        public PdfPTable FirstPage(Document pdfDoc, PdfWriter writer, imageReport output, string doctorName, string procedure)
        {
            string[] P1 = new string[] { "A", "B", "C", "D", "E", "F" };
            iTextSharp.text.Image picPdf1 = null, picPdf2 = null, picPdf3 = null, picPdf4 = null, picPdf5 = null, picPdf6 = null;
            iTextSharp.text.Image[] picPDF;
            picPDF = new iTextSharp.text.Image[] { picPdf1, picPdf2, picPdf3, picPdf4, picPdf5, picPdf6 };


            PdfPTable imgTable = new PdfPTable(2);


            int imageWidth = 173;
            int imageHeight = 97;
            int paddingLeft = 65;
            int smallGap = 2;


            int LoopX = paddingLeft;
            int LoopY = 200;


            int i = 0;
            for (int e = 0; e < output.imgCount; e++)
            {
                if (output.imgPath[i] != null)
                {
                    if (output.imgPath[i].Contains(procedure) == true)
                    {
                        i++;
                    }
                }
            }


            int imgperpage;
            if (i < 6) { imgperpage = i; } else { imgperpage = 6; }
            for (int z = 0; z < imgperpage; z++)
            {
                Image img = Image.FromFile(output.imgPath[z]);
                iTextSharp.text.Image v = iTextSharp.text.Image.GetInstance(output.MakeSquareEndoWayPoint(img, 500, output.recImage[z]), System.Drawing.Imaging.ImageFormat.Jpeg);

                picPDF[z] = v;
                picPDF[z].ScaleAbsolute(imageWidth, imageHeight);
                picPDF[z].SetAbsolutePosition(LoopX, LoopY);
                pdfDoc.Add(picPDF[z]);

                placeChunckImageTitle(writer, P1[z], LoopX, LoopY - 15);
                placeChunckImageDetail(writer, output.cBoxes[z].Text, LoopX + 12, LoopY - 14);
                if (z == 2)
                {
                    LoopX = paddingLeft; LoopY = LoopY - imageHeight - 20;
                }
                else
                { LoopX += imageWidth + smallGap; }
            }


            PdfContentByte cb = writer.DirectContent;
            int checkLength = doctorName.Length;
            int pLeft = (30 - checkLength) * 4;
            if (checkLength > 20) { pLeft += 20; }

            cb.MoveTo(200, 7);
            cb.LineTo(580, 7);
            cb.Stroke();
            PlaceChunckSignature(writer, "Signature", 200, 12);
            PlaceChunckSignature(writer, "(", 390, 12);
            PlaceChunckSignature(writer, doctorName, 390 + pLeft, 12);
            PlaceChunckSignature(writer, ")", 580, 12);

            return imgTable;
        }


        public PdfPTable MultiPage(Document pdfDoc, PdfWriter writer, int page, imageReport output, string doctorName,string procedure)
        {
            string[] P2, P3, P4, P5, P6, P7, P8, P9, PX = null;
            P2 = new string[] { "G", "H", "I", "J", "K", "L", "M", "N" };
            P3 = new string[] { "O", "P", "Q", "R", "S", "T", "U", "V" };
            P4 = new string[] { "W", "X", "Y", "Z", "AA", "AB", "AC", "AD" };
            P5 = new string[] { "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL" };
            P6 = new string[] { "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT" };
            P7 = new string[] { "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB" };
            P8 = new string[] { "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ" };
            P9 = new string[] { "BK", "BL", "BM", "BN" };


            iTextSharp.text.Image picPdf1 = null, picPdf2 = null, picPdf3 = null, picPdf4 = null, picPdf5 = null, picPdf6 = null, picPdf7 = null, picPdf8 = null;
            iTextSharp.text.Image[] picPDF;
            picPDF = new iTextSharp.text.Image[] { picPdf1, picPdf2, picPdf3, picPdf4, picPdf5, picPdf6, picPdf7, picPdf8 };


            PdfPTable imgTable = new PdfPTable(2);


            int i = 0;
            for (int e = 0; e < output.imgCount; e++)
            {
                if (output.imgPath[i] != null)
                {
                    if (output.imgPath[i].Contains(procedure) == true)
                    {
                        i++;
                    }
                }

            }
            int j = i;


            int paddingLeft = 65; 
            int BodyY = 595;
            int smallgap = 12;
            int LoopX = paddingLeft;
            int LoopY = BodyY;

            int imageWidth = 248;
            int imageHeight = 140;

            int prevPage = 0;
            int currentPage = 0;


            switch (page)
            {
                case 2:
                    PX = P2; currentPage = 14; prevPage = 6;
                    break;
                case 3:
                    PX = P3; currentPage = 22; prevPage = 14;
                    break;
                case 4:
                    PX = P4; currentPage = 30; prevPage = 22;
                    break;
                case 5:
                    PX = P5; currentPage = 38; prevPage = 30;
                    break;
                case 6:
                    PX = P6; currentPage = 46; prevPage = 38;
                    break;
                case 7:
                    PX = P7; currentPage = 54; prevPage = 46;
                    break;
                case 8:
                    PX = P8; currentPage = 62; prevPage = 54;
                    break;
                case 9:
                    PX = P9; currentPage = i; prevPage = 62;
                    break;

            }


            if (i >= currentPage) { j = currentPage; }


            int x = prevPage;


            for (int z = 0; z < j - prevPage; z++)
            {
                Image a = Image.FromFile(output.imgPath[x]);
                iTextSharp.text.Image v = iTextSharp.text.Image.GetInstance(output.MakeSquareEndoWayPoint(a, 500, output.recImage[z]), System.Drawing.Imaging.ImageFormat.Jpeg);
                picPDF[z] = v;
                picPDF[z].ScaleAbsolute(imageWidth, imageHeight);
                picPDF[z].SetAbsolutePosition(LoopX, LoopY);
                pdfDoc.Add(picPDF[z]);
                placeChunckImageTitle(writer, PX[z], LoopX, LoopY - 15);
                placeChunckImageDetail(writer, output.cBoxes[x].Text, LoopX + 12, LoopY - 14);
                if (z % 2 != 0)
                {
                    LoopX = paddingLeft;
                    LoopY = LoopY - imageHeight - 20;
                }
                else
                { LoopX += imageWidth + smallgap; }
                x++;
            }


            PdfContentByte cb = writer.DirectContent;
            int checkLength = doctorName.Length;
            int pLeft = (30 - checkLength) * 4;
            if (checkLength > 20) { pLeft += 20; }


            cb.MoveTo(200, 7);
            cb.LineTo(580, 7);
            cb.Stroke();
            PlaceChunckSignature(writer, "Signature", 200, 12);
            PlaceChunckSignature(writer, "(", 390, 12);
            PlaceChunckSignature(writer, doctorName, 390 + pLeft, 12);
            PlaceChunckSignature(writer, ")", 580, 12);


            return imgTable;
        }


        private void placeChunckImageDetail(PdfWriter writer, string text, int x, int y)
        {
            PdfContentByte cb = writer.DirectContent;
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

            string imageDetailColor = load.getOption("option_value", "imageDetailColor");

            cb.SaveState();
            cb.BeginText();
            cb.MoveText(x, y);
            cb.SetFontAndSize(bf, 9);
            switch (imageDetailColor)
            {
                case "Black":
                    cb.SetColorFill(Black);
                    break;
                case "DimGray":
                    cb.SetColorFill(DimGray);
                    break;
                case "Gray":
                    cb.SetColorFill(Gray);
                    break;
                case "LightSkyBlue":
                    cb.SetColorFill(LightSkyBlue);
                    break;
                case "DarkGreen":
                    cb.SetColorFill(DarkGreen);
                    break;
            }
            cb.ShowText(text);
            cb.EndText();
            cb.RestoreState();
        }


        private void placeChunckImageTitle(PdfWriter writer, string text, int x, int y)
        {
            PdfContentByte cb = writer.DirectContent;
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

            string imageTitleColor = load.getOption("option_value", "imageTitleColor");

            cb.SaveState();
            cb.Fill();
            cb.BeginText();
            cb.MoveText(x, y);
            cb.SetFontAndSize(bf, 13);
            switch (imageTitleColor)
            {
                case "Black":
                    cb.SetColorFill(Black);
                    break;
                case "DimGray":
                    cb.SetColorFill(DimGray);
                    break;
                case "Gray":
                    cb.SetColorFill(Gray);
                    break;
                case "LightSkyBlue":
                    cb.SetColorFill(LightSkyBlue);
                    break;
                case "DarkGreen":
                    cb.SetColorFill(DarkGreen);
                    break;
            }
            cb.ShowText(text);
            cb.EndText();
            cb.RestoreState();
        }


        private void PlaceChunckSignature(PdfWriter writer, string text, int x, int y)
        {
            PdfContentByte cb = writer.DirectContent;
            BaseFont bf = BaseFont.CreateFont("c:/windows/fonts/micross.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            cb.SaveState();
            cb.BeginText();
            cb.MoveText(x, y);
            cb.SetFontAndSize(bf, 11);
            cb.ShowText(text);
            cb.EndText();
            cb.RestoreState();
        }
    }
}
