using BudgetPlan.Application.Actions.TransactionCategoriesActions.Commands.AddOverTransactionCategory;
using BudgetPlan.Application.Actions.TransactionCategoriesActions.Commands.AddTransactionCategory;
using BudgetPlan.Application.Actions.TransactionCategoriesActions.Queries.GetListTransactionCategories;
using BudgetPlan.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlan.Api.Controllers;

[Route("api/transactionsCategories")]
public class TransactionCategoryController : BaseController
{
	[HttpGet]
	public async Task<IActionResult> GetListTransactionCategories()
	{
		var response = await Mediator.Send(new GetListTransactionCategoriesQuery());

		return Ok(response);
	}

	[HttpPost]
	[Route("overTransactionCategory")]
	public async Task<IActionResult> AddOverTransactionCategory([FromForm] AddOverTransactionCategoryDto dto)
	{
		var response =
			await Mediator.Send(new AddOverTransactionCategoryCommand(dto.BudgetPlanId, dto.Name, dto.TransactionType));

		return Ok(response);
	}

	[HttpPost]
	[Route("subTransactionCategory")]
	public async Task<IActionResult> AddTransactionCategory(
		[FromForm] AddTransactionCategoryDto addTransactionCategoryDto)
	{
		var response = await Mediator.Send(new AddTransactionCategoryCommand(
			addTransactionCategoryDto.OverTransactionCategoryId, addTransactionCategoryDto.CategoryName));

		return Ok(response);
	}

	[HttpDelete]
	[Route("{id}")]
	public async Task<IActionResult> DeleteTransactionCategory([FromQuery] Guid id, Guid? migrationId = null)
	{
		throw new NotImplementedException();
	}
}