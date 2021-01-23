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
    public partial class frmViewQuotes : Form
    {

        readonly MainProgramCode MPC = new MainProgramCode(); //Creating an instance of the class MainProgramCode containing specialised methods

        Pass passed;
        public frmViewQuotes(ref Pass passed)
        {
            InitializeComponent();
            this.passed = passed;
        }

        private void btnCreateNewQuote_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.passed = MPC.CreateNewQuote(ref this.passed); 
            this.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MPC.CloseApplication(MPC.RequestConfirmation("Are you sure you want to close the application?\nAny unsaved work will be lost.", "CONFIRMATION - Application Termination"));
        }

        private void managePumpsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.passed = MPC.ViewAllPumps(ref this.passed);
            this.Show();
        }

        private void createNewPumpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.passed = MPC.CreateNewPump(ref this.passed);
            this.Show();
        }

        private void viewAllPumpsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.managePumpsToolStripMenuItem.PerformClick();
        }

        private void addNewCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.passed = MPC.AddCustomer(ref this.passed);
            this.Show();
        }

        private void viewAllCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.passed = MPC.ViewCustomers(ref this.passed);
            this.Show();
        }

        private void manageCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.viewAllCustomersToolStripMenuItem.PerformClick();
        }

        private void addNewBusinessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.passed = MPC.AddBusiness(ref this.passed);
            this.Show();
        }

        private void viewAllBusinessesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.passed = MPC.ViewBusinesses(ref this.passed);
            this.Show();
        }

        private void manageBusinessesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.viewAllBusinessesToolStripMenuItem.PerformClick();
        }

        private void btnViewSelectedQuote_Click(object sender, EventArgs e)
        {
            if (dgvPreviousQuotes.SelectedCells.Count > 0)
            {
                int iGridSelection = Convert.ToInt32(dgvPreviousQuotes.SelectedCells[0].Value);

                Quote objQuoteSelection = this.passed.PassQuoteList.ElementAt(iGridSelection);

                Pass ChangeQuotePass = new Pass(passed.PassQuoteList, passed.PassBusinessList, passed.PassPumpList, passed.PassMandatoryPartList, passed.PassNonMandatoryPartList, ref objQuoteSelection, true);
                
                this.Hide();
                this.passed = MPC.CreateNewQuote(ref ChangeQuotePass);
                this.Show();

                this.passed.ChangeSpecificObject = false;
            }
            else
            {
                MPC.ShowError("The current selection is invalid.\nPlease choose a valid Quote from the list.","ERROR - Invalid Selection");
            }
        }

        private void btnCreateNewQuoteOnSelection_Click(object sender, EventArgs e)
        {
            if (dgvPreviousQuotes.SelectedCells.Count > 0)
            {
                int iGridSelection = Convert.ToInt32(dgvPreviousQuotes.SelectedCells[0].Value);

                Quote objQuoteSelection = this.passed.PassQuoteList.ElementAt(iGridSelection);

                Pass ChangeQuotePass = new Pass(passed.PassQuoteList, passed.PassBusinessList, passed.PassPumpList,passed.PassMandatoryPartList, passed.PassNonMandatoryPartList, ref objQuoteSelection, false);

                this.Hide();
                this.passed = MPC.CreateNewQuote(ref ChangeQuotePass);
                this.Show();
            }
            else
            {
                MPC.ShowError("The current selection is invalid.\nPlease choose a valid Quote from the list.", "ERROR - Invalid Selection");
            }
        }
    }
}
