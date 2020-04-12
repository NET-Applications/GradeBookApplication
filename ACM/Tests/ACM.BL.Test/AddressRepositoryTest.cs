using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BL.Test
{
    [TestClass]
    public class AddressRepositoryTest
    {
        #region public test methods
        [TestMethod]
        public void RetrieveValid()
        {
            // arrange
            var addressRepository = new AddressRepository();
            var expected = new Address(1)
            {
                AddressType = 1,
                StreetLine1 = "Bag End",
                StreetLine2 = "Bagshot row",
                City = "Hobbiton",
                State = "Shire",
                Country = "Middle Earth",
                PostalCode = "144"
            };
            // act
            var result = addressRepository.Retrieve(1);
            // assert
            Assert.AreEqual(expected.AddressId, result.AddressId);
            Assert.AreEqual(expected.AddressType, result.AddressType);
            Assert.AreEqual(expected.StreetLine1, result.StreetLine1);
            Assert.AreEqual(expected.StreetLine2, result.StreetLine2);
            Assert.AreEqual(expected.City, result.City);
            Assert.AreEqual(expected.State, result.State);
            Assert.AreEqual(expected.Country, result.Country);
            Assert.AreEqual(expected.PostalCode, result.PostalCode);
        }
        [TestMethod]
        public void RetrieveInValid()
        {
            // arrange
            var addressRepository = new AddressRepository();
            var expected = new Address(2)
            {
                AddressType = 2,
                StreetLine1 = "Darkness",
                StreetLine2 = "Castle",
                City = "Orcland",
                State = "Mordor",
                Country = "Central Earth",
                PostalCode = "113"
            };
            // act
            var result = addressRepository.Retrieve(1);
            // assert
            Assert.AreNotEqual(expected.AddressId, result.AddressId);
            Assert.AreNotEqual(expected.AddressType, result.AddressType);
            Assert.AreNotEqual(expected.StreetLine1, result.StreetLine1);
            Assert.AreNotEqual(expected.StreetLine2, result.StreetLine2);
            Assert.AreNotEqual(expected.City, result.City);
            Assert.AreNotEqual(expected.State, result.State);
            Assert.AreNotEqual(expected.Country, result.Country);
            Assert.AreNotEqual(expected.PostalCode, result.PostalCode);
        }
        [TestMethod]
        public void SaveTestValid()
        {
            // arrange
            var addressRepository = new AddressRepository();
            var updatedAddress = new Address(2)
            {
                AddressType = 1,
                StreetLine1 = "Bag End",
                StreetLine2 = "Bagshot row",
                City = "Hobbiton",
                State = "Shire",
                Country = "Middle Earth",
                PostalCode = "144",
                HasChanges = true
            };

            // act
            var result = addressRepository.Save(updatedAddress);
            // assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void SaveTestMissingPostalCode()
        {
            // arrange
            var addressRepository = new AddressRepository();
            var updatedAddress = new Address(2)
            {
                AddressType = 1,
                StreetLine1 = "Bag End",
                StreetLine2 = "Bagshot row",
                City = "Hobbiton",
                State = "Shire",
                Country = "Middle Earth",
                PostalCode = null,
                HasChanges = true
            };

            // act
            var result = addressRepository.Save(updatedAddress);
            // assert
            Assert.IsFalse(result);
        }
        #endregion public test methods
    }
}
