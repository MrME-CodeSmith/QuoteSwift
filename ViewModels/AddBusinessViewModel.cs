using System.ComponentModel;

namespace QuoteSwift
{
    public class AddBusinessViewModel : INotifyPropertyChanged
    {
        readonly IDataService dataService;
        readonly Pass pass;
        Business currentBusiness;

        public event PropertyChangedEventHandler PropertyChanged;

        public AddBusinessViewModel(IDataService service)
        {
            dataService = service;
            pass = new Pass(null, null, null, null);
        }

        public IDataService DataService => dataService;

        public Pass Pass => pass;

        public Business CurrentBusiness
        {
            get => currentBusiness;
            set
            {
                if (currentBusiness != value)
                {
                    currentBusiness = value;
                    OnPropertyChanged(nameof(CurrentBusiness));
                }
            }
        }

        public void LoadData()
        {
            pass.PassBusinessList = dataService.LoadBusinessList();
        }

        public void UpdatePass(Pass newPass)
        {
            if (newPass == null) return;
            pass.PassQuoteMap = newPass.PassQuoteMap;
            pass.PassBusinessList = newPass.PassBusinessList;
            pass.PassPartList = newPass.PassPartList;
            pass.PassPumpList = newPass.PassPumpList;
        }

        public bool AddBusiness()
        {
            if (!ValidateBusiness())
                return false;

            if (pass.PassBusinessList == null)
                pass.PassBusinessList = new BindingList<Business>();

            if (pass.BusinessLookup.ContainsKey(CurrentBusiness.BusinessName) ||
                pass.BusinessVatNumbers.Contains(CurrentBusiness.BusinessLegalDetails?.VatNumber) ||
                pass.BusinessRegNumbers.Contains(CurrentBusiness.BusinessLegalDetails?.RegistrationNumber))
            {
                MainProgramCode.ShowError("This business has already been added previously.\nHINT: Business Name,VAT Number and Registration Number should be unique", "ERROR - Business Already Added");
                return false;
            }

            pass.PassBusinessList.Add(CurrentBusiness);
            pass.BusinessLookup[CurrentBusiness.BusinessName] = CurrentBusiness;
            pass.BusinessVatNumbers.Add(CurrentBusiness.BusinessLegalDetails?.VatNumber);
            pass.BusinessRegNumbers.Add(CurrentBusiness.BusinessLegalDetails?.RegistrationNumber);

            pass.BusinessToChange = null;
            pass.ChangeSpecificObject = false;
            return true;
        }

        public bool UpdateBusiness()
        {
            if (!ValidateBusiness())
                return false;

            if (pass.BusinessToChange == null)
                return false;

            string oldName = pass.BusinessToChange.BusinessName;
            string oldVat = pass.BusinessToChange.BusinessLegalDetails?.VatNumber;
            string oldReg = pass.BusinessToChange.BusinessLegalDetails?.RegistrationNumber;

            pass.BusinessToChange.BusinessName = CurrentBusiness.BusinessName;
            pass.BusinessToChange.BusinessExtraInformation = CurrentBusiness.BusinessExtraInformation;
            pass.BusinessToChange.BusinessLegalDetails = new Legal(CurrentBusiness.BusinessLegalDetails?.RegistrationNumber, CurrentBusiness.BusinessLegalDetails?.VatNumber);

            pass.BusinessLookup.Remove(oldName);
            pass.BusinessVatNumbers.Remove(oldVat);
            pass.BusinessRegNumbers.Remove(oldReg);

            CurrentBusiness = pass.BusinessToChange;
            pass.BusinessLookup[CurrentBusiness.BusinessName] = CurrentBusiness;
            pass.BusinessVatNumbers.Add(CurrentBusiness.BusinessLegalDetails?.VatNumber);
            pass.BusinessRegNumbers.Add(CurrentBusiness.BusinessLegalDetails?.RegistrationNumber);

            return true;
        }

        public bool AddAddress(Address address)
        {
            if (!ValidateAddress(address))
                return false;

            string key = StringUtil.NormalizeKey(address.AddressDescription);
            if (CurrentBusiness.AddressMap.ContainsKey(key))
            {
                MainProgramCode.ShowError("This address has already been added previously.\nHINT: Description should be unique", "ERROR - Address Already Added");
                return false;
            }

            CurrentBusiness.AddAddress(address);
            return true;
        }

