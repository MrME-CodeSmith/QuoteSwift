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
        readonly ApplicationData appData;
        readonly IMessageService messageService;

        public FrmViewAllBusinesses(ViewBusinessesViewModel viewModel, INavigationService navigation = null, ApplicationData appData = null, IMessageService messageService = null)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.navigation = navigation;
            this.appData = appData;
            this.messageService = messageService;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                MainProgramCode.CloseApplication(true,
                    appData?.BusinessList,
                    appData?.PumpList,
                    appData?.PartList,
                    appData?.QuoteMap);
        }

        private void BtnUpdateBusiness_Click(object sender, EventArgs e)
        {

            Business Business = GetBusinessSelection();

            if (Business == null)
            {
                messageService.ShowError("Please select a valid Business, the current selection is invalid", "ERROR - Invalid Business Selection");
                return;
            }

            navigation.AddBusiness(appData, Business, false);

            LoadInformation();

        }

        private void BtnAddBusiness_Click(object sender, EventArgs e)
        {
            Hide();
            navigation.AddBusiness(appData);
            Show();

            LoadInformation();
        }

        private void FrmViewAllBusinesses_Load(object sender, EventArgs e)
        {
            if (appData.BusinessList != null)
            {
                foreach (var business in appData.BusinessList)
                    DgvBusinessList.Rows.Add(business.BusinessName);
            }

            DgvBusinessList.RowsDefaultCellStyle.BackColor = Color.Bisque;
            DgvBusinessList.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }

        private void BtnRemoveSelected_Click(object sender, EventArgs e)
        {
            Business business = GetBusinessSelection();

            if (business != null && appData.BusinessList != null)
            {
                if (messageService.RequestConfirmation("Are you sure you want to permanently delete '" + business.BusinessName + "' from the business list?", "REQUEST - Deletion Request"))
                {
                    appData.BusinessList.Remove(business);
                    messageService.ShowInformation("Successfully deleted '" + business.BusinessName + "' from the business list", "CONFIRMATION - Deletion Success");

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

            if (appData.BusinessList != null)
            {
                return appData.BusinessList.FirstOrDefault(b => b.BusinessName == searchName);
            }

            return null;
        }

        private void LoadInformation()
        {
            DgvBusinessList.Rows.Clear();

            if (appData.BusinessList != null)
                foreach (var business in appData.BusinessList)
                {
                    DgvBusinessList.Rows.Add(business.BusinessName);
                }
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to cancel the current action?\nCancellation can cause any changes to be lost.", "REQUEST - Cancellation")) Close();
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmViewAllBusinesses_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainProgramCode.CloseApplication(true,
                appData?.BusinessList,
                appData?.PumpList,
                appData?.PartList,
                appData?.QuoteMap);
        }

        /**********************************************************************************/
    }
}
