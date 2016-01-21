namespace Probel.Mvvm.UnitTest.Events
{
    using System.Threading;
    using System.Threading.Tasks;

    using NUnit.Framework;

    using Toolkit.Events;

    [TestFixture]
    public class Test_Events
    {
        #region Fields

        private const string MESSAGE = "Message";

        #endregion Fields

        #region Methods

        [Test]
        public void TriggerAndFire_CanHandleMessage_DefaultScenario()
        {
            var ea = new EventAggregator();
            var source = new EventSource(ea);
            var handler = new EventHandler(ea);

            source.Publish(MESSAGE);

            Thread.Sleep(20);

            Assert.That(handler.Value, Is.EqualTo(MESSAGE));
        }

        [Test]
        public void TriggerAndFire_CanHaveMultipleListeners_DefaultScenario()
        {
            var ea = new EventAggregator();
            var source = new EventSource(ea);
            var handler1 = new EventHandler(ea);
            var handler2 = new EventHandler(ea);
            var handler3 = new EventHandler(ea);

            source.Publish(MESSAGE);

            Thread.Sleep(20);

            Assert.That(handler3.Value, Is.EqualTo(MESSAGE), "Handler3 didn't receive the message");
            Assert.That(handler1.Value, Is.EqualTo(MESSAGE), "Handler1 didn't receive the message");
            Assert.That(handler2.Value, Is.EqualTo(MESSAGE), "Handler2 didn't receive the message");
        }

        #endregion Methods
    }
}