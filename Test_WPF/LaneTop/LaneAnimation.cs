using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace LaneTop
{
    class LaneAnimation
    {
       public  Storyboard SB;

        /// <summary>
        /// Constructor
        /// </summary>
       public LaneAnimation()
       {
            SB = new Storyboard();
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
         

    }
}
