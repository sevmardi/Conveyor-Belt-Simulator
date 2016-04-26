using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Threading;
using System.Windows;
using System.ComponentModel;

namespace SSL_WPF.Events
{
    class EventDispatcher
    {
        public static Dispatcher BatchDispatcher { get; set; }
        protected static Dictionary<KeyValuePair<Components.AbstractComponents, PropertyChangedEventHandler>, Action> BatchNotifications = new Dictionary<KeyValuePair<Components.AbstractComponents, PropertyChangedEventHandler>, Action>();

        protected static Thread  bw;
           
         protected static void bw_DoWork()
         {
             DateTime LastBatchDispatch = DateTime.Now;
             while (true)
             {
                 if (BatchDispatcher != null)
                 {
                     List<Action> toBeDispatched = new List<Action>();
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
                 System.Threading.Thread.Sleep(100);

             }
         }


         public static PropertyChangedEventHandler CreateBatchDispatchedHandler(Components.AbstractComponents g, PropertyChangedEventHandler handler)
         {
             if (bw == null)
             {
                 bw = new Thread(bw_DoWork);
                 bw.IsBackground = true;
                 bw.Priority = ThreadPriority.BelowNormal;
                 bw.Start();
             }
             return new PropertyChangedEventHandler((sender, e) =>
             {
                 lock (BatchNotifications)
                 {
                     BatchNotifications[new KeyValuePair<Components.AbstractComponents, PropertyChangedEventHandler>(g, handler)] = new Action(() => { handler(sender, e); });

                 }
             });
         }

       

      
    }
}
