using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Components
{
    /// <summary>
    /// Generalized framework for a UI,  consisting of inputs and outputs.
    /// </summary>
    /// 
    public abstract class AbstractComponents : INotifyPropertyChanged
    {
        private bool[] outp;
        private bool[] inp;

        /// <summary>
        /// Inputs and outputs are indexed from 0.  The total number of
        /// each is specified in the constructor parameters.
        /// </summary>
        /// <param name="numInputs"></param>
        /// <param name="numOutputs"></param>
        public AbstractComponents(int numInputs, int numOutputs)
        {
            inp = new bool[numInputs];
            outp = new bool[numOutputs];
    
        }

        /// <summary>
        /// Number of inputs for this gate.  The number of
        /// outputs can be determined by checking the length
        /// from the public Output property.
        /// </summary>
        public int NumberofInupts
        {
            get
            {
                return inp.Length;
            }
        }

        /// <summary>
        /// View or edit the state of an input value.
        /// </summary>
        /// <param name="index">The input index</param>
        /// <returns>The input value</returns>
        /// 
        public bool this[int index]
        {
            get
            {

                return inp[index];
            }

            set
            {
                inp[index] = value;
                NotifyPropertyChanged("this");
                RunCompute();
            }
        }

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
        /// The name of the gate, usually "sensor", "motor", etc.
        /// </summary>
        public abstract string Name { get; }


        public void RunCompute()
        {
            bool[] newoutp = Compute(inp);
            for(int i = 0; i < newoutp.Length; i++)
                if (outp[i] != newoutp[i])
                {
                    // make this the new outputs 

                    outp = newoutp;
                    NotifyPropertyChanged("Output");
                    // no need to continue searching for a change
                    return;
                }

        }

        /// <summary>
        /// Called when any input value may have changed.
        /// Each specific gate should fill in logic to
        /// compute the outputs based on the given input array.
        /// </summary>
        /// <param name="inp">The input values to use.</param>
        /// <returns>The appropriate output values.</returns>
        protected abstract bool[] Compute(bool[] inp);



        /// <summary>
        /// Create a deep clone of this gate. Recursively clones
        /// all the way down, to create a completely seperate gate.
        /// </summary>
        /// <returns></returns>
        /// 
        public virtual AbstractComponents clone()
        {
            return (AbstractComponents)Activator.CreateInstance(GetType());
        }


























    }


}
