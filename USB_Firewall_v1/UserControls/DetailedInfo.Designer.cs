namespace USB_Firewall_v1
{
    partial class DetailedInfo
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.hardwareIDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.compatibleIDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.devicename = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.details_list = new System.Windows.Forms.ListBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnpDeviceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.hardwareIDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compatibleIDBindingSource)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnpDeviceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // hardwareIDBindingSource
            // 
            this.hardwareIDBindingSource.DataMember = "HardwareID";
            this.hardwareIDBindingSource.DataSource = this.pnpDeviceBindingSource;
            // 
            // compatibleIDBindingSource
            // 
            this.compatibleIDBindingSource.DataMember = "CompatibleID";
            this.compatibleIDBindingSource.DataSource = this.pnpDeviceBindingSource;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 359);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(603, 25);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(603, 79);
            this.panel3.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.flowLayoutPanel3);
            this.panel5.Controls.Add(this.devicename);
            this.panel5.Controls.Add(this.flowLayoutPanel2);
            this.panel5.Controls.Add(this.panel1);
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(603, 94);
            this.panel5.TabIndex = 2;
            // 
            // devicename
            // 
            this.devicename.AutoSize = true;
            this.devicename.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.devicename.ForeColor = System.Drawing.Color.Black;
            this.devicename.Location = new System.Drawing.Point(42, 43);
            this.devicename.Name = "devicename";
            this.devicename.Size = new System.Drawing.Size(115, 21);
            this.devicename.TabIndex = 3;
            this.devicename.Text = "Device name";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 40);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(26, 25);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(603, 29);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(603, 40);
            this.panel2.TabIndex = 0;
            // 
            // details_list
            // 
            this.details_list.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.details_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.details_list.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.details_list.FormattingEnabled = true;
            this.details_list.ItemHeight = 20;
            this.details_list.Items.AddRange(new object[] {
            "Example"});
            this.details_list.Location = new System.Drawing.Point(26, 79);
            this.details_list.Name = "details_list";
            this.details_list.Size = new System.Drawing.Size(551, 280);
            this.details_list.TabIndex = 4;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(577, 79);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(26, 280);
            this.panel7.TabIndex = 6;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 79);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(26, 280);
            this.panel6.TabIndex = 7;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(422, 40);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(181, 25);
            this.flowLayoutPanel3.TabIndex = 4;
            // 
            // pnpDeviceBindingSource
            // 
            this.pnpDeviceBindingSource.DataSource = typeof(USB_Firewall_v1.PnpDevice);
            // 
            // DetailedInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.Controls.Add(this.details_list);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "DetailedInfo";
            this.Size = new System.Drawing.Size(603, 384);
            this.Load += new System.EventHandler(this.DetailedInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hardwareIDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compatibleIDBindingSource)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnpDeviceBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource pnpDeviceBindingSource;
        private System.Windows.Forms.BindingSource hardwareIDBindingSource;
        private System.Windows.Forms.BindingSource compatibleIDBindingSource;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListBox details_list;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label devicename;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
    }
}
