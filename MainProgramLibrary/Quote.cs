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
        private string mQuotePrNumber;
        [ProtoMember(8)]
        private DateTime mQuotePaymentTerm;
        [ProtoMember(9)]
        private string mQuoteLineNumber;
        [ProtoMember(10)]
        private Address mQuoteBusinessPoBox;
        [ProtoMember(11)]
        private Address mQuoteCustomerPoBox;
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
        private BindingList<QuotePart> mQuoteMandatoryPartList;
        [ProtoMember(18)]
        private BindingList<QuotePart> mQuoteNewList;
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
        public Quote(string quoteNumber, DateTime quoteCreationDate, DateTime quoteExpireyDate, string quoteReference,
            string quoteJobNumber, string quotePrNumber, DateTime quotePaymentTerm, Address quoteBusinessPoBox,
            Address quoteCustomerPoBox, string quoteLineNumber, float quoteNewUnitPrice, float quoteRepairPercentage,
            string quoteDeliveryAddress, Customer quoteCustomer, Business quoteCompany,
            BindingList<QuotePart> quoteMandatoryPartList, BindingList<QuotePart> quoteNewList, string telefone,
            string cellphone, string email, int netDays, Pricing quoteCost, string name)
        {
            QuoteNumber = quoteNumber;
            QuoteCreationDate = quoteCreationDate;
            QuoteExpireyDate = quoteExpireyDate;
            QuoteReference = quoteReference;
            QuoteJobNumber = quoteJobNumber;
            QuotePrNumber = quotePrNumber;
            QuotePaymentTerm = quotePaymentTerm;
            QuoteBusinessPoBox = quoteBusinessPoBox;
            QuoteCustomerPoBox = quoteCustomerPoBox;
            QuoteLineNumber = quoteLineNumber;
            QuoteNewUnitPrice = quoteNewUnitPrice;
            QuoteRepairPercentage = quoteRepairPercentage;
            QuoteDeliveryAddress = quoteDeliveryAddress;
            QuoteCustomer = quoteCustomer;
            QuoteCompany = quoteCompany;
            QuoteMandatoryPartList = quoteMandatoryPartList;
            QuoteNewList = quoteNewList;
            Telefone = telefone;
            Cellphone = cellphone;
            Email = email;
            NetDays = netDays;
            QuoteCost = quoteCost;
            PumpName = name;
        }

        /** Getters && Setters */
        public string QuoteNumber { get => mQuoteNumber; set => mQuoteNumber = value; }
        public DateTime QuoteCreationDate { get => mQuoteCreationDate; set => mQuoteCreationDate = value; }
        public DateTime QuoteExpireyDate { get => mQuoteExpireyDate; set => mQuoteExpireyDate = value; }
        public string QuoteReference { get => mQuoteReference; set => mQuoteReference = value; }
        public string QuoteJobNumber { get => mQuoteJobNumber; set => mQuoteJobNumber = value; }
        public string QuotePrNumber { get => mQuotePrNumber; set => mQuotePrNumber = value; }
        public DateTime QuotePaymentTerm { get => mQuotePaymentTerm; set => mQuotePaymentTerm = value; }
        public string QuoteLineNumber { get => mQuoteLineNumber; set => mQuoteLineNumber = value; }
        public float QuoteNewUnitPrice { get => mQuoteNewUnitPrice; set => mQuoteNewUnitPrice = value; }
        public float QuoteRepairPercentage { get => mQuoteRepairPercentage; set => mQuoteRepairPercentage = value; }
        public string QuoteDeliveryAddress { get => mQuoteDeliveryAddress; set => mQuoteDeliveryAddress = value; }
        public Customer QuoteCustomer { get => mQuoteCustomer; set => mQuoteCustomer = value; }
        public Business QuoteCompany { get => mQuoteCompany; set => mQuoteCompany = value; }
        public BindingList<QuotePart> QuoteMandatoryPartList { get => mQuoteMandatoryPartList; set => mQuoteMandatoryPartList = value; }
        public BindingList<QuotePart> QuoteNewList { get => mQuoteNewList; set => mQuoteNewList = value; }
        public Address QuoteBusinessPoBox { get => mQuoteBusinessPoBox; set => mQuoteBusinessPoBox = value; }
        public string Telefone { get => mTelefone; set => mTelefone = value; }
        public string Cellphone { get => mCellphone; set => mCellphone = value; }
        public string Email { get => mEmail; set => mEmail = value; }
        public Address QuoteCustomerPoBox { get => mQuoteCustomerPoBox; set => mQuoteCustomerPoBox = value; }
        public int NetDays { get => mNetDays; set => mNetDays = value; }
        public Pricing QuoteCost { get => mQuoteCost; set => mQuoteCost = value; }
        public string PumpName { get => mPumpName; set => mPumpName = value; }
    }
}
