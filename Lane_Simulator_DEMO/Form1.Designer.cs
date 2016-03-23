namespace CSClient
{
    partial class MainForm
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
            this.DisconnectBtn = new System.Windows.Forms.Button();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.TxtSlot = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.TxtRack = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.TxtIP = new System.Windows.Forms.TextBox();
            this.TextError = new System.Windows.Forms.TextBox();
            this.ReadBtn = new System.Windows.Forms.Button();
            this.WriteBtn = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.AddressField = new System.Windows.Forms.TextBox();
            this.ValueField = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Label20 = new System.Windows.Forms.Label();
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.Label18 = new System.Windows.Forms.Label();
            this.Txt_System_Stop = new System.Windows.Forms.Label();
            this.StartButtonPanel = new System.Windows.Forms.Panel();
            this.Txt_System_Start = new System.Windows.Forms.Label();
            this.StopButtonPanel = new System.Windows.Forms.Panel();
            this.TxtStartButton = new System.Windows.Forms.Label();
            this.System_Start_Panel = new System.Windows.Forms.Panel();
            this.TxtStopButton = new System.Windows.Forms.Label();
            this.System_Button_Panel = new System.Windows.Forms.Panel();
            this.Txt_System_Reset = new System.Windows.Forms.Label();
            this.System_Reset_Panel = new System.Windows.Forms.Panel();
            this.Txt_Stop_Button = new System.Windows.Forms.Label();
            this.Stop_Button_Panel = new System.Windows.Forms.Panel();
            this.Txt_Start_Button = new System.Windows.Forms.Label();
            this.Start_Button_Panel = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DisconnectBtn
            // 
            this.DisconnectBtn.Enabled = false;
            this.DisconnectBtn.Location = new System.Drawing.Point(454, 25);
            this.DisconnectBtn.Name = "DisconnectBtn";
            this.DisconnectBtn.Size = new System.Drawing.Size(100, 23);
            this.DisconnectBtn.TabIndex = 31;
            this.DisconnectBtn.Text = "Disconnect";
            this.DisconnectBtn.UseVisualStyleBackColor = true;
            this.DisconnectBtn.Click += new System.EventHandler(this.DisconnectBtn_Click);
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(348, 25);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(100, 23);
            this.ConnectBtn.TabIndex = 26;
            this.ConnectBtn.Text = "Connect";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(234, 10);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(25, 13);
            this.Label3.TabIndex = 30;
            this.Label3.Text = "Slot";
            // 
            // TxtSlot
            // 
            this.TxtSlot.Location = new System.Drawing.Point(234, 28);
            this.TxtSlot.Name = "TxtSlot";
            this.TxtSlot.Size = new System.Drawing.Size(44, 20);
            this.TxtSlot.TabIndex = 25;
            this.TxtSlot.Text = "0";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(178, 10);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(33, 13);
            this.Label2.TabIndex = 27;
            this.Label2.Text = "Rack";
            // 
            // TxtRack
            // 
            this.TxtRack.Location = new System.Drawing.Point(178, 28);
            this.TxtRack.Name = "TxtRack";
            this.TxtRack.Size = new System.Drawing.Size(44, 20);
            this.TxtRack.TabIndex = 23;
            this.TxtRack.Text = "0";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(68, 10);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(58, 13);
            this.Label1.TabIndex = 24;
            this.Label1.Text = "IP Address";
            // 
            // TxtIP
            // 
            this.TxtIP.Location = new System.Drawing.Point(68, 28);
            this.TxtIP.Name = "TxtIP";
            this.TxtIP.Size = new System.Drawing.Size(100, 20);
            this.TxtIP.TabIndex = 22;
            this.TxtIP.Text = "192.168.2.16";
            // 
            // TextError
            // 
            this.TextError.BackColor = System.Drawing.Color.White;
            this.TextError.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TextError.ForeColor = System.Drawing.Color.Black;
            this.TextError.Location = new System.Drawing.Point(0, 447);
            this.TextError.Name = "TextError";
            this.TextError.ReadOnly = true;
            this.TextError.Size = new System.Drawing.Size(605, 20);
            this.TextError.TabIndex = 21;
            // 
            // ReadBtn
            // 
            this.ReadBtn.Enabled = false;
            this.ReadBtn.Location = new System.Drawing.Point(359, 328);
            this.ReadBtn.Name = "ReadBtn";
            this.ReadBtn.Size = new System.Drawing.Size(96, 23);
            this.ReadBtn.TabIndex = 53;
            this.ReadBtn.Text = "Read";
            this.ReadBtn.UseVisualStyleBackColor = true;
            this.ReadBtn.Click += new System.EventHandler(this.ReadBtn_Click);
            // 
            // WriteBtn
            // 
            this.WriteBtn.Enabled = false;
            this.WriteBtn.Location = new System.Drawing.Point(359, 368);
            this.WriteBtn.Name = "WriteBtn";
            this.WriteBtn.Size = new System.Drawing.Size(96, 23);
            this.WriteBtn.TabIndex = 63;
            this.WriteBtn.Text = "Write";
            this.WriteBtn.UseVisualStyleBackColor = true;
            this.WriteBtn.Click += new System.EventHandler(this.WriteBtn_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(26, 310);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(45, 13);
            this.label21.TabIndex = 66;
            this.label21.Text = "Address";
            // 
            // AddressField
            // 
            this.AddressField.Enabled = false;
            this.AddressField.Location = new System.Drawing.Point(25, 330);
            this.AddressField.Name = "AddressField";
            this.AddressField.Size = new System.Drawing.Size(119, 20);
            this.AddressField.TabIndex = 67;
            this.AddressField.Text = "0";
            // 
            // ValueField
            // 
            this.ValueField.Enabled = false;
            this.ValueField.Location = new System.Drawing.Point(24, 371);
            this.ValueField.Name = "ValueField";
            this.ValueField.Size = new System.Drawing.Size(119, 20);
            this.ValueField.TabIndex = 69;
            this.ValueField.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 353);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 68;
            this.label4.Text = "Value(byte)";
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.Location = new System.Drawing.Point(224, 310);
            this.Label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(31, 13);
            this.Label20.TabIndex = 82;
            this.Label20.Text = "Type";
            // 
            // ComboBox1
            // 
            this.ComboBox1.Enabled = false;
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.Items.AddRange(new object[] {
            "Inputs",
            "Outputs",
            "Flags"});
            this.ComboBox1.Location = new System.Drawing.Point(222, 329);
            this.ComboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(115, 21);
            this.ComboBox1.TabIndex = 83;
            this.ComboBox1.Text = "Inputs";
            // 
            // Label18
            // 
            this.Label18.AutoSize = true;
            this.Label18.Location = new System.Drawing.Point(152, 285);
            this.Label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(212, 13);
            this.Label18.TabIndex = 84;
            this.Label18.Text = "WRITING INPUT, OUTPUTS AND FLAGS";
            // 
            // Txt_System_Stop
            // 
            this.Txt_System_Stop.AutoSize = true;
            this.Txt_System_Stop.Location = new System.Drawing.Point(48, 206);
            this.Txt_System_Stop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Txt_System_Stop.Name = "Txt_System_Stop";
            this.Txt_System_Stop.Size = new System.Drawing.Size(108, 13);
            this.Txt_System_Stop.TabIndex = 116;
            this.Txt_System_Stop.Text = "System_Stop M917.1";
            // 
            // StartButtonPanel
            // 
            this.StartButtonPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.StartButtonPanel.Location = new System.Drawing.Point(24, 121);
            this.StartButtonPanel.Margin = new System.Windows.Forms.Padding(4);
            this.StartButtonPanel.Name = "StartButtonPanel";
            this.StartButtonPanel.Size = new System.Drawing.Size(16, 16);
            this.StartButtonPanel.TabIndex = 115;
            // 
            // Txt_System_Start
            // 
            this.Txt_System_Start.AutoSize = true;
            this.Txt_System_Start.Location = new System.Drawing.Point(48, 176);
            this.Txt_System_Start.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Txt_System_Start.Name = "Txt_System_Start";
            this.Txt_System_Start.Size = new System.Drawing.Size(108, 13);
            this.Txt_System_Start.TabIndex = 114;
            this.Txt_System_Start.Text = "System_Start M917.0";
            // 
            // StopButtonPanel
            // 
            this.StopButtonPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.StopButtonPanel.Location = new System.Drawing.Point(24, 148);
            this.StopButtonPanel.Margin = new System.Windows.Forms.Padding(4);
            this.StopButtonPanel.Name = "StopButtonPanel";
            this.StopButtonPanel.Size = new System.Drawing.Size(16, 16);
            this.StopButtonPanel.TabIndex = 113;
            // 
            // TxtStartButton
            // 
            this.TxtStartButton.AutoSize = true;
            this.TxtStartButton.Location = new System.Drawing.Point(48, 121);
            this.TxtStartButton.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TxtStartButton.Name = "TxtStartButton";
            this.TxtStartButton.Size = new System.Drawing.Size(92, 13);
            this.TxtStartButton.TabIndex = 112;
            this.TxtStartButton.Text = "StartButton Q11.7";
            // 
            // System_Start_Panel
            // 
            this.System_Start_Panel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.System_Start_Panel.Location = new System.Drawing.Point(24, 176);
            this.System_Start_Panel.Margin = new System.Windows.Forms.Padding(4);
            this.System_Start_Panel.Name = "System_Start_Panel";
            this.System_Start_Panel.Size = new System.Drawing.Size(16, 16);
            this.System_Start_Panel.TabIndex = 111;
            // 
            // TxtStopButton
            // 
            this.TxtStopButton.AutoSize = true;
            this.TxtStopButton.Location = new System.Drawing.Point(48, 148);
            this.TxtStopButton.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TxtStopButton.Name = "TxtStopButton";
            this.TxtStopButton.Size = new System.Drawing.Size(92, 13);
            this.TxtStopButton.TabIndex = 110;
            this.TxtStopButton.Text = "StopButton Q11.6";
            // 
            // System_Button_Panel
            // 
            this.System_Button_Panel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.System_Button_Panel.Location = new System.Drawing.Point(24, 206);
            this.System_Button_Panel.Margin = new System.Windows.Forms.Padding(4);
            this.System_Button_Panel.Name = "System_Button_Panel";
            this.System_Button_Panel.Size = new System.Drawing.Size(16, 16);
            this.System_Button_Panel.TabIndex = 109;
            // 
            // Txt_System_Reset
            // 
            this.Txt_System_Reset.AutoSize = true;
            this.Txt_System_Reset.Location = new System.Drawing.Point(244, 176);
            this.Txt_System_Reset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Txt_System_Reset.Name = "Txt_System_Reset";
            this.Txt_System_Reset.Size = new System.Drawing.Size(102, 13);
            this.Txt_System_Reset.TabIndex = 98;
            this.Txt_System_Reset.Text = "System_Reset I11.5";
            // 
            // System_Reset_Panel
            // 
            this.System_Reset_Panel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.System_Reset_Panel.Location = new System.Drawing.Point(220, 176);
            this.System_Reset_Panel.Margin = new System.Windows.Forms.Padding(4);
            this.System_Reset_Panel.Name = "System_Reset_Panel";
            this.System_Reset_Panel.Size = new System.Drawing.Size(16, 16);
            this.System_Reset_Panel.TabIndex = 97;
            // 
            // Txt_Stop_Button
            // 
            this.Txt_Stop_Button.AutoSize = true;
            this.Txt_Stop_Button.Location = new System.Drawing.Point(244, 148);
            this.Txt_Stop_Button.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Txt_Stop_Button.Name = "Txt_Stop_Button";
            this.Txt_Stop_Button.Size = new System.Drawing.Size(93, 13);
            this.Txt_Stop_Button.TabIndex = 96;
            this.Txt_Stop_Button.Text = "Stop_Button I11.6";
            // 
            // Stop_Button_Panel
            // 
            this.Stop_Button_Panel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Stop_Button_Panel.Location = new System.Drawing.Point(220, 148);
            this.Stop_Button_Panel.Margin = new System.Windows.Forms.Padding(4);
            this.Stop_Button_Panel.Name = "Stop_Button_Panel";
            this.Stop_Button_Panel.Size = new System.Drawing.Size(16, 16);
            this.Stop_Button_Panel.TabIndex = 95;
            // 
            // Txt_Start_Button
            // 
            this.Txt_Start_Button.AutoSize = true;
            this.Txt_Start_Button.Location = new System.Drawing.Point(244, 121);
            this.Txt_Start_Button.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Txt_Start_Button.Name = "Txt_Start_Button";
            this.Txt_Start_Button.Size = new System.Drawing.Size(93, 13);
            this.Txt_Start_Button.TabIndex = 94;
            this.Txt_Start_Button.Text = "Start_Button I11.7";
            // 
            // Start_Button_Panel
            // 
            this.Start_Button_Panel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Start_Button_Panel.Location = new System.Drawing.Point(220, 121);
            this.Start_Button_Panel.Margin = new System.Windows.Forms.Padding(4);
            this.Start_Button_Panel.Name = "Start_Button_Panel";
            this.Start_Button_Panel.Size = new System.Drawing.Size(16, 16);
            this.Start_Button_Panel.TabIndex = 93;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(162, 77);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(213, 13);
            this.label24.TabIndex = 117;
            this.label24.Text = "READING INPUT, OUTPUTS AND FLAGS";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 467);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.Txt_System_Stop);
            this.Controls.Add(this.StartButtonPanel);
            this.Controls.Add(this.Txt_System_Start);
            this.Controls.Add(this.StopButtonPanel);
            this.Controls.Add(this.TxtStartButton);
            this.Controls.Add(this.System_Start_Panel);
            this.Controls.Add(this.TxtStopButton);
            this.Controls.Add(this.System_Button_Panel);
            this.Controls.Add(this.Txt_System_Reset);
            this.Controls.Add(this.System_Reset_Panel);
            this.Controls.Add(this.Txt_Stop_Button);
            this.Controls.Add(this.Stop_Button_Panel);
            this.Controls.Add(this.Txt_Start_Button);
            this.Controls.Add(this.Start_Button_Panel);
            this.Controls.Add(this.Label18);
            this.Controls.Add(this.ComboBox1);
            this.Controls.Add(this.Label20);
            this.Controls.Add(this.ValueField);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.AddressField);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.WriteBtn);
            this.Controls.Add(this.ReadBtn);
            this.Controls.Add(this.DisconnectBtn);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.TxtSlot);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.TxtRack);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.TxtIP);
            this.Controls.Add(this.TextError);
            this.MaximumSize = new System.Drawing.Size(621, 99999);
            this.MinimumSize = new System.Drawing.Size(621, 38);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "C# Simple Demo App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button DisconnectBtn;
        internal System.Windows.Forms.Button ConnectBtn;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox TxtSlot;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox TxtRack;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox TxtIP;
        internal System.Windows.Forms.TextBox TextError;
        private System.Windows.Forms.Button ReadBtn;
        private System.Windows.Forms.Button WriteBtn;
        internal System.Windows.Forms.Label label21;
        internal System.Windows.Forms.TextBox AddressField;
        internal System.Windows.Forms.TextBox ValueField;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label Label20;
        internal System.Windows.Forms.ComboBox ComboBox1;
        internal System.Windows.Forms.Label Label18;
        internal System.Windows.Forms.Label Txt_System_Stop;
        internal System.Windows.Forms.Panel StartButtonPanel;
        internal System.Windows.Forms.Label Txt_System_Start;
        internal System.Windows.Forms.Panel StopButtonPanel;
        internal System.Windows.Forms.Label TxtStartButton;
        internal System.Windows.Forms.Panel System_Start_Panel;
        internal System.Windows.Forms.Label TxtStopButton;
        internal System.Windows.Forms.Panel System_Button_Panel;
        internal System.Windows.Forms.Label Txt_System_Reset;
        internal System.Windows.Forms.Panel System_Reset_Panel;
        internal System.Windows.Forms.Label Txt_Stop_Button;
        internal System.Windows.Forms.Panel Stop_Button_Panel;
        internal System.Windows.Forms.Label Txt_Start_Button;
        internal System.Windows.Forms.Panel Start_Button_Panel;
        internal System.Windows.Forms.Label label24;
    }
}

