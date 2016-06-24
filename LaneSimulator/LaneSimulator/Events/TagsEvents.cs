using System;
using System.Collections.Generic;
using System.Data;
using System.Timers;

namespace LaneSimulator.Events
{

    /// <summary>
    /// NOT USED
    /// </summary>
    class TagsEvents
    {
        public delegate void DataChangedEventHandler(string address, double newValue);

        private readonly Timer _tmr = new Timer();

        public event DataChangedEventHandler OnDataChanged;

        public void StartTimer(DataTable dt)
        {
            AddTagList(dt);
            SetInitialVales();
            _tmr.Elapsed += Timerticks;
            _tmr.Interval = 250;
            _tmr.Enabled = true;
            _tmr.Start();
        }

        private void StopTimer()
        {
            _tmr.Enabled = false;
            _tmr.Stop();
        }

        private readonly List<string> _tagValues = new List<string>();
        private readonly List<string> _oldValues = new List<string>();
        private readonly List<string> _newValues = new List<string>();

        private void AddTagList(DataTable dt)
        {
            int ILoop = 0;

            foreach (DataRow row in dt.Rows)
            {
                _tagValues.Add((string)row["Path"]);
                ILoop = ILoop + 1;
            }
        }

        private void SetInitialVales()
        {
            int iLoop = 0;
            foreach (string vals in _tagValues)
            {
                var rd = ReadTag(vals);
                _oldValues.Add(rd.ToString());
                _newValues.Add(rd.ToString());
                iLoop = iLoop + 1;
            }
            //newValues = oldValues
        }

        private object ReadTag(string vals)
        {
            throw new NotImplementedException();
        }


        private void Timerticks(object sender, EventArgs eventArgs)
        {
            int iLoop = 0;
            foreach (string vals in _tagValues)
            {
                _oldValues[iLoop] = ReadTag(vals).ToString();
                if (_oldValues[iLoop] != _newValues[iLoop])
                {
                    _newValues[iLoop] = _oldValues[iLoop];
                    if (OnDataChanged != null)
                    {
                        OnDataChanged(vals, Convert.ToInt32(_newValues[iLoop]));
                    }
                }
                iLoop = iLoop + 1;
            }
        }
    }
}
