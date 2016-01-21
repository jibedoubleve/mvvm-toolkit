namespace Probel.Mvvm.Gui
{
    using System;

    /// <summary>
    /// Provides an generic way to select file or directories
    /// </summary>
    public interface IFileManager
    {
        #region Methods

        /// <summary>
        /// Selects the directory.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns><c>True</c> if the user clicked on 'OK'; otherwise <c>False</c></returns>
        bool? SelectDirectory(Action<string> action);

        /// <summary>
        /// Selects the file.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns><c>True</c> if the user clicked on 'OK'; otherwise <c>False</c></returns>
        bool? SelectFile(Action<string> action);

        /// <summary>
        /// Selects the file.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="options">The options.</param>
        /// <returns><c>True</c> if the user clicked on 'OK'; otherwise <c>False</c></returns>
        bool? SelectFile(Action<string> action, FileManagerOptions options);

        /// <summary>
        /// Selects the directory.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="options">The options.</param>
        /// <returns><c>True</c> if the user clicked on 'OK'; otherwise <c>False</c></returns>
        bool? SelectFileToSave(Action<string> action, FileManagerOptions options);

        /// <summary>
        /// Selects the file where to save the data.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns><c>True</c> if the user clicked on 'OK'; otherwise <c>False</c></returns>
        bool? SelectFileToSave(Action<string> action);

        #endregion Methods
    }
}