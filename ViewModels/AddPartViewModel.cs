using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace QuoteSwift
{
    public class AddPartViewModel : INotifyPropertyChanged
    {
        readonly IDataService dataService;
        readonly Pass pass;
        BindingList<Part> parts;
        BindingList<Pump> pumps;
        Part currentPart;
        Pump selectedPump;
        int quantity;

        public event PropertyChangedEventHandler PropertyChanged;

        public AddPartViewModel(IDataService service)
        {
            dataService = service;
            pass = new Pass(null, null, null, null);
            CurrentPart = new Part();
        }

        public IDataService DataService => dataService;

        public Pass Pass => pass;

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
            pass.PassPartList = dataService.LoadPartList();
            pass.PassPumpList = dataService.LoadPumpList();
            Parts = new BindingList<Part>(pass.PassPartList?.Values.ToList() ?? new List<Part>());
            Pumps = pass.PassPumpList;
            CurrentPart = pass.PartToChange ?? new Part();
        }

        public void UpdatePass(Pass newPass)
        {
            if (newPass == null) return;
            pass.PassQuoteMap = newPass.PassQuoteMap;
            pass.PassBusinessList = newPass.PassBusinessList;
            pass.PassPartList = newPass.PassPartList;
            pass.PassPumpList = newPass.PassPumpList;
            Parts = new BindingList<Part>(pass.PassPartList?.Values.ToList() ?? new List<Part>());
            Pumps = pass.PassPumpList;
            CurrentPart = pass.PartToChange ?? new Part();
        }

        public void Initialize()
        {
            CurrentPart = pass.PartToChange ?? new Part();
        }

        public bool AddOrUpdatePart()
        {
            if (CurrentPart == null)
                return false;

            if (pass.ChangeSpecificObject && pass.PartToChange != null)
            {
                Part before = new Part(pass.PartToChange);

                pass.PartToChange.PartName = CurrentPart.PartName;
                pass.PartToChange.PartDescription = CurrentPart.PartDescription;
                pass.PartToChange.OriginalItemPartNumber = CurrentPart.OriginalItemPartNumber;
                pass.PartToChange.NewPartNumber = CurrentPart.NewPartNumber;
                pass.PartToChange.PartPrice = CurrentPart.PartPrice;
                pass.PartToChange.MandatoryPart = CurrentPart.MandatoryPart;

                if (before.MandatoryPart && !pass.PartToChange.MandatoryPart)
                    ChangeToNonMandatory(pass.PartToChange);
                else if (!before.MandatoryPart && pass.PartToChange.MandatoryPart)
                    ChangeToMandatory(pass.PartToChange);

                return true;
            }
            else
            {
                var newPart = new Part(CurrentPart);
                if (!DistinctInput(newPart))
                    return false;
                if (pass.PassPartList == null)
                    pass.PassPartList = new Dictionary<string, Part>();

                pass.AddPart(newPart);
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

                    Part old = pass.PartToChange;
                    pass.PartToChange = newPart;
                    bool distinct = DistinctInput(newPart);
                    pass.PartToChange = old;

                    if (pass.PassPartList == null)
                        pass.PassPartList = new Dictionary<string, Part>();

                    Part partForPump = newPart;
                    if (distinct)
                    {
                        pass.AddPart(newPart);
                        Parts.Add(newPart);
                    }
                    else
                    {
                        partForPump = GetPartByOriginal(newPart.OriginalItemPartNumber) ?? newPart;
                        if (updateDuplicates)
                        {
                            string oKey = StringUtil.NormalizeKey(newPart.OriginalItemPartNumber);
                            string nKey = StringUtil.NormalizeKey(newPart.NewPartNumber);
                            if (pass.PassPartList.TryGetValue(oKey, out var data) ||
                                pass.TryGetPartByNew(nKey, out data))
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

                    if (pass.PassPumpList != null)
                    {
                        Pump newPump = new Pump(readFields[7], "",
                            QuoteSwiftMainCode.ParseDecimal(readFields[8]), ref newPumpPartList);
                        Pump oldPump = null;
                        foreach (var pump in pass.PassPumpList)
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
                            pass.PassPumpList.Add(newPump);
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
                        pass.PassPumpList = new BindingList<Pump>
                        {
                            new Pump(readFields[7], "", QuoteSwiftMainCode.ParseDecimal(readFields[8]), ref newPumpPartList)
                        };
                        Pumps = pass.PassPumpList;
                    }
                }
            }
        }

        Part GetPartByOriginal(string originalNumber)
        {
            string key = StringUtil.NormalizeKey(originalNumber);
            if (pass.PassPartList != null &&
                pass.PassPartList.TryGetValue(key, out var part))
                return part;
            return null;
        }

        bool DistinctInput(Part part)
        {
            if (part == null) return false;
            if (pass.PassPartList != null)
            {
                string oKey = StringUtil.NormalizeKey(part.OriginalItemPartNumber);
                string nKey = StringUtil.NormalizeKey(part.NewPartNumber);
                if (pass.PassPartList.ContainsKey(oKey) || pass.TryGetPartByNew(nKey, out _))
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

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
