using ApplicationUnitTests.Common;
using ApplicationUnitTests.Common.Mocks;
using BudgetPlan.Application.Actions.TransactionCategoriesActions.Commands.AddTransactionCategory;
using BudgetPlan.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

namespace ApplicationUnitTests.TransactionCategories.Commands.AddTransactionCategory;

public class AddTransactionCategoryCommandHandlerTests : CommandTestBase
{
    [Fact]
    public async Task Handle_CreateTransactionCategory_GivenValidRequest_ShouldCreateNewTransactionCategory()
    {
        // Arrange
        var sut = new AddTransactionCategoryCommandHandler(_context, _currentUserService);
        
        var command = new AddTransactionCategoryCommand
        {
            TransactionCategoryName = "TEST",
            OverTransactionCategoryId = BudgetPlanDbContextSeedData.TRANSACTION_CATEGORY_3_GUID,
        };

        // Act
        var result = await sut.Handle(command, CancellationToken.None);

        // Assert
        var entity = await _context.TransactionCategories.FirstOrDefaultAsync(x => x.Id == result);
        var overTransactionCategory = await _context.TransactionCategories.FirstOrDefaultAsync(x => x.Id == command.OverTransactionCategoryId);
        
        entity.ShouldNotBeNull();
        entity.TransactionCategoryName.ShouldBe(command.TransactionCategoryName);
        entity.OverTransactionCategoryId.ShouldBe(command.OverTransactionCategoryId);
        entity.TransactionType.ShouldBe(overTransactionCategory.TransactionType);
    }
    
    [Fact]
    public async Task Handle_CreateTransactionCategory_GivenValidRequest_ShouldAddNewCategoryToAllBudgetPlans()
    {
        // Arrange
        var sut = new AddTransactionCategoryCommandHandler(_context, _currentUserService);
        
        var command = new AddTransactionCategoryCommand
        {
            TransactionCategoryName = "TEST",
            OverTransactionCategoryId = BudgetPlanDbContextSeedData.TRANSACTION_CATEGORY_3_GUID,
        };

        // Act
        var result = await sut.Handle(command, CancellationToken.None);

        // Assert
        var budgetPlans = await _context.BudgetPlanBases
            .Where(x => x.CreatedBy == _currentUserService.Email)
            .Include(x => x.BudgetPlanDetailsList)
            .ToListAsync();

        foreach (var budgetPlan in budgetPlans)
        {
            budgetPlan.BudgetPlanDetailsList.ShouldContain(x => x.TransactionCategoryId == result);
        }
    }

    [Fact]
    public async Task Handle_CreateTransactionCategory_GivenInvalidRequest_ShouldThrowOverTransactionCategoryNotFoundException()
    {
        // Arrange
        var handler = new AddTransactionCategoryCommandHandler(_context, _currentUserService);
        
        var command = new AddTransactionCategoryCommand
        {
            TransactionCategoryName = "TEST",
            OverTransactionCategoryId = new Guid()
        };

        // Act
        await Should.ThrowAsync<OverTransactionCategoryNotFoundException>(handler.Handle(command, CancellationToken.None));
    }
}