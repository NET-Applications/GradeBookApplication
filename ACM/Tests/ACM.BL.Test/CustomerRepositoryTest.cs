using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BL.Test
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        #region public test methods
        [TestMethod]
        public void RetrieveValid()
        {
            // arrange
            var customerRepository = new CustomerRepository();
            var expected = new Customer(1)
            {
                EmailAddress = "fbaggins@hobitton.me",
                FirstName = "Frodo",
                LastName = "Baggins"
            };
            // act
            var result = customerRepository.Retrieve(1);
            // assert
            Assert.ReferenceEquals(expected, result);
        }
        [TestMethod]
        public void RetrieveInValid()
        {
            // arrange
            var customerRepository = new CustomerRepository();
            var expected = new Customer(1)
            {
                EmailAddress = "sbaggins@hobitton.me",
                FirstName = "Sam",
                LastName = "Baggin"
            };
            // act
            var result = customerRepository.Retrieve(1);
            // assert
            Assert.AreNotEqual(expected.EmailAddress, result.EmailAddress);
            Assert.AreNotEqual(expected.FirstName, result.FirstName);
            Assert.AreNotEqual(expected.LastName, result.LastName);
        }
        #endregion public test methods
    }
}
