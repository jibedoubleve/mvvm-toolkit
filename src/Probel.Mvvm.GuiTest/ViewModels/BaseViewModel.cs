namespace Probel.Mvvm.GuiTest.ViewModels
{
    using Gui;
    using Gui.Messages;

    using Models;

    using Toolkit.DataBinding;
    using Toolkit.Events;

    public abstract class BaseViewModel : ObservableObject
    {
        #region Fields

        protected readonly Messenger Messenger = new Messenger();

        #endregion Fields

        #region Constructors

        public BaseViewModel()
        {
            this.EventAggregator = AppContext.EventAggregator;
            this.Notify = new WindowsMessageBox();
        }

        #endregion Constructors

        #region Properties

        protected EventAggregator EventAggregator
        {
            get; private set;
        }

        protected INotifyUser Notify
        {
            get; private set;
        }

        #endregion Properties
    }
}