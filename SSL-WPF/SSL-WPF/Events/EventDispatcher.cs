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
      
        protected Thread bw;
           
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
                         toBeDispatched.AddRange(BatchNotifications.values);

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

       

      
    }
}
