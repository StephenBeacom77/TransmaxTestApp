// <copyright file="GradeScoreTest.cs">Copyright ©  2016</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TransmaxTestApp;

namespace TransmaxTestApp.Tests
{
    /// <summary>This class contains parameterized unit tests for GradeScore</summary>
    [PexClass(typeof(GradeScore))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class GradeScoreTest
    {
        /// <summary>Test stub for .ctor(String, String, Int32, Int32)</summary>
        [PexMethod]
        public GradeScore ConstructorTest(
            string firstName,
            string lastName,
            int score,
            int index
        )
        {
            GradeScore target = new GradeScore(firstName, lastName, score, index);
            return target;
            // TODO: add assertions to method GradeScoreTest.ConstructorTest(String, String, Int32, Int32)
        }
    }
}
