using BudgetPlan.Shared.ViewModels;

namespace BudgetPlan.Application.Common.Interfaces.Services;

public interface IIncomesExpenseDataSummaryCollector
{
	Task<PieChartDataDoubleViewModel> GetIncomeSummary(Guid budgetPlanId, Guid? budgetPlanBaseId,
		bool percents, CancellationToken cancellationToken = default);
	Task<PieChartDataDoubleViewModel> GetExpensesSummary(Guid budgetPlanId, Guid? budgetPlanBaseId,
		bool percents, CancellationToken cancellationToken = default);
}