using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Media.Animation;
using System.Windows;

namespace SSL_WPF.Utility
{
    /// <summary>
    /// Allows UI elements to be faded in and out.
    /// </summary>
    /// 
    public static class Fader
    {
        public static void AnimationOpacity(double dest, params UIElement[] target)
        {
            if(dest > 0)
                foreach (UIElement t in target)
                {
                    t.Visibility = Visibility.Visible;
                }

            DoubleAnimation doubleAnimation = new DoubleAnimation(dest, new Duration(new TimeSpan(0, 0, 0, 0, 500)));
            doubleAnimation.AccelerationRatio = 0.2;
            doubleAnimation.DecelerationRatio = 0.2;

            IEnumerable<Storyboard> sbs = target.Select(t =>
            {
                Storyboard sb = new Storyboard();
                sb.Children.Add(doubleAnimation);

                Storyboard.SetTarget(doubleAnimation, t);
                Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(UIElement.OpacityProperty));
                sb.FillBehavior = FillBehavior.Stop;

                sb.Completed += (sender2, e2) =>
                {
                    t.Opacity = dest;
                    if (dest == 0)
                        t.Visibility = Visibility.Collapsed;

                };
                return sb;
            });

            foreach (Storyboard sb in sbs)
            {
                sb.Begin();
            }
        }



        public static void AnimationSSLOpacity(double dest, params SSL[] target)
        {
            if (dest > 0)
                foreach (UIElement t in target)
                    t.Visibility = Visibility.Visible;

            DoubleAnimation da = new DoubleAnimation(dest, new Duration(new TimeSpan(0, 0, 0, 0, 500)));
            da.AccelerationRatio = 0.2;
            da.DecelerationRatio = 0.2;

            IEnumerable<Storyboard> sbs = target.Select(t =>
            {
                Storyboard sb = new Storyboard();
                sb.Children.Add(da);

                Storyboard.SetTarget(da, t);
                Storyboard.SetTargetProperty(da, new PropertyPath(UIElement.OpacityProperty));
                sb.FillBehavior = FillBehavior.Stop;

                sb.Completed += (sender2, e2) =>
                {
                    t.Opacity = dest;
                    if (dest == 0)
                        t.Visibility = Visibility.Collapsed;

                };

                return sb;
            });

            foreach (Storyboard sb in sbs)
            {
                sb.Begin();
            }
        }
    }
}
