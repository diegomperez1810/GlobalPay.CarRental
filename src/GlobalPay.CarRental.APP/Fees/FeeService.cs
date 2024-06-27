namespace GlobalPay.CarRental.APP;

using GlobalPay.CarRental.DOM;
using GlobalPay.CarRental.DOM.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class FeeService(ICarRentalRepository repository, ILogger<FeeService> logger) : BaseOperations<FeeService>(logger), IFeeService
{
    private readonly ICarRentalRepository _repository = repository;

    public OperationResult<IQueryable<FeeResponse>> GetFees()
    {
        return ResolveOperation(() => {
          return _repository.GetNotTracking<Fee>()
                            .Include(f => f.FeeSurcharge)
                            .Select(fee => FeeResponse.CopyFrom(fee));
        });
    }
}
