using System;
using System.Windows.Forms;
using System.Collections.Generic;

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
            Pass passed = new Pass(new SortedDictionary<string, Quote>(), null, null, null, null);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmViewQuotes(ref passed));
        }
    }
}
