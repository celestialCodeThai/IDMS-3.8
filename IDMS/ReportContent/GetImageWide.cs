using IDMS.DataManage;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        /*
        public PdfPTable GetImageWideScreen(Document pdfDoc, PdfWriter writer, imageReport output, string doctorName)
        {
            string[] P1 = new string[] { "A", "B", "C", "D", "E", "F" };
            Image picPdf1 = null, picPdf2 = null, picPdf3 = null, picPdf4 = null, picPdf5 = null, picPdf6 = null;
            Image[] picPDF;
            picPDF = new Image[] { picPdf1, picPdf2, picPdf3, picPdf4, picPdf5, picPdf6 };


            PdfPTable imgTable = new PdfPTable(2);
            PdfContentByte cb = writer.DirectContent;

            int imageWidth = 173;
            int imageHeight = 97;
            int smallGap = 2;
            int paddingLeft = 65;

            int LoopX = paddingLeft;  
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
            if (i < 6) { imgperpage = i; } else { imgperpage = 6; }
            for (int z = 0; z < imgperpage; z++)
            {
                Image img = Image.FromFile(output.imgPath[z]);
                Image v = Image.GetInstance(output.MakeSquareEndoWayPoint(img, 500, output.recImage[z]), System.Drawing.Imaging.ImageFormat.Jpeg);

                picPDF[z] = v;
                picPDF[z].ScaleAbsolute(imageWidth, imageHeight);
                picPDF[z].SetAbsolutePosition(LoopX, LoopY);
                pdfDoc.Add(picPDF[z]);
                PlaceChunckTitle(writer, P1[z], LoopX, LoopY - 15);
                PlaceChunckDetail(writer, output.cBoxes[z].Text, LoopX + 12, LoopY - 14);
                if (z == 2)
                {
                    LoopX = paddingLeft; LoopY = LoopY - imageHeight - 20;
                }
                else
                { LoopX += imageWidth + smallGap; }
            }


            int checkLength = doctorName.Length;
            int paddingLeft = (30 - checkLength) * 4;
            if (checkLength > 20) { paddingLeft += 20; }


            cb.MoveTo(200, 7);
            cb.LineTo(580, 7);
            cb.Stroke();
            PlaceChunckSignature(writer, "Signature", 200, 12);
            PlaceChunckSignature(writer, "(", 390, 12);
            PlaceChunckSignature(writer, doctorName, 390 + paddingLeft, 12);
            PlaceChunckSignature(writer, ")", 580, 12);


            return imgTable;

        }
        */

        private void PlaceChunckDetail(PdfWriter writer, String text, int x, int y)
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


        private void PlaceChunckTitle(PdfWriter writer, String text, int x, int y)
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

    }
}
