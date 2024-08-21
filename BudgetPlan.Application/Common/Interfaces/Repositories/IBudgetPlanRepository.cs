using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Application.Common.Interfaces.Repositories;

public interface IBudgetPlanRepository
{
	Task<BudgetPlanEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
	Task<List<BudgetPlanEntity>> GetBudgetPlansForCurrentUserAsync(CancellationToken cancellationToken = default);
	Task<BudgetPlanEntity> Create(string name, CancellationToken cancellationToken = default);
	Task UpdateAsync(BudgetPlanEntity budgetPlan, CancellationToken cancellationToken = default);
	Task<BudgetPlanEntity> GetBudgetPlanBaseWithDetailsByIdAsync(Guid budgetPlanId, Guid? budgetPlanBaseId, CancellationToken cancellationToken = default);
}