using System.Collections.ObjectModel;

namespace WpfApplication1
{
    public class Viewmodel
    {
        public ObservableCollection<BoxData> ItemsA { get; set; }

        public Viewmodel()
        {
            ItemsA = new ObservableCollection<BoxData> { new BoxData() };
        }

    }
}
