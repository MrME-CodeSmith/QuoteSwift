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

            CommandBindings.Bind(btnAddCustomer, viewModel.SaveCustomerCommand);
            CommandBindings.Bind(btnAddAddress, viewModel.AddAddressCommand);
            CommandBindings.Bind(btnAddPOBoxAddress, viewModel.AddPOBoxAddressCommand);
            CommandBindings.Bind(btnAddNumber, viewModel.AddPhoneNumberCommand);
            CommandBindings.Bind(BtnAddEmail, viewModel.AddEmailCommand);
            CommandBindings.Bind(btnViewAll, viewModel.ViewPhoneNumbersCommand);
            CommandBindings.Bind(btnViewAllPOBoxAddresses, viewModel.ViewPOBoxAddressesCommand);
            CommandBindings.Bind(btnViewEmailAddresses, viewModel.ViewEmailAddressesCommand);
            CommandBindings.Bind(btnViewAddresses, viewModel.ViewAddressesCommand);
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (viewModel.ExitCommand.CanExecute(null))
                viewModel.ExitCommand.Execute(null);
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

            if (viewModel.CustomerToChange != null && viewModel.ChangeSpecificObject) // Change Existing Customer Info
            {
                viewModel.CurrentCustomer = viewModel.CustomerToChange;
            }
            else if (viewModel.CustomerToChange != null && !viewModel.ChangeSpecificObject) // View Existing Customer Info
            {
                viewModel.CurrentCustomer = viewModel.CustomerToChange;
                ConvertToViewOnly();
                LoadInformation();

            }
            else if (viewModel.CustomerToChange == null && !viewModel.ChangeSpecificObject) // Add New Business Info
            {
                viewModel.ClearCurrentCustomer();
            }
            else // Undefined Use - Show ERROR
            {
                messageService.ShowError("The form was activated without the correct parameters to have an achievable goal.\nThe Form's input parameters will be disabled to avoid possible data corruption.", "ERROR - Undefined Form Use Called");
                DisableMainComponents();
            }
        }

        





        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (viewModel.CancelCommand.CanExecute(null))
                viewModel.CancelCommand.Execute(null);
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

        private void UpdatedCustomerInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertToEdit();
            viewModel.ChangeSpecificObject = true;
            updatedCustomerInformationToolStripMenuItem.Enabled = false;
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
                txtCustomerCompanyName.Text = viewModel.CurrentCustomer.CustomerCompanyName;
                cbBusinessSelection.Text = Container?.BusinessName;
                mtxtVATNumber.Text = viewModel.CurrentCustomer.CustomerLegalDetails.VatNumber;
                mtxtRegistrationNumber.Text = viewModel.CurrentCustomer.CustomerLegalDetails.RegistrationNumber;
                mtxtVendorNumber.Text = viewModel.CurrentCustomer.VendorNumber;
            }
        }

        private void ConvertToViewOnly()
        {
            viewModel.ChangeSpecificObject = false;

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
            viewModel.ChangeSpecificObject = true;

            btnAddCustomer.Visible = true;
            btnAddCustomer.Text = "Update Customer";
            if (Container != null)
                Text = Text.Replace("Viewing " + Container.BusinessName, "Updating " + Container.BusinessName);
            if (viewModel.CustomerToChange != null)
                Text = Text.Replace("Viewing " + viewModel.CustomerToChange.CustomerName, "Updating " + viewModel.CustomerToChange.CustomerName);
            updatedCustomerInformationToolStripMenuItem.Enabled = false;
        }




        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        /**********************************************************************************/
    }
}
