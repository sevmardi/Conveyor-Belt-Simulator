using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;
using Gates;

namespace LaneSimulator.UIGates
{
    public class ShapeGate : Gate
    {
        private Path ph;


        public ShapeGate(Gates.AbstractGate abgate, string path)
        {
            ph = new Path();
            ph.StrokeEndLineCap = PenLineCap.Square;
            ph.StrokeStartLineCap = PenLineCap.Triangle;
            ph.Data = StreamGeometry.Parse(path);
            ph.Stroke = Brushes.Black;
            ph.StrokeThickness = 2;
            ph.Fill = Brushes.White;
            myCanvas.Children.Add(ph);
        }

        protected void ShapeGate_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            // note that this based on 64x64 gates only with with centered 30 tall shapes
            // not suitable for other sizes
            ph.RenderTransform = new ScaleTransform(1, (Height - 32.0) / 32.0, 0, 15.0);
        }
    }

    public class SmallTray : ShapeGate
    {
        #region collision and solve this

        public bool IsColliding(SmallTray otherSmallTray)
        {
            bool ret = false;

            var dx = otherSmallTray.TrayTranslateTransform.X - TrayTranslateTransform.X;
            var dY = otherSmallTray.TrayTranslateTransform.Y - TrayTranslateTransform.Y;

            var h = Math.Sqrt(dx * dx + dY * dY);

            ret = (h < 40);

            return ret;
        }

        public void RresolveCollision(SmallTray other)
        {
            //
        }

        #endregion

        #region props


        public TranslateTransform TrayTranslateTransform { get; set; }
        #endregion


        public SmallTray() : this(new Gates.Trays.SmallTray()){}

        public SmallTray(Gates.AbstractGate abgate) : base(abgate, "M 17,17 v 30 h 15 a 2,2 1 0 0 0,-30 h -15") { }
    }


    public class LargeTray : ShapeGate
    {
//        public LargeTray() : this(new Gates.Trays.LargeTray()) { }

        public LargeTray(AbstractGate abgate, string path) : base(abgate, path)
        {
            //
        }
    }


}
