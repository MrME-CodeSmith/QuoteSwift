using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace QuoteSwift
{
    public class ManagePhoneNumbersViewModel : ViewModelBase
    {
        readonly IDataService dataService;
        Business business;
        Customer customer;
        readonly BindingList<NumberEntry> telephoneNumbers;
        readonly BindingList<NumberEntry> cellphoneNumbers;
        NumberEntry selectedTelephoneNumber;
        NumberEntry selectedCellphoneNumber;
        string newTelephoneNumber;
        string newCellphoneNumber;
        readonly INavigationService navigation;
        readonly IMessageService messageService;
        readonly IApplicationService applicationService;

        public ICommand RemoveTelephoneCommand { get; }
        public ICommand RemoveCellphoneCommand { get; }
        public ICommand RemoveSelectedTelephoneCommand { get; }
        public ICommand RemoveSelectedCellphoneCommand { get; }
        public ICommand UpdateTelephoneCommand { get; }
        public ICommand UpdateCellphoneCommand { get; }
        public ICommand AddTelephoneCommand { get; }
        public ICommand AddCellphoneCommand { get; }
        public ICommand ExitCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand EditTelephoneCommand { get; }
        public ICommand EditCellphoneCommand { get; }

        public Action CloseAction { get; set; }


        public ManagePhoneNumbersViewModel(IDataService service, INavigationService navigation = null, IMessageService messageService = null, IApplicationService applicationService = null)
        {
            dataService = service;
            this.navigation = navigation;
            this.messageService = messageService;
            this.applicationService = applicationService;
            telephoneNumbers = new BindingList<NumberEntry>();
            cellphoneNumbers = new BindingList<NumberEntry>();
            RemoveTelephoneCommand = new RelayCommand(n => RemoveTelephone(n as string));
            RemoveCellphoneCommand = new RelayCommand(n => RemoveCellphone(n as string));
            RemoveSelectedTelephoneCommand = new RelayCommand(
                _ => RemoveTelephone(selectedTelephoneNumber?.Number),
                _ => selectedTelephoneNumber != null);
            RemoveSelectedCellphoneCommand = new RelayCommand(
                _ => RemoveCellphone(selectedCellphoneNumber?.Number),
                _ => selectedCellphoneNumber != null);
            AddTelephoneCommand = new RelayCommand(
                _ => { AddTelephone(NewTelephoneNumber); NewTelephoneNumber = string.Empty; },
                _ => !string.IsNullOrWhiteSpace(NewTelephoneNumber));
            AddCellphoneCommand = new RelayCommand(
                _ => { AddCellphone(NewCellphoneNumber); NewCellphoneNumber = string.Empty; },
                _ => !string.IsNullOrWhiteSpace(NewCellphoneNumber));
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
            ExitCommand = CreateExitCommand(() =>
            {
                navigation?.SaveAllData();
                applicationService?.Exit();
            }, messageService);

            CancelCommand = CreateCancelCommand(
                () => CloseAction?.Invoke(),
                messageService,
                "Are you sure you want to cancel the current action?\nCancelation can cause any changes to be lost.",
                "REQUEST - Cancelation");

            EditCellphoneCommand = new AsyncRelayCommand(async _ =>
            {
                if (Business != null && Business.BusinessCellphoneNumberList != null)
                {
                    string oldNumber = SelectedCellphoneNumber?.Number ?? string.Empty;
                    if (navigation != null) await navigation.EditPhoneNumber(Business, null, oldNumber);
                }
                else if (Customer != null && Customer.CustomerCellphoneNumberList != null)
                {
                    string oldNumber = SelectedCellphoneNumber?.Number ?? string.Empty;
                    if (navigation != null) await navigation.EditPhoneNumber(null, Customer, oldNumber);
                }
            });

            EditTelephoneCommand = new AsyncRelayCommand(async _ =>
            {
                if (Business != null && Business.BusinessTelephoneNumberList != null)
                {
                    string oldNumber = SelectedTelephoneNumber?.Number ?? string.Empty;
                    if (navigation != null) await navigation.EditPhoneNumber(Business, null, oldNumber);
                }
                else if (Customer != null && Customer.CustomerTelephoneNumberList != null)
                {
                    string oldNumber = SelectedTelephoneNumber?.Number ?? string.Empty;
                    if (navigation != null) await navigation.EditPhoneNumber(null, Customer, oldNumber);
                }
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

        public BindingList<NumberEntry> TelephoneNumbers => telephoneNumbers;

        public NumberEntry SelectedTelephoneNumber
        {
            get => selectedTelephoneNumber;
            set
            {
                if (SetProperty(ref selectedTelephoneNumber, value))
                    ((RelayCommand)RemoveSelectedTelephoneCommand).RaiseCanExecuteChanged();
            }
        }

        public BindingList<NumberEntry> CellphoneNumbers => cellphoneNumbers;

        public NumberEntry SelectedCellphoneNumber
        {
            get => selectedCellphoneNumber;
            set
            {
                if (SetProperty(ref selectedCellphoneNumber, value))
                    ((RelayCommand)RemoveSelectedCellphoneCommand).RaiseCanExecuteChanged();
            }
        }

        public string NewTelephoneNumber
        {
            get => newTelephoneNumber;
            set
            {
                if (SetProperty(ref newTelephoneNumber, value))
                    ((RelayCommand)AddTelephoneCommand).RaiseCanExecuteChanged();
            }
        }

        public string NewCellphoneNumber
        {
            get => newCellphoneNumber;
            set
            {
                if (SetProperty(ref newCellphoneNumber, value))
                    ((RelayCommand)AddCellphoneCommand).RaiseCanExecuteChanged();
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
            telephoneNumbers.Clear();
            cellphoneNumbers.Clear();
            if (Business != null)
            {
                if (Business.BusinessTelephoneNumberList != null)
                    foreach (var n in Business.BusinessTelephoneNumberList)
                        telephoneNumbers.Add(new NumberEntry { Number = n });

                if (Business.BusinessCellphoneNumberList != null)
                    foreach (var n in Business.BusinessCellphoneNumberList)
                        cellphoneNumbers.Add(new NumberEntry { Number = n });
            }
            else if (Customer != null)
            {
                if (Customer.CustomerTelephoneNumberList != null)
                    foreach (var n in Customer.CustomerTelephoneNumberList)
                        telephoneNumbers.Add(new NumberEntry { Number = n });

                if (Customer.CustomerCellphoneNumberList != null)
                    foreach (var n in Customer.CustomerCellphoneNumberList)
                        cellphoneNumbers.Add(new NumberEntry { Number = n });
            }
        }

        public void RemoveTelephone(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                return;
            if (Business != null)
                Business.RemoveTelephoneNumber(number);
            else if (Customer != null)
                Customer.RemoveTelephoneNumber(number);
            var entry = telephoneNumbers.FirstOrDefault(n => n.Number == number);
            if (entry != null)
                telephoneNumbers.Remove(entry);
        }

        public void RemoveCellphone(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                return;
            if (Business != null)
                Business.RemoveCellphoneNumber(number);
            else if (Customer != null)
                Customer.RemoveCellphoneNumber(number);
            var entry = cellphoneNumbers.FirstOrDefault(n => n.Number == number);
            if (entry != null)
                cellphoneNumbers.Remove(entry);
        }

        public void AddTelephone(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                return;
            if (Business != null)
                Business.AddTelephoneNumber(number);
            else if (Customer != null)
                Customer.AddTelephoneNumber(number);
            telephoneNumbers.Add(new NumberEntry { Number = number });
        }

        public void AddCellphone(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                return;
            if (Business != null)
                Business.AddCellphoneNumber(number);
            else if (Customer != null)
                Customer.AddCellphoneNumber(number);
            cellphoneNumbers.Add(new NumberEntry { Number = number });
        }

        public void UpdateTelephone(string oldNumber, string newNumber)
        {
            if (string.IsNullOrWhiteSpace(oldNumber) || string.IsNullOrWhiteSpace(newNumber))
                return;
            if (Business != null)
                Business.UpdateTelephoneNumber(oldNumber, newNumber);
            else if (Customer != null)
                Customer.UpdateTelephoneNumber(oldNumber, newNumber);
            var entry = telephoneNumbers.FirstOrDefault(n => n.Number == oldNumber);
            if (entry != null)
                entry.Number = newNumber;
        }

        public void UpdateCellphone(string oldNumber, string newNumber)
        {
            if (string.IsNullOrWhiteSpace(oldNumber) || string.IsNullOrWhiteSpace(newNumber))
                return;
            if (Business != null)
                Business.UpdateCellphoneNumber(oldNumber, newNumber);
            else if (Customer != null)
                Customer.UpdateCellphoneNumber(oldNumber, newNumber);
            var entry = cellphoneNumbers.FirstOrDefault(n => n.Number == oldNumber);
            if (entry != null)
                entry.Number = newNumber;
        }


        public class NumberEntry
        {
            public string Number { get; set; }
        }
    }
}
