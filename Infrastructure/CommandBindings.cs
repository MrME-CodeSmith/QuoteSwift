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
    }
}
