using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MainProgramLibrary;
using ToastNotifications;
using ToastNotifications.Position;
using System.Net.Http;
using QuoteSwift.Controllers;

namespace QuoteSwift
{
    public partial class FrmViewPoBoxAddresses : Form
    {

        AppContext passed;

        public ref AppContext Passed { get => ref passed; }

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
                    if (passed.BusinessToChange != null && passed.BusinessToChange.BusinessPoBoxAddressList != null)
                    {
                        passed.BusinessToChange.BusinessPoBoxAddressList.Remove(SelectedAddress);
                        MainProgramCode.ShowInformation("Successfully deleted '" + SelectedAddress.AddressDescription + "' from the address list", "CONFIRMATION - Deletion Success");
                        if (passed.BusinessToChange.BusinessPoBoxAddressList.Count == 0) passed.BusinessToChange.BusinessPoBoxAddressList = null;
                    }
                    else if (passed.CustomerToChange != null && passed.CustomerToChange.CustomerPoBoxAddress != null)
                    {
                        passed.CustomerToChange.CustomerPoBoxAddress.Remove(SelectedAddress);
                        MainProgramCode.ShowInformation("Successfully deleted '" + SelectedAddress.AddressDescription + "' from the address list", "CONFIRMATION - Deletion Success");
                        if (passed.CustomerToChange.CustomerPoBoxAddress.Count == 0) passed.CustomerToChange.CustomerPoBoxAddress = null;
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

            passed.ChangeSpecificObject = false;
            passed.AddressToChange = address;

            //if (passed != null && passed.BusinessToChange != null && passed.BusinessToChange.BusinessPoBoxAddressList != null)
            QuoteSwiftMainCode.EditBusinessAddress();

            if (!ReplacePOBoxAddress(address, passed.AddressToChange)) MainProgramCode.ShowError("An error occurred during the updating procedure of the P.O.Box Address.\nUpdated P.O.Box address will not be stored.", "ERROR - P.O.Box Address Not Updated");

            passed.AddressToChange = null;
            passed.ChangeSpecificObject = false;

            LoadInformation();
        }

        private void FrmViewPOBoxAddresses_Load(object sender, EventArgs e)
        {
            if (passed != null && passed.BusinessToChange != null && passed.BusinessToChange.BusinessPoBoxAddressList != null)
            {
                Text = Text.Replace("<<Business name>>", passed.BusinessToChange.BusinessName);

                if (!passed.ChangeSpecificObject)
                {
                    QuoteSwiftMainCode.ReadOnlyComponents(Controls);
                    BtnCancel.Enabled = true;
                }

                LoadInformation();
            }
            else if (passed != null && passed.CustomerToChange != null && passed.CustomerToChange.CustomerPoBoxAddress != null)
            {
                Text = Text.Replace("<<Business name>>", passed.CustomerToChange.CustomerName);

                if (!passed.ChangeSpecificObject)
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

            if (passed != null && passed.BusinessToChange != null && passed.BusinessToChange.BusinessPoBoxAddressList != null)
            {
                SelectedAddress = passed.BusinessToChange.BusinessPoBoxAddressList.SingleOrDefault(p => p.AddressDescription == SearchName);
                return SelectedAddress;
            }
            else if (passed != null && passed.CustomerToChange != null && passed.CustomerToChange.CustomerPoBoxAddress != null)
            {
                SelectedAddress = passed.CustomerToChange.CustomerPoBoxAddress.SingleOrDefault(p => p.AddressDescription == SearchName);
                return SelectedAddress;
            }

            return null;
        }

        void LoadInformation()
        {
            dgvPOBoxAddresses.Rows.Clear();
            if (passed != null && passed.BusinessToChange != null && passed.BusinessToChange.BusinessPoBoxAddressList != null)
                for (int i = 0; i < passed.BusinessToChange.BusinessPoBoxAddressList.Count; i++)
                    dgvPOBoxAddresses.Rows.Add(passed.BusinessToChange.BusinessPoBoxAddressList[i].AddressDescription, passed.BusinessToChange.BusinessPoBoxAddressList[i].AddressStreetNumber,
                                                         passed.BusinessToChange.BusinessPoBoxAddressList[i].AddressSuburb, passed.BusinessToChange.BusinessPoBoxAddressList[i].AddressCity,
                                                         passed.BusinessToChange.BusinessPoBoxAddressList[i].AddressAreaCode);

            if (passed != null && passed.CustomerToChange != null && passed.CustomerToChange.CustomerPoBoxAddress != null)
                for (int i = 0; i < passed.CustomerToChange.CustomerPoBoxAddress.Count; i++)
                    dgvPOBoxAddresses.Rows.Add(passed.CustomerToChange.CustomerPoBoxAddress[i].AddressDescription, passed.CustomerToChange.CustomerPoBoxAddress[i].AddressStreetNumber,
                                                         passed.CustomerToChange.CustomerPoBoxAddress[i].AddressSuburb, passed.CustomerToChange.CustomerPoBoxAddress[i].AddressCity,
                                                         passed.CustomerToChange.CustomerPoBoxAddress[i].AddressAreaCode);
        }

        private bool ReplacePOBoxAddress(Address Original, Address New)
        {
            if (passed != null && passed.BusinessToChange != null)
                if (New != null && Original != null && passed.BusinessToChange.BusinessPoBoxAddressList != null)
                    for (int i = 0; i < passed.BusinessToChange.BusinessPoBoxAddressList.Count; i++)
                        if (passed.BusinessToChange.BusinessPoBoxAddressList[i] == Original)
                        {
                            passed.BusinessToChange.BusinessPoBoxAddressList[i] = New;
                            return true;
                        }

            if (passed != null && passed.CustomerToChange != null)
                if (New != null && Original != null && passed.CustomerToChange.CustomerPoBoxAddress != null)
                    for (int i = 0; i < passed.CustomerToChange.CustomerPoBoxAddress.Count; i++)
                        if (passed.CustomerToChange.CustomerPoBoxAddress[i] == Original)
                        {
                            passed.CustomerToChange.CustomerPoBoxAddress[i] = New;
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
