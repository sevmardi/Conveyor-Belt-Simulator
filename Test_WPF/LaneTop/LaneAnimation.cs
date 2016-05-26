using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace LaneTop
{
    class LaneAnimation
    {
       public  Storyboard SB;
       private MainWindow _mainWindow;
       protected int delay;


        public LaneAnimation()
        {
            //_mainWindow  = new MainWindow();
        }
       private bool AnimationPaused()
       {
           
           bool pauze = false;

           if (SB.GetIsPaused())
           {
               SB.Resume();
               pauze = true;

               return pauze;
           }

           return pauze;

       }
        /// <summary>
        /// Stop Animation
        /// </summary>
        public  void StopAnimation()
        {
           SB.Stop();
        }

        public void AddAnimation()
        {

            Thread.Sleep(delay);


        }


        public void storyboard1()
        {
            var sub1 = _mainWindow.TryFindResource("Storyboard1") as Storyboard;
            if (sub1 != null) sub1.Begin();
        }
    }
}
