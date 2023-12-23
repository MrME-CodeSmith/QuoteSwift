using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmViewBusinessAddresses : Form
    {

        AppContext mPassed;

        public ref AppContext Passed { get => ref mPassed; }

        public FrmViewBusinessAddresses()
        {
            InitializeComponent();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                QuoteSwiftMainCode.CloseApplication(true);
        }

        private void FrmViewBusinessAddresses_Load(object sender, EventArgs e)
        {
            if (mPassed != null && mPassed.BusinessToChange != null && mPassed.BusinessToChange.BusinessAddressList != null) // View Business Address
            {
                Text = Text.Replace("<<Business name>>", mPassed.BusinessToChange.BusinessName);

                if (!mPassed.ChangeSpecificObject)
                {
                    QuoteSwiftMainCode.ReadOnlyComponents(Controls);
                    BtnCancel.Enabled = true;
                }

                LoadInformation();
            }
            else if (mPassed != null && mPassed.CustomerToChange != null && mPassed.CustomerToChange.CustomerDeliveryAddressList != null) //View Customer Address
            {
                Text = Text.Replace("<<Business name>>", mPassed.CustomerToChange.CustomerName);

                if (!mPassed.ChangeSpecificObject)
                {
                    QuoteSwiftMainCode.ReadOnlyComponents(Controls);
                    BtnCancel.Enabled = true;
                }

                LoadInformation();
            }

            DgvViewAllBusinessAddresses.RowsDefaultCellStyle.BackColor = Color.Bisque;
            DgvViewAllBusinessAddresses.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }

        private void BtnChangeAddressInfo_Click(object sender, EventArgs e)
        {
            Address address = GetAddressSelection();

            if (address == null)
            {
                MainProgramCode.ShowError("Please select a valid Business Address, the current selection is invalid", "ERROR - Invalid Address Selection");
                return;
            }

            mPassed.AddressToChange = address;
            mPassed.ChangeSpecificObject = false;

            QuoteSwiftMainCode.EditBusinessAddress();

            if (!ReplacePoBoxAddress(address, mPassed.AddressToChange)) MainProgramCode.ShowError("An error occurred during the updating procedure of the Address.\nUpdated address will not be stored.", "ERROR - Address Not Updated");

            mPassed.AddressToChange = null;
            mPassed.ChangeSpecificObject = false;

            LoadInformation();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancellation can cause any changes to be lost.", "REQUEST - Cancellation")) Close();
        }

        private void BtnRemoveSelected_Click(object sender, EventArgs e)
        {
            Address SelectedAddress = GetAddressSelection();
            if (SelectedAddress != null)
            {
                if (MainProgramCode.RequestConfirmation("Are you sure you want to permanently delete '" + SelectedAddress.AddressDescription + "' address from the list?", "REQUEST - Deletion Request"))
                {
                    if (mPassed.BusinessToChange != null && mPassed.CustomerToChange == null)
                    {
                        mPassed.BusinessToChange.BusinessAddressList.Remove(SelectedAddress);
                        MainProgramCode.ShowInformation("Successfully deleted '" + SelectedAddress.AddressDescription + "' from the address list", "CONFIRMATION - Deletion Success");
                        if (mPassed.BusinessToChange.BusinessAddressList.Count == 0) mPassed.BusinessToChange.BusinessAddressList = null;
                    }
                    else if (mPassed.BusinessToChange == null && mPassed.CustomerToChange != null)
                    {
                        mPassed.CustomerToChange.CustomerDeliveryAddressList.Remove(SelectedAddress);
                        MainProgramCode.ShowInformation("Successfully deleted '" + SelectedAddress.AddressDescription + "' from the address list", "CONFIRMATION - Deletion Success");
                        if (mPassed.CustomerToChange.CustomerDeliveryAddressList.Count == 0) mPassed.CustomerToChange.CustomerDeliveryAddressList = null;
                    }

                    LoadInformation();
                }
            }
            else
            {
                MainProgramCode.ShowError("The current selection is invalid.\nPlease choose a valid address from the list.", "ERROR - Invalid Selection");
            }
        }

        /** Form Specific Functions And Procedures: 
        *
        * Note: Not all Functions or Procedures below are used more than once
        *       Some of them are only to keep the above events readable 
        *       and clutter free.                                                          
        */

        Address GetAddressSelection()
        {
            Address SelectedAddress;
            string SearchName;
            int iGridSelection = DgvViewAllBusinessAddresses.CurrentCell.RowIndex;
            try
            {
                SearchName = DgvViewAllBusinessAddresses.Rows[iGridSelection].Cells[0].Value.ToString();
            }
            catch
            {
                return null;
            }

            if (mPassed != null && mPassed.BusinessToChange != null && mPassed.BusinessToChange.BusinessAddressList != null)
            {
                SelectedAddress = mPassed.BusinessToChange.BusinessAddressList.SingleOrDefault(p => p.AddressDescription == SearchName);
                return SelectedAddress;
            }
            else if (mPassed != null && mPassed.CustomerToChange != null && mPassed.CustomerToChange.CustomerDeliveryAddressList != null)
            {
                SelectedAddress = mPassed.CustomerToChange.CustomerDeliveryAddressList.SingleOrDefault(p => p.AddressDescription == SearchName);
                return SelectedAddress;
            }

            return null;
        }

        private void LoadInformation()
        {
            DgvViewAllBusinessAddresses.Rows.Clear();
            if (mPassed != null && mPassed.BusinessToChange != null && mPassed.BusinessToChange.BusinessAddressList != null)
                for (int i = 0; i < mPassed.BusinessToChange.BusinessAddressList.Count; i++)
                    DgvViewAllBusinessAddresses.Rows.Add(mPassed.BusinessToChange.BusinessAddressList[i].AddressDescription, mPassed.BusinessToChange.BusinessAddressList[i].AddressStreetNumber,
                                                         mPassed.BusinessToChange.BusinessAddressList[i].AddressStreetName, mPassed.BusinessToChange.BusinessAddressList[i].AddressSuburb,
                                                         mPassed.BusinessToChange.BusinessAddressList[i].AddressCity, mPassed.BusinessToChange.BusinessAddressList[i].AddressAreaCode);

            if (mPassed != null && mPassed.CustomerToChange != null && mPassed.CustomerToChange.CustomerDeliveryAddressList != null)
                for (int i = 0; i < mPassed.CustomerToChange.CustomerDeliveryAddressList.Count; i++)
                    DgvViewAllBusinessAddresses.Rows.Add(mPassed.CustomerToChange.CustomerDeliveryAddressList[i].AddressDescription, mPassed.CustomerToChange.CustomerDeliveryAddressList[i].AddressStreetNumber,
                                                         mPassed.CustomerToChange.CustomerDeliveryAddressList[i].AddressStreetName, mPassed.CustomerToChange.CustomerDeliveryAddressList[i].AddressSuburb,
                                                         mPassed.CustomerToChange.CustomerDeliveryAddressList[i].AddressCity, mPassed.CustomerToChange.CustomerDeliveryAddressList[i].AddressAreaCode);
        }

        private bool ReplacePoBoxAddress(Address original, Address @new)
        {
            if (mPassed != null && mPassed.BusinessToChange != null)
                if (@new != null && original != null && mPassed.BusinessToChange.BusinessAddressList != null)
                    for (int i = 0; i < mPassed.BusinessToChange.BusinessAddressList.Count; i++)
                        if (mPassed.BusinessToChange.BusinessAddressList[i] == original)
                        {
                            mPassed.BusinessToChange.BusinessAddressList[i] = @new;
                            return true;
                        }

            if (mPassed != null && mPassed.CustomerToChange != null)
                if (@new != null && original != null && mPassed.CustomerToChange.CustomerDeliveryAddressList != null)
                    for (int i = 0; i < mPassed.CustomerToChange.CustomerDeliveryAddressList.Count; i++)
                        if (mPassed.CustomerToChange.CustomerDeliveryAddressList[i] == original)
                        {
                            mPassed.CustomerToChange.CustomerDeliveryAddressList[i] = @new;
                            return true;
                        }

            return false;
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmViewBusinessAddresses_FormClosing(object sender, FormClosingEventArgs e)
        {
            QuoteSwiftMainCode.CloseApplication(true);
        }


        /**********************************************************************************/
    }
}
