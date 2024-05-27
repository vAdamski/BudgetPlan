using BudgetPlan.Shared.ViewModels;

namespace BudgetPlan.Application.Common.Interfaces.Managers;

public interface IDataAccessManager
{
	Task<AccessesListViewModel> GetDataAccessesList(CancellationToken cancellationToken = default);

	Task<DataAccessBudgetPlanViewModel> GetDataAccessForBudgetPlan(Guid budgetPlanId,
		CancellationToken cancellationToken = default);
}