using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MainProgramLibrary;
using QuoteSwift.Models;

namespace QuoteSwift.Forms
{
    public partial class FrmViewAllBusinesses : Form
    {


        AppContext mPassed;

        public ref AppContext Passed { get => ref mPassed; }

        public FrmViewAllBusinesses()
        {
            InitializeComponent();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                QuoteSwiftMainCode.CloseApplication(true);
        }

        private void BtnUpdateBusiness_Click(object sender, EventArgs e)
        {

            Business Business = GetBusinessSelection();

            if (Business == null)
            {
                MainProgramCode.ShowError("Please select a valid Business, the current selection is invalid", "ERROR - Invalid Business Selection");
                return;
            }

            mPassed.BusinessToChange = Business;
            mPassed.ChangeSpecificObject = false;
            QuoteSwiftMainCode.AddBusiness();

            if (!ReplaceBusiness(Business, mPassed.BusinessToChange) && mPassed.ChangeSpecificObject) MainProgramCode.ShowError("An error occurred during the updating procedure.\nUpdated Business will not be stored.", "ERROR - Business Not Updated");

            mPassed.BusinessToChange = null;
            mPassed.ChangeSpecificObject = false;

            LoadInformation();

        }

        private void BtnAddBusiness_Click(object sender, EventArgs e)
        {
            Hide();
            QuoteSwiftMainCode.AddBusiness();
            Show();

            LoadInformation();
        }

        private void FrmViewAllBusinesses_Load(object sender, EventArgs e)
        {
            if (mPassed.BusinessMap != null)
            {
                for (int i = 0; i < mPassed.BusinessMap.Count; i++)
                    DgvBusinessList.Rows.Add(mPassed.BusinessMap.Values.ToArray()[i].BusinessName);
            }

            DgvBusinessList.RowsDefaultCellStyle.BackColor = Color.Bisque;
            DgvBusinessList.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }

        private void BtnRemoveSelected_Click(object sender, EventArgs e)
        {
            Business business = GetBusinessSelection();

            if (business != null && mPassed.BusinessMap != null)
            {
                if (MainProgramCode.RequestConfirmation("Are you sure you want to permanently delete '" + business.BusinessName + "' from the business list?", "REQUEST - Deletion Request"))
                {
                    mPassed.BusinessMap.Remove(business.BusinessLegalDetails.RegistrationNumber);
                    MainProgramCode.ShowInformation("Successfully deleted '" + business.BusinessName + "' from the business list", "CONFIRMATION - Deletion Success");

                    if (mPassed.BusinessMap.Count == 0) mPassed.BusinessMap = null;

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
            Business business;
            string SearchName;
            int iGridSelection;
            try
            {
                iGridSelection = DgvBusinessList.CurrentCell.RowIndex;
                SearchName = DgvBusinessList.Rows[iGridSelection].Cells[0].Value.ToString();
            }
            catch
            {
                return null;
            }

            if (mPassed.BusinessMap != null)
            {
                business = mPassed.BusinessMap.SingleOrDefault(p => p.Value.BusinessName == SearchName).Value;
                return business;
            }

            return null;
        }

        private void LoadInformation()
        {
            DgvBusinessList.Rows.Clear();

            if (mPassed.BusinessMap != null)
                for (int i = 0; i < mPassed.BusinessMap.Count; i++)
                {
                    DgvBusinessList.Rows.Add(mPassed.BusinessMap.Values.ToArray()[i].BusinessName);
                }
        }

        private bool ReplaceBusiness(Business original, Business @new)
        {
            if (@new != null && original != null && mPassed.BusinessMap != null)
                for (int i = 0; i < mPassed.BusinessMap.Count; i++)
                    if (mPassed.BusinessMap.Values.ToArray()[i] == original)
                    {
                        mPassed.BusinessMap.Values.ToArray()[i] = @new;
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
            QuoteSwiftMainCode.CloseApplication(true);
        }

        /**********************************************************************************/
    }
}
