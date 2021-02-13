using ProtoBuf;
using System;

namespace QuoteSwift
{
    [ProtoContract(SkipConstructor = true)]
    public class Address
    {
        /** Descriptive variable names used where possible
         * to avoid possible confusion*/

        [ProtoMember(1)]
        private string mAddressDescription;
        [ProtoMember(2)]
        private int mAddressStreetNumber;
        [ProtoMember(3)]
        private string mAddressStreetName;
        [ProtoMember(4)]
        private string mAddressSuburb;
        [ProtoMember(5)]
        private string mAddressCity;
        [ProtoMember(6)]
        private int mAddressAreaCode;

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
