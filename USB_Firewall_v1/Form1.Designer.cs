namespace USB_Firewall_v1
{
    partial class usbfirewall_form
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usbfirewall_form));
            this.Header_panel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.exitpanel = new System.Windows.Forms.Panel();
            this.contentpanel = new System.Windows.Forms.Panel();
            this.Logo_panel = new System.Windows.Forms.Panel();
            this.AppName = new System.Windows.Forms.Label();
            this.devicespanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pendingdevicespanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.processespanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.settingspanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.Options_panel = new System.Windows.Forms.Panel();
            this.Header_panel.SuspendLayout();
            this.Logo_panel.SuspendLayout();
            this.devicespanel.SuspendLayout();
            this.pendingdevicespanel.SuspendLayout();
            this.processespanel.SuspendLayout();
            this.settingspanel.SuspendLayout();
            this.Options_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Header_panel
            // 
            this.Header_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.Header_panel.Controls.Add(this.panel1);
            this.Header_panel.Controls.Add(this.exitpanel);
            this.Header_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header_panel.Location = new System.Drawing.Point(200, 0);
            this.Header_panel.Name = "Header_panel";
            this.Header_panel.Size = new System.Drawing.Size(635, 61);
            this.Header_panel.TabIndex = 1;
            this.Header_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WindowMouseDown);
            this.Header_panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WindowMouseMove);
            this.Header_panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WindowMouseUp);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(530, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(52, 61);
            this.panel1.TabIndex = 1;
            this.panel1.Click += new System.EventHandler(this.Minimize);
            // 
            // exitpanel
            // 
            this.exitpanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exitpanel.BackgroundImage")));
            this.exitpanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.exitpanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.exitpanel.Location = new System.Drawing.Point(582, 0);
            this.exitpanel.Name = "exitpanel";
            this.exitpanel.Size = new System.Drawing.Size(53, 61);
            this.exitpanel.TabIndex = 0;
            this.exitpanel.Click += new System.EventHandler(this.Exit);
            // 
            // contentpanel
            // 
            this.contentpanel.BackColor = System.Drawing.Color.Gainsboro;
            this.contentpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentpanel.Location = new System.Drawing.Point(200, 61);
            this.contentpanel.Name = "contentpanel";
            this.contentpanel.Size = new System.Drawing.Size(635, 446);
            this.contentpanel.TabIndex = 2;
            // 
            // Logo_panel
            // 
            this.Logo_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(126)))), ((int)(((byte)(49)))));
            this.Logo_panel.Controls.Add(this.AppName);
            this.Logo_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Logo_panel.Location = new System.Drawing.Point(0, 0);
            this.Logo_panel.Name = "Logo_panel";
            this.Logo_panel.Size = new System.Drawing.Size(200, 61);
            this.Logo_panel.TabIndex = 0;
            this.Logo_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.WindowMouseDown);
            this.Logo_panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WindowMouseMove);
            this.Logo_panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.WindowMouseUp);
            // 
            // AppName
            // 
            this.AppName.AutoSize = true;
            this.AppName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppName.ForeColor = System.Drawing.Color.White;
            this.AppName.Location = new System.Drawing.Point(62, 20);
            this.AppName.Name = "AppName";
            this.AppName.Size = new System.Drawing.Size(122, 25);
            this.AppName.TabIndex = 0;
            this.AppName.Text = "Plug&&Pray";
            // 
            // devicespanel
            // 
            this.devicespanel.Controls.Add(this.label1);
            this.devicespanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.devicespanel.Location = new System.Drawing.Point(0, 61);
            this.devicespanel.Name = "devicespanel";
            this.devicespanel.Size = new System.Drawing.Size(200, 62);
            this.devicespanel.TabIndex = 1;
            this.devicespanel.Click += new System.EventHandler(this.GetDevices);
            this.devicespanel.MouseLeave += new System.EventHandler(this.ChangeColorLeaveEvent);
            this.devicespanel.MouseHover += new System.EventHandler(this.ChangeColorHoverEvent);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(23, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Devices";
            this.label1.Click += new System.EventHandler(this.GetDevices);
            // 
            // pendingdevicespanel
            // 
            this.pendingdevicespanel.Controls.Add(this.label2);
            this.pendingdevicespanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pendingdevicespanel.Location = new System.Drawing.Point(0, 123);
            this.pendingdevicespanel.Name = "pendingdevicespanel";
            this.pendingdevicespanel.Size = new System.Drawing.Size(200, 62);
            this.pendingdevicespanel.TabIndex = 2;
            this.pendingdevicespanel.Click += new System.EventHandler(this.GetPendingDevices);
            this.pendingdevicespanel.MouseLeave += new System.EventHandler(this.ChangeColorLeaveEvent);
            this.pendingdevicespanel.MouseHover += new System.EventHandler(this.ChangeColorHoverEvent);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(23, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Pending Devices";
            this.label2.Click += new System.EventHandler(this.GetPendingDevices);
            // 
            // processespanel
            // 
            this.processespanel.Controls.Add(this.label3);
            this.processespanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.processespanel.Location = new System.Drawing.Point(0, 185);
            this.processespanel.Name = "processespanel";
            this.processespanel.Size = new System.Drawing.Size(200, 62);
            this.processespanel.TabIndex = 3;
            this.processespanel.Click += new System.EventHandler(this.GetProcesses);
            this.processespanel.MouseLeave += new System.EventHandler(this.ChangeColorLeaveEvent);
            this.processespanel.MouseHover += new System.EventHandler(this.ChangeColorHoverEvent);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.LightGray;
            this.label3.Location = new System.Drawing.Point(23, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Processes";
            this.label3.Click += new System.EventHandler(this.GetProcesses);
            // 
            // settingspanel
            // 
            this.settingspanel.Controls.Add(this.label4);
            this.settingspanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.settingspanel.Location = new System.Drawing.Point(0, 247);
            this.settingspanel.Name = "settingspanel";
            this.settingspanel.Size = new System.Drawing.Size(200, 64);
            this.settingspanel.TabIndex = 4;
            this.settingspanel.Click += new System.EventHandler(this.GetSettings);
            this.settingspanel.MouseLeave += new System.EventHandler(this.ChangeColorLeaveEvent);
            this.settingspanel.MouseHover += new System.EventHandler(this.ChangeColorHoverEvent);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.LightGray;
            this.label4.Location = new System.Drawing.Point(27, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Settings";
            this.label4.Click += new System.EventHandler(this.GetSettings);
            // 
            // Options_panel
            // 
            this.Options_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.Options_panel.Controls.Add(this.settingspanel);
            this.Options_panel.Controls.Add(this.processespanel);
            this.Options_panel.Controls.Add(this.pendingdevicespanel);
            this.Options_panel.Controls.Add(this.devicespanel);
            this.Options_panel.Controls.Add(this.Logo_panel);
            this.Options_panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.Options_panel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Options_panel.Location = new System.Drawing.Point(0, 0);
            this.Options_panel.Name = "Options_panel";
            this.Options_panel.Size = new System.Drawing.Size(200, 507);
            this.Options_panel.TabIndex = 0;
            // 
            // usbfirewall_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(835, 507);
            this.Controls.Add(this.contentpanel);
            this.Controls.Add(this.Header_panel);
            this.Controls.Add(this.Options_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "usbfirewall_form";
            this.Text = "Form1";
            this.Header_panel.ResumeLayout(false);
            this.Logo_panel.ResumeLayout(false);
            this.Logo_panel.PerformLayout();
            this.devicespanel.ResumeLayout(false);
            this.devicespanel.PerformLayout();
            this.pendingdevicespanel.ResumeLayout(false);
            this.pendingdevicespanel.PerformLayout();
            this.processespanel.ResumeLayout(false);
            this.processespanel.PerformLayout();
            this.settingspanel.ResumeLayout(false);
            this.settingspanel.PerformLayout();
            this.Options_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Header_panel;
        private System.Windows.Forms.Panel exitpanel;
        private System.Windows.Forms.Panel contentpanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel Logo_panel;
        private System.Windows.Forms.Label AppName;
        private System.Windows.Forms.Panel devicespanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pendingdevicespanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel processespanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel settingspanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel Options_panel;
    }
}

