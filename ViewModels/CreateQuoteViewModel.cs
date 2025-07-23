using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Threading.Tasks;

namespace QuoteSwift
{
    public class CreateQuoteViewModel : ViewModelBase, ILoadableViewModel
    {
        readonly IDataService dataService;
        readonly INotificationService notificationService;
        readonly IExcelExportService excelExportService;
        readonly INavigationService navigation;
        readonly IMessageService messageService;
        readonly IApplicationService applicationService;
        readonly ApplicationData appData;
        Dictionary<string, Part> partList;
        BindingList<Pump> pumps;
        BindingList<Business> businesses;
        SortedDictionary<string, Quote> quoteMap;
        string nextQuoteNumber;
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

        Address selectedBusinessPOBox;
        Address selectedCustomerPOBox;
        Address selectedCustomerDeliveryAddress;
        string businessTelephone;
        string businessCellphone;
        string businessEmail;
        string customerDeliveryDescription;
        DateTime quoteCreationDate = DateTime.Today;
        DateTime quoteExpiryDate = DateTime.Today;
        DateTime paymentTerm = DateTime.Today;
        decimal rebateInput;

        Quote quoteToChange;
        bool changeSpecificObject;

        public Action CloseAction { get; set; }

        public ICommand AddQuoteCommand { get; }
        public ICommand SaveQuoteCommand { get; }
        public ICommand CompleteQuoteCommand { get; }
        public ICommand LoadDataCommand { get; }
        public ICommand ExportQuoteCommand { get; }
        public ICommand ExitCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand CalculateRebateCommand { get; }
        public ICommand UpdateDatesCommand { get; }

        Quote lastCreatedQuote;
        public Quote LastCreatedQuote
        {
            get => lastCreatedQuote;
            private set
            {
                if (lastCreatedQuote != value)
                {
                    lastCreatedQuote = value;
                    OnPropertyChanged(nameof(LastCreatedQuote));
                }
            }
        }

