using BudgetPlan.Application.Actions.BudgetPlanBaseActions.Commands.CreateBudgetPlanBase;
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
        throw new NotImplementedException();
    }
    
    [HttpGet]
    [Route("list")]
    public async Task<IActionResult> GetList()
    {
        var response = await Mediator.Send(new GetUserBudgetPlansListQuery());

        return Ok(response);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Create([FromForm]CreateBudgetPlanBaseDto createBudgetPlanBase)
    {
        var response = await Mediator.Send(new CreateBudgetPlanBaseCommand(createBudgetPlanBase.DateFrom, createBudgetPlanBase.DateTo, createBudgetPlanBase.BudgetPlanEntityId));
        
        return Ok(response);
    }
}