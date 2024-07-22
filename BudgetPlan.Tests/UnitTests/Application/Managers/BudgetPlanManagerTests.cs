using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Application.Managers;
using BudgetPlan.Domain.Entities;
using Moq;

namespace BudgetPlan.Tests.UnitTests.Application.Managers;

public class BudgetPlanManagerTest
{
	[Fact]
	public async Task GetBudgetPlanListViewModelAsync_ShouldReturnBudgetPlanListViewModel()
	{
		// Arrange
		var mockBudgetPlanRepository = new Mock<IBudgetPlanRepository>();
		mockBudgetPlanRepository.Setup(x => x.GetBudgetPlansForCurrentUserAsync(CancellationToken.None)).ReturnsAsync(new List<BudgetPlanEntity>());
		
		var budgetPlanManager = new BudgetPlanManager(mockBudgetPlanRepository.Object);
		
		// Act
		await budgetPlanManager.GetBudgetPlanListViewModelAsync(CancellationToken.None);
		
		// Assert
		mockBudgetPlanRepository.Verify(x => x.GetBudgetPlansForCurrentUserAsync(CancellationToken.None), Times.Once);
	}
}