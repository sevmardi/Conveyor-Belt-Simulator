using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SSL_WPF.Save
{
    /// <summary>
    /// Provides a save, don't save, cancel dialog.  Could be done with
    /// MessageBox and yes, no, cancel; but that's not quite as easy
    /// to understand.
    /// </summary>
    public partial class SaveClose : Window
    {

        private Result _r = Result.CANCEL;

        public enum Result
        {
            SAVE, DONT_SAVE, CANCEL
        }


        /// <summary>
        /// Result selected by the user.  Defaults to CANCEL
        /// </summary>
        public Result Selected
        {
            get
            {
                return _r;
            }
        }

        public SaveClose(string fileName)
        {
            InitializeComponent();

            lblCircuit.Text = String.Format(lblCircuit.Text, fileName);
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            _r = Result.SAVE;
            Close();
        }

        private void btnDontSave_Click(object sender, RoutedEventArgs e)
        {
            _r = Result.DONT_SAVE;
            Close();
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            _r = Result.CANCEL;
            Close();
        }

    }
}
