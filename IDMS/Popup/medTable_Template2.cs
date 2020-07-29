using IDMS.DataManage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDMS.Popup

{
    public partial class medTable_Template2 : Form
    {
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private SQLiteDataReader reader;

        public medTable_Template2()
        {
            InitializeComponent();

            string query = "SELECT * FROM NewICD10";

            sql_con = new SQLiteConnection(dbhelper.CnnVal("dbl"));
            sql_con.Open();
            sql_cmd = new SQLiteCommand(query, sql_con);
            reader = sql_cmd.ExecuteReader();

            DB = new SQLiteDataAdapter(query, sql_con);
            DataSet ds = new DataSet();
            DB.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 400;
            dataGridView1.Columns[2].Width = 400;

            reader.Close();
            sql_con.Close();
            sql_con.Dispose();
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

        private void searchtextBox_TextChanged(object sender, EventArgs e)
        {
            if (searchtextBox.Text.Contains("'")) { return; }

            string query = "SELECT * FROM NewICD10 WHERE Code LIKE '" + searchtextBox.Text.ToUpper() + "%' OR ICD10 LIKE '" +
                searchtextBox.Text.ToUpper() + "%' OR Common LIKE '" +
                searchtextBox.Text.ToUpper() + "%' ";

            sql_con = new SQLiteConnection(dbhelper.CnnVal("dbl"));
            sql_con.Open();
            sql_cmd = new SQLiteCommand(query, sql_con);
            reader = sql_cmd.ExecuteReader();

            DB = new SQLiteDataAdapter(query, sql_con);
            DataSet ds = new DataSet();
            DB.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

            reader.Close();
            sql_con.Close();
            sql_con.Dispose();
        }

        public string GetMyResult()
        {
            return common;
        }

        public string GetMyResultID()
        {
            return id;
        }

        private void medConfirm_Click(object sender, EventArgs e)
        {
            Close();
        }

        string id;
        string common;

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            common = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Close();
        }
    }
}
