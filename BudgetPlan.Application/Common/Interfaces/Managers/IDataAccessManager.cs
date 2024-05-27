using BudgetPlan.Shared.ViewModels;

namespace BudgetPlan.Application.Common.Interfaces.Managers;

public interface IDataAccessManager
{
	Task<AccessesListViewModel> GetAccessesList(CancellationToken cancellationToken = default);
}