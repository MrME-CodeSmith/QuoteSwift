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
            return services.BuildServiceProvider();
        }

        static void Main()
        {
            var serviceProvider = ConfigureServices();
            var appData = serviceProvider.GetRequiredService<ApplicationData>();
            appData.Load();

            var dataService = serviceProvider.GetRequiredService<IDataService>();
            var navigation = serviceProvider.GetRequiredService<INavigationService>();
            var messenger = serviceProvider.GetRequiredService<IMessageService>();
            var serializationService = serviceProvider.GetRequiredService<ISerializationService>();
            QuotesViewModel viewModel = new QuotesViewModel(dataService, navigation, messenger);
            viewModel.UpdateData(appData.QuoteMap, appData.BusinessList, appData.PumpList, appData.PartList);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmViewQuotes(viewModel, navigation, messenger, serializationService));
        }
    }
}
