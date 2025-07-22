using System.ComponentModel;
using System.Windows.Input;

namespace QuoteSwift
{
    public class EditBusinessAddressViewModel : ViewModelBase
    {
        Business business;
        Customer customer;
        Address address;

        string addressDescription = string.Empty;
        int streetNumber;
        string streetName = string.Empty;
        string suburb = string.Empty;
        string city = string.Empty;
        int areaCode;
        OperationResult lastResult = OperationResult.Successful();

        public ICommand UpdateAddressCommand { get; }

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

        public string AddressDescription
        {
            get => addressDescription;
            set => SetProperty(ref addressDescription, value);
        }

        public int StreetNumber
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

        public int AreaCode
        {
            get => areaCode;
            set => SetProperty(ref areaCode, value);
        }


        public EditBusinessAddressViewModel(Business business = null, Customer customer = null, Address address = null)
        {
            Initialize(business, customer, address);

            UpdateAddressCommand = new RelayCommand(_ =>
            {
                var updated = new Address
                {
                    AddressDescription = AddressDescription,
                    AddressStreetNumber = StreetNumber,
                    AddressStreetName = StreetName,
                    AddressSuburb = Suburb,
                    AddressCity = City,
                    AddressAreaCode = AreaCode
                };

                var r = UpdateAddress(updated);
                LastResult = r;
            });
        }

        public void Initialize(Business business = null, Customer customer = null, Address address = null)
        {
            this.business = business;
            this.customer = customer;
            this.address = address;

            if (address != null)
            {
                AddressDescription = address.AddressDescription;
                StreetNumber = address.AddressStreetNumber;
                StreetName = address.AddressStreetName;
                Suburb = address.AddressSuburb;
                City = address.AddressCity;
                AreaCode = address.AddressAreaCode;
            }
        }

        public Business Business => business;
        public Customer Customer => customer;
        public Address Address => address;

        public OperationResult UpdateAddress(Address updated)
        {
            var valid = ValidateInput(updated);
            if (!valid.Success)
                return valid;
            if (AddressExists(updated))
            {
                return OperationResult.Failure("Address not updated since this address is already in the list of addresses.\nNOTE: Address Description should be unique.", "ERROR - Address Already Added");
            }
            if (address != null)
            {
                address.AddressDescription = updated.AddressDescription;
                address.AddressStreetNumber = updated.AddressStreetNumber;
                address.AddressStreetName = updated.AddressStreetName;
                address.AddressSuburb = updated.AddressSuburb;
                address.AddressCity = updated.AddressCity;
                address.AddressAreaCode = updated.AddressAreaCode;
            }
            return OperationResult.Successful();
        }

        OperationResult ValidateInput(Address a)
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

        bool AddressExists(Address a)
        {
            if (a == null) return false;
            string key = StringUtil.NormalizeKey(a.AddressDescription);
            if (business != null && business.AddressMap.TryGetValue(key, out Address existingB))
            {
                if (!ReferenceEquals(existingB, address))
                    return true;
            }
            if (customer != null && customer.DeliveryAddressMap.TryGetValue(key, out Address existingC))
            {
                if (!ReferenceEquals(existingC, address))
                    return true;
            }
            return false;
        }

    }
}
