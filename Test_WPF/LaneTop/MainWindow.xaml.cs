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
namespace LaneTop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
         private S7Client myclient;
        int amount = 1;
        int DBNumber = 0;
        int area;
        int wordlen = S7Client.S7WLBit;
        byte[] buffer = new byte[10];
        int res;

        static S7Client.S7DataItem[] items = new S7Client.S7DataItem[20];

        public MainWindow()
        {
            InitializeComponent();
          //  object_to_move.Visibility = Visibility.Hidden;
        }

        private void EstablishContact()
        {
            myclient = new S7Client();
            myclient.ConnectTo("192.168.2.16", 0, 0);

            if (myclient.Connected())
            {
                MessageBox.Show("Connection Established");
                stopsystem();
            }
            else
                MessageBox.Show("Something went wrong");

        }

        private void btnStartSystem_Click(object sender, RoutedEventArgs e)
        {
            if (myclient.Connected())
            {
                buffer[0] = 1;
                myclient.WriteArea(S7Client.S7AreaPE, DBNumber, 448, amount, wordlen, buffer);
                object_to_move.Visibility = Visibility.Visible;
                _0102_S1.Fill = new SolidColorBrush(Colors.Red);
                _0102_S2.Fill = new SolidColorBrush(Colors.Red);
                _0103_S1.Fill = new SolidColorBrush(Colors.Red);
                _0104_S1.Fill = new SolidColorBrush(Colors.Red);
                _0105_S1.Fill = new SolidColorBrush(Colors.Red);
                _0105_S2.Fill = new SolidColorBrush(Colors.Red);
                _0301_S1.Fill = new SolidColorBrush(Colors.Red);
                _0301_S2.Fill = new SolidColorBrush(Colors.Red);
                _0302_S1.Fill = new SolidColorBrush(Colors.Red);
                _0303_S1.Fill = new SolidColorBrush(Colors.Red);
                _0304_S1.Fill = new SolidColorBrush(Colors.Red);
                _0304_S2.Fill = new SolidColorBrush(Colors.Red);
                _0304_S3.Fill = new SolidColorBrush(Colors.Red);
                _0701_S1.Fill = new SolidColorBrush(Colors.Red);

                StartAnimation();
            }
        }



        private void btnRest_Click(object sender, RoutedEventArgs e)
        {
            object_to_move.Visibility = Visibility.Visible;
            buffer[0] = 1;
            myclient.WriteArea(S7Client.S7AreaMK, DBNumber, 7997, amount, wordlen, buffer);
        }

        private void btnStopSystem_Click(object sender, RoutedEventArgs e)
        {
            buffer[0] = 1;
            myclient.WriteArea(S7Client.S7AreaPE, DBNumber, 322, amount, wordlen, buffer);
            stopsystem();
        }

        protected void stopsystem()
        {
            buffer[0] = 0;
            myclient.WriteArea(S7Client.S7AreaPE, DBNumber, 448, amount, wordlen, buffer);
            object_to_move.Visibility = Visibility.Hidden;
        }

        private void btnConnectToPLC_Click(object sender, RoutedEventArgs e)
        {
            EstablishContact();
        }

        private void btnDisconnect_Click(object sender, RoutedEventArgs e)
        {
            myclient.Disconnect();
            MessageBox.Show("Disconnectd!");
            stopsystem();
        }

        private void StartAnimation()
        {
            //path139798.Freeze();
            //path139750.Freeze();
            //DoubleAnimationUsingPath daPath = new DoubleAnimationUsingPath();
            //daPath.Duration = TimeSpan.FromSeconds(5);
            //daPath.RepeatBehavior = RepeatBehavior.Forever;
            //daPath.AccelerationRatio = 0.6;
            //daPath.DecelerationRatio = 0.4;
            //daPath.AutoReverse = false;
            //daPath.PathGeometry = path139798;
            //daPath.PathGeometry = path139750;
            //daPath.Source = PathAnimationSource.X;
            //object_to_move.BeginAnimation(Canvas.LeftProperty, daPath);
        }
        

    }
}
