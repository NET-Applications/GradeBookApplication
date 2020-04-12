using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class CustomerRepository
    {
        #region public methods
        ///<summary>
        /// Retrieve one customer. 
        ///</summary>
        public Customer Retrieve(int customerId)
        {
            // Create an instance of the Customer class
            // Pass in the requested id
            Customer customer = new Customer(customerId);

            // Code that retrieves the defined customer.

            // Temporary hard-coded values to return a populated customer
            if(customerId == 1)
            {
                customer.EmailAddress = "fbaggins@hobitton.me";
                customer.FirstName = "Frodo";
                customer.LastName = "Baggins";
            }
            return customer;
        }
        ///<summary>
        /// Saves the current customer.
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
