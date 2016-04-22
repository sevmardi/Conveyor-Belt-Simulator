﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.ComponentModel;
using Snap7;
using System.Runtime.InteropServices;
using System;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private S7Client myclient;
        int amount = 1;
        int DBNumber = 0;
        int area;
        int wordlen = S7Client.S7WLBit;
        byte[] buffer = new byte[10];
        int res;

        static S7Client.S7DataItem[] items = new S7Client.S7DataItem[20];

        public MainWindow()
        {
            InitializeComponent();
            myclient = new S7Client();

            myclient.ConnectTo("192.168.2.16", 0, 0);

            object_to_move.Visibility = Visibility.Hidden;
          
         
        }

        private void btnStartSystem_Click(object sender, RoutedEventArgs e)
        {
            if (myclient.Connected())
            {
                buffer[0] = 1;
                myclient.WriteArea(S7Client.S7AreaPE, DBNumber, 448, amount, wordlen, buffer);
                object_to_move.Visibility = Visibility.Visible;
                _0102_S1.Fill = new SolidColorBrush(Colors.Red);

            }
          

        }

        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

        #endregion  

        private void btnRest_Click(object sender, RoutedEventArgs e)
        {
            object_to_move.Visibility = Visibility.Visible;
            buffer[0] = 1;
            myclient.WriteArea(S7Client.S7AreaMK, DBNumber, 7997, amount, wordlen, buffer);
        }

        private void btnStopSystem_Click(object sender, RoutedEventArgs e)
        {

            buffer[0] = 1;
            myclient.WriteArea(S7Client.S7AreaPE, DBNumber, 322, amount, wordlen, buffer);
            stopsystem();

        }
        protected void stopsystem()
        {
            buffer[0] = 0;
            myclient.WriteArea(S7Client.S7AreaPE, DBNumber, 448, amount, wordlen, buffer);
         //   object_to_move.Visibility = Visibility.Hidden;
           
        }

        
        
    }
}