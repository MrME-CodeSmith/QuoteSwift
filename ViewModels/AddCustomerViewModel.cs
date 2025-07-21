using System.ComponentModel;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Linq;

namespace QuoteSwift
{
    public class AddCustomerViewModel : ViewModelBase
    {
        readonly IDataService dataService;
        readonly INotificationService notificationService;
        BindingList<Business> businessList;
        Customer customerToChange;
        bool changeSpecificObject;
        Customer currentCustomer;
        bool lastOperationSuccessful;
        OperationResult lastResult = OperationResult.Successful();
        string formTitle;

        public ICommand AddCustomerCommand { get; }
        public ICommand UpdateCustomerCommand { get; }

        public OperationResult LastResult
        {
            get => lastResult;
            private set
            {
                if (lastResult != value)
                {
                    lastResult = value;
                    OnPropertyChanged(nameof(LastResult));
                }
            }
        }

        public bool LastOperationSuccessful
        {
            get => lastOperationSuccessful;
            private set
            {
                if (lastOperationSuccessful != value)
                {
                    lastOperationSuccessful = value;
                    OnPropertyChanged(nameof(LastOperationSuccessful));
                }
            }
        }

        public bool IsEditing => changeSpecificObject;

        public string FormTitle
        {
            get
            {
                if (customerToChange != null)
                    return IsEditing ?
                        $"Updating {customerToChange.CustomerName}" :
                        $"Viewing {customerToChange.CustomerName}";
                return "Add Customer";
            }
        }


