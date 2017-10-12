using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USB_Firewall_v1
{
    public partial class DetailedInfo : UserControl
    {

        private static DetailedInfo _instance;

        public static DetailedInfo Instance
        {
            get
            {
                if (_instance == null) _instance = new DetailedInfo();
                return _instance;
            }
        }

        public DetailedInfo()
        {
            InitializeComponent();

            this.BackColor = Color.FromArgb(255, 192, 128);
        }
        
        public void SetDetails(PnpDevice d)
        {
            details_list.Items.Clear();

            devicename.Text = d.Name;

            try
            {
                details_list.Items.Add("Compatible ID: " + d.CompatibleID[0]);
            }
            catch (Exception ex)
            {
                details_list.Items.Add("Compatible ID: Cant find // Driver installed...");
            }

            details_list.Items.Add("Availability: " + d.Availability);
            details_list.Items.Add("Caption: " + d.Caption);
            details_list.Items.Add("ClassGuid: " + d.ClassGuid);
            details_list.Items.Add("ConfigManagerErrorCode: " + d.ConfigManagerErrorCode);
            details_list.Items.Add("ConfigManagerUserConfig: " + d.ConfigManagerUserConfig);
            details_list.Items.Add("CreationClassName: " + d.CreationClassName);
            details_list.Items.Add("Description: " + d.Description);

            details_list.Items.Add("HardwareID: " + d.HardwareID[0]);

            details_list.Items.Add("DeviceID: " + d.DeviceID);
            details_list.Items.Add("ErrorCleared: " + d.ErrorCleared);
            details_list.Items.Add("ErrorDescription: " + d.ErrorDescription);
            details_list.Items.Add("InstallDate: " + d.InstallDate);
            details_list.Items.Add("LastErrorCode: " + d.LastErrorCode);
            details_list.Items.Add("Manufacturer: " + d.Manufacturer);
            details_list.Items.Add("Name: " + d.Name);

            details_list.Items.Add("PNPClass: " + d.PNPClass);
            details_list.Items.Add("PNPDeviceID: " + d.PNPDeviceID);
            details_list.Items.Add("PowerManagementCapabilities: " + d.PowerManagementCapabilities);
            details_list.Items.Add("PowerManagementSupported: " + d.PowerManagementSupported);
            details_list.Items.Add("Service: " + d.Service);
            details_list.Items.Add("Present: " + d.Present);
            details_list.Items.Add("Status: " + d.Status);

            details_list.Items.Add("StatusInfo: " + d.StatusInfo);
            details_list.Items.Add("SystemCreationClassName: " + d.SystemCreationClassName);
            details_list.Items.Add("SystemName: " + d.SystemName);

            details_list.Invalidate();
        }

        private void DetailedInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
