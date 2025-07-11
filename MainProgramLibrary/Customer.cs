using System.ComponentModel;

namespace QuoteSwift
{
    public class Customer
    {
        private string mCustomerName;
        private string mCustomerCompanyName;
        private BindingList<Address> mCustomerPOBoxAddress;
        private BindingList<Address> mCustomerDeliveryAddressList;
        private Legal mCustomerLegalDetails;
        private string mCustomerVendorNumber;
        private BindingList<string> mCustomerTelephoneNumberList;
        private BindingList<string> mCustomerCellphoneNumberList;
        private BindingList<string> mCustomerEmailList;
        private string mVendorNumber;

        //Default Constructor
        public Customer()
        {
            CustomerName = "";
            CustomerCompanyName = "";
            CustomerPOBoxAddress = null;
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
            CustomerPOBoxAddress = c.CustomerPOBoxAddress;
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
        public BindingList<Address> CustomerPOBoxAddress { get => mCustomerPOBoxAddress; set => mCustomerPOBoxAddress = value; }
        public BindingList<Address> CustomerDeliveryAddressList { get => mCustomerDeliveryAddressList; set => mCustomerDeliveryAddressList = value; }
        public Legal CustomerLegalDetails { get => mCustomerLegalDetails; set => mCustomerLegalDetails = value; }
        public string CustomerVendorNumber { get => mCustomerVendorNumber; set => mCustomerVendorNumber = value; }
        public BindingList<string> CustomerTelephoneNumberList { get => mCustomerTelephoneNumberList; set => mCustomerTelephoneNumberList = value; }
        public BindingList<string> CustomerCellphoneNumberList { get => mCustomerCellphoneNumberList; set => mCustomerCellphoneNumberList = value; }
        public BindingList<string> CustomerEmailList { get => mCustomerEmailList; set => mCustomerEmailList = value; }
        public string VendorNumber { get => mVendorNumber; set => mVendorNumber = value; }
    }
}
