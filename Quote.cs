using System;
using ProtoBuf;
using System.ComponentModel;

namespace QuoteSwift
{
    [ProtoContract(SkipConstructor = true)]
    public class Quote
    {
        private string mQuoteNumber;
        private DateTime mQuoteCreationDate;
        private DateTime mQuoteExpireyDate;
        private string mQuoteReference;
        private string mQuoteJobNumber;
        private string mQuotePRNumber;
        private DateTime mQuotePaymentTerm;
        private int mQuoteLineNumber;
        private float mQuoteNewUnitPrice;
        private float mQuoteRepairPercentage;
        private Address mQuoteDeliveryAddress;
        private Customer mQuoteCustomer;
        private Business mQuoteCompany;
        private BindingList<Pump_Part> mQuoteMandatoryPartList;
        private BindingList<Pump_Part> mQuoteNewList;

        /** Constructor */
        public Quote(string mQuoteNumber, DateTime mQuoteCreationDate, DateTime mQuoteExpireyDate, string mQuoteReference, 
            string mQuoteJobNumber, string mQuotePRNumber, DateTime mQuotePaymentTerm, int mQuoteLineNumber, 
            float mQuoteNewUnitPrice, float mQuoteRepairPercentage, Address mQuoteDeliveryAddress, Customer mQuoteCustomer, 
            Business mQuoteCompany, BindingList<Pump_Part> mQuoteMandatoryPartList, BindingList<Pump_Part> mQuoteNewList)
        {
            QuoteNumber = mQuoteNumber;
            QuoteCreationDate = mQuoteCreationDate;
            QuoteExpireyDate = mQuoteExpireyDate;
            QuoteReference = mQuoteReference;
            QuoteJobNumber = mQuoteJobNumber;
            QuotePRNumber = mQuotePRNumber;
            QuotePaymentTerm = mQuotePaymentTerm;
            QuoteLineNumber = mQuoteLineNumber;
            QuoteNewUnitPrice = mQuoteNewUnitPrice;
            QuoteRepairPercentage = mQuoteRepairPercentage;
            QuoteDeliveryAddress = mQuoteDeliveryAddress;
            QuoteCustomer = mQuoteCustomer;
            QuoteCompany = mQuoteCompany;
            QuoteMandatoryPartList = mQuoteMandatoryPartList;
            QuoteNewList = mQuoteNewList;
        }

        void ExportQuoteToTemplate()
        {
            //Export to Excell Template Code
        }

        /** Getters && Setters */
        public string QuoteNumber { get => mQuoteNumber; set => mQuoteNumber = value; }
        public DateTime QuoteCreationDate { get => mQuoteCreationDate; set => mQuoteCreationDate = value; }
        public DateTime QuoteExpireyDate { get => mQuoteExpireyDate; set => mQuoteExpireyDate = value; }
        public string QuoteReference { get => mQuoteReference; set => mQuoteReference = value; }
        public string QuoteJobNumber { get => mQuoteJobNumber; set => mQuoteJobNumber = value; }
        public string QuotePRNumber { get => mQuotePRNumber; set => mQuotePRNumber = value; }
        public DateTime QuotePaymentTerm { get => mQuotePaymentTerm; set => mQuotePaymentTerm = value; }
        public int QuoteLineNumber { get => mQuoteLineNumber; set => mQuoteLineNumber = value; }
        public float QuoteNewUnitPrice { get => mQuoteNewUnitPrice; set => mQuoteNewUnitPrice = value; }
        public float QuoteRepairPercentage { get => mQuoteRepairPercentage; set => mQuoteRepairPercentage = value; }
        public Address QuoteDeliveryAddress { get => mQuoteDeliveryAddress; set => mQuoteDeliveryAddress = value; }
        public Customer QuoteCustomer { get => mQuoteCustomer; set => mQuoteCustomer = value; }
        public Business QuoteCompany { get => mQuoteCompany; set => mQuoteCompany = value; }
        public BindingList<Pump_Part> QuoteMandatoryPartList { get => mQuoteMandatoryPartList; set => mQuoteMandatoryPartList = value; }
        public BindingList<Pump_Part> QuoteNewList { get => mQuoteNewList; set => mQuoteNewList = value; }
    }
}
