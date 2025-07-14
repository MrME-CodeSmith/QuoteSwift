using System.ComponentModel;
using System.Collections.Generic;

namespace QuoteSwift
{
    public class Business
    {
        private string mBusinessName;
        private string mBusinessExtraInformation;
        private BindingList<Address> mBusinessAddressList;
        private BindingList<Address> mBusinessPOBoxAddressList;
        private Legal mBusinessLegalDetails;
        private BindingList<string> mBusinessTelephoneNumberList;
        private BindingList<string> mBusinessCellphoneNumberList;
        private BindingList<string> mBusinessEmailAddressList;
        private BindingList<Customer> mBusinessCustomerList;

        // lookup collections for quick searches and duplicate checks
        private Dictionary<string, Address> mAddressMap;
        private Dictionary<string, Address> mPOBoxMap;
        private HashSet<string> mTelephoneNumbers;
        private HashSet<string> mCellphoneNumbers;
        private HashSet<string> mEmailAddresses;
        private Dictionary<string, Customer> mCustomerMap;

        //Default Constructor
        public Business()
        {
            BusinessName = "";
            BusinessExtraInformation = "";
            BusinessAddressList = new BindingList<Address>();
            BusinessPOBoxAddressList = new BindingList<Address>();
            BusinessLegalDetails = null;
            BusinessTelephoneNumberList = new BindingList<string>();
            BusinessCellphoneNumberList = new BindingList<string>();
            BusinessEmailAddressList = new BindingList<string>();
            BusinessCustomerList = new BindingList<Customer>();

            mAddressMap = new Dictionary<string, Address>();
            mPOBoxMap = new Dictionary<string, Address>();
            mTelephoneNumbers = new HashSet<string>();
            mCellphoneNumbers = new HashSet<string>();
            mEmailAddresses = new HashSet<string>();
            mCustomerMap = new Dictionary<string, Customer>();
        }

        // Copy Constructor

        public Business(Business b)
        {
            BusinessName = b.mBusinessName;
            BusinessExtraInformation = b.mBusinessExtraInformation;

            if (b.mBusinessAddressList != null)
            {
                BusinessAddressList = new BindingList<Address>();
                foreach (var a in b.mBusinessAddressList)
                    BusinessAddressList.Add(new Address(a));
            }
            else
            {
                BusinessAddressList = null;
            }

            if (b.mBusinessPOBoxAddressList != null)
            {
                BusinessPOBoxAddressList = new BindingList<Address>();
                foreach (var a in b.mBusinessPOBoxAddressList)
                    BusinessPOBoxAddressList.Add(new Address(a));
            }
            else
            {
                BusinessPOBoxAddressList = null;
            }

            BusinessLegalDetails = b.mBusinessLegalDetails != null
                ? new Legal(b.mBusinessLegalDetails.RegistrationNumber, b.mBusinessLegalDetails.VatNumber)
                : null;

            if (b.mBusinessTelephoneNumberList != null)
            {
                BusinessTelephoneNumberList = new BindingList<string>();
                foreach (var n in b.mBusinessTelephoneNumberList)
                    BusinessTelephoneNumberList.Add(n);
            }
            else
            {
                BusinessTelephoneNumberList = null;
            }

            if (b.mBusinessCellphoneNumberList != null)
            {
                BusinessCellphoneNumberList = new BindingList<string>();
                foreach (var n in b.mBusinessCellphoneNumberList)
                    BusinessCellphoneNumberList.Add(n);
            }
            else
            {
                BusinessCellphoneNumberList = null;
            }

            if (b.mBusinessEmailAddressList != null)
            {
                BusinessEmailAddressList = new BindingList<string>();
                foreach (var e in b.mBusinessEmailAddressList)
                    BusinessEmailAddressList.Add(e);
            }
            else
            {
                BusinessEmailAddressList = null;
            }

            if (b.mBusinessCustomerList != null)
            {
                BusinessCustomerList = new BindingList<Customer>();
                foreach (var c in b.mBusinessCustomerList)
                    BusinessCustomerList.Add(new Customer(c));
            }
            else
            {
                BusinessCustomerList = null;
            }

            mAddressMap = new Dictionary<string, Address>();
            if (mBusinessAddressList != null)
                foreach (var a in mBusinessAddressList)
                    mAddressMap[StringUtil.NormalizeKey(a.AddressDescription)] = a;

            mPOBoxMap = new Dictionary<string, Address>();
            if (mBusinessPOBoxAddressList != null)
                foreach (var a in mBusinessPOBoxAddressList)
                    mPOBoxMap[StringUtil.NormalizeKey(a.AddressDescription)] = a;

            mTelephoneNumbers = new HashSet<string>(mBusinessTelephoneNumberList ?? new BindingList<string>());
            mCellphoneNumbers = new HashSet<string>(mBusinessCellphoneNumberList ?? new BindingList<string>());
            mEmailAddresses = new HashSet<string>(mBusinessEmailAddressList ?? new BindingList<string>());

            mCustomerMap = new Dictionary<string, Customer>();
            if (mBusinessCustomerList != null)
                foreach (var c in mBusinessCustomerList)
                    mCustomerMap[c.CustomerCompanyName] = c;
        }


