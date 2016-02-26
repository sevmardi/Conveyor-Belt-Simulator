using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S7.Net;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        S7.Net.Plc plc;

        public Form1()
        {
            InitializeComponent();

            // new timer

            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            t.Interval = 150;
            t.Tick += new EventHandler(timer_Tick);
            t.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            CpuType cputype = S7.Net.CpuType.S71500;
            String cpuip = "192.168.2.16";
            short spurack = 0;
            short cpuslot = 1;
            using (var plc = new Plc(cputype, cpuip, spurack, cpuslot))
            {
                if (plc.IsAvailable)
                {
                    ErrorCode connectionResult = plc.Open();
                    //MessageBox.Show("PLC connected", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    if (connectionResult.Equals(ErrorCode.NoError))
                    {
                        // get data
                        label1.Text = plc.Read("QW162").ToString();
                    }
                    else
                    {
                        MessageBox.Show("Device available but connection failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Device unavailable", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
