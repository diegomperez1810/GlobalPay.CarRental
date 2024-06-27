namespace GlobalPay.CarRental.INF.REST;

using GlobalPay.CarRental.APP;
using GlobalPay.CarRental.DOM;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/carhire")]
public class CarHireController(ICarHireService carHireService): BaseApiController
{
    private readonly ICarHireService _carHireService = carHireService;


    [HttpGet()]
    public ActionResult<IQueryable<CarHireResponse>> Get()
    {
        return GetResponse(_carHireService.RecoverRents());
    }

    [HttpPost("rent")]
    public async Task<ActionResult<IEnumerable<CarHireResponse>>> Rent([FromBody] IEnumerable<CarHireRequest> requests)
    {
        var response = await _carHireService.RentAsync(requests);
        return GetResponse(response);
    }

    [HttpPost("return")]
    public async Task<ActionResult<CarHireResponse>> Return(Guid carId, DateTime returnDate)
    {
        var response = await _carHireService.ReturnAsync(carId, returnDate);
        return GetResponse(response);
    }
}