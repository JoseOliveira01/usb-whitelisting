using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USB_Firewall_v1.Other_Classes
{
    public class DriverInstall
    {
        // Device to install
        private PnpDevice device;          

        // Inf file possible locations
        private const string WINDOWSINF = @"C:\windows\INF";
        private const string WINDOWSFILEREPOSITORY = @"C:\Windows\System32\DriverStore\FileRepository";

        // List of possible Inf file
        private List<string> _inflist;

        //Invoked Singleton statement
        private static DriverInstall _instance;

        private DriverInstall() {  }

        public static DriverInstall Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DriverInstall();
                }
                return _instance;
            }
        }

        public void AutoInstall(PnpDevice device)
        {
            try
            {
                InstallDriver(device.HardwareID[0], (GetInf(device))[0]);
            }   catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }                               

        //Used outside of the class
        public List<string> GetInf(PnpDevice device)
        {
            try
            {
                _inflist.Clear(); // Clear the list
            }
            catch (NullReferenceException nre) { Console.WriteLine(nre); }
            _inflist = new List<string>();

            this.device = device;

            DirectoryInfo d = new DirectoryInfo(WINDOWSINF);

            int test = Search(d);
            Console.WriteLine(test);
            if (_inflist.Count <= 0)
            {
                SearchFileRepositoryFolder();
            }

            if (_inflist.Count <= 0) Console.WriteLine("INF List is empty !!!");
            return _inflist;
        }


        private int Search(DirectoryInfo directory)
        {
            foreach (var file in directory.GetFiles("*.inf"))
            {
                Console.WriteLine("Scanning: " + file.FullName);
                ReadFile(file);
            }

            List<string> _infAux = new List<string>();
            for (int i = _inflist.Count - 1; i >= 0; i--)
            {
                _infAux.Add(_inflist[i]);
            }
            _inflist = _infAux;

            Console.WriteLine("INF list has " + _inflist.Count + " possible infs");
            return 0;
        }

        private void SearchFileRepositoryFolder()
        {
            DirectoryInfo d = new DirectoryInfo(WINDOWSFILEREPOSITORY);
            DirectoryInfo[] directories = d.GetDirectories();

            foreach (var directory in directories) Search(directory);
        }


        // Read files and search for the class
        public void ReadFile(FileInfo file)
        {           
            foreach (var line in File.ReadAllLines(file.FullName))
            {

                // Search for Hardware ID
                foreach (string hwid in device.HardwareID)
                {
                    if (line.Contains(hwid))
                    {
                        // This file contains device compatibleID, this can be the right driver
                        Console.WriteLine("»»»»»»»» FOUND COMPATIBLE DRIVER -> " + file.FullName + " (hardware id)");
                        _inflist.Add(file.FullName);
                    }
                }

                // Search for Compatible ID
                foreach (string cmid in device.CompatibleID)
                {
                    if (line.Contains(cmid))
                    {
                        // This file contains device compatibleID, this can be the right driver

                        Console.WriteLine("»»»»»»»» FOUND COMPATIBLE DRIVER -> " + file.FullName + " (compatible id)");
                        _inflist.Add(file.FullName);
                    }
                }

            }
        }


        [DllImport("NewDev.dll", CharSet = CharSet.Auto, EntryPoint = "UpdateDriverForPlugAndPlayDevices")]
        [SecurityCritical]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal extern static bool UpdateDriverForPlugAndPlayDevices
    (
        IntPtr hwndParent,
        [MarshalAs(UnmanagedType.LPWStr)]String szHardwordID,
        [MarshalAs(UnmanagedType.LPWStr)]String szINFName,
        uint installFlags,
        IntPtr bRebootRequired
    );


        public void InstallDriver(string _hwid, string _infPath)
        {
            try
            {
                UpdateDriverForPlugAndPlayDevices(IntPtr.Zero, _hwid, _infPath, 1, IntPtr.Zero);
            }
            catch(Exception e) { Console.WriteLine(e); }
        }

    }
}
