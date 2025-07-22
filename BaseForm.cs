using System.Windows.Forms;

namespace QuoteSwift
{
    public abstract class BaseForm : Form
    {
        protected readonly IMessageService messageService;
        protected readonly INavigationService navigation;

        protected BaseForm(IMessageService messageService = null, INavigationService navigation = null)
        {
            this.messageService = messageService;
            this.navigation = navigation;
        }

        protected virtual void OnClose()
        {
            navigation?.SaveAllData();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            OnClose();
            base.OnFormClosing(e);
        }
    }
}
