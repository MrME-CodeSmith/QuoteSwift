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
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                QuoteSwiftMainCode.CloseApplication(true);
        }

        private void BtnAddBusiness_Click(object sender, EventArgs e)
        {
            if (ValidBusiness() && !mPassed.ChangeSpecificObject)
            {
                //Add Final Details to mBusiness object
                mBusiness.BusinessName = txtBusinessName.Text;
                mBusiness.BusinessExtraInformation = rtxtExtraInformation.Text;
                mBusiness.BusinessLegalDetails = new Legal(mtxtRegistrationNumber.Text, mtxtVATNumber.Text);

                if (mPassed.BusinessMap == null)
                {
                    //Create New business List
                    mPassed.BusinessMap = new Dictionary<string, Business>()
                    {
                        { mBusiness.BusinessLegalDetails.RegistrationNumber, mBusiness }
                    };
                }
                else //Add To List
                {
                    if (mPassed.BusinessMap.SingleOrDefault(p => p.Value.BusinessName == mBusiness.BusinessName).Value != null)
                    {
                        MainProgramCode.ShowError("This business has already been added previously.\nHINT: mBusiness Name,VAT Number and Registration Number should be unique", "ERROR - mBusiness Already Added");
                        return;
                    }
                    else if (mPassed.BusinessMap.SingleOrDefault(p => p.Value.BusinessLegalDetails.VatNumber == mBusiness.BusinessLegalDetails.VatNumber).Value != null)
                    {
                        MainProgramCode.ShowError("This business has already been added previously.\nHINT: mBusiness Name,VAT Number and Registration Number should be unique", "ERROR - mBusiness Already Added");
                        return;
                    }
                    else if (mPassed.BusinessMap.SingleOrDefault(p => p.Value.BusinessLegalDetails.RegistrationNumber == mBusiness.BusinessLegalDetails.RegistrationNumber).Value != null)
                    {
                        MainProgramCode.ShowError("This business has already been added previously.\nHINT: mBusiness Name,VAT Number and Registration Number should be unique", "ERROR - mBusiness Already Added");
                        return;
                    }
                    else mPassed.BusinessMap.Add(mBusiness.BusinessLegalDetails.RegistrationNumber ,mBusiness);
                }

                mPassed.BusinessToChange = null;
                mPassed.ChangeSpecificObject = false;

                MainProgramCode.ShowInformation(mBusiness.BusinessName + " has been added.", "INFORMATION - mBusiness Successfully Added");

                ResetScreenInput();
            }
            else if (ValidBusiness() && mPassed.ChangeSpecificObject)
            {
                mPassed.BusinessToChange.BusinessName = txtBusinessName.Text;
                mPassed.BusinessToChange.BusinessExtraInformation = rtxtExtraInformation.Text;
                mPassed.BusinessToChange.BusinessLegalDetails = new Legal(mtxtRegistrationNumber.Text, mtxtVATNumber.Text);

                MainProgramCode.ShowInformation(mBusiness.BusinessName + " has been successfully updated.", "INFORMATION - mBusiness Successfully Updated");
                ConvertToViewOnly();
            }
        }

        private void BtnAddPOBoxAddress_Click(object sender, EventArgs e)
        {
            if (ValidBusinessPoBoxAddress())
            {
                Address address = new Address(txtBusinessPODescription.Text, QuoteSwiftMainCode.ParseInt(mtxtPOBoxStreetNumber.Text),
                                              "", txtPOBoxSuburb.Text, txtPOBoxCity.Text, QuoteSwiftMainCode.ParseInt(mtxtPOBoxAreaCode.Text));
                if (!PoBoxAddressExisting(address))
                {
                    if (mBusiness.BusinessPoBoxAddressList == null)
                    {
                        //Create New List
                        mBusiness.BusinessPoBoxAddressList = new BindingList<Address> { address };
                        MainProgramCode.ShowInformation("Successfully added the business P.O.Box address", "INFORMATION - mBusiness P.O.Box Address Added Successfully");
                    }
                    else // AddingNewEventArgs To list
                    {
                        mBusiness.BusinessPoBoxAddressList.Add(address);
                        MainProgramCode.ShowInformation("Successfully added the business P.O.Box address", "INFORMATION - mBusiness P.O.Box Address Added Successfully");
                    }

                    ClearPoBoxAddressInput();
                }
            }
        }

        private void BtnAddAddress_Click(object sender, EventArgs e)
        {
            if (ValidBusinessAddress())
            {
                Address address = new Address(txtBusinessAddresssDescription.Text, QuoteSwiftMainCode.ParseInt(mtxtStreetnumber.Text),
                                              txtStreetName.Text, txtSuburb.Text, txtCity.Text, QuoteSwiftMainCode.ParseInt(mtxtAreaCode.Text));
                if (!AddressExisting(address))
                {
                    if (mBusiness.BusinessAddressList == null)
                    {
                        //Create New List
                        mBusiness.BusinessAddressList = new BindingList<Address> { address };
                        MainProgramCode.ShowInformation("Successfully added the business address", "INFORMATION - mBusiness Address Added Successfully");
                    }
                    else //Add To Current list
                    {
                        mBusiness.BusinessAddressList.Add(address);
                        MainProgramCode.ShowInformation("Successfully added the business address", "INFORMATION - mBusiness Address Added Successfully");
                    }

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

        private bool ValidBusinessAddress()
        {
            if (txtBusinessAddresssDescription.Text.Length < 2)
            {
                MainProgramCode.ShowError("The provided mBusiness Address Description is invalid, please provide a valid description", "ERROR - Invalid mBusiness Address Description");
                return (false);
            }

            if (QuoteSwiftMainCode.ParseInt(mtxtStreetnumber.Text) == 0)
            {
                MainProgramCode.ShowError("The provided mBusiness Address Street Number is invalid, please provide a valid street number", "ERROR - Invalid mBusiness Address Street Number");
                return (false);
            }

            if (txtStreetName.Text.Length < 2)
            {
                MainProgramCode.ShowError("The provided mBusiness Address Street Name is invalid, please provide a valid street name", "ERROR - Invalid mBusiness Address Street Name");
                return (false);
            }

            if (txtSuburb.Text.Length < 2)
            {
                MainProgramCode.ShowError("The provided mBusiness Address Suburb is invalid, please provide a valid suburb", "ERROR - Invalid mBusiness Address Suburb");
                return (false);
            }

            if (txtCity.Text.Length < 2)
            {
                MainProgramCode.ShowError("The provided mBusiness Address City is invalid, please provide a valid city", "ERROR - Invalid mBusiness Address City");
                return (false);
            }

            if (QuoteSwiftMainCode.ParseInt(mtxtAreaCode.Text) == 0)
            {
                MainProgramCode.ShowError("The provided mBusiness Address Area Code is invalid, please provide a valid area code", "ERROR - Invalid mBusiness Address Area Code");
                return (false);
            }

            return true;
        }

        private bool ValidBusinessPoBoxAddress()
        {
            if (txtBusinessPODescription.Text.Length < 2)
            {
                MainProgramCode.ShowError("The provided mBusiness P.O.Box Address Description is invalid, please provide a valid description", "ERROR - Invalid mBusiness P.O.Box Address Description");
                return (false);
            }

            if (QuoteSwiftMainCode.ParseInt(mtxtPOBoxStreetNumber.Text) == 0)
            {
                MainProgramCode.ShowError("The provided mBusiness' P.O.Box Address Street Number is invalid, please provide a valid street number", "ERROR - Invalid mBusiness' P.O.Box Address Street Number");
                return (false);
            }

            if (txtPOBoxSuburb.Text.Length < 2)
            {
                MainProgramCode.ShowError("The provided mBusiness' P.O.Box Address Suburb is invalid, please provide a valid suburb", "ERROR - Invalid mBusiness' P.O.Box Address Suburb");
                return (false);
            }

            if (txtPOBoxCity.Text.Length < 2)
            {
                MainProgramCode.ShowError("The provided mBusiness Address City is invalid, please provide a valid city", "ERROR - Invalid mBusiness' P.O.Box Address City");
                return (false);
            }

            if (QuoteSwiftMainCode.ParseInt(mtxtPOBoxAreaCode.Text) == 0)
            {
                MainProgramCode.ShowError("The provided mBusiness Address Area Code is invalid, please provide a valid area code", "ERROR - Invalid mBusiness' P.O.Box Address Area Code");
                return (false);
            }

            return true;
        }

        private bool ValidBusiness()
        {
            if (txtBusinessName.Text.Length < 3)
            {
                MainProgramCode.ShowError("The provided business name is invalid, please provide a business name longer that 2 characters.", "ERROR - Invalid mBusiness Name");
                return false;
            }

            if (mtxtVATNumber.Text.Length < 7)
            {
                MainProgramCode.ShowError("The provided VAT number is invalid, please provide a valid VAT number.", "ERROR - Invalid mBusiness VAT Number");
                return false;
            }

            if (mtxtRegistrationNumber.Text.Length < 7)
            {
                MainProgramCode.ShowError("The provided registration number is invalid, please provide a valid registration number.", "ERROR - Invalid mBusiness Registration Number");
                return false;
            }

            if (mBusiness.BusinessAddressList == null)
            {
                MainProgramCode.ShowError("Please add a valid business address under the 'mBusiness Address' section.", "ERROR - Current mBusiness Invalid");
                return false;
            }

            if (mBusiness.BusinessPoBoxAddressList == null)
            {
                MainProgramCode.ShowError("Please add a valid business P.O.Box address under the 'mBusiness P.O.Box Address' section.", "ERROR - Current mBusiness Invalid");
                return false;
            }

            if (mBusiness.BusinessTelephoneNumberList == null && mBusiness.BusinessCellphoneNumberList == null)
            {
                MainProgramCode.ShowError("Please add a valid phone number under the 'Phone Related' section.", "ERROR - Current mBusiness Invalid");
                return false;
            }

            if (mBusiness.BusinessEmailAddressList == null)
            {
                MainProgramCode.ShowError("Please add a valid business email address under the 'Email Related' section.", "ERROR - Current mBusiness Invalid");
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

            if (mBusiness.BusinessPoBoxAddressList != null)
            {
                for (int i = 0; i < mBusiness.BusinessPoBoxAddressList.Count; i++)
                {
                    if (mBusiness.BusinessPoBoxAddressList.SingleOrDefault(p => p.AddressDescription == a.AddressDescription) != null)
                    {
                        MainProgramCode.ShowError("This P.O.Box address has already been added previously.\nHINT: Description should be unique", "ERROR - P.O.Box Address Already Added");
                        return true;
                    }
                }
            }

            return false;
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
