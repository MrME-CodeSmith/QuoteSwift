using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            MainProgramCode.CloseApplication(MainProgramCode.RequestConfirmation("Are you sure you want to close the application?\nAny unsaved work will be lost.", "REQUEST - Application Termination"), ref this.passed);
        }

        private void BtnUpdateSelectedPump_Click(object sender, EventArgs e)
        {
            int iGridSelection;

            if (dgvPumpList.SelectedCells.Count > 0)
            {
                iGridSelection = dgvPumpList.CurrentCell.RowIndex;
                
                this.passed.PumpToChange = this.passed.PassPumpList.ElementAt(iGridSelection);
                this.passed.ChangeSpecificObject = false;

                this.Hide();
                this.passed = MainProgramCode.CreateNewPump(ref this.passed);
                this.Show();

                this.passed.ChangeSpecificObject = false;
                this.passed.PumpToChange = null;

                LoadInformation();
            }
            else
            {
                MainProgramCode.ShowError("The current selection is invalid.\nPlease choose a valid Pump from the list.", "ERROR - Invalid Selection");
            }
        }

        private void BtnAddPump_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.passed = MainProgramCode.CreateNewPump(ref this.passed);
            this.Show();
        }

        private void BtnRemovePumpSelection_Click(object sender, EventArgs e)
        {
            if (dgvPumpList.SelectedCells.Count > 0)
            {
                int iGridSelection = dgvPumpList.CurrentCell.RowIndex;

                Pump objPumpSelection = this.passed.PassPumpList.ElementAt(iGridSelection);

                if(MainProgramCode.RequestConfirmation("Are you sure you want to permanently delete " + objPumpSelection.PumpName + "pump from the list of pumps?", "REQUEST - Deletion Request"))
                {
                    passed.PassPumpList.RemoveAt(iGridSelection);

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
            this.Close();
            this.Hide();
        }

        private void FrmViewPump_Load(object sender, EventArgs e)
        {
            LoadInformation();
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
                for (int i = 0; i < passed.PassPumpList.Count; i++)
                {
                    dgvPumpList.Rows.Add(passed.PassPumpList[i].PumpName, passed.PassPumpList[i].PumpDescription, passed.PassPumpList[i].NewPumpPrice.ToString());
                }
            }
        }

        /*********************************************************************************/
    }
}
