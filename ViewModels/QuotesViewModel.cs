using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace QuoteSwift
{
    public class QuotesViewModel : INotifyPropertyChanged
    {
        readonly IDataService dataService;
        readonly Pass pass;
        BindingList<Quote> quotes;
        Quote selectedQuote;

        public event PropertyChangedEventHandler PropertyChanged;

        public QuotesViewModel(IDataService service)
        {
            dataService = service;
            pass = new Pass(null, null, null, null);
        }

        public Pass Pass
        {
            get => pass;
            private set
            {
                if (value != null)
                {
                    pass.PassQuoteMap = value.PassQuoteMap;
                    pass.PassBusinessList = value.PassBusinessList;
                    pass.PassPartList = value.PassPartList;
                    pass.PassPumpList = value.PassPumpList;
                }
            }
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
                selectedQuote = value;
                OnPropertyChanged(nameof(SelectedQuote));
            }
        }

        public void LoadData()
        {
            pass.PassPartList = dataService.LoadPartList();
            pass.PassPumpList = dataService.LoadPumpList();
            pass.PassBusinessList = dataService.LoadBusinessList();
            pass.PassQuoteMap = dataService.LoadQuoteMap();

            Quotes = new BindingList<Quote>(pass.PassQuoteMap.Values.ToList());
        }

        public void UpdatePass(Pass newPass)
        {
            if (newPass == null) return;
            pass.PassQuoteMap = newPass.PassQuoteMap;
            pass.PassBusinessList = newPass.PassBusinessList;
            pass.PassPartList = newPass.PassPartList;
            pass.PassPumpList = newPass.PassPumpList;
            Quotes = new BindingList<Quote>(pass.PassQuoteMap.Values.ToList());
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
