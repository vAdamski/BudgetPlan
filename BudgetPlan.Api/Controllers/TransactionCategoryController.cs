using BudgetPlan.Application.TransactionCategories.Commands.AddTransactionCategory;
using BudgetPlan.Application.TransactionCategories.Queries.GetListTransactionCategories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlan.Api.Controllers;

[AllowAnonymous]
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
    public async Task<IActionResult> AddTransactionCategory(AddTransactionCategoryCommand command)
    {
        var response = await Mediator.Send(command);
        return Ok(response);
    }
}