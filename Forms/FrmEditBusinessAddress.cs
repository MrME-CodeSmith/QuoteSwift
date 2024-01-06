using System;
using System.Windows.Forms;
using MainProgramLibrary;
using QuoteSwift.Models;

namespace QuoteSwift.Forms
{
    public partial class FrmEditBusinessAddress : Form
    {
        AppContext mPassed;

        public ref AppContext Passed { get => ref mPassed; }

        public FrmEditBusinessAddress()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancellation can cause any changes to be lost.", "REQUEST - Cancellation")) Close();
        }

        private void FrmEditBusinessAddress_Load(object sender, EventArgs e)
        {
            if (mPassed.AddressToChange != null)
            {
                txtBusinessAddresssDescription.Text = mPassed.AddressToChange.AddressDescription;
                mtxtStreetnumber.Text = mPassed.AddressToChange.AddressStreetNumber.ToString();
                txtStreetName.Text = mPassed.AddressToChange.AddressStreetName;
                txtSuburb.Text = mPassed.AddressToChange.AddressSuburb;
                txtCity.Text = mPassed.AddressToChange.AddressCity;
                mtxtAreaCode.Text = mPassed.AddressToChange.AddressAreaCode.ToString();
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
                    mPassed.AddressToChange = UpdatedAddress;
                    MainProgramCode.ShowInformation("The address has been successfully updated", "INFORMATION - Address Successfully Updated");
                    Close();
                }
                else MainProgramCode.ShowError("Address not updated since this address is already in the list of addresses.\nNOTE: Address Description should be unique.", "ERROR - Address Already Added");
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                QuoteSwiftMainCode.CloseApplication(true);
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

            if (txtStreetName.Text.Length < 2 && mPassed.AddressToChange == null)
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
            if (mPassed != null && mPassed.BusinessToChange != null && mPassed.BusinessToChange.BusinessPoBoxAddressList != null)
                if (mPassed.BusinessToChange.BusinessPoBoxAddressList != null && a != null)
                    for (int i = 0; i < mPassed.BusinessToChange.BusinessPoBoxAddressList.Count; i++)
                    {
                        if (mPassed.BusinessToChange.BusinessPoBoxAddressList[i].AddressDescription == a.AddressDescription && mPassed.BusinessToChange.BusinessPoBoxAddressList[i].AddressDescription != mPassed.AddressToChange.AddressDescription) return false;
                    }

            if (mPassed != null && mPassed.CustomerToChange != null && mPassed.CustomerToChange.CustomerPoBoxAddress != null)
                if (mPassed.CustomerToChange.CustomerPoBoxAddress != null && a != null)
                    for (int i = 0; i < mPassed.CustomerToChange.CustomerPoBoxAddress.Count; i++)
                    {
                        if (mPassed.CustomerToChange.CustomerPoBoxAddress[i].AddressDescription == a.AddressDescription && mPassed.CustomerToChange.CustomerPoBoxAddress[i].AddressDescription != mPassed.AddressToChange.AddressDescription) return false;
                    }
            return false;
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmEditBusinessAddress_FormClosing(object sender, FormClosingEventArgs e)
        {
            QuoteSwiftMainCode.CloseApplication(true);
        }
    }
}
