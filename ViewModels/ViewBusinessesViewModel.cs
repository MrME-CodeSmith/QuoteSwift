using System.ComponentModel;
using System.Threading.Tasks;

namespace QuoteSwift
{
    public class ViewBusinessesViewModel : ViewModelBase
    {
        readonly IDataService dataService;
        BindingList<Business> businesses;

        public ICommand LoadDataCommand { get; }


        public ViewBusinessesViewModel(IDataService service)
        {
            dataService = service;
            LoadDataCommand = new AsyncRelayCommand(_ => LoadDataAsync());
        }

        public IDataService DataService => dataService;

        public BindingList<Business> Businesses
        {
            get => businesses;
            private set
            {
                businesses = value;
                OnPropertyChanged(nameof(Businesses));
            }
        }

        public void LoadData()
        {
            LoadDataAsync().GetAwaiter().GetResult();
        }

        public async Task LoadDataAsync()
        {
            Businesses = await dataService.LoadBusinessListAsync();
        }

        public void UpdateData(BindingList<Business> list)
        {
            Businesses = list;
        }

        public void AddBusiness(Business business)
        {
            Businesses?.Add(business);
        }

        public void RemoveBusiness(Business business)
        {
            Businesses?.Remove(business);
        }

    }
}
