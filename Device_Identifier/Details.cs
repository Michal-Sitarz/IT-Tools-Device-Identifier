using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device_Identifier
{
    class Details
    {
        public string pc_OSversion { get; set; }
        public string pc_Type { get; set; }
        public string pc_Manufacturer { get; set; }
        public string pc_Model { get; set; }
        public string pc_SerialNumber { get; set; }
        public string pc_ComputerName { get; set; }

        public string pcSpecs_CPU { get; set; }
        public string pcSpecs_RAMinstalled { get; set; }
        public string pcSpecs_RAMcapabilities { get; set; }
        public string pcSpecs_RAMmoduleDetails { get; set; }
        public string pcSpecs_HDDcapacity { get; set; }
        public string pcSpecs_HDDtype { get; set; }

        public int user_ID { get; set; }
        public string user_Username { get; set; }
        public string user_Location { get; set; }
        public string user_Department { get; set; }

        public bool periph_DockingStation { get; set; }
        public string periph_PortsAvailable { get; set; }
        public string periph_InputDevices { get; set; }
        public string periph_MonitorsConnected { get; set; }


        //default CTOR with empty values
        public Details()
        {
            pc_OSversion = "";
            pc_Type = "";
            pc_Manufacturer = "";
            pc_Model = "";
            pc_SerialNumber = "";
            pc_ComputerName = "";

            pcSpecs_CPU = "";
            pcSpecs_RAMinstalled = "";
            pcSpecs_RAMcapabilities = "";
            pcSpecs_RAMmoduleDetails = "";
            pcSpecs_HDDcapacity = "";
            pcSpecs_HDDtype = "";

            user_ID = 0;
            user_Username = "";
            user_Location = "";
            user_Department = "";

            periph_DockingStation = false;
            periph_PortsAvailable = "";
            periph_InputDevices = "";
            periph_MonitorsConnected = "";
        }
    }
}
