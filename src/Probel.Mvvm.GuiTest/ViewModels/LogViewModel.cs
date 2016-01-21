namespace Probel.Mvvm.GuiTest.ViewModels
{
    using System;

    using Probel.Mvvm.GuiTest.Models;
    using Probel.Mvvm.Toolkit.Events;

    public class LogViewModel : BaseViewModel, IEventHandler<EventAction>
    {
        #region Fields

        private string logs;

        #endregion Fields

        #region Constructors

        public LogViewModel()
        {
            this.EventAggregator.Subscribe(this);
        }

        #endregion Constructors

        #region Properties

        public string Logs
        {
            get { return this.logs; }
            set
            {
                this.logs = value;
                this.OnPropertyChanged(() => Logs);
            }
        }

        #endregion Properties

        #region Methods

        public void HandleEvent(EventAction context)
        {
            switch (context.Action)
            {
                case Actions.Load:
                    this.LoadLogs(context.Message);
                    break;
                case Actions.Clear:
                    this.ClearLogs(context.Message);
                    break;
                default:
                    //Do nothing
                    break;
            }
        }

        private void ClearLogs(string message)
        {
            this.EventAggregator.Publish(new StatusMessage(message));
            this.Logs = string.Empty;
        }

        private void LoadLogs(string message)
        {
            this.EventAggregator.Publish(new StatusMessage(message));

            for (int i = 0; i < 120; i++)
            {
                this.Logs += Guid.NewGuid().ToString();
                this.Logs += Environment.NewLine;
            }
        }

        #endregion Methods
    }
}