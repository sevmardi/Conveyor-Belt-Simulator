using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using LaneSimulator.Model;
using LaneSimulator.PLC;
using LaneSimulator.UIGates;
using LaneSimulator.Views;
using Snap7;
using Timer = System.Timers.Timer;

namespace LaneSimulator.Lanes
{
    /// <summary>
    /// Interaction logic for LaneTop.xaml
    /// </summary>
    public partial class LaneTop
    {
        private readonly PlcCalls _plcCalls;
        private static readonly byte[] Buffer = new byte[500];
        private static int _res;
        private Storyboard _storyboard;
        private AttributesPanel _attributesPanel;
        private SchedulerPanel _schedulerPanel;
        static int count = 0;
        static int scheudler = 0;
        List<Sensor> SensorList = new List<Sensor>();
        private FrameworkElement _element;
        private SensorTimerHandler _sensorTimerHandler;
        private PLCAbstract _plcAbstract;   
       
        public LaneTop()
        {
            InitializeComponent();
            _plcCalls = new PlcCalls();
           _sensorTimerHandler = new SensorTimerHandler();
            _plcAbstract= new PLCAbstract();
            
   
        }

        private void InitializeSensors()
        {
            //SensorList.Add(new Sensor());
            //SensorList.Add(new Sensor());
            //SensorList.Add(new Sensor());

            //foreach (var sensor in SensorList)
            //{
            //    var ell = new Sensor()
            //    {
            //        Width = 2,
            //        Height = 2,
            //     //   Stroke = new SolidColorBrush(Colors.White),
            //       // StrokeThickness = 2,
            //        //     Fill = new SolidColorBrush(kart.BodyColor2),
            //        Margin = new Thickness(-8, -8, 8, 8),
            //        HorizontalAlignment = HorizontalAlignment.Left,
            //        VerticalAlignment = VerticalAlignment.Top
            //    };

            //    TestGrid.Children.Add(sensor);
            //}

        }

        public void Executor()
        {
       //     _0102_S1_TurnOff();
            //SecondSensorTimer();
            //ThirdSensor();
            //FourthSensor();
            //FifthSensor();
            //SixthSensor();
        }



        #region motoren

        public void _0102_D1Motor()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0102_D1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Dispatcher.Invoke((Action) (() => { _0102_D1.Fill = new SolidColorBrush(Colors.Chartreuse); }));
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }

