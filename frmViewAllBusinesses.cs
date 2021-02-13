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
    public partial class FrmViewAllBusinesses : Form
    {


        Pass passed;

        public ref Pass Passed { get => ref passed; }

        public FrmViewAllBusinesses(ref Pass passed)
        {
            InitializeComponent();
            this.Passed = passed;
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainProgramCode.CloseApplication(MainProgramCode.RequestConfirmation("Are you sure you want to close the application?\nAny unsaved work will be lost.", "REQUEST - Application Termination"), ref this.passed);
        }

        private void BtnUpdateBusiness_Click(object sender, EventArgs e)
        {

        }

        private void BtnAddBusiness_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainProgramCode.AddBusiness(ref passed);
            this.Show();
        }

        private void FrmViewAllBusinesses_Load(object sender, EventArgs e)
        {
            if (passed.PassBusinessList != null)
            {
                for (int i = 0; i < passed.PassBusinessList.Count; i++)
                    DgvBusinessList.Rows.Add(passed.PassBusinessList[i].BusinessName);
            }
        }

        private void BtnRemoveSelected_Click(object sender, EventArgs e)
        {
            Business business = GetBusinessSelection();

            if (business != null && passed.PassBusinessList != null)
            {
                if (MainProgramCode.RequestConfirmation("Are you sure you want to permanently delete '" + business.BusinessName + "' from the business list?", "REQUEST - Deletion Request"))
                {
                    passed.PassBusinessList.Remove(business);
                    MainProgramCode.ShowInformation("Successfully deleted '" + business.BusinessName + "' from the business list", "CONFIRMATION - Deletion Success");

                    if (passed.PassBusinessList.Count == 0) passed.PassBusinessList = null;

                    LoadInformation();
                }
            }
        }

        /** Form Specific Functions And Procedures: 
        *
        * Note: Not all Functions or Procedures below are used more than once
        *       Some of them are only to keep the above events readable 
        *       and clutter free.                                                          
        */

        private Business GetBusinessSelection()
        {
            Business business;
            string SearchName;
            int iGridSelection = DgvBusinessList.CurrentCell.RowIndex;
            try
            {
                SearchName = DgvBusinessList.Rows[iGridSelection].Cells[0].Value.ToString();
            }
            catch
            {
                return null;
            }

            if (passed.BusinessToChange != null && passed.BusinessToChange.BusinessAddressList != null)
            {
                business = passed.PassBusinessList.SingleOrDefault(p => p.BusinessName == SearchName);
                return business;
            }

            return null;
        }

        private void LoadInformation()
        {
            DgvBusinessList.Rows.Clear();

            if(passed.PassBusinessList != null)
                for(int i = 0; i < passed.PassBusinessList.Count; i++)
                {
                    DgvBusinessList.Rows.Add(passed.PassBusinessList[i].BusinessName);
                }
        }

        /**********************************************************************************/
    }
}
