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

                                                                                        
            possibledrivers.Items.AddRange((DriverInstall.Instance.GetInf(device)).ToArray());
            possibledrivers.SelectedIndex = 0;

            FilterResults();
            ReAnalyzeFile();
            
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
                 
        // This function is responsible for installing driver for device IF allowed
        private void InstallDriver()
        {
            try
            {
                Console.WriteLine("Installing...");
                DriverInstall.Instance.InstallDriver(device.HardwareID[0], compatibleDriver);
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
