﻿using System;
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
using LaneTop = LaneSimulator.UIGates.LaneTop;

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
        private LaneTop _laneTop;


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
            InitializeLaneTop();
            InitializeComponent();
            Timer1.Interval = new TimeSpan(0, 0, 0, 0, 100);
            Timer1.Tick += Timer1_Tick;
        }

        private void InitializeLaneTop()
        {
            //_laneTop = new LaneTop();
            //GC.VerticalAlignment = VerticalAlignment.Center;
            //GC.HorizontalAlignment = HorizontalAlignment.Left;
            //GC.Children.Add(_laneTop);
            //UpdateLayout();
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
                                double dx = mp2.X - mp.X;
                                double dy = mp2.Y - mp.Y;
                                ((GateLocation)g.Tag).X = ((GateLocation)g.Tag).X + dx;
                                ((GateLocation)g.Tag).Y = ((GateLocation)g.Tag).Y + dy;
                                double cx = ((GateLocation)g.Tag).X % GRID_SIZE;
                                double cy = ((GateLocation)g.Tag).Y % GRID_SIZE;

                                Point op = new Point(g.Margin.Left, g.Margin.Top);

                                if ((Math.Abs(cx) < DELTA_SNAP || Math.Abs(GRID_SIZE - cx) < DELTA_SNAP) &&
                                    (Math.Abs(cy) < DELTA_SNAP || Math.Abs(GRID_SIZE - cy) < DELTA_SNAP))
                                {
                                    g.Margin = new Thickness(Math.Round(g.Margin.Left / GRID_SIZE) * GRID_SIZE,
                                        Math.Round(g.Margin.Top / GRID_SIZE) * GRID_SIZE, 0, 0);

                                }
                                else
                                {
                                    g.Margin = new Thickness(((GateLocation)g.Tag).X, ((GateLocation)g.Tag).Y, 0, 0);
                                }

                                Point np = new Point(g.Margin.Left, g.Margin.Top);
              

                                SizeCanvas();
                                g.BringIntoView(); // still needed because gate larger than 20px block
                            }

                            if (e.RightButton == MouseButtonState.Pressed)
                            {
                                Gate rotateSrc = selected[selected.Count - 1];
                                Point mpp = rotateSrc.TranslatePoint(new Point(32, 32), GC);
                                double dx = mp2.X - mpp.X;
                                double dy = mp2.Y - mpp.Y;


                                double newtheta = Math.Atan2(dy, dx) * (180.0 / Math.PI);

                                dx = mp.X - mpp.X;
                                dy = mp.Y - mpp.Y;
                                double theta = Math.Atan2(dy, dx) * (180.0 / Math.PI);


                                // the snap-to messes up the rotation
                                // so we store smooth angle in the tag
                                // and actual snapped angle in the transform
                                double na = ((GateLocation)g.Tag).Angle + newtheta - theta;
                                if (na < 0) na += 360;
                                if (na >= 360) na -= 360;
                                ((GateLocation)g.Tag).Angle = na;

                                double or = ((RotateTransform)g.RenderTransform).Angle;

                                // snap-to corners
                                if (na >= 360 - ANGLE_SNAP_DEG || na <= ANGLE_SNAP_DEG) na = 0;
                                if (na >= 270 - ANGLE_SNAP_DEG && na <= 270 + ANGLE_SNAP_DEG) na = 270;
                                if (na >= 180 - ANGLE_SNAP_DEG && na <= 180 + ANGLE_SNAP_DEG) na = 180;
                                if (na >= 90 - ANGLE_SNAP_DEG && na <= 90 + ANGLE_SNAP_DEG) na = 90;


                                ((RotateTransform)g.RenderTransform).Angle = na;
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

                            // select any gates inside the rectangle
                            Rect select = new Rect(x1, y1, width, height);
                            foreach (Gate g in gates.Values)
                            {
                                Rect grect = new Rect(g.Margin.Left, g.Margin.Top, g.Width, g.Height);
                                if (select.IntersectsWith(grect) && !g.Selected)
                                {
                                    g.Selected = true;
                                    selected.Add(g);
                                }

                                // this is not the same as just "not" or else the above
                                if (!select.IntersectsWith(grect) && g.Selected)
                                {
                                    g.Selected = false;
                                    selected.Remove(g);
                                }


                            }
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
            AbstractGate gate = uigate.AbGate;

            gates[gate] = uigate;
            uigate.Margin = new Thickness(pos.X, pos.Y, 0, 0);

            GC.Children.Add(uigate);

            //uigate.RenderTransform = new RotateTransform(pos.Angle, uigate.Width/2.0, uigate.Height/2.0);
            //uigate.Tag = new GateLocation() {X = pos.X, Y = pos.Y, Angle = pos.Angle};
            
        }

        public void AddGate(Gates.AbstractGate gate, GateLocation pos)
        {
            Gate uigate;

            uigate = new SmallTray((Gates.Trays.SmallTray)gate);

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
