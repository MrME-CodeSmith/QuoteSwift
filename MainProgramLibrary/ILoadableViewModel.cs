namespace QuoteSwift
{
    /// <summary>
    /// Provides a contract for view models that require loading data
    /// asynchronously when initialized.
    /// </summary>
    public interface ILoadableViewModel
    {
        /// <summary>
        /// Asynchronously loads any data required by the view model.
        /// </summary>
        System.Threading.Tasks.Task LoadDataAsync();
    }
}
