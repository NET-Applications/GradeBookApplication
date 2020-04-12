using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BL.Test
{
    [TestClass]
    public class OrderItemTest
    {
        #region public test methods
        [TestMethod]
        public void ValidateValid()
        {
            // arrange
            OrderItem orderItem = new OrderItem
            {
                ProductId = 1,
                PurchasePrice = 25m,
                Quantity = 2
            };

            bool expected = true;
            // act
            var result = orderItem.Validate();
            // assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void ValidateInValid()
        {
            // arrange
            OrderItem orderItem = new OrderItem();

            bool expected = false;
            // act
            var result = orderItem.Validate();
            // assert
            Assert.AreEqual(expected, result);
        }
        #endregion public test methods
    }
}
