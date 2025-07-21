using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuoteSwift
{
    /// <summary>
    /// ICommand implementation supporting asynchronous Execute and CanExecute logic.
    /// </summary>
    public class AsyncRelayCommand : ICommand
    {
        readonly Func<object, Task> execute;
        readonly Func<object, Task<bool>> canExecute;
        bool isExecuting;

        public event EventHandler CanExecuteChanged;

        public AsyncRelayCommand(Func<Task> execute, Func<Task<bool>> canExecute = null)
            : this(execute != null ? new Func<object, Task>(_ => execute()) : null,
                   canExecute != null ? new Func<object, Task<bool>>(_ => canExecute()) : null)
        {
        }

        public AsyncRelayCommand(Func<object, Task> execute, Func<object, Task<bool>> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (isExecuting)
                return false;

            if (canExecute == null)
                return true;

            return canExecute(parameter).GetAwaiter().GetResult();
        }

        public async void Execute(object parameter)
        {
            await ExecuteAsync(parameter).ConfigureAwait(false);
        }

        public async Task ExecuteAsync(object parameter)
        {
            if (!CanExecute(parameter))
                return;

            try
            {
                isExecuting = true;
                RaiseCanExecuteChanged();
                await execute(parameter).ConfigureAwait(false);
            }
            finally
            {
                isExecuting = false;
                RaiseCanExecuteChanged();
            }
        }

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
