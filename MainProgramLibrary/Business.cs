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
                    mAddressMap[a.AddressDescription] = a;

            mPOBoxMap = new Dictionary<string, Address>();
            if (mBusinessPOBoxAddressList != null)
                foreach (var a in mBusinessPOBoxAddressList)
                    mPOBoxMap[a.AddressDescription] = a;

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
                        mAddressMap[a.AddressDescription] = a;
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
                        mPOBoxMap[a.AddressDescription] = a;
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
    }
}
