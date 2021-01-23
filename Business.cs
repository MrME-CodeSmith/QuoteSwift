using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace QuoteSwift
{
    [Serializable]
    public class Business
    {
        private string mBusinessName;
        private string mBusinessExtraInformation;
        private BindingList<Address> mBusinessAddressList;
        private BindingList<Address> mBusinessPOBoxAddressList;
        private Legal mBusinessLegalDetails;
        private BindingList<string> mBusinessTelephoneNumberList;
        private BindingList<string> mBusinessCellphoneNumberList;
        private BindingList<string> mBusinessEmailAddressList;
        private BindingList<Customer> mBusinessCustomerList;

        public Business(string mBusinessName, string mBusinessExtraInformation, BindingList<Address> mBusinessAddressList, BindingList<Address> mBusinessPOBoxAddressList, 
            Legal mBusinessLegalDetails, BindingList<string> mBusinessTelephoneNumberList, BindingList<string> mBusinessCellphoneNumberList, 
            BindingList<string> mBusinessEmailAddressList, BindingList<Customer> mBusinessCustomerList)
        {
            BusinessName = mBusinessName;
            BusinessExtraInformation = mBusinessExtraInformation;
            BusinessAddressList = mBusinessAddressList;
            BusinessPOBoxAddressList = mBusinessPOBoxAddressList;
            BusinessLegalDetails = mBusinessLegalDetails;
            BusinessTelephoneNumberList = mBusinessTelephoneNumberList;
            BusinessCellphoneNumberList = mBusinessCellphoneNumberList;
            BusinessEmailAddressList = mBusinessEmailAddressList;
            BusinessCustomerList = mBusinessCustomerList;
        }

        public string BusinessName { get => mBusinessName; set => mBusinessName = value; }
        public string BusinessExtraInformation { get => mBusinessExtraInformation; set => mBusinessExtraInformation = value; }
        public BindingList<Address> BusinessAddressList { get => mBusinessAddressList; set => mBusinessAddressList = value; }
        public BindingList<Address> BusinessPOBoxAddressList { get => mBusinessPOBoxAddressList; set => mBusinessPOBoxAddressList = value; }
        public Legal BusinessLegalDetails { get => mBusinessLegalDetails; set => mBusinessLegalDetails = value; }
        public BindingList<string> BusinessTelephoneNumberList { get => mBusinessTelephoneNumberList; set => mBusinessTelephoneNumberList = value; }
        public BindingList<string> BusinessCellphoneNumberList { get => mBusinessCellphoneNumberList; set => mBusinessCellphoneNumberList = value; }
        public BindingList<string> BusinessEmailAddressList { get => mBusinessEmailAddressList; set => mBusinessEmailAddressList = value; }
        public BindingList<Customer> BusinessCustomerList { get => mBusinessCustomerList; set => mBusinessCustomerList = value; }
    }
}
