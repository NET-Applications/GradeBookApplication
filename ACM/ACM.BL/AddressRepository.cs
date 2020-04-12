using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class AddressRepository
    {
        #region public methods
        ///<summary>
        /// Retrieve one address.
        /// </summary>
        /// <returns></returns>
        public Address Retrieve(int addressId)
        {
            // Create an instance of the Address class
            // Pass the requested id
            Address address = new Address(addressId);

            // Code that retrives the defined address

            // Temporary hard-coded values to return a populated address
            if (addressId == 1)
            {
                address.AddressType = 1;
                address.StreetLine1 = "Bag End";
                address.StreetLine2 = "Bagshot row";
                address.City = "Hobbiton";
                address.State = "Shire";
                address.Country = "Middle Earth";
                address.PostalCode = "144";

            }
            return address;
        }
        ///<summary>
        /// Retrives all the addresses of a customer
        /// </summary>
        /// <returns>IEnumerable<Address><see cref="IEnumerable{Address}"/></returns>
        public IEnumerable<Address> RetrieveByCustomerId(int customerId)
        {
            // Code that retrieves the defined address for the customer

            // Temporary hard-coded values to return a set of addresses for a customer
            var addressList = new List<Address>()
            {
                new Address(1)
                {
                    AddressType = 1,
                    StreetLine1 = "Bag End",
                    StreetLine2 = "Bagshot row",
                    City = "Hobbiton",
                    State = "Shire",
                    Country = "Middle Earth",
                    PostalCode = "144"
                },
                new Address(2)
                {
                    AddressType = 2,
                    StreetLine1 = "Green Dragon",
                    StreetLine2 = "Elsyer",
                    City = "ByWater",
                    State = "Shire",
                    Country = "Middle Earth",
                    PostalCode = "146"
                }
            };
            return addressList;
        }
        ///<summary>
        /// Saves the current address.
        /// </summary>
        public bool Save(Address address)
        {
            // Code that saves the passed in address
            var success = true;
            if (address.HasChanges)
            {
                if (address.IsValid)
                {
                    if (address.IsNew)
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
