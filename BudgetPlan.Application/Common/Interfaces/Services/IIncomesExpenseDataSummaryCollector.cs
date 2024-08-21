using BudgetPlan.Shared.ViewModels;

namespace BudgetPlan.Application.Common.Interfaces.Services;

public interface IIncomesExpenseDataSummaryCollector
{
	Task<PieChartDataDoubleViewModel> GetExpensesSummary(Guid budgetPlanId, Guid? budgetPlanBaseId,
		bool percents, CancellationToken cancellationToken = default);
}