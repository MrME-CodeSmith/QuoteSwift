using System.ComponentModel;
using System.Windows.Input;

namespace QuoteSwift
{
    public class EditPhoneNumberViewModel : ViewModelBase
    {
        Business business;
        Customer customer;
        readonly IMessageService messageService;
        OperationResult lastResult = OperationResult.Successful();
        string originalNumber;
        string currentNumber;

        public ICommand UpdateNumberCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand ExitCommand { get; }

        public Action CloseAction { get; set; }


        public EditPhoneNumberViewModel(Business business = null, Customer customer = null, string number = "", IMessageService messageService = null)
        {
            this.messageService = messageService;
            Initialize(business, customer, number);
            UpdateNumberCommand = new RelayCommand(_ =>
            {
                var r = UpdateNumber();
                LastResult = r;
            });
            CancelCommand = new RelayCommand(_ =>
            {
                if (messageService?.RequestConfirmation(
                        "By canceling the current event, any parts not added will not be available in the part's list.",
                        "REQUEAST - Action Cancellation") == true)
                    CloseAction?.Invoke();
            });
            ExitCommand = new RelayCommand(_ =>
            {
                if (messageService?.RequestConfirmation(
                        "Are you sure you want to close the application?",
                        "REQUEST - Application Termination") == true)
                    System.Windows.Forms.Application.Exit();
            });
        }

        public void Initialize(Business business = null, Customer customer = null, string number = "")
        {
            this.business = business;
            this.customer = customer;
            originalNumber = number ?? string.Empty;
            CurrentNumber = originalNumber;
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

        public Business Business => business;
        public Customer Customer => customer;
        public string OriginalNumber => originalNumber;
        public string CurrentNumber
        {
            get => currentNumber;
            set => SetProperty(ref currentNumber, value);
        }

        public OperationResult UpdateNumber()
        {
            var valid = ValidateNumber(CurrentNumber);
            if (!valid.Success)
                return valid;
            if (business != null)
            {
                bool isCell = business.CellphoneNumbers.Contains(originalNumber);
                bool isTel = business.TelephoneNumbers.Contains(originalNumber);
                if ((business.CellphoneNumbers.Contains(CurrentNumber) || business.TelephoneNumbers.Contains(CurrentNumber)) && CurrentNumber != originalNumber)
                {
                    return OperationResult.Failure("This number has already been added previously.", "ERROR - Number Already Added");
                }
                if (isCell)
                    business.UpdateCellphoneNumber(originalNumber, CurrentNumber);
                else if (isTel)
                    business.UpdateTelephoneNumber(originalNumber, CurrentNumber);
            }
            else if (customer != null)
            {
                bool isCell = customer.CellphoneNumbers.Contains(originalNumber);
                bool isTel = customer.TelephoneNumbers.Contains(originalNumber);
                if ((customer.CellphoneNumbers.Contains(CurrentNumber) || customer.TelephoneNumbers.Contains(CurrentNumber)) && CurrentNumber != originalNumber)
                {
                    return OperationResult.Failure("This number has already been added previously.", "ERROR - Number Already Added");
                }
                if (isCell)
                    customer.UpdateCellphoneNumber(originalNumber, CurrentNumber);
                else if (isTel)
                    customer.UpdateTelephoneNumber(originalNumber, CurrentNumber);
            }
            originalNumber = CurrentNumber;
            return OperationResult.Successful();
        }

        OperationResult ValidateNumber(string number)
        {
            if (string.IsNullOrWhiteSpace(number) || number.Length < 10)
            {
                return OperationResult.Failure("A valid phone number was not provided.", "ERROR - Invalid Number Provided");
            }
            return OperationResult.Successful();
        }

    }
}
