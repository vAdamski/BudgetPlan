namespace BudgetPlan.Application.Common.Interfaces;

public interface IBudgetPlanDbContext
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}