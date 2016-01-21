namespace Probel.Mvvm.UnitTest.DataBinding
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using NUnit.Framework;

    using Probel.Mvvm.Toolkit.DataBinding;

    [TestFixture]
    public class Test_ObservableCollection
    {
        #region Fields

        private readonly IEnumerable<string> listWith2Elements = new List<string> { "a", "b" };
        private readonly IEnumerable<string> listWith3Elements = new List<string> { "1", "2", "3" };

        #endregion Fields

        #region Methods

        [Test]
        public void RefillCollection_DefaultScenario()
        {
            var col = new ObservableCollection<string>(listWith3Elements);
            Assert.That(col.Count, Is.EqualTo(3));

            col.Refill(listWith2Elements);
            Assert.That(col.Count, Is.EqualTo(2));
        }

        [Test]
        public void RefillCollection_WithNull_ErrorScenario()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var col = new ObservableCollection<string>(listWith3Elements);
                col.Refill(null);
            });
        }

        [Test]
        public void RefillNullCollection_ErrorScenario()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var col = new ObservableCollection<string>(null);
                col.Refill(listWith2Elements);
            });
        }

        #endregion Methods
    }
}