using System;

namespace QuoteSwift
{
    public interface INavigationService
    {
        void CreateNewQuote(Quote quoteToChange = null, bool changeSpecificObject = false);
        void ViewAllQuotes();
        void ViewAllPumps();
        void CreateNewPump();
        void ViewAllParts();
        void AddNewPart(Part partToChange = null, bool changeSpecificObject = false);
        void AddCustomer(Business businessToChange = null, Customer customerToChange = null, bool changeSpecificObject = false);
        void ViewCustomers();
        void AddBusiness(Business businessToChange = null, bool changeSpecificObject = false);
        void ViewBusinesses();
        void ViewBusinessesAddresses(Business business = null, Customer customer = null);
        void ViewBusinessesPOBoxAddresses(Business business = null, Customer customer = null);
        void ViewBusinessesEmailAddresses(Business business = null, Customer customer = null);
        void ViewBusinessesPhoneNumbers(Business business = null, Customer customer = null);
        void EditBusinessAddress(Business business = null, Customer customer = null, Address address = null);
        void EditBusinessEmailAddress(Business business = null, Customer customer = null, string email = "");
        void EditPhoneNumber(Business business = null, Customer customer = null, string number = "");
        void SaveAllData();
    }
}
