using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Order
    {
        #region public constructors
        public Order()
        {

        }
        public Order(int orderId)
        {
            OrderId = orderId;
        }
        #endregion public constructors

        #region public properties
        //Property to get or set the order date.
        public DateTimeOffset? OrderDate { get; set; }
        //Property to get the order id, it can be set within the class.
        public int OrderId { get; private set; }
        #endregion public properties

        #region public methods
        ///<summary>
        /// Validates the order data.
        ///</summary>
        ///<returns>Boolean value.</returns>
        public bool Validate()
        {
            var isValid = true;
            if (OrderDate == null)
                isValid = false;
            return isValid;
        }
        #endregion public methods

    }
}
