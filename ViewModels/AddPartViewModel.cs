using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace QuoteSwift
{
    public class AddPartViewModel : ViewModelBase
    {
        readonly IDataService dataService;
        readonly INotificationService notificationService;
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

        public ICommand SavePartCommand { get; }

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


        public AddPartViewModel(IDataService service, INotificationService notifier)
        {
            dataService = service;
            notificationService = notifier;
            CurrentPart = new Part();
            SavePartCommand = new RelayCommand(_ => LastOperationSuccessful = AddOrUpdatePart());
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
            set => partToChange = value;
        }

        public bool ChangeSpecificObject
        {
            get => changeSpecificObject;
            set => changeSpecificObject = value;
        }

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

        public void LoadData()
        {
            PartMap = dataService.LoadPartList();
            PumpList = dataService.LoadPumpList();
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

        public void ImportPartsFromCsv(string file, bool updateDuplicates)
        {
            using (var parser = new TextFieldParser(file))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                while (!parser.EndOfData)
                {
                    string[] readFields = parser.ReadFields();
                    Part newPart = new Part(readFields[1], readFields[2], readFields[0], readFields[3],
                        QuoteSwiftMainCode.ParseBoolean(readFields[6]),
                        QuoteSwiftMainCode.ParseDecimal(readFields[4]));

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
                            QuoteSwiftMainCode.ParseDecimal(readFields[8]), ref newPumpPartList);
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
                            new Pump(readFields[7], "", QuoteSwiftMainCode.ParseDecimal(readFields[8]), ref newPumpPartList)
                        };
                        Pumps = PumpList;
                    }
                }
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
