using System;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmEditBusinessAddress : Form
    {
        readonly ApplicationData appData;
        readonly EditBusinessAddressViewModel viewModel;

        public FrmEditBusinessAddress(EditBusinessAddressViewModel viewModel, ApplicationData data = null)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            appData = data;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancellation can cause any changes to be lost.", "REQUEST - Cancellation")) Close();
        }

        private void FrmEditBusinessAddress_Load(object sender, EventArgs e)
        {
            if (viewModel.Address != null)
            {
                txtBusinessAddresssDescription.Text = viewModel.Address.AddressDescription;
                mtxtStreetnumber.Text = viewModel.Address.AddressStreetNumber.ToString();
                txtStreetName.Text = viewModel.Address.AddressStreetName;
                txtSuburb.Text = viewModel.Address.AddressSuburb;
                txtCity.Text = viewModel.Address.AddressCity;
                mtxtAreaCode.Text = viewModel.Address.AddressAreaCode.ToString();
                txtStreetName.Enabled = false;
            }
        }

        private void BtnUpdateAddress_Click(object sender, EventArgs e)
        {
            Address updated = new Address
            {
                AddressDescription = txtBusinessAddresssDescription.Text,
                AddressStreetNumber = QuoteSwiftMainCode.ParseInt(mtxtStreetnumber.Text),
                AddressStreetName = txtStreetName.Text,
                AddressSuburb = txtSuburb.Text,
                AddressCity = txtCity.Text,
                AddressAreaCode = QuoteSwiftMainCode.ParseInt(mtxtAreaCode.Text)
            };

            if (viewModel.UpdateAddress(updated))
            {
                MainProgramCode.ShowInformation("The address has been successfully updated", "INFORMATION - Address Successfully Updated");
                Close();
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                appData.SaveAll();
        }


        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmEditBusinessAddress_FormClosing(object sender, FormClosingEventArgs e)
        {
            appData.SaveAll();
        }
    }
}
