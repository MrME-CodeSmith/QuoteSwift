using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using System.Threading.Tasks;

namespace QuoteSwift
{
    public class AddPartViewModel : ViewModelBase
    {
        readonly IDataService dataService;
        readonly INotificationService notificationService;
        readonly IMessageService messageService;
        readonly IFileDialogService fileDialogService;
        readonly INavigationService navigation;
        readonly IApplicationService applicationService;
        Dictionary<string, Part> partMap;
        BindingList<Pump> pumpList;
        Part partToChange;
        bool changeSpecificObject;
        BindingList<Part> parts;
        BindingList<Pump> pumps;
        Part currentPart;
        Pump selectedPump;
        int quantity;
        bool lastOperationSuccessful;
        string formTitle;

        public ICommand SavePartCommand { get; }
        public ICommand LoadDataCommand { get; }
        public ICommand ImportPartsCommand { get; }
        public ICommand ExitCommand { get; }
        public ICommand ResetInputCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand StartEditCommand { get; }

        public Action CloseAction { get; set; }

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

        public bool IsViewing => partToChange != null && !changeSpecificObject;

        public bool IsAdding => partToChange == null && !changeSpecificObject;

        public bool ShowSaveButton => !IsViewing;

        public string SaveButtonText => changeSpecificObject ? "Update Part" : "Add Part";

        public string FormTitle
        {
            get
            {
                if (partToChange != null)
                    return IsEditing ?
                        $"Updating {partToChange.PartName}" :
                        $"Viewing {partToChange.PartName}";
                return "Add Part";
            }
        }


        public AddPartViewModel(IDataService service, INotificationService notifier,
                                IMessageService messenger = null, IFileDialogService dialogService = null,
                                INavigationService navigation = null, IApplicationService applicationService = null)
        {
            dataService = service;
            notificationService = notifier;
            messageService = messenger;
            fileDialogService = dialogService;
            this.navigation = navigation;
            this.applicationService = applicationService;
            CurrentPart = new Part();
            SavePartCommand = new RelayCommand(_ =>
            {
                if (!ValidateInput())
                    return;

                bool updating = ChangeSpecificObject;
                LastOperationSuccessful = AddOrUpdatePart();
                if (!LastOperationSuccessful)
                {
                    notificationService.ShowInformation(
                        "The provided new part information already has a part which has the same New Part Number or Original Part Number.\nPlease ensure that the provided Part Numbers' are distinct.",
                        "INFORMATION - Part Already Listed");
                    return;
                }

                if (updating)
                {
                    notificationService.ShowInformation(
                        "Successfully updated the part",
                        "CONFIRMATION - Update Successful");
                    ChangeSpecificObject = false;
                }
                else
                {
                    string info = CurrentPart.MandatoryPart ?
                        " successfully added to the mandatory part list." :
                        " successfully added to the non-mandatory part list.";
                    notificationService.ShowInformation(CurrentPart.PartName + info,
                        "INFORMATION - Part Added Success");
                    if (SelectedPump != null)
                    {
                        notificationService.ShowInformation(
                            CurrentPart.PartName + " successfully added to " + SelectedPump.PumpName + " pump the part list.",
                            "INFORMATION - Part Added  To Pump Success");
                    }

                    ResetInput();
                }
            });
            LoadDataCommand = CreateLoadCommand(LoadDataAsync);
            ImportPartsCommand = new AsyncRelayCommand(_ => ImportPartsAsync());
            ExitCommand = CreateExitCommand(() =>
            {
                navigation?.SaveAllData();
                applicationService?.Exit();
            }, messageService);

            ResetInputCommand = new RelayCommand(_ =>
            {
                if (messageService.RequestConfirmation(
                        "Are you sure you want to reset the current screen to it's default values?",
                        "REQUEST - Screen Defaults Reset"))
                    ResetInput();
            });

            CancelCommand = CreateCancelCommand(
                () => CloseAction?.Invoke(),
                messageService,
                "By canceling the current event, any parts not added will not be available in the part's list.",
                "REQUEAST - Action Cancellation");

            StartEditCommand = new RelayCommand(_ =>
            {
                if (PartToChange != null && messageService.RequestConfirmation(
                        $"You are currently only viewing {PartToChange.PartName} part, would you like to update it's details instead?",
                        "REQUEST - Update Specific Part Details"))
                {
                    ChangeSpecificObject = true;
                }
            }, _ => !ChangeSpecificObject);
        }

