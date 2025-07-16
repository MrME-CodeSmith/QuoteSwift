using System.Linq;
using System.Windows.Forms;

namespace QuoteSwift
{
    static class ControlStateHelper
    {
        public static void ApplyReadOnly(Control.ControlCollection controls, bool readOnly)
        {
            if (controls == null) return;

            foreach (Panel pnl in controls.OfType<Panel>()) pnl.Enabled = !readOnly;
            foreach (GroupBox gbx in controls.OfType<GroupBox>()) gbx.Enabled = !readOnly;
            foreach (TextBox txt in controls.OfType<TextBox>()) txt.ReadOnly = readOnly;
            foreach (MaskedTextBox mtxt in controls.OfType<MaskedTextBox>()) mtxt.ReadOnly = readOnly;
            foreach (RichTextBox rtxt in controls.OfType<RichTextBox>()) rtxt.ReadOnly = readOnly;
            foreach (ComboBox cb in controls.OfType<ComboBox>()) cb.Enabled = !readOnly;
            foreach (DateTimePicker dtp in controls.OfType<DateTimePicker>()) dtp.Enabled = !readOnly;
            foreach (NumericUpDown nud in controls.OfType<NumericUpDown>()) nud.ReadOnly = readOnly;
            foreach (DataGridView dgv in controls.OfType<DataGridView>()) dgv.ReadOnly = readOnly;
            foreach (Button btn in controls.OfType<Button>()) btn.Enabled = !readOnly;
            foreach (CheckBox cbx in controls.OfType<CheckBox>()) cbx.Enabled = !readOnly;
            foreach (QuoteSwift.Controls.NumericTextBox ntxt in controls.OfType<QuoteSwift.Controls.NumericTextBox>()) ntxt.Enabled = !readOnly;
        }
    }
}
