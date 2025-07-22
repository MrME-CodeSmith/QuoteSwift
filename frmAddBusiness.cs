using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmAddBusiness : BaseForm
    {

        readonly AddBusinessViewModel viewModel;
        readonly INavigationService navigation;
        readonly IMessageService messageService;
        readonly ISerializationService serializationService;

        public FrmAddBusiness(AddBusinessViewModel viewModel, INavigationService navigation = null, IMessageService messageService = null, ISerializationService serializationService = null)
            : base(messageService, navigation)
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
            if (e.PropertyName == nameof(AddBusinessViewModel.IsViewing))
            {
                updateBusinessInformationToolStripMenuItem.Enabled = viewModel.IsViewing;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to cancel the current action?\nCancellation can cause any changes to be lost.", "REQUEST - Cancellation")) Close();
        }

        private void BtnViewEmailAddresses_Click(object sender, EventArgs e)
        {
            viewModel.ViewEmailAddressesCommand.Execute(null);
        }

        private void BtnViewAddresses_Click(object sender, EventArgs e)
        {
            viewModel.ViewAddressesCommand.Execute(null);
        }

        private void BtnViewAllPOBoxAddresses_Click(object sender, EventArgs e)
        {
            viewModel.ViewPOBoxAddressesCommand.Execute(null);
        }

        private void BtnViewAll_Click(object sender, EventArgs e)
        {
            viewModel.ViewPhoneNumbersCommand.Execute(null);
        }

        private async void FrmAddBusiness_Load(object sender, EventArgs e)
        {
            await viewModel.LoadDataAsync();
            if (!viewModel.InitializeCurrentBusiness())
            {
                messageService.ShowError("The form was activated without the correct parameters to have an achievable goal.\nThe Form's input parameters will be disabled to avoid possible data corruption.", "ERROR - Undefined Form Use Called");
                DisableMainComponents();
            }

            viewModel.EnsureLegalDetails();
            SetupBindings();
            updateBusinessInformationToolStripMenuItem.Enabled = viewModel.IsViewing;
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

            btnAddBusiness.DataBindings.Add("Visible", viewModel, nameof(AddBusinessViewModel.ShowSaveButton));
            btnAddBusiness.DataBindings.Add("Text", viewModel, nameof(AddBusinessViewModel.SaveButtonText));

            CommandBindings.Bind(btnAddBusiness, viewModel.SaveBusinessCommand);
            CommandBindings.Bind(btnAddAddress, viewModel.AddAddressCommand);
            CommandBindings.Bind(btnAddPOBoxAddress, viewModel.AddPOBoxAddressCommand);
            CommandBindings.Bind(btnAddNumber, viewModel.AddPhoneNumberCommand);
            CommandBindings.Bind(btnAddBusinessEmail, viewModel.AddEmailCommand);
            CommandBindings.Bind(btnViewEmailAddresses, viewModel.ViewEmailAddressesCommand);
            CommandBindings.Bind(btnViewAddresses, viewModel.ViewAddressesCommand);
            CommandBindings.Bind(btnViewAllPOBoxAddresses, viewModel.ViewPOBoxAddressesCommand);
            CommandBindings.Bind(btnViewAll, viewModel.ViewPhoneNumbersCommand);
        }

        /**********************************************************************************/
    }
}
