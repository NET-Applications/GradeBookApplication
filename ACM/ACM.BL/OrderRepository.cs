using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class OrderRepository
    {
        #region public methods
        ///<summary>
        /// Retrieve one order. 
        ///</summary>
        public Order Retrieve(int orderId)
        {
            // Create an instance of the Order class
            // Pass the requested id
            Order order = new Order(orderId);

            // Code that retrieves the defined order.
            // Temporary hard-coded values to return a populated order
            if(orderId == 1)
            {
                order.OrderDate = new DateTimeOffset(DateTime.Now.Year, 4, 14, 10, 00, 00, new TimeSpan(7,0,0));
            }
            return order;
        }
        ///<summary>
        /// Saves the current order.
        ///</summary>
        ///<returns>Boolean value.</returns>
        public bool Save(Order order)
        {
            // Code that saves the defined order.
            var success = true;
            if (order.HasChanges)
            {
                if (order.IsValid)
                {
                    if (order.IsNew)
                    {
                        // Call an Insert Stored Procedure
                    }
                    else
                    {
                        // Call an Update Stored Procedure
                    }
                }
                else
                {
                    success = false;
                }
            }
            return success;
        }
        #endregion public methods
    }
}
