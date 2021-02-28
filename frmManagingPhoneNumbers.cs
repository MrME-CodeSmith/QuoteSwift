﻿using System;
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
            if (passed != null && passed.BusinessToChange != null && passed.BusinessToChange.BusinessCellphoneNumberList != null)
            {
                string OldNumber = GetNumberSelection(passed.BusinessToChange.BusinessCellphoneNumberList, ref dgvCellphoneNumbers);
                this.passed.PhoneNumberToChange = OldNumber;
                this.passed.ChangeSpecificObject = true;

                this.passed = MainProgramCode.EditPhoneNumber(ref this.passed);
                SetNewNumber(OldNumber, this.passed.PhoneNumberToChange, passed.BusinessToChange.BusinessCellphoneNumberList);

                this.passed.PhoneNumberToChange = "";
                this.passed.ChangeSpecificObject = false;
            }
            else if (passed != null && passed.CustomerToChange != null && passed.CustomerToChange.CustomerCellphoneNumberList != null)
            {
                string OldNumber = GetNumberSelection(passed.CustomerToChange.CustomerCellphoneNumberList, ref dgvCellphoneNumbers);
                this.passed.PhoneNumberToChange = OldNumber;
                this.passed.ChangeSpecificObject = true;

                this.passed = MainProgramCode.EditPhoneNumber(ref this.passed);
                SetNewNumber(OldNumber, this.passed.PhoneNumberToChange, passed.CustomerToChange.CustomerCellphoneNumberList);

                this.passed.PhoneNumberToChange = "";
                this.passed.ChangeSpecificObject = false;
            }

                LoadInformation();
        }

        private void BtnUpdateTelephoneNumber_Click(object sender, EventArgs e)
        {
            if (passed != null && passed.BusinessToChange != null && passed.BusinessToChange.BusinessTelephoneNumberList != null)
            {
                string OldNumber = GetNumberSelection(passed.BusinessToChange.BusinessTelephoneNumberList, ref dgvTelephoneNumbers);
                this.passed.PhoneNumberToChange = OldNumber;
                this.passed.ChangeSpecificObject = true;

                this.passed = MainProgramCode.EditPhoneNumber(ref this.passed);
                SetNewNumber(OldNumber, this.passed.PhoneNumberToChange, passed.BusinessToChange.BusinessTelephoneNumberList);

                this.passed.PhoneNumberToChange = "";
                this.passed.ChangeSpecificObject = false;
            }
            else if (passed != null && passed.CustomerToChange != null && passed.CustomerToChange.CustomerTelephoneNumberList != null)
            {
                string OldNumber = GetNumberSelection(passed.CustomerToChange.CustomerTelephoneNumberList, ref dgvTelephoneNumbers);
                this.passed.PhoneNumberToChange = OldNumber;
                this.passed.ChangeSpecificObject = true;

                this.passed = MainProgramCode.EditPhoneNumber(ref this.passed);
                SetNewNumber(OldNumber, this.passed.PhoneNumberToChange, passed.CustomerToChange.CustomerTelephoneNumberList);

                this.passed.PhoneNumberToChange = "";
                this.passed.ChangeSpecificObject = false;
            }

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
            else if(passed != null && passed.CustomerToChange != null && (passed.CustomerToChange.CustomerCellphoneNumberList != null || passed.CustomerToChange.CustomerTelephoneNumberList != null))
            {
                this.Text = this.Text.Replace("< Business Name >", passed.CustomerToChange.CustomerName);

                if (!passed.ChangeSpecificObject)
                {
                    MainProgramCode.ReadOnlyComponents(this.Controls);
                    BtnCancel.Enabled = true;
                }

                LoadInformation();
            }

            this.dgvCellphoneNumbers.RowsDefaultCellStyle.BackColor = Color.Bisque;
            this.dgvCellphoneNumbers.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;

            this.dgvTelephoneNumbers.RowsDefaultCellStyle.BackColor = Color.Bisque;
            this.dgvTelephoneNumbers.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
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
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancelation can cause any changes to be lost.", "REQUEST - Cancelation")) this.Close();
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

            if(passed != null && passed.BusinessToChange != null && passed.BusinessToChange.BusinessTelephoneNumberList != null)
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
                for (int i = 0; i < b.Count ; i++)
                {
                    if (b[i] == OldNumber) b[i] = NewNumber;
                    break;
                }
            }
        }
    }
}
