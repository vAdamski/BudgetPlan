using BudgetPlan.Common.Extension;

namespace BudgetPlan.Tests.UnitTests.Common.Extension;

public class DateOnlyExtensionTests
{
	[Fact]
	public void ToDateTime_ShouldConvertToDateCorrectly()
	{
		// Arrange
		var dateOnly = new DateOnly(2024, 12, 31);

		// Act
		var result = dateOnly.ToDateTime();

		// Assert
		result.ShouldBe(new DateTime(2024, 12, 31, 0, 0, 0));
	}
}