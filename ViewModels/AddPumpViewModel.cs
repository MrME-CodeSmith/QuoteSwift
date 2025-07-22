using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Input;
using System.Threading.Tasks;

namespace QuoteSwift
{
    public class AddPumpViewModel : ViewModelBase
    {
        readonly IDataService dataService;
        readonly INotificationService notificationService;
        readonly INavigationService navigation;
        Pump currentPump;
        bool lastOperationSuccessful;
        string formTitle;

        public ICommand AddPumpCommand { get; }
        public ICommand UpdatePumpCommand { get; }
        public ICommand SavePumpCommand { get; }
        public ICommand LoadDataCommand { get; }
        public ICommand ExitCommand { get; }

        public bool LastOperationSuccessful
        {
            get => lastOperationSuccessful;
            private set
            {
                if (lastOperationSuccessful != value)
                {
                    lastOperationSuccessful = value;
                    OnPropertyChanged(nameof(LastOperationSuccessful));
                }
            }
        }

        public bool IsEditing => changeSpecificObject;

        public bool IsViewing => pumpToChange != null && !changeSpecificObject;

        public bool IsAdding => pumpToChange == null && !changeSpecificObject;

        public bool ShowSaveButton => !IsViewing;

        public string SaveButtonText => changeSpecificObject ? "Update Pump" : "Add Pump";

        public string FormTitle
        {
            get
            {
                if (PumpToChange != null)
                    return IsEditing ?
                        $"Updating {PumpToChange.PumpName} Pump" :
                        $"Viewing {PumpToChange.PumpName} Pump";
                return "Add Pump";
            }
        }

        public BindingList<Pump> PumpList { get; private set; }
        public Dictionary<string, Part> PartMap { get; private set; }
        public HashSet<string> RepairableItemNames { get; private set; }
        Pump pumpToChange;
        public Pump PumpToChange
        {
            get => pumpToChange;
            set
            {
                if (pumpToChange != value)
                {
                    pumpToChange = value;
                    OnPropertyChanged(nameof(PumpToChange));
                    OnPropertyChanged(nameof(FormTitle));
                    OnPropertyChanged(nameof(IsViewing));
                    OnPropertyChanged(nameof(IsAdding));
                    OnPropertyChanged(nameof(ShowSaveButton));
                    OnPropertyChanged(nameof(SaveButtonText));
                }
            }
        }

        bool changeSpecificObject;
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
                    OnPropertyChanged(nameof(IsEditing));
                    OnPropertyChanged(nameof(IsViewing));
                    OnPropertyChanged(nameof(IsAdding));
                    OnPropertyChanged(nameof(CanEdit));
                    OnPropertyChanged(nameof(FormTitle));
                    OnPropertyChanged(nameof(ShowSaveButton));
                    OnPropertyChanged(nameof(SaveButtonText));
                }
            }
        }

        public bool IsReadOnly => !changeSpecificObject;

        public bool CanEdit => changeSpecificObject;


        public AddPumpViewModel(IDataService service,
                                INotificationService notifier,
                                INavigationService navigation = null)
        {
            dataService = service;
            notificationService = notifier;
            this.navigation = navigation;
            SelectedMandatoryParts = new BindingList<Pump_Part>();
            SelectedNonMandatoryParts = new BindingList<Pump_Part>();
            RepairableItemNames = new HashSet<string>();
            AddPumpCommand = new RelayCommand(_ => LastOperationSuccessful = AddPump());
            UpdatePumpCommand = new RelayCommand(_ => LastOperationSuccessful = UpdatePump());
            SavePumpCommand = new RelayCommand(_ =>
            {
                if (ChangeSpecificObject)
                    LastOperationSuccessful = UpdatePump();
                else
                    LastOperationSuccessful = AddPump();
            });
            LoadDataCommand = CreateLoadCommand(LoadDataAsync);
            ExitCommand = new RelayCommand(_ =>
            {
                navigation?.SaveAllData();
                System.Windows.Forms.Application.Exit();
            });
        }

        public IDataService DataService => dataService;

        public Pump CurrentPump
        {
            get => currentPump;
            set
            {
                currentPump = value;
                OnPropertyChanged(nameof(CurrentPump));
                OnPropertyChanged(nameof(FormTitle));
            }
        }

        public BindingList<Pump_Part> SelectedMandatoryParts { get; }

        public BindingList<Pump_Part> SelectedNonMandatoryParts { get; }

        public async Task LoadDataAsync()
        {
            PumpList = await dataService.LoadPumpListAsync();
            PartMap = await dataService.LoadPartListAsync();
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

        public void UpdateData(BindingList<Pump> pumpList,
                               Dictionary<string, Part> partMap,
                               Pump pumpToChange = null,
                               bool changeSpecificObject = false,
                               HashSet<string> repairableItemNames = null)
        {
            PumpList = pumpList;
            PartMap = partMap;
            PumpToChange = pumpToChange;
            ChangeSpecificObject = changeSpecificObject;
            if (repairableItemNames != null)
                RepairableItemNames = repairableItemNames;
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

        public void RecordNewInformation()
        {
            if (PumpToChange == null || CurrentPump == null)
                return;

            if (PumpToChange.PumpName != CurrentPump.PumpName)
                PumpToChange.PumpName = CurrentPump.PumpName;

            if (PumpToChange.PumpDescription != CurrentPump.PumpDescription)
                PumpToChange.PumpDescription = CurrentPump.PumpDescription;

            if (PumpToChange.NewPumpPrice != CurrentPump.NewPumpPrice)
                PumpToChange.NewPumpPrice = CurrentPump.NewPumpPrice;

            PumpToChange.PartList = new BindingList<Pump_Part>(
                SelectedMandatoryParts.Concat(SelectedNonMandatoryParts).ToList());
        }

        public bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(CurrentPump?.PumpName) || CurrentPump.PumpName.Length < 3)
            {
                notificationService.ShowError("Please ensure the input for the Pump Name is correct and longer than 3 characters.", "INFORMATION -Pump Name Input Incorrect");
                return false;
            }

            if (string.IsNullOrWhiteSpace(CurrentPump?.PumpDescription) || CurrentPump.PumpDescription.Length < 3)
            {
                notificationService.ShowError("Please ensure the input for the description of the pump is correct and longer than 3 characters.", "INFORMATION - Pump Description Input Incorrect");
                return false;
            }

            if (CurrentPump.NewPumpPrice == 0)
            {
                notificationService.ShowError("Please ensure the input for the price of the pump is correct and longer than 2 characters.", "INFORMATION - Pump Price Input Incorrect");
                return false;
            }

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

    }
}
