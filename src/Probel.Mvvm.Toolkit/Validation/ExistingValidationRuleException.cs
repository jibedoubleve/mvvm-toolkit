namespace Probel.Mvvm.Toolkit.Validation
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// A validation rule has been set for this property
    /// </summary>
    [Serializable]
    public class ExistingValidationRuleException : Exception
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ExistingValidationRuleException"/> class.
        /// </summary>
        public ExistingValidationRuleException()
            : this("The validation rule for this property is already set")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExistingValidationRuleException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ExistingValidationRuleException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExistingValidationRuleException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public ExistingValidationRuleException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExistingValidationRuleException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="info"/> parameter is null. </exception>
        ///   
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"/> is zero (0). </exception>
        protected ExistingValidationRuleException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion Constructors
    }
}