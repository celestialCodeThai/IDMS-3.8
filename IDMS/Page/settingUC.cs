using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.SqlClient;
using IDMS.DataManage;
using System.IO;
using IDMS.Popup;

namespace IDMS.Page
{
    public partial class settingUC : UserControl
    {
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private SQLiteDataReader reader;
        DataGridViewButtonColumn btnc = new DataGridViewButtonColumn();
        DataGridViewButtonColumn btnc2 = new DataGridViewButtonColumn();
        DataGridViewButtonColumn deleteRoomButton = new DataGridViewButtonColumn();

        DataAccess data = new DataAccess();
        string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
        string path;

        string docDB = "doctor";
        string snurseDB = "nurse";
        string cnurseDB = "nurse";
        string anesDB = "anesthesist";
        string cameraDB = "camera";
        string workingDirectory;
        string projectDirectory;

        public settingUC()
        {
            InitializeComponent();
            btnc.Name = " ";
            btnc.Text = "Delete";
            btnc.UseColumnTextForButtonValue = true;
            btnc.Visible = true;
            btnc.FlatStyle = FlatStyle.Popup;

            btnc2.Name = " ";
            btnc2.Text = "Delete";
            btnc2.UseColumnTextForButtonValue = true;
            btnc2.Visible = true;
            btnc2.FlatStyle = FlatStyle.Popup;

            deleteRoomButton.Name = " ";
            deleteRoomButton.Text = "Delete";
            deleteRoomButton.UseColumnTextForButtonValue = true;
            deleteRoomButton.Visible = true;
            deleteRoomButton.FlatStyle = FlatStyle.Popup;

            dts.AllowUserToAddRows = false;
            cTable.AllowUserToAddRows = false;
            procedureRoomTable.AllowUserToAddRows = false;

            path = (System.IO.Path.GetDirectoryName(executable));

            // This will get the current WORKING directory (i.e. \bin\Debug)
            workingDirectory = Environment.CurrentDirectory;
            // or: Directory.GetCurrentDirectory() gives the same result

            // This will get the current PROJECT directory
            projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            projectDirectory += "\\Resources\\";

            loadCDataList(cameraDB);
            space.Text = GetFreeSpace();
            DataManage.DataAccess Load = new DataManage.DataAccess();
            ha.Text = Load.getsettingtext("1", "name");
            hb.Text = Load.getsettingtext("1", "line1");
            hc.Text = Load.getsettingtext("1", "line2");


            if (Load.getusbtext("1", "IS_USE") == "1")
            {
                usb.Text = "ON";
                usb.BackColor = Color.Green;

            }
            else
            {
                usb.Text = "OFF";
                usb.BackColor = Color.Red;
            }


            usb_list.DataSource = Environment.GetLogicalDrives();

            usb_path.Text = Load.getusbtext("1", "USB_PATH");

            string previewPopupValue = Load.getOption("option_value", "previewPopup");

            if (previewPopupValue == "1")
            {
                popup.Text = "ON";
                popup.BackColor = Color.Green;
            }
            else
            {
                popup.Text = "OFF";
                popup.BackColor = Color.Red;
            }

            string reportTemplate = Load.getOption("option_value", "reportType");
            switch (reportTemplate)
            {
                case "1":
                    radioButton1.Checked = true;
                    break;
                case "2":
                    radioButton2.Checked = true;
                    break;
                default:
                    radioButton1.Checked = true;
                    break;
            }

            string useCamera = Load.getOption("option_value", "useCamera");
            switch (useCamera)
            {
                case "NORMAL":
                    radioCameraNormal.Checked = true;
                    break;
                case "HD":
                    radioCameraHd.Checked = true;
                    break;
                case "HD+PREVIEW":
                    radioCameraHdMenu.Checked = true;
                    break;
                default:
                    radioCameraNormal.Checked = true;
                    break;
            }

            string headerColor = data.getOption("option_value", "headerColor");
            comboBox_headerColor.Text = headerColor;

            string labelColor = data.getOption("option_value", "labelColor");
            comboBox_labelColor.Text = labelColor;

            string subLabelColor = data.getOption("option_value", "subLabelColor");
            comboBox_subLabelColor.Text = subLabelColor;

            string resultColor = data.getOption("option_value", "resultColor");
            comboBox_resultColor.Text = resultColor;

            string imageTitleColor = data.getOption("option_value", "imageTitleColor");
            comboBox_imageTitleColor.Text = imageTitleColor;

            string imageDetailColor = data.getOption("option_value", "imageDetailColor");
            comboBox_imageDetailColor.Text = imageDetailColor;

            loadProcedureRoom();

        }
        bool docisClick = false;
        bool snisClick = false;
        bool cnisClick = false;
        bool anisClick = false;