        public Business(string mBusinessName, string mBusinessExtraInformation, BindingList<Address> mBusinessAddressList, BindingList<Address> mBusinessPOBoxAddressList,
            Legal mBusinessLegalDetails, BindingList<string> mBusinessTelephoneNumberList, BindingList<string> mBusinessCellphoneNumberList,
            BindingList<string> mBusinessEmailAddressList, BindingList<Customer> mBusinessCustomerList)
        {
            BusinessName = mBusinessName;
            BusinessExtraInformation = mBusinessExtraInformation;
            BusinessAddressList = mBusinessAddressList;
            BusinessPOBoxAddressList = mBusinessPOBoxAddressList;
            BusinessLegalDetails = mBusinessLegalDetails;
            BusinessTelephoneNumberList = mBusinessTelephoneNumberList;
            BusinessCellphoneNumberList = mBusinessCellphoneNumberList;
            BusinessEmailAddressList = mBusinessEmailAddressList;
            BusinessCustomerList = mBusinessCustomerList;

            mAddressMap = new Dictionary<string, Address>();
            if (mBusinessAddressList != null)
                foreach (var a in mBusinessAddressList)
                    mAddressMap[StringUtil.NormalizeKey(a.AddressDescription)] = a;

            mPOBoxMap = new Dictionary<string, Address>();
            if (mBusinessPOBoxAddressList != null)
                foreach (var a in mBusinessPOBoxAddressList)
                    mPOBoxMap[StringUtil.NormalizeKey(a.AddressDescription)] = a;

            mTelephoneNumbers = new HashSet<string>(mBusinessTelephoneNumberList ?? new BindingList<string>());
            mCellphoneNumbers = new HashSet<string>(mBusinessCellphoneNumberList ?? new BindingList<string>());
            mEmailAddresses = new HashSet<string>(mBusinessEmailAddressList ?? new BindingList<string>());

            mCustomerMap = new Dictionary<string, Customer>();
            if (mBusinessCustomerList != null)
                foreach (var c in mBusinessCustomerList)
                    mCustomerMap[c.CustomerCompanyName] = c;
        }

        public string BusinessName { get => mBusinessName; set => mBusinessName = value; }
        public string BusinessExtraInformation { get => mBusinessExtraInformation; set => mBusinessExtraInformation = value; }
        public IReadOnlyList<Address> BusinessAddressList => mBusinessAddressList;
        public IReadOnlyList<Address> BusinessPOBoxAddressList => mBusinessPOBoxAddressList;
        public Legal BusinessLegalDetails { get => mBusinessLegalDetails; set => mBusinessLegalDetails = value; }
        public IReadOnlyList<string> BusinessTelephoneNumberList => mBusinessTelephoneNumberList;
        public IReadOnlyList<string> BusinessCellphoneNumberList => mBusinessCellphoneNumberList;
        public IReadOnlyList<string> BusinessEmailAddressList => mBusinessEmailAddressList;
        public IReadOnlyList<Customer> BusinessCustomerList => mBusinessCustomerList;
        public Dictionary<string, Address> AddressMap => mAddressMap;
        public Dictionary<string, Address> POBoxMap => mPOBoxMap;
        public HashSet<string> TelephoneNumbers => mTelephoneNumbers;
        public HashSet<string> CellphoneNumbers => mCellphoneNumbers;
        public HashSet<string> EmailAddresses => mEmailAddresses;
        public Dictionary<string, Customer> CustomerMap => mCustomerMap;

