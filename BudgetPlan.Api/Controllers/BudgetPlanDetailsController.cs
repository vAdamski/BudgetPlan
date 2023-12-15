using BudgetPlan.Application.BudgetPlanDetailsActions.Commands.UpdateBudgetPlanDetail;
using BudgetPlan.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlan.Api.Controllers;


[Route("api/[controller]")]
public class BudgetPlanDetailsController : BaseController
{
    [HttpPut]
    public async Task<IActionResult> UpdateBudgetPlanDetail(UpdateBudgetPlanDetailDto dto)
    {
        await Mediator.Send(new UpdateBudgetPlanDetailCommand(dto));
        return NoContent();
    }
}