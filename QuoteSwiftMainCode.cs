using System;
using System.Linq;
using System.Windows.Forms;



namespace QuoteSwift
{ 


    public static class QuoteSwiftMainCode
    {
        

        // Set Components To Read Write:

        public static void ReadWriteComponents(Control.ControlCollection cc)
        {
            if (cc != null)
            {
                foreach (Panel pnl in cc.OfType<Panel>()) pnl.Enabled = true;
                foreach (GroupBox gbx in cc.OfType<GroupBox>()) gbx.Enabled = true;
                foreach (TextBox txt in cc.OfType<TextBox>()) txt.ReadOnly = false;
                foreach (MaskedTextBox mtxt in cc.OfType<MaskedTextBox>()) mtxt.ReadOnly = false;
                foreach (RichTextBox rtxt in cc.OfType<RichTextBox>()) rtxt.ReadOnly = false;
                foreach (ComboBox cb in cc.OfType<ComboBox>()) cb.Enabled = true;
                foreach (DateTimePicker dtp in cc.OfType<DateTimePicker>()) dtp.Enabled = true;
                foreach (NumericUpDown nud in cc.OfType<NumericUpDown>()) nud.ReadOnly = false;
                foreach (DataGridView dgv in cc.OfType<DataGridView>()) dgv.ReadOnly = false;
                foreach (Button btn in cc.OfType<Button>()) btn.Enabled = true;
                foreach (CheckBox cbx in cc.OfType<CheckBox>()) cbx.Enabled = true;
                foreach (Syncfusion.Windows.Forms.Tools.DoubleTextBox dtxt in cc.OfType<Syncfusion.Windows.Forms.Tools.DoubleTextBox>()) dtxt.Enabled = true;
            }
        }

        // Set Components To Read-Only:

        public static void ReadOnlyComponents(Control.ControlCollection cc)
        {
            if (cc != null)
            {
                foreach (Panel pnl in cc.OfType<Panel>()) pnl.Enabled = false;
                foreach (GroupBox gbx in cc.OfType<GroupBox>()) gbx.Enabled = false;
                foreach (TextBox txt in cc.OfType<TextBox>()) txt.ReadOnly = true;
                foreach (MaskedTextBox mtxt in cc.OfType<MaskedTextBox>()) mtxt.ReadOnly = true;
                foreach (RichTextBox rtxt in cc.OfType<RichTextBox>()) rtxt.ReadOnly = true;
                foreach (ComboBox cb in cc.OfType<ComboBox>()) cb.Enabled = false;
                foreach (DateTimePicker dtp in cc.OfType<DateTimePicker>()) dtp.Enabled = false;
                foreach (NumericUpDown nud in cc.OfType<NumericUpDown>()) nud.ReadOnly = true;
                foreach (DataGridView dgv in cc.OfType<DataGridView>()) dgv.ReadOnly = true;
                foreach (Button btn in cc.OfType<Button>()) btn.Enabled = false;
                foreach (CheckBox cbx in cc.OfType<CheckBox>()) cbx.Enabled = false;
                foreach (Syncfusion.Windows.Forms.Tools.DoubleTextBox dtxt in cc.OfType<Syncfusion.Windows.Forms.Tools.DoubleTextBox>()) dtxt.Enabled = false;
            }
        }




        /** Message Box Custom Functions */


        


        /*********************************/



        //Procedure Handling The Closing Of The Application
        public static void CloseApplication(bool b, ref Pass passed)
        {
            if (b)
            {
                try
                {

                    MainProgramCode.SerializeMandatoryPartList(ref passed);

                    MainProgramCode.SerializeNonMandatoryPartList(ref passed);

                    MainProgramCode.SerializePumpList(ref passed);

                    MainProgramCode.SerializeBusinessList(ref passed);

                    MainProgramCode.SerializeQuoteList(ref passed);

                }
                catch (Exception Ex)
                {

                    while (Ex != null)
                    {
                        MainProgramCode.ShowError(Ex.Message, "ERROR Occurred");
                        Ex = Ex.InnerException;
                    }

                }
                finally
                {
                    Application.Exit();
                }
            }
        }

        /** Parse String Inputs: */

        // Parse Float:

        public static float ParseFloat(string t)
        {
            float.TryParse(t, out float temp);
            return temp;
        }

        // Parse Decimal:

        public static decimal ParseDecimal(string t)
        {
            decimal.TryParse(t, out decimal temp);
            return temp;
        }

        // Parse Boole:

        public static bool ParseBoolean(string t)
        {
            bool.TryParse(t, out bool temp);
            return temp;
        }

