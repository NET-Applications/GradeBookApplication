using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BL.Test
{
    [TestClass]
    public class AddressTest
    {
        #region public test methods
        [TestMethod]
        public void ValidateValid()
        {
            // arrange
            Address address = new Address
            {
                PostalCode = "600013"
            };

            bool expected = true;
            // act
            var result = address.Validate();
            // assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ValidateInValid()
        {
            // arrange
            Address address = new Address();

            bool expected = false;
            // act
            var result = address.Validate();
            // assert
            Assert.AreEqual(expected, result);
        }
        #endregion public test methods
    }
}
