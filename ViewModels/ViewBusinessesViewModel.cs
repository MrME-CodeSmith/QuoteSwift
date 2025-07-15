using System.ComponentModel;

namespace QuoteSwift
{
    public class ViewBusinessesViewModel : INotifyPropertyChanged
    {
        readonly IDataService dataService;
        BindingList<Business> businesses;

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewBusinessesViewModel(IDataService service)
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

        public void LoadData()
        {
            Businesses = dataService.LoadBusinessList();
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

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
