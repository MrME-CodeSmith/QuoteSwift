using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using QuoteSwift.Views;

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
            using (var form = serviceProvider.GetRequiredService<FrmCreateQuote>())
            {
                form.Initialize(quoteToChange, changeSpecificObject);
                form.ShowDialog();
            }
            appData.SaveAll();
        }

        public void ViewAllQuotes()
        {
            using (var form = serviceProvider.GetRequiredService<FrmViewQuotes>())
            {
                form.ViewModel.UpdateData(appData.QuoteMap, appData.BusinessList, appData.PumpList, appData.PartList);
                form.ShowDialog();
                appData.QuoteMap = form.ViewModel.QuoteMap;
                appData.BusinessList = form.ViewModel.BusinessList;
                appData.PumpList = form.ViewModel.PumpList;
                appData.PartList = form.ViewModel.PartMap;
            }
            appData.SaveAll();
        }

        public void ViewAllPumps()
        {
            using (var form = serviceProvider.GetRequiredService<FrmViewPump>())
            {
                form.ViewModel.LoadDataCommand.Execute(null);
                form.ShowDialog();
            }
        }

        public async Task CreateNewPump()
        {
            using (var form = serviceProvider.GetRequiredService<FrmAddPump>())
            {
                await form.ViewModel.LoadDataAsync();
                form.ShowDialog();
            }
            appData.SaveAll();
        }

        public void ViewAllParts()
        {
            using (var form = serviceProvider.GetRequiredService<FrmViewParts>())
            {
                form.ViewModel.LoadDataCommand.Execute(null);
                form.ShowDialog();
            }
        }

        public void AddNewPart(Part partToChange = null, bool changeSpecificObject = false)
        {
            using (var form = serviceProvider.GetRequiredService<FrmAddPart>())
            {
                form.ViewModel.PartToChange = partToChange;
                form.ViewModel.ChangeSpecificObject = changeSpecificObject;
                form.ViewModel.LoadDataCommand.Execute(null);
                form.ShowDialog();
            }
            appData.SaveAll();
        }


        public async Task AddCustomer(Business businessToChange = null, Customer customerToChange = null, bool changeSpecificObject = false)
        {
            using (var form = serviceProvider.GetRequiredService<FrmAddCustomer>())
            {
                form.ViewModel.UpdateData(appData.BusinessList, customerToChange, changeSpecificObject);
                form.Container = businessToChange;
                form.ShowDialog();
            }
            appData.SaveAll();
            await Task.CompletedTask;
        }

        public async Task ViewCustomers()
        {
            using (var form = serviceProvider.GetRequiredService<FrmViewCustomers>())
            {
                await form.ViewModel.LoadDataAsync();
                form.ShowDialog();
            }
        }

        public async Task AddBusiness(Business businessToChange = null, bool changeSpecificObject = false)
        {
            using (var form = serviceProvider.GetRequiredService<FrmAddBusiness>())
            {
                form.ViewModel.UpdateData(appData.BusinessList, businessToChange, changeSpecificObject);
                await form.ViewModel.LoadDataAsync();
                form.ShowDialog();
                appData.BusinessList = form.ViewModel.BusinessList;
            }
            appData.SaveAll();
        }

        public void ViewBusinesses()
        {
            using (var form = serviceProvider.GetRequiredService<FrmViewAllBusinesses>())
            {
                form.ViewModel.UpdateData(appData.BusinessList);
                form.ShowDialog();
            }
        }

        public void ViewBusinessesAddresses(Business business = null, Customer customer = null)
        {
            using (var form = serviceProvider.GetRequiredService<FrmViewBusinessAddresses>())
            {
                form.Initialize(business, customer);
                form.ViewModel.UpdateData(business, customer);
                form.ShowDialog();
            }
        }

        public void ViewBusinessesPOBoxAddresses(Business business = null, Customer customer = null)
        {
            using (var form = serviceProvider.GetRequiredService<FrmViewPOBoxAddresses>())
            {
                form.Initialize(business, customer);
                form.ViewModel.UpdateData(business, customer);
                form.ShowDialog();
            }
        }

        public void ViewBusinessesEmailAddresses(Business business = null, Customer customer = null)
        {
            using (var form = serviceProvider.GetRequiredService<FrmManageAllEmails>())
            {
                form.ViewModel.UpdateData(business, customer);
                form.ShowDialog();
            }
        }

        public void ViewBusinessesPhoneNumbers(Business business = null, Customer customer = null)
        {
            using (var form = serviceProvider.GetRequiredService<FrmManagingPhoneNumbers>())
            {
                form.ViewModel.UpdateData(business, customer);
                form.ShowDialog();
            }
        }

        public void EditBusinessAddress(Business business = null, Customer customer = null, Address address = null)
        {
            using (var form = serviceProvider.GetRequiredService<FrmEditBusinessAddress>())
            {
                form.ViewModel.Initialize(business, customer, address);
                form.ShowDialog();
            }
        }

        public void EditBusinessEmailAddress(Business business = null, Customer customer = null, string email = "")
        {
            using (var form = serviceProvider.GetRequiredService<FrmEditEmailAddress>())
            {
                form.ViewModel.Initialize(business, customer, email);
                form.ShowDialog();
            }
        }

        public void EditPhoneNumber(Business business = null, Customer customer = null, string number = "")
        {
            using (var form = serviceProvider.GetRequiredService<FrmEditPhoneNumber>())
            {
                form.ViewModel.Initialize(business, customer, number);
                form.ShowDialog();
            }
        }

        public void SaveAllData()
        {
            appData.SaveAll();
            serializationService.CloseApplication(true,
                appData.BusinessList,
                appData.PumpList,
                appData.PartList,
                appData.QuoteMap);
        }
    }
}
