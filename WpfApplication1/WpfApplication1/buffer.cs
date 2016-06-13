using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class buffer
    {
        private ObjectToMove ObjectToMove;
        private bool empty = true;

        public void read(ref ObjectToMove move)
        {
            lock (this)
            {
                if (empty)
                {
                    Monitor.Wait(this);
                    empty = true;
                    move = this.ObjectToMove;
                    Monitor.Pulse(this);

                }
            }
        }

        public void write(ObjectToMove move)
        {
            lock (this)
            {
                if (!empty)
                    Monitor.Wait(this);
                empty = false;
                this.ObjectToMove = move;
                Monitor.Pulse(this);

            }
        }
    }
}
