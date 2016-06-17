using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            ConveyorA = new ObservableCollection<ObjectToMove>();
            ConveyorB = new ObservableCollection<ObjectToMove>();
        }

        public ObservableCollection<ObjectToMove> ConveyorA { get; set; }
        public ObservableCollection<ObjectToMove> ConveyorB { get; set; }

    }
}
