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
    public partial class frmViewCustomers : Form
    {

        readonly MainProgramCode MPC = new MainProgramCode(); //Creating an instance of the class MainProgramCode containing specialised methods

        Pass passed;

        public ref Pass Passed { get => ref passed; }

        public frmViewCustomers(ref Pass passed)
        {
            InitializeComponent();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MPC.CloseApplication(MPC.RequestConfirmation("Are you sure you want to close the application?\nAny unsaved work will be lost.", "CONFIRMATION - Application Termination"));
        }

        private void btnUpdateSelectedCustomer_Click(object sender, EventArgs e)
        {

        }
    }
}
