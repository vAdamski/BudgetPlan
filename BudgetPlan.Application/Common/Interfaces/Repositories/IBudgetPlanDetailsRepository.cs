namespace BudgetPlan.Application.Common.Interfaces.Repositories;

public interface IBudgetPlanDetailsRepository
{
    Task UpdateBudgetPlanDetail(Guid id, double expectedAmount);
}