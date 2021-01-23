using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Threading;

namespace QuoteSwift
{
    class MainProgramCode
    {

        /** Message Box Custom Functions */

        //Confirmation Request:

        public bool RequestConfirmation(string text, string caption)
        {
            DialogResult MessageBoxResult = MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return MessageBoxResult == DialogResult.Yes ? true : false;
        }

        public void ShowError(string text, string caption)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowInformation(string text, string caption)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /*********************************/
        
        //Procedure Handeling The Closing Of The Application
        public void CloseApplication(bool b)
        {
            if (b) Application.Exit();
        }

        /** Different Screen Creation Handeling */

        // New Quote:

        public ref Pass CreateNewQuote(ref Pass passed)
        {
            frmCreateQuote newQuote = new frmCreateQuote(ref passed);
            newQuote.ShowDialog();
            return ref newQuote.Passed;
        }

        // View Pumps:

        public ref Pass ViewAllPumps(ref Pass passed)
        {
            frmViewPump frmViewPump = new frmViewPump(ref passed);
            frmViewPump.ShowDialog();
            return ref frmViewPump.Passed;
        }

        // New Pump:

        public ref Pass CreateNewPump(ref Pass passed)
        {
            frmAddPump frmAddPump = new frmAddPump(ref passed);
            frmAddPump.ShowDialog();
            return ref frmAddPump.Passed;
        }

        // New Customer:

        public ref Pass AddCustomer(ref Pass passed)
        {
            frmAddCustomer frmAddCustomer = new frmAddCustomer(ref passed);
            frmAddCustomer.ShowDialog();
            return ref frmAddCustomer.Passed;
        }

        // View Customers:

        public ref Pass ViewCustomers(ref Pass passed)
        {
            frmViewCustomers frmViewCustomers = new frmViewCustomers(ref passed);
            frmViewCustomers.ShowDialog();
            return ref frmViewCustomers.Passed;
        }

        // New Business:

        public ref Pass AddBusiness(ref Pass passed)
        {
            frmAddBusiness frmAddBusiness = new frmAddBusiness(ref passed);
            frmAddBusiness.ShowDialog();
            return ref frmAddBusiness.Passed;
        }

        // View Businesses

        public  Pass ViewBusinesses(ref Pass passed)
        {
            frmViewAllBusinesses frmViewAllBusinesses = new frmViewAllBusinesses(ref passed);
            frmViewAllBusinesses.ShowDialog();
            return frmViewAllBusinesses.Passed;
        }

        /***************************************/

    }
}
