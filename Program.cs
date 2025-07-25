﻿using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using QuoteSwift.Views;

namespace QuoteSwift
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IMessageService, MessageBoxService>();
            services.AddSingleton<ISerializationService, FileSerializationService>();
            services.AddSingleton<IDataService, FileDataService>();
            services.AddSingleton<INotificationService, MessageBoxNotificationService>();
            services.AddSingleton<IFileDialogService, FileDialogService>();
            services.AddSingleton<IApplicationService, WinFormsApplicationService>();
            services.AddSingleton<ApplicationData>();
            services.AddSingleton<IExcelExportService, FileExcelExportService>();
            services.AddSingleton<INavigationService, NavigationService>();
            // register view models
            services.AddTransient<AddBusinessViewModel>();
            services.AddTransient<AddCustomerViewModel>();
            services.AddTransient<AddPartViewModel>();
            services.AddTransient<AddPumpViewModel>();
            services.AddTransient<CreateQuoteViewModel>();
            services.AddTransient<EditBusinessAddressViewModel>();
            services.AddTransient<EditEmailAddressViewModel>();
            services.AddTransient<EditPhoneNumberViewModel>();
            services.AddTransient<ManageEmailsViewModel>();
            services.AddTransient<ManagePhoneNumbersViewModel>();
            services.AddTransient<QuotesViewModel>();
            services.AddTransient<ViewBusinessAddressesViewModel>();
            services.AddTransient<ViewBusinessesViewModel>();
            services.AddTransient<ViewCustomersViewModel>();
            services.AddTransient<ViewPOBoxAddressesViewModel>();
            services.AddTransient<ViewPartsViewModel>();
            services.AddTransient<ViewPumpViewModel>();
            // register forms
            services.AddTransient<FrmAddPump>();
            services.AddTransient<FrmAddPart>();
            services.AddTransient<FrmViewParts>();
            services.AddTransient<FrmViewPump>();
            services.AddTransient<FrmCreateQuote>();
            services.AddTransient<FrmViewQuotes>();
            services.AddTransient<FrmAddCustomer>();
            services.AddTransient<FrmViewCustomers>();
            services.AddTransient<FrmAddBusiness>();
            services.AddTransient<FrmViewAllBusinesses>();
            services.AddTransient<FrmViewBusinessAddresses>();
            services.AddTransient<FrmViewPOBoxAddresses>();
            services.AddTransient<FrmManageAllEmails>();
            services.AddTransient<FrmManagingPhoneNumbers>();
            services.AddTransient<FrmEditBusinessAddress>();
            services.AddTransient<FrmEditEmailAddress>();
            services.AddTransient<FrmEditPhoneNumber>();
            return services.BuildServiceProvider();
        }

        static async Task Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var serviceProvider = ConfigureServices();
            var appData = serviceProvider.GetRequiredService<ApplicationData>();
            await appData.LoadAsync();

            var mainForm = serviceProvider.GetRequiredService<FrmViewQuotes>();
            mainForm.ViewModel.UpdateData(appData.QuoteMap, appData.BusinessList, appData.PumpList, appData.PartList);

            Application.Run(mainForm);
        }
    }
}
