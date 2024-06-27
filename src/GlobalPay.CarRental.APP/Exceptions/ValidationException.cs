namespace GlobalPay.CarRental.APP;

public class ValidationException: Exception
{
	public string CODE { get; private set; }
	public string MESSAGE { get; private set; }

	public ValidationException(string code, string message): base($"{code}-{message}")
	{
		CODE = code;
		MESSAGE = message;
	}
}
