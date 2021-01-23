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
    public partial class frmViewParts : Form
    {
        readonly MainProgramCode MPC = new MainProgramCode(); //Creating an instance of the class MainProgramCode containing specialised methods

        Pass passed;

        public frmViewParts(ref Pass passed)
        {
            InitializeComponent();
            this.passed = passed;
        }

        public Pass Passed { get => passed; }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MPC.CloseApplication(MPC.RequestConfirmation("Are you sure you want to close the application?\nAny unsaved work will be lost.", "CONFIRMATION - Application Termination"));
        }

        private void btnAddPart_Click(object sender, EventArgs e)
        {
            frmAddPart NewPart = new frmAddPart(ref passed);
            this.Hide();
            NewPart.ShowDialog();
        }

        private void btnUpdateSelectedPart_Click(object sender, EventArgs e)
        {

        }
    }
}