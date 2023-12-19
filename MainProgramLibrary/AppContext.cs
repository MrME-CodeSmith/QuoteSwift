using ProtoBuf;
using System.Collections.Generic;
using System.ComponentModel;


namespace QuoteSwift
{
    public static class Global
    {
        public static AppContext Context { get; private set; }

        public static void InitializeContext()
        {
            Context = new AppContext(
                new Dictionary<string, Quote>(), 
                new BindingList<Business>(),
                new BindingList<Product>(), 
                new BindingList<Part>(), 
                new BindingList<Part>()
             );
        }
    }

    [ProtoContract(SkipConstructor = true)]
    public class AppContext
    {
        private Dictionary<string, Quote> mPassQuoteList;
        private Dictionary<string, Business> mPassBusinessList;
        private Dictionary<string, Product> mPassPumpList;
        private Dictionary<string, Part> mPassMandatoryPartList;
        private Dictionary<string, Part> mPassNonMandatoryPartList;
        private Business mBusinessToChange = null; //In the event that a Business' information needs to be changed
        private Customer mCustomerToChange = null; //In the event that a Customer's information needs to be changed
        private Quote mQuoteTOChange = null; //In the event that a Quote's information needs to be changed
        private Product mPumpToChange = null; //In the event that a Pump's information needs to be changed
        private Part mPartToChange = null; //In the event that a Part's information needs to be changed
        private Address mAddressToChange = null;//In the event that an Address needs to be changed
        private string mEmailToChange = ""; //In the event that an Email needs to be changed.
        private string mPhoneNumberToChange = "";//In the event that a Phone number needs to be changed.
        private bool mChangeSpecificObject = false; //To determine whether object should be viewed or changed


        //Pass All Constructor :

        public AppContext(
            Dictionary<string, Quote> mPassQuoteMap, 
            Dictionary<string, Business> mPassBusinessMap, 
            Dictionary<string, Product> mPassPumpMap, 
            Dictionary<string, Part> mPassMandatoryPartMap,
            Dictionary<string, Part> mPassNonMandatoryPartMap
        ){
            QuoteMap = mPassQuoteMap;
            BusinessMap = mPassBusinessMap;
            ProductMap = mPassPumpMap;
            MandatoryPartMap = mPassMandatoryPartMap;
            NonMandatoryPartMap = mPassNonMandatoryPartMap;
        }

        //Pass Quote Constructor:

        public AppContext(
            Dictionary<string, Quote> mPassQuoteMap,
            Dictionary<string, Business> mPassBusinessMap,
            Dictionary<string, Product> mPassPumpMap,
            Dictionary<string, Part> mPassMandatoryPartMap,
            Dictionary<string, Part> mPassNonMandatoryPartMap,
            ref Quote mQuoteTOChange, 
            bool mChangeSpecificObject = false
        ){
            QuoteMap = mPassQuoteMap;
            BusinessMap = mPassBusinessMap;
            ProductMap = mPassPumpMap;
            MandatoryPartMap = mPassMandatoryPartMap;
            NonMandatoryPartMap = mPassNonMandatoryPartMap;
            QuoteTOChange = mQuoteTOChange;
            ChangeSpecificObject = mChangeSpecificObject;
        }

        //Pass Business Constructor:

        public AppContext(
            Dictionary<string, Quote> mPassQuoteMap,
            Dictionary<string, Business> mPassBusinessMap,
            Dictionary<string, Product> mPassPumpMap,
            Dictionary<string, Part> mPassMandatoryPartMap,
            Dictionary<string, Part> mPassNonMandatoryPartMap,
            ref Business mBusinessToChange, 
            bool mChangeSpecificObject = false
        ){
            QuoteMap = mPassQuoteMap;
            BusinessMap = mPassBusinessMap;
            ProductMap = mPassPumpMap;
            MandatoryPartMap = mPassMandatoryPartMap;
            NonMandatoryPartMap = mPassNonMandatoryPartMap;
            BusinessToChange = mBusinessToChange;
            ChangeSpecificObject = mChangeSpecificObject;
        }

