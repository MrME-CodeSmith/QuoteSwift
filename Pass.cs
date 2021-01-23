using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace QuoteSwift
{
    [Serializable]
    public class Pass
    {
        private BindingList<Quote> mPassQuoteList;
        private BindingList<Business> mPassBusinessList;
        private BindingList<Pump> mPassPumpList;
        private BindingList<Part> mPassMandatoryPartList;
        private BindingList<Part> mPassNonMandatoryPartList;
        private Business mBusinessToChange = null; //In the event that a Business' information needs to be changed
        private Customer mCustomerToChange = null; //In the event that a Customer's information needs to be changed
        private Quote mQuoteTOChange = null; //In the event that a Quote's information needs to be changed
        private Pump mPumpToChange = null; //In the event that a Pump's information needs to be changed
        private bool mChangeSpecificObject = false; //To determine whether object should be viewed or changed

        public Pass(BindingList<Quote> mPassQuoteList, BindingList<Business> mPassBusinessList, BindingList<Pump> mPassPumpList, BindingList<Part> mPassMandatoryPartList, BindingList<Part> mPassNonMandatoryPartList) //Pass All Constructor
        {
            PassQuoteList = mPassQuoteList;
            PassBusinessList = mPassBusinessList;
            PassPumpList = mPassPumpList;
            PassMandatoryPartList = mPassMandatoryPartList;
            PassNonMandatoryPartList = mPassNonMandatoryPartList;
        }

        public Pass(BindingList<Quote> mPassQuoteList, BindingList<Business> mPassBusinessList, BindingList<Pump> mPassPumpList, BindingList<Part> mPassMandatoryPartList, BindingList<Part> mPassNonMandatoryPartList, ref Quote mQuoteTOChange, bool mChangeSpecificObject = false)  //Pass Quote Constructor
        {
            PassQuoteList = mPassQuoteList;
            PassBusinessList = mPassBusinessList;
            PassPumpList = mPassPumpList;
            PassMandatoryPartList = mPassMandatoryPartList;
            PassNonMandatoryPartList = mPassNonMandatoryPartList;
            QuoteTOChange = mQuoteTOChange;
            ChangeSpecificObject = mChangeSpecificObject;
        }

        public Pass(BindingList<Quote> mPassQuoteList, BindingList<Business> mPassBusinessList, BindingList<Pump> mPassPumpList, BindingList<Part> mPassMandatoryPartList, BindingList<Part> mPassNonMandatoryPartList, ref Business mBusinessToChange, bool mChangeSpecificObject = false) //Pass Business Constructor
        {
            PassQuoteList = mPassQuoteList;
            PassBusinessList = mPassBusinessList;
            PassPumpList = mPassPumpList;
            PassMandatoryPartList = mPassMandatoryPartList;
            PassNonMandatoryPartList = mPassNonMandatoryPartList;
            BusinessToChange = mBusinessToChange;
            ChangeSpecificObject = mChangeSpecificObject;
        }

        public Pass(BindingList<Quote> mPassQuoteList, BindingList<Business> mPassBusinessList, BindingList<Pump> mPassPumpList, BindingList<Part> mPassMandatoryPartList, BindingList<Part> mPassNonMandatoryPartList, ref Customer mCustomerToChange, bool mChangeSpecificObject = false) //Pass Customer Constructor
        {
            PassQuoteList = mPassQuoteList;
            PassBusinessList = mPassBusinessList;
            PassPumpList = mPassPumpList;
            PassMandatoryPartList = mPassMandatoryPartList;
            PassNonMandatoryPartList = mPassNonMandatoryPartList;
            CustomerToChange = mCustomerToChange;
            ChangeSpecificObject = mChangeSpecificObject;
        }

        public Pass(BindingList<Quote> mPassQuoteList, BindingList<Business> mPassBusinessList, BindingList<Pump> mPassPumpList, BindingList<Part> mPassMandatoryPartList, BindingList<Part> mPassNonMandatoryPartList, ref Pump mPumpToChange, bool mChangeSpecificObject = false) //Pass Pump Constructor
        {
            PassQuoteList = mPassQuoteList;
            PassBusinessList = mPassBusinessList;
            PassPumpList = mPassPumpList;
            PassMandatoryPartList = mPassMandatoryPartList;
            PassNonMandatoryPartList = mPassNonMandatoryPartList;
            PumpToChange = mPumpToChange;
            ChangeSpecificObject = mChangeSpecificObject;
        }

        public BindingList<Quote> PassQuoteList { get => mPassQuoteList; set => mPassQuoteList = value; }
        public BindingList<Business> PassBusinessList { get => mPassBusinessList; set => mPassBusinessList = value; }
        public BindingList<Pump> PassPumpList { get => mPassPumpList; set => mPassPumpList = value; }
        public Business BusinessToChange { get => mBusinessToChange; set => mBusinessToChange = value; }
        public Customer CustomerToChange { get => mCustomerToChange; set => mCustomerToChange = value; }
        public Quote QuoteTOChange { get => mQuoteTOChange; set => mQuoteTOChange = value; }
        public bool ChangeSpecificObject { get => mChangeSpecificObject; set => mChangeSpecificObject = value; }
        public Pump PumpToChange { get => mPumpToChange; set => mPumpToChange = value; }
        public BindingList<Part> PassMandatoryPartList { get => mPassMandatoryPartList; set => mPassMandatoryPartList = value; }
        public BindingList<Part> PassNonMandatoryPartList { get => mPassNonMandatoryPartList; set => mPassNonMandatoryPartList = value; }
    }
}
