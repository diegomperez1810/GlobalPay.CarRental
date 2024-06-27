using GlobalPay.CarRental.DOM;

namespace GlobalPay.CarRental.APP;

public interface IFeeService
{
    OperationResult<IQueryable<FeeResponse>> GetFees();
}
