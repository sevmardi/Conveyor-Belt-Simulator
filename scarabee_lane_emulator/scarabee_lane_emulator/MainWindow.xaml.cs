using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Drawing;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using Snap7;


namespace scarabee_lane_emulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Form
    {

        private S7Client Client;
        private byte[] Buffer = new byte[65536];


        private void ShowResult(int Result)
        {
            // This function returns a textual explaination of the error code
            TextError.Text = Client.ErrorText(Result);
        }

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
