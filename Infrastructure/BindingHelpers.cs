using System.Linq;
using System.Windows.Forms;

namespace QuoteSwift
{
    /// <summary>
    /// Utility methods simplifying common WinForms data bindings.
    /// </summary>
    static class BindingHelpers
    {
        public static void BindText(Control control, object source, string propertyName,
            DataSourceUpdateMode mode = DataSourceUpdateMode.OnPropertyChanged)
        {
            if (control == null || source == null || string.IsNullOrWhiteSpace(propertyName))
                return;
            ClearExisting(control, "Text");
            control.DataBindings.Add("Text", source, propertyName, false, mode);
        }

        public static void BindValue(Control control, object source, string propertyName,
            DataSourceUpdateMode mode = DataSourceUpdateMode.OnPropertyChanged)
        {
            if (control == null || source == null || string.IsNullOrWhiteSpace(propertyName))
                return;
            ClearExisting(control, "Value");
            control.DataBindings.Add("Value", source, propertyName, false, mode);
        }

        public static void BindDataGridView(DataGridView grid, object source, string listProperty,
            DataSourceUpdateMode mode = DataSourceUpdateMode.OnPropertyChanged)
        {
            if (grid == null || source == null || string.IsNullOrWhiteSpace(listProperty))
                return;
            ClearExisting(grid, "DataSource");
            grid.DataBindings.Add("DataSource", source, listProperty, false, mode);
        }

        public static void BindComboBox(ComboBox combo, object source, string itemsProperty,
            string selectedItemProperty, string displayMember = null, string valueMember = null,
            DataSourceUpdateMode mode = DataSourceUpdateMode.OnPropertyChanged)
        {
            if (combo == null || source == null)
                return;
            if (!string.IsNullOrWhiteSpace(itemsProperty))
            {
                ClearExisting(combo, "DataSource");
                combo.DataBindings.Add("DataSource", source, itemsProperty, false, mode);
            }
            if (!string.IsNullOrWhiteSpace(displayMember))
                combo.DisplayMember = displayMember;
            if (!string.IsNullOrWhiteSpace(valueMember))
                combo.ValueMember = valueMember;
            if (!string.IsNullOrWhiteSpace(selectedItemProperty))
            {
                ClearExisting(combo, "SelectedItem");
                combo.DataBindings.Add("SelectedItem", source, selectedItemProperty, false, mode);
            }
        }

        static void ClearExisting(Control control, string propertyName)
        {
            var toRemove = control.DataBindings.Cast<Binding>()
                .Where(b => b.PropertyName == propertyName)
                .ToList();
            foreach (var b in toRemove)
                control.DataBindings.Remove(b);
        }
    }
}
