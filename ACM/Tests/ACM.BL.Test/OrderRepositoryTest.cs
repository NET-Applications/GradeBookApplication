using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BL.Test
{
    [TestClass]
    public class OrderRepositoryTest
    {
        #region public test methods
        [TestMethod]
        public void RetrieveValid()
        {
            // arrange
            var orderRepository = new OrderRepository();
            var expected = new Order(1)
            {
                OrderDate = new DateTimeOffset(DateTime.Now.Year, 4, 14, 10, 00, 00, new TimeSpan(7, 0, 0))
            };
            // act
            var result = orderRepository.Retrieve(1);
            // assert
            Assert.AreEqual(expected.OrderDate, result.OrderDate);
        }
        [TestMethod]
        public void RetrieveInValid()
        {
            // arrange
            var orderRepository = new OrderRepository();
            var expected = new Order(1)
            {
                OrderDate = DateTimeOffset.Now.AddDays(1),
            };
            // act
            var result = orderRepository.Retrieve(1);
            // assert
            Assert.AreNotEqual(expected.OrderDate, result.OrderDate);
        }
        #endregion public test methods
    }
}
