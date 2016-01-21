namespace Probel.Mvvm.GuiTest.Models
{
    #region Enumerations

    public enum Actions
    {
        Load,
        Clear,
        Open,
    }

    #endregion Enumerations

    public class EventAction
    {
        #region Constructors

        private EventAction(Actions action, string message)
        {
            this.Message = message;
            this.Action = action;
        }

        #endregion Constructors

        #region Properties

        public Actions Action
        {
            get; set;
        }

        public string Message
        {
            get; set;
        }

        #endregion Properties

        #region Methods

        public static EventAction Clear(string message)
        {
            return new EventAction(Actions.Clear, message);
        }

        public static EventAction Load(string message)
        {
            return new EventAction(Actions.Load, message);
        }

        public static EventAction Open(string message)
        {
            return new EventAction(Actions.Open, message);
        }

        #endregion Methods
    }
}