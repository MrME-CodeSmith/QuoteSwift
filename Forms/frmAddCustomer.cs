﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using MainProgramLibrary;
using QuoteSwift.Models;

namespace QuoteSwift.Forms
{
    public partial class FrmAddCustomer : Form
    {

        AppContext mPassed;

        Customer mCustomer;

        Business mContainer;

        public ref AppContext Passed { get => ref mPassed; }

        public FrmAddCustomer()
        {
            InitializeComponent();
            mCustomer = mPassed.CustomerToChange;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                QuoteSwiftMainCode.CloseApplication(true);
        }

        private void BtnAddCustomer_Click(object sender, EventArgs e)
        {
            if (ValidBusiness() && !mPassed.ChangeSpecificObject)
            {
                Business LinkBusiness = GetSelectedBusiness();

                //Add Final Details to Customer object
                mCustomer.CustomerName = "";
                mCustomer.CustomerCompanyName = txtCustomerCompanyName.Text;
                mCustomer.CustomerLegalDetails = new Legal(mtxtRegistrationNumber.Text, mtxtVATNumber.Text);
                mCustomer.VendorNumber = mtxtVendorNumber.Text;

                if (LinkBusiness.CustomerList == null)
                {
                    //Create New Customer List
                    LinkBusiness.CustomerList = new BindingList<Customer> { mCustomer };
                }
                else //Add To List
                {
                    if (LinkBusiness.CustomerList.SingleOrDefault(p => p.CustomerName == mCustomer.CustomerName) != null)
                    {
                        MainProgramCode.ShowError("This customer has already been added previously.\nHINT: Customer Name,VAT Number and Registration Number should be unique", "ERROR - Customer Already Added");
                        return;
                    }
                    else LinkBusiness.CustomerList.Add(mCustomer);
                }

                mPassed.CustomerToChange = null;
                mPassed.ChangeSpecificObject = false;

                MainProgramCode.ShowInformation(mCustomer.CustomerCompanyName + " has been added.", "INFORMATION - Business Successfully Added");

                ResetScreenInput();
            }
            else if (ValidBusiness() && mPassed.ChangeSpecificObject)
            {
                mPassed.CustomerToChange.CustomerName = "";
                mPassed.CustomerToChange.CustomerCompanyName = txtCustomerCompanyName.Text;
                mPassed.CustomerToChange.CustomerLegalDetails = new Legal(mtxtRegistrationNumber.Text, mtxtVATNumber.Text);
                mPassed.CustomerToChange.VendorNumber = mtxtVendorNumber.Text;

                MainProgramCode.ShowInformation(mCustomer.CustomerCompanyName + " has been successfully updated.", "INFORMATION - Customer Successfully Updated");
                ConvertToViewOnly();
            }
        }

        private void FrmAddCustomer_Load(object sender, EventArgs e)
        {
            FrmViewCustomers frmViewCustomers = new FrmViewCustomers();
            frmViewCustomers.LinkBusinessToSource(ref cbBusinessSelection);

            if (mPassed.CustomerToChange != null && mPassed.ChangeSpecificObject) // Change Existing Customer Info
            {
                mCustomer = mPassed.CustomerToChange;
            }
            else if (mPassed.CustomerToChange != null && !mPassed.ChangeSpecificObject) // View Existing Customer Info
            {
                mCustomer = mPassed.CustomerToChange;
                ConvertToViewOnly();
                LoadInformation();

            }
            else if (mPassed.CustomerToChange == null && !mPassed.ChangeSpecificObject) // Add New Business Info
            {
                mCustomer = new Customer();
            }
            else // Undefined Use - Show ERROR
            {
                MainProgramCode.ShowError("The form was activated without the correct parameters to have an achievable goal.\nThe Form's input parameters will be disabled to avoid possible data corruption.", "ERROR - Undefined Form Use Called");
                DisableMainComponents();
            }
        }

