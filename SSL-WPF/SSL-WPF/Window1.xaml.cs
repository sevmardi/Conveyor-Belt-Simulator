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
using System.Windows.Shapes;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Controls.Primitives;
using SSL_WPF.Info;
using SSL_WPF.Save;

namespace SSL_WPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public static string APP_TITLE;
        public static string APP_VERSION;
        public static string APP_COPYRIGHT;

        public static string LOAD_ON_START = "";

        private string _filename;
        private EditLevel _myEditLevel;
        private ShadowBox sbZoom, sbSpeed, sbGates;

        private Rectangle ICBounds;
        private Line ICBounds_Line1, ICBounds_Line2;

       
        public Window1()
        {
            InitializeComponent();
           // _myEditLevel = e;

           // SSLCanvas.Circuit.Start();


            // Everybody gets zoom
            sbZoom = new ShadowBox();
            sbZoom.Margin = new Thickness(20);
           // Grid1.Children.Remove(spZoom);
          //  sbZoom.Children.Add(spZoom);
          //  spZoom.Background = Brushes.Transparent;
            sbZoom.VerticalAlignment = VerticalAlignment.Top;
            sbZoom.HorizontalAlignment = HorizontalAlignment.Right;
            Grid1.Children.Add(sbZoom);
            Grid.SetColumn(sbZoom, 1);
            Grid.SetRow(sbZoom, 1);


            // everybody gets view keys
           // this.PreviewKeyDown += new KeyEventHandler(Window1_View_KeyDown);


        }

      

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DisplayConnectScreen();
        } 

        private void DisplayConnectScreen()
        {
            ConnectPanel connectpanel = new ConnectPanel();

            connectpanel.Owner = this;
            connectpanel.ShowDialog();

            if (connectpanel.DialogResult.HasValue && connectpanel.DialogResult.Value)
            {
                //do something
                MessageBox.Show("Connected!");
                
            }
            else
                this.Close();
        }


        public void RefreshSSLCanvas()
        {
           // Grid1.Children.Remove(SSLCanvas);


            // SSLCanvas.Circuit.Stop();


        }


        /// <summary>
        /// The "edit" permissions of a window
        /// </summary>
        public enum EditLevel
        {
            /// <summary>
            /// Full applies only to the main window.  Full indicates all application
            /// control.  Only one full window should exist.
            /// </summary>
            FULL,

            /// <summary>
            /// Edit applies changes to be applied to the circuit, but not application-level
            /// operations like creating an IC or saving.
            /// </summary>
            EDIT,

            /// <summary>
            /// View allows only observation of a circuit.
            /// </summary>
            VIEW
        }


        /// <summary>
        /// Gets the edit level of this window
        /// </summary>
        public EditLevel MyEditLevel
        {
            get
            {
                return _myEditLevel;
            }
        }

        private void Window1_Closing(object sender, CancelEventArgs e)
        {
            // only the orginal full window 
            e.Cancel = !QuerySave();
        }


        private bool QuerySave()
        {
            if (!((UndoRedo.UndoManager)Resources["undoManager"]).isASavePoint)
            {
                SaveClose sc = new SaveClose(String.IsNullOrEmpty(_filename) ? "[Untitled]" : _filename);
                sc.ShowDialog();
                switch (sc.Selected)
                {
                    case SaveClose.Result.SAVE:
                        break;
                    case SaveClose.Result.DONT_SAVE:
                        break;
                    case SaveClose.Result.CANCEL:
                        break;
                    default:
                        break;
                }
            }

            return true;
        }

        private void InfoLine_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(InfoLine.GetInstance().CurrentInfoLine) || !this.IsActive)
            {
                lblInfoLine.Visibility = Visibility.Collapsed;
                spAppInfo.Visibility = Visibility.Visible;

            }
            else
            {
                lblInfoLine.Text = InfoLine.GetInstance().CurrentInfoLine;
                lblInfoLine.Visibility = Visibility.Visible;
                spAppInfo.Visibility = Visibility.Collapsed;
            }
        }


    }
}
