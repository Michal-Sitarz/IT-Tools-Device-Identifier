﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
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

        public string user_Username = "";
        public string user_Location = "";
        public string user_Department = "";

        public string pc_OSversion = "";
        public string pc_Type = "";
        public string pc_Manufacturer = "";
        public string pc_Model = "";
        public string pc_SerialNumber = "";
        public string pc_ComputerName = "";
        public bool pc_NameMatching = false;

        public string pcSpecs_CPU = "";
        public string pcSpecs_RAMmoduleDetails = "";
        public string pcSpecs_RAMinstalled = "";
        public string pcSpecs_RAMcapabilities = "";
        public string pcSpecs_HDDmodel = "";
        public string pcSpecs_HDDcapacity = "";

        public string periph_InputDevice = "";
        public bool periph_DockingStation = false;
        public bool periph_TPM_BitLocker_ON = false;
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
            "MIS",
            "Engineering",
            "Management",
            "Finance",
            "Purchasing",
            "Marketing",
            "HR",
            "Customer Service",
            "Logistics",
            "Manufacturing",
            "Quality",
            "Reception",
            "temporary"
        };


        public List<string> periph_InputDeviceList = new List<string>()
        {
            "HP set (wired)",
            "MS set (wireless)",
            "Dell set (wired)"
        };

        // database variables
        public string dbFilePath = Directory.GetCurrentDirectory() + @"\deviceDatabase.db";


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
            checkBox_TPM_BitLocker.Checked = false;

            box_locationZone.Text = getLastLocation();

            textBox_Username.Select();

            btn_SaveToDB.BackColor = Color.IndianRed;

            // scan the system for hardware specs
            scanSystem();

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
            textBox_HDDtype.Text = pcSpecs_HDDmodel;

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
            if (pc_ComputerName != "")
            {
                if (btn_SaveToDB.BackColor == Color.IndianRed)
                {
                    if (readManualInputFields())
                    {
                        if (saveDetailsInDB())
                        {
                            btn_SaveToDB.BackColor = Color.ForestGreen;
                        }
                    }
                }
                else { MessageBox.Show("This device has been added already!", "Saving in DB...", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else { MessageBox.Show("Read the device's specs first!!! \n(Use the blue button).", "Details missing!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }



        /// method to scan the system 
        /// and obtain all the required information
        private void scanSystem()
        {

            /// OS version
            pc_OSversion = performWin32Query("Caption", "Win32_OperatingSystem");
            pc_OSversion += " ";
            pc_OSversion += performWin32Query("OSArchitecture", "Win32_OperatingSystem");

            /// Type
            pc_Type = getChassisType().ToString();

            /// Manufacturer
            pc_Manufacturer = performWin32Query("Manufacturer", "Win32_ComputerSystem");

            // keep the names consistent and short
            if (pc_Manufacturer.Contains("HP") || pc_Manufacturer.Contains("Hewlett-Packard"))
            {
                pc_Manufacturer = "HP";
            }
            else if (pc_Manufacturer.Contains("Dell"))
            {
                pc_Manufacturer = "Dell";
            }
            else
            {
                pc_Manufacturer = "other";
            }


            /// Model
            pc_Model = performWin32Query("Model", "Win32_ComputerSystem");
            pc_Model = trimSpaces(pc_Model);

            /// Serial Number
            pc_SerialNumber = performWin32Query("SerialNumber", "Win32_BIOS");

            /// Computer Name
            pc_ComputerName = performWin32Query("Caption", "Win32_ComputerSystem");

            /// Comp. Name matching Serial Number
            pc_NameMatching = setLabelsColours();

            /// CPU
            pcSpecs_CPU = performWin32Query("Name", "Win32_Processor").Trim();
            pcSpecs_CPU = trimSpaces(pcSpecs_CPU);

            /// RAM: module details
            pcSpecs_RAMmoduleDetails = performWin32Query("Manufacturer", "Win32_PhysicalMemory");
            pcSpecs_RAMmoduleDetails += " ";
            pcSpecs_RAMmoduleDetails += performWin32Query("PartNumber", "Win32_PhysicalMemory");
            pcSpecs_RAMmoduleDetails += " @ ";
            pcSpecs_RAMmoduleDetails += performWin32Query("Speed", "Win32_PhysicalMemory");
            pcSpecs_RAMmoduleDetails += " MHz";
            pcSpecs_RAMmoduleDetails = trimSpaces(pcSpecs_RAMmoduleDetails);

            /// RAM: installed
            pcSpecs_RAMinstalled = getRAMinstalled();

            /// RAM: capabilities
            pcSpecs_RAMcapabilities = performWin32Query("MaxCapacity", "Win32_PhysicalMemoryArray");
            pcSpecs_RAMcapabilities = (Convert.ToUInt64(pcSpecs_RAMcapabilities) / (1024 * 1024)).ToString() + " GB / "; //converts to GB units
            pcSpecs_RAMcapabilities += performWin32Query("MemoryDevices", "Win32_PhysicalMemoryArray");

            /// HDD model
            pcSpecs_HDDmodel = performWin32Query("Model", "Win32_DiskDrive WHERE Index=0");
            pcSpecs_HDDmodel = trimSpaces(pcSpecs_HDDmodel);


            /// HDD capacity
            pcSpecs_HDDcapacity = performWin32Query("Size", "Win32_DiskDrive WHERE Index=0");
            pcSpecs_HDDcapacity = Convert.ToInt16(Convert.ToUInt64(pcSpecs_HDDcapacity) / (Math.Pow(1000, 3))).ToString() + " GB"; //converts to GB units

            /// Monitors connected
            periph_MonitorsConnected = performWin32Query("Caption", "Win32_DesktopMonitor");
            periph_MonitorsConnected = trimSpaces(periph_MonitorsConnected);


            ///update displayed details
            updateDisplayedDetails();

            // warn if the computer is in the database already
            if (computerNameIsFound(pc_ComputerName))
            {
                MessageBox.Show("This device already exists in the Database.\nYou won't be able to add it again...", "[ Computer Name ]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_SaveToDB.BackColor = Color.Gray;
            }
        }


        /// labels (used as an indicator) to display 
        /// if the Computer Name matches company's naming convention
        /// blue: YES, red: NO

        private bool setLabelsColours()
        {
            bool checkCompNameMatchingSN = false;

            // check if the serial number matches computer name  
            if (pc_SerialNumber == pc_ComputerName.Substring(1))
            {
                // check if the computer name prefix matches the manufacturer name, e.g. H for HP
                if (pc_ComputerName.Substring(0, 1) == pc_Manufacturer.Substring(0, 1))
                {
                    checkCompNameMatchingSN = true;
                }
            }

            if (checkCompNameMatchingSN)
            {
                // set label to blue
                lblTop_Match.BackColor = Color.CornflowerBlue;
                lblBot_Match.BackColor = Color.CornflowerBlue;
                lblSide_Match.BackColor = Color.CornflowerBlue;
            }
            else
            {
                // set label to red
                lblTop_Match.BackColor = Color.Red;
                lblBot_Match.BackColor = Color.Red;
                lblSide_Match.BackColor = Color.Red;
            }

            return checkCompNameMatchingSN;
        }



        /// method to perform single WMI query
        private string performWin32Query(string queryField, string queryWin32lib)
        {
            string queryString = "";
            try
            {
                using (ManagementObjectSearcher searcherQuery = new ManagementObjectSearcher("SELECT " + queryField + " FROM " + queryWin32lib))
                {
                    foreach (ManagementObject queryData in searcherQuery.Get())
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


        /// method to obtain the info about installed RAM memory
        public string getRAMinstalled()
        {
            ulong ramCapacity = 0;
            int slotsQuantity = 0;

            try
            {
                using (ManagementObjectSearcher mosQuery = new ManagementObjectSearcher("SELECT DeviceLocator, Capacity FROM Win32_PhysicalMemory"))
                {
                    foreach (ManagementObject queryData in mosQuery.Get())
                    {
                        if (queryData["DeviceLocator"] != null && queryData["Capacity"] != null)
                        {
                            ramCapacity += Convert.ToUInt64(queryData["Capacity"].ToString());
                            slotsQuantity++;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return (ramCapacity / Math.Pow(1024, 3)).ToString() + " GB / " + slotsQuantity.ToString(); // RAM capacity converted to GB !!!

        }


        /// method to assign corresponding values 
        /// from manual (user's) input
        public bool readManualInputFields()
        {

            // username
            if (textBox_Username.Text != "")
            {
                user_Username = textBox_Username.Text;
                // add domain address (@doverfs.com) automatically, if not typed-in
                if (!user_Username.Contains("@"))
                {
                    if (user_Username != "none" && user_Username != "empty")
                    {
                        user_Username += "@doverfs.com";
                    }
                }

            }
            else
            {
                MessageBox.Show("You forgot to type-in the username \nused on the last log on.", "[ Username ]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            // location
            if (box_locationPos.Value != 0)
            {
                if (box_locationPos.Value < 10)
                {
                    user_Location = box_locationZone.Text + "0" + box_locationPos.Value.ToString();
                }
                else
                {
                    user_Location = box_locationZone.Text + box_locationPos.Value.ToString();
                }
            }
            else
            {
                MessageBox.Show("You forgot to set the location correctly.", "[ Location ]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            // departments
            if (comboBox_Department.Text != "")
            {
                user_Department = comboBox_Department.Text;
            }
            else
            {
                MessageBox.Show("You forgot to choose the DEPARTMENT!", "[ Department ]", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            // input devices
            if (comboBox_InputDevices.Text == "")
            {
                DialogResult msgBoxInputDevices = MessageBox.Show("Are you sure there are no mouse or keyboard available?", "[ Input Devices ]", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msgBoxInputDevices == DialogResult.No)
                {
                    return false;
                }
            }
            periph_InputDevice = comboBox_InputDevices.Text;


            // docking station
            if (checkBox_DockingStation.Checked == false)
            {
                if (pc_Type == "Laptop" || pc_Type == "Notebook")
                {
                    DialogResult msgBoxDockStation = MessageBox.Show("Did you forget to 'check' the docking station box?", "[ Docking Station ]", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (msgBoxDockStation == DialogResult.Yes)
                    {
                        checkBox_DockingStation.Checked = true;
                        periph_DockingStation = true;
                    }
                    if (msgBoxDockStation == DialogResult.No)
                    {
                        periph_DockingStation = false;
                    }
                }
            }
            else
            {
                periph_DockingStation = true;
            }


            // TPM/BitLocker
            if (checkBox_TPM_BitLocker.Checked == false)
            {
                if (pc_Type == "Laptop" || pc_Type == "Notebook")
                {
                    DialogResult msgBoxDockStation = MessageBox.Show("TPM/BitLocker checked???", "[ TPM ]", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgBoxDockStation == DialogResult.No)
                    {
                        return false;
                    }
                }

            }
            else
            {
                periph_TPM_BitLocker_ON = true;
            }


            // monitors conected
            periph_MonitorsConnected = textBox_MonitorsConnected.Text;
            if (numericBox_MonitorsConnected.Value != 0)
            {
                periph_MonitorsConnected += " (x" + numericBox_MonitorsConnected.Value.ToString() + ")";
            }
            else
            {
                DialogResult msgBoxMonitors = MessageBox.Show("Did you forgot about the monitors??", "[ Monitors Connected ]", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (msgBoxMonitors == DialogResult.Yes)
                {
                    return false;
                }
                else
                {
                    if (pc_Type == "Desktop" || pc_Type == "LowProfileDesktop" || pc_Type == "MiniTower" || pc_Type == "Tower")
                    {
                        MessageBox.Show("You have to set the number of monitors available \non this desk.", "[ Monitors Connected ]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return true;
        }


        /// DATABASE functionality (local single-file SQLite DB)

        // create DB
        public void createDBfile()
        {
            if (!File.Exists(dbFilePath))
            {
                string queryCreateDB = @"CREATE TABLE deviceDB(
                                        user_ID INTEGER PRIMARY KEY NOT NULL, 
                                        user_Username TEXT NOT NULL, 
                                        user_Location TEXT NOT NULL, 
                                        user_Department TEXT NOT NULL, 
	                                    pc_ComputerName TEXT NOT NULL, 
                                        pc_SerialNumber TEXT NOT NULL,
                                        pc_NameMatching BOOLEAN NOT NULL,
	                                    pc_Manufacturer TEXT NOT NULL, 
                                        pc_Model TEXT NOT NULL, 
	                                    pc_Type TEXT NOT NULL, 
                                        pc_OSversion TEXT NOT NULL, 
	                                    pcSpecs_CPU TEXT NOT NULL, 
                                        pcSpecs_RAMmoduleDetails TEXT NOT NULL, 
	                                    pcSpecs_RAMinstalled TEXT NOT NULL, 
                                        pcSpecs_RAMcapabilities TEXT NOT NULL, 
	                                    pcSpecs_HDDmodel TEXT NOT NULL, 
                                        pcSpecs_HDDcapacity TEXT NOT NULL, 
	                                    periph_MonitorsConnected TEXT NOT NULL, 
                                        periph_InputDevice TEXT NOT NULL, 
	                                    periph_DockingStation BOOLEAN NOT NULL,
                                        periph_TPM_BitLocker_ON BOOLEAN NOT NULL
                                    )";
                //create DB file
                try
                {
                    SQLiteConnection.CreateFile(dbFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Can't access local hard drive.");
                }

                // run query to create DB tables
                runDBquery(queryCreateDB);
            }

        }


        // save in DB
        public bool saveDetailsInDB()
        {

            // check if the DB file exists or not
            if (!File.Exists(dbFilePath))
            {
                createDBfile();
            }
            // query to perform that adds new entry to the DB
            string querySaveDetails = "INSERT INTO deviceDB("
                                        + "user_ID, "
                                        + "user_Username, "
                                        + "user_Location, "
                                        + "user_Department, "
                                        + "pc_ComputerName, "
                                        + "pc_SerialNumber, "
                                        + "pc_NameMatching, "
                                        + "pc_Manufacturer, "
                                        + "pc_Model, "
                                        + "pc_Type, "
                                        + "pc_OSversion, "
                                        + "pcSpecs_CPU, "
                                        + "pcSpecs_RAMmoduleDetails, "
                                        + "pcSpecs_RAMinstalled, "
                                        + "pcSpecs_RAMcapabilities, "
                                        + "pcSpecs_HDDmodel, "
                                        + "pcSpecs_HDDcapacity, "
                                        + "periph_MonitorsConnected, "
                                        + "periph_InputDevice, "
                                        + "periph_DockingStation, "
                                        + "periph_TPM_BitLocker_ON "
                                    + ") VALUES ("
                                        + "NULL, '"
                                        + user_Username + "','"
                                        + user_Location + "','"
                                        + user_Department + "','"
                                        + pc_ComputerName + "','"
                                        + pc_SerialNumber + "','"
                                        + pc_NameMatching + "','"
                                        + pc_Manufacturer + "','"
                                        + pc_Model + "','"
                                        + pc_Type + "','"
                                        + pc_OSversion + "','"
                                        + pcSpecs_CPU + "','"
                                        + pcSpecs_RAMmoduleDetails + "','"
                                        + pcSpecs_RAMinstalled + "','"
                                        + pcSpecs_RAMcapabilities + "','"
                                        + pcSpecs_HDDmodel + "','"
                                        + pcSpecs_HDDcapacity + "','"
                                        + periph_MonitorsConnected + "','"
                                        + periph_InputDevice + "','"
                                        + periph_DockingStation + "','"
                                        + periph_TPM_BitLocker_ON + "')";

            // run the query and return its state
            return runDBquery(querySaveDetails);
        }


        // default SQLite query (INSERT, CREATE)
        public bool runDBquery(string queryString)
        {
            bool querySuccess = false;
            string connectionString = " Data Source = " + dbFilePath + "; Version=3; ";

            // run query to create DB tables
            using (SQLiteConnection dbCon = new SQLiteConnection(connectionString))
            {
                try
                {
                    dbCon.Open();
                    using (SQLiteCommand command = new SQLiteCommand(queryString, dbCon))
                    {
                        command.ExecuteNonQuery();
                    }
                    dbCon.Close();
                    querySuccess = true;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            return querySuccess;
        }


        // method to get the last inserted location 
        // from the Database (SELECT)
        public string getLastLocation()
        {
            string lastLocation = "";
            // read from the DB
            if (File.Exists(dbFilePath))
            {
                string connectionString = " Data Source = " + dbFilePath + "; Version=3; ";

                // run query to read the data from DB
                using (SQLiteConnection dbCon = new SQLiteConnection(connectionString))
                {
                    try
                    {
                        dbCon.Open();

                        using (SQLiteCommand command = new SQLiteCommand("SELECT MAX(ROWID), user_Location FROM deviceDB", dbCon))
                        {
                            using (SQLiteDataReader data = command.ExecuteReader())
                            {
                                if (data.Read())
                                {
                                    lastLocation = (string)(data["user_Location"]);
                                }
                            }

                        }

                        dbCon.Close();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }

            // compute string and attach data to the corresponding box
            if (lastLocation != "")
            {
                lastLocation = lastLocation.Substring(0, 2);
            }

            return lastLocation;
        }

        public bool computerNameIsFound(string currentName)
        {
            bool sameNameFound = false;
            List<string> compNameList = new List<string>();
            /// read the comp names from DB
            /// and put them into ArrayList

            // read from the DB
            if (File.Exists(dbFilePath))
            {
                string connectionString = " Data Source = " + dbFilePath + "; Version=3; ";

                // run query to read the data from DB
                using (SQLiteConnection dbCon = new SQLiteConnection(connectionString))
                {
                    try
                    {
                        dbCon.Open();

                        using (SQLiteCommand command = new SQLiteCommand("SELECT pc_ComputerName FROM deviceDB", dbCon))
                        {
                            using (SQLiteDataReader data = command.ExecuteReader())
                            {
                                while (data.Read())
                                {
                                    compNameList.Add((string)(data["pc_ComputerName"]));
                                }
                            }

                        }

                        dbCon.Close();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }

            // search through the array to compare the name
            foreach (string name in compNameList)
            {
                if (currentName == name)
                {
                    sameNameFound = true;
                }
            }

            // return result
            return sameNameFound;
        }

        // method to change multiple whitespaces into single space
        public string trimSpaces(string strTrim)
        {
            strTrim = strTrim.Trim(); // trim any leading and trailing whitespaces
            while (strTrim.Contains("  "))
            {
                strTrim = strTrim.Replace("  ", " "); // trim any double-spaces to single-spaces
            }
            return strTrim;
        }

    }
}
