using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Timers;

namespace LaneTop.Events
{
    class TagsEvents
    {
        public delegate void DataChangedEventHandler(string TagName, int NewValue);

        private Timer tmr = new Timer();

        public event DataChangedEventHandler OnDataChanged;

        public void StartTimer(DataTable dt)
        {
            AddTagList(dt);
            SetInitialVales();
            tmr.Elapsed += timerticks;
            tmr.Interval = 250;
            tmr.Enabled = true;
            tmr.Start();
        }

        private void StopTimer()
        {
            tmr.Enabled = false;
            tmr.Stop();
        }

        private List<string> TagValues = new List<string>();
        private List<string> oldValues = new List<string>();
        private List<string> newValues = new List<string>();

        private void AddTagList(DataTable dt)
        {
            int ILoop = 0;

            foreach (DataRow row in dt.Rows)
            {
                TagValues.Add((string)row["Path"]);
                ILoop = ILoop + 1;
            }
        }

        private void SetInitialVales()
        {
            int iLoop = 0;
            foreach (string vals in TagValues)
            {
                var rd = ReadTag(vals);
                oldValues.Add(rd.ToString());
                newValues.Add(rd.ToString());
                iLoop = iLoop + 1;
            }
            //newValues = oldValues
        }

        private object ReadTag(string vals)
        {
            throw new NotImplementedException();
        }


        private void timerticks(object sender, EventArgs eventArgs)
        {
            int iLoop = 0;
            foreach (string vals in TagValues)
            {
                oldValues[iLoop] = ReadTag(vals).ToString();
                if (oldValues[iLoop] != newValues[iLoop])
                {
                    newValues[iLoop] = oldValues[iLoop];
                    if (OnDataChanged != null)
                    {
                        OnDataChanged(vals, Convert.ToInt32(newValues[iLoop]));
                    }
                }
                iLoop = iLoop + 1;
            }
        }

    }
}
