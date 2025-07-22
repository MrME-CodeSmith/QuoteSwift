using System;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmEditBusinessAddress : Form
    {
        readonly IMessageService messageService;
        readonly EditBusinessAddressViewModel viewModel;
        public EditBusinessAddressViewModel ViewModel => viewModel;

        public FrmEditBusinessAddress(EditBusinessAddressViewModel viewModel, IMessageService messageService = null)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.messageService = messageService;
            SetupBindings();
        }

        void SetupBindings()
        {
            txtBusinessAddresssDescription.DataBindings.Add("Text", viewModel, nameof(EditBusinessAddressViewModel.AddressDescription), false, DataSourceUpdateMode.OnPropertyChanged);
            mtxtStreetnumber.DataBindings.Add("Text", viewModel, nameof(EditBusinessAddressViewModel.StreetNumber), false, DataSourceUpdateMode.OnPropertyChanged);
            txtStreetName.DataBindings.Add("Text", viewModel, nameof(EditBusinessAddressViewModel.StreetName), false, DataSourceUpdateMode.OnPropertyChanged);
            txtSuburb.DataBindings.Add("Text", viewModel, nameof(EditBusinessAddressViewModel.Suburb), false, DataSourceUpdateMode.OnPropertyChanged);
            txtCity.DataBindings.Add("Text", viewModel, nameof(EditBusinessAddressViewModel.City), false, DataSourceUpdateMode.OnPropertyChanged);
            mtxtAreaCode.DataBindings.Add("Text", viewModel, nameof(EditBusinessAddressViewModel.AreaCode), false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to cancel the current action?\nCancellation can cause any changes to be lost.", "REQUEST - Cancellation")) Close();
        }

        private void FrmEditBusinessAddress_Load(object sender, EventArgs e)
        {
            if (viewModel.Address != null)
            {
                txtStreetName.Enabled = false;
            }
        }

        private void BtnUpdateAddress_Click(object sender, EventArgs e)
        {
            viewModel.UpdateAddressCommand.Execute(null);
            var result = viewModel.LastResult;
            if (result.Success)
            {
                messageService.ShowInformation("The address has been successfully updated", "INFORMATION - Address Successfully Updated");
                Close();
            }
            else if (result.Message != null)
                messageService.ShowError(result.Message, result.Caption);
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                Application.Exit();
        }


        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmEditBusinessAddress_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
