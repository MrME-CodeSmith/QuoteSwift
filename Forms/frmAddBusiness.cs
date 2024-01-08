using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using MainProgramLibrary;
using QuoteSwift.Models;

namespace QuoteSwift.Forms
{
    public partial class FrmAddBusiness : Form
    {

        AppContext mPassed;

        Business mBusiness;

        public FrmAddBusiness()
        {
            InitializeComponent();
            mBusiness = mPassed.BusinessToChange;
        }

        public ref AppContext Passed { get => ref mPassed; }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation(Messages.TerminationRequestText, Messages.TerminationRequestCaption))
                QuoteSwiftMainCode.CloseApplication(true);
        }

        private void BtnAddBusiness_Click(object sender, EventArgs e)
        {
            var ctx = Global.Context;
            if (
                ValidBusiness(
                    businessName: txtBusinessName.Text,
                    taxNumber: mtxtVATNumber.Text,
                    registrationNumber: mtxtRegistrationNumber.Text,
                    addressList: mBusiness.BusinessAddressList.ToList(),
                    poBoxAddressList: mBusiness.BusinessPoBoxAddressList.ToList(),
                    telephoneNumberList: mBusiness.BusinessTelephoneNumberList.ToList(),
                    cellPhoneNumberList: mBusiness.BusinessCellphoneNumberList.ToList(),
                    emailAddressList: mBusiness.BusinessEmailAddressList.ToList()
                ) && 
                !ctx.ChangeSpecificObject
            )
            {
                //Add Final Details to mBusiness object
                mBusiness.BusinessName = txtBusinessName.Text;
                mBusiness.BusinessExtraInformation = rtxtExtraInformation.Text;
                mBusiness.BusinessLegalDetails = new Legal(mtxtRegistrationNumber.Text, mtxtVATNumber.Text);

                try
                {
                    ctx.AddBusiness(ref mBusiness);
                }
                catch (FeedbackException Ex)
                {
                    if(true) 
                        MainProgramCode.ShowWarning(
                            Ex.Message,
                            Messages.TaskWarningInformationCaption
                        );
                    //return false;
                }
                catch (Exception)
                {
                    if (true)
                        MainProgramCode.ShowError(
                            Messages.TaskErrorInformationText,
                            Messages.TaskErrorInformationCaption
                        );
                    //return false;
                }

                ctx.BusinessToChange = null;
                ctx.ChangeSpecificObject = false;

                MainProgramCode.ShowInformation(Messages.AddConfirmationInformationText, Messages.AddConfirmationInformationCaption);

                ResetScreenInput();
            }
            else if (
                ValidBusiness(
                     businessName: txtBusinessName.Text,
                     taxNumber: mtxtVATNumber.Text,
                     registrationNumber: mtxtRegistrationNumber.Text,
                     addressList: mBusiness.BusinessAddressList.ToList(),
                     poBoxAddressList: mBusiness.BusinessPoBoxAddressList.ToList(),
                     telephoneNumberList: mBusiness.BusinessTelephoneNumberList.ToList(),
                     cellPhoneNumberList: mBusiness.BusinessCellphoneNumberList.ToList(),
                     emailAddressList: mBusiness.BusinessEmailAddressList.ToList()
                 ) 
                &&
                ctx.ChangeSpecificObject)
            {
                ctx.BusinessToChange.BusinessName = txtBusinessName.Text;
                ctx.BusinessToChange.BusinessExtraInformation = rtxtExtraInformation.Text;
                ctx.BusinessToChange.BusinessLegalDetails = new Legal(mtxtRegistrationNumber.Text, mtxtVATNumber.Text);

                MainProgramCode.ShowInformation(Messages.UpdateConfirmationInfoText, Messages.UpdateConfirmationInfoCaption);
                ConvertToViewOnly();
            }
        }

        private void BtnAddPOBoxAddress_Click(object sender, EventArgs e)
        {
            var poDescription = txtBusinessPODescription.Text.Trim();
            var poStreetNumber = mtxtPOBoxStreetNumber.Text.Trim();
            var poSuburb = txtPOBoxSuburb.Text.Trim();
            var poCity = txtPOBoxCity.Text.Trim();
            var poAreaCode = mtxtPOBoxAreaCode.Text.Trim();

            if (
                ValidBusinessPoBoxAddress(
                    businessPoDescription: poDescription,
                    businessPoStreetNumber: poStreetNumber,
                    businessPoSuburb: poSuburb,
                    businessPoCity: poCity,
                    businessPoAreaCode: poAreaCode
                )
            )
            {
                var address = new Address(
                    addressDescription: poDescription, 
                    addressStreetNumber: QuoteSwiftMainCode.ParseInt(poStreetNumber),
                    addressStreetName: "",
                    addressSuburb: poSuburb,
                    addressCity: poCity, 
                    addressAreaCode: QuoteSwiftMainCode.ParseInt(poAreaCode)
                );

                if (!PoBoxAddressExisting(address))
                {
                    if (mBusiness.BusinessPoBoxAddressList != null)
                    {
                        mBusiness.BusinessPoBoxAddressList.Add(address);
                        mBusiness.BusinessAddressMap.Add(address.AddressDescription.Trim(), address);
                    }
                    else mBusiness.BusinessPoBoxAddressList = new BindingList<Address>() { address };

                    MainProgramCode.ShowInformation(Messages.AddConfirmationInformationText, Messages.AddConfirmationInformationCaption);

                    ClearPoBoxAddressInput();
                }
            }
        }

        private void BtnAddAddress_Click(object sender, EventArgs e)
        {
            var businessAddressDescription = txtBusinessAddresssDescription.Text.Trim();
            var businessAddressStreetNumber = mtxtStreetnumber.Text.Trim();
            var businessAddressStreetName = txtStreetName.Text.Trim();
            var businessAddressSuburb = txtSuburb.Text.Trim();
            var businessAddressCity = txtCity.Text.Trim();
            var businessAddressAreaCode = mtxtAreaCode.Text.Trim();

            if (
                ValidBusinessAddress(
                    businessAddressDescription: businessAddressDescription,
                    businessAddressStreetNumber: businessAddressStreetNumber,
                    businessAddressStreetName: businessAddressStreetName,
                    businessAddressSuburb: businessAddressSuburb,
                    businessAddressCity: businessAddressCity,
                    businessAddressAreaCode: businessAddressAreaCode
                )
            )
            {
                Address address = new Address(
                    addressDescription: businessAddressDescription,
                    addressStreetNumber: QuoteSwiftMainCode.ParseInt(businessAddressStreetNumber),
                    addressStreetName: businessAddressStreetName,
                    addressSuburb: businessAddressSuburb,
                    addressCity: businessAddressCity,
                    addressAreaCode: QuoteSwiftMainCode.ParseInt(businessAddressAreaCode)
                );

                if (!AddressExisting(address))
                {
                    if (mBusiness.BusinessPoBoxAddressList != null)
                    {
                        mBusiness.BusinessAddressList.Add(address);
                        mBusiness.BusinessAddressMap.Add(address.AddressDescription.Trim(), address);
                    }
                    else mBusiness.BusinessAddressList = new BindingList<Address>() { address };

                    MainProgramCode.ShowInformation(Messages.AddConfirmationInformationText, Messages.AddConfirmationInformationCaption);

                    ClearBusinessAddressInput();
                }
            }
        }

        private void BtnAddNumber_Click(object sender, EventArgs e)
        {
            bool Added = false;
            if (mtxtTelephoneNumber.Text.Length < 10 && mtxtCellphoneNumber.Text.Length < 10)
            {
                MainProgramCode.ShowError("a Valid Phone Number/s were not provided, please provide at least one valid phone number.", "ERROR - Invalid Number/s Provided");
            }

            if (mtxtTelephoneNumber.Text.Length > 10 && !PhoneNumberExisting(mtxtTelephoneNumber.Text))
            {
                if (mBusiness.BusinessTelephoneNumberList == null)
                {
                    // Create new List
                    mBusiness.BusinessTelephoneNumberList = new BindingList<string> { mtxtTelephoneNumber.Text };
                    Added = true;
                }
                else // Add To List
                {
                    mBusiness.BusinessTelephoneNumberList.Add(mtxtTelephoneNumber.Text);
                    Added = true;
                }

                mtxtTelephoneNumber.ResetText();
            }

            if (mtxtCellphoneNumber.Text.Length > 10 && !PhoneNumberExisting(mtxtCellphoneNumber.Text))
            {
                if (mBusiness.BusinessCellphoneNumberList == null)
                {
                    // Create new List
                    mBusiness.BusinessCellphoneNumberList = new BindingList<string> { mtxtCellphoneNumber.Text };
                    Added = true;
                }
                else // Add To List
                {
                    mBusiness.BusinessCellphoneNumberList.Add(mtxtCellphoneNumber.Text);
                    Added = true;
                }

                mtxtCellphoneNumber.ResetText();
            }

            if (Added)
            {
                MainProgramCode.ShowInformation("Successfully added the business phone number/s", "INFORMATION - mBusiness Phone Number/s Added Successfully");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancellation can cause any changes to be lost.", "REQUEST - Cancellation")) Close();
        }

        private void BtnAddBusinessEmail_Click(object sender, EventArgs e)
        {
            if (mtxtEmail.Text.Length > 3 && mtxtEmail.Text.Contains("@"))
            {
                if (!EmailAddressExisting(mtxtEmail.Text))
                {
                    if (mBusiness.BusinessEmailAddressList == null)
                    {
                        //Create New List
                        mBusiness.BusinessEmailAddressList = new BindingList<string> { mtxtEmail.Text };
                        MainProgramCode.ShowInformation("Successfully added the business Email address", "INFORMATION - mBusiness Email Address Added Successfully");
                    }
                    else //Add To Existing List
                    {
                        mBusiness.BusinessEmailAddressList.Add(mtxtEmail.Text);
                        MainProgramCode.ShowInformation("Successfully added the business Email address", "INFORMATION - mBusiness Email Address Added Successfully");
                    }

                    mtxtEmail.ResetText();
                }
            }
            else MainProgramCode.ShowError("The provided Email Address is invalid. Please provide a valid Email Address", "ERROR - Invalid Email Address");
        }

        private void BtnViewEmailAddresses_Click(object sender, EventArgs e)
        {
            if (mBusiness.BusinessEmailAddressList != null)
            {
                mPassed.BusinessToChange = mBusiness;
                mPassed.ChangeSpecificObject = !updateBusinessInformationToolStripMenuItem.Enabled;

                Hide();
                QuoteSwiftMainCode.ViewBusinessesEmailAddresses();
                Show();

                mBusiness = mPassed.BusinessToChange;
                mPassed.BusinessToChange = null;
                mPassed.ChangeSpecificObject = false;

            }
            else MainProgramCode.ShowError("You need to first add an Email address before you can view the list of addresses.\nPlease add an address first", "ERROR - Can't View Non-Existing mBusiness Email Addresses");
        }

        private void BtnViewAddresses_Click(object sender, EventArgs e)
        {
            if (mBusiness.BusinessAddressList != null)
            {
                mPassed.BusinessToChange = mBusiness;
                mPassed.ChangeSpecificObject = !updateBusinessInformationToolStripMenuItem.Enabled;

                Hide();
                QuoteSwiftMainCode.ViewBusinessesAddresses();
                Show();

                mBusiness = mPassed.BusinessToChange;
                mPassed.BusinessToChange = null;
                mPassed.ChangeSpecificObject = false;
            }
            else MainProgramCode.ShowError("You need to first add an address before you can view the list of addresses.\nPlease add an address first", "ERROR - Can't View Non-Existing mBusiness Addresses");
        }

        private void BtnViewAllPOBoxAddresses_Click(object sender, EventArgs e)
        {
            if (mBusiness.BusinessPoBoxAddressList != null)
            {
                mPassed.BusinessToChange = mBusiness;
                mPassed.ChangeSpecificObject = !updateBusinessInformationToolStripMenuItem.Enabled;

                Hide();
                QuoteSwiftMainCode.ViewBusinessesPoBoxAddresses();
                Show();

                mBusiness = mPassed.BusinessToChange;
                mPassed.BusinessToChange = null;
                mPassed.ChangeSpecificObject = false;
            }
            else MainProgramCode.ShowError("You need to first add an P.O.Box address before you can view the list of addresses.\nPlease add an address first", "ERROR - Can't View Non-Existing mBusiness P.O.Box Addresses");
        }

        private void BtnViewAll_Click(object sender, EventArgs e)
        {
            if (mBusiness.BusinessTelephoneNumberList != null || mBusiness.BusinessCellphoneNumberList != null)
            {
                mPassed.BusinessToChange = mBusiness;
                mPassed.ChangeSpecificObject = !updateBusinessInformationToolStripMenuItem.Enabled;

                Hide();
                QuoteSwiftMainCode.ViewBusinessesPhoneNumbers();
                Show();

                mBusiness = mPassed.BusinessToChange;
                mPassed.BusinessToChange = null;
                mPassed.ChangeSpecificObject = false;
            }
            else MainProgramCode.ShowError("You need to first add at least one phone number before you can view the list of phone numbers.\nPlease add a phone number first", "ERROR - Can't View Non-Existing mBusiness Phone Numbers");
        }

        private void FrmAddBusiness_Load(object sender, EventArgs e)
        {
            if (mPassed.BusinessToChange != null && mPassed.ChangeSpecificObject) // Change Existing mBusiness Info
            {
                mBusiness = mPassed.BusinessToChange;
            }
            else if (mPassed.BusinessToChange != null && !mPassed.ChangeSpecificObject) // View Existing mBusiness Info
            {
                mBusiness = mPassed.BusinessToChange;
                ConvertToViewOnly();
                LoadInformation();
            }
            else if (mPassed.BusinessToChange == null && !mPassed.ChangeSpecificObject) // Add New mBusiness Info
            {
                mBusiness = new Business();
            }
            else // Undefined Use - Show ERROR
            {
                MainProgramCode.ShowError("The form was activated without the correct parameters to have an achievable goal.\nThe Form's input parameters will be disabled to avoid possible data corruption.", "ERROR - Undefined Form Use Called");
                DisableMainComponents();
            }
        }

        private void FrmAddBusiness_FormClosing(object sender, FormClosingEventArgs e)
        {
            QuoteSwiftMainCode.CloseApplication(true);
        }

        private void UpdateBusinessInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertToEdit();
            mPassed.ChangeSpecificObject = true;
            updateBusinessInformationToolStripMenuItem.Enabled = false;
        }

        /** Form Specific Functions And Procedures: 
        *
        * Note: Not all Functions or Procedures below are used more than once
        *       Some of them are only to keep the above events readable 
        *       and clutter free.                                                          
        */

        private bool ValidBusinessAddress(
            string businessAddressDescription,
            string businessAddressStreetNumber,
            string businessAddressStreetName,
            string businessAddressSuburb,
            string businessAddressCity,
            string businessAddressAreaCode
        )
        {
            if (businessAddressDescription.Trim().Length < 2)
            {
                MainProgramCode.ShowError("The provided mBusiness Address Description is invalid, please provide a valid description", "ERROR - Invalid mBusiness Address Description");
                return (false);
            }

            if (QuoteSwiftMainCode.ParseInt(businessAddressStreetNumber.Trim()) == 0)
            {
                MainProgramCode.ShowError("The provided mBusiness Address Street Number is invalid, please provide a valid street number", "ERROR - Invalid mBusiness Address Street Number");
                return (false);
            }

            if (businessAddressStreetName.Trim().Length < 2)
            {
                MainProgramCode.ShowError("The provided mBusiness Address Street Name is invalid, please provide a valid street name", "ERROR - Invalid mBusiness Address Street Name");
                return (false);
            }

            if (businessAddressSuburb.Trim().Length < 2)
            {
                MainProgramCode.ShowError("The provided mBusiness Address Suburb is invalid, please provide a valid suburb", "ERROR - Invalid mBusiness Address Suburb");
                return (false);
            }

            if (businessAddressCity.Trim().Length < 2)
            {
                MainProgramCode.ShowError("The provided mBusiness Address City is invalid, please provide a valid city", "ERROR - Invalid mBusiness Address City");
                return (false);
            }

            if (QuoteSwiftMainCode.ParseInt(businessAddressAreaCode.Trim()) == 0)
            {
                MainProgramCode.ShowError("The provided mBusiness Address Area Code is invalid, please provide a valid area code", "ERROR - Invalid mBusiness Address Area Code");
                return (false);
            }

            return true;
        }

        private bool ValidBusinessPoBoxAddress(
            string businessPoDescription,
            string businessPoStreetNumber,
            string businessPoSuburb,
            string businessPoCity,
            string businessPoAreaCode
        )
        {
            if (businessPoDescription.Trim().Length < 2)
            {
                MainProgramCode.ShowError("The provided mBusiness P.O.Box Address Description is invalid, please provide a valid description", "ERROR - Invalid mBusiness P.O.Box Address Description");
                return (false);
            }

            if (QuoteSwiftMainCode.ParseInt(businessPoStreetNumber.Trim()) == 0)
            {
                MainProgramCode.ShowError("The provided mBusiness' P.O.Box Address Street Number is invalid, please provide a valid street number", "ERROR - Invalid mBusiness' P.O.Box Address Street Number");
                return (false);
            }

            if (businessPoSuburb.Trim().Length < 2)
            {
                MainProgramCode.ShowError("The provided mBusiness' P.O.Box Address Suburb is invalid, please provide a valid suburb", "ERROR - Invalid mBusiness' P.O.Box Address Suburb");
                return (false);
            }

            if (businessPoCity.Trim().Length < 2)
            {
                MainProgramCode.ShowError("The provided mBusiness Address City is invalid, please provide a valid city", "ERROR - Invalid mBusiness' P.O.Box Address City");
                return (false);
            }

            if (QuoteSwiftMainCode.ParseInt(businessPoAreaCode.Trim()) == 0)
            {
                MainProgramCode.ShowError("The provided mBusiness Address Area Code is invalid, please provide a valid area code", "ERROR - Invalid mBusiness' P.O.Box Address Area Code");
                return (false);
            }

            return true;
        }

        private bool ValidBusiness(
            string businessName,
            string taxNumber,
            string registrationNumber,
            IReadOnlyCollection<Address> addressList,
            IReadOnlyCollection<Address> poBoxAddressList,
            IReadOnlyCollection<string> telephoneNumberList,
            IReadOnlyCollection<string> cellPhoneNumberList,
            IReadOnlyCollection<string> emailAddressList
        )
        {
            if (businessName.Trim().Length < 3)
            {
                MainProgramCode.ShowError(Messages.InvalidBusinessName, Messages.InvalidInputErrorCaption);
                return false;
            }

            if (taxNumber.Trim().Length < 7)
            {
                MainProgramCode.ShowError(Messages.InvalidTaxNumber, Messages.InvalidInputErrorCaption);
                return false;
            }

            if (registrationNumber.Trim().Length != 10)
            {
                MainProgramCode.ShowError(Messages.InvalidRegistrationNumber, Messages.InvalidInputErrorCaption);
                return false;
            }

            if (addressList == null)
            {
                MainProgramCode.ShowError(Messages.NoBusinessAddress, Messages.InvalidInputErrorCaption);
                return false;
            }

            if (poBoxAddressList == null)
            {
                MainProgramCode.ShowError(Messages.NoPoBoxAddress, Messages.InvalidInputErrorCaption);
                return false;
            }

            if (telephoneNumberList == null && cellPhoneNumberList == null)
            {
                MainProgramCode.ShowError(Messages.NoValidPhoneNumber, Messages.InvalidInputErrorCaption);
                return false;
            }

            if (emailAddressList == null)
            {
                MainProgramCode.ShowError(Messages.NoValidEmailAddress, Messages.InvalidInputErrorCaption);
                return false;
            }

            return true;
        }

        private void DisableMainComponents()
        {
            gbxBusinessInformation.Enabled = false;
            gbxBusinessAddress.Enabled = false;
            gbxPhoneRelated.Enabled = false;
            gbxEmailRelated.Enabled = false;
            gbxPOBoxAddress.Enabled = false;
            btnAddBusiness.Enabled = false;
        }

        private void ClearBusinessAddressInput()
        {
            txtBusinessAddresssDescription.ResetText();
            mtxtStreetnumber.ResetText();
            txtStreetName.ResetText();
            txtSuburb.ResetText();
            txtCity.ResetText();
            mtxtAreaCode.ResetText();
        }

        private void ClearPoBoxAddressInput()
        {
            txtBusinessPODescription.ResetText();
            mtxtPOBoxStreetNumber.ResetText();
            txtPOBoxSuburb.ResetText();
            txtPOBoxCity.ResetText();
            mtxtPOBoxAreaCode.ResetText();
        }

        private void ResetScreenInput()
        {
            txtBusinessName.ResetText();
            rtxtExtraInformation.ResetText();
            mtxtVATNumber.ResetText();
            mtxtRegistrationNumber.ResetText();
            ClearBusinessAddressInput();
            ClearPoBoxAddressInput();
            mtxtEmail.ResetText();
            mtxtCellphoneNumber.ResetText();
            mtxtTelephoneNumber.ResetText();
        }

        public bool AddressExisting(Address a)
        {
            if (mBusiness.BusinessAddressList != null)
            {
                for (int i = 0; i < mBusiness.BusinessAddressList.Count; i++)
                {
                    if (mBusiness.BusinessAddressList.SingleOrDefault(p => p.AddressDescription == a.AddressDescription) != null)
                    {
                        MainProgramCode.ShowError("This address has already been added previously.\nHINT: Description should be unique", "ERROR - Address Already Added");
                        return true;
                    }
                }
            }

            return false;
        }

        private bool PoBoxAddressExisting(Address a)
        {
            return mBusiness.BusinessPoBoxAddressList != null &&
                   !mBusiness.BusinessAddressMap.ContainsKey(a.AddressDescription.Trim());
        }

        public bool EmailAddressExisting(string s)
        {
            if (mBusiness.BusinessEmailAddressList != null)
            {
                if (mBusiness.BusinessEmailAddressList.SingleOrDefault(p => p == s) != null)
                {
                    MainProgramCode.ShowError("This email address has already been added previously.", "ERROR - Email Address Already Added");
                    return true;
                }

            }

            return false;
        }

        public bool PhoneNumberExisting(string s)
        {
            if (mBusiness.BusinessTelephoneNumberList != null)
            {
                for (int i = 0; i < mBusiness.BusinessTelephoneNumberList.Count; i++)
                {
                    if (mBusiness.BusinessTelephoneNumberList.SingleOrDefault(p => p == s) != null)
                    {
                        MainProgramCode.ShowError("This number has already been added previously to the Telephone Number List.", "ERROR - Number Already Added");
                        return true;
                    }
                }
            }

            if (mBusiness.BusinessCellphoneNumberList != null)
            {
                for (int i = 0; i < mBusiness.BusinessCellphoneNumberList.Count; i++)
                {
                    if (mBusiness.BusinessCellphoneNumberList.SingleOrDefault(p => p == s) != null)
                    {
                        MainProgramCode.ShowError("This number has already been added previously to the Cellphone Number List.", "ERROR - Number Already Added");
                        return true;
                    }
                }
            }

            return false;
        }

        private void LoadInformation()
        {
            if (mBusiness != null)
            {
                txtBusinessName.Text = mBusiness.BusinessName;
                rtxtExtraInformation.Text = mBusiness.BusinessExtraInformation;
                mtxtVATNumber.Text = mBusiness.BusinessLegalDetails.VatNumber;
                mtxtRegistrationNumber.Text = mBusiness.BusinessLegalDetails.RegistrationNumber;
            }
        }

        private void ConvertToViewOnly()
        {
            QuoteSwiftMainCode.ReadOnlyComponents(gbxBusinessAddress.Controls);
            QuoteSwiftMainCode.ReadOnlyComponents(gbxBusinessInformation.Controls);
            QuoteSwiftMainCode.ReadOnlyComponents(gbxEmailRelated.Controls);
            QuoteSwiftMainCode.ReadOnlyComponents(gbxLegalInformation.Controls);
            QuoteSwiftMainCode.ReadOnlyComponents(gbxPhoneRelated.Controls);
            QuoteSwiftMainCode.ReadOnlyComponents(gbxPOBoxAddress.Controls);

            btnViewAddresses.Enabled = true;
            btnViewAll.Enabled = true;
            btnViewAllPOBoxAddresses.Enabled = true;
            btnViewEmailAddresses.Enabled = true;

            btnAddBusiness.Visible = false;
            Text = Text.Replace("Add mBusiness", "Viewing " + mPassed.BusinessToChange.BusinessName);
            updateBusinessInformationToolStripMenuItem.Enabled = true;
        }

        private void ConvertToEdit()
        {
            QuoteSwiftMainCode.ReadWriteComponents(gbxBusinessAddress.Controls);
            QuoteSwiftMainCode.ReadWriteComponents(gbxBusinessInformation.Controls);
            QuoteSwiftMainCode.ReadWriteComponents(gbxEmailRelated.Controls);
            QuoteSwiftMainCode.ReadWriteComponents(gbxLegalInformation.Controls);
            QuoteSwiftMainCode.ReadWriteComponents(gbxPhoneRelated.Controls);
            QuoteSwiftMainCode.ReadWriteComponents(gbxPOBoxAddress.Controls);

            btnAddBusiness.Visible = true;
            btnAddBusiness.Text = "Update mBusiness";
            Text = Text.Replace("Viewing " + mBusiness.BusinessName, "Updating " + mBusiness.BusinessName);
            updateBusinessInformationToolStripMenuItem.Enabled = false;
        }

        /**********************************************************************************/
    }
}
