using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Persistence.Respositories;

public class AccessedPersonsRepository(IBudgetPlanDbContext context) : IAccessedPersonsRepository
{
	public async Task RemoveAccessedPersonAsync(AccessedPerson accessedPerson, CancellationToken cancellationToken = default)
	{
		if (accessedPerson == null)
			throw new ArgumentNullException(nameof(accessedPerson), "AccessedUser cannot be null!");
		
		context.AccessedPersons.Remove(accessedPerson);

		await context.SaveChangesAsync(cancellationToken);
	}
}