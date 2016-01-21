namespace Probel.Mvvm.UnitTest.Events
{
    using Probel.Mvvm.Toolkit.Events;

    class EventHandler : IEventHandler<string>
    {
        #region Constructors

        public EventHandler(EventAggregator aggregator)
        {
            aggregator.Subscribe(this);
        }

        #endregion Constructors

        #region Properties

        public string Value
        {
            get; private set;
        }

        #endregion Properties

        #region Methods

        public void HandleEvent(string context)
        {
            this.Value = context;
        }

        #endregion Methods
    }
}