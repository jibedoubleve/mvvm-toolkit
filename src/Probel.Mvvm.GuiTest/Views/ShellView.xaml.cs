namespace Probel.Mvvm.GuiTest.Views
{
    using System.Windows;

    using Models;

    using Toolkit.Events;

    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window, IEventHandler<EventAction>
    {
        #region Constructors

        public ShellView()
        {
            InitializeComponent();
            AppContext.EventAggregator.Subscribe(this);
        }

        #endregion Constructors

        #region Methods

        public void HandleEvent(EventAction context)
        {
            if (context.Action == Actions.Open)
            {
                var window = new ModalView();
                window.Owner = this;
                window.ShowDialog();
                AppContext.EventAggregator.Publish(new StatusMessage("AFTER opening the window..."));
            }
        }

        #endregion Methods
    }
}