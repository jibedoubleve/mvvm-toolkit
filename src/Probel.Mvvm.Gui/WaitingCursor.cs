﻿namespace Probel.Mvvm.Gui
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// During the life time of this object, the mouse is showing the sandglass.
    /// As soon as this object is disposed, the mouse arrow is back to indicate
    /// the work is done.
    /// </summary>
    public class WaitingCursor : IDisposable
    {
        #region Constructors

        private WaitingCursor()
        {
            Mouse.OverrideCursor = Cursors.Wait;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// During the lifetime of this object, a waiting cursor is shown
        /// </summary>
        public static WaitingCursor While
        {
            get { return new WaitingCursor(); }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Reset the cursor to the prinstine state
        /// </summary>
        public void Dispose()
        {
            Mouse.OverrideCursor = null;
        }

        #endregion Methods
    }
}