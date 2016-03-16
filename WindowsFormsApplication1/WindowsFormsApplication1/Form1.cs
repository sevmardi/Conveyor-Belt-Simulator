using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Snap7;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        static S7Client Client;
        private byte[] Buffer = new byte[1];

        private void ShowResult(int Result)
        {
            // This function returns a textual explaination of the error code
           // TextError.Text = Client.ErrorText(Result);
        }


        public Form1()
        {
            InitializeComponent();
            Client = new S7Client();
            if (IntPtr.Size == 4)
                this.Text = this.Text + " - Running 32 bit Code";
            else
                this.Text = this.Text + " - Running 64 bit Code";

           // CBType.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            Client.ConnectTo("192.168.2.16",0,0);
            Client.WriteArea(S7Client.S7AreaPA, 0, 8, 1, S7Client.S7WLBit, Buffer);
            Client = null;
        }

        private void TextError_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
