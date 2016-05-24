using System;

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
            Timer_Lable.Text = (this.T = this.T + 0.1).ToString("0.00",
                (IFormatProvider)CultureInfo.InvariantCulture);
        }

        //public Rect GetBounds(double padding, bool selectedOnly)
        //{
        //    if (selectedOnly)
        //        return GetBounds(selected, padding);
        //    else
        //        return GetBounds(gates.Values, padding);
        //}


        //mouse up event for canvas clicks

        private void GateCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            dragging = DragState.NONE;
            dragSelect.Width = 0;
            dragSelect.Height = 0;
            dragSelect.Margin = new Thickness(0, 0, 0, 0);
            dragSelect.Visibility = Visibility.Hidden;

            //dragWire.Destination = new Point(0, 0);
            //dragWire.Origin = new Point(0, 0);

            // unhightlight all
            //foreach (Gates.AbstractGate ag in gates.Keys)
            //{

            //    for (int i = 0; i < ag.Output.Length; i++)
            //    {
            //        gates[ag].FindTerminal(false, i).t.Highlight = false;
            //    }

            //    for (int i = 0; i < ag.NumberOfInputs; i++)
            //    {
            //        gates[ag].FindTerminal(true, i).t.Highlight = false;
            //    }
            //}

            //if (UndoProvider != null && moves != null && moves.Count > 0)
            //    UndoProvider.Add(moves);
            //moves = null;

            ReadyToSelect = false;
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

    }
}
