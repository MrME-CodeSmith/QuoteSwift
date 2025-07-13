using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmAddBusiness : Form
    {

        Pass passed;

        Business Business;

        public FrmAddBusiness(ref Pass passed)
        {
            InitializeComponent();
            this.passed = passed;
            Business = passed.BusinessToChange;
        }

        public ref Pass Passed { get => ref passed; }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                QuoteSwiftMainCode.CloseApplication(true, ref passed);
        }

        private void BtnAddBusiness_Click(object sender, EventArgs e)
        {
            if (ValidBusiness() && !passed.ChangeSpecificObject)
            {
                //Add Final Details to Business object
                Business.BusinessName = txtBusinessName.Text;
                Business.BusinessExtraInformation = rtxtExtraInformation.Text;
                Business.BusinessLegalDetails = new Legal(mtxtRegistrationNumber.Text, mtxtVATNumber.Text);

                if (passed.PassBusinessList == null)
                {
                    //Create New business List
                    passed.PassBusinessList = new BindingList<Business> { Business };
                }
                else //Add To List
                {
                    if (passed.BusinessLookup.ContainsKey(Business.BusinessName) ||
                        passed.BusinessVatNumbers.Contains(Business.BusinessLegalDetails.VatNumber) ||
                        passed.BusinessRegNumbers.Contains(Business.BusinessLegalDetails.RegistrationNumber))
                    {
                        MainProgramCode.ShowError("This business has already been added previously.\nHINT: Business Name,VAT Number and Registration Number should be unique", "ERROR - Business Already Added");
                        return;
                    }
                    passed.PassBusinessList.Add(Business);
                }

                passed.BusinessLookup[Business.BusinessName] = Business;
                passed.BusinessVatNumbers.Add(Business.BusinessLegalDetails.VatNumber);
                passed.BusinessRegNumbers.Add(Business.BusinessLegalDetails.RegistrationNumber);

                passed.BusinessToChange = null;
                passed.ChangeSpecificObject = false;

                MainProgramCode.ShowInformation(Business.BusinessName + " has been added.", "INFORMATION - Business Successfully Added");

                ResetScreenInput();
            }
            else if (ValidBusiness() && passed.ChangeSpecificObject)
            {
                string oldName = passed.BusinessToChange.BusinessName;
                string oldVat = passed.BusinessToChange.BusinessLegalDetails.VatNumber;
                string oldReg = passed.BusinessToChange.BusinessLegalDetails.RegistrationNumber;

                passed.BusinessToChange.BusinessName = txtBusinessName.Text;
                passed.BusinessToChange.BusinessExtraInformation = rtxtExtraInformation.Text;
                passed.BusinessToChange.BusinessLegalDetails = new Legal(mtxtRegistrationNumber.Text, mtxtVATNumber.Text);

                passed.BusinessLookup.Remove(oldName);
                passed.BusinessVatNumbers.Remove(oldVat);
                passed.BusinessRegNumbers.Remove(oldReg);

                Business = passed.BusinessToChange;
                passed.BusinessLookup[Business.BusinessName] = Business;
                passed.BusinessVatNumbers.Add(Business.BusinessLegalDetails.VatNumber);
                passed.BusinessRegNumbers.Add(Business.BusinessLegalDetails.RegistrationNumber);

                MainProgramCode.ShowInformation(Business.BusinessName + " has been successfully updated.", "INFORMATION - Business Successfully Updated");
                ConvertToViewOnly();
            }
        }

        private void BtnAddPOBoxAddress_Click(object sender, EventArgs e)
        {
            if (ValidBusinessPOBoxAddress())
            {
                Address address = new Address(txtBusinessPODescription.Text, QuoteSwiftMainCode.ParseInt(mtxtPOBoxStreetNumber.Text),
                                              "", txtPOBoxSuburb.Text, txtPOBoxCity.Text, QuoteSwiftMainCode.ParseInt(mtxtPOBoxAreaCode.Text));
                if (!POBoxAddressExisting(address))
                {
                    Business.BusinessPOBoxAddressList.Add(address);
                    MainProgramCode.ShowInformation("Successfully added the business P.O.Box address", "INFORMATION - Business P.O.Box Address Added Successfully");

                    Business.POBoxMap[address.AddressDescription] = address;

                    ClearPOBoxAddressInput();
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
                    Business.BusinessAddressList.Add(address);
                    Business.AddressMap[address.AddressDescription] = address;
                    MainProgramCode.ShowInformation("Successfully added the business address", "INFORMATION - Business Address Added Successfully");

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
                Business.AddTelephoneNumber(mtxtTelephoneNumber.Text);
                Added = true;

                mtxtTelephoneNumber.ResetText();
            }

            if (mtxtCellphoneNumber.Text.Length > 10 && !PhoneNumberExisting(mtxtCellphoneNumber.Text))
            {
                Business.AddCellphoneNumber(mtxtCellphoneNumber.Text);
                Added = true;

                mtxtCellphoneNumber.ResetText();
            }

            if (Added)
            {
                MainProgramCode.ShowInformation("Successfully added the business phone number/s", "INFORMATION - Business Phone Number/s Added Successfully");
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
                    Business.AddEmailAddress(mtxtEmail.Text);
                    MainProgramCode.ShowInformation("Successfully added the business Email address", "INFORMATION - Business Email Address Added Successfully");

                    mtxtEmail.ResetText();
                }
            }
            else MainProgramCode.ShowError("The provided Email Address is invalid. Please provide a valid Email Address", "ERROR - Invalid Email Address");
        }

        private void BtnViewEmailAddresses_Click(object sender, EventArgs e)
        {
            if (Business.BusinessEmailAddressList != null)
            {
                passed.BusinessToChange = Business;
                passed.ChangeSpecificObject = !updateBusinessInformationToolStripMenuItem.Enabled;

                Hide();
                passed = QuoteSwiftMainCode.ViewBusinessesEmailAddresses(ref passed);
                Show();

                Business = passed.BusinessToChange;
                passed.BusinessToChange = null;
                passed.ChangeSpecificObject = false;

            }
            else MainProgramCode.ShowError("You need to first add an Email address before you can view the list of addresses.\nPlease add an address first", "ERROR - Can't View Non-Existing Business Email Addresses");
        }

        private void BtnViewAddresses_Click(object sender, EventArgs e)
        {
            if (Business.BusinessAddressList != null)
            {
                passed.BusinessToChange = Business;
                passed.ChangeSpecificObject = !updateBusinessInformationToolStripMenuItem.Enabled;

                Hide();
                passed = QuoteSwiftMainCode.ViewBusinessesAddresses(ref passed);
                Show();

                Business = passed.BusinessToChange;
                passed.BusinessToChange = null;
                passed.ChangeSpecificObject = false;
            }
            else MainProgramCode.ShowError("You need to first add an address before you can view the list of addresses.\nPlease add an address first", "ERROR - Can't View Non-Existing Business Addresses");
        }

        private void BtnViewAllPOBoxAddresses_Click(object sender, EventArgs e)
        {
            if (Business.BusinessPOBoxAddressList != null)
            {
                passed.BusinessToChange = Business;
                passed.ChangeSpecificObject = !updateBusinessInformationToolStripMenuItem.Enabled;

                Hide();
                passed = QuoteSwiftMainCode.ViewBusinessesPOBoxAddresses(ref passed);
                Show();

                Business = passed.BusinessToChange;
                passed.BusinessToChange = null;
                passed.ChangeSpecificObject = false;
            }
            else MainProgramCode.ShowError("You need to first add an P.O.Box address before you can view the list of addresses.\nPlease add an address first", "ERROR - Can't View Non-Existing Business P.O.Box Addresses");
        }

        private void BtnViewAll_Click(object sender, EventArgs e)
        {
            if (Business.BusinessTelephoneNumberList != null || Business.BusinessCellphoneNumberList != null)
            {
                passed.BusinessToChange = Business;
                passed.ChangeSpecificObject = !updateBusinessInformationToolStripMenuItem.Enabled;

                Hide();
                passed = QuoteSwiftMainCode.ViewBusinessesPhoneNumbers(ref passed);
                Show();

                Business = passed.BusinessToChange;
                passed.BusinessToChange = null;
                passed.ChangeSpecificObject = false;
            }
            else MainProgramCode.ShowError("You need to first add at least one phone number before you can view the list of phone numbers.\nPlease add a phone number first", "ERROR - Can't View Non-Existing Business Phone Numbers");
        }

        private void FrmAddBusiness_Load(object sender, EventArgs e)
        {
            if (passed.BusinessToChange != null && passed.ChangeSpecificObject) // Change Existing Business Info
            {
                Business = passed.BusinessToChange;
            }
            else if (passed.BusinessToChange != null && !passed.ChangeSpecificObject) // View Existing Business Info
            {
                Business = passed.BusinessToChange;
                ConvertToViewOnly();
                LoadInformation();
            }
            else if (passed.BusinessToChange == null && !passed.ChangeSpecificObject) // Add New Business Info
            {
                Business = new Business();
            }
            else // Undefined Use - Show ERROR
            {
                MainProgramCode.ShowError("The form was activated without the correct parameters to have an achievable goal.\nThe Form's input parameters will be disabled to avoid possible data corruption.", "ERROR - Undefined Form Use Called");
                DisableMainComponents();
            }
        }

        private void FrmAddBusiness_FormClosing(object sender, FormClosingEventArgs e)
        {
            QuoteSwiftMainCode.CloseApplication(true, ref passed);
        }

        private void UpdateBusinessInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertToEdit();
            passed.ChangeSpecificObject = true;
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
                MainProgramCode.ShowError("The provided Business Address Description is invalid, please provide a valid description", "ERROR - Invalid Business Address Description");
                return (false);
            }

            if (QuoteSwiftMainCode.ParseInt(mtxtStreetnumber.Text) == 0)
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

            if (QuoteSwiftMainCode.ParseInt(mtxtAreaCode.Text) == 0)
            {
                MainProgramCode.ShowError("The provided Business Address Area Code is invalid, please provide a valid area code", "ERROR - Invalid Business Address Area Code");
                return (false);
            }

            return true;
        }

        private bool ValidBusinessPOBoxAddress()
        {
            if (txtBusinessPODescription.Text.Length < 2)
            {
                MainProgramCode.ShowError("The provided Business P.O.Box Address Description is invalid, please provide a valid description", "ERROR - Invalid Business P.O.Box Address Description");
                return (false);
            }

            if (QuoteSwiftMainCode.ParseInt(mtxtPOBoxStreetNumber.Text) == 0)
            {
                MainProgramCode.ShowError("The provided Business' P.O.Box Address Street Number is invalid, please provide a valid street number", "ERROR - Invalid Business' P.O.Box Address Street Number");
                return (false);
            }

            if (txtPOBoxSuburb.Text.Length < 2)
            {
                MainProgramCode.ShowError("The provided Business' P.O.Box Address Suburb is invalid, please provide a valid suburb", "ERROR - Invalid Business' P.O.Box Address Suburb");
                return (false);
            }

            if (txtPOBoxCity.Text.Length < 2)
            {
                MainProgramCode.ShowError("The provided Business Address City is invalid, please provide a valid city", "ERROR - Invalid Business' P.O.Box Address City");
                return (false);
            }

            if (QuoteSwiftMainCode.ParseInt(mtxtPOBoxAreaCode.Text) == 0)
            {
                MainProgramCode.ShowError("The provided Business Address Area Code is invalid, please provide a valid area code", "ERROR - Invalid Business' P.O.Box Address Area Code");
                return (false);
            }

            return true;
        }

        private bool ValidBusiness()
        {
            if (txtBusinessName.Text.Length < 3)
            {
                MainProgramCode.ShowError("The provided business name is invalid, please provide a business name longer that 2 characters.", "ERROR - Invalid Business Name");
                return false;
            }

            if (mtxtVATNumber.Text.Length < 7)
            {
                MainProgramCode.ShowError("The provided VAT number is invalid, please provide a valid VAT number.", "ERROR - Invalid Business VAT Number");
                return false;
            }

            if (mtxtRegistrationNumber.Text.Length < 7)
            {
                MainProgramCode.ShowError("The provided registration number is invalid, please provide a valid registration number.", "ERROR - Invalid Business Registration Number");
                return false;
            }

            if (Business.BusinessAddressList == null)
            {
                MainProgramCode.ShowError("Please add a valid business address under the 'Business Address' section.", "ERROR - Current Business Invalid");
                return false;
            }

            if (Business.BusinessPOBoxAddressList == null)
            {
                MainProgramCode.ShowError("Please add a valid business P.O.Box address under the 'Business P.O.Box Address' section.", "ERROR - Current Business Invalid");
                return false;
            }

            if (Business.BusinessTelephoneNumberList == null && Business.BusinessCellphoneNumberList == null)
            {
                MainProgramCode.ShowError("Please add a valid phone number under the 'Phone Related' section.", "ERROR - Current Business Invalid");
                return false;
            }

            if (Business.BusinessEmailAddressList == null)
            {
                MainProgramCode.ShowError("Please add a valid business email address under the 'Email Related' section.", "ERROR - Current Business Invalid");
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

        private void ClearPOBoxAddressInput()
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
            ClearPOBoxAddressInput();
            mtxtEmail.ResetText();
            mtxtCellphoneNumber.ResetText();
            mtxtTelephoneNumber.ResetText();
        }

        public bool AddressExisting(Address a)
        {
            if (Business.AddressMap.ContainsKey(a.AddressDescription))
            {
                MainProgramCode.ShowError("This address has already been added previously.\nHINT: Description should be unique", "ERROR - Address Already Added");
                return true;
            }

            return false;
        }

        private bool POBoxAddressExisting(Address a)
        {
            if (Business.POBoxMap.ContainsKey(a.AddressDescription))
            {
                MainProgramCode.ShowError("This P.O.Box address has already been added previously.\nHINT: Description should be unique", "ERROR - P.O.Box Address Already Added");
                return true;
            }

            return false;
        }

        public bool EmailAddressExisting(string s)
        {
            if (Business.EmailAddresses.Contains(s))
            {
                MainProgramCode.ShowError("This email address has already been added previously.", "ERROR - Email Address Already Added");
                return true;
            }

            return false;
        }

        public bool PhoneNumberExisting(string s)
        {
            if (Business.TelephoneNumbers.Contains(s) || Business.CellphoneNumbers.Contains(s))
            {
                MainProgramCode.ShowError("This number has already been added previously.", "ERROR - Number Already Added");
                return true;
            }

            return false;
        }

        private void LoadInformation()
        {
            if (Business != null)
            {
                txtBusinessName.Text = Business.BusinessName;
                rtxtExtraInformation.Text = Business.BusinessExtraInformation;
                mtxtVATNumber.Text = Business.BusinessLegalDetails.VatNumber;
                mtxtRegistrationNumber.Text = Business.BusinessLegalDetails.RegistrationNumber;
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
            Text = Text.Replace("Add Business", "Viewing " + passed.BusinessToChange.BusinessName);
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
            btnAddBusiness.Text = "Update Business";
            Text = Text.Replace("Viewing " + Business.BusinessName, "Updating " + Business.BusinessName);
            updateBusinessInformationToolStripMenuItem.Enabled = false;
        }

        /**********************************************************************************/
    }
}
