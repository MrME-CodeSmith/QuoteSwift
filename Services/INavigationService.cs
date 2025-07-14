using System;

namespace QuoteSwift
{
    public interface INavigationService
    {
        void CreateNewQuote(Pass pass);
        void ViewAllQuotes(Pass pass);
        void ViewAllPumps(Pass pass);
        void CreateNewPump(Pass pass);
        void ViewAllParts(Pass pass);
        void AddNewPart(Pass pass);
        void AddCustomer(Pass pass);
        void ViewCustomers(Pass pass);
        void AddBusiness(Pass pass);
        void ViewBusinesses(Pass pass);
        void ViewBusinessesAddresses(Pass pass);
        void ViewBusinessesPOBoxAddresses(Pass pass);
        void ViewBusinessesEmailAddresses(Pass pass);
        void ViewBusinessesPhoneNumbers(Pass pass);
        void EditBusinessAddress(Pass pass);
        void EditBusinessEmailAddress(Pass pass);
        void EditPhoneNumber(Pass pass);
    }
}
