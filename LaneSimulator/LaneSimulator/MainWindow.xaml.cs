using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using LaneSimulator.Lanes;
using LaneSimulator.Model;
using LaneSimulator.PLC;
using LaneSimulator.UIGates;
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
        private ShadowBox sbZoom, sbSpeed, sslObjects, total, SSL, timerBox, btnsPanelBox, counterBox, DegradedBtns, LaneStatus;
        
        private readonly Utilities.SSLCanvas _sslCanvas;
        private double T = 0.0;
        private DispatcherTimer Timer1 = new DispatcherTimer();
        private readonly PlcCalls _plcCalls;
        private LaneTop _laneTop;
        static int count = 0;

        public MainWindow()
        {
            InitializeComponent();
           
            Timer1.Interval = new TimeSpan(0, 0, 0, 0, 100);
            Timer1.Tick += new EventHandler(this.Timer1_Tick);
            Closing += new CancelEventHandler(MainWindow1Closing);

            InitializeLaneTop();
            _sslCanvas = new Utilities.SSLCanvas();
     
           _plcCalls = new PlcCalls();

           AssemblyTitleAttribute title;
           AssemblyCopyrightAttribute copyright;
           Assembly aAssembly = Assembly.GetExecutingAssembly();


           title = (AssemblyTitleAttribute)
                   AssemblyTitleAttribute.GetCustomAttribute(
               aAssembly, typeof(AssemblyTitleAttribute));

           copyright = (AssemblyCopyrightAttribute)
                   AssemblyCopyrightAttribute.GetCustomAttribute(
               aAssembly, typeof(AssemblyCopyrightAttribute));
           APP_TITLE = title.Title;
           APP_VERSION = aAssembly.GetName().Version.ToString();
           APP_COPYRIGHT = copyright.Copyright;


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

            //TraysCounter - NUmber of trays been on the lane
            Grid1.Children.Remove(traysCounter);
            total = new ShadowBox();
            total.Margin = new Thickness(20);
            total.Children.Add(traysCounter);
            traysCounter.Background = Brushes.Transparent;
            total.VerticalAlignment = VerticalAlignment.Bottom;
            total.HorizontalAlignment = HorizontalAlignment.Right;
            Grid1.Children.Add(total);
            Grid.SetColumn(total, 1);
            Grid.SetRow(total, 1);

            //SensorTimerHandler
            Grid1.Children.Remove(Timer);
            timerBox = new ShadowBox();
            timerBox.Margin = new Thickness(20, 20, 175, 20);
            timerBox.Children.Add(Timer);
            Timer.Background = Brushes.Transparent;
            timerBox.VerticalAlignment = VerticalAlignment.Bottom;
            timerBox.HorizontalAlignment = HorizontalAlignment.Left;
            Grid1.Children.Add(timerBox);
            Grid.SetColumn(timerBox, 1);
            Grid.SetRow(timerBox, 1);
 
            // Control Panel - On/Off reset buttons
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

            // Number of mouse clicks
            Grid1.Children.Remove(Counter);
            btnsPanelBox = new ShadowBox();
            btnsPanelBox.Margin = new Thickness(20, 20, 175, 20);
            btnsPanelBox.Children.Add(Counter);
            Counter.Background = Brushes.Transparent;
            btnsPanelBox.VerticalAlignment = VerticalAlignment.Top;
            btnsPanelBox.HorizontalAlignment = HorizontalAlignment.Left;
            Grid1.Children.Add(btnsPanelBox);
            Grid.SetColumn(btnsPanelBox, 1);
            Grid.SetRow(btnsPanelBox, 1);

            // Degraded buttons
            Grid1.Children.Remove(DegradedPanel);
            DegradedBtns = new ShadowBox();
            DegradedBtns.Margin = new Thickness(-150, 200, 200, 200);
            DegradedBtns.Children.Add(DegradedPanel);
            DegradedPanel.Background = Brushes.Transparent;
            DegradedBtns.VerticalAlignment = VerticalAlignment.Top;
            DegradedBtns.HorizontalAlignment = HorizontalAlignment.Center;
            Grid1.Children.Add(DegradedBtns);
            Grid.SetColumn(DegradedBtns, 1);
            Grid.SetRow(DegradedBtns, 1);

            Grid1.Children.Remove(Status);
            LaneStatus = new ShadowBox();
            LaneStatus.Margin = new Thickness(20, 20, 175, 20);
            LaneStatus.Children.Add(Status);
            Status.Background = Brushes.Transparent;
            LaneStatus.VerticalAlignment = VerticalAlignment.Top;
            LaneStatus.HorizontalAlignment = HorizontalAlignment.Center;
            Grid1.Children.Add(LaneStatus);
            Grid.SetColumn(LaneStatus, 1);
            Grid.SetRow(LaneStatus, 1);


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

           InfoLine.GetInstance().PropertyChanged += InfoLine_PropertyChanged;

        }

        private void InitializeLaneTop()
        {
            _laneTop = new LaneTop();
            SSLCanvas.GC.VerticalAlignment = VerticalAlignment.Center;
            SSLCanvas.GC.HorizontalAlignment = HorizontalAlignment.Left;
            SSLCanvas.GC.Children.Add(_laneTop);
            SSLCanvas.UpdateLayout();
        }

        private void DragDropHelper_ItemDropped(object sender, DragDropEventArgs e)
        {
            if (e.DropTarget.IsDescendantOf(SSLCanvas) && this.IsActive)
            {
                Gate newgate = null;

                newgate = ((Gate) e.Content).CreateUserInstance();

                SSLCanvas.AddGate(newgate,
                    new GateLocation(SSLCanvas.GetNearestSnapTo(SSLCanvas.TranslateScrolledPoint(e.Position))));

                SSLCanvas.UpdateLayout();
            }
        }

        /// <summary>
        /// Auth screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                //   MessageBox.Show("Connected!");
            }
            else

                Close();
        }

        public void ResetTimer()
        {
            T = 0.0;
            Timer_Lable.Text = "0.00";
            Total();
        }

        /// <summary>
        /// Fetch the count the trays which already been through the conveyor. 
        /// </summary>
        private void Total()
        {
       //   this.total_text1.Text = (this.tray_Wrap.Children.Count).ToString();

         // Dispatcher.Invoke((Action)(() => { (AnimationPanel.Children.Count).ToString(); }));
        }

        public void NumberOfClicksToProduceTray()
        {
            count++;
            MouseClickOfUser.Text = count.ToString();
        }


        private void MainWindow1Closing(object sender, CancelEventArgs e)
        {
            _plcCalls.Disconnect();
  
            _plcCalls.StopBtnInput();
        //    MessageBox.Show("System is stopped");
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
                Storyboard.SetTargetProperty(pa, new PropertyPath(Utilities.SSLCanvas.ZoomCenterProperty));
                SSLCanvas.UseZoomCenter = true;
            }

            Storyboard.SetTarget(da, slZoom);
            Storyboard.SetTargetProperty(da, new PropertyPath(Slider.ValueProperty));
            sb.FillBehavior = FillBehavior.Stop;

            sb.Begin();

            BackgroundWorker finishani = new BackgroundWorker();

            finishani.DoWork += (sender2, e2) => { System.Threading.Thread.Sleep(900); };

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


        private void btnChart_Click(object sender, RoutedEventArgs e)
        {
            SchedulerPanel schedulerPanel = new SchedulerPanel();
            schedulerPanel.Show();
        }

        private void StopButton_OnClick(object sender, RoutedEventArgs e)
        {   
             // Stop the PLC
            // Stop the animation as  well. 
            // When system is stopped all other buttons are not avialable
            _plcCalls.StopBtnInput();
        }

        private void Reset_Button_OnClick(object sender, RoutedEventArgs e)
        {
            _plcCalls.ResetBtn();
        }

        private void StartSystem_OnClick(object sender, RoutedEventArgs e)
        {
            _laneTop.StartSystem();
            SSLOperational();
        }

        private void NotApproved_OnClick(object sender, RoutedEventArgs e)
        {
           //disapprove the tray and keep it moving forward [not approved]. 
            _plcCalls.DegradedDecisionEventNotOk();
        }

        private void Approvel_OnClick(object sender, RoutedEventArgs e)
        {
            // approve the tray and move it to another approval conveyor
            _plcCalls.DegradedDecisionEventOk();
        }

        public void TrayTimer()
        {
            var aTimer = new Timer();
           // aTimer.Elapsed += new ElapsedEventHandler(MakeTrayBtn2_Click);
            aTimer.Interval = 2500;
            aTimer.Enabled = true;
            aTimer.AutoReset = true;
        }


        public void NumberOfClicksToProduceTray(int count)
        {
            Dispatcher.Invoke((Action) (() => { MouseClickOfUser.Text = count.ToString(); }));
        }

        public void SSLOperational()
        {
           

            LaneStatusName.Text = "NIce";
        }
       
    }

    public enum DegradedMode
    {
        Approved,
        NotApproved
    }
}
