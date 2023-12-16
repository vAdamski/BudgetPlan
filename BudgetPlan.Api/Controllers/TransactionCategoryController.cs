using BudgetPlan.Application.Actions.TransactionCategoriesActions.Commands.AddOverTransactionCategory;
using BudgetPlan.Application.Actions.TransactionCategoriesActions.Commands.AddTransactionCategory;
using BudgetPlan.Application.Actions.TransactionCategoriesActions.Queries.GetListTransactionCategories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlan.Api.Controllers;

[Route("api/[controller]")]
public class TransactionCategoryController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetListTransactionCategories()
    {
        var response = await Mediator.Send(new GetListTransactionCategoriesQuery());
        return Ok(response);
    }

    [HttpPost]
    [Route("overCategory")]
    public async Task<IActionResult> AddOverTransactionCategory(AddOverTransactionCategoryCommand command)
    {
        var response = await Mediator.Send(command);
        return Ok(response);
    }
    
    [HttpPost]
    [Route("category")]
    public async Task<IActionResult> AddTransactionCategory(AddTransactionCategoryCommand command)
    {
        var response = await Mediator.Send(command);
        return Ok(response);
    }
}