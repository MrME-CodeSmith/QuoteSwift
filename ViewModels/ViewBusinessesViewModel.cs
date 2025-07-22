using System.ComponentModel;
using System.Threading.Tasks;

namespace QuoteSwift
{
    public class ViewBusinessesViewModel : ViewModelBase
    {
        readonly IDataService dataService;
        readonly INavigationService navigation;
        readonly IMessageService messageService;
        BindingList<Business> businesses;
        Business selectedBusiness;

        public ICommand LoadDataCommand { get; }
        public ICommand AddBusinessCommand { get; }
        public ICommand UpdateBusinessCommand { get; }


        public ViewBusinessesViewModel(IDataService service, INavigationService navigation = null, IMessageService messageService = null)
        {
            dataService = service;
            this.navigation = navigation;
            this.messageService = messageService;
            LoadDataCommand = CreateLoadCommand(LoadDataAsync);
            AddBusinessCommand = new RelayCommand(_ => navigation?.AddBusiness());
            UpdateBusinessCommand = new RelayCommand(_ =>
            {
                if (SelectedBusiness != null)
                    navigation?.AddBusiness(SelectedBusiness, false);
                else
                    messageService?.ShowError("Please select a valid Business, the current selection is invalid", "ERROR - Invalid Business Selection");
            }, _ => SelectedBusiness != null);
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

        public Business SelectedBusiness
        {
            get => selectedBusiness;
            set
            {
                if (SetProperty(ref selectedBusiness, value))
                {
                    ((RelayCommand)UpdateBusinessCommand).RaiseCanExecuteChanged();
                }
            }
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
