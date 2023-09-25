using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Application.Common.Interfaces.Repositories;

public interface IBudgetPlanBaseRepository
{
    Task<List<BudgetPlanBase>>  GetBudgetPlansForCurrentUser(CancellationToken cancellationToken = default);
    Task<BudgetPlanBase> GetById(Guid id, CancellationToken cancellationToken = default);
    Task<List<BudgetPlanBase>> GetActiveBudgetPlansBasesForCurrentUser(CancellationToken cancellationToken = default);
    Task DeleteAsync(BudgetPlanBase budgetPlanBase, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}