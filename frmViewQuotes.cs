using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace QuoteSwift
{
    public partial class FrmViewQuotes : Form
    {

        readonly QuotesViewModel viewModel;
        readonly INavigationService navigation;

        public FrmViewQuotes(QuotesViewModel viewModel, INavigationService navigation = null)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.navigation = navigation;
        }

        private void BtnCreateNewQuote_Click(object sender, EventArgs e)
        {
            if (viewModel.BusinessList != null && viewModel.BusinessList.Count > 0 && viewModel.PumpList != null && viewModel.BusinessList[0].BusinessCustomerList != null)
            {
                Hide();
                navigation.Pass = new Pass(viewModel.QuoteMap, viewModel.BusinessList, viewModel.PumpList, viewModel.PartMap);
                navigation.CreateNewQuote();
                viewModel.UpdateData(navigation.Pass.PassQuoteMap, navigation.Pass.PassBusinessList, navigation.Pass.PassPumpList, navigation.Pass.PassPartList);
                try
                {
                    Show();
                }
                catch (Exception)
                {
                    // Do Nothing - Since this only happens when Application.Exit() is called.
                }
            }
            else
            {
                MainProgramCode.ShowError("Please ensure that the following information is provided before creating a quote:\n" +
                                          ">  Business Information.\n" +
                                          ">  Business' Customer's Information.\n" +
                                          ">  Pump Information.", "ERROR - Prerequisites Not Met");
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainProgramCode.RequestConfirmation("Are you sure you want to close the application?", "REQUEST - Application Termination"))
            {
                var p = new Pass(viewModel.QuoteMap, viewModel.BusinessList, viewModel.PumpList, viewModel.PartMap);
                MainProgramCode.CloseApplication(true, ref p);
                viewModel.UpdateData(p.PassQuoteMap, p.PassBusinessList, p.PassPumpList, p.PassPartList);
            }
        }

        private void ManagePumpsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            navigation.Pass = new Pass(viewModel.QuoteMap, viewModel.BusinessList, viewModel.PumpList, viewModel.PartMap);
            navigation.ViewAllPumps();
            viewModel.UpdateData(navigation.Pass.PassQuoteMap, navigation.Pass.PassBusinessList, navigation.Pass.PassPumpList, navigation.Pass.PassPartList);
            try
            {
                Show();
            }
            catch (Exception)
            {
                // Do Nothing - Since this only happens when Application.Exit() is called.
            }
        }

        private void CreateNewPumpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            navigation.Pass = new Pass(viewModel.QuoteMap, viewModel.BusinessList, viewModel.PumpList, viewModel.PartMap);
            navigation.CreateNewPump();
            viewModel.UpdateData(navigation.Pass.PassQuoteMap, navigation.Pass.PassBusinessList, navigation.Pass.PassPumpList, navigation.Pass.PassPartList);
            try
            {
                Show();
            }
            catch (Exception)
            {
                // Do Nothing - Since this only happens when Application.Exit() is called.
            }
        }

        private void ViewAllPumpsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            managePumpsToolStripMenuItem.PerformClick();
        }

        private void AddNewCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            navigation.Pass = new Pass(viewModel.QuoteMap, viewModel.BusinessList, viewModel.PumpList, viewModel.PartMap);
            navigation.AddCustomer();
            viewModel.UpdateData(navigation.Pass.PassQuoteMap, navigation.Pass.PassBusinessList, navigation.Pass.PassPumpList, navigation.Pass.PassPartList);
            try
            {
                Show();
            }
            catch (Exception)
            {
                // Do Nothing - Since this only happens when Application.Exit() is called.
            }
        }

        private void ViewAllCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            navigation.Pass = new Pass(viewModel.QuoteMap, viewModel.BusinessList, viewModel.PumpList, viewModel.PartMap);
            navigation.ViewCustomers();
            viewModel.UpdateData(navigation.Pass.PassQuoteMap, navigation.Pass.PassBusinessList, navigation.Pass.PassPumpList, navigation.Pass.PassPartList);
            try
            {
                Show();
            }
            catch (Exception)
            {
                // Do Nothing - Since this only happens when Application.Exit() is called.
            }
        }

        private void ManageCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewAllCustomersToolStripMenuItem.PerformClick();
        }

        private void AddNewBusinessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            navigation.Pass = new Pass(viewModel.QuoteMap, viewModel.BusinessList, viewModel.PumpList, viewModel.PartMap);
            navigation.AddBusiness();
            viewModel.UpdateData(navigation.Pass.PassQuoteMap, navigation.Pass.PassBusinessList, navigation.Pass.PassPumpList, navigation.Pass.PassPartList);
            try
            {
                Show();
            }
            catch (Exception)
            {
                // Do Nothing - Since this only happens when Application.Exit() is called.
            }
        }

        private void ViewAllBusinessesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            navigation.Pass = new Pass(viewModel.QuoteMap, viewModel.BusinessList, viewModel.PumpList, viewModel.PartMap);
            navigation.ViewBusinesses();
            viewModel.UpdateData(navigation.Pass.PassQuoteMap, navigation.Pass.PassBusinessList, navigation.Pass.PassPumpList, navigation.Pass.PassPartList);
            try
            {
                Show();
            }
            catch (Exception)
            {
                // Do Nothing - Since this only happens when Application.Exit() is called.
            }
        }

        private void ManageBusinessesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewAllBusinessesToolStripMenuItem.PerformClick();
        }

        Quote GetSelectedQuote()
        {
            if (dgvPreviousQuotes.CurrentCell == null || dgvPreviousQuotes.CurrentRow == null)
                return null;

            int idx = dgvPreviousQuotes.CurrentCell.RowIndex;
            if (idx < 0 || idx >= dgvPreviousQuotes.Rows.Count)
                return null;

            return dgvPreviousQuotes.Rows[idx].DataBoundItem as Quote;
        }

        private void BtnViewSelectedQuote_Click(object sender, EventArgs e)
        {
            if (viewModel.QuoteMap != null)
            {
                Quote selected = GetSelectedQuote();
                if (selected != null)
                {
                    Hide();
                    navigation.Pass = new Pass(viewModel.QuoteMap, viewModel.BusinessList, viewModel.PumpList, viewModel.PartMap);
                    navigation.Pass.QuoteTOChange = selected;
                    navigation.Pass.ChangeSpecificObject = false;
                    navigation.CreateNewQuote();
                    navigation.Pass.QuoteTOChange = null;
                    navigation.Pass.ChangeSpecificObject = false;
                    viewModel.UpdateData(navigation.Pass.PassQuoteMap, navigation.Pass.PassBusinessList, navigation.Pass.PassPumpList, navigation.Pass.PassPartList);
                    Show();
                }
            }
        }

        private void BtnCreateNewQuoteOnSelection_Click(object sender, EventArgs e)
        {
            if (viewModel.QuoteMap != null)
            {
                Quote selected = GetSelectedQuote();
                if (selected != null)
                {
                    this.Hide();
                    navigation.Pass = new Pass(viewModel.QuoteMap, viewModel.BusinessList, viewModel.PumpList, viewModel.PartMap);
                    navigation.Pass.QuoteTOChange = selected;
                    navigation.Pass.ChangeSpecificObject = true;
                    navigation.CreateNewQuote();
                    navigation.Pass.QuoteTOChange = null;
                    navigation.Pass.ChangeSpecificObject = false;
                    viewModel.UpdateData(navigation.Pass.PassQuoteMap, navigation.Pass.PassBusinessList, navigation.Pass.PassPumpList, navigation.Pass.PassPartList);
                    this.Show();
                }
            }
        }

        private void ViewAllPartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            navigation.Pass = new Pass(viewModel.QuoteMap, viewModel.BusinessList, viewModel.PumpList, viewModel.PartMap);
            navigation.ViewAllParts();
            viewModel.UpdateData(navigation.Pass.PassQuoteMap, navigation.Pass.PassBusinessList, navigation.Pass.PassPumpList, navigation.Pass.PassPartList);
            try
            {
                Show();
            }
            catch (Exception)
            {
                // Do Nothing - Since this only happens when Application.Exit() is called.
            }
        }

        private void ManagePumpPartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewAllPartsToolStripMenuItem.PerformClick();
        }

        private void AddNewPartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            navigation.Pass = new Pass(viewModel.QuoteMap, viewModel.BusinessList, viewModel.PumpList, viewModel.PartMap);
            navigation.AddNewPart();
            viewModel.UpdateData(navigation.Pass.PassQuoteMap, navigation.Pass.PassBusinessList, navigation.Pass.PassPumpList, navigation.Pass.PassPartList);
            try
            {
                Show();
            }
            catch (Exception)
            {
                // Do Nothing - Since this only happens when Application.Exit() is called.
            }
        }

        private void FrmViewQuotes_Load(object sender, EventArgs e)
        {

            viewModel.LoadData();
            LoadDataGrid();
        }

        readonly int count = 0;
        private void FrmViewQuotes_FormClosing(object sender, FormClosingEventArgs e)
        {
            var p = new Pass(viewModel.QuoteMap, viewModel.BusinessList, viewModel.PumpList, viewModel.PartMap);
            MainProgramCode.CloseApplication(true, ref p);
            viewModel.UpdateData(p.PassQuoteMap, p.PassBusinessList, p.PassPumpList, p.PassPartList);
        }

        void LoadDataGrid()
        {


            BindingSource PreviousQuotesDatagridBindingSource = null;
            if (viewModel.QuoteMap != null)
                PreviousQuotesDatagridBindingSource = new BindingSource { DataSource = new BindingList<Quote>(viewModel.QuoteMap.Values.ToList()) };

            if (PreviousQuotesDatagridBindingSource != null)
            {
                dgvPreviousQuotes.DataSource = PreviousQuotesDatagridBindingSource;


                dgvPreviousQuotes.Columns["QuoteNumber"].HeaderText = "Quote Number";
                dgvPreviousQuotes.Columns["QuoteNumber"].ReadOnly = true;

                dgvPreviousQuotes.Columns["QuoteCreationDate"].HeaderText = "Quote Creation Date";
                dgvPreviousQuotes.Columns["QuoteCreationDate"].ReadOnly = true;

                dgvPreviousQuotes.Columns["QuoteExpireyDate"].HeaderText = "Quote Expiry Date";
                dgvPreviousQuotes.Columns["QuoteExpireyDate"].ReadOnly = true;

                dgvPreviousQuotes.Columns["QuoteReference"].HeaderText = "Quote Reference";
                dgvPreviousQuotes.Columns["QuoteReference"].Visible = false;

                dgvPreviousQuotes.Columns["QuoteJobNumber"].HeaderText = "Quote Job-Number";
                dgvPreviousQuotes.Columns["QuoteJobNumber"].ReadOnly = true;


                dgvPreviousQuotes.Columns["QuotePRNumber"].HeaderText = "Quote PR-Number";
                dgvPreviousQuotes.Columns["QuotePRNumber"].Visible = false;
                dgvPreviousQuotes.Columns["QuotePRNumber"].ReadOnly = true;

                dgvPreviousQuotes.Columns["QuotePaymentTerm"].HeaderText = "Quote Payment Term";
                dgvPreviousQuotes.Columns["QuotePaymentTerm"].Visible = false;
                dgvPreviousQuotes.Columns["QuotePaymentTerm"].ReadOnly = true;


                dgvPreviousQuotes.Columns["QuoteLineNumber"].HeaderText = "Quote Line Number";
                dgvPreviousQuotes.Columns["QuoteLineNumber"].Visible = false;
                dgvPreviousQuotes.Columns["QuoteLineNumber"].ReadOnly = true;


                dgvPreviousQuotes.Columns["QuoteNewUnitPrice"].HeaderText = "New Pump Unit Price";
                dgvPreviousQuotes.Columns["QuoteNewUnitPrice"].Visible = false;
                dgvPreviousQuotes.Columns["QuoteNewUnitPrice"].ReadOnly = true;


                dgvPreviousQuotes.Columns["QuoteRepairPercentage"].HeaderText = "Repair Percentage";
                dgvPreviousQuotes.Columns["QuoteRepairPercentage"].Visible = false;
                dgvPreviousQuotes.Columns["QuoteRepairPercentage"].ReadOnly = true;

                dgvPreviousQuotes.Columns["QuoteDeliveryAddress"].HeaderText = "Delivery Address";
                dgvPreviousQuotes.Columns["QuoteDeliveryAddress"].Visible = false;

                dgvPreviousQuotes.Columns["Telefone"].HeaderText = "Telephone";
                dgvPreviousQuotes.Columns["Telefone"].Visible = false;
                dgvPreviousQuotes.Columns["Telefone"].ReadOnly = true;

                dgvPreviousQuotes.Columns["Cellphone"].HeaderText = "Cellphone";
                dgvPreviousQuotes.Columns["Cellphone"].Visible = false;
                dgvPreviousQuotes.Columns["Cellphone"].ReadOnly = true;

                dgvPreviousQuotes.Columns["Email"].HeaderText = "Email";
                dgvPreviousQuotes.Columns["Email"].ReadOnly = true;
                dgvPreviousQuotes.Columns["Email"].Visible = false;

                dgvPreviousQuotes.Columns["NetDays"].HeaderText = "Quote Creation Date";
                dgvPreviousQuotes.Columns["NetDays"].Visible = false;
                dgvPreviousQuotes.Columns["NetDays"].ReadOnly = true;

                dgvPreviousQuotes.Columns["PumpName"].HeaderText = "Quote Number";
                dgvPreviousQuotes.Columns["PumpName"].Visible = false;
                dgvPreviousQuotes.Columns["PumpName"].ReadOnly = true;

            }

        }

        private void FrmViewQuotes_Activated(object sender, EventArgs e)
        {
            LoadDataGrid();
        }
    }
}
