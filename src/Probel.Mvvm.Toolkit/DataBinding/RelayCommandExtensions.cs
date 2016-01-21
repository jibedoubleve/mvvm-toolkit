namespace Probel.Mvvm.Toolkit.DataBinding
{
    using System.Windows.Input;

    public static class RelayCommandExtensions
    {
        #region Methods

        public static bool TryExecute(this ICommand command)
        {
            if (command.CanExecute(null))
            {
                command.Execute(null);
                return true;
            }
            else { return false; }
        }

        public static bool TryExecute<TContext>(this ICommand command, TContext context)
        {
            if (command.CanExecute(context))
            {
                command.Execute(context);
                return true;
            }
            else { return false; }
        }

        #endregion Methods
    }
}