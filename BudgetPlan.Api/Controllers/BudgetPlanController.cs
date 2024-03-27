using BudgetPlan.Application.Actions.BudgetPlanActions.Commands.CreateBudgetPlan;
using BudgetPlan.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlan.Api.Controllers;

[Route("api/[controller]")]
public class BudgetPlanController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromForm]CreateBudgetPlanDto createBudgetPlan)
    {
        return Ok(await Mediator.Send(new CreateBudgetPlanCommand(createBudgetPlan.Name)));
    }
}