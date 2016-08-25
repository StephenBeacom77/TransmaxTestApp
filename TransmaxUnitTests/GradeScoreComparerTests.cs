using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using TransmaxTestApp;

namespace TransmaxUnitTests
{
    [TestFixture]
    public class GradeScoreComparerTests
    {
        [Test]
        public void ComparerShouldSortNullsToEnd()
        {
            GradeScore s1 = null;
            GradeScore s2 = new GradeScore("first name", "last name", 456, 2);
            GradeScore s3 = null;

            List<GradeScore> scores = new List<GradeScore> { s1, s2, s3 };
            scores.Sort(new GradeScoreComparer());
            Assert.That(scores[0], Is.EqualTo(s2));
            Assert.That(scores[1], Is.EqualTo(s1));
            Assert.That(scores[2], Is.EqualTo(s3));
        }

        [Test]
        public void ComparerShouldSortByScoreWhenDifferent()
        {
            GradeScore s1 = new GradeScore("first name", "last name", 123, 1);
            GradeScore s2 = new GradeScore("first name", "last name", 456, 2);
            GradeScore s3 = new GradeScore("first name", "last name", 789, 3);

            List<GradeScore> scores = new List<GradeScore> { s1, s2, s3 };
            scores.Sort(new GradeScoreComparer());
            Assert.That(scores[0], Is.EqualTo(s3));
            Assert.That(scores[1], Is.EqualTo(s2));
            Assert.That(scores[2], Is.EqualTo(s1));
        }

        [Test]
        public void ComparerShouldSortByLastNameWhenScoresAreEqual()
        {
            GradeScore s1 = new GradeScore("first name", "last name 3", 123, 1);
            GradeScore s2 = new GradeScore("first name", "last name 2", 123, 2);
            GradeScore s3 = new GradeScore("first name", "last name 1", 123, 3);

            List<GradeScore> scores = new List<GradeScore> { s1, s2, s3 };
            scores.Sort(new GradeScoreComparer());
            Assert.That(scores[0], Is.EqualTo(s3));
            Assert.That(scores[1], Is.EqualTo(s2));
            Assert.That(scores[2], Is.EqualTo(s1));
        }

        [Test]
        public void ComparerShouldSortByFirstNameWhenLastNamesAndScoresAreEqual()
        {
            GradeScore s1 = new GradeScore("first name 3", "last name", 123, 1);
            GradeScore s2 = new GradeScore("first name 2", "last name", 123, 2);
            GradeScore s3 = new GradeScore("first name 1", "last name", 123, 3);

            List<GradeScore> scores = new List<GradeScore> { s1, s2, s3 };
            scores.Sort(new GradeScoreComparer());
            Assert.That(scores[0], Is.EqualTo(s3));
            Assert.That(scores[1], Is.EqualTo(s2));
            Assert.That(scores[2], Is.EqualTo(s1));
        }

    }
}
