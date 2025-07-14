using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmManageAllEmails : Form
    {

        readonly ManageEmailsViewModel viewModel;
        readonly INavigationService navigation;

        Pass passed;

        public ref Pass Passed => ref passed;

        public FrmManageAllEmails(ManageEmailsViewModel viewModel, INavigationService navigation = null, Pass pass = null)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.navigation = navigation;
            passed = pass ?? new Pass(null, null, null, null);
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                MainProgramCode.CloseApplication(true, ref passed);
        }

        private void FrmManageAllEmails_Load(object sender, EventArgs e)
        {
            if (passed != null && passed.BusinessToChange != null && passed.BusinessToChange.BusinessEmailAddressList != null)
            {
                Text = Text.Replace("< Business Name >", passed.BusinessToChange.BusinessName);

                if (!passed.ChangeSpecificObject)
                {
                    QuoteSwiftMainCode.ReadOnlyComponents(Controls);
                    BtnCancel.Enabled = true;
                }

                LoadInformation();
            }
            else if (passed != null && passed.CustomerToChange != null && passed.CustomerToChange.CustomerEmailList != null)
            {
                Text = Text.Replace("< Business Name >", passed.CustomerToChange.CustomerName);

                if (!passed.ChangeSpecificObject)
                {
                    QuoteSwiftMainCode.ReadOnlyComponents(Controls);
                    BtnCancel.Enabled = true;
                }

                LoadInformation();
            }

            DgvEmails.RowsDefaultCellStyle.BackColor = Color.Bisque;
            DgvEmails.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancellation can cause any changes to be lost.", "REQUEST - Cancellation")) Close();
        }

        private void BtnRemoveAddress_Click(object sender, EventArgs e)
        {
            string SelectedEmail = GetEmailSelection();
            if (SelectedEmail != "")
            {
                if (MainProgramCode.RequestConfirmation("Are you sure you want to permanently delete '" + SelectedEmail + "' email address from the list?", "REQUEST - Deletion Request"))
                {
                    if (passed.BusinessToChange != null && passed.BusinessToChange.BusinessEmailAddressList != null)
                    {
                        passed.BusinessToChange.RemoveEmailAddress(SelectedEmail);
                        MainProgramCode.ShowInformation("Successfully deleted '" + SelectedEmail + "' from the email address list", "CONFIRMATION - Deletion Success");
                    }
                    else if (passed.CustomerToChange != null && passed.CustomerToChange.CustomerEmailList != null)
                    {
                        passed.CustomerToChange.RemoveEmailAddress(SelectedEmail);
                        MainProgramCode.ShowInformation("Successfully deleted '" + SelectedEmail + "' from the email address list", "CONFIRMATION - Deletion Success");
                    }


                    LoadInformation();
                }
            }
            else
            {
                MainProgramCode.ShowError("The current selection is invalid.\nPlease choose a valid email address from the list.", "ERROR - Invalid Selection");
            }
        }

        private void BtnChangeAddressInfo_Click(object sender, EventArgs e)
        {
            string email = GetEmailSelection();
            passed.EmailToChange = email;
            passed.ChangeSpecificObject = true;
            navigation.Pass = passed;
            navigation.EditBusinessEmailAddress();
            passed = navigation.Pass;

            if (passed.BusinessToChange != null && passed.BusinessToChange.BusinessEmailAddressList != null)
            {
                passed.BusinessToChange.UpdateEmailAddress(email, passed.EmailToChange);
            }
            else if (passed.CustomerToChange != null && passed.CustomerToChange.CustomerEmailList != null)
            {
                passed.CustomerToChange.UpdateEmailAddress(email, passed.EmailToChange);
            }

            passed.ChangeSpecificObject = false;
            passed.EmailToChange = null;
            LoadInformation();
        }

        string GetEmailSelection()
        {
            if (DgvEmails.CurrentCell == null || DgvEmails.CurrentRow == null)
                return string.Empty;

            int iGridSelection = DgvEmails.CurrentCell.RowIndex;
            if (iGridSelection < 0 || iGridSelection >= DgvEmails.Rows.Count)
                return string.Empty;

            string SearchName = DgvEmails.Rows[iGridSelection].Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(SearchName))
                return string.Empty;

            if (passed.BusinessToChange != null && passed.BusinessToChange.BusinessEmailAddressList != null)
            {
                return passed.BusinessToChange.BusinessEmailAddressList.SingleOrDefault(p => p == SearchName) ?? string.Empty;
            }
            else if (passed.CustomerToChange != null && passed.CustomerToChange.CustomerEmailList != null)
            {
                return passed.CustomerToChange.CustomerEmailList.SingleOrDefault(p => p == SearchName) ?? string.Empty;
            }

            return string.Empty;
        }

        private void LoadInformation()
        {
            DgvEmails.Rows.Clear();
            if (passed != null && passed.BusinessToChange != null && passed.BusinessToChange.BusinessEmailAddressList != null)
            {
                foreach (var email in passed.BusinessToChange.BusinessEmailAddressList)
                {
                    DgvEmails.Rows.Add(email);
                }
            }
            else if (passed != null && passed.CustomerToChange != null && passed.CustomerToChange.CustomerEmailList != null)
            {
                foreach (var email in passed.CustomerToChange.CustomerEmailList)
                {
                    DgvEmails.Rows.Add(email);
                }
            }
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmManageAllEmails_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainProgramCode.CloseApplication(true, ref passed);
        }
    }

}
