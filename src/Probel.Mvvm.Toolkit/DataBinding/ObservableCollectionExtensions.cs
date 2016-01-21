namespace Probel.Mvvm.Toolkit.DataBinding
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Allow to refill, add items to an ObservableCollection
    /// </summary>
    public static class ObservableCollectionExtensions
    {
        #region Methods

        /// <summary>
        /// Adds specified collection into the ObservableCollection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="oCollection">The o collection.</param>
        /// <param name="collection">The collection.</param>
        public static void AddRange<T>(this ObservableCollection<T> oCollection, IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                oCollection.Add(item);
            }
        }

        /// <summary>
        /// Clears the ObservableCollection and refill it with the specified collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="oCollection">The o collection.</param>
        /// <param name="collection">The collection.</param>
        public static void Refill<T>(this ObservableCollection<T> oCollection, IEnumerable<T> collection)
        {
            if (oCollection == null) throw new ArgumentNullException("oCollection");
            if (collection == null) throw new ArgumentNullException("collection");

            oCollection.Clear();
            oCollection.AddRange(collection);
        }

        #endregion Methods
    }
}