using System.ComponentModel;
using System.Collections.Generic;

namespace QuoteSwift
{
    public class Customer : ObservableObject
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
            mCustomerPOBoxAddress = new BindingList<Address>();
            mCustomerDeliveryAddressList = new BindingList<Address>();
            CustomerLegalDetails = null;
            mCustomerTelephoneNumberList = new BindingList<string>();
            mCustomerCellphoneNumberList = new BindingList<string>();
            mCustomerEmailList = new BindingList<string>();
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
                mCustomerPOBoxAddress = new BindingList<Address>();
                foreach (var a in c.mCustomerPOBoxAddress)
                    mCustomerPOBoxAddress.Add(new Address(a));
            }
            else
            {
                mCustomerPOBoxAddress = null;
            }

            if (c.mCustomerDeliveryAddressList != null)
            {
                mCustomerDeliveryAddressList = new BindingList<Address>();
                foreach (var a in c.mCustomerDeliveryAddressList)
                    mCustomerDeliveryAddressList.Add(new Address(a));
            }
            else
            {
                mCustomerDeliveryAddressList = null;
            }

            CustomerLegalDetails = c.mCustomerLegalDetails != null
                ? new Legal(c.mCustomerLegalDetails.RegistrationNumber, c.mCustomerLegalDetails.VatNumber)
                : null;

            if (c.mCustomerTelephoneNumberList != null)
            {
                mCustomerTelephoneNumberList = new BindingList<string>();
                foreach (var n in c.mCustomerTelephoneNumberList)
                    mCustomerTelephoneNumberList.Add(n);
            }
            else
            {
                mCustomerTelephoneNumberList = null;
            }

            if (c.mCustomerCellphoneNumberList != null)
            {
                mCustomerCellphoneNumberList = new BindingList<string>();
                foreach (var n in c.mCustomerCellphoneNumberList)
                    mCustomerCellphoneNumberList.Add(n);
            }
            else
            {
                mCustomerCellphoneNumberList = null;
            }

            if (c.mCustomerEmailList != null)
            {
                mCustomerEmailList = new BindingList<string>();
                foreach (var e in c.mCustomerEmailList)
                    mCustomerEmailList.Add(e);
            }
            else
            {
                mCustomerEmailList = null;
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


        public string CustomerName
        {
            get => mCustomerName;
            set => SetProperty(ref mCustomerName, value);
        }

        public string CustomerCompanyName
        {
            get => mCustomerCompanyName;
            set => SetProperty(ref mCustomerCompanyName, value);
        }
        public IReadOnlyList<Address> CustomerPOBoxAddress => mCustomerPOBoxAddress;
        public IReadOnlyList<Address> CustomerDeliveryAddressList => mCustomerDeliveryAddressList;
        public Legal CustomerLegalDetails
        {
            get => mCustomerLegalDetails;
            set => SetProperty(ref mCustomerLegalDetails, value);
        }
        public IReadOnlyList<string> CustomerTelephoneNumberList => mCustomerTelephoneNumberList;
        public IReadOnlyList<string> CustomerCellphoneNumberList => mCustomerCellphoneNumberList;
        public IReadOnlyList<string> CustomerEmailList => mCustomerEmailList;
        public string VendorNumber
        {
            get => mVendorNumber;
            set => SetProperty(ref mVendorNumber, value);
        }
        public Dictionary<string, Address> DeliveryAddressMap => mDeliveryAddressMap;
        public Dictionary<string, Address> POBoxMap => mPOBoxMap;
        public HashSet<string> TelephoneNumbers => mTelephoneNumbers;
        public HashSet<string> CellphoneNumbers => mCellphoneNumbers;
        public HashSet<string> EmailAddresses => mEmailAddresses;

        // helper methods to manage addresses while keeping the lookup collections in sync
        public void AddDeliveryAddress(Address address)
        {
            if (address == null) return;
            if (mCustomerDeliveryAddressList == null)
                mCustomerDeliveryAddressList = new BindingList<Address>();
            mCustomerDeliveryAddressList.Add(address);
            mDeliveryAddressMap[StringUtil.NormalizeKey(address.AddressDescription)] = address;
        }

        public void RemoveDeliveryAddress(Address address)
        {
            if (address == null) return;
            if (mCustomerDeliveryAddressList != null && mCustomerDeliveryAddressList.Remove(address))
            {
                mDeliveryAddressMap.Remove(StringUtil.NormalizeKey(address.AddressDescription));
                if (mCustomerDeliveryAddressList.Count == 0)
                    mCustomerDeliveryAddressList = null;
            }
        }

        public void UpdateDeliveryAddress(Address original, Address updated)
        {
            if (original == null || updated == null) return;
            if (mCustomerDeliveryAddressList != null)
            {
                int index = mCustomerDeliveryAddressList.IndexOf(original);
                if (index >= 0)
                {
                    mCustomerDeliveryAddressList[index] = updated;
                    mDeliveryAddressMap.Remove(StringUtil.NormalizeKey(original.AddressDescription));
                    mDeliveryAddressMap[StringUtil.NormalizeKey(updated.AddressDescription)] = updated;
                }
            }
        }

        public void AddPOBoxAddress(Address address)
        {
            if (address == null) return;
            if (mCustomerPOBoxAddress == null)
                mCustomerPOBoxAddress = new BindingList<Address>();
            mCustomerPOBoxAddress.Add(address);
            mPOBoxMap[StringUtil.NormalizeKey(address.AddressDescription)] = address;
        }

        public void RemovePOBoxAddress(Address address)
        {
            if (address == null) return;
            if (mCustomerPOBoxAddress != null && mCustomerPOBoxAddress.Remove(address))
            {
                mPOBoxMap.Remove(StringUtil.NormalizeKey(address.AddressDescription));
                if (mCustomerPOBoxAddress.Count == 0)
                    mCustomerPOBoxAddress = null;
            }
        }

        public void UpdatePOBoxAddress(Address original, Address updated)
        {
            if (original == null || updated == null) return;
            if (mCustomerPOBoxAddress != null)
            {
                int index = mCustomerPOBoxAddress.IndexOf(original);
                if (index >= 0)
                {
                    mCustomerPOBoxAddress[index] = updated;
                    mPOBoxMap.Remove(StringUtil.NormalizeKey(original.AddressDescription));
                    mPOBoxMap[StringUtil.NormalizeKey(updated.AddressDescription)] = updated;
                }
            }
        }

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
