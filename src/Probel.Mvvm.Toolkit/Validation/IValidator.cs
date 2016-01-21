namespace Probel.Mvvm.Toolkit.Validation
{
    /// <summary>
    /// Set all the validation rules to a <see cref="ValidatableObject"/>
    /// </summary>
    public interface IValidator
    {
        #region Properties

        /// <summary>
        /// Gets an error message indicating what is wrong with this object.
        /// </summary>
        /// <value></value>
        /// <returns>An error message indicating what is wrong with this object. The default is an empty string ("").</returns>
        string Error
        {
            get;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Sets the validation rules for the specified instance.
        /// </summary>
        /// <param name="item">The item.</param>
        void SetValidationLogic(ValidatableObject item);

        #endregion Methods
    }
}