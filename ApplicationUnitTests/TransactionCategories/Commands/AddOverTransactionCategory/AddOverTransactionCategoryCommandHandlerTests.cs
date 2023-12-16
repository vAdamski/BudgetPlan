using ApplicationUnitTests.Common;
using BudgetPlan.Application.Actions.TransactionCategoriesActions.Commands.AddOverTransactionCategory;
using BudgetPlan.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

namespace ApplicationUnitTests.TransactionCategories.Commands.AddOverTransactionCategory;

public class AddOverTransactionCategoryCommandHandlerTests : CommandTestBase
{
    [Fact]
    public async Task Handle_CreateOverTransactionCategory_GivenValidRequest_ShouldCreateNewOverTransactionCategory()
    {
        // Arrange
        var sut = new AddOverTransactionCategoryCommandHandler(_context);
        
        var command = new AddOverTransactionCategoryCommand
        {
            TransactionCategoryName = "TEST",
            TransactionType = TransactionType.Expense
        };

        // Act
        var result = await sut.Handle(command, CancellationToken.None);

        // Assert
        var entity = await _context.TransactionCategories.FirstOrDefaultAsync(x => x.Id == result);
        
        entity.ShouldNotBeNull();
        entity.TransactionCategoryName.ShouldBe(command.TransactionCategoryName);
        entity.TransactionType.ShouldBe(command.TransactionType);
        entity.OverTransactionCategoryId.ShouldBeNull();
    }
}