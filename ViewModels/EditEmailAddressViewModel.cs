using System;
using System.ComponentModel;
using System.Windows.Input;

namespace QuoteSwift
{
    public class EditEmailAddressViewModel : ViewModelBase
    {
        Business business;
        Customer customer;
        readonly IMessageService messageService;
        OperationResult lastResult = OperationResult.Successful();
        string originalEmail;
        string currentEmail;

        public ICommand UpdateEmailCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand ExitCommand { get; }

        public Action CloseAction { get; set; }

        public EditEmailAddressViewModel(Business business = null,
                                          Customer customer = null,
                                          string email = null,
                                          IMessageService messageService = null)
        {
            this.messageService = messageService;
            Initialize(business, customer, email);
            UpdateEmailCommand = new RelayCommand(_ =>
            {
                var r = UpdateEmail();
                LastResult = r;
            });
            SaveCommand = new RelayCommand(_ =>
            {
                UpdateEmailCommand.Execute(null);
                var result = LastResult;
                if (result.Success)
                {
                    messageService?.ShowInformation("The email address has been successfully updated", "INFORMATION - Email Address Successfully Updated");
                    CloseAction?.Invoke();
                }
                else if (result.Message != null)
                    messageService?.ShowError(result.Message, result.Caption);
            });

            CancelCommand = new RelayCommand(_ =>
            {
                if (messageService?.RequestConfirmation(
                        "Are you sure you want to cancel the current action?\nCancellation can cause any changes to be lost.",
                        "REQUEST - Cancellation") == true)
                    CloseAction?.Invoke();
            });

            ExitCommand = new RelayCommand(_ =>
            {
                if (messageService?.RequestConfirmation(
                        "Are you sure you want to close the application?",
                        "REQUEST - Application Termination") == true)
                {
                    System.Windows.Forms.Application.Exit();
                }
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
