using System;
using System.Threading.Tasks;

namespace QuoteSwift
{
    /// <summary>
    /// Base class for all view models providing notification helpers and
    /// convenience helpers for common commands.
    /// </summary>
    public class ViewModelBase : ObservableObject
    {
        bool isBusy;

        /// <summary>
        /// Indicates whether the view model is performing a background
        /// operation.
        /// </summary>
        public bool IsBusy
        {
            get => isBusy;
            protected set => SetProperty(ref isBusy, value);
        }
        /// <summary>
        /// Creates an <see cref="AsyncRelayCommand"/> for the supplied asynchronous
        /// load action.
        /// </summary>
        /// <param name="loadAction">The asynchronous load action.</param>
        /// <returns>An initialized <see cref="AsyncRelayCommand"/>.</returns>
        protected AsyncRelayCommand CreateLoadCommand(Func<Task> loadAction)
        {
            return new AsyncRelayCommand(async () =>
            {
                IsBusy = true;
                try
                {
                    await loadAction();
                }
                finally
                {
                    IsBusy = false;
                }
            });
        }

        /// <summary>
        /// Creates a <see cref="RelayCommand"/> that first displays a confirmation
        /// dialog via the provided <see cref="IMessageService"/> and executes the
        /// supplied action when confirmed.
        /// </summary>
        /// <param name="executeAction">Action to execute if the user confirms.</param>
        /// <param name="messageService">Service used to show the confirmation.</param>
        /// <param name="message">Confirmation message text.</param>
        /// <param name="caption">Confirmation dialog caption.</param>
        /// <returns>An initialized <see cref="RelayCommand"/>.</returns>
        protected RelayCommand CreateConfirmationCommand(
            Action executeAction,
            IMessageService messageService,
            string message,
            string caption)
        {
            if (executeAction == null)
                throw new ArgumentNullException(nameof(executeAction));

            return new RelayCommand(_ =>
            {
                if (messageService?.RequestConfirmation(message, caption) == true)
                    executeAction();
            });
        }

        /// <summary>
        /// Creates a <see cref="RelayCommand"/> prompting for cancellation
        /// confirmation.
        /// </summary>
        /// <param name="cancelAction">Action to execute when confirmed.</param>
        /// <param name="messageService">Service used to show the confirmation.</param>
        /// <param name="message">Optional confirmation message.</param>
        /// <param name="caption">Optional confirmation caption.</param>
        /// <returns>An initialized <see cref="RelayCommand"/>.</returns>
        protected RelayCommand CreateCancelCommand(
            Action cancelAction,
            IMessageService messageService,
            string message = "Are you sure you want to cancel the current action?\nCancellation can cause any changes to be lost.",
            string caption = "REQUEST - Cancellation")
        {
            return CreateConfirmationCommand(cancelAction, messageService, message, caption);
        }

        /// <summary>
        /// Creates a <see cref="RelayCommand"/> prompting for application exit
        /// confirmation.
        /// </summary>
        /// <param name="exitAction">Action to execute when confirmed.</param>
        /// <param name="messageService">Service used to show the confirmation.</param>
        /// <param name="message">Optional confirmation message.</param>
        /// <param name="caption">Optional confirmation caption.</param>
        /// <returns>An initialized <see cref="RelayCommand"/>.</returns>
        protected RelayCommand CreateExitCommand(
            Action exitAction,
            IMessageService messageService,
            string message = "Are you sure you want to close the application?",
            string caption = "REQUEST - Application Termination")
        {
            return CreateConfirmationCommand(exitAction, messageService, message, caption);
        }
    }
}