        private void BtnAddAddress_Click(object sender, EventArgs e)
        {
            if (ValidCustomerAddress())
            {
                Address address = new Address(txtCustomerAddresssDescription.Text, 0, txtAtt.Text, txtWorkArea.Text, txtWorkPlace.Text, 0);
                if (!AddressExisting(address))
                {
                    if (mCustomer.CustomerDeliveryAddressList == null)
                    {
                        //Create New List
                        mCustomer.CustomerDeliveryAddressList = new BindingList<Address> { address };
                        MainProgramCode.ShowInformation("Successfully added the customer address", "INFORMATION - Customer Address Added Successfully");
                    }
                    else //Add To Current list
                    {
                        mCustomer.CustomerDeliveryAddressList.Add(address);
                        MainProgramCode.ShowInformation("Successfully added the customer address", "INFORMATION - Customer Address Added Successfully");
                    }

                    ClearCustomerAddressInput();
                }
            }
        }

        private void BtnAddPOBoxAddress_Click(object sender, EventArgs e)
        {
            if (ValidCustomerPoBoxAddress())
            {
                Address address = new Address(txtCustomerPODescription.Text, QuoteSwiftMainCode.ParseInt(mtxtPOBoxStreetNumber.Text),
                                              "", txtPOBoxSuburb.Text, txtPOBoxCity.Text, QuoteSwiftMainCode.ParseInt(mtxtPOBoxAreaCode.Text));
                if (!PoBoxAddressExisting(address))
                {
                    if (mCustomer.CustomerPoBoxAddress == null)
                    {
                        //Create New List
                        mCustomer.CustomerPoBoxAddress = new BindingList<Address> { address };
                        MainProgramCode.ShowInformation("Successfully added the customer P.O.Box address", "INFORMATION - Business P.O.Box Address Added Successfully");
                    }
                    else // AddingNewEventArgs To list
                    {
                        mCustomer.CustomerPoBoxAddress.Add(address);
                        MainProgramCode.ShowInformation("Successfully added the customer P.O.Box address", "INFORMATION - Business P.O.Box Address Added Successfully");
                    }

                    ClearPoBoxAddressInput();
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
                if (mCustomer.CustomerTelephoneNumberList == null)
                {
                    // Create new List
                    mCustomer.CustomerTelephoneNumberList = new BindingList<string> { mtxtTelephoneNumber.Text };
                    Added = true;
                }
                else // Add To List
                {
                    mCustomer.CustomerTelephoneNumberList.Add(mtxtTelephoneNumber.Text);
                    Added = true;
                }

                mtxtTelephoneNumber.ResetText();
            }

            if (mtxtCellphoneNumber.Text.Length > 10 && !PhoneNumberExisting(mtxtCellphoneNumber.Text))
            {
                if (mCustomer.CustomerCellphoneNumberList == null)
                {
                    // Create new List
                    mCustomer.CustomerCellphoneNumberList = new BindingList<string> { mtxtCellphoneNumber.Text };
                    Added = true;
                }
                else // Add To List
                {
                    mCustomer.CustomerCellphoneNumberList.Add(mtxtCellphoneNumber.Text);
                    Added = true;
                }

                mtxtCellphoneNumber.ResetText();
            }

            if (Added)
            {
                MainProgramCode.ShowInformation("Successfully added the customer phone number/s", "INFORMATION - Customer Phone Number/s Added Successfully");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancellation can cause any changes to be lost.", "REQUEST - Cancellation")) Close();
        }

        private void BtnViewAll_Click(object sender, EventArgs e)
        {
            if (mCustomer.CustomerCellphoneNumberList != null || mCustomer.CustomerTelephoneNumberList != null)
            {
                mPassed.CustomerToChange = mCustomer;
                mPassed.ChangeSpecificObject = !updatedCustomerInformationToolStripMenuItem.Enabled;

                Hide();
                QuoteSwiftMainCode.ViewBusinessesPhoneNumbers();
                Show();

                mCustomer = mPassed.CustomerToChange;
                mPassed.CustomerToChange = null;
                mPassed.ChangeSpecificObject = false;
            }
            else MainProgramCode.ShowError("You need to first add at least one phone number before you can view the list of phone numbers.\nPlease add a phone number first", "ERROR - Can't View Non-Existing Customer Phone Numbers");
        }

        private void BtnViewAllPOBoxAddresses_Click(object sender, EventArgs e)
        {
            if (mCustomer.CustomerPoBoxAddress != null)
            {
                mPassed.CustomerToChange = mCustomer;
                mPassed.ChangeSpecificObject = !updatedCustomerInformationToolStripMenuItem.Enabled;

                Hide();
                QuoteSwiftMainCode.ViewBusinessesPoBoxAddresses();
                Show();

                mCustomer = mPassed.CustomerToChange;
                mPassed.CustomerToChange = null;
                mPassed.ChangeSpecificObject = false;
            }
            else MainProgramCode.ShowError("You need to first add an P.O.Box address before you can view the list of addresses.\nPlease add an address first", "ERROR - Can't View Non-Existing Customer P.O.Box Addresses");
        }

        private void BtnViewEmailAddresses_Click(object sender, EventArgs e)
        {
            if (mCustomer.CustomerEmailList != null)
            {
                mPassed.CustomerToChange = mCustomer;
                mPassed.ChangeSpecificObject = !updatedCustomerInformationToolStripMenuItem.Enabled;

                Hide();
                QuoteSwiftMainCode.ViewBusinessesEmailAddresses();
                Show();

                mCustomer = mPassed.CustomerToChange;
                mPassed.CustomerToChange = null;
                mPassed.ChangeSpecificObject = false;

            }
            else MainProgramCode.ShowError("You need to first add an Email address before you can view the list of addresses.\nPlease add an address first", "ERROR - Can't View Non-Existing Customer Email Addresses");
        }

        private void BtnViewAddresses_Click(object sender, EventArgs e)
        {
            if (mCustomer != null)
            {
                mPassed.CustomerToChange = mCustomer;
                mPassed.ChangeSpecificObject = !updatedCustomerInformationToolStripMenuItem.Enabled;

                Hide();
                QuoteSwiftMainCode.ViewBusinessesAddresses();
                Show();

                mCustomer = mPassed.CustomerToChange;
                mPassed.CustomerToChange = null;
                mPassed.ChangeSpecificObject = false;
            }
            else MainProgramCode.ShowError("You need to first add an address before you can view the list of addresses.\nPlease add an address first", "ERROR - Can't View Non-Existing Customer Addresses");
        }

        private void UpdatedCustomerInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertToEdit();
            mPassed.ChangeSpecificObject = true;
            updatedCustomerInformationToolStripMenuItem.Enabled = false;
        }

        private void BtnAddEmail_Click(object sender, EventArgs e)
        {
            if (mtxtEmailAddress.Text.Length > 3 && mtxtEmailAddress.Text.Contains("@"))
            {
                if (!EmailAddressExisting(mtxtEmailAddress.Text))
                {
                    if (mCustomer.CustomerEmailList == null)
                    {
                        //Create New List
                        mCustomer.CustomerEmailList = new BindingList<string> { mtxtEmailAddress.Text };
                        MainProgramCode.ShowInformation("Successfully added the customer Email address", "INFORMATION - Customer Email Address Added Successfully");
                    }
                    else //Add To Existing List
                    {
                        mCustomer.CustomerEmailList.Add(mtxtEmailAddress.Text);
                        MainProgramCode.ShowInformation("Successfully added the business Email address", "INFORMATION - Customer Email Address Added Successfully");
                    }

                    mtxtEmailAddress.ResetText();
                }
            }
            else MainProgramCode.ShowError("The provided Email Address is invalid. Please provide a valid Email Address", "ERROR - Invalid Email Address");
        }

        private void FrmAddCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            QuoteSwiftMainCode.CloseApplication(true);
        }

