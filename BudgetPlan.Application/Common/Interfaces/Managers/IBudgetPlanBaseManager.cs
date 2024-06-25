using BudgetPlan.Shared.ViewModels;

namespace BudgetPlan.Application.Common.Interfaces.Managers;

public interface IBudgetPlanBaseManager
{
	Task<BudgetPlanBaseViewModel> BuildDetailedViewModel(Guid budgetPlanBaseId,
		CancellationToken cancellationToken = default);

	Task<BudgetPlanBasesListViewModel> GetBudgetPlanBasesForBudgetPlanAsync(Guid requestBudgetPlanId, CancellationToken cancellationToken = default);
}