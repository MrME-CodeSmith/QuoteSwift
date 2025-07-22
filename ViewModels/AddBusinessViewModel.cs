using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Input;
using System.Threading.Tasks;

namespace QuoteSwift
{
    public class AddBusinessViewModel : ViewModelBase
    {
        readonly IDataService dataService;
        readonly INavigationService navigation;
        readonly IMessageService messageService;
        BindingList<Business> businessList;
        readonly Dictionary<string, Business> businessLookup = new Dictionary<string, Business>();
        readonly HashSet<string> businessVatNumbers = new HashSet<string>();
        readonly HashSet<string> businessRegNumbers = new HashSet<string>();
        Business businessToChange;
        bool changeSpecificObject;
        Business currentBusiness;
        bool lastOperationSuccessful;
        OperationResult lastResult = OperationResult.Successful();

        string addressDescription;
        string streetNumber;
        string streetName;
        string suburb;
        string city;
        string areaCode;
        string poDescription;
        string poStreetNumber;
        string poSuburb;
        string poCity;
        string poAreaCode;
        string telephoneInput;
        string cellphoneInput;
        string emailInput;

        public ICommand AddAddressCommand { get; }
        public ICommand AddPOBoxAddressCommand { get; }
        public ICommand AddPhoneNumberCommand { get; }
        public ICommand AddEmailCommand { get; }

        public ICommand ViewEmailAddressesCommand { get; }
        public ICommand ViewAddressesCommand { get; }
        public ICommand ViewPOBoxAddressesCommand { get; }
        public ICommand ViewPhoneNumbersCommand { get; }
        
        public ICommand AddBusinessCommand { get; }
        public ICommand UpdateBusinessCommand { get; }
        public ICommand SaveBusinessCommand { get; }
        public ICommand LoadDataCommand { get; }

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

        public string AddressDescription
        {
            get => addressDescription;
            set => SetProperty(ref addressDescription, value);
        }

        public string StreetNumber
        {
            get => streetNumber;
            set => SetProperty(ref streetNumber, value);
        }

        public string StreetName
        {
            get => streetName;
            set => SetProperty(ref streetName, value);
        }

        public string Suburb
        {
            get => suburb;
            set => SetProperty(ref suburb, value);
        }

        public string City
        {
            get => city;
            set => SetProperty(ref city, value);
        }

        public string AreaCode
        {
            get => areaCode;
            set => SetProperty(ref areaCode, value);
        }

        public string PODescription
        {
            get => poDescription;
            set => SetProperty(ref poDescription, value);
        }

        public string POStreetNumber
        {
            get => poStreetNumber;
            set => SetProperty(ref poStreetNumber, value);
        }

        public string POSuburb
        {
            get => poSuburb;
            set => SetProperty(ref poSuburb, value);
        }

        public string POCity
        {
            get => poCity;
            set => SetProperty(ref poCity, value);
        }

        public string POAreaCode
        {
            get => poAreaCode;
            set => SetProperty(ref poAreaCode, value);
        }

        public string TelephoneInput
        {
            get => telephoneInput;
            set => SetProperty(ref telephoneInput, value);
        }

        public string CellphoneInput
        {
            get => cellphoneInput;
            set => SetProperty(ref cellphoneInput, value);
        }

        public string EmailInput
        {
            get => emailInput;
            set => SetProperty(ref emailInput, value);
        }

        public bool IsEditing => changeSpecificObject;

        public string FormTitle
        {
            get
            {
                if (businessToChange != null)
                    return IsEditing ?
                        $"Updating {businessToChange.BusinessName}" :
                        $"Viewing {businessToChange.BusinessName}";
                return "Add Business";
            }
        }


