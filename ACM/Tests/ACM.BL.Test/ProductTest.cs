using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BL.Test
{
    [TestClass]
    public class ProductTest
    {
        #region public test methods
        [TestMethod]
        public void ValidateValid()
        {
            // arrange
            Product product = new Product
            {
                ProductName = "Hammer",
                CurrentPrice = 25m
            };

            bool expected = true;
            // act
            var result = product.Validate();
            // assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ValidateInValid()
        {
            // arrange
            Product product = new Product
            {
                ProductName = " ",
                CurrentPrice = null
            };

            bool expected = false;
            // act
            var result = product.Validate();
            // assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ProductNameWithoutSpaces()
        {
            // arrange
            Product product = new Product(1)
            {
                ProductName = "SonicScrewdriver",
                CurrentPrice = 25m
            };
            var expected = "Sonic Screwdriver";
            // act
            var result = product.ProductName;
            // assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ProductNameWithSpaces()
        {
            // arrange
            Product product = new Product(1)
            {
                ProductName = "Sonic Screwdriver",
                CurrentPrice = 25m
            };
            var expected = "Sonic Screwdriver";
            // act
            var result = product.ProductName;
            // assert
            Assert.AreEqual(expected, result);
        }
        #endregion public test methods
    }
}
