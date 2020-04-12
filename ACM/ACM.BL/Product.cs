using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Product
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

        #region public methods
        ///<summary>
        /// Retrieve all products.
        /// </summary>
        public List<Product> Retrieve()
        {
            // Code that retrieve all of the products.
            return new List<Product>();
        }
        ///<summary>
        /// Retrieve one product. 
        ///</summary>
        public Product Retrieve(int productId)
        {
            // Code that retrieves the defined product.
            return new Product(productId);
        }
        ///<summary>
        /// Saves the current product.
        ///</summary>
        ///<returns>Boolean value.</returns>
        public bool Save()
        {
            // Code that saves the defined customer.
            return true;
        }
        ///<summary>
        /// Validates the product data.
        ///</summary>
        ///<returns>Boolean value.</returns>
        public bool Validate()
        {
            var isValid = true;
            if (string.IsNullOrWhiteSpace(ProductName))
                isValid = false;
            else if (CurrentPrice == null)
                isValid = false;
            return isValid;
        }
        #endregion public methods

    }
}
