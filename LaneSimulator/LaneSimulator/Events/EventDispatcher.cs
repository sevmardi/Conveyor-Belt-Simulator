using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Threading;

namespace LaneSimulator.Events
{
    /// <summary>
    /// Just a quick wrapper class to allow events which occur in a non-UI thread
    /// to be "transferred" over to the UI thread so they can perform UI updates.
    /// </summary>
    internal class EventDispatcher
    {
        public static Dispatcher BatchDispatcher { get; set; }

        protected static Dictionary<KeyValuePair<Gates.AbstractGate, PropertyChangedEventHandler>, Action>
            BatchNotifications = new Dictionary<KeyValuePair<Gates.AbstractGate, PropertyChangedEventHandler>, Action>();


        protected static Thread Bw;

        protected static void bw_work()
        {
            while (true)
            {
                if (BatchDispatcher != null)
                {
                    var toBeDispatched = new List<Action>();
                    lock (BatchNotifications)
                    {
                        toBeDispatched.AddRange(BatchNotifications.Values);

                        BatchNotifications.Clear();
                    }
                    BatchDispatcher.BeginInvoke(new Action(() =>
                    {
                        foreach (var act in toBeDispatched)
                            act(); // execute the action from the queue
                    }));
                }
                Thread.Sleep(100);
            }
        }

        public static PropertyChangedEventHandler CreateBatchDispatchedHandler(Gates.AbstractGate g,
            PropertyChangedEventHandler handler)
        {
            if (Bw == null)
            {
                Bw = new Thread(bw_work)
                {
                    IsBackground = true,
                    Priority = ThreadPriority.BelowNormal
                };
                Bw.Start();
            }
            return (sender, e) =>
            {
                lock (BatchNotifications)
                {
                    BatchNotifications[new KeyValuePair<Gates.AbstractGate, PropertyChangedEventHandler>(g, handler)] =
                        () => { handler(sender, e); };
                }
            };
        }


        public static PropertyChangedEventHandler CreateDispatchedHandler(Dispatcher disp,
            PropertyChangedEventHandler handler)
        {
            return CreateDispatchedHandler(disp, DispatcherPriority.ApplicationIdle, handler);
        }

        public static PropertyChangedEventHandler CreateDispatchedHandler(Dispatcher disp, DispatcherPriority dp,
            PropertyChangedEventHandler handler)
        {
            return (sender, e) => { disp.BeginInvoke(handler, dp, sender, e); };
        }
    }
}
