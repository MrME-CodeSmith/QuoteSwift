using System.ComponentModel;
using System.Windows.Input;

namespace QuoteSwift
{
    public class ManageEmailsViewModel : ViewModelBase
    {
        readonly IDataService dataService;
        Business business;
        Customer customer;
        BindingList<EmailEntry> emails;

        public ICommand AddEmailCommand { get; }
        public ICommand RemoveEmailCommand { get; }
        public ICommand UpdateEmailCommand { get; }


        public ManageEmailsViewModel(IDataService service)
        {
            dataService = service;
            AddEmailCommand = new RelayCommand(e => AddEmail(e as string));
            RemoveEmailCommand = new RelayCommand(e => RemoveEmail(e as string));
            UpdateEmailCommand = new RelayCommand(p =>
            {
                if (p is object[] arr && arr.Length == 2 && arr[0] is string oldE && arr[1] is string newE)
                    UpdateEmail(oldE, newE);
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

        public BindingList<EmailEntry> Emails
        {
            get => emails;
            private set
            {
                emails = value;
                OnPropertyChanged(nameof(Emails));
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
            if (Business != null && Business.BusinessEmailAddressList != null)
            {
                Emails = new BindingList<EmailEntry>();
                foreach (var e in Business.BusinessEmailAddressList)
                    Emails.Add(new EmailEntry { Address = e });
            }
            else if (Customer != null && Customer.CustomerEmailList != null)
            {
                Emails = new BindingList<EmailEntry>();
                foreach (var e in Customer.CustomerEmailList)
                    Emails.Add(new EmailEntry { Address = e });
            }
            else
            {
                Emails = new BindingList<EmailEntry>();
            }
        }

        public void RemoveEmail(string email)
        {
            if (Business != null)
                Business.RemoveEmailAddress(email);
            else if (Customer != null)
                Customer.RemoveEmailAddress(email);
            RefreshEmails();
        }

        public void AddEmail(string email)
        {
            if (Business != null)
                Business.AddEmailAddress(email);
            else if (Customer != null)
                Customer.AddEmailAddress(email);
            RefreshEmails();
        }

        public void UpdateEmail(string oldEmail, string newEmail)
        {
            if (Business != null)
                Business.UpdateEmailAddress(oldEmail, newEmail);
            else if (Customer != null)
                Customer.UpdateEmailAddress(oldEmail, newEmail);
            RefreshEmails();
        }


        public class EmailEntry
        {
            public string Address { get; set; }
        }
}
}
