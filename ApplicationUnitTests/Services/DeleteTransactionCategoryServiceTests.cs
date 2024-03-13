using ApplicationUnitTests.Common;
using BudgetPlan.Application.Common.Interfaces.Repositories;
using BudgetPlan.Application.Common.Interfaces.Services;
using BudgetPlan.Application.Services.DeleteTransactionCategory;
using BudgetPlan.Domain.Exceptions;
using BudgetPlan.Persistence.Respositories;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

namespace ApplicationUnitTests.Services;

public class DeleteTransactionCategoryServiceTests : CommandTestBase
{
    private readonly IDeleteTransactionCategoryService _deleteTransactionCategoryService;

    public DeleteTransactionCategoryServiceTests()
    {
        ITransactionCategoriesRepository transactionCategoriesRepository =
            new TransactionCategoriesRepository(
                _context,
                _currentUserService);

        ITransactionDetailsRepository transactionDetailsRepository =
            new TransactionDetailsRepository(
                _context);

        _deleteTransactionCategoryService =
            new DeleteTransactionCategoryService(
                transactionCategoriesRepository,
                transactionDetailsRepository,
                _currentUserService);
    }

    [Fact]
    public async Task DeleteTransactionCategory_GivenValidParams_ShouldDeleteCategoryWithDetails()
    {
        // Arrange
        Guid transactionCategoryId = BudgetPlanDbContextSeedData.TRANSACTION_CATEGORY_4_GUID;

        // Act
        await _deleteTransactionCategoryService.DeleteTransactionCategory(transactionCategoryId);

        // Assert
        var category = await _context.TransactionCategories.FirstOrDefaultAsync(x => x.Id == transactionCategoryId);

        category.ShouldNotBeNull();
        category.StatusId.ShouldBe(0);

        _context.TransactionDetails.Where(x => x.TransactionCategoryId == transactionCategoryId).ToList().ForEach(x =>
        {
            x.StatusId.ShouldBe(0);
        });
    }

    [Fact]
    public async Task
        DeleteTransactionCategoryWithMigrationItems_GivenValidParams_ShouldDeleteCategoryAndMigrateDetails()
    {
        // Arrange
        Guid transactionCategoryToDeleteId = BudgetPlanDbContextSeedData.TRANSACTION_CATEGORY_7_GUID;
        Guid transactionCategoryToMigrateId = BudgetPlanDbContextSeedData.TRANSACTION_CATEGORY_4_GUID;

        // Act
        await _deleteTransactionCategoryService.DeleteTransactionCategoryWithMigrationItems(
            transactionCategoryToDeleteId, transactionCategoryToMigrateId);

        // Assert
        var category =
            await _context.TransactionCategories.FirstOrDefaultAsync(x => x.Id == transactionCategoryToDeleteId);

        category.ShouldNotBeNull();
        category.StatusId.ShouldBe(0);

        var transactionDetails = await _context.TransactionDetails
            .Where(x => x.TransactionCategoryId == transactionCategoryToMigrateId).ToListAsync();

        transactionDetails.Count.ShouldBe(3);

        transactionDetails.ForEach(x =>
        {
            x.TransactionCategoryId.ShouldBe(transactionCategoryToMigrateId);
            x.StatusId.ShouldBe(1);
        });
    }

    [Fact]
    public async Task
        DeleteTransactionCategoryWithMigrationItems_GivenUnderTransactionWhichOneIsToDelete_ShouldThrowException()
    {
        // Arrange
        Guid transactionCategoryToDeleteId = BudgetPlanDbContextSeedData.TRANSACTION_CATEGORY_3_GUID;
        Guid transactionCategoryToMigrateId = BudgetPlanDbContextSeedData.TRANSACTION_CATEGORY_4_GUID;

        // Act & Assert
        var result = await Should.ThrowAsync<TransactionCategoryMigrateToCannotBeUnderTransactionCategoryToDeleteException>(() =>
            _deleteTransactionCategoryService.DeleteTransactionCategoryWithMigrationItems(
                transactionCategoryToDeleteId, transactionCategoryToMigrateId));
        
        result.ShouldNotBeNull();
        result.Message.ShouldBe("Destination transaction category cannot be under the transaction category to delete.");
    }
}