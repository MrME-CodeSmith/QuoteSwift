using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmViewAllBusinesses : Form
    {

        readonly ViewBusinessesViewModel viewModel;
        readonly INavigationService navigation;


        public FrmViewAllBusinesses(ViewBusinessesViewModel viewModel, INavigationService navigation = null)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.navigation = navigation;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
            {
                var p = viewModel.Pass;
                MainProgramCode.CloseApplication(true, ref p);
                viewModel.UpdatePass(p);
            }
        }

        private void BtnUpdateBusiness_Click(object sender, EventArgs e)
        {

            Business Business = GetBusinessSelection();

            if (Business == null)
            {
                MainProgramCode.ShowError("Please select a valid Business, the current selection is invalid", "ERROR - Invalid Business Selection");
                return;
            }

            viewModel.Pass.BusinessToChange = Business;
            viewModel.Pass.ChangeSpecificObject = false;
            navigation.AddBusiness();
            viewModel.UpdatePass(navigation.Pass);

            if (!ReplaceBusiness(Business, viewModel.Pass.BusinessToChange) && viewModel.Pass.ChangeSpecificObject) MainProgramCode.ShowError("An error occurred during the updating procedure.\nUpdated Business will not be stored.", "ERROR - Business Not Updated");

            viewModel.Pass.BusinessToChange = null;
            viewModel.Pass.ChangeSpecificObject = false;

            LoadInformation();

        }

        private void BtnAddBusiness_Click(object sender, EventArgs e)
        {
            Hide();
            navigation.AddBusiness();
            viewModel.UpdatePass(navigation.Pass);
            Show();

            LoadInformation();
        }

        private void FrmViewAllBusinesses_Load(object sender, EventArgs e)
        {
            if (viewModel.Pass.PassBusinessList != null)
            {
                foreach (var business in viewModel.Pass.PassBusinessList)
                    DgvBusinessList.Rows.Add(business.BusinessName);
            }

            DgvBusinessList.RowsDefaultCellStyle.BackColor = Color.Bisque;
            DgvBusinessList.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }

        private void BtnRemoveSelected_Click(object sender, EventArgs e)
        {
            Business business = GetBusinessSelection();

            if (business != null && viewModel.Pass.PassBusinessList != null)
            {
                if (MainProgramCode.RequestConfirmation("Are you sure you want to permanently delete '" + business.BusinessName + "' from the business list?", "REQUEST - Deletion Request"))
                {
                    viewModel.Pass.PassBusinessList.Remove(business);
                    viewModel.Pass.BusinessLookup.Remove(business.BusinessName);
                    viewModel.Pass.BusinessVatNumbers.Remove(business.BusinessLegalDetails.VatNumber);
                    viewModel.Pass.BusinessRegNumbers.Remove(business.BusinessLegalDetails.RegistrationNumber);
                    MainProgramCode.ShowInformation("Successfully deleted '" + business.BusinessName + "' from the business list", "CONFIRMATION - Deletion Success");

                    if (viewModel.Pass.PassBusinessList.Count == 0) viewModel.Pass.PassBusinessList = null;

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

            if (viewModel.Pass.BusinessLookup != null && viewModel.Pass.BusinessLookup.TryGetValue(searchName, out Business business))
            {
                return business;
            }

            return null;
        }

        private void LoadInformation()
        {
            DgvBusinessList.Rows.Clear();

            if (viewModel.Pass.PassBusinessList != null)
                foreach (var business in viewModel.Pass.PassBusinessList)
                {
                    DgvBusinessList.Rows.Add(business.BusinessName);
                }
        }

        private bool ReplaceBusiness(Business Original, Business New)
        {
            if (New != null && Original != null && viewModel.Pass.PassBusinessList != null)
                for (int i = 0; i < viewModel.Pass.PassBusinessList.Count; i++)
                    if (viewModel.Pass.PassBusinessList[i] == Original)
                    {
                        viewModel.Pass.PassBusinessList[i] = New;
                        viewModel.Pass.BusinessLookup.Remove(Original.BusinessName);
                        viewModel.Pass.BusinessVatNumbers.Remove(Original.BusinessLegalDetails.VatNumber);
                        viewModel.Pass.BusinessRegNumbers.Remove(Original.BusinessLegalDetails.RegistrationNumber);
                        viewModel.Pass.BusinessLookup[New.BusinessName] = New;
                        viewModel.Pass.BusinessVatNumbers.Add(New.BusinessLegalDetails.VatNumber);
                        viewModel.Pass.BusinessRegNumbers.Add(New.BusinessLegalDetails.RegistrationNumber);
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
            var p = viewModel.Pass;
            MainProgramCode.CloseApplication(true, ref p);
            viewModel.UpdatePass(p);
        }

        /**********************************************************************************/
    }
}