        // helper methods to manage addresses and customers while keeping
        // the lookup collections in sync
        public void AddAddress(Address address)
        {
            if (address == null) return;
            if (mBusinessAddressList == null)
                mBusinessAddressList = new BindingList<Address>();
            mBusinessAddressList.Add(address);
            mAddressMap[StringUtil.NormalizeKey(address.AddressDescription)] = address;
        }

        public void RemoveAddress(Address address)
        {
            if (address == null) return;
            if (mBusinessAddressList != null && mBusinessAddressList.Remove(address))
            {
                mAddressMap.Remove(StringUtil.NormalizeKey(address.AddressDescription));
                if (mBusinessAddressList.Count == 0)
                    mBusinessAddressList = null;
            }
        }

        public void UpdateAddress(Address original, Address updated)
        {
            if (original == null || updated == null) return;
            if (mBusinessAddressList != null)
            {
                int index = mBusinessAddressList.IndexOf(original);
                if (index >= 0)
                {
                    mBusinessAddressList[index] = updated;
                    mAddressMap.Remove(StringUtil.NormalizeKey(original.AddressDescription));
                    mAddressMap[StringUtil.NormalizeKey(updated.AddressDescription)] = updated;
                }
            }
        }

        public void AddPOBoxAddress(Address address)
        {
            if (address == null) return;
            if (mBusinessPOBoxAddressList == null)
                mBusinessPOBoxAddressList = new BindingList<Address>();
            mBusinessPOBoxAddressList.Add(address);
            mPOBoxMap[StringUtil.NormalizeKey(address.AddressDescription)] = address;
        }

        public void RemovePOBoxAddress(Address address)
        {
            if (address == null) return;
            if (mBusinessPOBoxAddressList != null && mBusinessPOBoxAddressList.Remove(address))
            {
                mPOBoxMap.Remove(StringUtil.NormalizeKey(address.AddressDescription));
                if (mBusinessPOBoxAddressList.Count == 0)
                    mBusinessPOBoxAddressList = null;
            }
        }

        public void UpdatePOBoxAddress(Address original, Address updated)
        {
            if (original == null || updated == null) return;
            if (mBusinessPOBoxAddressList != null)
            {
                int index = mBusinessPOBoxAddressList.IndexOf(original);
                if (index >= 0)
                {
                    mBusinessPOBoxAddressList[index] = updated;
                    mPOBoxMap.Remove(StringUtil.NormalizeKey(original.AddressDescription));
                    mPOBoxMap[StringUtil.NormalizeKey(updated.AddressDescription)] = updated;
                }
            }
        }

        public void AddCustomer(Customer customer)
        {
            if (customer == null) return;
            if (mBusinessCustomerList == null)
                mBusinessCustomerList = new BindingList<Customer>();
            mBusinessCustomerList.Add(customer);
            mCustomerMap[customer.CustomerCompanyName] = customer;
        }

        public void RemoveCustomer(Customer customer)
        {
            if (customer == null) return;
            if (mBusinessCustomerList != null && mBusinessCustomerList.Remove(customer))
            {
                mCustomerMap.Remove(customer.CustomerCompanyName);
                if (mBusinessCustomerList.Count == 0)
                    mBusinessCustomerList = null;
            }
        }

        public void UpdateCustomer(Customer original, Customer updated)
        {
            if (original == null || updated == null) return;
            if (mBusinessCustomerList != null)
            {
                int index = mBusinessCustomerList.IndexOf(original);
                if (index >= 0)
                {
                    mBusinessCustomerList[index] = updated;
                    mCustomerMap.Remove(original.CustomerCompanyName);
                    mCustomerMap[updated.CustomerCompanyName] = updated;
                }
            }
        }

