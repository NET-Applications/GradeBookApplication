using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class CustomerRepository
    {
        #region public constructors
        public CustomerRepository()
        {
            addressRepository = new AddressRepository();
        }
        #endregion public constructors

        #region private properties
        //Property to get or set address repository within the class.
        private AddressRepository addressRepository { get; set; }
        #endregion private properties

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
                customer.AddressList = addressRepository.RetrieveByCustomerId(customerId).ToList<Address>();
            }
            return customer;
        }
        ///<summary>
        /// Saves the current customer.
        ///</summary>
        ///<returns>Boolean value.</returns>
        public bool Save(Customer customer)
        {
            // Code that saves the defined customer.
            var success = true;
            if (customer.HasChanges)
            {
                if (customer.IsValid)
                {
                    if (customer.IsNew)
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
