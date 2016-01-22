﻿namespace Probel.Mvvm.Toolkit.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// Convert a boolean to visibility. If <c>True</c> return Visibility.Visible otherwise Visibility.Collapsed
    /// </summary>
    /// <seealso cref="System.Windows.Data.IValueConverter" />
    public class BoolToVisibilityConverter : IValueConverter
    {
        #region Methods

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <exception cref="System.NotSupportedException">Convertion to visibility impossible</exception>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool)
            {
                var isVisible = (bool)value;

                return (isVisible)
                    ? Visibility.Visible
                    : Visibility.Collapsed;
            }
            else { throw new NotSupportedException("Convertion to visibility impossible"); }
        }

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <exception cref="System.NotSupportedException">Convertion to bool impossible</exception>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Visibility)
            {
                var vis = (Visibility)value;

                return (Visibility.Visible);
            }
            else { throw new NotSupportedException("Convertion to bool impossible"); }
        }

        #endregion Methods
    }
}