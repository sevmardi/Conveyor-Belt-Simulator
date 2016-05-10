using System;
using System.Net.Mime;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace LaneTop
{
    /// <summary>
    /// Interaction logic for Trays.xaml
    /// </summary>
    public partial class Trays : UserControl, IComponentConnector
    {
        internal Trays UserControl2;
        private bool _contentLoaded;
        
        public Trays()
        {
            this.InitializeComponent();
        }

        //public void InitializeComponent()
        //{
        //    if (this._contentLoaded) return;
        //    this._contentLoaded = true;
        //    Application.LoadComponent((object)this, new Uri("/LaneTop/Trays.xaml ", UriKind.Relative));
        //}
    }
}
