using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmViewParts : Form
    {

        readonly ViewPartsViewModel viewModel;
        readonly NavigationService navigation;

        Pass passed
        {
            get => viewModel.Pass;
            set => viewModel.UpdatePass(value);
        }

        public FrmViewParts(ViewPartsViewModel viewModel, NavigationService navigation = null)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.navigation = navigation;
        }

        public ref Pass Passed { get => ref passed; }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                MainProgramCode.CloseApplication(true, ref passed);
        }

        private void BtnAddPart_Click(object sender, EventArgs e)
        {
            Hide();
            navigation.Pass = passed;
            navigation.AddNewPart();
            passed = navigation.Pass;
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
                navigation.Pass = passed;
                navigation.AddNewPart();
                passed = navigation.Pass;
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
                        passed.RemovePart(SelectedPart);
                        MainProgramCode.ShowInformation("Successfully deleted " + SelectedPart.PartName + " from the pump list", "CONFIRMATION - Deletion Success");
                    }
                }
                else
                {
                    if (MainProgramCode.RequestConfirmation("Are you sure you want to permanently delete " + SelectedPart.PartName + " part from the list of parts?", "REQUEST - Deletion Request"))
                    {
                        passed.RemovePart(SelectedPart);
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
            if (passed.PassPartList != null)
            {
                foreach (var part in passed.MandatoryParts)
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
            if (passed.PassPartList != null)
            {
                foreach (var part in passed.NonMandatoryParts)
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

            if (passed.PassPartList != null && passed.PassPartList.Count > 0)
            {
                string key = StringUtil.NormalizeKey(SearchName);
                if ((bool)(dgvAllParts.Rows[iGridSelection].Cells[4].Value) == true)
                {
                    //Search for part in mandatory
                    passed.PassPartList.TryGetValue(key, out var part);
                    return part;
                }
                else // Search in Non-Mandatory
                {
                    passed.PassPartList.TryGetValue(key, out var part);
                    return part;
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
            MainProgramCode.CloseApplication(true, ref passed);
        }

        /*********************************************************************************/
    }
}