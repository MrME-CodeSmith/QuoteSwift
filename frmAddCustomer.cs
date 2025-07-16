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
        readonly ApplicationData appData;
        readonly IMessageService messageService;
        readonly ISerializationService serializationService;

        Business Container;

        public FrmAddCustomer(AddCustomerViewModel viewModel, INavigationService navigation = null, ApplicationData appData = null, Business container = null, IMessageService messageService = null, ISerializationService serializationService = null)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.navigation = navigation;
            this.appData = appData;
            this.serializationService = serializationService;
            this.messageService = messageService;
            this.Container = container;
            viewModel.CurrentCustomer = viewModel.CustomerToChange ?? new Customer();

            txtCustomerCompanyName.DataBindings.Add("Text", viewModel.CurrentCustomer, nameof(Customer.CustomerCompanyName), false, DataSourceUpdateMode.OnPropertyChanged);
            mtxtVendorNumber.DataBindings.Add("Text", viewModel.CurrentCustomer, nameof(Customer.VendorNumber), false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
            {
                serializationService.CloseApplication(true,
                    appData?.BusinessList,
                    appData?.PumpList,
                    appData?.PartList,
                    appData?.QuoteMap);
        }

        private void BtnAddCustomer_Click(object sender, EventArgs e)
        {
            if (viewModel.ValidateBusiness() && !viewModel.ChangeSpecificObject)
            {
                Business linkBusiness = GetSelectedBusiness();
                viewModel.CurrentCustomer.CustomerName = string.Empty;
                viewModel.CurrentCustomer.CustomerLegalDetails = new Legal(mtxtRegistrationNumber.Text, mtxtVATNumber.Text);
                viewModel.CurrentCustomer.VendorNumber = mtxtVendorNumber.Text;

                viewModel.AddCustomerCommand.Execute(linkBusiness);
                if (viewModel.LastOperationSuccessful)
                {
                    messageService.ShowInformation(viewModel.CurrentCustomer.CustomerCompanyName + " has been added.", "INFORMATION - Business Successfully Added");
                    viewModel.ClearCurrentCustomer();
                    ResetScreenInput();
                }
                else if (viewModel.LastResult?.Message != null)
                    messageService.ShowError(viewModel.LastResult.Message, viewModel.LastResult.Caption);
            }
            else if (viewModel.ValidateBusiness() && viewModel.ChangeSpecificObject)
            {
                string oldName = viewModel.CustomerToChange.CustomerCompanyName;
                viewModel.CurrentCustomer.CustomerName = string.Empty;
                viewModel.CurrentCustomer.CustomerLegalDetails = new Legal(mtxtRegistrationNumber.Text, mtxtVATNumber.Text);
                viewModel.CurrentCustomer.VendorNumber = mtxtVendorNumber.Text;

                Business container = GetSelectedBusiness();
                viewModel.UpdateCustomerCommand.Execute(new object[] { container, oldName });
                if (viewModel.LastOperationSuccessful)
                {
                    messageService.ShowInformation(viewModel.CurrentCustomer.CustomerCompanyName + " has been successfully updated.", "INFORMATION - Customer Successfully Updated");
                    ConvertToViewOnly();
                }
                else if (viewModel.LastResult?.Message != null)
                    messageService.ShowError(viewModel.LastResult.Message, viewModel.LastResult.Caption);
            }
        }

        private void FrmAddCustomer_Load(object sender, EventArgs e)
        {
            viewModel.LoadData();
            if (appData.BusinessList != null)
            {
                BindingSource source = new BindingSource { DataSource = appData.BusinessList };
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

        private void BtnAddAddress_Click(object sender, EventArgs e)
        {
            var addr = viewModel.BuildCustomerAddress(txtCustomerAddresssDescription.Text,
                                                     txtAtt.Text,
                                                     txtWorkArea.Text,
                                                     txtWorkPlace.Text);
            if (viewModel.ValidateCustomerAddress(addr))
            {
                var r = viewModel.AddDeliveryAddress(addr);
                if (r.Success)
                {
                    messageService.ShowInformation("Successfully added the customer address", "INFORMATION - Customer Address Added Successfully");
                    ClearCustomerAddressInput();
                }
                else if (r.Message != null)
                    messageService.ShowError(r.Message, r.Caption);
            }
        }

        private void BtnAddPOBoxAddress_Click(object sender, EventArgs e)
        {
            var po = viewModel.BuildPOBoxAddress(txtCustomerPODescription.Text,
                                                mtxtPOBoxStreetNumber.Text,
                                                txtPOBoxSuburb.Text,
                                                txtPOBoxCity.Text,
                                                mtxtPOBoxAreaCode.Text);
            if (viewModel.ValidateCustomerPOBoxAddress(po))
            {
                var r = viewModel.AddPOBoxAddress(po);
                if (r.Success)
                {
                    messageService.ShowInformation("Successfully added the customer P.O.Box address", "INFORMATION - Business P.O.Box Address Added Successfully");
                    ClearPOBoxAddressInput();
                }
                else if (r.Message != null)
                    messageService.ShowError(r.Message, r.Caption);
            }
        }

        private void BtnAddNumber_Click(object sender, EventArgs e)
        {
            var nr = viewModel.AddPhoneNumbers(mtxtTelephoneNumber.Text, mtxtCellphoneNumber.Text);
            if (nr.Success)
            {
                mtxtTelephoneNumber.ResetText();
                mtxtCellphoneNumber.ResetText();
                messageService.ShowInformation("Successfully added the customer phone number/s", "INFORMATION - Customer Phone Number/s Added Successfully");
            }
            else if (nr.Message != null)
                messageService.ShowError(nr.Message, nr.Caption);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to cancel the current action?\nCancellation can cause any changes to be lost.", "REQUEST - Cancellation")) Close();
        }

        private void BtnViewAll_Click(object sender, EventArgs e)
        {
            if (viewModel.CurrentCustomer.CustomerCellphoneNumberList != null || viewModel.CurrentCustomer.CustomerTelephoneNumberList != null)
            {
                Hide();
                navigation.ViewBusinessesPhoneNumbers(null, viewModel.CurrentCustomer);
                Show();
            }
            else messageService.ShowError("You need to first add at least one phone number before you can view the list of phone numbers.\nPlease add a phone number first", "ERROR - Can't View Non-Existing Customer Phone Numbers");
        }

        private void BtnViewAllPOBoxAddresses_Click(object sender, EventArgs e)
        {
            if (viewModel.CurrentCustomer.CustomerPOBoxAddress != null)
            {
                Hide();
                navigation.ViewBusinessesPOBoxAddresses(null, viewModel.CurrentCustomer);
                Show();
            }
            else messageService.ShowError("You need to first add an P.O.Box address before you can view the list of addresses.\nPlease add an address first", "ERROR - Can't View Non-Existing Customer P.O.Box Addresses");
        }

        private void BtnViewEmailAddresses_Click(object sender, EventArgs e)
        {
            if (viewModel.CurrentCustomer.CustomerEmailList != null)
            {
                Hide();
                navigation.ViewBusinessesEmailAddresses(null, viewModel.CurrentCustomer);
                Show();

            }
            else messageService.ShowError("You need to first add an Email address before you can view the list of addresses.\nPlease add an address first", "ERROR - Can't View Non-Existing Customer Email Addresses");
        }

        private void BtnViewAddresses_Click(object sender, EventArgs e)
        {
            if (viewModel.CurrentCustomer != null)
            {
                Hide();
                navigation.ViewBusinessesAddresses(null, viewModel.CurrentCustomer);
                Show();
            }
            else messageService.ShowError("You need to first add an address before you can view the list of addresses.\nPlease add an address first", "ERROR - Can't View Non-Existing Customer Addresses");
        }

        private void UpdatedCustomerInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertToEdit();
            viewModel.ChangeSpecificObject = true;
            updatedCustomerInformationToolStripMenuItem.Enabled = false;
        }

        private void BtnAddEmail_Click(object sender, EventArgs e)
        {
            if (viewModel.AddEmailAddress(mtxtEmailAddress.Text))
            {
                messageService.ShowInformation("Successfully added the customer Email address", "INFORMATION - Customer Email Address Added Successfully");
                mtxtEmailAddress.ResetText();
            }
        }

        private void FrmAddCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            serializationService.CloseApplication(true,
                appData?.BusinessList,
                appData?.PumpList,
                appData?.PartList,
                appData?.QuoteMap);

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
            ApplyControlState();

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
            ApplyControlState();

            btnAddCustomer.Visible = true;
            btnAddCustomer.Text = "Update Customer";
            if (Container != null)
                Text = Text.Replace("Viewing " + Container.BusinessName, "Updating " + Container.BusinessName);
            if (viewModel.CustomerToChange != null)
                Text = Text.Replace("Viewing " + viewModel.CustomerToChange.CustomerName, "Updating " + viewModel.CustomerToChange.CustomerName);
            updatedCustomerInformationToolStripMenuItem.Enabled = false;
        }

        void ApplyControlState()
        {
            bool ro = viewModel.IsReadOnly;
            ControlStateHelper.ApplyReadOnly(gbxCustomerInformation.Controls, ro);
            ControlStateHelper.ApplyReadOnly(gbxCustomerAddress.Controls, ro);
            ControlStateHelper.ApplyReadOnly(gbxEmailRelated.Controls, ro);
            ControlStateHelper.ApplyReadOnly(gbxLegalInformation.Controls, ro);
            ControlStateHelper.ApplyReadOnly(gbxPhoneRelated.Controls, ro);
            ControlStateHelper.ApplyReadOnly(gbxPOBoxAddress.Controls, ro);
        }

        private Business GetSelectedBusiness()
        {
            if (cbBusinessSelection.Text.Length > 0 && appData.BusinessList != null)
            {
                return appData.BusinessList.FirstOrDefault(b => b.BusinessName == cbBusinessSelection.Text);
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
