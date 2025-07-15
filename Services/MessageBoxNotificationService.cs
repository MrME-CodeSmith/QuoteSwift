using System.Windows.Forms;

namespace QuoteSwift
{
    public class MessageBoxNotificationService : INotificationService
    {
        public void ShowError(string text, string caption)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
