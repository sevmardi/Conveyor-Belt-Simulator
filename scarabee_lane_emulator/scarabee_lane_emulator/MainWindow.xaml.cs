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
using S7.Net;

namespace scarabee_lane_emulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    
    public partial class MainWindow : Window
    {

      //  Dim Buffer(65536) as byte

        public MainWindow()
        {
            InitializeComponent();
           // Client = new S7Client();

            if (IntPtr.Size == 4)
            {
                //Text = 
            }
            else
            {
                 //Text = Text + " - Running 64 bit Code"
            }

        }

        private void ConnectBtn_Click()
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
