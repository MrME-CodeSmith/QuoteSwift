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
            MainProgramCode.CloseApplication(MainProgramCode.RequestConfirmation("Are you sure you want to close the application?\nAny unsaved work will be lost.", "REQUEST - Application Termination"), ref this.passed);
        }

        private void BtnAddBusiness_Click(object sender, EventArgs e)
        {
            if(ValidBusiness() && !passed.ChangeSpecificObject)
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
                    if (passed.PassBusinessList.SingleOrDefault(p => p.BusinessName == Business.BusinessName) != null)
                    {
                        MainProgramCode.ShowError("This business has already been added previously.\nHINT: Business Name,VAT Number and Registration Number should be unique", "ERROR - Business Already Added");
                        return;
                    } 
                    else if (passed.PassBusinessList.SingleOrDefault(p => p.BusinessLegalDetails.VatNumber == Business.BusinessLegalDetails.VatNumber) != null)
                    {
                        MainProgramCode.ShowError("This business has already been added previously.\nHINT: Business Name,VAT Number and Registration Number should be unique", "ERROR - Business Already Added");
                        return;
                    }
                    else if (passed.PassBusinessList.SingleOrDefault(p => p.BusinessLegalDetails.RegistrationNumber == Business.BusinessLegalDetails.RegistrationNumber) != null)
                    {
                        MainProgramCode.ShowError("This business has already been added previously.\nHINT: Business Name,VAT Number and Registration Number should be unique", "ERROR - Business Already Added");
                        return;
                    }
                    else passed.PassBusinessList.Add(Business);
                }

                this.passed.BusinessToChange = null;
                this.passed.ChangeSpecificObject = false;

                MainProgramCode.ShowInformation(Business.BusinessName + " has been added.","INFORMATION - Business Sucessfully Added");

                ResetScreenInput();
            } 
            else if(ValidBusiness() && passed.ChangeSpecificObject)
            {
                passed.BusinessToChange.BusinessName = txtBusinessName.Text;
                passed.BusinessToChange.BusinessExtraInformation = rtxtExtraInformation.Text;
                passed.BusinessToChange.BusinessLegalDetails = new Legal(mtxtRegistrationNumber.Text, mtxtVATNumber.Text);

                MainProgramCode.ShowInformation(Business.BusinessName + " has been successfully updated.", "INFORMATION - Business Sucessfully Updated");
                ConvertToViewOnly();
            }
        }

        private void BtnAddPOBoxAddress_Click(object sender, EventArgs e)
        {
            if(ValidBusinessPOBoxAddress())
            {
                Address address = new Address(txtBusinessPODescription.Text, MainProgramCode.ParseInt(mtxtPOBoxStreetNumber.Text),
                                              txtPOBoxStreetName.Text, txtPOBoxSuburb.Text, txtPOBoxCity.Text, MainProgramCode.ParseInt(mtxtPOBoxAreaCode.Text));
                if (!POBoxAddressExisting(address))
                {
                    if (Business.BusinessPOBoxAddressList == null)
                    {
                        //Create New List
                        Business.BusinessPOBoxAddressList = new BindingList<Address> { address };
                        MainProgramCode.ShowInformation("Successfuly added the business P.O.Box address", "INFORMATION - Business P.O.Box Address Added Successfully");
                    }
                    else // AddingNewEventArgs To list
                    {
                        Business.BusinessPOBoxAddressList.Add(address);
                        MainProgramCode.ShowInformation("Successfuly added the business P.O.Box address", "INFORMATION - Business P.O.Box Address Added Successfully");
                    }

                    ClearPOBoxAddressInput();
                }
            }
        }

        private void BtnAddAddress_Click(object sender, EventArgs e)
        {
            if(ValidBusinessAddress())
            {
                Address address = new Address(txtBusinessAddresssDescription.Text,MainProgramCode.ParseInt(mtxtStreetnumber.Text),
                                              txtStreetName.Text, txtSuburb.Text, txtCity.Text, MainProgramCode.ParseInt(mtxtAreaCode.Text));
                if (!AddressExisting(address))
                {
                    if (Business.BusinessAddressList == null)
                    {
                        //Create New List
                        Business.BusinessAddressList = new BindingList<Address> { address };
                        MainProgramCode.ShowInformation("Successfuly added the business address", "INFORMATION - Business Address Added Successfully");
                    }
                    else //Add To Current list
                    {
                        Business.BusinessAddressList.Add(address);
                        MainProgramCode.ShowInformation("Successfuly added the business address", "INFORMATION - Business Address Added Successfully");
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
            
            if(mtxtTelephoneNumber.Text.Length > 10 && !PhoneNumberExisting(mtxtTelephoneNumber.Text))
            {
                if(Business.BusinessTelephoneNumberList == null)
                {
                    // Create new List
                    Business.BusinessTelephoneNumberList = new BindingList<string> { mtxtTelephoneNumber.Text };
                    Added = true;
                }
                else // Add To List
                {
                    Business.BusinessTelephoneNumberList.Add(mtxtTelephoneNumber.Text);
                    Added = true;
                }

                mtxtTelephoneNumber.ResetText();
            }

            if(mtxtCellphoneNumber.Text.Length > 10 && !PhoneNumberExisting(mtxtCellphoneNumber.Text))
            {
                if (Business.BusinessCellphoneNumberList == null)
                {
                    // Create new List
                    Business.BusinessCellphoneNumberList = new BindingList<string> { mtxtCellphoneNumber.Text };
                    Added = true;
                }
                else // Add To List
                {
                    Business.BusinessCellphoneNumberList.Add(mtxtCellphoneNumber.Text);
                    Added = true;
                }

                mtxtCellphoneNumber.ResetText();
            }

            if(Added)
            {
                MainProgramCode.ShowInformation("Successfuly added the business phone number/s", "INFORMATION - Business Phone Number/s Added Successfully");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancelation can cause any changes to be lost.", "REQUEST - Cancelation")) this.Close();
        }

        private void BtnAddBusinessEmail_Click(object sender, EventArgs e)
        {
            if(mtxtEmail.Text.Length > 3 && mtxtEmail.Text.Contains("@"))
            {
                if (!EmailAddressExisting(mtxtEmail.Text))
                {
                    if (Business.BusinessEmailAddressList == null)
                    {
                        //Create New List
                        Business.BusinessEmailAddressList = new BindingList<string> { mtxtEmail.Text };
                        MainProgramCode.ShowInformation("Successfuly added the business Email address", "INFORMATION - Business Email Address Added Successfully");
                    }
                    else //Add To Existing List
                    {
                        Business.BusinessEmailAddressList.Add(mtxtEmail.Text);
                        MainProgramCode.ShowInformation("Successfuly added the business Email address", "INFORMATION - Business Email Address Added Successfully");
                    }

                    mtxtEmail.ResetText();  
                }
            }
            else MainProgramCode.ShowError("The provided Email Address is invalid. Please provide a valid Email Address", "ERROR - Invalid Email Address");
        }

        private void BtnViewEmailAddresses_Click(object sender, EventArgs e)
        {
            if (Business != null)
            {
                this.passed.BusinessToChange = Business;
                this.Hide();
                this.passed = MainProgramCode.ViewBusinessesEmailAddresses(ref this.passed);
                this.Show();
                Business = this.passed.BusinessToChange;

            }
            else MainProgramCode.ShowError("You need to first add an Email address before you can view the list of addresses.\nPlease add an address first", "ERROR - Can't View Non-Existing Business Email Addresses");
        }

        private void BtnViewAddresses_Click(object sender, EventArgs e)
        {
            if(Business != null)
            {
                this.passed.BusinessToChange = Business;
                this.Hide();
                this.passed = MainProgramCode.ViewBusinessesAddresses(ref this.passed);
                this.Show();
                Business = this.passed.BusinessToChange;
            }
            else MainProgramCode.ShowError("You need to first add an address before you can view the list of addresses.\nPlease add an address first","ERROR - Can't View Non-Existing Business Addresses");
        }

        private void BtnViewAllPOBoxAddresses_Click(object sender, EventArgs e)
        {
            if (Business != null)
            {
                this.passed.BusinessToChange = Business;
                this.Hide();
                this.passed = MainProgramCode.ViewBusinessesPOBoxAddresses(ref this.passed);
                this.Show();
                Business = this.passed.BusinessToChange;
            }
            else MainProgramCode.ShowError("You need to first add an P.O.Box address before you can view the list of addresses.\nPlease add an address first", "ERROR - Can't View Non-Existing Business P.O.Box Addresses");
        }

        private void BtnViewAll_Click(object sender, EventArgs e)
        {
            if (Business != null)
            {
                this.passed.BusinessToChange = Business;
                this.Hide();
                this.passed = MainProgramCode.ViewBusinessesPhoneNumbers(ref this.passed);
                this.Show();
                Business = this.passed.BusinessToChange;
            }
            else MainProgramCode.ShowError("You need to first add an P.O.Box address before you can view the list of addresses.\nPlease add an address first", "ERROR - Can't View Non-Existing Business P.O.Box Addresses");
        }

        private void FrmAddBusiness_Load(object sender, EventArgs e)
        {
            if(passed.BusinessToChange != null && passed.ChangeSpecificObject) // Change Existing Business Info
            {
                Business = passed.BusinessToChange;
            }
            else if(passed.BusinessToChange != null && !passed.ChangeSpecificObject) // View Existing Business Info
            {
                Business = passed.BusinessToChange;
                ConvertToViewOnly();
                
                LoadInformation();
            }
            else if(passed.BusinessToChange == null && !passed.ChangeSpecificObject) // Add New Business Info
            {
                Business = new Business();
            }
            else // Undefined Use - Show ERROR
            {
                MainProgramCode.ShowError("The form was activated without the correct parameters to have an achievable goal.\nThe Form's input parameters will be disabled to avoid possible data corruption.","ERROR - Undefined Form Use Called");
                DisableMainComponents();
            }
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

            if (MainProgramCode.ParseInt(mtxtStreetnumber.Text) == 0)
            {
                MainProgramCode.ShowError("The provided Business Address Street Number is invalid, please provide a valid street number", "ERROR - Invalid Business Address Street Number");
                return (false);
            }

            if(txtStreetName.Text.Length < 2)
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

        private bool ValidBusinessPOBoxAddress()
        {
            if (txtBusinessPODescription.Text.Length < 2)
            {
                MainProgramCode.ShowError("The provided Business P.O.Box Address Description is invalid, please provide a valid description", "ERROR - Invalid Business P.O.Box Address Description");
                return (false);
            }

            if (MainProgramCode.ParseInt(mtxtPOBoxStreetNumber.Text) == 0)
            {
                MainProgramCode.ShowError("The provided Business' P.O.Box Address Street Number is invalid, please provide a valid street number", "ERROR - Invalid Business' P.O.Box Address Street Number");
                return (false);
            }

            if (txtPOBoxStreetName.Text.Length < 2)
            {
                MainProgramCode.ShowError("The provided Business' P.O.Box Address Street Name is invalid, please provide a valid street name", "ERROR - Invalid Business' P.O.Box Address Street Name");
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

            if (MainProgramCode.ParseInt(mtxtPOBoxAreaCode.Text) == 0)
            {
                MainProgramCode.ShowError("The provided Business Address Area Code is invalid, please provide a valid area code", "ERROR - Invalid Business' P.O.Box Address Area Code");
                return (false);
            }

            return true;
        }

        private bool ValidBusiness()
        {
            if(txtBusinessName.Text.Length < 3)
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
                MainProgramCode.ShowError("Please add a valid business address under the 'Business Address' section.","ERROR - Current Business Invalid");
                return false;
            }
            
            if(Business.BusinessPOBoxAddressList == null)
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
            txtPOBoxStreetName.ResetText();
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
            if(Business.BusinessAddressList != null)
            {
                for(int i = 0; i < Business.BusinessAddressList.Count; i++)
                {
                    if (Business.BusinessAddressList.SingleOrDefault(p => p.AddressDescription == a.AddressDescription) != null)
                    {
                        MainProgramCode.ShowError("This address has already been added previously.\nHINT: Description should be unique", "ERROR - Address Already Added");
                        return true;
                    }
                }
            }

            return false;
        }

        private bool POBoxAddressExisting(Address a)
        {

            if (Business.BusinessPOBoxAddressList != null)
            {
                for (int i = 0; i < Business.BusinessPOBoxAddressList.Count; i++)
                {
                    if (Business.BusinessPOBoxAddressList.SingleOrDefault(p => p.AddressDescription == a.AddressDescription) != null)
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
            if (Business.BusinessEmailAddressList != null)
            {
                if (Business.BusinessEmailAddressList.SingleOrDefault(p => p == s) != null)
                {
                    MainProgramCode.ShowError("This email address has already been added previously.", "ERROR - Email Address Already Added");
                    return true;
                }

            }

            return false;
        }

        public bool PhoneNumberExisting(string s)
        {
            if (Business.BusinessTelephoneNumberList != null)
            {
                for (int i = 0; i < Business.BusinessTelephoneNumberList.Count; i++)
                {
                    if (Business.BusinessTelephoneNumberList.SingleOrDefault(p => p == s) != null)
                    {
                        MainProgramCode.ShowError("This number has already been added previously to the Telephone Number List.", "ERROR - Number Already Added");
                        return true;
                    }
                }
            }

            if (Business.BusinessCellphoneNumberList != null)
            {
                for (int i = 0; i < Business.BusinessCellphoneNumberList.Count; i++)
                {
                    if (Business.BusinessCellphoneNumberList.SingleOrDefault(p => p == s) != null)
                    {
                        MainProgramCode.ShowError("This number has already been added previously to the Cellphone Number List.", "ERROR - Number Already Added");
                        return true;
                    }
                }
            }

            return false;
        }

        private void FrmAddBusiness_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (passed != null)
            {
                if (passed.BusinessToChange != null) passed.BusinessToChange = null;
                if (passed.ChangeSpecificObject) passed.ChangeSpecificObject = false;
            }
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
            MainProgramCode.ReadOnlyComponents(gbxBusinessAddress.Controls);
            MainProgramCode.ReadOnlyComponents(gbxBusinessInformation.Controls);
            MainProgramCode.ReadOnlyComponents(gbxEmailRelated.Controls);
            MainProgramCode.ReadOnlyComponents(gbxLegalInformation.Controls);
            MainProgramCode.ReadOnlyComponents(gbxPhoneRelated.Controls);
            MainProgramCode.ReadOnlyComponents(gbxPOBoxAddress.Controls);

            btnViewAddresses.Enabled = true;
            btnViewAll.Enabled = true;
            btnViewAllPOBoxAddresses.Enabled = true;
            btnViewEmailAddresses.Enabled = true;

            btnAddBusiness.Visible = false;
            this.Text.Replace("Add Business", "Viewing " + passed.BusinessToChange.BusinessName);
        }

        private void ConvertToEdit()
        {
            MainProgramCode.ReadWriteComponents(gbxBusinessAddress.Controls);
            MainProgramCode.ReadWriteComponents(gbxBusinessInformation.Controls);
            MainProgramCode.ReadWriteComponents(gbxEmailRelated.Controls);
            MainProgramCode.ReadWriteComponents(gbxLegalInformation.Controls);
            MainProgramCode.ReadWriteComponents(gbxPhoneRelated.Controls);
            MainProgramCode.ReadWriteComponents(gbxPOBoxAddress.Controls);

            btnAddBusiness.Visible = true;
            btnAddBusiness.Text = "Update Business";
            this.Text.Replace("Viewing " + passed.BusinessToChange.BusinessName, "Updating " + passed.BusinessToChange.BusinessName);
        }

        private void UpdateBusinessInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertToEdit();
            this.passed.ChangeSpecificObject = true;
            updateBusinessInformationToolStripMenuItem.Enabled = false;
        }

        /**********************************************************************************/
    }
}
