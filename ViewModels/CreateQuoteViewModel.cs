using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Threading.Tasks;

namespace QuoteSwift
{
    public class CreateQuoteViewModel : ViewModelBase
    {
        readonly IDataService dataService;
        readonly INotificationService notificationService;
        Dictionary<string, Part> partList;
        BindingList<Pump> pumps;
        BindingList<Business> businesses;
        SortedDictionary<string, Quote> quoteMap;
        Business selectedBusiness;
        Customer selectedCustomer;
        Pump selectedPump;
        BindingList<Quote_Part> mandatoryParts = new BindingList<Quote_Part>();
        BindingList<Quote_Part> nonMandatoryParts = new BindingList<Quote_Part>();

        string customerVatNumber;
        string jobNumber;
        string referenceNumber;
        string prNumber;
        string lineNumber;
        string quoteNumber;

        BindingList<string> businessTelephoneNumbers = new BindingList<string>();
        BindingList<string> businessCellphoneNumbers = new BindingList<string>();
        BindingList<string> businessEmailAddresses = new BindingList<string>();
        BindingList<Address> businessPOBoxes = new BindingList<Address>();
        BindingList<Customer> customers = new BindingList<Customer>();
        BindingList<Address> customerDeliveryAddresses = new BindingList<Address>();
        BindingList<Address> customerPOBoxes = new BindingList<Address>();

        Pricing pricing = new Pricing();
        float repairPercentage;

        public ICommand AddQuoteCommand { get; }


        public CreateQuoteViewModel(IDataService service, INotificationService notifier)
        {
            dataService = service;
            notificationService = notifier;
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
                if (SetProperty(ref selectedBusiness, value))
                {
                    if (selectedBusiness != null)
                    {
                        BusinessTelephoneNumbers = selectedBusiness.BusinessTelephoneNumberList != null
                            ? new BindingList<string>(new List<string>(selectedBusiness.BusinessTelephoneNumberList))
                            : new BindingList<string>();
                        BusinessCellphoneNumbers = selectedBusiness.BusinessCellphoneNumberList != null
                            ? new BindingList<string>(new List<string>(selectedBusiness.BusinessCellphoneNumberList))
                            : new BindingList<string>();
                        BusinessEmailAddresses = selectedBusiness.BusinessEmailAddressList != null
                            ? new BindingList<string>(new List<string>(selectedBusiness.BusinessEmailAddressList))
                            : new BindingList<string>();
                        BusinessPOBoxes = selectedBusiness.BusinessPOBoxAddressList != null
                            ? new BindingList<Address>(new List<Address>(selectedBusiness.BusinessPOBoxAddressList))
                            : new BindingList<Address>();
                        Customers = selectedBusiness.BusinessCustomerList != null
                            ? new BindingList<Customer>(new List<Customer>(selectedBusiness.BusinessCustomerList))
                            : new BindingList<Customer>();
                        SelectedCustomer = Customers.Count > 0 ? Customers[0] : null;
                    }
                    else
                    {
                        BusinessTelephoneNumbers = new BindingList<string>();
                        BusinessCellphoneNumbers = new BindingList<string>();
                        BusinessEmailAddresses = new BindingList<string>();
                        BusinessPOBoxes = new BindingList<Address>();
                        Customers = new BindingList<Customer>();
                        SelectedCustomer = null;
                    }
                }
            }
        }

        public Customer SelectedCustomer
        {
            get => selectedCustomer;
            set
            {
                if (SetProperty(ref selectedCustomer, value))
                {
                    if (selectedCustomer != null)
                    {
                        CustomerDeliveryAddresses = selectedCustomer.CustomerDeliveryAddressList != null
                            ? new BindingList<Address>(new List<Address>(selectedCustomer.CustomerDeliveryAddressList))
                            : new BindingList<Address>();
                        CustomerPOBoxes = selectedCustomer.CustomerPOBoxAddress != null
                            ? new BindingList<Address>(new List<Address>(selectedCustomer.CustomerPOBoxAddress))
                            : new BindingList<Address>();
                    }
                    else
                    {
                        CustomerDeliveryAddresses = new BindingList<Address>();
                        CustomerPOBoxes = new BindingList<Address>();
                    }
                }
            }
        }

