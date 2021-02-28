﻿using System;
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
                    if (passed.BusinessToChange != null && passed.BusinessToChange.BusinessPOBoxAddressList != null)
                    {
                        passed.BusinessToChange.BusinessPOBoxAddressList.Remove(SelectedAddress);
                        MainProgramCode.ShowInformation("Successfully deleted '" + SelectedAddress.AddressDescription + "' from the address list", "CONFIRMATION - Deletion Success");
                        if (passed.BusinessToChange.BusinessPOBoxAddressList.Count == 0) passed.BusinessToChange.BusinessPOBoxAddressList = null;
                    }
                    else if(passed.CustomerToChange != null && passed.CustomerToChange.CustomerPOBoxAddress != null)
                    {
                        passed.CustomerToChange.CustomerPOBoxAddress.Remove(SelectedAddress);
                        MainProgramCode.ShowInformation("Successfully deleted '" + SelectedAddress.AddressDescription + "' from the address list", "CONFIRMATION - Deletion Success");
                        if (passed.CustomerToChange.CustomerPOBoxAddress.Count == 0) passed.CustomerToChange.CustomerPOBoxAddress = null;
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
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancelation can cause any changes to be lost.", "REQUEST - Cancelation")) this.Close();
        }

        private void BtnChangeAddressInfo_Click(object sender, EventArgs e)
        {
            Address address = GetAddressSelection();

            if (address == null)
            {
                MainProgramCode.ShowError("Please select a valid P.O.Box Address, the current selection is invalid", "ERROR - Invalid P.O.Box Address Selection");
                return;
            }

            this.passed.AddressToChange = address;

            //if (passed != null && passed.BusinessToChange != null && passed.BusinessToChange.BusinessPOBoxAddressList != null)
            this.passed = MainProgramCode.EditBusinessAddress(ref this.passed);

            if (!ReplacePOBoxAddress(address, this.passed.AddressToChange)) MainProgramCode.ShowError("An error occured during the updating procedure of the P.O.Box Address.\nUpdated P.O.Box address will not be stored.","ERROR - P.O.Box Address Not Updated");

            this.passed.AddressToChange = null;
            LoadInformation();
        }

        private void FrmViewPOBoxAddresses_Load(object sender, EventArgs e)
        {
            if (passed != null && passed.BusinessToChange != null && passed.BusinessToChange.BusinessPOBoxAddressList != null)
            {
                this.Text = this.Text.Replace("<<Business name>>", passed.BusinessToChange.BusinessName);

                if(!passed.ChangeSpecificObject)
                {
                    MainProgramCode.ReadOnlyComponents(this.Controls);
                    BtnCancel.Enabled = true;
                }

                LoadInformation();
            }
            else if(passed != null && passed.CustomerToChange != null && passed.CustomerToChange.CustomerPOBoxAddress != null)
            {
                this.Text = this.Text.Replace("<<Business name>>", passed.CustomerToChange.CustomerName);

                if (!passed.ChangeSpecificObject)
                {
                    MainProgramCode.ReadOnlyComponents(this.Controls);
                    BtnCancel.Enabled = true;
                }

                LoadInformation();
            }

            this.dgvPOBoxAddresses.RowsDefaultCellStyle.BackColor = Color.Bisque;
            this.dgvPOBoxAddresses.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
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

            if (passed != null && passed.BusinessToChange != null && passed.BusinessToChange.BusinessPOBoxAddressList != null)
            {
                SelectedAddress = passed.BusinessToChange.BusinessPOBoxAddressList.SingleOrDefault(p => p.AddressDescription == SearchName);
                return SelectedAddress;
            }
            else if (passed != null && passed.CustomerToChange != null && passed.CustomerToChange.CustomerPOBoxAddress != null)
            {
                SelectedAddress = passed.CustomerToChange.CustomerPOBoxAddress.SingleOrDefault(p => p.AddressDescription == SearchName);
                return SelectedAddress;
            }

            return null;
        }

        void LoadInformation()
        {
            dgvPOBoxAddresses.Rows.Clear();
            if (passed != null && passed.BusinessToChange != null && passed.BusinessToChange.BusinessPOBoxAddressList != null)
            for (int i = 0; i < passed.BusinessToChange.BusinessPOBoxAddressList.Count; i++)
                dgvPOBoxAddresses.Rows.Add(passed.BusinessToChange.BusinessPOBoxAddressList[i].AddressDescription, passed.BusinessToChange.BusinessPOBoxAddressList[i].AddressStreetNumber,
                                                     passed.BusinessToChange.BusinessPOBoxAddressList[i].AddressStreetName, passed.BusinessToChange.BusinessPOBoxAddressList[i].AddressSuburb,
                                                     passed.BusinessToChange.BusinessPOBoxAddressList[i].AddressCity, passed.BusinessToChange.BusinessPOBoxAddressList[i].AddressAreaCode);

            if (passed != null && passed.CustomerToChange != null && passed.CustomerToChange.CustomerPOBoxAddress != null)
                for (int i = 0; i < passed.CustomerToChange.CustomerPOBoxAddress.Count; i++)
                    dgvPOBoxAddresses.Rows.Add(passed.CustomerToChange.CustomerPOBoxAddress[i].AddressDescription, passed.CustomerToChange.CustomerPOBoxAddress[i].AddressStreetNumber,
                                                         passed.CustomerToChange.CustomerPOBoxAddress[i].AddressStreetName, passed.CustomerToChange.CustomerPOBoxAddress[i].AddressSuburb,
                                                         passed.CustomerToChange.CustomerPOBoxAddress[i].AddressCity, passed.CustomerToChange.CustomerPOBoxAddress[i].AddressAreaCode);
        }

        private bool ReplacePOBoxAddress(Address Original, Address New)
        {
            if(passed != null && passed.BusinessToChange != null)
                if (New != null && Original != null && this.passed.BusinessToChange.BusinessPOBoxAddressList != null)
                    for (int i = 0; i < this.passed.BusinessToChange.BusinessPOBoxAddressList.Count; i++)
                        if (this.passed.BusinessToChange.BusinessPOBoxAddressList[i] == Original)
                        {
                            this.passed.BusinessToChange.BusinessPOBoxAddressList[i] = New;
                            return true;
                        }

            if (passed != null && passed.CustomerToChange != null)
                if (New != null && Original != null && this.passed.CustomerToChange.CustomerPOBoxAddress != null)
                    for (int i = 0; i < this.passed.CustomerToChange.CustomerPOBoxAddress.Count; i++)
                        if (this.passed.CustomerToChange.CustomerPOBoxAddress[i] == Original)
                        {
                            this.passed.CustomerToChange.CustomerPOBoxAddress[i] = New;
                            return true;
                        }

            return false;
        }

        /**********************************************************************************/
    }
}
