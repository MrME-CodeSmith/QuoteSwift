using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace QuoteSwift // Repair Quote Swift
{
    public partial class FrmViewPump : Form
    {

        readonly ViewPumpViewModel viewModel;
        readonly INavigationService navigation;
        readonly ApplicationData appData;
        readonly IMessageService messageService;

        public FrmViewPump(ViewPumpViewModel viewModel, INavigationService navigation = null, ApplicationData data = null, IMessageService messageService = null)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.navigation = navigation;
            appData = data;
            this.messageService = messageService;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
            {
                appData.SaveAll();
                Application.Exit();
            }
        }

        private void BtnUpdateSelectedPump_Click(object sender, EventArgs e)
        {
            if (dgvPumpList.SelectedCells.Count > 0)
            {
                int iGridSelection = dgvPumpList.CurrentCell.RowIndex;

                var pToChange = appData.PumpList.ElementAt(iGridSelection);
                Hide();
                navigation.CreateNewPump();
                Show();

                viewModel.RepairableItemNames = new HashSet<string>(appData.PumpList.Select(p => StringUtil.NormalizeKey(p.PumpName)));

                LoadInformation();
            }
            else
            {
                messageService.ShowError("The current selection is invalid.\nPlease choose a valid Pump from the list.", "ERROR - Invalid Selection");
            }
        }

        private void BtnAddPump_Click(object sender, EventArgs e)
        {
            Hide();
            navigation.CreateNewPump();
            viewModel.RepairableItemNames = new HashSet<string>(appData.PumpList.Select(pu => StringUtil.NormalizeKey(pu.PumpName)));
            Show();
        }

        private void BtnRemovePumpSelection_Click(object sender, EventArgs e)
        {
            if (dgvPumpList.SelectedCells.Count > 0)
            {
                int iGridSelection = dgvPumpList.CurrentCell.RowIndex;

                Pump objPumpSelection = appData.PumpList.ElementAt(iGridSelection);

                if (messageService.RequestConfirmation("Are you sure you want to permanently delete " + objPumpSelection.PumpName + "pump from the list of pumps?", "REQUEST - Deletion Request"))
                {
                    appData.PumpList.RemoveAt(iGridSelection);
                    viewModel.RepairableItemNames.Remove(StringUtil.NormalizeKey(objPumpSelection.PumpName));

                    messageService.ShowInformation("Successfully deleted " + objPumpSelection.PumpName + " from the pump list", "INFORMATION - Deletion Success");
                }
            }
            else
            {
                messageService.ShowError("The current selection is invalid.\nPlease choose a valid Pump from the list.", "ERROR - Invalid Selection");
            }
        }

        private void MainScreenViewQuotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            Hide();
        }

        private void FrmViewPump_Load(object sender, EventArgs e)
        {
            LoadInformation();
            dgvPumpList.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dgvPumpList.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }

        /** Form Specific Functions And Procedures: 
        *
        * Note: Not all Functions or Procedures below are being used more than once
        *       Some of them are only here to keep the above events easily understandable 
        *       and clutter free.                                                          
        */

        private void LoadInformation()
        {
            //Manually Load Pump items:
            dgvPumpList.Rows.Clear();

            if (appData.PumpList != null)
            {
                foreach (var pump in appData.PumpList)
                {
                    dgvPumpList.Rows.Add(pump.PumpName,
                                        pump.PumpDescription,
                                        pump.NewPumpPrice.ToString());
                }
            }
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void ExportInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv|All Files (*.*)|*.*";
                sfd.DefaultExt = "csv";
                sfd.FileName = "Inventory.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        MainProgramCode.ExportInventory(appData.PumpList, sfd.FileName);
                        messageService.ShowInformation("Inventory exported successfully.", "INFORMATION - Export Successful");
                    }
                    catch (Exception ex)
                    {
                        messageService.ShowError("Inventory export failed.\n" + ex.Message, "ERROR - Export Failed");
                    }
                }
            }
        }

        private void FrmViewPump_FormClosing(object sender, FormClosingEventArgs e)
        {
            appData.SaveAll();
        }

        /*********************************************************************************/
    }
}