            else
            {
                MessageBox.Show("There is no Connection!! ");
            }
        }

        public void _0103_D1Motor()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0103_D1, _plcCalls.Amount,_plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Dispatcher.Invoke((Action)(() =>
                        {
                            _0103_D1.Fill = new SolidColorBrush(Colors.Chartreuse);
                        }));

                    }
                    else
                    {
                       // MessageBox.Show("Motor 0103D1 FALSE ");
                      
                    }
                }
                catch (Exception)
                {
                    
                    throw;
                }
         
            }
        }

        public void _0104_D1Motor()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0104_D1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 1)
                {
                      Dispatcher.Invoke((Action)(() =>
                      {
                          _0104_D1.Fill = new SolidColorBrush(Colors.Chartreuse);
                      }));

                }
            }
        }

        public void _0105_D1Motor()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0105_D1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 1)
                {
                    Dispatcher.Invoke((Action)(() =>
                    {
                        _0105_D1.Fill = new SolidColorBrush(Colors.Chartreuse);
                    }));

                }


            }
        }

        public void _0301_D1Motor()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0301_D1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

                if (_res == 0)
                {
                    try
                    {
                        if (Buffer[0] == 1)
                        {
                            Dispatcher.Invoke((Action)(() =>
                            {
                                _0301_D1.Fill = new SolidColorBrush(Colors.Chartreuse);
                            }));
                        }
                        else
                        {
                            MessageBox.Show("Motor not working!");
                        }
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Motor not working!");
                    }

                }
                else
                    MessageBox.Show("Connection must be established first");
        }

        public void _0302_D1Motor()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0302_D1, _plcCalls.Amount,
               _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Dispatcher.Invoke((Action)(() =>
                        {
                            _0302_D1.Fill = new SolidColorBrush(Colors.Chartreuse);
                        }));
                    }
                    else
                    {
                        MessageBox.Show("Motor not working!");
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Motor not working!");
                }

            }
            else
                MessageBox.Show("Connection must be established first");

        }

        public void _0303_D1Motor()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0303_D1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Dispatcher.Invoke((Action)(() =>
                        {
                            _0303_D1.Fill = new SolidColorBrush(Colors.Chartreuse);
                        }));
                      
                    }
                    else
                    {
                        MessageBox.Show("Motor not working!");
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Motor not working!");
                }
            }
            else
                MessageBox.Show("Connection must be established first");
        }

        public void _0304_D1Motor()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0304_D1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Dispatcher.Invoke((Action)(() =>
                        {
                            _0304_D1.Fill = new SolidColorBrush(Colors.Chartreuse);
                        }));
                    }
                    else
                    {
                        MessageBox.Show("Motor not working!");
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Motor not working!");
                }
            }
            else
                MessageBox.Show("Connection must be established first");
        }

        public void _0702_D1Motor()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0702_D1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Dispatcher.Invoke((Action)(() =>
                        {
                            _0702_D1.Fill = new SolidColorBrush(Colors.Chartreuse);
                        }));
                    }
                    else
                    {
                        MessageBox.Show("Motor _0702_D1 is not working!");
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        public void _1001_D1Motor()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._1001_D1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Dispatcher.Invoke((Action)(() =>
                        {
                            _1001_D1.Fill = new SolidColorBrush(Colors.Chartreuse);
                        }));
                    }
                    else
                    {
                        MessageBox.Show("Motor _1001_D1 is not working!");
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        public void _1002_D1Motor()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._1002_D1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Dispatcher.Invoke((Action) (() => { _1002_D1.Fill = new SolidColorBrush(Colors.Chartreuse); }));
                    }
                    else
                    {
                        MessageBox.Show("Motor _1002_D1 is not working!");
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        public void _1003_D2Motor()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._1003_D2, _plcCalls.Amount,
               _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Dispatcher.Invoke((Action)(() => { _1003_D2.Fill = new SolidColorBrush(Colors.Chartreuse); }));
                    }
                    else
                    {
                        MessageBox.Show("Motor _1003_D2 is not working!");
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        public void _1003_D1Motor()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._1003_D1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Dispatcher.Invoke((Action) (() => { _1003_D1.Fill = new SolidColorBrush(Colors.Chartreuse); }));
                    }
                    else
                    {
                        MessageBox.Show("Motor _1003_D1 is not working!");
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        public void _1003_D3Motor()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._1003_D3, _plcCalls.Amount,
               _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Dispatcher.Invoke((Action)(() => { _1003_D3.Fill = new SolidColorBrush(Colors.Chartreuse); }));
                    }
                    else
                    {
                        MessageBox.Show("Motor _1003_D3 is not working!");
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        public void _1003_D4Motor()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._1003_D4, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Dispatcher.Invoke((Action) (() => { _1003_D4.Fill = new SolidColorBrush(Colors.Chartreuse); }));
                    }
                    else
                    {
                        MessageBox.Show("Motor _1003_D4 is not working!");
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        public void _1004_D1Motor()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._1004_D1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Dispatcher.Invoke((Action) (() => { _1004_D1.Fill = new SolidColorBrush(Colors.Chartreuse); }));
                    }
                    else
                    {
                        MessageBox.Show("Motor _1004_D1 is not working!");
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        public void _1004_D2Motor()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._1004_D2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Dispatcher.Invoke((Action) (() => { _1004_D2.Fill = new SolidColorBrush(Colors.Chartreuse); }));
                    }
                    else
                    {
                        MessageBox.Show("Motor _1004_D2 is not working!");
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        public void _1004_D3Motor()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._1004_D3, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Dispatcher.Invoke((Action)(() => { _1004_D3.Fill = new SolidColorBrush(Colors.Chartreuse); }));
                    }
                    else
                    {
                        MessageBox.Show("Motor _1004_D2 is not working!");
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        public void _1701_D1Motor()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._1701_D1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Dispatcher.Invoke((Action)(() => { _1701_D1.Fill = new SolidColorBrush(Colors.Chartreuse); }));
                    }
                    else
                    {
                        MessageBox.Show("Motor _1004_D2 is not working!");
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        public void _1702_D1Motor()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._1702_D1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Dispatcher.Invoke((Action)(() => { _1701_D2.Fill = new SolidColorBrush(Colors.Chartreuse); }));
                    }
                    else
                    {
                        MessageBox.Show("Motor _1702_D1 is not working!");
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        #endregion



        #region Conveyor A - sensoren 

        public void _0102_S1_TurnOff()
        {
            #region old method body 

//_res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            //if (_res == 0)
            //{
            //    try
            //    {
            //        if (Buffer[0] == 1)
            //        {
            //            Buffer[0] = 0;

            //            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S1,
            //                _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            //            _0102_S1.Fill = new SolidColorBrush(Colors.DarkGray);
            //            //DelayAction(800, new Action(() => { this._0102_D1Motor(); }));

            //            _0102_D1Motor();
            //        }
            //        else
            //        {

            //            MessageBox.Show("Sensor #0102S1 on false");
            //        }

            //    }
            //    catch (Exception)
            //    {

            //        throw;
            //    }

            #endregion

            try
            {
                _res =  _plcAbstract.ReadSensorInput(PLCTags._0102_S1);

                if (_res == 0)
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;
                        
                        _plcAbstract.WriteSensorInput(PLCTags._0102_S1);
                        _0102_S1.Fill = new SolidColorBrush(Colors.DarkGray);
                        
                        _0102_D1Motor();
                    }
                    else
                        MessageBox.Show("Sensor #0102S1 on false");
                }
            }
            catch
            {
                throw;
            }
            _sensorTimerHandler.Timer(400, _0102_S1_TurnOn);
            // FirstSensor();  
        }

        public void _0102_S1_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() =>
            {
                _0102_S1.Fill = new SolidColorBrush(Colors.Red);
                _0102_D1.Fill = new SolidColorBrush(Colors.DarkGray);
            }));

        }

        public void _0102_S2_TurnOff(object source, ElapsedEventArgs e)
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 1)
                {
                    Buffer[0] = 0;
                    _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S2, _plcCalls.Amount,
                        _plcCalls.Wordlen, Buffer);

                    Dispatcher.Invoke((Action) (() =>
                    {
                        _0102_S2.Fill = new SolidColorBrush(Colors.DarkGray);

                    }));

                    _0103_D1Motor();

                }
            }

            SecondSensorWrite();
        }

        public void _0102_S2_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;
            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            //Buffer[0] = 0;

            //_res = _plcCalls.Client.WriteArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0103_D1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() =>
            {
                _0102_S2.Fill = new SolidColorBrush(Colors.Red);
                _0103_D1.Fill = new SolidColorBrush(Colors.DarkGray);
            }));
        }

        public void _0103_S1_TurnOff(object source, ElapsedEventArgs e)
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

                    Dispatcher.Invoke((Action) (() =>
                    {
                        _0103_S1.Fill = new SolidColorBrush(Colors.DarkGray);

                    }));

                    _0104_D1Motor();

                }
            }

            ThirdSensorWrite();

        }

        public void _0103_S1_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;
            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0103_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);
            Buffer[0] = 0;
            _res = _plcCalls.Client.WriteArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0104_D1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() =>
            {
                _0103_S1.Fill = new SolidColorBrush(Colors.Red);
                _0104_D1.Fill = new SolidColorBrush(Colors.DarkGray);
            }));
        }

        public void _0104_S1_TurnOff(object source, ElapsedEventArgs e)
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

                    Dispatcher.Invoke((Action) (() => { _0104_S1.Fill = new SolidColorBrush(Colors.DarkGray); }));
                }
            }
            FourthSensorWrite();
        }

        public void _0104_S1_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;
            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0104_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            //Buffer[0] = 0;
            //_res = _plcCalls.Client.WriteArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0105_D1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() =>
            {
                _0104_S1.Fill = new SolidColorBrush(Colors.Red);
                _0105_D1.Fill = new SolidColorBrush(Colors.DarkGray);
            }));
        }

        public void _0105_S1_TurnOff(object source, ElapsedEventArgs e)
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0105_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 1)
                {
                    Buffer[0] = 0;
                    _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0105_S1, _plcCalls.Amount,
                        _plcCalls.Wordlen, Buffer);

                    Dispatcher.Invoke((Action) (() =>
                    {
                        _0105_S1.Fill = new SolidColorBrush(Colors.DarkGray);

                    }));

                    _0105_D1Motor();
                }
            }
            FifthSensorWrite();

        }

        public void _0105_S1_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;
            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0105_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);
            //Buffer[0] = 0;
            //_res = plcCalls.Client.WriteArea(S7Client.S7AreaPA, PlcCalls.DbNumber, PLCTags._0105_D1, PlcCalls.Amount,
            //    PlcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() =>
            {
                _0105_S1.Fill = new SolidColorBrush(Colors.Red);
                _0105_D1.Fill = new SolidColorBrush(Colors.DarkGray);
            }));
        }

        public void _0105_S2_TurnOff(object source, ElapsedEventArgs e)
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0105_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 1)
                {
                    Buffer[0] = 0;
                    _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0105_S2, _plcCalls.Amount,
                        _plcCalls.Wordlen, Buffer);

                    Dispatcher.Invoke((Action) (() =>
                    {
                        _0105_S2.Fill = new SolidColorBrush(Colors.DarkGray);

                    }));
                }
            }

            SixthSensorWrite();

        }

        public void _0105_S2_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;
            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0105_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            //Buffer[0] = 0;
            //_res = _plcCalls.Client.WriteArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0105_D1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() =>
            {
                _0105_S2.Fill = new SolidColorBrush(Colors.Red);
                _0105_D1.Fill = new SolidColorBrush(Colors.DarkGray);
            }));
        }

        #endregion


        #region Conveyor B

        public void _0301_S1_TurnOff(object source, ElapsedEventArgs e)
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0301_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 1)
                {
                    Buffer[0] = 0;
                    _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0301_S1, _plcCalls.Amount,
                        _plcCalls.Wordlen, Buffer);

                    Dispatcher.Invoke((Action) (() =>
                    {
                        _0301_S1.Fill = new SolidColorBrush(Colors.DarkGray);

                    }));

                    _0301_D1Motor();

                }
            }
        }

        public void _0301_S1_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;
            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0301_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() =>
            {
                _0301_S1.Fill = new SolidColorBrush(Colors.Red);

            }));
        }

        public void _0301_S2_TurnOff(object source, ElapsedEventArgs e)
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0301_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0301_S2,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _0301_S1.Fill = new SolidColorBrush(Colors.DarkGray); }));

                        //  _0301_D1Motor();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("");
                }
            }
            else
                MessageBox.Show("");
        }

        public void _0301_S2_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0301_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() =>
            {
                _0301_S2.Fill = new SolidColorBrush(Colors.Red);

            }));
        }

        public void _0302_S1_TurnOff(object source, ElapsedEventArgs e)
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0302_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0302_S1,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _0302_S1.Fill = new SolidColorBrush(Colors.DarkGray); }));

                        //  _0301_D1Motor();
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        public void _0302_S1_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0302_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() =>
            {
                _0302_S1.Fill = new SolidColorBrush(Colors.Red);

            }));
        }

        public void _0303_S1_TurnOff(object source, ElapsedEventArgs e)
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0303_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0303_S1,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _0303_S1.Fill = new SolidColorBrush(Colors.DarkGray); }));

                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        public void _0303_S1_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0303_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() =>
            {
                _0303_S1.Fill = new SolidColorBrush(Colors.Red);

            }));
        }

        public void _0304_S1_TurnOff(object source, ElapsedEventArgs e)
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0304_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0304_S1,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _0304_S1.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        public void _0304_S1_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0304_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() =>
            {
                _0304_S1.Fill = new SolidColorBrush(Colors.Red);

            }));
        }

        public void _0304_S2_TurnOff(object source, ElapsedEventArgs e)
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0304_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0304_S2,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _0304_S2.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        public void _0304_S2_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0304_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() =>
            {
                _0304_S2.Fill = new SolidColorBrush(Colors.Red);

            }));
        }

        public void _0304_S3_TurnOff(object source, ElapsedEventArgs e)
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0304_S3, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0304_S3,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _0304_S3.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        public void _0304_S3_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0304_S3, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() =>
            {
                _0304_S3.Fill = new SolidColorBrush(Colors.Red);

            }));
        }

        public void _0701_S1_TurnOff()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0701_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0701_S1,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _0701_S1.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        public void _0701_S1_TurnOn()
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0701_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() =>
            {
                _0701_S1.Fill = new SolidColorBrush(Colors.Red);
            }));
        }

        #endregion


        #region Section C

        public void _0701_S2_TurnOff()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0701_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0701_S2,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _0701_S2.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        public void _0701_S2_TurnOn()
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0701_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() =>
            {
                _0701_S2.Fill = new SolidColorBrush(Colors.Red);
            }));
        }

        public void _0702_S1_TurnOff()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0702_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0702_S1,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _0702_S1.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        public void _0702_S1_TurnOn()
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0702_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() =>
            {
                _0702_S1.Fill = new SolidColorBrush(Colors.Red);
            }));
        }

        public void _0702_S2_TurnOff()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0702_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0702_S2,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _0702_S2.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        public void _0702_S2_TurnOn()
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0702_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() =>
            {
                _0702_S2.Fill = new SolidColorBrush(Colors.Red);
            }));
        }

        #endregion

        #region Section D

        public void _1001_S1_TurnOff()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1001_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1001_S1,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _1001_S1.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        public void _1001_S1_TurnOn()
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1001_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _0702_S2.Fill = new SolidColorBrush(Colors.Red); }));
        }

        public void _1001_S2_TurnOff()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1001_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1001_S2,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _1001_S2.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        public void _1001_S2_TurnOn()
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1001_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1001_S2.Fill = new SolidColorBrush(Colors.Red); }));
        }

        public void _1002_S1_TurnOff()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1002_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1002_S1,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _1002_S1.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        public void _1002_S1_TurnOn()
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1002_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1002_S1.Fill = new SolidColorBrush(Colors.Red); }));
        }

        public void _1002_S2_TurnOff()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1002_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1002_S2,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _1002_S2.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        public void _1002_S2_TurnOn()
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1002_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1002_S2.Fill = new SolidColorBrush(Colors.Red); }));
        }

        public void _1004_S1_TurnOff()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1004_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1004_S1,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _1004_S1.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        public void _1004_S1_TurnOn()
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1004_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1004_S1.Fill = new SolidColorBrush(Colors.Red); }));
        }

        public void _1003_S1_TurnOff()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1003_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1003_S1,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _1003_S1.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        public void _1003_S1_TurnOn()
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1003_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1003_S1.Fill = new SolidColorBrush(Colors.Red); }));
        }

        public void _1003_S3_TurnOff()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1003_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1003_S3,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _1003_S3.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        public void _1003_S3_TurnOn()
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1003_S3, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1003_S3.Fill = new SolidColorBrush(Colors.Red); }));
        }

        public void _1003_S4_TurnOff()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1003_S4, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1003_S4,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _1003_S4.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }
        }

        public void _1003_S4_TurnOn()
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1003_S4, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1003_S4.Fill = new SolidColorBrush(Colors.Red); }));
        }


        public void _1003_S5_TurnOff()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1003_S5, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1003_S5,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _1003_S5.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    throw new ArgumentException();
                }
            }
        }

        public void _1003_S5_TurnOn()
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1003_S5, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1003_S5.Fill = new SolidColorBrush(Colors.Red); }));
        }

        public void _1003_S2_TurnOff()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1003_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1003_S2,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _1003_S2.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    throw new ArgumentException();
                }
            }
            else
                MessageBox.Show("Connection Must be established first");
        }

        public void _1003_S2_TurnOn()
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1003_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1003_S2.Fill = new SolidColorBrush(Colors.Red); }));
        }

        public void _1004_S2_TurnOff()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1004_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1004_S2,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _1004_S2.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    throw new ArgumentException();
                }
            }
        }

        public void _1004_S2_TurnOn()
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1003_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1003_S2.Fill = new SolidColorBrush(Colors.Red); }));
        }

        #endregion


        #region Section E



        public void _1101_S1_TurnOff()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1101_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1101_S1,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _1101_S1.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    throw new ArgumentException();
                }
            }
        }

        public void _1101_S1_TurnOn()
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1101_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1101_S1.Fill = new SolidColorBrush(Colors.Red); }));
        }

        public void _1102_S1_TurnOff()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1102_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1102_S1,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _1102_S1.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    throw new ArgumentException();
                }
            }
        }

        public void _1102_S1_TurnOn()
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1102_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1102_S1.Fill = new SolidColorBrush(Colors.Red); }));
        }

        public void _1101_S2_TurnOff()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1102_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1102_S1,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _1102_S1.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    throw new ArgumentException();
                }
            }
        }

        public void _1101_S2_TurnOn()
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1101_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1101_S2.Fill = new SolidColorBrush(Colors.Red); }));
        }

        public void _1102_S2_TurnOff()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1102_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1102_S2,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _1102_S2.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    throw new ArgumentException();
                }
            }
        }

        public void _1102_S2_TurnOn()
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1102_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1102_S2.Fill = new SolidColorBrush(Colors.Red); }));
        }

        public void _1101_S3_TurnOff()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1101_S3, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1101_S3,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _1101_S3.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    throw new ArgumentException();
                }
            }
        }

        public void _1101_S3_TurnOn()
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1101_S3, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1101_S3.Fill = new SolidColorBrush(Colors.Red); }));
        }

        public void _1102_S3_TurnOff()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1102_S3, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1102_S3,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _1102_S3.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    throw new ArgumentException();
                }
            }
        }

        public void _1102_S3_TurnOn()
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1102_S3, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1102_S3.Fill = new SolidColorBrush(Colors.Red); }));
        }

        #endregion


        #region Section F

        public void _1601_S1_TurnOff()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1601_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1601_S1,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _1601_S1.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    throw new ArgumentException();
                }
            }
        }

        public void _1601_S1_TurnOn()
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1601_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1601_S1.Fill = new SolidColorBrush(Colors.Red); }));
        }

        public void _1601_S2_TurnOff()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1601_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1601_S2,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _1601_S2.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    throw new ArgumentException();
                }
            }
        }

        public void _1601_S2_TurnOn()
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1601_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1601_S2.Fill = new SolidColorBrush(Colors.Red); }));
        }

        public void _1601_S3_TurnOff()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1601_S3, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1601_S3,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _1601_S3.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    throw new ArgumentException();
                }
            }
        }

        public void _1601_S3_TurnOn()
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1601_S3, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1601_S3.Fill = new SolidColorBrush(Colors.Red); }));
        }

        public void _1602_S1_TurnOff()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1602_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1602_S1,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _1602_S1.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    throw new ArgumentException();
                }
            }
        }

        public void _1602_S1_TurnOn()
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1602_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1602_S1.Fill = new SolidColorBrush(Colors.Red); }));
        }

        public void _1602_S2_TurnOff()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1602_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1602_S2,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _1602_S2.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    throw new ArgumentException();
                }
            }
        }

        public void _1602_S2_TurnOn()
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1602_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1602_S2.Fill = new SolidColorBrush(Colors.Red); }));
        }

        public void _1602_S3_TurnOff()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1602_S3, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1602_S3,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _1602_S3.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    throw new ArgumentException();
                }
            }
        }

        public void _1602_S3_TurnOn()
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1602_S3, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1602_S3.Fill = new SolidColorBrush(Colors.Red); }));
        }

        #endregion


        #region Section G

        public void _1701_S1_TurnOff()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1701_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1701_S1,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _1701_S1.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    throw new ArgumentException();
                }
            }
        }

        public void _1701_S1_TurnOn()
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1701_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1701_S1.Fill = new SolidColorBrush(Colors.Red); }));
        }

        public void _1702_S1_TurnOff()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1702_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1702_S1,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _1702_S1.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    throw new ArgumentException();
                }
            }
        }

        public void _1702_S1_TurnOn()
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1702_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1702_S1.Fill = new SolidColorBrush(Colors.Red); }));
        }

        public void _1701_S2_TurnOff()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1701_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1701_S2,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _1701_S2.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    throw new ArgumentException();
                }
            }
        }

        public void _1701_S2_TurnOn()
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1701_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1701_S2.Fill = new SolidColorBrush(Colors.Red); }));
        }

       


        //public void _1701_S3T_TurnOff()
        //{
        //    _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1701_S3T, _plcCalls.Amount,
        // _plcCalls.Wordlen, Buffer);

        //    if (_res == 0)
        //    {
        //        try
        //        {
        //            if (Buffer[0] == 1)
        //            {
        //                Buffer[0] = 0;

        //                _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1701_S2,
        //                    _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

        //                Dispatcher.Invoke((Action)(() => { _1701_S3T.Fill = new SolidColorBrush(Colors.DarkGray); }));
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            throw new ArgumentException();
        //        }
        //    }
        //}

        //public void _1701_S3T_TurnOn()
        //{
        //    Buffer[0] = 1;

        //    _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1701_S3T, _plcCalls.Amount,
        //        _plcCalls.Wordlen, Buffer);

        //    Dispatcher.Invoke((Action)(() => { _1701_S3T.Fill = new SolidColorBrush(Colors.Red); }));
        //}

        public void _1702_S2_TurnOff()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1702_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1702_S2,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _1702_S2.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    throw new ArgumentException();
                }
            }
        }

        public void _1702_S2_TurnOn()
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1702_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1702_S2.Fill = new SolidColorBrush(Colors.Red); }));
        }

        #endregion


   

        //public void _1703_S3T_TurnOff()
        //{
        //    _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1703_S3T, _plcCalls.Amount,
        //       _plcCalls.Wordlen, Buffer);

        //    if (_res == 0)
        //    {
        //        try
        //        {
        //            if (Buffer[0] == 1)
        //            {
        //                Buffer[0] = 0;

        //                _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1703_S3T,
        //                    _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

        //                Dispatcher.Invoke((Action)(() => { _1703_S3T.Fill = new SolidColorBrush(Colors.DarkGray); }));
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            throw new ArgumentException();
        //        }
        //    }
        //}

        //public void _1703_S3T_TurnOn()
        //{
        //    Buffer[0] = 1;

        //    _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1703_S3T, _plcCalls.Amount,
        //        _plcCalls.Wordlen, Buffer);

        //    Dispatcher.Invoke((Action)(() => { _1703_S3T.Fill = new SolidColorBrush(Colors.Red); }));
        //}

       
        #region timers

        protected void FirstSensor()
        {
            //Timer aTimer = new Timer();
            //aTimer.Elapsed += new ElapsedEventHandler(_0102_S1_TurnOn);
            //aTimer.Interval = 400;
            //aTimer.Enabled = true;

            //aTimer.Elapsed += (s, e) => { aTimer.Stop(); };
        }

        protected void SecondSensorTimer()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0102_S2_TurnOff);
            aTimer.Interval = 800;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) => { aTimer.Stop(); };
        }

        protected void SecondSensorWrite()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0102_S2_TurnOn);
            aTimer.Interval = 900;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) => { aTimer.Stop(); };
        }

        protected void ThirdSensor()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0103_S1_TurnOff);
            aTimer.Interval = 2000;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) => { aTimer.Stop(); };
        }

        protected void ThirdSensorWrite()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0103_S1_TurnOn);
            aTimer.Interval = 820;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) => { aTimer.Stop(); };
        }

        protected void FourthSensor()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0104_S1_TurnOff);
            aTimer.Interval = 3000;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) => { aTimer.Stop(); };
        }

        protected void FourthSensorWrite()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0104_S1_TurnOn);
            aTimer.Interval = 650;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) => { aTimer.Stop(); };
        }

        protected void FifthSensor()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0105_S1_TurnOff);
            aTimer.Interval = 3600;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) => { aTimer.Stop(); };
        }

        protected void FifthSensorWrite()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0105_S1_TurnOn);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) => { aTimer.Stop(); };
        }

        protected void SixthSensor()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0105_S2_TurnOff);
            aTimer.Interval = 4500;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) => { aTimer.Stop(); };
        }

        protected void SixthSensorWrite()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0105_S2_TurnOn);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) => { aTimer.Stop(); };
        }


        protected void _0301_S2_Timer()
        {
            Timer aTimer = new Timer();
           aTimer.Elapsed += new ElapsedEventHandler(_0301_S1_TurnOff);
            aTimer.Interval = 4500;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) => { aTimer.Stop(); };
        }


        protected void _0301_S2_Timer_Write()
        {
            Timer aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(_0301_S1_TurnOn);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;

            aTimer.Elapsed += (s, e) => { aTimer.Stop(); };
        }

 

        #endregion

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
                  _plcCalls.EstablishContact();
               
               // myclient.ConnectTo("192.168.2.16", 0, 0);
              
                if (_plcCalls.Client.Connected())
                {
                    
                    _plcCalls.StartUp();
                    _plcCalls.SectionA();
                    _plcCalls.SectionB();
                    _plcCalls.SectionC();
                    _plcCalls.SectionD();
                    _plcCalls.SectionE();
                    _plcCalls.SectionF();
                    _plcCalls.SectionG();

                    //buffer[0] = 1;
                   // myclient.WriteArea(S7Client.S7AreaPE, DBNumber, 448, amount, wordlen, buffer);
                    
                    
                    _0102_S1.Fill = new SolidColorBrush(Colors.Red);
                    _0102_S2.Fill = new SolidColorBrush(Colors.Red);
                    _0103_S1.Fill = new SolidColorBrush(Colors.Red);
                    _0104_S1.Fill = new SolidColorBrush(Colors.Red);
                    _0105_S1.Fill = new SolidColorBrush(Colors.Red);
                    _0105_S2.Fill = new SolidColorBrush(Colors.Red);
                    _0301_S1.Fill = new SolidColorBrush(Colors.Red);
                    _0301_S2.Fill = new SolidColorBrush(Colors.Red);
                    _0302_S1.Fill = new SolidColorBrush(Colors.Red);
                    _0303_S1.Fill = new SolidColorBrush(Colors.Red);
                    _0304_S1.Fill = new SolidColorBrush(Colors.Red);
                    _0304_S2.Fill = new SolidColorBrush(Colors.Red);
                    _0304_S3.Fill = new SolidColorBrush(Colors.Red);
                    _0701_S1.Fill = new SolidColorBrush(Colors.Red);
                    _0702_S1.Fill = new SolidColorBrush(Colors.Red);
                    _0701_S2.Fill = new SolidColorBrush(Colors.Red);
                    _0702_S2.Fill = new SolidColorBrush(Colors.Red);
                    _1001_S1.Fill = new SolidColorBrush(Colors.Red);
                    _1001_S2.Fill = new SolidColorBrush(Colors.Red);
                    _1002_S2.Fill = new SolidColorBrush(Colors.Red);
                    _1003_S1.Fill = new SolidColorBrush(Colors.Red);
                    _1004_S1.Fill = new SolidColorBrush(Colors.Red);
                    _1003_S3.Fill = new SolidColorBrush(Colors.Red);
                    _1003_S4.Fill = new SolidColorBrush(Colors.Red);
                    _1003_S5.Fill = new SolidColorBrush(Colors.Red);
                    _1003_S2.Fill = new SolidColorBrush(Colors.Red);
                    _1101_S1.Fill = new SolidColorBrush(Colors.Red);
                    _1101_S2.Fill = new SolidColorBrush(Colors.Red);
                    _1101_S3.Fill = new SolidColorBrush(Colors.Red);
                    _1102_S1.Fill = new SolidColorBrush(Colors.Red);
                    _1102_S2.Fill = new SolidColorBrush(Colors.Red);
                    _1102_S3.Fill = new SolidColorBrush(Colors.Red);
                    _1002_S1.Fill = new SolidColorBrush(Colors.Red);
                    _1004_S2.Fill = new SolidColorBrush(Colors.Red);
                    _1601_S1.Fill = new SolidColorBrush(Colors.Red);
                    _1601_S2.Fill = new SolidColorBrush(Colors.Red);
                    _1601_S3.Fill = new SolidColorBrush(Colors.Red);
                    _1602_S1.Fill = new SolidColorBrush(Colors.Red);
                    _1602_S2.Fill = new SolidColorBrush(Colors.Red);
                    _1602_S3.Fill = new SolidColorBrush(Colors.Red);
                    _1701_S1.Fill = new SolidColorBrush(Colors.Red);
                    _1702_S1.Fill = new SolidColorBrush(Colors.Red);
                    _1701_S2.Fill = new SolidColorBrush(Colors.Red);
                    _1702_S2.Fill = new SolidColorBrush(Colors.Red);
                    _1701_S3T.Fill = new SolidColorBrush(Colors.Red);
                    _1702_S3T.Fill = new SolidColorBrush(Colors.Red);

                    ContactPlcBtn.IsEnabled = false;
                    
                }

            }


        /// <summary>
        /// Scheduler class 
        /// </summary>
        /// <param name="trays"></param>
        public void spraier(int trays)
        {
           
            //for (int i = 0; i < trays; i++)
            //{
                count += trays;
               
            //}
            NumberOfClicksToProduceTray(count);

        }



        public void NumberOfClicksToProduceTray(int count)
        {
            Dispatcher.Invoke((Action)(() => { MouseClickOfUser.Text = count.ToString(); }));
            
        }


        #region 

        public void TaskRunner()
        {
            int testtrays = 5;
            for (int i = 0; i < testtrays; i++)
            {
                SmallTray smallTray = new SmallTray();
                AnimationPannel.Children.Add(smallTray);
            }
        }

        #endregion



        public void addbutton(object source, ElapsedEventArgs e)
        {
            Dispatcher.Invoke((Action) (() => { AddTrayBtn.IsEnabled = true; }));
        }

   
     
        private void Grid_MouseDown_1(object sender, MouseButtonEventArgs e)
        {

            _attributesPanel = new AttributesPanel();

            _attributesPanel.Show();
           
            
            //   _0102_S1_TurnOff();


         //  _0102_S1_TurnOff();

            // this solutions from http://stackoverflow.com/questions/23507052/how-to-select-xaml-object-by-xname
//            foreach (UIElement item in Sensors.Children )
//            {
//                Ellipse el = (Ellipse)item;
//
//                if (el.Name == "_0102_S1")
//                {
//                    
//                }
//
//               
//            }
        }

      
        public void TestTimer()
        {
            var aTimer = new Timer();
            aTimer.Elapsed += new ElapsedEventHandler(MakeTrayBtn2_Click);
            aTimer.Interval = 1500;
            aTimer.Enabled = true;
            aTimer.AutoReset = true;
          
        }

       
      

        private void StopSimBtn_Click(object sender, RoutedEventArgs e)
        {
            _plcCalls.DegradedDecisionEventOk();
        }

        private void SchedulerBtn_Click(object sender, RoutedEventArgs e)
        {
            _schedulerPanel = new SchedulerPanel();
            _schedulerPanel.Show();
        }

        private void LaneTop_OnLoaded(object sender, RoutedEventArgs e)
        {
            TestTimer();
            
        }


        private void MakeTrayBtn2_Click(object sender, ElapsedEventArgs e)
        {
            var moveTopUpDuration = TimeSpan.FromSeconds(1);


            if (count > 0)
            {
                Dispatcher.Invoke((Action)(() =>
                {
                    _element = new SimpleTray();

                    var sb1 = FindResource("SectionA_SB") as Storyboard;
                    sb1.Begin(_element, true);
                    TestGrid.Children.Add(_element);

                    count--;
                    NumberOfClicksToProduceTray(count);


                   

                }));
                // 1. kijk of er ruimte is om een bak erbij te doen
                // 2. zo wel, dan kan een nieuwe bak aanmaken. 
                // 3. count --;
                // 4. NumberOfClicksToProduceTray(count);
                // 5. laat zien in text box. 
                // 6. zo niet, dan geberut er niks. 
            }

 


        }

        private void MakeTrayBtn_Click(object sender, RoutedEventArgs e)
        {

            count++;
            NumberOfClicksToProduceTray(count);
          
            
            // Executor();
        }

        #region storyboard completed

        private void StoryBoardSectionACompleted(object sender, EventArgs e)
        {
            var sb1 = FindResource("SectionB_SB") as Storyboard;

            sb1.Begin(_element);
            sb1.Completed += StoryBoardSectionBCompleted;
        }

        private void StoryBoardSectionBCompleted(object sender, EventArgs e)
        {
            var sb3 = FindResource("SectionB_SB") as Storyboard;

            sb3.Begin(_element);
        }

        #endregion




        private void Total(int count)
        {
           // total_text1.Text = (this.tray_Wrap.Children.Count).ToString();
            Dispatcher.Invoke((Action)(() => { TotalofObjects.Text = count.ToString(); }));
        }




        // building Queue 
        // from http://stackoverflow.com/a/1607741/3641381



       












    }


}
