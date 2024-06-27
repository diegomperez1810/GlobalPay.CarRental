namespace GlobalPay.CarRental.APP;

using GlobalPay.CarRental.DOM;
using GlobalPay.CarRental.DOM.Entities;
using Microsoft.Extensions.Logging;

public class CarService(ICarRentalRepository repository, ILogger<CarService> logger): BaseOperations<CarService>(logger), ICarService
{
    private readonly ICarRentalRepository _repository = repository;

    public OperationResult<IQueryable<CarResponse>> GetCars()
    {
        return ResolveOperation(() => {
          return _repository.GetNotTracking<Car>()
                            .Select(car => CarResponse.CopyFrom(car));
        });
    }
}
