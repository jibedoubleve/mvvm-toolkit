namespace Probel.Mvvm.GuiTest.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Mail
    {
        #region Fields

        static int IdCounter = 0;

        #endregion Fields

        #region Constructors

        public Mail(string to, string message)
        {
            this.Id = ++IdCounter;
            this.To = to;
            this.Message = message;
        }

        #endregion Constructors

        #region Properties

        public int Id
        {
            get; set;
        }

        public string Message
        {
            get; set;
        }

        public string To
        {
            get; set;
        }

        #endregion Properties
    }
}