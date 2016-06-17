using System;
using System.Windows;

namespace wpf_ItemsControl_Canvas_Animation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
             InitializeComponent();
            
        }


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
          
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            MainWindowViewModel mwv = this.DataContext as MainWindowViewModel;
            mwv.NextAnimation(mwv.ItemsA, mwv.ItemsB, mwv.ItemsA[0]);
        }
    }
}
