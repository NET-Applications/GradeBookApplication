using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BL.Test
{
    [TestClass]
    public class OrderTest
    {
        #region public test methods
        [TestMethod]
        public void ValidateValid()
        {
            // arrange
            Order order = new Order
            {
                OrderDate = DateTimeOffset.Now
            };

            bool expected = true;
            // act
            var result = order.Validate();
            // assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ValidateInValid()
        {
            // arrange
            Order order = new Order();

            bool expected = false;
            // act
            var result = order.Validate();
            // assert
            Assert.AreEqual(expected, result);
        }
        #endregion public test methods
    }
}
