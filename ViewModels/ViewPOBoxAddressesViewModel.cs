using System.ComponentModel;

namespace QuoteSwift
{
    public class ViewPOBoxAddressesViewModel : ViewModelBase
    {
        readonly IDataService dataService;
        BindingList<Business> businesses;
        bool changeSpecificObject;


        public ViewPOBoxAddressesViewModel(IDataService service)
        {
            dataService = service;
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

        public void LoadData()
        {
            Businesses = dataService.LoadBusinessList();
        }

    }
}
