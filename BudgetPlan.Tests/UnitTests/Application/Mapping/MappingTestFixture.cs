using AutoMapper;
using BudgetPlan.Application.Common.Mapping;

namespace BudgetPlan.Tests.UnitTests.Application.Mapping;

public class MappingTestFixture
{
	public MappingTestFixture()
	{
		ConfigurationProvider = new MapperConfiguration(cfg =>
		{
			cfg.AddProfile<MappingProfile>();
		});
		Mapper = ConfigurationProvider.CreateMapper();
	}
	
	public IConfigurationProvider ConfigurationProvider { get; set; }
	public IMapper Mapper { get; set; }
}