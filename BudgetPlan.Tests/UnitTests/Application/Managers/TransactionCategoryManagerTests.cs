using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Application.Managers;
using BudgetPlan.Domain.Entities;
using BudgetPlan.Domain.Enums;
using Moq;

namespace BudgetPlan.Tests.UnitTests.Application.Managers;

public class TransactionCategoryManagerTests
{
	[Fact]
	public async Task AddOverTransactionCategoryAsync_GivenValidInputs_ShouldReturnTransactionCategoryId()
	{
		Mock<IBudgetPlanRepository> mockBudgetPlanRepository = new();
		Mock<ITransactionCategoriesRepository> mockTransactionCategoriesRepository = new();

		var budgetPlan = BudgetPlanEntity.Create("Test", "user@test.com");
		budgetPlan.Id = Guid.NewGuid();
		
		mockBudgetPlanRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
			.ReturnsAsync(budgetPlan);
		
		var manager = new TransactionCategoryManager(
			mockTransactionCategoriesRepository.Object,
			mockBudgetPlanRepository.Object);
		
		var result = await manager.AddOverTransactionCategoryAsync(
			Guid.NewGuid(), "TestCategory", TransactionType.Income);

		// Assert
		mockBudgetPlanRepository.Verify(x => x.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), Times.Once);
		mockTransactionCategoriesRepository.Verify(x => x.UpdateAsync(It.IsAny<TransactionCategory>(), It.IsAny<CancellationToken>()), Times.Once);
		result.ShouldNotBe(Guid.Empty);
	}
}