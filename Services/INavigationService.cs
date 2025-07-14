using System;

namespace QuoteSwift
{
    public interface INavigationService
    {

        void CreateNewQuote();
        void ViewAllQuotes();
        void ViewAllPumps();
        void CreateNewPump();
        void ViewAllParts();
        void AddNewPart();
        void AddCustomer();
        void ViewCustomers();
        void AddBusiness();
        void ViewBusinesses();
        void ViewBusinessesAddresses();
        void ViewBusinessesPOBoxAddresses();
        void ViewBusinessesEmailAddresses();
        void ViewBusinessesPhoneNumbers();
        void EditBusinessAddress();
        void EditBusinessEmailAddress();
        void EditPhoneNumber();
    }
}
