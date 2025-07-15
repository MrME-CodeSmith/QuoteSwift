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
            IDataService dataService = new FileDataService();
            var appData = new ApplicationData(dataService);
            appData.Load();

            var navigation = new NavigationService(dataService, appData);
            QuotesViewModel viewModel = new QuotesViewModel(dataService);
            viewModel.UpdateData(appData.QuoteMap, appData.BusinessList, appData.PumpList, appData.PartList);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmViewQuotes(viewModel, navigation));
        }
    }
}
