namespace GlobalPay.CarRental.APP;

using GlobalPay.CarRental.DOM;
using Microsoft.Extensions.Logging;

public abstract class BaseOperations<R>(ILogger<R> logger)
{
    private readonly ILogger<R> _logger = logger;

    protected async Task<OperationResult<T>> ResolveOperationAsync<T>(Func<Task<T>> funct)
    {
        try
        {
            var result = await funct();

            return new OperationResult<T>(data: result);
        }
        catch(ValidationException ex)
        {
            var error = new Error(ex.MESSAGE, ex.CODE);
            return new OperationResult<T>(error: new List<Error> { error });
        }
        catch (Exception ex)
        {
            _logger.LogError("Error: {exception}", ex);
            var error = new Error(ValidationMessages.INFR, ValidationCodeError.CODE_INFRA, ex);
            return new OperationResult<T>(new List<Error> { error });
        }
    }

    protected OperationResult<T> ResolveOperation<T>(Func<T> funct)
    {
        try
        {
            var result = funct();

            return new OperationResult<T>(data: result);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error: {exception}", ex);
            var error = new Error(ValidationMessages.INFR, ValidationCodeError.CODE_INFRA, ex);
            return new OperationResult<T>(new List<Error> { error });
        }
    }
}
