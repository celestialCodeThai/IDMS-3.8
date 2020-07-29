using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDMS.Popup
{
    public partial class ConfirnClearData : Form
    {
        public ConfirnClearData()
        {
            InitializeComponent();
        }

        bool isClear = false;

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (passwordValue.Text == "delete3000")
            {
                isClear = true;
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        public bool GetMyResult()
        {
            return isClear;
        }
    }
}
