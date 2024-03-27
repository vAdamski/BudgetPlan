using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Application.Common.Interfaces.Repositories;

public interface IBudgetPlanRepository
{
    Task<BudgetPlanEntity> Create(string name, CancellationToken cancellationToken = default);
}