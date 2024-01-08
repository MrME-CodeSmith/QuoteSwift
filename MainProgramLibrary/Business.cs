using System.Collections.Generic;
using ProtoBuf;
using System.ComponentModel;
using System.Linq;

namespace QuoteSwift
{
    [ProtoContract(SkipConstructor = true)]
    public class Business
    {
        [ProtoMember(1)]
        private string mBusinessName;
        [ProtoMember(2)]
        private string mBusinessExtraInformation;
        [ProtoMember(3)]
        private BindingList<Address> mBusinessAddressList;
        [ProtoMember(4)]
        private BindingList<Address> mBusinessPoBoxAddressList;
        [ProtoMember(5)]
        private Legal mBusinessLegalDetails;
        [ProtoMember(6)]
        private BindingList<string> mBusinessTelephoneNumberList;
        [ProtoMember(7)]
        private BindingList<string> mBusinessCellphoneNumberList;
        [ProtoMember(8)]
        private BindingList<string> mBusinessEmailAddressList;
        [ProtoMember(9)]
        private BindingList<Customer> mBusinessCustomerList;

        // Maps to optimise searching:
        private Dictionary<string, Address> mBusinessAddressMap;
        private Dictionary<string, object> mTelephoneNumberMap;
        private Dictionary<string, object> mCellphoneNumberMap;

        //Default Constructor
        public Business()
        {
            BusinessName = "";
            BusinessExtraInformation = "";
            BusinessAddressList = null;
            BusinessPoBoxAddressList = null;
            BusinessLegalDetails = null;
            BusinessTelephoneNumberList = null;
            BusinessCellphoneNumberList = null;
            BusinessEmailAddressList = null;
            CustomerList = null;
            mBusinessAddressMap = null;
        }

        // Copy Constructor

        public Business(Business b)
        {
            BusinessName = b.mBusinessName;
            BusinessExtraInformation = b.mBusinessExtraInformation;
            BusinessAddressList = b.mBusinessAddressList;
            BusinessPoBoxAddressList = b.mBusinessPoBoxAddressList;
            BusinessLegalDetails = b.mBusinessLegalDetails;
            BusinessTelephoneNumberList = b.mBusinessTelephoneNumberList;
            BusinessCellphoneNumberList = b.mBusinessCellphoneNumberList;
            BusinessEmailAddressList = b.mBusinessEmailAddressList;
            CustomerList = b.mBusinessCustomerList;
            mBusinessAddressMap = b.BusinessAddressMap;
        }


        public Business(string businessName, string businessExtraInformation, BindingList<Address> businessAddressList, BindingList<Address> businessPoBoxAddressList,
            Legal businessLegalDetails, BindingList<string> businessTelephoneNumberList, BindingList<string> businessCellphoneNumberList,
            BindingList<string> businessEmailAddressList, BindingList<Customer> businessCustomerList)
        {
            BusinessName = businessName;
            BusinessExtraInformation = businessExtraInformation;
            BusinessAddressList = businessAddressList;
            BusinessPoBoxAddressList = businessPoBoxAddressList;
            BusinessLegalDetails = businessLegalDetails;
            BusinessTelephoneNumberList = businessTelephoneNumberList;
            BusinessCellphoneNumberList = businessCellphoneNumberList;
            BusinessEmailAddressList = businessEmailAddressList;
            CustomerList = businessCustomerList;
        }

        public string BusinessName { get => mBusinessName; set => mBusinessName = value; }
        public string BusinessExtraInformation { get => mBusinessExtraInformation; set => mBusinessExtraInformation = value; }
        public BindingList<Address> BusinessAddressList { get => mBusinessAddressList; set => mBusinessAddressList = value; }
        public BindingList<Address> BusinessPoBoxAddressList { get => mBusinessPoBoxAddressList; set => mBusinessPoBoxAddressList = value; }
        public Legal BusinessLegalDetails { get => mBusinessLegalDetails; set => mBusinessLegalDetails = value; }
        public BindingList<string> BusinessTelephoneNumberList { get => mBusinessTelephoneNumberList; set => mBusinessTelephoneNumberList = value; }
        public BindingList<string> BusinessCellphoneNumberList { get => mBusinessCellphoneNumberList; set => mBusinessCellphoneNumberList = value; }
        public BindingList<string> BusinessEmailAddressList { get => mBusinessEmailAddressList; set => mBusinessEmailAddressList = value; }
        public BindingList<Customer> CustomerList { get => mBusinessCustomerList; set => mBusinessCustomerList = value; }
        public Dictionary<string, Address> BusinessAddressMap { get => mBusinessAddressMap; set => mBusinessAddressMap = value; }
        public Dictionary<string, object> TelephoneNumberMap { get => mTelephoneNumberMap; set => mTelephoneNumberMap = value; }
        public Dictionary<string, object> CellphoneNumberMap { get => mCellphoneNumberMap; set => mCellphoneNumberMap = value; }
    }
}
