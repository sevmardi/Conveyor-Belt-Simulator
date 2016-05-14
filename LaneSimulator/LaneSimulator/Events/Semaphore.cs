using System.Threading;

namespace LaneSimulator.Events
{
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
