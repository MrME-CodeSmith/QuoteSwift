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
    public partial class FrmEditBusinessAddress : Form
    {
        Pass passed;

        public ref Pass Passed { get => ref passed; }

        public FrmEditBusinessAddress(ref Pass passed)
        {
            InitializeComponent();
            this.passed = passed;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancelation can cause any changes to be lost.", "REQUEST - Cancelation")) this.Close();
        }

        private void FrmEditBusinessAddress_Load(object sender, EventArgs e)
        {
            if(passed.AddressToChange != null)
            {
                txtBusinessAddresssDescription.Text = passed.AddressToChange.AddressDescription;
                mtxtStreetnumber.Text = passed.AddressToChange.AddressStreetNumber.ToString();
                txtStreetName.Text = passed.AddressToChange.AddressStreetName;
                txtSuburb.Text = passed.AddressToChange.AddressSuburb;
                txtCity.Text = passed.AddressToChange.AddressCity;
                mtxtAreaCode.Text = passed.AddressToChange.AddressAreaCode.ToString();
            }
        }

        private void BtnAddAddress_Click(object sender, EventArgs e)
        {
            if(ValidInput())
            {
                passed.AddressToChange.AddressDescription = txtBusinessAddresssDescription.Text;
                passed.AddressToChange.AddressStreetNumber = MainProgramCode.ParseInt(mtxtStreetnumber.Text);
                passed.AddressToChange.AddressStreetName = txtStreetName.Text;
                passed.AddressToChange.AddressSuburb = txtSuburb.Text;
                passed.AddressToChange.AddressCity = txtCity.Text;
                passed.AddressToChange.AddressAreaCode = MainProgramCode.ParseInt(mtxtAreaCode.Text);

                if (passed.BusinessToChange.BusinessAddressList.SingleOrDefault(p => p.AddressDescription == passed.AddressToChange.AddressDescription) == null)
                {
                    MainProgramCode.ShowInformation("The address has been successfully updated", "INFORMATION - Address Successfully Updated");
                    this.Close();
                }
                else MainProgramCode.ShowError("Address not updated since this address is already in the list of addresses.\nNOTE: Address Description should be unique.", "ERROR - Address Already Added");

            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainProgramCode.CloseApplication(MainProgramCode.RequestConfirmation("Are you sure you want to close the application?\nAny unsaved work will be lost.", "REQUEST - Application Termination"), ref this.passed);
        }

        bool ValidInput()
        {
            if (txtBusinessAddresssDescription.Text.Length < 2)
            {
                MainProgramCode.ShowError("The provided Business Address Description is invalid, please provide a valid description", "ERROR - Invalid Business Address Description");
                return (false);
            }

            if (MainProgramCode.ParseInt(mtxtStreetnumber.Text) == 0)
            {
                MainProgramCode.ShowError("The provided Business Address Street Number is invalid, please provide a valid street number", "ERROR - Invalid Business Address Street Number");
                return (false);
            }

            if (txtStreetName.Text.Length < 2)
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

            if (MainProgramCode.ParseInt(mtxtAreaCode.Text) == 0)
            {
                MainProgramCode.ShowError("The provided Business Address Area Code is invalid, please provide a valid area code", "ERROR - Invalid Business Address Area Code");
                return (false);
            }

            return true;
        }

    }
}