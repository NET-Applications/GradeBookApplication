using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Product : EntityBase
    {
        #region public constructors
        public Product()
        {

        }
        public Product(int productId)
        {
            ProductId = productId;
        }
        #endregion public constructors    

        #region public properties
        //Property to get or set the name of the product.
        public string ProductName { get; set; }
        //Property to get or set the description of the product.
        public string ProductDescription { get; set; }
        //Property to get or set the current price of the product.
        public decimal? CurrentPrice { get; set; }
        //Property to get the product id and set it within the class.
        public int ProductId { get; private set; }
        #endregion public properties

        #region public overridden methods
        // Overriding toString method using expression bodied members.
        public override string ToString() => ProductName;
        ///<summary>
        /// Validates the product data.
        ///</summary>
        ///<returns>Boolean value.</returns>
        public override bool Validate()
        {
            var isValid = true;
            if (string.IsNullOrWhiteSpace(ProductName))
                isValid = false;
            else if (CurrentPrice == null)
                isValid = false;
            return isValid;
        }
        #endregion public overridden methods

    }
}
