namespace Probel.Mvvm.UnitTest.DataBinding
{
    using NUnit.Framework;

    [TestFixture]
    public class Test_ObservableObject
    {
        #region Fields

        private const string MEMBER_NAME = "Property";

        #endregion Fields

        #region Methods

        [Test]
        public void ChangeProperty_DefaultScenario()
        {
            var o = new Observable();
            var triggered = false;
            o.PropertyChanged += (sender, e) =>
            {
                Assert.That(e.PropertyName, Is.EqualTo(MEMBER_NAME));
                triggered = true;
            };

            o.Property = "some test";

            Assert.That(triggered, Is.True);
        }

        #endregion Methods
    }
}