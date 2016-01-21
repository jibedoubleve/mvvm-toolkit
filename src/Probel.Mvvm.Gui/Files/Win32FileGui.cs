namespace Probel.Mvvm.Gui.Files
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Implements the FileService with Microsoft.Win32 
    /// </summary>
    public class Win32FileGui : IFileManager
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Win32FileGui"/> class.
        /// </summary>
        internal Win32FileGui()
        {
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Selects the directory.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns><c>True</c> if the user clicked on 'OK'; otherwise <c>False</c></returns>
        public bool? SelectDirectory(Action<string> action)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            var dr = folderBrowserDialog.ShowDialog();

            if (dr == DialogResult.OK)
            {
                action(folderBrowserDialog.SelectedPath);
            }
            return (dr == DialogResult.OK);
        }

        /// <summary>
        /// Selects the file.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns><c>True</c> if the user clicked on 'OK'; otherwise <c>False</c></returns>
        public bool? SelectFile(Action<string> action)
        {
            return this.SelectFile(action, FileManagerOptions.Default);
        }

        /// <summary>
        /// Selects the file.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="options">The options.</param>
        /// <returns><c>True</c> if the user clicked on 'OK'; otherwise <c>False</c></returns>
        public bool? SelectFile(Action<string> action, FileManagerOptions options)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = options.Filter;
            openFileDialog.Multiselect = options.Multiselect;
            openFileDialog.InitialDirectory = options.InitialDirectory;
            openFileDialog.Title = options.Title;

            bool? flag = openFileDialog.ShowDialog();

            if (flag.HasValue && flag.Value)
            {
                action(openFileDialog.FileName);
            }
            return flag;
        }

        /// <summary>
        /// Selects the file where to save the data.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <returns><c>True</c> if the user clicked on 'OK'; otherwise <c>False</c></returns>
        public bool? SelectFileToSave(Action<string> action)
        {
            return this.SelectFileToSave(action, FileManagerOptions.Default);
        }

        /// <summary>
        /// Selects the file where to save the data.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <param name="options">The options.</param>
        /// <returns><c>True</c> if the user clicked on 'OK'; otherwise <c>False</c></returns>
        public bool? SelectFileToSave(Action<string> action, FileManagerOptions options)
        {
            var saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = options.Filter;
            saveFileDialog.InitialDirectory = options.InitialDirectory;
            saveFileDialog.Title = options.Title;

            bool? flag = saveFileDialog.ShowDialog();
            if (flag.HasValue && flag.Value)
            {
                action(saveFileDialog.FileName);
            }
            return flag;
        }

        #endregion Methods
    }
}