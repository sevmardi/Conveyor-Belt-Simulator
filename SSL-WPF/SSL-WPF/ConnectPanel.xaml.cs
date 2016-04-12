using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Snap7;


namespace SSL_WPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ConnectPanel : Window
    {
        private S7Client Client;
        private byte[] Buffer = new byte[65536];

        public ConnectPanel()
        {
            InitializeComponent();
            Client = new S7Client();
        }

        private void ConnectBtn_Click(object sender, RoutedEventArgs e)
        {
            // Make connection with PLC using IP, slot, etc..
            //int Result;
            //int Rack = System.Convert.ToInt32(TxtRack.Text);
            //int Slot = System.Convert.ToInt32(TxtSlot.Text);

            //Result = Client.ConnectTo(TxtIP.Text, Rack, Slot);

            //if (Result == 0)
            //{
                
            //    DialogResult = true;
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Not right");
            //}

          
            DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
