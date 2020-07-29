using IDMS.DataManage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDMS.Popup
{
    public partial class Instrument : Form
    {
        public Instrument()
        {
            InitializeComponent();



            loadDataList("camera");










        }
        delegate void DelUserControlMetod(string name);


        private const int HT_CAPTION = 0x2;
        private const int WM_NCLBUTTONDOWN = 0x00A1;
        [DllImport("user32", CharSet = CharSet.Auto)]
        private static extern bool ReleaseCapture();
        [DllImport("user32", CharSet = CharSet.Auto)]
        private static extern int SendMessage(
            IntPtr hwnd,
            int wMsg,
            int wParam,
            int lParam);
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                Rectangle rct = DisplayRectangle;
                if (rct.Contains(e.Location))
                {
                    ReleaseCapture();
                    SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
        }

        string id;
        string common;

        public string GetMyResult()
        {
            return common;
        }
        public string GetMyResultID()
        {
            return id;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count == 0)
                return;

            ListViewItem item = listView2.SelectedItems[0];
            //fill the text boxes
            id = item.Text;
            common = item.SubItems[1].Text;
            // System.Windows.Forms.MessageBox.Show(id+" " +common);
            this.Close();

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private SQLiteDataReader reader;
        private void loadDataList(string table)
        {

            string query = "select * from " + table;
            sql_con = new SQLiteConnection(dbhelper.CnnVal("setting"));
            sql_con.Open();
            sql_cmd = new SQLiteCommand(query, sql_con);
            reader = sql_cmd.ExecuteReader();
          
            DB = new SQLiteDataAdapter(query, sql_con);
            //DataSet ds = new DataSet();
            //DB.Fill(ds);
            DataTable dt = new DataTable();
            DB.Fill(dt);
            reader.Close();
            sql_con.Close();
            sql_con.Dispose();

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                listView2.Items.Add(dt.Rows[i].ItemArray[2].ToString());
                listView2.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                listView2.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());

                if ((dt.Rows[i].ItemArray[1].ToString() == "FUJIFILM"))
                {
                    listView2.Items[i].Group = listView2.Groups[0];
                }
                else
                {
                    if ((dt.Rows[i].ItemArray[1].ToString() == "OLYMPUS"))
                    {
                        listView2.Items[i].Group = listView2.Groups[1];
                    }
                }
            }

            

        }
    }
}
