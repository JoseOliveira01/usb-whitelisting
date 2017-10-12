using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace USB_Firewall_v1
{
    class UsbNotification
    {                              
        public const int WM_DEVICECHANGE = 0x0219;                 // device change event      
        public const int DBT_DEVICEARRIVAL = 0x8000;               // system detected a new device      
        public const int DBT_DEVICEREMOVEPENDING = 0x8003;         // about to remove, still available      
        public const int DBT_DEVICEREMOVECOMPLETE = 0x8004;        // device is gone  

        public const int DBT_QUERYCHANGECONFIG = 0x0017;
        public const int DBT_CONFIGCHANGECANCELED = 0x0019;
        public const int DBT_CUSTOMEVENT = 0x8006;
        public const int DBT_DEVICETYPESPECIFIC = 0x8005;
        public const int DBT_USERDEFINED = 0xFFFF;
        public const int DBT_DEVICEQUERYREMOVE = 0x8001;

        public const int DBT_DEVNODES_CHANGED = 0x0007; // A device has been added to or removed from the system
                                                                                                                 
        public const int DBT_DEVTYP_PORT = 0x00000003;      // serial, parallel

        private const int DbtDevtypDeviceinterface = 5;
        private static readonly Guid GuidDevinterfaceUSBDevice = new Guid("A5DCBF10-6530-11D2-901F-00C04FB951ED"); // USB devices
        private static IntPtr notificationHandle;

        /// <summary>
        /// Registers a window to receive notifications when USB devices are plugged or unplugged.
        /// </summary>
        /// <param name="windowHandle">Handle to the window receiving notifications.</param>
        public static void RegisterUsbDeviceNotification(IntPtr windowHandle)
        {
            DevBroadcastDeviceinterface dbi = new DevBroadcastDeviceinterface
            {
                DeviceType = DbtDevtypDeviceinterface,
                Reserved = 0,
                ClassGuid = GuidDevinterfaceUSBDevice,
                Name = 0
            };

            dbi.Size = Marshal.SizeOf(dbi);
            IntPtr buffer = Marshal.AllocHGlobal(dbi.Size);
            Marshal.StructureToPtr(dbi, buffer, true);

            notificationHandle = RegisterDeviceNotification(windowHandle, buffer, 0);

             
        }

        /// <summary>
        /// Unregisters the window for USB device notifications
        /// </summary>
        public static void UnregisterUsbDeviceNotification()
        {
            UnregisterDeviceNotification(notificationHandle);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr RegisterDeviceNotification(IntPtr recipient, IntPtr notificationFilter, int flags);

        [DllImport("user32.dll")]
        private static extern bool UnregisterDeviceNotification(IntPtr handle);

        [StructLayout(LayoutKind.Sequential)]
        private struct DevBroadcastDeviceinterface
        {
            internal int Size;
            internal int DeviceType;
            internal int Reserved;
            internal Guid ClassGuid;
            internal short Name;
        }

    }
}
