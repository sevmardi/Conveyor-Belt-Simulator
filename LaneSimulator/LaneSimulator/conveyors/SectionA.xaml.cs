
using System;
using System.Timers;
using System.Windows;
using System.Windows.Media;
using LaneSimulator.PLC;
using Snap7;

namespace LaneSimulator.conveyors
{
    /// <summary>
    /// Interaction logic for Conveyor_A.xaml
    /// </summary>
    partial class SectionA
    {

        #region attributes
         private PLCAbstract _plcAbstract;
         private readonly byte[] _buffer = new byte[500];
         private int _res;

        public static readonly DependencyProperty ForwardDependencyProperty = DependencyProperty.Register("Forward",
            typeof(bool), typeof(SectionA), new PropertyMetadata(false));

        public static readonly DependencyProperty BackwardsDependencyProperty = DependencyProperty.Register("Reverse",
            typeof(bool), typeof(SectionA), new PropertyMetadata(false));

        public static DependencyProperty MaxSpeeDependencyProperty = DependencyProperty.Register("MaxSpeed",
            typeof(double), typeof(SectionA), new PropertyMetadata(new PropertyChangedCallback(MaxSpeedChanged)));

        double maxSpeed = 20.0;

        #endregion

        #region ctor
        public SectionA()
        {
            InitializeComponent();
           
            
        }
        #endregion
       
        #region properties
        public double MaxSpeed
        {
            get { return (double)GetValue(MaxSpeeDependencyProperty); }
            set { SetValue(MaxSpeeDependencyProperty, value); }
        }

        public bool Forward
        {
            get { return (bool)GetValue(ForwardDependencyProperty); }
            set { SetValue(ForwardDependencyProperty, value); }
        }

        public bool Reverse
        {
            get { return (bool)GetValue(BackwardsDependencyProperty); }
            set { SetValue(BackwardsDependencyProperty, value); }
        }

        public double Speed { get; set; }
        public double Acceleration { get; set; }
        #endregion

       


        //#region Motors

