# mvvm-toolkit

These two libraries provides a lightweight toolbox to manage MVVM pattern and help a few to work with the views

## MVVM toolkit
### Converters
It contains some converters that implements `System.Windows.Data.IValueConverter`
 - `BoolToVisibilityConverter`: if the value is `true` `Visibility.Visible` is return; otherwise `Visibility.Collapsed`
 - `InvertBoolConverter`: if the value is `true` return `false`; otherwise returns `true`
 - `StringToVisibilityConverter`: is `string` is null or empty returns `Visibility.Collapsed`; otherwise returns `Visibility.Visible`
 
### Databinding
 - Provides simple implementations of `System.Windows.Input.ICommand`
 - Provides basic implementation of `System.ComponentModel.INotifyPropertyChanged`
 - `ObservableCollectionExtensions` provides some helpers to clear or refill an `System.Collections.ObjectModel.ObservableCollection<T>`
 - `FrameworkElementExtensions` provides some helpers to retreive the ViewModel from a View (that should be a `System.Windows.FrameworkElement`
 
### Event aggregator
All the class that implements `IEventHandler<TEventContext>` can handle events provied to the `EventAggregator`

Here's a sample:

*The source of the event (the class in charge of triggering the events*

    class EventSource
    {
        public EventSource(EventAggregator aggregator)
        {
            this.Aggregator = aggregator;
        }
        public EventAggregator Aggregator
        {
            get; private set;
        }
        public void Publish(string message)
        {
            Aggregator.Publish(message);
        }
    }
*The class that handles the events triggered:*

    class EventHandler : IEventHandler<string>
    {
        public EventHandler(EventAggregator aggregator)
        {
            aggregator.Subscribe(this);
        }
        public string Value
        {
            get; private set;
        }
        public void HandleEvent(string context)
        {
            this.Value = context;
        }
    }
### Validation
 Gives an implementation of `IDataErrorInfo`
 
 First of all, define your model and specify `ValidatableObject` as a base object (Which derives from ObservableObject that implements INPC.
 
 Next, specify in the constructor an implementation if `IValidator` that is in charge of the validation
 
     public class User : ValidatableObject
    {
        private DateTime birthdate;
        private string name;
        
        public User()
            : base(new UserValidator())
        {
        }

        public DateTime Birthdate
        {
            get { return this.birthdate; }
            set
            {
                this.birthdate = value;
                this.OnPropertyChanged(() => this.Birthdate);
            }
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                this.OnPropertyChanged(() => this.Name);
            }
        }
    }
    
Here's an example of an implementation of `IValidator` for `User`
    
    public class UserValidator : IValidator
    {
        public string Error
        {
            get { return "This instance is in error state"; }
        }
        public void SetValidationLogic(ValidatableObject item)
        {
            var user = item as User;
            user.AddValidationRule(() => user.Name
                , () => !user.Name.ToLower().StartsWith("r")
                , "This name starts with 'r', it is bad");
        }
    }
## GUI toolkit
This library offers some wrapper to manage files and messgaes boxes. All these features are wrapped into `Interfaces`
### File management
This interface has one implementation (`Win32FileGui`) using `System.Windows.FormsFolderBrowserDialog` and `System.Windows.FormsOpenFileDialog`:

    public interface IFileManager
    {
        bool? SelectDirectory(Action<string> action);
        
        bool? SelectFile(Action<string> action);
        
        bool? SelectFile(Action<string> action, FileManagerOptions options);
        
        bool? SelectFileToSave(Action<string> action, FileManagerOptions options);
        
        bool? SelectFileToSave(Action<string> action);
    }
### Message boxes
This interface has one implementation (`WindowsMessageBox`) using `System.Windows.MessageBox`

    public interface INotifyUser
    {
        void Asterisk(object message);
        
        void AsteriskFormat(string message, params object[] args);
        
        bool? CancelableQuestion(object message);
        
        bool? CancelableQuestionFormat(string message, params object[] args);
        
        void Error(object message);
        
        void ErrorFormat(string message, params object[] args);
        
        void Exclamation(object message);
        
        void ExclamationFormat(string message, params object[] args);
        
        void Hand(object message);
        
        void HandFormat(string message, params object[] args);
        
        void Information(object message);
        
        void InformationFormat(string message, params object[] args);
        
        void None(object message, string title);
        
        bool Question(object message);
        
        bool QuestionFormat(string message, params object[] args);
        
        void Stop(object message);
        
        void StopFormat(string message, params object[] args);
        
        void Warning(object message);
        
        void WarningFormat(string message, params object[] args);
    }
