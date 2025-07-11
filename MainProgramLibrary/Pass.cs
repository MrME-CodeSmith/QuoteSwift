using System.ComponentModel;
using System.Collections.Generic;


namespace QuoteSwift
{
    public class Pass
    {
        private SortedDictionary<string, Quote> mPassQuoteMap;
        private BindingList<Business> mPassBusinessList;
        private BindingList<Pump> mPassPumpList;
        private BindingList<Part> mPassMandatoryPartList;
        private BindingList<Part> mPassNonMandatoryPartList;

        // lookup collections for businesses
        private Dictionary<string, Business> mBusinessLookup = new Dictionary<string, Business>();
        private HashSet<string> mBusinessVatNumbers = new HashSet<string>();
        private HashSet<string> mBusinessRegNumbers = new HashSet<string>();
        private Business mBusinessToChange = null; //In the event that a Business' information needs to be changed
        private Customer mCustomerToChange = null; //In the event that a Customer's information needs to be changed
        private Quote mQuoteTOChange = null; //In the event that a Quote's information needs to be changed
        private Pump mPumpToChange = null; //In the event that a Pump's information needs to be changed
        private Part mPartToChange = null; //In the event that a Part's information needs to be changed
        private Address mAddressToChange = null;//In the event that an Address needs to be changed
        private string mEmailToChange = ""; //In the event that an Email needs to be changed.
        private string mPhoneNumberToChange = "";//In the event that a Phone number needs to be changed.
        private bool mChangeSpecificObject = false; //To determine whether object should be viewed or changed


        //Pass All Constructor :

        public Pass(SortedDictionary<string, Quote> quoteMap, BindingList<Business> mPassBusinessList, BindingList<Pump> mPassPumpList, BindingList<Part> mPassMandatoryPartList, BindingList<Part> mPassNonMandatoryPartList)
        {
            PassQuoteMap = quoteMap;
            PassBusinessList = mPassBusinessList;
            PassPumpList = mPassPumpList;
            PassMandatoryPartList = mPassMandatoryPartList;
            PassNonMandatoryPartList = mPassNonMandatoryPartList;
        }

        //Pass Quote Constructor:

        public Pass(SortedDictionary<string, Quote> quoteMap, BindingList<Business> mPassBusinessList, BindingList<Pump> mPassPumpList, BindingList<Part> mPassMandatoryPartList, BindingList<Part> mPassNonMandatoryPartList, ref Quote mQuoteTOChange, bool mChangeSpecificObject = false)
        {
            PassQuoteMap = quoteMap;
            PassBusinessList = mPassBusinessList;
            PassPumpList = mPassPumpList;
            PassMandatoryPartList = mPassMandatoryPartList;
            PassNonMandatoryPartList = mPassNonMandatoryPartList;
            QuoteTOChange = mQuoteTOChange;
            ChangeSpecificObject = mChangeSpecificObject;
        }

        //Pass Business Constructor:

        public Pass(SortedDictionary<string, Quote> quoteMap, BindingList<Business> mPassBusinessList, BindingList<Pump> mPassPumpList, BindingList<Part> mPassMandatoryPartList, BindingList<Part> mPassNonMandatoryPartList, ref Business mBusinessToChange, bool mChangeSpecificObject = false)
        {
            PassQuoteMap = quoteMap;
            PassBusinessList = mPassBusinessList;
            PassPumpList = mPassPumpList;
            PassMandatoryPartList = mPassMandatoryPartList;
            PassNonMandatoryPartList = mPassNonMandatoryPartList;
            BusinessToChange = mBusinessToChange;
            ChangeSpecificObject = mChangeSpecificObject;
        }

        //Pass Customer Constructor:

        public Pass(SortedDictionary<string, Quote> quoteMap, BindingList<Business> mPassBusinessList, BindingList<Pump> mPassPumpList, BindingList<Part> mPassMandatoryPartList, BindingList<Part> mPassNonMandatoryPartList, ref Customer mCustomerToChange, bool mChangeSpecificObject = false)
        {
            PassQuoteMap = quoteMap;
            PassBusinessList = mPassBusinessList;
            PassPumpList = mPassPumpList;
            PassMandatoryPartList = mPassMandatoryPartList;
            PassNonMandatoryPartList = mPassNonMandatoryPartList;
            CustomerToChange = mCustomerToChange;
            ChangeSpecificObject = mChangeSpecificObject;
        }

