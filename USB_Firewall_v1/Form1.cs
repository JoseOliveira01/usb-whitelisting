using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.Win32;
using System.Security.Principal;
using System.Security.Permissions;
using System.Threading;
using System.Diagnostics;

namespace USB_Firewall_v1
{
    public partial class usbfirewall_form : Form
    {
        // Button color properties
        Color btnstandardcolor = new Color();
        Color btnpressedcolor = new Color();
        bool _devices_clicked = false;
        bool _pendingdevices_clicked = false;
        bool _processes_clicked = false;
        bool _settings_clicked = false;


        // Window movement properties
        bool _dragging = false;
        Point _startPos;


        public usbfirewall_form()
        {
            InitializeComponent();

            


            // Initialize Terminal
            AllocConsole();
            Console.Title = "USB FIREWALL TERMINAL";
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            try
            {
                Console.Clear();
            }catch(IOException io)
            {
                Console.WriteLine(io);
            }

            Console.WriteLine("hello");

            // Define new colors for the costum buttons
            btnstandardcolor = Color.FromArgb(41, 53, 65);
            btnpressedcolor = Color.FromArgb(34, 45, 61);

            _devices_clicked = true;
            devicespanel.BackColor = btnpressedcolor;
            contentpanel.Controls.Add(Devices.Instance);
            Devices.Instance.Dock = DockStyle.Fill;
            Devices.Instance.BringToFront();

            contentpanel.Controls.Add(PendingDevices.Instance);
            PendingDevices.Instance.Dock = DockStyle.Fill;

            contentpanel.Controls.Add(Processes.Instance);
            Processes.Instance.Dock = DockStyle.Fill;

            contentpanel.Controls.Add(Settings.Instance);
            Settings.Instance.Dock = DockStyle.Fill;

            contentpanel.Controls.Add(DetailedInfo.Instance);
            DetailedInfo.Instance.Dock = DockStyle.Fill;


            // Start USBNotification Handle
            UsbNotification.RegisterUsbDeviceNotification(this.Handle);


            // Disable autorun when applications starts
            RegistryKey Rkey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true);
            try
            {
                //Rkey.SetValue("NoDriveTypeAutoRun", 255); //disable for all media types, recommended 
                //Rkey.SetValue("NoDriveTypeAutoRun", 95); //disable
                Rkey.SetValue("NoDriveTypeAutoRun", 145); //enable
            }
            catch (NullReferenceException nre) { Console.WriteLine(nre); }
  


            // Disable USBSTOR to make sure no usb storage devices get started 
            int optionUSBSTOR = 3; // USB storage »» 3 = yes, 4 = no
            Microsoft.Win32.Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\USBSTOR", "Start", optionUSBSTOR, Microsoft.Win32.RegistryValueKind.DWord);


            // Create Registry Key to Deny PnP device install
            Rkey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Policies\\Microsoft\\Windows\\DeviceInstall\\Restrictions");
            Rkey.SetValue("AllowAdminInstall", 1, Microsoft.Win32.RegistryValueKind.DWord);        // Allow Admin to override restrictions and install anyway if needed
            Rkey.SetValue("DenyRemovableDevices", 1, Microsoft.Win32.RegistryValueKind.DWord);     // Disable Device install »» 0 to false, 1 to true
            Rkey.Close();


        }

        // Clikc devices button
        private void GetDevices(object sender, EventArgs e)
        {
            _devices_clicked = true;
            _pendingdevices_clicked = false;
            _processes_clicked = false;
            _settings_clicked = false;

            ChangeColorEventClick(devicespanel); // Change color 
            ChangeColorLeaveEvent(pendingdevicespanel, e); // Reset color
            ChangeColorLeaveEvent(processespanel, e);  // Reset color
            ChangeColorLeaveEvent(settingspanel, e);  // Reset color

            // Get devices panel
            //Devices.Instance.UpdateList();
            Devices.Instance.BringToFront();
                          
        }

