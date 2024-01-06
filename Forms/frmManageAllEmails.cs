using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MainProgramLibrary;
using QuoteSwift.Models;

namespace QuoteSwift.Forms
{
    public partial class FrmManageAllEmails : Form
    {

        AppContext mPassed;

        public ref AppContext Passed { get => ref mPassed; }

        public FrmManageAllEmails()
        {
            InitializeComponent();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                QuoteSwiftMainCode.CloseApplication(true);
        }

        private void FrmManageAllEmails_Load(object sender, EventArgs e)
        {
            if (mPassed != null && mPassed.BusinessToChange != null && mPassed.BusinessToChange.BusinessEmailAddressList != null)
            {
                Text = Text.Replace("< Business Name >", mPassed.BusinessToChange.BusinessName);

                if (!mPassed.ChangeSpecificObject)
                {
                    QuoteSwiftMainCode.ReadOnlyComponents(Controls);
                    BtnCancel.Enabled = true;
                }

                LoadInformation();
            }
            else if (mPassed != null && mPassed.CustomerToChange != null && mPassed.CustomerToChange.CustomerEmailList != null)
            {
                Text = Text.Replace("< Business Name >", mPassed.CustomerToChange.CustomerName);

                if (!mPassed.ChangeSpecificObject)
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
                    if (mPassed.BusinessToChange != null && mPassed.BusinessToChange.BusinessEmailAddressList != null)
                    {
                        mPassed.BusinessToChange.BusinessEmailAddressList.Remove(SelectedEmail);
                        MainProgramCode.ShowInformation("Successfully deleted '" + SelectedEmail + "' from the email address list", "CONFIRMATION - Deletion Success");
                        if (mPassed.BusinessToChange.BusinessEmailAddressList.Count == 0) mPassed.BusinessToChange.BusinessEmailAddressList = null;
                    }
                    else if (mPassed.CustomerToChange != null && mPassed.CustomerToChange.CustomerEmailList != null)
                    {
                        mPassed.CustomerToChange.CustomerEmailList.Remove(SelectedEmail);
                        MainProgramCode.ShowInformation("Successfully deleted '" + SelectedEmail + "' from the email address list", "CONFIRMATION - Deletion Success");
                        if (mPassed.CustomerToChange.CustomerEmailList.Count == 0) mPassed.CustomerToChange.CustomerEmailList = null;
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
            mPassed.EmailToChange = email;
            mPassed.ChangeSpecificObject = true;
            QuoteSwiftMainCode.EditBusinessEmailAddress();

            if (mPassed.BusinessToChange != null && mPassed.BusinessToChange.BusinessEmailAddressList != null)
            {
                for (int i = 0; i < mPassed.BusinessToChange.BusinessEmailAddressList.Count; i++)
                {
                    if (mPassed.BusinessToChange.BusinessEmailAddressList[i] == email)
                    {
                        mPassed.BusinessToChange.BusinessEmailAddressList[i] = mPassed.EmailToChange;
                    }
                }
            }
            else if (mPassed.CustomerToChange != null && mPassed.CustomerToChange.CustomerEmailList != null)
            {
                for (int i = 0; i < mPassed.CustomerToChange.CustomerEmailList.Count; i++)
                {
                    if (mPassed.CustomerToChange.CustomerEmailList[i] == email)
                    {
                        mPassed.CustomerToChange.CustomerEmailList[i] = mPassed.EmailToChange;
                    }
                }
            }

            mPassed.ChangeSpecificObject = false;
            mPassed.EmailToChange = null;
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

            if (mPassed.BusinessToChange != null && mPassed.BusinessToChange.BusinessEmailAddressList != null)
            {
                SearchName = mPassed.BusinessToChange.BusinessEmailAddressList.SingleOrDefault(p => p == SearchName);
                return SearchName;
            }
            else if (mPassed.CustomerToChange != null && mPassed.CustomerToChange.CustomerEmailList != null)
            {
                SearchName = mPassed.CustomerToChange.CustomerEmailList.SingleOrDefault(p => p == SearchName);
                return SearchName;
            }

            return "";
        }

        private void LoadInformation()
        {
            DgvEmails.Rows.Clear();
            if (mPassed != null && mPassed.BusinessToChange != null && mPassed.BusinessToChange.BusinessEmailAddressList != null)
            {
                for (int i = 0; i < mPassed.BusinessToChange.BusinessEmailAddressList.Count; i++)
                {
                    DgvEmails.Rows.Add(mPassed.BusinessToChange.BusinessEmailAddressList[i]);
                }
            }
            else if (mPassed != null && mPassed.CustomerToChange != null && mPassed.CustomerToChange.CustomerEmailList != null)
            {
                for (int i = 0; i < mPassed.CustomerToChange.CustomerEmailList.Count; i++)
                {
                    DgvEmails.Rows.Add(mPassed.CustomerToChange.CustomerEmailList[i]);
                }
            }
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmManageAllEmails_FormClosing(object sender, FormClosingEventArgs e)
        {
            QuoteSwiftMainCode.CloseApplication(true);
        }
    }

}