        public void _0102_D1Motor()
        {
            _res = _plcAbstract.Client.ReadArea(S7Client.S7AreaPA, _plcAbstract.DbNumber, PLCTags._0102_D1, _plcAbstract.Amount, _plcAbstract.Wordlen, _buffer);

            if (_res == 0)
            {
                try
                {
                    if (_buffer[0] == 1)
                    {
                       // Dispatcher.Invoke((Action) (() => { _0102_D1.Fill = new SolidColorBrush(Colors.Chartreuse); }));
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

        //public void _0103_D1Motor()
        //{
        //    _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0103_D1, _plcCalls.Amount,
        //        _plcCalls.Wordlen, Buffer);

        //    if (_res == 0)
        //    {
        //        try
        //        {
        //            if (Buffer[0] == 1)
        //            {
        //                Dispatcher.Invoke((Action) (() =>
        //                {
        //                    _0103_D1.Fill = new SolidColorBrush(Colors.Chartreuse);
        //                }));

        //            }
        //            else
        //            {
        //                // MessageBox.Show("Motor 0103D1 FALSE ");

        //            }
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }

        //    }
        //}

        //public void _0104_D1Motor()
        //{
        //    _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0104_D1, _plcCalls.Amount,
        //        _plcCalls.Wordlen, Buffer);

        //    if (_res == 0)
        //    {
        //        if (Buffer[0] == 1)
        //        {
        //            Dispatcher.Invoke((Action) (() =>
        //            {
        //                _0104_D1.Fill = new SolidColorBrush(Colors.Chartreuse);
        //            }));

        //        }
        //    }
        //}

        //public void _0105_D1Motor()
        //{
        //    _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0105_D1, _plcCalls.Amount,
        //        _plcCalls.Wordlen, Buffer);

        //    if (_res == 0)
        //    {
        //        if (Buffer[0] == 1)
        //        {
        //            Dispatcher.Invoke((Action) (() =>
        //            {
        //                _0105_D1.Fill = new SolidColorBrush(Colors.Chartreuse);
        //            }));

        //        }


        //    }
        //}

        //#endregion

        //#region Sensoren

        //public void _0102_S1_TurnOff()
        //{
        //    _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S1, _plcCalls.Amount,
        //        _plcCalls.Wordlen, Buffer);

        //    if (_res == 0)
        //    {
        //        try
        //        {
        //            if (Buffer[0] == 1)
        //            {
        //                Buffer[0] = 0;

        //                _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S1,
        //                    _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

        //                _0102_S1.Fill = new SolidColorBrush(Colors.DarkGray);
        //                //DelayAction(800, new Action(() => { this._0102_D1Motor(); }));

        //                _0102_D1Motor();
        //            }
        //            else
        //            {
        //                MessageBox.Show("Sensor #0102S1 on false");
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }

        //        FirstSensor();
        //    }
        //}

        //public void _0102_S1_TurnOn(object source, ElapsedEventArgs e)
        //{
        //    Buffer[0] = 1;

        //    _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S1, _plcCalls.Amount,
        //        _plcCalls.Wordlen, Buffer);

        //    Dispatcher.Invoke((Action) (() =>
        //    {
        //        _0102_S1.Fill = new SolidColorBrush(Colors.Red);
        //        _0102_D1.Fill = new SolidColorBrush(Colors.DarkGray);
        //    }));
        //}

        //public void _0102_S2_TurnOff(object source, ElapsedEventArgs e)
        //{
        //    _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S2, _plcCalls.Amount,
        //        _plcCalls.Wordlen, Buffer);

        //    if (_res == 0)
        //    {
        //        if (Buffer[0] == 1)
        //        {
        //            Buffer[0] = 0;
        //            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S2, _plcCalls.Amount,
        //                _plcCalls.Wordlen, Buffer);

        //            Dispatcher.Invoke((Action) (() => { _0102_S2.Fill = new SolidColorBrush(Colors.DarkGray); }));

        //            _0103_D1Motor();
        //        }
        //    }

        //    SecondSensorWrite();
        //}

        //public void _0102_S2_TurnOn(object source, ElapsedEventArgs e)
        //{
        //    Buffer[0] = 1;
        //    _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S2, _plcCalls.Amount,
        //        _plcCalls.Wordlen, Buffer);

        //    //Buffer[0] = 0;

        //    //_res = _plcCalls.Client.WriteArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0103_D1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

        //    Dispatcher.Invoke((Action) (() =>
        //    {
        //        _0102_S2.Fill = new SolidColorBrush(Colors.Red);
        //        _0103_D1.Fill = new SolidColorBrush(Colors.DarkGray);
        //    }));
        //}

        //public void _0103_S1_TurnOff(object source, ElapsedEventArgs e)
        //{
        //    _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0103_S1, _plcCalls.Amount,
        //        _plcCalls.Wordlen, Buffer);

        //    if (_res == 0)
        //    {
        //        if (Buffer[0] == 1)
        //        {
        //            Buffer[0] = 0;
        //            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0103_S1, _plcCalls.Amount,
        //                _plcCalls.Wordlen, Buffer);

        //            Dispatcher.Invoke((Action) (() => { _0103_S1.Fill = new SolidColorBrush(Colors.DarkGray); }));

        //            _0104_D1Motor();
        //        }
        //    }

        //    ThirdSensorWrite();
        //}

        //public void _0103_S1_TurnOn(object source, ElapsedEventArgs e)
        //{
        //    Buffer[0] = 1;
        //    _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0103_S1, _plcCalls.Amount,
        //        _plcCalls.Wordlen, Buffer);
        //    Buffer[0] = 0;
        //    _res = _plcCalls.Client.WriteArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0104_D1, _plcCalls.Amount,
        //        _plcCalls.Wordlen, Buffer);

        //    Dispatcher.Invoke((Action) (() =>
        //    {
        //        _0103_S1.Fill = new SolidColorBrush(Colors.Red);
        //        _0104_D1.Fill = new SolidColorBrush(Colors.DarkGray);
        //    }));
        //}

        //public void _0104_S1_TurnOff(object source, ElapsedEventArgs e)
        //{
        //    _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0104_S1, _plcCalls.Amount,
        //        _plcCalls.Wordlen, Buffer);

        //    if (_res == 0)
        //    {
        //        if (Buffer[0] == 1)
        //        {
        //            Buffer[0] = 0;
        //            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0104_S1, _plcCalls.Amount,
        //                _plcCalls.Wordlen, Buffer);

        //            Dispatcher.Invoke((Action) (() => { _0104_S1.Fill = new SolidColorBrush(Colors.DarkGray); }));
        //        }
        //    }
        //    FourthSensorWrite();
        //}

        //public void _0104_S1_TurnOn(object source, ElapsedEventArgs e)
        //{
        //    Buffer[0] = 1;
        //    _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0104_S1, _plcCalls.Amount,
        //        _plcCalls.Wordlen, Buffer);

        //    //Buffer[0] = 0;
        //    //_res = _plcCalls.Client.WriteArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0105_D1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

        //    Dispatcher.Invoke((Action) (() =>
        //    {
        //        _0104_S1.Fill = new SolidColorBrush(Colors.Red);
        //        _0105_D1.Fill = new SolidColorBrush(Colors.DarkGray);
        //    }));
        //}

        //public void _0105_S1_TurnOff(object source, ElapsedEventArgs e)
        //{
        //    _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0105_S1, _plcCalls.Amount,
        //        _plcCalls.Wordlen, Buffer);

        //    if (_res == 0)
        //    {
        //        if (Buffer[0] == 1)
        //        {
        //            Buffer[0] = 0;
        //            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0105_S1, _plcCalls.Amount,
        //                _plcCalls.Wordlen, Buffer);

        //            Dispatcher.Invoke((Action) (() => { _0105_S1.Fill = new SolidColorBrush(Colors.DarkGray); }));

        //            _0105_D1Motor();
        //        }
        //    }
        //    FifthSensorWrite();
        //}

        //public void _0105_S1_TurnOn(object source, ElapsedEventArgs e)
        //{
        //    Buffer[0] = 1;
        //    _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0105_S1, _plcCalls.Amount,
        //        _plcCalls.Wordlen, Buffer);
        //    //Buffer[0] = 0;
        //    //_res = plcCalls.Client.WriteArea(S7Client.S7AreaPA, PlcCalls.DbNumber, PLCTags._0105_D1, PlcCalls.Amount,
        //    //    PlcCalls.Wordlen, Buffer);

        //    Dispatcher.Invoke((Action) (() =>
        //    {
        //        _0105_S1.Fill = new SolidColorBrush(Colors.Red);
        //        _0105_D1.Fill = new SolidColorBrush(Colors.DarkGray);
        //    }));
        //}

        //public void _0105_S2_TurnOff(object source, ElapsedEventArgs e)
        //{
        //    _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0105_S2, _plcCalls.Amount,
        //        _plcCalls.Wordlen, Buffer);

        //    if (_res == 0)
        //    {
        //        if (Buffer[0] == 1)
        //        {
        //            Buffer[0] = 0;
        //            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0105_S2, _plcCalls.Amount,
        //                _plcCalls.Wordlen, Buffer);

        //            Dispatcher.Invoke((Action) (() => { _0105_S2.Fill = new SolidColorBrush(Colors.DarkGray); }));
        //        }
        //    }

        //    SixthSensorWrite();
        //}

        //public void _0105_S2_TurnOn(object source, ElapsedEventArgs e)
        //{
        //    Buffer[0] = 1;
        //    _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0105_S2, _plcCalls.Amount,
        //        _plcCalls.Wordlen, Buffer);

        //    //Buffer[0] = 0;
        //    //_res = _plcCalls.Client.WriteArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0105_D1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

        //    Dispatcher.Invoke((Action) (() =>
        //    {
        //        _0105_S2.Fill = new SolidColorBrush(Colors.Red);
        //        _0105_D1.Fill = new SolidColorBrush(Colors.DarkGray);
        //    }));
        //}

        //#endregion






    

        #region events
        public static void MaxSpeedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SectionA sectionA = d as SectionA;
            if (sectionA != null) sectionA.MaxSpeed = (double)e.NewValue;
        }

        #endregion
    }
}
