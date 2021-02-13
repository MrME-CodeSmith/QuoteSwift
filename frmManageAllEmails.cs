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
    public partial class FrmManageAllEmails : Form
    {

        Pass passed;

        public ref Pass Passed { get => ref passed; }

        public FrmManageAllEmails(ref Pass passed)
        {
            InitializeComponent();
            this.passed = passed;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainProgramCode.CloseApplication(MainProgramCode.RequestConfirmation("Are you sure you want to close the application?\nAny unsaved work will be lost.", "REQUEST - Application Termination"), ref this.passed);
        }

        private void FrmManageAllEmails_Load(object sender, EventArgs e)
        {
            if (passed != null && passed.BusinessToChange != null && passed.BusinessToChange.BusinessEmailAddressList != null)
            {
                this.Text = this.Text.Replace("< Business Name >", passed.BusinessToChange.BusinessName);

                LoadInformation();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancelation can cause any changes to be lost.", "REQUEST - Cancelation")) this.Close();
        }

        private void DgvEmails_Leave(object sender, EventArgs e)
        {
            //TODO: Determine if changes were made, if so then request if user wants to save changes.
        }

        private void BtnRemoveAddress_Click(object sender, EventArgs e)
        {
            string SelectedEmail = GetEmailSelection();
            if (SelectedEmail != "")
            {
                if (MainProgramCode.RequestConfirmation("Are you sure you want to permanently delete '" + SelectedEmail + "' email address from the list?", "REQUEST - Deletion Request"))
                {
                    passed.BusinessToChange.BusinessEmailAddressList.Remove(SelectedEmail);
                    MainProgramCode.ShowInformation("Successfully deleted '" + SelectedEmail + "' from the email address list", "CONFIRMATION - Deletion Success");
                    LoadInformation();
                }

                if (passed.BusinessToChange.BusinessEmailAddressList.Count == 0) passed.BusinessToChange.BusinessEmailAddressList = null;
            }
            else
            {
                MainProgramCode.ShowError("The current selection is invalid.\nPlease choose a valid email address from the list.", "ERROR - Invalid Selection");
            }
        }

        private void BtnChangeAddressInfo_Click(object sender, EventArgs e)
        {
            string email = GetEmailSelection();
            this.passed.EmailToChange = email;
            this.passed = MainProgramCode.EditBusinessEmailAddress(ref this.passed);

            if (passed.BusinessToChange != null && passed.BusinessToChange.BusinessEmailAddressList != null)
            {
                for (int i = 0; i < passed.BusinessToChange.BusinessEmailAddressList.Count; i++)
                {
                    if (passed.BusinessToChange.BusinessEmailAddressList[i] == email)
                    {
                        passed.BusinessToChange.BusinessEmailAddressList[i] = this.passed.EmailToChange;
                    }
                }
            }

            this.passed.EmailToChange = null;
            LoadInformation();
        }

        string GetEmailSelection()
        {
            string SearchName;
            int iGridSelection = DgvEmails.CurrentCell.RowIndex;
            try
            {
                SearchName = DgvEmails.Rows[iGridSelection].Cells[0].Value.ToString();
            }
            catch
            {
                return "";
            }

            if (passed.BusinessToChange != null && passed.BusinessToChange.BusinessEmailAddressList != null)
            {
                SearchName = passed.BusinessToChange.BusinessEmailAddressList.SingleOrDefault(p => p == SearchName);
                return SearchName;
            }

            return "";
        }

        private void LoadInformation()
        {
            DgvEmails.Rows.Clear();
            for (int i = 0; i < passed.BusinessToChange.BusinessEmailAddressList.Count; i++)
            {
                DgvEmails.Rows.Add(passed.BusinessToChange.BusinessEmailAddressList[i]);
            }
        }
    }
    
}
