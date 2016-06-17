using System.Collections.ObjectModel;

namespace WpfApplication1
{
    class ViewModel
    {
        public ViewModel()
        {
            ConveyorA = new ObservableCollection<ObjectToMove>();
            ConveyorB = new ObservableCollection<ObjectToMove>();

        }

        public ObservableCollection<ObjectToMove> ConveyorA { get; set; }
        public ObservableCollection<ObjectToMove> ConveyorB { get; set; }

    }
}
