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
    public partial class FrmManagingPhoneNumbers : Form
    {

        Pass passed;

        public ref Pass Passed { get => ref passed; }

        public FrmManagingPhoneNumbers(ref Pass passed)
        {
            InitializeComponent();
            this.passed = passed;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainProgramCode.CloseApplication(MainProgramCode.RequestConfirmation("Are you sure you want to close the application?\nAny unsaved work will be lost.", "REQUEST - Application Termination"), ref this.passed);
        }

        private void BtnChangePhoneNumberInfo_Click(object sender, EventArgs e)
        {
            string OldNumber = GetNumberSelection(passed.BusinessToChange.BusinessCellphoneNumberList, ref dgvCellphoneNumbers);
            this.passed.PhoneNumberToChange = OldNumber;
            this.passed.ChangeSpecificObject = true;

            this.passed = MainProgramCode.EditPhoneNumber(ref this.passed);
            SetNewNumber(OldNumber, this.passed.PhoneNumberToChange, passed.BusinessToChange.BusinessCellphoneNumberList);

            this.passed.PhoneNumberToChange = "";
            this.passed.ChangeSpecificObject = false;

            LoadInformation();
        }

        private void BtnUpdateTelephoneNumber_Click(object sender, EventArgs e)
        {
            string OldNumber = GetNumberSelection(passed.BusinessToChange.BusinessTelephoneNumberList, ref dgvTelephoneNumbers);
            this.passed.PhoneNumberToChange = OldNumber;
            this.passed.ChangeSpecificObject = true;

            this.passed = MainProgramCode.EditPhoneNumber(ref this.passed);
            SetNewNumber(OldNumber, this.passed.PhoneNumberToChange, passed.BusinessToChange.BusinessTelephoneNumberList);

            this.passed.PhoneNumberToChange = "";
            this.passed.ChangeSpecificObject = false;

            LoadInformation();
        }

        private void FrmManagingPhoneNumbers_Load(object sender, EventArgs e)
        {
            if (passed != null && passed.BusinessToChange != null && (passed.BusinessToChange.BusinessTelephoneNumberList != null || passed.BusinessToChange.BusinessCellphoneNumberList != null))
            {
                this.Text = this.Text.Replace("< Business Name >", passed.BusinessToChange.BusinessName);

                if(!passed.ChangeSpecificObject)
                {
                    MainProgramCode.ReadOnlyComponents(this.Controls);
                    BtnCancel.Enabled = true;
                }

                LoadInformation();
            }
        }

        private void BtnRemoveTelNumber_Click(object sender, EventArgs e)
        {
            string SelectedNumber = GetNumberSelection(passed.BusinessToChange.BusinessTelephoneNumberList, ref dgvTelephoneNumbers);
            if (SelectedNumber != "")
            {
                if (MainProgramCode.RequestConfirmation("Are you sure you want to permanently delete this '" + SelectedNumber + "' number from the list?", "REQUEST - Deletion Request"))
                {
                    passed.BusinessToChange.BusinessTelephoneNumberList.Remove(SelectedNumber);
                    MainProgramCode.ShowInformation("Successfully deleted this '" + SelectedNumber + "' number from the list", "CONFIRMATION - Deletion Success");

                    if (passed.BusinessToChange.BusinessTelephoneNumberList.Count == 0) passed.BusinessToChange.BusinessTelephoneNumberList = null;

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
            string SelectedNumber = GetNumberSelection(passed.BusinessToChange.BusinessCellphoneNumberList, ref dgvCellphoneNumbers);
            if (SelectedNumber != "")
            {
                if (MainProgramCode.RequestConfirmation("Are you sure you want to permanently delete this '" + SelectedNumber + "' number from the list?", "REQUEST - Deletion Request"))
                {
                    passed.BusinessToChange.BusinessCellphoneNumberList.Remove(SelectedNumber);
                    MainProgramCode.ShowInformation("Successfully deleted this '" + SelectedNumber + "' number from the list", "CONFIRMATION - Deletion Success");

                    if (passed.BusinessToChange.BusinessCellphoneNumberList.Count == 0) passed.BusinessToChange.BusinessCellphoneNumberList = null;

                    LoadInformation();
                }
            }
            else
            {
                MainProgramCode.ShowError("The current selection is invalid.\nPlease choose a valid number from the list.", "ERROR - Invalid Selection");
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancelation can cause any changes to be lost.", "REQUEST - Cancelation")) this.Close();
        }

        private void DgvTelephoneNumbers_Leave(object sender, EventArgs e)
        {
            if (!dgvTelephoneNumbers.Columns["clmTelephoneNumbers"].ReadOnly)
            {
                if (ChangesMade(passed.BusinessToChange.BusinessTelephoneNumberList, ref dgvTelephoneNumbers)) 
                    if(MainProgramCode.RequestConfirmation("Changes were made to the Telephone List.\nWould you like to save these changes?","REQUEST - Store Changed Telephone Numbers"))
                        StoreChanges(passed.BusinessToChange.BusinessTelephoneNumberList, ref dgvTelephoneNumbers);
            }
        }

        private void DgvCellphoneNumbers_Leave(object sender, EventArgs e)
        {
            if (!dgvCellphoneNumbers.Columns["ClmCellphoneNumbers"].ReadOnly)
            {
                if (ChangesMade(passed.BusinessToChange.BusinessCellphoneNumberList, ref dgvCellphoneNumbers))
                    if (MainProgramCode.RequestConfirmation("Changes were made to the Cellphone number List.\nWould you like to save these changes?", "REQUEST - Store Changed Cellphone Numbers"))
                        StoreChanges(passed.BusinessToChange.BusinessCellphoneNumberList, ref dgvCellphoneNumbers);
            }
        }

        string GetNumberSelection(BindingList<string> b,ref DataGridView d)
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

            if (passed.BusinessToChange.BusinessTelephoneNumberList != null)
            {
                for (int i = 0; i < passed.BusinessToChange.BusinessTelephoneNumberList.Count; i++)
                {
                    dgvTelephoneNumbers.Rows.Add(passed.BusinessToChange.BusinessTelephoneNumberList[i]);
                }
            }

            if (passed.BusinessToChange.BusinessCellphoneNumberList != null)
            {
                for (int i = 0; i < passed.BusinessToChange.BusinessCellphoneNumberList.Count; i++)
                {
                    dgvCellphoneNumbers.Rows.Add(passed.BusinessToChange.BusinessCellphoneNumberList[i]);
                }
            }
        } 

        private bool ChangesMade(BindingList<string> b, ref DataGridView d)
        {
            if (b != null)
                for (int i = 0; i < b.Count; i++)
                {
                    if(b[i] != (string)d.Rows[i].Cells[0].Value)
                    {
                        return true;
                    }
                }

            return false;
        }

        private void StoreChanges(BindingList<string> b, ref DataGridView d)
        {
            if (b != null)
            {
                for (int i = 0; i < b.Count; i++)
                {

                    string temp = (string)d.Rows[i].Cells[0].Value;

                    if (b[i] != temp) b[i] = temp;

                }
                MainProgramCode.ShowInformation("The changes were successfully stored","INFORMATION - Changes Successfully Stored");
                LoadInformation();
            }
        }


        private void SetNewNumber(string OldNumber, string NewNumber, BindingList<string> b)
        {
            if (b != null)
            {
                for (int i = 0; i < b.Count ; i++)
                {
                    if (b[i] == OldNumber) b[i] = NewNumber;
                    break;
                }
            }
        }
    }
}
