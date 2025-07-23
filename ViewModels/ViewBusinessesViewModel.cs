using System.ComponentModel;
using System.Threading.Tasks;

namespace QuoteSwift
{
    public class ViewBusinessesViewModel : ViewModelBase, ILoadableViewModel
    {
        readonly IDataService dataService;
        readonly INavigationService navigation;
        readonly IMessageService messageService;
        readonly IApplicationService applicationService;
        BindingList<Business> businesses;
        Business selectedBusiness;

        public ICommand LoadDataCommand { get; }
        public ICommand AddBusinessCommand { get; }
        public ICommand UpdateBusinessCommand { get; }
        public ICommand RemoveBusinessCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand ExitCommand { get; }

        public Action CloseAction { get; set; }


        public ViewBusinessesViewModel(IDataService service, INavigationService navigation = null, IMessageService messageService = null, IApplicationService applicationService = null)
        {
            dataService = service;
            this.navigation = navigation;
            this.messageService = messageService;
            this.applicationService = applicationService;
            LoadDataCommand = CreateLoadCommand(LoadDataAsync);
            AddBusinessCommand = new AsyncRelayCommand(async _ =>
            {
                if (navigation != null) await navigation.AddBusiness();
            });
            UpdateBusinessCommand = new AsyncRelayCommand(async _ =>
            {
                if (SelectedBusiness != null)
                {
                    if (navigation != null) await navigation.AddBusiness(SelectedBusiness, false);
                }
                else
                {
                    messageService?.ShowError("Please select a valid Business, the current selection is invalid", "ERROR - Invalid Business Selection");
                }
            }, _ => Task.FromResult(SelectedBusiness != null));

            RemoveBusinessCommand = new RelayCommand(_ => RemoveBusinessWithConfirmation(SelectedBusiness),
                _ => SelectedBusiness != null);

            CancelCommand = CreateCancelCommand(() => CloseAction?.Invoke(), messageService);

            ExitCommand = CreateExitCommand(() =>
            {
                navigation?.SaveAllData();
                applicationService?.Exit();
            }, messageService);
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
                    ((AsyncRelayCommand)UpdateBusinessCommand).RaiseCanExecuteChanged();
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

        void RemoveBusinessWithConfirmation(Business business)
        {
            if (business == null)
                return;

            if (messageService?.RequestConfirmation(
                    "Are you sure you want to permanently delete '" + business.BusinessName + "' from the business list?",
                    "REQUEST - Deletion Request") == true)
            {
                RemoveBusiness(business);
                messageService?.ShowInformation(
                    "Successfully deleted '" + business.BusinessName + "' from the business list",
                    "CONFIRMATION - Deletion Success");
            }
        }

    }
}
