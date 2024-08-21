using BudgetPlan.Shared.ViewModels;
using MediatR;

namespace BudgetPlan.Application.Actions.DataSummaryActions.Queries.IncomeExpenseSummary;

public class GetIncomeExpenseSummaryQuery(Guid budgetPlanId, Guid? budgetPlanBaseId = null) : IRequest<double>
{
	public Guid BudgetPlanId { get; } = budgetPlanId;
	public Guid? BudgetPlanBaseId { get; } = budgetPlanBaseId;
}