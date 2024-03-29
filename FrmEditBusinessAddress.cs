﻿using System;
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
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancellation can cause any changes to be lost.", "REQUEST - Cancellation")) Close();
        }

        private void FrmEditBusinessAddress_Load(object sender, EventArgs e)
        {
            if (passed.AddressToChange != null)
            {
                txtBusinessAddresssDescription.Text = passed.AddressToChange.AddressDescription;
                mtxtStreetnumber.Text = passed.AddressToChange.AddressStreetNumber.ToString();
                txtStreetName.Text = passed.AddressToChange.AddressStreetName;
                txtSuburb.Text = passed.AddressToChange.AddressSuburb;
                txtCity.Text = passed.AddressToChange.AddressCity;
                mtxtAreaCode.Text = passed.AddressToChange.AddressAreaCode.ToString();
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
                    passed.AddressToChange = UpdatedAddress;
                    MainProgramCode.ShowInformation("The address has been successfully updated", "INFORMATION - Address Successfully Updated");
                    Close();
                }
                else MainProgramCode.ShowError("Address not updated since this address is already in the list of addresses.\nNOTE: Address Description should be unique.", "ERROR - Address Already Added");
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                QuoteSwiftMainCode.CloseApplication(true, ref passed);
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

            if (txtStreetName.Text.Length < 2 && passed.AddressToChange == null)
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
            if (passed != null && passed.BusinessToChange != null && passed.BusinessToChange.BusinessPOBoxAddressList != null)
                if (passed.BusinessToChange.BusinessPOBoxAddressList != null && a != null)
                    for (int i = 0; i < passed.BusinessToChange.BusinessPOBoxAddressList.Count; i++)
                    {
                        if (passed.BusinessToChange.BusinessPOBoxAddressList[i].AddressDescription == a.AddressDescription && passed.BusinessToChange.BusinessPOBoxAddressList[i].AddressDescription != passed.AddressToChange.AddressDescription) return false;
                    }

            if (passed != null && passed.CustomerToChange != null && passed.CustomerToChange.CustomerPOBoxAddress != null)
                if (passed.CustomerToChange.CustomerPOBoxAddress != null && a != null)
                    for (int i = 0; i < passed.CustomerToChange.CustomerPOBoxAddress.Count; i++)
                    {
                        if (passed.CustomerToChange.CustomerPOBoxAddress[i].AddressDescription == a.AddressDescription && passed.CustomerToChange.CustomerPOBoxAddress[i].AddressDescription != passed.AddressToChange.AddressDescription) return false;
                    }
            return false;
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmEditBusinessAddress_FormClosing(object sender, FormClosingEventArgs e)
        {
            QuoteSwiftMainCode.CloseApplication(true, ref passed);
        }
    }
}
