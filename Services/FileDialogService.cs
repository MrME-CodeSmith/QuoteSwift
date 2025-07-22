using System.Windows.Forms;

namespace QuoteSwift
{
    public class FileDialogService : IFileDialogService
    {
        public string ShowSaveFileDialog(string filter, string defaultExt, string fileName)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = filter;
                sfd.DefaultExt = defaultExt;
                sfd.FileName = fileName;
                return sfd.ShowDialog() == DialogResult.OK ? sfd.FileName : null;
            }
        }

        public string ShowOpenFileDialog(string filter, string defaultExt)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = filter;
                ofd.DefaultExt = defaultExt;
                return ofd.ShowDialog() == DialogResult.OK ? ofd.FileName : null;
            }
        }
    }
}
