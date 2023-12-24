using System;
using ProtoBuf;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using MainProgramLibrary;

namespace QuoteSwift
{
    public static class Global
    {
        public static AppContext Context { get; private set; }

        public static void InitializeContext()
        {
            Context = new AppContext(
                new Dictionary<string, Quote>(),
                new Dictionary<string, Business>(),
                new Dictionary<string, Product>(),
                new Dictionary<string, Part>(),
                new Dictionary<string, Part>()
            )
            {
                MandatoryPartList = new BindingList<Part>(),
                NonMandatoryPartList = new BindingList<Part>()
            };
        }
    }

    [ProtoContract(SkipConstructor = true)]
    public class AppContext
    {
        private Dictionary<string, Quote> mQuoteMap;
        private Dictionary<string, Business> mBusinessMap;
        private Dictionary<string, Product> mPumpMap;
        private Dictionary<string, Part> mMandatoryPartMap;
        private Dictionary<string, Part> mNonMandatoryPartMap;
        private BindingList<Part> mMandatoryPartList;
        private BindingList<Part> mNonMandatoryPartList;

        private Business mBusinessToChange = null; //In the event that a Business' information needs to be changed
        private Customer mCustomerToChange = null; //In the event that a Customer's information needs to be changed
        private Quote mQuoteToChange = null; //In the event that a Quote's information needs to be changed
        private Product mPumpToChange = null; //In the event that a Pump's information needs to be changed
        private Part mPartToChange = null; //In the event that a Part's information needs to be changed
        private Address mAddressToChange = null;//In the event that an Address needs to be changed
        private string mEmailToChange = ""; //In the event that an Email needs to be changed.
        private string mPhoneNumberToChange = "";//In the event that a Phone number needs to be changed.
        private bool mChangeSpecificObject = false; //To determine whether object should be viewed or changed

        //Pass All Constructor :

        public AppContext(
            Dictionary<string, Quote> passQuoteMap, 
            Dictionary<string, Business> passBusinessMap, 
            Dictionary<string, Product> passPumpMap, 
            Dictionary<string, Part> passMandatoryPartMap,
            Dictionary<string, Part> passNonMandatoryPartMap
        ){
            QuoteMap = passQuoteMap;
            BusinessMap = passBusinessMap;
            ProductMap = passPumpMap;
            MandatoryPartMap = passMandatoryPartMap;
            NonMandatoryPartMap = passNonMandatoryPartMap;
        }

        //Pass Quote Constructor:

        public AppContext(
            Dictionary<string, Quote> passQuoteMap,
            Dictionary<string, Business> passBusinessMap,
            Dictionary<string, Product> passPumpMap,
            Dictionary<string, Part> passMandatoryPartMap,
            Dictionary<string, Part> passNonMandatoryPartMap,
            ref Quote quoteToChange, 
            bool changeSpecificObject = false
        ){
            QuoteMap = passQuoteMap;
            BusinessMap = passBusinessMap;
            ProductMap = passPumpMap;
            MandatoryPartMap = passMandatoryPartMap;
            NonMandatoryPartMap = passNonMandatoryPartMap;
            QuoteToChange = quoteToChange;
            ChangeSpecificObject = changeSpecificObject;
        }

        //Pass Business Constructor:

        public AppContext(
            Dictionary<string, Quote> passQuoteMap,
            Dictionary<string, Business> passBusinessMap,
            Dictionary<string, Product> passPumpMap,
            Dictionary<string, Part> passMandatoryPartMap,
            Dictionary<string, Part> passNonMandatoryPartMap,
            ref Business businessToChange, 
            bool changeSpecificObject = false
        ){
            QuoteMap = passQuoteMap;
            BusinessMap = passBusinessMap;
            ProductMap = passPumpMap;
            MandatoryPartMap = passMandatoryPartMap;
            NonMandatoryPartMap = passNonMandatoryPartMap;
            BusinessToChange = businessToChange;
            ChangeSpecificObject = changeSpecificObject;
        }

        //Pass Customer Constructor:

        public AppContext(
            Dictionary<string, Quote> passQuoteMap,
            Dictionary<string, Business> passBusinessMap,
            Dictionary<string, Product> passPumpMap,
            Dictionary<string, Part> passMandatoryPartMap,
            Dictionary<string, Part> passNonMandatoryPartMap,
            ref Customer customerToChange, 
            bool changeSpecificObject = false
        ){
            QuoteMap = passQuoteMap;
            BusinessMap = passBusinessMap;
            ProductMap = passPumpMap;
            MandatoryPartMap = passMandatoryPartMap;
            NonMandatoryPartMap = passNonMandatoryPartMap;
            CustomerToChange = customerToChange;
            ChangeSpecificObject = changeSpecificObject;
        }

