using BudgetPlan.Application.Actions.TransactionDetailsActions.Commands.AddTransactionDetail;
using BudgetPlan.Application.Actions.TransactionDetailsActions.Commands.DeleteTransactionDetail;
using BudgetPlan.Application.Actions.TransactionDetailsActions.Commands.UpdateTransactionDetail;
using BudgetPlan.Shared.Dtos;
using BudgetPlan.Shared.ViewModels;
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

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateTransactionDetail(Guid id, UpdateTransactionDetailsViewModel viewModel)
    {
        if (id != viewModel.Id)
            return BadRequest();
        
        var command = new UpdateTransactionDetailCommand(id, viewModel);
        await Mediator.Send(command);
        
        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteTransactionDetail(Guid id)
    {
        await Mediator.Send(new DeleteTransactionDetailCommand(id));

        return Ok();
    }
}