namespace Probel.Mvvm.GuiTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Messenger
    {
        #region Methods

        public void Post(string message)
        {
            AppContext.EventAggregator.Publish(new StatusMessage(message));
        }

        public void PostFormat(string format, string to)
        {
            this.Post(string.Format(format, to));
        }

        #endregion Methods
    }
}