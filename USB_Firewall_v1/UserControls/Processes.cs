using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace USB_Firewall_v1
{
    public partial class Processes : UserControl
    {
        private List<Process> pl;
        Thread _processesSearch;
        List<Process> savedList;
        List<int> popUps;  

        private static Processes _instance;

        public static Processes Instance
        {
            get
            {
                if (_instance == null) _instance = new Processes();
                return _instance;
            }
        }

        public Processes()
        {
            InitializeComponent();

            pl = new List<Process>();
            savedList = new List<Process>();
            popUps = new List<int>();

            _processesSearch = new Thread(ProcessesSearch);
            _processesSearch.Start();

            dataGridView1.Font = new System.Drawing.Font("Century Gothic", 11); // the Media namespace
            dataGridView1.DefaultCellStyle.BackColor = dataGridView1.GridColor;

            Padding newPadding = new Padding(0, 3, 0, 3);
            this.dataGridView1.RowTemplate.DefaultCellStyle.Padding = newPadding;
            this.dataGridView1.RowTemplate.Height += 20;

        }

        public void UpdateList()
        {
            //listBox1.Items.Clear();
            

            dataGridView1.Rows.Clear();

            List<Process> processList = new List<Process>();
            processList.Clear();
            processList.AddRange(pl);

            if (processList.Count > 0)
            {
                foreach (var p in processList)
                {
                    try
                    {
                        /* listBox1.Items.Add(p.ProcessName + " " + p.MainModule.FileName);   
                         listBox1.Items.Add(" ");        */

                        if (!p.HasExited)
                        {
                            int row = dataGridView1.Rows.Add();
                            dataGridView1.Rows[row].Cells["id_column"].Value = p.Id;
                            dataGridView1.Rows[row].Cells["name_column"].Value = p.ProcessName;
                            dataGridView1.Rows[row].Cells["path_column"].Value = p.MainModule.FileName;
                            dataGridView1.Rows[row].Tag = p;
                        }
                    }
                    catch (Exception e)
                    {
                        /*listBox1.Items.Add(" PROBLEM DETECTED ");
                        listBox1.Items.Add(" "); */
                    }
                }

            }
            else Console.WriteLine("asssssssssssssssssssssssssss");
        }

        private void ProcessesSearch()
        {
            while (true)
            {
                savedList = new List<Process>();
                savedList.Clear();

                pl.Clear();


                // Get all processes running         

                List<Process> currentProcesses = new List<Process>(Process.GetProcesses());  

                foreach (Process p in currentProcesses)
                {
                    try
                    {
                        if(DriveInfo.GetDrives().Count()>0)
                        foreach (DriveInfo d in DriveInfo.GetDrives())
                        {
                            
                            if (p != null || !p.HasExited)
                                try
                                    {
                                        if (p.MainModule.FileName.Contains(d.Name) && d.DriveType == DriveType.Removable)
                                        {
                                            pl.Add(p);
                                            if (!Settings.Instance.AllowProcessNotifications())
                                            {
                                                savedList.Add(p);
                                            }
                                            //CheckDifference();
                                        }
                                    }    catch(InvalidOperationException test)
                                    {
                                        Console.WriteLine("[1]Process ended");
                                        Console.WriteLine(test);
                                    }
                        }

                    }
                    catch (Win32Exception e) { }
                }

                /*   try
                    {
                        if (DriveInfo.GetDrives().Count() > 0)
                        {
                            foreach (DriveInfo d in DriveInfo.GetDrives().Where(drive => drive.DriveType == DriveType.Removable))
                            {
                                Console.WriteLine(d.DriveType + " " + d.Name + " " + d.VolumeLabel);
                                try
                                {             
                                    List<Process> lgp = new List<Process>();

                                    // Save Processes 
                                    List<Process> currentProcesses = new List<Process>(Process.GetProcesses());
                                    foreach (var p in currentProcesses)
                                    {
                                        if (p.MainModule.FileName.Contains(d.Name))
                                        {
                                            lgp.Add(p);
                                        }
                                    }

                                        foreach (Process p in lgp)
                                    {     
                                        Console.WriteLine(p.MachineName);
                                        pl.Add(p);
                                        if (!Settings.Instance.AllowProcessNotifications())
                                        {   
                                            savedList.Add(p);
                                        }
                                        //else CheckDifference();
                                    }
                                }    catch(Win32Exception e) { Console.WriteLine(e); }
                            }
                        }

                    }
                    catch (Win32Exception ex) { }  */

               // foreach (var p in Process.GetProcesses()) Console.WriteLine(p.ProcessName + " " + p.MainModule.FileName);
 
                //dataGridView1.Invalidate();
                Thread.Sleep(1000);
            }
        }


        public void AbortThread()
        {
            _processesSearch.Abort();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("details_column"))
            {   
                Process p = (Process)dataGridView1.Rows[e.RowIndex].Tag;
                 if (MessageBox.Show("Terminate process? \n" + p.ProcessName, "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    pl.Remove(p);
                    p.Kill();
                    dataGridView1.Invalidate();           
                }
            }
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Processes_Load(object sender, EventArgs e)
        {
            UpdateList();
        }

       /*
        private void CheckDifference()
        {
            List<Process> oldProcesses = new List<Process>();
            List<Process> repeated = new List<Process>();
            List<Process> markToDeath = new List<Process>();
                              
            if (pl.Count > oldProcesses.Count)
            {
                // Found new Process
                foreach (var p in pl)
                {
                    foreach (var p1 in oldProcesses)
                    {
                        if (p.Id == p1.Id) repeated.Add(p);
                    }
                }
            }

            oldProcesses.Clear();
            oldProcesses.AddRange(pl);

            IEnumerable<Process> newProcess = oldProcesses.Except(repeated);
            foreach (Process p in newProcess)
            {
                  if(savedList.Count>0)
                    foreach (var p1 in savedList)
                    {
                        Console.WriteLine("Process : " + p.Id + " Saved...");
                        if (p.Id != p1.Id)
                        {
                            Console.WriteLine(" New Process : " + p.ProcessName);
                            if (Settings.Instance.AllowProcessNotifications())
                            {
                                // Notify user of new process income
                                if (MessageBox.Show("Terminate process? \n" + p.ProcessName, "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                                {
                                    markToDeath.Add(p);
                                }
                                else
                                {
                                    // Keep it active
                                    savedList.Add(p);
                                    Console.WriteLine("Process : " + p.Id + " Saved...22222");
                                }
                            }
                        }
                    }

                
            }

            for (int i = 0; i < markToDeath.Count; i++)
            {
                markToDeath[i].Kill();
            }

            oldProcesses.Clear();
            oldProcesses.AddRange(pl);
        }   */
    }
}
