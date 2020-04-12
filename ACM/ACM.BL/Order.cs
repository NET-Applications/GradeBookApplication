using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Order : EntityBase
    {
        #region public constructors
        public Order() : this(0)
        {

        }
        public Order(int orderId)
        {
            OrderId = orderId;
            OrderItems = new List<OrderItem>();
        }
        #endregion public constructors

        #region public properties
        //Property to get or set customer id.
        public int CustomerId { get; set; }
        //Property to get or set the address id for shipping the order.
        public int ShippingAddressId { get; set; }
        //Property to get or set the order items of a customer.
        public List<OrderItem> OrderItems { get; set; }
        //Property to get or set the order date.
        public DateTimeOffset? OrderDate { get; set; }
        //Property to get the order id, it can be set within the class.
        public int OrderId { get; private set; }
        #endregion public properties

        #region public overridden methods
        // Overriding toString method using expresion bodied members.
        public override string ToString() => $"{OrderDate.Value.Date} ({OrderId})";
        ///<summary>
        /// Validates the order data.
        ///</summary>
        ///<returns>Boolean value.</returns>
        public override bool Validate()
        {
            var isValid = true;
            if (OrderDate == null)
                isValid = false;
            return isValid;
        }
        #endregion public overridden methods
    }
}
