using System;

namespace QuoteSwift
{
    public class Address
    {
        /** Descriptive variable names used where possible
         * to avoid possible confusion*/

        private string mAddressDescription = "";
        private int mAddressStreetNumber = 0;
        private string mAddressStreetName = "";
        private string mAddressSuburb = "";
        private string mAddressCity = "";
        private int mAddressAreaCode = 0;

        //Default Constructor
        public Address()
        {
            AddressDescription = "";
            AddressStreetNumber = 0;
            AddressStreetName = "";
            AddressSuburb = "";
            AddressCity = "";
            AddressAreaCode = 0;
        }

        public Address(Address a)
        {
            AddressDescription = a.mAddressDescription;
            AddressStreetNumber = a.mAddressStreetNumber;
            AddressStreetName = a.mAddressStreetName;
            AddressSuburb = a.mAddressSuburb;
            AddressCity = a.mAddressCity;
            AddressAreaCode = a.mAddressAreaCode;
        }

        public Address(string mAddressDescription, int mAddressStreetNumber, string mAddressStreetName, string mAddressSuburb, string mAddressCity, int mAddressAreaCode)
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

        internal object SingleOrDefault(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
