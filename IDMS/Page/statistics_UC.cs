using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace IDMS.Page
{
    public partial class statistics_UC : UserControl
    {
        public statistics_UC()
        {
            InitializeComponent();

            chart1.Titles.Add("Total Patients");
            chart1.Series["sPatient"].Points.AddXY("Male", "56");
            chart1.Series["sPatient"].Points.AddXY("Female", "42");

            chart2.Series["age"].Points.AddXY("15-29 yrs", "45");
            chart2.Series["age"].Points.AddXY("30-39 yrs", "63");
            chart2.Series["age"].Points.AddXY("40-49 yrs", "55");
            chart2.Series["age"].Points.AddXY("50-59 yrs", "28");
            chart2.Series["age"].Points.AddXY("60-69 yrs", "81");
            chart2.Series["age"].Points.AddXY(">70 yrs", "75");

        }

      
    }
}
