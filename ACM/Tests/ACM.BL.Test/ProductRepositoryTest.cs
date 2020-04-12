using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BL.Test
{
    [TestClass]
    public class ProductRepositoryTest
    {
        #region public test methods
        [TestMethod]
        public void RetirieveValid()
        {
            // arrange
            var productRepository = new ProductRepository();
            var expected = new Product(1)
            {
                ProductName = "Hammer",
                CurrentPrice = 25m
            };
            // act
            var result = productRepository.Retrieve(1);
            // assert
            Assert.AreEqual(expected.ProductName, result.ProductName);
            Assert.AreEqual(expected.CurrentPrice, result.CurrentPrice);
        }
        [TestMethod]
        public void RetirieveInValid()
        {
            // arrange
            var productRepository = new ProductRepository();
            var expected = new Product(1)
            {
                ProductName = "Bat",
                CurrentPrice = 35m
            };
            // act
            var result = productRepository.Retrieve(1);
            // assert
            Assert.AreNotEqual(expected.ProductName, result.ProductName);
            Assert.AreNotEqual(expected.CurrentPrice, result.CurrentPrice);
        }
        #endregion public test methods
    }
}
