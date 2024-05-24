using BudgetPlan.Shared.ViewModels;

namespace BudgetPlan.Application.Common.Interfaces.Managers;

public interface IBudgetPlanManager
{
	Task<BudgetPlanListViewModel> GetBudgetPlanListViewModel(CancellationToken cancellationToken = default);
}