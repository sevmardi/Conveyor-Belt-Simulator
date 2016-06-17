using System;
using System.Timers;


namespace LaneSimulator.Model
{
    class SensorTimerHandler
    {
        public SensorTimerHandler()
        {
            //
        }
        /// <summary>
        /// Timer for the sensors. 
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="callback"></param>
        public void Timer(int interval, ElapsedEventHandler callback)
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(callback);
            aTimer.Interval = interval;
            aTimer.Enabled = true;
            aTimer.Elapsed += (s, e) => { aTimer.Stop(); };
        }
    }
}
