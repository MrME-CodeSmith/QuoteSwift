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
    }
}
