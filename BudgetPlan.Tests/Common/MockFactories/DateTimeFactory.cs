using BudgetPlan.Application.Common.Interfaces;
using Moq;

namespace BudgetPlan.Tests.Common.MockFactories;

public static class DateTimeFactory
{
	public static Mock<IDateTime> Create()
	{
		var dateTime = new DateTime(2024, 7, 17);

		return Create(dateTime);
	}
	
	public static Mock<IDateTime> Create(DateTime dateTime)
	{
		var dateTimeMock = new Mock<IDateTime>();
		dateTimeMock.Setup(m => m.Now).Returns(dateTime);

		return dateTimeMock;
	}
}