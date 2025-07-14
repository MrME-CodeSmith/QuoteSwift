using System.ComponentModel;

namespace QuoteSwift
{
    public class AddCustomerViewModel : INotifyPropertyChanged
    {
        readonly IDataService dataService;
        readonly Pass pass;
        Customer currentCustomer;

        public event PropertyChangedEventHandler PropertyChanged;

        public AddCustomerViewModel(IDataService service)
        {
            dataService = service;
            pass = new Pass(null, null, null, null);
            currentCustomer = new Customer();
        }

        public IDataService DataService => dataService;

        public Pass Pass => pass;

        public Customer CurrentCustomer
        {
            get => currentCustomer;
            set
            {
                currentCustomer = value;
                OnPropertyChanged(nameof(CurrentCustomer));
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

        public bool AddCustomer(Business container)
        {
            if (container == null)
            {
                MainProgramCode.ShowError("Please select a valid Business, the current selection is invalid", "ERROR - Invalid Business Selection");
                return false;
            }

            if (container.CustomerMap.ContainsKey(CurrentCustomer.CustomerCompanyName))
            {
                MainProgramCode.ShowError("This customer has already been added previously.\nHINT: Customer Name,VAT Number and Registration Number should be unique", "ERROR - Customer Already Added");
                return false;
            }

            container.AddCustomer(CurrentCustomer);
            container.CustomerMap[CurrentCustomer.CustomerCompanyName] = CurrentCustomer;
            pass.CustomerToChange = null;
            pass.ChangeSpecificObject = false;
            return true;
        }

        public bool UpdateCustomer(Business container, string oldName)
        {
            if (container == null)
            {
                MainProgramCode.ShowError("Please select a valid Business, the current selection is invalid", "ERROR - Invalid Business Selection");
                return false;
            }

            if (container.CustomerMap.TryGetValue(CurrentCustomer.CustomerCompanyName, out Customer existing) && existing != pass.CustomerToChange)
            {
                MainProgramCode.ShowError("This customer name is already in use.", "ERROR - Duplicate Customer Name");
                CurrentCustomer.CustomerCompanyName = oldName;
                return false;
            }

            container.CustomerMap.Remove(oldName);
            container.CustomerMap[CurrentCustomer.CustomerCompanyName] = CurrentCustomer;
            pass.ChangeSpecificObject = false;
            return true;
        }

        public bool AddDeliveryAddress(Address address)
        {
            if (address == null) return false;
            string key = StringUtil.NormalizeKey(address.AddressDescription);
            if (CurrentCustomer.DeliveryAddressMap.ContainsKey(key))
            {
                MainProgramCode.ShowError("This address has already been added previously.\nHINT: Description should be unique", "ERROR - Address Already Added");
                return false;
            }
            CurrentCustomer.AddDeliveryAddress(address);
            return true;
        }

        public bool AddPOBoxAddress(Address address)
        {
            if (address == null) return false;
            string key = StringUtil.NormalizeKey(address.AddressDescription);
            if (CurrentCustomer.POBoxMap.ContainsKey(key))
            {
                MainProgramCode.ShowError("This P.O.Box address has already been added previously.\nHINT: Description should be unique", "ERROR - P.O.Box Address Already Added");
                return false;
            }
            CurrentCustomer.AddPOBoxAddress(address);
            return true;
        }

        public bool AddPhoneNumbers(string telephone, string cellphone)
        {
            bool added = false;
            if (string.IsNullOrWhiteSpace(telephone) && string.IsNullOrWhiteSpace(cellphone))
            {
                MainProgramCode.ShowError("a Valid Phone Number/s were not provided, please provide at least one valid phone number.", "ERROR - Invalid Number/s Provided");
                return false;
            }

            if (!string.IsNullOrWhiteSpace(telephone) && telephone.Length >= 10 && !CurrentCustomer.TelephoneNumbers.Contains(telephone))
            {
                CurrentCustomer.AddTelephoneNumber(telephone);
                added = true;
            }
            else if (!string.IsNullOrWhiteSpace(telephone) && CurrentCustomer.TelephoneNumbers.Contains(telephone))
            {
                MainProgramCode.ShowError("This number has already been added previously.", "ERROR - Number Already Added");
            }

            if (!string.IsNullOrWhiteSpace(cellphone) && cellphone.Length >= 10 && !CurrentCustomer.CellphoneNumbers.Contains(cellphone))
            {
                CurrentCustomer.AddCellphoneNumber(cellphone);
                added = true;
            }
            else if (!string.IsNullOrWhiteSpace(cellphone) && CurrentCustomer.CellphoneNumbers.Contains(cellphone))
            {
                MainProgramCode.ShowError("This number has already been added previously.", "ERROR - Number Already Added");
            }

            return added;
        }

        public bool AddEmailAddress(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            {
                MainProgramCode.ShowError("The provided Email Address is invalid. Please provide a valid Email Address", "ERROR - Invalid Email Address");
                return false;
            }

            if (CurrentCustomer.EmailAddresses.Contains(email))
            {
                MainProgramCode.ShowError("This email address has already been added previously.", "ERROR - Email Address Already Added");
                return false;
            }

            CurrentCustomer.AddEmailAddress(email);
            return true;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
