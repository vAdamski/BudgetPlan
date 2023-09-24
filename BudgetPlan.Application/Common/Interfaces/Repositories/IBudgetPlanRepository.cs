using BudgetPlan.Domain.Entities;

namespace BudgetPlan.Application.Common.Interfaces.Repositories;

public interface IBudgetPlanRepository
{
    Task<List<BudgetPlanBase>> GetBudgetPlansForCurrentUser();
}