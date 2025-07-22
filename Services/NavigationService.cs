using System;
using Microsoft.Extensions.DependencyInjection;

namespace QuoteSwift
{
    public class NavigationService : INavigationService
    {
        readonly IDataService dataService;
        readonly ApplicationData appData;
        readonly INotificationService notificationService;
        readonly IMessageService messageService;
        readonly ISerializationService serializationService;
        readonly IExcelExportService excelExportService;
        readonly IFileDialogService fileDialogService;
        readonly IServiceProvider serviceProvider;

        public NavigationService(IServiceProvider provider, ApplicationData data, IDataService service, INotificationService notifier, IMessageService messenger, ISerializationService serializer, IExcelExportService excelExporter, IFileDialogService dialogService)
        {
            serviceProvider = provider;
            dataService = service;
            appData = data;
            serializationService = serializer;
            notificationService = notifier;
            messageService = messenger;
            excelExportService = excelExporter;
            fileDialogService = dialogService;
        }

        public void CreateNewQuote(Quote quoteToChange = null, bool changeSpecificObject = false)
        {
            var vm = serviceProvider.GetRequiredService<CreateQuoteViewModel>();
            using (var form = new FrmCreateQuote(vm, appData, quoteToChange, changeSpecificObject, messageService, serializationService))
                form.ShowDialog();
            }
            appData.SaveAll();
        }

        public void ViewAllQuotes()
        {
            var vm = serviceProvider.GetRequiredService<QuotesViewModel>();
            vm.UpdateData(appData.QuoteMap, appData.BusinessList, appData.PumpList, appData.PartList);
            using (var form = new FrmViewQuotes(vm, this, messageService, serializationService))
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
            var vm = serviceProvider.GetRequiredService<ViewPumpViewModel>();
            vm.UpdateData(appData.PumpList);
            using (var form = new FrmViewPump(vm, this, messageService))
            {
                form.ShowDialog();
            }
        }

        public void CreateNewPump()
        {
            var vm = serviceProvider.GetRequiredService<AddPumpViewModel>();
            vm.UpdateData(appData.PumpList, appData.PartList);
            vm.LoadDataAsync().GetAwaiter().GetResult();
            using (var form = new FrmAddPump(vm, this, appData, messageService, serializationService))
            {
                form.ShowDialog();
            }
            appData.PumpList = vm.PumpList;
            appData.PartList = vm.PartMap;
            appData.SaveAll();
        }

        public void ViewAllParts()
        {
            var vm = serviceProvider.GetRequiredService<ViewPartsViewModel>();
            vm.UpdateData(appData.PartList);
            using (var form = new FrmViewParts(vm, this, appData, messageService, serializationService))
            {
                form.ShowDialog();
            }
        }

        public void AddNewPart(Part partToChange = null, bool changeSpecificObject = false)
        {
            var vm = serviceProvider.GetRequiredService<AddPartViewModel>();
            vm.UpdateData(appData.PartList, appData.PumpList, partToChange, changeSpecificObject);
            using (var form = new FrmAddPart(vm, this, appData, messageService, serializationService))
            {
                form.ShowDialog();
            }
            appData.PartList = vm.PartMap;
            appData.PumpList = vm.PumpList;
            appData.SaveAll();
        }


        public void AddCustomer(Business businessToChange = null, Customer customerToChange = null, bool changeSpecificObject = false)
        {
            var vm = serviceProvider.GetRequiredService<AddCustomerViewModel>();
            vm.UpdateData(appData.BusinessList, customerToChange, changeSpecificObject);
            using (var form = new FrmAddCustomer(vm, this, businessToChange, messageService, serializationService))
            {
                form.ShowDialog();
            }
            appData.SaveAll();
        }

        public void ViewCustomers()
        {
            var vm = serviceProvider.GetRequiredService<ViewCustomersViewModel>();
            vm.LoadDataAsync().GetAwaiter().GetResult();
            using (var form = new FrmViewCustomers(vm, this, appData, messageService, serializationService))
            {
                form.ShowDialog();
            }
        }

        public void AddBusiness(Business businessToChange = null, bool changeSpecificObject = false)
        {
            var vm = serviceProvider.GetRequiredService<AddBusinessViewModel>();
            vm.UpdateData(appData.BusinessList, businessToChange, changeSpecificObject);
            vm.LoadDataAsync().GetAwaiter().GetResult();
            using (var form = new FrmAddBusiness(vm, this, messageService, serializationService))
            {
                form.ShowDialog();
            }
            appData.BusinessList = vm.BusinessList;
            appData.SaveAll();
        }

        public void ViewBusinesses()
        {
            var vm = serviceProvider.GetRequiredService<ViewBusinessesViewModel>();
            vm.UpdateData(appData.BusinessList);
            using (var form = new FrmViewAllBusinesses(vm, this, messageService))
            {
                form.ShowDialog();
            }
        }

        public void ViewBusinessesAddresses(Business business = null, Customer customer = null)
        {
            var vm = serviceProvider.GetRequiredService<ViewBusinessAddressesViewModel>();
            vm.UpdateData(business, customer);
            using (var form = new FrmViewBusinessAddresses(vm, this, business, customer, messageService))
            {
                form.ShowDialog();
            }
        }

        public void ViewBusinessesPOBoxAddresses(Business business = null, Customer customer = null)
        {
            var vm = serviceProvider.GetRequiredService<ViewPOBoxAddressesViewModel>();
            vm.UpdateData(business, customer);
            using (var form = new FrmViewPOBoxAddresses(vm, this, business, customer, messageService))
            {
                form.ShowDialog();
            }
        }

        public void ViewBusinessesEmailAddresses(Business business = null, Customer customer = null)
        {
            var vm = serviceProvider.GetRequiredService<ManageEmailsViewModel>();
            vm.UpdateData(business, customer);
            using (var form = new FrmManageAllEmails(vm, this, messageService))
            {
                form.ShowDialog();
            }
        }

        public void ViewBusinessesPhoneNumbers(Business business = null, Customer customer = null)
        {
            var vm = serviceProvider.GetRequiredService<ManagePhoneNumbersViewModel>();
            vm.UpdateData(business, customer);
            using (var form = new FrmManagingPhoneNumbers(vm, this, messageService))
            {
                form.ShowDialog();
            }
        }

        public void EditBusinessAddress(Business business = null, Customer customer = null, Address address = null)
        {
            var vm = serviceProvider.GetRequiredService<EditBusinessAddressViewModel>();
            vm.Initialize(business, customer, address);
            using (var form = new FrmEditBusinessAddress(vm, messageService))
            {
                form.ShowDialog();
            }
        }

        public void EditBusinessEmailAddress(Business business = null, Customer customer = null, string email = "")
        {
            var vm = serviceProvider.GetRequiredService<EditEmailAddressViewModel>();
            vm.Initialize(business, customer, email);
            using (var form = new FrmEditEmailAddress(vm, messageService))
            {
                form.ShowDialog();
            }
        }

        public void EditPhoneNumber(Business business = null, Customer customer = null, string number = "")
        {
            var vm = serviceProvider.GetRequiredService<EditPhoneNumberViewModel>();
            vm.Initialize(business, customer, number);
            using (var form = new FrmEditPhoneNumber(vm, messageService))
            {
                form.ShowDialog();
            }
        }

        public void SaveAllData()
        {
            appData.SaveAll();
        }
    }
}
