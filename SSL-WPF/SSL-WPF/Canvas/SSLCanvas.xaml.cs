using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using Components;

namespace SSL_WPF
{
    // <summary>
    /// The SSL canvas contains a group of visual UIs and wires which represent a lane.
    /// Changes may be made at various levels; to the circuit directly (which then manifest visually),
    /// or to visual representations which in some cases can be transmitted to the circuit.
    /// The gate canvas is one of the center-points of this application, coordinating activity
    /// between many different objects.
    /// </summary>
    public partial class SSLCanvas : UserControl
    {
        //the name of Motor/sensor, if any.
        private string name;

        /// <summary>
        /// A list of selected stuff.  Must be coordinated with the Selected
        /// property on each one.
        /// </summary>
        public BindingList<SSL> selected = new BindingList<SSL>();


       

        private bool _ro = false;
        private bool _iso = false;



        private Dictionary<Components.AbstractComponents, SSL> SSLs = new Dictionary<AbstractComponents, SSL>();
        private DragState dragging = DragState.NONE;
        private bool ReadyToSelect = false;
        private Point mp;
        private Point sp;
        private double _zoom = 1.0;
        private UndoRedo.Transaction moves;
        private Brush oldBackground;
        private bool _mute;

        private const double ANGLE_SNAP_DEG = 10;
        private const double DELTA_SNAP = 5;
        private const double GRID_SIZE = 32;

        /// <summary>
        /// All UI Gates on this canvas.
        /// </summary>
        /// 
        public IEnumerable<SSL> SSL
        {
            get
            {

                return SSLs.Values;
            }
        }

        public SSLCanvas()
        {
            InitializeComponent();
        }

        private void SizeCanvas()
        {
            // green team notes:  increased size to make scroll bars visible on start
            // this will ensure the mouse center zoom method works on start up
            double maxx = (SSLScroller.ViewportWidth / _zoom);
            double maxy = (SSLScroller.ViewportHeight / _zoom);

            //foreach (Gate g in gates.Values)
            //{
            //    maxx = Math.Max(maxx, g.Margin.Left + g.Width + 64);
            //    maxy = Math.Max(maxy, g.Margin.Top + g.Height + 64);

            //}

           // GC.Width = maxx;
            //GC.Height = maxy;

        }
        public bool DisableSizeCanvas { get; set; }

        private void SSLScroller_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (!_mute && !DisableSizeCanvas)
                SizeCanvas();
        }

        private void SSLScroller_LayoutUpdated(object sender, EventArgs e)
        {
            if (!_mute && !DisableSizeCanvas)
                SizeCanvas();
        }

        private void SSLScroller_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {

            //if (dragging == DragState.MOVE)
            //{
            //    System.Threading.Thread.Sleep(100); // don't let them scroll themselves into oblivion
            //}

        }

        protected enum DragState
        {
            NONE, MOVE, CONNECT_TO, CONNECT_FROM
        }




   


    }
}
