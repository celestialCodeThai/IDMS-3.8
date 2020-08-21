using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using IDMS.DataManage;
using IDMS.ReportContent;
using System.Text.RegularExpressions;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Rectangle = iTextSharp.text.Rectangle;
using Image = System.Drawing.Image;
using Font = iTextSharp.text.Font;
using System.Diagnostics;
using IDMS.Popup;
using System.Threading;

namespace IDMS.Page


{
    public partial class Report : UserControl
    {
        const int BODY_X = 65;
        const int SMALL_GAP = 2;
        const int IMG_SIZE = 130;
        public static int fileCount;

        private idmsPage idms;
        public string imgFolder;
        public int currentRow;
        public static Report Current;

        string PRO = "";
        imageReport EGDControl;
        imageReport COLControl;
        imageReport ENTControl;
        imageReport BRONCOControl;
        imageReport ERCPControl;


        reportControlEGD report;
        reportControlColono report2;
        reportControlERCP report3;
        reportControlBronco report4;
        reportControlENT report5;

        public bool Multimode;
        public DataTable table = new DataTable();
        string hnid;
        public string caseid;
        public string casepro;
        AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

        MySqlConnection connection = new MySqlConnection(dbhelper.CnnVal("db"));
        MySqlDataReader reader;
        MySqlDataReader readerPro;

        public string date;
        public string day;
        public static string Savecid;
        public static string SavePRO = "";
        public static imageReport SaveEGDControl;
        public static imageReport SaveCOLControl;
        public static imageReport SaveENTControl;
        public static imageReport SaveBRONCOControl;
        public static imageReport SaveERCPControl;

        public static UserControl Savereport;

        public static reportControlColono RC;
        public static imageReport RCIMG;

        public static reportControlEGD RE;
        public static imageReport REIMG;

        public static reportControlERCP RCP;
        public static imageReport RCPIMG;
        public static reportControlERCP Savereport3;


        public static reportControlColono Savereport2;
        public static reportControlBronco Savereport4;
        public static reportControlENT Savereport5;




        public static Report Saveinfo;
        public static string ALL_PRO;
        public static bool SaveMultimode;

        public Report(idmsPage mainPage, string hn, string cid, string pro)
        {
            Savecid = cid;
            fileCount = 0;
            idmsPage.currentPage = "report";
            this.hnid = hn;
            this.caseid = cid;
            this.casepro = pro;
            table.Columns.Add("Image List");
            InitializeComponent();
            this.idms = mainPage;
            MySqlConnection connectionP = new MySqlConnection(dbhelper.CnnVal("db"));
            connectionP.Open();

            MySqlCommand myCommandPro = new MySqlCommand("select * from patientcase where caseid='" + caseid + "'", connectionP);
            readerPro = myCommandPro.ExecuteReader();
            while (readerPro.Read())
            {

                infopro.Text = readerPro["Procedure"].ToString();
                date = readerPro["Date"].ToString();
                day = readerPro["Day"].ToString();
            }

            connectionP.Close();
            Multimode = false;
            if (infopro.Text.Contains("/") == true)
            {
                Multimode = true;
                ALL_PRO = infopro.Text;
            }

            if (Multimode)
            {

                if (casepro == "EGD")
                {
                    PRO = "EGD";
                    report = new reportControlEGD(cid); ;
                    userPanel.Controls.Add(report);

                    EGDControl = new imageReport(casepro);
                    imagePanel.Controls.Add(EGDControl);
                    RE = (reportControlEGD)report;
                    REIMG = EGDControl;
                }
                if (casepro == "Colonoscopy")
                {
                    PRO = "COL";
                    report2 = new reportControlColono(cid);
                    userPanel.Controls.Add(report2);

                    COLControl = new imageReport(casepro);
                    imagePanel.Controls.Add(COLControl);
                    RC = (reportControlColono)report2;
                    RCIMG = COLControl;
                }
                if (casepro == "ERCP")
                {
                    PRO = "ERCP";
                    report3 = new reportControlERCP(cid);
                    userPanel.Controls.Add(report3);

                    ERCPControl = new imageReport(casepro);
                    imagePanel.Controls.Add(ERCPControl);
                    RCP = (reportControlERCP)report3;
                    RCPIMG = ERCPControl;
                }
                infopro.Text = casepro;
            }
            else
            {
                if (infopro.Text == "EGD")
                {
                    PRO = "EGD";
                    report = new reportControlEGD(cid); ;
                    userPanel.Controls.Add(report);
                    EGDControl = new imageReport(infopro.Text);
                    imagePanel.Controls.Add(EGDControl);
                }
                else
                {
                    if (infopro.Text == "Colonoscopy")
                    {
                        PRO = "COL";
                        report2 = new reportControlColono(cid);
                        userPanel.Controls.Add(report2);
                        COLControl = new imageReport(infopro.Text);
                        imagePanel.Controls.Add(COLControl);
                    }
                    else
                    {
                        if (infopro.Text == "ERCP")
                        {
                            PRO = "ERCP";
                            report3 = new reportControlERCP(cid);
                            userPanel.Controls.Add(report3);

                            ERCPControl = new imageReport(infopro.Text);
                            imagePanel.Controls.Add(ERCPControl);
                        }
                        else
                        {
                            if (infopro.Text == "BRONCO")
                            {
                                PRO = "BRONCO";
                                report4 = new reportControlBronco(cid);
                                userPanel.Controls.Add(report4);

                                BRONCOControl = new imageReport(infopro.Text);
                                imagePanel.Controls.Add(BRONCOControl);
                                BronL1.Visible = true;
                                BronL2.Visible = true;
                                BronL3.Visible = true;
                            }
                            else
                            {
                                if (infopro.Text == "ENT")
                                {
                                    PRO = "ENT";
                                    report5 = new reportControlENT();
                                    userPanel.Controls.Add(report5);

                                    ENTControl = new imageReport(infopro.Text);
                                    imagePanel.Controls.Add(ENTControl);

                                }
                            }
                        }
                    }
                }
            }

            //
            SavePRO = PRO;
            SaveCOLControl = COLControl;
            SaveEGDControl = EGDControl;
            SaveENTControl = ENTControl;
            SaveERCPControl = ERCPControl;
            SaveBRONCOControl = BRONCOControl;
            Savereport = report;
            Savereport2 = report2;
            Savereport3 = report3;
            Savereport4 = report4;
            Savereport5 = report5;

            SaveMultimode = Multimode;
            Saveinfo = this;
            //
            ORIGINAL_ID = caseid;
            // imagePanel.Controls.Add(imgControl);










            if (caseid.Contains(PRO))
            {
                ORIGINAL_ID = caseid.Replace(PRO, null);
            }


            imgFolder = IDMS.World.Settings.savePath + "/images/" + specialCharReplace(ORIGINAL_ID) + "/" + PRO + "/";
            string imgFolder_oldversion = IDMS.World.Settings.savePath + "/" + specialCharReplace(ORIGINAL_ID) + "/pictures/" + PRO + "/";

            imgFolder_oldversion = imgFolder_oldversion.Replace("idmsCASE", "idmsData");


            if ((!System.IO.Directory.Exists(imgFolder)) && (System.IO.Directory.Exists(imgFolder_oldversion)))
            {
                imgFolder = imgFolder_oldversion;
            }



            if (!Directory.Exists(imgFolder))
            {
                //MessageBox.Show(imgFolder + "\r\n has been not Found ! \r\n Create new Folder");
                autoDirectoryImage();
            }

            reloadImageList();
            loadCaseData();

            saveReportdata();


            string caseID = caseid;
            if (Multimode)
            {
                caseID = ORIGINAL_ID + PRO;
            }


            //load data
            LOAD_DATA(PRO, caseID);
            //if (PRO == "COL")
            //{

            //    manageReportCOL newreport = new manageReportCOL();
            //    newreport.LoadReportField(report2, caseID, this);
            //    newreport.Loadpicture(this, COLControl, caseID);
            //}
            //else
            //{
            //    if (PRO == "EGD")
            //    {


            //        manageReportEGD newreport = new manageReportEGD();
            //        newreport.LoadReportField(report, caseID, this);
            //        newreport.Loadpicture(this, EGDControl, caseID);

            //    }
            //}


        }








        delegate void DelUserControlMetod(string name);



