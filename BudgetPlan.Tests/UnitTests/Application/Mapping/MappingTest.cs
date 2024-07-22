using AutoMapper;

namespace BudgetPlan.Tests.UnitTests.Application.Mapping;

public class MappingTest : IClassFixture<MappingTestFixture>
{
	private readonly IConfigurationProvider _configuration;
	private readonly IMapper _mapper;

	public MappingTest(MappingTestFixture fixture)
	{
		_configuration = fixture.ConfigurationProvider;
		_mapper = fixture.Mapper;
	}

	[Fact]
	public void ShouldHaveValidConfiguration()
	{
		_configuration.AssertConfigurationIsValid();
	}
}