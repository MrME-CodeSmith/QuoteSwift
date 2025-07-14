using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmViewParts : Form
    {

        readonly ViewPartsViewModel viewModel;
        readonly INavigationService navigation;

        public FrmViewParts(ViewPartsViewModel viewModel, INavigationService navigation = null)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.navigation = navigation;
        }


        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
            {
                var p = viewModel.Pass;
                MainProgramCode.CloseApplication(true, ref p);
                viewModel.UpdatePass(p);
            }
        }

        private void BtnAddPart_Click(object sender, EventArgs e)
        {
            Hide();
            navigation.AddNewPart();
            viewModel.UpdatePass(navigation.Pass);
            Show();
        }

        private void BtnUpdateSelectedPart_Click(object sender, EventArgs e)
        {
            Part objPartSelection = GetSelectedPart();

            if (objPartSelection != null)
            {
                viewModel.Pass.ChangeSpecificObject = false;
                viewModel.Pass.PartToChange = objPartSelection;

                Hide();
                navigation.AddNewPart();
                viewModel.UpdatePass(navigation.Pass);
                Show();

                viewModel.Pass.ChangeSpecificObject = false;
                viewModel.Pass.PartToChange = null;
            }
            else
            {
                MainProgramCode.ShowError("The current selection is invalid.\nPlease choose a valid Part from the list.", "ERROR - Invalid Selection");
            }
        }

        private void FrmViewParts_Activated(object sender, EventArgs e)
        {
            if (viewModel.Pass != null)
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
                        viewModel.Pass.RemovePart(SelectedPart);
                        MainProgramCode.ShowInformation("Successfully deleted " + SelectedPart.PartName + " from the pump list", "CONFIRMATION - Deletion Success");
                    }
                }
                else
                {
                    if (MainProgramCode.RequestConfirmation("Are you sure you want to permanently delete " + SelectedPart.PartName + " part from the list of parts?", "REQUEST - Deletion Request"))
                    {
                        viewModel.Pass.RemovePart(SelectedPart);
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
            if (viewModel.Pass.PassPartList != null)
            {
                foreach (var part in viewModel.Pass.MandatoryParts)
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
            if (viewModel.Pass.PassPartList != null)
            {
                foreach (var part in viewModel.Pass.NonMandatoryParts)
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

            if (viewModel.Pass.PassPartList != null && viewModel.Pass.PassPartList.Count > 0)
            {
                string key = StringUtil.NormalizeKey(SearchName);
                if ((bool)(dgvAllParts.Rows[iGridSelection].Cells[4].Value) == true)
                {
                    //Search for part in mandatory
                    viewModel.Pass.PassPartList.TryGetValue(key, out var part);
                    return part;
                }
                else // Search in Non-Mandatory
                {
                    viewModel.Pass.PassPartList.TryGetValue(key, out var part);
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
            var p = viewModel.Pass;
            MainProgramCode.CloseApplication(true, ref p);
            viewModel.UpdatePass(p);
        }

        /*********************************************************************************/
    }
}