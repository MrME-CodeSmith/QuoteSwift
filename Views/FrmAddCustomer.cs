using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace QuoteSwift.Views
{
    public partial class FrmAddCustomer : BaseForm<AddCustomerViewModel>
    {

        readonly INavigationService navigation;
        readonly IMessageService messageService;
        readonly ISerializationService serializationService;

        public Business Container { get; set; }

        public FrmAddCustomer(AddCustomerViewModel viewModel, INavigationService navigation = null, IMessageService messageService = null, ISerializationService serializationService = null)
            : base(viewModel, messageService, navigation)
        {
            InitializeComponent();
            this.navigation = navigation;
            this.serializationService = serializationService;
            this.messageService = messageService;
            ViewModel.CloseAction = Close;
            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            DataBindings.Add("Text", ViewModel, nameof(AddCustomerViewModel.FormTitle));
            ViewModel.CurrentCustomer = ViewModel.CustomerToChange ?? new Customer();
            BindIsBusy(ViewModel);

            BindingHelpers.BindText(txtCustomerCompanyName, ViewModel.CurrentCustomer, nameof(Customer.CustomerCompanyName));
            BindingHelpers.BindText(mtxtVendorNumber, ViewModel.CurrentCustomer, nameof(Customer.VendorNumber));

            BindingHelpers.BindText(txtCustomerAddresssDescription, ViewModel, nameof(AddCustomerViewModel.AddressDescription));
            BindingHelpers.BindText(txtAtt, ViewModel, nameof(AddCustomerViewModel.Att));
            BindingHelpers.BindText(txtWorkArea, ViewModel, nameof(AddCustomerViewModel.WorkArea));
            BindingHelpers.BindText(txtWorkPlace, ViewModel, nameof(AddCustomerViewModel.WorkPlace));

            BindingHelpers.BindText(txtCustomerPODescription, ViewModel, nameof(AddCustomerViewModel.PODescription));
            BindingHelpers.BindText(mtxtPOBoxStreetNumber, ViewModel, nameof(AddCustomerViewModel.POStreetNumber));
            BindingHelpers.BindText(txtPOBoxSuburb, ViewModel, nameof(AddCustomerViewModel.POSuburb));
            BindingHelpers.BindText(txtPOBoxCity, ViewModel, nameof(AddCustomerViewModel.POCity));
            BindingHelpers.BindText(mtxtPOBoxAreaCode, ViewModel, nameof(AddCustomerViewModel.POAreaCode));

            BindingHelpers.BindText(mtxtTelephoneNumber, ViewModel, nameof(AddCustomerViewModel.TelephoneInput));
            BindingHelpers.BindText(mtxtCellphoneNumber, ViewModel, nameof(AddCustomerViewModel.CellphoneInput));

            BindingHelpers.BindText(mtxtEmailAddress, ViewModel, nameof(AddCustomerViewModel.EmailInput));

            gbxCustomerInformation.DataBindings.Add("Enabled", ViewModel, nameof(AddCustomerViewModel.IsEditing));
            gbxCustomerAddress.DataBindings.Add("Enabled", ViewModel, nameof(AddCustomerViewModel.IsEditing));
            gbxEmailRelated.DataBindings.Add("Enabled", ViewModel, nameof(AddCustomerViewModel.IsEditing));
            gbxLegalInformation.DataBindings.Add("Enabled", ViewModel, nameof(AddCustomerViewModel.IsEditing));
            gbxPhoneRelated.DataBindings.Add("Enabled", ViewModel, nameof(AddCustomerViewModel.IsEditing));
            gbxPOBoxAddress.DataBindings.Add("Enabled", ViewModel, nameof(AddCustomerViewModel.IsEditing));

            btnAddCustomer.DataBindings.Add("Visible", ViewModel, nameof(AddCustomerViewModel.ShowSaveButton));
            btnAddCustomer.DataBindings.Add("Text", ViewModel, nameof(AddCustomerViewModel.SaveButtonText));

            CommandBindings.Bind(btnAddCustomer, ViewModel.SaveCustomerCommand);
            CommandBindings.Bind(btnAddAddress, ViewModel.AddAddressCommand);
            CommandBindings.Bind(btnAddPOBoxAddress, ViewModel.AddPOBoxAddressCommand);
            CommandBindings.Bind(btnAddNumber, ViewModel.AddPhoneNumberCommand);
            CommandBindings.Bind(BtnAddEmail, ViewModel.AddEmailCommand);
            CommandBindings.Bind(btnViewAll, ViewModel.ViewPhoneNumbersCommand);
            CommandBindings.Bind(btnViewAllPOBoxAddresses, ViewModel.ViewPOBoxAddressesCommand);
            CommandBindings.Bind(btnViewEmailAddresses, ViewModel.ViewEmailAddressesCommand);
            CommandBindings.Bind(btnViewAddresses, ViewModel.ViewAddressesCommand);
            CommandBindings.Bind(btnCancel, ViewModel.CancelCommand);
            CommandBindings.Bind(closeToolStripMenuItem, ViewModel.ExitCommand);
            CommandBindings.Bind(updatedCustomerInformationToolStripMenuItem, ViewModel.StartEditCommand);
        }

        void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AddCustomerViewModel.IsViewing))
            {
                updatedCustomerInformationToolStripMenuItem.Enabled = ViewModel.IsViewing;
            }
        }


        private async void FrmAddCustomer_Load(object sender, EventArgs e)
        {
            await ((AsyncRelayCommand)ViewModel.LoadDataCommand).ExecuteAsync(null);
            if (ViewModel.BusinessList != null)
            {
                BindingSource source = new BindingSource { DataSource = ViewModel.BusinessList };
                cbBusinessSelection.DataSource = source.DataSource;
                cbBusinessSelection.DisplayMember = "BusinessName";
                cbBusinessSelection.ValueMember = "BusinessName";
            }

            bool initSuccess = ViewModel.ValidateInitialization();
            if (!initSuccess)
            {
                DisableMainComponents();
            }
        }

        





        private void BtnViewAll_Click(object sender, EventArgs e)
        {
            ViewModel.ViewPhoneNumbersCommand.Execute(null);
        }

        private void BtnViewAllPOBoxAddresses_Click(object sender, EventArgs e)
        {
            ViewModel.ViewPOBoxAddressesCommand.Execute(null);
        }

        private void BtnViewEmailAddresses_Click(object sender, EventArgs e)
        {
            ViewModel.ViewEmailAddressesCommand.Execute(null);
        }

        private void BtnViewAddresses_Click(object sender, EventArgs e)
        {
            ViewModel.ViewAddressesCommand.Execute(null);
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
