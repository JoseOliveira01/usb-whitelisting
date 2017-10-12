using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using USB_Firewall_v1.Other_Classes;

namespace USB_Firewall_v1
{
    public partial class AutoPlay : Form
    {

        // Button color properties
        Color btnstandardcolor = new Color();
        Color btnpressedcolor = new Color();


        // Window movement properties
        bool _dragging = false;
        Point _startPos;


        // Driver installation
        private const string DRIVERPATH = @"C:\windows\INF";
        private const string ALTERNATIVEDRIVERPATH = @"C:\Windows\System32\DriverStore\FileRepository";
        private DirectoryInfo d;
        private string compatibleDriver = string.Empty;

        // Target device
        private PnpDevice device;          

        public AutoPlay(PnpDevice p)
        {
            const string caption = "Form Closing";
            MessageBox.Show("hello", caption,
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);
            Console.WriteLine("im here");
            InitializeComponent();

            // Define new colors for the costum buttons
            btnstandardcolor = Color.FromArgb(41, 53, 65);
            btnpressedcolor = Color.FromArgb(34, 45, 61);

            this.device = p;
            label_deviceinfo.Text = device.Name;

            //if (!SearchINFFolder()) SearchDriverForDevice(ALTERNATIVEDRIVERPATH);

            //SearchINFFolder();
            //SearchDriverForDevice(ALTERNATIVEDRIVERPATH);

                                                                                        
            possibledrivers.Items.AddRange((DriverInstall.Instance.GetInf(device)).ToArray());
            possibledrivers.SelectedIndex = 0;

            FilterResults();
            ReAnalyzeFile();

            /*driver = new Driver();
            foreach (var d in driver.SearchDriverForDevice(p))
                possibledrivers.Items.Add(d);    */

        }

        void FilterResults()
        {
            List<string> repeated = new List<string>();
            for(int i = 0; i < possibledrivers.Items.Count -1; i++)
            {
                if (possibledrivers.Items[i].Equals(possibledrivers.Items[i+1]))
                {
                    repeated.Add(possibledrivers.Items[i].ToString());
                }
            }

            foreach(var r in repeated)
            {
                listBox1.Items.Remove(r);
                possibledrivers.Items.Remove(r);
            }

            //if (possibledrivers.Items.Count > 0) possibledrivers.SelectedIndex = possibledrivers.Items.Count - 1;
        }


        /*private void SearchDriverForDevice(string s)
        {                           
            DirectoryInfo dinfo = new DirectoryInfo(s);
            DirectoryInfo[] directories = dinfo.GetDirectories();                

            foreach (var directory in directories)
            {
                //Console.WriteLine("Scanning " + directory.FullName);
                ScanDirectory(directory);                
            }    
            
               // if (line.Contains("Class ")) _class += "Class: " + line.Substring(line.LastIndexOf('=') + 1) + "\n";
               //          if (line.Contains("Svcdesc ")) _svcdesc += "Svcdesc " + line.Substring(line.LastIndexOf('=') + 1) + "\n";
             
        }

        bool SearchINFFolder()
        {
            d = new DirectoryInfo(DRIVERPATH);

            ScanDirectory(d);

            if (possibledrivers.Items.Count > 0) return true;
            else return false;        
        }

        void ScanDirectory(DirectoryInfo directory)
        {
            foreach (var file in directory.GetFiles("*.inf"))
            {                
                Console.WriteLine("Scanning: " + file.FullName);
                foreach (var line in File.ReadAllLines(file.FullName))
                {          

                    // Search for Hardware ID
                    foreach (string hwid in device.HardwareID)
                    {
                        if (line.Contains(hwid))
                        {
                            // This file contains device compatibleID, this can be the right driver
                            compatibleDriver = file.FullName;
                            Console.WriteLine("»»»»»»»» FOUND COMPATIBLE DRIVER -> " + file.FullName + " (hardware id)");
                            possibledrivers.Items.Add(file.FullName);
                            listBox1.Items.Add(file.FullName);

                            ReAnalyzeFile(file);
                            return;
                        }
                    }

                    // Search for Compatible ID
                    foreach (string cmid in device.CompatibleID)
                    {
                        if (line.Contains(cmid))
                        {
                            // This file contains device compatibleID, this can be the right driver
                            compatibleDriver = file.FullName;
                            Console.WriteLine("»»»»»»»» FOUND COMPATIBLE DRIVER -> " + file.FullName + " (compatible id)");
                            possibledrivers.Items.Add(file.FullName);
                            listBox1.Items.Add(file.FullName);        

                            ReAnalyzeFile(file);
                        }
                    }

                    

                }
            }
                
        }
        */

