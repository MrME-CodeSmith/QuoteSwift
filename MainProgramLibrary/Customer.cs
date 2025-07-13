using System.ComponentModel;
using System.Collections.Generic;

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

        // lookup collections for quick searches and duplicate checks
        private Dictionary<string, Address> mDeliveryAddressMap;
        private Dictionary<string, Address> mPOBoxMap;
        private HashSet<string> mTelephoneNumbers;
        private HashSet<string> mCellphoneNumbers;
        private HashSet<string> mEmailAddresses;

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

            mDeliveryAddressMap = new Dictionary<string, Address>();
            mPOBoxMap = new Dictionary<string, Address>();
            mTelephoneNumbers = new HashSet<string>();
            mCellphoneNumbers = new HashSet<string>();
            mEmailAddresses = new HashSet<string>();
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

            mDeliveryAddressMap = new Dictionary<string, Address>(c.mDeliveryAddressMap);
            mPOBoxMap = new Dictionary<string, Address>(c.mPOBoxMap);
            mTelephoneNumbers = new HashSet<string>(c.mTelephoneNumbers);
            mCellphoneNumbers = new HashSet<string>(c.mCellphoneNumbers);
            mEmailAddresses = new HashSet<string>(c.mEmailAddresses);
        }


        public string CustomerName { get => mCustomerName; set => mCustomerName = value; }
        public string CustomerCompanyName { get => mCustomerCompanyName; set => mCustomerCompanyName = value; }
        public BindingList<Address> CustomerPOBoxAddress
        {
            get => mCustomerPOBoxAddress;
            set
            {
                mCustomerPOBoxAddress = value;
                mPOBoxMap?.Clear();
                if (mCustomerPOBoxAddress != null)
                    foreach (var a in mCustomerPOBoxAddress)
                        mPOBoxMap[a.AddressDescription] = a;
            }
        }
        public BindingList<Address> CustomerDeliveryAddressList
        {
            get => mCustomerDeliveryAddressList;
            set
            {
                mCustomerDeliveryAddressList = value;
                mDeliveryAddressMap?.Clear();
                if (mCustomerDeliveryAddressList != null)
                    foreach (var a in mCustomerDeliveryAddressList)
                        mDeliveryAddressMap[a.AddressDescription] = a;
            }
        }
        public Legal CustomerLegalDetails { get => mCustomerLegalDetails; set => mCustomerLegalDetails = value; }
        public string CustomerVendorNumber { get => mCustomerVendorNumber; set => mCustomerVendorNumber = value; }
        public BindingList<string> CustomerTelephoneNumberList
        {
            get => mCustomerTelephoneNumberList;
            set
            {
                mCustomerTelephoneNumberList = value;
                mTelephoneNumbers?.Clear();
                if (mCustomerTelephoneNumberList != null)
                    foreach (var n in mCustomerTelephoneNumberList)
                        mTelephoneNumbers.Add(n);
            }
        }
        public BindingList<string> CustomerCellphoneNumberList
        {
            get => mCustomerCellphoneNumberList;
            set
            {
                mCustomerCellphoneNumberList = value;
                mCellphoneNumbers?.Clear();
                if (mCustomerCellphoneNumberList != null)
                    foreach (var n in mCustomerCellphoneNumberList)
                        mCellphoneNumbers.Add(n);
            }
        }
        public BindingList<string> CustomerEmailList
        {
            get => mCustomerEmailList;
            set
            {
                mCustomerEmailList = value;
                mEmailAddresses?.Clear();
                if (mCustomerEmailList != null)
                    foreach (var e in mCustomerEmailList)
                        mEmailAddresses.Add(e);
            }
        }
        public string VendorNumber { get => mVendorNumber; set => mVendorNumber = value; }
        public Dictionary<string, Address> DeliveryAddressMap => mDeliveryAddressMap;
        public Dictionary<string, Address> POBoxMap => mPOBoxMap;
        public HashSet<string> TelephoneNumbers => mTelephoneNumbers;
        public HashSet<string> CellphoneNumbers => mCellphoneNumbers;
        public HashSet<string> EmailAddresses => mEmailAddresses;
    }
}
