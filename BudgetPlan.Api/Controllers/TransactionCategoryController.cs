using BudgetPlan.Application.TransactionCategories.Commands.AddTransactionCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlan.Api.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
public class TransactionCategoryController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> AddTransactionCategory(AddTransactionCategoryCommand command)
    {
        var response = await Mediator.Send(command);
        return Ok(response);
    }
}