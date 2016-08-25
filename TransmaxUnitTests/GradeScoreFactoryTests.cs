using System;

using NUnit.Framework;

using TransmaxTestApp;

namespace TransmaxUnitTests
{
    [TestFixture]
    public class GradeScoreFactoryTests
    {
        [Test]
        [TestCase(int.MinValue)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(int.MaxValue)]
        public void CreateShouldPass(int score)
        {
            GradeScoreFactory factory = new GradeScoreFactory();
            string line = $"first name, last name, {score}";
            GradeScore gradeScore = factory.Create(line, 1);
            Assert.That(gradeScore.FirstName, Is.EqualTo("first name"));
            Assert.That(gradeScore.LastName, Is.EqualTo("last name"));
            Assert.That(gradeScore.Score, Is.EqualTo(score));
        }

        [Test]
        public void CreateShouldThrowWhenLineIsNull()
        {
            GradeScoreFactory factory = new GradeScoreFactory();
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => factory.Create(null, 1));
            Assert.That(ex.Message, Does.Contain("line 1 is not a valid score. It cannot be null."));
        }

        [Test]
        [TestCase("one")]
        [TestCase("one, two")]
        [TestCase("one, two, three, four")]
        public void CreateShouldThrowWhenLineHasBadPartsCount(string line)
        {
            GradeScoreFactory factory = new GradeScoreFactory();
            ArgumentException ex = Assert.Throws<ArgumentException>(() => factory.Create(line, 1));
            Assert.That(ex.Message, Does.Contain("line 1 is not a valid score. It must have the format \"First Name, Last Name, Score\"."));
        }

        [Test]
        [TestCase(", last name, 123")]
        [TestCase(" , last name, 123")]
        [TestCase("\t, last name, 123")]
        public void ConstructorShouldThrowWhenFirstNameIsEmptyOrWhiteSpace(string line)
        {
            GradeScoreFactory factory = new GradeScoreFactory();
            ArgumentException ex = Assert.Throws<ArgumentException>(() => factory.Create(line, 1));
            Assert.That(ex.Message, Does.Contain("firstName is not a valid value on line 1. It must be a string and cannot be empty."));
        }

        [Test]
        [TestCase("first name,, 123")]
        [TestCase("first name, , 123")]
        [TestCase("first name,\t, 123")]
        public void ConstructorShouldThrowWhenLastNameIsEmptyOrWhiteSpace(string line)
        {
            GradeScoreFactory factory = new GradeScoreFactory();
            ArgumentException ex = Assert.Throws<ArgumentException>(() => factory.Create(line, 1));
            Assert.That(ex.Message, Does.Contain("lastName is not a valid value on line 1. It must be a string and cannot be empty."));
        }

        [Test]
        [TestCase("first name, last name,")]
        [TestCase("first name, last name, score")]
        [TestCase("first name, last name, 12.34")]
        public void ConstructorShouldThrowWhenScoreIsNotAnInteger(string line)
        {
            GradeScoreFactory factory = new GradeScoreFactory();
            ArgumentException ex = Assert.Throws<ArgumentException>(() => factory.Create(line, 1));
            Assert.That(ex.Message, Does.Contain("score is not a valid value on line 1. It must be an integer."));
        }
    }
}
