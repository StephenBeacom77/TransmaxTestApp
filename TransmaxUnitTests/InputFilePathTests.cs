using System;

using NUnit.Framework;

using TransmaxTestApp;

namespace TransmaxUnitTests
{
    [TestFixture]
    public class InputFilePathTests
    {
        [Test]
        public void ConstructorShouldPass()
        {
            string[] args = new string[] { "c:\temp\file.txt" };
            InputFilePath path = new InputFilePath(args);
            Assert.That(path.Value, Is.EqualTo(args[0]));
        }

        [Test]
        public void ConstructorShouldThrowWhenArgumentCountIsLessThanOne()
        {
            string[] args = new string[] { };
            ArgumentException ex = Assert.Throws<ArgumentException>(() => new InputFilePath(args));
            Assert.That(ex.Message, Does.Contain("Only 1 argument is required to specify the input file but 0 arguments have been specified."));
        }

        [Test]
        public void ConstructorShouldThrowWhenArgumentCountIsMoreThanOne()
        {
            string[] args = new string[] { "1", "2" };
            ArgumentException ex = Assert.Throws<ArgumentException>(() => new InputFilePath(args));
            Assert.That(ex.Message, Does.Contain("Only 1 argument is required to specify the input file but 2 arguments have been specified."));
        }
    }
}
