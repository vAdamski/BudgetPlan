using BudgetPlan.Application.Common.Interfaces.Managers;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Shared.ViewModels;

namespace BudgetPlan.Application.Managers;

public class DataAccessManager(IBudgetPlanRepository budgetPlanRepository) : IDataAccessManager
{
	public async Task<AccessesListViewModel> GetDataAccessesList(CancellationToken cancellationToken = default)
	{
		var budgetPlans = await budgetPlanRepository.GetBudgetPlans(cancellationToken);

		AccessesListViewModel vm = new AccessesListViewModel(budgetPlans);

		return vm;
	}

	public async Task<DataAccessBudgetPlanViewModel> GetDataAccessForBudgetPlan(Guid budgetPlanId,
		CancellationToken cancellationToken = default)
	{
		var budgetPlan = await budgetPlanRepository.GetByIdAsync(budgetPlanId, cancellationToken);

		DataAccessBudgetPlanViewModel vm = new DataAccessBudgetPlanViewModel(budgetPlan);

		return vm;
	}
}