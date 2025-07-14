using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmViewAllBusinesses : Form
    {

        readonly ViewBusinessesViewModel viewModel;

        Pass passed
        {
            get => viewModel.Pass;
            set => viewModel.UpdatePass(value);
        }

        public ref Pass Passed { get => ref passed; }

        public FrmViewAllBusinesses(ViewBusinessesViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                MainProgramCode.CloseApplication(true, ref passed);
        }

        private void BtnUpdateBusiness_Click(object sender, EventArgs e)
        {

            Business Business = GetBusinessSelection();

            if (Business == null)
            {
                MainProgramCode.ShowError("Please select a valid Business, the current selection is invalid", "ERROR - Invalid Business Selection");
                return;
            }

            passed.BusinessToChange = Business;
            passed.ChangeSpecificObject = false;
            passed = QuoteSwiftMainCode.AddBusiness(ref passed);

            if (!ReplaceBusiness(Business, passed.BusinessToChange) && passed.ChangeSpecificObject) MainProgramCode.ShowError("An error occurred during the updating procedure.\nUpdated Business will not be stored.", "ERROR - Business Not Updated");

            passed.BusinessToChange = null;
            passed.ChangeSpecificObject = false;

            LoadInformation();

        }

        private void BtnAddBusiness_Click(object sender, EventArgs e)
        {
            Hide();
            passed = QuoteSwiftMainCode.AddBusiness(ref passed);
            Show();

            LoadInformation();
        }

        private void FrmViewAllBusinesses_Load(object sender, EventArgs e)
        {
            if (passed.PassBusinessList != null)
            {
                foreach (var business in passed.PassBusinessList)
                    DgvBusinessList.Rows.Add(business.BusinessName);
            }

            DgvBusinessList.RowsDefaultCellStyle.BackColor = Color.Bisque;
            DgvBusinessList.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }

        private void BtnRemoveSelected_Click(object sender, EventArgs e)
        {
            Business business = GetBusinessSelection();

            if (business != null && passed.PassBusinessList != null)
            {
                if (MainProgramCode.RequestConfirmation("Are you sure you want to permanently delete '" + business.BusinessName + "' from the business list?", "REQUEST - Deletion Request"))
                {
                    passed.PassBusinessList.Remove(business);
                    passed.BusinessLookup.Remove(business.BusinessName);
                    passed.BusinessVatNumbers.Remove(business.BusinessLegalDetails.VatNumber);
                    passed.BusinessRegNumbers.Remove(business.BusinessLegalDetails.RegistrationNumber);
                    MainProgramCode.ShowInformation("Successfully deleted '" + business.BusinessName + "' from the business list", "CONFIRMATION - Deletion Success");

                    if (passed.PassBusinessList.Count == 0) passed.PassBusinessList = null;

                    LoadInformation();
                }
            }
        }

        /** Form Specific Functions And Procedures: 
        *
        * Note: Not all Functions or Procedures below are used more than once
        *       Some of them are only to keep the above events readable 
        *       and clutter free.                                                          
        */

        private Business GetBusinessSelection()
        {
            if (DgvBusinessList.CurrentCell == null || DgvBusinessList.CurrentRow == null)
                return null;

            int iGridSelection = DgvBusinessList.CurrentCell.RowIndex;
            if (iGridSelection < 0 || iGridSelection >= DgvBusinessList.Rows.Count)
                return null;

            string searchName = DgvBusinessList.Rows[iGridSelection].Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(searchName))
                return null;

            if (passed.BusinessLookup != null && passed.BusinessLookup.TryGetValue(searchName, out Business business))
            {
                return business;
            }

            return null;
        }

        private void LoadInformation()
        {
            DgvBusinessList.Rows.Clear();

            if (passed.PassBusinessList != null)
                foreach (var business in passed.PassBusinessList)
                {
                    DgvBusinessList.Rows.Add(business.BusinessName);
                }
        }

        private bool ReplaceBusiness(Business Original, Business New)
        {
            if (New != null && Original != null && passed.PassBusinessList != null)
                for (int i = 0; i < passed.PassBusinessList.Count; i++)
                    if (passed.PassBusinessList[i] == Original)
                    {
                        passed.PassBusinessList[i] = New;
                        passed.BusinessLookup.Remove(Original.BusinessName);
                        passed.BusinessVatNumbers.Remove(Original.BusinessLegalDetails.VatNumber);
                        passed.BusinessRegNumbers.Remove(Original.BusinessLegalDetails.RegistrationNumber);
                        passed.BusinessLookup[New.BusinessName] = New;
                        passed.BusinessVatNumbers.Add(New.BusinessLegalDetails.VatNumber);
                        passed.BusinessRegNumbers.Add(New.BusinessLegalDetails.RegistrationNumber);
                        return true;
                    }

            return false;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancellation can cause any changes to be lost.", "REQUEST - Cancellation")) Close();
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmViewAllBusinesses_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainProgramCode.CloseApplication(true, ref passed);
        }

        /**********************************************************************************/
    }
}
