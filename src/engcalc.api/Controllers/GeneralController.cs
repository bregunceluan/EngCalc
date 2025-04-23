using Microsoft.AspNetCore.Mvc;

namespace engcalc.api.Controllers;

[Route("api/")]
[ApiController]
public class GeneralController : ControllerBase
{
    [HttpGet("isAlive")]
    public IResult HealthCheck()
    {
        return Results.Ok("Opa, estou nas nuvens, se é que me entende.");
    }
}
