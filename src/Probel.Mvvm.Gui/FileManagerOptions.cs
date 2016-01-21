namespace Probel.Mvvm.Gui
{
    /// <summary>
    /// Options to configure a FileService item
    /// </summary>
    public class FileManagerOptions
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FileManagerOptions"/> class.
        /// </summary>
        public FileManagerOptions()
        {
            this.Multiselect = false;
            this.Filter = null;
            this.InitialDirectory = null;
            this.Title = null;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the default options.
        /// </summary>
        public static FileManagerOptions Default
        {
            get { return new FileManagerOptions(); }
        }

        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public string Filter
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the initial directory.
        /// </summary>
        /// <value>
        /// The initial directory.
        /// </value>
        public string InitialDirectory
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether multiple file can be selected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if multiselect; otherwise, <c>false</c>.
        /// </value>
        public bool Multiselect
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title
        {
            get;
            set;
        }

        #endregion Properties
    }
}