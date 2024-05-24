using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Application.Common.Interfaces.Repositories;

public interface IBudgetPlanBaseRepository
{
	Task<List<BudgetPlanBase>> GetAllForUserAsync(CancellationToken cancellationToken = default);
}