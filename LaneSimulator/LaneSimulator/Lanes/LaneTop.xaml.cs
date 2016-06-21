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
            _plcAbstract = new PLCAbstract();
            _plcCalls.EstablishContact();
        }


        public void ExecutorA()
        {
            _0102_S1_TurnOff();
            _sensorTimerHandler.Timer(1500, _0102_S2_TurnOff);
            _sensorTimerHandler.Timer(2000, _0103_S1_TurnOff);
            _sensorTimerHandler.Timer(3000, _0104_S1_TurnOff);
            _sensorTimerHandler.Timer(4500, _0105_S1_TurnOff);
            _sensorTimerHandler.Timer(5300, _0105_S2_TurnOff);
        }

        public void ExecutorC()
        {
            _sensorTimerHandler.Timer(15500, _0701_S2_TurnOff);
            _sensorTimerHandler.Timer(16000, _0702_S1_TurnOff);
            _sensorTimerHandler.Timer(17000, _0702_S2_TurnOff);
        }

        #region motoren

        //Section A
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
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0105_D1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 1)
                {
                    Dispatcher.Invoke((Action) (() => { _0105_D1.Fill = new SolidColorBrush(Colors.Chartreuse); }));
                }
            }
        }


        // section b 
        public void _0301_D1Motor()
        {
           _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0301_D1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 1)
                {
                    Dispatcher.Invoke((Action)(() => { _0301_D1.Fill = new SolidColorBrush(Colors.Chartreuse); }));
                }
            }
        }

        public void _0302_D1Motor()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0302_D1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 1)
                {
                    Dispatcher.Invoke((Action) (() => { _0302_D1.Fill = new SolidColorBrush(Colors.Chartreuse); }));
                }
            }
        }

        public void _0303_D1Motor()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0303_D1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 1)
                {
                    Dispatcher.Invoke((Action) (() => { _0303_D1.Fill = new SolidColorBrush(Colors.Chartreuse); }));
                }
            }
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
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0702_D1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 1)
                {
                    Dispatcher.Invoke((Action)(() => { _0702_D1.Fill = new SolidColorBrush(Colors.Chartreuse); }));
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

        // Sensor 1
        public void _0102_S1_TurnOff()
        {
            #region old method body 

            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                try
                {
                    if (Buffer[0] == 1)
                    {
                        Buffer[0] = 0;

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S1,
                            _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        _0102_S1.Fill = new SolidColorBrush(Colors.DarkGray);
                        //DelayAction(800, new Action(() => { this._0102_D1Motor(); }));

                        _0102_D1Motor();
                    }
                    else
                    {
                        MessageBox.Show("Sensor #0102S1 on false");
                    }
                    _sensorTimerHandler.Timer(1000, _0102_S1_TurnOn);
                }
                catch (Exception)
                {
                    new ArgumentException();
                }
            }

            #endregion

            #region new method

            //try
            //{
            //    _res = _plcAbstract.ReadSensorInput(PLCTags._0102_S1);

            //    if (_res == 0)
            //    {
            //        if (Buffer[0] == 1)
            //        {
            //            Buffer[0] = 0;

            //            _plcAbstract.WriteSensorInput(PLCTags._0102_S1);

            //            _0102_S1.Fill = new SolidColorBrush(Colors.DarkGray);

            //            //  _0102_D1Motor();
            //        }
            //        else
            //            MessageBox.Show("Sensor #0102S1 on false");
            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("There is no connection");
            //}

            #endregion

            //    _sensorTimerHandler.Timer(400, _0102_S1_TurnOn);
            // FirstSensor();  
        }

        public void _0102_S1_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() =>
            {
                _0102_S1.Fill = new SolidColorBrush(Colors.Red);
                _0102_D1.Fill = new SolidColorBrush(Colors.DarkGray);
            }));
        }

        // Sensor 2
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
            _sensorTimerHandler.Timer(650, _0102_S2_TurnOn);

              //   SecondSensorWrite();
        }

        public void _0102_S2_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;
            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() =>
            {
                _0102_S2.Fill = new SolidColorBrush(Colors.Red);
                _0103_D1.Fill = new SolidColorBrush(Colors.DarkGray);
            }));
        }

        // Sensor 3
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

                    Dispatcher.Invoke((Action) (() => { _0103_S1.Fill = new SolidColorBrush(Colors.DarkGray); }));

                    _0104_D1Motor();
                }
            }

            _sensorTimerHandler.Timer(650, _0103_S1_TurnOn);
        }

        public void _0103_S1_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;
            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0103_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);
 
            Dispatcher.Invoke((Action) (() =>
            {
                _0103_S1.Fill = new SolidColorBrush(Colors.Red);
                _0104_D1.Fill = new SolidColorBrush(Colors.DarkGray);
            }));
        }

        // Sensor 4 
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
            _sensorTimerHandler.Timer(650, _0104_S1_TurnOn);
        }

        public void _0104_S1_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0104_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() =>
            {
                _0104_S1.Fill = new SolidColorBrush(Colors.Red);
                _0105_D1.Fill = new SolidColorBrush(Colors.DarkGray);
            }));
        }

        // Sensor 5 
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
            _sensorTimerHandler.Timer(650, _0105_S1_TurnOn);
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

        // Sensor 6
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
            _sensorTimerHandler.Timer(650, _0105_S2_TurnOn);
           

        }

        public void _0105_S2_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;
            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0105_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() =>
            {
                _0105_S2.Fill = new SolidColorBrush(Colors.Red);
                _0105_D1.Fill = new SolidColorBrush(Colors.DarkGray);
            }));
        }

        #endregion

        public void ExecutorB()
        {
            _sensorTimerHandler.Timer(6000, _0301_S1_TurnOff);
            _sensorTimerHandler.Timer(7000, _0301_S2_TurnOff);
            _sensorTimerHandler.Timer(8000, _0302_S1_TurnOff);
            _sensorTimerHandler.Timer(8200, _0303_S1_TurnOff);
            _sensorTimerHandler.Timer(8300, _0304_S1_TurnOff);
            _sensorTimerHandler.Timer(8400, _0304_S2_TurnOff);

            _sensorTimerHandler.Timer(10200, _0304_S3_TurnOff);
            _sensorTimerHandler.Timer(12000, _0701_S1_TurnOff);
        }

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
            _sensorTimerHandler.Timer(650, _0301_S1_TurnOn);
        }
        public void _0301_S1_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;
            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0301_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() =>
            {
                _0301_S1.Fill = new SolidColorBrush(Colors.Red);
                _0301_D1.Fill = new SolidColorBrush(Colors.DarkGray);
            }));
        }
        
        public void _0301_S2_TurnOff(object source, ElapsedEventArgs e)
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0301_S2, _plcCalls.Amount,
               _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 1)
                {
                    Buffer[0] = 0;
                    _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0301_S2, _plcCalls.Amount,
                        _plcCalls.Wordlen, Buffer);

                    Dispatcher.Invoke((Action)(() =>
                    {
                        _0301_S2.Fill = new SolidColorBrush(Colors.DarkGray);
                        _0301_D1Motor();
                        _0302_D1Motor();
                        _0303_D1Motor();
                    }));
                }
            }
            _sensorTimerHandler.Timer(650, _0301_S2_TurnOn);
        }
        public void _0301_S2_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0301_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() =>
            {
                _0301_S2.Fill = new SolidColorBrush(Colors.Red);
                _0301_D1.Fill = new SolidColorBrush(Colors.DarkGray);
                _0302_D1.Fill = new SolidColorBrush(Colors.DarkGray);
                _0303_D1.Fill = new SolidColorBrush(Colors.DarkGray);
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

                        _0302_D1Motor();
                        _0303_D1Motor();
                    }
                }
                catch (Exception)
                {
                    new ArgumentException();
                }
            }
            _sensorTimerHandler.Timer(650, _0302_S1_TurnOn);
        }
        public void _0302_S1_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0302_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() =>
            {
                _0302_S1.Fill = new SolidColorBrush(Colors.Red);
                _0302_D1.Fill = new SolidColorBrush(Colors.DarkGray);
                _0303_D1.Fill = new SolidColorBrush(Colors.DarkGray);
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
            _sensorTimerHandler.Timer(500, _0303_S1_TurnOn);
        }     
        public void _0303_S1_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0303_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _0303_S1.Fill = new SolidColorBrush(Colors.Red); }));
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
            _sensorTimerHandler.Timer(500, _0304_S1_TurnOn);
        }
        public void _0304_S1_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0304_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _0304_S1.Fill = new SolidColorBrush(Colors.Red); }));
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
           _sensorTimerHandler.Timer(650, _0304_S2_TurnOn);
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
        // tot hier done

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
            _sensorTimerHandler.Timer(650, _0304_S3_TurnOn);
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

        public void _0701_S1_TurnOff(object source, ElapsedEventArgs e)
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
            _sensorTimerHandler.Timer(650, _0701_S1_TurnOn);
        }

        public void _0701_S1_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0701_S1, _plcCalls.Amount,_plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() =>
            {
                _0701_S1.Fill = new SolidColorBrush(Colors.Red);
            }));
        }

        #endregion


        #region Section C

        public void _0701_S2_TurnOff(object source, ElapsedEventArgs e)
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

                        _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0701_S2, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

                        Dispatcher.Invoke((Action) (() => { _0701_S2.Fill = new SolidColorBrush(Colors.DarkGray); }));
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }
            _sensorTimerHandler.Timer(650, _0701_S2_TurnOn);
        }

        public void _0701_S2_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0701_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() =>
            {
                _0701_S2.Fill = new SolidColorBrush(Colors.Red);
            }));
        }

       
        public void _0702_S1_TurnOff(object source, ElapsedEventArgs e)
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

                        _0702_D1Motor();
                    }
                }
                catch (Exception)
                {
                    //ignore
                }
            }
            _sensorTimerHandler.Timer(650, _0702_S1_TurnOn);
        }

        public void _0702_S1_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0702_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() =>
            {
                _0702_S1.Fill = new SolidColorBrush(Colors.Red);
       
                _0702_D1.Fill = new SolidColorBrush(Colors.DarkGray);
            }));
        }

      
        public void _0702_S2_TurnOff(object source, ElapsedEventArgs e)
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
            _sensorTimerHandler.Timer(650, _0702_S2_TurnOn);
        }

        public void _0702_S2_TurnOn(object source, ElapsedEventArgs e)
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

        public void ExecutorD()
        {
            _sensorTimerHandler.Timer(18000, _1001_S1_TurnOff);
            _sensorTimerHandler.Timer(18500, _1001_S2_TurnOff);
            _sensorTimerHandler.Timer(19200, _1002_S1_TurnOff);
            _sensorTimerHandler.Timer(19700, _1002_S2_TurnOff);
            _sensorTimerHandler.Timer(19710, _1004_S1_TurnOff);
            _sensorTimerHandler.Timer(19720, _1003_S1_TurnOff);

            _sensorTimerHandler.Timer(20100, _1003_S3_TurnOff);
            _sensorTimerHandler.Timer(19760, _1003_S4_TurnOff);

            //_sensorTimerHandler.Timer(21500, _1003_S5_TurnOff);
            //_sensorTimerHandler.Timer(22500, _1003_S2_TurnOff);
            _sensorTimerHandler.Timer(21500, _1004_S2_TurnOff);
        }

        #region Section D

        public void _1001_S1_TurnOff(object source, ElapsedEventArgs e)
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
            _sensorTimerHandler.Timer(650, _1001_S1_TurnOn);
        }

        public void _1001_S1_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1001_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action)(() => { _1001_S1.Fill = new SolidColorBrush(Colors.Red); }));
        }


        public void _1001_S2_TurnOff(object source, ElapsedEventArgs e)
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
            _sensorTimerHandler.Timer(650, _1001_S2_TurnOn);
        }

        public void _1001_S2_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1001_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1001_S2.Fill = new SolidColorBrush(Colors.Red); }));
        }

        
        public void _1002_S1_TurnOff(object source, ElapsedEventArgs e)
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
            _sensorTimerHandler.Timer(650, _1002_S1_TurnOn);
        }

        public void _1002_S1_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1002_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1002_S1.Fill = new SolidColorBrush(Colors.Red); }));
        }

    
        public void _1002_S2_TurnOff(object source, ElapsedEventArgs e)
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
            _sensorTimerHandler.Timer(650, _1002_S2_TurnOn);
        }

        public void _1002_S2_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1002_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1002_S2.Fill = new SolidColorBrush(Colors.Red); }));
        }


        public void _1004_S1_TurnOff(object source, ElapsedEventArgs e)
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
            _sensorTimerHandler.Timer(650, _1004_S1_TurnOn);
        }

        public void _1004_S1_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1004_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1004_S1.Fill = new SolidColorBrush(Colors.Red); }));
        }

     
        public void _1003_S1_TurnOff(object source, ElapsedEventArgs e)
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
            _sensorTimerHandler.Timer(650, _1003_S1_TurnOn);
        }

        public void _1003_S1_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1003_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1003_S1.Fill = new SolidColorBrush(Colors.Red); }));
        }

 
        public void _1003_S3_TurnOff(object source, ElapsedEventArgs e)
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
            _sensorTimerHandler.Timer(650, _1003_S3_TurnOn);
        }

        public void _1003_S3_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1003_S3, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1003_S3.Fill = new SolidColorBrush(Colors.Red); }));
        }

        public void _1003_S4_TurnOff(object source, ElapsedEventArgs e)
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
            _sensorTimerHandler.Timer(650, _1003_S4_TurnOn);
        }

        public void _1003_S4_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1003_S4, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1003_S4.Fill = new SolidColorBrush(Colors.Red); }));
        }


        public void _1003_S5_TurnOff(object source, ElapsedEventArgs e)
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
            _sensorTimerHandler.Timer(650, _1003_S5_TurnOn);
        }

        public void _1003_S5_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1003_S5, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1003_S5.Fill = new SolidColorBrush(Colors.Red); }));
        }

      
        public void _1003_S2_TurnOff(object source, ElapsedEventArgs e)
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
            _sensorTimerHandler.Timer(650, _1003_S2_TurnOn);
        }

        public void _1003_S2_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1003_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1003_S2.Fill = new SolidColorBrush(Colors.Red); }));
        }


        public void _1004_S2_TurnOff(object source, ElapsedEventArgs e)
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
            _sensorTimerHandler.Timer(650, _1004_S2_TurnOn);
        }

        public void _1004_S2_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1003_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1003_S2.Fill = new SolidColorBrush(Colors.Red); }));
        }

        #endregion

        public void ExecutorE()
        {
            //   _sensorTimerHandler.Timer(22500, _1101_S1_TurnOff);

            _sensorTimerHandler.Timer(28500, _1102_S1_TurnOff);

            //        _sensorTimerHandler.Timer(23500, _1101_S2_TurnOff);
            _sensorTimerHandler.Timer(29000, _1102_S2_TurnOff);
            //      _sensorTimerHandler.Timer(24500, _1101_S3_TurnOff);

            _sensorTimerHandler.Timer(29500, _1102_S3_TurnOff);
        }


        #region Section E
        public void _1101_S1_TurnOff(object source, ElapsedEventArgs e)
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
            _sensorTimerHandler.Timer(21500, _1101_S1_TurnOn); 
        }

        public void _1101_S1_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1101_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1101_S1.Fill = new SolidColorBrush(Colors.Red); }));
        }


        public void _1102_S1_TurnOff(object source, ElapsedEventArgs e)
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
            _sensorTimerHandler.Timer(650, _1102_S1_TurnOn); 
        }

        public void _1102_S1_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1102_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1102_S1.Fill = new SolidColorBrush(Colors.Red); }));
        }


        public void _1101_S2_TurnOff(object source, ElapsedEventArgs e)
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
            _sensorTimerHandler.Timer(650, _1101_S2_TurnOn); 
        }

        public void _1101_S2_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1101_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1101_S2.Fill = new SolidColorBrush(Colors.Red); }));
        }

        
        public void _1102_S2_TurnOff(object source, ElapsedEventArgs e)
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
            _sensorTimerHandler.Timer(650, _1102_S2_TurnOn); 
        }

        public void _1102_S2_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1102_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1102_S2.Fill = new SolidColorBrush(Colors.Red); }));
        }

        
        public void _1101_S3_TurnOff(object source, ElapsedEventArgs e)
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
            _sensorTimerHandler.Timer(650, _1101_S3_TurnOn); 
        }

        public void _1101_S3_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1101_S3, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1101_S3.Fill = new SolidColorBrush(Colors.Red); }));
        }

        
        public void _1102_S3_TurnOff(object source, ElapsedEventArgs e)
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

        public void _1102_S3_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1102_S3, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1102_S3.Fill = new SolidColorBrush(Colors.Red); }));
        }

        #endregion

        
        public void ExecutorF()
        {
            //  _sensorTimerHandler.Timer(22500, _1601_S1_TurnOff);
            //  _sensorTimerHandler.Timer(22500, _1601_S2_TurnOff);
            //  _sensorTimerHandler.Timer(23500, _1601_S3_TurnOff);
            _sensorTimerHandler.Timer(29500, _1602_S1_TurnOff);
            _sensorTimerHandler.Timer(30000, _1602_S2_TurnOff);
            _sensorTimerHandler.Timer(31000, _1602_S3_TurnOff);
        }


        #region Section F

        public void _1601_S1_TurnOff(object source, ElapsedEventArgs e)
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
            _sensorTimerHandler.Timer(650, _1601_S1_TurnOn);
        }

        public void _1601_S1_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1601_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1601_S1.Fill = new SolidColorBrush(Colors.Red); }));
        }

        
        public void _1601_S2_TurnOff(object source, ElapsedEventArgs e)
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
            _sensorTimerHandler.Timer(650, _1601_S2_TurnOn);
        }

        public void _1601_S2_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1601_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1601_S2.Fill = new SolidColorBrush(Colors.Red); }));
        }

       
        public void _1601_S3_TurnOff(object source, ElapsedEventArgs e)
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
            _sensorTimerHandler.Timer(650, _1601_S3_TurnOn);
        }

        public void _1601_S3_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1601_S3, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1601_S3.Fill = new SolidColorBrush(Colors.Red); }));
        }

        
        public void _1602_S1_TurnOff(object source, ElapsedEventArgs e)
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
            _sensorTimerHandler.Timer(650, _1602_S1_TurnOn);
        }

        public void _1602_S1_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1602_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1602_S1.Fill = new SolidColorBrush(Colors.Red); }));
        }

       
        public void _1602_S2_TurnOff(object source, ElapsedEventArgs e)
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
            _sensorTimerHandler.Timer(650, _1602_S2_TurnOn);
        }

        public void _1602_S2_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1602_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1602_S2.Fill = new SolidColorBrush(Colors.Red); }));
        }

       
        public void _1602_S3_TurnOff(object source, ElapsedEventArgs e)
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
            _sensorTimerHandler.Timer(650, _1602_S3_TurnOn);
        }

        public void _1602_S3_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1602_S3, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1602_S3.Fill = new SolidColorBrush(Colors.Red); }));
        }

        #endregion

        public void ExecutorG()
        {
            //    _sensorTimerHandler.Timer(22500, _1701_S1_TurnOff);
            //   _sensorTimerHandler.Timer(22500, _1702_S1_TurnOff);

            _sensorTimerHandler.Timer(32000, _1701_S2_TurnOff);
            _sensorTimerHandler.Timer(33000, _1702_S2_TurnOff);
        }

        #region Section G

        public void _1701_S1_TurnOff(object source, ElapsedEventArgs e)
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
            _sensorTimerHandler.Timer(650, _1701_S1_TurnOn);
        }

        public void _1701_S1_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1701_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1701_S1.Fill = new SolidColorBrush(Colors.Red); }));
        }


        public void _1702_S1_TurnOff(object source, ElapsedEventArgs e)
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
            _sensorTimerHandler.Timer(650, _1702_S1_TurnOn);
        }

        public void _1702_S1_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1702_S1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1702_S1.Fill = new SolidColorBrush(Colors.Red); }));
        }


        public void _1701_S2_TurnOff(object source, ElapsedEventArgs e)
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
            _sensorTimerHandler.Timer(650, _1701_S2_TurnOn);
        }

        public void _1701_S2_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1701_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1701_S2.Fill = new SolidColorBrush(Colors.Red); }));
        }


        public void _1702_S2_TurnOff(object source, ElapsedEventArgs e)
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
            _sensorTimerHandler.Timer(650, _1702_S2_TurnOn);
        }

        public void _1702_S2_TurnOn(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;

            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._1702_S2, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            Dispatcher.Invoke((Action) (() => { _1702_S2.Fill = new SolidColorBrush(Colors.Red); }));
        }

        #endregion


   




     
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

      
//        public void TestTimer()
//        {
//            var aTimer = new Timer();
//            aTimer.Elapsed += new ElapsedEventHandler(MakeTrayBtn2_Click);
//            aTimer.Interval = 2500;
//            aTimer.Enabled = true;
//            aTimer.AutoReset = true;
//        }




        public void test()
        {
            Dispatcher.Invoke((Action) (() =>
            {
                _element = new SimpleTray();
                var sb1 = FindResource("LongApprovedSB") as Storyboard;
                sb1.Begin(_element, true);
                PanelForApproved.Children.Add(_element);

                MainExecutor();
            }));
        }

        public void StopSystem()
        {
            PanelForApproved.Children.Remove(_element);
        }

       /* private void MakeTrayBtn2_Click(object sender, ElapsedEventArgs e)
        {
            var moveTopUpDuration = TimeSpan.FromSeconds(1);


            if (count > 0)
            {
                Dispatcher.Invoke((Action)(() =>
                {
                    _element = new SimpleTray();

                    //ViewModel vm = this.DataContext as ViewModel;

                    //vm.ApprovedCollection.Add(new SimpleTray());

                    var sb1 = FindResource("LongApprovedSB") as Storyboard;
                    sb1.Begin(_element, true);
                    PanelForApproved.Children.Add(_element);
                    
                    MainExecutor();
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

        }*/



        #region storyboard completed

        private void StoryBoardSectionACompleted(object sender, EventArgs e)
        {

        }

        private void StoryBoardSectionBCompleted(object sender, EventArgs e)
        {
          
        }

        #endregion

        private void Total()
        {
           // total_text1.Text = (this.tray_Wrap.Children.Count).ToString();
            Dispatcher.Invoke((Action)(() => { (AnimationPanel.Children.Count).ToString(); }));
        }




        // building Queue 
        // from http://stackoverflow.com/a/1607741/3641381



        public void StartSystem()
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

            //    ContactPlcBtn.IsEnabled = false;

            }
        }


        public void MainExecutor()
        {
//            ExecutorA();
//            ExecutorB();
//            ExecutorC();
//            ExecutorD();
//            ExecutorE();
//            ExecutorF();
//            ExecutorG();
        }





    }

    public enum DegradedMode
    {
        Approved,
        NotApproved
    }
}
