using System.ComponentModel;

namespace QuoteSwift
{
    public class ViewCustomersViewModel : INotifyPropertyChanged
    {
        readonly IDataService dataService;
        readonly Pass pass;

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewCustomersViewModel(IDataService service)
        {
            dataService = service;
            pass = new Pass(null, null, null, null);
        }

        public Pass Pass => pass;

        public void LoadData()
        {
            pass.PassBusinessList = dataService.LoadBusinessList();
            pass.PassQuoteMap = dataService.LoadQuoteMap();
        }

        public void UpdatePass(Pass newPass)
        {
            if (newPass == null) return;
            pass.PassQuoteMap = newPass.PassQuoteMap;
            pass.PassBusinessList = newPass.PassBusinessList;
            pass.PassPartList = newPass.PassPartList;
            pass.PassPumpList = newPass.PassPumpList;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
