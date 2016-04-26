using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Components
{
    public abstract class AbstractComponents : INotifyPropertyChanged
    {
        private bool[] outp;
        private bool[] inp;

        #region INotifyPropertyChanged Members

        protected void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
        /// <summary>
        /// Retrieve an output value.
        /// </summary>
        public bool[] Output
        {
            get
            {
                return (bool[])outp.Clone();
            }
        }


        /// <summary>
        /// The name of the gate, usually "and", "not", etc.
        /// </summary>
        public abstract string Name { get; }




























    }


}