        public IDataService DataService => dataService;

        public Dictionary<string, Part> PartMap
        {
            get => partMap;
            set => partMap = value;
        }

        public BindingList<Pump> PumpList
        {
            get => pumpList;
            set => pumpList = value;
        }

        public Part PartToChange
        {
            get => partToChange;
            set
            {
                if (partToChange != value)
                {
                    partToChange = value;
                    OnPropertyChanged(nameof(PartToChange));
                    OnPropertyChanged(nameof(FormTitle));
                    OnPropertyChanged(nameof(IsViewing));
                    OnPropertyChanged(nameof(IsAdding));
                    OnPropertyChanged(nameof(ShowSaveButton));
                    OnPropertyChanged(nameof(SaveButtonText));
                }
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
                    OnPropertyChanged(nameof(IsEditing));
                    OnPropertyChanged(nameof(IsViewing));
                    OnPropertyChanged(nameof(IsAdding));
                    OnPropertyChanged(nameof(CanEdit));
                    OnPropertyChanged(nameof(FormTitle));
                    OnPropertyChanged(nameof(ShowSaveButton));
                    OnPropertyChanged(nameof(SaveButtonText));
                    ((RelayCommand)StartEditCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public bool IsReadOnly => !changeSpecificObject;

        public bool CanEdit => changeSpecificObject;

        public BindingList<Part> Parts
        {
            get => parts;
            private set
            {
                parts = value;
                OnPropertyChanged(nameof(Parts));
            }
        }

        public BindingList<Pump> Pumps
        {
            get => pumps;
            private set
            {
                pumps = value;
                OnPropertyChanged(nameof(Pumps));
            }
        }

        public Part CurrentPart
        {
            get => currentPart;
            set
            {
                currentPart = value;
                OnPropertyChanged(nameof(CurrentPart));
                OnPropertyChanged(nameof(FormTitle));
            }
        }

        public Pump SelectedPump
        {
            get => selectedPump;
            set
            {
                selectedPump = value;
                OnPropertyChanged(nameof(SelectedPump));
            }
        }

        public int Quantity
        {
            get => quantity;
            set
            {
                quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        public async Task LoadDataAsync()
        {
            PartMap = await dataService.LoadPartListAsync();
            PumpList = await dataService.LoadPumpListAsync();
            Parts = new BindingList<Part>(PartMap?.Values.ToList() ?? new List<Part>());
            Pumps = PumpList;
            CurrentPart = PartToChange ?? new Part();
        }

        public void UpdateData(Dictionary<string, Part> partMap,
                               BindingList<Pump> pumpList,
                               Part partToChange = null,
                               bool changeSpecificObject = false)
        {
            PartMap = partMap;
            PumpList = pumpList;
            PartToChange = partToChange;
            ChangeSpecificObject = changeSpecificObject;
            Parts = new BindingList<Part>(PartMap?.Values.ToList() ?? new List<Part>());
            Pumps = PumpList;
            CurrentPart = PartToChange ?? new Part();
        }

        public void Initialize()
        {
            CurrentPart = PartToChange ?? new Part();
        }

        public void ResetInput()
        {
            CurrentPart = new Part();
            SelectedPump = null;
            Quantity = 0;
        }

        public bool AddOrUpdatePart()
        {
            if (CurrentPart == null)
                return false;

            if (ChangeSpecificObject && PartToChange != null)
            {
                Part before = new Part(PartToChange);

                PartToChange.PartName = CurrentPart.PartName;
                PartToChange.PartDescription = CurrentPart.PartDescription;
                PartToChange.OriginalItemPartNumber = CurrentPart.OriginalItemPartNumber;
                PartToChange.NewPartNumber = CurrentPart.NewPartNumber;
                PartToChange.PartPrice = CurrentPart.PartPrice;
                PartToChange.MandatoryPart = CurrentPart.MandatoryPart;

                if (before.MandatoryPart && !PartToChange.MandatoryPart)
                    ChangeToNonMandatory(PartToChange);
                else if (!before.MandatoryPart && PartToChange.MandatoryPart)
                    ChangeToMandatory(PartToChange);

                return true;
            }
            else
            {
                var newPart = new Part(CurrentPart);
                if (!DistinctInput(newPart))
                    return false;
                if (PartMap == null)
                    PartMap = new Dictionary<string, Part>();

                AddPart(newPart);
                Parts.Add(newPart);

                if (SelectedPump != null)
                    AddOrOverridePumpPart(SelectedPump, newPart, Quantity);

                CurrentPart = new Part();
                Quantity = 0;
                return true;
            }
        }

        async Task ImportPartsAsync()
        {
            if (messageService == null)
                return;

            string message = "Please ensure that the selected CSV file has the following items in this exact order:\n\n" +
                             "First Column: Original Part Number\n" +
                             "Second Column: Part Name\n" +
                             "Third Column: Part Description\n" +
                             "Fourth Column: New Part Number\n" +
                             "Fifth Column: Part Price\n" +
                             "Sixth Column: Part Quantity (To add this amount of parts to the pump specified) \n" +
                             "Seventh Column: TRUE / FALSE value (Mandatory part)\n" +
                             "Eighth Column: Pump Name(To add a part to a specific pump)\n" +
                             "Ninth Column: Pump Price (Price when pump is bought new)\n" +
                             "Click the OK button to select the file or alternative choose cancel to abort this action.";

            bool proceed = messageService.RequestConfirmation(message, "INFORMATION - CSV Batch Part Import");

            if (!proceed)
                return;

            string file = fileDialogService?.ShowOpenFileDialog("CSV files (*.csv)|*.csv|All Files (*.*)|*.*", "csv");
            if (string.IsNullOrEmpty(file))
                return;

            bool updateDup = messageService.RequestConfirmation(
                "In the case that a duplicate part is being added would you like to update the parts that has already been added before?",
                "REQUEST - Update Duplicate Part");

            try
            {
                await ImportPartsFromCsvAsync(file, updateDup);
                messageService.ShowInformation("The selected CSV file has been successfully imported.", "CONFIRMATION - Batch Part Import Successful");
            }
            catch
            {
                messageService.ShowError("The provided CSV File's format is incorrect, please try again once the format has been corrected.", "ERROR - CSV File Format Incorrect");
            }
        }

        public async Task ImportPartsFromCsvAsync(string file, bool updateDuplicates)
        {
            IsBusy = true;
            try
            {
                using (var parser = new TextFieldParser(file))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                while (!parser.EndOfData)
                {
                    string[] readFields = parser.ReadFields();
                    Part newPart = new Part(readFields[1], readFields[2], readFields[0], readFields[3],
                        ParsingService.ParseBoolean(readFields[6]),
                        ParsingService.ParseDecimal(readFields[4]));

                    Part old = PartToChange;
                    PartToChange = newPart;
                    bool distinct = DistinctInput(newPart);
                    PartToChange = old;

                    if (PartMap == null)
                        PartMap = new Dictionary<string, Part>();

                    Part partForPump = newPart;
                    if (distinct)
                    {
                        AddPart(newPart);
                        Parts.Add(newPart);
                    }
                    else
                    {
                        partForPump = GetPartByOriginal(newPart.OriginalItemPartNumber) ?? newPart;
                        if (updateDuplicates)
                        {
                            string oKey = StringUtil.NormalizeKey(newPart.OriginalItemPartNumber);
                            string nKey = StringUtil.NormalizeKey(newPart.NewPartNumber);
                            if (PartMap.TryGetValue(oKey, out var data) ||
                                TryGetPartByNew(nKey, out data))
                            {
                                data.MandatoryPart = newPart.MandatoryPart;
                                data.PartDescription = newPart.PartDescription;
                                data.PartName = newPart.PartName;
                                data.PartPrice = newPart.PartPrice;
                            }
                        }
                    }

                    bool foundPump = false;
                    BindingList<Pump_Part> newPumpPartList = new BindingList<Pump_Part>();

                    if (PumpList != null)
                    {
                        Pump newPump = new Pump(readFields[7], "",
                            ParsingService.ParseDecimal(readFields[8]), ref newPumpPartList);
                        Pump oldPump = null;
                        foreach (var pump in PumpList)
                        {
                            if (StringUtil.NormalizeKey(pump.PumpName) == StringUtil.NormalizeKey(newPump.PumpName))
                            {
                                foundPump = true;
                                oldPump = pump;
                                break;
                            }
                        }

                        if (!foundPump)
                        {
                            newPumpPartList = new BindingList<Pump_Part> { new Pump_Part(partForPump, int.Parse(readFields[5])) };
                            newPump.PartList = newPumpPartList;
                            PumpList.Add(newPump);
                            Pumps.Add(newPump);
                        }
                        else
                        {
                            AddOrOverridePumpPart(oldPump, partForPump, int.Parse(readFields[5]));
                            if (oldPump.NewPumpPrice != newPump.NewPumpPrice)
                                oldPump.NewPumpPrice = newPump.NewPumpPrice;
                        }
                    }
                    else
                    {
                        newPumpPartList = new BindingList<Pump_Part> { new Pump_Part(partForPump, int.Parse(readFields[5])) };
                        PumpList = new BindingList<Pump>
                        {
                            new Pump(readFields[7], "", ParsingService.ParseDecimal(readFields[8]), ref newPumpPartList)
                        };
                        Pumps = PumpList;
                    }
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        Part GetPartByOriginal(string originalNumber)
        {
            string key = StringUtil.NormalizeKey(originalNumber);
            if (PartMap != null && PartMap.TryGetValue(key, out var part))
                return part;
            return null;
        }

        bool DistinctInput(Part part)
        {
            if (part == null) return false;
            if (PartMap != null)
            {
                string oKey = StringUtil.NormalizeKey(part.OriginalItemPartNumber);
                string nKey = StringUtil.NormalizeKey(part.NewPartNumber);
                if (PartMap.ContainsKey(oKey) || TryGetPartByNew(nKey, out _))
                    return false;
            }
            return true;
        }

        bool ChangeToMandatory(Part switchPart)
        {
            if (switchPart != null)
            {
                switchPart.MandatoryPart = true;
                return true;
            }
            return false;
        }

        bool ChangeToNonMandatory(Part switchPart)
        {
            if (switchPart != null)
            {
                switchPart.MandatoryPart = false;
                return true;
            }
            return false;
        }

        public bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(CurrentPart.PartName) || CurrentPart.PartName.Length < 3)
            {
                notificationService.ShowError("Please ensure that the name of the Item is valid and it has a length greater than two(2) characters.", "ERROR - Invalid Input");
                return false;
            }

            if (string.IsNullOrWhiteSpace(CurrentPart.PartDescription) || CurrentPart.PartDescription.Length < 3)
            {
                notificationService.ShowError("Please ensure that the description of the Item is valid and it has a length greater than two(2) characters.", "ERROR - Invalid Input");
                return false;
            }

            if (string.IsNullOrWhiteSpace(CurrentPart.OriginalItemPartNumber) || CurrentPart.OriginalItemPartNumber.Length < 3)
            {
                notificationService.ShowError("Please ensure that the original part number of the Item is valid and it has a length greater than two(2) characters.", "ERROR - Invalid Input");
                return false;
            }

            if (string.IsNullOrWhiteSpace(CurrentPart.NewPartNumber) || CurrentPart.NewPartNumber.Length < 3)
            {
                notificationService.ShowError("Please ensure that the new part number of the Item is valid and it has a length greater than two(2) characters.", "ERROR - Invalid Input");
                return false;
            }

            if (CurrentPart.PartPrice == 0)
            {
                notificationService.ShowError("Please ensure that the price of the Item is valid and it has a value greater than R99.", "ERROR - Invalid Input");
                return false;
            }

            return true;
        }

        void AddPart(Part part)
        {
            if (part == null) return;
            if (PartMap == null) PartMap = new Dictionary<string, Part>();
            string origKey = StringUtil.NormalizeKey(part.OriginalItemPartNumber);
            PartMap[origKey] = part;
        }

        bool TryGetPartByNew(string newNumber, out Part part)
        {
            part = null;
            if (PartMap == null) return false;
            string key = StringUtil.NormalizeKey(newNumber);
            foreach (var p in PartMap.Values)
            {
                if (StringUtil.NormalizeKey(p.NewPartNumber) == key)
                {
                    part = p;
                    return true;
                }
            }
            return false;
        }

        void AddOrOverridePumpPart(Pump pump, Part part, int qty)
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
                    pp.PumpPartQuantity = qty;
                    return;
                }
            }

            pump.PartList.Add(new Pump_Part(part, qty));
        }

    }
}
