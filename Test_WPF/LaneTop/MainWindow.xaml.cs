using System;

using System.Globalization;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace LaneTop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _timer = new DispatcherTimer();
        private LaneAnimation _laneanimatin;
        readonly SectionA _sectionA;
        private PlcCalls PLC;
        private Tray _tray;
        private double T = 0.0;
       
        public MainWindow()
        {
          

          
            InitializeComponent();
      
            //laneanimatin.sb = (Storyboard)this.Resources["Storyboard1"];
            //newObject.Visibility = Visibility.Hidden;
           // StartAnimationBtn1.IsEnabled = false;
            PLC = new PlcCalls();
            _tray = new Tray();
        }




        private void btnStartSystem_Click(object sender, RoutedEventArgs e)
        {
            if (PlcCalls.Client.Connected())
            {

                PlcCalls.StartUp();
                PlcCalls.SectionA();
                PlcCalls.SectionB();
                PlcCalls.SectionC();
                PlcCalls.SectionD();
                PlcCalls.SectionE();
                PlcCalls.SectionF();
                PlcCalls.SectionG();


                //ObjectToMove.Visibility = Visibility.Visible;
              
                // Sensors section-A
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
            PlcCalls.ResetBtn();
        }

        private void btnStopSystem_Click(object sender, RoutedEventArgs e)
        {
            PLC.StopBtnInput();

            var sb1 = FindResource("Storyboard1") as Storyboard;
            if (sb1 != null) sb1.Pause();
            var sb2 = FindResource("Storyboard2") as Storyboard;
            if (sb2 != null) sb2.Pause();
            var sb3 = FindResource("Storyboard3") as Storyboard;
            if (sb3 != null) sb3.Pause();
            var sb4 = FindResource("Storyboard4") as Storyboard;
            if (sb4 != null) sb4.Pause();
        

        }

        private void btnConnectToPLC_Click(object sender, RoutedEventArgs e)
        {
            PlcCalls.EstablishContact();
        }

        private void btnDisconnect_Click(object sender, RoutedEventArgs e)
        {
            PlcCalls.Disconnect();

         //   Disconnect.IsEnabled = false;

        }


        private void StartAnimationBtn_Click(object sender, RoutedEventArgs e)
        {
            //https://msdn.microsoft.com/en-us/library/cc295328.aspx

            var sub1 = FindResource("Storyboard1") as Storyboard;

            if (sub1 != null)
            {
               //Storyboard.SetTargetName(sub1, Tray);
                sub1.Begin(ObjectToMove);
              //  Storyboard.SetTargetName(sub1, _tray);
                
                
                
                
                
                //CreateNewObject();

               // SetMotorOnInSectionA();
            }
               
            
     
        
        }






        private void storyboard_Completed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }



        public void CreateNewObject()
        {
            //ObjectToMove  = new Rectangle();
            //ObjectToMove.Fill = new SolidColorBrush(Colors.Green);
            //ObjectToMove.Height = 31;
            //ObjectToMove.Width = 42;
            //ObjectToMove.Stroke = (Brush)Brushes.Black;
            //ObjectToMove.StrokeThickness = 1.5;

            //http://stackoverflow.com/questions/2029680/wpf-c-sharp-path-how-to-get-from-a-string-with-path-data-to-geometry-in-code-n
            var shitload = new Path();
            shitload.Data = Geometry.Parse("M-294,428.33333 L-287.33333,393.00034 -263.66823,352.33366 -235.33574,330.6674");


        }

        private void MyStoryboardCompleted(object sender, EventArgs e)
        {
            var thing = this.FindResource("Storyboard2");

            var OtherSB = (Storyboard)thing;
            OtherSB.Begin();
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


   

    }
}
