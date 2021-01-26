using System.Windows.Forms;


namespace QuoteSwift
{
    public static class MainProgramCode
    {

        /** Message Box Custom Functions */



        //REQUEST Request:

        public static bool RequestConfirmation(string text, string caption)
        {
            DialogResult MessageBoxResult = MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            return MessageBoxResult == DialogResult.Yes;
        }

        public static void ShowError(string text, string caption)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowInformation(string text, string caption)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        /*********************************/
        


        //Procedure Handeling The Closing Of The Application
        public static void CloseApplication(bool b)
        {
            if (b) Application.Exit();
        }



        /** Parse String Inputs: */

        // Parse Float:

        public static float ParseFloat(string t)
        {
            float.TryParse(t, out float temp);
            return temp;
        }
        
        // Parse Bool:

        public static bool ParseBoolean(string t)
        {
            bool.TryParse(t, out bool temp);
            return temp;
        }


        /*************************/



        /** Different Screen Creation Handeling */

        // New Quote:

        public static ref Pass CreateNewQuote(ref Pass passed)
        {
            frmCreateQuote newQuote = new frmCreateQuote(ref passed);
            newQuote.ShowDialog();
            return ref newQuote.Passed;
        }

        //View Quote:

        public static ref Pass ViewAllQuotes(ref Pass passed)
        {
            frmViewQuotes frmViewQuotes = new frmViewQuotes(ref passed);
            frmViewQuotes.ShowDialog();
            return ref frmViewQuotes.Passed;
        }

        // View Pumps:

        public static ref Pass ViewAllPumps(ref Pass passed)
        {
            frmViewPump frmViewPump = new frmViewPump(ref passed);
            frmViewPump.ShowDialog();
            return ref frmViewPump.Passed;
        }

        // New Pump:

        public static ref Pass CreateNewPump(ref Pass passed)
        {
            FrmViewParts frmViewParts = new FrmViewParts(ref passed);
            frmViewParts.ShowDialog();
            return ref frmViewParts.Passed;
        }

        // View Pump Parts:

        public static ref Pass ViewAllParts(ref Pass passed)
        {
            FrmViewParts frmViewParts = new FrmViewParts(ref passed);
            frmViewParts.ShowDialog();
            return ref frmViewParts.Passed;
        }

        // New Parts:

        public static ref Pass AddNewPart(ref Pass passed)
        {
            FrmAddPart frmAddPart = new FrmAddPart(ref passed);
            frmAddPart.ShowDialog();
            return ref frmAddPart.Passed;
        }

        // New Customer:

        public static ref Pass AddCustomer(ref Pass passed)
        {
            frmAddCustomer frmAddCustomer = new frmAddCustomer(ref passed);
            frmAddCustomer.ShowDialog();
            return ref frmAddCustomer.Passed;
        }

        // View Customers:

        public static ref Pass ViewCustomers(ref Pass passed)
        {
            FrmViewCustomers frmViewCustomers = new FrmViewCustomers(ref passed);
            frmViewCustomers.ShowDialog();
            return ref frmViewCustomers.Passed;
        }

        // New Business:

        public static ref Pass AddBusiness(ref Pass passed)
        {
            FrmAddBusiness frmAddBusiness = new FrmAddBusiness(ref passed);
            frmAddBusiness.ShowDialog();
            return ref frmAddBusiness.Passed;
        }

        // View Businesses

        public static ref Pass ViewBusinesses(ref Pass passed)
        {
            frmViewAllBusinesses frmViewAllBusinesses = new frmViewAllBusinesses(ref passed);
            frmViewAllBusinesses.ShowDialog();
            return ref frmViewAllBusinesses.Passed;
        }

        /***************************************/

    }
}
