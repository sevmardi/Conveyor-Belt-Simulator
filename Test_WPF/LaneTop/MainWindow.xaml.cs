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
        SectionA _sectionA;
        public MainWindow()
        {
             _sectionA = new SectionA(this);
            InitializeComponent();
            //laneanimatin.sb = (Storyboard)this.Resources["Storyboard1"];
            ObjectToMove.Visibility = Visibility.Hidden;
        }


        private void btnStartSystem_Click(object sender, RoutedEventArgs e)
        {
            if (PlcCalls.Client.Connected())
            {
               
               PlcCalls.SectionA();
               PlcCalls.SectionB();
               PlcCalls.SectionC();
               PlcCalls.SectionD();
               PlcCalls.SectionE();
               PlcCalls.SectionF();
               PlcCalls.SectionG();
               PlcCalls.StartUp();

               ObjectToMove.Visibility = Visibility.Visible;
              
                // Sensors section-A
               _0102_S1.Fill = new SolidColorBrush(Colors.Red);
               _0102_S2.Fill = new SolidColorBrush(Colors.Red);
               _0103_S1.Fill = new SolidColorBrush(Colors.Red);
               _0104_S1.Fill = new SolidColorBrush(Colors.Red);
               _0105_S1.Fill = new SolidColorBrush(Colors.Red);
               _0105_S2.Fill = new SolidColorBrush(Colors.Red);

                // Sensors section-B

            }
         
        }

        private void btnRest_Click(object sender, RoutedEventArgs e)
        {
            PlcCalls.ResetBtn();
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

                SetMotorOnInSectionA();
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



        private void SetMotorOnInSectionA()
        {
             _sectionA.Executor();
            
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
