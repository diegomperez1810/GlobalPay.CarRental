namespace GlobalPay.CarRental.APP;

using GlobalPay.CarRental.DOM;

public interface ICarHireService
{
    Task<OperationResult<IEnumerable<CarHireResponse>>> RentAsync(IEnumerable<CarHireRequest> requests);
    OperationResult<IQueryable<CarHireResponse>> RecoverRents();
    Task<OperationResult<CarHireResponse>> ReturnAsync(Guid guid, DateTime returnDate);
}