        /** Form Specific Functions And Procedures: 
       *
       * Note: Not all Functions or Procedures below are used more than once
       *       Some of them are only to keep the above events readable 
       *       and clutter free.                                                          
       */

        private bool ValidCustomerAddress()
        {
            if (txtCustomerAddresssDescription.Text.Length < 2)
            {
                MainProgramCode.ShowError("The provided Business Address Description is invalid, please provide a valid description", "ERROR - Invalid Business Address Description");
                return (false);
            }

            if (txtAtt.Text.Length < 2)
            {
                MainProgramCode.ShowError("The provided Business Address Street Name is invalid, please provide a valid street name", "ERROR - Invalid Business Address Street Name");
                return (false);
            }

            if (txtWorkArea.Text.Length < 2)
            {
                MainProgramCode.ShowError("The provided Business Address Suburb is invalid, please provide a valid suburb", "ERROR - Invalid Business Address Suburb");
                return (false);
            }

            if (txtWorkPlace.Text.Length < 2)
            {
                MainProgramCode.ShowError("The provided Business Address City is invalid, please provide a valid city", "ERROR - Invalid Business Address City");
                return (false);
            }

            return true;
        }

        private bool ValidCustomerPoBoxAddress()
        {
            if (txtCustomerPODescription.Text.Length < 2)
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

            if (mtxtVendorNumber.Text.Length < 5)
            {
                MainProgramCode.ShowError("The provided vendor number is invalid, please provide a valid vendor number.", "ERROR - Invalid Business Registration Number");
                return false;
            }

            if (mCustomer.CustomerDeliveryAddressList == null)
            {
                MainProgramCode.ShowError("Please add a valid customer delivery address under the 'Customer Address' section.", "ERROR - Current Customer Invalid");
                return false;
            }

            if (mCustomer.CustomerPoBoxAddress == null)
            {
                MainProgramCode.ShowError("Please add a valid customer P.O.Box address under the 'Customer P.O.Box Address' section.", "ERROR - Current Customer Invalid");
                return false;
            }

            if (mCustomer.CustomerCellphoneNumberList == null && mCustomer.CustomerTelephoneNumberList == null)
            {
                MainProgramCode.ShowError("Please add a valid phone number under the 'Phone Related' section.", "ERROR - Current Customer Invalid");
                return false;
            }

            if (mCustomer.CustomerEmailList == null)
            {
                MainProgramCode.ShowError("Please add a valid customer email address under the 'Email Related' section.", "ERROR - Current Customer Invalid");
                return false;
            }

            return true;
        }

