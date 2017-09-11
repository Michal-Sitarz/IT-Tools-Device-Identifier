using System;
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

        public string pcSpecs_CPU = "";
        public string pcSpecs_RAMmoduleDetails = "";
        public string pcSpecs_RAMinstalled = "";
        public string pcSpecs_RAMcapabilities = "";
        public string pcSpecs_HDDmodel = "";
        public string pcSpecs_HDDcapacity = "";

        public string periph_InputDevice = "";
        public bool periph_DockingStation = false;
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

            box_locationZone.Text = getLastLocation();

            textBox_Username.Select();

            btn_SaveToDB.BackColor = Color.IndianRed;

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
            textBox_HDDtype.Text = pcSpecs_HDDmodel;

            textBox_MonitorsConnected.Text = periph_MonitorsConnected;
        }


        /// MAIN button: Read Specs
        private void btn_ReadSpecs_Click(object sender, EventArgs e)
        {
            scanSystem();
            if (computerNameIsFound(pc_ComputerName))
            {
                MessageBox.Show("This device already exists in the Database.\nYou won't be able to add it again...", "[ Computer Name ]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_SaveToDB.BackColor = Color.Gray;
            }
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

            // OS version
            pc_OSversion = performWin32Query("Caption", "Win32_OperatingSystem");
            pc_OSversion += " ";
            pc_OSversion += performWin32Query("OSArchitecture", "Win32_OperatingSystem");

            // Type
            pc_Type = getChassisType().ToString();

            // Manufacturer
            pc_Manufacturer = performWin32Query("Manufacturer", "Win32_ComputerSystem");

            // Model
            pc_Model = performWin32Query("Model", "Win32_ComputerSystem");

            // Serial Number
            pc_SerialNumber = performWin32Query("SerialNumber", "Win32_BIOS");

            // Computer Name
            pc_ComputerName = performWin32Query("Caption", "Win32_ComputerSystem");

            // CPU
            pcSpecs_CPU = performWin32Query("Name", "Win32_Processor");

            // RAM: module details
            pcSpecs_RAMmoduleDetails = performWin32Query("Manufacturer", "Win32_PhysicalMemory");
            pcSpecs_RAMmoduleDetails += " ";
            pcSpecs_RAMmoduleDetails += performWin32Query("PartNumber", "Win32_PhysicalMemory").Trim();
            pcSpecs_RAMmoduleDetails += " @ ";
            pcSpecs_RAMmoduleDetails += performWin32Query("Speed", "Win32_PhysicalMemory");
            pcSpecs_RAMmoduleDetails += " MHz";

            // RAM: installed
            pcSpecs_RAMinstalled = getRAMinstalled();

            // RAM: capabilities
            pcSpecs_RAMcapabilities = performWin32Query("MaxCapacity", "Win32_PhysicalMemoryArray");
            pcSpecs_RAMcapabilities = (Convert.ToUInt64(pcSpecs_RAMcapabilities) / (1024 * 1024)).ToString() + " GB / "; //converts to GB units
            pcSpecs_RAMcapabilities += performWin32Query("MemoryDevices", "Win32_PhysicalMemoryArray");

            // HDD model
            pcSpecs_HDDmodel = performWin32Query("Model", "Win32_DiskDrive WHERE Index=0");

            // HDD capacity
            pcSpecs_HDDcapacity = performWin32Query("Size", "Win32_DiskDrive WHERE Index=0");
            pcSpecs_HDDcapacity = Convert.ToInt16(Convert.ToUInt64(pcSpecs_HDDcapacity) / (Math.Pow(1000, 3))).ToString() + " GB"; //converts to GB units

            // Monitors connected
            periph_MonitorsConnected = performWin32Query("Caption", "Win32_DesktopMonitor");


            ///update displayed details
            updateDisplayedDetails();
            setLabelsColours();
        }


        /// method to perform single WMI query
        private string performWin32Query(string queryField, string queryWin32lib)
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


            // monitors conected
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
                                        + "periph_DockingStation "
                                    + ") VALUES ("
                                        + "NULL, '"
                                        + user_Username + "','"
                                        + user_Location + "','"
                                        + user_Department + "','"
                                        + pc_ComputerName + "','"
                                        + pc_SerialNumber + "','"
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
                                        + periph_DockingStation + "')";

            // run the query and return its state
            return runDBquery(querySaveDetails);
        }

        public void createDBfile()
        {
            if (!File.Exists(dbFilePath))
            {
                string queryCreateDB = @"CREATE TABLE deviceDB(
                                        user_ID INTEGER PRIMARY KEY, 
                                        user_Username TEXT, 
                                        user_Location TEXT,
                                        user_Department TEXT,
	                                    pc_ComputerName TEXT,
                                        pc_SerialNumber TEXT,
	                                    pc_Manufacturer TEXT,
                                        pc_Model TEXT,
	                                    pc_Type TEXT,
                                        pc_OSversion TEXT,
	                                    pcSpecs_CPU TEXT,
                                        pcSpecs_RAMmoduleDetails TEXT,
	                                    pcSpecs_RAMinstalled TEXT,
                                        pcSpecs_RAMcapabilities TEXT,
	                                    pcSpecs_HDDmodel TEXT,
                                        pcSpecs_HDDcapacity TEXT,
	                                    periph_MonitorsConnected TEXT,
                                        periph_InputDevice TEXT,
	                                    periph_DockingStation BOOLEAN
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

    }
}
