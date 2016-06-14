using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Gates;
using LaneSimulator.Model;
using LaneSimulator.UIGates;

namespace LaneSimulator.Utilities
{
    /// <summary>
    /// Interaction logic for SSLCanvas.xaml
    /// </summary>
    public partial class SSLCanvas : UserControl
    {
        public BindingList<Gate> selected = new BindingList<Gate>();
        private Dictionary<Gates.AbstractGate, Gate> gates = new Dictionary<Gates.AbstractGate, Gate>();
        private DragState dragging = DragState.NONE;
        private bool ReadyToSelect = false;
        private Point mp;
        private Point sp;
        private double _zoom = 1.0;
        public DispatcherTimer Timer1 = new DispatcherTimer();
        private double T = 0.0;
        private bool _mute;
        private Brush oldBackground;
        private SmallTray _smallTray;
        private bool _iso = false;

        private const double ANGLE_SNAP_DEG = 10;
        private const double DELTA_SNAP = 5;
        private const double GRID_SIZE = 32;



        /// <summary>
        /// All UI Gates on this canvas.
        /// </summary>
        public IEnumerable<Gate> Gates
        {
            get
            {
                return gates.Values;
            }
        }

        public SSLCanvas()
        {
            InitializeComponent();
            Timer1.Interval = new TimeSpan(0, 0, 0, 0, 100);
            Timer1.Tick += new EventHandler(this.Timer1_Tick);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected enum DragState
        {
            NONE, MOVE
        }


        private static Rect GetBounds(IEnumerable<Gate> gts, double padding)
        {
            double minx = 0, maxx = 0, miny = 0, maxy = 0;
            bool fst = true;
            foreach (Gate g in gts)
            {
                if (fst)
                {
                    minx = g.Margin.Left;
                    maxx = g.Margin.Left + g.Width;
                    miny = g.Margin.Top;
                    maxy = g.Margin.Top + g.Height;
                    fst = false;
                }

                minx = Math.Min(minx, g.Margin.Left - padding);
                maxx = Math.Max(maxx, g.Margin.Left + g.Width + padding);
                miny = Math.Min(miny, g.Margin.Top - padding);
                maxy = Math.Max(maxy, g.Margin.Top + g.Height + padding);
            }

            return new Rect(minx, miny, maxx - minx, maxy - miny);
        }

        /// <summary>
        /// Determine the extent of visual gates on this canvas, taking into account
        /// any requested padding, and whether all gates should be considered or
        /// only selected gates.
        /// </summary>
        /// <param name="padding"></param>
        /// <param name="selectedOnly"></param>
        /// <returns></returns>
        public Rect GetBounds(double padding, bool selectedOnly)
        {
            if (selectedOnly)
                return GetBounds(selected, padding);
            else
                return GetBounds(gates.Values, padding);
        }


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

        //mouse down event for canvas clicks
        private void SSLCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // only come here if the uigate doesn't handle it
            ClearSelection();

            // prepare for a dragging selection
            Point mp2 = e.GetPosition(GC);
            sp = new Point(mp2.X, mp2.Y);

            ReadyToSelect = true;

            if (_iso)
            {
                _iso = false;
                foreach (KeyValuePair<AbstractGate, Gate> pair in gates)
                {
                    Gate value = pair.Value;
                    Fader.AnimateOpacity(1, value);
                }
            }
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

                        foreach (Gate g in selected)
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

        /// <summary>
        /// Clear the selection.  This empties the selected list and sets selected to false
        /// on all gates which were in it.
        /// </summary>
        /// 
        public void ClearSelection()
        {
            foreach (Gate g in selected)
                g.Selected = false;

            selected.Clear();
        }

        public void SelectAll()
        {
            ClearSelection();

            foreach (Gate g in gates.Values)
            {
                g.Selected = true;
                selected.Add(g);
            }
        }

        public void SizeCanvas()
        {
            // this will ensure the mouse center zoom method works on start up
            var maxx = Scroller.ViewportWidth/_zoom;
            var maxy = Scroller.ViewportHeight/_zoom;

            foreach (var g in gates.Values)
            {
                maxx = Math.Max(maxx, g.Margin.Left + g.Width + 64);
                maxy = Math.Max(maxy, g.Margin.Top + g.Height + 64);
            }

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

        public void AddObject(SmallTray smallTray)
        {
            smallTray = new SmallTray();

        }

        public enum SELECTED_GATES
        {
            /// <summary>
            /// All gates in the canvas
            /// </summary>
            ALL,

            /// <summary>
            /// Only those selected gates in the canvas, if any
            /// </summary>
            SELECTED,

            /// <summary>
            /// If 2 or more gates are selected, use selected gates.
            /// Otherwise, use all gates.
            /// </summary>
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
            get { return _zoom; }

            set
            {
                double centerX = (Scroller.HorizontalOffset + Scroller.ViewportWidth/2.0)/_zoom;
                double centerY = (Scroller.VerticalOffset + Scroller.ViewportHeight/2.0)/_zoom;
                _zoom = value;
                GC.LayoutTransform = new ScaleTransform(value, value);
                if (UseZoomCenter)
                {
                    centerX = ZoomCenter.X;
                    centerY = ZoomCenter.Y;
                }

                if (!double.IsNaN(centerX))
                {
                    Scroller.ScrollToHorizontalOffset((centerX*_zoom) - Scroller.ViewportWidth/2.0);
                    Scroller.ScrollToVerticalOffset((centerY*_zoom) - Scroller.ViewportHeight/2.0);
                }
            }
        }

        /// <summary>
        /// Given a point on the canvas, find the nearest "snap" point.  Useful
        /// for placing new gates.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Point GetNearestSnapTo(Point p)
        {
            return new Point(Math.Round(p.X / GRID_SIZE) * GRID_SIZE,
                                        Math.Round(p.Y / GRID_SIZE) * GRID_SIZE);
        }


        public void AddGate(Gate uigate, GateLocation pos)
        {
            ClearSelection();
            Gates.AbstractGate gate = uigate.AbGate;

            gates[gate] = uigate;
            uigate.Margin = new Thickness(pos.X, pos.Y, 0, 0);

            GC.Children.Add(uigate);

            //uigate.RenderTransform = new RotateTransform(pos.Angle, uigate.Width/2.0, uigate.Height/2.0);
            //uigate.Tag = new GateLocation() {X = pos.X, Y = pos.Y, Angle = pos.Angle};
            
        }

        public void AddGate(Gates.AbstractGate gate, GateLocation pos)
        {
            Gate uigate;

            uigate = new UIGates.SmallTray((Gates.Trays.SmallTray)gate);

            AddGate(uigate, pos);
        }

        /// <summary>
        /// Given a relative point on the SSLCanvas control,
        /// adjust it using the current zoom and scroll settings
        /// to reflect an actual point on the unscrolled, unzoomed canvas.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public Point TranslateScrolledPoint(Point p)
        {
            Point np = new Point();
            np.X = Scroller.HorizontalOffset + p.X;
            np.Y = Scroller.VerticalOffset + p.Y;
            np.X /= _zoom;
            np.Y /= _zoom;
            return np;
        }


        public bool DisableSizeCanvas { get; set; }


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

    }
}
