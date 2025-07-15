namespace QuoteSwift
{
    public interface IMessageService
    {
        bool RequestConfirmation(string text, string caption);
        void ShowError(string text, string caption);
        void ShowInformation(string text, string caption);
    }
}
