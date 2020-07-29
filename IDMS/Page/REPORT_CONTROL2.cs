using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IDMS.ReportContent;

namespace IDMS.Page
{
    public partial class REPORT_CONTROL2 : UserControl
    {
        public REPORT_CONTROL2()
        {
            InitializeComponent();
            reportControlEGD report = new reportControlEGD("dfdff");
            RCONTROL.Controls.Add(report);
            output a = new output();
           P_CONTROL.Controls.Add(a);
        }
    }
}
