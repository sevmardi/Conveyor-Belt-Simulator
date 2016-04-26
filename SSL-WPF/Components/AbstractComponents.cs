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

        public event PropertyChangedEventHandler PropertyChanged;

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
