using System;

namespace QuoteSwift
{
    public interface INavigationService
    {
        Pass CreateNewQuote(Pass pass);
        Pass ViewAllQuotes(Pass pass);
        Pass ViewAllPumps(Pass pass);
        void CreateNewPump(ApplicationData data);
        Pass ViewAllParts(Pass pass);
        Pass AddNewPart(Pass pass);
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
