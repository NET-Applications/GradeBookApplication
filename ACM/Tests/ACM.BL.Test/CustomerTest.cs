using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BL.Test
{
    [TestClass]
    public class CustomerTest
    {
        #region public test methods
        [TestMethod]
        public void FullNameTestValid()
        {
            // arrange
            Customer customer = new Customer
            {
                FirstName = "Bilbo",
                LastName = "Baggins"
            };
            var expected = "Baggins, Bilbo";
            // act
            var result = customer.FullName;
            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void FullNameFirstNameEmpty()
        {
            // arrange
            Customer customer = new Customer
            {
                LastName = "Baggins"
            };
            var expected = "Baggins";
            // act
            var result = customer.FullName;
            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void FullNameLastNameEmpty()
        {
            // arrange
            Customer customer = new Customer
            {
                FirstName = "Bilbo",
            };
            var expected = "Bilbo";
            // act
            var result = customer.FullName;
            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void FullNameFirstNameAndLastNameEmpty()
        {
            // arrange
            Customer customer = new Customer();
            var expected = String.Empty;
            // act
            var result = customer.FullName;
            // assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ValidateValid()
        {
            // arrange
            Customer customer = new Customer
            {
                LastName = "Baggins",
                EmailAddress = "fbaggins@hobbiton.me"
            };

            bool expected = true;
            // act
            var result = customer.Validate();
            // assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ValidateInValid()
        {
            // arrange
            Customer customer = new Customer
            {
                LastName = " ",
                EmailAddress = "fbaggins@hobbiton.me"
            };

            bool expected = false;
            // act
            var result = customer.Validate();
            // assert
            Assert.AreEqual(expected, result);
        }
        #endregion public test methods

    }
}
