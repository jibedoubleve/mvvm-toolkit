﻿namespace Probel.Mvvm.UnitTest.Validation
{
    using System;

    using Toolkit.Validation;

    public class User : ValidatableObject
    {
        #region Fields

        private DateTime birthdate;
        private string name;

        #endregion Fields

        #region Constructors

        public User(string name)
            : this()
        {
            this.Name = name;
        }

        public User()
            : base(new UserValidator())
        {
        }

        #endregion Constructors

        #region Properties

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

        #endregion Properties
    }
}