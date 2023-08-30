using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Persistence;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace ApplicationUnitTests.Common;

public static class BudgetPlanDbContextFactory
{
    public static Mock<BudgetPlanDbContext> Create()
    {
        var dateTime =  new DateTime(2000,1, 1);
        var dateTimeMock = new Mock<IDateTime>();
        dateTimeMock.Setup(m => m.Now).Returns(dateTime);

        var currentUserServiceMock = CurrentUserServiceFactory.Create();
        
        var options = new DbContextOptionsBuilder<BudgetPlanDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        
        var mock = new Mock<BudgetPlanDbContext>(options, dateTimeMock.Object, currentUserServiceMock.Object)
        {
            CallBase = true
        };
        
        var context = mock.Object;

        context.Database.EnsureCreated();
        
        BudgetPlanDbContextSeedData.Seed(context);

        return mock;
    }
    
    public static void Destroy(BudgetPlanDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}