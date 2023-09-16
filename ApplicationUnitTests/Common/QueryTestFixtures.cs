using AutoMapper;
using BudgetPlan.Application.Common.AutoMapper;
using BudgetPlan.Application.Common.Interfaces;
using BudgetPlan.Persistence;
using Xunit;

namespace ApplicationUnitTests.Common;

public class QueryTestFixtures : IDisposable
{
    public ICurrentUserService CurrentUserService { get; private set; }
    public BudgetPlanDbContext Context { get; private set; }
    public IMapper Mapper { get; private set; }

    public QueryTestFixtures()
    {
        CurrentUserService = CurrentUserServiceFactory.Create().Object;
        Context = BudgetPlanDbContextFactory.Create().Object;
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        
        Mapper = configurationProvider.CreateMapper();
    }
    
    public void Dispose()
    {
        BudgetPlanDbContextFactory.Destroy(Context);
    }
}

[CollectionDefinition("QueryCollection")]
public class QueryCollection : ICollectionFixture<QueryTestFixtures>
{
}