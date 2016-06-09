using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media.Animation;
using LaneSimulator.UIGates;

namespace LaneSimulator.Utilities
{
    /// <summary>
    /// Allows UI elements to be faded in and out.
    /// </summary>
    class Fader
    {
        public static void AnimateOpacity(double dest, params UIElement[] target)
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

        public static void AnimateObjectOpacity(double dest, params SmallTray[] target)
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
