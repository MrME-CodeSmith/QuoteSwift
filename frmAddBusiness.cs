using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmAddBusiness : Form
    {

        readonly AddBusinessViewModel viewModel;
        readonly INavigationService navigation;
        readonly IMessageService messageService;
        readonly ISerializationService serializationService;

        public FrmAddBusiness(AddBusinessViewModel viewModel, INavigationService navigation = null, IMessageService messageService = null, ISerializationService serializationService = null)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.navigation = navigation;
            this.serializationService = serializationService;
            this.messageService = messageService;

            DataBindings.Add("Text", viewModel, nameof(AddBusinessViewModel.FormTitle));
            viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
            {
                navigation?.SaveAllData();
                Application.Exit();
            }
        }


        void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AddBusinessViewModel.ChangeSpecificObject) ||
                e.PropertyName == nameof(AddBusinessViewModel.BusinessToChange))
            {
                btnAddBusiness.Visible = viewModel.ChangeSpecificObject || viewModel.BusinessToChange == null;
                btnAddBusiness.Text = viewModel.ChangeSpecificObject ? "Update Business" : "Add Business";
                updateBusinessInformationToolStripMenuItem.Enabled = !viewModel.ChangeSpecificObject && viewModel.BusinessToChange != null;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to cancel the current action?\nCancellation can cause any changes to be lost.", "REQUEST - Cancellation")) Close();
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
        }

        private void FrmAddBusiness_FormClosing(object sender, FormClosingEventArgs e)
        {
            navigation?.SaveAllData();
        }

        private void UpdateBusinessInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewModel.ChangeSpecificObject = true;
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

            txtBusinessAddresssDescription.DataBindings.Add("Text", viewModel, nameof(AddBusinessViewModel.AddressDescription), false, DataSourceUpdateMode.OnPropertyChanged);
            mtxtStreetnumber.DataBindings.Add("Text", viewModel, nameof(AddBusinessViewModel.StreetNumber), false, DataSourceUpdateMode.OnPropertyChanged);
            txtStreetName.DataBindings.Add("Text", viewModel, nameof(AddBusinessViewModel.StreetName), false, DataSourceUpdateMode.OnPropertyChanged);
            txtSuburb.DataBindings.Add("Text", viewModel, nameof(AddBusinessViewModel.Suburb), false, DataSourceUpdateMode.OnPropertyChanged);
            txtCity.DataBindings.Add("Text", viewModel, nameof(AddBusinessViewModel.City), false, DataSourceUpdateMode.OnPropertyChanged);
            mtxtAreaCode.DataBindings.Add("Text", viewModel, nameof(AddBusinessViewModel.AreaCode), false, DataSourceUpdateMode.OnPropertyChanged);

            txtBusinessPODescription.DataBindings.Add("Text", viewModel, nameof(AddBusinessViewModel.PODescription), false, DataSourceUpdateMode.OnPropertyChanged);
            mtxtPOBoxStreetNumber.DataBindings.Add("Text", viewModel, nameof(AddBusinessViewModel.POStreetNumber), false, DataSourceUpdateMode.OnPropertyChanged);
            txtPOBoxSuburb.DataBindings.Add("Text", viewModel, nameof(AddBusinessViewModel.POSuburb), false, DataSourceUpdateMode.OnPropertyChanged);
            txtPOBoxCity.DataBindings.Add("Text", viewModel, nameof(AddBusinessViewModel.POCity), false, DataSourceUpdateMode.OnPropertyChanged);
            mtxtPOBoxAreaCode.DataBindings.Add("Text", viewModel, nameof(AddBusinessViewModel.POAreaCode), false, DataSourceUpdateMode.OnPropertyChanged);

            mtxtTelephoneNumber.DataBindings.Add("Text", viewModel, nameof(AddBusinessViewModel.TelephoneInput), false, DataSourceUpdateMode.OnPropertyChanged);
            mtxtCellphoneNumber.DataBindings.Add("Text", viewModel, nameof(AddBusinessViewModel.CellphoneInput), false, DataSourceUpdateMode.OnPropertyChanged);

            mtxtEmail.DataBindings.Add("Text", viewModel, nameof(AddBusinessViewModel.EmailInput), false, DataSourceUpdateMode.OnPropertyChanged);

            gbxBusinessAddress.DataBindings.Add("Enabled", viewModel, nameof(AddBusinessViewModel.IsEditing));
            gbxBusinessInformation.DataBindings.Add("Enabled", viewModel, nameof(AddBusinessViewModel.IsEditing));
            gbxEmailRelated.DataBindings.Add("Enabled", viewModel, nameof(AddBusinessViewModel.IsEditing));
            gbxLegalInformation.DataBindings.Add("Enabled", viewModel, nameof(AddBusinessViewModel.IsEditing));
            gbxPhoneRelated.DataBindings.Add("Enabled", viewModel, nameof(AddBusinessViewModel.IsEditing));
            gbxPOBoxAddress.DataBindings.Add("Enabled", viewModel, nameof(AddBusinessViewModel.IsEditing));

            CommandBindings.Bind(btnAddBusiness, viewModel.SaveBusinessCommand);
            CommandBindings.Bind(btnAddAddress, viewModel.AddAddressCommand);
            CommandBindings.Bind(btnAddPOBoxAddress, viewModel.AddPOBoxAddressCommand);
            CommandBindings.Bind(btnAddNumber, viewModel.AddPhoneNumberCommand);
            CommandBindings.Bind(btnAddBusinessEmail, viewModel.AddEmailCommand);
        }

        /**********************************************************************************/
    }
}