        //Pass Pump Constructor:

        public Pass(SortedDictionary<string, Quote> quoteMap, BindingList<Business> mPassBusinessList, BindingList<Pump> mPassPumpList, BindingList<Part> mPassMandatoryPartList, BindingList<Part> mPassNonMandatoryPartList, ref Pump mPumpToChange, bool mChangeSpecificObject = false)
        {
            PassQuoteMap = quoteMap;
            PassBusinessList = mPassBusinessList;
            PassPumpList = mPassPumpList;
            PassMandatoryPartList = mPassMandatoryPartList;
            PassNonMandatoryPartList = mPassNonMandatoryPartList;
            PumpToChange = mPumpToChange;
            ChangeSpecificObject = mChangeSpecificObject;
        }

        //Pass Part Constructor:

        public Pass(SortedDictionary<string, Quote> quoteMap, BindingList<Business> mPassBusinessList, BindingList<Pump> mPassPumpList, BindingList<Part> mPassMandatoryPartList, BindingList<Part> mPassNonMandatoryPartList, ref Part mPartToChange, bool mChangeSpecificObject = false)
        {
            PassQuoteMap = quoteMap;
            PassBusinessList = mPassBusinessList;
            PassPumpList = mPassPumpList;
            PassMandatoryPartList = mPassMandatoryPartList;
            PassNonMandatoryPartList = mPassNonMandatoryPartList;
            PartToChange = mPartToChange;
            ChangeSpecificObject = mChangeSpecificObject;
        }

        public SortedDictionary<string, Quote> PassQuoteMap { get => mPassQuoteMap; set => mPassQuoteMap = value; }
        public IEnumerable<Quote> PassQuoteList => mPassQuoteMap?.Values;
        public BindingList<Business> PassBusinessList
        {
            get => mPassBusinessList;
            set
            {
                mPassBusinessList = value;
                SyncBusinessLookup();
            }
        }
        public BindingList<Pump> PassPumpList { get => mPassPumpList; set => mPassPumpList = value; }
        public Business BusinessToChange { get => mBusinessToChange; set => mBusinessToChange = value; }
        public Customer CustomerToChange { get => mCustomerToChange; set => mCustomerToChange = value; }
        public Quote QuoteTOChange { get => mQuoteTOChange; set => mQuoteTOChange = value; }
        public bool ChangeSpecificObject { get => mChangeSpecificObject; set => mChangeSpecificObject = value; }
        public Pump PumpToChange { get => mPumpToChange; set => mPumpToChange = value; }
        public Part PartToChange { get => mPartToChange; set => mPartToChange = value; }
        public BindingList<Part> PassMandatoryPartList { get => mPassMandatoryPartList; set => mPassMandatoryPartList = value; }
        public BindingList<Part> PassNonMandatoryPartList { get => mPassNonMandatoryPartList; set => mPassNonMandatoryPartList = value; }
        public Address AddressToChange { get => mAddressToChange; set => mAddressToChange = value; }
        public string EmailToChange { get => mEmailToChange; set => mEmailToChange = value; }
        public string PhoneNumberToChange { get => mPhoneNumberToChange; set => mPhoneNumberToChange = value; }

        public Dictionary<string, Business> BusinessLookup => mBusinessLookup;
        public HashSet<string> BusinessVatNumbers => mBusinessVatNumbers;
        public HashSet<string> BusinessRegNumbers => mBusinessRegNumbers;

        private void SyncBusinessLookup()
        {
            mBusinessLookup.Clear();
            mBusinessVatNumbers.Clear();
            mBusinessRegNumbers.Clear();
            if (mPassBusinessList != null)
            {
                foreach (var b in mPassBusinessList)
                {
                    if (!mBusinessLookup.ContainsKey(b.BusinessName))
                        mBusinessLookup[b.BusinessName] = b;
                    mBusinessVatNumbers.Add(b.BusinessLegalDetails?.VatNumber);
                    mBusinessRegNumbers.Add(b.BusinessLegalDetails?.RegistrationNumber);
                }
            }
        }
    }
}