        public bool AddPOBoxAddress(Address address)
        {
            if (!ValidatePOBoxAddress(address))
                return false;

            string key = StringUtil.NormalizeKey(address.AddressDescription);
            if (CurrentBusiness.POBoxMap.ContainsKey(key))
            {
                MainProgramCode.ShowError("This P.O.Box address has already been added previously.\nHINT: Description should be unique", "ERROR - P.O.Box Address Already Added");
                return false;
            }

            CurrentBusiness.AddPOBoxAddress(address);
            return true;
        }

        public bool AddPhoneNumber(string telephone, string cellphone)
        {
            bool added = false;
            if ((telephone == null || telephone.Length < 10) && (cellphone == null || cellphone.Length < 10))
            {
                MainProgramCode.ShowError("a Valid Phone Number/s were not provided, please provide at least one valid phone number.", "ERROR - Invalid Number/s Provided");
                return false;
            }

            if (!string.IsNullOrWhiteSpace(telephone) && telephone.Length >= 10)
            {
                if (CurrentBusiness.TelephoneNumbers.Contains(telephone) || CurrentBusiness.CellphoneNumbers.Contains(telephone))
                {
                    MainProgramCode.ShowError("This number has already been added previously.", "ERROR - Number Already Added");
                }
                else
                {
                    CurrentBusiness.AddTelephoneNumber(telephone);
                    added = true;
                }
            }

            if (!string.IsNullOrWhiteSpace(cellphone) && cellphone.Length >= 10)
            {
                if (CurrentBusiness.TelephoneNumbers.Contains(cellphone) || CurrentBusiness.CellphoneNumbers.Contains(cellphone))
                {
                    MainProgramCode.ShowError("This number has already been added previously.", "ERROR - Number Already Added");
                }
                else
                {
                    CurrentBusiness.AddCellphoneNumber(cellphone);
                    added = true;
                }
            }

            return added;
        }

        public bool AddEmailAddress(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || email.Length <= 3 || !email.Contains("@"))
            {
                MainProgramCode.ShowError("The provided Email Address is invalid. Please provide a valid Email Address", "ERROR - Invalid Email Address");
                return false;
            }

            if (CurrentBusiness.EmailAddresses.Contains(email))
            {
                MainProgramCode.ShowError("This email address has already been added previously.", "ERROR - Email Address Already Added");
                return false;
            }

            CurrentBusiness.AddEmailAddress(email);
            return true;
        }

        bool ValidateAddress(Address a)
        {
            if (a == null)
                return false;

            if (string.IsNullOrWhiteSpace(a.AddressDescription) || a.AddressDescription.Length < 2)
            {
                MainProgramCode.ShowError("The provided Business Address Description is invalid, please provide a valid description", "ERROR - Invalid Business Address Description");
                return false;
            }

            if (a.AddressStreetNumber == 0)
            {
                MainProgramCode.ShowError("The provided Business Address Street Number is invalid, please provide a valid street number", "ERROR - Invalid Business Address Street Number");
                return false;
            }

            if (string.IsNullOrWhiteSpace(a.AddressStreetName) || a.AddressStreetName.Length < 2)
            {
                MainProgramCode.ShowError("The provided Business Address Street Name is invalid, please provide a valid street name", "ERROR - Invalid Business Address Street Name");
                return false;
            }

            if (string.IsNullOrWhiteSpace(a.AddressSuburb) || a.AddressSuburb.Length < 2)
            {
                MainProgramCode.ShowError("The provided Business Address Suburb is invalid, please provide a valid suburb", "ERROR - Invalid Business Address Suburb");
                return false;
            }

            if (string.IsNullOrWhiteSpace(a.AddressCity) || a.AddressCity.Length < 2)
            {
                MainProgramCode.ShowError("The provided Business Address City is invalid, please provide a valid city", "ERROR - Invalid Business Address City");
                return false;
            }

            if (a.AddressAreaCode == 0)
            {
                MainProgramCode.ShowError("The provided Business Address Area Code is invalid, please provide a valid area code", "ERROR - Invalid Business Address Area Code");
                return false;
            }

            return true;
        }