        public AddCustomerViewModel(IDataService service, INotificationService notifier)
        {
            dataService = service;
            notificationService = notifier;
            currentCustomer = new Customer();
            AddCustomerCommand = new RelayCommand(p =>
            {
                var result = AddCustomer(p as Business);
                LastResult = result;
                LastOperationSuccessful = result.Success;
            });
            UpdateCustomerCommand = new RelayCommand(p =>
            {
                if (p is object[] arr && arr.Length == 2 && arr[0] is Business b && arr[1] is string name)
                {
                    var r = UpdateCustomer(b, name);
                    LastResult = r;
                    LastOperationSuccessful = r.Success;
                }
            });
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

        public Business GetBusinessByName(string name)
        {
            if (BusinessList != null && !string.IsNullOrWhiteSpace(name))
            {
                return BusinessList.FirstOrDefault(b => b.BusinessName == name);
            }

            return null;
        }

        public void ClearCurrentCustomer()
        {
            CurrentCustomer = new Customer();
        }

        public Address BuildCustomerAddress(string description,
                                            string att,
                                            string workArea,
                                            string workPlace)
        {
            var address = new Address(description, 0, att, workArea, workPlace, 0);
            return ValidateCustomerAddress(address) ? address : null;
        }

        public Address BuildPOBoxAddress(string description,
                                         string streetNumber,
                                         string suburb,
                                         string city,
                                         string areaCode)
        {
            var address = new Address(description,
                                       ParsingService.ParseInt(streetNumber),
                                       string.Empty,
                                       suburb,
                                       city,
                                       ParsingService.ParseInt(areaCode));
            return ValidateCustomerPOBoxAddress(address) ? address : null;
        }

        public Customer CustomerToChange
        {
            get => customerToChange;
            set
            {
                if (customerToChange != value)
                {
                    customerToChange = value;
                    OnPropertyChanged(nameof(CustomerToChange));
                    OnPropertyChanged(nameof(FormTitle));
                }
            }
        }

        public bool ChangeSpecificObject
        {
            get => changeSpecificObject;
            set
            {
                if (changeSpecificObject != value)
                {
                    changeSpecificObject = value;
                    OnPropertyChanged(nameof(ChangeSpecificObject));
                    OnPropertyChanged(nameof(IsReadOnly));
                    OnPropertyChanged(nameof(IsEditing));
                    OnPropertyChanged(nameof(FormTitle));
                }
            }
        }

        public bool IsReadOnly => !changeSpecificObject;

        public Customer CurrentCustomer
        {
            get => currentCustomer;
            set
            {
                currentCustomer = value;
                OnPropertyChanged(nameof(CurrentCustomer));
                OnPropertyChanged(nameof(FormTitle));
            }
        }

        public void LoadData()
        {
            LoadDataAsync().GetAwaiter().GetResult();
        }

        public async Task LoadDataAsync()
        {
            BusinessList = await dataService.LoadBusinessListAsync();
        }

        public void UpdateData(BindingList<Business> businessList,
                               Customer customerToChange = null,
                               bool changeSpecificObject = false)
        {
            BusinessList = businessList;
            CustomerToChange = customerToChange;
            ChangeSpecificObject = changeSpecificObject;
        }

        public OperationResult AddCustomer(Business container)
        {
            if (container == null)
            {
                return OperationResult.Failure("Please select a valid Business, the current selection is invalid", "ERROR - Invalid Business Selection");
            }

            if (container.CustomerMap.ContainsKey(CurrentCustomer.CustomerCompanyName))
            {
                return OperationResult.Failure("This customer has already been added previously.\nHINT: Customer Name,VAT Number and Registration Number should be unique", "ERROR - Customer Already Added");
            }

            container.AddCustomer(CurrentCustomer);
            container.CustomerMap[CurrentCustomer.CustomerCompanyName] = CurrentCustomer;
            CustomerToChange = null;
            ChangeSpecificObject = false;
            return OperationResult.Successful();
        }

        public OperationResult UpdateCustomer(Business container, string oldName)
        {
            if (container == null)
            {
                return OperationResult.Failure("Please select a valid Business, the current selection is invalid", "ERROR - Invalid Business Selection");
            }

            if (container.CustomerMap.TryGetValue(CurrentCustomer.CustomerCompanyName, out Customer existing) && existing != CustomerToChange)
            {
                CurrentCustomer.CustomerCompanyName = oldName;
                return OperationResult.Failure("This customer name is already in use.", "ERROR - Duplicate Customer Name");
            }

            container.CustomerMap.Remove(oldName);
            container.CustomerMap[CurrentCustomer.CustomerCompanyName] = CurrentCustomer;
            ChangeSpecificObject = false;
            return OperationResult.Successful();
        }

        public OperationResult AddDeliveryAddress(Address address)
        {
            if (address == null) return OperationResult.Failure(null, null);
            string key = StringUtil.NormalizeKey(address.AddressDescription);
            if (CurrentCustomer.DeliveryAddressMap.ContainsKey(key))
            {
                return OperationResult.Failure("This address has already been added previously.\nHINT: Description should be unique", "ERROR - Address Already Added");
            }
            CurrentCustomer.AddDeliveryAddress(address);
            return OperationResult.Successful();
        }

        public OperationResult AddPOBoxAddress(Address address)
        {
            if (address == null) return OperationResult.Failure(null, null);
            string key = StringUtil.NormalizeKey(address.AddressDescription);
            if (CurrentCustomer.POBoxMap.ContainsKey(key))
            {
                return OperationResult.Failure("This P.O.Box address has already been added previously.\nHINT: Description should be unique", "ERROR - P.O.Box Address Already Added");
            }
            CurrentCustomer.AddPOBoxAddress(address);
            return OperationResult.Successful();
        }

        public OperationResult AddPhoneNumbers(string telephone, string cellphone)
        {
            bool added = false;
            if (string.IsNullOrWhiteSpace(telephone) && string.IsNullOrWhiteSpace(cellphone))
            {
                return OperationResult.Failure("a Valid Phone Number/s were not provided, please provide at least one valid phone number.", "ERROR - Invalid Number/s Provided");
            }

            if (!string.IsNullOrWhiteSpace(telephone) && telephone.Length >= 10 && !CurrentCustomer.TelephoneNumbers.Contains(telephone))
            {
                CurrentCustomer.AddTelephoneNumber(telephone);
                added = true;
            }
            else if (!string.IsNullOrWhiteSpace(telephone) && CurrentCustomer.TelephoneNumbers.Contains(telephone))
            {
                LastResult = OperationResult.Failure("This number has already been added previously.", "ERROR - Number Already Added");
            }

            if (!string.IsNullOrWhiteSpace(cellphone) && cellphone.Length >= 10 && !CurrentCustomer.CellphoneNumbers.Contains(cellphone))
            {
                CurrentCustomer.AddCellphoneNumber(cellphone);
                added = true;
            }
            else if (!string.IsNullOrWhiteSpace(cellphone) && CurrentCustomer.CellphoneNumbers.Contains(cellphone))
            {
                LastResult = OperationResult.Failure("This number has already been added previously.", "ERROR - Number Already Added");
            }

            return added ? OperationResult.Successful() : LastResult;
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

    }
}
