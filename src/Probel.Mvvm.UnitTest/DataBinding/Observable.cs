namespace Probel.Mvvm.UnitTest.DataBinding
{
    using Probel.Mvvm.Toolkit.DataBinding;

    public class Observable : ObservableObject
    {
        #region Fields

        private string property;

        #endregion Fields

        #region Properties

        public string Property
        {
            get { return this.property; }
            set
            {
                this.property = value;
                this.OnPropertyChanged(() => Property);
            }
        }

        #endregion Properties
    }
}