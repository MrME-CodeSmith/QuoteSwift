using System.ComponentModel;

namespace QuoteSwift
{
    public class AddPumpViewModel : INotifyPropertyChanged
    {
        readonly IDataService dataService;
        readonly Pass pass;
        Pump currentPump;

        public event PropertyChangedEventHandler PropertyChanged;

        public AddPumpViewModel(IDataService service)
        {
            dataService = service;
            pass = new Pass(null, null, null, null);
            SelectedMandatoryParts = new BindingList<Pump_Part>();
            SelectedNonMandatoryParts = new BindingList<Pump_Part>();
        }

        public IDataService DataService => dataService;

        public Pass Pass => pass;

        public Pump CurrentPump
        {
            get => currentPump;
            set
            {
                currentPump = value;
                OnPropertyChanged(nameof(CurrentPump));
            }
        }

        public BindingList<Pump_Part> SelectedMandatoryParts { get; }

        public BindingList<Pump_Part> SelectedNonMandatoryParts { get; }

        public void LoadData()
        {
            pass.PassPumpList = dataService.LoadPumpList();
            pass.PassPartList = dataService.LoadPartList();
        }

        public void UpdatePass(Pass newPass)
        {
            if (newPass == null) return;
            pass.PassQuoteMap = newPass.PassQuoteMap;
            pass.PassBusinessList = newPass.PassBusinessList;
            pass.PassPartList = newPass.PassPartList;
            pass.PassPumpList = newPass.PassPumpList;
        }

        public bool AddPump()
        {
            if (currentPump == null) return false;
            if (pass.PassPumpList == null)
                pass.PassPumpList = new BindingList<Pump>();

            string key = StringUtil.NormalizeKey(currentPump.PumpName);
            if (pass.RepairableItemNames.Contains(key))
                return false;

            pass.PassPumpList.Add(currentPump);
            pass.RepairableItemNames.Add(key);
            return true;
        }

        public bool UpdatePump()
        {
            if (currentPump == null || pass.PumpToChange == null)
                return false;

            string newKey = StringUtil.NormalizeKey(currentPump.PumpName);
            string oldKey = StringUtil.NormalizeKey(pass.PumpToChange.PumpName);

            if (pass.RepairableItemNames.Contains(newKey) && newKey != oldKey)
                return false;

            pass.PumpToChange.PumpName = currentPump.PumpName;
            pass.PumpToChange.PumpDescription = currentPump.PumpDescription;
            pass.PumpToChange.NewPumpPrice = currentPump.NewPumpPrice;
            pass.PumpToChange.PartList = currentPump.PartList;

            pass.RepairableItemNames.Remove(oldKey);
            pass.RepairableItemNames.Add(newKey);
            return true;
        }

        public void AddPumpPart(Pump pump, Part part, int quantity)
        {
            if (pump == null || part == null)
                return;

            if (pump.PartList == null)
                pump.PartList = new BindingList<Pump_Part>();

            string key = StringUtil.NormalizeKey(part.OriginalItemPartNumber);
            foreach (var pp in pump.PartList)
            {
                if (StringUtil.NormalizeKey(pp.PumpPart.OriginalItemPartNumber) == key)
                {
                    pp.PumpPartQuantity = quantity;
                    return;
                }
            }

            pump.PartList.Add(new Pump_Part(part, quantity));
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