        public Quote QuoteToChange
        {
            get => quoteToChange;
            set
            {
                if (SetProperty(ref quoteToChange, value))
                {
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
                if (SetProperty(ref changeSpecificObject, value))
                {
                    OnPropertyChanged(nameof(IsReadOnly));
                    OnPropertyChanged(nameof(IsEditing));
                    OnPropertyChanged(nameof(IsViewing));
                    OnPropertyChanged(nameof(IsAdding));
                    OnPropertyChanged(nameof(CanEdit));
                    OnPropertyChanged(nameof(ShowSaveButton));
                    OnPropertyChanged(nameof(SaveButtonText));
                }
            }
        }

        public bool IsEditing => changeSpecificObject;

        public bool IsViewing => quoteToChange != null && !changeSpecificObject;

        public bool IsAdding => quoteToChange == null && !changeSpecificObject;

        public bool IsReadOnly => !changeSpecificObject;

        public bool CanEdit => changeSpecificObject;

        public bool ShowSaveButton => true;

        public string SaveButtonText => IsViewing ? "Export" : "Complete";


        public CreateQuoteViewModel(IDataService service,
                                    INotificationService notifier,
                                    IExcelExportService excelExporter,
                                    ApplicationData appData,
                                    INavigationService navigation = null,
                                    IMessageService messageService = null,
                                    IApplicationService applicationService = null)
        {
            dataService = service;
            notificationService = notifier;
            excelExportService = excelExporter;
            this.appData = appData;
            this.navigation = navigation;
            this.messageService = messageService;
            this.applicationService = applicationService;
            AddQuoteCommand = new RelayCommand(q => AddQuote(q as Quote));
            SaveQuoteCommand = new RelayCommand(_ => LastCreatedQuote = CreateAndSaveQuote());
            LoadDataCommand = CreateLoadCommand(LoadDataAsync);
            ExportQuoteCommand = new AsyncRelayCommand(q => ExportQuoteToTemplateAsync(q as Quote));
            CompleteQuoteCommand = new AsyncRelayCommand(_ => CompleteQuoteAsync());

            CancelCommand = CreateCancelCommand(
                () => CloseAction?.Invoke(),
                messageService,
                "By canceling the current event, any parts not added will not be available in the part's list.",
                "REQUEAST - Action Cancellation");

            ExitCommand = CreateExitCommand(() =>
            {
                navigation?.SaveAllData();
                applicationService?.Exit();
            }, messageService);
            CalculateRebateCommand = new RelayCommand(_ =>
            {
                Pricing.Rebate = RebateInput;
                Calculate();
            });
            UpdateDatesCommand = new RelayCommand(p =>
            {
                if (p is DateTime date)
                    UpdateDates(date);
            });

            pricing.PropertyChanged += Pricing_PropertyChanged;
            OnPricingChanged();
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
                UpdateNextQuoteNumber();
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
                        OnPropertyChanged(nameof(BusinessRegistrationNumberDisplay));
                        OnPropertyChanged(nameof(BusinessVATNumberDisplay));
                }
                else
                {
                    BusinessTelephoneNumbers = new BindingList<string>();
                    BusinessCellphoneNumbers = new BindingList<string>();
                        BusinessEmailAddresses = new BindingList<string>();
                        BusinessPOBoxes = new BindingList<Address>();
                        Customers = new BindingList<Customer>();
                        SelectedCustomer = null;
                        OnPropertyChanged(nameof(BusinessRegistrationNumberDisplay));
                        OnPropertyChanged(nameof(BusinessVATNumberDisplay));
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
                        CustomerVATNumber = selectedCustomer.CustomerLegalDetails?.VatNumber;
                        OnPropertyChanged(nameof(CustomerVendorNumberDisplay));
                    }
                    else
                    {
                        CustomerDeliveryAddresses = new BindingList<Address>();
                        CustomerPOBoxes = new BindingList<Address>();
                        CustomerVATNumber = string.Empty;
                        OnPropertyChanged(nameof(CustomerVendorNumberDisplay));
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

        public string NextQuoteNumber
        {
            get => nextQuoteNumber;
            private set => SetProperty(ref nextQuoteNumber, value);
        }

        public Pricing Pricing
        {
            get => pricing;
            private set
            {
                if (pricing != null)
                    pricing.PropertyChanged -= Pricing_PropertyChanged;
                pricing = value;
                if (pricing != null)
                    pricing.PropertyChanged += Pricing_PropertyChanged;
                OnPropertyChanged(nameof(Pricing));
                OnPricingChanged();
            }
        }

        public float RepairPercentage
        {
            get => repairPercentage;
            private set
            {
                if (SetProperty(ref repairPercentage, value))
                    OnPropertyChanged(nameof(RepairPercentageDisplay));
            }
        }

        public string PumpPriceDisplay => $"New Pump Price: R {Pricing.PumpPrice}";
        public string RebateDisplay => $"R{Pricing.Rebate}";
        public string SubTotalDisplay => $"R{Pricing.SubTotal}";
        public string VATDisplay => $"R{Pricing.VAT}";
        public string TotalDueDisplay => $"R{Pricing.TotalDue}";
        public string RepairPercentageDisplay => $"Repair Percentage: {RepairPercentage}%";

        void Pricing_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPricingChanged();
        }

        void OnPricingChanged()
        {
            OnPropertyChanged(nameof(PumpPriceDisplay));
            OnPropertyChanged(nameof(RebateDisplay));
            OnPropertyChanged(nameof(SubTotalDisplay));
            OnPropertyChanged(nameof(VATDisplay));
            OnPropertyChanged(nameof(TotalDueDisplay));
        }

        public Address SelectedBusinessPOBox
        {
            get => selectedBusinessPOBox;
            set
            {
                if (SetProperty(ref selectedBusinessPOBox, value))
                {
                    OnPropertyChanged(nameof(BusinessPOBoxNumberDisplay));
                    OnPropertyChanged(nameof(BusinessPOBoxSuburbDisplay));
                    OnPropertyChanged(nameof(BusinessPOBoxCityDisplay));
                    OnPropertyChanged(nameof(BusinessPOBoxAreaCodeDisplay));
                }
            }
        }

        public Address SelectedCustomerPOBox
        {
            get => selectedCustomerPOBox;
            set
            {
                if (SetProperty(ref selectedCustomerPOBox, value))
                {
                    OnPropertyChanged(nameof(CustomerPOBoxStreetNameDisplay));
                    OnPropertyChanged(nameof(CustomerPOBoxSuburbDisplay));
                    OnPropertyChanged(nameof(CustomerPOBoxCityDisplay));
                    OnPropertyChanged(nameof(CustomerPOBoxAreaCodeDisplay));
                }
            }
        }

        public Address SelectedCustomerDeliveryAddress
        {
            get => selectedCustomerDeliveryAddress;
            set
            {
                if (SetProperty(ref selectedCustomerDeliveryAddress, value))
                {
                    CustomerDeliveryDescription = value != null ?
                        $"ATT: {value.AddressStreetName}\n{value.AddressSuburb}\n{value.AddressCity}" :
                        string.Empty;
                    OnPropertyChanged(nameof(CustomerDeliveryAddressDisplay));
                }
            }
        }

        public string BusinessTelephone
        {
            get => businessTelephone;
            set => SetProperty(ref businessTelephone, value);
        }

        public string BusinessCellphone
        {
            get => businessCellphone;
            set => SetProperty(ref businessCellphone, value);
        }

        public string BusinessEmail
        {
            get => businessEmail;
            set => SetProperty(ref businessEmail, value);
        }

        public string CustomerDeliveryDescription
        {
            get => customerDeliveryDescription;
            set => SetProperty(ref customerDeliveryDescription, value);
        }

        public DateTime QuoteCreationDate
        {
            get => quoteCreationDate;
            set => SetProperty(ref quoteCreationDate, value);
        }

        public DateTime QuoteExpiryDate
        {
            get => quoteExpiryDate;
            set => SetProperty(ref quoteExpiryDate, value);
        }

        public DateTime PaymentTerm
        {
            get => paymentTerm;
            set => SetProperty(ref paymentTerm, value);
        }

        public decimal RebateInput
        {
            get => rebateInput;
            set => SetProperty(ref rebateInput, value);
        }

        public string BusinessPOBoxNumberDisplay =>
            SelectedBusinessPOBox != null ?
                $"P.O.Box Number {SelectedBusinessPOBox.AddressStreetNumber}" : string.Empty;

        public string BusinessPOBoxSuburbDisplay =>
            SelectedBusinessPOBox != null ?
                $"Suburb: {SelectedBusinessPOBox.AddressSuburb}" : string.Empty;

        public string BusinessPOBoxCityDisplay =>
            SelectedBusinessPOBox != null ?
                $"City: {SelectedBusinessPOBox.AddressCity}" : string.Empty;

        public string BusinessPOBoxAreaCodeDisplay =>
            SelectedBusinessPOBox != null ?
                $"Area Code: {SelectedBusinessPOBox.AddressAreaCode}" : string.Empty;

        public string CustomerPOBoxStreetNameDisplay =>
            SelectedCustomerPOBox != null ?
                $"P.O.Box Number {SelectedCustomerPOBox.AddressStreetNumber}" : string.Empty;

        public string CustomerPOBoxSuburbDisplay =>
            SelectedCustomerPOBox != null ?
                $"Suburb: {SelectedCustomerPOBox.AddressSuburb}" : string.Empty;

        public string CustomerPOBoxCityDisplay =>
            SelectedCustomerPOBox != null ?
                $"City: {SelectedCustomerPOBox.AddressCity}" : string.Empty;

        public string CustomerPOBoxAreaCodeDisplay =>
            SelectedCustomerPOBox != null ?
                $"Area Code: {SelectedCustomerPOBox.AddressAreaCode}" : string.Empty;

        public string BusinessRegistrationNumberDisplay =>
            SelectedBusiness != null ?
                $"Registration Number: {SelectedBusiness.BusinessLegalDetails.RegistrationNumber}" : string.Empty;

        public string BusinessVATNumberDisplay =>
            SelectedBusiness != null ?
                $"VAT Number: {SelectedBusiness.BusinessLegalDetails.VatNumber}" : string.Empty;

        public string CustomerVendorNumberDisplay =>
            SelectedCustomer != null ?
                $"Vendor Number: {SelectedCustomer.VendorNumber}" : string.Empty;

        public string CustomerDeliveryAddressDisplay =>
            SelectedCustomerDeliveryAddress != null ?
                $"ATT: {SelectedCustomerDeliveryAddress.AddressStreetName}\n{SelectedCustomerDeliveryAddress.AddressSuburb}\n{SelectedCustomerDeliveryAddress.AddressCity}" :
                string.Empty;

        public async Task LoadDataAsync()
        {
            PartList = appData.PartList;
            Pumps = appData.PumpList;
            Businesses = appData.BusinessList;
            QuoteMap = appData.QuoteMap;
            Pricing = new Pricing();
            PrepareComboBoxLists();
            await Task.CompletedTask;
        }

        public void LoadQuote(Quote quote)
        {
            if (quote == null)
                return;

            QuoteNumber = quote.QuoteNumber;
            ReferenceNumber = quote.QuoteReference;
            JobNumber = quote.QuoteJobNumber;
            PRNumber = quote.QuotePRNumber;
            LineNumber = quote.QuoteLineNumber;
            CustomerVATNumber = quote.QuoteCustomer.CustomerLegalDetails.VatNumber;

            QuoteCreationDate = quote.QuoteCreationDate;
            QuoteExpiryDate = quote.QuoteExpireyDate;
            PaymentTerm = quote.QuotePaymentTerm;

            BusinessTelephone = quote.Telefone;
            BusinessCellphone = quote.Cellphone;
            BusinessEmail = quote.Email;
            CustomerDeliveryDescription = quote.QuoteDeliveryAddress;

            SelectedCustomerDeliveryAddress = null;

            Pricing = new Pricing(quote.QuoteCost.Machining,
                                 quote.QuoteCost.Labour,
                                 quote.QuoteCost.Consumables,
                                 quote.QuoteCost.Rebate,
                                 quote.QuoteCost.SubTotal,
                                 quote.QuoteCost.VAT,
                                 quote.QuoteCost.TotalDue,
                                 quote.QuoteCost.PumpPrice);
            RepairPercentage = quote.QuoteRepairPercentage;

            SelectedBusiness = Businesses?.FirstOrDefault(b => b.BusinessName == quote.QuoteCompany.BusinessName);
            if (SelectedBusiness != null)
            {
                SelectedBusinessPOBox = SelectedBusiness.BusinessPOBoxAddressList?.FirstOrDefault(a => a.AddressDescription == quote.QuoteBusinessPOBox.AddressDescription);
                SelectedCustomer = SelectedBusiness.BusinessCustomerList?.FirstOrDefault(c => c.CustomerCompanyName == quote.QuoteCustomer.CustomerCompanyName);
            }

            if (SelectedCustomer != null)
                SelectedCustomerPOBox = SelectedCustomer.CustomerPOBoxAddress?.FirstOrDefault(a => a.AddressDescription == quote.QuoteCustomerPOBox.AddressDescription);

            SelectedPump = Pumps?.FirstOrDefault(p => p.PumpName == quote.PumpName);

            MandatoryParts = new BindingList<Quote_Part>(quote.QuoteMandatoryPartList.ToList());
            NonMandatoryParts = new BindingList<Quote_Part>(quote.QuoteNewList.ToList());
            NonMandatoryParts.Add(new Quote_Part(new Pump_Part(new Part { NewPartNumber = "TS6MACH", PartDescription = "MACHINING", PartPrice = quote.QuoteCost.Machining }, 1), 0, 0, 1, quote.QuoteCost.Machining, quote.QuoteCost.Machining, 1));
            NonMandatoryParts.Add(new Quote_Part(new Pump_Part(new Part { NewPartNumber = "TS6LAB", PartDescription = "LABOUR", PartPrice = quote.QuoteCost.Labour }, 1), 0, 0, 1, quote.QuoteCost.Labour, quote.QuoteCost.Labour, 1));
            NonMandatoryParts.Add(new Quote_Part(new Pump_Part(new Part { NewPartNumber = "CON TS6", PartDescription = "CONSUMABLES incl COLLECTION & DELIVERY", PartPrice = quote.QuoteCost.Consumables }, 1), 0, 0, 1, quote.QuoteCost.Consumables, quote.QuoteCost.Consumables, 1));
        }

        public void LoadFromQuote(Quote quote)
        {
            LoadQuote(quote);
            PrepareComboBoxLists();
        }

        public void PrepareComboBoxLists()
        {
            if (Businesses != null && Businesses.Count > 0)
                SelectedBusiness = Businesses[0];
            else
                SelectedBusiness = null;

            if (Pumps != null && Pumps.Count > 0)
                SelectedPump = Pumps[0];
            else
                SelectedPump = null;

            if (Customers != null && Customers.Count > 0)
                SelectedCustomer = Customers[0];
            else
                SelectedCustomer = null;

            if (BusinessPOBoxes != null && BusinessPOBoxes.Count > 0)
                SelectedBusinessPOBox = BusinessPOBoxes[0];
            else
                SelectedBusinessPOBox = null;

            if (CustomerPOBoxes != null && CustomerPOBoxes.Count > 0)
                SelectedCustomerPOBox = CustomerPOBoxes[0];
            else
                SelectedCustomerPOBox = null;

            if (CustomerDeliveryAddresses != null && CustomerDeliveryAddresses.Count > 0)
                SelectedCustomerDeliveryAddress = CustomerDeliveryAddresses[0];
            else
                SelectedCustomerDeliveryAddress = null;

            BusinessTelephone = BusinessTelephoneNumbers?.FirstOrDefault();
            BusinessCellphone = BusinessCellphoneNumbers?.FirstOrDefault();
            BusinessEmail = BusinessEmailAddresses?.FirstOrDefault();
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

        void UpdateDates(DateTime value)
        {
            // Determine which date changed based on current bindings
            if (value == QuoteCreationDate)
            {
                QuoteExpiryDate = QuoteCreationDate.AddMonths(2);
                PaymentTerm = QuoteCreationDate.AddMonths(1);
            }
            else if (value == QuoteExpiryDate)
            {
                QuoteCreationDate = QuoteExpiryDate.AddMonths(-2);
                PaymentTerm = QuoteCreationDate.AddMonths(1);
            }
        }

        public void UpdateNextQuoteNumber()
        {
            NextQuoteNumber = ComputeNextQuoteNumber();
        }

        string ComputeNextQuoteNumber()
        {
            if (QuoteMap == null || QuoteMap.Count == 0)
                return null;

            int last = 0;
            foreach (var q in QuoteMap.Values)
            {
                int num = ParseQuoteNumber(q);
                if (num > last)
                    last = num;
            }
            return $"TRR{last + 1}";
        }

        int ParseQuoteNumber(Quote quote)
        {
            if (quote == null)
                return 0;

            return ParseQuoteNumber(quote.QuoteNumber);
        }

        int ParseQuoteNumber(string quoteNumber)
        {
            if (string.IsNullOrWhiteSpace(quoteNumber))
                return 0;

            if (quoteNumber.Contains("_"))
            {
                if (quoteNumber.Contains("TRR"))
                {
                    int pos = quoteNumber.IndexOf("TRR") + 3;
                    string number = quoteNumber.Substring(pos);
                    int underscore = number.IndexOf("_");
                    if (underscore >= 0)
                        number = number.Remove(underscore);
                    return ParsingService.ParseInt(number);
                }
            }
            else if (quoteNumber.Contains("TRR"))
            {
                int pos = quoteNumber.IndexOf("TRR") + 3;
                string number = quoteNumber.Substring(pos);
                return ParsingService.ParseInt(number);
            }
            return 0;
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
            UpdateNextQuoteNumber();
            return true;
        }

        public Quote CreateAndSaveQuote()
        {
            if (!ValidateInput())
                return null;

            Calculate();

            var quote = CreateQuote(QuoteNumber,
                                     QuoteCreationDate,
                                     QuoteExpiryDate,
                                     ReferenceNumber,
                                     JobNumber,
                                     PRNumber,
                                     PaymentTerm,
                                     SelectedBusinessPOBox,
                                     SelectedCustomerPOBox,
                                     LineNumber,
                                     BusinessTelephone,
                                     BusinessCellphone,
                                     BusinessEmail,
                                     (int)(PaymentTerm.Subtract(QuoteCreationDate).TotalDays),
                                     Pricing);

            if (quote == null)
                return null;

            if (!AddQuote(quote))
            {
                notificationService?.ShowError(
                    "The provided quote number or Job number has been used in a previous quote.\nPlease ensure that the provided details are indeed correct.",
                    "ERROR - Quote Number or Job Number Already Exists.");
                return null;
            }

            return quote;
        }

        public async Task CompleteQuoteAsync()
        {
            if (!ChangeSpecificObject && QuoteToChange != null)
            {
                await ExportQuoteToTemplateAsync(QuoteToChange);
                return;
            }

            Pricing.Rebate = RebateInput;
            LastCreatedQuote = CreateAndSaveQuote();
            var newQuote = LastCreatedQuote;

            if (newQuote != null)
            {
                if (messageService?.RequestConfirmation(
                        "The quote was successfully created. Would you like to export the quote an Excel document?",
                        "REQUEST - Export Quote to Excel") == true)
                {
                    await ExportQuoteToTemplateAsync(newQuote);
                }
                else
                {
                    messageService?.ShowInformation(
                        "The quote was successfully added to the list of quotes.",
                        "INFORMATION - Quote Added To List");
                }

                QuoteToChange = newQuote;
                ChangeSpecificObject = false;
            }
            else
            {
                messageService?.ShowError("The Quote could not be created successfully.",
                    "ERROR - Quote Creation Unsuccessful");
            }
        }

        public async Task ExportQuoteToTemplateAsync(Quote quote)
        {
            IsBusy = true;
            try
            {
                await excelExportService.ExportQuoteToExcelAsync(quote);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
