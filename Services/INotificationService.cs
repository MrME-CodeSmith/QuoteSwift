namespace QuoteSwift
{
    public interface INotificationService
    {
        void ShowError(string text, string caption);
        void ShowInformation(string text, string caption);
    }
}
