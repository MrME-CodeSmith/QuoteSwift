using System;

namespace QuoteSwift
{
    public class NavigationService : INavigationService
    {
        readonly IDataService dataService;
        readonly ApplicationData appData;

        public NavigationService(ApplicationData data)
        {
            dataService = new FileDataService();
            appData = data;
        }

        public void CreateNewQuote(ApplicationData data, Quote quoteToChange = null, bool changeSpecificObject = false)
        {
            var vm = new CreateQuoteViewModel(dataService);
            using (var form = new FrmCreateQuote(vm, appData, quoteToChange, changeSpecificObject))
            {
                form.ShowDialog();
            }
            appData.SaveAll();
        }

        public void ViewAllQuotes(ApplicationData data)
        {
            var vm = new QuotesViewModel(dataService);
            vm.UpdateData(appData.QuoteMap, appData.BusinessList, appData.PumpList, appData.PartList);
            using (var form = new FrmViewQuotes(vm, this, appData))
            {
                form.ShowDialog();
            }
            appData.QuoteMap = vm.QuoteMap;
            appData.BusinessList = vm.BusinessList;
            appData.PumpList = vm.PumpList;
            appData.PartList = vm.PartMap;
            appData.SaveAll();
        }

        public void ViewAllPumps(ApplicationData data)
        {
            var vm = new ViewPumpViewModel(dataService);
            vm.LoadData();
            using (var form = new FrmViewPump(vm, this, appData))
            {
                form.ShowDialog();
            }
        }

        public void CreateNewPump(ApplicationData data)
        {
            var vm = new AddPumpViewModel(dataService);
            vm.UpdateData(appData.PumpList, appData.PartList);
            vm.LoadData();
            using (var form = new FrmAddPump(vm, this, appData))
            {
                form.ShowDialog();
            }
            appData.PumpList = vm.PumpList;
            appData.PartList = vm.PartMap;
            appData.SaveAll();
        }

        public void ViewAllParts(ApplicationData data)
        {
            var vm = new ViewPartsViewModel(dataService);
            vm.UpdateData(appData.PartList);
            using (var form = new FrmViewParts(vm, this, appData))
            {
                form.ShowDialog();
            }
        }

        public void AddNewPart(ApplicationData data, Part partToChange = null, bool changeSpecificObject = false)
        {
            var vm = new AddPartViewModel(dataService);
            vm.UpdateData(appData.PartList, appData.PumpList, partToChange, changeSpecificObject);
            using (var form = new FrmAddPart(vm, this, appData))
            {
                form.ShowDialog();
            }
            appData.PartList = vm.PartMap;
            appData.PumpList = vm.PumpList;
            appData.SaveAll();
        }


        public void AddCustomer(ApplicationData data, Business businessToChange = null, Customer customerToChange = null, bool changeSpecificObject = false)
        {
            var vm = new AddCustomerViewModel(dataService);
            vm.UpdateData(appData.BusinessList, customerToChange, changeSpecificObject);
            using (var form = new FrmAddCustomer(vm, this, appData, businessToChange))
            {
                form.ShowDialog();
            }
            appData.SaveAll();
        }

        public void ViewCustomers(ApplicationData data)
        {
            var vm = new ViewCustomersViewModel(dataService);
            vm.LoadData();
            using (var form = new FrmViewCustomers(vm, this, appData))
            {
                form.ShowDialog();
            }
        }

        public void AddBusiness(ApplicationData data, Business businessToChange = null, bool changeSpecificObject = false)
        {
            var vm = new AddBusinessViewModel(dataService);
            vm.UpdateData(appData.BusinessList, businessToChange, changeSpecificObject);
            vm.LoadData();
            using (var form = new FrmAddBusiness(vm, this, appData))
            {
                form.ShowDialog();
            }
            appData.BusinessList = vm.BusinessList;
            appData.SaveAll();
        }

        public void ViewBusinesses(ApplicationData data)
        {
            var vm = new ViewBusinessesViewModel(dataService);
            vm.LoadData();
            using (var form = new FrmViewAllBusinesses(vm, this, appData))
            {
                form.ShowDialog();
            }
        }

        public void ViewBusinessesAddresses(Business business = null, Customer customer = null)
        {
            var vm = new ViewBusinessAddressesViewModel(dataService);
            vm.LoadData();
            using (var form = new FrmViewBusinessAddresses(vm, this, appData, business, customer))
            {
                form.ShowDialog();
            }
        }

        public void ViewBusinessesPOBoxAddresses(Business business = null, Customer customer = null)
        {
            var vm = new ViewPOBoxAddressesViewModel(dataService);
            vm.LoadData();
            using (var form = new FrmViewPOBoxAddresses(vm, this, appData, business, customer))
            {
                form.ShowDialog();
            }
        }

        public void ViewBusinessesEmailAddresses(Business business = null, Customer customer = null)
        {
            var vm = new ManageEmailsViewModel(dataService);
            vm.LoadData();
            using (var form = new FrmManageAllEmails(vm, this, appData, business, customer))
            {
                form.ShowDialog();
            }
        }

        public void ViewBusinessesPhoneNumbers(Business business = null, Customer customer = null)
        {
            var vm = new ManagePhoneNumbersViewModel(dataService);
            vm.LoadData();
            using (var form = new FrmManagingPhoneNumbers(vm, this, appData, business, customer))
            {
                form.ShowDialog();
            }
        }

        public void EditBusinessAddress(Business business = null, Customer customer = null, Address address = null)
        {
            using (var form = new FrmEditBusinessAddress(appData, business, customer, address))
            {
                form.ShowDialog();
            }
        }

        public void EditBusinessEmailAddress(Business business = null, Customer customer = null, string email = "")
        {
            using (var form = new FrmEditEmailAddress(appData, business, customer, email))
            {
                form.ShowDialog();
            }
        }

        public void EditPhoneNumber(Business business = null, Customer customer = null, string number = "")
        {
            using (var form = new FrmEditPhoneNumber(appData, business, customer, number))
            {
                form.ShowDialog();
            }
        }
    }
}
