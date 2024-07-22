using BudgetPlan.Common.Validators;

namespace BudgetPlan.Tests.UnitTests.Common.Extension;

public class EmailValidatorTests
{
	[Theory]
	[InlineData("egebege", false)]
	[InlineData("egebege@", false)]
	[InlineData("egebege@.com", false)]
	[InlineData("egebege.com", false)]
	[InlineData("", false)]
	[InlineData("test@test.com", true)]
	[InlineData("test@test.pl", true)]
	public void IsValid_GivenInvalidEmail_ShouldReturnFalse(string email, bool expected)
	{
		// Arrange & Act
		var result = EmailValidator.IsValid(email);
		// Assert
		result.ShouldBe(expected);
	}
}