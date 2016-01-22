﻿namespace Probel.Mvvm.Toolkit.Validation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq.Expressions;

    using DataBinding;

    using Tools;

    /// <summary>
    /// Every objects that derive from this class will have the features to validates its properties
    /// and be used with WPF technology because it implements the IDataErrorInfo interface.
    /// </summary>
    [Serializable]
    public class ValidatableObject : ObservableObject, IDataErrorInfo
    {
        #region Fields

        /// <summary>
        /// Never use this variable directly
        /// </summary>
        [NonSerialized]
        private readonly Dictionary<string, ValidationRule> @__validationRules = new Dictionary<string, ValidationRule>();
        private readonly IValidator Validator;

        private bool validationSet = false;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidatableObject"/> class.
        /// </summary>
        /// <param name="validator">The validator in charge to validate the data of this instance.</param>
        public ValidatableObject(IValidator validator)
        {
            this.Validator = validator;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets an error message indicating what is wrong with this object.
        /// </summary>
        /// <value></value>
        /// <returns>An error message indicating what is wrong with this object. The default is an empty string ("").</returns>
        public string Error
        {
            get { return this.Validator.Error; }
        }

        private Dictionary<string, ValidationRule> ValidationRules
        {
            get
            {
                this.LazyValidationConfiguration();
                return this.@__validationRules;
            }
        }

        #endregion Properties

        #region Indexers

        /// <summary>
        /// Gets the error message for the property with the given name.
        /// </summary>
        /// <value>The name of the property whose error message to get.</value>
        /// <returns>The error message for the property. The default is an empty string ("").</returns>
        public string this[string columnName]
        {
            get
            {
                if (this.ValidationRules.ContainsKey(columnName))
                {
                    var rule = this.ValidationRules[columnName];

                    return (rule.CheckCondition())
                        ? null
                        : rule.Error;
                }
                else { return null; }
            }
        }

        #endregion Indexers

        #region Methods

        /// <summary>
        /// Adds a new valudation rule.
        /// The validation returns <c>True</c> when the property tested is valid; otherwise <c>False</c>
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="property">The property to validate.</param>
        /// <param name="validation">The validation condition. This returns <c>True</c> 
        /// if the property is valid; otherwise <c>False</c></param>
        /// <param name="error">The error to display if the property is not valid.</param>
        /// <exception cref="ExistingValidationRuleException">If a validation is already set for the specified property</exception>
        public void AddValidationRule<TProperty>(Expression<Func<TProperty>> property, Func<bool> validation, string error)
        {
            var key = property.GetMemberInfo().Name;

            if (this.ValidationRules.ContainsKey(key))
            {
                throw new ExistingValidationRuleException();
            }
            else
            {
                this.ValidationRules.Add(key, new ValidationRule(validation, error));
            }
        }

        /// <summary>
        /// Determines whether this item is valid. That's whether all condition returns <c>true</c>
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </returns>
        public bool IsValid()
        {
            foreach (var rule in this.ValidationRules.Values)
            {
                if (!rule.CheckCondition()) return false;
            }
            return true;
        }

        private void LazyValidationConfiguration()
        {
            if (!this.validationSet)
            {
                /* HACK: if you don't set ValidationSet now,
                 * then you'll go into an infinite loop and have a StackOverflow... */
                this.validationSet = true;
                this.Validator.SetValidationLogic(this);
            }
        }

        #endregion Methods
    }
}