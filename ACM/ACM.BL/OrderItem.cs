using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class OrderItem
    {
        #region public constructors
        public OrderItem()
        {

        }
        public OrderItem(int orderItemId)
        {
            OrderItemId = orderItemId;
        }
        #endregion public constructors

        #region public properties
        //Property to get the orderItemId for the order, it can be set within the class.
        public int OrderItemId { get; private set; }
        //Property to get or set productId for the order.
        public int ProductId { get; set; }
        //Property to get or set the purchase price for the order.
        public decimal? PurchasePrice { get; set; }
        //Property to get or set the quantity of the product ordered.
        public int Quantity { get; set; }
        #endregion public properties

        #region public methods
        ///<summary>
        /// Retrieve one order item. 
        ///</summary>
        public OrderItem Retrieve(int orderItemId)
        {
            // Code that retrieves the defined order item.
            return new OrderItem(orderItemId);
        }
        ///<summary>
        /// Saves the current order item.
        ///</summary>
        ///<returns>Boolean value.</returns>
        public bool Save()
        {
            // Code that saves the defined order item.
            return true;
        }
        ///<summary>
        /// Validates the order data.
        ///</summary>
        ///<returns>Boolean value.</returns>
        public bool Validate()
        {
            var isValid = true;
            if (Quantity <= 0)
                isValid = false;
            else if (ProductId <= 0)
                isValid = false;
            else if (PurchasePrice == null)
                isValid = false;
            return isValid;
        }
        #endregion public methods

    }
}
