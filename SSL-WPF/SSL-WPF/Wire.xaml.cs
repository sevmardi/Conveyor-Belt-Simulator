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
using System.Windows.Media.Animation;

namespace SSL_WPF
{
    /// <summary>
    /// An animated wire which can show a flow of current from an origin to destination.
    /// </summary>
    public partial class Wire : UserControl
    {
        private TranslateTransform flowOffset;
        private LinearGradientBrush flow;
        private BezierSegment bz;
        private PathFigure pf;
        private DoubleAnimation da;
        private Point _origin, _dest;
        private delegate void SetFillDelegate(bool value);

        public Wire()
        {
            InitializeComponent();

            flow = new LinearGradientBrush(Colors.White, Colors.Red, 0);
            flow.MappingMode = BrushMappingMode.Absolute;
            flow.SpreadMethod = GradientSpreadMethod.Repeat;

            pf = new PathFigure();
            bz = new BezierSegment();
            pf.Segments.Add(bz);
            PathGeometry pg = new PathGeometry(new PathFigure[] { pf });
            Inner.Data = pg;
            Outer.Data = pg;

            Inner.Stroke = Brushes.White;


        }


        private void setFill(bool value)
        {
            if (value)
            {
                Inner.Stroke = flow;
            }
            else
                Inner.Stroke = Brushes.White;
        }

        /// <summary>
        /// Set the flow (on or off) for this wire.  
        /// </summary>
        public bool value
        {
            set
            {
                setFill(value);
            }
        }



        /// <summary>
        /// Gets or sets the origin point of this wire.
        /// </summary>
        public Point Origin
        {
            get
            {
                return _origin;
            }
            set
            {
                _origin = value;
               // Recompute();
            }

        }

        /// <summary>
        /// Gets or sets the destination point of this wire.
        /// </summary>
        public Point Destination
        {
            get
            {
                return _dest;
            }
            set
            {
                _dest = value;
               // Recompute();
            }
        }

    }
}
