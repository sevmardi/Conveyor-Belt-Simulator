using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSL_WPF.UndoRedo
{
    /// <summary>
    /// A transaction is an ordered list of undoables, performed together in sequence.
    /// Undo is performed most recently added to first added; redo performed in opposite order.
    /// </summary>
    class Transaction : List<IUndoable>, IUndoable
    {
        private bool undone = false;
        private string _name;

        public Transaction(string name)
        {
            _name = name;
        }

        #region IUndoable Members

        public void Undo()
        {
            if (!CanUndo())
                throw new InvalidOperationException();
            for (int i = this.Count - 1; i >= 0; i--)
                this[i].Undo();
            undone = true;

        }

        public void Redo()
        {
            if (!CanRedo())
                throw new InvalidOperationException();
            for (int i = 0; i < this.Count; i++)
                this[i].Redo();

            undone = false;
        }

        public bool CanUndo()
        {

            if (undone) return false;
            if (this.Count == 0) return true;
            return this[this.Count - 1].CanUndo();

        }

        public bool CanRedo()
        {
            if (!undone) return false;
            if (this.Count == 0) return true;
            return this[0].CanRedo();

        }

        public string Name
        {
            get { return _name; }
        }

        #endregion
    }
}
