using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Device_Identifier
{
    public partial class FormMain : Form
    {
        
        // global strings:
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

        public int    user_ID = 0;
        public string user_Username = "";
        public string user_Location = "";
        public string user_Department = "";

        public bool   periph_DockingStation = false;
        public string periph_PortsAvailable = "";
        public string periph_InputDevices = "";
        public string periph_MonitorsConnected = "";
        // END: global strings
        
        
        public FormMain()
        {
            InitializeComponent();
            textBox_Username.Select();
            displayDetails();
        }

        // method to display values in the corresponding fields
        private void displayDetails() {

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
            textBox_Username.Text = user_Username;
            textBox_Location.Text = user_Location;
            //Department

            //DockingStation
            textBox_PortsAvailable.Text = periph_PortsAvailable;
            //InputDevices
            textBox_MonitorsConnected.Text = periph_MonitorsConnected;

        }


        // MAIN button: Read Specs
        private void btn_ReadSpecs_Click(object sender, EventArgs e)
        {

        }

        // button: SAVE to the database
        private void btn_SaveToDB_Click(object sender, EventArgs e)
        {

        }

        // method to scan the system 
        // and obtain all the required information
        private void scanSystem() {

        }

    }
}
