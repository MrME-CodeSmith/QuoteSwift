using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            MainProgramCode.CloseApplication(MainProgramCode.RequestConfirmation("Are you sure you want to close the application?\nAny unsaved work will be lost.", "REQUEST - Application Termination"), ref this.passed);
        }

        private void FrmViewBusinessAddresses_Load(object sender, EventArgs e)
        {
            if (passed != null && passed.BusinessToChange != null && passed.BusinessToChange.BusinessAddressList != null)
            {
                this.Text = this.Text.Replace("<<Business name>>", passed.BusinessToChange.BusinessName);

                if(!passed.ChangeSpecificObject)
                {
                    MainProgramCode.ReadOnlyComponents(this.Controls);
                    BtnCancel.Enabled = true;
                }

                LoadInformation();
            }
        }

        private void BtnChangeAddressInfo_Click(object sender, EventArgs e)
        {
            Address address = GetAddressSelection();

            if (address == null)
            {
                MainProgramCode.ShowError("Please select a valid Business Address, the current selection is invalid", "ERROR - Invalid Address Selection");
                return;
            }

            this.passed.AddressToChange = address;

            this.passed = MainProgramCode.EditBusinessAddress(ref this.passed);

            if (!ReplacePOBoxAddress(address, this.passed.AddressToChange)) MainProgramCode.ShowError("An error occured during the updating procedure of the Address.\nUpdated address will not be stored.", "ERROR - Address Not Updated");

            this.passed.AddressToChange = null;
            LoadInformation();
        }

            private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancelation can cause any changes to be lost.", "REQUEST - Cancelation")) this.Close();
        }

        private void BtnRemoveSelected_Click(object sender, EventArgs e)
        {
            Address SelectedAddress = GetAddressSelection();
            if (SelectedAddress != null)
            {
                if (MainProgramCode.RequestConfirmation("Are you sure you want to permanently delete '" + SelectedAddress.AddressDescription + "' address from the list?", "REQUEST - Deletion Request"))
                {
                    passed.BusinessToChange.BusinessAddressList.Remove(SelectedAddress);
                    MainProgramCode.ShowInformation("Successfully deleted '" + SelectedAddress.AddressDescription + "' from the address list", "CONFIRMATION - Deletion Success");

                    if (passed.BusinessToChange.BusinessAddressList.Count == 0) passed.BusinessToChange.BusinessAddressList = null;

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

            if (passed.BusinessToChange != null && passed.BusinessToChange.BusinessAddressList != null)
            {
                SelectedAddress = passed.BusinessToChange.BusinessAddressList.SingleOrDefault(p => p.AddressDescription == SearchName);
                return SelectedAddress;
            }

            return null;
        }

        private void LoadInformation()
        {
            DgvViewAllBusinessAddresses.Rows.Clear();
            if (passed.BusinessToChange.BusinessAddressList != null && passed.BusinessToChange.BusinessAddressList.Count > 0)
                for (int i = 0; i < passed.BusinessToChange.BusinessAddressList.Count; i++)
                    DgvViewAllBusinessAddresses.Rows.Add(passed.BusinessToChange.BusinessAddressList[i].AddressDescription, passed.BusinessToChange.BusinessAddressList[i].AddressStreetNumber,
                                                         passed.BusinessToChange.BusinessAddressList[i].AddressStreetName, passed.BusinessToChange.BusinessAddressList[i].AddressSuburb,
                                                         passed.BusinessToChange.BusinessAddressList[i].AddressCity, passed.BusinessToChange.BusinessAddressList[i].AddressAreaCode);
        }

        private bool ReplacePOBoxAddress(Address Original, Address New)
        {
            if (New != null && Original != null && this.passed.BusinessToChange.BusinessAddressList != null)
                for (int i = 0; i < this.passed.BusinessToChange.BusinessAddressList.Count; i++)
                    if (this.passed.BusinessToChange.BusinessAddressList[i] == Original)
                    {
                        this.passed.BusinessToChange.BusinessAddressList[i] = New;
                        return true;
                    }

            return false;
        }


        /**********************************************************************************/
    }
}