        private void docbtn_Click(object sender, EventArgs e)
        {
            if (!docisClick)
            {
                docbtn.BackColor = Color.Red;
                loadDataList(docDB);
                docisClick = true;
                snisClick = false;
                cnisClick = false;
                anisClick = false;

                snursebtn.BackColor = Color.CornflowerBlue;
                cnursebtn.BackColor = Color.CornflowerBlue;
                abtn.BackColor = Color.CornflowerBlue;
            }
            else
            {
                docbtn.BackColor = Color.CornflowerBlue;
                docisClick = false;
            }
        }

        private void loadDocList()
        {
            string query = "select * from doctor";
            sql_con = new SQLiteConnection(dbhelper.CnnVal("setting"));
            sql_con.Open();
            sql_cmd = new SQLiteCommand(query, sql_con);
            reader = sql_cmd.ExecuteReader();
            if (dts.Columns.Count < 1)
            {
                dts.Columns.Add(btnc);
            }
            DB = new SQLiteDataAdapter(query, sql_con);
            DataSet ds = new DataSet();
            DB.Fill(ds);
            dts.DataSource = ds.Tables[0];
            reader.Close();
            sql_con.Close();
            sql_con.Dispose();

            dts.Columns[1].Visible = false;
            dts.Columns[0].Width = dts.Width / 6;
            dts.Columns[1].Width = dts.Width - dts.Columns[0].Width;


        }
        private void loadDataList(string table)
        {
            string query = "select * from " + table;
            sql_con = new SQLiteConnection(dbhelper.CnnVal("setting"));
            sql_con.Open();
            sql_cmd = new SQLiteCommand(query, sql_con);
            reader = sql_cmd.ExecuteReader();
            if (dts.Columns.Count < 1)
            {
                dts.Columns.Add(btnc2);
            }
            DB = new SQLiteDataAdapter(query, sql_con);
            DataSet ds = new DataSet();
            DB.Fill(ds);
            dts.DataSource = ds.Tables[0];
            reader.Close();
            sql_con.Close();
            sql_con.Dispose();

            dts.Columns[1].Visible = false;
            dts.Columns[0].Width = dts.Width / 4;
            dts.Columns[1].Width = dts.Width - dts.Columns[0].Width;

            if (table == "doctor")
            {
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.DisplayMember = "docname";
                comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                comboBox1.AutoCompleteCustomSource = GetAutoSourceCollectionFromTable(ds.Tables[0]);
            }



        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            ADD();
        }

        private void dts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 0)
            {
                DataGridViewRow row = this.dts.Rows[e.RowIndex];
                DialogResult dialogResult = MessageBox.Show("Do you wish to Remove [" + row.Cells[2].Value.ToString() + "]", "Remove Data", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {




                    if (docisClick)
                    {
                        data.removeDoctor(row.Cells[1].Value.ToString());
                        loadDataList(docDB);
                    }
                    if (snisClick)
                    {
                        data.removeSnurse(row.Cells[1].Value.ToString());
                        loadDataList(snurseDB);
                    }
                    if (cnisClick)
                    {
                        data.removeCnurse(row.Cells[1].Value.ToString());
                        loadDataList(cnurseDB);
                    }
                    if (anisClick)
                    {
                        data.removeAnesthesist(row.Cells[1].Value.ToString());
                        loadDataList(anesDB);
                    }
                }
            }
        }

        private void snursebtn_Click(object sender, EventArgs e)
        {

            if (!snisClick)
            {
                snursebtn.BackColor = Color.Red;
                loadDataList(snurseDB);
                snisClick = true;
                docisClick = false;

                cnisClick = false;
                anisClick = false;

                cnursebtn.BackColor = Color.CornflowerBlue;
                docbtn.BackColor = Color.CornflowerBlue;
                abtn.BackColor = Color.CornflowerBlue;
            }
            else
            {
                snursebtn.BackColor = Color.CornflowerBlue;
                snisClick = false;
            }

        }

