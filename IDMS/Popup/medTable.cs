using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
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
    public partial class medTable : Form
    {
      
        public bool valueResult;
        String constr;
        String name = "Sheet1";
        public medTable()
        {
            InitializeComponent();
            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
            string FileName = string.Format("{0}Resources\\ICD10.xlsx", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));
             constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                            FileName +
                            ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

            OleDbConnection con = new OleDbConnection(constr);
            OleDbCommand oconn = new OleDbCommand("SELECT * From [" + name + "$]", con);
            con.Open();
            OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
         
            dataGridView1.Columns[0].Width = dataGridView1.Width / 5;
            dataGridView1.Columns[1].Width = dataGridView1.Width / 2;
            dataGridView1.Columns[2].Width = dataGridView1.Width - dataGridView1.Columns[0].Width - dataGridView1.Columns[1].Width;
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
            OleDbConnection con = new OleDbConnection(constr);
            //  OleDbCommand oconn = new OleDbCommand("SELECT * From [" + name + "$] where Common LIKE '" + SN.Text + "%'", con);
            OleDbCommand oconn = new OleDbCommand("SELECT * From [" + name + "$] where UCase([Common]) LIKE '" + searchtextBox.Text.ToUpper() + "%' OR  UCase([Code]) LIKE '" + searchtextBox.Text.ToUpper() + "%' OR  UCase([ICD10]) LIKE '" + searchtextBox.Text.ToUpper() + "%'   ", con);
            con.Open();
            ///F1 As Code, F2 As ICD10, F3 As Common
            OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            //  dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //  dataGridView1.AutoSize = true;
            //  dataGridView1.Auto
            dataGridView1.Columns[0].Width = dataGridView1.Width / 5;
            dataGridView1.Columns[1].Width = dataGridView1.Width / 2;
            dataGridView1.Columns[2].Width = dataGridView1.Width - dataGridView1.Columns[0].Width - dataGridView1.Columns[1].Width;
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
            this.Close();
        }

        string id;
        string common;

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            common = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            this.Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
