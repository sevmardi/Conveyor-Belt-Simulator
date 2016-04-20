using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SSL_WPF
{
    /// <summary>
    /// Interaction logic for SSLCanvas.xaml
    /// </summary>
    public partial class SSLCanvas : UserControl
    {

        private bool ReadyToSelect = false;

        private bool _ro = false;
        private bool _iso = false;

        private const double ANGLE_SNAP_DEG = 10;
        private const double DELTA_SNAP = 5;
        private const double GRID_SIZE = 32;

        private Brush oldBackground;
        private bool _mute;


        private double _zoom = 1.0;

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
    }
}