        //Pass Customer Constructor:

        public AppContext(
            Dictionary<string, Quote> mPassQuoteMap,
            Dictionary<string, Business> mPassBusinessMap,
            Dictionary<string, Product> mPassPumpMap,
            Dictionary<string, Part> mPassMandatoryPartMap,
            Dictionary<string, Part> mPassNonMandatoryPartMap,
            ref Customer mCustomerToChange, 
            bool mChangeSpecificObject = false
        ){
            QuoteMap = mPassQuoteMap;
            BusinessMap = mPassBusinessMap;
            ProductMap = mPassPumpMap;
            MandatoryPartMap = mPassMandatoryPartMap;
            NonMandatoryPartMap = mPassNonMandatoryPartMap;
            CustomerToChange = mCustomerToChange;
            ChangeSpecificObject = mChangeSpecificObject;
        }

        //Pass Pump Constructor:

        public AppContext(
            Dictionary<string, Quote> mPassQuoteMap,
            Dictionary<string, Business> mPassBusinessMap,
            Dictionary<string, Product> mPassPumpMap,
            Dictionary<string, Part> mPassMandatoryPartMap,
            Dictionary<string, Part> mPassNonMandatoryPartMap,
            ref Product mPumpToChange, 
            bool mChangeSpecificObject = false
        ){
            QuoteMap = mPassQuoteMap;
            BusinessMap = mPassBusinessMap;
            ProductMap = mPassPumpMap;
            MandatoryPartMap = mPassMandatoryPartMap;
            NonMandatoryPartMap = mPassNonMandatoryPartMap;
            PumpToChange = mPumpToChange;
            ChangeSpecificObject = mChangeSpecificObject;
        }

        //Pass Part Constructor:

        public AppContext(
            Dictionary<string, Quote> mPassQuoteMap,
            Dictionary<string, Business> mPassBusinessMap,
            Dictionary<string, Product> mPassPumpMap,
            Dictionary<string, Part> mPassMandatoryPartMap,
            Dictionary<string, Part> mPassNonMandatoryPartMap,
            ref Part mPartToChange, 
            bool mChangeSpecificObject = false
        ){
            QuoteMap = mPassQuoteMap;
            BusinessMap = mPassBusinessMap;
            ProductMap = mPassPumpMap;
            MandatoryPartMap = mPassMandatoryPartMap;
            NonMandatoryPartMap = mPassNonMandatoryPartMap;
            PartToChange = mPartToChange;
            ChangeSpecificObject = mChangeSpecificObject;
        }

        public Dictionary<string, Quote> QuoteMap { get => mPassQuoteList; set => mPassQuoteList = value; }
        public Dictionary<string, Business> BusinessMap { get => mPassBusinessList; set => mPassBusinessList = value; }
        public Dictionary<string, Product> ProductMap { get => mPassPumpList; set => mPassPumpList = value; }
        public Dictionary<string, Part> MandatoryPartMap { get => mPassMandatoryPartList; set => mPassMandatoryPartList = value; }
        public Dictionary<string, Part> NonMandatoryPartMap { get => mPassNonMandatoryPartList; set => mPassNonMandatoryPartList = value; }
        public Business BusinessToChange { get => mBusinessToChange; set => mBusinessToChange = value; }
        public Customer CustomerToChange { get => mCustomerToChange; set => mCustomerToChange = value; }
        public Quote QuoteTOChange { get => mQuoteTOChange; set => mQuoteTOChange = value; }
        public bool ChangeSpecificObject { get => mChangeSpecificObject; set => mChangeSpecificObject = value; }
        public Product PumpToChange { get => mPumpToChange; set => mPumpToChange = value; }
        public Part PartToChange { get => mPartToChange; set => mPartToChange = value; }
        public Address AddressToChange { get => mAddressToChange; set => mAddressToChange = value; }
        public string EmailToChange { get => mEmailToChange; set => mEmailToChange = value; }
        public string PhoneNumberToChange { get => mPhoneNumberToChange; set => mPhoneNumberToChange = value; }
    }
}
