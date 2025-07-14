using System.ComponentModel;

namespace QuoteSwift
{
    public class ViewPartsViewModel : INotifyPropertyChanged
    {
        readonly IDataService dataService;
        readonly Pass pass;

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewPartsViewModel(IDataService service)
        {
            dataService = service;
            pass = new Pass(null, null, null, null);
        }

        public IDataService DataService => dataService;

        public Pass Pass => pass;

        public void LoadData()
        {
            pass.PassPartList = dataService.LoadPartList();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
