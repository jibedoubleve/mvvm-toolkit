namespace Probel.Mvvm.UnitTest.Validation
{
    using System;

    using NUnit.Framework;

    using Toolkit.Validation;

    [TestFixture]
    public class Test_Validation
    {
        #region Methods

        [Test]
        public void ValidateObject_ManuallValidation_ValidationOnIsValid()
        {
            var user = new User("Robert"); //Validation doesn't allow names which starts with "R"

            var error = user.IsValid();

            Assert.IsFalse(error);
        }

        [Test]
        public void ValidateObject_ManuallValidation_ValidationWorks()
        {
            var user = new User("Robert"); //Validation doesn't allow names which starts with "R"

            var error = user["Name"];

            Assert.IsNotNull(error);
        }

        [Test]
        public void ValidateObject_OverrideRole_ExistingValidationRuleExceptionThrown()
        {
            var user = new User("Robert");
            var error = user["Name"];

            Assert.IsNotNull(error, "Default validation");

            Assert.Throws<ExistingValidationRuleException>(() =>
            {
                user.AddValidationRule(() => user.Name
                    , () => !user.Name.ToLower().StartsWith("a")
                    , "Oops");
            });
        }

        #endregion Methods
    }
}