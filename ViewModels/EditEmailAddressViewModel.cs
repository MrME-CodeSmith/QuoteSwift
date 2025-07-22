using System.ComponentModel;
using System.Windows.Input;

namespace QuoteSwift
{
    public class EditEmailAddressViewModel : ViewModelBase
    {
        Business business;
        Customer customer;
        OperationResult lastResult = OperationResult.Successful();
        string originalEmail;
        string currentEmail;

        public ICommand UpdateEmailCommand { get; }


        public EditEmailAddressViewModel(Business business = null, Customer customer = null, string email = null)
        {
            Initialize(business, customer, email);
            UpdateEmailCommand = new RelayCommand(_ =>
            {
                var r = UpdateEmail();
                LastResult = r;
            });
        }

        public void Initialize(Business business = null, Customer customer = null, string email = null)
        {
            this.business = business;
            this.customer = customer;
            originalEmail = email ?? string.Empty;
            CurrentEmail = originalEmail;
        }

        public OperationResult LastResult
        {
            get => lastResult;
            private set
            {
                if (lastResult != value)
                {
                    lastResult = value;
                    OnPropertyChanged(nameof(LastResult));
                }
            }
        }

        public string CurrentEmail
        {
            get => currentEmail;
            set => SetProperty(ref currentEmail, value);
        }
        public Business Business => business;
        public Customer Customer => customer;
        public string OriginalEmail => originalEmail;

        public OperationResult UpdateEmail()
        {
            var valid = ValidateEmail(CurrentEmail);
            if (!valid.Success)
                return valid;
            if (business != null)
            {
                if (business.EmailAddresses.Contains(CurrentEmail) && CurrentEmail != originalEmail)
                {
                    return OperationResult.Failure("This email address has already been added previously.", "ERROR - Email Address Already Added");
                }
                business.UpdateEmailAddress(originalEmail, CurrentEmail);
            }
            else if (customer != null)
            {
                if (customer.EmailAddresses.Contains(CurrentEmail) && CurrentEmail != originalEmail)
                {
                    return OperationResult.Failure("This email address has already been added previously.", "ERROR - Email Address Already Added");
                }
                customer.UpdateEmailAddress(originalEmail, CurrentEmail);
            }
            originalEmail = CurrentEmail;
            return OperationResult.Successful();
        }

        OperationResult ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || email.Length <= 3 || !email.Contains("@"))
            {
                return OperationResult.Failure("The provided Email Address is invalid. Please provide a valid Email Address", "ERROR - Invalid Email Address");
            }
            return OperationResult.Successful();
        }

    }
}
