using System;
using System.ComponentModel;

namespace Gates
{
    public abstract class AbstractGate : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public abstract string Name { get; }


        /// <summary>
        /// Create a deep clone of this gate. Recursively clones
        /// all the way down, to create a completely seperate gate.
        /// </summary>
        /// <returns></returns>
        public virtual AbstractGate Clone()
        {
            return (AbstractGate)Activator.CreateInstance(GetType());
        }
    }

    
}
