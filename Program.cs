using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;

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
            return services.BuildServiceProvider();
        }

        static void Main()
        {
            var serviceProvider = ConfigureServices();
            var appData = serviceProvider.GetRequiredService<ApplicationData>();
            appData.Load();

            var navigation = serviceProvider.GetRequiredService<INavigationService>();
            var messenger = serviceProvider.GetRequiredService<IMessageService>();
            var serializationService = serviceProvider.GetRequiredService<ISerializationService>();
            var viewModel = serviceProvider.GetRequiredService<QuotesViewModel>();
            viewModel.UpdateData(appData.QuoteMap, appData.BusinessList, appData.PumpList, appData.PartList);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmViewQuotes(viewModel, navigation, messenger, serializationService));
        }
    }
}
