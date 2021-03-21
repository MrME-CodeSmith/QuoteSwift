using ProtoBuf;
using System;
using System.ComponentModel;

namespace QuoteSwift
{
    [ProtoContract(SkipConstructor = true)]
    public class Quote
    {
        [ProtoMember(1)]
        private string mPumpName;
        [ProtoMember(2)]
        private string mQuoteNumber;
        [ProtoMember(3)]
        private DateTime mQuoteCreationDate;
        [ProtoMember(4)]
        private DateTime mQuoteExpireyDate;
        [ProtoMember(5)]
        private string mQuoteReference;
        [ProtoMember(6)]
        private string mQuoteJobNumber;
        [ProtoMember(7)]
        private string mQuotePRNumber;
        [ProtoMember(8)]
        private DateTime mQuotePaymentTerm;
        [ProtoMember(9)]
        private string mQuoteLineNumber;
        [ProtoMember(10)]
        private Address mQuoteBusinessPOBox;
        [ProtoMember(11)]
        private Address mQuoteCustomerPOBox;
        [ProtoMember(12)]
        private float mQuoteNewUnitPrice;
        [ProtoMember(13)]
        private float mQuoteRepairPercentage;
        [ProtoMember(14)]
        private string mQuoteDeliveryAddress;
        [ProtoMember(15)]
        private Customer mQuoteCustomer;
        [ProtoMember(16)]
        private Business mQuoteCompany;
        [ProtoMember(17)]
        private BindingList<Quote_Part> mQuoteMandatoryPartList;
        [ProtoMember(18)]
        private BindingList<Quote_Part> mQuoteNewList;
        [ProtoMember(19)]
        private string mTelefone;
        [ProtoMember(20)]
        private string mCellphone;
        [ProtoMember(21)]
        private string mEmail;
        [ProtoMember(22)]
        private int mNetDays;
        [ProtoMember(23)]
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
        public string QuoteNumber { get => mQuoteNumber; set => mQuoteNumber = value; }
        public DateTime QuoteCreationDate { get => mQuoteCreationDate; set => mQuoteCreationDate = value; }
        public DateTime QuoteExpireyDate { get => mQuoteExpireyDate; set => mQuoteExpireyDate = value; }
        public string QuoteReference { get => mQuoteReference; set => mQuoteReference = value; }
        public string QuoteJobNumber { get => mQuoteJobNumber; set => mQuoteJobNumber = value; }
        public string QuotePRNumber { get => mQuotePRNumber; set => mQuotePRNumber = value; }
        public DateTime QuotePaymentTerm { get => mQuotePaymentTerm; set => mQuotePaymentTerm = value; }
        public string QuoteLineNumber { get => mQuoteLineNumber; set => mQuoteLineNumber = value; }
        public float QuoteNewUnitPrice { get => mQuoteNewUnitPrice; set => mQuoteNewUnitPrice = value; }
        public float QuoteRepairPercentage { get => mQuoteRepairPercentage; set => mQuoteRepairPercentage = value; }
        public string QuoteDeliveryAddress { get => mQuoteDeliveryAddress; set => mQuoteDeliveryAddress = value; }
        public Customer QuoteCustomer { get => mQuoteCustomer; set => mQuoteCustomer = value; }
        public Business QuoteCompany { get => mQuoteCompany; set => mQuoteCompany = value; }
        public BindingList<Quote_Part> QuoteMandatoryPartList { get => mQuoteMandatoryPartList; set => mQuoteMandatoryPartList = value; }
        public BindingList<Quote_Part> QuoteNewList { get => mQuoteNewList; set => mQuoteNewList = value; }
        public Address QuoteBusinessPOBox { get => mQuoteBusinessPOBox; set => mQuoteBusinessPOBox = value; }
        public string Telefone { get => mTelefone; set => mTelefone = value; }
        public string Cellphone { get => mCellphone; set => mCellphone = value; }
        public string Email { get => mEmail; set => mEmail = value; }
        public Address QuoteCustomerPOBox { get => mQuoteCustomerPOBox; set => mQuoteCustomerPOBox = value; }
        public int NetDays { get => mNetDays; set => mNetDays = value; }
        public Pricing QuoteCost { get => mQuoteCost; set => mQuoteCost = value; }
        public string PumpName { get => mPumpName; set => mPumpName = value; }
    }
}
