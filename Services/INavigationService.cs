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
        Pass AddCustomer(Pass pass);
        Pass ViewCustomers(Pass pass);
        Pass AddBusiness(Pass pass);
        Pass ViewBusinesses(Pass pass);
        void AddCustomer(ApplicationData data);
        void ViewCustomers(ApplicationData data);
        void AddBusiness(ApplicationData data);
        void ViewBusinesses(ApplicationData data);
        Pass ViewBusinessesAddresses(Pass pass);
        Pass ViewBusinessesPOBoxAddresses(Pass pass);
        Pass ViewBusinessesEmailAddresses(Pass pass);
        Pass ViewBusinessesPhoneNumbers(Pass pass);
        Pass EditBusinessAddress(Pass pass);
        Pass EditBusinessEmailAddress(Pass pass);
        Pass EditPhoneNumber(Pass pass);
    }
}
