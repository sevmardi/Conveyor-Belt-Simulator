﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace SSL_WPF.UndoRedo
{

     /// <summary>
    /// Manages a sequence of undoable events. Items may be added to the
    /// undo line, undone, and redone as allowed by the iundoable instances.
    /// </summary>
    class UndoManager : INotifyPropertyChanged
    {
        private Stack<IUndoable> undos;
        private Stack<IUndoable> redos;

        private int? savepoint;

        public UndoManager()
        {
            undos = new Stack<IUndoable>();
            redos = new Stack<IUndoable>();
            savepoint = null;

        }

        /// <summary>
        /// Set the current state as a saved point.
        /// Whenever this state is reached by undo/redo sequence,
        /// the IsAtSavePoint property is true.
        /// </summary>
        public void SetSavePoint()
        {
            savepoint = 0;
            NotifyPropertyChanged("IsAtSavePoint");
        }

        public bool isASavePoint
        {
            get 
            {
                   return savepoint.HasValue && savepoint == 0;

            }

        }

        private void NotifyAllProps()
        {
            NotifyPropertyChanged("CanUndo");
            NotifyPropertyChanged("CanRedo");
            NotifyPropertyChanged("UndoName");
            NotifyPropertyChanged("RedoName");
            NotifyPropertyChanged("IsAtSavePoint");
        }

        /// <summary>
        /// Add an action to the top of the undo stack.
        /// This operation clears the redo stack.
        /// </summary>
        /// <param name="action"></param>
        public void Add(IUndoable action)
        {
            undos.Push(action);
            redos.Clear();

            if (savepoint.HasValue)
            {
                if (savepoint <= 0)
                {
                    // when adding an undo item, the save point moves away
                    // further back into the undo stack
                    // negatives redos means undos are required
                    savepoint--;
                }
                else
                {
                    // savepoint is on the redo stack
                    // redo stack just got cleared
                    savepoint = null;
                }

            }

            NotifyAllProps();
        }


        /// <summary>
        /// If possible, undo the top action on the undo stack.
        /// The action is moved onto the redo stack
        /// If not possible, throws an InvalidOperationException
        /// </summary>
        public void Undo()
        {
            if (!CanUndo)
                throw new InvalidOperationException();

            IUndoable action = undos.Pop();
            action.Undo();
            redos.Push(action);

            if (savepoint.HasValue)
            {
                // it will now take one more "redo" to reach the save point
                savepoint++;

            }

            NotifyAllProps();

        }

        /// <summary>
        /// If possible, redo the top action on the redo stack.
        /// The action is moved onto the undo stack.
        /// If not possible, throws an InvalidOperationException
        /// </summary>
        public void Redo()
        {
            if (!CanRedo)
                throw new InvalidOperationException();

            IUndoable action = redos.Pop();
            action.Redo();
            undos.Push(action);

            if (savepoint.HasValue)
            {
                // it will now take one less redo to reach the savepoint
                savepoint--;

            }

            NotifyAllProps();
        }

        /// <summary>
        /// Indicate if there is an item on the undo stack,
        /// and if the top item indicates it can undo.
        /// </summary>
        public bool CanUndo
        {
            get
            {
                if (undos.Count == 0) return false;
                return undos.Peek().CanUndo();
            }
        }

        /// <summary>
        /// Indicates if there is an item on the redo stack,
        /// and if the top item indicates it can redo.
        /// </summary>
        public bool CanRedo
        {
            get
            {
                if (redos.Count == 0) return false;
                return redos.Peek().CanRedo();
            }
        }

        /// <summary>
        /// "Undo " + The name of the top undo item + " (Ctrl+Z), if undo can be done.
        /// If not, just "Undo (Ctrl+Z)".
        /// </summary>
        public string UndoName
        {
            get
            {
                return "Undo " + (CanUndo ? undos.Peek().Name : "") + " (Ctrl+Z)";
            }
        }

        /// <summary>
        /// "Redo " + The name of the top redo item + " (Ctrl+Y)", if redo can be done.
        /// If not, just "Redo (Ctrl+Y)".
        /// </summary>
        public string RedoName
        {
            get
            {
                return "Redo " + (CanRedo ? redos.Peek().Name : "") + " (Ctrl+Y)";

            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        #endregion


    }
}
