using System;
using System.ComponentModel;

namespace QuoteSwift
{
    public class Quote : ObservableObject
    {
        private string mPumpName;
        private string mQuoteNumber;
        private DateTime mQuoteCreationDate;
        private DateTime mQuoteExpireyDate;
        private string mQuoteReference;
        private string mQuoteJobNumber;
        private string mQuotePRNumber;
        private DateTime mQuotePaymentTerm;
        private string mQuoteLineNumber;
        private Address mQuoteBusinessPOBox;
        private Address mQuoteCustomerPOBox;
        private float mQuoteNewUnitPrice;
        private float mQuoteRepairPercentage;
        private string mQuoteDeliveryAddress;
        private Customer mQuoteCustomer;
        private Business mQuoteCompany;
        private BindingList<Quote_Part> mQuoteMandatoryPartList;
        private BindingList<Quote_Part> mQuoteNewList;
        private string mTelefone;
        private string mCellphone;
        private string mEmail;
        private int mNetDays;
        private Pricing mQuoteCost;

        /** Constructor */
        public Quote(string mQuoteNumber, DateTime mQuoteCreationDate, DateTime mQuoteExpireyDate, string mQuoteReference,
            string mQuoteJobNumber, string mQuotePRNumber, DateTime mQuotePaymentTerm, Address mQuoteBusinessPOBox,
            Address mQuoteCustomerPOBox, string mQuoteLineNumber, float mQuoteNewUnitPrice, float mQuoteRepairPercentage,
            string mQuoteDeliveryAddress, Customer mQuoteCustomer, Business mQuoteCompany,
            BindingList<Quote_Part> mQuoteMandatoryPartList, BindingList<Quote_Part> mQuoteNewList, string mTelefone,
            string mCellphone, string mEmail, int mNetDays, Pricing mQuoteCost, string name)
        {
            QuoteNumber = mQuoteNumber;
            QuoteCreationDate = mQuoteCreationDate;
            QuoteExpireyDate = mQuoteExpireyDate;
            QuoteReference = mQuoteReference;
            QuoteJobNumber = mQuoteJobNumber;
            QuotePRNumber = mQuotePRNumber;
            QuotePaymentTerm = mQuotePaymentTerm;
            QuoteBusinessPOBox = mQuoteBusinessPOBox;
            QuoteCustomerPOBox = mQuoteCustomerPOBox;
            QuoteLineNumber = mQuoteLineNumber;
            QuoteNewUnitPrice = mQuoteNewUnitPrice;
            QuoteRepairPercentage = mQuoteRepairPercentage;
            QuoteDeliveryAddress = mQuoteDeliveryAddress;
            QuoteCustomer = mQuoteCustomer;
            QuoteCompany = mQuoteCompany;
            QuoteMandatoryPartList = mQuoteMandatoryPartList;
            QuoteNewList = mQuoteNewList;
            Telefone = mTelefone;
            Cellphone = mCellphone;
            Email = mEmail;
            NetDays = mNetDays;
            QuoteCost = mQuoteCost;
            PumpName = name;
        }

        /** Getters && Setters */
        public string QuoteNumber
        {
            get => mQuoteNumber;
            set => SetProperty(ref mQuoteNumber, value);
        }

        public DateTime QuoteCreationDate
        {
            get => mQuoteCreationDate;
            set => SetProperty(ref mQuoteCreationDate, value);
        }

        public DateTime QuoteExpireyDate
        {
            get => mQuoteExpireyDate;
            set => SetProperty(ref mQuoteExpireyDate, value);
        }

        public string QuoteReference
        {
            get => mQuoteReference;
            set => SetProperty(ref mQuoteReference, value);
        }

        public string QuoteJobNumber
        {
            get => mQuoteJobNumber;
            set => SetProperty(ref mQuoteJobNumber, value);
        }

        public string QuotePRNumber
        {
            get => mQuotePRNumber;
            set => SetProperty(ref mQuotePRNumber, value);
        }

        public DateTime QuotePaymentTerm
        {
            get => mQuotePaymentTerm;
            set => SetProperty(ref mQuotePaymentTerm, value);
        }

        public string QuoteLineNumber
        {
            get => mQuoteLineNumber;
            set => SetProperty(ref mQuoteLineNumber, value);
        }

        public float QuoteNewUnitPrice
        {
            get => mQuoteNewUnitPrice;
            set => SetProperty(ref mQuoteNewUnitPrice, value);
        }

        public float QuoteRepairPercentage
        {
            get => mQuoteRepairPercentage;
            set => SetProperty(ref mQuoteRepairPercentage, value);
        }

        public string QuoteDeliveryAddress
        {
            get => mQuoteDeliveryAddress;
            set => SetProperty(ref mQuoteDeliveryAddress, value);
        }

        public Customer QuoteCustomer
        {
            get => mQuoteCustomer;
            set => SetProperty(ref mQuoteCustomer, value);
        }

        public Business QuoteCompany
        {
            get => mQuoteCompany;
            set => SetProperty(ref mQuoteCompany, value);
        }

        public BindingList<Quote_Part> QuoteMandatoryPartList
        {
            get => mQuoteMandatoryPartList;
            set => SetProperty(ref mQuoteMandatoryPartList, value);
        }

        public BindingList<Quote_Part> QuoteNewList
        {
            get => mQuoteNewList;
            set => SetProperty(ref mQuoteNewList, value);
        }

        public Address QuoteBusinessPOBox
        {
            get => mQuoteBusinessPOBox;
            set => SetProperty(ref mQuoteBusinessPOBox, value);
        }

        public string Telefone
        {
            get => mTelefone;
            set => SetProperty(ref mTelefone, value);
        }

        public string Cellphone
        {
            get => mCellphone;
            set => SetProperty(ref mCellphone, value);
        }

        public string Email
        {
            get => mEmail;
            set => SetProperty(ref mEmail, value);
        }

        public Address QuoteCustomerPOBox
        {
            get => mQuoteCustomerPOBox;
            set => SetProperty(ref mQuoteCustomerPOBox, value);
        }

        public int NetDays
        {
            get => mNetDays;
            set => SetProperty(ref mNetDays, value);
        }

        public Pricing QuoteCost
        {
            get => mQuoteCost;
            set => SetProperty(ref mQuoteCost, value);
        }

        public string PumpName
        {
            get => mPumpName;
            set => SetProperty(ref mPumpName, value);
        }
    }
}
