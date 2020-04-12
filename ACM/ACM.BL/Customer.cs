using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Customer
    {

        #region public constructors
        public Customer()
        {
        }
        public Customer(int customerId)
        {
            CustomerId = customerId;
        }
        #endregion public constructors

        #region private fields
        // Last name of the customer.
        private string _lastName;
        #endregion private fields       

        #region public properties
        //Property to get and set the customer ID
        public int CustomerId { get; private set; }
        //Property to get and set emil address of the customer.
        public string EmailAddress { get; set; }
        //Property to set and get the first name of the customer.
        public string FirstName { get; set; }
        //Property to get the full name for the customer.
        public string FullName
        {
            get
            {
                // Using the new switch case statement for pattern recognition.
                switch (FirstName + LastName)
                {
                    case var name when String.Equals(name, FirstName) || String.Equals(name, LastName):
                        return name;
                    case var name when !String.IsNullOrWhiteSpace(name):
                        return $"{LastName}, {FirstName}";                        
                    default:
                        return string.Empty;

                }

            }
        }
        // Property to get and set the last name of the customer.
        public string LastName
        {
            get
            {
                return _lastName;
            }

            set
            {
                _lastName = value;
            }
        }
        #endregion public properties

        #region public methods
        ///<summary>
        /// Validates the customer data.
        ///</summary>
        ///<returns>Boolean value.</returns>
        public bool Validate()
        {
            var isValid = true;
            if (string.IsNullOrWhiteSpace(LastName))
                isValid = false;
            else if (string.IsNullOrWhiteSpace(EmailAddress))
                isValid = false;
            return isValid;
        }
        #endregion public methods

    }
}
