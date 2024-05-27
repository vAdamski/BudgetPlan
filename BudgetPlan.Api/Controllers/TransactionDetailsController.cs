using BudgetPlan.Application.Actions.TransactionDetailsActions.Commands.AddTransactionDetail;
using BudgetPlan.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlan.Api.Controllers;

[Route("api/transactionDetails")]
public class TransactionDetailsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> AddTransactionDetail([FromForm] AddTransactionDetailDto addTransactionDetailDto)
    {
        var response = await Mediator.Send(new AddTransactionDetailCommand(addTransactionDetailDto));
        
        return Ok(response);
    }
}