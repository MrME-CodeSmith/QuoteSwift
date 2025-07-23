using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;


namespace QuoteSwift
{
    public class QuotesViewModel : ViewModelBase
    {
        readonly IDataService dataService;
        readonly INavigationService navigation;
        readonly IMessageService messageService;
        readonly ISerializationService serializationService;
        BindingList<Quote> quotes;
        Quote selectedQuote;

        SortedDictionary<string, Quote> quoteMap;
        BindingList<Business> businessList;
        BindingList<Pump> pumpList;
        Dictionary<string, Part> partMap;

        public ICommand LoadDataCommand { get; }
        public ICommand CreateQuoteCommand { get; }
        public ICommand ViewQuoteCommand { get; }
        public ICommand CreateQuoteFromSelectionCommand { get; }
        public ICommand AddBusinessCommand { get; }
        public ICommand ViewBusinessesCommand { get; }
        public ICommand AddCustomerCommand { get; }
        public ICommand ViewCustomersCommand { get; }
        public ICommand CreatePumpCommand { get; }
        public ICommand ViewPumpsCommand { get; }
        public ICommand AddPartCommand { get; }
        public ICommand ViewPartsCommand { get; }
        public ICommand ExitCommand { get; }


        public QuotesViewModel(IDataService service,
                               INavigationService navigation = null,
                               IMessageService messageService = null,
                               ISerializationService serializationService = null)
        {
            dataService = service;
            this.navigation = navigation;
            this.messageService = messageService;
            this.serializationService = serializationService;

            LoadDataCommand = CreateLoadCommand(LoadDataAsync);

            CreateQuoteCommand = new AsyncRelayCommand(_ => CreateQuoteAsync());
            ViewQuoteCommand = new AsyncRelayCommand(_ => ViewQuoteAsync(), _ => Task.FromResult(SelectedQuote != null));
            CreateQuoteFromSelectionCommand = new AsyncRelayCommand(_ => CreateQuoteFromSelectionAsync(), _ => Task.FromResult(SelectedQuote != null));
            AddBusinessCommand = new AsyncRelayCommand(async _ => {
                if (navigation != null) await navigation.AddBusiness();
                await LoadDataAsync();
            });
            ViewBusinessesCommand = new AsyncRelayCommand(async _ => { navigation?.ViewBusinesses(); await LoadDataAsync(); });
            AddCustomerCommand = new AsyncRelayCommand(async _ => {
                if (navigation != null) await navigation.AddCustomer();
                await LoadDataAsync();
            });
            ViewCustomersCommand = new AsyncRelayCommand(async _ => {
                if (navigation != null) await navigation.ViewCustomers();
                await LoadDataAsync();
            });
            CreatePumpCommand = new AsyncRelayCommand(async _ => {
                if (navigation != null) await navigation.CreateNewPump();
                await LoadDataAsync();
            });
            ViewPumpsCommand = new AsyncRelayCommand(async _ => { navigation?.ViewAllPumps(); await LoadDataAsync(); });
            AddPartCommand = new AsyncRelayCommand(async _ => { navigation?.AddNewPart(); await LoadDataAsync(); });
            ViewPartsCommand = new AsyncRelayCommand(async _ => { navigation?.ViewAllParts(); await LoadDataAsync(); });

            ExitCommand = CreateExitCommand(() =>
            {
                serializationService?.CloseApplication(true,
                    BusinessList,
                    PumpList,
                    PartMap,
                    QuoteMap);
            }, messageService);
        }


        public BindingList<Quote> Quotes
        {
            get => quotes;
            private set
            {
                quotes = value;
                OnPropertyChanged(nameof(Quotes));
            }
        }

        public Quote SelectedQuote
        {
            get => selectedQuote;
            set
            {
                if (SetProperty(ref selectedQuote, value))
                {
                    ((RelayCommand)ViewQuoteCommand).RaiseCanExecuteChanged();
                    ((RelayCommand)CreateQuoteFromSelectionCommand).RaiseCanExecuteChanged();
                }
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

        public BindingList<Business> BusinessList
        {
            get => businessList;
            private set
            {
                businessList = value;
                OnPropertyChanged(nameof(BusinessList));
            }
        }

        public BindingList<Pump> PumpList
        {
            get => pumpList;
            private set
            {
                pumpList = value;
                OnPropertyChanged(nameof(PumpList));
            }
        }

        public Dictionary<string, Part> PartMap
        {
            get => partMap;
            private set
            {
                partMap = value;
                OnPropertyChanged(nameof(PartMap));
            }
        }

        public async Task LoadDataAsync()
        {
            PartMap = await dataService.LoadPartListAsync();
            PumpList = await dataService.LoadPumpListAsync();
            BusinessList = await dataService.LoadBusinessListAsync();
            QuoteMap = await dataService.LoadQuoteMapAsync();

            Quotes = new BindingList<Quote>(QuoteMap.Values.ToList());
        }

        public void UpdateData(SortedDictionary<string, Quote> quoteMap,
                               BindingList<Business> businessList,
                               BindingList<Pump> pumpList,
                               Dictionary<string, Part> partMap)
        {
            QuoteMap = quoteMap;
            BusinessList = businessList;
            PumpList = pumpList;
            PartMap = partMap;
            Quotes = new BindingList<Quote>(QuoteMap?.Values.ToList() ?? new List<Quote>());
        }

        public void SaveChanges()
        {
            if (QuoteMap != null)
                dataService.SaveQuotes(QuoteMap);
            if (BusinessList != null)
                dataService.SaveBusinesses(BusinessList);
            if (PumpList != null)
                dataService.SavePumps(PumpList);
            if (PartMap != null)
                dataService.SaveParts(PartMap);
        }

        async Task CreateQuoteAsync()
        {
            if (BusinessList != null && BusinessList.Count > 0 && PumpList != null && BusinessList[0].BusinessCustomerList != null)
            {
                navigation?.CreateNewQuote();
                await LoadDataAsync();
            }
            else
            {
                messageService?.ShowError(
                    "Please ensure that the following information is provided before creating a quote:\n" +
                    ">  Business Information.\n" +
                    ">  Business' Customer's Information.\n" +
                    ">  Pump Information.",
                    "ERROR - Prerequisites Not Met");
            }
        }

        async Task ViewQuoteAsync()
        {
            if (SelectedQuote != null)
            {
                navigation?.CreateNewQuote(SelectedQuote, false);
                await LoadDataAsync();
            }
        }

        async Task CreateQuoteFromSelectionAsync()
        {
            if (SelectedQuote != null)
            {
                navigation?.CreateNewQuote(SelectedQuote, true);
                await LoadDataAsync();
            }
        }

    }
}
