using System;
using System.ComponentModel;
using System.Globalization;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using LaneSimulator.Models.Components;

namespace LaneSimulator
{
    /// <summary>
    /// Interaction logic for SSLCanvas.xaml
    /// </summary>
    public partial class SSLCanvas : UserControl
    {
        public BindingList<Tray> selected = new BindingList<Tray>();


        private DragState dragging = DragState.NONE;
        private bool ReadyToSelect = false;
        private Point mp;
        private Point sp;
        private double _zoom = 1.0;
        public DispatcherTimer Timer1 = new DispatcherTimer();
        private double T = 0.0;
        private bool _mute;
        private Brush oldBackground;


        private const double ANGLE_SNAP_DEG = 10;
        private const double DELTA_SNAP = 5;
        private const double GRID_SIZE = 32;




        public SSLCanvas()
        {
            InitializeComponent();
            Timer1.Interval = new TimeSpan(0, 0, 0, 0, 100);
            Timer1.Tick += new EventHandler(this.Timer1_Tick);
        }

        protected enum DragState
        {
            NONE, MOVE
        }


        public void Scroller_LayoutUpdated(object sender, EventArgs e)
        {
            if (!_mute && !DisableSizeCanvas)
                SizeCanvas();
        }
        private void Scroller_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (!_mute && !DisableSizeCanvas)
                SizeCanvas();
        }

        private void Scroller_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            if (dragging == DragState.MOVE)
            {
                System.Threading.Thread.Sleep(100); // don't let them scroll themselves into oblivion
            }
        }

        public bool DisableSizeCanvas { get; set; }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //Timer_Lable.Text = (this.T = this.T + 0.1).ToString("0.00",
            //    (IFormatProvider)CultureInfo.InvariantCulture);
        }

        //public Rect GetBounds(double padding, bool selectedOnly)
        //{
        //    if (selectedOnly)
        //        return GetBounds(selected, padding);
        //    else
        //        return GetBounds(gates.Values, padding);
        //}


        //mouse up event for canvas clicks
        private void SSLCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            dragging = DragState.NONE;
            dragSelect.Width = 0;
            dragSelect.Height = 0;
            dragSelect.Margin = new Thickness(0, 0, 0, 0);
            dragSelect.Visibility = Visibility.Hidden;

            ReadyToSelect = false;
        }

        private void SSLCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point mp2 = e.GetPosition(GC);

            if (e.LeftButton == MouseButtonState.Pressed || e.RightButton == MouseButtonState.Pressed)
            {
                GC.BringIntoView(new Rect(new Point(mp2.X - 10, mp2.Y - 10),
                 new Point(mp2.X + 10, mp2.Y + 10)));

                switch (dragging)
                {
                        case DragState.MOVE:

                        foreach (Tray tray in selected)
                        {

                            if (e.LeftButton == MouseButtonState.Pressed)
                            {

                            }

                            if (e.RightButton == MouseButtonState.Pressed)
                            {

                            }
                        }
                        break;

                        case DragState.NONE:
                            // not dragging
                            // creating a selection rectangle

                        if (ReadyToSelect)
                        {
                            double x1 = Math.Min(mp2.X, sp.X);
                            double width = Math.Abs(mp2.X - sp.X);

                            double y1 = Math.Min(mp2.Y, sp.Y);
                            double height = Math.Abs(mp2.Y - sp.Y);

                            dragSelect.Margin = new Thickness(x1, y1, 0, 0);
                            dragSelect.Width = width;
                            dragSelect.Height = height;
                            dragSelect.Visibility = Visibility.Visible;

                            Rect select = new Rect(x1, y1, width, height);
                        }
                        break;
                }

            }
        }

        // Green Team Notes:  This clears selection
        public void ClearSelection()
        {
            //foreach (Gate g in selected)
            //    g.Selected = false;

            //selected.Clear();
        }

        public void SelectAll()
        {
            //ClearSelection();

            //foreach (Gate g in gates.Values)
            //{
            //    g.Selected = true;
            //    selected.Add(g);
            //}
        }

        public void SizeCanvas()
        {
            // green team notes:  increased size to make scroll bars visible on start
            // this will ensure the mouse center zoom method works on start up
            double maxx = (Scroller.ViewportWidth / _zoom);
            double maxy = (Scroller.ViewportHeight / _zoom);

            //foreach (Gate g in gates.Values)
            //{
            //    maxx = Math.Max(maxx, g.Margin.Left + g.Width + 64);
            //    maxy = Math.Max(maxy, g.Margin.Top + g.Height + 64);

            //}

            GC.Width = maxx;
            GC.Height = maxy;
        }


        /// <summary>
        /// Sets the background to white temporarily for image capture or printing
        /// </summary>
        public bool Mute
        {
            set
            {
                if (value)
                {
                    oldBackground = GC.Background;
                    GC.Background = Brushes.White;


                }
                else
                {
                    GC.Background = oldBackground;

                }
                _mute = value;
            }

        }

        public void AddObject(Tray tray)
        {
            tray = new Tray();

        }

        public void AddTray()
        {
            
        }

        public enum SELECTED_OBJECTS
        {
            ALL,

            SELECTED,

            SELECTED_IF_TWO_OR_MORE
        }

        public void SetZoomCenter()
        {
            double centerX = (Scroller.HorizontalOffset + Scroller.ViewportWidth / 2.0) / _zoom;
            double centerY = (Scroller.VerticalOffset + Scroller.ViewportHeight / 2.0) / _zoom;
            ZoomCenter = new Point(centerX, centerY);  
        }

        public Point ZoomCenter
        {
            get
            {
                return (Point)GetValue(ZoomCenterProperty);
            }
            set
            {
                SetValue(ZoomCenterProperty, value);
            }
        }

        public static readonly DependencyProperty ZoomCenterProperty = DependencyProperty.Register("ZoomCenter", typeof(Point), typeof(SSLCanvas));

        /// <summary>  
        /// Indicate if the user provided value in ZoomCenter should be used  
        /// </summary>  
        /// 
        public bool UseZoomCenter { get; set; }

        /// <summary>  
        /// Sets the zoom factor.  Changes to zoom occur based on the center of the displayed area,  
        /// or, if UseZoomCenter is set to true, around the user defined zoom center.  
        /// </summary>  
        /// 
        public double Zoom
        {

            get
            {
                return _zoom;
            }

            set
            {


                double centerX = (Scroller.HorizontalOffset + Scroller.ViewportWidth / 2.0) / _zoom;
                double centerY = (Scroller.VerticalOffset + Scroller.ViewportHeight / 2.0) / _zoom;
                _zoom = value;
                GC.LayoutTransform = new ScaleTransform(value, value);
                if (UseZoomCenter)
                {
                    centerX = ZoomCenter.X;
                    centerY = ZoomCenter.Y;
                }

                if (!double.IsNaN(centerX))
                {
                    Scroller.ScrollToHorizontalOffset((centerX * _zoom) - Scroller.ViewportWidth / 2.0);
                    Scroller.ScrollToVerticalOffset((centerY * _zoom) - Scroller.ViewportHeight / 2.0);
                }

            }
        }

    }
}
