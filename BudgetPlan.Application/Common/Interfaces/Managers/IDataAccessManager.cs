using BudgetPlan.Shared.ViewModels;

namespace BudgetPlan.Application.Common.Interfaces.Managers;

public interface IDataAccessManager
{
	Task<AccessesListViewModel> GetDataAccessesListForCurrentUserAsync(CancellationToken cancellationToken = default);

	Task<DataAccessBudgetPlanViewModel> GetDataAccessForBudgetPlan(Guid budgetPlanId,
		CancellationToken cancellationToken = default);

	Task UpdateDataAccess(Guid requestId, UpdateDataAccessViewModel requestViewModel,
		CancellationToken cancellationToken = default);

	Task AddUserToAccess(Guid dataAccessId, string email, CancellationToken cancellationToken = default);
	
	Task RemoveUserFromAccess(Guid dataAccessId, string email, CancellationToken cancellationToken = default);
}