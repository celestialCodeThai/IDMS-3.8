using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Timers;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace IDMS.World
{
    public class Settings
    {
        #region CameraSettings

        public static List<string> vdo = new List<string>();
        public static BindingList<string> vdoList = new BindingList<string>(vdo);

        private static int _selectedVSource = int.Parse(ConfigurationManager.AppSettings["vdoSelect"]);
        public static int selectedVSource
        {
            get { return _selectedVSource; }
            set
            {
                _selectedVSource = value;

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                config.AppSettings.Settings["vdoSelect"].Value = value.ToString();
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");

            }
        }

        private static string _selectedComPort = ConfigurationManager.AppSettings["comPort"];
        public static string selectedComPort
        {
            get { return _selectedComPort; }
            set
            {
                _selectedComPort = value;

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                config.AppSettings.Settings["comPort"].Value = value.ToString();
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");

            }
        }

        public static List<string> availableComPorts = new List<string>();
        public static string[] OrderedPortNames()
        {
            // Just a placeholder for a successful parsing of a string to an integer
            int num;

            // Order the serial port names in numberic order (if possible)
            return SerialPort.GetPortNames().OrderBy(a => a.Length > 3 && int.TryParse(a.Substring(3), out num) ? num : 0).ToArray();
        }
        public static string RefreshComPortList(IEnumerable<string> PreviousPortNames, string CurrentSelection, bool PortOpen)
        {
            // Create a new return report to populate
            string selected = null;

            // Retrieve the list of ports currently mounted by the operating system (sorted by name)
            string[] ports = SerialPort.GetPortNames();

            // First determain if there was a change (any additions or removals)
            bool updated = PreviousPortNames.Except(ports).Count() > 0 || ports.Except(PreviousPortNames).Count() > 0;

            // If there was a change, then select an appropriate default port
            if (updated)
            {
                // Use the correctly ordered set of port names
                ports = OrderedPortNames();

                // Find newest port if one or more were added
                string newest = SerialPort.GetPortNames().Except(PreviousPortNames).OrderBy(a => a).LastOrDefault();

                // If the port was already open... (see logic notes and reasoning in Notes.txt)
                if (PortOpen)
                {
                    if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
                    else if (!String.IsNullOrEmpty(newest)) selected = newest;
                    else selected = ports.LastOrDefault();
                }
                else
                {
                    if (!String.IsNullOrEmpty(newest)) selected = newest;
                    else if (ports.Contains(CurrentSelection)) selected = CurrentSelection;
                    else selected = ports.LastOrDefault();
                }
            }

            // If there was a change to the port list, return the recommended default selection
            return selected;
        }

        #endregion


        private static string _savePath = ConfigurationManager.AppSettings["savePath"];
        public static string savePath
        {
          

            get {
                DataManage.DataAccess Load = new DataManage.DataAccess();
                string data = Load.getusbtext("2", "USB_PATH")+ "idmsCASE";



                return data;

              //  return _savePath;



            }
            set
            {
                _savePath = value;

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                config.AppSettings.Settings["savePath"].Value = value.ToString();
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private static string _savePathLocal = ConfigurationManager.AppSettings["savePathLocal"];
        public static string savePathLocal
        {
            get { return _savePathLocal; }
            set
            {
                _savePathLocal = value;

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                config.AppSettings.Settings["savePathLocal"].Value = value.ToString();
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private static string _mac = ConfigurationManager.AppSettings["MAC"];
        public static string mac
        {
            get { return _mac; }
            set
            {
                _mac = value;

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                config.AppSettings.Settings["MAC"].Value = value.ToString();
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

    }
}
