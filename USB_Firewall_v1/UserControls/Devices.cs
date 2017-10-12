using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Management;
using System.Linq;
using System.Collections;
using System.Drawing;
using USB_Firewall_v1.Other_Classes;

namespace USB_Firewall_v1
{
    public partial class Devices : UserControl
    {
        private Thread _deviceSearch;

        private const string hidGUID = "{745a17a0-74d3-11d0-b6fe-00a0c90f57da}"; // class: HID Human Interface Devices
        private const string keyboardGUID = "{4d36e96b-e325-11ce-bfc1-08002be10318}"; // class: keyboard
        private const string mouseGUID = "{4d36e96f-e325-11ce-bfc1-08002be10318}"; // class: mouse
        private const string multimediaGUID = "{4d36e96c-e325-11ce-bfc1-08002be10318}"; // class: multimedia
        private const string netGUID = "{4d36e972-e325-11ce-bfc1-08002be10318}"; // class: net        
        private const string printerGUID = "{4d36e979-e325-11ce-bfc1-08002be10318}"; // class: printer              
        private const string smartcardreaderGUID = "{50dd5230-ba8a-11d1-bf5d-0000f805f530}"; // class: smartcardreader
        private const string volumeGUID = "{71a27cdd-812a-11d0-bec7-08002be2092f}"; // class: volume       
        private const string usbdeviceGUID = "{88BAE032-5A81-49f0-BC3D-A4FF138216D6}"; // class: usbdevice  
        private const string usbstordeviceGUID = "{36FC9E60-C465-11CF-8056-444553540000}"; // class: usbstordevice  
        private const string diskdrivesGUID = "{4d36e967-e325-11ce-bfc1-08002be10318}"; // class: diskdrives 
        private const string bluetoothGUID = "{e0cbf06c-cd8b-4647-bb8a-263b43f0f974}"; // class: bluetooth 
        private const string modemGUID = "{4D36E96D-E325-11CE-BFC1-08002BE10318}"; // class: modem

        // ManagementObjectCollection collection = new ManagementObjectCollection();
        private List<PnpDevice> _pnpDevices;
        private List<PnpDevice> _pnpAllDevices;
        private List<PnpDevice> _pnpDevicesError;
        ManagementObjectSearcher searcher;

        private static Devices _instance;

        public static Devices Instance
        {
          get
            {         
                if(_instance == null) _instance = new Devices();    
                return _instance;
            }
        }

        public Devices()
        {
            InitializeComponent();

            _pnpDevices = new List<PnpDevice>();
            _pnpAllDevices = new List<PnpDevice>();
            _pnpDevicesError = new List<PnpDevice>();
            searcher = new ManagementObjectSearcher(@"Select * From Win32_PnPEntity");
            _deviceSearch = new Thread(DeviceSearch);

            dataGridView1.Font = new System.Drawing.Font("Century Gothic", 11); // the Media namespace
            dataGridView1.DefaultCellStyle.BackColor = this.BackColor;

            Padding newPadding = new Padding(0, 3, 0, 3);
            this.dataGridView1.RowTemplate.DefaultCellStyle.Padding = newPadding;          
            this.dataGridView1.RowTemplate.Height += 20;

           // Image del = Image.FromFile("Images\\details.png");

            CheckDevices();

            _deviceSearch.Abort();

            Controls.Add(PendingDevices.Instance);
            PendingDevices.Instance.Dock = DockStyle.Fill;
        }


