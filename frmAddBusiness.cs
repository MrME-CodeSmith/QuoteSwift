using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmAddBusiness : Form
    {

        readonly AddBusinessViewModel viewModel;
        readonly INavigationService navigation;

        Pass passed;

        public void SetPass(Pass value)
        {
            passed = value;
            viewModel.UpdateData(value.PassBusinessList, value.BusinessToChange, value.ChangeSpecificObject);
        }

        public FrmAddBusiness(AddBusinessViewModel viewModel, INavigationService navigation = null)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.navigation = navigation;
        }

        public ref Pass Passed { get => ref passed; }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                MainProgramCode.CloseApplication(true, ref passed);
        }

        private void BtnAddBusiness_Click(object sender, EventArgs e)
        {
            if (!passed.ChangeSpecificObject)
            {
                if (viewModel.AddBusiness())
                {
                    MainProgramCode.ShowInformation(viewModel.CurrentBusiness.BusinessName + " has been added.", "INFORMATION - Business Successfully Added");
                    viewModel.CurrentBusiness = new Business { BusinessLegalDetails = new Legal("", "") };
                    SetupBindings();
                    ResetScreenInput();
                }
            }
            else
            {
                if (viewModel.UpdateBusiness())
                {
                    MainProgramCode.ShowInformation(viewModel.CurrentBusiness.BusinessName + " has been successfully updated.", "INFORMATION - Business Successfully Updated");
                    ConvertToViewOnly();
                }
            }
        }

        private void BtnAddPOBoxAddress_Click(object sender, EventArgs e)
        {
            Address address = new Address(txtBusinessPODescription.Text, QuoteSwiftMainCode.ParseInt(mtxtPOBoxStreetNumber.Text),
                                          "", txtPOBoxSuburb.Text, txtPOBoxCity.Text, QuoteSwiftMainCode.ParseInt(mtxtPOBoxAreaCode.Text));
            if (viewModel.AddPOBoxAddress(address))
            {
                MainProgramCode.ShowInformation("Successfully added the business P.O.Box address", "INFORMATION - Business P.O.Box Address Added Successfully");
                ClearPOBoxAddressInput();
            }
        }

        private void BtnAddAddress_Click(object sender, EventArgs e)
        {
            Address address = new Address(txtBusinessAddresssDescription.Text, QuoteSwiftMainCode.ParseInt(mtxtStreetnumber.Text),
                                          txtStreetName.Text, txtSuburb.Text, txtCity.Text, QuoteSwiftMainCode.ParseInt(mtxtAreaCode.Text));
            if (viewModel.AddAddress(address))
            {
                MainProgramCode.ShowInformation("Successfully added the business address", "INFORMATION - Business Address Added Successfully");
                ClearBusinessAddressInput();
            }
        }

        private void BtnAddNumber_Click(object sender, EventArgs e)
        {
            if (viewModel.AddPhoneNumber(mtxtTelephoneNumber.Text, mtxtCellphoneNumber.Text))
            {
                MainProgramCode.ShowInformation("Successfully added the business phone number/s", "INFORMATION - Business Phone Number/s Added Successfully");
                mtxtTelephoneNumber.ResetText();
                mtxtCellphoneNumber.ResetText();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancellation can cause any changes to be lost.", "REQUEST - Cancellation")) Close();
        }

        private void BtnAddBusinessEmail_Click(object sender, EventArgs e)
        {
            if (viewModel.AddEmailAddress(mtxtEmail.Text))
            {
                MainProgramCode.ShowInformation("Successfully added the business Email address", "INFORMATION - Business Email Address Added Successfully");
                mtxtEmail.ResetText();
            }
        }

        private void BtnViewEmailAddresses_Click(object sender, EventArgs e)
        {
            if (viewModel.CurrentBusiness.BusinessEmailAddressList != null)
            {
                passed.BusinessToChange = viewModel.CurrentBusiness;
                passed.ChangeSpecificObject = !updateBusinessInformationToolStripMenuItem.Enabled;

                Hide();
                passed = navigation.ViewBusinessesEmailAddresses(passed);
                Show();
                Show();

                viewModel.CurrentBusiness = passed.BusinessToChange;
                passed.BusinessToChange = null;
                passed.ChangeSpecificObject = false;

            }
            else MainProgramCode.ShowError("You need to first add an Email address before you can view the list of addresses.\nPlease add an address first", "ERROR - Can't View Non-Existing Business Email Addresses");
        }

        private void BtnViewAddresses_Click(object sender, EventArgs e)
        {
            if (viewModel.CurrentBusiness.BusinessAddressList != null)
            {
                passed.BusinessToChange = viewModel.CurrentBusiness;
                passed.ChangeSpecificObject = !updateBusinessInformationToolStripMenuItem.Enabled;

                Hide();
                passed = navigation.ViewBusinessesAddresses(passed);
                Show();
                Show();

                viewModel.CurrentBusiness = passed.BusinessToChange;
                passed.BusinessToChange = null;
                passed.ChangeSpecificObject = false;
            }
            else MainProgramCode.ShowError("You need to first add an address before you can view the list of addresses.\nPlease add an address first", "ERROR - Can't View Non-Existing Business Addresses");
        }

        private void BtnViewAllPOBoxAddresses_Click(object sender, EventArgs e)
        {
            if (viewModel.CurrentBusiness.BusinessPOBoxAddressList != null)
            {
                passed.BusinessToChange = viewModel.CurrentBusiness;
                passed.ChangeSpecificObject = !updateBusinessInformationToolStripMenuItem.Enabled;

                Hide();
                passed = navigation.ViewBusinessesPOBoxAddresses(passed);
                Show();
                Show();

                viewModel.CurrentBusiness = passed.BusinessToChange;
                passed.BusinessToChange = null;
                passed.ChangeSpecificObject = false;
            }
            else MainProgramCode.ShowError("You need to first add an P.O.Box address before you can view the list of addresses.\nPlease add an address first", "ERROR - Can't View Non-Existing Business P.O.Box Addresses");
        }

        private void BtnViewAll_Click(object sender, EventArgs e)
        {
            if (viewModel.CurrentBusiness.BusinessTelephoneNumberList != null || viewModel.CurrentBusiness.BusinessCellphoneNumberList != null)
            {
                passed.BusinessToChange = viewModel.CurrentBusiness;
                passed.ChangeSpecificObject = !updateBusinessInformationToolStripMenuItem.Enabled;

                Hide();
                passed = navigation.ViewBusinessesPhoneNumbers(passed);
                Show();
                Show();

                viewModel.CurrentBusiness = passed.BusinessToChange;
                passed.BusinessToChange = null;
                passed.ChangeSpecificObject = false;
            }
            else MainProgramCode.ShowError("You need to first add at least one phone number before you can view the list of phone numbers.\nPlease add a phone number first", "ERROR - Can't View Non-Existing Business Phone Numbers");
        }

        private void FrmAddBusiness_Load(object sender, EventArgs e)
        {
            viewModel.LoadData();
            if (passed.BusinessToChange != null && passed.ChangeSpecificObject) // Change Existing Business Info
            {
                viewModel.CurrentBusiness = passed.BusinessToChange;
            }
            else if (passed.BusinessToChange != null && !passed.ChangeSpecificObject) // View Existing Business Info
            {
                viewModel.CurrentBusiness = passed.BusinessToChange;
                ConvertToViewOnly();
            }
            else if (passed.BusinessToChange == null && !passed.ChangeSpecificObject) // Add New Business Info
            {
                viewModel.CurrentBusiness = new Business();
            }
            else // Undefined Use - Show ERROR
            {
                MainProgramCode.ShowError("The form was activated without the correct parameters to have an achievable goal.\nThe Form's input parameters will be disabled to avoid possible data corruption.", "ERROR - Undefined Form Use Called");
                DisableMainComponents();
            }

            if (viewModel.CurrentBusiness.BusinessLegalDetails == null)
                viewModel.CurrentBusiness.BusinessLegalDetails = new Legal("", "");
            SetupBindings();
        }

        private void FrmAddBusiness_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainProgramCode.CloseApplication(true, ref passed);
        }

        private void UpdateBusinessInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertToEdit();
            passed.ChangeSpecificObject = true;
        private void ConvertToViewOnly()
        {
            QuoteSwiftMainCode.ReadOnlyComponents(gbxBusinessAddress.Controls);
            QuoteSwiftMainCode.ReadOnlyComponents(gbxBusinessInformation.Controls);
            QuoteSwiftMainCode.ReadOnlyComponents(gbxEmailRelated.Controls);
            QuoteSwiftMainCode.ReadOnlyComponents(gbxLegalInformation.Controls);
            QuoteSwiftMainCode.ReadOnlyComponents(gbxPhoneRelated.Controls);
            QuoteSwiftMainCode.ReadOnlyComponents(gbxPOBoxAddress.Controls);

            btnViewAddresses.Enabled = true;
            btnViewAll.Enabled = true;
            btnViewAllPOBoxAddresses.Enabled = true;
            btnViewEmailAddresses.Enabled = true;

            btnAddBusiness.Visible = false;
            Text = Text.Replace("Add Business", "Viewing " + passed.BusinessToChange.BusinessName);
            updateBusinessInformationToolStripMenuItem.Enabled = true;
        }

        private void ConvertToEdit()
        {
            QuoteSwiftMainCode.ReadWriteComponents(gbxBusinessAddress.Controls);
            QuoteSwiftMainCode.ReadWriteComponents(gbxBusinessInformation.Controls);
            QuoteSwiftMainCode.ReadWriteComponents(gbxEmailRelated.Controls);
            QuoteSwiftMainCode.ReadWriteComponents(gbxLegalInformation.Controls);
            QuoteSwiftMainCode.ReadWriteComponents(gbxPhoneRelated.Controls);
            QuoteSwiftMainCode.ReadWriteComponents(gbxPOBoxAddress.Controls);

            btnAddBusiness.Visible = true;
            btnAddBusiness.Text = "Update Business";
            Text = Text.Replace("Viewing " + viewModel.CurrentBusiness.BusinessName, "Updating " + viewModel.CurrentBusiness.BusinessName);
            updateBusinessInformationToolStripMenuItem.Enabled = false;
        }

        private void SetupBindings()
        {
            txtBusinessName.DataBindings.Clear();
            txtBusinessName.DataBindings.Add("Text", viewModel.CurrentBusiness, nameof(Business.BusinessName), false, DataSourceUpdateMode.OnPropertyChanged);

            rtxtExtraInformation.DataBindings.Clear();
            rtxtExtraInformation.DataBindings.Add("Text", viewModel.CurrentBusiness, nameof(Business.BusinessExtraInformation), false, DataSourceUpdateMode.OnPropertyChanged);

            mtxtVATNumber.DataBindings.Clear();
            mtxtVATNumber.DataBindings.Add("Text", viewModel.CurrentBusiness, "BusinessLegalDetails.VatNumber", false, DataSourceUpdateMode.OnPropertyChanged);

            mtxtRegistrationNumber.DataBindings.Clear();
            mtxtRegistrationNumber.DataBindings.Add("Text", viewModel.CurrentBusiness, "BusinessLegalDetails.RegistrationNumber", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        /**********************************************************************************/
    }
}
