using BudgetPlan.Application.Actions.TransactionCategoriesActions.Commands.AddOverTransactionCategory;
using BudgetPlan.Application.Actions.TransactionCategoriesActions.Commands.AddTransactionCategory;
using BudgetPlan.Application.Actions.TransactionCategoriesActions.Commands.DeleteTransactionCategory;
using BudgetPlan.Application.Actions.TransactionCategoriesActions.Queries.GetBudgetPlanSubTransactionCategories;
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
	
	[HttpGet]
	[Route("{id}/subTransactionCategories")]
	public async Task<IActionResult> GetListSubTransactionCategories(Guid id)
	{
		var response = await Mediator.Send(new GetBudgetPlanSubTransactionCategoriesQuery(id));

		return Ok(response);
	}
	

	[HttpPost]
	[Route("overTransactionCategory")]
	public async Task<IActionResult> AddOverTransactionCategory(AddOverTransactionCategoryDto dto)
	{
		var response =
			await Mediator.Send(new AddOverTransactionCategoryCommand(dto.BudgetPlanId, dto.Name, dto.TransactionType));

		return Ok(response);
	}

	[HttpPost]
	[Route("subTransactionCategory")]
	public async Task<IActionResult> AddTransactionCategory(AddTransactionCategoryDto addTransactionCategoryDto)
	{
		var response = await Mediator.Send(new AddTransactionCategoryCommand(
			addTransactionCategoryDto.OverTransactionCategoryId, addTransactionCategoryDto.CategoryName));

		return Ok(response);
	}

	[HttpDelete]
	[Route("{id}")]
	public async Task<IActionResult> DeleteTransactionCategory(Guid id, Guid? migrationId = null)
	{
		await Mediator.Send(new DeleteTransactionCategoryCommand(id, migrationId));

		return NoContent();
	}
}