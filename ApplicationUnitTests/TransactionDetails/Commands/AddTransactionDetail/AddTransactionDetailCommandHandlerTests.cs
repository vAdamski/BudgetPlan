using ApplicationUnitTests.Common;
using ApplicationUnitTests.Common.Mocks;
using BudgetPlan.Application.TransactionDetails.Commands.AddTransactionDetail;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shouldly;
using Xunit;

namespace ApplicationUnitTests.TransactionDetails.Commands.AddTransactionDetail;

public class AddTransactionDetailCommandHandlerTests : CommandTestBase
{
    [Fact]
    public async Task Handle_AddTransactionDetails_GivenValidRequest_ShouldAddTransactionDetails()
    {
        // Arrange
        var command = new AddTransactionDetailCommand()
        {
            Value = 100,
            Description = "Food",
            TransactionDate = DateTime.Now,
            TransactionCategoryId = BudgetPlanDbContextSeedData.TRANSACTION_CATEGORY_4_GUID
        };
        
        var handler = new AddTransactionDetailCommandHandler(
            _context,
            _currentUserService, 
            LoggerMockFactory<AddTransactionDetailCommandHandler>.Create()
            );

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        var transactionDetails = await _context.TransactionDetails.Where(x => x.Id == result).FirstOrDefaultAsync();
        transactionDetails.ShouldNotBeNull();
        transactionDetails.Value.ShouldBe(command.Value);
        transactionDetails.Description.ShouldBe(command.Description);
        transactionDetails.TransactionDate.ShouldBe(command.TransactionDate);
        transactionDetails.TransactionCategoryId.ShouldBe(command.TransactionCategoryId);
    }
}