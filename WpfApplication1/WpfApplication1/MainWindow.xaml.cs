using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
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
using System.Windows.Threading;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double T = 0.0;
        private DispatcherTimer Timer1 = new DispatcherTimer();
        
        public MainWindow()
        {
            InitializeComponent();
            this.Timer1.Interval = new TimeSpan(0, 0, 0, 0, 100);
            this.Timer1.Tick += new EventHandler(this.Timer1_Tick);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var sb1 = FindResource("LongPathAnimation") as Storyboard;

            //ObjectToMove objectToMove = new ObjectToMove();
            //objectToMove.RenderTransformOrigin = new Point(0.5, 0.5);
            //objectToMove.HorizontalAlignment = HorizontalAlignment.Left;
            //RotateTransform myRotateTransform = new RotateTransform(0);
            //TranslateTransform myTranslateTransform = new TranslateTransform();
            //objectToMove.RenderTransform = myTranslateTransform;
            //objectToMove.RenderTransform = myRotateTransform;


            sb1.Begin(ObjectToMove);

            Timer1.Start();
           
        }

        private void Total()
        {
            ObjectToMove objectToMove = new ObjectToMove();

            this.Steel_Wrap.Children.Add((UIElement)objectToMove);
            total_text1.Text = (Steel_Wrap.Children.Count).ToString();
        }

        private void Timeline_OnCompleted(object sender, EventArgs e)
        {

           // MessageBox.Show(" Complted");
          
     
            Total();
            var sb1 = FindResource("LongPathAnimation") as Storyboard;
            sb1.Stop(ObjectToMove);
            Timer1.Stop();
            ObjectToMove = null;


        }



        private void Timer1_Tick(object sender, EventArgs e)
        {
            this.Timer_Lable.Text = (this.T = this.T + 0.1).ToString("0.00", (IFormatProvider)CultureInfo.InvariantCulture);
        }


        private void MakeTrayBtn_Click(object sender, RoutedEventArgs e)
        {
          
        }
    }
}
