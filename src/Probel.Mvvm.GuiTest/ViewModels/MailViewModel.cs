namespace Probel.Mvvm.GuiTest.ViewModels
{
    using System.Windows.Input;

    using Models;

    using Toolkit.DataBinding;
    using Toolkit.Events;

    public class MailViewModel : BaseViewModel, IEventHandler<Mail>
    {
        #region Fields

        private int id;
        private string message;
        private string to;

        #endregion Fields

        #region Constructors

        public MailViewModel()
        {
            this.EventAggregator.Subscribe(this);
            this.UpdateCommand = new RelayCommand(Update, CanUpdate);
        }

        #endregion Constructors

        #region Properties

        public int Id
        {
            get { return this.id; }
            set
            {
                this.id = value;
                this.OnPropertyChanged(() => Id);
            }
        }

        public string Message
        {
            get { return this.message; }
            set
            {
                this.message = value;
                this.OnPropertyChanged(() => Message);
            }
        }

        public string To
        {
            get { return this.to; }
            set
            {
                this.to = value;
                this.OnPropertyChanged(() => To);
            }
        }

        public ICommand UpdateCommand
        {
            get;
            private set;
        }

        #endregion Properties

        #region Methods

        public void HandleEvent(Mail context)
        {
            this.Id = context.Id;
            this.Message = context.Message;
            this.To = context.To;
        }

        private bool CanUpdate()
        {
            return !string.IsNullOrEmpty(this.Message);
        }

        private void Update()
        {
            if (this.Notify.QuestionFormat("Do you want {0}", "to save this mail?"))
            {
                var service = new MailService();
                service.UpdateMail(Id, Message);
                this.Messenger.Post("Mail upated!");
            }
        }

        #endregion Methods
    }
}