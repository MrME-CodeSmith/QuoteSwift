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
                foreach (QuoteSwift.Controls.NumericTextBox dtxt in cc.OfType<QuoteSwift.Controls.NumericTextBox>()) dtxt.Enabled = true;
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
                foreach (QuoteSwift.Controls.NumericTextBox dtxt in cc.OfType<QuoteSwift.Controls.NumericTextBox>()) dtxt.Enabled = false;
            }
        }




        /** Message Box Custom Functions */


        


        /*********************************/



        //Procedure Handling The Closing Of The Application
        // Removed - use MainProgramCode.CloseApplication instead.

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

        [Obsolete("Use NavigationService.CreateNewQuote instead")]
        public static ref Pass CreateNewQuote(ref Pass passed)
        {
            var vm = new CreateQuoteViewModel(new FileDataService());
            vm.UpdatePass(passed);
            FrmCreateQuote newQuote = new FrmCreateQuote(vm);
            try
            {
                newQuote.ShowDialog();
            }
            catch (Exception e)
            {
                MainProgramCode.ShowError(e.ToString(), "ERROR - Error Occurred");
                //Do Nothing
            }
            passed = vm.Pass;
            return ref passed;
        }

        //View Quote:

        [Obsolete("Use NavigationService.ViewAllQuotes instead")]
        public static ref Pass ViewAllQuotes(ref Pass passed)
        {
            var vm = new QuotesViewModel(new FileDataService());
            vm.UpdatePass(passed);
            FrmViewQuotes frmViewQuotes = new FrmViewQuotes(vm, null);
            frmViewQuotes.ShowDialog();
            passed = vm.Pass;
            return ref passed;
        }

        // View Pumps:

        [Obsolete("Use NavigationService.ViewAllPumps instead")]
        public static ref Pass ViewAllPumps(ref Pass passed)
        {
            var vm = new ViewPumpViewModel(new FileDataService());
            vm.UpdatePass(passed);
            FrmViewPump frmViewPump = new FrmViewPump(vm, null);
            frmViewPump.ShowDialog();
            passed = vm.Pass;
            return ref passed;
        }

        // New Pump:

        [Obsolete("Use NavigationService.CreateNewPump instead")]
        public static ref Pass CreateNewPump(ref Pass passed)
        {
            var vm = new AddPumpViewModel(new FileDataService());
            vm.UpdatePass(passed);
            FrmAddPump frmAddPump = new FrmAddPump(vm, null);
            frmAddPump.ShowDialog();
            passed = vm.Pass;
            return ref passed;
        }

        // View Pump Parts:

        [Obsolete("Use NavigationService.ViewAllParts instead")]
        public static ref Pass ViewAllParts(ref Pass passed)
        {
            var vm = new ViewPartsViewModel(new FileDataService());
            vm.UpdatePass(passed);
            FrmViewParts frmViewParts = new FrmViewParts(vm, null);
            try
            {
                frmViewParts.ShowDialog();
            }
            catch
            {
                //do nothing
            }
            passed = vm.Pass;
            return ref passed;
        }

        // New Parts:

        [Obsolete("Use NavigationService.AddNewPart instead")]
        public static ref Pass AddNewPart(ref Pass passed)
        {
            var vm = new AddPartViewModel(new FileDataService());
            vm.UpdatePass(passed.PassPartList, passed.PassPumpList, passed.PartToChange, passed.ChangeSpecificObject);
            FrmAddPart frmAddPart = new FrmAddPart(vm, null);
            frmAddPart.SetPass(passed);
            frmAddPart.ShowDialog();
            return ref passed;
        }

        // New Customer:

        [Obsolete("Use NavigationService.AddCustomer instead")]
        public static ref Pass AddCustomer(ref Pass passed)
        {
            var vm = new AddCustomerViewModel(new FileDataService());
            vm.UpdatePass(passed);
            FrmAddCustomer frmAddCustomer = new FrmAddCustomer(vm, null);
            frmAddCustomer.ShowDialog();
            passed = vm.Pass;
            return ref passed;
        }

        // View Customers:

        [Obsolete("Use NavigationService.ViewCustomers instead")]
        public static ref Pass ViewCustomers(ref Pass passed)
        {
            var vm = new ViewCustomersViewModel(new FileDataService());
            vm.UpdatePass(passed);
            FrmViewCustomers frmViewCustomers = new FrmViewCustomers(vm, null);
            frmViewCustomers.ShowDialog();
            passed = vm.Pass;
            return ref passed;
        }

        // New Business:

        [Obsolete("Use NavigationService.AddBusiness instead")]
        public static ref Pass AddBusiness(ref Pass passed)
        {
            var vm = new AddBusinessViewModel(new FileDataService());
            vm.UpdatePass(passed);
            FrmAddBusiness frmAddBusiness = new FrmAddBusiness(vm, null);
            frmAddBusiness.ShowDialog();
            passed = vm.Pass;
            return ref passed;
        }

        // View Businesses

        [Obsolete("Use NavigationService.ViewBusinesses instead")]
        public static ref Pass ViewBusinesses(ref Pass passed)
        {
            var vm = new ViewBusinessesViewModel(new FileDataService());
            vm.UpdatePass(passed);
            FrmViewAllBusinesses frmViewAllBusinesses = new FrmViewAllBusinesses(vm, null);
            frmViewAllBusinesses.ShowDialog();
            passed = vm.Pass;
            return ref passed;
        }

        // View Business Addresses

        [Obsolete("Use NavigationService.ViewBusinessesAddresses instead")]
        public static ref Pass ViewBusinessesAddresses(ref Pass passed)
        {
            var vm = new ViewBusinessAddressesViewModel(new FileDataService());
            vm.UpdatePass(passed);
            FrmViewBusinessAddresses FrmViewBusinessAddresses = new FrmViewBusinessAddresses(vm, null);
            FrmViewBusinessAddresses.ShowDialog();
            passed = vm.Pass;
            return ref passed;
        }

        // View Business P.O.Box Addresses

        [Obsolete("Use NavigationService.ViewBusinessesPOBoxAddresses instead")]
        public static ref Pass ViewBusinessesPOBoxAddresses(ref Pass passed)
        {
            var vm = new ViewPOBoxAddressesViewModel(new FileDataService());
            vm.UpdatePass(passed);
            FrmViewPOBoxAddresses FrmViewPOBoxAddresses = new FrmViewPOBoxAddresses(vm, null);
            FrmViewPOBoxAddresses.ShowDialog();
            passed = vm.Pass;
            return ref passed;
        }

        // View Business Email Addresses

        [Obsolete("Use NavigationService.ViewBusinessesEmailAddresses instead")]
        public static ref Pass ViewBusinessesEmailAddresses(ref Pass passed)
        {
            var vm = new ManageEmailsViewModel(new FileDataService());
            vm.UpdatePass(passed);
            FrmManageAllEmails FrmManageAllEmails = new FrmManageAllEmails(vm, null);
            FrmManageAllEmails.ShowDialog();
            passed = vm.Pass;
            return ref passed;
        }

        // View Business Phone Numbers

        [Obsolete("Use NavigationService.ViewBusinessesPhoneNumbers instead")]
        public static ref Pass ViewBusinessesPhoneNumbers(ref Pass passed)
        {
            var vm = new ManagePhoneNumbersViewModel(new FileDataService());
            vm.UpdatePass(passed);
            FrmManagingPhoneNumbers FrmManagingPhoneNumbers = new FrmManagingPhoneNumbers(vm, null);
            FrmManagingPhoneNumbers.ShowDialog();
            passed = vm.Pass;
            return ref passed;
        }

        // Edit Business Address:

        [Obsolete("Use NavigationService.EditBusinessAddress instead")]
        public static ref Pass EditBusinessAddress(ref Pass passed)
        {
            var vm = new ViewBusinessAddressesViewModel(new FileDataService());
            vm.UpdatePass(passed);
            FrmEditBusinessAddress frmEditBusinessAddress = new FrmEditBusinessAddress(vm);
            frmEditBusinessAddress.ShowDialog();
            passed = vm.Pass;
            return ref passed;
        }

        // Edit Business Email Address:

        [Obsolete("Use NavigationService.EditBusinessEmailAddress instead")]
        public static ref Pass EditBusinessEmailAddress(ref Pass passed)
        {
            var vm = new ManageEmailsViewModel(new FileDataService());
            vm.UpdatePass(passed);
            FrmEditEmailAddress FrmEditEmailAddress = new FrmEditEmailAddress(vm);
            FrmEditEmailAddress.ShowDialog();
            passed = vm.Pass;
            return ref passed;
        }

        // Edit Business Phone nUmbers

        [Obsolete("Use NavigationService.EditPhoneNumber instead")]
        public static ref Pass EditPhoneNumber(ref Pass passed)
        {
            var vm = new ManagePhoneNumbersViewModel(new FileDataService());
            vm.UpdatePass(passed);
            FrmEditPhoneNumber frmEditPhoneNumber = new FrmEditPhoneNumber(vm);
            frmEditPhoneNumber.ShowDialog();
            passed = vm.Pass;
            return ref passed;
        }

        /***************************************/

    }
}
