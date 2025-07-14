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
            CustomerPOBoxAddress = new BindingList<Address>();
            CustomerDeliveryAddressList = new BindingList<Address>();
            CustomerLegalDetails = null;
            CustomerTelephoneNumberList = new BindingList<string>();
            CustomerCellphoneNumberList = new BindingList<string>();
            CustomerEmailList = new BindingList<string>();
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

            if (c.mCustomerPOBoxAddress != null)
            {
                CustomerPOBoxAddress = new BindingList<Address>();
                foreach (var a in c.mCustomerPOBoxAddress)
                    CustomerPOBoxAddress.Add(new Address(a));
            }
            else
            {
                CustomerPOBoxAddress = null;
            }

            if (c.mCustomerDeliveryAddressList != null)
            {
                CustomerDeliveryAddressList = new BindingList<Address>();
                foreach (var a in c.mCustomerDeliveryAddressList)
                    CustomerDeliveryAddressList.Add(new Address(a));
            }
            else
            {
                CustomerDeliveryAddressList = null;
            }

            CustomerLegalDetails = c.mCustomerLegalDetails != null
                ? new Legal(c.mCustomerLegalDetails.RegistrationNumber, c.mCustomerLegalDetails.VatNumber)
                : null;

            if (c.mCustomerTelephoneNumberList != null)
            {
                CustomerTelephoneNumberList = new BindingList<string>();
                foreach (var n in c.mCustomerTelephoneNumberList)
                    CustomerTelephoneNumberList.Add(n);
            }
            else
            {
                CustomerTelephoneNumberList = null;
            }

            if (c.mCustomerCellphoneNumberList != null)
            {
                CustomerCellphoneNumberList = new BindingList<string>();
                foreach (var n in c.mCustomerCellphoneNumberList)
                    CustomerCellphoneNumberList.Add(n);
            }
            else
            {
                CustomerCellphoneNumberList = null;
            }

            if (c.mCustomerEmailList != null)
            {
                CustomerEmailList = new BindingList<string>();
                foreach (var e in c.mCustomerEmailList)
                    CustomerEmailList.Add(e);
            }
            else
            {
                CustomerEmailList = null;
            }

            VendorNumber = c.VendorNumber;

            mDeliveryAddressMap = new Dictionary<string, Address>();
            if (mCustomerDeliveryAddressList != null)
                foreach (var a in mCustomerDeliveryAddressList)
                    mDeliveryAddressMap[StringUtil.NormalizeKey(a.AddressDescription)] = a;

            mPOBoxMap = new Dictionary<string, Address>();
            if (mCustomerPOBoxAddress != null)
                foreach (var a in mCustomerPOBoxAddress)
                    mPOBoxMap[StringUtil.NormalizeKey(a.AddressDescription)] = a;

            mTelephoneNumbers = new HashSet<string>(mCustomerTelephoneNumberList ?? new BindingList<string>());
            mCellphoneNumbers = new HashSet<string>(mCustomerCellphoneNumberList ?? new BindingList<string>());
            mEmailAddresses = new HashSet<string>(mCustomerEmailList ?? new BindingList<string>());
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
                        mPOBoxMap[StringUtil.NormalizeKey(a.AddressDescription)] = a;
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
                        mDeliveryAddressMap[StringUtil.NormalizeKey(a.AddressDescription)] = a;
            }
        }
        public Legal CustomerLegalDetails { get => mCustomerLegalDetails; set => mCustomerLegalDetails = value; }
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

        // helper methods to manage phone numbers and emails while keeping
        // the lookup collections in sync
        public void AddTelephoneNumber(string number)
        {
            if (string.IsNullOrWhiteSpace(number)) return;
            if (mCustomerTelephoneNumberList == null)
                mCustomerTelephoneNumberList = new BindingList<string>();
            if (mTelephoneNumbers.Add(number))
                mCustomerTelephoneNumberList.Add(number);
        }

        public void RemoveTelephoneNumber(string number)
        {
            if (string.IsNullOrWhiteSpace(number)) return;
            if (mTelephoneNumbers.Remove(number))
            {
                mCustomerTelephoneNumberList?.Remove(number);
                if (mCustomerTelephoneNumberList != null && mCustomerTelephoneNumberList.Count == 0)
                    mCustomerTelephoneNumberList = null;
            }
        }

        public void UpdateTelephoneNumber(string oldNumber, string newNumber)
        {
            if (string.IsNullOrWhiteSpace(oldNumber) || string.IsNullOrWhiteSpace(newNumber)) return;
            if (mTelephoneNumbers.Remove(oldNumber))
            {
                mTelephoneNumbers.Add(newNumber);
                if (mCustomerTelephoneNumberList != null)
                {
                    int index = mCustomerTelephoneNumberList.IndexOf(oldNumber);
                    if (index >= 0)
                        mCustomerTelephoneNumberList[index] = newNumber;
                }
            }
        }

        public void AddCellphoneNumber(string number)
        {
            if (string.IsNullOrWhiteSpace(number)) return;
            if (mCustomerCellphoneNumberList == null)
                mCustomerCellphoneNumberList = new BindingList<string>();
            if (mCellphoneNumbers.Add(number))
                mCustomerCellphoneNumberList.Add(number);
        }

        public void RemoveCellphoneNumber(string number)
        {
            if (string.IsNullOrWhiteSpace(number)) return;
            if (mCellphoneNumbers.Remove(number))
            {
                mCustomerCellphoneNumberList?.Remove(number);
                if (mCustomerCellphoneNumberList != null && mCustomerCellphoneNumberList.Count == 0)
                    mCustomerCellphoneNumberList = null;
            }
        }

        public void UpdateCellphoneNumber(string oldNumber, string newNumber)
        {
            if (string.IsNullOrWhiteSpace(oldNumber) || string.IsNullOrWhiteSpace(newNumber)) return;
            if (mCellphoneNumbers.Remove(oldNumber))
            {
                mCellphoneNumbers.Add(newNumber);
                if (mCustomerCellphoneNumberList != null)
                {
                    int index = mCustomerCellphoneNumberList.IndexOf(oldNumber);
                    if (index >= 0)
                        mCustomerCellphoneNumberList[index] = newNumber;
                }
            }
        }

        public void AddEmailAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address)) return;
            if (mCustomerEmailList == null)
                mCustomerEmailList = new BindingList<string>();
            if (mEmailAddresses.Add(address))
                mCustomerEmailList.Add(address);
        }

        public void RemoveEmailAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address)) return;
            if (mEmailAddresses.Remove(address))
            {
                mCustomerEmailList?.Remove(address);
                if (mCustomerEmailList != null && mCustomerEmailList.Count == 0)
                    mCustomerEmailList = null;
            }
        }

        public void UpdateEmailAddress(string oldAddress, string newAddress)
        {
            if (string.IsNullOrWhiteSpace(oldAddress) || string.IsNullOrWhiteSpace(newAddress)) return;
            if (mEmailAddresses.Remove(oldAddress))
            {
                mEmailAddresses.Add(newAddress);
                if (mCustomerEmailList != null)
                {
                    int index = mCustomerEmailList.IndexOf(oldAddress);
                    if (index >= 0)
                        mCustomerEmailList[index] = newAddress;
                }
            }
        }
    }
}
