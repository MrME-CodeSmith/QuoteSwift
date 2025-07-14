using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace QuoteSwift // Repair Quote Swift
{
    public partial class FrmViewPump : Form
    {

        Pass passed;

        public ref Pass Passed { get => ref passed; }

        public FrmViewPump(ref Pass passed)
        {
            InitializeComponent();
            this.passed = passed;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                MainProgramCode.CloseApplication(true, ref passed);
        }

        private void BtnUpdateSelectedPump_Click(object sender, EventArgs e)
        {
            int iGridSelection;

            if (dgvPumpList.SelectedCells.Count > 0)
            {
                iGridSelection = dgvPumpList.CurrentCell.RowIndex;

                passed.PumpToChange = passed.PassPumpList.ElementAt(iGridSelection);
                passed.ChangeSpecificObject = false;

                Hide();
                passed = QuoteSwiftMainCode.CreateNewPump(ref passed);
                Show();

                passed.ChangeSpecificObject = false;
                passed.PumpToChange = null;

                LoadInformation();
            }
            else
            {
                MainProgramCode.ShowError("The current selection is invalid.\nPlease choose a valid Pump from the list.", "ERROR - Invalid Selection");
            }
        }

        private void BtnAddPump_Click(object sender, EventArgs e)
        {
            Hide();
            passed = QuoteSwiftMainCode.CreateNewPump(ref passed);
            Show();
        }

        private void BtnRemovePumpSelection_Click(object sender, EventArgs e)
        {
            if (dgvPumpList.SelectedCells.Count > 0)
            {
                int iGridSelection = dgvPumpList.CurrentCell.RowIndex;

                Pump objPumpSelection = passed.PassPumpList.ElementAt(iGridSelection);

                if (MainProgramCode.RequestConfirmation("Are you sure you want to permanently delete " + objPumpSelection.PumpName + "pump from the list of pumps?", "REQUEST - Deletion Request"))
                {
                    passed.RemoveRepairableItem(objPumpSelection);

                    MainProgramCode.ShowInformation("Successfully deleted " + objPumpSelection.PumpName + " from the pump list", "INFORMATION - Deletion Success");
                }
            }
            else
            {
                MainProgramCode.ShowError("The current selection is invalid.\nPlease choose a valid Pump from the list.", "ERROR - Invalid Selection");
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

            if (passed.PassPumpList != null)
            {
                foreach (var pump in passed.PassPumpList)
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
                        MainProgramCode.ExportInventory(passed.PassPumpList, sfd.FileName);
                        MainProgramCode.ShowInformation("Inventory exported successfully.", "INFORMATION - Export Successful");
                    }
                    catch (Exception ex)
                    {
                        MainProgramCode.ShowError("Inventory export failed.\n" + ex.Message, "ERROR - Export Failed");
                    }
                }
            }
        }

        private void FrmViewPump_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainProgramCode.CloseApplication(true, ref passed);
        }

        /*********************************************************************************/
    }
}
