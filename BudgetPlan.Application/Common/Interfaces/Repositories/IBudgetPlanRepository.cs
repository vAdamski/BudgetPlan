namespace BudgetPlan.Application.Common.Interfaces.Repositories;

public interface IBudgetPlanRepository
{
    Task<List<Domain.Entities.BudgetPlan>> GetBudgetPlansForCurrentUser();
}