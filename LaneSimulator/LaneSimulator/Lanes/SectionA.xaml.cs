using System.Windows.Controls;
using LaneSimulator.PLC;
using Snap7;
using System.Timers;
using System;
using System.Windows.Media;

namespace LaneSimulator.Lanes
{
    /// <summary>
    /// Interaction logic for SectionA.xaml
    /// </summary>
    public partial class SectionA
    {
        private static int _res;
        private static readonly byte[] Buffer = new byte[500];
        private readonly PlcCalls _plcCalls;
        MainWindow main;


        public SectionA()
        {
            InitializeComponent();
           
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


        #region Motors section-A
        public void _0102_D1()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0102_D1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 0)
                {
                    // main._0102_D1.Fill = new SolidColorBrush(Colors.Chartreuse);
                }
            }
        }

        public void _0103_D1()
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

        public void _0104_D1()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0104_D1, _plcCalls.Amount,
                _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 1)
                {
                    //  main._0104_D1.Fill = new SolidColorBrush(Colors.Chartreuse);
                }
            }
        }

        public void _0105_D1()
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
        #endregion

        public void _0102_S1Read()
        {
            _res = _plcCalls.Client.ReadArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            if (_res == 0)
            {
                if (Buffer[0] == 1)
                {
                    Buffer[0] = 0;
                    _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);
                    //main._0102_S1.Fill = new SolidColorBrush(Colors.DarkGray);
                    _0102_D1();
                }
            }

            FirstSensor();
        }

        public void _0102_S1Write(object source, ElapsedEventArgs e)
        {
            Buffer[0] = 1;
            _plcCalls.Client.WriteArea(S7Client.S7AreaPE, _plcCalls.DbNumber, PLCTags._0102_S1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            //Buffer[0] = 0;
            //_res = _plcCalls.Client.WriteArea(S7Client.S7AreaPA, _plcCalls.DbNumber, PLCTags._0102_D1, _plcCalls.Amount, _plcCalls.Wordlen, Buffer);

            main.Dispatcher.Invoke((Action)(() =>
            {
                //      main._0102_S1.Fill = new SolidColorBrush(Colors.Red);
                //    main._0102_D1.Fill = new SolidColorBrush(Colors.DarkGray);
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

                    main.Dispatcher.Invoke((Action)(() =>
                    {
                      //  main._0102_S2.Fill = new SolidColorBrush(Colors.DarkGray);

                    }));

                    _0103_D1();

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

            main.Dispatcher.Invoke((Action)(() =>
            {
              //  main._0102_S2.Fill = new SolidColorBrush(Colors.Red);
              // main._0103_D1.Fill = new SolidColorBrush(Colors.DarkGray);
            }));
        }

        //public void _0103_S1Read(object source, ElapsedEventArgs e)
        //{
        //    _res = plcCalls.Client.ReadArea(S7Client.S7AreaPE, PlcCalls.DbNumber, PLCTags._0103_S1, PlcCalls.Amount,
        //        PlcCalls.Wordlen, Buffer);

        //    if (_res == 0)
        //    {
        //        if (Buffer[0] == 1)
        //        {
        //            Buffer[0] = 0;
        //            plcCalls.Client.WriteArea(S7Client.S7AreaPE, PlcCalls.DbNumber, PLCTags._0103_S1, PlcCalls.Amount,
        //                PlcCalls.Wordlen, Buffer);

        //            main.Dispatcher.Invoke((Action)(() =>
        //            {
        //                main._0103_S1.Fill = new SolidColorBrush(Colors.DarkGray);

        //            }));

        //            _0104_D1();

        //        }
        //    }

        //    ThirdSensorWrite();

        //}

        //public void _0103_S1Write(object source, ElapsedEventArgs e)
        //{
        //    Buffer[0] = 1;
        //    plcCalls.Client.WriteArea(S7Client.S7AreaPE, PlcCalls.DbNumber, PLCTags._0103_S1, PlcCalls.Amount,
        //        PlcCalls.Wordlen, Buffer);
        //    Buffer[0] = 0;
        //    _res = plcCalls.Client.WriteArea(S7Client.S7AreaPA, PlcCalls.DbNumber, PLCTags._0104_D1, PlcCalls.Amount,
        //        PlcCalls.Wordlen, Buffer);

        //    main.Dispatcher.Invoke((Action)(() =>
        //    {
        //        main._0103_S1.Fill = new SolidColorBrush(Colors.Red);
        //        main._0104_D1.Fill = new SolidColorBrush(Colors.DarkGray);
        //    }));
        //}

        //public void _0104_S1Read(object source, ElapsedEventArgs e)
        //{
        //    _res = plcCalls.Client.ReadArea(S7Client.S7AreaPE, PlcCalls.DbNumber, PLCTags._0104_S1, PlcCalls.Amount,
        //        PlcCalls.Wordlen, Buffer);

        //    if (_res == 0)
        //    {
        //        if (Buffer[0] == 1)
        //        {
        //            Buffer[0] = 0;
        //            plcCalls.Client.WriteArea(S7Client.S7AreaPE, PlcCalls.DbNumber, PLCTags._0104_S1, PlcCalls.Amount,
        //                PlcCalls.Wordlen, Buffer);

        //            main.Dispatcher.Invoke((Action)(() =>
        //            {
        //                main._0104_S1.Fill = new SolidColorBrush(Colors.DarkGray);

        //            }));


        //        }
        //    }
        //    FourthSensorWrite();

        //}

        //public void _0104_S1Write(object source, ElapsedEventArgs e)
        //{
        //    Buffer[0] = 1;
        //    plcCalls.Client.WriteArea(S7Client.S7AreaPE, PlcCalls.DbNumber, PLCTags._0104_S1, PlcCalls.Amount,
        //        PlcCalls.Wordlen, Buffer);
        //    Buffer[0] = 0;
        //    _res = PlcCalls.Client.WriteArea(S7Client.S7AreaPA, PlcCalls.DBNumber, PLCTags._0105_D1, PlcCalls.Amount,
        //        PlcCalls.Wordlen, Buffer);

        //    main.Dispatcher.Invoke((Action)(() =>
        //    {
        //        main._0104_S1.Fill = new SolidColorBrush(Colors.Red);
        //        main._0105_D1.Fill = new SolidColorBrush(Colors.DarkGray);
        //    }));
        //}

        //public void _0105_S1Read(object source, ElapsedEventArgs e)
        //{
        //    _res = plcCalls.Client.ReadArea(S7Client.S7AreaPE, PlcCalls.DbNumber, PLCTags._0105_S1, PlcCalls.Amount,
        //        PlcCalls.Wordlen, Buffer);

        //    if (_res == 0)
        //    {
        //        if (Buffer[0] == 1)
        //        {
        //            Buffer[0] = 0;
        //            plcCalls.Client.WriteArea(S7Client.S7AreaPE, PlcCalls.DbNumber, PLCTags._0105_S1, PlcCalls.Amount,
        //                PlcCalls.Wordlen, Buffer);

        //            main.Dispatcher.Invoke((Action)(() =>
        //            {
        //                main._0105_S1.Fill = new SolidColorBrush(Colors.DarkGray);

        //            }));

        //            _0105_D1();
        //        }
        //    }
        //    FifthSensorWrite();

        //}

        //public void _0105_S1Write(object source, ElapsedEventArgs e)
        //{
        //    Buffer[0] = 1;
        //    plcCalls.Client.WriteArea(S7Client.S7AreaPE, PlcCalls.DbNumber, PLCTags._0105_S1, PlcCalls.Amount,
        //        PlcCalls.Wordlen, Buffer);
        //    Buffer[0] = 0;
        //    _res = plcCalls.Client.WriteArea(S7Client.S7AreaPA, PlcCalls.DbNumber, PLCTags._0105_D1, PlcCalls.Amount,
        //        PlcCalls.Wordlen, Buffer);

        //    main.Dispatcher.Invoke((Action)(() =>
        //    {
        //        main._0105_S1.Fill = new SolidColorBrush(Colors.Red);
        //        main._0105_D1.Fill = new SolidColorBrush(Colors.DarkGray);
        //    }));
        //}

        //public void _0105_S2Read(object source, ElapsedEventArgs e)
        //{
        //    _res = plcCalls.Client.ReadArea(S7Client.S7AreaPE, PlcCalls.DbNumber, PLCTags._0105_S2, PlcCalls.Amount,
        //        PlcCalls.Wordlen, Buffer);

        //    if (_res == 0)
        //    {
        //        if (Buffer[0] == 1)
        //        {
        //            Buffer[0] = 0;
        //            plcCalls.Client.WriteArea(S7Client.S7AreaPE, PlcCalls.DbNumber, PLCTags._0105_S2, PlcCalls.Amount,
        //                PlcCalls.Wordlen, Buffer);

        //            main.Dispatcher.Invoke((Action)(() =>
        //            {
        //                main._0105_S2.Fill = new SolidColorBrush(Colors.DarkGray);

        //            }));


        //        }
        //    }
        //    SixthSensorWrite();

        //}

        //public void _0105_S2Write(object source, ElapsedEventArgs e)
        //{
        //    Buffer[0] = 1;
        //    plcCalls.Client.WriteArea(S7Client.S7AreaPE, PlcCalls.DbNumber, PLCTags._0105_S2, PlcCalls.Amount,
        //        PlcCalls.Wordlen, Buffer);
        //    Buffer[0] = 0;
        //    _res = PlcCalls.Client.WriteArea(S7Client.S7AreaPA, PlcCalls.DBNumber, PLCTags._0105_D1, PlcCalls.Amount,
        //        PlcCalls.Wordlen, Buffer);

        //    main.Dispatcher.Invoke((Action)(() =>
        //    {
        //        main._0105_S2.Fill = new SolidColorBrush(Colors.Red);
        //        main._0105_D1.Fill = new SolidColorBrush(Colors.DarkGray);
        //    }));
        //}


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


        //protected void ThirdSensor()
        //{
        //    Timer aTimer = new Timer();
        //    aTimer.Elapsed += new ElapsedEventHandler(_0103_S1Read);
        //    aTimer.Interval = 2000;
        //    aTimer.Enabled = true;

        //    aTimer.Elapsed += (s, e) =>
        //    {
        //        aTimer.Stop();
        //    };
        //}


        //protected void ThirdSensorWrite()
        //{
        //    Timer aTimer = new Timer();
        //    aTimer.Elapsed += new ElapsedEventHandler(_0103_S1Write);
        //    aTimer.Interval = 3500;
        //    aTimer.Enabled = true;

        //    aTimer.Elapsed += (s, e) =>
        //    {
        //        aTimer.Stop();
        //    };
        //}


        //protected void FourthSensor()
        //{
        //    Timer aTimer = new Timer();
        //    aTimer.Elapsed += new ElapsedEventHandler(_0104_S1Read);
        //    aTimer.Interval = 2500;
        //    aTimer.Enabled = true;

        //    aTimer.Elapsed += (s, e) =>
        //    {
        //        aTimer.Stop();
        //    };
        //}


        //protected void FourthSensorWrite()
        //{
        //    Timer aTimer = new Timer();
        //    aTimer.Elapsed += new ElapsedEventHandler(_0104_S1Write);
        //    aTimer.Interval = 3500;
        //    aTimer.Enabled = true;

        //    aTimer.Elapsed += (s, e) =>
        //    {
        //        aTimer.Stop();
        //    };
        //}


        //protected void FifthSensor()
        //{
        //    Timer aTimer = new Timer();
        //    aTimer.Elapsed += new ElapsedEventHandler(_0105_S1Read);
        //    aTimer.Interval = 3600;
        //    aTimer.Enabled = true;

        //    aTimer.Elapsed += (s, e) =>
        //    {
        //        aTimer.Stop();
        //    };
        //}


        //protected void FifthSensorWrite()
        //{
        //    Timer aTimer = new Timer();
        //    aTimer.Elapsed += new ElapsedEventHandler(_0105_S1Write);
        //    aTimer.Interval = 3800;
        //    aTimer.Enabled = true;

        //    aTimer.Elapsed += (s, e) =>
        //    {
        //        aTimer.Stop();
        //    };
        //}


        //protected void SixthSensor()
        //{
        //    Timer aTimer = new Timer();
        //    aTimer.Elapsed += new ElapsedEventHandler(_0105_S2Read);
        //    aTimer.Interval = 4500;
        //    aTimer.Enabled = true;

        //    aTimer.Elapsed += (s, e) =>
        //    {
        //        aTimer.Stop();
        //    };
        //}


        //protected void SixthSensorWrite()
        //{
        //    Timer aTimer = new Timer();
        //    aTimer.Elapsed += new ElapsedEventHandler(_0105_S2Write);
        //    aTimer.Interval = 4100;
        //    aTimer.Enabled = true;

        //    aTimer.Elapsed += (s, e) =>
        //    {
        //        aTimer.Stop();
        //    };
        //}

    }
}
