using ProtoBuf;
using System.ComponentModel;

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
        private BindingList<Address> mCustomerPoBoxAddress;
        [ProtoMember(4)]
        private BindingList<Address> mCustomerDeliveryAddressList;
        [ProtoMember(5)]
        private Legal mCustomerLegalDetails;
        [ProtoMember(6)]
        private string mCustomerVendorNumber;
        [ProtoMember(7)]
        private BindingList<string> mCustomerTelephoneNumberList;
        [ProtoMember(8)]
        private BindingList<string> mCustomerCellphoneNumberList;
        [ProtoMember(9)]
        private BindingList<string> mCustomerEmailList;
        [ProtoMember(10)]
        private string mVendorNumber;

        //Default Constructor
        public Customer()
        {
            CustomerName = "";
            CustomerCompanyName = "";
            CustomerPoBoxAddress = null;
            CustomerDeliveryAddressList = null;
            CustomerLegalDetails = null;
            CustomerVendorNumber = "";
            CustomerTelephoneNumberList = null;
            CustomerCellphoneNumberList = null;
            CustomerEmailList = null;
            VendorNumber = "";
        }

        //Copy Constructor
        public Customer(Customer c)
        {
            CustomerName = c.CustomerName;
            CustomerCompanyName = c.CustomerCompanyName;
            CustomerPoBoxAddress = c.CustomerPoBoxAddress;
            CustomerDeliveryAddressList = c.CustomerDeliveryAddressList;
            CustomerLegalDetails = c.CustomerLegalDetails;
            CustomerVendorNumber = c.CustomerVendorNumber;
            CustomerTelephoneNumberList = c.CustomerTelephoneNumberList;
            CustomerCellphoneNumberList = c.CustomerCellphoneNumberList;
            CustomerEmailList = c.CustomerEmailList;
            VendorNumber = c.VendorNumber;
        }


        public string CustomerName { get => mCustomerName; set => mCustomerName = value; }
        public string CustomerCompanyName { get => mCustomerCompanyName; set => mCustomerCompanyName = value; }
        public BindingList<Address> CustomerPoBoxAddress { get => mCustomerPoBoxAddress; set => mCustomerPoBoxAddress = value; }
        public BindingList<Address> CustomerDeliveryAddressList { get => mCustomerDeliveryAddressList; set => mCustomerDeliveryAddressList = value; }
        public Legal CustomerLegalDetails { get => mCustomerLegalDetails; set => mCustomerLegalDetails = value; }
        public string CustomerVendorNumber { get => mCustomerVendorNumber; set => mCustomerVendorNumber = value; }
        public BindingList<string> CustomerTelephoneNumberList { get => mCustomerTelephoneNumberList; set => mCustomerTelephoneNumberList = value; }
        public BindingList<string> CustomerCellphoneNumberList { get => mCustomerCellphoneNumberList; set => mCustomerCellphoneNumberList = value; }
        public BindingList<string> CustomerEmailList { get => mCustomerEmailList; set => mCustomerEmailList = value; }
        public string VendorNumber { get => mVendorNumber; set => mVendorNumber = value; }
    }
}
