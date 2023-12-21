using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuoteSwift // Repair Quote Swift
{
    public partial class FrmViewPump : Form
    {

        AppContext passed;

        public ref AppContext Passed { get => ref passed; }

        public FrmViewPump()
        {
            InitializeComponent();
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                QuoteSwiftMainCode.CloseApplication(true);
        }

        private void BtnUpdateSelectedPump_Click(object sender, EventArgs e)
        {
            int iGridSelection;

            if (dgvPumpList.SelectedCells.Count > 0)
            {
                iGridSelection = dgvPumpList.CurrentCell.RowIndex;

                passed.PumpToChange = passed.ProductMap.Values.ToArray().ElementAt(iGridSelection);
                passed.ChangeSpecificObject = false;

                Hide();
                QuoteSwiftMainCode.CreateNewPump();
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
            QuoteSwiftMainCode.CreateNewPump();
            Show();
        }

        private void BtnRemovePumpSelection_Click(object sender, EventArgs e)
        {
            if (dgvPumpList.SelectedCells.Count > 0)
            {
                int iGridSelection = dgvPumpList.CurrentCell.RowIndex;

                Product objPumpSelection = passed.ProductMap.Values.ToArray().ElementAt(iGridSelection);

                if (MainProgramCode.RequestConfirmation("Are you sure you want to permanently delete " + objPumpSelection.ProductName + "pump from the list of pumps?", "REQUEST - Deletion Request"))
                {
                    passed.ProductMap.Remove(objPumpSelection.ProductName);

                    MainProgramCode.ShowInformation("Successfully deleted " + objPumpSelection.ProductName + " from the pump list", "INFORMATION - Deletion Success");
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

            if (passed.ProductMap != null)
            {
                for (int i = 0; i < passed.ProductMap.Count; i++)
                {
                    dgvPumpList.Rows.Add(passed.ProductMap.Values.ToArray()[i].ProductName, passed.ProductMap.Values.ToArray()[i].PumpDescription, passed.ProductMap.Values.ToArray()[i].NewProductPrice.ToString());
                }
            }
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmViewPump_FormClosing(object sender, FormClosingEventArgs e)
        {
            QuoteSwiftMainCode.CloseApplication(true);
        }

        /*********************************************************************************/
    }
}
