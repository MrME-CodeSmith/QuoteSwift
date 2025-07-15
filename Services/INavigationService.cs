using System;

namespace QuoteSwift
{
    public interface INavigationService
    {
        void CreateNewQuote(ApplicationData data, Quote quoteToChange = null, bool changeSpecificObject = false);
        void ViewAllQuotes(ApplicationData data);
        void ViewAllPumps(ApplicationData data);
        void CreateNewPump(ApplicationData data);
        void ViewAllParts(ApplicationData data);
        void AddNewPart(ApplicationData data, Part partToChange = null, bool changeSpecificObject = false);
        void AddCustomer(ApplicationData data, Business businessToChange = null, Customer customerToChange = null, bool changeSpecificObject = false);
        void ViewCustomers(ApplicationData data);
        void AddBusiness(ApplicationData data, Business businessToChange = null, bool changeSpecificObject = false);
        void ViewBusinesses(ApplicationData data);
        void ViewBusinessesAddresses(Business business = null, Customer customer = null);
        void ViewBusinessesPOBoxAddresses(Business business = null, Customer customer = null);
        void ViewBusinessesEmailAddresses(Business business = null, Customer customer = null);
        void ViewBusinessesPhoneNumbers(Business business = null, Customer customer = null);
        void EditBusinessAddress(Business business = null, Customer customer = null, Address address = null);
        void EditBusinessEmailAddress(Business business = null, Customer customer = null, string email = "");
        void EditPhoneNumber(Business business = null, Customer customer = null, string number = "");
    }
}
