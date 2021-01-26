using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuoteSwift
{

    public partial class frmViewPump : Form
    {
        
         

        Pass passed;

        public frmViewPump(ref Pass passed)
        {
            InitializeComponent();
            this.passed = passed;
        }

        public ref Pass Passed { get => ref passed; }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainProgramCode.CloseApplication(MainProgramCode.RequestConfirmation("Are you sure you want to close the application?\nAny unsaved work will be lost.", "REQUEST - Application Termination"));
        }

        private void BtnUpdateSelectedPump_Click(object sender, EventArgs e)
        {
            if (dgvPumpList.SelectedCells.Count > 0)
            {
                int iGridSelection = Convert.ToInt32(dgvPumpList.SelectedCells[0].Value);

                Pump objPumpSelection = this.passed.PassPumpList.ElementAt(iGridSelection);

                Pass ChangePumpPass = new Pass(passed.PassQuoteList, passed.PassBusinessList, passed.PassPumpList, passed.PassMandatoryPartList, passed.PassNonMandatoryPartList, ref objPumpSelection, true);

                this.Hide();
                this.passed = MainProgramCode.CreateNewPump(ref ChangePumpPass);
                this.Show();

                this.passed.ChangeSpecificObject = false;
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

        private void FrmViewPump_Activated(object sender, EventArgs e)
        {
            if(passed != null && passed.PassPumpList != null) dgvPumpList.DataSource = passed.PassPumpList;
        }

        private void BtnRemovePumpSelection_Click(object sender, EventArgs e)
        {
            if (dgvPumpList.SelectedCells.Count > 0)
            {
                int iGridSelection = Convert.ToInt32(dgvPumpList.SelectedCells[0].Value);

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

        /** Form Specific Functions And Procedures: 
        *
        * Note: Not all Functions or Procedures below are being used more than once
        *       Some of them are only here to keep the above events easily understandable 
        *       and clutter free.                                                          
        */

        /*********************************************************************************/
    }
}
