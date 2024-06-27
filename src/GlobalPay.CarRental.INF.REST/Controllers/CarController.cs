namespace GlobalPay.CarRental.INF.REST;

using GlobalPay.CarRental.APP;
using GlobalPay.CarRental.DOM;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/cars")]
public class CarController(ICarService carService): BaseApiController
{
    private readonly ICarService _carService = carService;

    [HttpGet()]
    public ActionResult<IQueryable<CarResponse>> Get()
    {
        return GetResponse(_carService.GetCars());
    }
}
