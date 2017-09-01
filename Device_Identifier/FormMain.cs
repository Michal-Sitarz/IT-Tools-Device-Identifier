using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Device_Identifier
{
    public partial class FormMain : Form
    {
        /// global variables:

        // database fields
        public string pc_OSversion = "";
        public string pc_Type = "";
        public string pc_Manufacturer = "";
        public string pc_Model = "";
        public string pc_SerialNumber = "";
        public string pc_ComputerName = "";

        public string pcSpecs_CPU = "";
        public string pcSpecs_RAMinstalled = "";
        public string pcSpecs_RAMcapabilities = "";
        public string pcSpecs_RAMmoduleDetails = "";
        public string pcSpecs_HDDcapacity = "";
        public string pcSpecs_HDDtype = "";

        public int user_ID = 0;
        public string user_Username = "";
        public string user_Location = "";
        public string user_Department = "";
        
        public bool periph_DockingStation = false;
        public string periph_InputDevice = "";
        public string periph_MonitorsConnected = "";
        

        // chassis type enumeration
        public enum ChassisTypes
        {
            Other = 1,
            Unknown,
            Desktop,
            LowProfileDesktop,
            PizzaBox,
            MiniTower,
            Tower,
            Portable,
            Laptop,
            Notebook,
            Handheld,
            DockingStation,
            AllInOne,
            SubNotebook,
            SpaceSaving,
            LunchBox,
            MainSystemChassis,
            ExpansionChassis,
            SubChassis,
            BusExpansionChassis,
            PeripheralChassis,
            StorageChassis,
            RackMountChassis,
            SealedCasePC
        }


        // Win32 query variables
        public string queryField = "";
        public string queryWin32lib = "";


        // combo-box lists
        public List<string> user_DepartmentList = new List<string>()
        {
            "MIS", "Finance", "Purchasing", "Engineering"
        };

        public List<string> periph_InputDeviceList = new List<string>()
        {
            "HP mouse & keyboard (wired)",
            "MS mouse & keyboard (wireless)"
        };
        
        /// END: global variables/arrays


        /// main form (initialize)
        public FormMain()
        {
            InitializeComponent();

            comboBox_Department.DataSource = user_DepartmentList;
            comboBox_Department.SelectedIndex = -1;
            comboBox_InputDevices.DataSource = periph_InputDeviceList;
            comboBox_InputDevices.SelectedIndex = -1;

            checkBox_DockingStation.Checked = false;
            textBox_Username.Select();

        }

        /// labels (used as an indicator) to display 
        /// if the Computer Name / Serial Number
        /// is matching company's naming convention or not
        /// green - for YES, red - for NO
        private void setLabelsColours()
        {
            string checkSN = pc_SerialNumber;
            string checkCompName = pc_ComputerName.Substring(1);

            if (checkSN == checkCompName)
            {
                // set to blue
                lblTop_Match.BackColor = Color.CornflowerBlue;
                lblBot_Match.BackColor = Color.CornflowerBlue;
                lblSide_Match.BackColor = Color.CornflowerBlue;
            }
            else
            {
                // set to red
                lblTop_Match.BackColor = Color.Red;
                lblBot_Match.BackColor = Color.Red;
                lblSide_Match.BackColor = Color.Red;
            }
        }

        /// method to display values in the corresponding fields
        private void updateDisplayedDetails()
        {
            textBox_OSversion.Text = pc_OSversion;
            textBox_Type.Text = pc_Type;
            textBox_Manufacturer.Text = pc_Manufacturer;
            textBox_Model.Text = pc_Model;
            textBox_SerialNumber.Text = pc_SerialNumber;
            textBox_ComputerName.Text = pc_ComputerName;

            textBox_CPU.Text = pcSpecs_CPU;
            textBox_RAMinstalled.Text = pcSpecs_RAMinstalled;
            textBox_RAMcapabilities.Text = pcSpecs_RAMcapabilities;
            textBox_RAMmoduleDetails.Text = pcSpecs_RAMmoduleDetails;
            textBox_HDDcapacity.Text = pcSpecs_HDDcapacity;
            textBox_HDDtype.Text = pcSpecs_HDDtype;

            textBox_ID.Text = user_ID.ToString();

            textBox_MonitorsConnected.Text = periph_MonitorsConnected;
        }


        /// MAIN button: Read Specs
        private void btn_ReadSpecs_Click(object sender, EventArgs e)
        {
            scanSystem();

        }

        /// button: SAVE to the database
        private void btn_SaveToDB_Click(object sender, EventArgs e)
        {

        }

        /// method to scan the system 
        /// and obtain all the required information
        private void scanSystem()
        {

            // OS version
            pc_OSversion = performQuery("Caption", "Win32_OperatingSystem");
            pc_OSversion += " ";
            pc_OSversion += performQuery("OSArchitecture", "Win32_OperatingSystem");

            // Type
            pc_Type = getChassisType().ToString();

            // Manufacturer
            pc_Manufacturer = performQuery("Manufacturer", "Win32_ComputerSystem");

            // Model
            pc_Model = performQuery("Model", "Win32_ComputerSystem");

            // Serial Number
            pc_SerialNumber = performQuery("SerialNumber", "Win32_BIOS");

            // Computer Name
            pc_ComputerName = performQuery("Caption", "Win32_ComputerSystem");

            // CPU
            pcSpecs_CPU = performQuery("Name", "Win32_Processor");

            // RAM: module details
            pcSpecs_RAMmoduleDetails = performQuery("Manufacturer", "Win32_PhysicalMemory");
            pcSpecs_RAMmoduleDetails += " ";
            pcSpecs_RAMmoduleDetails += performQuery("PartNumber", "Win32_PhysicalMemory").Trim();
            pcSpecs_RAMmoduleDetails += " @ ";
            pcSpecs_RAMmoduleDetails += performQuery("Speed", "Win32_PhysicalMemory");
            pcSpecs_RAMmoduleDetails += " MHz";

            // RAM: installed


            // RAM: capabilities



            ///update displayed details
            updateDisplayedDetails();
            setLabelsColours();
        }

        /// method to perform single WMI query
        private string performQuery(string queryField, string queryWin32lib)
        {
            string queryString = "";
            try
            {
                using (ManagementObjectSearcher mosQuery = new ManagementObjectSearcher("SELECT " + queryField + " FROM " + queryWin32lib))
                {
                    foreach (ManagementObject queryData in mosQuery.Get())
                    {
                        if (queryData[queryField] != null)
                        {
                            queryString = queryData[queryField].ToString();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return queryString;

        }

        /// method to obtain chassis type
        public ChassisTypes getChassisType()
        {
            try
            {
                using (ManagementClass systemEnclosures = new ManagementClass("Win32_SystemEnclosure"))
                {

                    foreach (ManagementObject obj in systemEnclosures.GetInstances())
                    {
                        foreach (int i in (UInt16[])(obj["ChassisTypes"]))
                        {
                            if (i > 0 && i < 25)
                            {
                                return (ChassisTypes)i;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return ChassisTypes.Unknown;
        }

    }
}
