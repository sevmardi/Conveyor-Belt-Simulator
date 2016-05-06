using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace LaneTop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        private LaneAnimation _laneanimatin;

        public MainWindow()
        {

            InitializeComponent();
            //laneanimatin.sb = (Storyboard)this.Resources["Storyboard1"];
        }


        private void btnStartSystem_Click(object sender, RoutedEventArgs e)
        {
            if (PlcCalls.Client.Connected())
            {
                 ObjectToMove.Visibility = Visibility.Visible;
                _0102_S1.Fill = new SolidColorBrush(Colors.Red);
                _0102_S2.Fill = new SolidColorBrush(Colors.Red);


                PlcCalls.AllSensorsOnTrue();
                PlcCalls.StartUp();
            }
         
        }

        private void btnRest_Click(object sender, RoutedEventArgs e)
        {
           
            ObjectToMove.Visibility = Visibility.Visible;
        }

        private void btnStopSystem_Click(object sender, RoutedEventArgs e)
        {
            PlcCalls.StopBtnInput();
        

        }

        private void btnConnectToPLC_Click(object sender, RoutedEventArgs e)
        {
            PlcCalls.EstablishContact();
        }

        private void btnDisconnect_Click(object sender, RoutedEventArgs e)
        {
            PlcCalls.Disconnect();
 
        }


        private void StartAnimationBtn_Click(object sender, RoutedEventArgs e)
        {
            //https://msdn.microsoft.com/en-us/library/cc295328.aspx

            var sub1 = FindResource("Storyboard1") as Storyboard;
           
            if (sub1 != null) 
                
                sub1.Begin();
           

        }



        private void StopAnimationBtn_Click(object sender, RoutedEventArgs e)
        {
            var sub = FindResource("Storyboard1") as Storyboard;
            sub.Pause();
           

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
            if (sub != null) sub.Seek(TimeSpan.Zero);
           
        }


















        private void Timeline_OnCompleted(object sender, EventArgs e)
        {
            var thing = this.FindResource("Storyboard3");

            var OtherSB = (Storyboard)thing;
            OtherSB.Begin();
        }

        private void Timeline_OnCompleted4(object sender, EventArgs e)
        {
       
            var thing = this.FindResource("Storyboard4");

            var OtherSB = (Storyboard)thing;
            OtherSB.Begin();
        }


        private void MyStoryboardCompleted(object sender, EventArgs e)
        {
            var thing = this.FindResource("Storyboard2");

            var OtherSB = (Storyboard)thing;
            OtherSB.Begin();
        }

    }
}
