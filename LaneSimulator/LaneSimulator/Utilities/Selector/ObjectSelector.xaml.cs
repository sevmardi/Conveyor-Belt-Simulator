using System;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using LaneSimulator.Models.Components;

namespace LaneSimulator.Utilities.Selector
{
    /// <summary>
    /// Interaction logic for ObjectSelector.xaml
    /// </summary>
    public partial class ObjectSelector : UserControl
    {

        private const double MAX_SIZE = 100;

        public ObjectSelector()
        {
            InitializeComponent();

            Tray.DataContext = new Tray();
        }

        private void SetInfoLine(Tray tray)
        {
            string inf = "Left-drag and place at the beginning of the lane ";

            InfoLine.SetInfo(tray, inf);
        }

        private void AddDragDropObject(int pos, Tray tray)
        {
           
            DragDrop.DragDropHelper.SetIsDragSource(tray, true);
            DragDrop.DragDropHelper.SetDragDropControl(tray, new DragDrop.ObjectDragDropAdorner());
            DragDrop.DragDropHelper.SetDropTarget(tray, "SSLCanvas");
            DragDrop.DragDropHelper.SetAdornerLayer(tray, "adornerLayer");


            //ScaleTransform st = new ScaleTransform();
            //st.CenterX = tray.Width / 2.0;
            //st.CenterY = tray.Height / 2.0;


        }




    }

    public class ExpanderHeightConverter : IMultiValueConverter
    {
        #region IMultiValueConverter Members

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double result = 1.0;
            foreach (object v in values)
                if (v is double)
                    result *= (double)v;

            result += 22; // minimum height to show header

            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
