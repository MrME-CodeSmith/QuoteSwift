using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteSwift
{
    public class ViewCustomersViewModel : ViewModelBase, ILoadableViewModel
    {
        readonly IDataService dataService;
        readonly INavigationService navigation;
        readonly IMessageService messageService;
        readonly IApplicationService applicationService;
        BindingList<Business> businesses;
        SortedDictionary<string, Quote> quoteMap;
        Business selectedBusiness;
        BindingList<Customer> customers;
        Customer selectedCustomer;
        public ICommand LoadDataCommand { get; }
        public ICommand AddCustomerCommand { get; }
        public ICommand UpdateCustomerCommand { get; }
        public ICommand RemoveCustomerCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand ExitCommand { get; }

        public Action CloseAction { get; set; }


        public ViewCustomersViewModel(IDataService service, INavigationService navigation = null, IMessageService messageService = null, IApplicationService applicationService = null)
        {
            dataService = service;
            this.navigation = navigation;
            this.messageService = messageService;
            this.applicationService = applicationService;
            LoadDataCommand = CreateLoadCommand(LoadDataAsync);
            AddCustomerCommand = new AsyncRelayCommand(async _ =>
            {
                if (navigation != null) await navigation.AddCustomer();
            });
            UpdateCustomerCommand = new AsyncRelayCommand(async _ =>
            {
                if (SelectedCustomer != null)
                {
                    if (navigation != null) await navigation.AddCustomer(SelectedBusiness, SelectedCustomer, false);
                }
                else
                {
                    messageService?.ShowError("Please select a valid customer, the current selection is invalid", "ERROR - Invalid Customer Selection");
                }
            }, _ => Task.FromResult(SelectedCustomer != null));

            RemoveCustomerCommand = new RelayCommand(_ => RemoveCustomerWithConfirmation(SelectedCustomer),
                _ => SelectedCustomer != null);

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

        public BindingList<Business> Businesses
        {
            get => businesses;
            private set
            {
                businesses = value;
                OnPropertyChanged(nameof(Businesses));
            }
        }

        public SortedDictionary<string, Quote> QuoteMap
        {
            get => quoteMap;
            private set
            {
                quoteMap = value;
                OnPropertyChanged(nameof(QuoteMap));
            }
        }

        public Business SelectedBusiness
        {
            get => selectedBusiness;
            set
            {
                if (SetProperty(ref selectedBusiness, value))
                {
                    RefreshCustomers();
                }
            }
        }

        public BindingList<Customer> Customers
        {
            get => customers;
            private set
            {
                customers = value;
                OnPropertyChanged(nameof(Customers));
            }
        }

        public Customer SelectedCustomer
        {
            get => selectedCustomer;
            set
            {
                if (SetProperty(ref selectedCustomer, value))
                {
                    ((AsyncRelayCommand)UpdateCustomerCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public async Task LoadDataAsync()
        {
            Businesses = await dataService.LoadBusinessListAsync();
            QuoteMap = await dataService.LoadQuoteMapAsync();
            if (Businesses != null && Businesses.Count > 0)
                SelectBusiness(Businesses[0]);
            else
                RefreshCustomers();
        }

        public void SelectBusiness(Business business)
        {
            SelectedBusiness = business;
        }

        public void RefreshCustomers()
        {
            if (SelectedBusiness != null && SelectedBusiness.BusinessCustomerList != null)
                Customers = new BindingList<Customer>(new List<Customer>(SelectedBusiness.BusinessCustomerList));
            else
                Customers = new BindingList<Customer>();

            if (Customers != null)
                foreach (var c in Customers)
                    c.PreviousQuoteDate = GetPreviousQuoteDate(c);
        }

        public Customer GetCustomer(string companyName)
        {
            if (SelectedBusiness != null && SelectedBusiness.CustomerMap != null &&
                SelectedBusiness.CustomerMap.TryGetValue(companyName, out Customer c))
                return c;
            return null;
        }

        public void RemoveCustomer(Customer customer)
        {
            if (SelectedBusiness != null && customer != null)
            {
                SelectedBusiness.RemoveCustomer(customer);
                RefreshCustomers();
            }
        }

        void RemoveCustomerWithConfirmation(Customer customer)
        {
            if (customer == null)
                return;

            if (messageService?.RequestConfirmation(
                    "Are you sure you want to permanently delete '" + customer.CustomerName + "' from the customer list?",
                    "REQUEST - Deletion Request") == true)
            {
                RemoveCustomer(customer);
                messageService?.ShowInformation(
                    "Successfully deleted '" + customer.CustomerName + "' from the business list",
                    "CONFIRMATION - Deletion Success");
            }
        }

        public string GetPreviousQuoteDate(Customer c)
        {
            if (QuoteMap != null)
            {
                DateTime latest = DateTime.MinValue;
                bool found = false;

                foreach (var q in QuoteMap.Values)
                {
                    if (q.QuoteCustomer != null && c != null &&
                        q.QuoteCustomer.CustomerCompanyName == c.CustomerCompanyName)
                    {
                        if (!found || q.QuoteCreationDate.Date > latest.Date)
                        {
                            latest = q.QuoteCreationDate;
                            found = true;
                        }
                    }
                }

                if (found)
                {
                    return latest.ToShortDateString();
                }
            }

            return "No Previous Quote Date Available";
        }

    }
}
