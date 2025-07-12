using System;
using System.Windows.Forms;

namespace QuoteSwift.Controls
{
    /// <summary>
    /// Simple textbox that only accepts decimal numeric input.
    /// </summary>
    public class NumericTextBox : TextBox
    {
        private decimal minValue = 0m;
        private decimal maxValue = decimal.MaxValue;
        private decimal currentValue = 0m;

        public decimal MinValue
        {
            get => minValue;
            set { minValue = value; ValidateValue(); }
        }

        public decimal MaxValue
        {
            get => maxValue;
            set { maxValue = value; ValidateValue(); }
        }

        public decimal Value
        {
            get
            {
                if (decimal.TryParse(Text, out var v))
                {
                    currentValue = Clamp(v);
                }
                return currentValue;
            }
            set
            {
                currentValue = Clamp(value);
                Text = currentValue.ToString("0.##");
            }
        }

        private decimal Clamp(decimal v)
        {
            if (v < MinValue) v = MinValue;
            if (v > MaxValue) v = MaxValue;
            return v;
        }

        private void ValidateValue()
        {
            Value = Value;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            char ch = e.KeyChar;
            if (!char.IsControl(ch) && !char.IsDigit(ch) && ch != '.' && ch != '-')
            {
                e.Handled = true;
            }
            if (ch == '.' && Text.Contains("."))
            {
                e.Handled = true;
            }
            if (ch == '-' && (SelectionStart != 0 || Text.Contains("-")))
            {
                e.Handled = true;
            }
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            Value = Value; // clamp and format
        }
    }
}
