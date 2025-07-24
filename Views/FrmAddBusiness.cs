using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace QuoteSwift.Views
{
    public partial class FrmAddBusiness : BaseForm<AddBusinessViewModel>
    {

        readonly INavigationService navigation;
        readonly IMessageService messageService;
        readonly ISerializationService serializationService;

        public FrmAddBusiness(AddBusinessViewModel viewModel, INavigationService navigation = null, IMessageService messageService = null, ISerializationService serializationService = null)
            : base(viewModel, messageService, navigation)
        {
            InitializeComponent();
            this.navigation = navigation;
            this.serializationService = serializationService;
            this.messageService = messageService;
            ViewModel.CloseAction = Close;

            DataBindings.Add("Text", ViewModel, nameof(AddBusinessViewModel.FormTitle));
            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            BindIsBusy(ViewModel);
        }




        void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AddBusinessViewModel.IsViewing))
            {
                updateBusinessInformationToolStripMenuItem.Enabled = ViewModel.IsViewing;
            }
        }



        private async void FrmAddBusiness_Load(object sender, EventArgs e)
        {
            await ((AsyncRelayCommand)ViewModel.LoadDataCommand).ExecuteAsync(null);
            var initResult = ViewModel.InitializeCurrentBusinessResult();
            if (!initResult.Success)
            {
                DisableMainComponents();
            }

            ViewModel.EnsureLegalDetails();
            SetupBindings();
            updateBusinessInformationToolStripMenuItem.Enabled = ViewModel.IsViewing;
        }


        private void UpdateBusinessInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewModel.ChangeSpecificObject = true;
        }




        private void SetupBindings()
        {
            BindingHelpers.BindText(txtBusinessName, ViewModel.CurrentBusiness, nameof(Business.BusinessName));
            BindingHelpers.BindText(rtxtExtraInformation, ViewModel.CurrentBusiness, nameof(Business.BusinessExtraInformation));
            BindingHelpers.BindText(mtxtVATNumber, ViewModel.CurrentBusiness, "BusinessLegalDetails.VatNumber");
            BindingHelpers.BindText(mtxtRegistrationNumber, ViewModel.CurrentBusiness, "BusinessLegalDetails.RegistrationNumber");

            BindingHelpers.BindText(txtBusinessAddresssDescription, ViewModel, nameof(AddBusinessViewModel.AddressDescription));
            BindingHelpers.BindText(mtxtStreetnumber, ViewModel, nameof(AddBusinessViewModel.StreetNumber));
            BindingHelpers.BindText(txtStreetName, ViewModel, nameof(AddBusinessViewModel.StreetName));
            BindingHelpers.BindText(txtSuburb, ViewModel, nameof(AddBusinessViewModel.Suburb));
            BindingHelpers.BindText(txtCity, ViewModel, nameof(AddBusinessViewModel.City));
            BindingHelpers.BindText(mtxtAreaCode, ViewModel, nameof(AddBusinessViewModel.AreaCode));

            BindingHelpers.BindText(txtBusinessPODescription, ViewModel, nameof(AddBusinessViewModel.PODescription));
            BindingHelpers.BindText(mtxtPOBoxStreetNumber, ViewModel, nameof(AddBusinessViewModel.POStreetNumber));
            BindingHelpers.BindText(txtPOBoxSuburb, ViewModel, nameof(AddBusinessViewModel.POSuburb));
            BindingHelpers.BindText(txtPOBoxCity, ViewModel, nameof(AddBusinessViewModel.POCity));
            BindingHelpers.BindText(mtxtPOBoxAreaCode, ViewModel, nameof(AddBusinessViewModel.POAreaCode));

            BindingHelpers.BindText(mtxtTelephoneNumber, ViewModel, nameof(AddBusinessViewModel.TelephoneInput));
            BindingHelpers.BindText(mtxtCellphoneNumber, ViewModel, nameof(AddBusinessViewModel.CellphoneInput));

            BindingHelpers.BindText(mtxtEmail, ViewModel, nameof(AddBusinessViewModel.EmailInput));

            gbxBusinessAddress.DataBindings.Add("Enabled", ViewModel, nameof(AddBusinessViewModel.IsEditing));
            gbxBusinessInformation.DataBindings.Add("Enabled", ViewModel, nameof(AddBusinessViewModel.IsEditing));
            gbxEmailRelated.DataBindings.Add("Enabled", ViewModel, nameof(AddBusinessViewModel.IsEditing));
            gbxLegalInformation.DataBindings.Add("Enabled", ViewModel, nameof(AddBusinessViewModel.IsEditing));
            gbxPhoneRelated.DataBindings.Add("Enabled", ViewModel, nameof(AddBusinessViewModel.IsEditing));
            gbxPOBoxAddress.DataBindings.Add("Enabled", ViewModel, nameof(AddBusinessViewModel.IsEditing));

            btnAddBusiness.DataBindings.Add("Visible", ViewModel, nameof(AddBusinessViewModel.ShowSaveButton));
            btnAddBusiness.DataBindings.Add("Text", ViewModel, nameof(AddBusinessViewModel.SaveButtonText));

            CommandBindings.Bind(btnAddBusiness, ViewModel.SaveBusinessCommand);
            CommandBindings.Bind(btnAddAddress, ViewModel.AddAddressCommand);
            CommandBindings.Bind(btnAddPOBoxAddress, ViewModel.AddPOBoxAddressCommand);
            CommandBindings.Bind(btnAddNumber, ViewModel.AddPhoneNumberCommand);
            CommandBindings.Bind(btnAddBusinessEmail, ViewModel.AddEmailCommand);
            CommandBindings.Bind(btnViewEmailAddresses, ViewModel.ViewEmailAddressesCommand);
            CommandBindings.Bind(btnViewAddresses, ViewModel.ViewAddressesCommand);
            CommandBindings.Bind(btnViewAllPOBoxAddresses, ViewModel.ViewPOBoxAddressesCommand);
            CommandBindings.Bind(btnViewAll, ViewModel.ViewPhoneNumbersCommand);
            CommandBindings.Bind(btnCancel, ViewModel.CancelCommand);
            CommandBindings.Bind(closeToolStripMenuItem, ViewModel.ExitCommand);
        }

        private void DisableMainComponents()
        {
            gbxBusinessAddress.Enabled = false;
            gbxBusinessInformation.Enabled = false;
            gbxPhoneRelated.Enabled = false;
            gbxEmailRelated.Enabled = false;
            gbxLegalInformation.Enabled = false;
            gbxPOBoxAddress.Enabled = false;
            btnAddBusiness.Enabled = false;
        }

        /**********************************************************************************/
    }
}
