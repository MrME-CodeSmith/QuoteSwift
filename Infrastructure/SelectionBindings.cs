using System;
using System.Reflection;
using System.Windows.Forms;

namespace QuoteSwift
{
    /// <summary>
    /// Helper methods for binding DataGridView selection to view model properties.
    /// </summary>
    static class SelectionBindings
    {
        public static void BindSelectedItem(DataGridView grid, object viewModel, string propertyName)
        {
            if (grid == null || viewModel == null || string.IsNullOrWhiteSpace(propertyName))
                return;

            var prop = viewModel.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
            if (prop == null || !prop.CanWrite)
                return;

            grid.SelectionChanged += (s, e) =>
            {
                var value = grid.CurrentRow?.DataBoundItem;
                prop.SetValue(viewModel, value);
            };
        }
    }
}
