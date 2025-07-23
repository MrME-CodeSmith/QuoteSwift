using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuoteSwift
{
    /// <summary>
    /// ICommand implementation supporting asynchronous Execute and CanExecute logic.
    /// </summary>
    public class AsyncRelayCommand : ICommand
    {
        readonly Func<object, CancellationToken, Task> execute;
        readonly Func<object, CancellationToken, Task<bool>> canExecute;
        CancellationTokenSource cancellationSource;
        bool isExecuting;

        public event EventHandler CanExecuteChanged;

        public AsyncRelayCommand(Func<Task> execute, Func<Task<bool>> canExecute = null)
            : this(execute != null ? new Func<object, CancellationToken, Task>((_, __) => execute()) : null,
                   canExecute != null ? new Func<object, CancellationToken, Task<bool>>((_, __) => canExecute()) : null)
        {
        }

        public AsyncRelayCommand(Func<CancellationToken, Task> execute, Func<CancellationToken, Task<bool>> canExecute = null)
            : this(execute != null ? new Func<object, CancellationToken, Task>((_, token) => execute(token)) : null,
                   canExecute != null ? new Func<object, CancellationToken, Task<bool>>((_, token) => canExecute(token)) : null)
        {
        }

        public AsyncRelayCommand(Func<object, Task> execute, Func<object, Task<bool>> canExecute = null)
            : this(execute != null ? new Func<object, CancellationToken, Task>((o, __) => execute(o)) : null,
                   canExecute != null ? new Func<object, CancellationToken, Task<bool>>((o, __) => canExecute(o)) : null)
        {
        }

        public AsyncRelayCommand(Func<object, CancellationToken, Task> execute, Func<object, CancellationToken, Task<bool>> canExecute = null)
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

            return canExecute(parameter, cancellationSource?.Token ?? CancellationToken.None)
                .GetAwaiter().GetResult();
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
                cancellationSource = new CancellationTokenSource();
                isExecuting = true;
                RaiseCanExecuteChanged();
                await execute(parameter, cancellationSource.Token).ConfigureAwait(false);
            }
            finally
            {
                isExecuting = false;
                RaiseCanExecuteChanged();
            }
        }

        public void Cancel()
        {
            if (cancellationSource != null && !cancellationSource.IsCancellationRequested)
                cancellationSource.Cancel();
        }

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
