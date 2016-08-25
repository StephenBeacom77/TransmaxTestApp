using System;

using NUnit.Framework;

using TransmaxTestApp;

namespace TransmaxUnitTests
{
    [TestFixture]
    public class GradeScoreTests
    {
        [Test]
        [TestCase(int.MinValue)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(int.MaxValue)]
        public void ConstructorShouldPass(int score)
        {
            GradeScore gradeScore = new GradeScore("first name", "last name", 123, 1);
            Assert.That(gradeScore.FirstName, Is.EqualTo("first name"));
            Assert.That(gradeScore.LastName, Is.EqualTo("last name"));
            Assert.That(gradeScore.Score, Is.EqualTo(123));
        }

        [Test]
        public void ConstructorShouldThrowWhenFirstNameIsNull()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => new GradeScore(null, "test", 123, 456));
            Assert.That(ex.Message, Does.Contain("firstName"));
            Assert.That(ex.Message, Does.Contain("line 456"));
        }

        [Test]
        public void ConstructorShouldThrowWhenLastNameIsNull()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => new GradeScore("test", null, 123, 456));
            Assert.That(ex.Message, Does.Contain("lastName"));
            Assert.That(ex.Message, Does.Contain("line 456"));
        }
    }
}
