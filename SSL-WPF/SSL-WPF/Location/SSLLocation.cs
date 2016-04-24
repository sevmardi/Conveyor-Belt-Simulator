using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;


namespace SSL_WPF
{
    /// <summary>
    /// Serves the same purpose as a Point class, but expanded to include angle
    /// </summary>
    class SSLLocation
    {
        public double Angle { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public SSLLocation() { }

        public SSLLocation(Point p)
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