        private void cnursebtn_Click(object sender, EventArgs e)
        {
            if (!cnisClick)
            {
                cnursebtn.BackColor = Color.Red;
                loadDataList(cnurseDB);
                snisClick = false;
                docisClick = false;

                cnisClick = true;
                anisClick = false;

                snursebtn.BackColor = Color.CornflowerBlue;
                docbtn.BackColor = Color.CornflowerBlue;
                abtn.BackColor = Color.CornflowerBlue;
            }
            else
            {
                cnursebtn.BackColor = Color.CornflowerBlue;
                cnisClick = false;
            }

        }

        private void abtn_Click(object sender, EventArgs e)
        {

            if (!anisClick)
            {
                abtn.BackColor = Color.Red;
                loadDataList(anesDB);
                snisClick = false;
                docisClick = false;

                cnisClick = false;
                anisClick = true;

                snursebtn.BackColor = Color.CornflowerBlue;
                docbtn.BackColor = Color.CornflowerBlue;
                cnursebtn.BackColor = Color.CornflowerBlue;

            }
            else
            {
                abtn.BackColor = Color.CornflowerBlue;
                anisClick = false;


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool isClear = false;
            using (ConfirnClearData formOptions = new ConfirnClearData())
            {
                formOptions.ShowDialog();
                isClear = formOptions.GetMyResult();
            }

            if (isClear)
            {
                DialogResult dialogResult2 = MessageBox.Show("Are you sure ?", "Delete All Data", MessageBoxButtons.YesNo);

                if (dialogResult2 == DialogResult.Yes)
                {
                    DataAccess data = new DataAccess();
                    data.DeleteAll();

                    System.IO.DirectoryInfo di = new DirectoryInfo(IDMS.World.Settings.savePath + "\\images");
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);
                    }

                    System.IO.DirectoryInfo di2 = new DirectoryInfo(IDMS.World.Settings.savePath + "\\vdo");
                    foreach (DirectoryInfo dir in di2.GetDirectories())
                    {
                        dir.Delete(true);
                    }

                    MessageBox.Show("Delete Succeeded");
                    space.Text = GetFreeSpace();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //  MessageBox.Show(projectDirectory);
            var openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            var dialogResult = openFileDialog.ShowDialog();
            if (dialogResult != DialogResult.OK) return;
            Upload(openFileDialog.FileName);
        }
        private void Upload(string fileName)
        {
            MessageBox.Show(fileName);
            var onlyFileName = System.IO.Path.GetFileName(fileName);
            MessageBox.Show(onlyFileName);
            if (File.Exists(projectDirectory + onlyFileName))
            {

                DialogResult dr = MessageBox.Show(onlyFileName + " Already Exist Do you want to Replace it?",
                          "Already Exist", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:

                        break;
                    case DialogResult.No:
                        return;


                }
            }
            try
            {
                System.IO.File.Copy(fileName, projectDirectory + onlyFileName, true);
                DataAccess save = new DataAccess();
                save.settingHeaderImage("1", onlyFileName, "Logo");
            }
            catch (Exception ex)
            {
                // handle other exceptions
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bool isClear = false;
            using (ConfirnClearData formOptions = new ConfirnClearData())
            {
                formOptions.ShowDialog();
                isClear = formOptions.GetMyResult();
            }

            if (isClear)
            {
                string[] filesindirectory = System.IO.Directory.GetDirectories(IDMS.World.Settings.savePath + "\\vdo");
                foreach (string subdir in filesindirectory)
                {
                    string[] filesindirectory_root = System.IO.Directory.GetDirectories(subdir);
                    foreach (string subdir_root in filesindirectory_root)
                    {

                        if (subdir_root.Contains("\\EGD"))
                        {
                            System.IO.DirectoryInfo folderInfo = new System.IO.DirectoryInfo(subdir_root);

                            foreach (System.IO.FileInfo file in folderInfo.GetFiles())
                            {
                                if (file.Extension.Contains("mp4"))
                                {
                                    file.Delete();
                                }
                            }
                        }
                        if (subdir_root.Contains("\\COL"))
                        {
                            System.IO.DirectoryInfo folderInfo = new System.IO.DirectoryInfo(subdir_root);

                            foreach (System.IO.FileInfo file in folderInfo.GetFiles())
                            {
                                if (file.Extension.Contains("mp4"))
                                {
                                    file.Delete();
                                }
                            }
                        }
                        if (subdir_root.Contains("\\ERCP"))
                        {
                            System.IO.DirectoryInfo folderInfo = new System.IO.DirectoryInfo(subdir_root);

                            foreach (System.IO.FileInfo file in folderInfo.GetFiles())
                            {
                                if (file.Extension.Contains("mp4"))
                                {
                                    file.Delete();
                                }
                            }
                        }
                        if (subdir_root.Contains("\\ENT"))
                        {
                            System.IO.DirectoryInfo folderInfo = new System.IO.DirectoryInfo(subdir_root);

                            foreach (System.IO.FileInfo file in folderInfo.GetFiles())
                            {
                                if (file.Extension.Contains("mp4"))
                                {
                                    file.Delete();
                                }
                            }
                        }
                        if (subdir_root.Contains("\\BRONCO"))
                        {
                            System.IO.DirectoryInfo folderInfo = new System.IO.DirectoryInfo(subdir_root);

                            foreach (System.IO.FileInfo file in folderInfo.GetFiles())
                            {
                                if (file.Extension.Contains("mp4"))
                                {
                                    file.Delete();
                                }
                            }
                        }

                    }

                }

                MessageBox.Show("All Video Has Been Delete");
                space.Text = GetFreeSpace();

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string[] filesindirectory = System.IO.Directory.GetDirectories(IDMS.World.Settings.savePath + "\\images");
            foreach (string subdir in filesindirectory)
            {
                string[] filesindirectory_root = System.IO.Directory.GetDirectories(subdir);
                foreach (string subdir_root in filesindirectory_root)
                {

                    if (subdir_root.Contains("\\EGD"))
                    {
                        System.IO.DirectoryInfo folderInfo = new System.IO.DirectoryInfo(subdir_root);

                        foreach (System.IO.FileInfo file in folderInfo.GetFiles())
                        {
                            if (file.Extension.Contains("jpg"))
                            {
                                file.Delete();
                            }
                        }
                    }
                    if (subdir_root.Contains("\\COL"))
                    {
                        System.IO.DirectoryInfo folderInfo = new System.IO.DirectoryInfo(subdir_root);

                        foreach (System.IO.FileInfo file in folderInfo.GetFiles())
                        {
                            if (file.Extension.Contains("jpg"))
                            {
                                file.Delete();
                            }
                        }
                    }
                    if (subdir_root.Contains("\\ERCP"))
                    {
                        System.IO.DirectoryInfo folderInfo = new System.IO.DirectoryInfo(subdir_root);

                        foreach (System.IO.FileInfo file in folderInfo.GetFiles())
                        {
                            if (file.Extension.Contains("jpg"))
                            {
                                file.Delete();
                            }
                        }
                    }
                    if (subdir_root.Contains("\\ENT"))
                    {
                        System.IO.DirectoryInfo folderInfo = new System.IO.DirectoryInfo(subdir_root);

                        foreach (System.IO.FileInfo file in folderInfo.GetFiles())
                        {
                            if (file.Extension.Contains("jpg"))
                            {
                                file.Delete();
                            }
                        }
                    }
                    if (subdir_root.Contains("\\BRONCO"))
                    {
                        System.IO.DirectoryInfo folderInfo = new System.IO.DirectoryInfo(subdir_root);

                        foreach (System.IO.FileInfo file in folderInfo.GetFiles())
                        {
                            if (file.Extension.Contains("jpg"))
                            {
                                file.Delete();
                            }
                        }
                    }



                }

            }

            MessageBox.Show("All Image Has Been Delete");

            space.Text = GetFreeSpace();


        }

        private void txtADD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                ADD();
            }
        }
        private void ADD()
        {
            if (txtADD.Text != "")
            {
                if (docisClick)
                {
                    data.addDoctor(txtADD.Text);
                    loadDataList(docDB);
                }
                if (snisClick)
                {
                    data.addnurse(txtADD.Text);
                    loadDataList(snurseDB);
                }
                if (cnisClick)
                {
                    data.addnurse(txtADD.Text);
                    loadDataList(cnurseDB);
                }
                if (anisClick)
                {
                    data.addAnesthesist(txtADD.Text);
                    loadDataList(anesDB);
                }
                dts.FirstDisplayedScrollingRowIndex = dts.RowCount - 1;

            }

            txtADD.Text = "";

        }

        private AutoCompleteStringCollection GetAutoSourceCollectionFromTable(DataTable table)
        {
            AutoCompleteStringCollection autoSourceCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in table.Rows)
            {
                autoSourceCollection.Add(row[1].ToString()); //assuming required data is in first column
            }

            return autoSourceCollection;
        }


