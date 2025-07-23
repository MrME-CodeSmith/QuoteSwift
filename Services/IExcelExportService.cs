namespace QuoteSwift
{
    public interface IExcelExportService
    {
        System.Threading.Tasks.Task ExportQuoteToExcelAsync(Quote quote, System.Threading.CancellationToken token);
    }
}
