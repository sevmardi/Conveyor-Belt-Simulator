using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Remoting.Channels;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;
using LaneSimulator.Conveyor;
using LaneSimulator.PLC;
using LaneSimulator.Views;

namespace LaneSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static string APP_TITLE;
        public static string APP_VERSION;
        public static string APP_COPYRIGHT;
        private bool Ispaused = false;
        private readonly SectionA _sectionA;
        private double T = 0.0;
        private DispatcherTimer Timer1 = new DispatcherTimer();
        private readonly PlcCalls _plcCalls;
        
        
        public MainWindow()
        {
            InitializeComponent();
            Timer1.Interval = new TimeSpan(0, 0, 0, 0, 100);
            Timer1.Tick += new EventHandler(this.Timer1_Tick);
            Closing += new CancelEventHandler(MainWindow1Closing);
            _sectionA = new SectionA();
         //   ObjectToMove.Visibility = Visibility.Hidden;
           _plcCalls = new PlcCalls();
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ConnectPanel connectpanel = new ConnectPanel();
            connectpanel.Owner = this;
            connectpanel.ShowDialog(); 
        }

        public void ResetTimer()
        {
            T = 0.0;
           // Timer_Lable.Text = "0.00";
        //    tray_Wrap.Children.Clear();
            Total();
        }

        /// <summary>
        /// Fetch the count the trays which already been through the conveyor. 
        /// </summary>
        private void Total()
        {
         //   this.total_text1.Text = (this.tray_Wrap.Children.Count).ToString();
        }

        private void btnRest_Click(object sender, RoutedEventArgs e)
        {
            _plcCalls.ResetBtn();
        }

        private void btnStopSystem_Click(object sender, RoutedEventArgs e)
        {
         //   _plcCalls.StopBtnInput();
            StopStoryboard1();
            StopStorboard2();
            StopStorboard3();
            StopStoryboard4();
        }

        private void StartAnimationBtn_Click(object sender, RoutedEventArgs e)
        {
            ////https://msdn.microsoft.com/en-us/library/cc295328.aspx

            var sub1 = FindResource("Storyboard1") as Storyboard;

            if (sub1 != null)
            {
                //Storyboard.SetTargetName(sub1, Tray);
                sub1.Begin();
              //  Timer1.Start();
                //CreateNewObject();

              //   SetMotorOnInSectionA();
            }

        }


        private void btnStartSystem_Click(object sender, RoutedEventArgs e)
        {
                _plcCalls.StartUp();
                //_plcCalls.SectionA();
                //_plcCalls.SectionB();
                //_plcCalls.SectionC();
                //_plcCalls.SectionD();
                //_plcCalls.SectionE();
                //_plcCalls.SectionF();
                //_plcCalls.SectionG();

                //ObjectToMove.Visibility = Visibility.Visible;

                // Sensors section-A
                //_0102_S1.Fill = new SolidColorBrush(Colors.Red);
                //_0102_S2.Fill = new SolidColorBrush(Colors.Red);
                //_0103_S1.Fill = new SolidColorBrush(Colors.Red);
                //_0104_S1.Fill = new SolidColorBrush(Colors.Red);
                //_0105_S1.Fill = new SolidColorBrush(Colors.Red);
                //_0105_S2.Fill = new SolidColorBrush(Colors.Red);
                //_0301_S1.Fill = new SolidColorBrush(Colors.Red);
                //_0301_S2.Fill = new SolidColorBrush(Colors.Red);
                //_0302_S1.Fill = new SolidColorBrush(Colors.Red);

                //_0303_S1.Fill = new SolidColorBrush(Colors.Red);
                //_0304_S1.Fill = new SolidColorBrush(Colors.Red);
                //_0304_S2.Fill = new SolidColorBrush(Colors.Red);
                //_0304_S3.Fill = new SolidColorBrush(Colors.Red);
                //_0701_S1.Fill = new SolidColorBrush(Colors.Red);

        }

        private void SetMotorOnInSectionA()
        {
           _sectionA.Executor();
        }

        private void StopStoryboard1()
        {
            var sb1 = FindResource("Storyboard1") as Storyboard;
            if (sb1 != null) sb1.Pause();
        }

        private void StopStorboard2()
        {
            var sb2 = FindResource("Storyboard2") as Storyboard;
            if (sb2 != null) sb2.Pause();
        }

        private void StopStorboard3()
        {
            var sb3 = FindResource("Storyboard3") as Storyboard;
            if (sb3 != null) sb3.Pause(); 
        }

        private void StopStoryboard4()
        {
            var sb4 = FindResource("Storyboard4") as Storyboard;
            if (sb4 != null) sb4.Pause();
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

        private void MainWindow1Closing(object sender, CancelEventArgs e)
        {
            // only the orginal full window 
           
            // e.Cancel = !QuerySave();
            //PlcCalls.Disconnect();
            //StopStoryboard1();
            //StopStorboard2();
            //StopStorboard3();
            //StopStoryboard4();
            //_plcCalls.StopBtnInput();
             MessageBox.Show("sure thing buddy");
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //this.Timer_Lable.Text = (this.T = this.T + 0.1).ToString("0.00",
            //    (IFormatProvider)CultureInfo.InvariantCulture);
        }


        //private void InfoLine_PropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    if (String.IsNullOrEmpty(InfoLine.GetInstance().CurrentInfoLine) || !this.IsActive)
        //    {
        //        lblInfoLine.Visibility = Visibility.Collapsed;
        //        spAppInfo.Visibility = Visibility.Visible;
        //    }
        //    else
        //    {
        //        lblInfoLine.Text = InfoLine.GetInstance().CurrentInfoLine;
        //        lblInfoLine.Visibility = Visibility.Visible;
        //        spAppInfo.Visibility = Visibility.Collapsed;
        //    }

        //}

       
        //TEST
       
        private void NewRectangle()
        {
            Rectangle newobject = new Rectangle();
            newobject.Width = 40;
            newobject.Height = 40;
            newobject.Stroke = (Brush)Brushes.Black;

            newobject.StrokeThickness = 1.5;


        }
    }
}
