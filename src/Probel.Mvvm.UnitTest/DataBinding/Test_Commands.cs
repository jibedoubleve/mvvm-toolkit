namespace Probel.Mvvm.UnitTest.DataBinding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using NUnit.Framework;

    using Probel.Mvvm.Toolkit.DataBinding;

    [TestFixture]
    public class Test_Commands
    {
        #region Methods

        [Test]
        public void WithArgs_Command_CtorWithNull_ErrorScenario()
        {
            Assert.Throws<ArgumentNullException>(() => new RelayCommand<Context>(null, null));
        }

        [Test]
        public void WithArgs_Helper_TryExecute_DefaultScenario()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var cmd = new RelayCommand(null, null);
                cmd.TryExecute("string");
            });
        }

        [Test]
        public void WithArg_Command_CanExecute_DefaultScenario()
        {
            var ctx = new Context(12, "hello");
            var cmd = new RelayCommand<Context>(c => c.Integer = 24);

            Assert.That(cmd.CanExecute(ctx), Is.True);
        }

        [Test]
        public void WithArg_Command_Execute_DefaultScenario()
        {
            var ctx = new Context(12, "hello");
            var cmd = new RelayCommand<Context>(c => c.Integer = 24);
            cmd.Execute(ctx);
            Assert.That(ctx.Integer, Is.EqualTo(24));
        }

        [Test]
        public void WithoutArgs_Helper_TryExecute_DefaultScenario()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var cmd = new RelayCommand(null, null);
                cmd.TryExecute();
            });
        }

        [Test]
        public void WithoutArg_Command_CanExecute_DefaultScenario()
        {
            var cmd = new RelayCommand(() => Console.WriteLine(), null);

            Assert.That(cmd.CanExecute(null), Is.True);
        }

        [Test]
        public void WithoutArg_Command_CtorWithNull_ErrorScenario()
        {
            Assert.Throws<ArgumentNullException>(() => new RelayCommand(null, null));
        }

        #endregion Methods
    }
}