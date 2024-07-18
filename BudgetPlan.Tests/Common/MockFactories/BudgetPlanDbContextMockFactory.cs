using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Persistence;
using BudgetPlan.Tests.Common.DatabaseSeeds;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace BudgetPlan.Tests.Common.MockFactories;

public static class BudgetPlanDbContextMockFactory
{
	public static Mock<BudgetPlanDbContext> Create()
	{
		var dateTimeMock = DateTimeFactory.Create(new DateTime(2024, 7, 17));
		
		var currentUserServiceMock = CurrentUserServiceMockFactory.Create();

		var options = new DbContextOptionsBuilder<BudgetPlanDbContext>()
			.UseInMemoryDatabase(Guid.NewGuid().ToString())
			.Options;
		
		var mock = new Mock<BudgetPlanDbContext>(options, dateTimeMock.Object, currentUserServiceMock.Object)
		{
			CallBase = true
		};
		
		var context = mock.Object;
		
		context.Database.EnsureCreated();

		context.Seed().Wait();

		return mock;
	}
	
	public static void Destroy(BudgetPlanDbContext context)
	{
		context.Database.EnsureDeleted();
		context.Dispose();
	}
}