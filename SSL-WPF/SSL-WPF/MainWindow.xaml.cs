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
using SSL_WPF.MainPanel;

namespace SSL_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private S7Client Client;
        private byte[] Buffer = new byte[65536];

        public MainWindow()
        {
            InitializeComponent();
            Client = new S7Client();
           
        }

        private void ConnectBtn_Click(object sender, RoutedEventArgs e)
        {
            int Result;
            int Rack = System.Convert.ToInt32(TxtRack.Text);
            int Slot = System.Convert.ToInt32(TxtSlot.Text);

            Result = Client.ConnectTo(TxtIP.Text, Rack, Slot);

            if (Result == 0)
            {
                // Make connection with PLC using IP, slot, etc..
               
            }
            else
            {
                MessageBox.Show("Not right");
            }
        }
    }
}