        public string GetFreeSpace()
        {
            var drives = System.IO.DriveInfo.GetDrives();
            string SPACE = "";
            double freeSpace = -1;
            double formatDivideBy = 1;
            foreach (System.IO.DriveInfo info in drives)
            {
                if (info.Name == "C:\\")
                {
                    // SPACE = (info.TotalFreeSpace/ 1024.0).ToString();
                    long freeSpaceNative = info.AvailableFreeSpace;
                    formatDivideBy = Math.Pow(1024, (int)3);

                    freeSpace = freeSpaceNative / formatDivideBy;
                    freeSpace = Math.Round(freeSpace, 2, MidpointRounding.ToEven);

                }
            }
            SPACE = freeSpace.ToString() + " GB available";
            return SPACE;
        }

        private void loadCDataList(string table)
        {
            string query = "select * from " + table;
            sql_con = new SQLiteConnection(dbhelper.CnnVal("setting"));
            sql_con.Open();
            sql_cmd = new SQLiteCommand(query, sql_con);
            reader = sql_cmd.ExecuteReader();
            if (cTable.Columns.Count < 1)
            {
                cTable.Columns.Add(btnc);
            }
            DB = new SQLiteDataAdapter(query, sql_con);
            DataSet ds = new DataSet();
            DB.Fill(ds);
            cTable.DataSource = ds.Tables[0];
            reader.Close();
            sql_con.Close();
            sql_con.Dispose();

            cTable.Columns[1].Visible = false;
            cTable.Columns[0].Width = cTable.Width / 8;
            cTable.Columns[1].Width = cTable.Width - cTable.Columns[0].Width;
            //this.cTable.Font = new Font("Times", 8);
        }

