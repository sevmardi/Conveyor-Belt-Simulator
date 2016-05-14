using LaneSimulator.Objects;
using System.Threading;

namespace LaneSimulator.Events
{
    class Buffer
    {
        private Tray tray;
        private bool ReachingPoint = true;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tray"></param>
        public void Read(ref Tray tray)
        {
            lock (this)
            {
                if (ReachingPoint)
                {
                    Monitor.Wait(this);
                    ReachingPoint = true;
                    tray = this.tray;
                    Monitor.Pulse(this);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tray"></param>
        public void Write(Tray tray)
        {
            lock (this)
            {
                if (!ReachingPoint)
                    Monitor.Wait(this);
                ReachingPoint = false;
                this.tray = tray;
                Monitor.Pulse(this);
            }
        }


    }
}