        public AddBusinessViewModel(IDataService service,
                                    INavigationService navigation,
                                    IMessageService messageService)
        {
            dataService = service;
            this.navigation = navigation;
            this.messageService = messageService;
            AddBusinessCommand = new RelayCommand(_ =>
            {
                var result = AddBusiness();
                LastResult = result;
                LastOperationSuccessful = result.Success;
            });
            UpdateBusinessCommand = new RelayCommand(_ =>
            {
                var result = UpdateBusiness();
                LastResult = result;
                LastOperationSuccessful = result.Success;
            });
            SaveBusinessCommand = new RelayCommand(_ =>
            {
                if (ChangeSpecificObject)
                {
                    var result = UpdateBusiness();
                    LastResult = result;
                    LastOperationSuccessful = result.Success;
                }
                else
                {
                    var result = AddBusiness();
                    LastResult = result;
                    LastOperationSuccessful = result.Success;
                }
            });
            AddAddressCommand = new RelayCommand(_ =>
            {
                var a = BuildAddress(AddressDescription, StreetNumber, StreetName, Suburb, City, AreaCode);
                if (a != null)
                {
                    var r = AddAddress(a);
                    LastResult = r;
                    LastOperationSuccessful = r.Success;
                    if (r.Success)
                    {
                        AddressDescription = StreetNumber = StreetName = Suburb = City = AreaCode = string.Empty;
                    }
                }
            });
            AddPOBoxAddressCommand = new RelayCommand(_ =>
            {
                var a = BuildPOBoxAddress(PODescription, POStreetNumber, POSuburb, POCity, POAreaCode);
                if (a != null)
                {
                    var r = AddPOBoxAddress(a);
                    LastResult = r;
                    LastOperationSuccessful = r.Success;
                    if (r.Success)
                    {
                        PODescription = POStreetNumber = POSuburb = POCity = POAreaCode = string.Empty;
                    }
                }
            });
            AddPhoneNumberCommand = new RelayCommand(_ =>
            {
                var r = AddPhoneNumber(TelephoneInput, CellphoneInput);
                LastResult = r;
                LastOperationSuccessful = r.Success;
                if (r.Success)
                {
                    TelephoneInput = CellphoneInput = string.Empty;
                }
            });
            AddEmailCommand = new RelayCommand(_ =>
            {
                var r = AddEmailAddress(EmailInput);
                LastResult = r;
                LastOperationSuccessful = r.Success;
                if (r.Success)
                {
                    EmailInput = string.Empty;
                }
            });
            ViewEmailAddressesCommand = new RelayCommand(_ =>
            {
                if (CurrentBusiness.BusinessEmailAddressList != null)
                {
                    navigation?.ViewBusinessesEmailAddresses(CurrentBusiness, null);
                }
                else
                {
                    messageService.ShowError("You need to first add an Email address before you can view the list of addresses.\nPlease add an address first", "ERROR - Can't View Non-Existing Business Email Addresses");
                }
            });
            ViewAddressesCommand = new RelayCommand(_ =>
            {
                if (CurrentBusiness.BusinessAddressList != null)
                {
                    navigation?.ViewBusinessesAddresses(CurrentBusiness, null);
                }
                else
                {
                    messageService.ShowError("You need to first add an address before you can view the list of addresses.\nPlease add an address first", "ERROR - Can't View Non-Existing Business Addresses");
                }
            });
            ViewPOBoxAddressesCommand = new RelayCommand(_ =>
            {
                if (CurrentBusiness.BusinessPOBoxAddressList != null)
                {
                    navigation?.ViewBusinessesPOBoxAddresses(CurrentBusiness, null);
                }
                else
                {
                    messageService.ShowError("You need to first add an P.O.Box address before you can view the list of addresses.\nPlease add an address first", "ERROR - Can't View Non-Existing Business P.O.Box Addresses");
                }
            });
            ViewPhoneNumbersCommand = new RelayCommand(_ =>
            {
                if (CurrentBusiness.BusinessTelephoneNumberList != null || CurrentBusiness.BusinessCellphoneNumberList != null)
                {
                    navigation?.ViewBusinessesPhoneNumbers(CurrentBusiness, null);
                }
                else
                {
                    messageService.ShowError("You need to first add at least one phone number before you can view the list of phone numbers.\nPlease add a phone number first", "ERROR - Can't View Non-Existing Business Phone Numbers");
                }
            });
            LoadDataCommand = CreateLoadCommand(LoadDataAsync);
        }

        public IDataService DataService => dataService;

        public BindingList<Business> BusinessList
        {
            get => businessList;
            set
            {
                businessList = value;
                SyncLookup();
            }
        }

        public void ClearCurrentBusiness()
        {
            CurrentBusiness = new Business { BusinessLegalDetails = new Legal("", "") };
        }

