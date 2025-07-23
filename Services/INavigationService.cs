using System;
using System.Threading.Tasks;

namespace QuoteSwift
{
    public interface INavigationService
    {
        Task CreateNewQuote(Quote quoteToChange = null, bool changeSpecificObject = false);
        Task ViewAllQuotes();
        Task ViewAllPumps();
        Task CreateNewPump();
        Task ViewAllParts();
        Task AddNewPart(Part partToChange = null, bool changeSpecificObject = false);
        Task AddCustomer(Business businessToChange = null, Customer customerToChange = null, bool changeSpecificObject = false);
        Task ViewCustomers();
        Task AddBusiness(Business businessToChange = null, bool changeSpecificObject = false);
        Task ViewBusinesses();
        Task ViewBusinessesAddresses(Business business = null, Customer customer = null);
        Task ViewBusinessesPOBoxAddresses(Business business = null, Customer customer = null);
        Task ViewBusinessesEmailAddresses(Business business = null, Customer customer = null);
        Task ViewBusinessesPhoneNumbers(Business business = null, Customer customer = null);
        Task EditBusinessAddress(Business business = null, Customer customer = null, Address address = null);
        Task EditBusinessEmailAddress(Business business = null, Customer customer = null, string email = "");
        Task EditPhoneNumber(Business business = null, Customer customer = null, string number = "");
        void SaveAllData();
    }
}
