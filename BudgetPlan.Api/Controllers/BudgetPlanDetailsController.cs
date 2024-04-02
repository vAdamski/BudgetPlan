using BudgetPlan.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlan.Api.Controllers;


[Route("api/[controller]")]
public class BudgetPlanDetailsController : BaseController
{
    [HttpPut]
    public async Task<IActionResult> UpdateBudgetPlanDetail(UpdateBudgetPlanDetailDto dto)
    {
        throw new NotImplementedException();
    }
}