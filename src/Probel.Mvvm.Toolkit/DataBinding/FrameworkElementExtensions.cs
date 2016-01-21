namespace Probel.Mvvm.Toolkit.DataBinding
{
    using System;
    using System.Windows;

    /// <summary>
    /// Add extension methods to manage the Views and the ViewModels
    /// </summary>
    public static class FrameworkElementExtensions
    {
        #region Methods

        /// <summary>
        /// Returns the ViewModel as it is configured in the specified View
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="view">The view.</param>
        /// <returns>The specified ViewModel</returns>
        /// <exception cref="NullReferenceException">Thrown of the DataContext of the specified view is not set</exception>
        /// <exception cref="InvalidCastException">Thrown if the type of the DataContext of the view is not of the expected type</exception>
        public static TViewModel GetViewModel<TViewModel>(this FrameworkElement view)
            where TViewModel : class
        {
            if (view.DataContext == null) { throw new NullReferenceException("The specified DataContext is null"); }
            else
            {
                try { return (TViewModel)view.DataContext; }
                catch (InvalidCastException ex)
                {
                    var msg = string.Format("The DataContext  type should be '{0}' but it is '{1}'", typeof(TViewModel), view.DataContext.GetType());
                    throw new InvalidCastException(msg, ex); ;
                }
                catch { throw; }
            }
        }

        #endregion Methods
    }
}