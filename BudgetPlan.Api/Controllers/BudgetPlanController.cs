using BudgetPlan.Application.BudgetPlan.Commands.CreateBudgetPlan;
using BudgetPlan.Application.BudgetPlan.Queries.GetBudgetPlanView;
using BudgetPlan.Application.BudgetPlan.Queries.GetUserBudgetPlansList;
using BudgetPlan.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlan.Api.Controllers;

[Route("api/[controller]")]
public class BudgetPlanController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetViewModel(Guid id)
    {
        return Ok(await Mediator.Send(new GetBudgetPlanViewCommand {BudgetPlanId = id}));
    }
    
    [HttpGet]
    [Route("list")]
    public async Task<IActionResult> GetList()
    {
        return Ok(await Mediator.Send(new GetUserBudgetPlansListQuery()));
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Create([FromForm]CreateBudgetPlanDto createBudgetPlan)
    {
        return Ok(await Mediator.Send(new CreateBudgetPlanCommand(new DateTime(createBudgetPlan.Year, createBudgetPlan.Month, 1))));
    }
}