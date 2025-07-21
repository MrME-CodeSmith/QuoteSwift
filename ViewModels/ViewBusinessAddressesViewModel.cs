using System.ComponentModel;

namespace QuoteSwift
{
    public class ViewBusinessAddressesViewModel : ViewModelBase
    {
        readonly IDataService dataService;
        readonly BindingList<Address> addresses = new BindingList<Address>();
        Business business;
        Customer customer;
        bool changeSpecificObject;


        public ViewBusinessAddressesViewModel(IDataService service)
        {
            dataService = service;
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
                }
            }
        }

        public bool IsReadOnly => !changeSpecificObject;

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

    }
}
