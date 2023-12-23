using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmViewPoBoxAddresses : Form
    {

        AppContext mPassed;

        public ref AppContext Passed { get => ref mPassed; }

        public FrmViewPoBoxAddresses()
        {
            InitializeComponent();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                QuoteSwiftMainCode.CloseApplication(true);
        }

        private void BtnRemoveAddress_Click(object sender, EventArgs e)
        {
            Address SelectedAddress = GetAddressSelection();
            if (SelectedAddress != null)
            {
                if (MainProgramCode.RequestConfirmation("Are you sure you want to permanently delete '" + SelectedAddress.AddressDescription + "' address from the list?", "REQUEST - Deletion Request"))
                {
                    if (mPassed.BusinessToChange != null && mPassed.BusinessToChange.BusinessPoBoxAddressList != null)
                    {
                        mPassed.BusinessToChange.BusinessPoBoxAddressList.Remove(SelectedAddress);
                        MainProgramCode.ShowInformation("Successfully deleted '" + SelectedAddress.AddressDescription + "' from the address list", "CONFIRMATION - Deletion Success");
                        if (mPassed.BusinessToChange.BusinessPoBoxAddressList.Count == 0) mPassed.BusinessToChange.BusinessPoBoxAddressList = null;
                    }
                    else if (mPassed.CustomerToChange != null && mPassed.CustomerToChange.CustomerPoBoxAddress != null)
                    {
                        mPassed.CustomerToChange.CustomerPoBoxAddress.Remove(SelectedAddress);
                        MainProgramCode.ShowInformation("Successfully deleted '" + SelectedAddress.AddressDescription + "' from the address list", "CONFIRMATION - Deletion Success");
                        if (mPassed.CustomerToChange.CustomerPoBoxAddress.Count == 0) mPassed.CustomerToChange.CustomerPoBoxAddress = null;
                    }

                    LoadInformation();
                }
            }
            else
            {
                MainProgramCode.ShowError("The current selection is invalid.\nPlease choose a valid P.O.Box address from the list.", "ERROR - Invalid Selection");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancellation can cause any changes to be lost.", "REQUEST - Cancellation")) Close();
        }

        private void BtnChangeAddressInfo_Click(object sender, EventArgs e)
        {
            Address address = GetAddressSelection();

            if (address == null)
            {
                MainProgramCode.ShowError("Please select a valid P.O.Box Address, the current selection is invalid", "ERROR - Invalid P.O.Box Address Selection");
                return;
            }

            mPassed.ChangeSpecificObject = false;
            mPassed.AddressToChange = address;

            //if (passed != null && passed.BusinessToChange != null && passed.BusinessToChange.BusinessPOBoxAddressList != null)
            QuoteSwiftMainCode.EditBusinessAddress();

            if (!ReplacePoBoxAddress(address, mPassed.AddressToChange)) MainProgramCode.ShowError("An error occurred during the updating procedure of the P.O.Box Address.\nUpdated P.O.Box address will not be stored.", "ERROR - P.O.Box Address Not Updated");

            mPassed.AddressToChange = null;
            mPassed.ChangeSpecificObject = false;

            LoadInformation();
        }

        private void FrmViewPOBoxAddresses_Load(object sender, EventArgs e)
        {
            if (mPassed != null && mPassed.BusinessToChange != null && mPassed.BusinessToChange.BusinessPoBoxAddressList != null)
            {
                Text = Text.Replace("<<Business name>>", mPassed.BusinessToChange.BusinessName);

                if (!mPassed.ChangeSpecificObject)
                {
                    QuoteSwiftMainCode.ReadOnlyComponents(Controls);
                    BtnCancel.Enabled = true;
                }

                LoadInformation();
            }
            else if (mPassed != null && mPassed.CustomerToChange != null && mPassed.CustomerToChange.CustomerPoBoxAddress != null)
            {
                Text = Text.Replace("<<Business name>>", mPassed.CustomerToChange.CustomerName);

                if (!mPassed.ChangeSpecificObject)
                {
                    QuoteSwiftMainCode.ReadOnlyComponents(Controls);
                    BtnCancel.Enabled = true;
                }

                LoadInformation();
            }

            dgvPOBoxAddresses.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dgvPOBoxAddresses.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
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
            int iGridSelection = dgvPOBoxAddresses.CurrentCell.RowIndex;
            try
            {
                SearchName = dgvPOBoxAddresses.Rows[iGridSelection].Cells[0].Value.ToString();
            }
            catch
            {
                return null;
            }

            if (mPassed != null && mPassed.BusinessToChange != null && mPassed.BusinessToChange.BusinessPoBoxAddressList != null)
            {
                SelectedAddress = mPassed.BusinessToChange.BusinessPoBoxAddressList.SingleOrDefault(p => p.AddressDescription == SearchName);
                return SelectedAddress;
            }
            else if (mPassed != null && mPassed.CustomerToChange != null && mPassed.CustomerToChange.CustomerPoBoxAddress != null)
            {
                SelectedAddress = mPassed.CustomerToChange.CustomerPoBoxAddress.SingleOrDefault(p => p.AddressDescription == SearchName);
                return SelectedAddress;
            }

            return null;
        }

        void LoadInformation()
        {
            dgvPOBoxAddresses.Rows.Clear();
            if (mPassed != null && mPassed.BusinessToChange != null && mPassed.BusinessToChange.BusinessPoBoxAddressList != null)
                for (int i = 0; i < mPassed.BusinessToChange.BusinessPoBoxAddressList.Count; i++)
                    dgvPOBoxAddresses.Rows.Add(mPassed.BusinessToChange.BusinessPoBoxAddressList[i].AddressDescription, mPassed.BusinessToChange.BusinessPoBoxAddressList[i].AddressStreetNumber,
                                                         mPassed.BusinessToChange.BusinessPoBoxAddressList[i].AddressSuburb, mPassed.BusinessToChange.BusinessPoBoxAddressList[i].AddressCity,
                                                         mPassed.BusinessToChange.BusinessPoBoxAddressList[i].AddressAreaCode);

            if (mPassed != null && mPassed.CustomerToChange != null && mPassed.CustomerToChange.CustomerPoBoxAddress != null)
                for (int i = 0; i < mPassed.CustomerToChange.CustomerPoBoxAddress.Count; i++)
                    dgvPOBoxAddresses.Rows.Add(mPassed.CustomerToChange.CustomerPoBoxAddress[i].AddressDescription, mPassed.CustomerToChange.CustomerPoBoxAddress[i].AddressStreetNumber,
                                                         mPassed.CustomerToChange.CustomerPoBoxAddress[i].AddressSuburb, mPassed.CustomerToChange.CustomerPoBoxAddress[i].AddressCity,
                                                         mPassed.CustomerToChange.CustomerPoBoxAddress[i].AddressAreaCode);
        }

        private bool ReplacePoBoxAddress(Address original, Address @new)
        {
            if (mPassed != null && mPassed.BusinessToChange != null)
                if (@new != null && original != null && mPassed.BusinessToChange.BusinessPoBoxAddressList != null)
                    for (int i = 0; i < mPassed.BusinessToChange.BusinessPoBoxAddressList.Count; i++)
                        if (mPassed.BusinessToChange.BusinessPoBoxAddressList[i] == original)
                        {
                            mPassed.BusinessToChange.BusinessPoBoxAddressList[i] = @new;
                            return true;
                        }

            if (mPassed != null && mPassed.CustomerToChange != null)
                if (@new != null && original != null && mPassed.CustomerToChange.CustomerPoBoxAddress != null)
                    for (int i = 0; i < mPassed.CustomerToChange.CustomerPoBoxAddress.Count; i++)
                        if (mPassed.CustomerToChange.CustomerPoBoxAddress[i] == original)
                        {
                            mPassed.CustomerToChange.CustomerPoBoxAddress[i] = @new;
                            return true;
                        }

            return false;
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmViewPOBoxAddresses_FormClosing(object sender, FormClosingEventArgs e)
        {
            QuoteSwiftMainCode.CloseApplication(true);
        }

        /**********************************************************************************/
    }
}
