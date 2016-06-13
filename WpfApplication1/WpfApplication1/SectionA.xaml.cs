using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for SectionA.xaml
    /// </summary>
    public partial class SectionA
    {
        public SectionA()
        {
            InitializeComponent();
        }

        public bool Start
        {
            get { return (bool)GetValue(StartProperty); }
            set { SetValue(StartProperty, value); }
        }
        public static readonly DependencyProperty StartProperty = DependencyProperty.Register("Start", typeof(bool), typeof(SectionA), new PropertyMetadata(false));
    }
}
