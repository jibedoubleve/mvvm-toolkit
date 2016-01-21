namespace Probel.Mvvm.UnitTest.Events
{
    using Probel.Mvvm.Toolkit.Events;

    class EventSource
    {
        #region Constructors

        public EventSource(EventAggregator aggregator)
        {
            this.Aggregator = aggregator;
        }

        #endregion Constructors

        #region Properties

        public EventAggregator Aggregator
        {
            get; private set;
        }

        #endregion Properties

        #region Methods

        public void Publish(string message)
        {
            Aggregator.Publish(message);
        }

        #endregion Methods
    }
}