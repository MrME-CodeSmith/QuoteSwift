using System;

namespace QuoteSwift
{
    public class NavigationService : INavigationService
    {
        readonly IDataService dataService;
        readonly ApplicationData appData;
        readonly INotificationService notificationService;
        readonly IMessageService messageService;

        public NavigationService(ApplicationData data, INotificationService notifier, IMessageService messenger)
        {
            dataService = new FileDataService(messenger);
            appData = data;
            notificationService = notifier;
            messageService = messenger;
        }

        public void CreateNewQuote(Quote quoteToChange = null, bool changeSpecificObject = false)
        {
            var vm = new CreateQuoteViewModel(dataService);
            using (var form = new FrmCreateQuote(vm, appData, quoteToChange, changeSpecificObject, messageService))
            {
                form.ShowDialog();
            }
            appData.SaveAll();
        }

        public void ViewAllQuotes()
        {
            var vm = new QuotesViewModel(dataService);
            vm.UpdateData(appData.QuoteMap, appData.BusinessList, appData.PumpList, appData.PartList);
            using (var form = new FrmViewQuotes(vm, this, messageService))
            {
                form.ShowDialog();
            }
            appData.QuoteMap = vm.QuoteMap;
            appData.BusinessList = vm.BusinessList;
            appData.PumpList = vm.PumpList;
            appData.PartList = vm.PartMap;
            appData.SaveAll();
        }

        public void ViewAllPumps()
        {
            var vm = new ViewPumpViewModel(dataService);
            vm.UpdateData(appData.PumpList);
            using (var form = new FrmViewPump(vm, this, messageService))
            {
                form.ShowDialog();
            }
        }

        public void CreateNewPump()
        {
            var vm = new AddPumpViewModel(dataService, notificationService);
            vm.UpdateData(appData.PumpList, appData.PartList);
            vm.LoadData();
            using (var form = new FrmAddPump(vm, this, appData, messageService))
            {
                form.ShowDialog();
            }
            appData.PumpList = vm.PumpList;
            appData.PartList = vm.PartMap;
            appData.SaveAll();
        }

        public void ViewAllParts()
        {
            var vm = new ViewPartsViewModel(dataService);
            vm.UpdateData(appData.PartList);
            using (var form = new FrmViewParts(vm, this, appData, messageService))
            {
                form.ShowDialog();
            }
        }

        public void AddNewPart(Part partToChange = null, bool changeSpecificObject = false)
        {
            var vm = new AddPartViewModel(dataService, notificationService);
            vm.UpdateData(appData.PartList, appData.PumpList, partToChange, changeSpecificObject);
            using (var form = new FrmAddPart(vm, this, appData, messageService))
            {
                form.ShowDialog();
            }
            appData.PartList = vm.PartMap;
            appData.PumpList = vm.PumpList;
            appData.SaveAll();
        }


        public void AddCustomer(Business businessToChange = null, Customer customerToChange = null, bool changeSpecificObject = false)
        {
            var vm = new AddCustomerViewModel(dataService, notificationService, messageService);
            vm.UpdateData(appData.BusinessList, customerToChange, changeSpecificObject);
            using (var form = new FrmAddCustomer(vm, this, appData, businessToChange, messageService))
            {
                form.ShowDialog();
            }
            appData.SaveAll();
        }

        public void ViewCustomers()
        {
            var vm = new ViewCustomersViewModel(dataService);
            vm.LoadData();
            using (var form = new FrmViewCustomers(vm, this, appData, messageService))
            {
                form.ShowDialog();
            }
        }

        public void AddBusiness(Business businessToChange = null, bool changeSpecificObject = false)
        {
            var vm = new AddBusinessViewModel(dataService, messageService);
            vm.UpdateData(appData.BusinessList, businessToChange, changeSpecificObject);
            vm.LoadData();
            using (var form = new FrmAddBusiness(vm, this, appData, messageService))
            {
                form.ShowDialog();
            }
            appData.BusinessList = vm.BusinessList;
            appData.SaveAll();
        }

        public void ViewBusinesses()
        {
            var vm = new ViewBusinessesViewModel(dataService);
            vm.UpdateData(appData.BusinessList);
            using (var form = new FrmViewAllBusinesses(vm, this, messageService))
            {
                form.ShowDialog();
            }
        }

        public void ViewBusinessesAddresses(Business business = null, Customer customer = null)
        {
            var vm = new ViewBusinessAddressesViewModel(dataService);
            vm.LoadData();
            using (var form = new FrmViewBusinessAddresses(vm, this, appData, business, customer, messageService))
            {
                form.ShowDialog();
            }
        }

        public void ViewBusinessesPOBoxAddresses(Business business = null, Customer customer = null)
        {
            var vm = new ViewPOBoxAddressesViewModel(dataService);
            vm.LoadData();
            using (var form = new FrmViewPOBoxAddresses(vm, this, appData, business, customer, messageService))
            {
                form.ShowDialog();
            }
        }

        public void ViewBusinessesEmailAddresses(Business business = null, Customer customer = null)
        {
            var vm = new ManageEmailsViewModel(dataService);
            vm.UpdateData(business, customer);
            using (var form = new FrmManageAllEmails(vm, messageService))
            {
                form.ShowDialog();
            }
        }

        public void ViewBusinessesPhoneNumbers(Business business = null, Customer customer = null)
        {
            var vm = new ManagePhoneNumbersViewModel(dataService);
            vm.UpdateData(business, customer);
            using (var form = new FrmManagingPhoneNumbers(vm, messageService))
            {
                form.ShowDialog();
            }
        }

        public void EditBusinessAddress(Business business = null, Customer customer = null, Address address = null)
        {
            var vm = new EditBusinessAddressViewModel(business, customer, address, messageService);
            using (var form = new FrmEditBusinessAddress(vm, messageService))
            {
                form.ShowDialog();
            }
        }

        public void EditBusinessEmailAddress(Business business = null, Customer customer = null, string email = "")
        {
            var vm = new EditEmailAddressViewModel(business, customer, email, messageService);
            using (var form = new FrmEditEmailAddress(vm, messageService))
            {
                form.ShowDialog();
            }
        }

        public void EditPhoneNumber(Business business = null, Customer customer = null, string number = "")
        {
            var vm = new EditPhoneNumberViewModel(business, customer, number, messageService);
            using (var form = new FrmEditPhoneNumber(vm, messageService))
            {
                form.ShowDialog();
            }
        }
    }
}
