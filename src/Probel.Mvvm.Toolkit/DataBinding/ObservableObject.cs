namespace Probel.Mvvm.Toolkit.DataBinding
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq.Expressions;

    using Tools;

    /// <summary>
    /// Basic implementation of <see cref="INotifyPropertyChanged"/>
    /// </summary>
    public class ObservableObject : INotifyPropertyChanged
    {
        #region Events

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public virtual event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Methods

        /// <summary>
        /// Notify the property was changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.VerifyPropertyName(propertyName);
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Notifies subscribers of the property change.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="property">The property expression.</param>
        protected void OnPropertyChanged<TProperty>(Expression<Func<TProperty>> property)
        {
            this.OnPropertyChanged(property.GetMemberInfo().Name);
        }

        /// <summary>
        /// Warns the developer if this object does not have a public property with
        /// the specified name. This method does not exist in a Release build.
        /// </summary>
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        private void VerifyPropertyName(string propertyName)
        {
            // verify that the property name matches a real,
            // public, instance property on this object.
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                throw new InvalidOperationException(string.Format("Invalid property name \"{0}\" before triggering 'PropertyChanged' event.", propertyName));
            }
        }

        #endregion Methods
    }
}