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
            MainProgramCode.CloseApplication(MainProgramCode.RequestConfirmation("Are you sure you want to close the application?\nAny unsaved work will be lost.", "REQUEST - Application Termination"), ref this.passed);
        }

        private void BtnAddPart_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.passed = MainProgramCode.AddNewPart(ref this.passed);
            this.Show();
        }

        private void BtnUpdateSelectedPart_Click(object sender, EventArgs e)
        {
            Part objPartSelection = GetSelectedPart();

            if (objPartSelection != null)
            {
                this.passed.ChangeSpecificObject = false;
                this.passed.PartToChange = objPartSelection;

                this.Hide();
                this.passed = MainProgramCode.AddNewPart(ref this.passed);
                this.Show();

                this.passed.ChangeSpecificObject = false;
                this.passed.PartToChange = null;
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
            Part SelectedPart = GetSelectedPart();
            if (SelectedPart != null)
            {
                if (SelectedPart.MandatoryPart)
                {
                    if (MainProgramCode.RequestConfirmation("Are you sure you want to permanently delete " + SelectedPart.PartName + " part from the list of parts?", "REQUEST - Deletion Request"))
                    {
                        passed.PassMandatoryPartList.Remove(SelectedPart);
                        MainProgramCode.ShowInformation("Successfully deleted " + SelectedPart.PartName + " from the pump list", "CONFIRMATION - Deletion Success");
                    }
                }
                else
                {
                    if (MainProgramCode.RequestConfirmation("Are you sure you want to permanently delete " + SelectedPart.PartName + " part from the list of parts?", "REQUEST - Deletion Request"))
                    {
                        passed.PassNonMandatoryPartList.Remove(SelectedPart);
                        MainProgramCode.ShowInformation("Successfully deleted " + SelectedPart.PartName + " from the pump list", "CONFIRMATION - Deletion Success");
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
        
        Part GetSelectedPart()
        {
            Part SelectedPart;
            string SearchName;
            int iGridSelection = 0;
            try
            {
                iGridSelection = dgvAllParts.CurrentCell.RowIndex;
                SearchName = dgvAllParts.Rows[iGridSelection].Cells[2].Value.ToString();
            }
            catch (NullReferenceException)
            {
                return null;
            }


            if (passed.PassMandatoryPartList.Count > 0 || passed.PassNonMandatoryPartList.Count > 0 || passed != null || passed.PassMandatoryPartList != null || passed.PassNonMandatoryPartList != null)
            {

                if ((bool)(dgvAllParts.Rows[iGridSelection].Cells[4].Value) == true)
                {
                    //serach for part in mandatory

                    SelectedPart = passed.PassMandatoryPartList.SingleOrDefault(p => p.OriginalItemPartNumber == SearchName);
                    return SelectedPart;
                    
                }
                else // Search in Non-Mandatory
                {
                    SelectedPart = passed.PassNonMandatoryPartList.SingleOrDefault(p => p.OriginalItemPartNumber == SearchName);
                    return SelectedPart;
                }
            }

            return null;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancelation can cause any changes to this current window to be lost.", "REQUEST - Cancelation")) this.Close();
        }

        private void FrmViewParts_Load(object sender, EventArgs e)
        {
            this.dgvAllParts.RowsDefaultCellStyle.BackColor = Color.Bisque;
            this.dgvAllParts.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }

        /*********************************************************************************/
    }
}