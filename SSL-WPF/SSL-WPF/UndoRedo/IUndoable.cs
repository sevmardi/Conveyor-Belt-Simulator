using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSL_WPF.UndoRedo
{
    /// <summary>
    /// Describes an action which may be undone and/or redone
    /// </summary>
    public interface IUndoable
    {
        /// <summary>
        /// Undo this operation
        /// </summary>
        void Undo();

        /// <summary>
        /// Redo this operation
        /// </summary>
        void Redo();

        /// <summary>
        /// Indicates if an operation may be undone
        /// </summary>
        /// <returns></returns>
        bool CanUndo();

        /// <summary>
        /// Indicates if an operation may be redone
        /// </summary>
        /// <returns></returns>
        bool CanRedo();

        /// <summary>
        /// The user-readable name of this operation
        /// </summary>
        string Name { get; }
    }
}