        // Parse Int:

        public static int ParseInt(string t)
        {
            int.TryParse(t, out int temp);
            return temp;
        }


        /*************************/



        /** Different Screen Creation Handling */

        // New Quote:

        public static ref Pass CreateNewQuote(ref Pass passed)
        {
            FrmCreateQuote newQuote = new FrmCreateQuote(ref passed);
            try
            {
                newQuote.ShowDialog();
            }
            catch (Exception e)
            {
                MainProgramCode.ShowError(e.ToString(), "ERROR - Error Occurred");
                //Do Nothing
            }
            return ref newQuote.Passed;
        }

        //View Quote:

        public static ref Pass ViewAllQuotes(ref Pass passed)
        {
            FrmViewQuotes frmViewQuotes = new FrmViewQuotes(ref passed);
            frmViewQuotes.ShowDialog();
            return ref frmViewQuotes.Passed;
        }

        // View Pumps:

        public static ref Pass ViewAllPumps(ref Pass passed)
        {
            FrmViewPump frmViewPump = new FrmViewPump(ref passed);
            frmViewPump.ShowDialog();
            return ref frmViewPump.Passed;
        }

        // New Pump:

        public static ref Pass CreateNewPump(ref Pass passed)
        {
            FrmAddPump frmAddPump = new FrmAddPump(ref passed);
            frmAddPump.ShowDialog();
            return ref frmAddPump.Passed;
        }

        // View Pump Parts:

        public static ref Pass ViewAllParts(ref Pass passed)
        {
            FrmViewParts frmViewParts = new FrmViewParts(ref passed);
            try
            {
                frmViewParts.ShowDialog();
            }
            catch
            {
                //do nothing
            }
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
            FrmAddCustomer frmAddCustomer = new FrmAddCustomer(ref passed);
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
            FrmViewAllBusinesses frmViewAllBusinesses = new FrmViewAllBusinesses(ref passed);
            frmViewAllBusinesses.ShowDialog();
            return ref frmViewAllBusinesses.Passed;
        }

        // View Business Addresses

        public static ref Pass ViewBusinessesAddresses(ref Pass passed)
        {
            FrmViewBusinessAddresses FrmViewBusinessAddresses = new FrmViewBusinessAddresses(ref passed);
            FrmViewBusinessAddresses.ShowDialog();
            return ref FrmViewBusinessAddresses.Passed;
        }

        // View Business P.O.Box Addresses

        public static ref Pass ViewBusinessesPOBoxAddresses(ref Pass passed)
        {
            FrmViewPOBoxAddresses FrmViewPOBoxAddresses = new FrmViewPOBoxAddresses(ref passed);
            FrmViewPOBoxAddresses.ShowDialog();
            return ref FrmViewPOBoxAddresses.Passed;
        }

        // View Business Email Addresses

        public static ref Pass ViewBusinessesEmailAddresses(ref Pass passed)
        {
            FrmManageAllEmails FrmManageAllEmails = new FrmManageAllEmails(ref passed);
            FrmManageAllEmails.ShowDialog();
            return ref FrmManageAllEmails.Passed;
        }

        // View Business Phone Numbers

        public static ref Pass ViewBusinessesPhoneNumbers(ref Pass passed)
        {
            FrmManagingPhoneNumbers FrmManagingPhoneNumbers = new FrmManagingPhoneNumbers(ref passed);
            FrmManagingPhoneNumbers.ShowDialog();
            return ref FrmManagingPhoneNumbers.Passed;
        }

        // Edit Business Address:

        public static ref Pass EditBusinessAddress(ref Pass passed)
        {
            FrmEditBusinessAddress frmEditBusinessAddress = new FrmEditBusinessAddress(ref passed);
            frmEditBusinessAddress.ShowDialog();
            return ref frmEditBusinessAddress.Passed;
        }

        // Edit Business Email Address:

        public static ref Pass EditBusinessEmailAddress(ref Pass passed)
        {
            FrmEditEmailAddress FrmEditEmailAddress = new FrmEditEmailAddress(ref passed);
            FrmEditEmailAddress.ShowDialog();
            return ref FrmEditEmailAddress.Passed;
        }

        // Edit Business Phone nUmbers

        public static ref Pass EditPhoneNumber(ref Pass passed)
        {
            FrmEditPhoneNumber frmEditPhoneNumber = new FrmEditPhoneNumber(ref passed);
            frmEditPhoneNumber.ShowDialog();
            return ref frmEditPhoneNumber.Passed;
        }

        /***************************************/

    }
}
