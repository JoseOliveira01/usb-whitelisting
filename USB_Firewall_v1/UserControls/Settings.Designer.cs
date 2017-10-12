namespace USB_Firewall_v1
{
    partial class Settings
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
            this.notify_check = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.processnotify_check = new System.Windows.Forms.CheckBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.blockdevices = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notify_check
            // 
            this.notify_check.AutoSize = true;
            this.notify_check.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notify_check.Location = new System.Drawing.Point(67, 262);
            this.notify_check.Name = "notify_check";
            this.notify_check.Size = new System.Drawing.Size(461, 25);
            this.notify_check.TabIndex = 0;
            this.notify_check.Text = "Send notification each time a new device is connected";
            this.notify_check.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(596, 94);
            this.panel1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DarkMagenta;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(175, 40);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(421, 25);
            this.panel4.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(63, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Settings";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.DarkMagenta;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 40);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(26, 25);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 65);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(596, 29);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(596, 40);
            this.panel2.TabIndex = 0;
            // 
            // processnotify_check
            // 
            this.processnotify_check.AutoSize = true;
            this.processnotify_check.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.processnotify_check.Location = new System.Drawing.Point(67, 311);
            this.processnotify_check.Name = "processnotify_check";
            this.processnotify_check.Size = new System.Drawing.Size(423, 25);
            this.processnotify_check.TabIndex = 2;
            this.processnotify_check.Text = "Send notification each time a new process is found";
            this.processnotify_check.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(67, 133);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(385, 25);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Allow every new device (Not Recommended)";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // blockdevices
            // 
            this.blockdevices.AutoSize = true;
            this.blockdevices.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blockdevices.Location = new System.Drawing.Point(67, 189);
            this.blockdevices.Name = "blockdevices";
            this.blockdevices.Size = new System.Drawing.Size(153, 25);
            this.blockdevices.TabIndex = 5;
            this.blockdevices.TabStop = true;
            this.blockdevices.Text = "Block all devices";
            this.blockdevices.UseVisualStyleBackColor = true;
            this.blockdevices.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.blockdevices);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.processnotify_check);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.notify_check);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(596, 433);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox notify_check;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox processnotify_check;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton blockdevices;
    }
}
