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
    public partial class FrmViewQuotes : Form
    {

        

        Pass passed;

        public ref Pass Passed { get => ref passed; }

        public FrmViewQuotes(ref Pass passed)
        {
            InitializeComponent();
            this.passed = passed;
            if (this.passed == null) passed = new Pass(new BindingList<Quote>(), new BindingList<Business>(), new BindingList<Pump>(), new BindingList<Part>(), new BindingList<Part>());
            
        }

        private void BtnCreateNewQuote_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.passed = MainProgramCode.CreateNewQuote(ref this.passed);
            try
            {
                this.Show();
            }
            catch (Exception)
            {
                // Do Nothing - Since this only happens when Application.Exit() is called.
            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManagePumpsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.passed = MainProgramCode.ViewAllPumps(ref this.passed);
            try
            {
                this.Show();
            }
            catch (Exception)
            {
                // Do Nothing - Since this only happens when Application.Exit() is called.
            }
        }

        private void CreateNewPumpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.passed = MainProgramCode.CreateNewPump(ref this.passed);
            try
            {
                this.Show();
            }
            catch (Exception)
            {
                // Do Nothing - Since this only happens when Application.Exit() is called.
            }
        }

        private void ViewAllPumpsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.managePumpsToolStripMenuItem.PerformClick();
        }

        private void AddNewCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.passed = MainProgramCode.AddCustomer(ref this.passed);
            try
            {
                this.Show();
            }
            catch (Exception)
            {
                // Do Nothing - Since this only happens when Application.Exit() is called.
            }
        }

        private void ViewAllCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.passed = MainProgramCode.ViewCustomers(ref this.passed);
            try
            {
                this.Show();
            }
            catch (Exception)
            {
                // Do Nothing - Since this only happens when Application.Exit() is called.
            }
        }

        private void ManageCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.viewAllCustomersToolStripMenuItem.PerformClick();
        }

        private void AddNewBusinessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.passed = MainProgramCode.AddBusiness(ref this.passed);
            try
            {
                this.Show();
            }
            catch (Exception)
            {
                // Do Nothing - Since this only happens when Application.Exit() is called.
            }
        }

        private void ViewAllBusinessesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.passed = MainProgramCode.ViewBusinesses(ref this.passed);
            try
            {
                this.Show();
            }
            catch (Exception)
            {
                // Do Nothing - Since this only happens when Application.Exit() is called.
            }
        }

        private void ManageBusinessesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ViewAllBusinessesToolStripMenuItem.PerformClick();
        }

        private void BtnViewSelectedQuote_Click(object sender, EventArgs e)
        {
            int iGridSelection;
            if (dgvPreviousQuotes.SelectedCells.Count > 0)
            {
                iGridSelection = Convert.ToInt32(dgvPreviousQuotes.SelectedCells[0].Value);

                Quote objQuoteSelection = this.passed.PassQuoteList.ElementAt(iGridSelection);

                Pass ChangeQuotePass = new Pass(passed.PassQuoteList, passed.PassBusinessList, passed.PassPumpList, passed.PassMandatoryPartList, passed.PassNonMandatoryPartList, ref objQuoteSelection, true);
                
                this.Hide();
                this.passed = MainProgramCode.CreateNewQuote(ref ChangeQuotePass);
                try
                {
                    this.Show();
                }
                catch (Exception)
                {
                    // Do Nothing - Since this only happens when Application.Exit() is called.
                }

                this.passed.ChangeSpecificObject = false;
            }
            else
            {
                MainProgramCode.ShowError("The current selection is invalid.\nPlease choose a valid Quote from the list.","ERROR - Invalid Selection");
            }
        }

        private void BtnCreateNewQuoteOnSelection_Click(object sender, EventArgs e)
        {
            if (dgvPreviousQuotes.SelectedCells.Count > 0)
            {
                int iGridSelection = Convert.ToInt32(dgvPreviousQuotes.SelectedCells[0].Value);

                Quote objQuoteSelection = this.passed.PassQuoteList.ElementAt(iGridSelection);

                Pass ChangeQuotePass = new Pass(passed.PassQuoteList, passed.PassBusinessList, passed.PassPumpList,passed.PassMandatoryPartList, passed.PassNonMandatoryPartList, ref objQuoteSelection, false);

                this.Hide();
                this.passed = MainProgramCode.CreateNewQuote(ref ChangeQuotePass);
                try
                {
                    this.Show();
                }
                catch (Exception)
                {
                    // Do Nothing - Since this only happens when Application.Exit() is called.
                }
            }
            else
            {
                MainProgramCode.ShowError("The current selection is invalid.\nPlease choose a valid Quote from the list.", "ERROR - Invalid Selection");
            }
        }

        private void ViewAllPartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.passed = MainProgramCode.ViewAllParts(ref this.passed);
            try
            {
                this.Show();
            }
            catch(Exception)
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
            this.Hide();
            this.passed = MainProgramCode.AddNewPart(ref this.passed);
            try
            {
                this.Show();
            }
            catch (Exception)
            {
                // Do Nothing - Since this only happens when Application.Exit() is called.
            }
        }

        private void FrmViewQuotes_Load(object sender, EventArgs e)
        {  
            if (passed != null)
            {
                try
                {
                    byte[] RetreivedMandatoryPartList = MainProgramCode.RetreiveData("MandatoryParts.pbf");

                    this.passed.PassMandatoryPartList = new BindingList<Part>(MainProgramCode.DeserializePartList(RetreivedMandatoryPartList));

                    RetreivedMandatoryPartList = MainProgramCode.RetreiveData("NonMandatoryParts.pbf");

                    this.passed.PassNonMandatoryPartList = new BindingList<Part>(MainProgramCode.DeserializePartList(RetreivedMandatoryPartList));
                    
                    byte[] RetreivePumpList = MainProgramCode.RetreiveData("PumpList.pbf");

                    this.passed.PassPumpList = new BindingList<Pump>(MainProgramCode.DeserializePumpList(RetreivePumpList));
                }
                catch
                {
                    return;
                }
            }
        }

        int count = 0;
        private void FrmViewQuotes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (count == 0)
            {
                count++;
                MainProgramCode.CloseApplication(MainProgramCode.RequestConfirmation("Are you sure you want to close the application?\nAny unsaved work will be lost.", "REQUEST - Application Termination"), ref this.passed);
            }
        }
    }
}
