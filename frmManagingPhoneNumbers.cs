﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
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
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                QuoteSwiftMainCode.CloseApplication(true, ref passed);
        }

        private void BtnChangePhoneNumberInfo_Click(object sender, EventArgs e)
        {
            if (passed != null && passed.BusinessToChange != null && passed.BusinessToChange.BusinessCellphoneNumberList != null)
            {
                string OldNumber = GetNumberSelection(passed.BusinessToChange.BusinessCellphoneNumberList, ref dgvCellphoneNumbers);
                passed.PhoneNumberToChange = OldNumber;
                passed.ChangeSpecificObject = true;

                passed = QuoteSwiftMainCode.EditPhoneNumber(ref passed);
                SetNewNumber(OldNumber, passed.PhoneNumberToChange, passed.BusinessToChange.BusinessCellphoneNumberList);

                passed.PhoneNumberToChange = "";
                passed.ChangeSpecificObject = false;
            }
            else if (passed != null && passed.CustomerToChange != null && passed.CustomerToChange.CustomerCellphoneNumberList != null)
            {
                string OldNumber = GetNumberSelection(passed.CustomerToChange.CustomerCellphoneNumberList, ref dgvCellphoneNumbers);
                passed.PhoneNumberToChange = OldNumber;
                passed.ChangeSpecificObject = true;

                passed = QuoteSwiftMainCode.EditPhoneNumber(ref passed);
                SetNewNumber(OldNumber, passed.PhoneNumberToChange, passed.CustomerToChange.CustomerCellphoneNumberList);

                passed.PhoneNumberToChange = "";
                passed.ChangeSpecificObject = false;
            }

            LoadInformation();
        }

        private void BtnUpdateTelephoneNumber_Click(object sender, EventArgs e)
        {
            if (passed != null && passed.BusinessToChange != null && passed.BusinessToChange.BusinessTelephoneNumberList != null)
            {
                string OldNumber = GetNumberSelection(passed.BusinessToChange.BusinessTelephoneNumberList, ref dgvTelephoneNumbers);
                passed.PhoneNumberToChange = OldNumber;
                passed.ChangeSpecificObject = true;

                passed = QuoteSwiftMainCode.EditPhoneNumber(ref passed);
                SetNewNumber(OldNumber, passed.PhoneNumberToChange, passed.BusinessToChange.BusinessTelephoneNumberList);

                passed.PhoneNumberToChange = "";
                passed.ChangeSpecificObject = false;
            }
            else if (passed != null && passed.CustomerToChange != null && passed.CustomerToChange.CustomerTelephoneNumberList != null)
            {
                string OldNumber = GetNumberSelection(passed.CustomerToChange.CustomerTelephoneNumberList, ref dgvTelephoneNumbers);
                passed.PhoneNumberToChange = OldNumber;
                passed.ChangeSpecificObject = true;

                passed = QuoteSwiftMainCode.EditPhoneNumber(ref passed);
                SetNewNumber(OldNumber, passed.PhoneNumberToChange, passed.CustomerToChange.CustomerTelephoneNumberList);

                passed.PhoneNumberToChange = "";
                passed.ChangeSpecificObject = false;
            }

            LoadInformation();
        }

        private void FrmManagingPhoneNumbers_Load(object sender, EventArgs e)
        {
            if (passed != null && passed.BusinessToChange != null && (passed.BusinessToChange.BusinessTelephoneNumberList != null || passed.BusinessToChange.BusinessCellphoneNumberList != null))
            {
                Text = Text.Replace("< Business Name >", passed.BusinessToChange.BusinessName);

                if (!passed.ChangeSpecificObject)
                {
                    QuoteSwiftMainCode.ReadOnlyComponents(Controls);
                    BtnCancel.Enabled = true;
                }

                LoadInformation();
            }
            else if (passed != null && passed.CustomerToChange != null && (passed.CustomerToChange.CustomerCellphoneNumberList != null || passed.CustomerToChange.CustomerTelephoneNumberList != null))
            {
                Text = Text.Replace("< Business Name >", passed.CustomerToChange.CustomerName);

                if (!passed.ChangeSpecificObject)
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

            if (passed.BusinessToChange != null && passed.BusinessToChange.BusinessTelephoneNumberList != null)
                SelectedNumber = GetNumberSelection(passed.BusinessToChange.BusinessTelephoneNumberList, ref dgvTelephoneNumbers);

            if (passed.CustomerToChange != null && passed.CustomerToChange.CustomerTelephoneNumberList != null)
                SelectedNumber = GetNumberSelection(passed.CustomerToChange.CustomerTelephoneNumberList, ref dgvTelephoneNumbers);

            if (SelectedNumber != "")
            {
                if (MainProgramCode.RequestConfirmation("Are you sure you want to permanently delete this '" + SelectedNumber + "' number from the list?", "REQUEST - Deletion Request"))
                {
                    if (passed.BusinessToChange != null && passed.BusinessToChange.BusinessTelephoneNumberList != null)
                    {
                        passed.BusinessToChange.BusinessTelephoneNumberList.Remove(SelectedNumber);
                        MainProgramCode.ShowInformation("Successfully deleted this '" + SelectedNumber + "' number from the list", "CONFIRMATION - Deletion Success");
                        if (passed.BusinessToChange.BusinessTelephoneNumberList.Count == 0) passed.BusinessToChange.BusinessTelephoneNumberList = null;
                    }
                    else if (passed.CustomerToChange != null && passed.CustomerToChange.CustomerTelephoneNumberList != null)
                    {
                        passed.CustomerToChange.CustomerTelephoneNumberList.Remove(SelectedNumber);
                        MainProgramCode.ShowInformation("Successfully deleted this '" + SelectedNumber + "' number from the list", "CONFIRMATION - Deletion Success");
                        if (passed.CustomerToChange.CustomerTelephoneNumberList.Count == 0) passed.CustomerToChange.CustomerTelephoneNumberList = null;
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
            string SelectedNumber = GetNumberSelection(passed.BusinessToChange.BusinessCellphoneNumberList, ref dgvCellphoneNumbers);
            if (SelectedNumber != "")
            {
                if (passed.BusinessToChange != null && passed.BusinessToChange.BusinessCellphoneNumberList != null)
                {
                    passed.BusinessToChange.BusinessCellphoneNumberList.Remove(SelectedNumber);
                    MainProgramCode.ShowInformation("Successfully deleted this '" + SelectedNumber + "' number from the list", "CONFIRMATION - Deletion Success");
                    if (passed.BusinessToChange.BusinessCellphoneNumberList.Count == 0) passed.BusinessToChange.BusinessCellphoneNumberList = null;
                }
                else if (passed.CustomerToChange != null && passed.CustomerToChange.CustomerCellphoneNumberList != null)
                {
                    passed.CustomerToChange.CustomerCellphoneNumberList.Remove(SelectedNumber);
                    MainProgramCode.ShowInformation("Successfully deleted this '" + SelectedNumber + "' number from the list", "CONFIRMATION - Deletion Success");
                    if (passed.CustomerToChange.CustomerCellphoneNumberList.Count == 0) passed.CustomerToChange.CustomerCellphoneNumberList = null;
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

            if (passed != null && passed.BusinessToChange != null && passed.BusinessToChange.BusinessTelephoneNumberList != null)
            {
                for (int i = 0; i < passed.BusinessToChange.BusinessTelephoneNumberList.Count; i++)
                {
                    dgvTelephoneNumbers.Rows.Add(passed.BusinessToChange.BusinessTelephoneNumberList[i]);
                }
            }

            if (passed != null && passed.BusinessToChange != null && passed.BusinessToChange.BusinessCellphoneNumberList != null)
            {
                for (int i = 0; i < passed.BusinessToChange.BusinessCellphoneNumberList.Count; i++)
                {
                    dgvCellphoneNumbers.Rows.Add(passed.BusinessToChange.BusinessCellphoneNumberList[i]);
                }
            }

            if (passed != null && passed.CustomerToChange != null && passed.CustomerToChange.CustomerCellphoneNumberList != null)
            {
                for (int i = 0; i < passed.CustomerToChange.CustomerCellphoneNumberList.Count; i++)
                {
                    dgvCellphoneNumbers.Rows.Add(passed.CustomerToChange.CustomerCellphoneNumberList[i]);
                }
            }

            if (passed != null && passed.CustomerToChange != null && passed.CustomerToChange.CustomerTelephoneNumberList != null)
            {
                for (int i = 0; i < passed.CustomerToChange.CustomerTelephoneNumberList.Count; i++)
                {
                    dgvTelephoneNumbers.Rows.Add(passed.CustomerToChange.CustomerTelephoneNumberList[i]);
                }
            }
        }

        private void SetNewNumber(string OldNumber, string NewNumber, BindingList<string> b)
        {
            if (b != null)
            {
                for (int i = 0; i < b.Count; i++)
                {
                    if (b[i] == OldNumber) b[i] = NewNumber;
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
            QuoteSwiftMainCode.CloseApplication(true, ref passed);
        }
    }
}
