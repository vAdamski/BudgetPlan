using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Application.Common.Interfaces.Repositories;

public interface IDataAccessRepository
{
	Task<DataAccess> GetById(Guid id, CancellationToken cancellationToken = default);
	Task UpdateAsync(DataAccess dataAccess, CancellationToken cancellationToken = default);
}