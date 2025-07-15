using System.ComponentModel;
using System.Windows.Input;

namespace QuoteSwift
{
    public class EditPhoneNumberViewModel : ViewModelBase
    {
        readonly Business business;
        readonly Customer customer;
        readonly IMessageService messageService;
        string originalNumber;

        public ICommand UpdateNumberCommand { get; }


        public EditPhoneNumberViewModel(Business business = null, Customer customer = null, string number = "", IMessageService messageService = null)
        {
            this.business = business;
            this.customer = customer;
            originalNumber = number ?? string.Empty;
            this.messageService = messageService;
            CurrentNumber = originalNumber;
            UpdateNumberCommand = new RelayCommand(_ => UpdateNumber());
        }

        public Business Business => business;
        public Customer Customer => customer;
        public string OriginalNumber => originalNumber;
        public string CurrentNumber { get; set; }

        public bool UpdateNumber()
        {
            if (!ValidateNumber(CurrentNumber))
                return false;
            if (business != null)
            {
                bool isCell = business.CellphoneNumbers.Contains(originalNumber);
                bool isTel = business.TelephoneNumbers.Contains(originalNumber);
                if ((business.CellphoneNumbers.Contains(CurrentNumber) || business.TelephoneNumbers.Contains(CurrentNumber)) && CurrentNumber != originalNumber)
                {
                    messageService.ShowError("This number has already been added previously.", "ERROR - Number Already Added");
                    return false;
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
                    messageService.ShowError("This number has already been added previously.", "ERROR - Number Already Added");
                    return false;
                }
                if (isCell)
                    customer.UpdateCellphoneNumber(originalNumber, CurrentNumber);
                else if (isTel)
                    customer.UpdateTelephoneNumber(originalNumber, CurrentNumber);
            }
            originalNumber = CurrentNumber;
            return true;
        }

        bool ValidateNumber(string number)
        {
            if (string.IsNullOrWhiteSpace(number) || number.Length < 10)
            {
                messageService.ShowError("A valid phone number was not provided.", "ERROR - Invalid Number Provided");
                return false;
            }
            return true;
        }

    }
}
