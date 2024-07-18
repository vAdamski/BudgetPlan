using BudgetPlan.Application.Common.Interfaces;
using Moq;

namespace BudgetPlan.Tests.Common.MockFactories;

public static class CurrentUserServiceMockFactory
{
	public static Mock<ICurrentUserService> Create()
	{
		var currentUserServiceMock = new Mock<ICurrentUserService>();
		currentUserServiceMock.Setup(m => m.Email).Returns("user@test.com");
		currentUserServiceMock.Setup(m => m.Name).Returns("testUser");
		currentUserServiceMock.Setup(m => m.FirstName).Returns("Test");
		currentUserServiceMock.Setup(m => m.LastName).Returns("User");
		currentUserServiceMock.Setup(m => m.FullName).Returns("Test User");
		currentUserServiceMock.Setup(m => m.IsAuthenticated).Returns(true);

		return currentUserServiceMock;
	}
}