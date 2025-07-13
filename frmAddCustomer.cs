using System;
using System.ComponentModel;
using System.Linq;
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
            Passed = passed;
            Customer = passed.CustomerToChange;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                QuoteSwiftMainCode.CloseApplication(true, ref passed);
        }

        private void BtnAddCustomer_Click(object sender, EventArgs e)
        {
            if (ValidBusiness() && !passed.ChangeSpecificObject)
            {
                Business LinkBusiness = GetSelectedBusiness();
                if (LinkBusiness == null)
                {
                    MainProgramCode.ShowError("Please select a valid Business, the current selection is invalid", "ERROR - Invalid Business Selection");
                    return;
                }

                //Add Final Details to Customer object
                Customer.CustomerName = "";
                Customer.CustomerCompanyName = txtCustomerCompanyName.Text;
                Customer.CustomerLegalDetails = new Legal(mtxtRegistrationNumber.Text, mtxtVATNumber.Text);
                Customer.VendorNumber = mtxtVendorNumber.Text;

                if (LinkBusiness.CustomerMap.ContainsKey(Customer.CustomerCompanyName))
                {
                    MainProgramCode.ShowError("This customer has already been added previously.\nHINT: Customer Name,VAT Number and Registration Number should be unique", "ERROR - Customer Already Added");
                    return;
                }
                if (LinkBusiness.BusinessCustomerList == null)
                    LinkBusiness.BusinessCustomerList = new BindingList<Customer>();
                LinkBusiness.BusinessCustomerList.Add(Customer);

                LinkBusiness.CustomerMap[Customer.CustomerCompanyName] = Customer;

                passed.CustomerToChange = null;
                passed.ChangeSpecificObject = false;

                MainProgramCode.ShowInformation(Customer.CustomerCompanyName + " has been added.", "INFORMATION - Business Successfully Added");

                ResetScreenInput();
            }
            else if (ValidBusiness() && passed.ChangeSpecificObject)
            {
                string oldName = passed.CustomerToChange.CustomerCompanyName;
                passed.CustomerToChange.CustomerName = "";
                passed.CustomerToChange.CustomerCompanyName = txtCustomerCompanyName.Text;
                passed.CustomerToChange.CustomerLegalDetails = new Legal(mtxtRegistrationNumber.Text, mtxtVATNumber.Text);
                passed.CustomerToChange.VendorNumber = mtxtVendorNumber.Text;

                Business container = GetSelectedBusiness();
                if (container == null)
                {
                    MainProgramCode.ShowError("Please select a valid Business, the current selection is invalid", "ERROR - Invalid Business Selection");
                    return;
                }

                if (container.CustomerMap.TryGetValue(passed.CustomerToChange.CustomerCompanyName, out Customer existing)
                    && existing != passed.CustomerToChange)
                {
                    MainProgramCode.ShowError("This customer name is already in use.", "ERROR - Duplicate Customer Name");
                    passed.CustomerToChange.CustomerCompanyName = oldName;
                    return;
                }

                container.CustomerMap.Remove(oldName);
                container.CustomerMap[passed.CustomerToChange.CustomerCompanyName] = passed.CustomerToChange;

                MainProgramCode.ShowInformation(Customer.CustomerCompanyName + " has been successfully updated.", "INFORMATION - Customer Successfully Updated");
                ConvertToViewOnly();
            }
        }

        private void FrmAddCustomer_Load(object sender, EventArgs e)
        {
            FrmViewCustomers frmViewCustomers = new FrmViewCustomers(ref passed);
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
                Address address = new Address(txtCustomerAddresssDescription.Text, 0, txtAtt.Text, txtWorkArea.Text, txtWorkPlace.Text, 0);
                if (!AddressExisting(address))
                {
                    if (Customer.CustomerDeliveryAddressList == null)
                    {
                        //Create New List
                        Customer.CustomerDeliveryAddressList = new BindingList<Address> { address };
                    }
                    else //Add To Current list
                    {
                        Customer.CustomerDeliveryAddressList.Add(address);
                    }
                    Customer.DeliveryAddressMap[StringUtil.NormalizeKey(address.AddressDescription)] = address;
                    MainProgramCode.ShowInformation("Successfully added the customer address", "INFORMATION - Customer Address Added Successfully");

                    ClearCustomerAddressInput();
                }
            }
        }

        private void BtnAddPOBoxAddress_Click(object sender, EventArgs e)
        {
            if (ValidCustomerPOBoxAddress())
            {
                Address address = new Address(txtCustomerPODescription.Text, QuoteSwiftMainCode.ParseInt(mtxtPOBoxStreetNumber.Text),
                                              "", txtPOBoxSuburb.Text, txtPOBoxCity.Text, QuoteSwiftMainCode.ParseInt(mtxtPOBoxAreaCode.Text));
                if (!POBoxAddressExisting(address))
                {
                    Customer.CustomerPOBoxAddress.Add(address);
                    Customer.POBoxMap[StringUtil.NormalizeKey(address.AddressDescription)] = address;
                    MainProgramCode.ShowInformation("Successfully added the customer P.O.Box address", "INFORMATION - Business P.O.Box Address Added Successfully");

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
                Customer.AddTelephoneNumber(mtxtTelephoneNumber.Text);
                Added = true;

                mtxtTelephoneNumber.ResetText();
            }

            if (mtxtCellphoneNumber.Text.Length > 10 && !PhoneNumberExisting(mtxtCellphoneNumber.Text))
            {
                Customer.AddCellphoneNumber(mtxtCellphoneNumber.Text);
                Added = true;

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
            if (Customer.CustomerCellphoneNumberList != null || Customer.CustomerTelephoneNumberList != null)
            {
                passed.CustomerToChange = Customer;
                passed.ChangeSpecificObject = !updatedCustomerInformationToolStripMenuItem.Enabled;

                Hide();
                passed = QuoteSwiftMainCode.ViewBusinessesPhoneNumbers(ref passed);
                Show();

                Customer = passed.CustomerToChange;
                passed.CustomerToChange = null;
                passed.ChangeSpecificObject = false;
            }
            else MainProgramCode.ShowError("You need to first add at least one phone number before you can view the list of phone numbers.\nPlease add a phone number first", "ERROR - Can't View Non-Existing Customer Phone Numbers");
        }

        private void BtnViewAllPOBoxAddresses_Click(object sender, EventArgs e)
        {
            if (Customer.CustomerPOBoxAddress != null)
            {
                passed.CustomerToChange = Customer;
                passed.ChangeSpecificObject = !updatedCustomerInformationToolStripMenuItem.Enabled;

                Hide();
                passed = QuoteSwiftMainCode.ViewBusinessesPOBoxAddresses(ref passed);
                Show();

                Customer = passed.CustomerToChange;
                passed.CustomerToChange = null;
                passed.ChangeSpecificObject = false;
            }
            else MainProgramCode.ShowError("You need to first add an P.O.Box address before you can view the list of addresses.\nPlease add an address first", "ERROR - Can't View Non-Existing Customer P.O.Box Addresses");
        }

        private void BtnViewEmailAddresses_Click(object sender, EventArgs e)
        {
            if (Customer.CustomerEmailList != null)
            {
                passed.CustomerToChange = Customer;
                passed.ChangeSpecificObject = !updatedCustomerInformationToolStripMenuItem.Enabled;

                Hide();
                passed = QuoteSwiftMainCode.ViewBusinessesEmailAddresses(ref passed);
                Show();

                Customer = passed.CustomerToChange;
                passed.CustomerToChange = null;
                passed.ChangeSpecificObject = false;

            }
            else MainProgramCode.ShowError("You need to first add an Email address before you can view the list of addresses.\nPlease add an address first", "ERROR - Can't View Non-Existing Customer Email Addresses");
        }

        private void BtnViewAddresses_Click(object sender, EventArgs e)
        {
            if (Customer != null)
            {
                passed.CustomerToChange = Customer;
                passed.ChangeSpecificObject = !updatedCustomerInformationToolStripMenuItem.Enabled;

                Hide();
                passed = QuoteSwiftMainCode.ViewBusinessesAddresses(ref passed);
                Show();

                Customer = passed.CustomerToChange;
                passed.CustomerToChange = null;
                passed.ChangeSpecificObject = false;
            }
            else MainProgramCode.ShowError("You need to first add an address before you can view the list of addresses.\nPlease add an address first", "ERROR - Can't View Non-Existing Customer Addresses");
        }

        private void UpdatedCustomerInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvertToEdit();
            passed.ChangeSpecificObject = true;
            updatedCustomerInformationToolStripMenuItem.Enabled = false;
        }

        private void BtnAddEmail_Click(object sender, EventArgs e)
        {
            if (mtxtEmailAddress.Text.Length > 3 && mtxtEmailAddress.Text.Contains("@"))
            {
                if (!EmailAddressExisting(mtxtEmailAddress.Text))
                {
                    Customer.AddEmailAddress(mtxtEmailAddress.Text);
                    MainProgramCode.ShowInformation("Successfully added the customer Email address", "INFORMATION - Customer Email Address Added Successfully");

                    mtxtEmailAddress.ResetText();
                }
            }
            else MainProgramCode.ShowError("The provided Email Address is invalid. Please provide a valid Email Address", "ERROR - Invalid Email Address");
        }

        private void FrmAddCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            QuoteSwiftMainCode.CloseApplication(true, ref passed);
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

        private bool ValidCustomerPOBoxAddress()
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

            if (Customer.CustomerCellphoneNumberList == null && Customer.CustomerTelephoneNumberList == null)
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
            txtAtt.ResetText();
            txtWorkArea.ResetText();
            txtWorkPlace.ResetText();
        }

        private void ClearPOBoxAddressInput()
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
            ClearPOBoxAddressInput();
            mtxtEmailAddress.ResetText();
            mtxtCellphoneNumber.ResetText();
            mtxtTelephoneNumber.ResetText();
            mtxtVendorNumber.ResetText();
        }

        public bool AddressExisting(Address a)
        {
            string key = StringUtil.NormalizeKey(a.AddressDescription);
            if (Customer.DeliveryAddressMap.ContainsKey(key))
            {
                MainProgramCode.ShowError("This address has already been added previously.\nHINT: Description should be unique", "ERROR - Address Already Added");
                return true;
            }

            return false;
        }

        private bool POBoxAddressExisting(Address a)
        {
            string key = StringUtil.NormalizeKey(a.AddressDescription);
            if (Customer.POBoxMap.ContainsKey(key))
            {
                MainProgramCode.ShowError("This P.O.Box address has already been added previously.\nHINT: Description should be unique", "ERROR - P.O.Box Address Already Added");
                return true;
            }

            return false;
        }

        public bool EmailAddressExisting(string s)
        {
            if (Customer.EmailAddresses.Contains(s))
            {
                MainProgramCode.ShowError("This email address has already been added previously.", "ERROR - Email Address Already Added");
                return true;
            }
            return false;
        }

        public bool PhoneNumberExisting(string s)
        {
            if (Customer.TelephoneNumbers.Contains(s) || Customer.CellphoneNumbers.Contains(s))
            {
                MainProgramCode.ShowError("This number has already been added previously.", "ERROR - Number Already Added");
                return true;
            }

            return false;
        }

        private void LoadInformation()
        {
            if (Customer != null)
            {
                Container = passed.BusinessToChange;
                passed.BusinessToChange = null;

                txtCustomerCompanyName.Text = Customer.CustomerCompanyName;
                cbBusinessSelection.Text = Container.BusinessName;
                mtxtVATNumber.Text = Customer.CustomerLegalDetails.VatNumber;
                mtxtRegistrationNumber.Text = Customer.CustomerLegalDetails.RegistrationNumber;
                mtxtVendorNumber.Text = Customer.VendorNumber;
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
            Text = Text.Replace("Add Customer", "Viewing " + Customer.CustomerName);
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
            if (passed != null && passed.BusinessToChange != null)
                Text = Text.Replace("Viewing " + passed.BusinessToChange.BusinessName, "Updating " + passed.BusinessToChange.BusinessName);
            if (passed != null && passed.CustomerToChange != null)
                Text = Text.Replace("Viewing " + passed.CustomerToChange.CustomerName, "Updating " + passed.CustomerToChange.CustomerName);
            updatedCustomerInformationToolStripMenuItem.Enabled = false;
        }

        private Business GetSelectedBusiness()
        {
            if (cbBusinessSelection.Text.Length > 0 && passed.BusinessLookup.TryGetValue(cbBusinessSelection.Text, out Business business))
            {
                return business;
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
