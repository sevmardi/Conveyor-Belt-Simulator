using System.Threading;

namespace LaneTop
{
    /// <summary>
    /// This class represetns a wall which signels for tray to move on or stop
    /// </summary>
    class Semaphore
    {
        private int count = 0;
        
        /// <summary>
        /// 
        /// </summary>
        public void Wait()
        {
            lock (this)
            {
                while (count == 0)
                {
                    Monitor.Wait(this);
                }
                count = 0;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Signal()
        {
            lock (this)
            {
                count = 1;
                Monitor.Pulse(this);
            }
        }
    }
}