        public Pump SelectedPump
        {
            get => selectedPump;
            set
            {
                if (SetProperty(ref selectedPump, value))
                {
                    LoadPartlists();
                }
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

        public BindingList<string> BusinessTelephoneNumbers
        {
            get => businessTelephoneNumbers;
            private set
            {
                businessTelephoneNumbers = value;
                OnPropertyChanged(nameof(BusinessTelephoneNumbers));
            }
        }

        public BindingList<string> BusinessCellphoneNumbers
        {
            get => businessCellphoneNumbers;
            private set
            {
                businessCellphoneNumbers = value;
                OnPropertyChanged(nameof(BusinessCellphoneNumbers));
            }
        }

        public BindingList<string> BusinessEmailAddresses
        {
            get => businessEmailAddresses;
            private set
            {
                businessEmailAddresses = value;
                OnPropertyChanged(nameof(BusinessEmailAddresses));
            }
        }

        public BindingList<Address> BusinessPOBoxes
        {
            get => businessPOBoxes;
            private set
            {
                businessPOBoxes = value;
                OnPropertyChanged(nameof(BusinessPOBoxes));
            }
        }

        public BindingList<Customer> Customers
        {
            get => customers;
            private set
            {
                customers = value;
                OnPropertyChanged(nameof(Customers));
            }
        }

        public BindingList<Address> CustomerDeliveryAddresses
        {
            get => customerDeliveryAddresses;
            private set
            {
                customerDeliveryAddresses = value;
                OnPropertyChanged(nameof(CustomerDeliveryAddresses));
            }
        }

        public BindingList<Address> CustomerPOBoxes
        {
            get => customerPOBoxes;
            private set
            {
                customerPOBoxes = value;
                OnPropertyChanged(nameof(CustomerPOBoxes));
            }
        }

        public Address GetBusinessPOBoxByDescription(string description)
        {
            if (SelectedBusiness != null && SelectedBusiness.BusinessPOBoxAddressList != null && !string.IsNullOrWhiteSpace(description))
            {
                return SelectedBusiness.BusinessPOBoxAddressList.SingleOrDefault(p => p.AddressDescription == description);
            }
            return null;
        }

        public Address GetCustomerPOBoxByDescription(string description)
        {
            if (SelectedCustomer != null && SelectedCustomer.CustomerPOBoxAddress != null && !string.IsNullOrWhiteSpace(description))
            {
                return SelectedCustomer.CustomerPOBoxAddress.SingleOrDefault(p => p.AddressDescription == description);
            }
            return null;
        }

        public Address GetCustomerDeliveryAddressByDescription(string description)
        {
            if (SelectedCustomer != null && SelectedCustomer.CustomerDeliveryAddressList != null && !string.IsNullOrWhiteSpace(description))
            {
                return SelectedCustomer.CustomerDeliveryAddressList.SingleOrDefault(p => p.AddressDescription == description);
            }
            return null;
        }

        public string CustomerVATNumber
        {
            get => customerVatNumber;
            set => SetProperty(ref customerVatNumber, value);
        }

        public string JobNumber
        {
            get => jobNumber;
            set => SetProperty(ref jobNumber, value);
        }

        public string ReferenceNumber
        {
            get => referenceNumber;
            set => SetProperty(ref referenceNumber, value);
        }

        public string PRNumber
        {
            get => prNumber;
            set => SetProperty(ref prNumber, value);
        }

        public string LineNumber
        {
            get => lineNumber;
            set => SetProperty(ref lineNumber, value);
        }

        public string QuoteNumber
        {
            get => quoteNumber;
            set => SetProperty(ref quoteNumber, value);
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
            LoadDataAsync().GetAwaiter().GetResult();
        }

        public async Task LoadDataAsync()
        {
            PartList = await dataService.LoadPartListAsync();
            Pumps = await dataService.LoadPumpListAsync();
            Businesses = await dataService.LoadBusinessListAsync();
            QuoteMap = await dataService.LoadQuoteMapAsync();
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

        public bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(CustomerVATNumber) || CustomerVATNumber.Length < 3)
            {
                notificationService?.ShowError("Please provide a valid Customer VAT Number", "ERROR - Invalid Quote Input");
                return false;
            }

            if (string.IsNullOrWhiteSpace(JobNumber) || JobNumber.Length < 3)
            {
                notificationService?.ShowError("Please provide a valid Job Number", "ERROR - Invalid Quote Input");
                return false;
            }

            if (string.IsNullOrWhiteSpace(ReferenceNumber) || ReferenceNumber.Length < 3)
            {
                notificationService?.ShowError("Please provide a valid Reference Number", "ERROR - Invalid Quote Input");
                return false;
            }

            if (string.IsNullOrWhiteSpace(PRNumber) || PRNumber.Length < 3)
            {
                notificationService?.ShowError("Please provide a valid PR Number", "ERROR - Invalid Quote Input");
                return false;
            }

            if (string.IsNullOrWhiteSpace(LineNumber))
            {
                notificationService?.ShowError("Please provide a valid Line Number", "ERROR - Invalid Quote Input");
                return false;
            }

            if (string.IsNullOrWhiteSpace(QuoteNumber) || QuoteNumber.Length < 8)
            {
                notificationService?.ShowError("Please provide a valid Quote Number", "ERROR - Invalid Quote Input");
                return false;
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
