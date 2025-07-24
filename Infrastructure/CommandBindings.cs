using System.Windows.Forms;
using System.Windows.Input;

namespace QuoteSwift
{
    static class CommandBindings
    {
        public static void Bind(Button button, ICommand command)
        {
            if (button == null || command == null)
                return;
            button.Enabled = command.CanExecute(null);
            command.CanExecuteChanged += (s, e) => button.Enabled = command.CanExecute(null);
            button.Click += (s, e) =>
            {
                if (command.CanExecute(null))
                    command.Execute(null);
            };
        }

        public static void Bind(Button button, ICommand command, Func<object> parameterProvider)
        {
            if (button == null || command == null)
                return;

            object GetParam() => parameterProvider?.Invoke();

            button.Enabled = command.CanExecute(GetParam());
            command.CanExecuteChanged += (s, e) => button.Enabled = command.CanExecute(GetParam());
            button.Click += (s, e) =>
            {
                var param = GetParam();
                if (command.CanExecute(param))
                    command.Execute(param);
            };
        }

        public static void Bind(ToolStripMenuItem item, ICommand command)
        {
            if (item == null || command == null)
                return;
            item.Enabled = command.CanExecute(null);
            command.CanExecuteChanged += (s, e) => item.Enabled = command.CanExecute(null);
            item.Click += (s, e) =>
            {
                if (command.CanExecute(null))
                    command.Execute(null);
            };
        }

        public static void Bind(DateTimePicker picker, ICommand command)
        {
            if (picker == null || command == null)
                return;

            // Evaluate CanExecute using the picker's current value
            picker.Enabled = command.CanExecute(picker.Value);
            command.CanExecuteChanged += (s, e) => picker.Enabled = command.CanExecute(picker.Value);

            picker.ValueChanged += (s, e) =>
            {
                var value = picker.Value;
                if (command.CanExecute(value))
                    command.Execute(value);
            };
        }
    }
}
