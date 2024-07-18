using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Application.Managers;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Shared.ViewModels;
using Moq;

namespace BudgetPlan.Tests.UnitTests.Application.Managers;

public class BudgetPlanManagerTests
{
	private readonly Mock<IBudgetPlanRepository> _mockBudgetPlanRepository;
	private readonly BudgetPlanManager _budgetPlanManager;

	public BudgetPlanManagerTests()
	{
		_mockBudgetPlanRepository = new Mock<IBudgetPlanRepository>();
		_budgetPlanManager = new BudgetPlanManager(_mockBudgetPlanRepository.Object);
	}

	[Fact]
	public async Task GetBudgetPlanListViewModelAsync_ShouldReturnBudgetPlanListViewModel()
	{
		// Arrange
		_mockBudgetPlanRepository.Setup(budgetRepo =>
			budgetRepo.GetBudgetPlansAsync(It.IsAny<CancellationToken>())).ReturnsAsync(new List<BudgetPlanEntity>()
		{
			BudgetPlanEntity.Create("Test", "test@test.com")
		});

		// Act
		var result = await _budgetPlanManager.GetBudgetPlanListViewModelAsync(CancellationToken.None);

		// Assert
		result.ShouldBeOfType<BudgetPlanListViewModel>();
		result.BudgetPlanDtos.Count.ShouldBe(1);
		result.BudgetPlanDtos.First().Name.ShouldBe("Test");
	}
}