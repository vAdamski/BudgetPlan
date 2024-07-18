using BudgetPlan.Application.Actions.BudgetPlanActions.Queries.GetListOfBudgetPlans;
using BudgetPlan.Application.Common.Interfaces.Managers;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Shared.ViewModels;
using Moq;

namespace BudgetPlan.Tests.UnitTests.Application.Actions.BudgetPlanActions.Queries.GetListOfBudgetPlans;

public class GetListOfBudgetPlansQueryHandlerTests
{
	[Fact]
	public async Task Handle_ReturnsBudgetPlanListViewModel()
	{
		// Arrange
		var mockBudgetPlanManager = new Mock<IBudgetPlanManager>();
		var expectedViewModel = new BudgetPlanListViewModel(new List<BudgetPlanEntity>());
		mockBudgetPlanManager.Setup(m => m.GetBudgetPlanListViewModelAsync(It.IsAny<CancellationToken>()))
			.ReturnsAsync(expectedViewModel);

		var handler = new GetListOfBudgetPlansQueryHandler(mockBudgetPlanManager.Object);
		var request = new GetListOfBudgetPlansQuery();
		var cancellationToken = new CancellationToken();

		// Act
		var result = await handler.Handle(request, cancellationToken);

		// Assert
		result.ShouldBe(expectedViewModel);
	}

	[Fact]
	public async Task Handle_CallsGetBudgetPlanListViewModelAsyncOnce()
	{
		// Arrange
		var mockBudgetPlanManager = new Mock<IBudgetPlanManager>();
		mockBudgetPlanManager.Setup(m => m.GetBudgetPlanListViewModelAsync(It.IsAny<CancellationToken>()))
			.ReturnsAsync(new BudgetPlanListViewModel(new List<BudgetPlanEntity>()));

		var handler = new GetListOfBudgetPlansQueryHandler(mockBudgetPlanManager.Object);
		var request = new GetListOfBudgetPlansQuery();
		var cancellationToken = new CancellationToken();

		// Act
		await handler.Handle(request, cancellationToken);

		// Assert
		mockBudgetPlanManager.Verify(m => m.GetBudgetPlanListViewModelAsync(It.IsAny<CancellationToken>()), Times.Once);
	}
}