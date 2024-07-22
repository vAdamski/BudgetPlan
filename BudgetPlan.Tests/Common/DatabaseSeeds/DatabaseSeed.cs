using BudgetPlan.Domain.Entities;
using BudgetPlan.Persistence;

namespace BudgetPlan.Tests.Common.DatabaseSeeds;

public static class DatabaseSeed
{
	public static async Task Seed(this BudgetPlanDbContext context)
	{
		List<BudgetPlanEntity> budgetPlans = new List<BudgetPlanEntity>
		{
			BudgetPlanEntity.Create("Test1", "user@test.com"),
			BudgetPlanEntity.Create("Test2", "user@test.com"),
		};
		
		context.BudgetPlanEntities.AddRange(budgetPlans);
		
		await context.SaveChangesAsync();
	}
}