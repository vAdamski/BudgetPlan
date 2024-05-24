using BudgetPlan.Application.Actions.BudgetPlanActions.Commands.CreateBudgetPlan;
using BudgetPlan.Application.Actions.BudgetPlanActions.Queries.GetListOfBudgetPlans;
using BudgetPlan.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlan.Api.Controllers;

[Route("api/[controller]")]
public class BudgetPlanController : BaseController
{
    [HttpGet]
    [Route("getBudgetPlans")]
    public async Task<IActionResult> GetBudgetPlans()
    {
        var response = await Mediator.Send(new GetListOfBudgetPlansQuery());

        return Ok(response);
    }
    
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create([FromForm]CreateBudgetPlanDto createBudgetPlan)
    {
        var command = new CreateBudgetPlanCommand(createBudgetPlan.Name);
        var budgetPlanId = await Mediator.Send(command);

        return Ok(budgetPlanId);
    }
}