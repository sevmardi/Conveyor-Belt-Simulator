using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
using LaneSimulator.Models.Components;
using LaneSimulator.PLC;
using Snap7;

namespace LaneSimulator.Lanes
{
    /// <summary>
    /// Interaction logic for LaneTop.xaml
    /// </summary>
    public partial class LaneTop : UserControl
    {
        private readonly PlcCalls _plcCalls;
        private static readonly byte[] Buffer = new byte[500];
        private static int _res;
        private Storyboard sb1;
       
        public LaneTop()
        {
            InitializeComponent();
            _plcCalls = new PlcCalls();
            sb1 = FindResource("LongPathAnimation") as Storyboard; 
        }

        public void Executor()
        {
            _0102_S1Read();
           
            //SecondSensorTimer();
            //ThirdSensor();
            //FourthSensor();
            //FifthSensor();
            //SixthSensor();
        }


        private void Total()
        {
         // total_text1.Text= (this.tray_Wrap.Children.Count).ToString();
        }

        private void storyboard_Completed()
        {
            this.tray_Wrap.Children.Add((UIElement) new Tray());

        }

        private void Timeline_OnCompleted(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void _0102_D1Motor()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0102_D1, _plcCalls.Amount,_plcCalls.Wordlen, Buffer);
           
            try
            {
                if (_res == 0)
                {
                    if (Buffer[0] == 0)
                    {
                        _0102_D1.Fill = new SolidColorBrush(Colors.Chartreuse);
                    }
                }
            }
            catch (Exception)
            {
                
               sb1.Stop();
                MessageBox.Show("Motor not working!");
            }
  
        }

