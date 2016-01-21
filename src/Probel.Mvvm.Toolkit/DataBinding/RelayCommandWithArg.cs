namespace Probel.Mvvm.Toolkit.DataBinding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    public class RelayCommand<TContext> : ICommand
    {
        #region Fields

        /// <summary>
        /// Null to indicate the command is empty
        /// </summary>
        public static readonly ICommand Empty = null;

        private readonly Func<TContext, bool> canExecute;
        private readonly Action<TContext> execute;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the RelayCommand class
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        public RelayCommand(Action<TContext> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the RelayCommand class
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<TContext> execute, Func<TContext, bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            this.execute = execute;
            this.canExecute = canExecute;
        }

        #endregion Constructors

        #region Events

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (this.canExecute != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (this.canExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }

        #endregion Events

        #region Methods

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            if (this.canExecute == null) { return true; }
            else
            {
                if (parameter is TContext)
                {
                    return this.canExecute((TContext)parameter);
                }
                else { throw new ArgumentException("This parameter is not of the expected type", "parameter"); }
            }
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
            if (parameter is TContext)
            {
                this.execute((TContext)parameter);
            }
            else { throw new ArgumentException("This parameter is not of the expected type", "parameter"); }
        }

        #endregion Methods
    }
}