        public Address BuildAddress(string description,
                                    string streetNumber,
                                    string streetName,
                                    string suburb,
                                    string city,
                                    string areaCode)
        {
            var address = new Address(description,
                                       ParsingService.ParseInt(streetNumber),
                                       streetName,
                                       suburb,
                                       city,
                                       ParsingService.ParseInt(areaCode));

            var result = ValidateAddress(address);
            LastResult = result;
            return result.Success ? address : null;
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

            var result = ValidatePOBoxAddress(address);
            LastResult = result;
            return result.Success ? address : null;
        }

        public Dictionary<string, Business> BusinessLookup => businessLookup;
        public HashSet<string> BusinessVatNumbers => businessVatNumbers;
        public HashSet<string> BusinessRegNumbers => businessRegNumbers;
        public Business BusinessToChange
        {
            get => businessToChange;
            set
            {
                if (businessToChange != value)
                {
                    businessToChange = value;
                    OnPropertyChanged(nameof(BusinessToChange));
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

        public Business CurrentBusiness
        {
            get => currentBusiness;
            set
            {
                if (currentBusiness != value)
                {
                    currentBusiness = value;
                    OnPropertyChanged(nameof(CurrentBusiness));
                    OnPropertyChanged(nameof(FormTitle));
                }
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
                               Business businessToChange = null,
                               bool changeSpecificObject = false)
        {
            BusinessList = businessList;
            this.businessToChange = businessToChange;
            this.changeSpecificObject = changeSpecificObject;
        }

        public OperationResult AddBusiness()
        {
            var valid = ValidateBusiness();
            if (!valid.Success)
                return valid;

            if (businessList == null)
                businessList = new BindingList<Business>();

            if (businessLookup.ContainsKey(CurrentBusiness.BusinessName) ||
                businessVatNumbers.Contains(CurrentBusiness.BusinessLegalDetails?.VatNumber) ||
                businessRegNumbers.Contains(CurrentBusiness.BusinessLegalDetails?.RegistrationNumber))
            {
                return OperationResult.Failure("This business has already been added previously.\nHINT: Business Name,VAT Number and Registration Number should be unique", "ERROR - Business Already Added");
            }

            businessList.Add(CurrentBusiness);
            businessLookup[CurrentBusiness.BusinessName] = CurrentBusiness;
            businessVatNumbers.Add(CurrentBusiness.BusinessLegalDetails?.VatNumber);
            businessRegNumbers.Add(CurrentBusiness.BusinessLegalDetails?.RegistrationNumber);

            businessToChange = null;
            changeSpecificObject = false;
            return OperationResult.Successful();
        }

        public OperationResult UpdateBusiness()
        {
            var valid = ValidateBusiness();
            if (!valid.Success)
                return valid;

            if (businessToChange == null)
                return OperationResult.Failure(null, null);

            string oldName = businessToChange.BusinessName;
            string oldVat = businessToChange.BusinessLegalDetails?.VatNumber;
            string oldReg = businessToChange.BusinessLegalDetails?.RegistrationNumber;

            businessToChange.BusinessName = CurrentBusiness.BusinessName;
            businessToChange.BusinessExtraInformation = CurrentBusiness.BusinessExtraInformation;
            businessToChange.BusinessLegalDetails = new Legal(CurrentBusiness.BusinessLegalDetails?.RegistrationNumber, CurrentBusiness.BusinessLegalDetails?.VatNumber);

            businessLookup.Remove(oldName);
            businessVatNumbers.Remove(oldVat);
            businessRegNumbers.Remove(oldReg);

            CurrentBusiness = businessToChange;
            businessLookup[CurrentBusiness.BusinessName] = CurrentBusiness;
            businessVatNumbers.Add(CurrentBusiness.BusinessLegalDetails?.VatNumber);
            businessRegNumbers.Add(CurrentBusiness.BusinessLegalDetails?.RegistrationNumber);
            
            return OperationResult.Successful();
        }

        public OperationResult AddAddress(Address address)
        {
            var valid = ValidateAddress(address);
            if (!valid.Success)
                return valid;

            string key = StringUtil.NormalizeKey(address.AddressDescription);
            if (CurrentBusiness.AddressMap.ContainsKey(key))
            {
                return OperationResult.Failure("This address has already been added previously.\nHINT: Description should be unique", "ERROR - Address Already Added");
            }

            CurrentBusiness.AddAddress(address);
            return OperationResult.Successful();
        }

        public OperationResult AddPOBoxAddress(Address address)
        {
            var valid = ValidatePOBoxAddress(address);
            if (!valid.Success)
                return valid;

            string key = StringUtil.NormalizeKey(address.AddressDescription);
            if (CurrentBusiness.POBoxMap.ContainsKey(key))
            {
                return OperationResult.Failure("This P.O.Box address has already been added previously.\nHINT: Description should be unique", "ERROR - P.O.Box Address Already Added");
            }

            CurrentBusiness.AddPOBoxAddress(address);
            return OperationResult.Successful();
        }

        public OperationResult AddPhoneNumber(string telephone, string cellphone)
        {
            bool added = false;
            if ((telephone == null || telephone.Length < 10) && (cellphone == null || cellphone.Length < 10))
            {
                return OperationResult.Failure("a Valid Phone Number/s were not provided, please provide at least one valid phone number.", "ERROR - Invalid Number/s Provided");
            }

            if (!string.IsNullOrWhiteSpace(telephone) && telephone.Length >= 10)
            {
                if (CurrentBusiness.TelephoneNumbers.Contains(telephone) || CurrentBusiness.CellphoneNumbers.Contains(telephone))
                {
                    LastResult = OperationResult.Failure("This number has already been added previously.", "ERROR - Number Already Added");
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
                    LastResult = OperationResult.Failure("This number has already been added previously.", "ERROR - Number Already Added");
                }
                else
                {
                    CurrentBusiness.AddCellphoneNumber(cellphone);
                    added = true;
                }
            }

            return added ? OperationResult.Successful() : LastResult;
        }

        public OperationResult AddEmailAddress(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || email.Length <= 3 || !email.Contains("@"))
            {
                return OperationResult.Failure("The provided Email Address is invalid. Please provide a valid Email Address", "ERROR - Invalid Email Address");
            }

            if (CurrentBusiness.EmailAddresses.Contains(email))
            {
                return OperationResult.Failure("This email address has already been added previously.", "ERROR - Email Address Already Added");
            }

            CurrentBusiness.AddEmailAddress(email);
            return OperationResult.Successful();
        }

        OperationResult ValidateAddress(Address a)
        {
            if (a == null)
                return OperationResult.Failure(null, null);

            if (string.IsNullOrWhiteSpace(a.AddressDescription) || a.AddressDescription.Length < 2)
            {
                return OperationResult.Failure("The provided Business Address Description is invalid, please provide a valid description", "ERROR - Invalid Business Address Description");
            }

            if (a.AddressStreetNumber == 0)
            {
                return OperationResult.Failure("The provided Business Address Street Number is invalid, please provide a valid street number", "ERROR - Invalid Business Address Street Number");
            }

            if (string.IsNullOrWhiteSpace(a.AddressStreetName) || a.AddressStreetName.Length < 2)
            {
                return OperationResult.Failure("The provided Business Address Street Name is invalid, please provide a valid street name", "ERROR - Invalid Business Address Street Name");
            }

            if (string.IsNullOrWhiteSpace(a.AddressSuburb) || a.AddressSuburb.Length < 2)
            {
                return OperationResult.Failure("The provided Business Address Suburb is invalid, please provide a valid suburb", "ERROR - Invalid Business Address Suburb");
            }

            if (string.IsNullOrWhiteSpace(a.AddressCity) || a.AddressCity.Length < 2)
            {
                return OperationResult.Failure("The provided Business Address City is invalid, please provide a valid city", "ERROR - Invalid Business Address City");
            }

            if (a.AddressAreaCode == 0)
            {
                return OperationResult.Failure("The provided Business Address Area Code is invalid, please provide a valid area code", "ERROR - Invalid Business Address Area Code");
            }

            return OperationResult.Successful();
        }

        OperationResult ValidatePOBoxAddress(Address a)
        {
            if (a == null)
                return OperationResult.Failure(null, null);

            if (string.IsNullOrWhiteSpace(a.AddressDescription) || a.AddressDescription.Length < 2)
            {
                return OperationResult.Failure("The provided Business P.O.Box Address Description is invalid, please provide a valid description", "ERROR - Invalid Business P.O.Box Address Description");
            }

            if (a.AddressStreetNumber == 0)
            {
                return OperationResult.Failure("The provided Business' P.O.Box Address Street Number is invalid, please provide a valid street number", "ERROR - Invalid Business' P.O.Box Address Street Number");
            }

            if (string.IsNullOrWhiteSpace(a.AddressSuburb) || a.AddressSuburb.Length < 2)
            {
                return OperationResult.Failure("The provided Business' P.O.Box Address Suburb is invalid, please provide a valid suburb", "ERROR - Invalid Business' P.O.Box Address Suburb");
            }

            if (string.IsNullOrWhiteSpace(a.AddressCity) || a.AddressCity.Length < 2)
            {
                return OperationResult.Failure("The provided Business Address City is invalid, please provide a valid city", "ERROR - Invalid Business' P.O.Box Address City");
            }

            if (a.AddressAreaCode == 0)
            {
                return OperationResult.Failure("The provided Business Address Area Code is invalid, please provide a valid area code", "ERROR - Invalid Business' P.O.Box Address Area Code");
            }

            return OperationResult.Successful();
        }

        OperationResult ValidateBusiness()
        {
            if (string.IsNullOrWhiteSpace(CurrentBusiness.BusinessName) || CurrentBusiness.BusinessName.Length < 3)
            {
                return OperationResult.Failure("The provided business name is invalid, please provide a business name longer that 2 characters.", "ERROR - Invalid Business Name");
            }

            if (CurrentBusiness.BusinessLegalDetails == null || string.IsNullOrWhiteSpace(CurrentBusiness.BusinessLegalDetails.VatNumber) || CurrentBusiness.BusinessLegalDetails.VatNumber.Length < 7)
            {
                return OperationResult.Failure("The provided VAT number is invalid, please provide a valid VAT number.", "ERROR - Invalid Business VAT Number");
            }

            if (CurrentBusiness.BusinessLegalDetails == null || string.IsNullOrWhiteSpace(CurrentBusiness.BusinessLegalDetails.RegistrationNumber) || CurrentBusiness.BusinessLegalDetails.RegistrationNumber.Length < 7)
            {
                return OperationResult.Failure("The provided registration number is invalid, please provide a valid registration number.", "ERROR - Invalid Business Registration Number");
            }

            if (CurrentBusiness.BusinessAddressList == null || CurrentBusiness.BusinessAddressList.Count == 0)
            {
                return OperationResult.Failure("Please add a valid business address under the 'Business Address' section.", "ERROR - Current Business Invalid");
            }

            if (CurrentBusiness.BusinessPOBoxAddressList == null || CurrentBusiness.BusinessPOBoxAddressList.Count == 0)
            {
                return OperationResult.Failure("Please add a valid business P.O.Box address under the 'Business P.O.Box Address' section.", "ERROR - Current Business Invalid");
            }

            if ((CurrentBusiness.BusinessTelephoneNumberList == null || CurrentBusiness.BusinessTelephoneNumberList.Count == 0) &&
                (CurrentBusiness.BusinessCellphoneNumberList == null || CurrentBusiness.BusinessCellphoneNumberList.Count == 0))
            {
                return OperationResult.Failure("Please add a valid phone number under the 'Phone Related' section.", "ERROR - Current Business Invalid");
            }

            if (CurrentBusiness.BusinessEmailAddressList == null || CurrentBusiness.BusinessEmailAddressList.Count == 0)
            {
                return OperationResult.Failure("Please add a valid business email address under the 'Email Related' section.", "ERROR - Current Business Invalid");
            }

            return OperationResult.Successful();
        }

        void SyncLookup()
        {
            businessLookup.Clear();
            businessVatNumbers.Clear();
            businessRegNumbers.Clear();
            if (businessList != null)
            {
                foreach (var b in businessList)
                {
                    if (!businessLookup.ContainsKey(b.BusinessName))
                        businessLookup[b.BusinessName] = b;
                    businessVatNumbers.Add(b.BusinessLegalDetails?.VatNumber);
                    businessRegNumbers.Add(b.BusinessLegalDetails?.RegistrationNumber);
                }
            }
        }

    }
}
