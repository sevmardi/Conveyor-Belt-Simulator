using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSL_WPF.UndoRedo
{
    /// <summary>
    /// An undo event for handling renames or other text changes.
    /// A method to change the text must be provided.
    /// </summary>

    public class ChangeUserText : IUndoable
    {
        private SSL ssl;

        private string oldText, newText;

        private delegate void setName(string n);
        private setName snf;

        //public ChangeUserText(SSL ssl, string oldText, string newText, setName snf)
        //{
        //    this.ssl = ssl;
        //    this.oldText = oldText;
        //    this.newText = newText;
        //    this.snf = snf;
        //}

        #region IUndoable Members

        public void Undo()
        {
            snf(oldText);
        }

        public void Redo()
        {
            snf(newText);
        }

        public bool CanUndo()
        {
            return true;
        }

        public bool CanRedo()
        {
            return true;
        }

        public string Name
        {
            get { return "Change User Text"; }
        }

        #endregion

    }

    /// <summary>
    /// An undo event handling the replacement of a SSL
    /// in an ICList with a different gate.
    /// </summary>
    

}