        //Pass Pump Constructor:

        public AppContext(
            Dictionary<string, Quote> passQuoteMap,
            Dictionary<string, Business> passBusinessMap,
            Dictionary<string, Product> passPumpMap,
            Dictionary<string, Part> passMandatoryPartMap,
            Dictionary<string, Part> passNonMandatoryPartMap,
            ref Product pumpToChange, 
            bool changeSpecificObject = false
        ){
            QuoteMap = passQuoteMap;
            BusinessMap = passBusinessMap;
            ProductMap = passPumpMap;
            MandatoryPartMap = passMandatoryPartMap;
            NonMandatoryPartMap = passNonMandatoryPartMap;
            PumpToChange = pumpToChange;
            ChangeSpecificObject = changeSpecificObject;
        }

        //Pass Part Constructor:

        public AppContext(
            Dictionary<string, Quote> passQuoteMap,
            Dictionary<string, Business> passBusinessMap,
            Dictionary<string, Product> passPumpMap,
            Dictionary<string, Part> passMandatoryPartMap,
            Dictionary<string, Part> passNonMandatoryPartMap,
            ref Part partToChange, 
            bool changeSpecificObject = false
        ){
            QuoteMap = passQuoteMap;
            BusinessMap = passBusinessMap;
            ProductMap = passPumpMap;
            MandatoryPartMap = passMandatoryPartMap;
            NonMandatoryPartMap = passNonMandatoryPartMap;
            PartToChange = partToChange;
            ChangeSpecificObject = changeSpecificObject;
        }

        public void AddPart(ref Part p)
        {
            if (p != null)
            {
                if (p.MandatoryPart)
                {
                    if (!MandatoryPartMap.ContainsKey(p.OriginalItemPartNumber) &&
                        !MandatoryPartMap.ContainsKey(p.NewPartNumber) &&
                        !NonMandatoryPartMap.ContainsKey(p.OriginalItemPartNumber) &&
                        !NonMandatoryPartMap.ContainsKey(p.NewPartNumber)
                       )
                    {
                        MandatoryPartMap[p.OriginalItemPartNumber] = p;
                        MandatoryPartMap[p.NewPartNumber] = p;
                    }
                    else throw new FeedbackException(Messages.PartAlreadyExists);
                }
                else
                {
                    if (!MandatoryPartMap.ContainsKey(p.OriginalItemPartNumber) &&
                        !MandatoryPartMap.ContainsKey(p.NewPartNumber) &&
                        !NonMandatoryPartMap.ContainsKey(p.OriginalItemPartNumber) &&
                        !NonMandatoryPartMap.ContainsKey(p.NewPartNumber)
                       )
                    {
                        NonMandatoryPartMap[p.OriginalItemPartNumber] = p;
                        NonMandatoryPartMap[p.NewPartNumber] = p;
                    }
                    else throw new FeedbackException(Messages.PartAlreadyExists);
                }
            }
            else throw new GeneralErrorException(Messages.InvalidParameter);
        }

        public Dictionary<string, Quote> QuoteMap { get => mQuoteMap; set => mQuoteMap = value; }
        public Dictionary<string, Business> BusinessMap { get => mBusinessMap; set => mBusinessMap = value; }
        public Dictionary<string, Product> ProductMap { get => mPumpMap; set => mPumpMap = value; }
        public Dictionary<string, Part> MandatoryPartMap { get => mMandatoryPartMap; set => mMandatoryPartMap = value; }
        public Dictionary<string, Part> NonMandatoryPartMap { get => mNonMandatoryPartMap; set => mNonMandatoryPartMap = value; }
        public Business BusinessToChange { get => mBusinessToChange; set => mBusinessToChange = value; }
        public Customer CustomerToChange { get => mCustomerToChange; set => mCustomerToChange = value; }
        public Quote QuoteToChange { get => mQuoteToChange; set => mQuoteToChange = value; }
        public bool ChangeSpecificObject { get => mChangeSpecificObject; set => mChangeSpecificObject = value; }
        public Product PumpToChange { get => mPumpToChange; set => mPumpToChange = value; }
        public Part PartToChange { get => mPartToChange; set => mPartToChange = value; }
        public Address AddressToChange { get => mAddressToChange; set => mAddressToChange = value; }
        public string EmailToChange { get => mEmailToChange; set => mEmailToChange = value; }
        public string PhoneNumberToChange { get => mPhoneNumberToChange; set => mPhoneNumberToChange = value; }
        public BindingList<Part> MandatoryPartList { get => mMandatoryPartList; set => mMandatoryPartList = value; }
        public BindingList<Part> NonMandatoryPartList { get => mNonMandatoryPartList; set => mNonMandatoryPartList = value;}
    }
}
