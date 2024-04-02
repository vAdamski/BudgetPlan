using BudgetPlan.Application.Actions.TransactionCategoriesActions.Commands.AddOverTransactionCategory;
using BudgetPlan.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlan.Api.Controllers;

[Route("api/[controller]")]
public class TransactionCategoryController : BaseController
{
    [HttpGet]
    [Route("list")]
    public async Task<IActionResult> GetListTransactionCategories()
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    [Route("createOverCategory")]
    public async Task<IActionResult> AddOverTransactionCategory([FromForm] AddOverTransactionCategoryDto dto)
    {
        var response = await Mediator.Send(new AddOverTransactionCategoryCommand(dto.BudgetPlanId, dto.Name, dto.TransactionType));
        
        return Ok(response);
    }
    
    [HttpPost]
    [Route("createCategory")]
    public async Task<IActionResult> AddTransactionCategory()
    {
        throw new NotImplementedException();
    }
    
    [HttpDelete]
    [Route("delete/utc/{id}")]
    public async Task<IActionResult> DeleteTransactionCategory(Guid id)
    {
        throw new NotImplementedException();
    }
    
    [HttpDelete]
    [Route("delete/utc/{id}/{migrationId}")]
    public async Task<IActionResult> DeleteTransactionCategory(Guid id, Guid migrationId)
    {
        throw new NotImplementedException();
    }
}