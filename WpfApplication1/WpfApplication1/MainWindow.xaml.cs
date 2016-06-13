using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double T = 0.0;
        private DispatcherTimer Timer1 = new DispatcherTimer();

        private SectionA _sectionA;
        private ObjectToMove _objectToMove;
        private FrameworkContentElement _moElement;
        private Semaphore semaphoreThis;
        private buffer bufferThis;
        public ObservableCollection<ObjectToMove> topp { get; set; }
        protected int delay;
        List<ObjectToMove> objecttomovelist = new List<ObjectToMove>();
        public MainWindow()
        {
            
            InitializeComponent();
            this.Timer1.Interval = new TimeSpan(0, 0, 0, 0, 100);
            this.Timer1.Tick += new EventHandler(this.Timer1_Tick);
           
            DataContext = this;
            topp = new ObservableCollection<ObjectToMove>();
            topp.Add(new ObjectToMove());
            this.semaphoreThis = semaphoreThis;
        }



        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {

            //var _objectToMove = new ObjectToMove();

            //var sb1 = FindResource("SectionA_SB") as Storyboard;

            //Animation_Pannel.Children.Add(_objectToMove);
            //sb1.Begin(_objectToMove);

           // Timer1.Start();

            //var _moElement = new ObjectToMove();
            //Animation_Pannel.Children.Add(_moElement);

            //var storyBoardsToRun = new[] { "Storyboard1", "Storyboard2" };

            //storyBoardsToRun
            //    .Select(sbName => FindResource(sbName) as Storyboard)
            //    .ToList()
            //    .ForEach(async sb => await sb.BeginAsync(_moElement));

            //from https://social.msdn.microsoft.com/Forums/en-US/2913abcd-5bdb-48a7-8aac-2a6b1b24fe5b/stop-storyboard-in-canvas?forum=wpf

            //_sectionA = new SectionA() { Template = (ControlTemplate)Resources["ConveyorATemplate"] };
            // sectionA.Children.Add(_sectionA);
            //_sectionA.SetCurrentValue(WpfApplication1.SectionA.StartProperty, true);

            //_objectToMove = new ObjectToMove { Template = (ControlTemplate)Resources["ConveyorATemplate"] };
            //sectionA.Children.Add(_objectToMove);
           
            //_objectToMove.TrayTranslateTransform = new TranslateTransform()
            //{
            //    X = 3500,
            //    Y = 300
            //};
            //_objectToMove.SetCurrentValue(ObjectToMove.GoProperty, true);
            
            //if(_objectToMove.IsColliding(_objectToMove))
            //{
            //    MessageBox.Show("Colliding");
            //}

            BoxData test = new BoxData();
            var b = test.GoState == StoryBoardState.Start;
        }

        //private void Maketry(object sender, ElapsedEventArgs elapsedEventArgs)
        //{
        //    _sectionA = new SectionA() { Template = (ControlTemplate)Resources["ConveyorATemplate"] };

        //    sectionA.Children.Add(_sectionA);
        //    _sectionA.SetCurrentValue(WpfApplication1.SectionA.StartProperty, true);
        //}
        
        private void StopAnimation(object sender, RoutedEventArgs e)
        {
            _sectionA.SetCurrentValue(WpfApplication1.SectionA.StartProperty, false);
          //  _objectToMove.SetCurrentValue(ObjectToMove.GoProperty, false);
        }



        public void waitpanel()
        {
            Thread.Sleep(delay);
            
            for (int i = 1; i < 200; i++)
            {
                semaphoreThis.wait();
            }
        }






        //protected void addbuttontimer()
        //{
        //    var aTimer = new System.Timers.Timer();
        //    aTimer.Elapsed += new ElapsedEventHandler(Maketry);
        //    aTimer.Interval = 2500;
        //    aTimer.Enabled = true;

        //    aTimer.Elapsed += (s, e) => { aTimer.Stop(); };
        //}



        private void Total()
        {

            Steel_Wrap.Children.Add((UIElement)_objectToMove);
            Steel_Wrap.Children.Remove((UIElement)_objectToMove);
            total_text1.Text = (Steel_Wrap.Children.Count).ToString();
        }

        private void Timeline_OnCompleted(object sender, EventArgs e)
        {

           // MessageBox.Show(" Complted");
          

            Total();
           // var sb1 = FindResource("LongPathAnimation") as Storyboard;
          
          
            //_objectToMove = null;

        }



        private void Timer1_Tick(object sender, EventArgs e)
        {
            this.Timer_Lable.Text = (this.T = this.T + 0.1).ToString("0.00", (IFormatProvider)CultureInfo.InvariantCulture);
        }




    }

    public static class StoryBoardExtensions
    {
        public static Task BeginAsync(this Storyboard sb, FrameworkContentElement element)
        {
            var source = new TaskCompletionSource<object>();
            sb.Completed += delegate
            {
                source.SetResult(null);
            };
            sb.Begin(element);
            return source.Task;
        }
    }
}
