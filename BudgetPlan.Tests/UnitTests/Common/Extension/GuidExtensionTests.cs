using BudgetPlan.Common.Extension;

namespace BudgetPlan.Tests.UnitTests.Common.Extension;

public class GuidExtensionTests
{
	[Fact]
	public void IsNullOrEmpty_PassedNullGuid_ShouldReturnTrue()
	{
		// Arrange
		Guid? guid = null;
		
		// Act
		var result = guid.IsNullOrEmpty();
		
		// Assert
		result.ShouldBeTrue();
	}
	
	[Fact]
	public void IsNullOrEmpty_PassedEmptyGuid_ShouldReturnTrue()
	{
		// Arrange
		Guid guid = Guid.Empty;
		
		// Act
		var result = guid.IsNullOrEmpty();
		
		// Assert
		result.ShouldBeTrue();
	}
	
	[Fact]
	public void IsNullOrEmpty_PassedProperGuid_ShouldReturnFalse()
	{
		// Arrange
		Guid guid = Guid.NewGuid();
		
		// Act
		var result = guid.IsNullOrEmpty();
		
		// Assert
		result.ShouldBeFalse();
	}
}