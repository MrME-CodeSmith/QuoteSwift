using System.ComponentModel;

namespace QuoteSwift
{
    public class ViewPumpViewModel : INotifyPropertyChanged
    {
        readonly IDataService dataService;
        readonly Pass pass;

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewPumpViewModel(IDataService service)
        {
            dataService = service;
            pass = new Pass(null, null, null, null);
        }

        public IDataService DataService => dataService;

        public Pass Pass => pass;

        public void LoadData()
        {
            pass.PassPumpList = dataService.LoadPumpList();
        }

        public void UpdatePass(Pass newPass)
        {
            if (newPass == null) return;
            pass.PassQuoteMap = newPass.PassQuoteMap;
            pass.PassBusinessList = newPass.PassBusinessList;
            pass.PassPartList = newPass.PassPartList;
            pass.PassPumpList = newPass.PassPumpList;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
