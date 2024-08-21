using BudgetPlan.Shared.ViewModels;
using MediatR;

namespace BudgetPlan.Application.Actions.DataSummaryActions.Queries.IncomeSummary;

public class GetIncomeSummaryQuery(Guid budgetPlanId, Guid? budgetPlanBaseId = null, bool percent = false)
	: IRequest<PieChartDataDoubleViewModel>
{
	public Guid BudgetPlanId { get; } = budgetPlanId;
	public Guid? BudgetPlanBaseId { get; } = budgetPlanBaseId;
	public bool Percent { get; } = percent;
}