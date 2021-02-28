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
    public partial class FrmAddCustomer : Form
    {

        Pass passed;

        Customer Customer;

        Business Container;

        public ref Pass Passed { get => ref passed; }

        public FrmAddCustomer(ref Pass passed)
        {
            InitializeComponent();
            this.Passed = passed;
            Customer = passed.CustomerToChange;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainProgramCode.CloseApplication(MainProgramCode.RequestConfirmation("Are you sure you want to close the application?\nAny unsaved work will be lost.", "REQUEST - Application Termination"), ref this.passed);
        }

        private void BtnAddCustomer_Click(object sender, EventArgs e)
        {
            if (ValidBusiness() && !passed.ChangeSpecificObject)
            {
                Business LinkBusiness = GetSelectedBusiness();

                //Add Final Details to Customer object
                Customer.CustomerName = txtCustomerName.Text;
                Customer.CustomerCompanyName = txtCustomerCompanyName.Text;
                Customer.CustomerLegalDetails = new Legal(mtxtRegistrationNumber.Text, mtxtVATNumber.Text);
                Customer.VendorNumber = mtxtVendorNumber.Text;

                if (LinkBusiness.BusinessCustomerList == null)
                {
                    //Create New Customer List
                    LinkBusiness.BusinessCustomerList = new BindingList<Customer> { Customer };
                }
                else //Add To List
                {
                    if (LinkBusiness.BusinessCustomerList.SingleOrDefault(p => p.CustomerName == Customer.CustomerName) != null)
                    {
                        MainProgramCode.ShowError("This customer has already been added previously.\nHINT: Customer Name,VAT Number and Registration Number should be unique", "ERROR - Customer Already Added");
                        return;
                    }
                    else LinkBusiness.BusinessCustomerList.Add(Customer);
                }

                this.passed.CustomerToChange = null;
                this.passed.ChangeSpecificObject = false;

                MainProgramCode.ShowInformation(Customer.CustomerName + " has been added.", "INFORMATION - Business Sucessfully Added");

                ResetScreenInput();
            }
            else if (ValidBusiness() && passed.ChangeSpecificObject)
            {
                passed.CustomerToChange.CustomerName = txtCustomerName.Text;
                passed.CustomerToChange.CustomerCompanyName = txtCustomerCompanyName.Text;
                passed.CustomerToChange.CustomerLegalDetails = new Legal(mtxtRegistrationNumber.Text, mtxtVATNumber.Text);
                passed.CustomerToChange.VendorNumber = mtxtVendorNumber.Text;

                MainProgramCode.ShowInformation(Customer.CustomerName + " has been successfully updated.", "INFORMATION - Customer Sucessfully Updated");
                ConvertToViewOnly();
            }
        }

        private void FrmAddCustomer_Load(object sender, EventArgs e)
        {
            FrmViewCustomers frmViewCustomers = new FrmViewCustomers(ref this.passed);
            frmViewCustomers.LinkBusinessToSource(ref cbBusinessSelection);

            if (passed.CustomerToChange != null && passed.ChangeSpecificObject) // Change Existing Customer Info
            {
                Customer = passed.CustomerToChange;
            }
            else if (passed.CustomerToChange != null && !passed.ChangeSpecificObject) // View Existing Customer Info
            {
                Customer = passed.CustomerToChange;
                ConvertToViewOnly();

                LoadInformation();
            }
            else if (passed.CustomerToChange == null && !passed.ChangeSpecificObject) // Add New Business Info
            {
                Customer = new Customer();
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
                Address address = new Address(txtCustomerAddresssDescription.Text, MainProgramCode.ParseInt(mtxtStreetnumber.Text),
                                              txtStreetName.Text, txtSuburb.Text, txtCity.Text, MainProgramCode.ParseInt(mtxtAreaCode.Text));
                if (!AddressExisting(address))
                {
                    if (Customer.CustomerDeliveryAddressList == null)
                    {
                        //Create New List
                        Customer.CustomerDeliveryAddressList = new BindingList<Address> { address };
                        MainProgramCode.ShowInformation("Successfuly added the customer address", "INFORMATION - Customer Address Added Successfully");
                    }
                    else //Add To Current list
                    {
                        Customer.CustomerDeliveryAddressList.Add(address);
                        MainProgramCode.ShowInformation("Successfuly added the customer address", "INFORMATION - Customer Address Added Successfully");
                    }

                    ClearCustomerAddressInput();
                }
            }
        }

        private void BtnAddPOBoxAddress_Click(object sender, EventArgs e)
        {
            if (ValidCustomerPOBoxAddress())
            {
                Address address = new Address(txtCustomerPODescription.Text, MainProgramCode.ParseInt(mtxtPOBoxStreetNumber.Text),
                                              txtPOBoxStreetName.Text, txtPOBoxSuburb.Text, txtPOBoxCity.Text, MainProgramCode.ParseInt(mtxtPOBoxAreaCode.Text));
                if (!POBoxAddressExisting(address))
                {
                    if (Customer.CustomerPOBoxAddress == null)
                    {
                        //Create New List
                        Customer.CustomerPOBoxAddress = new BindingList<Address> { address };
                        MainProgramCode.ShowInformation("Successfuly added the customer P.O.Box address", "INFORMATION - Business P.O.Box Address Added Successfully");
                    }
                    else // AddingNewEventArgs To list
                    {
                        Customer.CustomerPOBoxAddress.Add(address);
                        MainProgramCode.ShowInformation("Successfuly added the customer P.O.Box address", "INFORMATION - Business P.O.Box Address Added Successfully");
                    }

                    ClearPOBoxAddressInput();
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
                if (Customer.CustomerTelephoneNumberList == null)
                {
                    // Create new List
                    Customer.CustomerTelephoneNumberList = new BindingList<string> { mtxtTelephoneNumber.Text };
                    Added = true;
                }
                else // Add To List
                {
                    Customer.CustomerTelephoneNumberList.Add(mtxtTelephoneNumber.Text);
                    Added = true;
                }

                mtxtTelephoneNumber.ResetText();
            }

            if (mtxtCellphoneNumber.Text.Length > 10 && !PhoneNumberExisting(mtxtCellphoneNumber.Text))
            {
                if (Customer.CustomerCellphoneNumberList == null)
                {
                    // Create new List
                    Customer.CustomerCellphoneNumberList = new BindingList<string> { mtxtCellphoneNumber.Text };
                    Added = true;
                }
                else // Add To List
                {
                    Customer.CustomerCellphoneNumberList.Add(mtxtCellphoneNumber.Text);
                    Added = true;
                }

                mtxtCellphoneNumber.ResetText();
            }

            if (Added)
            {
                MainProgramCode.ShowInformation("Successfuly added the customer phone number/s", "INFORMATION - Customer Phone Number/s Added Successfully");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancelation can cause any changes to be lost.", "REQUEST - Cancelation")) this.Close();
        }

        private void BtnViewAll_Click(object sender, EventArgs e)
        {
            if (Customer.CustomerCellphoneNumberList != null || Customer.CustomerTelephoneNumberList != null)
            {
                this.passed.CustomerToChange = Customer;
                this.Hide();
                this.passed = MainProgramCode.ViewBusinessesPhoneNumbers(ref this.passed);
                this.Show();
                Customer = this.passed.CustomerToChange;
            }
            else MainProgramCode.ShowError("You need to first add at least one phone number before you can view the list of phone numbers.\nPlease add a phone number first", "ERROR - Can't View Non-Existing Customer Phone Numebrs");
        }

        private void BtnViewAllPOBoxAddresses_Click(object sender, EventArgs e)
        {
            if (Customer.CustomerPOBoxAddress != null)
            {
                this.passed.CustomerToChange = Customer;
                this.Hide();
                this.passed = MainProgramCode.ViewBusinessesPOBoxAddresses(ref this.passed);
                this.Show();
                Customer = this.passed.CustomerToChange;
            }
            else MainProgramCode.ShowError("You need to first add an P.O.Box address before you can view the list of addresses.\nPlease add an address first", "ERROR - Can't View Non-Existing Customer P.O.Box Addresses");
        }

        private void BtnViewEmailAddresses_Click(object sender, EventArgs e)
        {
            if (Customer.CustomerEmailList != null)
            {
                this.passed.CustomerToChange = Customer;
                this.Hide();
                this.passed = MainProgramCode.ViewBusinessesEmailAddresses(ref this.passed);
                this.Show();
                Customer = this.passed.CustomerToChange;

            }
            else MainProgramCode.ShowError("You need to first add an Email address before you can view the list of addresses.\nPlease add an address first", "ERROR - Can't View Non-Existing Customer Email Addresses");
        }

        private void BtnViewAddresses_Click(object sender, EventArgs e)
        {
            if (Customer != null)
            {
                this.passed.CustomerToChange = Customer;
                this.Hide();
                this.passed = MainProgramCode.ViewBusinessesAddresses(ref this.passed);
                this.Show();
                Customer = this.passed.CustomerToChange;
            }
            else MainProgramCode.ShowError("You need to first add an address before you can view the list of addresses.\nPlease add an address first", "ERROR - Can't View Non-Existing Customer Addresses");
        }

        private void UpdatedCustomerInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertToEdit();
            this.passed.ChangeSpecificObject = true;
            updatedCustomerInformationToolStripMenuItem.Enabled = false;
        }

        private void BtnAddEmail_Click(object sender, EventArgs e)
        {
            if (mtxtEmailAddress.Text.Length > 3 && mtxtEmailAddress.Text.Contains("@"))
            {
                if (!EmailAddressExisting(mtxtEmailAddress.Text))
                {
                    if (Customer.CustomerEmailList == null)
                    {
                        //Create New List
                        Customer.CustomerEmailList = new BindingList<string> { mtxtEmailAddress.Text };
                        MainProgramCode.ShowInformation("Successfuly added the customer Email address", "INFORMATION - Customer Email Address Added Successfully");
                    }
                    else //Add To Existing List
                    {
                        Customer.CustomerEmailList.Add(mtxtEmailAddress.Text);
                        MainProgramCode.ShowInformation("Successfuly added the business Email address", "INFORMATION - Customer Email Address Added Successfully");
                    }

                    mtxtEmailAddress.ResetText();
                }
            }
            else MainProgramCode.ShowError("The provided Email Address is invalid. Please provide a valid Email Address", "ERROR - Invalid Email Address");
        }

        private void FrmAddCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (passed != null)
            {
                if (passed.CustomerToChange != null) passed.CustomerToChange = null;
                if (passed.ChangeSpecificObject) passed.ChangeSpecificObject = false;
            }
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

        private bool ValidCustomerPOBoxAddress()
        {
            if (txtCustomerPODescription.Text.Length < 2)
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
            if (txtCustomerName.Text.Length < 3)
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

            if(mtxtVendorNumber.Text.Length < 5)
            {
                MainProgramCode.ShowError("The provided vendor number is invalid, please provide a valid vendor number.", "ERROR - Invalid Business Registration Number");
                return false;
            }

            if (Customer.CustomerDeliveryAddressList == null)
            {
                MainProgramCode.ShowError("Please add a valid customer delivery address under the 'Customer Address' section.", "ERROR - Current Customer Invalid");
                return false;
            }

            if (Customer.CustomerPOBoxAddress == null)
            {
                MainProgramCode.ShowError("Please add a valid customer P.O.Box address under the 'Customer P.O.Box Address' section.", "ERROR - Current Customer Invalid");
                return false;
            }

            if (Customer.CustomerCellphoneNumberList== null && Customer.CustomerTelephoneNumberList == null)
            {
                MainProgramCode.ShowError("Please add a valid phone number under the 'Phone Related' section.", "ERROR - Current Customer Invalid");
                return false;
            }

            if (Customer.CustomerEmailList == null)
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
            mtxtStreetnumber.ResetText();
            txtStreetName.ResetText();
            txtSuburb.ResetText();
            txtCity.ResetText();
            mtxtAreaCode.ResetText();
        }

        private void ClearPOBoxAddressInput()
        {
            txtCustomerPODescription.ResetText();
            mtxtPOBoxStreetNumber.ResetText();
            txtPOBoxStreetName.ResetText();
            txtPOBoxSuburb.ResetText();
            txtPOBoxCity.ResetText();
            mtxtPOBoxAreaCode.ResetText();
        }

        private void ResetScreenInput()
        {
            txtCustomerName.ResetText();
            txtCustomerCompanyName.ResetText();
            cbBusinessSelection.ResetText();
            mtxtVATNumber.ResetText();
            mtxtRegistrationNumber.ResetText();
            ClearCustomerAddressInput();
            ClearPOBoxAddressInput();
            mtxtEmailAddress.ResetText();
            mtxtCellphoneNumber.ResetText();
            mtxtTelephoneNumber.ResetText();
        }

        public bool AddressExisting(Address a)
        {
            if (Customer.CustomerDeliveryAddressList != null)
            {
                for (int i = 0; i < Customer.CustomerDeliveryAddressList.Count; i++)
                {
                    if (Customer.CustomerDeliveryAddressList.SingleOrDefault(p => p.AddressDescription == a.AddressDescription) != null)
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

            if (Customer.CustomerPOBoxAddress != null)
            {
                for (int i = 0; i < Customer.CustomerPOBoxAddress.Count; i++)
                {
                    if (Customer.CustomerPOBoxAddress.SingleOrDefault(p => p.AddressDescription == a.AddressDescription) != null)
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
            if (Customer.CustomerEmailList != null)
            {
                if (Customer.CustomerEmailList.SingleOrDefault(p => p == s) != null)
                {
                    MainProgramCode.ShowError("This email address has already been added previously.", "ERROR - Email Address Already Added");
                    return true;
                }
            }
            return false;
        }

        public bool PhoneNumberExisting(string s)
        {
            if (Customer.CustomerTelephoneNumberList != null)
            {
                for (int i = 0; i < Customer.CustomerTelephoneNumberList.Count; i++)
                {
                    if (Customer.CustomerTelephoneNumberList.SingleOrDefault(p => p == s) != null)
                    {
                        MainProgramCode.ShowError("This number has already been added previously to the Telephone Number List.", "ERROR - Number Already Added");
                        return true;
                    }
                }
            }

            if (Customer.CustomerTelephoneNumberList != null)
            {
                for (int i = 0; i < Customer.CustomerTelephoneNumberList.Count; i++)
                {
                    if (Customer.CustomerTelephoneNumberList.SingleOrDefault(p => p == s) != null)
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
            if (Customer != null)
            {
                Container = passed.BusinessToChange;
                passed.BusinessToChange = null;

                txtCustomerName.Text = Customer.CustomerName;
                txtCustomerCompanyName.Text = Customer.CustomerCompanyName;
                cbBusinessSelection.Text = Container.BusinessName;
                mtxtVATNumber.Text = Customer.CustomerLegalDetails.VatNumber;
                mtxtRegistrationNumber.Text = Customer.CustomerLegalDetails.RegistrationNumber;
                mtxtVendorNumber.Text = Customer.VendorNumber;
            }
        }

        private void ConvertToViewOnly()
        {
            MainProgramCode.ReadOnlyComponents(gbxCustomerInformation.Controls);
            MainProgramCode.ReadOnlyComponents(gbxCustomerAddress.Controls);
            MainProgramCode.ReadOnlyComponents(gbxEmailRelated.Controls);
            MainProgramCode.ReadOnlyComponents(gbxLegalInformation.Controls);
            MainProgramCode.ReadOnlyComponents(gbxPhoneRelated.Controls);
            MainProgramCode.ReadOnlyComponents(gbxPOBoxAddress.Controls);

            btnViewAddresses.Enabled = true;
            btnViewAll.Enabled = true;
            btnViewAllPOBoxAddresses.Enabled = true;
            btnViewEmailAddresses.Enabled = true;

            btnAddCustomer.Visible = false;
            this.Text = this.Text.Replace("Add Customer", "Viewing " + Customer.CustomerName);
        }

        private void ConvertToEdit()
        {
            MainProgramCode.ReadWriteComponents(gbxCustomerInformation.Controls);
            MainProgramCode.ReadWriteComponents(gbxCustomerAddress.Controls);
            MainProgramCode.ReadWriteComponents(gbxEmailRelated.Controls);
            MainProgramCode.ReadWriteComponents(gbxLegalInformation.Controls);
            MainProgramCode.ReadWriteComponents(gbxPhoneRelated.Controls);
            MainProgramCode.ReadWriteComponents(gbxPOBoxAddress.Controls);

            btnAddCustomer.Visible = true;
            btnAddCustomer.Text = "Update Customer";
            if(passed != null && passed.BusinessToChange != null)
                this.Text = this.Text.Replace("Viewing " + passed.BusinessToChange.BusinessName, "Updating " + passed.BusinessToChange.BusinessName);
            if(passed!= null && passed.CustomerToChange != null)
                this.Text = this.Text.Replace("Viewing " + passed.CustomerToChange.CustomerName, "Updating " + passed.CustomerToChange.CustomerName);
        }

        private Business GetSelectedBusiness()
        {
            if (passed.PassBusinessList != null && cbBusinessSelection.Text.Length > 0)
            {
                for (int i = 0; i < passed.PassBusinessList.Count; i++)
                {
                    if (passed.PassBusinessList[i].BusinessName == cbBusinessSelection.Text) return passed.PassBusinessList[i];
                }
            }

            return null;
        }

        /**********************************************************************************/
    }
}
