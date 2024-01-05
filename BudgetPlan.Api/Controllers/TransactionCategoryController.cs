using BudgetPlan.Application.Actions.TransactionCategoriesActions.Commands.AddOverTransactionCategory;
using BudgetPlan.Application.Actions.TransactionCategoriesActions.Commands.AddTransactionCategory;
using BudgetPlan.Application.Actions.TransactionCategoriesActions.Commands.DeleteTransactionCategory;
using BudgetPlan.Application.Actions.TransactionCategoriesActions.Commands.DeleteTransactionCategoryWithMigrationAction;
using BudgetPlan.Application.Actions.TransactionCategoriesActions.Queries.GetListTransactionCategories;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlan.Api.Controllers;

[Route("api/[controller]")]
public class TransactionCategoryController : BaseController
{
    [HttpGet]
    [Route("list")]
    public async Task<IActionResult> GetListTransactionCategories()
    {
        var response = await Mediator.Send(new GetListTransactionCategoriesQuery());
        return Ok(response);
    }

    [HttpPost]
    [Route("createOverCategory")]
    public async Task<IActionResult> AddOverTransactionCategory(AddOverTransactionCategoryCommand command)
    {
        var response = await Mediator.Send(command);
        return Ok(response);
    }
    
    [HttpPost]
    [Route("createCategory")]
    public async Task<IActionResult> AddTransactionCategory(AddTransactionCategoryCommand command)
    {
        var response = await Mediator.Send(command);
        return Ok(response);
    }
    
    [HttpDelete]
    [Route("delete/utc/{id}")]
    public async Task<IActionResult> DeleteTransactionCategory(Guid id)
    {
        await Mediator.Send(new DeleteTransactionCategoryCommand(id));
        return NoContent();
    }
    
    [HttpDelete]
    [Route("delete/utc/{id}/{migrationId}")]
    public async Task<IActionResult> DeleteTransactionCategory(Guid id, Guid migrationId)
    {
        await Mediator.Send(new DeleteTransactionCategoryWithMigrationActionCommand(id, migrationId));
        return NoContent();
    }
}