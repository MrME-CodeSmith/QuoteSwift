using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MainProgramLibrary;
using QuoteSwift.Models;

namespace QuoteSwift.Forms
{
    public partial class FrmViewParts : Form
    {

        AppContext mPassed;

        public FrmViewParts()
        {
            InitializeComponent();
        }

        public ref AppContext Passed { get => ref mPassed; }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                QuoteSwiftMainCode.CloseApplication(true);
        }

        private void BtnAddPart_Click(object sender, EventArgs e)
        {
            Hide();
            QuoteSwiftMainCode.AddNewPart();
            Show();
        }

        private void BtnUpdateSelectedPart_Click(object sender, EventArgs e)
        {
            Part objPartSelection = GetSelectedPart();

            if (objPartSelection != null)
            {
                mPassed.ChangeSpecificObject = false;
                mPassed.PartToChange = objPartSelection;

                Hide();
                QuoteSwiftMainCode.AddNewPart();
                Show();

                mPassed.ChangeSpecificObject = false;
                mPassed.PartToChange = null;
            }
            else
            {
                MainProgramCode.ShowError("The current selection is invalid.\nPlease choose a valid Part from the list.", "ERROR - Invalid Selection");
            }
        }

        private void FrmViewParts_Activated(object sender, EventArgs e)
        {
            if (mPassed != null)
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
                        mPassed.MandatoryPartMap.Remove(SelectedPart.NewPartNumber); // Remember map contains both New and Original part numbers
                        MainProgramCode.ShowInformation("Successfully deleted " + SelectedPart.PartName + " from the pump list", "CONFIRMATION - Deletion Success");
                    }
                }
                else
                {
                    if (MainProgramCode.RequestConfirmation("Are you sure you want to permanently delete " + SelectedPart.PartName + " part from the list of parts?", "REQUEST - Deletion Request"))
                    {
                        mPassed.NonMandatoryPartMap.Remove(SelectedPart.NewPartNumber); // Remember map contains both New and Original part numbers
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
            if (mPassed.MandatoryPartMap != null)
                for (int i = 0; i < mPassed.MandatoryPartMap.Count; i++)
                {
                    //Manually setting the data grid's rows' values:
                    dgvAllParts.Rows.Add(mPassed.MandatoryPartMap.Values.ToArray()[i].PartName, mPassed.MandatoryPartMap.Values.ToArray()[i].PartDescription, mPassed.MandatoryPartMap.Values.ToArray()[i].OriginalItemPartNumber, mPassed.MandatoryPartMap.Values.ToArray()[i].NewPartNumber, true, mPassed.MandatoryPartMap.Values.ToArray()[i].PartPrice);
                }
        }

        void LoadNonMandatoryParts()
        {
            if (mPassed.NonMandatoryPartMap != null)
                for (int k = 0; k < mPassed.NonMandatoryPartMap.Count; k++)
                {
                    //Manually setting the data grid's rows' values:
                    dgvAllParts.Rows.Add(mPassed.NonMandatoryPartMap.Values.ToArray()[k].PartName, mPassed.NonMandatoryPartMap.Values.ToArray()[k].PartDescription, mPassed.NonMandatoryPartMap.Values.ToArray()[k].OriginalItemPartNumber, mPassed.NonMandatoryPartMap.Values.ToArray()[k].NewPartNumber, false, mPassed.NonMandatoryPartMap.Values.ToArray()[k].PartPrice);
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


            if (mPassed.MandatoryPartMap.Count > 0 || mPassed.NonMandatoryPartMap.Count > 0 || mPassed != null || mPassed.MandatoryPartMap != null || mPassed.NonMandatoryPartMap != null)
            {

                if ((bool)(dgvAllParts.Rows[iGridSelection].Cells[4].Value) == true)
                {
                    //Search for part in mandatory

                    SelectedPart = mPassed.MandatoryPartMap.SingleOrDefault(p => p.Value.OriginalItemPartNumber == SearchName).Value;
                    return SelectedPart;

                }
                else // Search in Non-Mandatory
                {
                    SelectedPart = mPassed.NonMandatoryPartMap.SingleOrDefault(p => p.Value.OriginalItemPartNumber == SearchName).Value;
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
            QuoteSwiftMainCode.CloseApplication(true);
        }

        /*********************************************************************************/
    }
}