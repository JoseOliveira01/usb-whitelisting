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
    public partial class PendingDevices : UserControl
    {
        List<PnpDevice> pd = new List<PnpDevice>();
            
        private static PendingDevices _instance;

        public static PendingDevices Instance
        {
            get
            {
                if (_instance == null) _instance = new PendingDevices();
                return _instance;
            }
        }

        public PendingDevices()
        {
            InitializeComponent();

            dataGridView1.Font = new System.Drawing.Font("Century Gothic", 11); // the Media namespace
            dataGridView1.DefaultCellStyle.BackColor = dataGridView1.GridColor;

            Padding newPadding = new Padding(0, 3, 0, 3);
            this.dataGridView1.RowTemplate.DefaultCellStyle.Padding = newPadding;
            this.dataGridView1.RowTemplate.Height += 20;
        }



        public void SetPendingDevices(List<PnpDevice> l)
        {
            pd.Clear();
            pd = new List<PnpDevice>();
            pd.AddRange(l);

            dataGridView1.Rows.Clear();
            foreach(var d in l)
            {
                /*listBox1.Items.Add(d.Name);
                listBox1.Items.Add("");  */

                int row = dataGridView1.Rows.Add();
                dataGridView1.Rows[row].Cells["name_column"].Value = d.Name;
                dataGridView1.Rows[row].Cells["class_column"].Value = d.PNPClass;
                dataGridView1.Rows[row].Tag = d;
            }
        }

        public void UpdateList()
        {
            SetPendingDevices(Devices.Instance.GetPendingDeviceList());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("details_column"))
            {
                PnpDevice p = (PnpDevice)dataGridView1.Rows[e.RowIndex].Tag;

                if (p.CompatibleID.Length > 0)
                {
                    // Notify user of new device income
                    AutoPlay auto = new AutoPlay(p);
                    auto.Show();

                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
