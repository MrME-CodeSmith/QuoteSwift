using System.ComponentModel;
using System.Collections.Generic;

namespace QuoteSwift
{
    public class AddPumpViewModel : INotifyPropertyChanged
    {
        readonly IDataService dataService;
        Pump currentPump;

        public BindingList<Pump> PumpList { get; private set; }
        public Dictionary<string, Part> PartMap { get; private set; }
        public HashSet<string> RepairableItemNames { get; private set; }
        public Pump PumpToChange { get; set; }
        public bool ChangeSpecificObject { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public AddPumpViewModel(IDataService service)
        {
            dataService = service;
            SelectedMandatoryParts = new BindingList<Pump_Part>();
            SelectedNonMandatoryParts = new BindingList<Pump_Part>();
            RepairableItemNames = new HashSet<string>();
        }

        public IDataService DataService => dataService;

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
            PumpList = dataService.LoadPumpList();
            PartMap = dataService.LoadPartList();
            if (PumpList != null)
            {
                RepairableItemNames = new HashSet<string>();
                foreach (var p in PumpList)
                    RepairableItemNames.Add(StringUtil.NormalizeKey(p.PumpName));
            }
            else
            {
                RepairableItemNames = new HashSet<string>();
            }
        }

        public void UpdatePass(Pass newPass)
        {
            if (newPass == null) return;
            PumpList = newPass.PassPumpList;
            PartMap = newPass.PassPartList;
            RepairableItemNames = newPass.RepairableItemNames;
            PumpToChange = newPass.PumpToChange;
            ChangeSpecificObject = newPass.ChangeSpecificObject;
        }

        public bool AddPump()
        {
            if (currentPump == null) return false;
            if (PumpList == null)
                PumpList = new BindingList<Pump>();

            string key = StringUtil.NormalizeKey(currentPump.PumpName);
            if (RepairableItemNames != null && RepairableItemNames.Contains(key))
                return false;

            PumpList.Add(currentPump);
            if (RepairableItemNames == null)
                RepairableItemNames = new HashSet<string>();
            RepairableItemNames.Add(key);
            return true;
        }

        public bool UpdatePump()
        {
            if (currentPump == null || PumpToChange == null)
                return false;

            string newKey = StringUtil.NormalizeKey(currentPump.PumpName);
            string oldKey = StringUtil.NormalizeKey(PumpToChange.PumpName);

            if (RepairableItemNames != null && RepairableItemNames.Contains(newKey) && newKey != oldKey)
                return false;

            PumpToChange.PumpName = currentPump.PumpName;
            PumpToChange.PumpDescription = currentPump.PumpDescription;
            PumpToChange.NewPumpPrice = currentPump.NewPumpPrice;
            PumpToChange.PartList = currentPump.PartList;

            RepairableItemNames?.Remove(oldKey);
            if (RepairableItemNames == null)
                RepairableItemNames = new HashSet<string>();
            RepairableItemNames.Add(newKey);
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
