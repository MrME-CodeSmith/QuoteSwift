using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmManagingPhoneNumbers : Form
    {

        AppContext mPassed;

        public ref AppContext Passed { get => ref mPassed; }

        public FrmManagingPhoneNumbers()
        {
            InitializeComponent();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                QuoteSwiftMainCode.CloseApplication(true);
        }

        private void BtnChangePhoneNumberInfo_Click(object sender, EventArgs e)
        {
            if (mPassed != null && mPassed.BusinessToChange != null && mPassed.BusinessToChange.BusinessCellphoneNumberList != null)
            {
                string OldNumber = GetNumberSelection(mPassed.BusinessToChange.BusinessCellphoneNumberList, ref dgvCellphoneNumbers);
                mPassed.PhoneNumberToChange = OldNumber;
                mPassed.ChangeSpecificObject = true;

                QuoteSwiftMainCode.EditPhoneNumber();
                SetNewNumber(OldNumber, mPassed.PhoneNumberToChange, mPassed.BusinessToChange.BusinessCellphoneNumberList);

                mPassed.PhoneNumberToChange = "";
                mPassed.ChangeSpecificObject = false;
            }
            else if (mPassed != null && mPassed.CustomerToChange != null && mPassed.CustomerToChange.CustomerCellphoneNumberList != null)
            {
                string OldNumber = GetNumberSelection(mPassed.CustomerToChange.CustomerCellphoneNumberList, ref dgvCellphoneNumbers);
                mPassed.PhoneNumberToChange = OldNumber;
                mPassed.ChangeSpecificObject = true;

                QuoteSwiftMainCode.EditPhoneNumber();
                SetNewNumber(OldNumber, mPassed.PhoneNumberToChange, mPassed.CustomerToChange.CustomerCellphoneNumberList);

                mPassed.PhoneNumberToChange = "";
                mPassed.ChangeSpecificObject = false;
            }

            LoadInformation();
        }

        private void BtnUpdateTelephoneNumber_Click(object sender, EventArgs e)
        {
            if (mPassed != null && mPassed.BusinessToChange != null && mPassed.BusinessToChange.BusinessTelephoneNumberList != null)
            {
                string OldNumber = GetNumberSelection(mPassed.BusinessToChange.BusinessTelephoneNumberList, ref dgvTelephoneNumbers);
                mPassed.PhoneNumberToChange = OldNumber;
                mPassed.ChangeSpecificObject = true;

                QuoteSwiftMainCode.EditPhoneNumber();
                SetNewNumber(OldNumber, mPassed.PhoneNumberToChange, mPassed.BusinessToChange.BusinessTelephoneNumberList);

                mPassed.PhoneNumberToChange = "";
                mPassed.ChangeSpecificObject = false;
            }
            else if (mPassed != null && mPassed.CustomerToChange != null && mPassed.CustomerToChange.CustomerTelephoneNumberList != null)
            {
                string OldNumber = GetNumberSelection(mPassed.CustomerToChange.CustomerTelephoneNumberList, ref dgvTelephoneNumbers);
                mPassed.PhoneNumberToChange = OldNumber;
                mPassed.ChangeSpecificObject = true;

                QuoteSwiftMainCode.EditPhoneNumber();
                SetNewNumber(OldNumber, mPassed.PhoneNumberToChange, mPassed.CustomerToChange.CustomerTelephoneNumberList);

                mPassed.PhoneNumberToChange = "";
                mPassed.ChangeSpecificObject = false;
            }

            LoadInformation();
        }

        private void FrmManagingPhoneNumbers_Load(object sender, EventArgs e)
        {
            if (mPassed != null && mPassed.BusinessToChange != null && (mPassed.BusinessToChange.BusinessTelephoneNumberList != null || mPassed.BusinessToChange.BusinessCellphoneNumberList != null))
            {
                Text = Text.Replace("< Business Name >", mPassed.BusinessToChange.BusinessName);

                if (!mPassed.ChangeSpecificObject)
                {
                    QuoteSwiftMainCode.ReadOnlyComponents(Controls);
                    BtnCancel.Enabled = true;
                }

                LoadInformation();
            }
            else if (mPassed != null && mPassed.CustomerToChange != null && (mPassed.CustomerToChange.CustomerCellphoneNumberList != null || mPassed.CustomerToChange.CustomerTelephoneNumberList != null))
            {
                Text = Text.Replace("< Business Name >", mPassed.CustomerToChange.CustomerName);

                if (!mPassed.ChangeSpecificObject)
                {
                    QuoteSwiftMainCode.ReadOnlyComponents(Controls);
                    BtnCancel.Enabled = true;
                }

                LoadInformation();
            }

            dgvCellphoneNumbers.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dgvCellphoneNumbers.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

            dgvTelephoneNumbers.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dgvTelephoneNumbers.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }

        private void BtnRemoveTelNumber_Click(object sender, EventArgs e)
        {
            string SelectedNumber = "";

            if (mPassed.BusinessToChange != null && mPassed.BusinessToChange.BusinessTelephoneNumberList != null)
                SelectedNumber = GetNumberSelection(mPassed.BusinessToChange.BusinessTelephoneNumberList, ref dgvTelephoneNumbers);

            if (mPassed.CustomerToChange != null && mPassed.CustomerToChange.CustomerTelephoneNumberList != null)
                SelectedNumber = GetNumberSelection(mPassed.CustomerToChange.CustomerTelephoneNumberList, ref dgvTelephoneNumbers);

            if (SelectedNumber != "")
            {
                if (MainProgramCode.RequestConfirmation("Are you sure you want to permanently delete this '" + SelectedNumber + "' number from the list?", "REQUEST - Deletion Request"))
                {
                    if (mPassed.BusinessToChange != null && mPassed.BusinessToChange.BusinessTelephoneNumberList != null)
                    {
                        mPassed.BusinessToChange.BusinessTelephoneNumberList.Remove(SelectedNumber);
                        MainProgramCode.ShowInformation("Successfully deleted this '" + SelectedNumber + "' number from the list", "CONFIRMATION - Deletion Success");
                        if (mPassed.BusinessToChange.BusinessTelephoneNumberList.Count == 0) mPassed.BusinessToChange.BusinessTelephoneNumberList = null;
                    }
                    else if (mPassed.CustomerToChange != null && mPassed.CustomerToChange.CustomerTelephoneNumberList != null)
                    {
                        mPassed.CustomerToChange.CustomerTelephoneNumberList.Remove(SelectedNumber);
                        MainProgramCode.ShowInformation("Successfully deleted this '" + SelectedNumber + "' number from the list", "CONFIRMATION - Deletion Success");
                        if (mPassed.CustomerToChange.CustomerTelephoneNumberList.Count == 0) mPassed.CustomerToChange.CustomerTelephoneNumberList = null;
                    }

                    LoadInformation();
                }
            }
            else
            {
                MainProgramCode.ShowError("The current selection is invalid.\nPlease choose a valid number from the list.", "ERROR - Invalid Selection");
            }
        }

        private void BtnRemoveCellNumber_Click(object sender, EventArgs e)
        {
            string SelectedNumber = GetNumberSelection(mPassed.BusinessToChange.BusinessCellphoneNumberList, ref dgvCellphoneNumbers);
            if (SelectedNumber != "")
            {
                if (mPassed.BusinessToChange != null && mPassed.BusinessToChange.BusinessCellphoneNumberList != null)
                {
                    mPassed.BusinessToChange.BusinessCellphoneNumberList.Remove(SelectedNumber);
                    MainProgramCode.ShowInformation("Successfully deleted this '" + SelectedNumber + "' number from the list", "CONFIRMATION - Deletion Success");
                    if (mPassed.BusinessToChange.BusinessCellphoneNumberList.Count == 0) mPassed.BusinessToChange.BusinessCellphoneNumberList = null;
                }
                else if (mPassed.CustomerToChange != null && mPassed.CustomerToChange.CustomerCellphoneNumberList != null)
                {
                    mPassed.CustomerToChange.CustomerCellphoneNumberList.Remove(SelectedNumber);
                    MainProgramCode.ShowInformation("Successfully deleted this '" + SelectedNumber + "' number from the list", "CONFIRMATION - Deletion Success");
                    if (mPassed.CustomerToChange.CustomerCellphoneNumberList.Count == 0) mPassed.CustomerToChange.CustomerCellphoneNumberList = null;
                }

                LoadInformation();
            }
            else
            {
                MainProgramCode.ShowError("The current selection is invalid.\nPlease choose a valid number from the list.", "ERROR - Invalid Selection");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancelation can cause any changes to be lost.", "REQUEST - Cancelation")) Close();
        }

        string GetNumberSelection(BindingList<string> b, ref DataGridView d)
        {
            string SearchName;
            int iGridSelection = d.CurrentCell.RowIndex;
            try
            {
                SearchName = d.Rows[iGridSelection].Cells[0].Value.ToString();
            }
            catch
            {
                return "";
            }

            if (b != null)
            {
                SearchName = b.SingleOrDefault(p => p == SearchName);
                return SearchName;
            }

            return "";
        }

        private void LoadInformation()
        {
            dgvTelephoneNumbers.Rows.Clear();
            dgvCellphoneNumbers.Rows.Clear();

            if (mPassed != null && mPassed.BusinessToChange != null && mPassed.BusinessToChange.BusinessTelephoneNumberList != null)
            {
                for (int i = 0; i < mPassed.BusinessToChange.BusinessTelephoneNumberList.Count; i++)
                {
                    dgvTelephoneNumbers.Rows.Add(mPassed.BusinessToChange.BusinessTelephoneNumberList[i]);
                }
            }

            if (mPassed != null && mPassed.BusinessToChange != null && mPassed.BusinessToChange.BusinessCellphoneNumberList != null)
            {
                for (int i = 0; i < mPassed.BusinessToChange.BusinessCellphoneNumberList.Count; i++)
                {
                    dgvCellphoneNumbers.Rows.Add(mPassed.BusinessToChange.BusinessCellphoneNumberList[i]);
                }
            }

            if (mPassed != null && mPassed.CustomerToChange != null && mPassed.CustomerToChange.CustomerCellphoneNumberList != null)
            {
                for (int i = 0; i < mPassed.CustomerToChange.CustomerCellphoneNumberList.Count; i++)
                {
                    dgvCellphoneNumbers.Rows.Add(mPassed.CustomerToChange.CustomerCellphoneNumberList[i]);
                }
            }

            if (mPassed != null && mPassed.CustomerToChange != null && mPassed.CustomerToChange.CustomerTelephoneNumberList != null)
            {
                for (int i = 0; i < mPassed.CustomerToChange.CustomerTelephoneNumberList.Count; i++)
                {
                    dgvTelephoneNumbers.Rows.Add(mPassed.CustomerToChange.CustomerTelephoneNumberList[i]);
                }
            }
        }

        private void SetNewNumber(string oldNumber, string newNumber, BindingList<string> b)
        {
            if (b != null)
            {
                for (int i = 0; i < b.Count; i++)
                {
                    if (b[i] == oldNumber) b[i] = newNumber;
                    break;
                }
            }
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmManagingPhoneNumbers_FormClosing(object sender, FormClosingEventArgs e)
        {
            QuoteSwiftMainCode.CloseApplication(true);
        }
    }
}