        private void Report_Load(object sender, EventArgs e)
        {
            //  reloadImageList();

            DelUserControlMetod delUserControl = new DelUserControlMetod(updateTable);
            if (PRO == "EGD")
            {
                EGDControl.CallingPageMethod = delUserControl;
            }
            if (PRO == "COL")
            {
                COLControl.CallingPageMethod = delUserControl;
            }
            if (PRO == "ERCP")
            {
                ERCPControl.CallingPageMethod = delUserControl;
            }
            if (PRO == "BRONCO")
            {
                BRONCOControl.CallingPageMethod = delUserControl;
            }
            if (PRO == "ENT")
            {
                ENTControl.CallingPageMethod = delUserControl;
            }
        }

        public void updateTable(string name)
        {
            string fileName = Path.GetFileName(name);
            table.Rows.Add(fileName);
            for (int v = 0; v < selectImageTable.Rows.Count; v++)
            {
                if (string.Equals(selectImageTable[0, v].Value as string, fileName))
                {
                    selectImageTable.Rows.RemoveAt(v);
                    v--;
                }
            }
        }

        public void reloadImageList()
        {

            try
            {
                string[] files = Directory.GetFiles(imgFolder);
                for (int i = 0; i < files.Length; i++)
                {
                    FileInfo file = new FileInfo(files[i]);
                    table.Rows.Add(file.Name);
                }

                imagelistTable.DataSource = table;




            }
            catch (DirectoryNotFoundException)
            {

                return;
            }






        }

        private void imagelistTable_DoubleClick(object sender, EventArgs e)
        {

            if ((rowIsNotNull(currentRow) == true) && selectImageTable.Rows.Count <= 66)
            {
                string imageName = imagelistTable.CurrentRow.Cells[0].Value.ToString();

                imagelistTable.CurrentCell = imagelistTable.CurrentRow.Cells[0];

                //MultiMode
                if (PRO == "EGD")
                {
                    EGDControl.setPicture(imgFolder + imageName);
                }
                else
                if (PRO == "COL")
                {
                    COLControl.setPicture(imgFolder + imageName);
                }
                else
                if (PRO == "ERCP")
                {
                    ERCPControl.setPicture(imgFolder + imageName);
                }
                else
                if (PRO == "BRONCO")
                {
                    BRONCOControl.setPicture(imgFolder + imageName);
                }
                else
                if (PRO == "ENT")
                {
                    ENTControl.setPicture(imgFolder + imageName);
                }
                //MultiMode

                selectImageTable.Rows.Add(imageName);
                int x = selectImageTable.Rows.Count - 2;
                selectImageTable.ClearSelection();
                if (selectImageTable.Rows[x].Cells[0].Value != null)
                { selectImageTable.Rows[x].Selected = true; }
                imagelistTable.Rows.RemoveAt(imagelistTable.CurrentCell.RowIndex);
                selectImageTable.FirstDisplayedScrollingRowIndex = x;
                if (imagelistTable.Rows.Count > 0 && imagelistTable.Rows[0] != null && imagelistTable.Rows[0].Cells[0] != null && imagelistTable.Rows[0].Cells[0].Value != null)
                {
                    //MessageBox.Show(imagelistTable.Rows.Count.ToString());

                    if (PRO == "EGD")
                    {
                        picPreview.Image = EGDControl.MakeSquareEndoWay(Image.FromFile(imgFolder + imagelistTable.Rows[0].Cells[0].Value.ToString()), 500);

                    }
                    else
                    {
                        if (PRO == "COL")
                        {
                            picPreview.Image = COLControl.MakeSquareEndoWay(Image.FromFile(imgFolder + imagelistTable.Rows[0].Cells[0].Value.ToString()), 500);
                        }
                        else
                        if (PRO == "ERCP")
                        {
                            picPreview.Image = ERCPControl.MakeSquareEndoWay(Image.FromFile(imgFolder + imagelistTable.Rows[0].Cells[0].Value.ToString()), 500);
                        }
                        else
                        if (PRO == "BRONCO")
                        {
                            picPreview.Image = BRONCOControl.MakeSquareEndoWay(Image.FromFile(imgFolder + imagelistTable.Rows[0].Cells[0].Value.ToString()), 500);
                        }
                        else
                        if (PRO == "ENT")
                        {
                            picPreview.Image = ENTControl.MakeSquareEndoWay(Image.FromFile(imgFolder + imagelistTable.Rows[0].Cells[0].Value.ToString()), 500);
                        }
                    }
                    /*
                    if (PRO == "EGD")
                    {
                        picPreview.Image = EGDControl.MakeSquareEndoWayPoint(Image.FromFile(imgFolder + imagelistTable.Rows[0].Cells[0].Value.ToString()), 500, EGDControl.recImage[0]);

                    }
                    else
                    {
                        if (PRO == "COL")
                        {
                            picPreview.Image = COLControl.MakeSquareEndoWayPoint(Image.FromFile(imgFolder + imagelistTable.Rows[0].Cells[0].Value.ToString()), 500, COLControl.recImage[0]);
                        }
                        else
                        if (PRO == "ERCP")
                        {
                            picPreview.Image = ENTControl.MakeSquareEndoWayPoint(Image.FromFile(imgFolder + imagelistTable.Rows[0].Cells[0].Value.ToString()), 500, ENTControl.recImage[0]);
                        }
                        else
                        if (PRO == "BRONCO")
                        {
                            picPreview.Image = BRONCOControl.MakeSquareEndoWayPoint(Image.FromFile(imgFolder + imagelistTable.Rows[0].Cells[0].Value.ToString()), 500, BRONCOControl.recImage[0]);
                        }
                    }
                    */
                    imageName = imagelistTable.CurrentRow.Cells[0].Value.ToString();
                    picnamePreview.Text = imageName.Substring(0, imageName.Length - 4);
                }

            }
        }






        private void imagelistTable_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            /*
            currentRow = e.RowIndex;
            if ((rowIsNotNull(currentRow) == true))
            {
                imagelistTable.CurrentCell = imagelistTable.Rows[e.RowIndex].Cells[0];

                string imageName = imagelistTable.CurrentRow.Cells[0].Value.ToString();

                imagelistTable.CurrentCell = imagelistTable.CurrentRow.Cells[0];

                Image img;
                img = Image.FromFile(imgFolder + imageName);

                picPreview.Image = img;
                picnamePreview.Text = imageName.Substring(0, imageName.Length - 4);

            }
            */



        }

        private void imagelistTable_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {


        }



