using System;
using System.Windows;
using System.Windows.Media.Animation;
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

        public MainWindow()
        {
            InitializeComponent();
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



    }
}
