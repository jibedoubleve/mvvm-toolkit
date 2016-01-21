namespace Probel.Mvvm.GuiTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StatusMessage
    {
        #region Constructors

        public StatusMessage(string message)
        {
            Message = message;
        }

        #endregion Constructors

        #region Properties

        public string Message
        {
            get; set;
        }

        #endregion Properties
    }
}