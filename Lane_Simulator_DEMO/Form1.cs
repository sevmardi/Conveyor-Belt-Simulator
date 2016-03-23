using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Snap7;

namespace CSClient
{

    public partial class MainForm : Form
    {
        private S7Client Client;
        private byte[] Buffer = new byte[65536];
        
        //Inputs
        public static int Start_Button = 95;
        public static int Stop_Button = 94;
       
         // outputs 
        public static int StartButton = 95;
        public static int StopButton = 94;
        
        public static int System_Reset = 93;
        // Merkers
        public static int System_Start = 7336;
        public static int System_Stop = 7337;


        private void ShowResult(int Result)
        {
            // This function returns a textual explaination of the error code
            TextError.Text = Client.ErrorText(Result);
        }

        public MainForm()
        {
            InitializeComponent();
            Client = new S7Client();
            if (IntPtr.Size == 4)
                this.Text = this.Text + " - Running 32 bit Code";
            else
                this.Text = this.Text + " - Running 64 bit Code";

            //CBType.SelectedIndex = 0;
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            int Result;
            int Rack = System.Convert.ToInt32(TxtRack.Text);
            int Slot = System.Convert.ToInt32(TxtSlot.Text);
            Result = Client.ConnectTo(TxtIP.Text, Rack, Slot);
            ShowResult(Result);
            
            if (Result == 0)
            {
                
                // Make connection with PLC using IP, slot, etc..
                TxtIP.Enabled = false;
                TxtRack.Enabled = false;
                TxtSlot.Enabled = false;
                ConnectBtn.Enabled = false;
                DisconnectBtn.Enabled = true;

                AddressField.Enabled = true;
                ValueField.Enabled = false;
              
                WriteBtn.Enabled = true;
                ReadBtn.Enabled = true;

                ComboBox1.Enabled = true;

            }
        }

        private void DisconnectBtn_Click(object sender, EventArgs e)
        {
            Client.Disconnect();
            TxtIP.Enabled = true;
            TxtRack.Enabled = true;
            TxtSlot.Enabled = true;
            ConnectBtn.Enabled = true;
            DisconnectBtn.Enabled = false;

            AddressField.Enabled = false;
            ValueField.Enabled = false;
           
            WriteBtn.Enabled = false;
            ReadBtn.Enabled = false;

            ComboBox1.Enabled = false;

        }




       

        private void WriteBtn_Click(object sender, EventArgs e)
        {
            if (ComboBox1.SelectedItem == "Inputs")
            {
                InputWrite();
            }
            if (ComboBox1.SelectedItem == "Outputs")
            {
                OutputWrite();
            }
        }

        private void ReadBtn_Click(object sender, EventArgs e)
        {
            if (ComboBox1.SelectedItem == "Inputs")
            {
                ValueField.Enabled = true;
                InputRead();
            }
            if (ComboBox1.SelectedItem == "Outputs")
            {
                OutputRead();
            }
        }

 
        private void InputRead()
        {
            // Declaration separated from the code for readability
            int DBNumber = 0;
            int start;
            int amount = 1;
            byte[] buffer = new byte[1];

            int area = S7Client.S7AreaPE;
            int Result;
            start = System.Convert.ToInt32(AddressField.Text);

            Result = Client.ReadArea(area, DBNumber, start, amount, S7Client.S7WLBit, buffer);

            if (Result == 0)
            {
                if (start == Start_Button)
                {
                    if (buffer[0] == 1)
                    {
                        Start_Button_Panel.BackColor = Color.Green;
                    }

                    else
                    {
                        Start_Button_Panel.BackColor = Color.DarkGray;
                    }
                }
                if (start == Stop_Button)
                {
                    if (buffer[0] == 1)
                    {
                        Stop_Button_Panel.BackColor = Color.Green;
                    }

                    else
                    {
                        Stop_Button_Panel.BackColor = Color.DarkGray;
                    }
                }

                if (start == System_Reset)
                {
                    if (buffer[0] == 1)
                    {
                        System_Button_Panel.BackColor = Color.Green;
                    }

                    else
                    {
                        System_Button_Panel.BackColor = Color.DarkGray;
                    }
                }

            }

        }


        private void InputWrite()
        {
            int DBNumber = 0;
            int amount = 1;
            int start;
            int area = S7Client.S7AreaPE;
            int Result;
            start = System.Convert.ToInt32(AddressField.Text);

            byte[] buffer = new byte[1];

            Byte.TryParse(ValueField.Text, out buffer[0]);

            Result = Client.WriteArea(S7Client.S7AreaPE, DBNumber, start, amount, S7Client.S7WLBit, buffer);
            
            if (Result == 0)
            {
                if (start == Start_Button)
                {
                    if (buffer[0] == 1)
                    {
                        Start_Button_Panel.BackColor = Color.Green;
                    }

                    else
                    {
                        Start_Button_Panel.BackColor = Color.DarkGray;
                    }
                }
                if (start == Stop_Button)
                {
                    if (buffer[0] == 1)
                    {
                        Stop_Button_Panel.BackColor = Color.Green;
                    }

                    else
                    {
                        Stop_Button_Panel.BackColor = Color.DarkGray;
                    }
                }

                if (start == System_Reset)
                {
                    if (buffer[0] == 1)
                    {
                        System_Button_Panel.BackColor = Color.Green;
                    }

                    else
                    {
                        System_Button_Panel.BackColor = Color.DarkGray;
                    }
                }
                
            }
      
        }



        private void OutputRead()
        {
            int DBNumber = 0;
            int amount = 1;
            int start;
            int area = S7Client.S7AreaPA;
            int Result;

            start = System.Convert.ToInt32(AddressField.Text);

            byte[] buffer = new byte[1];
            
            Byte.TryParse(ValueField.Text, out buffer[0]);

            Result = Client.ReadArea(area, DBNumber, start, amount, S7Client.S7WLBit, buffer);
        }


        private void OutputWrite()
        {
            // Declaration separated from the code for readability
            int DBNumber = 0;
            int amount = 1;
            int start;
            int area = S7Client.S7AreaPA;
            int Result;
            start = System.Convert.ToInt32(AddressField.Text);

            byte[] buffer = new byte[1];

            Byte.TryParse(ValueField.Text, out buffer[0]);
            
        
            Result = Client.WriteArea(area, DBNumber, start, amount, S7Client.S7WLBit, buffer);

            if (Result == 0)
            {
                if (start == StartButton)
                {
                    if (buffer[0] == 1)
                    {
                        StartButtonPanel.BackColor = Color.Green;
                    }

                    else
                    {
                        StartButtonPanel.BackColor = Color.DarkGray;
                    }
                }
                if (start == StopButton)
                {
                    if (buffer[0] == 1)
                    {
                        StopButtonPanel.BackColor = Color.Green;
                    }

                    else
                    {
                        StopButtonPanel.BackColor = Color.DarkGray;
                    }
                }
            }
            
            OutputRead();
      
        }



        private void realTimeSimulation()
        {
            int DBNumber = 0;
            int amount = 1;
            int start;
            int area = S7Client.S7AreaPA;
            int Result;
            start = System.Convert.ToInt32(AddressField.Text);

            byte[] buffer = new byte[1];

            Byte.TryParse(ValueField.Text, out buffer[0]);

            Result = Client.ReadArea(area, DBNumber, start, amount, S7Client.S7WLBit, buffer);

            if (Result == 0)
            {
      
            }
        }


  

    }
}


