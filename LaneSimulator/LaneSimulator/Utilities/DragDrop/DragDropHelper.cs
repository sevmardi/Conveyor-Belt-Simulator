using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Controls;


namespace LaneSimulator.Utilities.DragDrop
{
    class DragDropHelper
    {
        #region Private Members
        private Point _initialMousePosition;
        private Point _delta;
        private Point _scrollTarget;
        private UIElement _dropTarget;
        private Rect _dropBoundingBox;
        private bool _mouseCaptured;
        private object _draggedData;

        private Window _topWindow;
        private Canvas _adornerLayer;
        private DragDropAdornerBase _adorner;

        private static DragDropHelper instance;
        private static DragDropHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DragDropHelper();
                }
                return instance;
            }
        }



        #endregion

        #region Attached Properties
        public static bool GetIsDragSource(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsDragSourceProperty);
        }
        public static void SetIsDragSource(DependencyObject obj, bool value)
        {
            obj.SetValue(IsDragSourceProperty, value);
        }
        public static UIElement GetDragDropControl(DependencyObject obj)
        {
            return (UIElement)obj.GetValue(DragDropControlProperty);
        }
        public static void SetDragDropControl(DependencyObject obj, UIElement value)
        {
            obj.SetValue(DragDropControlProperty, value);
        }
        public static string GetDropTarget(DependencyObject obj)
        {
            return (string)obj.GetValue(DropTargetProperty);
        }
        public static void SetDropTarget(DependencyObject obj, string value)
        {
            obj.SetValue(DropTargetProperty, value);
        }
        public static string GetAdornerLayer(DependencyObject obj)
        {
            return (string)obj.GetValue(AdornerLayerProperty);
        }
        public static void SetAdornerLayer(DependencyObject obj, string value)
        {
            obj.SetValue(AdornerLayerProperty, value);
        }

        public static readonly DependencyProperty IsDragSourceProperty =
            DependencyProperty.RegisterAttached("IsDragSource", typeof(bool), typeof(DragDropHelper), new UIPropertyMetadata(false, IsDragSourceChanged));

        public static readonly DependencyProperty DragDropControlProperty =
            DependencyProperty.RegisterAttached("DragDropControl", typeof(UIElement), typeof(DragDropHelper), new UIPropertyMetadata(null));

        public static readonly DependencyProperty AdornerLayerProperty =
             DependencyProperty.RegisterAttached("AdornerLayer", typeof(string), typeof(DragDropHelper), new UIPropertyMetadata(null));

        public static readonly DependencyProperty DropTargetProperty =
            DependencyProperty.RegisterAttached("DropTarget", typeof(string), typeof(DragDropHelper), new UIPropertyMetadata(string.Empty));



        private static void IsDragSourceChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var dragSource = obj as UIElement;
            if (dragSource != null)
            {
                if (Object.Equals(e.NewValue, true))
                {
                    //dragSource.PreviewMouseLeftButtonDown += Instance.DragSource_PreviewMouseLeftButtonDown;
                    //dragSource.PreviewMouseLeftButtonUp += Instance.DragSource_PreviewMouseLeftButtonUp;
                    //dragSource.PreviewMouseMove += Instance.DragSource_PreviewMouseMove;
                }
                else
                {
                    //dragSource.PreviewMouseLeftButtonDown -= Instance.DragSource_PreviewMouseLeftButtonDown;
                    //dragSource.PreviewMouseLeftButtonUp -= Instance.DragSource_PreviewMouseLeftButtonUp;
                    //dragSource.PreviewMouseMove -= Instance.DragSource_PreviewMouseMove;
                }
            }
        }




        #endregion

        #region Utilities
        public static FrameworkElement FindAncestor(Type ancestorType, Visual visual)
        {
            while (visual != null && !ancestorType.IsInstanceOfType(visual))
            {
                visual = (Visual)VisualTreeHelper.GetParent(visual);
            }
            return visual as FrameworkElement;
        }

        public static bool IsMovementBigEnough(Point initialMousePosition, Point currentPosition)
        {
            return (Math.Abs(currentPosition.X - initialMousePosition.X) >= SystemParameters.MinimumHorizontalDragDistance ||
                 Math.Abs(currentPosition.Y - initialMousePosition.Y) >= SystemParameters.MinimumVerticalDragDistance);
        }
        #endregion

    

        #region Events
        public static event EventHandler<DragDropEventArgs> ItemDropped;
        #endregion
    }

    public class DragDropEventArgs : EventArgs
    {
        public object Content;
        public Point Position;
        public UIElement DropTarget;
        public DragDropEventArgs() { }
        public DragDropEventArgs(object content, Point pos, UIElement dropTarget)
        {
            Content = content;
            Position = pos;
            DropTarget = dropTarget;
        }
    }
}
