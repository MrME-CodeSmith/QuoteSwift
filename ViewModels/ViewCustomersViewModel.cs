using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteSwift
{
    public class ViewCustomersViewModel : ViewModelBase
    {
        readonly IDataService dataService;
        BindingList<Business> businesses;
        SortedDictionary<string, Quote> quoteMap;
        Business selectedBusiness;
        BindingList<Customer> customers;
        public ICommand LoadDataCommand { get; }


        public ViewCustomersViewModel(IDataService service)
        {
            dataService = service;
            LoadDataCommand = new AsyncRelayCommand(_ => LoadDataAsync());
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
            private set
            {
                selectedBusiness = value;
                OnPropertyChanged(nameof(SelectedBusiness));
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

        public void LoadData()
        {
            LoadDataAsync().GetAwaiter().GetResult();
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
            RefreshCustomers();
        }

        public void RefreshCustomers()
        {
            if (SelectedBusiness != null && SelectedBusiness.BusinessCustomerList != null)
                Customers = new BindingList<Customer>(new List<Customer>(SelectedBusiness.BusinessCustomerList));
            else
                Customers = new BindingList<Customer>();
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
