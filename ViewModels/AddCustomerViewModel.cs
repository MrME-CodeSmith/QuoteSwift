using System.ComponentModel;

namespace QuoteSwift
{
    public class AddCustomerViewModel : INotifyPropertyChanged
    {
        readonly IDataService dataService;
        readonly INotificationService notificationService;
        readonly IMessageService messageService;
        BindingList<Business> businessList;
        Customer customerToChange;
        bool changeSpecificObject;
        Customer currentCustomer;

        public event PropertyChangedEventHandler PropertyChanged;

        public AddCustomerViewModel(IDataService service, INotificationService notifier, IMessageService messageService)
        {
            dataService = service;
            notificationService = notifier;
            this.messageService = messageService;
            currentCustomer = new Customer();
        }

        public IDataService DataService => dataService;


        public BindingList<Business> BusinessList
        {
            get => businessList;
            private set
            {
                businessList = value;
                OnPropertyChanged(nameof(BusinessList));
            }
        }

        public Customer CustomerToChange
        {
            get => customerToChange;
            set
            {
                customerToChange = value;
                OnPropertyChanged(nameof(CustomerToChange));
            }
        }

        public bool ChangeSpecificObject
        {
            get => changeSpecificObject;
            set
            {
                changeSpecificObject = value;
                OnPropertyChanged(nameof(ChangeSpecificObject));
            }
        }

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
            BusinessList = dataService.LoadBusinessList();
        }

        public void UpdateData(BindingList<Business> businessList,
                               Customer customerToChange = null,
                               bool changeSpecificObject = false)
        {
            BusinessList = businessList;
            CustomerToChange = customerToChange;
            ChangeSpecificObject = changeSpecificObject;
        }

        public bool AddCustomer(Business container)
        {
            if (container == null)
            {
                messageService.ShowError("Please select a valid Business, the current selection is invalid", "ERROR - Invalid Business Selection");
                return false;
            }

            if (container.CustomerMap.ContainsKey(CurrentCustomer.CustomerCompanyName))
            {
                messageService.ShowError("This customer has already been added previously.\nHINT: Customer Name,VAT Number and Registration Number should be unique", "ERROR - Customer Already Added");
                return false;
            }

            container.AddCustomer(CurrentCustomer);
            container.CustomerMap[CurrentCustomer.CustomerCompanyName] = CurrentCustomer;
            CustomerToChange = null;
            ChangeSpecificObject = false;
            return true;
        }

        public bool UpdateCustomer(Business container, string oldName)
        {
            if (container == null)
            {
                messageService.ShowError("Please select a valid Business, the current selection is invalid", "ERROR - Invalid Business Selection");
                return false;
            }

            if (container.CustomerMap.TryGetValue(CurrentCustomer.CustomerCompanyName, out Customer existing) && existing != CustomerToChange)
            {
                messageService.ShowError("This customer name is already in use.", "ERROR - Duplicate Customer Name");
                CurrentCustomer.CustomerCompanyName = oldName;
                return false;
            }

            container.CustomerMap.Remove(oldName);
            container.CustomerMap[CurrentCustomer.CustomerCompanyName] = CurrentCustomer;
            ChangeSpecificObject = false;
            return true;
        }

        public bool AddDeliveryAddress(Address address)
        {
            if (address == null) return false;
            string key = StringUtil.NormalizeKey(address.AddressDescription);
            if (CurrentCustomer.DeliveryAddressMap.ContainsKey(key))
            {
                messageService.ShowError("This address has already been added previously.\nHINT: Description should be unique", "ERROR - Address Already Added");
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
                messageService.ShowError("This P.O.Box address has already been added previously.\nHINT: Description should be unique", "ERROR - P.O.Box Address Already Added");
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
                messageService.ShowError("a Valid Phone Number/s were not provided, please provide at least one valid phone number.", "ERROR - Invalid Number/s Provided");
                return false;
            }

            if (!string.IsNullOrWhiteSpace(telephone) && telephone.Length >= 10 && !CurrentCustomer.TelephoneNumbers.Contains(telephone))
            {
                CurrentCustomer.AddTelephoneNumber(telephone);
                added = true;
            }
            else if (!string.IsNullOrWhiteSpace(telephone) && CurrentCustomer.TelephoneNumbers.Contains(telephone))
            {
                messageService.ShowError("This number has already been added previously.", "ERROR - Number Already Added");
            }

            if (!string.IsNullOrWhiteSpace(cellphone) && cellphone.Length >= 10 && !CurrentCustomer.CellphoneNumbers.Contains(cellphone))
            {
                CurrentCustomer.AddCellphoneNumber(cellphone);
                added = true;
            }
            else if (!string.IsNullOrWhiteSpace(cellphone) && CurrentCustomer.CellphoneNumbers.Contains(cellphone))
            {
                messageService.ShowError("This number has already been added previously.", "ERROR - Number Already Added");
            }

            return added;
        }

        public bool AddEmailAddress(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            {
                notificationService.ShowError("The provided Email Address is invalid. Please provide a valid Email Address", "ERROR - Invalid Email Address");
                return false;
            }

            if (CurrentCustomer.EmailAddresses.Contains(email))
            {
                notificationService.ShowError("This email address has already been added previously.", "ERROR - Email Address Already Added");
                return false;
            }

            CurrentCustomer.AddEmailAddress(email);
            return true;
        }

