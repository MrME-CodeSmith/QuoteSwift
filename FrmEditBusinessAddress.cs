using System;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmEditBusinessAddress : Form
    {
        readonly ApplicationData appData;
        readonly Business business;
        readonly Customer customer;
        readonly Address address;

        public FrmEditBusinessAddress(ApplicationData data, Business business = null, Customer customer = null, Address address = null)
        {
            InitializeComponent();
            appData = data;
            this.business = business;
            this.customer = customer;
            this.address = address;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancellation can cause any changes to be lost.", "REQUEST - Cancellation")) Close();
        }

        private void FrmEditBusinessAddress_Load(object sender, EventArgs e)
        {
            if (address != null)
            {
                txtBusinessAddresssDescription.Text = address.AddressDescription;
                mtxtStreetnumber.Text = address.AddressStreetNumber.ToString();
                txtStreetName.Text = address.AddressStreetName;
                txtSuburb.Text = address.AddressSuburb;
                txtCity.Text = address.AddressCity;
                mtxtAreaCode.Text = address.AddressAreaCode.ToString();
                txtStreetName.Enabled = false;
            }
        }

        private void BtnUpdateAddress_Click(object sender, EventArgs e)
        {
            if (ValidInput())
            {
                Address UpdatedAddress = new Address
                {
                    AddressDescription = txtBusinessAddresssDescription.Text,
                    AddressStreetNumber = QuoteSwiftMainCode.ParseInt(mtxtStreetnumber.Text),
                    AddressStreetName = txtStreetName.Text,
                    AddressSuburb = txtSuburb.Text,
                    AddressCity = txtCity.Text,
                    AddressAreaCode = QuoteSwiftMainCode.ParseInt(mtxtAreaCode.Text)
                };


                if (!AddressExists(UpdatedAddress))
                {
                    if (address != null)
                    {
                        address.AddressDescription = UpdatedAddress.AddressDescription;
                        address.AddressStreetNumber = UpdatedAddress.AddressStreetNumber;
                        address.AddressStreetName = UpdatedAddress.AddressStreetName;
                        address.AddressSuburb = UpdatedAddress.AddressSuburb;
                        address.AddressCity = UpdatedAddress.AddressCity;
                        address.AddressAreaCode = UpdatedAddress.AddressAreaCode;
                    }
                    MainProgramCode.ShowInformation("The address has been successfully updated", "INFORMATION - Address Successfully Updated");
                    Close();
                }
                else MainProgramCode.ShowError("Address not updated since this address is already in the list of addresses.\nNOTE: Address Description should be unique.", "ERROR - Address Already Added");
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                appData.SaveAll();
        }

        private bool ValidInput()
        {
            if (txtBusinessAddresssDescription.Text.Length < 2)
            {
                MainProgramCode.ShowError("The provided Business Address Description is invalid, please provide a valid description", "ERROR - Invalid Business Address Description");
                return (false);
            }

            if (QuoteSwiftMainCode.ParseInt(mtxtStreetnumber.Text) == 0)
            {
                MainProgramCode.ShowError("The provided Business Address Street Number is invalid, please provide a valid street number", "ERROR - Invalid Business Address Street Number");
                return (false);
            }

            if (txtStreetName.Text.Length < 2 && address == null)
            {
                MainProgramCode.ShowError("The provided Business Address Street Name is invalid, please provide a valid street name", "ERROR - Invalid Business Address Street Name");
                return (false);
            }

            if (txtSuburb.Text.Length < 2)
            {
                MainProgramCode.ShowError("The provided Business Address Suburb is invalid, please provide a valid suburb", "ERROR - Invalid Business Address Suburb");
                return (false);
            }

            if (txtCity.Text.Length < 2)
            {
                MainProgramCode.ShowError("The provided Business Address City is invalid, please provide a valid city", "ERROR - Invalid Business Address City");
                return (false);
            }

            if (QuoteSwiftMainCode.ParseInt(mtxtAreaCode.Text) == 0)
            {
                MainProgramCode.ShowError("The provided Business Address Area Code is invalid, please provide a valid area code", "ERROR - Invalid Business Address Area Code");
                return (false);
            }

            return true;
        }

        private bool AddressExists(Address a)
        {
            if (a == null) return false;

            string key = StringUtil.NormalizeKey(a.AddressDescription);

            if (business != null &&
                business.AddressMap.TryGetValue(key, out Address existingB))
            {
                if (!ReferenceEquals(existingB, address))
                    return true;
            }

            if (customer != null &&
                customer.DeliveryAddressMap.TryGetValue(key, out Address existingC))
            {
                if (!ReferenceEquals(existingC, address))
                    return true;
            }

            return false;
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
