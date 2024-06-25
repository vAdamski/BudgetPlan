using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Application.Common.Interfaces.Repositories;

public interface IBudgetPlanBaseRepository
{
	Task<BudgetPlanBase> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
	Task<BudgetPlanBase> GetWithBudgetPlanDetailsByIdAsync(Guid id, CancellationToken cancellationToken = default);
	Task<List<BudgetPlanBase>> GetAllForUserAsync(CancellationToken cancellationToken = default);

	Task<List<BudgetPlanBase>> GetBudgetPlanBasesForBudgetPlanAsync(Guid requestBudgetPlanId,
		CancellationToken cancellationToken = default);
}