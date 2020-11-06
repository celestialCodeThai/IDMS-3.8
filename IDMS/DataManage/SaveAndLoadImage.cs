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
    class SaveAndLoadImage
    {
        public const int max = 66;

        public static void savepicture(UserControl reportcon, string caseid)
        {
            imageReport report = (imageReport)reportcon;
            DataAccess load = new DataAccess();
            string pictureMode = load.getOption("option_value", "pictureMode");
            bool squareMode = pictureMode == "1";

            int k;
            string[] field = new string[max];
            string[] cfield = new string[max];
            string[] data = new string[max];
            string[] cdata = new string[max];
            for (int i = 0; i < max; i++)
            {
                k = i + 1;

                field[i] = "img" + k.ToString();
                data[i] = report.imgPath[i];
                cfield[i] = "cb" + k.ToString();
                cdata[i] = report.cBoxIndex[i].ToString();


            }

            load.addReportFieldnew(caseid, data, field);
            load.addReportFieldnew(caseid, cdata, cfield);

            string[] imagesPointDatas = new string[max];
            string[] imagesPointField = new string[max];

            for (int i = 0; i < max; i++)
            {
                imagesPointField[i] = "point_" + (i + 1) + "";
                imagesPointDatas[i] = report.recImage[i].ToString();
            }


            load.imagePointInsertOrUpdate(caseid, imagesPointDatas, imagesPointField, squareMode);

        }


        public static void Loadpicture(UserControl r, UserControl reportcon, string caseid)
        {
            imageReport report = (imageReport)reportcon;
            Report rep = (Report)r;
            DataAccess load = new DataAccess();
            string pictureMode = load.getOption("option_value", "pictureMode");
            bool squareMode = pictureMode == "1";

            string imageName = "";
            string Value = "";
            int k;
            for (int i = 0; i < max; i++)
            {
                k = i + 1;

                if (load.getValue(caseid, "img" + k) != "")
                {
                    Value = load.getValue(caseid, "img" + k);

                    int fieldNumber = i + 1;


                    string imagePoint;
                    if (squareMode)
                    {
                        imagePoint = load.getValueWithTableName(caseid, "image_point", "point_" + fieldNumber + "");
                    }
                    else
                    {
                        imagePoint = load.getValueWithTableName(caseid, "image_point_wide", "point_" + fieldNumber + "");
                    }


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

                    report.cBoxIndex[i] = Convert.ToInt32(load.getValue(caseid, "cb" + k));
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
