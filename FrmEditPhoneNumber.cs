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
    public partial class FrmEditPhoneNumber : Form
    {

        Pass passed;

        public ref Pass Passed { get => ref passed; }

        public FrmEditPhoneNumber(ref Pass passed)
        {
            InitializeComponent();
            this.passed = passed;
        }

        private void FrmEditPhoneNumber_Load(object sender, EventArgs e)
        {
            if(passed.PhoneNumberToChange != "") txtPhoneNumber.Text = passed.PhoneNumberToChange;
        }

        private void BtnUpdateNumber_Click(object sender, EventArgs e)
        {
            FrmAddBusiness frmAddBusiness = new FrmAddBusiness(ref passed);
            if(!frmAddBusiness.PhoneNumberExisting(txtPhoneNumber.Text))
            {
                passed.PhoneNumberToChange = txtPhoneNumber.Text;
                MainProgramCode.ShowInformation("The phone number was updated successfully.","INFORMATION - Phone Number Updated Successfully");
                this.Close();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
           if (MainProgramCode.RequestConfirmation("By canceling the current event, any parts not added will not be available in the part's list.", "REQUEAST - Action Cancelation")) this.Close();
        }
    }
}
