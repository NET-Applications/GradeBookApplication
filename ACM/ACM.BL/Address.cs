using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Address : EntityBase
    {
        #region public constructors
        public Address()
        {

        }
        public Address(int addressId)
        {
            AddressId = addressId;
        }
        #endregion public constructors

        #region public properties
        //Property to get address id and set it within the class.  
        public int AddressId { get; private set; }
        //Property to get or set address type.
        public int AddressType { get; set; }
        //Property to get or set city.
        public string City { get; set; }
        //Property to get or set country.
        public string Country { get; set; }
        //Property to get or set postal code.
        public string PostalCode { get; set; }
        //Property to get or set state.
        public string State { get; set; }
        //Property to get or set street line 1.
        public string StreetLine1 { get; set; }
        //Property to get or set street line 2.
        public string StreetLine2 { get; set; }
        #endregion public properties
                
        #region public overridden methods
        ///<summary>
        /// Validates the address data.
        ///</summary>
        ///<returns>Boolean value.</returns>
        public override bool Validate()
        {
            var isValid = true;
            if (PostalCode == null)
                isValid = false;
            return isValid;
        }
        #endregion public overridden methods

    }
}
