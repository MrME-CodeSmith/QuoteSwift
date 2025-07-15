using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

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


        public CreateQuoteViewModel(IDataService service)
        {
            dataService = service;
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

        public void LoadData()
        {
            PartList = dataService.LoadPartList();
            Pumps = dataService.LoadPumpList();
            Businesses = dataService.LoadBusinessList();
            QuoteMap = dataService.LoadQuoteMap();
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
