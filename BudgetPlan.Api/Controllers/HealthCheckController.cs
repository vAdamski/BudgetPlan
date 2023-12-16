using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlan.Api.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
public class HealthCheckController : BaseController
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Healthy");
    }
}