using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Application.Common.Interfaces.Repositories;

public interface IBudgetPlanBaseRepository
{
    Task<List<BudgetPlanBase>> GetBudgetPlansForUser(string userEmail, CancellationToken cancellationToken = default);
    Task<BudgetPlanBase> GetByIdWithBudgetPlanDetailsList(Guid id, CancellationToken cancellationToken = default);
}