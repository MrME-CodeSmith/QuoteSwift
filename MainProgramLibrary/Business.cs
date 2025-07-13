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
            BusinessAddressList = b.mBusinessAddressList;
            BusinessPOBoxAddressList = b.mBusinessPOBoxAddressList;
            BusinessLegalDetails = b.mBusinessLegalDetails;
            BusinessTelephoneNumberList = b.mBusinessTelephoneNumberList;
            BusinessCellphoneNumberList = b.mBusinessCellphoneNumberList;
            BusinessEmailAddressList = b.mBusinessEmailAddressList;
            BusinessCustomerList = b.mBusinessCustomerList;

            mAddressMap = new Dictionary<string, Address>(b.mAddressMap);
            mPOBoxMap = new Dictionary<string, Address>(b.mPOBoxMap);
            mTelephoneNumbers = new HashSet<string>(b.mTelephoneNumbers);
            mCellphoneNumbers = new HashSet<string>(b.mCellphoneNumbers);
            mEmailAddresses = new HashSet<string>(b.mEmailAddresses);
            mCustomerMap = new Dictionary<string, Customer>(b.mCustomerMap);
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
        public BindingList<Address> BusinessAddressList
        {
            get => mBusinessAddressList;
            set
            {
                mBusinessAddressList = value;
                mAddressMap?.Clear();
                if (mBusinessAddressList != null)
                    foreach (var a in mBusinessAddressList)
                        mAddressMap[StringUtil.NormalizeKey(a.AddressDescription)] = a;
            }
        }
        public BindingList<Address> BusinessPOBoxAddressList
        {
            get => mBusinessPOBoxAddressList;
            set
            {
                mBusinessPOBoxAddressList = value;
                mPOBoxMap?.Clear();
                if (mBusinessPOBoxAddressList != null)
                    foreach (var a in mBusinessPOBoxAddressList)
                        mPOBoxMap[StringUtil.NormalizeKey(a.AddressDescription)] = a;
            }
        }
        public Legal BusinessLegalDetails { get => mBusinessLegalDetails; set => mBusinessLegalDetails = value; }
        public BindingList<string> BusinessTelephoneNumberList
        {
            get => mBusinessTelephoneNumberList;
            set
            {
                mBusinessTelephoneNumberList = value;
                mTelephoneNumbers?.Clear();
                if (mBusinessTelephoneNumberList != null)
                    foreach (var n in mBusinessTelephoneNumberList)
                        mTelephoneNumbers.Add(n);
            }
        }
        public BindingList<string> BusinessCellphoneNumberList
        {
            get => mBusinessCellphoneNumberList;
            set
            {
                mBusinessCellphoneNumberList = value;
                mCellphoneNumbers?.Clear();
                if (mBusinessCellphoneNumberList != null)
                    foreach (var n in mBusinessCellphoneNumberList)
                        mCellphoneNumbers.Add(n);
            }
        }
        public BindingList<string> BusinessEmailAddressList
        {
            get => mBusinessEmailAddressList;
            set
            {
                mBusinessEmailAddressList = value;
                mEmailAddresses?.Clear();
                if (mBusinessEmailAddressList != null)
                    foreach (var e in mBusinessEmailAddressList)
                        mEmailAddresses.Add(e);
            }
        }
        public BindingList<Customer> BusinessCustomerList
        {
            get => mBusinessCustomerList;
            set
            {
                mBusinessCustomerList = value;
                mCustomerMap?.Clear();
                if (mBusinessCustomerList != null)
                    foreach (var c in mBusinessCustomerList)
                        mCustomerMap[c.CustomerCompanyName] = c;
            }
        }
        public Dictionary<string, Address> AddressMap => mAddressMap;
        public Dictionary<string, Address> POBoxMap => mPOBoxMap;
        public HashSet<string> TelephoneNumbers => mTelephoneNumbers;
        public HashSet<string> CellphoneNumbers => mCellphoneNumbers;
        public HashSet<string> EmailAddresses => mEmailAddresses;
        public Dictionary<string, Customer> CustomerMap => mCustomerMap;

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