        private void CADD()
        {
            if (BRAND.Text != "" || SN.Text != "" || MODEL.Text != "" || NICKNAME.Text != "")
            {
                data.addcamera(BRAND.Text, SN.Text, MODEL.Text, NICKNAME.Text);
                BRAND.Text = "";
                SN.Text = "";
                MODEL.Text = "";
                NICKNAME.Text = "";
                loadCDataList(cameraDB);

                if (cTable.RowCount > 0)
                {
                    cTable.FirstDisplayedScrollingRowIndex = cTable.RowCount - 1;
                }
            }
        }

        private void ADDC_Click(object sender, EventArgs e)
        {
            CADD();
        }


        private void cTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 0)
            {
                DataGridViewRow row = this.cTable.Rows[e.RowIndex];
                DialogResult dialogResult = MessageBox.Show("Do you wish to Remove [" + row.Cells[2].Value.ToString() + "]", "Remove Data", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {

                    data.removeCamera(row.Cells[1].Value.ToString());
                    loadCDataList(cameraDB);


                }
            }
        }

        private void hbtn_Click(object sender, EventArgs e)
        {
            DataAccess save = new DataAccess();
            save.settingHeader("1", ha.Text, "name");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataAccess save = new DataAccess();
            save.settingHeader("1", hb.Text, "line1");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataAccess save = new DataAccess();
            save.settingHeader("1", hc.Text, "line2");
        }

        private void usb_path_TextChanged(object sender, EventArgs e)
        {

        }

        private void usb_Click(object sender, EventArgs e)
        {
            string a = "0";
            if (usb.Text == "ON")
            {
                usb.Text = "OFF";
                usb.BackColor = Color.Red;
                a = "0";
            }
            else
            {

                usb.Text = "ON";
                usb.BackColor = Color.Green;
                a = "1";
            }

            DataAccess save = new DataAccess();
            save.settingUSB("1", a, "IS_USE");
        }

        //Start top popup button

        private void popup_Click(object sender, EventArgs e)
        {
            string popupValue = "0";
            if (popup.Text == "ON")
            {
                popup.Text = "OFF";
                popup.BackColor = Color.Red;
                popupValue = "0";
            }
            else
            {

                popup.Text = "ON";
                popup.BackColor = Color.Green;
                popupValue = "1";
            }

            DataAccess save = new DataAccess();
            save.updateOption("option_value", "previewPopup", popupValue);
        }

        //End top

        private void button5_Click(object sender, EventArgs e)
        {


            DataAccess save = new DataAccess();
            save.settingUSB("1", usb_path.Text, "USB_PATH");



        }

        private void usb_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            usb_path.Text = usb_list.SelectedItem.ToString();
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void radioButtonReport_CheckedChanged(object sender, EventArgs e)
        {
            bool checkA = radioButton1.Checked;
            bool checkB = radioButton2.Checked;
            DataAccess save = new DataAccess();

            if (checkA)
            {
                save.updateOption("option_value", "reportType", "1");
            }
            if (checkB)
            {
                save.updateOption("option_value", "reportType", "2");
            }
        }

        private void radioButtonUseCamera_CheckedChanged(object sender, EventArgs e)
        {
            bool checkA = radioCameraNormal.Checked;
            bool checkB = radioCameraHd.Checked;
            bool checkC = radioCameraHdMenu.Checked;
            DataAccess save = new DataAccess();
            if (checkA) { save.updateOption("option_value", "useCamera", "NORMAL"); }
            if (checkB) { save.updateOption("option_value", "useCamera", "HD"); }
            if (checkC) { save.updateOption("option_value", "useCamera", "HD+PREVIEW"); }
        }

        private void headerColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = comboBox_headerColor.Text;
            data.updateOption("option_value", "headerColor", value);
        }

        private void labelColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = comboBox_labelColor.Text;
            data.updateOption("option_value", "labelColor", value);
        }

        private void subLabelColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = comboBox_subLabelColor.Text;
            data.updateOption("option_value", "subLabelColor", value);
        }

        private void resultColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = comboBox_resultColor.Text;
            data.updateOption("option_value", "resultColor", value);
        }

        private void imageTitleColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = comboBox_imageTitleColor.Text;
            data.updateOption("option_value", "imageTitleColor", value);
        }

        private void imageDetailColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = comboBox_imageDetailColor.Text;
            data.updateOption("option_value", "imageDetailColor", value);
        }

        private void settingUC_Load(object sender, EventArgs e)
        {

        }

        private void loadProcedureRoom()
        {
            string query = "select * from procedure_room";

            sql_con = new SQLiteConnection(dbhelper.CnnVal("setting"));
            sql_con.Open();
            sql_cmd = new SQLiteCommand(query, sql_con);
            reader = sql_cmd.ExecuteReader();

            if (procedureRoomTable.Columns.Count < 1)
            {
                procedureRoomTable.Columns.Add(deleteRoomButton);
            }

            DB = new SQLiteDataAdapter(query, sql_con);
            DataSet ds = new DataSet();
            DB.Fill(ds);
            procedureRoomTable.DataSource = ds.Tables[0];
            reader.Close();
            sql_con.Close();
            sql_con.Dispose();

            procedureRoomTable.Columns[1].Visible = false;
            procedureRoomTable.Columns[0].Width = 80;
        }

        private void addProcedureRoom()
        {
            if (roomValue.Text != "")
            {
                data.addProcedureRoom(roomValue.Text);
                roomValue.Text = "";
                loadProcedureRoom();

                if (procedureRoomTable.RowCount > 0)
                {
                    procedureRoomTable.FirstDisplayedScrollingRowIndex = procedureRoomTable.RowCount - 1;
                }
            }
        }

        private void addRoom_Click(object sender, EventArgs e)
        {
            addProcedureRoom();
        }

        private void procedureRoomTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 0)
            {
                DataGridViewRow row = procedureRoomTable.Rows[e.RowIndex];
                DialogResult dialogResult = MessageBox.Show("Do you wish to Remove [" + row.Cells[2].Value.ToString() + "]", "Remove Data", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    data.removeProcedureRoom(row.Cells[1].Value.ToString());
                    loadProcedureRoom();
                }
            }
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void cTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