        private bool rowIsNotNull(int rowIndex)
        {
            if (rowIndex >= 0)
            {
                if (rowIndex < imagelistTable.RowCount - 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        private bool selectRowIsNotNull(int rowIndex)
        {
            if (rowIndex >= 0)
            {
                if (rowIndex < selectImageTable.RowCount - 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        private bool rowSelectIsNotNull(int rowIndex)
        {
            if (rowIndex >= 0)
            {
                if (rowIndex < selectImageTable.RowCount - 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void clearRecImage()
        {
            switch (PRO)
            {
                case "EGD":
                    EGDControl.setDefaultRectangle();
                    break;
                case "COL":
                    EGDControl.setDefaultRectangle();
                    break;
                case "ERCP":
                    EGDControl.setDefaultRectangle();
                    break;
                case "BRONCO":
                    EGDControl.setDefaultRectangle();
                    break;
                case "ENT":
                    EGDControl.setDefaultRectangle();
                    break;
            }
        }

        private void CLEAR_IMAGE()
        {
            if (casepro != "")
            {
                selectImageTable.ClearSelection();

                for (int v = 0; v < table.Rows.Count; v++)
                {
                    //string imageName = imagelistTable.CurrentRow.Cells[0].Value.ToString();
                    string imageName = imagelistTable.Rows[v].Cells[0].Value.ToString();
                    //System.Windows.Forms.MessageBox.Show(imageName);

                    // imagelistTable.CurrentCell = imagelistTable.CurrentRow.Cells[0];

                    if (PRO == "EGD")
                    {
                        EGDControl.setPicture(imgFolder + imageName);

                    }
                    if (PRO == "COL")
                    {
                        COLControl.setPicture(imgFolder + imageName);
                    }
                    if (PRO == "ERCP")
                    {
                        ERCPControl.setPicture(imgFolder + imageName);
                    }
                    if (PRO == "ENT")
                    {
                        ENTControl.setPicture(imgFolder + imageName);
                    }
                    if (PRO == "BRONCO")
                    {
                        BRONCOControl.setPicture(imgFolder + imageName);
                    }
                    selectImageTable.Rows.Add(imageName);




                }
                table.Clear();

            }
            if (PRO == "EGD")
            {
                EGDControl.clearPicture();

            }
            else
            {
                if (PRO == "COL")
                {
                    COLControl.clearPicture();

                }
                else
                {
                    if (PRO == "ERCP")
                    {
                        ERCPControl.clearPicture();

                    }
                    else
                    {
                        if (PRO == "BRONCO")
                        {
                            BRONCOControl.clearPicture();

                        }
                        else
                        {
                            if (PRO == "ENT")
                            {
                                ENTControl.clearPicture();

                            }

                        }

                    }

                }
            }
            selectImageTable.Rows.Clear();
            table.Clear();
            reloadImageList();
            try
            {
                if (imagelistTable.Rows.Count > 1)
                {

                    if (PRO == "EGD")
                    {
                        picPreview.Image = EGDControl.MakeSquareEndoWay(Image.FromFile(imgFolder + imagelistTable.Rows[0].Cells[0].Value.ToString()), 500);
                    }
                    else
                    {
                        if (PRO == "COL")
                        {
                            picPreview.Image = COLControl.MakeSquareEndoWay(Image.FromFile(imgFolder + imagelistTable.Rows[0].Cells[0].Value.ToString()), 500);
                        }
                        else
                        {
                            if (PRO == "ERCP")
                            {
                                picPreview.Image = ERCPControl.MakeSquareEndoWay(Image.FromFile(imgFolder + imagelistTable.Rows[0].Cells[0].Value.ToString()), 500);

                            }
                            else
                            {
                                if (PRO == "BRONCO")
                                {
                                    picPreview.Image = BRONCOControl.MakeSquareEndoWay(Image.FromFile(imgFolder + imagelistTable.Rows[0].Cells[0].Value.ToString()), 500);

                                }
                                {
                                    if (PRO == "ENT")
                                    {
                                        picPreview.Image = ENTControl.MakeSquareEndoWay(Image.FromFile(imgFolder + imagelistTable.Rows[0].Cells[0].Value.ToString()), 500);

                                    }

                                }

                            }

                        }
                    }
                    /*
                    if (PRO == "EGD")
                    {
                        picPreview.Image = EGDControl.MakeSquareEndoWayPoint(Image.FromFile(imgFolder + imagelistTable.Rows[0].Cells[0].Value.ToString()), 500, EGDControl.recImage[0]);
                    }
                    else
                    {
                        if (PRO == "COL")
                        {
                            picPreview.Image = COLControl.MakeSquareEndoWayPoint(Image.FromFile(imgFolder + imagelistTable.Rows[0].Cells[0].Value.ToString()), 500, COLControl.recImage[0]);
                        }
                        else
                        {
                            if (PRO == "ERCP")
                            {
                                picPreview.Image = ENTControl.MakeSquareEndoWayPoint(Image.FromFile(imgFolder + imagelistTable.Rows[0].Cells[0].Value.ToString()), 500, ENTControl.recImage[0]);

                            }
                            else
                            {
                                if (PRO == "BRONCO")
                                {
                                    picPreview.Image = BRONCOControl.MakeSquareEndoWayPoint(Image.FromFile(imgFolder + imagelistTable.Rows[0].Cells[0].Value.ToString()), 500, BRONCOControl.recImage[0]);

                                }

                            }

                        }
                    }
                    */
                    string imageName2 = imagelistTable.Rows[0].Cells[0].Value.ToString();

                    imageName2 = imagelistTable.CurrentRow.Cells[0].Value.ToString();
                    picnamePreview.Text = imageName2.Substring(0, imageName2.Length - 4);
                }
            }
            catch { }
        }



        private void clearImageButton_Click(object sender, EventArgs e)
        {

            CLEAR_IMAGE();
            clearRecImage();



        }







        /*
                private void selectImageTable_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
                {
                    currentRow = e.RowIndex;
                    if ((rowSelectIsNotNull(currentRow) == true))
                    {
                        selectImageTable.CurrentCell = selectImageTable.Rows[e.RowIndex].Cells[0];

                        string imageName = selectImageTable.CurrentRow.Cells[0].Value.ToString();

                        selectImageTable.CurrentCell = selectImageTable.CurrentRow.Cells[0];

                        Image img;
                        img = Image.FromFile(imgFolder + imageName);

                        picPreview.Image = img;
                        picnamePreview.Text = imageName.Substring(0, imageName.Length - 4);

                    }

                }
                /
                private void selectImageTable_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
                {
                    picPreview.Image = null;
                    picnamePreview.Text = null;
                }
                */
        private void importButton_Click(object sender, EventArgs e)
        {
            if (casepro != "")
            {
                switch (PRO)
                {
                    case "EGD":
                        EGDControl.clearPicture();
                        break;
                    case "COL":
                        COLControl.clearPicture();
                        break;
                    case "ERCP":
                        ERCPControl.clearPicture();
                        break;
                    case "ENT":
                        ENTControl.clearPicture();
                        break;
                    case "BRONCO":
                        BRONCOControl.clearPicture();
                        break;

                }
                selectImageTable.Rows.Clear();
                table.Clear();
                reloadImageList();





                picnamePreview.Text = "";





            }
            selectImageTable.ClearSelection();
            int row = table.Rows.Count;
            for (int v = 0; v < row && selectImageTable.Rows.Count <= 66; v++)
            {
                string imageName = imagelistTable.Rows[0].Cells[0].Value.ToString();
                switch (PRO)
                {
                    case "EGD":
                        EGDControl.setPicture(imgFolder + imageName);
                        break;
                    case "COL":
                        COLControl.setPicture(imgFolder + imageName);
                        break;
                    case "ERCP":
                        ERCPControl.setPicture(imgFolder + imageName);
                        break;
                    case "ENT":
                        ENTControl.setPicture(imgFolder + imageName);
                        break;
                    case "BRONCO":
                        BRONCOControl.setPicture(imgFolder + imageName);
                        break;

                }

                selectImageTable.Rows.Add(imageName);

                imagelistTable.Rows.RemoveAt(imagelistTable.Rows[0].Index);

            }
            //  table.Clear();

        }
        private void loadCaseData()
        {

            connection.Open();
            MySqlCommand myCommand = new MySqlCommand("select * from patientdata where hn='" + hnid + "'", connection);

            reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                patientHN.Text = hnid;
                patientFirstName.Text = (reader["name"].ToString());
                patientSurname.Text = (reader["surname"].ToString());
                //  infohn.Text = patientHN.Text;
                // infoname.Text = reader["prefix"].ToString() + " " + patientFirstName.Text + "  " + patientSurname.Text;
                infoage.Text = reader["age"].ToString();
                infosex.Text = reader["sex"].ToString();
                infoward.Text = reader["type"].ToString();
                nation.Text = reader["nationality"].ToString();


            }
            reader.Close();

            // changeFont(infoname);

            MySqlCommand myCommand2 = new MySqlCommand("select * from patientcase where caseid='" + caseid + "'", connection);


            reader = myCommand2.ExecuteReader();
            in2.Text = "";
            while (reader.Read())
            {
                inforegis.Text = reader["date"].ToString();
                registerDay.Text = reader["Day"].ToString();
                infoproroom.Text = reader["Procedure Room"].ToString();
                indication.Text = reader["Indication"].ToString();
                MessageBox.Show(indication.Text.Length.ToString());

                infoinstrument.Text = reader["cameraA"].ToString();
                in2.Text = reader["cameraB"].ToString();

                infohn.Text = reader["hn"].ToString();
                infoname.Text = reader["Patient Name"].ToString();

                infodoc.Text = reader["doctor"].ToString();
                infoass.Text = reader["doctor 2"].ToString();
                infosnurse.Text = reader["Scrub Nurse"].ToString();
                infocnurse.Text = reader["Circulating Nurse"].ToString();
                anes.Text = reader["Anesthesist"].ToString();
                pdx1.Text = reader["PreDX1"].ToString();
                pdx2.Text = reader["PreDX2"].ToString();
                pdx3.Text = reader["PreDX3"].ToString();
                pdx4.Text = reader["PreDX4"].ToString();
                Duration.Text = reader["Duration"].ToString();
            }
            //changeFont(infodoc);
            //changeFont(infoass);
            //changeFont(infosnurse);
            //changeFont(infocnurse);
            //changeFont(anes);
            string imageName;

            //if ((imagelistTable.Rows[0].Cells[0].Value != null) && (imagelistTable.Rows[0].Cells[0].Value.ToString() != ""))
            if (imagelistTable.Rows.Count > 1)
            {
                switch (PRO)
                {
                    case "EGD":
                        picPreview.Image = EGDControl.MakeSquareEndoWayPoint(Image.FromFile(imgFolder + imagelistTable.Rows[0].Cells[0].Value.ToString()), 500, EGDControl.recImage[0]);
                        imageName = imagelistTable.Rows[0].Cells[0].Value.ToString();
                        picnamePreview.Text = imageName.Substring(0, imageName.Length - 4);
                        break;
                    case "COL":
                        picPreview.Image = COLControl.MakeSquareEndoWayPoint(Image.FromFile(imgFolder + imagelistTable.Rows[0].Cells[0].Value.ToString()), 500, COLControl.recImage[0]);
                        imageName = imagelistTable.Rows[0].Cells[0].Value.ToString();
                        picnamePreview.Text = imageName.Substring(0, imageName.Length - 4);
                        break;
                    case "ERCP":
                        picPreview.Image = ERCPControl.MakeSquareEndoWayPoint(Image.FromFile(imgFolder + imagelistTable.Rows[0].Cells[0].Value.ToString()), 500, ERCPControl.recImage[0]);
                        imageName = imagelistTable.Rows[0].Cells[0].Value.ToString();
                        picnamePreview.Text = imageName.Substring(0, imageName.Length - 4);
                        break;
                    case "ENT":
                        picPreview.Image = ENTControl.MakeSquareEndoWayPoint(Image.FromFile(imgFolder + imagelistTable.Rows[0].Cells[0].Value.ToString()), 500, ENTControl.recImage[0]);
                        imageName = imagelistTable.Rows[0].Cells[0].Value.ToString();
                        picnamePreview.Text = imageName.Substring(0, imageName.Length - 4);
                        break;
                    case "BRONCO":
                        picPreview.Image = BRONCOControl.MakeSquareEndoWayPoint(Image.FromFile(imgFolder + imagelistTable.Rows[0].Cells[0].Value.ToString()), 500, BRONCOControl.recImage[0]);
                        imageName = imagelistTable.Rows[0].Cells[0].Value.ToString();
                        picnamePreview.Text = imageName.Substring(0, imageName.Length - 4);
                        break;
                }
            }
        }
        /*
        private void patientHN_TextChanged(object sender, EventArgs e)
        {
            this.patientHN.AutoCompleteCustomSource = collection;


            MySqlCommand myCommand = new MySqlCommand("select * from patientcase where caseid='" + caseid + "'", connection);
            reader.Close();

            reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                patientFirstName.Text = (reader["name"].ToString());
                patientSurname.Text = (reader["surname"].ToString());

            }

            //imgFolder = this.patientHN.ToString();

            caseInfoUpdate();

        }
        */
        private void patientFirstName_TextChanged(object sender, EventArgs e)
        {
            /*
            string cpro = "";
            if (casepro != "")
            {
                if (casepro == "EGD") { cpro = "EGD"; }
                if (casepro == "Colonoscopy") { cpro = "COL"; }
                if (casepro == "Enterscopy") { cpro = "ERCP"; }
            }
            else
            {
                if (infopro.Text == "EGD") { cpro = "EGD"; }
                if (infopro.Text == "Colonoscopy") { cpro = "COL"; }
                if (infopro.Text == "Enterscopy") { cpro = "ERCP"; }
            }
            imgFolder = IDMS.World.Settings.savePath + "/" + caseid + "/pictures/" + cpro + "/";
*/
            // reloadImageList();

        }

        private void Export_Click(object sender, EventArgs e)
        {

        }

        private void caseInfoUpdate()
        {
            infohn.Text = patientHN.Text;
            infoname.Text = patientFirstName.Text + " " + patientSurname.Text;
            // infoage.Text = 


        }

        private void imagelistTable_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void imagelistTable_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            currentRow = e.RowIndex;
            if ((rowIsNotNull(currentRow) == true))
            {
                imagelistTable.CurrentCell = imagelistTable.Rows[e.RowIndex].Cells[0];

                string imageName = imagelistTable.CurrentRow.Cells[0].Value.ToString();

                imagelistTable.CurrentCell = imagelistTable.CurrentRow.Cells[0];

                Image img;
                img = Image.FromFile(imgFolder + imageName);
                switch (PRO)
                {
                    case "EGD":
                        picPreview.Image = EGDControl.MakeSquareEndoWay(img, 500);
                        break;
                    case "COL":
                        picPreview.Image = COLControl.MakeSquareEndoWay(img, 500);
                        break;
                    case "ERCP":
                        picPreview.Image = ERCPControl.MakeSquareEndoWay(img, 500);
                        break;
                    case "ENT":
                        picPreview.Image = ENTControl.MakeSquareEndoWay(img, 500);
                        break;
                    case "BRONCO":
                        picPreview.Image = BRONCOControl.MakeSquareEndoWay(img, 500);
                        break;
                }
                picnamePreview.Text = imageName.Substring(0, imageName.Length - 4);

            }
        }






        private void selectImageTable_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            currentRow = e.RowIndex;
            if ((selectRowIsNotNull(currentRow) == true))
            {
                selectImageTable.CurrentCell = selectImageTable.Rows[e.RowIndex].Cells[0];

                string imageName = selectImageTable.CurrentRow.Cells[0].Value.ToString();

                selectImageTable.CurrentCell = selectImageTable.CurrentRow.Cells[0];
                try
                {
                    Image img;
                    img = Image.FromFile(imgFolder + imageName);
                    switch (PRO)
                    {
                        case "EGD":
                            picPreview.Image = EGDControl.MakeSquareEndoWayPoint(img, 500, EGDControl.recImage[currentRow]);
                            break;
                        case "COL":
                            picPreview.Image = COLControl.MakeSquareEndoWayPoint(img, 500, COLControl.recImage[currentRow]);
                            break;
                        case "ERCP":
                            picPreview.Image = ERCPControl.MakeSquareEndoWayPoint(img, 500, ERCPControl.recImage[currentRow]);
                            break;
                        case "ENT":
                            picPreview.Image = ENTControl.MakeSquareEndoWayPoint(img, 500, ENTControl.recImage[currentRow]);
                            break;
                        case "BRONCO":
                            picPreview.Image = BRONCOControl.MakeSquareEndoWayPoint(img, 500, BRONCOControl.recImage[currentRow]);
                            break;
                    }
                    picnamePreview.Text = imageName.Substring(0, imageName.Length - 4);
                }
                catch
                {
                    MessageBox.Show(imageName + " is missing");
                }

            }
        }

        private void infodoc_Click(object sender, EventArgs e)
        {

        }

        private void selectImageTable_DoubleClick(object sender, EventArgs e)
        {
            if (selectRowIsNotNull(currentRow) == true)
            {
                string imageName = selectImageTable.CurrentRow.Cells[0].Value.ToString();

                selectImageTable.CurrentCell = selectImageTable.CurrentRow.Cells[0];
                switch (PRO)
                {
                    case "EGD":
                        EGDControl.removePicture(imgFolder, imageName);
                        break;
                    case "COL":
                        COLControl.removePicture(imgFolder, imageName);
                        break;
                    case "ERCP":
                        ERCPControl.removePicture(imgFolder, imageName);
                        break;
                    case "ENT":
                        ENTControl.removePicture(imgFolder, imageName);
                        break;
                    case "BRONCO":
                        BRONCOControl.removePicture(imgFolder, imageName);
                        break;
                }
                table.Rows.Add(imageName);
                imagelistTable.Sort(imagelistTable.Columns[0], ListSortDirection.Ascending);

            }
        }




        private void changeFont(Label text)
        {
            string temp = text.Text.Replace(" ", null);
            temp = temp.Replace(".", null);
            if (Regex.IsMatch(temp, "^[a-zA-Z0-9]*$"))
            {
                text.Font = new System.Drawing.Font("Roboto", 11.25f, FontStyle.Regular);
                text.Location = new Point(text.Location.X, text.Location.Y + 2);
            }
            else
            {
                text.Font = new System.Drawing.Font("Roboto", 14f, FontStyle.Regular);
            }

        }

        public void saveReportdata()
        {
            DataAccess save = new DataAccess();
            string cid = caseid;
            if (PRO == "BRONCO")
            {
                if (save.checkRowExist(cid, "broncoreport") != true)
                {
                    save.addReportKey(cid, "caseid", "broncoreport");
                }
            }
            else
            {
                if (Multimode)
                {
                    cid = caseid + PRO;


                }

                if (save.checkRowExist(cid, "report") != true)
                {
                    save.addReportKey(cid, "caseid", "report");

                }

            }
        }
        /*
        public static void QuickSave()
        {
            if (SaveMultimode)
            {
                Savecid = Savecid + SavePRO;

                manageReportERCP newreport3 = new manageReportERCP();
                manageReportCOL newreport2 = new manageReportCOL();
                manageReportEGD newreport = new manageReportEGD();

                System.Windows.Forms.MessageBox.Show("SaveData before switch" + ALL_PRO);

                switch (ALL_PRO)
                {
                    case "EGD/Colono":
                        newreport2.saveReportField(RC, ReportMulti.reportBid, ReportMulti.reportB);
                        newreport.saveReportField(RE, ReportMulti.reportAid, ReportMulti.reportA);
                        // System.Windows.Forms.MessageBox.Show("EGD/Colono");

                        break;
                    case "EGD/ERCP":
                        newreport3.saveReportField(RCP, ReportMulti.reportCid, ReportMulti.reportC);

                        newreport.saveReportField(RE, ReportMulti.reportAid, ReportMulti.reportA);
                        // System.Windows.Forms.MessageBox.Show("EGD/ENT");

                        break;
                    case "Colono/ERCP":
                        newreport3.saveReportField(RCP, ReportMulti.reportCid, ReportMulti.reportC);
                        newreport2.saveReportField(RC, ReportMulti.reportBid, ReportMulti.reportB);
                        // System.Windows.Forms.MessageBox.Show("EGD/Colono");

                        break;
                    case "EGD/Colono/ERCP":

                        break;

                }




            }
            else
            {



                switch (SavePRO)
                {
                    case "COL":
                        manageReportCOL COLreport = new manageReportCOL();
                        COLreport.saveEditField(Savereport2, Savecid, Saveinfo);
                        break;
                    case "EGD":
                        manageReportEGD EGDreport = new manageReportEGD();
                        EGDreport.saveEditField(Savereport, Savecid, Saveinfo);
                        break;
                    case "ERCP":
                        manageReportERCP ERCPreport = new manageReportERCP();
                        ERCPreport.saveEditField(Savereport3, Savecid, Saveinfo);
                        break;
                    case "BRONCO":

                        break;
                }




            }


        }

*/

        public static void savedata()
        {

            if (SavePRO == "BRONCO")
            {

                manageReportBRONCO newreport = new manageReportBRONCO();
                newreport.saveReportField(Savereport4, Savecid, Saveinfo);
                newreport.savepicture(SaveBRONCOControl, Savecid);

            }
            else
            {
                Thread thread = new Thread(() =>
                {


                    if (SaveMultimode)
                    {
                        Savecid = Savecid + SavePRO;

                        manageReportERCP newreport3 = new manageReportERCP();
                        manageReportCOL newreport2 = new manageReportCOL();
                        manageReportEGD newreport = new manageReportEGD();

                        switch (ALL_PRO)
                        {
                            case "EGD/Colono":
                                if (FOLDER_EXIST("COL"))
                                {
                                    newreport2.saveReportField(RC, ReportMulti.reportBid, ReportMulti.reportB);
                                    newreport2.savepicture(RCIMG, ReportMulti.reportBid);
                                }
                                if (FOLDER_EXIST("EGD"))
                                {
                                    newreport.saveReportField(RE, ReportMulti.reportAid, ReportMulti.reportA);
                                    newreport.savepicture(REIMG, ReportMulti.reportAid);
                                }

                                break;
                            case "EGD/ERCP":


                                if (FOLDER_EXIST("ERCP"))
                                {
                                    newreport3.saveReportField(RCP, ReportMulti.reportCid, ReportMulti.reportC);
                                    newreport3.savepicture(RCPIMG, ReportMulti.reportCid);
                                }
                                if (FOLDER_EXIST("EGD"))
                                {
                                    newreport.saveReportField(RE, ReportMulti.reportAid, ReportMulti.reportA);
                                    newreport.savepicture(REIMG, ReportMulti.reportAid);
                                }
                                break;
                            case "Colono/ERCP":
                                if (FOLDER_EXIST("ERCP"))
                                {
                                    newreport3.saveReportField(RCP, ReportMulti.reportCid, ReportMulti.reportC);
                                    newreport3.savepicture(RCPIMG, ReportMulti.reportCid);
                                }

                                if (FOLDER_EXIST("COL"))
                                {
                                    newreport2.saveReportField(RC, ReportMulti.reportBid, ReportMulti.reportB);
                                    newreport2.savepicture(RCIMG, ReportMulti.reportBid);
                                }
                                break;
                            case "EGD/Colono/ERCP":
                                if (FOLDER_EXIST("ERCP"))
                                {
                                    newreport3.saveReportField(RCP, ReportMulti.reportCid, ReportMulti.reportC);
                                    newreport3.savepicture(RCPIMG, ReportMulti.reportCid);
                                }
                                if (FOLDER_EXIST("COL"))
                                {
                                    newreport2.saveReportField(RC, ReportMulti.reportBid, ReportMulti.reportB);
                                    newreport2.savepicture(RCIMG, ReportMulti.reportBid);
                                }
                                if (FOLDER_EXIST("EGD"))
                                {
                                    newreport.saveReportField(RE, ReportMulti.reportAid, ReportMulti.reportA);
                                    newreport.savepicture(REIMG, ReportMulti.reportAid);
                                }
                                break;

                        }
                    }
                    else
                    {
                        // MessageBox.Show(SavePRO);
                        if (SavePRO == "COL")
                        {

                            manageReportCOL newreport = new manageReportCOL();
                            newreport.saveReportField(Savereport2, Savecid, Saveinfo);
                            newreport.savepicture(SaveCOLControl, Savecid);

                        }
                        else
                        {
                            if (SavePRO == "EGD")
                            {


                                manageReportEGD newreport = new manageReportEGD();
                                newreport.saveReportField(Savereport, Savecid, Saveinfo);
                                newreport.savepicture(SaveEGDControl, Savecid);
                            }
                            else
                            {
                                if (SavePRO == "ERCP")
                                {


                                    manageReportERCP newreport = new manageReportERCP();
                                    newreport.saveReportField(Savereport3, Savecid, Saveinfo);
                                    newreport.savepicture(SaveERCPControl, Savecid);
                                }
                                else
                                {
                                    if (SavePRO == "ENT")
                                    {
                                        manageReportENT newreport = new manageReportENT();
                                        newreport.saveReportField(Savereport5, Savecid, Saveinfo);
                                        newreport.savepicture(SaveENTControl, Savecid);

                                    }
                                }
                            }
                        }
                    }

                });
                thread.Start();
            }
            LOADING_SCREEN();

        }

        public static void savedataExit()
        {
            try
            {
                //  Thread thread = new Thread(() =>
                //  {


                if (SaveMultimode)
                {
                    Savecid = Savecid + SavePRO;

                    manageReportERCP newreport3 = new manageReportERCP();
                    manageReportCOL newreport2 = new manageReportCOL();
                    manageReportEGD newreport = new manageReportEGD();


                    switch (ALL_PRO)
                    {
                        case "EGD/Colono":
                            if (FOLDER_EXIST("COL"))
                            {
                                newreport2.saveReportField(RC, ReportMulti.reportBid, ReportMulti.reportB);
                                newreport2.savepicture(RCIMG, ReportMulti.reportBid);
                            }
                            if (FOLDER_EXIST("EGD"))
                            {
                                newreport.saveReportField(RE, ReportMulti.reportAid, ReportMulti.reportA);
                                newreport.savepicture(REIMG, ReportMulti.reportAid);
                            }

                            break;
                        case "EGD/ERCP":


                            if (FOLDER_EXIST("ERCP"))
                            {
                                newreport3.saveReportField(RCP, ReportMulti.reportCid, ReportMulti.reportC);
                                newreport3.savepicture(RCPIMG, ReportMulti.reportCid);
                            }
                            if (FOLDER_EXIST("EGD"))
                            {
                                newreport.saveReportField(RE, ReportMulti.reportAid, ReportMulti.reportA);
                                newreport.savepicture(REIMG, ReportMulti.reportAid);
                            }
                            break;
                        case "Colono/ERCP":
                            if (FOLDER_EXIST("ERCP"))
                            {
                                newreport3.saveReportField(RCP, ReportMulti.reportCid, ReportMulti.reportC);
                                newreport3.savepicture(RCPIMG, ReportMulti.reportCid);
                            }

                            if (FOLDER_EXIST("COL"))
                            {
                                newreport2.saveReportField(RC, ReportMulti.reportBid, ReportMulti.reportB);
                                newreport2.savepicture(RCIMG, ReportMulti.reportBid);
                            }
                            break;
                        case "EGD/Colono/ERCP":
                            if (FOLDER_EXIST("ERCP"))
                            {
                                newreport3.saveReportField(RCP, ReportMulti.reportCid, ReportMulti.reportC);
                                newreport3.savepicture(RCPIMG, ReportMulti.reportCid);
                            }
                            if (FOLDER_EXIST("COL"))
                            {
                                newreport2.saveReportField(RC, ReportMulti.reportBid, ReportMulti.reportB);
                                newreport2.savepicture(RCIMG, ReportMulti.reportBid);
                            }
                            if (FOLDER_EXIST("EGD"))
                            {
                                newreport.saveReportField(RE, ReportMulti.reportAid, ReportMulti.reportA);
                                newreport.savepicture(REIMG, ReportMulti.reportAid);
                            }
                            break;

                    }
                }
                else
                {
                    // MessageBox.Show(SavePRO);
                    if (SavePRO == "COL")
                    {

                        manageReportCOL newreport = new manageReportCOL();
                        newreport.saveReportField(Savereport2, Savecid, Saveinfo);
                        newreport.savepicture(SaveCOLControl, Savecid);

                    }
                    else
                    {
                        if (SavePRO == "EGD")
                        {


                            manageReportEGD newreport = new manageReportEGD();
                            newreport.saveReportField(Savereport, Savecid, Saveinfo);
                            newreport.savepicture(SaveEGDControl, Savecid);
                        }
                        else
                        {
                            if (SavePRO == "ERCP")
                            {


                                manageReportERCP newreport = new manageReportERCP();
                                newreport.saveReportField(Savereport3, Savecid, Saveinfo);
                                newreport.savepicture(SaveENTControl, Savecid);
                            }
                            else
                            {
                                if (SavePRO == "BRONCO")
                                {
                                    manageReportBRONCO newreport = new manageReportBRONCO();
                                    newreport.saveReportField(Savereport4, Savecid, Saveinfo);
                                    newreport.savepicture(SaveBRONCOControl, Savecid);


                                }
                                else
                                {
                                    if (SavePRO == "ENT")
                                    {
                                        manageReportENT newreport = new manageReportENT();
                                        newreport.saveReportField(Savereport5, Savecid, Saveinfo);
                                        newreport.savepicture(SaveENTControl, Savecid);


                                    }
                                }
                            }
                        }
                    }
                }

                //  });
                //  thread.Start();
                LOADING_SCREEN();
                // thread.Join();
            }
            catch { }
        }


        bool page2 = false;
        bool page3 = false;
        bool page4 = false;
        bool page5 = false;
        bool page6 = false;



        public bool checkDBExist(string thishn)
        {
            MySqlDataReader checkreader;

            MySqlConnection Checkcon = new MySqlConnection(dbhelper.CnnVal("db"));
            Checkcon.Open();
            MySqlCommand CheckCommand = new MySqlCommand("select * from patientcase where caseid='" + thishn + "'", Checkcon);
            bool a = true;

            checkreader = CheckCommand.ExecuteReader();

            while (checkreader.Read())
            {
                if (checkreader.HasRows == true)
                {

                    a = false;
                }

            }
            checkreader.Close();
            return a;

        }
        string ORIGINAL_ID;

        private void OPEN_FOLDER_Click(object sender, EventArgs e)
        {
            ORIGINAL_ID = caseid;

            if (caseid.Contains(PRO))
            {
                ORIGINAL_ID = caseid.Replace(PRO, null);
            }



            Process.Start(imgFolder);
        }
        public string cutEnter(string b)
        {

            if (b.Contains("\r\n"))
            {
                b = b.Replace("\r\n", " ");

            }
            return b;
        }

        private static bool m_bLayoutCalled = false;
        private static DateTime m_dt;

        public static void LOADING_SCREEN()
        {
            SplashScreen.ShowSplashScreen();
            Application.DoEvents();

            SplashScreen.SetStatus("Loading module 1");
            System.Threading.Thread.Sleep(500);
            /*
            SplashScreen.SetStatus("Loading module 2");
            System.Threading.Thread.Sleep(300);
            SplashScreen.SetStatus("Loading module 3");
            System.Threading.Thread.Sleep(900);
            SplashScreen.SetStatus("Loading module 4");
            System.Threading.Thread.Sleep(100);
            SplashScreen.SetStatus("Loading module 5");
            System.Threading.Thread.Sleep(400);
            SplashScreen.SetStatus("Loading module 6");
            System.Threading.Thread.Sleep(50);
            SplashScreen.SetStatus("Loading module 7");
            System.Threading.Thread.Sleep(240);
            SplashScreen.SetStatus("Loading module 8");
            System.Threading.Thread.Sleep(900);
            SplashScreen.SetStatus("Loading module 9");
            System.Threading.Thread.Sleep(240);
            SplashScreen.SetStatus("Loading module 10");
            System.Threading.Thread.Sleep(90);
            SplashScreen.SetStatus("Loading module 11");
            System.Threading.Thread.Sleep(1000);
            SplashScreen.SetStatus("Loading module 12");
            System.Threading.Thread.Sleep(100);
            SplashScreen.SetStatus("Loading module 13");
            System.Threading.Thread.Sleep(500);
            SplashScreen.SetStatus("Loading module 14", false);
            System.Threading.Thread.Sleep(1000);
            SplashScreen.SetStatus("Loading module 14a", false);
            System.Threading.Thread.Sleep(1000);
            SplashScreen.SetStatus("Loading module 14b", false);
            System.Threading.Thread.Sleep(1000);
            SplashScreen.SetStatus("Loading module 14c", false);
            System.Threading.Thread.Sleep(1000);
            SplashScreen.SetStatus("Loading module 15");
            System.Threading.Thread.Sleep(20);
            SplashScreen.SetStatus("Loading module 16");
            System.Threading.Thread.Sleep(450);
            SplashScreen.SetStatus("Loading module 17");
            System.Threading.Thread.Sleep(240);
            SplashScreen.SetStatus("Loading module 18");
            System.Threading.Thread.Sleep(90);
           */
            m_bLayoutCalled = true;
            m_dt = DateTime.Now;
            SplashScreen.CloseForm();
        }
        bool EDIT_ISnotPRESS = true;
        private void Edit_Click(object sender, EventArgs e)
        {
            setEDIT(infohn, EDIT_ISnotPRESS);
            //setEDIT(infoname, EDIT_ISnotPRESS);

            //setEDIT(infosex, EDIT_ISnotPRESS);
            //setEDIT(infoage, EDIT_ISnotPRESS);
            //setEDIT(nation, EDIT_ISnotPRESS);
            //setEDIT(infoward, EDIT_ISnotPRESS);
            //setEDIT(inforegis, EDIT_ISnotPRESS);
            //setEDIT(indication, EDIT_ISnotPRESS);
            //setEDIT(infoproroom, EDIT_ISnotPRESS);
            //setEDIT(pdx1, EDIT_ISnotPRESS);
            //setEDIT(pdx2, EDIT_ISnotPRESS);
            //setEDIT(pdx3, EDIT_ISnotPRESS);
            //setEDIT(pdx4, EDIT_ISnotPRESS);
            //setEDIT(Duration, EDIT_ISnotPRESS);

            //setEDIT(infoinstrument, EDIT_ISnotPRESS);
            //setEDIT(in2, EDIT_ISnotPRESS);

            //setEDIT(infodoc, EDIT_ISnotPRESS);
            //setEDIT(infoass, EDIT_ISnotPRESS);
            //setEDIT(infocnurse, EDIT_ISnotPRESS);
            //setEDIT(infosnurse, EDIT_ISnotPRESS);
            //setEDIT(anes, EDIT_ISnotPRESS);
            if (EDIT_ISnotPRESS)
            { EDIT_ISnotPRESS = false; }
            else
            {
                EDIT_ISnotPRESS = true;

            }

        }
        public void setEDIT(TextBox a, bool press)
        {
            if (press)
            {
                a.BorderStyle = BorderStyle.Fixed3D;

                a.ReadOnly = false;
            }
            else
            {
                a.BorderStyle = BorderStyle.None;


                a.ReadOnly = true;

            }

        }

        private void preReportButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Start top
                DataAccess Load = new DataAccess();
                string reportType = Load.getOption("option_value", "reportType");

                if (reportType == "1")
                {
                    DataAccess cb = new DataAccess();
                    cb.updateDoneStatus(caseid);
                    switch (PRO)
                    {
                        case "EGD":
                            PdfEGD egd = new PdfEGD(EGDControl);
                            egd.GEN_PdfEGD(PRO, EGDControl, this, report, ORIGINAL_ID, Multimode);
                            break;
                        case "COL":
                            PdfColono col = new PdfColono(COLControl);
                            col.GEN_PdfCOL(PRO, COLControl, this, report2, ORIGINAL_ID, Multimode);
                            break;

                        case "ERCP":
                            PdfERCP ERCP = new PdfERCP(ERCPControl);
                            ERCP.GEN_PdfEGD(PRO, ERCPControl, this, report3, ORIGINAL_ID, Multimode);
                            break;
                        case "ENT":
                            PdfENT ENT = new PdfENT(ENTControl);
                            ENT.GEN_PdfEGD(PRO, ENTControl, this, report5, ORIGINAL_ID, Multimode);
                            break;
                        case "BRONCO":
                            PdfBronco bronco = new PdfBronco(BRONCOControl);
                            bronco.GEN_PdfEGD(PRO, BRONCOControl, this, report4, ORIGINAL_ID, Multimode);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    DataAccess cb = new DataAccess();
                    cb.updateDoneStatus(caseid);
                    switch (PRO)
                    {
                        case "EGD":
                            PdfEGD_TemplateB egd = new PdfEGD_TemplateB(EGDControl);
                            egd.GEN_PdfEGD(PRO, EGDControl, this, report, ORIGINAL_ID, Multimode);
                            break;

                        case "COL":

                            PdfColono_TemplateB col = new PdfColono_TemplateB(COLControl);
                            col.GEN_PdfCOL(PRO, COLControl, this, report2, ORIGINAL_ID, Multimode);
                            break;

                        case "ERCP":

                            PdfERCP_TemplateB ERCP = new PdfERCP_TemplateB(ERCPControl);
                            ERCP.GEN_PdfEGD(PRO, ERCPControl, this, report3, ORIGINAL_ID, Multimode);
                            break;
                        case "ENT":

                            PdfENT_TemplateB ENT = new PdfENT_TemplateB(ENTControl);
                            ENT.GEN_PdfEGD(PRO, ENTControl, this, report5, ORIGINAL_ID, Multimode);
                            break;
                        case "BRONCO":
                            PdfBroco_TemplateB bronco = new PdfBroco_TemplateB(BRONCOControl);
                            bronco.GEN_PdfEGD(PRO, BRONCOControl, this, report4, ORIGINAL_ID, Multimode);
                            break;

                        default:
                            break;
                    }
                }

                //End top
                /*
                DataAccess cb = new DataAccess();
                cb.updateDoneStatus(caseid);
                switch (PRO)
                {
                    case "EGD":
                        PdfEGD egd = new PdfEGD(EGDControl);
                        egd.GEN_PdfEGD(PRO, EGDControl, this, report, ORIGINAL_ID, Multimode);
                        ////break;
                        //PdfBronco egd = new PdfBronco(EGDControl);
                        //egd.GEN_PdfEGD(PRO, EGDControl, this, report, ORIGINAL_ID, Multimode);
                        break;

                    case "COL":
                        PdfCOL col = new PdfCOL(COLControl);
                        col.GEN_PdfCOL(PRO, COLControl, this, report2, ORIGINAL_ID, Multimode);
                        break;

                    case "ERCP":
                        PdfERCP ENT = new PdfERCP(ENTControl);
                        ENT.GEN_PdfEGD(PRO, ENTControl, this, report3, ORIGINAL_ID, Multimode);
                        //PdfCysto ENT = new PdfCysto(ENTControl);
                        //ENT.GEN_PdfEGD(PRO, ENTControl, this, report3, ORIGINAL_ID, Multimode);
                        break;
                    case "BRONCO":
                        PdfBronco bronco = new PdfBronco(BRONCOControl);
                        bronco.GEN_PdfEGD(PRO, BRONCOControl, this, report4, ORIGINAL_ID, Multimode);
                        break;
                    default:
                        break;
                }
                */
            }
            catch
            {
                MessageBox.Show("can't gen report due to some problem. try remove some picture and try again ");
            }
        }

        public void LOAD_DATA(string procedure, string caseID)
        {
            switch (procedure)
            {
                case "EGD":
                    manageReportEGD EGD_REPORT = new manageReportEGD();
                    EGD_REPORT.LoadReportField(report, caseID, this);
                    EGD_REPORT.Loadpicture(this, EGDControl, caseID);
                    break;
                case "COL":
                    manageReportCOL COL_REPORT = new manageReportCOL();
                    COL_REPORT.LoadReportField(report2, caseID, this);
                    COL_REPORT.Loadpicture(this, COLControl, caseID);
                    break;
                case "ERCP":
                    manageReportERCP ERCP_REPORT = new manageReportERCP();
                    ERCP_REPORT.LoadReportField(report3, caseID, this);
                    ERCP_REPORT.Loadpicture(this, ERCPControl, caseID);
                    break;
                case "ENT":
                    manageReportENT ENT_REPORT = new manageReportENT();
                    ENT_REPORT.LoadReportField(report5, caseID, this);
                    ENT_REPORT.Loadpicture(this, ENTControl, caseID);
                    break;
                case "BRONCO":
                    manageReportBRONCO BRONCO_REPORT = new manageReportBRONCO();
                    BRONCO_REPORT.LoadReportField(report4, caseID, this);
                    BRONCO_REPORT.Loadpicture(this, BRONCOControl, caseID);
                    break;
                default:
                    break;
            }
        }

        private void userPanel_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
            {
                userPanel.VerticalScroll.Value = e.NewValue;
            }
        }

        private void EditSex_Click(object sender, EventArgs e)
        {
            setEDIT(infosex, EDIT_ISnotPRESS);

            if (EDIT_ISnotPRESS)
            { EDIT_ISnotPRESS = false; }
            else { EDIT_ISnotPRESS = true; }

        }

        private void EditDate_Click(object sender, EventArgs e)
        {

            setEDIT(inforegis, EDIT_ISnotPRESS);

            if (EDIT_ISnotPRESS)
            { EDIT_ISnotPRESS = false; }
            else
            {
                EDIT_ISnotPRESS = true; DataAccess a = new DataAccess();
                a.EditData(caseid, "Date", inforegis.Text);
            }
        }

        private void EditIndi_Click(object sender, EventArgs e)
        {

            setEDIT(indication, EDIT_ISnotPRESS);

            if (EDIT_ISnotPRESS)
            { EDIT_ISnotPRESS = false; }
            else
            {
                EDIT_ISnotPRESS = true; DataAccess a = new DataAccess();
                a.EditData(caseid, "Indication", indication.Text);
            }
        }

        private void EditDuration_Click(object sender, EventArgs e)
        {

            setEDIT(Duration, EDIT_ISnotPRESS);


            if (EDIT_ISnotPRESS)
            { EDIT_ISnotPRESS = false; }
            else
            {
                EDIT_ISnotPRESS = true; DataAccess a = new DataAccess();
                a.EditData(caseid, "Duration", Duration.Text);

            }
        }

        private void EditName_Click(object sender, EventArgs e)
        {
            setEDIT(infoname, EDIT_ISnotPRESS);

            if (EDIT_ISnotPRESS)
            { EDIT_ISnotPRESS = false; }
            else
            {
                EDIT_ISnotPRESS = true;
                DataAccess a = new DataAccess();
                a.EditData(caseid, "Patient Name", infoname.Text);
            }

        }

        private void EditNation_Click(object sender, EventArgs e)
        {

            setEDIT(nation, EDIT_ISnotPRESS);

            if (EDIT_ISnotPRESS)
            { EDIT_ISnotPRESS = false; }
            else { EDIT_ISnotPRESS = true; }
        }

        private void EditPreDX_Click(object sender, EventArgs e)
        {

            setEDIT(pdx1, EDIT_ISnotPRESS);
            setEDIT(pdx2, EDIT_ISnotPRESS);
            setEDIT(pdx3, EDIT_ISnotPRESS);
            setEDIT(pdx4, EDIT_ISnotPRESS);

            if (EDIT_ISnotPRESS)
            { EDIT_ISnotPRESS = false; }
            else
            {
                EDIT_ISnotPRESS = true; DataAccess a = new DataAccess();
                a.EditData(caseid, "PreDX1", pdx1.Text);
                a.EditData(caseid, "PreDX2", pdx2.Text);
                a.EditData(caseid, "PreDX3", pdx3.Text);
                a.EditData(caseid, "PreDX4", pdx4.Text);
            }
        }

        private void EditAge_Click(object sender, EventArgs e)
        {


            setEDIT(infoage, EDIT_ISnotPRESS);

            if (EDIT_ISnotPRESS)
            { EDIT_ISnotPRESS = false; }
            else { EDIT_ISnotPRESS = true; }

        }

        private void EditWard_Click(object sender, EventArgs e)
        {

            setEDIT(infoward, EDIT_ISnotPRESS);

            if (EDIT_ISnotPRESS)
            { EDIT_ISnotPRESS = false; }
            else { EDIT_ISnotPRESS = true; }
        }

        private void EditRoom_Click(object sender, EventArgs e)
        {

            setEDIT(infoproroom, EDIT_ISnotPRESS);

            if (EDIT_ISnotPRESS)
            { EDIT_ISnotPRESS = false; }
            else
            {
                EDIT_ISnotPRESS = true; DataAccess a = new DataAccess();
                a.EditData(caseid, "Procedure Room", infoproroom.Text);
            }
        }

        private void EditIn_Click(object sender, EventArgs e)
        {

            setEDIT(infoinstrument, EDIT_ISnotPRESS);
            setEDIT(in2, EDIT_ISnotPRESS);
            //  setEDIT(in3, EDIT_ISnotPRESS);



            ;
            if (EDIT_ISnotPRESS)
            {
                EDIT_ISnotPRESS = false;
                cbtn1.Visible = true;
                cbtn2.Visible = true;
                // cbtn3.Visible = true;
            }
            else
            {
                EDIT_ISnotPRESS = true;
                cbtn1.Visible = false;
                cbtn2.Visible = false;
                // cbtn3.Visible = false;

                DataAccess a = new DataAccess();
                string t = infoinstrument.Text;


                if (in2.Text != "") { t = infoinstrument.Text + "$" + in2.Text; }

                a.EditData(caseid, "Instruments", t);
            }
        }

        private void EditDoc_Click(object sender, EventArgs e)
        {

            setEDIT(infodoc, EDIT_ISnotPRESS);

            if (EDIT_ISnotPRESS)
            { EDIT_ISnotPRESS = false; }
            else
            {
                EDIT_ISnotPRESS = true; DataAccess a = new DataAccess();
                a.EditData(caseid, "Doctor", infodoc.Text);
            }
        }

        private void EditAss_Click(object sender, EventArgs e)
        {

            setEDIT(infoass, EDIT_ISnotPRESS);

            if (EDIT_ISnotPRESS)
            { EDIT_ISnotPRESS = false; }
            else
            {
                EDIT_ISnotPRESS = true; DataAccess a = new DataAccess();
                a.EditData(caseid, "Doctor 2", infoass.Text);
            }
        }

        private void EditAnes_Click(object sender, EventArgs e)
        {

            setEDIT(anes, EDIT_ISnotPRESS);
            if (EDIT_ISnotPRESS)
            { EDIT_ISnotPRESS = false; }
            else
            {
                EDIT_ISnotPRESS = true; DataAccess a = new DataAccess();
                a.EditData(caseid, "Anesthesist", anes.Text);
            }
        }

        private void EditCnurse_Click(object sender, EventArgs e)
        {

            setEDIT(infocnurse, EDIT_ISnotPRESS);

            if (EDIT_ISnotPRESS)
            { EDIT_ISnotPRESS = false; }
            else
            {
                EDIT_ISnotPRESS = true; DataAccess a = new DataAccess();
                a.EditData(caseid, "Circulating Nurse", infocnurse.Text);
            }
        }



        private void EditSnurse_Click(object sender, EventArgs e)
        {

            setEDIT(infosnurse, EDIT_ISnotPRESS);

            if (EDIT_ISnotPRESS)
            { EDIT_ISnotPRESS = false; }
            else
            {
                EDIT_ISnotPRESS = true; DataAccess a = new DataAccess();
                a.EditData(caseid, "Scrub Nurse", infosnurse.Text);
            }
        }
        string cameraid;
        private string getcameraData()
        {
            using (Instrument formOptions = new Instrument())
            {
                formOptions.ShowDialog();

                string result = formOptions.GetMyResult();
                cameraid = formOptions.GetMyResultID();
                return result;

            }

        }
        private void cbtn3_Click(object sender, EventArgs e)
        {
            string camera = getcameraData();
            in3.Text = cameraid + "-" + camera;
        }

        private void cbtn2_Click(object sender, EventArgs e)
        {
            string camera = getcameraData();
            in2.Text = cameraid + "-" + camera;
        }

        private void cbtn1_Click(object sender, EventArgs e)
        {
            string camera = getcameraData();
            infoinstrument.Text = cameraid + "-" + camera;
        }
        static string imgFolderS;

        static public bool FOLDER_EXIST(string a)
        {
            bool IS_EXIST = true;
            imgFolderS = IDMS.World.Settings.savePath + "/images/" + ReportMulti.REALID + "/" + a + "/";

            string imgFolder_oldversion = IDMS.World.Settings.savePath + "/" + ReportMulti.REALID + "/pictures/" + a + "/";
            //  string imgFolder_oldversion = IDMS.World.Settings.savePath + "/" + HN + "/" + PROCEDURE + "/pictures/";
            imgFolder_oldversion = imgFolder_oldversion.Replace("idmsCASE", "idmsData");

            //   MessageBox.Show(imgFolderS);
            //  MessageBox.Show(imgFolder_oldversion);




            if (!(Directory.Exists(imgFolderS)) && !(Directory.Exists(imgFolder_oldversion)))
            {

                IS_EXIST = false;
            }
            return IS_EXIST;
        }

        private void import_btn_Click(object sender, EventArgs e)
        {
            using (import formOptions = new import(imgFolder, PRO))
            {
                formOptions.ShowDialog();
            }
            // MessageBox.Show(imagelistTable.RowCount.ToString());
            CLEAR_IMAGE();
            clearRecImage();
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



        public void autoDirectoryImage()
        {
            // if (imgPath.Length <= 0)
            // {
            if (IDMS.World.Settings.savePath == String.Empty)
            {
                IDMS.World.Settings.savePath = System.IO.Directory.GetCurrentDirectory();
            }
            string hnID = specialCharReplace(caseid);
            if (!Directory.Exists(IDMS.World.Settings.savePath + "\\images\\" + hnID))
                Directory.CreateDirectory(IDMS.World.Settings.savePath + "\\images\\" + hnID + "\\");


            string current_fullpath = String.Format("{0}\\images\\{1}", IDMS.World.Settings.savePath, hnID);
            if (!Directory.Exists(current_fullpath))
                Directory.CreateDirectory(current_fullpath);

            string current_fullpath_img = String.Format("{0}\\" + hnID + "\\" + PRO + "\\", current_fullpath);
            if (!Directory.Exists(current_fullpath + "\\" + PRO + "\\"))
                Directory.CreateDirectory(current_fullpath + "\\" + PRO + "\\");



        }

    }
}
