using System;

using NUnit.Framework;

using TransmaxTestApp;

namespace TransmaxUnitTests
{
    [TestFixture]
    public class OutputFilePathTests
    {
        [Test]
        [TestCase(@"c:\temp\file.txt", @"c:\temp\file-graded.txt")]
        [TestCase(@"c:\temp\file.bat", @"c:\temp\file-graded.bat")]
        [TestCase(@"d:\temp\file.txt", @"d:\temp\file-graded.txt")]
        [TestCase(@"c:\temp\file-graded.txt", @"c:\temp\file-graded-graded.txt")]
        public void ConstructorShouldPass(string inputFilePath, string outputFilePath)
        {
            OutputFilePath path = new OutputFilePath(inputFilePath);
            Assert.That(path.Value, Is.EqualTo(outputFilePath));
        }
    }
}