        //void ReAnalyzeFile(FileInfo file)
        void ReAnalyzeFile()
        {
            FileInfo file = new FileInfo(possibledrivers.Text);
           // listBox2.Items.Add("found new driver");                                                                               
            foreach (var line in File.ReadAllLines(file.FullName))
            {
                string s = string.Empty;

                if (line.Contains("SvcDesc ")|| line.Contains("SvcDesc="))
                {
                    s = line.Substring(line.IndexOf('"')+1);
                    listBox2.Items.Add(s);
                    deviceclass_label.Text = s;
                }
                else if (line.Contains("Class ") || line.Contains("Class="))
                {
                    s = line.Substring(line.LastIndexOf('=') + 1);
                    listBox2.Items.Add(s);
                    deviceclass_label.Text = s;
                }

            }

            List<string> repeated = new List<string>();
            for (int i = 0; i < listBox2.Items.Count - 1; i++)
            {
                if (listBox2.Items[i].Equals(listBox2.Items[i + 1]))
                {
                    repeated.Add(listBox2.Items[i + 1].ToString());
                }
            }

            foreach (var r in repeated)
            {
                listBox2.Items.Remove(r);      
            }
            
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Change panel colors when HOVER
        private void ChangeColorHoverEvent(object obj, EventArgs e)
        {
            ((Panel)obj).BackColor = btnpressedcolor;
        }                                    

        // Change panel colors when LEAVE
        private void ChangeColorLeaveEvent(object obj, EventArgs e)
        {
            ((Panel)obj).BackColor = btnstandardcolor;
        } 
        
        // Allow device
        private void AllowDevice(object o, EventArgs e)
        {
            Console.WriteLine("Allow device");

            if (possibledrivers.SelectedItem == null)
            {
                MessageBox.Show("Please choose a file");
            }
            else
            {
                // Remove allow/deny buttons
                Controls.Remove(allow_btn);
                Controls.Remove(allow_btn);

                compatibleDriver = possibledrivers.SelectedText;

                Console.WriteLine("INF choosed: " + compatibleDriver);
                Console.WriteLine("Device ID: " + device.HardwareID[0]);

                Thread Thread_DeviceInstall = new Thread(InstallDriver);
                Thread_DeviceInstall.Start();
                Thread_DeviceInstall.Join();

                if (!Thread_DeviceInstall.IsAlive)
                {
                    this.Close();
                }
                else Thread_DeviceInstall.Abort();

                //  driver.DriverInstall();
                PendingDevices.Instance.UpdateList();
                this.Close();

            }


        }
                   
        /*[DllImport("NewDev.dll", CharSet = CharSet.Auto, EntryPoint = "UpdateDriverForPlugAndPlayDevices")]
        [SecurityCritical]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal extern static bool UpdateDriverForPlugAndPlayDevices
            (
                IntPtr hwndParent,
                [MarshalAs(UnmanagedType.LPWStr)]String szHardwordID,
                [MarshalAs(UnmanagedType.LPWStr)]String szINFName,
                uint installFlags, 
                IntPtr bRebootRequired
            ); */

        // This function is responsible for installing driver for device IF allowed
        private void InstallDriver()
        {
            try
            {
                //UpdateDriverForPlugAndPlayDevices(IntPtr.Zero, device.HardwareID[0], compatibleDriver, 1, IntPtr.Zero); 
                //Console.WriteLine("ERROR::::" + Marshal.GetLastWin32Error());

                Console.WriteLine("Installing...");
                DriverInstall.Instance.InstallDriver(device.HardwareID[0], compatibleDriver);

                //throw new Exception();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }         

        // Deny device  
        private void DenyDevice(object o, EventArgs e)
        {
            Console.WriteLine("Deny device"); 
        }


        /*************************************************/
        /*             WINDOW MOVEMENT                   */
        /*************************************************/

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






    }
}
