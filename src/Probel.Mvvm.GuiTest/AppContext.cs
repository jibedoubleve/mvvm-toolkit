namespace Probel.Mvvm.GuiTest
{
    using Probel.Mvvm.Toolkit.Events;

    public static class AppContext
    {
        #region Fields

        public static readonly EventAggregator EventAggregator = new EventAggregator();

        #endregion Fields
    }
}