        bool ValidatePOBoxAddress(Address a)
        {
            if (a == null)
                return false;

            if (string.IsNullOrWhiteSpace(a.AddressDescription) || a.AddressDescription.Length < 2)
            {
                MainProgramCode.ShowError("The provided Business P.O.Box Address Description is invalid, please provide a valid description", "ERROR - Invalid Business P.O.Box Address Description");
                return false;
            }

            if (a.AddressStreetNumber == 0)
            {
                MainProgramCode.ShowError("The provided Business' P.O.Box Address Street Number is invalid, please provide a valid street number", "ERROR - Invalid Business' P.O.Box Address Street Number");
                return false;
            }

            if (string.IsNullOrWhiteSpace(a.AddressSuburb) || a.AddressSuburb.Length < 2)
            {
                MainProgramCode.ShowError("The provided Business' P.O.Box Address Suburb is invalid, please provide a valid suburb", "ERROR - Invalid Business' P.O.Box Address Suburb");
                return false;
            }

            if (string.IsNullOrWhiteSpace(a.AddressCity) || a.AddressCity.Length < 2)
            {
                MainProgramCode.ShowError("The provided Business Address City is invalid, please provide a valid city", "ERROR - Invalid Business' P.O.Box Address City");
                return false;
            }

            if (a.AddressAreaCode == 0)
            {
                MainProgramCode.ShowError("The provided Business Address Area Code is invalid, please provide a valid area code", "ERROR - Invalid Business' P.O.Box Address Area Code");
                return false;
            }

            return true;
        }

        bool ValidateBusiness()
        {
            if (string.IsNullOrWhiteSpace(CurrentBusiness.BusinessName) || CurrentBusiness.BusinessName.Length < 3)
            {
                MainProgramCode.ShowError("The provided business name is invalid, please provide a business name longer that 2 characters.", "ERROR - Invalid Business Name");
                return false;
            }

            if (CurrentBusiness.BusinessLegalDetails == null || string.IsNullOrWhiteSpace(CurrentBusiness.BusinessLegalDetails.VatNumber) || CurrentBusiness.BusinessLegalDetails.VatNumber.Length < 7)
            {
                MainProgramCode.ShowError("The provided VAT number is invalid, please provide a valid VAT number.", "ERROR - Invalid Business VAT Number");
                return false;
            }

            if (CurrentBusiness.BusinessLegalDetails == null || string.IsNullOrWhiteSpace(CurrentBusiness.BusinessLegalDetails.RegistrationNumber) || CurrentBusiness.BusinessLegalDetails.RegistrationNumber.Length < 7)
            {
                MainProgramCode.ShowError("The provided registration number is invalid, please provide a valid registration number.", "ERROR - Invalid Business Registration Number");
                return false;
            }

            if (CurrentBusiness.BusinessAddressList == null || CurrentBusiness.BusinessAddressList.Count == 0)
            {
                MainProgramCode.ShowError("Please add a valid business address under the 'Business Address' section.", "ERROR - Current Business Invalid");
                return false;
            }

            if (CurrentBusiness.BusinessPOBoxAddressList == null || CurrentBusiness.BusinessPOBoxAddressList.Count == 0)
            {
                MainProgramCode.ShowError("Please add a valid business P.O.Box address under the 'Business P.O.Box Address' section.", "ERROR - Current Business Invalid");
                return false;
            }

            if ((CurrentBusiness.BusinessTelephoneNumberList == null || CurrentBusiness.BusinessTelephoneNumberList.Count == 0) &&
                (CurrentBusiness.BusinessCellphoneNumberList == null || CurrentBusiness.BusinessCellphoneNumberList.Count == 0))
            {
                MainProgramCode.ShowError("Please add a valid phone number under the 'Phone Related' section.", "ERROR - Current Business Invalid");
                return false;
            }

            if (CurrentBusiness.BusinessEmailAddressList == null || CurrentBusiness.BusinessEmailAddressList.Count == 0)
            {
                MainProgramCode.ShowError("Please add a valid business email address under the 'Email Related' section.", "ERROR - Current Business Invalid");
                return false;
            }

            return true;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
