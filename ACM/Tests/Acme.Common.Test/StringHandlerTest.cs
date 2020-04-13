using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acme.Common.Test
{
    [TestClass]
    public class StringHandlerTest
    {
        #region public test methods
        [TestMethod]
        public void InsertSpacesTestValid()
        {
            // arrange
            var source = "SonicScrewdriver";
            var expected = "Sonic Screwdriver";
            // act
            var result = source.InsertSpaces();
            // assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void InsertSpacesTestWithExistingSpace()
        {
            // arrange
            var source = "Sonic  Screwdriver";
            var expected = "Sonic Screwdriver";
            // act
            var result = source.InsertSpaces();
            // assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void InsertSpacesTestWithEmptyString()
        {
            // arrange
            var source = string.Empty;
            var expected = string.Empty;
            // act
            var result = source.InsertSpaces();
            // assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void InsertSpacesTestWithNullValue()
        {
            // arrange
            string source = null;
            string expected = string.Empty;
            // act
            var result = source.InsertSpaces();
            // assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void InsertSpacesTestAWhiteSpace()
        {
            // arrange
            var source = " ";
            var expected = string.Empty;
            // act
            var result = source.InsertSpaces();
            // assert
            Assert.AreEqual(expected, result);
        }
        #endregion public test methods
    }
}
