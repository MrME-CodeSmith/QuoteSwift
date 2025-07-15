using System.ComponentModel;

namespace QuoteSwift
{
    public class EditEmailAddressViewModel : INotifyPropertyChanged
    {
        readonly Business business;
        readonly Customer customer;
        readonly IMessageService messageService;
        string originalEmail;

        public event PropertyChangedEventHandler PropertyChanged;

        public EditEmailAddressViewModel(Business business = null, Customer customer = null, string email = null, IMessageService messageService = null)
        {
            this.business = business;
            this.customer = customer;
            originalEmail = email ?? string.Empty;
            this.messageService = messageService;
            CurrentEmail = originalEmail;
        }

        public string CurrentEmail { get; set; }
        public Business Business => business;
        public Customer Customer => customer;
        public string OriginalEmail => originalEmail;

        public bool UpdateEmail()
        {
            if (!ValidateEmail(CurrentEmail))
                return false;
            if (business != null)
            {
                if (business.EmailAddresses.Contains(CurrentEmail) && CurrentEmail != originalEmail)
                {
                    messageService.ShowError("This email address has already been added previously.", "ERROR - Email Address Already Added");
                    return false;
                }
                business.UpdateEmailAddress(originalEmail, CurrentEmail);
            }
            else if (customer != null)
            {
                if (customer.EmailAddresses.Contains(CurrentEmail) && CurrentEmail != originalEmail)
                {
                    messageService.ShowError("This email address has already been added previously.", "ERROR - Email Address Already Added");
                    return false;
                }
                customer.UpdateEmailAddress(originalEmail, CurrentEmail);
            }
            originalEmail = CurrentEmail;
            return true;
        }

        bool ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || email.Length <= 3 || !email.Contains("@"))
            {
                messageService.ShowError("The provided Email Address is invalid. Please provide a valid Email Address", "ERROR - Invalid Email Address");
                return false;
            }
            return true;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
