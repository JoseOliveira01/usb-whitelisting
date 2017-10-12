using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USB_Firewall_v1
{
    public class PnpDevice
    {
        public PnpDevice() { }  
        public String Availability { get; set; }
        public String Caption { get; set; }
        public String ClassGuid { get; set; }
        public String[] CompatibleID { get; set; }
        public UInt32 ConfigManagerErrorCode { get; set; }
        public Boolean ConfigManagerUserConfig { get; set; }
        public String CreationClassName { get; set; }
        public String Description { get; set; }
        public String DeviceID { get; set; }
        public Boolean ErrorCleared { get; set; }
        public String ErrorDescription { get; set; }
        public String[] HardwareID { get; set; }
        public String InstallDate { get; set; }
        public String LastErrorCode { get; set; }
        public String Manufacturer { get; set; }
        public String Name { get; set; }
        public String PNPClass { get; set; }
        public String PNPDeviceID { get; set; }
        public String PowerManagementCapabilities { get; set; }
        public Boolean PowerManagementSupported { get; set; }
        public String Service { get; set; }
        public Boolean Present { get; set; }
        public String Status { get; set; }
        public String StatusInfo { get; set; }
        public String SystemCreationClassName { get; set; }
        public String SystemName { get; set; }
    }
}
