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
    public partial class FrmViewPOBoxAddresses : Form
    {

        Pass passed;

        public ref Pass Passed { get => ref passed; }

        public FrmViewPOBoxAddresses(ref Pass passed)
        {
            InitializeComponent();
            this.passed = passed;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainProgramCode.CloseApplication(MainProgramCode.RequestConfirmation("Are you sure you want to close the application?\nAny unsaved work will be lost.", "REQUEST - Application Termination"), ref this.passed);
        }

        private void BtnRemoveAddress_Click(object sender, EventArgs e)
        {
            Address SelectedAddress = GetAddressSelection();
            if (SelectedAddress != null)
            {
                if (MainProgramCode.RequestConfirmation("Are you sure you want to permanently delete '" + SelectedAddress.AddressDescription + "' address from the list?", "REQUEST - Deletion Request"))
                {
                    passed.BusinessToChange.BusinessPOBoxAddressList.Remove(SelectedAddress);
                    MainProgramCode.ShowInformation("Successfully deleted '" + SelectedAddress.AddressDescription + "' from the address list", "CONFIRMATION - Deletion Success");

                    if (passed.BusinessToChange.BusinessPOBoxAddressList.Count == 0) passed.BusinessToChange.BusinessPOBoxAddressList = null;

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
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancelation can cause any changes to be lost.", "REQUEST - Cancelation")) this.Close();
        }

        private void BtnChangeAddressInfo_Click(object sender, EventArgs e)
        {
            Address address = GetAddressSelection();
            this.passed.AddressToChange = address;
            this.passed = MainProgramCode.EditBusinessAddress(ref this.passed);

            if (passed.BusinessToChange != null && passed.BusinessToChange.BusinessPOBoxAddressList != null)
            {
                for (int i = 0; i < passed.BusinessToChange.BusinessPOBoxAddressList.Count; i++)
                {
                    if (passed.BusinessToChange.BusinessPOBoxAddressList[i] == address)
                    {
                        passed.BusinessToChange.BusinessPOBoxAddressList[i] = this.passed.AddressToChange;
                    }
                }
            }

            this.passed.AddressToChange = null;
            LoadInformation();
        }

        private void FrmViewPOBoxAddresses_Load(object sender, EventArgs e)
        {
            if (passed != null && passed.BusinessToChange != null && passed.BusinessToChange.BusinessPOBoxAddressList != null)
            {
                this.Text = this.Text.Replace("<<Business name>>", passed.BusinessToChange.BusinessName);

                LoadInformation();
            }
        }

        private void DgvPOBoxAddresses_Leave(object sender, EventArgs e)
        {
            if (ChangesMade())
                if (MainProgramCode.RequestConfirmation("Changes were made to the P.O.Box Address List.\nWould you like to save these changes?", "REQUEST - Store Changed P.O.Box Addresses"))
                    StoreChanges();
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

            if (passed.BusinessToChange != null && passed.BusinessToChange.BusinessPOBoxAddressList != null)
            {
                SelectedAddress = passed.BusinessToChange.BusinessPOBoxAddressList.SingleOrDefault(p => p.AddressDescription == SearchName);
                return SelectedAddress;
            }

            return null;
        }

        void LoadInformation()
        {
            dgvPOBoxAddresses.Rows.Clear();
            if (passed != null && passed.BusinessToChange.BusinessPOBoxAddressList != null)
            for (int i = 0; i < passed.BusinessToChange.BusinessPOBoxAddressList.Count; i++)
                dgvPOBoxAddresses.Rows.Add(passed.BusinessToChange.BusinessPOBoxAddressList[i].AddressDescription, passed.BusinessToChange.BusinessPOBoxAddressList[i].AddressStreetNumber,
                                                     passed.BusinessToChange.BusinessPOBoxAddressList[i].AddressStreetName, passed.BusinessToChange.BusinessPOBoxAddressList[i].AddressSuburb,
                                                     passed.BusinessToChange.BusinessPOBoxAddressList[i].AddressCity, passed.BusinessToChange.BusinessPOBoxAddressList[i].AddressAreaCode);
        }

        private bool ChangesMade()
        {
            if (passed.BusinessToChange.BusinessPOBoxAddressList != null)
                for (int i = 0; i < passed.BusinessToChange.BusinessPOBoxAddressList.Count ; i++)
                {
                    if (passed.BusinessToChange.BusinessPOBoxAddressList[i].AddressDescription != dgvPOBoxAddresses.Rows[i].Cells[0].Value.ToString()) return true;
                    if (passed.BusinessToChange.BusinessPOBoxAddressList[i].AddressStreetNumber != MainProgramCode.ParseInt(dgvPOBoxAddresses.Rows[i].Cells[1].Value.ToString())) return true;
                    if (passed.BusinessToChange.BusinessPOBoxAddressList[i].AddressStreetName != dgvPOBoxAddresses.Rows[i].Cells[2].Value.ToString()) return true;
                    if (passed.BusinessToChange.BusinessPOBoxAddressList[i].AddressSuburb != dgvPOBoxAddresses.Rows[i].Cells[3].Value.ToString()) return true;
                    if (passed.BusinessToChange.BusinessPOBoxAddressList[i].AddressSuburb != dgvPOBoxAddresses.Rows[i].Cells[4].Value.ToString()) return true;
                    if (passed.BusinessToChange.BusinessPOBoxAddressList[i].AddressAreaCode != MainProgramCode.ParseInt(dgvPOBoxAddresses.Rows[i].Cells[5].Value.ToString())) return true;
                }

            return false;
        }

        private void StoreChanges()
        {
            if (passed.BusinessToChange.BusinessPOBoxAddressList != null)
            {
                for (int i = 0; i < passed.BusinessToChange.BusinessPOBoxAddressList.Count; i++)
                {
                    passed.BusinessToChange.BusinessPOBoxAddressList[i].AddressDescription = dgvPOBoxAddresses.Rows[i].Cells[0].Value.ToString();
                    passed.BusinessToChange.BusinessPOBoxAddressList[i].AddressStreetNumber = MainProgramCode.ParseInt(dgvPOBoxAddresses.Rows[i].Cells[1].Value.ToString());
                    passed.BusinessToChange.BusinessPOBoxAddressList[i].AddressStreetName = dgvPOBoxAddresses.Rows[i].Cells[2].Value.ToString();
                    passed.BusinessToChange.BusinessPOBoxAddressList[i].AddressSuburb = dgvPOBoxAddresses.Rows[i].Cells[3].Value.ToString();
                    passed.BusinessToChange.BusinessPOBoxAddressList[i].AddressSuburb = dgvPOBoxAddresses.Rows[i].Cells[4].Value.ToString();
                    passed.BusinessToChange.BusinessPOBoxAddressList[i].AddressAreaCode = MainProgramCode.ParseInt(dgvPOBoxAddresses.Rows[i].Cells[5].Value.ToString());

                }
                MainProgramCode.ShowInformation("The changes were successfully stored", "INFORMATION - Changes Successfully Stored");
                LoadInformation();
            }
        }


        /**********************************************************************************/
    }
}