        public bool ValidateCustomerAddress(Address address)
        {
            if (address == null)
                return false;

            if (string.IsNullOrWhiteSpace(address.AddressDescription) || address.AddressDescription.Length < 2)
            {
                notificationService.ShowError("The provided Business Address Description is invalid, please provide a valid description", "ERROR - Invalid Business Address Description");
                return false;
            }

            if (string.IsNullOrWhiteSpace(address.AddressStreetName) || address.AddressStreetName.Length < 2)
            {
                notificationService.ShowError("The provided Business Address Street Name is invalid, please provide a valid street name", "ERROR - Invalid Business Address Street Name");
                return false;
            }

            if (string.IsNullOrWhiteSpace(address.AddressSuburb) || address.AddressSuburb.Length < 2)
            {
                notificationService.ShowError("The provided Business Address Suburb is invalid, please provide a valid suburb", "ERROR - Invalid Business Address Suburb");
                return false;
            }

            if (string.IsNullOrWhiteSpace(address.AddressCity) || address.AddressCity.Length < 2)
            {
                notificationService.ShowError("The provided Business Address City is invalid, please provide a valid city", "ERROR - Invalid Business Address City");
                return false;
            }

            return true;
        }

        public bool ValidateCustomerPOBoxAddress(Address address)
        {
            if (address == null)
                return false;

            if (string.IsNullOrWhiteSpace(address.AddressDescription) || address.AddressDescription.Length < 2)
            {
                notificationService.ShowError("The provided Business P.O.Box Address Description is invalid, please provide a valid description", "ERROR - Invalid Business P.O.Box Address Description");
                return false;
            }

            if (address.AddressStreetNumber == 0)
            {
                notificationService.ShowError("The provided Business' P.O.Box Address Street Number is invalid, please provide a valid street number", "ERROR - Invalid Business' P.O.Box Address Street Number");
                return false;
            }

            if (string.IsNullOrWhiteSpace(address.AddressSuburb) || address.AddressSuburb.Length < 2)
            {
                notificationService.ShowError("The provided Business' P.O.Box Address Suburb is invalid, please provide a valid suburb", "ERROR - Invalid Business' P.O.Box Address Suburb");
                return false;
            }

            if (string.IsNullOrWhiteSpace(address.AddressCity) || address.AddressCity.Length < 2)
            {
                notificationService.ShowError("The provided Business Address City is invalid, please provide a valid city", "ERROR - Invalid Business' P.O.Box Address City");
                return false;
            }

            if (address.AddressAreaCode == 0)
            {
                notificationService.ShowError("The provided Business Address Area Code is invalid, please provide a valid area code", "ERROR - Invalid Business' P.O.Box Address Area Code");
                return false;
            }

            return true;
        }

        public bool ValidateBusiness()
        {
            if (string.IsNullOrWhiteSpace(CurrentCustomer.CustomerLegalDetails?.VatNumber) || CurrentCustomer.CustomerLegalDetails.VatNumber.Length < 7)
            {
                notificationService.ShowError("The provided VAT number is invalid, please provide a valid VAT number.", "ERROR - Invalid Business VAT Number");
                return false;
            }

            if (string.IsNullOrWhiteSpace(CurrentCustomer.CustomerLegalDetails?.RegistrationNumber) || CurrentCustomer.CustomerLegalDetails.RegistrationNumber.Length < 7)
            {
                notificationService.ShowError("The provided registration number is invalid, please provide a valid registration number.", "ERROR - Invalid Business Registration Number");
                return false;
            }

            if (string.IsNullOrWhiteSpace(CurrentCustomer.VendorNumber) || CurrentCustomer.VendorNumber.Length < 5)
            {
                notificationService.ShowError("The provided vendor number is invalid, please provide a valid vendor number.", "ERROR - Invalid Business Registration Number");
                return false;
            }

            if (CurrentCustomer.DeliveryAddressMap == null || CurrentCustomer.DeliveryAddressMap.Count == 0)
            {
                notificationService.ShowError("Please add a valid customer delivery address under the 'Customer Address' section.", "ERROR - Current Customer Invalid");
                return false;
            }

            if (CurrentCustomer.POBoxMap == null || CurrentCustomer.POBoxMap.Count == 0)
            {
                notificationService.ShowError("Please add a valid customer P.O.Box address under the 'Customer P.O.Box Address' section.", "ERROR - Current Customer Invalid");
                return false;
            }

            if ((CurrentCustomer.CellphoneNumbers == null || CurrentCustomer.CellphoneNumbers.Count == 0) && (CurrentCustomer.TelephoneNumbers == null || CurrentCustomer.TelephoneNumbers.Count == 0))
            {
                notificationService.ShowError("Please add a valid phone number under the 'Phone Related' section.", "ERROR - Current Customer Invalid");
                return false;
            }

            if (CurrentCustomer.EmailAddresses == null || CurrentCustomer.EmailAddresses.Count == 0)
            {
                notificationService.ShowError("Please add a valid customer email address under the 'Email Related' section.", "ERROR - Current Customer Invalid");
                return false;
            }

            return true;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
