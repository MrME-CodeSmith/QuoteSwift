using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace QuoteSwift
{
    public class CreateQuoteViewModel : ViewModelBase
    {
        readonly IDataService dataService;
        Dictionary<string, Part> partList;
        BindingList<Pump> pumps;
        BindingList<Business> businesses;
        SortedDictionary<string, Quote> quoteMap;
        Business selectedBusiness;
        Customer selectedCustomer;
        Pump selectedPump;
        BindingList<Quote_Part> mandatoryParts = new BindingList<Quote_Part>();
        BindingList<Quote_Part> nonMandatoryParts = new BindingList<Quote_Part>();
        Pricing pricing = new Pricing();
        float repairPercentage;

        public ICommand AddQuoteCommand { get; }


        public CreateQuoteViewModel(IDataService service)
        {
            dataService = service;
            AddQuoteCommand = new RelayCommand(q => AddQuote(q as Quote));
        }

        public IDataService DataService => dataService;

        public Dictionary<string, Part> PartList
        {
            get => partList;
            private set
            {
                partList = value;
                OnPropertyChanged(nameof(PartList));
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

        public BindingList<Business> Businesses
        {
            get => businesses;
            private set
            {
                businesses = value;
                OnPropertyChanged(nameof(Businesses));
            }
        }

        public SortedDictionary<string, Quote> QuoteMap
        {
            get => quoteMap;
            private set
            {
                quoteMap = value;
                OnPropertyChanged(nameof(QuoteMap));
            }
        }

        public Business SelectedBusiness
        {
            get => selectedBusiness;
            set
            {
                selectedBusiness = value;
                OnPropertyChanged(nameof(SelectedBusiness));
            }
        }

        public Customer SelectedCustomer
        {
            get => selectedCustomer;
            set
            {
                selectedCustomer = value;
                OnPropertyChanged(nameof(SelectedCustomer));
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

        public BindingList<Quote_Part> MandatoryParts
        {
            get => mandatoryParts;
            set
            {
                mandatoryParts = value;
                OnPropertyChanged(nameof(MandatoryParts));
            }
        }

        public BindingList<Quote_Part> NonMandatoryParts
        {
            get => nonMandatoryParts;
            set
            {
                nonMandatoryParts = value;
                OnPropertyChanged(nameof(NonMandatoryParts));
            }
        }

        public Pricing Pricing
        {
            get => pricing;
            private set
            {
                pricing = value;
                OnPropertyChanged(nameof(Pricing));
            }
        }

        public float RepairPercentage
        {
            get => repairPercentage;
            private set => SetProperty(ref repairPercentage, value);
        }

        public void LoadData()
        {
            PartList = dataService.LoadPartList();
            Pumps = dataService.LoadPumpList();
            Businesses = dataService.LoadBusinessList();
            QuoteMap = dataService.LoadQuoteMap();
            Pricing = new Pricing();
        }

        public void LoadPartlists()
        {
            if (SelectedPump == null)
            {
                MandatoryParts = new BindingList<Quote_Part>();
                NonMandatoryParts = new BindingList<Quote_Part>();
                Pricing = new Pricing();
                return;
            }

            LoadParts(SelectedPump);
            Calculate();
        }

        void LoadParts(Pump pump)
        {
            MandatoryParts = new BindingList<Quote_Part>();
            NonMandatoryParts = new BindingList<Quote_Part>();

            if (pump.PartList != null)
            {
                foreach (var pp in pump.PartList)
                {
                    var qp = new Quote_Part(pp,
                                            pp.PumpPartQuantity,
                                            0,
                                            pp.PumpPartQuantity,
                                            pp.PumpPartQuantity * pp.PumpPart.PartPrice,
                                            pp.PumpPart.PartPrice,
                                            1);

                    if (pp.PumpPart.MandatoryPart)
                        MandatoryParts.Add(qp);
                    else
                        NonMandatoryParts.Add(qp);
                }

                NonMandatoryParts.Add(new Quote_Part(new Pump_Part(new Part { NewPartNumber = "TS6MACH", PartDescription = "MACHINING", PartPrice = 1000m }, 1), 0, 0, 1, 0, 1000m, 1));
                NonMandatoryParts.Add(new Quote_Part(new Pump_Part(new Part { NewPartNumber = "TS6LAB", PartDescription = "LABOUR", PartPrice = 1000m }, 1), 0, 0, 1, 0, 1000m, 1));
                NonMandatoryParts.Add(new Quote_Part(new Pump_Part(new Part { NewPartNumber = "CON TS6", PartDescription = "CONSUMABLES incl COLLECTION & DELIVERY", PartPrice = 1000m }, 1), 0, 0, 1, 0, 1000m, 1));

                Pricing.PumpPrice = pump.NewPumpPrice;
            }
        }

        public void Calculate()
        {
            decimal sum = 0m;

            foreach (var qp in MandatoryParts)
            {
                qp.MissingorScrap = qp.PumpPart.PumpPartQuantity - qp.Repaired;
                qp.New = qp.MissingorScrap;
                qp.Price = (qp.UnitPrice * qp.New) + (qp.Repaired * (qp.UnitPrice / qp.RepairDevider));
                sum += qp.Price;
            }

            foreach (var qp in NonMandatoryParts)
            {
                qp.MissingorScrap = qp.PumpPart.PumpPartQuantity - qp.Repaired;
                qp.New = qp.MissingorScrap;
                qp.Price = (qp.UnitPrice * qp.New) + (qp.Repaired * (qp.UnitPrice / qp.RepairDevider));
                sum += qp.Price;
            }

            Pricing.SubTotal = sum - Pricing.Rebate;
            Pricing.VAT = Pricing.SubTotal * 0.15m;
            Pricing.TotalDue = Pricing.SubTotal + Pricing.VAT;
            Pricing.Machining = GetPriceForNMItem("MACHINING");
            Pricing.Labour = GetPriceForNMItem("LABOUR");
            Pricing.Consumables = GetPriceForNMItem("CONSUMABLES incl COLLECTION & DELIVERY");

            if (SelectedPump != null && SelectedPump.NewPumpPrice > 0)
                RepairPercentage = (float)(Pricing.SubTotal / SelectedPump.NewPumpPrice * 100);
            else
                RepairPercentage = 0f;
        }

        decimal GetPriceForNMItem(string description)
        {
            if (string.IsNullOrEmpty(description))
                return 0m;

            var part = NonMandatoryParts?.FirstOrDefault(p => p.PumpPart.PumpPart.PartDescription == description);
            return part?.Price ?? 0m;
        }

        bool DistinctQuote(Quote quote)
        {
            if (QuoteMap != null)
            {
                foreach (var kv in QuoteMap)
                {
                    var q = kv.Value;
                    if (q.QuoteJobNumber == quote.QuoteJobNumber || q.QuoteNumber == quote.QuoteNumber)
                        return false;
                }
            }
            return true;
        }

        public Quote CreateQuote(string quoteNumber,
                                 DateTime creationDate,
                                 DateTime expiryDate,
                                 string reference,
                                 string jobNumber,
                                 string prNumber,
                                 DateTime paymentTerm,
                                 Address businessPOBox,
                                 Address customerPOBox,
                                 string lineNumber,
                                 string telefone,
                                 string cellphone,
                                 string email,
                                 int netDays,
                                 Pricing pricing)
        {
            if (SelectedPump == null || SelectedBusiness == null || SelectedCustomer == null)
                return null;

            var quote = new Quote(quoteNumber,
                                  creationDate,
                                  expiryDate,
                                  reference,
                                  jobNumber,
                                  prNumber,
                                  paymentTerm,
                                  new Address(businessPOBox),
                                  new Address(customerPOBox),
                                  lineNumber,
                                  (float)SelectedPump.NewPumpPrice,
                                  ((float)(pricing.SubTotal / SelectedPump.NewPumpPrice) * 100),
                                  SelectedCustomer.CustomerName,
                                  new Customer(SelectedCustomer),
                                  new Business(SelectedBusiness),
                                  new BindingList<Quote_Part>(MandatoryParts.ToList()),
                                  new BindingList<Quote_Part>(NonMandatoryParts.ToList()),
                                  telefone,
                                  cellphone,
                                  email,
                                  netDays,
                                  pricing,
                                  SelectedPump.PumpName);

            quote.QuoteRepairPercentage = ((float)(pricing.SubTotal / SelectedPump.NewPumpPrice * 100));
            return quote;
        }

        public bool AddQuote(Quote quote)
        {
            if (quote == null)
                return false;
            if (!DistinctQuote(quote))
                return false;

            if (QuoteMap == null)
                QuoteMap = new SortedDictionary<string, Quote>();

            QuoteMap[quote.QuoteNumber] = quote;
            dataService.SaveQuotes(QuoteMap);
            return true;
        }

        public void ExportQuoteToTemplate(Quote quote)
        {
            ExcelExporter.ExportQuoteToExcel(quote, null);
        }

    }
}
