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
    public partial class frmAddBusiness : Form
    {

        readonly MainProgramCode MPC = new MainProgramCode(); //Creating an instance of the class MainProgramCode containing specialised methods

        Pass passed;

        public frmAddBusiness(ref Pass passed)
        {
            InitializeComponent();
            this.passed = passed;
        }

        public ref Pass Passed { get => ref passed; }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txtBusinessName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddBusiness_Click(object sender, EventArgs e)
        {

        }
    }
}
