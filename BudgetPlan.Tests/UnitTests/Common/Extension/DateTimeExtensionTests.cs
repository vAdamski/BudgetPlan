using BudgetPlan.Common.Extension;

namespace BudgetPlan.Tests.UnitTests.Common.Extension;

public class DateTimeExtensionTests
{
	[Fact]
	public void ToDateOnly_WhenCalled_ReturnsCorrectDateOnly()
	{
		// Arrange
		DateTime dateTime = new DateTime(2022, 12, 31);
        
		// Act
		DateOnly dateOnly = dateTime.ToDateOnly();

		// Assert
		dateOnly.Year.ShouldBe(dateTime.Year);
		dateOnly.Month.ShouldBe(dateTime.Month);
		dateOnly.Day.ShouldBe(dateTime.Day);
	}
}