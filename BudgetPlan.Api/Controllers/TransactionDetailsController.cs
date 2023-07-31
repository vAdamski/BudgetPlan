using BudgetPlan.Application.TransactionDetails.Commands.AddTransactionDetail;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlan.Api.Controllers;

[Route("api/[controller]")]
public class TransactionDetailsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> AddTransactionDetail(AddTransactionDetailCommand command)
    {
        var response = await Mediator.Send(command);
        
        return Ok(response);
    }
}