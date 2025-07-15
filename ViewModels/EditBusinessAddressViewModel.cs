using System.ComponentModel;

namespace QuoteSwift
{
    public class EditBusinessAddressViewModel : ViewModelBase
    {
        readonly Business business;
        readonly Customer customer;
        readonly Address address;
        readonly IMessageService messageService;


        public EditBusinessAddressViewModel(Business business = null, Customer customer = null, Address address = null, IMessageService messageService = null)
        {
            this.business = business;
            this.customer = customer;
            this.address = address;
            this.messageService = messageService;
        }

        public Business Business => business;
        public Customer Customer => customer;
        public Address Address => address;

        public bool UpdateAddress(Address updated)
        {
            if (!ValidateInput(updated))
                return false;
            if (AddressExists(updated))
            {
                messageService.ShowError("Address not updated since this address is already in the list of addresses.\nNOTE: Address Description should be unique.", "ERROR - Address Already Added");
                return false;
            }
            if (address != null)
            {
                address.AddressDescription = updated.AddressDescription;
                address.AddressStreetNumber = updated.AddressStreetNumber;
                address.AddressStreetName = updated.AddressStreetName;
                address.AddressSuburb = updated.AddressSuburb;
                address.AddressCity = updated.AddressCity;
                address.AddressAreaCode = updated.AddressAreaCode;
            }
            return true;
        }

        bool ValidateInput(Address a)
        {
            if (a == null)
                return false;
            if (string.IsNullOrWhiteSpace(a.AddressDescription) || a.AddressDescription.Length < 2)
            {
                messageService.ShowError("The provided Business Address Description is invalid, please provide a valid description", "ERROR - Invalid Business Address Description");
                return false;
            }
            if (a.AddressStreetNumber == 0)
            {
                messageService.ShowError("The provided Business Address Street Number is invalid, please provide a valid street number", "ERROR - Invalid Business Address Street Number");
                return false;
            }
            if (string.IsNullOrWhiteSpace(a.AddressStreetName) || a.AddressStreetName.Length < 2)
            {
                messageService.ShowError("The provided Business Address Street Name is invalid, please provide a valid street name", "ERROR - Invalid Business Address Street Name");
                return false;
            }
            if (string.IsNullOrWhiteSpace(a.AddressSuburb) || a.AddressSuburb.Length < 2)
            {
                messageService.ShowError("The provided Business Address Suburb is invalid, please provide a valid suburb", "ERROR - Invalid Business Address Suburb");
                return false;
            }
            if (string.IsNullOrWhiteSpace(a.AddressCity) || a.AddressCity.Length < 2)
            {
                messageService.ShowError("The provided Business Address City is invalid, please provide a valid city", "ERROR - Invalid Business Address City");
                return false;
            }
            if (a.AddressAreaCode == 0)
            {
                messageService.ShowError("The provided Business Address Area Code is invalid, please provide a valid area code", "ERROR - Invalid Business Address Area Code");
                return false;
            }
            return true;
        }

        bool AddressExists(Address a)
        {
            if (a == null) return false;
            string key = StringUtil.NormalizeKey(a.AddressDescription);
            if (business != null && business.AddressMap.TryGetValue(key, out Address existingB))
            {
                if (!ReferenceEquals(existingB, address))
                    return true;
            }
            if (customer != null && customer.DeliveryAddressMap.TryGetValue(key, out Address existingC))
            {
                if (!ReferenceEquals(existingC, address))
                    return true;
            }
            return false;
        }

    }
}
