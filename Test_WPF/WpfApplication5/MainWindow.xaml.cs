using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
       
        private ObjectToMove _element;
        List<ObjectToMove> kartList = new List<ObjectToMove>();
       
        
        public MainWindow()
        {
            InitializeComponent();


 

        }


        private void storyboard_Completed(object sender, EventArgs e)
        {
            var sb1 = FindResource("SectionA_SB") as Storyboard;
            sb1.Remove();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            // ObjectToMove move = new ObjectToMove();
          
            
            _element = new ObjectToMove();
             kartList.Add(_element);


             _element.CarTranslateTransform = new TranslateTransform()
             {
                 X = 5000,
                 Y = 20
             };

             var sb1 = FindResource("SectionA_SB") as Storyboard;
             sb1.Begin(_element, true);
             
             Animation_Path.Children.Add(_element);

             //foreach (var otherobjecttomove in kartList)
             //{
             //    if (!_element.Equals(otherobjecttomove))
             //    {
             //        if (_element.IsColliding(otherobjecttomove))
             //        {
             //            MessageBox.Show("collision detected");
             //        }
                     
             //    }
             //}
            

        }

        public bool collision()
        {
            var collisiondetected = false;

            foreach (var otherobjecttomove in kartList)
            {
                if (!_element.Equals(otherobjecttomove))
                {
                    while (_element.IsColliding(otherobjecttomove))
                    {
                        MessageBox.Show("collision detected");
                    }
                   return  collisiondetected = true;
                }
            }
            return collisiondetected;
        }






    }
}