        private void DisableMainComponents()
        {
            gbxCustomerInformation.Enabled = false;
            gbxCustomerAddress.Enabled = false;
            gbxPhoneRelated.Enabled = false;
            gbxEmailRelated.Enabled = false;
            gbxPOBoxAddress.Enabled = false;
            btnAddCustomer.Enabled = false;
        }

        private void ClearCustomerAddressInput()
        {
            txtCustomerAddresssDescription.ResetText();
            txtAtt.ResetText();
            txtWorkArea.ResetText();
            txtWorkPlace.ResetText();
        }

        private void ClearPoBoxAddressInput()
        {
            txtCustomerPODescription.ResetText();
            mtxtPOBoxStreetNumber.ResetText();
            txtPOBoxSuburb.ResetText();
            txtPOBoxCity.ResetText();
            mtxtPOBoxAreaCode.ResetText();
        }

        private void ResetScreenInput()
        {
            txtCustomerCompanyName.ResetText();
            cbBusinessSelection.ResetText();
            mtxtVATNumber.ResetText();
            mtxtRegistrationNumber.ResetText();
            ClearCustomerAddressInput();
            ClearPoBoxAddressInput();
            mtxtEmailAddress.ResetText();
            mtxtCellphoneNumber.ResetText();
            mtxtTelephoneNumber.ResetText();
            mtxtVendorNumber.ResetText();
        }

