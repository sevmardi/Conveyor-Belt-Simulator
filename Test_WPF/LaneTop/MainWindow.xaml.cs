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
using System.Windows.Media.Animation;
using System.Runtime.InteropServices;

namespace LaneTop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
     
        private LaneAnimation laneanimatin;

        public MainWindow()
        {

            InitializeComponent();
            //laneanimatin.sb = (Storyboard)this.Resources["Storyboard1"];
        }

   

        private void btnStartSystem_Click(object sender, RoutedEventArgs e)
        {
            if (PLCCalls.myclient.Connected())
            {
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

            }
         
        }

        private void btnRest_Click(object sender, RoutedEventArgs e)
        {
            PLCCalls.ResetSystem();
            object_to_move.Visibility = Visibility.Visible;
        }

        private void btnStopSystem_Click(object sender, RoutedEventArgs e)
        {
            //buffer[0] = 1;
            //myclient.WriteArea(S7Client.S7AreaPE, DBNumber, 322, amount, wordlen, buffer);
            //stopsystem();

            laneanimatin.sb.Pause();

        }

        protected void stopsystem()
        {
            PLCCalls.StopSystem();
            object_to_move.Visibility = Visibility.Hidden;
        }

        private void btnConnectToPLC_Click(object sender, RoutedEventArgs e)
        {
            PLCCalls.EstablishContact();
        }

        private void btnDisconnect_Click(object sender, RoutedEventArgs e)
        {
            PLCCalls.Disconnect();
          
            stopsystem();
        }

        private void StartAnimation()
        {
            laneanimatin.sb.Begin();
            laneanimatin.sb.Seek(TimeSpan.FromMilliseconds(1000));
         

            
        }



        private void StartAnimationBtn_Click(object sender, RoutedEventArgs e)
        {
        //https://msdn.microsoft.com/en-us/library/cc295328.aspx
            //Storyboard myStoryboard;
            //myStoryboard = (Storyboard)this.Resources["Storyboard1"];
            //myStoryboard.Begin(this);
            var sub = FindResource("Storyboard1") as Storyboard;

            if (sub != null)
            {
                sub.Begin();
                
            }

           
        }



        private bool AnimationPaused()
        {
            var sub = FindResource("Storyboard1") as Storyboard;
            bool pauze = false;

            if (sub.GetIsPaused())
            {

                sub.Resume();
                pauze = true;

                return pauze;
            }

            return pauze;
        
        }



        private void StopAnimationBtn_Click(object sender, RoutedEventArgs e)
        {
            var sub = FindResource("Storyboard1") as Storyboard;
            sub.Pause();
            StartAnimationBtn.IsEnabled = false;

        }
        //http://stackoverflow.com/questions/21703266/change-button-background-color-on-eventtrigger-in-wpf
        private void ContinueAnimationBtn_Copy_Click(object sender, RoutedEventArgs e)
        {
            var sub = FindResource("Storyboard1") as Storyboard;
            sub.Resume();
           
        }

        private void ResetAnimationBtn_Copy1_Click(object sender, RoutedEventArgs e)
        {
            var sub = FindResource("Storyboard1") as Storyboard;
            sub.Seek(TimeSpan.Zero);
            StartAnimationBtn.IsEnabled = true;
        }

  
        



































    }
}
