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
    public partial class Settings : UserControl
    {
        private static Settings _instance;

        public static Settings Instance
        {
            get
            {
                if (_instance == null) _instance = new Settings();
                return _instance;
            }
        }

        public Settings()
        {
            InitializeComponent();

            blockdevices.Checked = true;
        }

        public bool AllowNotifications()
        {
            return notify_check.Checked;
        }

        public bool AllowProcessNotifications()
        {
            return processnotify_check.Checked;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                notify_check.Checked = false;
                processnotify_check.Checked = false;

                notify_check.Enabled = false;
                processnotify_check.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (blockdevices.Checked)
            {
                notify_check.Enabled = true;
                processnotify_check.Enabled = true;
            }
        }
    }
}
