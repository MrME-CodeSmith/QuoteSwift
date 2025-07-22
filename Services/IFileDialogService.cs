namespace QuoteSwift
{
    public interface IFileDialogService
    {
        string ShowSaveFileDialog(string filter, string defaultExt, string fileName);
        string ShowOpenFileDialog(string filter, string defaultExt);
    }
}
