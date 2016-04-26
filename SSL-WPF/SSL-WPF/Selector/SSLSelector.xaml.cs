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
using SSL_WPF.Info;

namespace SSL_WPF.Selector
{
    /// <summary>
    /// Interaction logic for SSLSelector.xaml
    /// </summary>
    public partial class SSLSelector : UserControl
    {
        private UndoRedo.UndoManager undoProvider;
        private bool _ro = false;
        private string _icname;
        private const double MAX_SIZE = 100;

        public SSLSelector()
        {
            InitializeComponent();
        }


        /// <summary>
        /// If an undo manager is provided, changes to UI will be undoable.
        /// </summary>
        //public UndoRedo.UndoManager UndoProvider
        //{
        //    set
        //    {
        //        undoProvider = value;
        //    }
        //}


        //public bool isReadyOnly
        //{
        //    set
        //    {
        //        foreach (SSL g in spSSL.Children)
        //        {
        //            g.isReadyOnly = value;
        //            g.ContextMenu.IsEnabled = !value;
        //            SetInfoLine(g as UISSL.IC);
        //        }
        //        _ro = value;
        //    }
        //}


        //private void SetInfoLine(string c)
        //{
        //    string inf = "Left-drag to place";

        //    if (!_ro)
        //        inf += ", double-click to edit, type to rename";
        //    InfoLine.SetInfo(c, inf);
        //}




    }
}
