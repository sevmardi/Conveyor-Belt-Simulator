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

using System.Windows.Media.Effects;
using System.ComponentModel;
using SSL_WPF.Events;
using SSL_WPF.Terminal;
using Components;

namespace SSL_WPF
{
    /// <summary>
    /// Interaction logic for SSL.xaml
    /// </summary>
    public partial class SSL : UserControl, IEnumerable<SSL.TerminalID>
    {
        private DropShadowEffect glow;
        protected TerminalID[] _termsid;
        private bool _sel;
        protected AbstractComponents _gate;


        /// <summary>
        /// Where a given terminal should be located.
        /// </summary>
        public enum Position
        {
            TOP, LEFT, RIGHT, BOTTOM
        }

        /// <summary>
        /// A terminal ID is a "catch-all" class which combines information
        /// about the actual gate, which input or output is involved, where it is
        /// on the visual gate, and the actual instance of the visual terminal class.
        /// </summary>
        public class TerminalID
        {

            /// <summary>
            /// Is this an input or output?
            /// </summary>
            public bool isInput;

            /// <summary>
            /// What is the input or output number?  This connects to the gate's
            /// input or output array.
            /// </summary>
            public int ID;

            /// <summary>
            /// Where is the terminal displayed?
            /// </summary>
            public Position pos;

            /// <summary>
            /// Actual terminal being displayed
            /// </summary>
            public Terminal.Terminal t;

            /// <summary>
            /// Gate being referenced
            /// </summary>
            public AbstractComponents abgate;
            public TerminalID(bool isInput, int ID, Position pos)
            {
                this.isInput = isInput;
                this.ID = ID;
                this.pos = pos;
                t = null;

                abgate = null;
            }
        }

        private Terminal.Terminal AddTerminal(Grid grid, int pos, bool isInput)
        {
            ColumnDefinition cd = new ColumnDefinition();
            cd.Width = new GridLength(1, GridUnitType.Star);
            grid.ColumnDefinitions.Add(cd);
            Terminal.Terminal myt = new Terminal.Terminal(isInput);
            grid.Children.Add(myt);
            Grid.SetColumn(myt, pos);

            return myt;
        }

        /// <summary>
        /// The gate "behind" this visual gate
        /// </summary>
        public AbstractComponents AbGate
        {
            get
            {
                return _gate;
            }
        }

        /// <summary>
        /// Retrieve a terminal by index.  The total number of terminals
        /// should be the number of inputs + the number of outputs for the gate.
        /// </summary>
        /// <param name="termidx"></param>
        /// <returns></returns>
        public TerminalID this[int termidx]
        {
            get
            {
                return _termsid[termidx];
            }
        }

        /// <summary>
        /// Number of terminals.  Should be # of inputs + # of outputs for the gate.
        /// </summary>
        public int Count
        {
            get
            {
                return _termsid.Count();
            }
        }


        private bool _showTF = true;
        public virtual bool ShowTrueFalse
        {
            get
            {
                return _showTF;

            }
            set
            {
                _showTF = value;
                _gate_PropertyChanged(null, null);
            }
        }

        /// Find a specific terminal that represents the given input or output
        /// on the gate.  ID refers to the 0-base array index for either
        /// the input or output array.
        /// </summary>
        /// <param name="isInput"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public TerminalID FindTerminal(bool isInput, int ID)
        {
            foreach (TerminalID ti in _termsid)
            {
                if (ti.isInput == isInput && ti.ID == ID)
                    return ti;
            }
            return null;
        }

        //private void _gate_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        //{
        //    foreach (TerminalID tid in _termsid)
        //    {
        //        if (ShowTrueFalse)
        //            tid.t.Value = tid.isInput ? _gate[tid.ID] : _gate.Output[tid.ID];
        //        else
        //            tid.t.Value = false;
        //    }

        //    ToolTip = _gate.Name;
        //}


        public SSL(AbstractComponents gate, TerminalID[] termsid)
        {
            InitializeComponent();
            _gate = gate;
            _termsid = termsid;

            ToolTip = _gate.Name;

            int ntop = 0, nleft = 0, nright = 0, nbottom = 0;
            for (int i = 0; i < termsid.Length; i++)
            {
                int posid;
                Grid target;
                switch (termsid[i].pos)
                {
                    case Position.TOP:
                        posid = ++ntop;
                        target = topGrid;
                        break;
                    case Position.LEFT:
                        posid = ++nleft;
                        target = leftGrid;
                        break;
                    case Position.RIGHT:
                        posid = ++nright;
                        target = rightGrid;
                        break;
                    case Position.BOTTOM:
                        posid = ++nbottom;
                        target = bottomGrid;
                        break;
                    default:
                        throw new ArgumentException("Position unspecified");
                }
                termsid[i].t = AddTerminal(target, posid, termsid[i].isInput);
                termsid[i].abgate = _gate;

                //  width and height depend on # of terminals
                this.SizeChanged += new SizeChangedEventHandler(SSL_SizeChanged);
                int horz = Math.Max(ntop, nbottom);
                int vert = Math.Max(nleft, nright);
                Width = Math.Max(horz * 20, Width);
                Height = Math.Max(vert * 20, Height);


                glow = new DropShadowEffect();
                glow.ShadowDepth = 0;
                glow.Color = Colors.Blue;
                glow.BlurRadius = 5;



                //_gate.PropertyChanged += EventDispatcher.CreateDispatchedHandler(Dispatcher, _gate_PropertyChanged);
                _gate.PropertyChanged += EventDispatcher.CreateBatchDispatchedHandler(_gate, _gate_PropertyChanged);

                _gate_PropertyChanged(null, null); // manually force load of initial values

                IsReadOnly = false;
            }
          }

         private void SSL_SizeChanged(object sender, SizeChangedEventArgs e)
         {
             topGrid.Width = Width;
             bottomGrid.Width = Width;
             // these last two are still width because they are just rotated
             leftGrid.Width = Height;
             rightGrid.Width = Height;

             SetValue(ExtraWidthProperty, Width - 64.0);
             SetValue(ExtraHeightProperty, Height - 64.0);
         }


         public bool Selected
         {
             get
             {
                 return _sel;
             }

             set
             {

                 _sel = value;
                 if (value)
                     Effect = glow;
                 else
                     Effect = null;
             }
         }
         public virtual SSL CreateUserInstance()
         {
             return (SSL)Activator.CreateInstance(GetType());
         }

         public virtual bool IsReadOnly { get; set; }

         protected static readonly DependencyProperty ExtraWidthProperty =
             DependencyProperty.Register("ExtraWidth", typeof(double), typeof(SSL));

         protected static readonly DependencyProperty ExtraHeightProperty =
             DependencyProperty.Register("ExtraHeight", typeof(double), typeof(SSL));

         #region IEnumerable<TerminalID> Members

         public IEnumerator<SSL.TerminalID> GetEnumerator()
         {
             return new List<SSL.TerminalID>(_termsid).GetEnumerator();
         }

         #endregion

         #region IEnumerable Members

         System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
         {
             return new List<SSL.TerminalID>(_termsid).GetEnumerator();
         }

         #endregion

    }
}
