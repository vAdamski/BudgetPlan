using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Application.Common.Interfaces.Repositories;

public interface IBudgetPlanRepository
{
	Task<BudgetPlanEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
	Task<List<BudgetPlanEntity>> GetBudgetPlans(CancellationToken cancellationToken = default);
	Task<BudgetPlanEntity> Create(string name, CancellationToken cancellationToken = default);
}