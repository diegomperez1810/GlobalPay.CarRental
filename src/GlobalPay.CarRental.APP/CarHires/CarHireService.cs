namespace GlobalPay.CarRental.APP;

using GlobalPay.CarRental.DOM;
using GlobalPay.CarRental.DOM.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class CarHireService(ICarRentalRepository repository, ILogger<CarService> logger): BaseOperations<CarService>(logger), ICarHireService
{
    private readonly ICarRentalRepository _repository = repository;

    public OperationResult<IQueryable<CarHireResponse>> RecoverRents()
    {
        return ResolveOperation(() =>  _repository.GetNotTracking<CarHire>()
                                                  .Select(carh => CarHireResponse.CopyFrom(carh)));
    }

    public async Task<OperationResult<IEnumerable<CarHireResponse>>> RentAsync(IEnumerable<CarHireRequest> requests)
    {
        return await ResolveOperationAsync(async () => {

            var (cars, fees) = await GetCarsAndFeesByRequestsAsync(requests);
            
            if(cars.Any(car => !car.ThereIsStock()))
            {
                var carNoStock = string.Format(ValidationMessages.NO_STOCK,cars.First().Id);
                throw new ValidationException(ValidationCodeError.CODE_NO_STOCK, carNoStock);
            }

            var carHires = cars.Select(car => {
                var req = requests.First(req => req.CarId == car.Id);
                var fee = fees.First(fee => fee.CarType == car.CarType);

                return CarHire.RentCar(fee, car, req.ScheduledReturnDate);
            }).ToList();

            await _repository.AddRangeAsync(carHires);
            await _repository.SaveChangeAsync();

            return carHires.Select(carh => CarHireResponse.CopyFrom(carh));
        });
    }

    public async Task<OperationResult<CarHireResponse>> ReturnAsync(Guid guid, DateTime returnDate)
    {
        return await ResolveOperationAsync(async () => 
        {
            var carHire = await _repository.Get<CarHire>()
                                           .FirstAsync(carh => carh.Id == guid);
            carHire.ReturnCar(returnDate);

            await _repository.SaveChangeAsync();

            return CarHireResponse.CopyFrom(carHire);
        });
    }

    private async Task<(List<Car>, List<Fee>)> GetCarsAndFeesByRequestsAsync(IEnumerable<CarHireRequest> requests)
    {
        var carIds = requests.Select(req => req.CarId)
                             .Distinct();

        var cars = await _repository.Get<Car>()
                                    .Where(car => carIds.Contains(car.Id))
                                    .ToListAsync();

        var carTypes = cars.Select(car => car.CarType);
        var fees = await _repository.Get<Fee>()
                                    .Include(fee => fee.Periods)
                                    .Where(fee => carTypes.Contains(fee.CarType))
                                    .ToListAsync();
        return (cars, fees);    
    }
}
