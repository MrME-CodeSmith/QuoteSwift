using System.ComponentModel;
using System.Windows.Input;

namespace QuoteSwift
{
    public class ViewPOBoxAddressesViewModel : ViewModelBase
    {
        readonly IDataService dataService;
        readonly INavigationService navigation;
        readonly BindingList<Address> addresses = new BindingList<Address>();
        Business business;
        Customer customer;
        bool changeSpecificObject;
        Address selectedAddress;

        public ICommand RemoveSelectedAddressCommand { get; }
        public ICommand SaveChangesCommand { get; }


        public ViewPOBoxAddressesViewModel(IDataService service, INavigationService navigation = null)
        {
            dataService = service;
            this.navigation = navigation;
            RemoveSelectedAddressCommand = new RelayCommand(
                _ => RemoveAddress(SelectedAddress),
                _ => SelectedAddress != null);
            SaveChangesCommand = new RelayCommand(_ => navigation?.SaveAllData());
        }

        public IDataService DataService => dataService;

        public BindingList<Address> Addresses => addresses;

        public Business Business
        {
            get => business;
            private set
            {
                business = value;
                OnPropertyChanged(nameof(Business));
            }
        }

        public Customer Customer
        {
            get => customer;
            private set
            {
                customer = value;
                OnPropertyChanged(nameof(Customer));
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
                    OnPropertyChanged(nameof(CanEdit));
                }
            }
        }

        public bool IsReadOnly => !changeSpecificObject;

        public bool CanEdit => changeSpecificObject;

        public void UpdateData(Business business = null, Customer customer = null)
        {
            Business = business;
            Customer = customer;
            RefreshAddresses();
        }

        void RefreshAddresses()
        {
            addresses.Clear();
            if (Business != null && Business.BusinessPOBoxAddressList != null)
            {
                foreach (var a in Business.BusinessPOBoxAddressList)
                    addresses.Add(a);
            }
            else if (Customer != null && Customer.CustomerPOBoxAddress != null)
            {
                foreach (var a in Customer.CustomerPOBoxAddress)
                    addresses.Add(a);
            }
        }

        public Address SelectedAddress
        {
            get => selectedAddress;
            set
            {
                if (SetProperty(ref selectedAddress, value))
                    ((RelayCommand)RemoveSelectedAddressCommand).RaiseCanExecuteChanged();
            }
        }

        void RemoveAddress(Address address)
        {
            if (address == null)
                return;
            if (Business != null)
                Business.RemovePOBoxAddress(address);
            else if (Customer != null)
                Customer.RemovePOBoxAddress(address);
            addresses.Remove(address);
        }

    }
}
