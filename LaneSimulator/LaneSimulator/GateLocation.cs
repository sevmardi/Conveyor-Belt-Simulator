using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LaneSimulator
{
    /// <summary>
    /// Serves the same purpose as a Point class, but expanded to include angle
    /// </summary>
    /// 
   public  class GateLocation
    {
        /// <summary>
        /// The angle as directly read or saved in a RotateTransform
        /// </summary>
        public double Angle { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }


        public GateLocation() { }

        /// <summary>
        /// Create based on a Point; angle = 0
        /// </summary>
        /// <param name="p"></param>
        public GateLocation(Point p)
        {
            this.X = p.X;
            this.Y = p.Y;
        }
        public Point GetPoint()
        {
            return new Point(X, Y);
        }
        public Rect GetRect()
        {
            return new Rect(GetPoint(), new Size(Width, Height));
        }

    }
}
