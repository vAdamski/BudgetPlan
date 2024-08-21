using BudgetPlan.Shared.ViewModels;
using MediatR;

namespace BudgetPlan.Application.Actions.DataSummaryActions.Queries.CategoriesPercentSummary;

public class GetCategoriesPercentSummaryQuery(Guid budgetPlanId, Guid? budgetPlanBaseId) : IRequest<PieChartDataDoubleViewModel>
{
	public Guid BudgetPlanId { get; } = budgetPlanId;
	public Guid? BudgetPlanBaseId { get; } = budgetPlanBaseId;
}