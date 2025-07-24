using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace QuoteSwift
{
    public class ManageEmailsViewModel : ViewModelBase
    {
        readonly IDataService dataService;
        Business business;
        Customer customer;
        readonly BindingList<EmailEntry> emails;
        readonly INavigationService navigation;
        readonly IMessageService messageService;
        readonly IApplicationService applicationService;
        EmailEntry selectedEmail;
        string newEmail;

        public ICommand AddEmailCommand { get; }
        public ICommand RemoveEmailCommand { get; }
        public ICommand RemoveSelectedEmailCommand { get; }
        public ICommand UpdateEmailCommand { get; }
        public ICommand ExitCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand EditSelectedEmailCommand { get; }



        public ManageEmailsViewModel(IDataService service, INavigationService navigation = null, IMessageService messageService = null, IApplicationService applicationService = null)
        {
            dataService = service;
            this.navigation = navigation;
            this.messageService = messageService;
            this.applicationService = applicationService;
            emails = new BindingList<EmailEntry>();
            AddEmailCommand = new RelayCommand(
                _ => { AddEmail(NewEmail); NewEmail = string.Empty; },
                _ => !string.IsNullOrWhiteSpace(NewEmail));
            RemoveEmailCommand = new RelayCommand(e => RemoveEmail(e as string));
            RemoveSelectedEmailCommand = new RelayCommand(
                _ => RemoveEmail(selectedEmail?.Address),
                _ => selectedEmail != null);
            UpdateEmailCommand = new RelayCommand(p =>
            {
                if (p is object[] arr && arr.Length == 2 && arr[0] is string oldE && arr[1] is string newE)
                    UpdateEmail(oldE, newE);
            });
            ExitCommand = CreateExitCommand(() =>
            {
                navigation?.SaveAllData();
                applicationService?.Exit();
            }, messageService);

            CancelCommand = CreateCancelCommand(() => CloseAction?.Invoke(), messageService);

            EditSelectedEmailCommand = new AsyncRelayCommand(async (object _) =>
            {
                string email = SelectedEmail?.Address ?? string.Empty;
                if (navigation != null) await navigation.EditBusinessEmailAddress(Business, Customer, email);
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

        public BindingList<EmailEntry> Emails => emails;

        public EmailEntry SelectedEmail
        {
            get => selectedEmail;
            set
            {
                if (SetProperty(ref selectedEmail, value))
                    ((RelayCommand)RemoveSelectedEmailCommand).RaiseCanExecuteChanged();
            }
        }

        public string NewEmail
        {
            get => newEmail;
            set
            {
                if (SetProperty(ref newEmail, value))
                    ((RelayCommand)AddEmailCommand).RaiseCanExecuteChanged();
            }
        }

        public void UpdateData(Business business = null, Customer customer = null)
        {
            Business = business;
            Customer = customer;
            RefreshEmails();
        }

        void RefreshEmails()
        {
            emails.Clear();
            if (Business != null && Business.BusinessEmailAddressList != null)
            {
                foreach (var e in Business.BusinessEmailAddressList)
                    emails.Add(new EmailEntry { Address = e });
            }
            else if (Customer != null && Customer.CustomerEmailList != null)
            {
                foreach (var e in Customer.CustomerEmailList)
                    emails.Add(new EmailEntry { Address = e });
            }
        }

        public void RemoveEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return;
            if (Business != null)
                Business.RemoveEmailAddress(email);
            else if (Customer != null)
                Customer.RemoveEmailAddress(email);
            var entry = emails.FirstOrDefault(e => e.Address == email);
            if (entry != null)
                emails.Remove(entry);
        }

        public void AddEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return;
            if (Business != null)
                Business.AddEmailAddress(email);
            else if (Customer != null)
                Customer.AddEmailAddress(email);
            emails.Add(new EmailEntry { Address = email });
        }

        public void UpdateEmail(string oldEmail, string newEmail)
        {
            if (string.IsNullOrWhiteSpace(oldEmail) || string.IsNullOrWhiteSpace(newEmail))
                return;
            if (Business != null)
                Business.UpdateEmailAddress(oldEmail, newEmail);
            else if (Customer != null)
                Customer.UpdateEmailAddress(oldEmail, newEmail);
            var entry = emails.FirstOrDefault(e => e.Address == oldEmail);
            if (entry != null)
                entry.Address = newEmail;
        }


        public class EmailEntry
        {
            public string Address { get; set; }
        }
}
}
