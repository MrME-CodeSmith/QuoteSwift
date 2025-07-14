using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;


namespace QuoteSwift
{
    public class Pass
    {
        private SortedDictionary<string, Quote> mPassQuoteMap;
        private BindingList<Business> mPassBusinessList;
        private BindingList<Pump> mPassPumpList;
        // dictionaries for parts keyed by original part number
        private Dictionary<string, Part> mPassPartList;
        // lookup dictionary for part new numbers
        private Dictionary<string, Part> mNewPartMap = new Dictionary<string, Part>();

        // lookup collections for businesses
        private Dictionary<string, Business> mBusinessLookup = new Dictionary<string, Business>();
        private HashSet<string> mBusinessVatNumbers = new HashSet<string>();
        private HashSet<string> mBusinessRegNumbers = new HashSet<string>();
        private HashSet<string> mRepairableItemNames = new HashSet<string>();
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

        public Pass(SortedDictionary<string, Quote> quoteMap, BindingList<Business> mPassBusinessList, BindingList<Pump> mPassPumpList, Dictionary<string, Part> partList)
        {
            PassQuoteMap = quoteMap;
            PassBusinessList = mPassBusinessList;
            PassPumpList = mPassPumpList;
            PassPartList = partList;
        }

        public SortedDictionary<string, Quote> PassQuoteMap { get => mPassQuoteMap; set => mPassQuoteMap = value; }
        public BindingList<Business> PassBusinessList
        {
            get => mPassBusinessList;
            set
            {
                mPassBusinessList = value;
                SyncBusinessLookup();
            }
        }
        public BindingList<Pump> PassPumpList
        {
            get => mPassPumpList;
            set
            {
                mPassPumpList = value;
                SyncRepairableItemLookup();
            }
        }
        public Business BusinessToChange { get => mBusinessToChange; set => mBusinessToChange = value; }
        public Customer CustomerToChange { get => mCustomerToChange; set => mCustomerToChange = value; }
        public Quote QuoteTOChange { get => mQuoteTOChange; set => mQuoteTOChange = value; }
        public bool ChangeSpecificObject { get => mChangeSpecificObject; set => mChangeSpecificObject = value; }
        public Pump PumpToChange { get => mPumpToChange; set => mPumpToChange = value; }
        public Part PartToChange { get => mPartToChange; set => mPartToChange = value; }
        public Dictionary<string, Part> PassPartList
        {
            get => mPassPartList;
            set
            {
                mPassPartList = value;
                SyncPartLookup();
            }
        }

        public IEnumerable<Part> MandatoryParts => mPassPartList?.Values?.Where(p => p.MandatoryPart);
        public IEnumerable<Part> NonMandatoryParts => mPassPartList?.Values?.Where(p => !p.MandatoryPart);
        public Address AddressToChange { get => mAddressToChange; set => mAddressToChange = value; }
        public string EmailToChange { get => mEmailToChange; set => mEmailToChange = value; }
        public string PhoneNumberToChange { get => mPhoneNumberToChange; set => mPhoneNumberToChange = value; }

        public Dictionary<string, Business> BusinessLookup => mBusinessLookup;
        public HashSet<string> BusinessVatNumbers => mBusinessVatNumbers;
        public HashSet<string> BusinessRegNumbers => mBusinessRegNumbers;
        public HashSet<string> RepairableItemNames => mRepairableItemNames;

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

        private void SyncRepairableItemLookup()
        {
            mRepairableItemNames.Clear();
            if (mPassPumpList != null)
            {
                foreach (var p in mPassPumpList)
                {
                    mRepairableItemNames.Add(StringUtil.NormalizeKey(p.PumpName));
                }
            }
        }

        private void SyncPartLookup()
        {
            mNewPartMap.Clear();
            if (mPassPartList != null)
            {
                foreach (var p in mPassPartList.Values)
                    mNewPartMap[StringUtil.NormalizeKey(p.NewPartNumber)] = p;
            }
        }

        public void AddPart(Part part)
        {
            if (part == null) return;
            if (mPassPartList == null) mPassPartList = new Dictionary<string, Part>();
            string origKey = StringUtil.NormalizeKey(part.OriginalItemPartNumber);
            mPassPartList[origKey] = part;
            mNewPartMap[StringUtil.NormalizeKey(part.NewPartNumber)] = part;
        }

        public void RemovePart(Part part)
        {
            if (part == null || mPassPartList == null) return;
            mPassPartList.Remove(StringUtil.NormalizeKey(part.OriginalItemPartNumber));
            mNewPartMap.Remove(StringUtil.NormalizeKey(part.NewPartNumber));
        }

        public bool TryGetPartByNew(string newNumber, out Part part)
        {
            return mNewPartMap.TryGetValue(StringUtil.NormalizeKey(newNumber), out part);
        }

    }
}
