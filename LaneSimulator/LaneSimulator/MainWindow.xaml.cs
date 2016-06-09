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
        private ShadowBox sbZoom, sbSpeed, sslObjects, total, SSL, counter, btnsPanelBox;
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

           // everybody gets view keys
        //   this.PreviewKeyDown += new KeyEventHandler(Window1_View_KeyDown);


           // drag/drop for edit or full
            DragDropHelper.ItemDropped += new EventHandler<DragDropEventArgs>(DragDropHelper_ItemDropped);

            Grid1.Children.Remove(SSLComponents);
            sslObjects = new ShadowBox();
            sslObjects.Margin = new Thickness(20, 20, 20, 20);
            sslObjects.Children.Add(SSLComponents);
            SSLComponents.Background = Brushes.Transparent;
            sslObjects.VerticalAlignment = VerticalAlignment.Center;
            sslObjects.HorizontalAlignment = HorizontalAlignment.Left;
            Grid1.Children.Add(sslObjects);
            Grid.SetColumn(sslObjects, 1);
            Grid.SetRow(sslObjects, 1);

            // Everybody gets zoom
            sbZoom = new ShadowBox();
            sbZoom.Margin = new Thickness(20);
            Grid1.Children.Remove(spZoom);
            sbZoom.Children.Add(spZoom);
            spZoom.Background = Brushes.Transparent;
            sbZoom.VerticalAlignment = VerticalAlignment.Top;
            sbZoom.HorizontalAlignment = HorizontalAlignment.Right;
            Grid1.Children.Add(sbZoom);
            Grid.SetColumn(sbZoom, 1);
            Grid.SetRow(sbZoom, 1);

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
            Grid1.Children.Remove(traysCounter);
            total = new ShadowBox();
            total.Margin = new Thickness(20, 20, 175, 20);
            total.Children.Add(traysCounter);
            traysCounter.Background = Brushes.Transparent;
            total.VerticalAlignment = VerticalAlignment.Top;
            total.HorizontalAlignment = HorizontalAlignment.Right;
            Grid1.Children.Add(total);
            Grid.SetColumn(total, 1);
            Grid.SetRow(total, 1);

            //Timer
            Grid1.Children.Remove(Timer);
            counter = new ShadowBox();
            counter.Margin = new Thickness(20, 20, 175, 20);
            counter.Children.Add(Timer);
            Timer.Background = Brushes.Transparent;
            counter.VerticalAlignment = VerticalAlignment.Top;
            counter.HorizontalAlignment = HorizontalAlignment.Left;
            Grid1.Children.Add(counter);
            Grid.SetColumn(counter, 1);
            Grid.SetRow(counter, 1);
 
            // SSL
            //Grid1.Children.Remove(LaneTop);
            //SSL = new ShadowBox();
            //SSL.Margin = new Thickness(20, 20, 175, 20);
            //SSL.Children.Add(LaneTop);
            //LaneTop.Background = Brushes.Transparent;
            //SSL.VerticalAlignment = VerticalAlignment.Center;
            //SSL.HorizontalAlignment = HorizontalAlignment.Center;
            //Grid1.Children.Add(SSL);
            //Grid.SetColumn(SSL, 1);
            //Grid.SetRow(SSL, 1);

            Grid1.Children.Remove(ButtonsPanel);
            btnsPanelBox = new ShadowBox();
            btnsPanelBox.Margin = new Thickness(20, 20, 175, 20);
            btnsPanelBox.Children.Add(ButtonsPanel);
            ButtonsPanel.Background = Brushes.Transparent;
            btnsPanelBox.VerticalAlignment = VerticalAlignment.Bottom;
            btnsPanelBox.HorizontalAlignment = HorizontalAlignment.Center;
            Grid1.Children.Add(btnsPanelBox);
            Grid.SetColumn(btnsPanelBox, 1);
            Grid.SetRow(btnsPanelBox, 1);



           this.Loaded += (sender2, e2) =>
           {
               lblAppTitle.Text = APP_TITLE;
               lblAppVersion.Text = APP_VERSION;
               lblAppCopyright.Text = APP_COPYRIGHT;
           };

           this.PreviewMouseWheel += (sender, e2) =>
           {
               if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
               {
                   SSLCanvas.UseZoomCenter = true;
                   double centerX = (Mouse.GetPosition(this).X + SSLCanvas.Scroller.HorizontalOffset) / SSLCanvas.Zoom;
                   double centerY = (Mouse.GetPosition(this).Y + SSLCanvas.Scroller.VerticalOffset) / SSLCanvas.Zoom;
                   SSLCanvas.ZoomCenter = new Point(centerX, centerY);

                   if (e2.Delta > 0)
                       slZoom.Value += 0.1;
                   else
                       slZoom.Value -= 0.1;

                   e2.Handled = true;
               }
           };


        }

        private void DragDropHelper_ItemDropped(object sender, DragDropEventArgs e)
        {
            if (e.DropTarget.IsDescendantOf(SSLCanvas) && this.IsActive)
            {
                Gate newgate = null;
                newgate = ((Gate)e.Content).CreateUserInstance();
              //  SSLCanvas.AddGate(newgate, new GateLocation(SSLCanvas.GetNearestSnapTo(SSLCanvas.TranslateScrolledPoint(e.Position))));

               
                SSLCanvas.AddTray();
                SSLCanvas.UpdateLayout();
            }
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
            Timer_Lable.Text = "0.00";
        //    tray_Wrap.Children.Clear();
            Total();
        }

        /// <summary>
        /// Fetch the count the trays which already been through the conveyor. 
        /// </summary>
        private void Total()
        {
           //this.total_text1.Text = (this.tray_Wrap.Children.Count).ToString();
        }

        private void btnRest_Click(object sender, RoutedEventArgs e)
        {
            _plcCalls.ResetBtn();
        }

        private void btnStopSystem_Click(object sender, RoutedEventArgs e)
        {
         //   _plcCalls.StopBtnInput();
            StopStoryboard1();
        }

        private void StartAnimationBtn_Click(object sender, RoutedEventArgs e)
        {
            ////https://msdn.microsoft.com/en-us/library/cc295328.aspx

            var sub1 = FindResource("Storyboard1") as Storyboard;

            if (sub1 != null)
            {
                //Storyboard.SetTargetName(sub1, SmallTray);
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


        
        private void MyStoryboardCompleted(object sender, EventArgs e)
        {
            var thing = this.FindResource("Storyboard2");

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
            Timer_Lable.Text = (this.T = this.T + 0.1).ToString("0.00",(IFormatProvider)CultureInfo.InvariantCulture);
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
            //SSLCanvas.ShowTrueFalse = true;
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

         #endregion

        private void slZoom_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SSLCanvas.Zoom = slZoom.Value;
        }

        private void AnimateZoom(double dest, Point? zoomCenter)
        {
            if (dest < slZoom.Minimum)
                dest = slZoom.Minimum;
            
            if (dest > slZoom.Maximum)
                dest = slZoom.Maximum;

            PointAnimation pa = null;

            if (zoomCenter.HasValue)
            {
                SSLCanvas.SetZoomCenter();
                pa = new PointAnimation(SSLCanvas.ZoomCenter, zoomCenter.Value, new Duration(new TimeSpan(0, 0, 1)));

                pa.AccelerationRatio = 0.2;
                pa.DecelerationRatio = 0.2;

            }

            DoubleAnimation da = new DoubleAnimation(dest, new Duration(new TimeSpan(0, 0, 1)));
            da.AccelerationRatio = 0.2;
            da.DecelerationRatio = 0.2;

            Storyboard sb = new Storyboard();
            sb.Children.Add(da);
            if (pa != null)
            {
                sb.Children.Add(pa);
                Storyboard.SetTarget(pa, SSLCanvas);
                Storyboard.SetTargetProperty(pa, new PropertyPath(SSLCanvas.ZoomCenterProperty));
                SSLCanvas.UseZoomCenter = true;
            }

            Storyboard.SetTarget(da, slZoom);
            Storyboard.SetTargetProperty(da, new PropertyPath(Slider.ValueProperty));
            sb.FillBehavior = FillBehavior.Stop;

            sb.Begin();

            BackgroundWorker finishani = new BackgroundWorker();

            finishani.DoWork += (sender2, e2) =>
            {
                System.Threading.Thread.Sleep(900);
            };

            finishani.RunWorkerCompleted += (sender2, e2) =>
            {
                if (zoomCenter.HasValue)
                    SSLCanvas.ZoomCenter = zoomCenter.Value;

                slZoom.Value = dest;
            };

            finishani.RunWorkerAsync();
        }

        private void btnActualSize_Click(object sender, RoutedEventArgs e)
        {
            AnimateZoom(1, null);
        }

        private void btnFitToScreen_Click(object sender, RoutedEventArgs e)
        {
            Rect bounds;
            bounds = SSLCanvas.GetBounds(64, SSLCanvas.selected.Count > 1);


            double minx = bounds.Left;
            double miny = bounds.Top;
            double maxx = bounds.Right;
            double maxy = bounds.Bottom;

            double wid = SSLCanvas.ActualWidth / (maxx - minx);
            double hei = SSLCanvas.ActualHeight / (maxy - miny);


            AnimateZoom(Math.Min(wid, hei), new Point(minx + (maxx - minx) / 2.0,
                miny + (maxy - miny) / 2.0));

            BackgroundWorker resetzc = new BackgroundWorker();
            resetzc.DoWork += (sender2, e2) =>
            {
                System.Threading.Thread.Sleep(1500);
            };
            resetzc.RunWorkerCompleted += (sender2, e2) =>
            {
                //gateCanvas.UseZoomCenter = false;
            };
            resetzc.RunWorkerAsync();

        }

        private void AddToAnimation()
        {
         //   var tray = new SmallTray();

            var sb1 = FindResource("Storyboard1") as Storyboard;

            //sb1.Begin(tray);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //AddToAnimation();

            //SmallTray tray = new SmallTray();
        }

        private void btnChart_Click(object sender, RoutedEventArgs e)
        {
            SchedulerPanel schedulerPanel = new SchedulerPanel();
            schedulerPanel.Show();
        }

        private void Image_Off_MouseUp(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void StopButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Reset_Button_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
