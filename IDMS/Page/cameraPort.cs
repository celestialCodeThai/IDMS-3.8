using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DirectX.Capture;

namespace IDMS.Page
{
    public partial class cameraPort : Form
    {
        public cameraPort()
        {
            InitializeComponent();
            try
            {
                LoadVdo();
            }
            catch
            {
                MessageBox.Show("No video device detected. Please attach the video device and restart the program.");
            }
            try
            {
                RefreshComPortList();
            }
            catch
            {
                MessageBox.Show("No COM Ports detected. Please attach the Com Port Device and restart the program..");
            }

        }



        private void LoadVdo()
        {
            videoSourceList.DataSource = World.Settings.vdoList;
            videoSourceList.SelectedIndex = World.Settings.selectedVSource;
        }

        private void setVsource_Click(object sender, EventArgs e)
        {
            string message = "This will change the camera source. All data and actions in the camera pane will be reset. Are you sure you want to set a new camera source? You will have to restart the program in order to have your changes be in effect.";
            string caption = "Set Camera";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Stop);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                IDMS.World.Settings.selectedVSource = videoSourceList.SelectedIndex;

                /*
                IDMS_Application.userControls.CaptureTest.aTimer.Enabled = false;
                if (IDMS_Application.userControls.CaptureTest.power) IDMS_Application.userControls.CaptureTest.capture.PreviewWindow = null;
                if (World.Current.Rec) { IDMS_Application.userControls.CaptureTest.capture.Stop(); }
                if (IDMS_Application.userControls.CaptureTest.comport.IsOpen) { IDMS_Application.userControls.CaptureTest.comport.Close(); }
                main_project.MainApp.myCtlMultiPanePage2.Controls.Clear();
                IDMS_Application.userControls.CaptureTest cam = new IDMS_Application.userControls.CaptureTest();
                IDMS_Application.userControls.CaptureTest.power = false;
                main_project.MainApp.myCtlMultiPanePage2.Controls.Add(cam);
                */
            }
        }

        private void RefreshComPortList()
        {
            // Determain if the list of com port names has changed since last checked



            bool f = IDMS.Page.examUC.comport.IsOpen;
            string selected = World.Settings.RefreshComPortList(cmbPortName.Items.Cast<string>(), cmbPortName.SelectedItem as string, f);

            // If there was an update, then update the control showing the user the list of port names
            if (!String.IsNullOrEmpty(selected))
            {
                cmbPortName.Items.Clear();
                cmbPortName.Items.AddRange(World.Settings.OrderedPortNames());
                //cmbPortName.SelectedItem = selected;
                cmbPortName.SelectedItem = World.Settings.selectedComPort;
            }




        }

        private void setComport_Click(object sender, EventArgs e)
        {
            World.Settings.selectedComPort = cmbPortName.Text;
        }


    }
}