        public bool AddressExisting(Address a)
        {
            if (mCustomer.CustomerDeliveryAddressList != null)
            {
                for (int i = 0; i < mCustomer.CustomerDeliveryAddressList.Count; i++)
                {
                    if (mCustomer.CustomerDeliveryAddressList.SingleOrDefault(p => p.AddressDescription == a.AddressDescription) != null)
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

            if (mCustomer.CustomerPoBoxAddress != null)
            {
                for (int i = 0; i < mCustomer.CustomerPoBoxAddress.Count; i++)
                {
                    if (mCustomer.CustomerPoBoxAddress.SingleOrDefault(p => p.AddressDescription == a.AddressDescription) != null)
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
            if (mCustomer.CustomerEmailList != null)
            {
                if (mCustomer.CustomerEmailList.SingleOrDefault(p => p == s) != null)
                {
                    MainProgramCode.ShowError("This email address has already been added previously.", "ERROR - Email Address Already Added");
                    return true;
                }
            }
            return false;
        }

        public bool PhoneNumberExisting(string s)
        {
            if (mCustomer.CustomerTelephoneNumberList != null)
            {
                for (int i = 0; i < mCustomer.CustomerTelephoneNumberList.Count; i++)
                {
                    if (mCustomer.CustomerTelephoneNumberList.SingleOrDefault(p => p == s) != null)
                    {
                        MainProgramCode.ShowError("This number has already been added previously to the Telephone Number List.", "ERROR - Number Already Added");
                        return true;
                    }
                }
            }

            if (mCustomer.CustomerTelephoneNumberList != null)
            {
                for (int i = 0; i < mCustomer.CustomerTelephoneNumberList.Count; i++)
                {
                    if (mCustomer.CustomerTelephoneNumberList.SingleOrDefault(p => p == s) != null)
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
            if (mCustomer != null)
            {
                mContainer = mPassed.BusinessToChange;
                mPassed.BusinessToChange = null;

                txtCustomerCompanyName.Text = mCustomer.CustomerCompanyName;
                cbBusinessSelection.Text = mContainer.BusinessName;
                mtxtVATNumber.Text = mCustomer.CustomerLegalDetails.VatNumber;
                mtxtRegistrationNumber.Text = mCustomer.CustomerLegalDetails.RegistrationNumber;
                mtxtVendorNumber.Text = mCustomer.VendorNumber;
            }
        }

        private void ConvertToViewOnly()
        {
            QuoteSwiftMainCode.ReadOnlyComponents(gbxCustomerInformation.Controls);
            QuoteSwiftMainCode.ReadOnlyComponents(gbxCustomerAddress.Controls);
            QuoteSwiftMainCode.ReadOnlyComponents(gbxEmailRelated.Controls);
            QuoteSwiftMainCode.ReadOnlyComponents(gbxLegalInformation.Controls);
            QuoteSwiftMainCode.ReadOnlyComponents(gbxPhoneRelated.Controls);
            QuoteSwiftMainCode.ReadOnlyComponents(gbxPOBoxAddress.Controls);

            btnViewAddresses.Enabled = true;
            btnViewAll.Enabled = true;
            btnViewAllPOBoxAddresses.Enabled = true;
            btnViewEmailAddresses.Enabled = true;

            btnAddCustomer.Visible = false;
            Text = Text.Replace("Add Customer", "Viewing " + mCustomer.CustomerName);
            updatedCustomerInformationToolStripMenuItem.Enabled = true;
        }

        private void ConvertToEdit()
        {
            QuoteSwiftMainCode.ReadWriteComponents(gbxCustomerInformation.Controls);
            QuoteSwiftMainCode.ReadWriteComponents(gbxCustomerAddress.Controls);
            QuoteSwiftMainCode.ReadWriteComponents(gbxEmailRelated.Controls);
            QuoteSwiftMainCode.ReadWriteComponents(gbxLegalInformation.Controls);
            QuoteSwiftMainCode.ReadWriteComponents(gbxPhoneRelated.Controls);
            QuoteSwiftMainCode.ReadWriteComponents(gbxPOBoxAddress.Controls);

            btnAddCustomer.Visible = true;
            btnAddCustomer.Text = "Update Customer";
            if (mPassed != null && mPassed.BusinessToChange != null)
                Text = Text.Replace("Viewing " + mPassed.BusinessToChange.BusinessName, "Updating " + mPassed.BusinessToChange.BusinessName);
            if (mPassed != null && mPassed.CustomerToChange != null)
                Text = Text.Replace("Viewing " + mPassed.CustomerToChange.CustomerName, "Updating " + mPassed.CustomerToChange.CustomerName);
            updatedCustomerInformationToolStripMenuItem.Enabled = false;
        }

        private Business GetSelectedBusiness()
        {
            if (mPassed.BusinessMap != null && cbBusinessSelection.Text.Length > 0)
            {
                for (int i = 0; i < mPassed.BusinessMap.Count; i++)
                {
                    if (mPassed.BusinessMap.Values.ToArray()[i].BusinessName == cbBusinessSelection.Text) return mPassed.BusinessMap.Values.ToArray()[i];
                }
            }

            return null;
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        /**********************************************************************************/
    }
}
