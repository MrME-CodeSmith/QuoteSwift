using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmViewBusinessAddresses : Form
    {

        Pass passed;

        public ref Pass Passed { get => ref passed; }

        public FrmViewBusinessAddresses(ref Pass passed)
        {
            InitializeComponent();
            this.passed = passed;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                MainProgramCode.CloseApplication(true, ref passed);
        }

        private void FrmViewBusinessAddresses_Load(object sender, EventArgs e)
        {
            if (passed != null && passed.BusinessToChange != null && passed.BusinessToChange.BusinessAddressList != null) // View Business Address
            {
                Text = Text.Replace("<<Business name>>", passed.BusinessToChange.BusinessName);

                if (!passed.ChangeSpecificObject)
                {
                    QuoteSwiftMainCode.ReadOnlyComponents(Controls);
                    BtnCancel.Enabled = true;
                }

                LoadInformation();
            }
            else if (passed != null && passed.CustomerToChange != null && passed.CustomerToChange.CustomerDeliveryAddressList != null) //View Customer Address
            {
                Text = Text.Replace("<<Business name>>", passed.CustomerToChange.CustomerName);

                if (!passed.ChangeSpecificObject)
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

            passed.AddressToChange = address;
            passed.ChangeSpecificObject = false;

            passed = QuoteSwiftMainCode.EditBusinessAddress(ref passed);

            if (!ReplacePOBoxAddress(address, passed.AddressToChange)) MainProgramCode.ShowError("An error occurred during the updating procedure of the Address.\nUpdated address will not be stored.", "ERROR - Address Not Updated");

            passed.AddressToChange = null;
            passed.ChangeSpecificObject = false;

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
                    if (passed.BusinessToChange != null && passed.CustomerToChange == null)
                    {
                        passed.BusinessToChange.RemoveAddress(SelectedAddress);
                        MainProgramCode.ShowInformation("Successfully deleted '" + SelectedAddress.AddressDescription + "' from the address list", "CONFIRMATION - Deletion Success");
                    }
                    else if (passed.CustomerToChange != null)
                    {
                        passed.CustomerToChange.RemoveDeliveryAddress(SelectedAddress);
                        MainProgramCode.ShowInformation("Successfully deleted '" + SelectedAddress.AddressDescription + "' from the address list", "CONFIRMATION - Deletion Success");
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
            if (DgvViewAllBusinessAddresses.CurrentCell == null || DgvViewAllBusinessAddresses.CurrentRow == null)
                return null;

            int iGridSelection = DgvViewAllBusinessAddresses.CurrentCell.RowIndex;
            if (iGridSelection < 0 || iGridSelection >= DgvViewAllBusinessAddresses.Rows.Count)
                return null;

            string SearchName = DgvViewAllBusinessAddresses.Rows[iGridSelection].Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(SearchName))
                return null;

            if (passed != null && passed.BusinessToChange != null && passed.BusinessToChange.BusinessAddressList != null)
            {
                return passed.BusinessToChange.BusinessAddressList.SingleOrDefault(p => p.AddressDescription == SearchName);
            }
            else if (passed != null && passed.CustomerToChange != null && passed.CustomerToChange.CustomerDeliveryAddressList != null)
            {
                return passed.CustomerToChange.CustomerDeliveryAddressList.SingleOrDefault(p => p.AddressDescription == SearchName);
            }

            return null;
        }

        private void LoadInformation()
        {
            DgvViewAllBusinessAddresses.Rows.Clear();
            if (passed != null && passed.BusinessToChange != null && passed.BusinessToChange.BusinessAddressList != null)
                for (int i = 0; i < passed.BusinessToChange.BusinessAddressList.Count; i++)
                    DgvViewAllBusinessAddresses.Rows.Add(passed.BusinessToChange.BusinessAddressList[i].AddressDescription, passed.BusinessToChange.BusinessAddressList[i].AddressStreetNumber,
                                                         passed.BusinessToChange.BusinessAddressList[i].AddressStreetName, passed.BusinessToChange.BusinessAddressList[i].AddressSuburb,
                                                         passed.BusinessToChange.BusinessAddressList[i].AddressCity, passed.BusinessToChange.BusinessAddressList[i].AddressAreaCode);

            if (passed != null && passed.CustomerToChange != null && passed.CustomerToChange.CustomerDeliveryAddressList != null)
                for (int i = 0; i < passed.CustomerToChange.CustomerDeliveryAddressList.Count; i++)
                    DgvViewAllBusinessAddresses.Rows.Add(passed.CustomerToChange.CustomerDeliveryAddressList[i].AddressDescription, passed.CustomerToChange.CustomerDeliveryAddressList[i].AddressStreetNumber,
                                                         passed.CustomerToChange.CustomerDeliveryAddressList[i].AddressStreetName, passed.CustomerToChange.CustomerDeliveryAddressList[i].AddressSuburb,
                                                         passed.CustomerToChange.CustomerDeliveryAddressList[i].AddressCity, passed.CustomerToChange.CustomerDeliveryAddressList[i].AddressAreaCode);
        }

        private bool ReplacePOBoxAddress(Address Original, Address New)
        {
            if (passed != null && passed.BusinessToChange != null)
            {
                passed.BusinessToChange.UpdateAddress(Original, New);
                return true;
            }

            if (passed != null && passed.CustomerToChange != null)
            {
                passed.CustomerToChange.UpdateDeliveryAddress(Original, New);
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
            MainProgramCode.CloseApplication(true, ref passed);
        }


        /**********************************************************************************/
    }
}
