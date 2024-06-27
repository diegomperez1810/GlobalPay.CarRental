namespace GlobalPay.CarRental.INF.REST;

using GlobalPay.CarRental.DOM;
using Microsoft.AspNetCore.Mvc;

public class BaseApiController : ControllerBase
{
    public ActionResult<T> GetResponse<T>(OperationResult<T> operationResult)
    {
        if (operationResult.HasErrors)
            return BadRequest(operationResult.ValidationErrors);

        if (operationResult.HasExceptions)
            return StatusCode(500, operationResult.ExceptionErrors);

        if (operationResult is null || operationResult.Data is null)
            return NoContent();

        return Ok(operationResult.Data);
    }
}
