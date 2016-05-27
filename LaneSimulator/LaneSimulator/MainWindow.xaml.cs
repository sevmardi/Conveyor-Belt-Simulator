using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using LaneSimulator.Lanes;
using LaneSimulator.Models.Components;
using LaneSimulator.PLC;
using LaneSimulator.Utilities;
using LaneSimulator.Utilities.DragDrop;
using LaneSimulator.Utilities.ShadowBox;
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
        private ShadowBox sbZoom, sbSpeed, sslObjects, counter, SSL;
        private readonly SectionA _sectionA;
        private readonly SSLCanvas _sslCanvas;
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
            _sslCanvas = new SSLCanvas();
     
           _plcCalls = new PlcCalls();


           // drag/drop for edit or full
            DragDropHelper.ItemDropped += new EventHandler<DragDropEventArgs>(DragDropHelper_ItemDropped);
            
            //Grid1.Children.Remove(SSLComponents);
            //sslObjects = new ShadowBox();
            //sslObjects.Margin = new Thickness(20, 20, 20, 20);
            //sslObjects.Children.Add(SSLComponents);
            //SSLComponents.Background = Brushes.Transparent;
            //sslObjects.VerticalAlignment = VerticalAlignment.Center;
            //sslObjects.HorizontalAlignment = HorizontalAlignment.Left;
            //Grid1.Children.Add(sslObjects);
            //Grid.SetColumn(sslObjects, 1);
            //Grid.SetRow(sslObjects, 1);

            // Everybody gets zoom
            //sbZoom = new ShadowBox();
            //sbZoom.Margin = new Thickness(20);
            //Grid1.Children.Remove(spZoom);
            //sbZoom.Children.Add(spZoom);
            //spZoom.Background = Brushes.Transparent;
            //sbZoom.VerticalAlignment = VerticalAlignment.Top;
            //sbZoom.HorizontalAlignment = HorizontalAlignment.Right;
            //Grid1.Children.Add(sbZoom);
            //Grid.SetColumn(sbZoom, 1);
            //Grid.SetRow(sbZoom, 1);

            //Speed of simulation
            //Grid1.Children.Remove(spSpeed);
            //sbSpeed = new ShadowBox();
            //sbSpeed.Margin = new Thickness(20, 20, 175, 20);
            //sbSpeed.Children.Add(spSpeed);
            //spSpeed.Background = Brushes.Transparent;
            //sbSpeed.VerticalAlignment = VerticalAlignment.Top;
            //sbSpeed.HorizontalAlignment = HorizontalAlignment.Right;
            //Grid1.Children.Add(sbSpeed);
            //Grid.SetColumn(sbSpeed, 1);
            //Grid.SetRow(sbSpeed, 1);

            //TraysCounter
            //Grid1.Children.Remove(traysCounter);
            //counter = new ShadowBox();
            //counter.Margin = new Thickness(20, 20, 175, 20);
            //counter.Children.Add(traysCounter);
            //traysCounter.Background = Brushes.Transparent;
            //counter.VerticalAlignment = VerticalAlignment.Top;
            //counter.HorizontalAlignment = HorizontalAlignment.Right;
            //Grid1.Children.Add(counter);
            //Grid.SetColumn(counter, 1);
            //Grid.SetRow(counter, 1);


         

           this.Loaded += (sender2, e2) =>
           {
             
               //lblAppTitle.Text = APP_TITLE;
               //lblAppVersion.Text = APP_VERSION;
               //lblAppCopyright.Text = APP_COPYRIGHT;

           };

        }

        private void DragDropHelper_ItemDropped(object sender, DragDropEventArgs e)
        {
            //if (e.DropTarget.IsDescendantOf(SSLCanvas) && this.IsActive)
            //{
                
            //}
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

                Close();
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
            _plcCalls.Disconnect();
            //StopStoryboard1();
            //StopStorboard2();
            //StopStorboard3();
            //StopStoryboard4();
            //_plcCalls.StopBtnInput();
            //MessageBox.Show("sure thing buddy");
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //_sslCanvas.Timer_Lable.Text = (this.T = this.T + 0.1).ToString("0.00",
            //    (IFormatProvider)CultureInfo.InvariantCulture);
        }


        private void InfoLine_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(InfoLine.GetInstance().CurrentInfoLine) || !this.IsActive)
            {
                //lblInfoLine.Visibility = Visibility.Collapsed;
                //spAppInfo.Visibility = Visibility.Visible;
            }
            else
            {
                //lblInfoLine.Text = InfoLine.GetInstance().CurrentInfoLine;
                //lblInfoLine.Visibility = Visibility.Visible;
                //spAppInfo.Visibility = Visibility.Collapsed;
            }

        }

       
     
     #region functions not implmented

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
   
        }

        private void btnSave_As_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnCut_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnPaste_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnFlatten_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnAlignTopLeft_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnCopyAsImage_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnSaveAsImage_Click(object sender, RoutedEventArgs e)
        {
  
        }

        private void btnChart_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnImportIC_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
        }

        private void btnCreateIC_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
        }

        private void btnShowTrueFalse_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void btnShowTrueFalse_Unchecked(object sender, RoutedEventArgs e)
        {
        }

        private void btnShowHideToolbars_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void btnShowHideToolbars_Unchecked(object sender, RoutedEventArgs e)
        {
        }

        private void btnUserMode_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void btnUserMode_Unchecked(object sender, RoutedEventArgs e)
        {
        }

          

        private void btnActualSize_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnFitToScreen_Click(object sender, RoutedEventArgs e)
        {

        }
         #endregion

        private void slZoom_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //SSLCanvas.Zoom = slZoom.Value;
        }

        private void SectionB_Loaded(object sender, RoutedEventArgs e)
        {

        }


        private void AddToAnimation()
        {
         //   var tray = new Tray();

            var sb1 = FindResource("Storyboard1") as Storyboard;

            sb1.Begin(tray);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //AddToAnimation();

            //Tray tray = new Tray();

            this.Animation_Pannel.Children.Add((UIElement)tray);
            Canvas.SetLeft((UIElement)tray, 220.0);
            Canvas.SetTop((UIElement)tray, 4.0);
            var sb1 = FindResource("Storyboard1") as Storyboard;

            sb1.Children.Add((Timeline)sb1);

            sb1.Begin();

        }
    }
}
