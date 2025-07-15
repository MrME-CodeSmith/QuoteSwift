using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmViewParts : Form
    {

        readonly ViewPartsViewModel viewModel;
        readonly INavigationService navigation;

        readonly ApplicationData appData;
        readonly IMessageService messageService;

        public FrmViewParts(ViewPartsViewModel viewModel, INavigationService navigation = null, ApplicationData data = null, IMessageService messageService = null)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.navigation = navigation;
            appData = data;
            this.messageService = messageService;
            if (appData != null)
                viewModel.UpdateData(appData.PartList);
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

        private void BtnAddPart_Click(object sender, EventArgs e)
        {
            Hide();
            navigation.AddNewPart();
            Show();
        }

        private void BtnUpdateSelectedPart_Click(object sender, EventArgs e)
        {
            Part objPartSelection = GetSelectedPart();

            if (objPartSelection != null)
            {
                Hide();
                navigation.AddNewPart(objPartSelection, false);
                Show();
            }
            else
            {
                messageService.ShowError("The current selection is invalid.\nPlease choose a valid Part from the list.", "ERROR - Invalid Selection");
            }
        }

        private void FrmViewParts_Activated(object sender, EventArgs e)
        {
            if (appData != null)
            {
                dgvAllParts.Rows.Clear();
                LoadMandatoryParts();
                LoadNonMandatoryParts();
            }
        }

        private void BtnRemovePart_Click(object sender, EventArgs e)
        {
            Part SelectedPart = GetSelectedPart();
            if (SelectedPart != null)
            {
                if (SelectedPart.MandatoryPart)
                {
                    if (messageService.RequestConfirmation("Are you sure you want to permanently delete " + SelectedPart.PartName + " part from the list of parts?", "REQUEST - Deletion Request"))
                    {
                        appData.PartList?.Remove(StringUtil.NormalizeKey(SelectedPart.OriginalItemPartNumber));
                        messageService.ShowInformation("Successfully deleted " + SelectedPart.PartName + " from the pump list", "CONFIRMATION - Deletion Success");
                    }
                }
                else
                {
                    if (messageService.RequestConfirmation("Are you sure you want to permanently delete " + SelectedPart.PartName + " part from the list of parts?", "REQUEST - Deletion Request"))
                    {
                        appData.PartList?.Remove(StringUtil.NormalizeKey(SelectedPart.OriginalItemPartNumber));
                        messageService.ShowInformation("Successfully deleted " + SelectedPart.PartName + " from the pump list", "CONFIRMATION - Deletion Success");
                    }
                }
            }
            else
            {
                messageService.ShowError("The current selection is invalid.\nPlease choose a valid Part from the list.", "ERROR - Invalid Selection");
            }

        }

        /** Form Specific Functions And Procedures: 
        *
        * Note: Not all Functions or Procedures below are being used more than once
        *       Some of them are only here to keep the above events easily understandable 
        *       and clutter free.                                                          
        */

        void LoadMandatoryParts()
        {
            if (appData.PartList != null)
            {
                foreach (var part in appData.PartList.Values.Where(p => p.MandatoryPart))
                {
                    //Manually setting the data grid's rows' values:
                    dgvAllParts.Rows.Add(part.PartName,
                                         part.PartDescription,
                                         part.OriginalItemPartNumber,
                                         part.NewPartNumber,
                                         true,
                                         part.PartPrice);
                }
            }
        }

        void LoadNonMandatoryParts()
        {
            if (appData.PartList != null)
            {
                foreach (var part in appData.PartList.Values.Where(p => !p.MandatoryPart))
                {
                    //Manually setting the data grid's rows' values:
                    dgvAllParts.Rows.Add(part.PartName,
                                         part.PartDescription,
                                         part.OriginalItemPartNumber,
                                         part.NewPartNumber,
                                         false,
                                         part.PartPrice);
                }
            }
        }

        Part GetSelectedPart()
        {
            if (dgvAllParts.CurrentCell == null || dgvAllParts.CurrentRow == null)
                return null;

            int iGridSelection = dgvAllParts.CurrentCell.RowIndex;
            if (iGridSelection < 0 || iGridSelection >= dgvAllParts.Rows.Count)
                return null;

            string SearchName = dgvAllParts.Rows[iGridSelection].Cells[2].Value?.ToString();
            if (string.IsNullOrEmpty(SearchName))
                return null;

            if (appData.PartList != null && appData.PartList.Count > 0)
            {
                string key = StringUtil.NormalizeKey(SearchName);
                if ((bool)(dgvAllParts.Rows[iGridSelection].Cells[4].Value) == true)
                {
                    appData.PartList.TryGetValue(key, out var part);
                    return part;
                }
                else // Search in Non-Mandatory
                {
                    appData.PartList.TryGetValue(key, out var part);
                    return part;
                }
            }

            return null;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to cancel the current action?\nCancellation can cause any changes to this current window to be lost.", "REQUEST - Cancellation")) Close();
        }

        private void FrmViewParts_Load(object sender, EventArgs e)
        {
            dgvAllParts.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dgvAllParts.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmViewParts_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainProgramCode.CloseApplication(true,
                appData?.BusinessList,
                appData?.PumpList,
                appData?.PartList,
                appData?.QuoteMap);
        }

        /*********************************************************************************/
    }
}