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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LaneSimulator
{
    /// <summary>
    /// Interaction logic for SSLCanvas.xaml
    /// </summary>
    public partial class SSLCanvas : UserControl
    {
        private DragState dragging = DragState.NONE;

        private const double ANGLE_SNAP_DEG = 10;
        private const double DELTA_SNAP = 5;
        private const double GRID_SIZE = 32;

        public SSLCanvas()
        {
            InitializeComponent();
        }

        protected enum DragState
        {
            NONE, MOVE
        }


        public void Scroller_LayoutUpdated(object sender, EventArgs e)
        {
            //

        }
        private void Scroller_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            //
        }

        private void Scroller_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void SizeCanvas()
        {
            //    
        }

        public bool DisableSizeCanvas { get; set; }

    }
}
