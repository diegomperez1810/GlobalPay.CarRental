namespace GlobalPay.CarRental.INF.REST;

using GlobalPay.CarRental.APP;
using GlobalPay.CarRental.DOM;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/fees")]
public class FeeController(IFeeService feeService): BaseApiController
{
    private readonly IFeeService _feeService = feeService;
    
    [HttpGet()]
    public ActionResult<IQueryable<FeeResponse>> Get()
    {
        return GetResponse(_feeService.GetFees());
    }

}
