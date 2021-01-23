using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteSwift
{
    [Serializable]
    public class Address
    {
        /** Descriptive variable names used where possible
         * to avoid possible confusion*/
        private string mAddressDescription;
        private int mAddressStreetNumber;
        private string mAddressStreetName;
        private string mAddressSuburb;
        private string mAddressCity;
        private int mAddressAreaCode;

        public Address(string mAddressDescription, short mAddressStreetNumber, string mAddressStreetName, string mAddressSuburb, string mAddressCity, short mAddressAreaCode)
        {
            AddressDescription = mAddressDescription;
            AddressStreetNumber = mAddressStreetNumber;
            AddressStreetName = mAddressStreetName;
            AddressSuburb = mAddressSuburb;
            AddressCity = mAddressCity;
            AddressAreaCode = mAddressAreaCode;
        }

        public string AddressDescription { get => mAddressDescription; set => mAddressDescription = value; }
        public int AddressStreetNumber { get => mAddressStreetNumber; set => mAddressStreetNumber = value; }
        public string AddressStreetName { get => mAddressStreetName; set => mAddressStreetName = value; }
        public string AddressSuburb { get => mAddressSuburb; set => mAddressSuburb = value; }
        public string AddressCity { get => mAddressCity; set => mAddressCity = value; }
        public int AddressAreaCode { get => mAddressAreaCode; set => mAddressAreaCode = value; }
    }
}
