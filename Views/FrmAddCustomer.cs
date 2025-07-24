using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace QuoteSwift.Views
{
    public partial class FrmAddCustomer : BaseForm
    {

        readonly AddCustomerViewModel viewModel;
        readonly INavigationService navigation;
        readonly IMessageService messageService;
        readonly ISerializationService serializationService;

        public AddCustomerViewModel ViewModel => viewModel;

        public Business Container { get; set; }

        public FrmAddCustomer(AddCustomerViewModel viewModel, INavigationService navigation = null, IMessageService messageService = null, ISerializationService serializationService = null)
            : base(messageService, navigation)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.navigation = navigation;
            this.serializationService = serializationService;
            this.messageService = messageService;
            viewModel.CloseAction = Close;
            viewModel.PropertyChanged += ViewModel_PropertyChanged;
            DataBindings.Add("Text", viewModel, nameof(AddCustomerViewModel.FormTitle));
            viewModel.CurrentCustomer = viewModel.CustomerToChange ?? new Customer();
            BindIsBusy(viewModel);

            BindingHelpers.BindText(txtCustomerCompanyName, viewModel.CurrentCustomer, nameof(Customer.CustomerCompanyName));
            BindingHelpers.BindText(mtxtVendorNumber, viewModel.CurrentCustomer, nameof(Customer.VendorNumber));

            BindingHelpers.BindText(txtCustomerAddresssDescription, viewModel, nameof(AddCustomerViewModel.AddressDescription));
            BindingHelpers.BindText(txtAtt, viewModel, nameof(AddCustomerViewModel.Att));
            BindingHelpers.BindText(txtWorkArea, viewModel, nameof(AddCustomerViewModel.WorkArea));
            BindingHelpers.BindText(txtWorkPlace, viewModel, nameof(AddCustomerViewModel.WorkPlace));

            BindingHelpers.BindText(txtCustomerPODescription, viewModel, nameof(AddCustomerViewModel.PODescription));
            BindingHelpers.BindText(mtxtPOBoxStreetNumber, viewModel, nameof(AddCustomerViewModel.POStreetNumber));
            BindingHelpers.BindText(txtPOBoxSuburb, viewModel, nameof(AddCustomerViewModel.POSuburb));
            BindingHelpers.BindText(txtPOBoxCity, viewModel, nameof(AddCustomerViewModel.POCity));
            BindingHelpers.BindText(mtxtPOBoxAreaCode, viewModel, nameof(AddCustomerViewModel.POAreaCode));

            BindingHelpers.BindText(mtxtTelephoneNumber, viewModel, nameof(AddCustomerViewModel.TelephoneInput));
            BindingHelpers.BindText(mtxtCellphoneNumber, viewModel, nameof(AddCustomerViewModel.CellphoneInput));

            BindingHelpers.BindText(mtxtEmailAddress, viewModel, nameof(AddCustomerViewModel.EmailInput));

            gbxCustomerInformation.DataBindings.Add("Enabled", viewModel, nameof(AddCustomerViewModel.IsEditing));
            gbxCustomerAddress.DataBindings.Add("Enabled", viewModel, nameof(AddCustomerViewModel.IsEditing));
            gbxEmailRelated.DataBindings.Add("Enabled", viewModel, nameof(AddCustomerViewModel.IsEditing));
            gbxLegalInformation.DataBindings.Add("Enabled", viewModel, nameof(AddCustomerViewModel.IsEditing));
            gbxPhoneRelated.DataBindings.Add("Enabled", viewModel, nameof(AddCustomerViewModel.IsEditing));
            gbxPOBoxAddress.DataBindings.Add("Enabled", viewModel, nameof(AddCustomerViewModel.IsEditing));

            btnAddCustomer.DataBindings.Add("Visible", viewModel, nameof(AddCustomerViewModel.ShowSaveButton));
            btnAddCustomer.DataBindings.Add("Text", viewModel, nameof(AddCustomerViewModel.SaveButtonText));

            CommandBindings.Bind(btnAddCustomer, viewModel.SaveCustomerCommand);
            CommandBindings.Bind(btnAddAddress, viewModel.AddAddressCommand);
            CommandBindings.Bind(btnAddPOBoxAddress, viewModel.AddPOBoxAddressCommand);
            CommandBindings.Bind(btnAddNumber, viewModel.AddPhoneNumberCommand);
            CommandBindings.Bind(BtnAddEmail, viewModel.AddEmailCommand);
            CommandBindings.Bind(btnViewAll, viewModel.ViewPhoneNumbersCommand);
            CommandBindings.Bind(btnViewAllPOBoxAddresses, viewModel.ViewPOBoxAddressesCommand);
            CommandBindings.Bind(btnViewEmailAddresses, viewModel.ViewEmailAddressesCommand);
            CommandBindings.Bind(btnViewAddresses, viewModel.ViewAddressesCommand);
            CommandBindings.Bind(btnCancel, viewModel.CancelCommand);
            CommandBindings.Bind(closeToolStripMenuItem, viewModel.ExitCommand);
            CommandBindings.Bind(updatedCustomerInformationToolStripMenuItem, viewModel.StartEditCommand);
        }

        void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AddCustomerViewModel.IsViewing))
            {
                updatedCustomerInformationToolStripMenuItem.Enabled = viewModel.IsViewing;
            }
        }


        private async void FrmAddCustomer_Load(object sender, EventArgs e)
        {
            await viewModel.LoadDataAsync();
            if (viewModel.BusinessList != null)
            {
                BindingSource source = new BindingSource { DataSource = viewModel.BusinessList };
                cbBusinessSelection.DataSource = source.DataSource;
                cbBusinessSelection.DisplayMember = "BusinessName";
                cbBusinessSelection.ValueMember = "BusinessName";
            }

            bool initSuccess = viewModel.ValidateInitialization();
            if (!initSuccess)
            {
                DisableMainComponents();
            }
        }

        





        private void BtnViewAll_Click(object sender, EventArgs e)
        {
            viewModel.ViewPhoneNumbersCommand.Execute(null);
        }

        private void BtnViewAllPOBoxAddresses_Click(object sender, EventArgs e)
        {
            viewModel.ViewPOBoxAddressesCommand.Execute(null);
        }

        private void BtnViewEmailAddresses_Click(object sender, EventArgs e)
        {
            viewModel.ViewEmailAddressesCommand.Execute(null);
        }

        private void BtnViewAddresses_Click(object sender, EventArgs e)
        {
            viewModel.ViewAddressesCommand.Execute(null);
        }






        /** Form Specific Functions And Procedures:
       *
       * Note: Not all Functions or Procedures below are used more than once
       *       Some of them are only to keep the above events readable 
       *       and clutter free.                                                          
       */


        private void DisableMainComponents()
        {
            gbxCustomerInformation.Enabled = false;
            gbxCustomerAddress.Enabled = false;
            gbxPhoneRelated.Enabled = false;
            gbxEmailRelated.Enabled = false;
            gbxPOBoxAddress.Enabled = false;
            btnAddCustomer.Enabled = false;
        }




        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        /**********************************************************************************/
    }
}
