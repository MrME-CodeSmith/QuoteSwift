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
    public partial class FrmAddBusiness : Form
    { 

        Pass passed;

        public FrmAddBusiness(ref Pass passed)
        {
            InitializeComponent();
            this.passed = passed;
        }

        public ref Pass Passed { get => ref passed; }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void TxtBusinessName_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnAddBusiness_Click(object sender, EventArgs e)
        {

        }
    }
}
