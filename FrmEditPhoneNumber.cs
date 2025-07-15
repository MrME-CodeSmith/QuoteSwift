using System;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmEditPhoneNumber : Form
    {

        readonly ApplicationData appData;
        readonly Business business;
        readonly Customer customer;
        string number;

        public FrmEditPhoneNumber(ApplicationData data, Business business = null, Customer customer = null, string number = "")
        {
            InitializeComponent();
            appData = data;
            this.business = business;
            this.customer = customer;
            this.number = number;
        }

        private void FrmEditPhoneNumber_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(number))
                txtPhoneNumber.Text = number;
        }

        private void BtnUpdateNumber_Click(object sender, EventArgs e)
        {
            string newNumber = txtPhoneNumber.Text;
            if (business != null)
            {
                bool isCell = business.CellphoneNumbers.Contains(number);
                bool isTel = business.TelephoneNumbers.Contains(number);
                if (!business.CellphoneNumbers.Contains(newNumber) && !business.TelephoneNumbers.Contains(newNumber))
                {
                    if (isCell)
                        business.UpdateCellphoneNumber(number, newNumber);
                    else if (isTel)
                        business.UpdateTelephoneNumber(number, newNumber);
                    number = newNumber;
                    MainProgramCode.ShowInformation("The phone number was updated successfully.", "INFORMATION - Phone Number Updated Successfully");
                    Close();
                }
            }
            else if (customer != null)
            {
                bool isCell = customer.CellphoneNumbers.Contains(number);
                bool isTel = customer.TelephoneNumbers.Contains(number);
                if (!customer.CellphoneNumbers.Contains(newNumber) && !customer.TelephoneNumbers.Contains(newNumber))
                {
                    if (isCell)
                        customer.UpdateCellphoneNumber(number, newNumber);
                    else if (isTel)
                        customer.UpdateTelephoneNumber(number, newNumber);
                    number = newNumber;
                    MainProgramCode.ShowInformation("The phone number was updated successfully.", "INFORMATION - Phone Number Updated Successfully");
                    Close();
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("By canceling the current event, any parts not added will not be available in the part's list.", "REQUEAST - Action Cancellation")) Close();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                appData.SaveAll();
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmEditPhoneNumber_FormClosing(object sender, FormClosingEventArgs e)
        {
            appData.SaveAll();
        }
    }
}
