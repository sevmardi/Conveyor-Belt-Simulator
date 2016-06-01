using System.Windows.Shapes;
using System.Windows;

namespace LaneTop
{
    public interface  Conveyor
    {
        Path trackpath { get; }
        Size GetSize();
    }
}
