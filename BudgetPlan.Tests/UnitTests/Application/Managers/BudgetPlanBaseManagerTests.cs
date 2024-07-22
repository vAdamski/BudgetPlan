using BudgetPlan.Application.Common.Interfaces.Builders;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Application.Managers;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Shared.ViewModels;
using Moq;

namespace BudgetPlan.Tests.UnitTests.Application.Managers;

public class BudgetPlanBaseManagerTests
{
	[Fact]
	public async Task BuildDetailedViewModel_PassedValidGuid_ShouldReturnBudgetPlanBaseViewModel()
	{
		// Arrange
		var mockBudgetPlanBaseViewModelBuilder = new Mock<IBudgetPlanBaseViewModelBuilder>();
		mockBudgetPlanBaseViewModelBuilder.Setup(x => x.Create(It.IsAny<Guid>(), CancellationToken.None)).ReturnsAsync(new BudgetPlanBaseViewModel());
		
		var mockBudgetPlanBaseRepository = new Mock<IBudgetPlanBaseRepository>();
		
		var budgetPlanBaseManager = new BudgetPlanBaseManager(mockBudgetPlanBaseViewModelBuilder.Object, mockBudgetPlanBaseRepository.Object);
		
		// Act
		await budgetPlanBaseManager.BuildDetailedViewModel(Guid.NewGuid(), CancellationToken.None);
		
		// Assert
		mockBudgetPlanBaseViewModelBuilder.Verify(x => x.Create(It.IsAny<Guid>(), CancellationToken.None), Times.Once);
	}
	
	[Fact]
	public async Task BuildDetailedViewModel_PassedInvalidGuid_ShouldThrowException()
	{
		// Arrange
		var mockBudgetPlanBaseViewModelBuilder = new Mock<IBudgetPlanBaseViewModelBuilder>();
		mockBudgetPlanBaseViewModelBuilder.Setup(x => x.Create(It.IsAny<Guid>(), CancellationToken.None)).ReturnsAsync(new BudgetPlanBaseViewModel());
		
		var mockBudgetPlanBaseRepository = new Mock<IBudgetPlanBaseRepository>();
		
		var budgetPlanBaseManager = new BudgetPlanBaseManager(mockBudgetPlanBaseViewModelBuilder.Object, mockBudgetPlanBaseRepository.Object);
		
		// Act
		Func<Task> act = async () => await budgetPlanBaseManager.BuildDetailedViewModel(Guid.Empty, CancellationToken.None);
		
		// Assert
		await Assert.ThrowsAsync<ArgumentException>(act);
	}
	
	[Fact]
	public async Task GetBudgetPlanBasesForBudgetPlanAsync_PassedValidGuid_ShouldReturnBudgetPlanBasesListViewModel()
	{
		// Arrange
		var mockBudgetPlanBaseViewModelBuilder = new Mock<IBudgetPlanBaseViewModelBuilder>();
		
		var mockBudgetPlanBaseRepository = new Mock<IBudgetPlanBaseRepository>();
		mockBudgetPlanBaseRepository.Setup(x => x.GetBudgetPlanBasesForBudgetPlanAsync(It.IsAny<Guid>(), CancellationToken.None)).ReturnsAsync(new List<BudgetPlanBase>());
		
		var budgetPlanBaseManager = new BudgetPlanBaseManager(mockBudgetPlanBaseViewModelBuilder.Object, mockBudgetPlanBaseRepository.Object);
		
		// Act
		await budgetPlanBaseManager.GetBudgetPlanBasesForBudgetPlanAsync(Guid.NewGuid(), CancellationToken.None);
		
		// Assert
		mockBudgetPlanBaseRepository.Verify(x => x.GetBudgetPlanBasesForBudgetPlanAsync(It.IsAny<Guid>(), CancellationToken.None), Times.Once);
	}
	
	[Fact]
	public async Task GetBudgetPlanBasesForBudgetPlanAsync_PassedInvalidGuid_ShouldThrowException()
	{
		// Arrange
		var mockBudgetPlanBaseViewModelBuilder = new Mock<IBudgetPlanBaseViewModelBuilder>();
		
		var mockBudgetPlanBaseRepository = new Mock<IBudgetPlanBaseRepository>();
		mockBudgetPlanBaseRepository.Setup(x => x.GetBudgetPlanBasesForBudgetPlanAsync(It.IsAny<Guid>(), CancellationToken.None)).ReturnsAsync(new List<BudgetPlanBase>());
		
		var budgetPlanBaseManager = new BudgetPlanBaseManager(mockBudgetPlanBaseViewModelBuilder.Object, mockBudgetPlanBaseRepository.Object);
		
		// Act
		Func<Task> act = async () => await budgetPlanBaseManager.GetBudgetPlanBasesForBudgetPlanAsync(Guid.Empty, CancellationToken.None);
		
		// Assert
		await Assert.ThrowsAsync<ArgumentException>(act);
	}
}