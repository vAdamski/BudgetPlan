using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Application.Common.Interfaces.Repositories;

public interface IAccessedPersonsRepository
{
	Task RemoveAccessedPersonAsync(AccessedPerson accessedPerson, CancellationToken cancellationToken = default);
}