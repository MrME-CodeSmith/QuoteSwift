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
        readonly IApplicationService applicationService;
        OperationResult lastResult = OperationResult.Successful();
        string originalEmail;
        string currentEmail;

        public ICommand UpdateEmailCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand ExitCommand { get; }


        public EditEmailAddressViewModel(Business business = null,
                                          Customer customer = null,
                                          string email = null,
                                          IMessageService messageService = null,
                                          IApplicationService applicationService = null)
        {
            this.messageService = messageService;
            this.applicationService = applicationService;
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

            CancelCommand = CreateCancelCommand(() => CloseAction?.Invoke(), messageService);

            ExitCommand = CreateExitCommand(() =>
            {
                applicationService?.Exit();
            }, messageService);
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
