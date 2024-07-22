using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Application.Managers;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Domain.Enums;
using BudgetPlan.Domain.Exceptions;
using Moq;

namespace BudgetPlan.Tests.UnitTests.Application.Managers;

public class BudgetPlanDetailsManagerTests
{
	[Fact]
	public async Task Update_PassedProperValues_ShouldUpdateExpectedAmount()
	{
		// Arrange
		var id = Guid.NewGuid();
		var expectedAmount = 1000;
		var cancellationToken = new CancellationToken();
		var budgetPlanDetails =
			new BudgetPlanDetails(10, BudgetPlanType.Monthly, Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());
		var budgetPlanDetailsRepositoryMock = new Mock<IBudgetPlanDetailsRepository>();
		budgetPlanDetailsRepositoryMock.Setup(x => x.GetByIdAsync(id, cancellationToken))
			.ReturnsAsync(budgetPlanDetails);
		var budgetPlanDetailsManager = new BudgetPlanDetailsManager(budgetPlanDetailsRepositoryMock.Object);

		// Act
		await budgetPlanDetailsManager.Update(id, expectedAmount, cancellationToken);

		// Assert
		budgetPlanDetailsRepositoryMock.Verify(x => x.UpdateAsync(budgetPlanDetails, cancellationToken), Times.Once);
		Assert.Equal(expectedAmount, budgetPlanDetails.ExpectedAmount);
	}

	[Fact]
	public async Task Update_PassedEmptyId_ShouldThrowArgumentNullException()
	{
		// Arrange
		var expectedAmount = 1000;
		var cancellationToken = new CancellationToken();
		var budgetPlanDetailsRepositoryMock = new Mock<IBudgetPlanDetailsRepository>();
		var budgetPlanDetailsManager = new BudgetPlanDetailsManager(budgetPlanDetailsRepositoryMock.Object);

		// Act & Assert

		await Should.ThrowAsync<ArgumentNullException>(async () =>
			await budgetPlanDetailsManager.Update(Guid.Empty, expectedAmount, cancellationToken));
	}
}