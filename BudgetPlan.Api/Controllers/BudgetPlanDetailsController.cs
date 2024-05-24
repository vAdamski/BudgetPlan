using BudgetPlan.Application.Actions.BudgetPlanDetailsActions.Commands.UpdateBudgetPlanDetail;
using BudgetPlan.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlan.Api.Controllers;


[Route("api/budgetPlanDetails")]
public class BudgetPlanDetailsController : BaseController
{
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateBudgetPlanDetail(Guid id, UpdateBudgetPlanDetailDto dto)
    {
        if (id != dto.Id)
            return BadRequest();
        
        await Mediator.Send(new UpdateBudgetPlanDetailCommand(dto));

        return NoContent();
    }
}