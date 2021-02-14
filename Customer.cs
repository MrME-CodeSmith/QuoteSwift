using System.ComponentModel;
using ProtoBuf;

namespace QuoteSwift
{
    [ProtoContract(SkipConstructor = true)]
    public class Customer
    {
        [ProtoMember(1)]
        private string mCustomerName;
        [ProtoMember(2)]
        private string mCustomerCompanyName;
        [ProtoMember(3)]
        private Address mCustomerPOBoxAddress;
        [ProtoMember(4)]
        private BindingList<Address> mCustomerDeliveryAddressList;
        [ProtoMember(5)]
        private Legal mCustomerLegalDetails;
        [ProtoMember(6)]
        private string mCustomerVendorNumber;

        public Customer(string mCustomerName, string mCustomerCompanyName, Address mCustomerPOBoxAddress, BindingList<Address> mCustomerDeliveryAddressList, Legal mCustomerLegalDetails, string mCustomerVendorNumber)
        {
            CustomerName = mCustomerName;
            CustomerCompanyName = mCustomerCompanyName;
            CustomerPOBoxAddress = mCustomerPOBoxAddress;
            CustomerDeliveryAddressList = mCustomerDeliveryAddressList;
            CustomerLegalDetails = mCustomerLegalDetails;
            CustomerVendorNumber = mCustomerVendorNumber;
        }

        public string CustomerName { get => mCustomerName; set => mCustomerName = value; }
        public string CustomerCompanyName { get => mCustomerCompanyName; set => mCustomerCompanyName = value; }
        public Address CustomerPOBoxAddress { get => mCustomerPOBoxAddress; set => mCustomerPOBoxAddress = value; }
        public BindingList<Address> CustomerDeliveryAddressList { get => mCustomerDeliveryAddressList; set => mCustomerDeliveryAddressList = value; }
        public Legal CustomerLegalDetails { get => mCustomerLegalDetails; set => mCustomerLegalDetails = value; }
        public string CustomerVendorNumber { get => mCustomerVendorNumber; set => mCustomerVendorNumber = value; }
    }
}
