using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

namespace QuoteSwift
{
    public partial class FrmViewParts : Form
    {

        readonly ViewPartsViewModel viewModel;
        readonly INavigationService navigation;

        readonly ApplicationData appData;
        readonly ISerializationService serializationService;
        readonly IMessageService messageService;
        public FrmViewParts(ViewPartsViewModel viewModel, INavigationService navigation = null, ApplicationData data = null, IMessageService messageService = null, ISerializationService serializationService = null)
        public FrmViewParts(ViewPartsViewModel viewModel, INavigationService navigation = null, ApplicationData data = null, IMessageService messageService = null)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.navigation = navigation;
            this.serializationService = serializationService;
            appData = data;
            this.messageService = messageService;
            if (appData != null)
                viewModel.UpdateData(appData.PartList);
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
                serializationService.CloseApplication(true,
                    appData?.BusinessList,
                    appData?.PumpList,
                    appData?.PartList,
                    appData?.QuoteMap);

        private void BtnAddPart_Click(object sender, EventArgs e)
        {
            Hide();
            navigation.AddNewPart();
            Show();
        }

        private void BtnUpdateSelectedPart_Click(object sender, EventArgs e)
        {
            Part objPartSelection = GetSelectedPart();

            if (objPartSelection != null)
            {
                Hide();
                navigation.AddNewPart(objPartSelection, false);
                Show();
            }
            else
            {
                messageService.ShowError("The current selection is invalid.\nPlease choose a valid Part from the list.", "ERROR - Invalid Selection");
            }
        }

        private void FrmViewParts_Activated(object sender, EventArgs e)
        {
            if (appData != null)
            {
                viewModel.UpdateData(appData.PartList);
                RefreshBinding();
            }
        }

        private void BtnRemovePart_Click(object sender, EventArgs e)
        {
            Part selectedPart = GetSelectedPart();
            if (selectedPart != null)
            {
                if (messageService.RequestConfirmation("Are you sure you want to permanently delete " + selectedPart.PartName + " part from the list of parts?", "REQUEST - Deletion Request"))
                {
                    viewModel.RemovePart(selectedPart);
                    messageService.ShowInformation("Successfully deleted " + selectedPart.PartName + " from the pump list", "CONFIRMATION - Deletion Success");
                    RefreshBinding();
                }
            }
            else
            {
                messageService.ShowError("The current selection is invalid.\nPlease choose a valid Part from the list.", "ERROR - Invalid Selection");
            }

        }

        /** Form Specific Functions And Procedures: 
        *
        * Note: Not all Functions or Procedures below are being used more than once
        *       Some of them are only here to keep the above events easily understandable 
        *       and clutter free.                                                          
        */

        void RefreshBinding()
        {
            var list = new BindingList<Part>();
            if (viewModel.MandatoryParts != null)
            {
                foreach (var p in viewModel.MandatoryParts)
                    list.Add(p);
            }
            if (viewModel.NonMandatoryParts != null)
            {
                foreach (var p in viewModel.NonMandatoryParts)
                    list.Add(p);
            }
            dgvAllParts.DataSource = new BindingSource { DataSource = list };
        }

        Part GetSelectedPart()
        {
            return dgvAllParts.CurrentRow?.DataBoundItem as Part;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (messageService.RequestConfirmation("Are you sure you want to cancel the current action?\nCancellation can cause any changes to this current window to be lost.", "REQUEST - Cancellation")) Close();
        }

        private void FrmViewParts_Load(object sender, EventArgs e)
        {
            dgvAllParts.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dgvAllParts.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            RefreshBinding();
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Still Needs Implementation.
        }

        private void FrmViewParts_FormClosing(object sender, FormClosingEventArgs e)
            serializationService.CloseApplication(true,
                appData?.BusinessList,
                appData?.PumpList,
                appData?.PartList,
                appData?.QuoteMap);
}