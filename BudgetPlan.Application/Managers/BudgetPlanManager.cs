using BudgetPlan.Application.Common.Interfaces.Managers;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Shared.ViewModels;

namespace BudgetPlan.Application.Managers;

public class BudgetPlanManager(IBudgetPlanRepository budgetPlanRepository) : IBudgetPlanManager
{
	public async Task<BudgetPlanListViewModel> GetBudgetPlanListViewModelAsync(CancellationToken cancellationToken = default)
	{
		var budgetPlans = await budgetPlanRepository.GetBudgetPlansForCurrentUserAsync(cancellationToken);

		return new BudgetPlanListViewModel(budgetPlans);
	}
}