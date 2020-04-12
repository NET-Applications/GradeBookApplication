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
        public void RetriveExistingWithAddress()
        {
            // arrange
            var customerRepository = new CustomerRepository();
            var expected = new Customer(1)
            {
                EmailAddress = "fbaggins@hobitton.me",
                FirstName = "Frodo",
                LastName = "Baggins",
                AddressList = new List<Address>()
                {
                    new Address(1)
                    {
                        AddressType = 1,
                        StreetLine1 = "Bag End",
                        StreetLine2 = "Bagshot row",
                        City = "Hobbiton",
                        State = "Shire",
                        Country = "Middle Earth",
                        PostalCode = "144"
                    },
                    new Address(2)
                    {
                        AddressType = 2,
                        StreetLine1 = "Green Dragon",
                        StreetLine2 = "Elsyer",
                        City = "ByWater",
                        State = "Shire",
                        Country = "Middle Earth",
                        PostalCode = "146"
                    }
                }
            };
            // act
            var result = customerRepository.Retrieve(1);
            // assert
            Assert.AreEqual(expected.CustomerId, result.CustomerId);
            Assert.AreEqual(expected.EmailAddress, result.EmailAddress);
            Assert.AreEqual(expected.FirstName, result.FirstName);
            Assert.AreEqual(expected.LastName, result.LastName);

            for(int i = 0; i < 1; i++)
            {
                Assert.AreEqual(expected.AddressList[i].AddressId, result.AddressList[i].AddressId);
                Assert.AreEqual(expected.AddressList[i].StreetLine1, result.AddressList[i].StreetLine1);
                Assert.AreEqual(expected.AddressList[i].StreetLine2, result.AddressList[i].StreetLine2);
                Assert.AreEqual(expected.AddressList[i].City, result.AddressList[i].City);
                Assert.AreEqual(expected.AddressList[i].State, result.AddressList[i].State);
                Assert.AreEqual(expected.AddressList[i].Country, result.AddressList[i].Country);
                Assert.AreEqual(expected.AddressList[i].PostalCode, result.AddressList[i].PostalCode);
            }
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
        [TestMethod]
        public void SaveTestValid()
        {
            // arrange
            var customerRepository = new CustomerRepository();
            var updatedCustomer = new Customer(2)
            {
                EmailAddress = "fbaggins@hobitton.me",
                FirstName = "Frodo",
                LastName = "Baggins",
                AddressList = new List<Address>()
                {
                    new Address(1)
                    {
                        AddressType = 1,
                        StreetLine1 = "Bag End",
                        StreetLine2 = "Bagshot row",
                        City = "Hobbiton",
                        State = "Shire",
                        Country = "Middle Earth",
                        PostalCode = "144"
                    },
                    new Address(2)
                    {
                        AddressType = 2,
                        StreetLine1 = "Green Dragon",
                        StreetLine2 = "Elsyer",
                        City = "ByWater",
                        State = "Shire",
                        Country = "Middle Earth",
                        PostalCode = "146"
                    }
                },
                HasChanges = true
            };

            // act
            var result = customerRepository.Save(updatedCustomer);
            // assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void SaveTestEmptyEmail()
        {
            // arrange
            var customerRepository = new CustomerRepository();
            var updatedCustomer = new Customer(2)
            {
                EmailAddress = " ",
                FirstName = "Frodo",
                LastName = "Baggins",
                AddressList = new List<Address>()
                {
                    new Address(1)
                    {
                        AddressType = 1,
                        StreetLine1 = "Bag End",
                        StreetLine2 = "Bagshot row",
                        City = "Hobbiton",
                        State = "Shire",
                        Country = "Middle Earth",
                        PostalCode = "144"
                    },
                    new Address(2)
                    {
                        AddressType = 2,
                        StreetLine1 = "Green Dragon",
                        StreetLine2 = "Elsyer",
                        City = "ByWater",
                        State = "Shire",
                        Country = "Middle Earth",
                        PostalCode = "146"
                    }
                },
                HasChanges = true
            };

            // act
            var result = customerRepository.Save(updatedCustomer);
            // assert
            Assert.IsFalse(result);
        }
        #endregion public test methods
    }
}
