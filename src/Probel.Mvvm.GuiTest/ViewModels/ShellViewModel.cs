namespace Probel.Mvvm.GuiTest.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using Models;

    using Toolkit.DataBinding;
    using Toolkit.Events;

    public class ShellViewModel : BaseViewModel, IEventHandler<StatusMessage>
    {
        #region Fields

        private Mail selectedMail;
        private string status;

        #endregion Fields

        #region Constructors

        public ShellViewModel()
        {
            this.Mails = new ObservableCollection<Mail>();
            this.LoadMailCommand = new RelayCommand(LoadMail);
            this.LoadLogsCommand = new RelayCommand(LoadLogs);
            this.ClearLogsCommand = new RelayCommand(ClearLogs);
            this.ShowModalCommand = new RelayCommand(ShowModal);

            this.EventAggregator.Subscribe(this);
        }

        #endregion Constructors

        #region Properties

        public ICommand ClearLogsCommand
        {
            get;
            private set;
        }

        public ICommand LoadLogsCommand
        {
            get;
            private set;
        }

        public ICommand LoadMailCommand
        {
            get;
            private set;
        }

        public ObservableCollection<Mail> Mails
        {
            get;
            private set;
        }

        public Mail SelectedMail
        {
            get { return this.selectedMail; }
            set
            {
                this.selectedMail = value;
                this.Messenger.PostFormat("Mail to {0} selected", value.To);
                this.EventAggregator.Publish(value);
                this.OnPropertyChanged(() => SelectedMail);
            }
        }

        public ICommand ShowModalCommand
        {
            get;
            private set;
        }

        public string Status
        {
            get { return this.status; }
            set
            {
                this.status = value;
                this.OnPropertyChanged(() => Status);
            }
        }

        #endregion Properties

        #region Methods

        public void HandleEvent(StatusMessage context)
        {
            this.Status = context.Message;
        }

        private void ClearLogs()
        {
            this.EventAggregator.Publish(EventAction.Clear("Clearing logs"));
        }

        private void LoadLogs()
        {
            this.EventAggregator.Publish(EventAction.Load("Loading logs"));
        }

        private void LoadMail()
        {
            Mails.Refill(new MailService().GetMails());
            this.Messenger.Post("Mails loaded!");
        }

        private void ShowModal()
        {
            this.EventAggregator.Publish(new StatusMessage("BEFORE opening the window..."));
            this.EventAggregator.Publish(EventAction.Open("Opening modal window"));
        }

        #endregion Methods
    }
}