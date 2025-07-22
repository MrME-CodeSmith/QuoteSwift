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
            viewModel.CloseAction = Close;

            DataBindings.Add("Text", viewModel, nameof(AddBusinessViewModel.FormTitle));
            viewModel.PropertyChanged += ViewModel_PropertyChanged;
            BindIsBusy(viewModel);
        }




        void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AddBusinessViewModel.IsViewing))
            {
                updateBusinessInformationToolStripMenuItem.Enabled = viewModel.IsViewing;
            }
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
            BindingHelpers.BindText(txtBusinessName, viewModel.CurrentBusiness, nameof(Business.BusinessName));
            BindingHelpers.BindText(rtxtExtraInformation, viewModel.CurrentBusiness, nameof(Business.BusinessExtraInformation));
            BindingHelpers.BindText(mtxtVATNumber, viewModel.CurrentBusiness, "BusinessLegalDetails.VatNumber");
            BindingHelpers.BindText(mtxtRegistrationNumber, viewModel.CurrentBusiness, "BusinessLegalDetails.RegistrationNumber");

            BindingHelpers.BindText(txtBusinessAddresssDescription, viewModel, nameof(AddBusinessViewModel.AddressDescription));
            BindingHelpers.BindText(mtxtStreetnumber, viewModel, nameof(AddBusinessViewModel.StreetNumber));
            BindingHelpers.BindText(txtStreetName, viewModel, nameof(AddBusinessViewModel.StreetName));
            BindingHelpers.BindText(txtSuburb, viewModel, nameof(AddBusinessViewModel.Suburb));
            BindingHelpers.BindText(txtCity, viewModel, nameof(AddBusinessViewModel.City));
            BindingHelpers.BindText(mtxtAreaCode, viewModel, nameof(AddBusinessViewModel.AreaCode));

            BindingHelpers.BindText(txtBusinessPODescription, viewModel, nameof(AddBusinessViewModel.PODescription));
            BindingHelpers.BindText(mtxtPOBoxStreetNumber, viewModel, nameof(AddBusinessViewModel.POStreetNumber));
            BindingHelpers.BindText(txtPOBoxSuburb, viewModel, nameof(AddBusinessViewModel.POSuburb));
            BindingHelpers.BindText(txtPOBoxCity, viewModel, nameof(AddBusinessViewModel.POCity));
            BindingHelpers.BindText(mtxtPOBoxAreaCode, viewModel, nameof(AddBusinessViewModel.POAreaCode));

            BindingHelpers.BindText(mtxtTelephoneNumber, viewModel, nameof(AddBusinessViewModel.TelephoneInput));
            BindingHelpers.BindText(mtxtCellphoneNumber, viewModel, nameof(AddBusinessViewModel.CellphoneInput));

            BindingHelpers.BindText(mtxtEmail, viewModel, nameof(AddBusinessViewModel.EmailInput));

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
            CommandBindings.Bind(btnCancel, viewModel.CancelCommand);
            CommandBindings.Bind(closeToolStripMenuItem, viewModel.ExitCommand);
        }

        /**********************************************************************************/
    }
}
