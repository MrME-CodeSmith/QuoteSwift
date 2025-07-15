using System;
using System.Windows.Input;

namespace QuoteSwift
{
    /// <summary>
    /// Simple ICommand implementation for WinForms to delegate command logic.
    /// </summary>
    public class RelayCommand : ICommand
    {
        readonly Action<object> execute;
        readonly Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
            : this(execute != null ? new Action<object>(_ => execute()) : null,
                   canExecute != null ? new Func<object, bool>(_ => canExecute()) : null)
        {
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => canExecute?.Invoke(parameter) ?? true;

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
                execute(parameter);
        }

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
