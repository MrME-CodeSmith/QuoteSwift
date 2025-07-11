using System;
using System.Drawing;
using System.Linq;
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
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                QuoteSwiftMainCode.CloseApplication(true, ref passed);
        }

        private void BtnAddPart_Click(object sender, EventArgs e)
        {
            Hide();
            passed = QuoteSwiftMainCode.AddNewPart(ref passed);
            Show();
        }

        private void BtnUpdateSelectedPart_Click(object sender, EventArgs e)
        {
            Part objPartSelection = GetSelectedPart();

            if (objPartSelection != null)
            {
                passed.ChangeSpecificObject = false;
                passed.PartToChange = objPartSelection;

                Hide();
                passed = QuoteSwiftMainCode.AddNewPart(ref passed);
                Show();

                passed.ChangeSpecificObject = false;
                passed.PartToChange = null;
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
            if (passed.PassMandatoryPartList != null)
            {
                foreach (var part in passed.PassMandatoryPartList)
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
            if (passed.PassNonMandatoryPartList != null)
            {
                foreach (var part in passed.PassNonMandatoryPartList)
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
                    //Search for part in mandatory

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
            if (MainProgramCode.RequestConfirmation("Are you sure you want to cancel the current action?\nCancellation can cause any changes to this current window to be lost.", "REQUEST - Cancellation")) Close();
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
            QuoteSwiftMainCode.CloseApplication(true, ref passed);
        }

        /*********************************************************************************/
    }
}