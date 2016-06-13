﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class Semaphore
    {
        public int count = 0;

        public void wait()
        {
            lock (this)
            {
                while (count == 0)
                    Monitor.Wait(this);

                count = 0;
            }
        }

        public void signal()
        {
            lock (this)
            {
                count = 1;
                Monitor.Pulse(this);
            } 
        }

    }
}
