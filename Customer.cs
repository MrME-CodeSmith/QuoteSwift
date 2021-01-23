using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace QuoteSwift
{
    [Serializable]
    public class Customer
    {
        private string mCustomerName;
        private string mCustomerCompanyName;
        private Address mCustomerPOBoxAddress;
        private BindingList<Address> mCustomerDeliveryAddressList;
        private Legal mCustomerLegalDetails;
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
