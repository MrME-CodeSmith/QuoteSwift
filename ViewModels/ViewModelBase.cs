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
        /// <summary>
        /// Creates an <see cref="AsyncRelayCommand"/> for the supplied asynchronous
        /// load action.
        /// </summary>
        /// <param name="loadAction">The asynchronous load action.</param>
        /// <returns>An initialized <see cref="AsyncRelayCommand"/>.</returns>
        protected AsyncRelayCommand CreateLoadCommand(Func<Task> loadAction)
        {
            return new AsyncRelayCommand(loadAction);
        }
    }
}
