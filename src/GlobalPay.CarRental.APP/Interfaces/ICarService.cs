using GlobalPay.CarRental.DOM;

namespace GlobalPay.CarRental.APP;

public interface ICarService
{
    OperationResult<IQueryable<CarResponse>> GetCars();
}
