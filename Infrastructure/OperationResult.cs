namespace QuoteSwift
{
    public class OperationResult
    {
        public bool Success { get; }
        public string Message { get; }
        public string Caption { get; }

        public OperationResult(bool success, string message = null, string caption = null)
        {
            Success = success;
            Message = message;
            Caption = caption;
        }

        public static OperationResult Successful() => new OperationResult(true);
        public static OperationResult Failure(string message, string caption) => new OperationResult(false, message, caption);
    }
}