        // helper methods to manage phone numbers and emails while keeping
        // the lookup collections in sync
        public void AddTelephoneNumber(string number)
        {
            if (string.IsNullOrWhiteSpace(number)) return;
            if (mBusinessTelephoneNumberList == null)
                mBusinessTelephoneNumberList = new BindingList<string>();
            if (mTelephoneNumbers.Add(number))
                mBusinessTelephoneNumberList.Add(number);
        }

        public void RemoveTelephoneNumber(string number)
        {
            if (string.IsNullOrWhiteSpace(number)) return;
            if (mTelephoneNumbers.Remove(number))
            {
                mBusinessTelephoneNumberList?.Remove(number);
                if (mBusinessTelephoneNumberList != null && mBusinessTelephoneNumberList.Count == 0)
                    mBusinessTelephoneNumberList = null;
            }
        }

        public void UpdateTelephoneNumber(string oldNumber, string newNumber)
        {
            if (string.IsNullOrWhiteSpace(oldNumber) || string.IsNullOrWhiteSpace(newNumber)) return;
            if (mTelephoneNumbers.Remove(oldNumber))
            {
                mTelephoneNumbers.Add(newNumber);
                if (mBusinessTelephoneNumberList != null)
                {
                    int index = mBusinessTelephoneNumberList.IndexOf(oldNumber);
                    if (index >= 0)
                        mBusinessTelephoneNumberList[index] = newNumber;
                }
            }
        }

        public void AddCellphoneNumber(string number)
        {
            if (string.IsNullOrWhiteSpace(number)) return;
            if (mBusinessCellphoneNumberList == null)
                mBusinessCellphoneNumberList = new BindingList<string>();
            if (mCellphoneNumbers.Add(number))
                mBusinessCellphoneNumberList.Add(number);
        }

        public void RemoveCellphoneNumber(string number)
        {
            if (string.IsNullOrWhiteSpace(number)) return;
            if (mCellphoneNumbers.Remove(number))
            {
                mBusinessCellphoneNumberList?.Remove(number);
                if (mBusinessCellphoneNumberList != null && mBusinessCellphoneNumberList.Count == 0)
                    mBusinessCellphoneNumberList = null;
            }
        }

        public void UpdateCellphoneNumber(string oldNumber, string newNumber)
        {
            if (string.IsNullOrWhiteSpace(oldNumber) || string.IsNullOrWhiteSpace(newNumber)) return;
            if (mCellphoneNumbers.Remove(oldNumber))
            {
                mCellphoneNumbers.Add(newNumber);
                if (mBusinessCellphoneNumberList != null)
                {
                    int index = mBusinessCellphoneNumberList.IndexOf(oldNumber);
                    if (index >= 0)
                        mBusinessCellphoneNumberList[index] = newNumber;
                }
            }
        }

        public void AddEmailAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address)) return;
            if (mBusinessEmailAddressList == null)
                mBusinessEmailAddressList = new BindingList<string>();
            if (mEmailAddresses.Add(address))
                mBusinessEmailAddressList.Add(address);
        }

        public void RemoveEmailAddress(string address)
        {
            if (string.IsNullOrWhiteSpace(address)) return;
            if (mEmailAddresses.Remove(address))
            {
                mBusinessEmailAddressList?.Remove(address);
                if (mBusinessEmailAddressList != null && mBusinessEmailAddressList.Count == 0)
                    mBusinessEmailAddressList = null;
            }
        }

        public void UpdateEmailAddress(string oldAddress, string newAddress)
        {
            if (string.IsNullOrWhiteSpace(oldAddress) || string.IsNullOrWhiteSpace(newAddress)) return;
            if (mEmailAddresses.Remove(oldAddress))
            {
                mEmailAddresses.Add(newAddress);
                if (mBusinessEmailAddressList != null)
                {
                    int index = mBusinessEmailAddressList.IndexOf(oldAddress);
                    if (index >= 0)
                        mBusinessEmailAddressList[index] = newAddress;
                }
            }
        }
    }
}