        private void DeviceSearch()
        {     
            try
            {
                _pnpDevices.Clear();
                _pnpAllDevices.Clear();
                _pnpDevicesError.Clear();
                _pnpDevices = new List<PnpDevice>();
                _pnpAllDevices = new List<PnpDevice>();
                _pnpDevicesError = new List<PnpDevice>();

                foreach (var device in searcher.Get())
                {

                    PnpDevice deviceInfo = new PnpDevice();
                    try
                    {
                        deviceInfo.Availability = Convert.ToString(device.GetPropertyValue("Availability"));
                        deviceInfo.Caption = (String)device.GetPropertyValue("Caption");
                        deviceInfo.ClassGuid = (String)device.GetPropertyValue("ClassGuid");
                        deviceInfo.CompatibleID = (String[])device.GetPropertyValue("CompatibleID");
                        deviceInfo.ConfigManagerErrorCode = (UInt32)device.GetPropertyValue("ConfigManagerErrorCode");
                        deviceInfo.ConfigManagerUserConfig = (Boolean)device.GetPropertyValue("ConfigManagerUserConfig");
                        deviceInfo.CreationClassName = (String)device.GetPropertyValue("CreationClassName");
                        deviceInfo.Description = (String)device.GetPropertyValue("Description");
                        deviceInfo.DeviceID = (String)device.GetPropertyValue("DeviceID");
                        if (device.GetPropertyValue("ErrorCleared") != null) deviceInfo.ErrorCleared = (bool)device.GetPropertyValue("ErrorCleared");
                        deviceInfo.ErrorDescription = (String)device.GetPropertyValue("ErrorDescription");
                        deviceInfo.HardwareID = (String[])device.GetPropertyValue("HardwareID");
                        deviceInfo.InstallDate = (String)device.GetPropertyValue("InstallDate");
                        deviceInfo.LastErrorCode = (String)device.GetPropertyValue("LastErrorCode");
                        deviceInfo.Manufacturer = (String)device.GetPropertyValue("Manufacturer");
                        deviceInfo.Name = (String)device.GetPropertyValue("Name");
                        deviceInfo.PNPClass = (String)device.GetPropertyValue("PNPClass");
                        deviceInfo.PNPDeviceID = (String)device.GetPropertyValue("PNPDeviceID");
                        deviceInfo.PowerManagementCapabilities = (String)device.GetPropertyValue("PowerManagementCapabilities");
                        if (device.GetPropertyValue("PowerManagementSupported") != null) deviceInfo.PowerManagementSupported = (bool)device.GetPropertyValue("PowerManagementSupported");
                        deviceInfo.Present = (bool)device.GetPropertyValue("Present");
                        deviceInfo.Service = (String)device.GetPropertyValue("Service");
                        deviceInfo.Status = (String)device.GetPropertyValue("Status");
                        deviceInfo.StatusInfo = (String)device.GetPropertyValue("StatusInfo");
                        deviceInfo.SystemCreationClassName = (String)device.GetPropertyValue("SystemCreationClassName");
                        deviceInfo.SystemName = (String)device.GetPropertyValue("SystemName");

                        if (deviceInfo.PNPDeviceID.Contains("USB") || deviceInfo.PNPDeviceID.Contains("HID"))
                        {
                            try
                            {
                                /*if (deviceInfo.ClassGuid.Contains(hidGUID) ||
                                    deviceInfo.ClassGuid.Contains(keyboardGUID) ||
                                    deviceInfo.ClassGuid.Contains(mouseGUID) ||
                                    deviceInfo.ClassGuid.Contains(multimediaGUID) ||
                                    deviceInfo.ClassGuid.Contains(netGUID) ||
                                    deviceInfo.ClassGuid.Contains(printerGUID) ||
                                    deviceInfo.ClassGuid.Contains(smartcardreaderGUID) ||
                                    deviceInfo.ClassGuid.Contains(volumeGUID) ||
                                    deviceInfo.ClassGuid.Contains(usbdeviceGUID) ||
                                    deviceInfo.ClassGuid.Contains(diskdrivesGUID) ||
                                    deviceInfo.ClassGuid.Contains(bluetoothGUID) ||
                                    deviceInfo.ClassGuid.Contains(usbstordeviceGUID) ||
                                    deviceInfo.ClassGuid.Contains(modemGUID))
                                {   */

                                if (!deviceInfo.ClassGuid.Equals(string.Empty))
                                {
                                    _pnpDevices.Add(deviceInfo);
                                    _pnpAllDevices.Add(deviceInfo);
                                }    
                                    
                                //}
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(deviceInfo.Description + " This device has an error");
                                _pnpAllDevices.Add(deviceInfo);

                                // If device is ready to install
                                if (deviceInfo.CompatibleID[0] != string.Empty) _pnpDevicesError.Add(deviceInfo);
                                                                                  
                                ///_pnpDevicesError.Add(deviceInfo);
                            }
                        }
                        else
                        {
                            // Detected other device that does not use USB communications
                            // Automatically installing device drivers
                            
                            try
                            {
                                if (deviceInfo.ClassGuid.Equals(string.Empty))
                                {
                                    // This will throw an exception for other pending devices
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("-------------------------------- Installing device drivers..." + deviceInfo.Description + " 2 " + deviceInfo.Name);
                                // DriverInstall.Instance.GetInf(deviceInfo);
                                DriverInstall.Instance.AutoInstall(deviceInfo);
                            }

                        }



                        
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                            
                }
            }
            catch (Exception e)
            {
                //listBox1.Items.Add(e);
            }
                                   
            searcher.Dispose();
                         
        }   


        public void UpdateList()
        {
            //listBox1.Items.Clear();
            dataGridView1.Rows.Clear();
            List < string > l = new List<string>();
            /*l.Add("hey");
            l.Add("hello");
            dataGridView1.Rows.Add(l.ToArray());  */

            Console.WriteLine(_pnpDevices.Count());  

            _deviceSearch = new Thread(DeviceSearch);
            _deviceSearch.Start();
            _deviceSearch.Join();

            if (_pnpDevices.Count > 0)
            {        
                foreach (var u in _pnpDevices)
                {
                    try
                    {                                           
                        int row = dataGridView1.Rows.Add();
                        dataGridView1.Rows[row].Cells["name_column"].Value = u.Name;
                        dataGridView1.Rows[row].Cells["class_column"].Value = u.PNPClass;         
                        dataGridView1.Rows[row].Tag = u;

                        /*ListViewItem item = new ListViewItem();
                        item.Tag = u;
                        item.Text = u.Name;
                        item.SubItems.Add(u.PNPClass);
                        listView1.Items.Add(item); */

                        //listBox1.Items.Add(u.Name);
                        // listBox1.Items.Add(u.PNPClass);
                        // listBox1.Items.Add(" ");
                    }
                    catch (Exception e)
                    {
                        //listBox1.Items.Add(" PROBLEM DETECTED " + u.Name + " " + u.Description);
                       // listBox1.Items.Add(" ");
                    }
                }

            }
            else Console.WriteLine("List is empty");
        }    

        public void CheckDevices()
        {
            Console.WriteLine("\n»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»CHECKING DEVICES«««««««««««««««««««««««««««««««««««««««");

            if(_deviceSearch.IsAlive)_deviceSearch.Abort();

            List<PnpDevice> erroraux = new List<PnpDevice>();
            erroraux.AddRange(_pnpDevicesError);

            _deviceSearch = new Thread(DeviceSearch);
            _deviceSearch.Start();
            _deviceSearch.Join();

            if (!_deviceSearch.IsAlive) Console.WriteLine("Devices list has been updated ...");
            else _deviceSearch.Abort();                      

            Console.WriteLine(" ");
            Console.WriteLine("GENERAL DEVICES:    " + _pnpAllDevices.Count());
            Console.WriteLine("DEVICES:            " + _pnpDevices.Count());
            Console.WriteLine("DEVICES WITH ERROR: " + _pnpDevicesError.Count());
            Console.WriteLine("AUX WITH ERROR:     " + erroraux.Count());
            Console.WriteLine(" ");

            Console.WriteLine("The following devices have an error:");
            foreach(var d in _pnpDevicesError) Console.WriteLine("Name: " + d.Name + " Class: " + d.PNPClass);
            Console.WriteLine("");

            List<PnpDevice> repeatedlist = new List<PnpDevice>();
             
            for(int i = 0; i < _pnpDevicesError.Count; i++)
            {                                         
                for (int j = 0; j < erroraux.Count; j++)
                {                                            
                    if (_pnpDevicesError[i].PNPDeviceID.Equals(erroraux[j].PNPDeviceID))
                    {
                        repeatedlist.Add(_pnpDevicesError[i]);
                        Console.WriteLine(" Found repeated member");
                    } 
                }       
            }
                    
            Console.WriteLine(" ");
            foreach (var d in _pnpDevicesError) Console.WriteLine("Name => " + d.Name);
            Console.WriteLine(" ");

            IEnumerable<PnpDevice> newErrorList = _pnpDevicesError.Except(repeatedlist);
            foreach (PnpDevice p in newErrorList)
            {
                Console.WriteLine(" New Device : " + p.Name);
                if (Settings.Instance.AllowNotifications() && p.CompatibleID.Length>0)
                {
                    // Notify user of new device income
                    AutoPlay auto = new AutoPlay(p);
                    auto.Show();
                }
            }

            UpdateList();

            Console.WriteLine("»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»»CHECKING DEVICES ENDED««««««««««««««««««««««««««««««««««««");
        }


        // Other methods

        public void AbortThread()
        {
            _deviceSearch.Abort();
        }


        public List<PnpDevice> GetDeviceList()
        {
            return _pnpDevices;
        }

        public List<PnpDevice> GetPendingDeviceList()
        {
            return _pnpDevicesError;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("details_column"))
            {
                //PnpDevice p = (PnpDevice)dataGridView1.Rows[e.RowIndex].Tag;
                /*foreach (PnpDevice device in _pnpDevices)
                {
                    if (device.PNPDeviceID.Equals(p.PNPDeviceID))
                    {
                        DetailedInfo.Instance.SetDetails(p);
                    }
                }  */
                DetailedInfo.Instance.SetDetails((PnpDevice)dataGridView1.Rows[e.RowIndex].Tag);
                DetailedInfo.Instance.BringToFront();
            }
        }   
    }
}
