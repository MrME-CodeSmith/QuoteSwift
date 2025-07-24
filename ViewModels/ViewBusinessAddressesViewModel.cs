using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuoteSwift
{
    public class ViewBusinessAddressesViewModel : ViewModelBase
    {
        readonly IDataService dataService;
        readonly INavigationService navigation;
        readonly IMessageService messageService;
        readonly IApplicationService applicationService;
        readonly BindingList<Address> addresses = new BindingList<Address>();
        Business business;
        Customer customer;
        bool changeSpecificObject;
        Address selectedAddress;


        public ICommand ExitCommand { get; }
        public ICommand CancelCommand { get; }

        public ICommand RemoveSelectedAddressCommand { get; }
        public ICommand EditAddressCommand { get; }


        public ViewBusinessAddressesViewModel(IDataService service,
                                              INavigationService navigation,
                                              IMessageService messageService,
                                              IApplicationService applicationService = null)
        {
            dataService = service;
            this.navigation = navigation;
            this.messageService = messageService;
            this.applicationService = applicationService;
            RemoveSelectedAddressCommand = new RelayCommand(
                _ => RemoveAddress(SelectedAddress),
                _ => SelectedAddress != null);
            EditAddressCommand = new AsyncRelayCommand(
                _ => EditSelectedAddressAsync(),
                _ => Task.FromResult(SelectedAddress != null));

            CancelCommand = CreateCancelCommand(
                () => CloseAction?.Invoke(),
                messageService,
                "Are you sure you want to cancel the current action?\nCancellation can cause any changes to this current window to be lost.");

            ExitCommand = CreateExitCommand(() =>
            {
                navigation?.SaveAllData();
                applicationService?.Exit();
            }, messageService);
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
            if (Business != null && Business.BusinessAddressList != null)
            {
                foreach (var a in Business.BusinessAddressList)
                    addresses.Add(a);
            }
            else if (Customer != null && Customer.CustomerDeliveryAddressList != null)
            {
                foreach (var a in Customer.CustomerDeliveryAddressList)
                    addresses.Add(a);
            }
        }

        public Address SelectedAddress
        {
            get => selectedAddress;
            set
            {
                if (SetProperty(ref selectedAddress, value))
                {
                    ((RelayCommand)RemoveSelectedAddressCommand).RaiseCanExecuteChanged();
                    ((RelayCommand)EditAddressCommand).RaiseCanExecuteChanged();
                }
            }
        }

        async Task EditSelectedAddressAsync()
        {
            if (SelectedAddress == null)
            {
                messageService.ShowError("Please select a valid Business Address, the current selection is invalid", "ERROR - Invalid Address Selection");
                return;
            }
            if (navigation != null) await navigation.EditBusinessAddress(business, customer, SelectedAddress);
            RefreshAddresses();
        }

        void RemoveAddress(Address address)
        {
            if (address == null)
                return;
            if (Business != null)
                Business.RemoveAddress(address);
            else if (Customer != null)
                Customer.RemoveDeliveryAddress(address);
            addresses.Remove(address);
        }

    }
}
