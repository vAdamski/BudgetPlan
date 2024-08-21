using BudgetPlan.Shared.ViewModels;

namespace BudgetPlan.Application.Common.Interfaces.Services;

public interface ITransactionCategoryDataSummaryCollector
{
	Task<PieChartDataDoubleViewModel> GetCategoriesPercentSummary(Guid budgetPlanId,
		Guid? budgetPlanBaseId, CancellationToken cancellationToken = default);
}