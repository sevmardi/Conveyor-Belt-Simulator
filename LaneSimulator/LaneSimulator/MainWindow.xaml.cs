using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;
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
        
        private double T = 0.0;
        private DispatcherTimer Timer1 = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            this.Timer1.Interval = new TimeSpan(0, 0, 0, 0, 100);
            this.Timer1.Tick += new EventHandler(this.Timer1_Tick);
            this.Closing += new CancelEventHandler(Window1_Closing);
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DisplayConnectScreen();
        }


        private void DisplayConnectScreen()
        {
            ConnectPanel connectpanel = new ConnectPanel();

            connectpanel.Owner = this;
            connectpanel.ShowDialog();

            if (connectpanel.DialogResult.HasValue && connectpanel.DialogResult.Value)
            {
                //do something
               
                MessageBox.Show("Connected!");

            }
            else
                this.Close();
        }



        private void btnRest_Click(object sender, RoutedEventArgs e)
        {
          //  PlcCalls.ResetBtn();
        }

        private void btnStopSystem_Click(object sender, RoutedEventArgs e)
        {
            //PLC.StopBtnInput();

            //var sb1 = FindResource("Storyboard1") as Storyboard;
            //if (sb1 != null) sb1.Pause();
            //var sb2 = FindResource("Storyboard2") as Storyboard;
            //if (sb2 != null) sb2.Pause();
            //var sb3 = FindResource("Storyboard3") as Storyboard;
            //if (sb3 != null) sb3.Pause();
            //var sb4 = FindResource("Storyboard4") as Storyboard;
            //if (sb4 != null) sb4.Pause();


        }

        private void StartAnimationBtn_Click(object sender, RoutedEventArgs e)
        {
            ////https://msdn.microsoft.com/en-us/library/cc295328.aspx

            var sub1 = FindResource("Storyboard1") as Storyboard;

            if (sub1 != null)
            {
                //Storyboard.SetTargetName(sub1, Tray);
                sub1.Begin();
                Timer1.Start();
                //CreateNewObject();

                // SetMotorOnInSectionA();
            }



        }



        private void SetMotorOnInSectionA()
        {
           // _sectionA.Executor();
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

        private void btnStartSystem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window1_Closing(object sender, CancelEventArgs e)
        {
            // only the orginal full window 
           // e.Cancel = !QuerySave();
            //PlcCalls.Disconnect();
            MessageBox.Show("sure thing buddy");
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            this.Timer_Lable.Text = (this.T = this.T + 0.1).ToString("0.00", (IFormatProvider)CultureInfo.InvariantCulture);
        }
        //TODO
        private void Total()
        {
            //
        }

        private void InfoLine_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(InfoLine.GetInstance().CurrentInfoLine) || !this.IsActive)
            {
                lblInfoLine.Visibility = Visibility.Collapsed;
                spAppInfo.Visibility = Visibility.Visible;
            }
            else
            {
                lblInfoLine.Text = InfoLine.GetInstance().CurrentInfoLine;
                lblInfoLine.Visibility = Visibility.Visible;
                spAppInfo.Visibility = Visibility.Collapsed;
            }

        }
    }
}
