using BudgetPlan.Application.BudgetPlan.Commands.CreateBudgetPlan;
using BudgetPlan.Application.BudgetPlan.Queries.GetBudgetPlanView;
using BudgetPlan.Shared.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlan.Api.Controllers;

[Route("api/[controller]")]
public class BudgetPlanController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetViewModel(int id)
    {
        return Ok(await Mediator.Send(new GetBudgetPlanViewCommand {BudgetPlanId = id}));
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateBudgetPlanCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
}