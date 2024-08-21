using BudgetPlan.Application.Actions.DataSummaryActions.Queries.CategoriesPercentSummary;
using BudgetPlan.Application.Actions.DataSummaryActions.Queries.ExpenseSummary;
using BudgetPlan.Application.Actions.DataSummaryActions.Queries.IncomeExpenseSummary;
using BudgetPlan.Application.Actions.DataSummaryActions.Queries.IncomeSummary;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlan.Api.Controllers;

[Route("api/[controller]")]
public class DataSummaryController : BaseController
{
	[HttpGet("{budgetPlanId}/categoryPercentSummary")]
	public async Task<IActionResult> GetCategoryPercentSummary(Guid budgetPlanId, Guid? budgetPlanBaseId = null)
	{
		var response = await Mediator.Send(new GetCategoriesPercentSummaryQuery(budgetPlanId, budgetPlanBaseId));

		return Ok(response);
	}
	
	[HttpGet("{budgetPlanId}/incomeSummary")]
	public async Task<IActionResult> GetIncomeSummary(Guid budgetPlanId, Guid? budgetPlanBaseId = null, bool percent = false)
	{
		var response = await Mediator.Send(new GetIncomeSummaryQuery(budgetPlanId, budgetPlanBaseId, percent));

		return Ok(response);
	}
	
	[HttpGet("{budgetPlanId}/expenseSummary")]
	public async Task<IActionResult> GetExpenseSummary(Guid budgetPlanId, Guid? budgetPlanBaseId = null, bool percent = false)
	{
		var response = await Mediator.Send(new GetExpenseSummaryQuery(budgetPlanId, budgetPlanBaseId, percent));

		return Ok(response);
	}
	
	[HttpGet("{budgetPlanId}/incomeExpenseSummary")]
	public async Task<IActionResult> GetIncomeExpenseSummary(Guid budgetPlanId, Guid? budgetPlanBaseId = null)
	{
		var response = await Mediator.Send(new GetIncomeExpenseSummaryQuery(budgetPlanId, budgetPlanBaseId));

		return Ok(response);
	}
}