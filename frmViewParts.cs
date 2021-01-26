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
    public partial class FrmViewParts : Form
    {

        Pass passed;

        public FrmViewParts(ref Pass passed)
        {
            InitializeComponent();
            this.passed = passed;
        }

        public ref Pass Passed { get => ref passed; }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainProgramCode.CloseApplication(MainProgramCode.RequestConfirmation("Are you sure you want to close the application?\nAny unsaved work will be lost.", "REQUEST - Application Termination"));
        }

        private void BtnAddPart_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.passed = MainProgramCode.AddNewPart(ref this.passed);
            this.Show();
        }

        private void BtnUpdateSelectedPart_Click(object sender, EventArgs e)
        {
            if (dgvAllParts.SelectedCells.Count-1 > 0 )
            {
                int iGridSelection = Convert.ToInt32(dgvAllParts.SelectedCells[0].Value);

                Part objPartSelection;
                if (iGridSelection > passed.PassMandatoryPartList.Count - 1) // Selection is a mandatory part
                {
                    objPartSelection = this.passed.PassMandatoryPartList.ElementAt(iGridSelection);
                }
                else // Otherwise it is a non-mandatory part
                {
                    objPartSelection = this.passed.PassNonMandatoryPartList.ElementAt(iGridSelection - (passed.PassMandatoryPartList.Count - 1));
                }

                Pass ChangePartPass = new Pass(passed.PassQuoteList, passed.PassBusinessList, passed.PassPumpList, passed.PassMandatoryPartList, passed.PassNonMandatoryPartList, ref objPartSelection, true);

                this.Hide();
                this.passed = MainProgramCode.CreateNewPump(ref ChangePartPass);
                this.Show();

                this.passed.ChangeSpecificObject = false;
            }
            else
            {
                MainProgramCode.ShowError("The current selection is invalid.\nPlease choose a valid Part from the list.", "ERROR - Invalid Selection");
            }
        }

        private void FrmViewParts_Activated(object sender, EventArgs e)
        {
            if (passed != null)
            {
                dgvAllParts.Rows.Clear();
                LoadMandatoryParts();
                LoadNonMandatoryParts();
            }
        }

        private void BtnRemovePart_Click(object sender, EventArgs e)
        {
            if (dgvAllParts.Rows.Count > 0 && passed != null && (passed.PassMandatoryPartList != null || passed.PassNonMandatoryPartList != null))
            {
                int iGridSelection = dgvAllParts.CurrentCell.RowIndex;

                Part objPartSelection;
                if (iGridSelection <= passed.PassMandatoryPartList.Count - 1) // Selection is a mandatory part
                {
                    objPartSelection = this.passed.PassMandatoryPartList.ElementAt(iGridSelection);

                    if (MainProgramCode.RequestConfirmation("Are you sure you want to permanently delete " + objPartSelection.PartName + " part from the list of parts?", "REQUEST - Deletion Request"))
                    {
                        passed.PassMandatoryPartList.RemoveAt(iGridSelection);

                        MainProgramCode.ShowInformation("Successfully deleted " + objPartSelection.PartName + " from the pump list", "CONFIRMATION - Deletion Success");
                    }
                }
                else // Otherwise it is a non-mandatory part
                {
                    objPartSelection = this.passed.PassNonMandatoryPartList.ElementAt(iGridSelection - (passed.PassMandatoryPartList.Count));

                    if (MainProgramCode.RequestConfirmation("Are you sure you want to permanently delete " + objPartSelection.PartName + " part from the list of parts?", "REQUEST - Deletion Request"))
                    {
                        passed.PassNonMandatoryPartList.RemoveAt(iGridSelection - (passed.PassMandatoryPartList.Count));

                        MainProgramCode.ShowInformation("Successfully deleted " + objPartSelection.PartName + " from the pump list", "CONFIRMATION - Deletion Success");
                    }
                }

            }
            else
            {
                MainProgramCode.ShowError("The current selection is invalid.\nPlease choose a valid Part from the list.", "ERROR - Invalid Selection");
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
            if(passed.PassMandatoryPartList != null)
                for (int i = 0; i < passed.PassMandatoryPartList.Count; i++)
                {
                    //Manually setting the data grid's rows' values:
                    dgvAllParts.Rows.Add(passed.PassMandatoryPartList[i].PartName, passed.PassMandatoryPartList[i].PartDescription, passed.PassMandatoryPartList[i].OriginalItemPartNumber, passed.PassMandatoryPartList[i].NewPartNumber, true, passed.PassMandatoryPartList[i].PartPrice);
                }
        }

        void LoadNonMandatoryParts()
        {
            if(passed.PassNonMandatoryPartList != null)
                for (int k = 0; k < passed.PassNonMandatoryPartList.Count; k++)
                {
                    //Manually setting the data grid's rows' values:
                    dgvAllParts.Rows.Add(passed.PassNonMandatoryPartList[k].PartName, passed.PassNonMandatoryPartList[k].PartDescription, passed.PassNonMandatoryPartList[k].OriginalItemPartNumber, passed.PassNonMandatoryPartList[k].NewPartNumber, false, passed.PassNonMandatoryPartList[k].PartPrice);
                }
        }

        /*********************************************************************************/
    }
}