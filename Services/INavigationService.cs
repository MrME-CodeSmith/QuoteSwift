using System;

namespace QuoteSwift
{
    public interface INavigationService
    {
        Pass CreateNewQuote(Pass pass);
        Pass ViewAllQuotes(Pass pass);
        void ViewAllPumps(ApplicationData data);
        void CreateNewPump(ApplicationData data);
        void ViewAllParts(ApplicationData data);
        void AddNewPart(ApplicationData data, Part partToChange = null, bool changeSpecificObject = false);
        Pass AddCustomer(Pass pass);
        Pass ViewCustomers(Pass pass);
        Pass AddBusiness(Pass pass);
        Pass ViewBusinesses(Pass pass);
        Pass ViewBusinessesAddresses(Pass pass);
        Pass ViewBusinessesPOBoxAddresses(Pass pass);
        Pass ViewBusinessesEmailAddresses(Pass pass);
        Pass ViewBusinessesPhoneNumbers(Pass pass);
        Pass EditBusinessAddress(Pass pass);
        Pass EditBusinessEmailAddress(Pass pass);
        Pass EditPhoneNumber(Pass pass);
    }
}
