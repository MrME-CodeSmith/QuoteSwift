using System.Windows.Forms;

namespace QuoteSwift
{
    public class WinFormsApplicationService : IApplicationService
    {
        public void Exit()
        {
            Application.Exit();
        }
    }
}