        public void _0103_D1Motor()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0103_D1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 0)
                {
                    // main._0103_D1.Fill = new SolidColorBrush(Colors.Chartreuse);
                }
            }
        }

        public void _0104_D1Motor()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0104_D1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 1)
                {
                     _0104_D1.Fill = new SolidColorBrush(Colors.Chartreuse);
                }
            }
        }

        public void _0105_D1Motor()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0105_D1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 1)
                {
                    //   main._0105_D1.Fill = new SolidColorBrush(Colors.Chartreuse);
                }
            }
        }

        public void _0102_S1Read()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            try
            {
                if (_res == 0)
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;
                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);
                        _0102_S1.Fill = new SolidColorBrush(Colors.DarkGray);
                        _0102_D1Motor();
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }


            FirstSensor();
        }

        public void _0102_S1Write(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;
            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            //Buffer[0] = 0;
            //_res = _plcCalls.Client.WriteArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0102_D1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action)(() =>
            {
                      _0102_S1.Fill = new SolidColorBrush(Colors.Red);
                      _0102_D1.Fill = new SolidColorBrush(Colors.DarkGray);
            }));

        }


        public void _0102_S2Read(object source, ElapsedEventArgs e)
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S2, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 1)
                {
                    Buffer[0] = 0;
                    _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S2, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                    Dispatcher.Invoke((Action)(() =>
                    {
                        _0102_S2.Fill = new SolidColorBrush(Colors.DarkGray);

                    }));

                    _0103_D1Motor();

                }
            }

            SecondSensorWrite();
        }

        public void _0102_S2Write(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;
            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S2, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            Buffer[0] = 0;

            _res = _plcCalls.Client.WriteArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0103_D1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action)(() =>
            {
                _0102_S2.Fill = new SolidColorBrush(Colors.Red);
                _0103_D1.Fill = new SolidColorBrush(Colors.DarkGray);
            }));
        }

        public void _0103_S1Read(object source, ElapsedEventArgs e)
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0103_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 1)
                {
                    Buffer[0] = 0;
                    _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0103_S1, _plcCalls.Amount,
                        _plcCalls.Wordlen, Buffer);

                    Dispatcher.Invoke((Action)(() =>
                    {
                        _0103_S1.Fill = new SolidColorBrush(Colors.DarkGray);

                    }));

                    _0104_D1Motor();

                }
            }

            ThirdSensorWrite();

        }




        public void _0103_S1Write(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;
            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0103_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);
            Buffer[0] = 0;
            _res = _plcCalls.Client.WriteArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0104_D1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action)(() =>
            {
                _0103_S1.Fill = new SolidColorBrush(Colors.Red);
                _0104_D1.Fill = new SolidColorBrush(Colors.DarkGray);
            }));
        }




        public void _0104_S1Read(object source, ElapsedEventArgs e)
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0104_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 1)
                {
                    Buffer[0] = 0;
                    _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0104_S1, _plcCalls.Amount,
                        _plcCalls.Wordlen, Buffer);

                    Dispatcher.Invoke((Action)(() =>
                    {
                        _0104_S1.Fill = new SolidColorBrush(Colors.DarkGray);

                    }));


                }
            }
            FourthSensorWrite();

        }


        public void _0104_S1Write(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;
            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0104_S1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);
             
            //Buffer[0] = 0;
            //_res = _plcCalls.Client.WriteArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0105_D1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action)(() =>
            {
                _0104_S1.Fill = new SolidColorBrush(Colors.Red);
                _0105_D1.Fill = new SolidColorBrush(Colors.DarkGray);
            }));
        }

        public void _0105_S1Read(object source, ElapsedEventArgs e)
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0105_S1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 1)
                {
                    Buffer[0] = 0;
                    _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0105_S1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                    Dispatcher.Invoke((Action)(() =>
                    {
                        _0105_S1.Fill = new SolidColorBrush(Colors.DarkGray);

                    }));

                    _0105_D1Motor();
                }
            }
            FifthSensorWrite();

        }

        public void _0105_S1Write(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;
            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0105_S1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);
            //Buffer[0] = 0;
            //_res = plcCalls.Client.WriteArea(S7Client.S7AreaPA, PlcCalls.DbNumber, PLCTags._0105_D1, PlcCalls.Amount,
            //    PlcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action)(() =>
            {
                _0105_S1.Fill = new SolidColorBrush(Colors.Red);
                _0105_D1.Fill = new SolidColorBrush(Colors.DarkGray);
            }));
        }

        public void _0105_S2Read(object source, ElapsedEventArgs e)
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0105_S2, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 1)
                {
                    Buffer[0] = 0;
                    _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0105_S2, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                    Dispatcher.Invoke((Action)(() =>
                    {
                        _0105_S2.Fill = new SolidColorBrush(Colors.DarkGray);

                    }));
                }
            }
            SixthSensorWrite();

        }

        public void _0105_S2Write(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;
            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0105_S2, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            //Buffer[0] = 0;
            //_res = _plcCalls.Client.WriteArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0105_D1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action)(() =>
            {
                _0105_S2.Fill = new SolidColorBrush(Colors.Red);
                _0105_D1.Fill = new SolidColorBrush(Colors.DarkGray);
            }));
        }



























        protected void FirstSensor()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0102_S1Write);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) =>
            {
                aTimer.Stop();
            };
        }


        protected void SecondSensorTimer()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0102_S2Read);
            aTimer.Interval = 800;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) =>
            {
                aTimer.Stop();
            };
        }


        
        protected void SecondSensorWrite()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0102_S2Write);
            aTimer.Interval = 3000;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) =>
            {
                aTimer.Stop();
            };
        }


        protected void ThirdSensor()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0103_S1Read);
            aTimer.Interval = 2000;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) =>
            {
                aTimer.Stop();
            };
        }


        protected void ThirdSensorWrite()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0103_S1Write);
            aTimer.Interval = 3500;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) =>
            {
                aTimer.Stop();
            };
        }

        protected void FourthSensor()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0104_S1Read);
            aTimer.Interval = 2500;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) =>
            {
                aTimer.Stop();
            };
        }




        protected void FourthSensorWrite()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0104_S1Write);
            aTimer.Interval = 3500;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) =>
            {
                aTimer.Stop();
            };
        }



        protected void FifthSensor()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0105_S1Read);
            aTimer.Interval = 3600;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) =>
            {
                aTimer.Stop();
            };
        }

        protected void FifthSensorWrite()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0105_S1Write);
            aTimer.Interval = 3800;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) =>
            {
                aTimer.Stop();
            };
        }

        protected void SixthSensor()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0105_S2Read);
            aTimer.Interval = 4500;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) =>
            {
                aTimer.Stop();
            };
        }


        protected void SixthSensorWrite()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0105_S2Write);
            aTimer.Interval = 4100;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) =>
            {
                aTimer.Stop();
            };
        }


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            //var sb1 = FindResource("LongPathAnimation") as Storyboard;

            sb1.Begin(ObjectToMove);
            Executor();
        }
    }
}
