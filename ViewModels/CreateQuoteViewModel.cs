using System.ComponentModel;

namespace QuoteSwift
{
    public class CreateQuoteViewModel : INotifyPropertyChanged
    {
        readonly IDataService dataService;
        readonly Pass pass;

        public event PropertyChangedEventHandler PropertyChanged;

        public CreateQuoteViewModel(IDataService service)
        {
            dataService = service;
            pass = new Pass(null, null, null, null);
        }

        public IDataService DataService => dataService;

        public Pass Pass => pass;

        public void LoadData()
        {
            pass.PassPartList = dataService.LoadPartList();
            pass.PassPumpList = dataService.LoadPumpList();
            pass.PassBusinessList = dataService.LoadBusinessList();
            pass.PassQuoteMap = dataService.LoadQuoteMap();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
