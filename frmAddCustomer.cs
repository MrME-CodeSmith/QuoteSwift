using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmAddCustomer : Form
    {

        readonly AddCustomerViewModel viewModel;
        readonly INavigationService navigation;

        Business Container;

        public FrmAddCustomer(AddCustomerViewModel viewModel, INavigationService navigation = null)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.navigation = navigation;
            viewModel.CurrentCustomer = viewModel.Pass.CustomerToChange ?? new Customer();

            txtCustomerCompanyName.DataBindings.Add("Text", viewModel.CurrentCustomer, nameof(Customer.CustomerCompanyName), false, DataSourceUpdateMode.OnPropertyChanged);
            mtxtVendorNumber.DataBindings.Add("Text", viewModel.CurrentCustomer, nameof(Customer.VendorNumber), false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
            {
                var p = viewModel.Pass;
                MainProgramCode.CloseApplication(true, ref p);
                viewModel.UpdatePass(p);
            }
        }

        private void BtnAddCustomer_Click(object sender, EventArgs e)
        {
            if (ValidBusiness() && !viewModel.Pass.ChangeSpecificObject)
            {
                Business linkBusiness = GetSelectedBusiness();
                viewModel.CurrentCustomer.CustomerName = string.Empty;
                viewModel.CurrentCustomer.CustomerLegalDetails = new Legal(mtxtRegistrationNumber.Text, mtxtVATNumber.Text);
                viewModel.CurrentCustomer.VendorNumber = mtxtVendorNumber.Text;

                if (viewModel.AddCustomer(linkBusiness))
                {
                    MainProgramCode.ShowInformation(viewModel.CurrentCustomer.CustomerCompanyName + " has been added.", "INFORMATION - Business Successfully Added");
                    ResetScreenInput();
                }
            }
            else if (ValidBusiness() && viewModel.Pass.ChangeSpecificObject)
            {
                string oldName = viewModel.Pass.CustomerToChange.CustomerCompanyName;
                viewModel.CurrentCustomer.CustomerName = string.Empty;
                viewModel.CurrentCustomer.CustomerLegalDetails = new Legal(mtxtRegistrationNumber.Text, mtxtVATNumber.Text);
                viewModel.CurrentCustomer.VendorNumber = mtxtVendorNumber.Text;

                Business container = GetSelectedBusiness();
                if (viewModel.UpdateCustomer(container, oldName))
                {
                    MainProgramCode.ShowInformation(viewModel.CurrentCustomer.CustomerCompanyName + " has been successfully updated.", "INFORMATION - Customer Successfully Updated");
                    ConvertToViewOnly();
                }
            }
        }

        private void FrmAddCustomer_Load(object sender, EventArgs e)
        {
            viewModel.LoadData();
            ViewCustomersViewModel vm = new ViewCustomersViewModel(viewModel.DataService);
            vm.LoadData();
            if (vm.Pass != null && vm.Pass.PassBusinessList != null)
            {
                BindingSource source = new BindingSource { DataSource = vm.Pass.PassBusinessList };
                cbBusinessSelection.DataSource = source.DataSource;
                cbBusinessSelection.DisplayMember = "BusinessName";
                cbBusinessSelection.ValueMember = "BusinessName";
            }

            if (viewModel.Pass.CustomerToChange != null && viewModel.Pass.ChangeSpecificObject) // Change Existing Customer Info
            {
                viewModel.CurrentCustomer = viewModel.Pass.CustomerToChange;
            }
            else if (viewModel.Pass.CustomerToChange != null && !viewModel.Pass.ChangeSpecificObject) // View Existing Customer Info
            {
                viewModel.CurrentCustomer = viewModel.Pass.CustomerToChange;
                ConvertToViewOnly();
                LoadInformation();

            }
            else if (viewModel.Pass.CustomerToChange == null && !viewModel.Pass.ChangeSpecificObject) // Add New Business Info
            {
                viewModel.CurrentCustomer = new Customer();
            }
            else // Undefined Use - Show ERROR
            {
                MainProgramCode.ShowError("The form was activated without the correct parameters to have an achievable goal.\nThe Form's input parameters will be disabled to avoid possible data corruption.", "ERROR - Undefined Form Use Called");
                DisableMainComponents();
            }
        }

        private void BtnAddAddress_Click(object sender, EventArgs e)
        {
            if (ValidCustomerAddress())
            {
                Address address = new Address(txtCustomerAddresssDescription.Text, 0, txtAtt.Text, txtWorkArea.Text, txtWorkPlace.Text, 0);
                if (viewModel.AddDeliveryAddress(address))
                {
                    MainProgramCode.ShowInformation("Successfully added the customer address", "INFORMATION - Customer Address Added Successfully");
                    ClearCustomerAddressInput();
                }
            }
        }

        private void BtnAddPOBoxAddress_Click(object sender, EventArgs e)
        {
            if (ValidCustomerPOBoxAddress())
            {
                Address address = new Address(txtCustomerPODescription.Text, QuoteSwiftMainCode.ParseInt(mtxtPOBoxStreetNumber.Text),
                                              "", txtPOBoxSuburb.Text, txtPOBoxCity.Text, QuoteSwiftMainCode.ParseInt(mtxtPOBoxAreaCode.Text));
                if (viewModel.AddPOBoxAddress(address))
                {
                    MainProgramCode.ShowInformation("Successfully added the customer P.O.Box address", "INFORMATION - Business P.O.Box Address Added Successfully");
                    ClearPOBoxAddressInput();
                }
            }
        }

        private void BtnAddNumber_Click(object sender, EventArgs e)
        {
            if (viewModel.AddPhoneNumbers(mtxtTelephoneNumber.Text, mtxtCellphoneNumber.Text))
            {
                mtxtTelephoneNumber.ResetText();
                mtxtCellphoneNumber.ResetText();
                MainProgramCode.ShowInformation("Successfully added the customer phone number/s", "INFORMATION - Customer Phone Number/s Added Successfully");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancellation can cause any changes to be lost.", "REQUEST - Cancellation")) Close();
        }

        private void BtnViewAll_Click(object sender, EventArgs e)
        {
            if (viewModel.CurrentCustomer.CustomerCellphoneNumberList != null || viewModel.CurrentCustomer.CustomerTelephoneNumberList != null)
            {
                viewModel.Pass.CustomerToChange = viewModel.CurrentCustomer;
                viewModel.Pass.ChangeSpecificObject = !updatedCustomerInformationToolStripMenuItem.Enabled;

                Hide();
                navigation.ViewBusinessesPhoneNumbers();
                viewModel.UpdatePass(navigation.Pass);
                Show();

                viewModel.CurrentCustomer = viewModel.Pass.CustomerToChange;
                viewModel.Pass.CustomerToChange = null;
                viewModel.Pass.ChangeSpecificObject = false;
            }
            else MainProgramCode.ShowError("You need to first add at least one phone number before you can view the list of phone numbers.\nPlease add a phone number first", "ERROR - Can't View Non-Existing Customer Phone Numbers");
        }

        private void BtnViewAllPOBoxAddresses_Click(object sender, EventArgs e)
        {
            if (viewModel.CurrentCustomer.CustomerPOBoxAddress != null)
            {
                viewModel.Pass.CustomerToChange = viewModel.CurrentCustomer;
                viewModel.Pass.ChangeSpecificObject = !updatedCustomerInformationToolStripMenuItem.Enabled;

                Hide();
                navigation.ViewBusinessesPOBoxAddresses();
                viewModel.UpdatePass(navigation.Pass);
                Show();

                viewModel.CurrentCustomer = viewModel.Pass.CustomerToChange;
                viewModel.Pass.CustomerToChange = null;
                viewModel.Pass.ChangeSpecificObject = false;
            }
            else MainProgramCode.ShowError("You need to first add an P.O.Box address before you can view the list of addresses.\nPlease add an address first", "ERROR - Can't View Non-Existing Customer P.O.Box Addresses");
        }

        private void BtnViewEmailAddresses_Click(object sender, EventArgs e)
        {
            if (viewModel.CurrentCustomer.CustomerEmailList != null)
            {
                viewModel.Pass.CustomerToChange = viewModel.CurrentCustomer;
                viewModel.Pass.ChangeSpecificObject = !updatedCustomerInformationToolStripMenuItem.Enabled;

                Hide();
                navigation.ViewBusinessesEmailAddresses();
                viewModel.UpdatePass(navigation.Pass);
                Show();

                viewModel.CurrentCustomer = viewModel.Pass.CustomerToChange;
                viewModel.Pass.CustomerToChange = null;
                viewModel.Pass.ChangeSpecificObject = false;

            }
            else MainProgramCode.ShowError("You need to first add an Email address before you can view the list of addresses.\nPlease add an address first", "ERROR - Can't View Non-Existing Customer Email Addresses");
        }

        private void BtnViewAddresses_Click(object sender, EventArgs e)
        {
            if (viewModel.CurrentCustomer != null)
            {
                viewModel.Pass.CustomerToChange = viewModel.CurrentCustomer;
                viewModel.Pass.ChangeSpecificObject = !updatedCustomerInformationToolStripMenuItem.Enabled;

                Hide();
                navigation.ViewBusinessesAddresses();
                viewModel.UpdatePass(navigation.Pass);
                Show();

                viewModel.CurrentCustomer = viewModel.Pass.CustomerToChange;
                viewModel.Pass.CustomerToChange = null;
                viewModel.Pass.ChangeSpecificObject = false;
            }
            else MainProgramCode.ShowError("You need to first add an address before you can view the list of addresses.\nPlease add an address first", "ERROR - Can't View Non-Existing Customer Addresses");
        }

        private void UpdatedCustomerInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertToEdit();
            viewModel.Pass.ChangeSpecificObject = true;
            updatedCustomerInformationToolStripMenuItem.Enabled = false;
        }

        private void BtnAddEmail_Click(object sender, EventArgs e)
        {
            if (viewModel.AddEmailAddress(mtxtEmailAddress.Text))
            {
                MainProgramCode.ShowInformation("Successfully added the customer Email address", "INFORMATION - Customer Email Address Added Successfully");
                mtxtEmailAddress.ResetText();
            }
        }

        private void FrmAddCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            var p = viewModel.Pass;
            MainProgramCode.CloseApplication(true, ref p);
            viewModel.UpdatePass(p);
        }

        /** Form Specific Functions And Procedures: 
       *
       * Note: Not all Functions or Procedures below are used more than once
       *       Some of them are only to keep the above events readable 
       *       and clutter free.                                                          
       */

        private bool ValidCustomerAddress()
        {
            if (txtCustomerAddresssDescription.Text.Length < 2)
            {
                MainProgramCode.ShowError("The provided Business Address Description is invalid, please provide a valid description", "ERROR - Invalid Business Address Description");
                return (false);
            }

            if (txtAtt.Text.Length < 2)
            {
                MainProgramCode.ShowError("The provided Business Address Street Name is invalid, please provide a valid street name", "ERROR - Invalid Business Address Street Name");
                return (false);
            }

            if (txtWorkArea.Text.Length < 2)
            {
                MainProgramCode.ShowError("The provided Business Address Suburb is invalid, please provide a valid suburb", "ERROR - Invalid Business Address Suburb");
                return (false);
            }

            if (txtWorkPlace.Text.Length < 2)
            {
                MainProgramCode.ShowError("The provided Business Address City is invalid, please provide a valid city", "ERROR - Invalid Business Address City");
                return (false);
            }

            return true;
        }

        private bool ValidCustomerPOBoxAddress()
        {
            if (txtCustomerPODescription.Text.Length < 2)
            {
                MainProgramCode.ShowError("The provided Business P.O.Box Address Description is invalid, please provide a valid description", "ERROR - Invalid Business P.O.Box Address Description");
                return (false);
            }

            if (QuoteSwiftMainCode.ParseInt(mtxtPOBoxStreetNumber.Text) == 0)
            {
                MainProgramCode.ShowError("The provided Business' P.O.Box Address Street Number is invalid, please provide a valid street number", "ERROR - Invalid Business' P.O.Box Address Street Number");
                return (false);
            }

            if (txtPOBoxSuburb.Text.Length < 2)
            {
                MainProgramCode.ShowError("The provided Business' P.O.Box Address Suburb is invalid, please provide a valid suburb", "ERROR - Invalid Business' P.O.Box Address Suburb");
                return (false);
            }

            if (txtPOBoxCity.Text.Length < 2)
            {
                MainProgramCode.ShowError("The provided Business Address City is invalid, please provide a valid city", "ERROR - Invalid Business' P.O.Box Address City");
                return (false);
            }

            if (QuoteSwiftMainCode.ParseInt(mtxtPOBoxAreaCode.Text) == 0)
            {
                MainProgramCode.ShowError("The provided Business Address Area Code is invalid, please provide a valid area code", "ERROR - Invalid Business' P.O.Box Address Area Code");
                return (false);
            }

            return true;
        }

        private bool ValidBusiness()
        {

            if (mtxtVATNumber.Text.Length < 7)
            {
                MainProgramCode.ShowError("The provided VAT number is invalid, please provide a valid VAT number.", "ERROR - Invalid Business VAT Number");
                return false;
            }

            if (mtxtRegistrationNumber.Text.Length < 7)
            {
                MainProgramCode.ShowError("The provided registration number is invalid, please provide a valid registration number.", "ERROR - Invalid Business Registration Number");
                return false;
            }

            if (mtxtVendorNumber.Text.Length < 5)
            {
                MainProgramCode.ShowError("The provided vendor number is invalid, please provide a valid vendor number.", "ERROR - Invalid Business Registration Number");
                return false;
            }

            if (viewModel.CurrentCustomer.CustomerDeliveryAddressList == null)
            {
                MainProgramCode.ShowError("Please add a valid customer delivery address under the 'Customer Address' section.", "ERROR - Current Customer Invalid");
                return false;
            }

            if (viewModel.CurrentCustomer.CustomerPOBoxAddress == null)
            {
                MainProgramCode.ShowError("Please add a valid customer P.O.Box address under the 'Customer P.O.Box Address' section.", "ERROR - Current Customer Invalid");
                return false;
            }

            if (viewModel.CurrentCustomer.CustomerCellphoneNumberList == null && viewModel.CurrentCustomer.CustomerTelephoneNumberList == null)
            {
                MainProgramCode.ShowError("Please add a valid phone number under the 'Phone Related' section.", "ERROR - Current Customer Invalid");
                return false;
            }

            if (viewModel.CurrentCustomer.CustomerEmailList == null)
            {
                MainProgramCode.ShowError("Please add a valid customer email address under the 'Email Related' section.", "ERROR - Current Customer Invalid");
                return false;
            }

            return true;
        }

        private void DisableMainComponents()
        {
            gbxCustomerInformation.Enabled = false;
            gbxCustomerAddress.Enabled = false;
            gbxPhoneRelated.Enabled = false;
            gbxEmailRelated.Enabled = false;
            gbxPOBoxAddress.Enabled = false;
            btnAddCustomer.Enabled = false;
        }

        private void ClearCustomerAddressInput()
        {
            txtCustomerAddresssDescription.ResetText();
            txtAtt.ResetText();
            txtWorkArea.ResetText();
            txtWorkPlace.ResetText();
        }

        private void ClearPOBoxAddressInput()
        {
            txtCustomerPODescription.ResetText();
            mtxtPOBoxStreetNumber.ResetText();
            txtPOBoxSuburb.ResetText();
            txtPOBoxCity.ResetText();
            mtxtPOBoxAreaCode.ResetText();
        }

        private void ResetScreenInput()
        {
            txtCustomerCompanyName.ResetText();
            cbBusinessSelection.ResetText();
            mtxtVATNumber.ResetText();
            mtxtRegistrationNumber.ResetText();
            ClearCustomerAddressInput();
            ClearPOBoxAddressInput();
            mtxtEmailAddress.ResetText();
            mtxtCellphoneNumber.ResetText();
            mtxtTelephoneNumber.ResetText();
            mtxtVendorNumber.ResetText();
        }

        private void LoadInformation()
        {
            if (viewModel.CurrentCustomer != null)
            {
                Container = viewModel.Pass.BusinessToChange;
                viewModel.Pass.BusinessToChange = null;

                txtCustomerCompanyName.Text = viewModel.CurrentCustomer.CustomerCompanyName;
                cbBusinessSelection.Text = Container.BusinessName;
                mtxtVATNumber.Text = viewModel.CurrentCustomer.CustomerLegalDetails.VatNumber;
                mtxtRegistrationNumber.Text = viewModel.CurrentCustomer.CustomerLegalDetails.RegistrationNumber;
                mtxtVendorNumber.Text = viewModel.CurrentCustomer.VendorNumber;
            }
        }

        private void ConvertToViewOnly()
        {
            QuoteSwiftMainCode.ReadOnlyComponents(gbxCustomerInformation.Controls);
            QuoteSwiftMainCode.ReadOnlyComponents(gbxCustomerAddress.Controls);
            QuoteSwiftMainCode.ReadOnlyComponents(gbxEmailRelated.Controls);
            QuoteSwiftMainCode.ReadOnlyComponents(gbxLegalInformation.Controls);
            QuoteSwiftMainCode.ReadOnlyComponents(gbxPhoneRelated.Controls);
            QuoteSwiftMainCode.ReadOnlyComponents(gbxPOBoxAddress.Controls);

            btnViewAddresses.Enabled = true;
            btnViewAll.Enabled = true;
            btnViewAllPOBoxAddresses.Enabled = true;
            btnViewEmailAddresses.Enabled = true;

            btnAddCustomer.Visible = false;
            Text = Text.Replace("Add Customer", "Viewing " + viewModel.CurrentCustomer.CustomerName);
            updatedCustomerInformationToolStripMenuItem.Enabled = true;
        }

        private void ConvertToEdit()
        {
            QuoteSwiftMainCode.ReadWriteComponents(gbxCustomerInformation.Controls);
            QuoteSwiftMainCode.ReadWriteComponents(gbxCustomerAddress.Controls);
            QuoteSwiftMainCode.ReadWriteComponents(gbxEmailRelated.Controls);
            QuoteSwiftMainCode.ReadWriteComponents(gbxLegalInformation.Controls);
            QuoteSwiftMainCode.ReadWriteComponents(gbxPhoneRelated.Controls);
            QuoteSwiftMainCode.ReadWriteComponents(gbxPOBoxAddress.Controls);

            btnAddCustomer.Visible = true;
            btnAddCustomer.Text = "Update Customer";
            if (viewModel.Pass != null && viewModel.Pass.BusinessToChange != null)
                Text = Text.Replace("Viewing " + viewModel.Pass.BusinessToChange.BusinessName, "Updating " + viewModel.Pass.BusinessToChange.BusinessName);
            if (viewModel.Pass != null && viewModel.Pass.CustomerToChange != null)
                Text = Text.Replace("Viewing " + viewModel.Pass.CustomerToChange.CustomerName, "Updating " + viewModel.Pass.CustomerToChange.CustomerName);
            updatedCustomerInformationToolStripMenuItem.Enabled = false;
        }

        private Business GetSelectedBusiness()
        {
            if (cbBusinessSelection.Text.Length > 0 && viewModel.Pass.BusinessLookup.TryGetValue(cbBusinessSelection.Text, out Business business))
            {
                return business;
            }

            return null;
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        /**********************************************************************************/
    }
}
