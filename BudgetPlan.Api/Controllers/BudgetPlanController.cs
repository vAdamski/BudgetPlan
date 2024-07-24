using BudgetPlan.Application.Actions.BudgetPlanActions.Commands.CreateBudgetPlan;
using BudgetPlan.Application.Actions.BudgetPlanActions.Queries.GetListOfBudgetPlans;
using BudgetPlan.Application.Actions.BudgetPlanBaseActions.Queries.GetBudgetPlanBasesForBudgetPlan;
using BudgetPlan.Application.Actions.DataAccessActions.Queries.GetDataAccessForBudgetPlan;
using BudgetPlan.Application.Actions.TransactionCategoriesActions.Queries.GetListTransactionCategoriesForBudgetPlan;
using BudgetPlan.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlan.Api.Controllers;

[Route("api/budgetPlans")]
public class BudgetPlanController : BaseController
{
	[HttpGet]
	public async Task<IActionResult> GetBudgetPlans()
	{
		var response = await Mediator.Send(new GetListOfBudgetPlansQuery());

		return Ok(response);
	}

	[HttpGet]
	[Route("{id}/access")]
	public async Task<IActionResult> GetAccessForBudgetPlan(Guid id)
	{
		var response = await Mediator.Send(new GetDataAccessForBudgetPlanQuery(id));
		
		return Ok(response);
	}
	
	[HttpGet]
	[Route("{budgetPlanId}/transactionCategories")]
	public async Task<IActionResult> GetListTransactionCategories(Guid budgetPlanId)
	{
		var response = await Mediator.Send(new GetListTransactionCategoriesForBudgetPlanQuery(budgetPlanId));

		return Ok(response);
	}
	
	[HttpGet]
	[Route("{id}/budgetPlanBases")]
	public async Task<IActionResult> GetBudgetPlanBases(Guid id)
	{
		var response = await Mediator.Send(new GetBudgetPlanBasesForBudgetPlanQuery(id));

		return Ok(response);
	}
	
	[HttpPost]
	public async Task<IActionResult> Create(
		CreateBudgetPlanDto createBudgetPlan)
	{
		var command = new CreateBudgetPlanCommand(createBudgetPlan.Name);
		var budgetPlanId = await Mediator.Send(command);

		return Ok(budgetPlanId);
	}
}