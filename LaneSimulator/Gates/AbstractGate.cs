using System.ComponentModel;

namespace Gates
{
    public abstract class AbstractGate : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
