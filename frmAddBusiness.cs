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
        readonly ApplicationData appData;
        readonly IMessageService messageService;
        readonly ISerializationService serializationService;

        public FrmAddBusiness(AddBusinessViewModel viewModel, INavigationService navigation = null, ApplicationData appData = null, IMessageService messageService = null, ISerializationService serializationService = null)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.navigation = navigation;
            this.appData = appData;
            this.serializationService = serializationService;
            this.messageService = messageService;

            DataBindings.Add("Text", viewModel, nameof(AddBusinessViewModel.FormTitle));
            viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                serializationService.CloseApplication(true,
                    appData?.BusinessList,
                    appData?.PumpList,
                    appData?.PartList,
                    appData?.QuoteMap);
        }

        private void BtnAddBusiness_Click(object sender, EventArgs e)
        {
            if (!viewModel.ChangeSpecificObject)
            {
                viewModel.AddBusinessCommand.Execute(null);
                if (viewModel.LastOperationSuccessful)
                {
                    messageService.ShowInformation(viewModel.CurrentBusiness.BusinessName + " has been added.", "INFORMATION - Business Successfully Added");
                    viewModel.ClearCurrentBusiness();
                    SetupBindings();
                    ResetScreenInput();
                }
                else if (viewModel.LastResult?.Message != null)
                {
                    messageService.ShowError(viewModel.LastResult.Message, viewModel.LastResult.Caption);
                }
            }
            else
            {
                viewModel.UpdateBusinessCommand.Execute(null);
                if (viewModel.LastOperationSuccessful)
                {
                    messageService.ShowInformation(viewModel.CurrentBusiness.BusinessName + " has been successfully updated.", "INFORMATION - Business Successfully Updated");
                    viewModel.ChangeSpecificObject = false;
                }
                else if (viewModel.LastResult?.Message != null)
                {
                    messageService.ShowError(viewModel.LastResult.Message, viewModel.LastResult.Caption);
                }
            }
        }

        void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AddBusinessViewModel.IsEditing) ||
                e.PropertyName == nameof(AddBusinessViewModel.IsReadOnly) ||
                e.PropertyName == nameof(AddBusinessViewModel.ChangeSpecificObject))
            {
                ApplyControlState();
            }
        }

        private void BtnAddPOBoxAddress_Click(object sender, EventArgs e)
        {
            var address = viewModel.BuildPOBoxAddress(txtBusinessPODescription.Text,
                                                      mtxtPOBoxStreetNumber.Text,
                                                      txtPOBoxSuburb.Text,
                                                      txtPOBoxCity.Text,
                                                      mtxtPOBoxAreaCode.Text);

            if (address != null)
            {
                var result = viewModel.AddPOBoxAddress(address);
                if (result.Success)
                {
                    messageService.ShowInformation("Successfully added the business P.O.Box address", "INFORMATION - Business P.O.Box Address Added Successfully");
                    ClearPOBoxAddressInput();
                }
                else if (result.Message != null)
                    messageService.ShowError(result.Message, result.Caption);
            }
            else if (viewModel.LastResult.Message != null)
            {
                messageService.ShowError(viewModel.LastResult.Message, viewModel.LastResult.Caption);
            }
        }

        private void BtnAddAddress_Click(object sender, EventArgs e)
        {
            var address = viewModel.BuildAddress(txtBusinessAddresssDescription.Text,
                                                mtxtStreetnumber.Text,
                                                txtStreetName.Text,
                                                txtSuburb.Text,
                                                txtCity.Text,
                                                mtxtAreaCode.Text);

            if (address != null)
            {
                result = viewModel.AddAddress(address);
                if (result.Success)
                {
                    messageService.ShowInformation("Successfully added the business address", "INFORMATION - Business Address Added Successfully");
                    ClearBusinessAddressInput();
                }
                else if (result.Message != null)
                    messageService.ShowError(result.Message, result.Caption);
            }
            else if (viewModel.LastResult.Message != null)
            {
                messageService.ShowError(viewModel.LastResult.Message, viewModel.LastResult.Caption);
            }
        }

        private void BtnAddNumber_Click(object sender, EventArgs e)
        {
            result = viewModel.AddPhoneNumber(mtxtTelephoneNumber.Text, mtxtCellphoneNumber.Text);
            if (result.Success)
            {
                messageService.ShowInformation("Successfully added the business phone number/s", "INFORMATION - Business Phone Number/s Added Successfully");
                mtxtTelephoneNumber.ResetText();
                mtxtCellphoneNumber.ResetText();
            }
            else if (result.Message != null)
                messageService.ShowError(result.Message, result.Caption);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to cancel the current action?\nCancellation can cause any changes to be lost.", "REQUEST - Cancellation")) Close();
        }

        private void BtnAddBusinessEmail_Click(object sender, EventArgs e)
        {
            result = viewModel.AddEmailAddress(mtxtEmail.Text);
            if (result.Success)
            {
                messageService.ShowInformation("Successfully added the business Email address", "INFORMATION - Business Email Address Added Successfully");
                mtxtEmail.ResetText();
            }
            else if (result.Message != null)
                messageService.ShowError(result.Message, result.Caption);
        }

        private void BtnViewEmailAddresses_Click(object sender, EventArgs e)
        {
            if (viewModel.CurrentBusiness.BusinessEmailAddressList != null)
            {
                Hide();
                navigation.ViewBusinessesEmailAddresses(viewModel.CurrentBusiness, null);
                Show();

            }
            else messageService.ShowError("You need to first add an Email address before you can view the list of addresses.\nPlease add an address first", "ERROR - Can't View Non-Existing Business Email Addresses");
        }

        private void BtnViewAddresses_Click(object sender, EventArgs e)
        {
            if (viewModel.CurrentBusiness.BusinessAddressList != null)
            {
                Hide();
                navigation.ViewBusinessesAddresses(viewModel.CurrentBusiness, null);
                Show();
            }
            else messageService.ShowError("You need to first add an address before you can view the list of addresses.\nPlease add an address first", "ERROR - Can't View Non-Existing Business Addresses");
        }

        private void BtnViewAllPOBoxAddresses_Click(object sender, EventArgs e)
        {
            if (viewModel.CurrentBusiness.BusinessPOBoxAddressList != null)
            {
                Hide();
                navigation.ViewBusinessesPOBoxAddresses(viewModel.CurrentBusiness, null);
                Show();
            }
            else messageService.ShowError("You need to first add an P.O.Box address before you can view the list of addresses.\nPlease add an address first", "ERROR - Can't View Non-Existing Business P.O.Box Addresses");
        }

        private void BtnViewAll_Click(object sender, EventArgs e)
        {
            if (viewModel.CurrentBusiness.BusinessTelephoneNumberList != null || viewModel.CurrentBusiness.BusinessCellphoneNumberList != null)
            {
                Hide();
                navigation.ViewBusinessesPhoneNumbers(viewModel.CurrentBusiness, null);
                Show();
            }
            else messageService.ShowError("You need to first add at least one phone number before you can view the list of phone numbers.\nPlease add a phone number first", "ERROR - Can't View Non-Existing Business Phone Numbers");
        }

        private void FrmAddBusiness_Load(object sender, EventArgs e)
        {
            viewModel.LoadData();
            if (viewModel.BusinessToChange != null && viewModel.ChangeSpecificObject) // Change Existing Business Info
            {
                viewModel.CurrentBusiness = viewModel.BusinessToChange;
            }
            else if (viewModel.BusinessToChange != null && !viewModel.ChangeSpecificObject) // View Existing Business Info
            {
                viewModel.CurrentBusiness = viewModel.BusinessToChange;
            }
            else if (viewModel.BusinessToChange == null && !viewModel.ChangeSpecificObject) // Add New Business Info
            {
                viewModel.ClearCurrentBusiness();
            }
            else // Undefined Use - Show ERROR
            {
                messageService.ShowError("The form was activated without the correct parameters to have an achievable goal.\nThe Form's input parameters will be disabled to avoid possible data corruption.", "ERROR - Undefined Form Use Called");
                DisableMainComponents();
            }

            if (viewModel.CurrentBusiness.BusinessLegalDetails == null)
                viewModel.CurrentBusiness.BusinessLegalDetails = new Legal("", "");
            SetupBindings();
            ApplyControlState();
        }

        private void FrmAddBusiness_FormClosing(object sender, FormClosingEventArgs e)
        {
            serializationService.CloseApplication(true,
                appData?.BusinessList,
                appData?.PumpList,
                appData?.PartList,
                appData?.QuoteMap);

        }

        private void UpdateBusinessInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewModel.ChangeSpecificObject = true;
        }



        void ApplyControlState()
        {
            bool ro = viewModel.IsReadOnly;
            ControlStateHelper.ApplyReadOnly(gbxBusinessAddress.Controls, ro);
            ControlStateHelper.ApplyReadOnly(gbxBusinessInformation.Controls, ro);
            ControlStateHelper.ApplyReadOnly(gbxEmailRelated.Controls, ro);
            ControlStateHelper.ApplyReadOnly(gbxLegalInformation.Controls, ro);
            ControlStateHelper.ApplyReadOnly(gbxPhoneRelated.Controls, ro);
            ControlStateHelper.ApplyReadOnly(gbxPOBoxAddress.Controls, ro);

            btnAddBusiness.Visible = viewModel.ChangeSpecificObject || viewModel.BusinessToChange == null;
            btnAddBusiness.Text = viewModel.ChangeSpecificObject ? "Update Business" : "Add Business";
            updateBusinessInformationToolStripMenuItem.Enabled = !viewModel.ChangeSpecificObject && viewModel.BusinessToChange != null;
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

            ApplyControlState();
        }

        /**********************************************************************************/
    }
}
