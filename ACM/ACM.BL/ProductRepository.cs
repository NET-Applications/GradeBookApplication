using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class ProductRepository
    {
        #region public methods
        ///<summary>
        /// Retrieve one product. 
        ///</summary>
        public Product Retrieve(int productId)
        {
            // Create an instance of the Product class
            // Pass the requested id
            Product product = new Product(productId);

            // Code that retrieves the defined product.
            // Temporary hard-coded values to return a populated product
            if(productId == 1)
            {
                product.ProductName = "Hammer";
                product.CurrentPrice = 25m;
            }
            return product;
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
        #endregion public methods
    }
}
