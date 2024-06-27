namespace GlobalPay.CarRental.DOM;

public class OperationResult<TData>(IEnumerable<Error>? error = default, TData? data = default)
{
    public TData? Data { get; private set; } = data;
    public IEnumerable<Error> Errors { get; private set; } = error ?? new HashSet<Error>();

    public IEnumerable<Error> ValidationErrors
    {
        get
        {
            return Errors.Where(err => err.Exception == null);
        }
    }

    public IEnumerable<Error> ExceptionErrors
    {
        get
        {
            return Errors.Where(err => err.Exception != null);
        }
    }

    public bool HasErrors => ValidationErrors.Any();
    public bool HasExceptions => ExceptionErrors.Any();

    public OperationResult<TData> AddResult(TData data)
    {
        Data = data;
        return this;
    }

    public OperationResult<TData> AddErrors(IEnumerable<Error> errors)
    {
        foreach(var error in errors) 
        {
            Errors = Errors.Append(error);
        }

        return this;
    }
}

public struct Void { }
