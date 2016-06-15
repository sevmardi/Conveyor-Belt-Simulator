using System;
using System.Windows;

namespace wpf_ItemsControl_Canvas_Animation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _mainWindowView;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Timeline_OnCompleted(object sender, EventArgs e)
        {
            MessageBox.Show("nice");
            //_mainWindowView = new MainWindowViewModel();
            // _mainWindowView.ItemsA.re;
            //  _mainWindowView.ItemsB.Add();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            _mainWindowView = new MainWindowViewModel();
            _mainWindowView.ItemsA.Add(new BoxData());
          
        }
    }
}
