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
            Pass passed = new Pass(null, null, null, null);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmViewQuotes(ref passed));
        }
    }
}
