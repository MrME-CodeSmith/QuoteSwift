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
    public partial class FrmAddCustomer : Form
    {

         

        Pass passed;

        public ref Pass Passed { get => ref passed; }

        public FrmAddCustomer(ref Pass passed)
        {
            InitializeComponent();
            this.Passed = passed;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainProgramCode.CloseApplication(MainProgramCode.RequestConfirmation("Are you sure you want to close the application?\nAny unsaved work will be lost.", "REQUEST - Application Termination"), ref this.passed);
        }

        private void BtnAddCustomer_Click(object sender, EventArgs e)
        {

        }
    }
}
