using Microsoft.EntityFrameworkCore;

namespace BudgetPlan.Persistence;

public class BudgetPlanDbContextFactory : DesignTimeDbContextFactoryBase<BudgetPlanDbContext>
{
    protected override BudgetPlanDbContext CreateNewInstance(DbContextOptions<BudgetPlanDbContext> options)
    {
        return new BudgetPlanDbContext(options);
    }
}