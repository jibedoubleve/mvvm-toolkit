namespace Probel.Mvvm.UnitTest.DataBinding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Context
    {
        #region Constructors

        public Context(int integer, string message)
        {
            this.Integer = integer;
            this.Message = message;
        }

        #endregion Constructors

        #region Properties

        public int Integer
        {
            get; set;
        }

        public string Message
        {
            get; set;
        }

        #endregion Properties
    }
}