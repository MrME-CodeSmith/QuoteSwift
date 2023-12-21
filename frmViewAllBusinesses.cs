using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmViewAllBusinesses : Form
    {


        AppContext passed;

        public ref AppContext Passed { get => ref passed; }

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

            passed.BusinessToChange = Business;
            passed.ChangeSpecificObject = false;
            QuoteSwiftMainCode.AddBusiness();

            if (!ReplaceBusiness(Business, passed.BusinessToChange) && passed.ChangeSpecificObject) MainProgramCode.ShowError("An error occurred during the updating procedure.\nUpdated Business will not be stored.", "ERROR - Business Not Updated");

            passed.BusinessToChange = null;
            passed.ChangeSpecificObject = false;

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
            if (passed.BusinessMap != null)
            {
                for (int i = 0; i < passed.BusinessMap.Count; i++)
                    DgvBusinessList.Rows.Add(passed.BusinessMap.Values.ToArray()[i].BusinessName);
            }

            DgvBusinessList.RowsDefaultCellStyle.BackColor = Color.Bisque;
            DgvBusinessList.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }

        private void BtnRemoveSelected_Click(object sender, EventArgs e)
        {
            Business business = GetBusinessSelection();

            if (business != null && passed.BusinessMap != null)
            {
                if (MainProgramCode.RequestConfirmation("Are you sure you want to permanently delete '" + business.BusinessName + "' from the business list?", "REQUEST - Deletion Request"))
                {
                    passed.BusinessMap.Remove(business.BusinessLegalDetails.RegistrationNumber);
                    MainProgramCode.ShowInformation("Successfully deleted '" + business.BusinessName + "' from the business list", "CONFIRMATION - Deletion Success");

                    if (passed.BusinessMap.Count == 0) passed.BusinessMap = null;

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

            if (passed.BusinessMap != null)
            {
                business = passed.BusinessMap.SingleOrDefault(p => p.Value.BusinessName == SearchName).Value;
                return business;
            }

            return null;
        }

        private void LoadInformation()
        {
            DgvBusinessList.Rows.Clear();

            if (passed.BusinessMap != null)
                for (int i = 0; i < passed.BusinessMap.Count; i++)
                {
                    DgvBusinessList.Rows.Add(passed.BusinessMap.Values.ToArray()[i].BusinessName);
                }
        }

        private bool ReplaceBusiness(Business Original, Business New)
        {
            if (New != null && Original != null && passed.BusinessMap != null)
                for (int i = 0; i < passed.BusinessMap.Count; i++)
                    if (passed.BusinessMap.Values.ToArray()[i] == Original)
                    {
                        passed.BusinessMap.Values.ToArray()[i] = New;
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
