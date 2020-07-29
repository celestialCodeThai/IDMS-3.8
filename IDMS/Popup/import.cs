using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDMS.Popup
{
    public partial class import : Form
    {
        string CASE_PATH;
        string Pro;
        public import(string PATH,string PRO)
        {
            CASE_PATH = PATH;
            Pro = PRO;
            InitializeComponent();
            Panel.AllowDrop = true;
            Panel.DragEnter += new DragEventHandler(Form1_DragEnter);
            Panel.DragDrop += new DragEventHandler(Form1_DragDrop);
        }
        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (ImageExtensions.Contains(Path.GetExtension(file).ToUpperInvariant()))
                {
                    MessageBox.Show("file is image");
                    fileCount = Directory.GetFiles(CASE_PATH).Length + 1;
                    System.IO.File.Copy(file, CASE_PATH+ (Pro + (fileCount).ToString("D2") + ".jpg"), true);
                }
                else
                {
                    Copy(file.ToString(), CASE_PATH);
                    MessageBox.Show("import complete");
                }
                this.Close();

            }
        }
        public static int fileCount;
        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };
        void CopyImage(string sourceDir, string targetDir)
        {
            try
            {
                Directory.CreateDirectory(targetDir);
                fileCount = Directory.GetFiles(targetDir).Length + 1;
                foreach (var file in Directory.GetFiles(sourceDir))
                {
                    if (ImageExtensions.Contains(Path.GetExtension(file).ToUpperInvariant()))
                    {
                        File.Copy(file, Path.Combine(targetDir, Path.GetFileName(Pro + (fileCount).ToString("D2") + ".jpg")));
                        fileCount++;
                    }
                }
            }
            catch
            {

            }
            //foreach (var directory in Directory.GetDirectories(sourceDir))
            //    Copy(directory, Path.Combine(targetDir, Path.GetFileName(directory)));
        }
        void Copy(string sourceDir, string targetDir)
        {
            try
            {
                Directory.CreateDirectory(targetDir);
                fileCount = Directory.GetFiles(targetDir).Length + 1;
                foreach (var file in Directory.GetFiles(sourceDir))
                {
                    if (ImageExtensions.Contains(Path.GetExtension(file).ToUpperInvariant()))
                    {
                        File.Copy(file, Path.Combine(targetDir, Path.GetFileName(Pro + (fileCount).ToString("D2") + ".jpg")));
                        fileCount++;
                    }
                }
            }catch
            {

            }
            //foreach (var directory in Directory.GetDirectories(sourceDir))
            //    Copy(directory, Path.Combine(targetDir, Path.GetFileName(directory)));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                  

                    Copy(fbd.SelectedPath.ToString(), CASE_PATH);
                }
            }
            MessageBox.Show("import complete");
            this.Close();
        }
    }
}
