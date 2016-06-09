
using System.Threading;
using LaneSimulator.UIGates;

namespace LaneSimulator.Events
{
   public class Buffer
    {
        private SmallTray smallTray;
        private bool ReachingPoint = true;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="smallTray"></param>
        public void Read(ref SmallTray smallTray)
        {
            lock (this)
            {
                if (ReachingPoint)
                {
                    Monitor.Wait(this);
                    ReachingPoint = true;
                    smallTray = this.smallTray;
                    Monitor.Pulse(this);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="smallTray"></param>
        public void Write(SmallTray smallTray)
        {
            lock (this)
            {
                if ( ! ReachingPoint)
                    Monitor.Wait(this);
                ReachingPoint = false;
                this.smallTray = smallTray;
                Monitor.Pulse(this);
            }
        }


    }
}
