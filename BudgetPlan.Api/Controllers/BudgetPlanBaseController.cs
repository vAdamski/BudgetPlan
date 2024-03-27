using BudgetPlan.Application.Actions.BudgetPlanBaseActions.Commands.CreateBudgetPlanBase;
using BudgetPlan.Application.Actions.BudgetPlanBaseActions.Queries.GetBudgetPlanView;
using BudgetPlan.Application.Actions.BudgetPlanBaseActions.Queries.GetUserBudgetPlansList;
using BudgetPlan.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlan.Api.Controllers;

[Route("api/[controller]")]
public class BudgetPlanBaseController : BaseController
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
    public async Task<IActionResult> Create([FromForm]CreateBudgetPlanBaseDto createBudgetPlanBase)
    {
        return Ok(await Mediator.Send(new CreateBudgetPlanBaseCommand(createBudgetPlanBase.DateFrom, createBudgetPlanBase.DateTo, createBudgetPlanBase.BudgetPlanEntityId)));
    }
}