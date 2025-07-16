using System;
using System.Windows.Forms;

namespace QuoteSwift
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IMessageService messenger = new MessageBoxService();
            IDataService dataService = new FileDataService(messenger);
            var appData = new ApplicationData(dataService);
            appData.Load();

            INotificationService notifier = new MessageBoxNotificationService();
            var navigation = new NavigationService(appData, notifier, messenger);
            QuotesViewModel viewModel = new QuotesViewModel(dataService);
            viewModel.UpdateData(appData.QuoteMap, appData.BusinessList, appData.PumpList, appData.PartList);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmViewQuotes(viewModel, navigation, messenger));
        }
    }
}
