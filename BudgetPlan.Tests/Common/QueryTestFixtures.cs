using AutoMapper;
using BudgetPlan.Application.Common.Mapping;
using BudgetPlan.Persistence;
using BudgetPlan.Tests.Common.MockFactories;

namespace BudgetPlan.Tests.Common;

public class QueryTestFixtures : IDisposable
{
	public BudgetPlanDbContext Context { get; private set; }
	public IMapper Mapper { get; private set; }

	public QueryTestFixtures()
	{
		Context = BudgetPlanDbContextMockFactory.Create().Object;
		
		var configurationProvider = new MapperConfiguration(cfg =>
		{
			cfg.AddProfile<MappingProfile>();
		});
	}
	
	public void Dispose()
	{
		BudgetPlanDbContextMockFactory.Destroy(Context);
	}
}

[CollectionDefinition("QueryCollection")]
public class QueryCollection : ICollectionFixture<QueryTestFixtures>
{
	
}