using BudgetPlan.Shared.ViewModels;

namespace BudgetPlan.Application.Common.Interfaces.Managers;

public interface IBudgetPlanManager
{
	Task<BudgetPlanListViewModel> GetBudgetPlanListViewModelAsync(CancellationToken cancellationToken = default);
}