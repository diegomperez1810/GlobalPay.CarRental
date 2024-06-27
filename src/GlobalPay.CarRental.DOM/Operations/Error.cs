namespace GlobalPay.CarRental.DOM;

public class Error(string message, string code, Exception? exception = null)
{
    public Exception? Exception { get; set; } = exception;
    public string Code { get; set; } = code;
    public string Message { get; set; } = message;
}
