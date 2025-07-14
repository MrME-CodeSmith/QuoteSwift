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
            var navigation = new NavigationService(dataService);
            QuotesViewModel viewModel = new QuotesViewModel(dataService);
            viewModel.LoadData();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmViewQuotes(viewModel, navigation));
        }
    }
}
