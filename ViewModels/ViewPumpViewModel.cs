using System.ComponentModel;

namespace QuoteSwift
{
    public class ViewPumpViewModel : INotifyPropertyChanged
    {
        readonly IDataService dataService;
        BindingList<Pump> pumps;

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewPumpViewModel(IDataService service)
        {
            dataService = service;
        }

        public IDataService DataService => dataService;

        public BindingList<Pump> Pumps
        {
            get => pumps;
            private set
            {
                pumps = value;
                OnPropertyChanged(nameof(Pumps));
            }
        }

        public void LoadData()
        {
            Pumps = dataService.LoadPumpList();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