        private void GetPendingDevices(object sender, EventArgs e)
        {
            _devices_clicked = false;
            _pendingdevices_clicked = true;
            _processes_clicked = false;
            _settings_clicked = false;
            ChangeColorEventClick(pendingdevicespanel);   // Change color
            ChangeColorLeaveEvent(devicespanel, e);     // Reset color
            ChangeColorLeaveEvent(processespanel, e);   // Reset color
            ChangeColorLeaveEvent(settingspanel, e);  // Reset color  

            // Get devices panel
            PendingDevices.Instance.SetPendingDevices(Devices.Instance.GetPendingDeviceList());
            PendingDevices.Instance.BringToFront();

        }

        private void GetProcesses(object sender, EventArgs e)
        {
            _devices_clicked = false;
            _pendingdevices_clicked = false;
            _processes_clicked = true;
            _settings_clicked = false;
            ChangeColorEventClick(processespanel);     // Change color
            ChangeColorLeaveEvent(devicespanel, e);        // Reset color
            ChangeColorLeaveEvent(pendingdevicespanel, e);  // Reset color
            ChangeColorLeaveEvent(settingspanel, e);  // Reset color

            // Get devices panel
            Processes.Instance.UpdateList();
            Processes.Instance.BringToFront();

        }

        private void GetSettings(object sender, EventArgs e)
        {
            _devices_clicked = false;
            _pendingdevices_clicked = false;
            _processes_clicked = false;
            _settings_clicked = true;
            ChangeColorEventClick(settingspanel);     // Change color
            ChangeColorLeaveEvent(devicespanel, e);        // Reset color
            ChangeColorLeaveEvent(pendingdevicespanel, e);  // Reset color
            ChangeColorLeaveEvent(processespanel, e);  // Reset color

            // Get Settings panel
            Settings.Instance.BringToFront();
        }


        // Change panel colors when clicked
        private void ChangeColorEventClick(Panel p)
        {
            // Change color
            p.BackColor = btnpressedcolor;
        }


        // Change panel colors when HOVER
        private void ChangeColorHoverEvent(object obj, EventArgs e)
        {
                ((Panel)obj).BackColor = btnpressedcolor;
        }


        // Change panel colors when LEAVE
        private void ChangeColorLeaveEvent(object obj, EventArgs e)
        {
            if (((Panel)obj).Name.Equals(devicespanel.Name) && !_devices_clicked)
            {
                ((Panel)obj).BackColor = btnstandardcolor;
            }
            else if (((Panel)obj).Name.Equals(pendingdevicespanel.Name) && !_pendingdevices_clicked)
            {
                ((Panel)obj).BackColor = btnstandardcolor;
            }
            else if (((Panel)obj).Name.Equals(processespanel.Name) && !_processes_clicked)
            {
                ((Panel)obj).BackColor = btnstandardcolor;
            }
            else if (((Panel)obj).Name.Equals(settingspanel.Name) && !_settings_clicked)
            {
                ((Panel)obj).BackColor = btnstandardcolor;
            }

            // Invalidate();
        }


        // Move window
        private void WindowMouseDown(object sender, MouseEventArgs e)
        {
            _dragging = true;
            _startPos = new Point(e.X, e.Y);                             
        }


        private void WindowMouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this._startPos.X, p.Y - this._startPos.Y);
            }
        }


        private void WindowMouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
        }


        private void Exit(object sender, EventArgs e)
        {
            Processes.Instance.AbortThread();
            Devices.Instance.AbortThread();
            Application.Exit();
        }

        private void Minimize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }



        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == UsbNotification.WM_DEVICECHANGE)
            {
                switch ((int)m.WParam)
                {
                    /*case UsbNotification.DBT_DEVICEREMOVECOMPLETE:
                        Console.WriteLine("Device removed");
                        break;
                    case UsbNotification.DBT_DEVICEARRIVAL:
                        Console.WriteLine("Device added");
                        break;  
                    case UsbNotification.DBT_DEVNODES_CHANGED: Devices.Instance.CheckDevices();
                        break;*/
                    case 7:
                        Devices.Instance.CheckDevices();
                        break;
                    default:
                        Console.WriteLine("m.wParam => " + m.WParam);
                        break;
                }
            }
        }    


        // Console
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();



    }
}
