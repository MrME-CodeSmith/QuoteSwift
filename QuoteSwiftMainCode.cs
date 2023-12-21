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

        //Get Last Quote

        public static Quote GetLastQuote()
        {
            if (Global.Context != null && Global.Context.QuoteMap != null)
            {
                int Index = 0;
                DateTime dt = Global.Context.QuoteMap.Values.ToArray()[0].QuoteCreationDate;
                for (int i = 1; i < Global.Context.QuoteMap.Count; i++)
                    if (Global.Context.QuoteMap.Values.ToArray()[i].QuoteCreationDate.Date > dt)
                    {
                        dt = Global.Context.QuoteMap.Values.ToArray()[i].QuoteCreationDate.Date;
                        Index = i;
                    }
                return Global.Context.QuoteMap.Values.ToArray()[Index];
            }

            return null;
        }


        /** Message Box Custom Functions */


        


        /*********************************/



        //Procedure Handling The Closing Of The Application
        public static void CloseApplication(bool b)
        {
            if (b)
            {
                try
                {

                    MainProgramCode.SerializeMandatoryPartList();

                    MainProgramCode.SerializeNonMandatoryPartList();

                    MainProgramCode.SerializePumpList();

                    MainProgramCode.SerializeBusinessList();

                    MainProgramCode.SerializeQuoteList();

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

        public static void CreateNewQuote()
        {
            FrmCreateQuote newQuote = new FrmCreateQuote();
            try
            {
                newQuote.ShowDialog();
            }
            catch (Exception e)
            {
                MainProgramCode.ShowError(e.ToString(), "ERROR - Error Occurred");
                //Do Nothing
            }
        }

        //View Quote:

        public static void ViewAllQuotes()
        {
            FrmViewQuotes frmViewQuotes = new FrmViewQuotes();
            frmViewQuotes.ShowDialog();
        }

        // View Pumps:

        public static void ViewAllPumps()
        {
            FrmViewPump frmViewPump = new FrmViewPump();
            frmViewPump.ShowDialog();
        }

        // New Pump:

        public static void CreateNewPump()
        {
            FrmAddPump frmAddPump = new FrmAddPump();
            frmAddPump.ShowDialog();
        }

        // View Pump Parts:

        public static void ViewAllParts()
        {
            FrmViewParts frmViewParts = new FrmViewParts();
            try
            {
                frmViewParts.ShowDialog();
            }
            catch
            {
                //do nothing
            }
        }

        // New Parts:

        public static void AddNewPart()
        {
            FrmAddPart frmAddPart = new FrmAddPart();
            frmAddPart.ShowDialog();
        }

        // New Customer:

        public static void AddCustomer()
        {
            FrmAddCustomer frmAddCustomer = new FrmAddCustomer();
            frmAddCustomer.ShowDialog();
        }

        // View Customers:

        public static void ViewCustomers()
        {
            FrmViewCustomers frmViewCustomers = new FrmViewCustomers();
            frmViewCustomers.ShowDialog();
        }

        // New Business:

        public static void AddBusiness()
        {
            FrmAddBusiness frmAddBusiness = new FrmAddBusiness();
            frmAddBusiness.ShowDialog();
        }

        // View Businesses

        public static void ViewBusinesses()
        {
            FrmViewAllBusinesses frmViewAllBusinesses = new FrmViewAllBusinesses();
            frmViewAllBusinesses.ShowDialog();
        }

        // View Business Addresses

        public static void ViewBusinessesAddresses()
        {
            FrmViewBusinessAddresses FrmViewBusinessAddresses = new FrmViewBusinessAddresses();
            FrmViewBusinessAddresses.ShowDialog();
        }

        // View Business P.O.Box Addresses

        public static void ViewBusinessesPOBoxAddresses()
        {
            FrmViewPOBoxAddresses FrmViewPOBoxAddresses = new FrmViewPOBoxAddresses();
            FrmViewPOBoxAddresses.ShowDialog();
        }

        // View Business Email Addresses

        public static void ViewBusinessesEmailAddresses()
        {
            FrmManageAllEmails FrmManageAllEmails = new FrmManageAllEmails();
            FrmManageAllEmails.ShowDialog();
        }

        // View Business Phone Numbers

        public static void ViewBusinessesPhoneNumbers()
        {
            FrmManagingPhoneNumbers FrmManagingPhoneNumbers = new FrmManagingPhoneNumbers();
            FrmManagingPhoneNumbers.ShowDialog();
        }

        // Edit Business Address:

        public static void EditBusinessAddress()
        {
            FrmEditBusinessAddress frmEditBusinessAddress = new FrmEditBusinessAddress();
            frmEditBusinessAddress.ShowDialog();
        }

        // Edit Business Email Address:

        public static void EditBusinessEmailAddress()
        {
            FrmEditEmailAddress FrmEditEmailAddress = new FrmEditEmailAddress();
            FrmEditEmailAddress.ShowDialog();
        }

        // Edit Business Phone nUmbers

        public static void EditPhoneNumber()
        {
            FrmEditPhoneNumber frmEditPhoneNumber = new FrmEditPhoneNumber();
            frmEditPhoneNumber.ShowDialog();
        }

        /***************************************/

    }
}
