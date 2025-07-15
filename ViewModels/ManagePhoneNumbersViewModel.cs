using System.ComponentModel;
using System.Windows.Input;

namespace QuoteSwift
{
    public class ManagePhoneNumbersViewModel : ViewModelBase
    {
        readonly IDataService dataService;
        Business business;
        Customer customer;
        BindingList<NumberEntry> telephoneNumbers;
        BindingList<NumberEntry> cellphoneNumbers;

        public ICommand RemoveTelephoneCommand { get; }
        public ICommand RemoveCellphoneCommand { get; }
        public ICommand UpdateTelephoneCommand { get; }
        public ICommand UpdateCellphoneCommand { get; }


        public ManagePhoneNumbersViewModel(IDataService service)
        {
            dataService = service;
            RemoveTelephoneCommand = new RelayCommand(n => RemoveTelephone(n as string));
            RemoveCellphoneCommand = new RelayCommand(n => RemoveCellphone(n as string));
            UpdateTelephoneCommand = new RelayCommand(p =>
            {
                if (p is object[] arr && arr.Length == 2 && arr[0] is string oldN && arr[1] is string newN)
                    UpdateTelephone(oldN, newN);
            });
            UpdateCellphoneCommand = new RelayCommand(p =>
            {
                if (p is object[] arr && arr.Length == 2 && arr[0] is string oldN && arr[1] is string newN)
                    UpdateCellphone(oldN, newN);
            });
        }

        public IDataService DataService => dataService;

        public Business Business
        {
            get => business;
            private set
            {
                business = value;
                OnPropertyChanged(nameof(Business));
            }
        }

        public Customer Customer
        {
            get => customer;
            private set
            {
                customer = value;
                OnPropertyChanged(nameof(Customer));
            }
        }

        public BindingList<NumberEntry> TelephoneNumbers
        {
            get => telephoneNumbers;
            private set
            {
                telephoneNumbers = value;
                OnPropertyChanged(nameof(TelephoneNumbers));
            }
        }

        public BindingList<NumberEntry> CellphoneNumbers
        {
            get => cellphoneNumbers;
            private set
            {
                cellphoneNumbers = value;
                OnPropertyChanged(nameof(CellphoneNumbers));
            }
        }

        public void UpdateData(Business business = null, Customer customer = null)
        {
            Business = business;
            Customer = customer;
            RefreshNumbers();
        }

        void RefreshNumbers()
        {
            if (Business != null)
            {
                TelephoneNumbers = new BindingList<NumberEntry>();
                if (Business.BusinessTelephoneNumberList != null)
                    foreach (var n in Business.BusinessTelephoneNumberList)
                        TelephoneNumbers.Add(new NumberEntry { Number = n });

                CellphoneNumbers = new BindingList<NumberEntry>();
                if (Business.BusinessCellphoneNumberList != null)
                    foreach (var n in Business.BusinessCellphoneNumberList)
                        CellphoneNumbers.Add(new NumberEntry { Number = n });
            }
            else if (Customer != null)
            {
                TelephoneNumbers = new BindingList<NumberEntry>();
                if (Customer.CustomerTelephoneNumberList != null)
                    foreach (var n in Customer.CustomerTelephoneNumberList)
                        TelephoneNumbers.Add(new NumberEntry { Number = n });

                CellphoneNumbers = new BindingList<NumberEntry>();
                if (Customer.CustomerCellphoneNumberList != null)
                    foreach (var n in Customer.CustomerCellphoneNumberList)
                        CellphoneNumbers.Add(new NumberEntry { Number = n });
            }
            else
            {
                TelephoneNumbers = new BindingList<NumberEntry>();
                CellphoneNumbers = new BindingList<NumberEntry>();
            }
        }

        public void RemoveTelephone(string number)
        {
            if (Business != null)
                Business.RemoveTelephoneNumber(number);
            else if (Customer != null)
                Customer.RemoveTelephoneNumber(number);
            RefreshNumbers();
        }

        public void RemoveCellphone(string number)
        {
            if (Business != null)
                Business.RemoveCellphoneNumber(number);
            else if (Customer != null)
                Customer.RemoveCellphoneNumber(number);
            RefreshNumbers();
        }

        public void UpdateTelephone(string oldNumber, string newNumber)
        {
            if (Business != null)
                Business.UpdateTelephoneNumber(oldNumber, newNumber);
            else if (Customer != null)
                Customer.UpdateTelephoneNumber(oldNumber, newNumber);
            RefreshNumbers();
        }

        public void UpdateCellphone(string oldNumber, string newNumber)
        {
            if (Business != null)
                Business.UpdateCellphoneNumber(oldNumber, newNumber);
            else if (Customer != null)
                Customer.UpdateCellphoneNumber(oldNumber, newNumber);
            RefreshNumbers();
        }


        public class NumberEntry
        {
            public string Number { get; set; }
        }
    }
}
