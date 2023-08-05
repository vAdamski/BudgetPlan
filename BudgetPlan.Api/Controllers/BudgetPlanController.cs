using BudgetPlan.Application.BudgetPlan.Commands.CreateBudgetPlan;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlan.Api.Controllers;

[Route("api/[controller]")]
public class BudgetPlanController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateBudgetPlanCommand command)
    {
        return await Mediator.Send(command);
    }
}