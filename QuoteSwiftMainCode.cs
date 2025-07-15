using System;
using System.Linq;
using System.Windows.Forms;



namespace QuoteSwift
{ 


    public static class QuoteSwiftMainCode
    {
        

        // Set Components To Read Write:

        public static void ReadWriteComponents(Control.ControlCollection cc)
        {
            if (cc != null)
            {
                foreach (Panel pnl in cc.OfType<Panel>()) pnl.Enabled = true;
                foreach (GroupBox gbx in cc.OfType<GroupBox>()) gbx.Enabled = true;
                foreach (TextBox txt in cc.OfType<TextBox>()) txt.ReadOnly = false;
                foreach (MaskedTextBox mtxt in cc.OfType<MaskedTextBox>()) mtxt.ReadOnly = false;
                foreach (RichTextBox rtxt in cc.OfType<RichTextBox>()) rtxt.ReadOnly = false;
                foreach (ComboBox cb in cc.OfType<ComboBox>()) cb.Enabled = true;
                foreach (DateTimePicker dtp in cc.OfType<DateTimePicker>()) dtp.Enabled = true;
                foreach (NumericUpDown nud in cc.OfType<NumericUpDown>()) nud.ReadOnly = false;
                foreach (DataGridView dgv in cc.OfType<DataGridView>()) dgv.ReadOnly = false;
                foreach (Button btn in cc.OfType<Button>()) btn.Enabled = true;
                foreach (CheckBox cbx in cc.OfType<CheckBox>()) cbx.Enabled = true;
                foreach (QuoteSwift.Controls.NumericTextBox dtxt in cc.OfType<QuoteSwift.Controls.NumericTextBox>()) dtxt.Enabled = true;
            }
        }

        // Set Components To Read-Only:

        public static void ReadOnlyComponents(Control.ControlCollection cc)
        {
            if (cc != null)
            {
                foreach (Panel pnl in cc.OfType<Panel>()) pnl.Enabled = false;
                foreach (GroupBox gbx in cc.OfType<GroupBox>()) gbx.Enabled = false;
                foreach (TextBox txt in cc.OfType<TextBox>()) txt.ReadOnly = true;
                foreach (MaskedTextBox mtxt in cc.OfType<MaskedTextBox>()) mtxt.ReadOnly = true;
                foreach (RichTextBox rtxt in cc.OfType<RichTextBox>()) rtxt.ReadOnly = true;
                foreach (ComboBox cb in cc.OfType<ComboBox>()) cb.Enabled = false;
                foreach (DateTimePicker dtp in cc.OfType<DateTimePicker>()) dtp.Enabled = false;
                foreach (NumericUpDown nud in cc.OfType<NumericUpDown>()) nud.ReadOnly = true;
                foreach (DataGridView dgv in cc.OfType<DataGridView>()) dgv.ReadOnly = true;
                foreach (Button btn in cc.OfType<Button>()) btn.Enabled = false;
                foreach (CheckBox cbx in cc.OfType<CheckBox>()) cbx.Enabled = false;
                foreach (QuoteSwift.Controls.NumericTextBox dtxt in cc.OfType<QuoteSwift.Controls.NumericTextBox>()) dtxt.Enabled = false;
            }
        }




        /** Message Box Custom Functions */


        


        /*********************************/



        //Procedure Handling The Closing Of The Application
        // Removed - use MainProgramCode.CloseApplication instead.

        /** Parse String Inputs: */

        // Parse Float:

        public static float ParseFloat(string t)
        {
            float.TryParse(t, out float temp);
            return temp;
        }

        // Parse Decimal:

        public static decimal ParseDecimal(string t)
        {
            decimal.TryParse(t, out decimal temp);
            return temp;
        }

        // Parse Boole:

        public static bool ParseBoolean(string t)
        {
            bool.TryParse(t, out bool temp);
            return temp;
        }

        // Parse Int:

        public static int ParseInt(string t)
        {
            int.TryParse(t, out int temp);
            return temp;
        }


        /*************************/




    }
}
